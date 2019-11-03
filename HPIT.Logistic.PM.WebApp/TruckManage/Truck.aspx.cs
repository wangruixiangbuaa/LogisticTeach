using HPIT.Logistic.PM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPIT.Logistic.PM.WebApp.TruckManage
{
    public partial class Truck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string teamName = TextBox_TeamName.Text;
            Repeater1.DataSource = TruckDal.Instance.GetDynamicList(teamName);
            Repeater1.DataBind();
        }

        protected void Button_Search_Click(object sender, EventArgs e)
        {
            string teamName = TextBox_TeamName.Text;
            Repeater1.DataSource = TruckDal.Instance.GetDynamicList(teamName);
            Repeater1.DataBind();
        }

    }
}