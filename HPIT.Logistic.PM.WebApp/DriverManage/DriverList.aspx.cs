using HPIT.Logistic.PM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPIT.Logistic.PM.WebApp.DriverManage
{
    public partial class DriverList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string teamName = TextBox_TeamName.Text;
            Repeater1.DataSource = DriverDal.Instance.GetDynamicList(teamName);
            Repeater1.DataBind();
        }

        protected void Btn_Search(object sender, EventArgs e)
        {
            string teamName = TextBox_TeamName.Text;
            Repeater1.DataSource = DriverDal.Instance.GetDynamicList(teamName);
            Repeater1.DataBind();
        }
    }
}