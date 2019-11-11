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

namespace HPIT.Logistic.PM.WebApp.Admin
{
    public partial class UserList : System.Web.UI.Page
    {
        UserBll bll = new UserBll();
        UserDal dal = new UserDal();
        RoleBll roleBll = new RoleBll();
        int pageIndex = 0;
        int pageSize = 5;
        int total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断是否重新进行请求
            if (!IsPostBack)
            {
                //下拉框数据源
                DropDownList_Roles.DataSource = roleBll.GetAllRole();
                DropDownList_Roles.DataTextField = "RoleName";
                DropDownList_Roles.DataValueField = "RoleID";
                DropDownList_Roles.DataBind();
                //查询
                SearchUsers();
            }
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            SearchUsers();
        }

        /// <summary>
        /// 
        /// </summary>
        public void SearchUsers()
        {
            //获取搜索参数
            string account = TextBox_Account.Text;
            string time = TextBox_CreateTime.Text;
            string roleName = DropDownList_Roles.SelectedItem.Text;
            //查询数据
            DateTime bornTime = string.IsNullOrEmpty(time) ? DateTime.Now : Convert.ToDateTime(time);
            UserModel model = new UserModel();
            model.Account = account;
            model.RoleName = roleName;
            model.CheckInTime = bornTime;
            List<UserModel> result = dal.GetNewUserPageList(pageIndex,pageSize,model,out total);
            //把数据绑定到界面 repeater
            Repeater1.DataSource = result;
            Repeater1.DataBind();
            //页码repeater2
            Repeater2.DataSource = PageDataHelper.GetPageList(total,pageSize);
            Repeater2.DataBind();
        }

        /// <summary>
        /// 注册repeater的事件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //获取当前行操作按钮的类型，和参数
            string cmdType = e.CommandName;
            string userID = e.CommandArgument.ToString();
            if (cmdType == "update")
            {
                //跳转更新页面页面
                Response.Redirect("AddUser.aspx?id=" + userID);
            }
            else
            {
                //根据用户id 删除数据
                int result = bll.DeleteUser(Convert.ToInt32(userID));
                //如果成功，跳转的list 页面
                if (result > 0)
                {
                    Response.Redirect("UserList.aspx");
                }
                else
                {
                    //失败，提示信息
                    Response.Write("<script>alert('删除失败，请重新删除！')</script>");
                }
            }
        }

        /// <summary>
        /// 页码的事件处理
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            pageIndex = Convert.ToInt32(e.CommandArgument);
            SearchUsers();
        }
    }
}