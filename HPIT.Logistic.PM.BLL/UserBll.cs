using HPIT.Logistic.PM.DAL;
using HPIT.Logistic.PM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.Logistic.PM.BLL
{
    public class UserBll
    {

        public UserDal dal = new UserDal();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public object LoginIn(string userName,string passWord)
        {
            //记录当前登录人的登录信息，加载收藏，加载订单
            return dal.LoginIn(userName,passWord);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserModel GetUserById(string id)
        {
            return dal.GetUserById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <param name="dateTime"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public List<UserModel> GetUsers(string account, DateTime dateTime, string roleName)
        {
            return dal.GetUserList(account,dateTime,roleName);
        }

        public int AddUser(UserModel model)
        {
            return dal.AddUser(model);
        }


        public int UpdateUser(UserModel model)
        {
            return dal.UpdateUser(model);
        }

        public int DeleteUser(int userId)
        {
            return dal.DeleteUser(userId);
        }

        public dynamic GetDynamicList()
        {
            return dal.GetDynamicList();
        }
    }
}
