using HPIT.Logistic.PM.BLL;
using HPIT.Logistic.PM.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPIT.Logistic.PM.WebApp
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                //从session 里面取用户id
                UserModel model = GetUserByID(Convert.ToInt32(Session["userID"]));
                //Label_User.Text = model.UserName;
                Label_UserName.Text = model.UserName;
                Label_UserName2.Text = model.UserName;
                Label_UserName3.Text = model.UserName;
            }
        }

        /// <summary>
        /// 根据用户ID 查询用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserModel GetUserByID(int userId)
        {
            UserModel model = new UserModel();
            UserBll bll = new UserBll();
            model = bll.GetUserById(userId.ToString());
            return model;
        }

    }
}