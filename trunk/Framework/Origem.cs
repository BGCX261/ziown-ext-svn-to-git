using System;

namespace Framework
{
	[Serializable]
    public class Origem
	{
		private string c_strId = string.Empty;
        private string c_strNomeAmigavel = string.Empty;
        private string c_strIdentificacaoCampo = string.Empty;
        private string c_strPagina = string.Empty;        
        
        public string ID //erros
        {
            get {return this.c_strId;}
            set {this.c_strId = value;}
        }
        
        public string NomeAmigavel // negócios (parametro de mensagens)
        {
            get {return this.c_strNomeAmigavel;}
            set {this.c_strNomeAmigavel = value;}
        }

        public string IdentificacaoCampo // log
        {
            get {return this.c_strIdentificacaoCampo;}
            set {this.c_strIdentificacaoCampo = value;}
        }

        public string Pagina
        {
            get {return this.c_strPagina;}
            set {this.c_strPagina = value;}
        }

        public Origem Copiar()
        {
            Origem objOrigem = new Origem();
            objOrigem.ID = this.ID;
            objOrigem.NomeAmigavel = this.NomeAmigavel;
            objOrigem.IdentificacaoCampo = this.IdentificacaoCampo;
            objOrigem.Pagina = this.Pagina;            
            return objOrigem;
        }
	}
}
