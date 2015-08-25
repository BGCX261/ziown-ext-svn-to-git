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
    public partial class PesquisarCadastroEmpresas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<CWEmpresa> lstEmpresas = new Empresa().Pesquisar(new CWEmpresa());               

                grdPesquisa.DataSource = lstEmpresas;
                grdPesquisa.DataBind();
            }
        }

        protected void grd_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }


        protected void grdPesquisa_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = "<a href=EditarEmpresa.aspx?id=" + ((Dados.CWEmpresa)(e.Row.DataItem)).RazaoSocial + ">" + ((Dados.CWEmpresa)(e.Row.DataItem)).RazaoSocial + "</a>";
                
            }
        }

        protected void btnPesquisar_Click(object sender, DirectEventArgs e)
        {

            CWEmpresa cwEmpresa = new CWEmpresa();

            cwEmpresa.RazaoSocial = txtRazaoSocial.Text;

            List<CWEmpresa> lstEmpresas = new Empresa().Pesquisar(cwEmpresa);

            grdPesquisa.DataSource = lstEmpresas;
            grdPesquisa.DataBind();


        }
    }
}
