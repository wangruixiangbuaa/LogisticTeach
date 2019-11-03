using HPIT.Logistic.PM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;

namespace HPIT.Logistic.PM.DAL
{
    public class RoleDal
    {

        public static RoleDal Instance = new RoleDal();
        public List<RoleModel> GetRoles()
        {
            string sql = "select * from [LogisticsDB].[dbo].[Role]";
            List<RoleModel> roles = new List<RoleModel>();
            SqlDataReader reader = DBHelper.ExcuteSqlDataReader(sql);
            roles.Add(new RoleModel() { RoleName = "请选择", RoleID = -1 });
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    RoleModel model = new RoleModel();
                    model.RoleID = Convert.ToInt32(reader["RoleID"]);
                    model.RoleName = reader["RoleName"].ToString();
                    model.RoleDesc = reader["RolePurview"].ToString();
                    roles.Add(model);
                }
            }
            return roles;
        }


        public dynamic GetDynamicList(string roleName)
        {
            //定义一个扩展的动态对象
            dynamic query = new ExpandoObject();
            //var param = new DynamicParameters();
            string sql = "select * from [Role] where 1=1 ";
            if (!string.IsNullOrEmpty(roleName))
            {
                query.role = roleName;
                sql += "and RoleName=@role";
            }
            var result = DapperDBHelper.Instance.ExcuteQuery<dynamic, dynamic>(sql, query);
            return result;
        }
    }
}
