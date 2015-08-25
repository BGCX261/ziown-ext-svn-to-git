using System;

namespace Framework
{	
    /// <summary>
    /// Classe com informações para os controles
    /// </summary>
    public class WebControlesInfo
    {
        /// <summary>
        /// Indica o caminho das imagens no servidor web
        /// </summary>        
        public static readonly string CAMINHO_IMAGENS = "images/";

        /// <summary>
        /// Identificador do separador do controle (FrameworkSystemGrid)
        /// </summary>
        public static readonly string IDENTIFICADOR_SEPARADOR_CONTROLE      = "<<==>>";

		/// <summary>
		/// Atributo usado para identificar o estado do registro no FrameworkSystemGrid
		/// </summary>
		public static readonly string ATRIBUTO_ESTADO_REGISTRO				= "EstadoRegistro";

        // Imagens padrão do TreeView
        public static readonly string TREEVIEW_IMAGENS_FOLDEROPEN   = "TreeView_folderOpen.gif";
        public static readonly string TREEVIEW_IMAGENS_FOLDERCLOSED = "TreeView_folderClosed.gif";
        public static readonly string TREEVIEW_IMAGENS_FOLDERNONE   = "TreeView_folderNone.gif";
        public static readonly string TREEVIEW_IMAGENS_PLUS         = "TreeView_plus.gif";
        public static readonly string TREEVIEW_IMAGENS_MINUS        = "TreeView_minus.gif";
        public static readonly string TREEVIEW_IMAGENS_LEAF         = "TreeView_file.gif";
        public static readonly string TREEVIEW_IMAGENS_EMPTY        = "TreeView_empty.gif";

		// Imagens do painel de funções
		public static readonly string PAINELFUNCOES_IMAGEM_SETA		= "Painel_Seta.gif";
		public static readonly string PAINELFUNCOES_IMAGEM_EXCLUIR	= "Painel_Excluir.gif";
		public static readonly string PAINELFUNCOES_IMAGEM_ANULAR	= "Painel_Anular.gif";		


		// Imagens do painel de funções
		public static readonly string TABCONTROL_IMAGEM_ABA_ESQUERDA					= "aba_esquerda_off.gif";
		public static readonly string TABCONTROL_IMAGEM_ABA_DIREITA						= "aba_direita_off.gif";
		public static readonly string TABCONTROL_IMAGEM_ABA_MEIO						= "aba_meio_off.gif";		
		public static readonly string TABCONTROL_IMAGEM_ABA_ESQUERDA_SELECIONADO		= "aba_esquerda.gif";
		public static readonly string TABCONTROL_IMAGEM_ABA_DIREITA_SELECIONADO			= "aba_direita.gif";
		public static readonly string TABCONTROL_IMAGEM_ABA_MEIO_SELECIONADO			= "aba_meio.gif";


