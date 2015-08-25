using System;
using System.Data;

namespace Framework
{
	/// <summary>
	/// Summary description for PropriedadeTabela.
	/// </summary>
	[Serializable]
	public sealed class PropriedadeTabela
	{

        DbType c_objType;
		string c_strIdPropriedade;
        string c_strNome;
        string c_strNomeComposto;
        string c_strApelido;
        string c_strNomeApelido;

        public PropriedadeTabela(string p_strIdPropriedade, string p_strNome, 
			string p_strNomeComposto, string p_strApelido, string p_strNomeApelido,  
			DbType p_objType)
        {
            c_objType           = p_objType;
			c_strIdPropriedade  = p_strIdPropriedade;
            c_strNome           = p_strNome;
            c_strNomeComposto   = p_strNomeComposto;
            c_strApelido        = p_strApelido;
            c_strNomeApelido    = p_strNomeApelido;
        }

		public PropriedadeTabela()
		{

		}

		public string Identificacao
		{
			get
			{
				return c_strIdPropriedade;
			}
			set
			{
				c_strIdPropriedade = value;
			}
		}   

        public string Nome
        {
            get
            {
                return c_strNome;
            }
            set
            {
                c_strNome = value;
            }
        }   
     	
        public string NomeComposto
        {
            get
            {
                return c_strNomeComposto;
            }
            set
            {
                c_strNomeComposto = value;
            }
        }   

        public string Apelido
        {
            get
            {
                return c_strApelido;
            }
            set
            {
                c_strApelido = value;
            }
        }   

        public string NomeApelido
        {
            get
            {
                return c_strNomeApelido;
            }
            set
            {
                c_strNomeApelido = value;
            }
        }   


        public DbType Tipo
        {
            get
            {
                return c_objType;
            }
            set
            {
                c_objType = value;
            }
        }        		
	}
}
