using HPIT.Logistic.PM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPIT.Logistic.PM.WebApp.TruckTeamManage
{
    public partial class TruckTeam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string teamName = TextBox_TeamName.Text;
                Repeater1.DataSource = TeamDal.Instance.GetDynamicList(teamName);
                Repeater1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string teamName = TextBox_TeamName.Text;
            Repeater1.DataSource = TeamDal.Instance.GetDynamicList(teamName);
            Repeater1.DataBind();
        }
    }
}