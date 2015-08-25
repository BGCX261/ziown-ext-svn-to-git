using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class CWNivel
    {
        private long nCodigo;
        private string sNivel;
        private string sDescricao;

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

        public string Nivel
        {
            get
            {
                return sNivel;
            }
            set
            {
                sNivel = value;
            }
        }

        public string Descricao
        {
            get
            {
                return sDescricao;
            }
            set
            {
                sDescricao = value;
            }
        }
    }
}
