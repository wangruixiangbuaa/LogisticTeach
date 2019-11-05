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
        protected void Page_Load(object sender, EventArgs e)
        {
            string teamName = TextBox_TeamName.Text;
            Repeater1.DataSource = TruckDal.Instance.GetDynamicList(teamName);
            Repeater1.DataBind();

            //显示页数列表
            Repeater2.DataSource = PageList();
            Repeater2.DataBind();

        }

        /// <summary>
        /// 获取页数列表
        /// </summary>
        /// <returns></returns>
        public List<PageModel> PageList()
        {
            TruckBll bll = new TruckBll();
            int total = 0;
            //查询数据的总数
            bll.GetTrucksWithPage(pageIndex,pageSize,out total);
            //构造repeater的数据源
            int pageCount = total % pageSize == 0 ? total / pageSize : total / pageSize + 1;
            Label_total.Text = "共"+pageCount+"页";
            List<PageModel> pages = new List<PageModel>();
            for (int  i = 0;  i < pageCount;  i++)
            {
                PageModel page = new PageModel();
                page.PageIndex = i;
                pages.Add(page);
            }
            return pages;
        }

        protected void Button_Search_Click(object sender, EventArgs e)
        {
            string teamName = TextBox_TeamName.Text;
            Repeater1.DataSource = TruckDal.Instance.GetDynamicList(teamName);
            Repeater1.DataBind();
        }

        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int pageIndex = Convert.ToInt32(e.CommandArgument);

        }
    }
}