using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class CWValidadeProposta
    {
        private long nCodigo;
        private string sValidade_Proposta;


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

        public string Validade_Proposta
        {
            get
            {
                return sValidade_Proposta;
            }
            set
            {
                sValidade_Proposta = value;
            }
        }

    }
}
