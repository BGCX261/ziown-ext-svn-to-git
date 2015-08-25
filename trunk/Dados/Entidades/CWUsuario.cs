using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class CWUsuario
    {
        public long Codigo { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public long Nivel { get; set; }
        public long Coordenador { get; set; }
        public long Setor { get; set; }
        public string MetaRec { get; set; }
        public string MetaEve { get; set; }
        public long Vende { get; set; }
        public string Cor { get; set; }
        public bool Status { get; set; }
        public long Area { get; set; }
        public string Fone { get; set; }
        public string FoneCel { get; set; }
        public string MetaPropostas { get; set; }
        public string MetaContatos { get; set; }
        public string MetaClientes { get; set; }
        public long PrimeiroAcesso { get; set; }
        public DateTime UltimoAcesso { get; set; }
        public long Funil_Vendas { get; set; } 
    }
}
