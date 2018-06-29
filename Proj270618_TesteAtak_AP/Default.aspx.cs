using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proj270618_TesteAtak_AP
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void pesquisar(object sender, EventArgs e)
        {
            AtakWS_PesquisaGoogle.PesquisaGoogleSoapClient webservice = new AtakWS_PesquisaGoogle.PesquisaGoogleSoapClient();
            DataTable itens = new DataTable();

            itens.Columns.Add("titulo");
            itens.Columns.Add("link");

            var xml = webservice.EfetuaPesquisa(iptBusca.Text);

            foreach (var item in xml.listaDeResultados)
            {
                if (item == null)
                    continue;

                itens.Rows.Add(item.titulo, item.link);
            }

            gvResultados.DataSource = itens;
            gvResultados.DataBind();
        }
    }
}