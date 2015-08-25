using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class CWOpcaoPagamento
    {
        private long nCodigo;
        private string sOpcao_Pagamento;


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

        public string Opcao_Pagamento
        {
            get
            {
                return sOpcao_Pagamento;
            }
            set
            {
                sOpcao_Pagamento = value;
            }
        }

    }
}
