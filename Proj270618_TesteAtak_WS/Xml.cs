using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Proj270618_TesteAtak_WS
{
    [XmlRoot(ElementName ="xml")]
    public class Xml
    {
        public Xml() { }

        public Xml(List<ResultadoPesquisa> resultado)
        {
            this.listaDeResultados = resultado;
        }

        public List<ResultadoPesquisa> listaDeResultados { get; set; }
    }

    public class ResultadoPesquisa
    {
        [XmlElement(ElementName = "titulo")]
        public string tituloDoItem { get; set; }

        [XmlElement(ElementName = "link")]
        public string linkDoItem { get; set; }

    }
}