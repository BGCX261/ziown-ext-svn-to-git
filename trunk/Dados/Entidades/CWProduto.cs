using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class CWProduto
    {
        private long nCodigo;
        private string sProduto;
        private string sDescritivo;

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

        public string Produto
        {
            get
            {
                return sProduto;
            }
            set
            {
                sProduto = value;
            }
        }

        public string Descritivo
        {
            get
            {
                return sDescritivo;
            }
            set
            {
                sDescritivo = value;
            }
        }
    }
}
