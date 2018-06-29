using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Proj270618_TesteAtak_WS
{
    /// <summary>
    /// Summary description for PesquisaGoogle
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PesquisaGoogle : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public Xml EfetuaPesquisa(string valorDaPesquisa)
        {
            //obtem pesquisa do google
            //https://www.google.com/search?q=texto+pesquisa

            var url = "https://www.google.com/search?q=";
            url = string.Concat(url, valorDaPesquisa.Replace(' ', '+'));

            List<ResultadoPesquisa> lista = new List<ResultadoPesquisa>();
            var client = new HttpClient();
            var response = client.GetAsync(new Uri(url), HttpCompletionOption.ResponseContentRead).Result;

            string content = response.Content.ReadAsStringAsync().Result;

            return textoParaXml(content);
        }

        public Xml textoParaXml(string content)
        {
            var resultados = separaResultados(content);
            List<ResultadoPesquisa> lista = new List<ResultadoPesquisa>();

            foreach (var item in resultados)
            {
                lista.Add(preparaResultado(item));
            }

            return new Xml(lista);
        }

        public List<string> separaResultados(string texto)
        {
            List<string> retorno = new List<string>();
            string padrao = "(<div class=\"g\"><h3 class=\"r\">)(.*)(<\\/h3>)";
            foreach (Match m in Regex.Matches(texto, padrao))
            {
                retorno.Add(m.Groups[2].Value);
            }
            
            return retorno;
        }

        public ResultadoPesquisa preparaResultado(string res)
        {
            string padraoLink = "(<a href=.\\/url\\?q=)(.*)(\\/?&amp;sa=.*\">)(.*)(<\\/a>)";
            ResultadoPesquisa retorno = new ResultadoPesquisa();

            Match m = Regex.Match(res, padraoLink);
            retorno.tituloDoItem = m.Groups[4].Value;
            retorno.linkDoItem = m.Groups[2].Value;

            //verificacao contra links auxiliares e extras do google (fotos, detalhes da pesquisa);
            if (retorno.linkDoItem.Contains("&amp;sa="))
                return null;
            
            return retorno;
        }
    }
}
