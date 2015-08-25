using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework
{

    [Serializable]
    public class SessaoInfo
    {
        public static readonly string ID_OBJETO_SESSAO = "SessionInfo";

        private int c_intCodigoAssinante;


        public SessaoInfo()
        {

        }

        #region Propriedades

        /// <summary>Código do Assinante</summary>
        public int CodigoAssinante
        {
            get { return this.c_intCodigoAssinante; }
            set { this.c_intCodigoAssinante = value; }
        }


        #endregion
    }
}
