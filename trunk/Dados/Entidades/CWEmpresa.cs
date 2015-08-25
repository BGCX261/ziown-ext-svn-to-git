using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class CWEmpresa
    {
        public long Codigo { get; set; }
        public double Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public double InscricaoEstaual { get; set; }
        public double InscricaoMunicipal { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string EmailDocumentacao { get; set; }
        public string EmailCRC { get; set; }
        public string EmailRenovacao { get; set; }
        public string Tributacao { get; set; }
        public decimal CapitalSocial { get; set; }
        public string Situacao { get; set; }

    }
}
