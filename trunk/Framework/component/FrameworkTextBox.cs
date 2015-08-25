using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Framework.component
{
    public delegate void KeyDownHandler(Object sender, KeyEventArgs e);
    /// <summary>
    /// Summary description for TextBox.
    /// </summary>
    public class TsmTextBox : System.Web.UI.WebControls.TextBox, IPostBackDataHandler
    {
        #region Declarations
        //private int maxLength=200;
        public event KeyDownHandler EnterKey;
        #endregion

        #region  Overriden Functions
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //
            //Add the Hidden Fields __EVENTTARGET and __EVENTARGUMENT
            //
            this.Page.RegisterHiddenField("__EVENTTARGET", "");
            this.Page.RegisterHiddenField("__EVENTARGUMENT", "");
            //
            //Add the Client Side Scripts __doPostBack and __doThis
            //
            string strScript = @"<script language='javascript'>
							<!--
							function __doARPostBack(eventTarget, eventArgument) {
								var theform;
								if (window.navigator.appName.toLowerCase().indexOf('netscape') > -1) {
									theform = document.forms[0];
								}
								else {
									theform = document.forms[0];
								}
								//
								//Set the hidden field values
								//
								theform.__EVENTTARGET.value = eventTarget.split('$').join(':');
								theform.__EVENTARGUMENT.value = eventArgument;
								theform.submit();
								}
							// -->
							</script>";
            //if(this.Page.ParseControl)
            this.Page.RegisterClientScriptBlock("doPost", strScript);

            strScript = @"<script language='javascript'>									
								function __doThis(fld){										
									var key = window.event.keyCode;
									if(key == 13){
										__doARPostBack(fld.id,'enterkey_event');
										return false;
									}								
									return true;
								}									
							</script>";

            this.Page.RegisterClientScriptBlock("doThis", strScript);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (this.EnterKey != null)
            {
                this.Attributes.Add("onkeydown", "return __doThis(this);");
            }

            base.OnPreRender(e);
        }

        #endregion

        #region EventHandler
        protected virtual void OnEnterKey(KeyEventArgs e)
        {
            if (this.EnterKey != null)
                this.EnterKey(this, e);
        }
        #endregion

        #region IPostBackDataHandler Members

        public void RaisePostDataChangedEvent()
        {
            // Do Nothing
        }

        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {

            this.Text = postCollection[postDataKey];
            string et = postCollection["__EVENTTARGET"].Trim();
            string ea = postCollection["__EVENTARGUMENT"].Trim();
            //
            //Compare the Event Target et with the Controls ID to see
            //whther this control is posted back
            //
            if (et.CompareTo(this.ClientID.Trim()) == 0)
            {
                switch (ea)
                {
                    case "enterkey_event":
                        //
                        //Invoke the EnterKey Event
                        //
                        KeyEventArgs k = new KeyEventArgs();
                        k.TextBoxID = this.ID;
                        k.Text = postCollection[postDataKey];
                        this.OnEnterKey(k);
                        break;
                }
            }
            return false;
        }
        #endregion

        #region Properties


        #endregion
    }

    #region KeyEventArgs Class
    public class KeyEventArgs : System.EventArgs
    {
        private string textBoxID;
        private string text;
        public KeyEventArgs()
        {
        }
        public string TextBoxID
        {
            set
            {
                this.textBoxID = value;
            }
            get
            {
                return this.textBoxID;
            }
        }
        public string Text
        {
            set
            {
                this.text = value;
            }
            get
            {
                return this.text;
            }
        }
    }
    #endregion
}
