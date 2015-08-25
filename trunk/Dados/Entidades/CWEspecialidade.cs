using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class CWEspecialidade
    {
        private long nCodigo;
        private string sNome;


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

    }
}
