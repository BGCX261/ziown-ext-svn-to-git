using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Dados;

namespace Ziown_ext
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["CODIGO_USUARIO"] = null;
        }

        protected void btnLogin_Click(object sender, DirectEventArgs e)
        {

            
            CWUsuario cwUsuario = new CWUsuario();

            cwUsuario.Usuario = txtUsername.Text;
            cwUsuario.Senha = txtPassword.Text;

            var usuario = new Usuario().ValidarAcesso(cwUsuario);

            if (usuario > 0)
            {
                Session["CODIGO_USUARIO"] = usuario;
                Response.Redirect("Default.aspx");
            }
            else
            {
                txtUsername.Focus();
                lblMessage.Html = "Usuário ou senha inválidos";
            }

            
        }
    }
}