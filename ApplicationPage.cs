using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace UI.Web
{
    public enum ModoForm { Alta, Baja, Modificacion }

    public class ApplicationPage : Page
    {
        public ModoForm Modo
        {
            get { return (ModoForm)ViewState["ModoForm"]; }
            set { ViewState["ModoForm"] = value; }
        }
    }
}