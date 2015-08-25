using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dados;
using Ext.Net;

namespace Ziown_ext
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           
            if (!IsPostBack)
            {
                if (Session["CODIGO_USUARIO"] != null)
                {
                    CWUsuario cwUsuario = new Usuario().Pesquisar(new CWUsuario() { Codigo = long.Parse(Session["CODIGO_USUARIO"].ToString()) }).FirstOrDefault();
                    lblUsuario.Text = cwUsuario.Nome;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

            }
        }

        protected void mnuHome_Click(object sender, EventArgs e)
        {

            Response.Redirect("Default.aspx");

        }

        protected void mnuCadastros_Click(object sender, EventArgs e)
        {

            //Response.Redirect("Default.aspx");

        }

        protected void mnuCadastroEmpresas_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/cadastros/PesquisarCadastroEmpresas.aspx");

        }
    }
}
