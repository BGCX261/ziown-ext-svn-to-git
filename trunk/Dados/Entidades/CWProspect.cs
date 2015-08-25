using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class CWProspect
    {
        private long nCodigo;
        private string sCNPJ;
        private DateTime dtData;
        private string sNome;
        private long nGerente;
        private long nCoordenador;
        private long nProduto;
        private decimal dcValorEve;
        private decimal dcValor;
        private long nFechamento;
        private long nStatus;
        private string sDominio;
        private DateTime dtDataCT;
        private string stxt_contato;
        private string stxt_fone;
        private long nPeriodo;
        private string semail;
        private string sCep;
        private string sEndereco;
        private string sNumero;
        private string sComplemento;
        private string sBairro;
        private string sCidade;
        private long nEstado;
        private bool blForm;
        private long nIndicacao;
        private string sCargo;
        private Single sglN_Maquinas;
        private long nAV_Anterior;
        private DateTime dtVencimento_AV;
        private long nCliente_Top;

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



        public string CNPJ
        {
            get
            {
                return sCNPJ;
            }
            set
            {
                sCNPJ = value;
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

        public long Gerente
        {
            get
            {
                return nGerente;
            }
            set
            {
                nGerente = value;
            }
        }

        public long Coordenador
        {
            get
            {
                return nCoordenador;
            }
            set
            {
                nCoordenador = value;
            }
        }

        public long Produto
        {
            get
            {
                return nProduto;
            }
            set
            {
                nProduto = value;
            }
        }

        public decimal ValorEve
        {
            get
            {
                return dcValorEve;
            }
            set
            {
                dcValorEve = value;
            }
        }

        public decimal Valor
        {
            get
            {
                return dcValor;
            }
            set
            {
                dcValor = value;
            }
        }
        public long Fechamento
        {
            get
            {
                return nFechamento;
            }
            set
            {
                nFechamento = value;
            }
        }

        public long Status
        {
            get
            {
                return nStatus;
            }
            set
            {
                nStatus = value;
            }
        }

        public string Dominio
        {
            get
            {
                return sDominio;
            }
            set
            {
                sDominio = value;
            }
        }

        public DateTime DataCT
        {
            get
            {
                return dtDataCT;
            }
            set
            {
                dtDataCT = value;
            }
        }
        public string txt_contato
        {
            get
            {
                return stxt_contato;
            }
            set
            {
                stxt_contato = value;
            }
        }

        public string txt_fone
        {
            get
            {
                return stxt_fone;
            }
            set
            {
                stxt_fone = value;
            }
        }

        public long Periodo
        {
            get
            {
                return nPeriodo;
            }
            set
            {
                nPeriodo = value;
            }
        }

        public string email
        {
            get
            {
                return semail;
            }
            set
            {
                semail = value;
            }
        }

        public string Cep
        {
            get
            {
                return sCep;
            }
            set
            {
                sCep = value;
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

        public string Numero
        {
            get
            {
                return sNumero;
            }
            set
            {
                sNumero = value;
            }
        }

        public string Complemento
        {
            get
            {
                return sComplemento;
            }
            set
            {
                sComplemento = value;
            }
        }

        public string Bairro
        {
            get
            {
                return sBairro;
            }
            set
            {
                sBairro = value;
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

        public long Estado
        {
            get
            {
                return nEstado;
            }
            set
            {
                nEstado = value;
            }
        }

        public bool Form
        {
            get
            {
                return blForm;
            }
            set
            {
                blForm = value;
            }
        }

        public long Indicacao
        {
            get
            {
                return nIndicacao;
            }
            set
            {
                nIndicacao = value;
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

        public Single N_Maquinas
        {
            get
            {
                return sglN_Maquinas;
            }
            set
            {
                sglN_Maquinas = value;
            }
        }

        public long AV_Anterior
        {
            get
            {
                return nAV_Anterior;
            }
            set
            {
                nAV_Anterior = value;
            }
        }

        public DateTime Vencimento_AV
        {
            get
            {
                return dtVencimento_AV;
            }
            set
            {
                dtVencimento_AV = value;
            }
        }

        public long Cliente_Top
        {
            get
            {
                return nCliente_Top;
            }
            set
            {
                nCliente_Top = value;
            }
        }


    }
}
