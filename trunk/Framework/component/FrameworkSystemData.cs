using System;
using System.IO;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.Design;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Framework
{
    /// <summary>
    /// Controle de data (calendário)
    /// </summary>
    [ToolboxBitmap(typeof(Calendar)),
    DesignerAttribute(typeof(FrameworkSystemDataDesigner), typeof(IDesigner)),	
    DefaultProperty("Text"),
    ToolboxData("<{0}:FrameworkSystemData runat=\"server\"></{0}:FrameworkSystemData>")]
    public class FrameworkSystemData : DataBoundControl, IPostBackDataHandler
    {
        #region Constantes

        private readonly string ID_TEXTBOX          = "_DataTextBox";
        private readonly string ID_BTNCALENDARIO    = "_btnCalendario";
        private readonly string IMAGEM_BOTAO        = "btnCalendario.gif";

        #endregion

        #region Variáveis de classe
        
        private TextBox     c_txtData       = new TextBox();
        private HtmlImage   c_btnCalendario = null;
        private Table       c_tblData       = null;   
        
        private string c_strIdentificacaoCampo = string.Empty;

        //private PropriedadesBinding		c_objPropriedadesBinding = null;

        private Origem c_objOrigem = new Origem();
        private string c_strNomeAmigavel = string.Empty;

        #endregion

        #region Propriedades

        [Category("FrameworkSystem"), DefaultValue(""), Description("Define um nome amigável para o campo")]
        public string NomeAmigavel {get; set;}

        /// <summary>
        /// Define se o controle é obrigatório (validação client-side do form)
        /// </summary>
        [Category("FrameworkSystem"),
        Description("Define se o controle é obrigatório (validação client-side do form)."),
        DefaultValue(false)]
        public bool Obrigatorio
        {
            get
            {
                if(ViewState["Obrigatorio"] != null)
                {
                    return Convert.ToBoolean(ViewState["Obrigatorio"]);
                }
                return false;
            }
            set
            {
                ViewState["Obrigatorio"] = value;
            }
        }  
   
        /// <summary>
        /// Define se o controle deve ser renderizado com estilo de erro (cor de fundo diferente)
        /// </summary>
        [Browsable(false)]
        public bool DestaqueVisual {get; set;}
        
        /// <summary>
        /// Define se o campo texto do controle deve estar habilitado (propriedade Enabled do TextBox).
        /// </summary>
        [Bindable(false), Category("FrameworkSystem"),
        DefaultValue(true),
        Description("Define se o campo texto do controle deve estar habilitado (propriedade Enabled do TextBox).")]
        public bool CampoTexto_Habilitado
        {
            get
            {
                if(ViewState["CampoTexto_Habilitado"] != null)
                {
                    return Convert.ToBoolean(ViewState["CampoTexto_Habilitado"]);
                }
                return true;
            }
            set
            { 
                ViewState["CampoTexto_Habilitado"] = value;                
            }			
        }

        /// <summary>
        /// Define se o campo texto do controle deve ser somente-leitura (propriedade ReadOnly do TextBox).
        /// </summary>
        [Bindable(false), Category("FrameworkSystem"),
        DefaultValue(false),
        Description("Define se o campo texto do controle deve ser somente-leitura (propriedade ReadOnly do TextBox).")]
        public bool CampoTexto_SomenteLeitura
        {
            get
            {                
                if(ViewState["CampoTexto_SomenteLeitura"] != null)
                {
                    return Convert.ToBoolean(ViewState["CampoTexto_SomenteLeitura"]);
                }
                return false;
            }
            set
            { 
                ViewState["CampoTexto_SomenteLeitura"] = value;                
            }			
        }

        /// <summary>
        /// Define se botão do controle deve estar habilitado para clique.
        /// </summary>
        [Bindable(false), Category("FrameworkSystem"),
        DefaultValue(true),
        Description("Define se botão do controle deve estar habilitado para clique.")]
        public bool Botao_Habilitado
        {
            get
            {
                if(ViewState["Botao_Habilitado"] != null)
                {
                    return Convert.ToBoolean(ViewState["Botao_Habilitado"]);
                }
                return true;
            }
            set
            { 
                ViewState["Botao_Habilitado"] = value;                
            }			
        }        
        
        /// <summary>
        /// Define o tamanho máximo em caracteres para o TextBox do controle.
        /// </summary>
        [Bindable(false), Category("FrameworkSystem"),
        DefaultValue(0),
        Description("Define o tamanho máximo em caracteres para o TextBox do controle.")]
        public int MaxLength
        {
            get
            {
                if(ViewState["MaxLength"] != null)
                {
                    return Convert.ToInt32(ViewState["MaxLength"]);
                }
                return 0;
            }
            set
            { 
                ViewState["MaxLength"] = value;
            }			
        }
        
        public override bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
                this.Botao_Habilitado = value;
                this.CampoTexto_Habilitado = value;
            }
        }

        /// <summary>
        /// Retorna o conteúdo do campo texto do controle
        /// </summary>
        [Category("Appearence")]
        public string Text
        {
            get
            {   
                TextBox txtTemp = this.ObterTextBox();
                if(txtTemp != null)
                {
                    return txtTemp.Text;
                }       
                return string.Empty;
            }
            set
            {
                TextBox txtTemp = this.ObterTextBox();
                if(txtTemp != null)
                {
                    txtTemp.Text = value;
                }                				
            }
        }

        [Browsable(true), Category("FrameworkSystem"), DefaultValue("")]
        public bool AutoPostBack
        {
            get
            {
                return c_txtData.AutoPostBack;
            }
            set
            {
                c_txtData.AutoPostBack = value;
            }
        }   

        #endregion         
                
        #region Overrides

        /// <summary>
        /// Retorna a classe CSS do controle
        /// </summary>
        public override string CssClass
        {
            get
            {
                return base.CssClass;
            }            
        }

        //public FrameworkSystemData()
        //{
        //    Origem = new Origem();
        //}

        protected override void OnInit(EventArgs e)
        { 
            // provoca a criação da tabela de controles (e obtem valor postado no form)            
            this.EnsureChildControls();
            base.OnInit (e);
        }
       
        protected override void OnLoad(EventArgs e)
        {	
            #region guarda informações de origem do controle

            //this.Origem.ID = this.ClientID;
            ////this.Origem.IdentificacaoCampo = this.IdentificacaoCampo;
            //this.Origem.NomeAmigavel = this.NomeAmigavel;

            //string strPath = this.Page.Request.CurrentExecutionFilePath;
            //this.Origem.Pagina = strPath.Substring(strPath.LastIndexOf("/")+1);

            #endregion

            if(this.Text == string.Empty)
            {
                // foi guardado algum valor quando o controle estava em somente-leitura ou sem acesso?
                if(ViewState["Texto_SomenteLeitura_ou_SemAcesso"] != null)
                {
                    // sim, devolve o valor à propriedade Text
                    this.Text = ViewState["Texto_SomenteLeitura_ou_SemAcesso"].ToString();

                    // descarta valor do ViewState
                    ViewState["Texto_SomenteLeitura_ou_SemAcesso"] = null;
                }
            }

            base.OnLoad (e);

            //Executa o textchange
            string strControle = Page.Request.Params.Get("__EVENTTARGET");
            if ((strControle == c_txtData.ClientID) || (strControle == c_txtData.UniqueID))
            {
                TextChanged(c_txtData, e);
            }
        }       

        protected override object SaveViewState()
        {
            
            return base.SaveViewState ();
        }

        protected override void CreateChildControls()
        {
            // instancia e configura os componentes do controle
            this.ConfigurarComponentes();

            // monta tabela do controle
            this.ConfigurarTabela();

            // adiciona tabela no controle
            this.Controls.Add(c_tblData);
            
            #region Recupera valor postado no form
            
            if(this.DesignMode == false)
            {         
                // foi postada uma data no form?
                if(this.Page.Request.Form[this.ID + this.ID_TEXTBOX] != null)
                {
                    // guarda o valor
                    this.Text = this.Page.Request.Form[this.ID + this.ID_TEXTBOX];
                }                
            }            

            #endregion

            // Emite JS para funcionamento do calendário
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ScriptCalendar_" + this.ID,"<script>AdicionarCalendario('Calendar_" + this.ClientID + "', 'Data', '" + this.ClientID + this.ID_TEXTBOX + "');</script>");
        }

        protected override void OnPreRender(EventArgs e)
        {
            #region Configura estado do controle
            
            // obtem referências ao TextBox e HtmlImage
            TextBox txtTemp             = this.ObterTextBox();
            HtmlImage btnCalendario     = this.ObterBotaoCalendario();

            txtTemp.Enabled     = this.CampoTexto_Habilitado;
            //txtTemp.ReadOnly    = this.CampoTexto_SomenteLeitura;

            if (this.CampoTexto_SomenteLeitura)
            {
                txtTemp.Attributes["onkeydown"] = "return BloquearDigitacao(this, event);";
            }

            if(this.Botao_Habilitado)
            {
                this.HabilitarBotaoCalendario(btnCalendario, true); 
            }
            else
            {
                this.HabilitarBotaoCalendario(btnCalendario, false);   
            }          

            #endregion            

            this.AdicionarAtributoObrigatoriedade();           

            //Identifica o controle
            //this.c_txtData.Attributes.Add(WebControlesInfo.TIPO_CONTROLE, "FrameworkSystemData");

            // Trata campo sem máscara
            this.c_txtData.Attributes.Add("onkeypress", "javascript: return ValidarDigitoData(this, event);");

            base.OnPreRender (e);
        }

        protected override void Render(HtmlTextWriter writer)
        {   
           

            this.Attributes.Add("onKeyUp", "InserirMascara('" + 
                c_txtData.ClientID + "', event, false, 3);");
            
            
            base.Render (writer);
            
        }

        #endregion  

        #region Métodos
       
        /// <summary>
        /// Adiciona atributo de obrigatoriedade na tag HTML do controle
        /// </summary>
        public void AdicionarAtributoObrigatoriedade()
        {
            if(this.Obrigatorio)
            {
                this.c_txtData.Attributes.Add(WebControlesInfo.OBRIGATORIEDADE_ATRIBUTO, "true");
            }            
            this.c_txtData.Attributes.Add(WebControlesInfo.OBRIGATORIEDADE_NOME_CAMPO,
                this.NomeAmigavel);
        }        
        private void ConfigurarComponentes()
        {
            // tamanho zero para o controle?
            if (this.Width.Value == 0)
            {
                // altera para 100 pixels
                this.Width = Unit.Pixel(100);
            }                   

            // instancia e configura TextBox
            //c_txtData           = new TextBox();
            c_txtData.ID        = this.ID + this.ID_TEXTBOX;
            c_txtData.MaxLength = this.MaxLength;
            c_txtData.Width     = Unit.Pixel(Convert.ToInt32(this.Width.Value) - 24);
            c_txtData.CssClass = WebControlesInfo.ESTILO_FrameworkSystem_DATA;
    
            // instancia e configura botão de pesquisa
            c_btnCalendario           = new HtmlImage();
            c_btnCalendario.ID        = this.ID + this.ID_BTNCALENDARIO;
            c_btnCalendario.Border    = 0;
            c_btnCalendario.Src       = WebControlesInfo.CAMINHO_IMAGENS + this.IMAGEM_BOTAO;
            //if (AutoPostBack && !Page.IsPostBack)
            //{
            //    c_txtData.Attributes.Add("onchange", "__doPostBack('" + c_txtData.ClientID + "','');");
            //}
        }

        private void ConfigurarTabela()
        {            
            // instancia e configura tabela do controle
            c_tblData               = new Table();
            c_tblData.CellPadding   = 0;
            c_tblData.CellSpacing   = 0;			
            c_tblData.Width         = this.Width;
            
            // table row
            TableRow rowData         = new TableRow();
            rowData.VerticalAlign    = VerticalAlign.Bottom;

            // cria table cell e adiciona o TextBox
            TableCell celControle       = new TableCell();
            celControle.VerticalAlign   = VerticalAlign.Bottom;            
            celControle.Controls.Add(c_txtData);
           
            // adiciona table cell na row
            rowData.Cells.Add(celControle);

            // cria table cell e adiciona o botão de pesquisa
            celControle                 = new TableCell();
            celControle.VerticalAlign   = VerticalAlign.Bottom;
            celControle.Style.Add("padding-left", "5px");
            celControle.Controls.Add(c_btnCalendario);
           
            // adiciona table cell na row
            rowData.Cells.Add(celControle);

            // adiciona row na tabela
            c_tblData.Rows.Add(rowData);            
        }      

        private TextBox ObterTextBox()
        {
            if(this.Controls.Count > 0)
            {
                Table objTable = (Table)this.Controls[0];
                if(objTable.Rows[0].Cells[0].Controls[0] is TextBox)
                {
                    return (TextBox) objTable.Rows[0].Cells[0].Controls[0];
                }
            }
            return null;
        }
       
        public event EventHandler TextChanged;

        private void c_txtData_TextChanged(object sender, EventArgs e)
        {
            
            if (TextChanged != null)
            {
                TextChanged(sender, e);
            }
        }      
        private HtmlImage ObterBotaoCalendario()
        {
            if(this.Controls.Count > 0)
            {
                Table objTable = (Table)this.Controls[0];
                if(objTable.Rows[0].Cells[1].Controls[0] is HtmlImage)
                {
                    return (HtmlImage) objTable.Rows[0].Cells[1].Controls[0];
                }
            }
            return null;
        }

        private void HabilitarBotaoCalendario(HtmlImage p_btnCalendario, bool p_blnHabilitar)
        {            
            if(p_btnCalendario != null)
            {
                if(p_blnHabilitar)
                {
                    // habilita botão de calendário adicionando atributo onclick e estilo
                    p_btnCalendario.Attributes.Add("onclick", "CalendarioClick(event, 'Calendar_" + this.ClientID + "');");
                    p_btnCalendario.Style.Add("cursor", "pointer");
                }
                else
                {
                    // desabilita botão de calendário removendo atributo onclick e estilo
                    p_btnCalendario.Attributes.Remove("onclick");
                    p_btnCalendario.Style.Remove("cursor");
                }
            }
        }
        
        #endregion

        #region Design
        
        /// <summary>
        /// Renderiza o controle para o designer do Visual Studio
        /// </summary>
        /// <returns>string HTML que representa o controle</returns>
        public string DesignControle()
        { 
            // instancia e configura os componentes do controle
            this.ConfigurarComponentes();

            // monta tabela do controle
            this.ConfigurarTabela();            

            StringWriter	stwRender		= new StringWriter();
            HtmlTextWriter	htwRender		= new HtmlTextWriter(stwRender); 
            
            // rederiza o controle			
            c_tblData.RenderControl(htwRender);            
            
            return stwRender.ToString(); 
        }    
        #endregion       
    
        #region IPostBackDataHandler Members
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            return false;
        }

        public void RaisePostDataChangedEvent()
        {

        }

        #endregion
    }

    public class FrameworkSystemDataDesigner : ControlDesigner
    {	
        public override string GetDesignTimeHtml()
        {
            return ((FrameworkSystemData) Component).DesignControle();
        }  
    }
}