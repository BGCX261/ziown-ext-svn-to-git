using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class CWSetor
    {
        private long nCodigo;
        private string sSetor;
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

        public string Setor
        {
            get
            {
                return sSetor;
            }
            set
            {
                sSetor = value;
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
