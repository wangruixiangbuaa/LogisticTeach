using HPIT.Logistic.PM.BLL;
using HPIT.Logistic.PM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPIT.Logistic.PM.WebApp.Admin
{
    public partial class AddUser : System.Web.UI.Page
    {
        UserBll bll = new UserBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取浏览器地址里面的参数
                //根据用户id 加载用户信息
                if(Request.QueryString["id"] != null)
                {
                    UserModel userModel = bll.GetUserById(Request.QueryString["id"]);
                    //给界面上赋值
                    TextBox_UserName.Text = userModel.UserName;
                    TextBox_Account.Text = userModel.Account;
                    TextBox_Born.Text = userModel.CheckInTime.ToShortDateString();
                    TextBox_Password.Text = userModel.PassWord;
                    TextBox_Phone.Text = userModel.Phone;
                    TextBox_Email.Text = userModel.Email;
                }

            }
        }

        /// <summary>
        /// 添加
        /// 修改
        /// ui - bll -dal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Add_Click(object sender, EventArgs e)
        {
            UserModel model = new UserModel();
            model.UserName = TextBox_UserName.Text;
            model.Account = TextBox_Account.Text;
            model.CheckInTime = Convert.ToDateTime(TextBox_Born.Text);
            model.AlertTime = DateTime.Now;
            model.PassWord = TextBox_Password.Text;
            model.Phone = TextBox_Phone.Text;
            model.Email = TextBox_Email.Text;
            model.RoleId = 1;
            model.IsDelete = 0;
            //获取性别的值
            model.Sex =Convert.ToInt32(radlSex.SelectedItem.Value);
            UserBll bll = new UserBll();
            int result = 0;
            //与数据库进行交互
            if (Request.QueryString["id"] == null)
            {
                result = bll.AddUser(model);
            }
            else
            {
                //获取浏览器地址上的id 
                model.UserID = Convert.ToInt32(Request.QueryString["id"]);
                //然后调用更新方法，更新model
                result = bll.UpdateUser(model);
            }
            if (result > 0)
            {
                if (result == 100)
                {
                    ClientScript.RegisterStartupScript(GetType(), "", "alert('添加的用户已经存在！')", true);
                    return;
                }
                ClientScript.RegisterStartupScript(GetType(), "", "alert('保存成功！');window.location = 'UserList.aspx';", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "", "alert('保存失败！');", true);
            }

        }
    }
}