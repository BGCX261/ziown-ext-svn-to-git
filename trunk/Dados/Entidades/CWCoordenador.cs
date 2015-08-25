using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class CWCoordenador
    {
        private long nCodigo;
        private string sNome;
        private string sEmail;
        private string sCargo;


        private string sEmpresa;
        private string sEndereco;
        private string sCidade;
        private string sEstado;
        private string sTelefone;
        private string sEmail_Empresa;
        private string sSite;
        private string sLogo;

        public long Codigo
        {
            get
            {
                return nCodigo;
            }
            set
            {
                nCodigo = value;
            }
        }

        public string Nome
        {
            get
            {
                return sNome;
            }
            set
            {
                sNome = value;
            }
        }

        public string Email
        {
            get
            {
                return sEmail;
            }
            set
            {
                sEmail = value;
            }
        }

        public string Cargo
        {
            get
            {
                return sCargo;
            }
            set
            {
                sCargo = value;
            }

        }


        public string Empresa
        {
            get
            {
                return sEmpresa;
            }
            set
            {
                sEmpresa = value;
            }

        }

        public string Endereco
        {
            get
            {
                return sEndereco;
            }
            set
            {
                sEndereco = value;
            }

        }

        public string Cidade
        {
            get
            {
                return sCidade;
            }
            set
            {
                sCidade = value;
            }

        }

        public string Estado
        {
            get
            {
                return sEstado;
            }
            set
            {
                sEstado = value;
            }

        }

        public string Telefone
        {
            get
            {
                return sTelefone;
            }
            set
            {
                sTelefone = value;
            }

        }

        public string Email_Empresa
        {
            get
            {
                return sEmail_Empresa;
            }
            set
            {
                sEmail_Empresa = value;
            }

        }

        public string Site
        {
            get
            {
                return sSite;
            }
            set
            {
                sSite = value;
            }

        }

        public string Logo
        {
            get
            {
                return sLogo;
            }
            set
            {
                sLogo = value;
            }

        }

    }
}
