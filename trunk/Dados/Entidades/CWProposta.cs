using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class CWProposta
    {
        private long nCodigo;
        private long nCodigoCliente;
        private long nHospedagem;
        private DateTime dtData;
        private string sArquivo;
        private DateTime dtDataCadastro;
        private decimal dcNProposta;
        private decimal dcValorProposta;
        private decimal dcValorInstalacao;
        private long nNMaquinas;
        private string sPeriodicidade;

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


        public long CodigoCliente
        {
            get
            {
                return nCodigoCliente;
            }
            set
            {
                nCodigoCliente = value;
            }
        }


        public long Hospedagem
        {
            get
            {
                return nHospedagem;
            }
            set
            {
                nHospedagem = value;
            }
        }

        public DateTime Data
        {
            get
            {
                return dtData;
            }
            set
            {
                dtData = value;
            }
        }


        public string Arquivo
        {
            get
            {
                return sArquivo;
            }
            set
            {
                sArquivo = value;
            }
        }


        public DateTime DataCadastro
        {
            get
            {
                return dtDataCadastro;
            }
            set
            {
                dtDataCadastro = value;
            }
        }


        public decimal NProposta
        {
            get
            {
                return dcNProposta;
            }
            set
            {
                dcNProposta = value;
            }
        }


        public decimal ValorProposta
        {
            get
            {
                return dcValorProposta;
            }
            set
            {
                dcValorProposta = value;
            }
        }


        public decimal ValorInstalacao
        {
            get
            {
                return dcValorInstalacao;
            }
            set
            {
                dcValorInstalacao = value;
            }
        }


        public long NMaquinas
        {
            get
            {
                return nNMaquinas;
            }
            set
            {
                nNMaquinas = value;
            }
        }



        public string Periodicidade
        {
            get
            {
                return sPeriodicidade;
            }
            set
            {
                sPeriodicidade = value;
            }
        }

    }
}
