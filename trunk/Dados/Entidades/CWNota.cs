using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class CWNota
    {
        private long nCodigo;
        private long nCodigoCliente;
        private DateTime dtData;
        private string sNota;

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

        public string Nota
        {
            get
            {
                return sNota;
            }
            set
            {
                sNota = value;
            }
        }
    }
}

