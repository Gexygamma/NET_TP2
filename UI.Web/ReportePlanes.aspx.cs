using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;

namespace UI.Web
{
    public partial class ReportePlanes : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PlanLogic planLogic = new PlanLogic();
                ddlPlan.DataSource = planLogic.GetAll();
                ddlPlan.DataTextField = "Descripcion";
                ddlPlan.DataValueField = "ID";
                ddlPlan.DataBind();
                ddlPlan.SelectedIndex = -1;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ddlPlan.SelectedValue != string.Empty)
            {
                MateriaLogic materialogic = new MateriaLogic();
                int idPlan = int.Parse(ddlPlan.SelectedValue.ToString());
                GridView1.DataSource = materialogic.GetAllPlan(idPlan);
                GridView1.DataBind();
            }
        }
    }
}