        // Estilos
        public static readonly string ESTILO_FrameworkSystem_BOTAO                    = "FrameworkSystem_Botao";
        public static readonly string ESTILO_FrameworkSystem_BOTAO_DESABILITADO       = "FrameworkSystem_Botao_Desabilitado";
        public static readonly string ESTILO_FrameworkSystem_DATA                     = "FrameworkSystem_Data";
        public static readonly string ESTILO_FrameworkSystem_PESQUISA                 = "FrameworkSystem_Pesquisa";
        public static readonly string ESTILO_FrameworkSystem_TEXTBOX                  = "FrameworkSystem_TextBox";
        public static readonly string ESTILO_FrameworkSystem_TEXTBOX_MULTILINE        = "FrameworkSystem_TextBox_Multiline";
        public static readonly string ESTILO_FrameworkSystem_COMBOBOX                 = "FrameworkSystem_ComboBox";
        public static readonly string ESTILO_FrameworkSystem_CHECKBOX                 = "FrameworkSystem_CheckBox";
        public static readonly string ESTILO_FrameworkSystem_RADIOBUTTON              = "FrameworkSystem_RadioButton";
        public static readonly string ESTILO_FrameworkSystem_LABEL_PADRAO             = "FrameworkSystem_Label_Padrao";
        public static readonly string ESTILO_FrameworkSystem_LABEL_NEGRITO            = "FrameworkSystem_Label_Negrito";
        public static readonly string ESTILO_FrameworkSystem_LABEL_VERMELHO           = "FrameworkSystem_Label_Vermelho";
        public static readonly string ESTILO_FrameworkSystem_LISTBOX                  = "FrameworkSystem_ListBox";
        public static readonly string ESTILO_FrameworkSystem_LISTBOX_TITULO           = "FrameworkSystem_ListBox_Titulo";
        public static readonly string ESTILO_FrameworkSystem_MENSAGEM_TABELA          = "FrameworkSystem_Mensagem_Tabela";
        public static readonly string ESTILO_FrameworkSystem_MENSAGEM_TD_TABELA       = "FrameworkSystem_Mensagem_TD_Tabela";
        public static readonly string ESTILO_FrameworkSystem_ASSOCIACAO_BOTOES        = "FrameworkSystem_Associacao_Botoes";
        public static readonly string ESTILO_FrameworkSystem_PAGINACAO_LABEL_PAGINA   = "FrameworkSystem_Paginacao_Label_Pagina";
		public static readonly string ESTILO_FrameworkSystem_PAGINACAO_LABEL_TOTAL    = "FrameworkSystem_Paginacao_Label_Total_Registros";		
        public static readonly string ESTILO_FrameworkSystem_PAGINACAO_TEXTBOX_IRPARA = "FrameworkSystem_Paginacao_TextBox_IrPara";
		public static readonly string ESTILO_FrameworkSystem_PAINELFUNCOES_LINK		= "FrameworkSystem_PainelFuncoes_Link";
		public static readonly string ESTILO_FrameworkSystem_PAINELFUNCOES_TD			= "FrameworkSystem_PainelFuncoes_TD";
		public static readonly string ESTILO_FrameworkSystem_PAINELFUNCOES_DIV		= "FrameworkSystem_PainelFuncoes_DIV";
        public static readonly string COR_ERRO                              = "#FCE1C5";
		public static readonly string ESTILO_FrameworkSystem_TABCONTROL				= "FrameworkSystem_TabControl";


        // Estilos FrameworkSystemGrid
        public static readonly string ESTILO_FrameworkSystem_GRID                     = "FrameworkSystem_Grid";
        public static readonly string ESTILO_FrameworkSystem_GRID_TD_CABECALHO        = "FrameworkSystem_Grid_TD_Cabecalho";
        public static readonly string ESTILO_FrameworkSystem_GRID_TD_COMUM            = "FrameworkSystem_Grid_TD_Comum";
        public static readonly string ESTILO_FrameworkSystem_GRID_TD_ANULADA          = "FrameworkSystem_Grid_TD_Anulada";
        public static readonly string ESTILO_FrameworkSystem_GRID_TR_COMUM            = "FrameworkSystem_Grid_TR_Comum";
        public static readonly string ESTILO_FrameworkSystem_GRID_TR_SELECIONADA      = "FrameworkSystem_Grid_TR_Selecionada";

        // Estilos FrameworkSystemTreeView
        public static readonly string ESTILO_FrameworkSystem_TREEVIEW_SPAN            = "TreeView_Span";
        public static readonly string ESTILO_FrameworkSystem_TREEVIEW_ERRO            = "TreeView_Erro";

		// Obrigatoriedade
		public static readonly string OBRIGATORIEDADE_ATRIBUTO				= "OBRIGATORIO";
		public static readonly string OBRIGATORIEDADE_NOME_CAMPO			= "NOMECAMPO";
		public static readonly string OBRIGATORIEDADE_TIPO_VALIDACAO		= "TIPOVALIDACAO";

        //
        public static readonly string TIPO_CONTROLE				            = "TipoControle";

		// FrameworkSystemWebBase
		public static readonly string IDENTIFICADOR_GUID_PROCESSO			= "NOMECAMPO";
    }       

    /// <summary>
    /// Enumerador para controle de acesso, utilizados pelos controles de interface do sistema
    /// </summary>
    public enum EnumRenderizacaoAcesso
    {
        AcessoTotal,
        SomenteLeitura,
        SemAcesso
    }
}