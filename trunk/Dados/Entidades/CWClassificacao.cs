using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class CWClassificacao
    {
        private long nCodigo;
        private string sClassificacao;
        private string sTempoContato;
        private string sTempoVisita;

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

        public string Classificacao
        {
            get
            {
                return sClassificacao;
            }
            set
            {
                sClassificacao = value;
            }
        }

        public string TempoContato
        {
            get
            {
                return sTempoContato;
            }
            set
            {
                sTempoContato = value;
            }
        }
        public string TempoVisita
        {
            get
            {
                return sTempoVisita;
            }
            set
            {
                sTempoVisita = value;
            }
        }
    }
}
