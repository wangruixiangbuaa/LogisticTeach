using HPIT.Data.Core;
using HPIT.Logistic.PM.BLL;
using HPIT.Logistic.PM.DAL;
using HPIT.Logistic.PM.Model;
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
        public int pageIndex = 0;
        public int pageSize = 5;
        public int total = 0;
        public TruckBll bll = new TruckBll();
        public TruckDal dal = new TruckDal();
        protected void Page_Load(object sender, EventArgs e)
        {
            //是否回发
            if (!IsPostBack)
            {
                string teamName = TextBox_TeamName.Text;
                DateTime time = string.IsNullOrEmpty(TextBox_CreateTime.Text) ? DateTime.Now : Convert.ToDateTime(TextBox_CreateTime.Text);
                Repeater1.DataSource = dal.GetTruckList(pageIndex, pageSize, teamName,time, out total);
                Repeater1.DataBind();
                //显示页数列表
                Repeater2.DataSource = PageDataHelper.GetPageList(total, pageSize);
                Repeater2.DataBind();
            }

        }

        protected void Button_Search_Click(object sender, EventArgs e)
        {
            string teamName = TextBox_TeamName.Text;
            DateTime time = string.IsNullOrEmpty(TextBox_CreateTime.Text) ? DateTime.Now : Convert.ToDateTime(TextBox_CreateTime.Text);
            //重新绑定列表绑定的数据.
            Repeater1.DataSource = dal.GetTruckList(pageIndex, pageSize, teamName, time, out total);
            Repeater1.DataBind();
            //显示页数列表
            Repeater2.DataSource = PageDataHelper.GetPageList(total, pageSize);
            Repeater2.DataBind();
        }

        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //页码切换数据的事件处理
            int pageIndex = Convert.ToInt32(e.CommandArgument);
            string teamName = TextBox_TeamName.Text;
            DateTime time = string.IsNullOrEmpty(TextBox_CreateTime.Text) ? DateTime.Now : Convert.ToDateTime(TextBox_CreateTime.Text);
            //重新绑定列表绑定的数据.
            Repeater1.DataSource = dal.GetTruckList(pageIndex, pageSize, teamName, time, out total);
            Repeater1.DataBind();
        }
    }
}