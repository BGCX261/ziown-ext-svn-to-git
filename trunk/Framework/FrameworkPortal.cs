using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Framework
{
    public class FrameworkPortal : System.Web.UI.Page
    {
        public static readonly string ID_OBJETO_SESSAO;

        [Browsable(false)]
        public SessaoInfo Sessao
        {
            get
            {
                if (this.Session[SessaoInfo.ID_OBJETO_SESSAO] == null)
                {
                    this.Session[SessaoInfo.ID_OBJETO_SESSAO] = new SessaoInfo();
                }
                return (SessaoInfo)Session[SessaoInfo.ID_OBJETO_SESSAO];
            }
            set
            {
                Session[SessaoInfo.ID_OBJETO_SESSAO] = value;
            }
        }
    }
}
