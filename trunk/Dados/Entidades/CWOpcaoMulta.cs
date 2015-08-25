using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class CWOpcaoMulta
    {
        private long nCodigo;
        private string sOpcao_Multa;


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

        public string Opcao_Multa
        {
            get
            {
                return sOpcao_Multa;
            }
            set
            {
                sOpcao_Multa = value;
            }
        }

    }
}
