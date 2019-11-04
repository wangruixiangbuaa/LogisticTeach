using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.Logistic.PM.DAL
{
    public class DriverDal
    {
        public static DriverDal Instance = new DriverDal();
        public dynamic GetDynamicList(string teamName)
        {
            //定义一个扩展的动态对象
            dynamic query = new ExpandoObject();
            //var param = new DynamicParameters();
            string sql = "select * from Driver where 1=1 ";
            if (!string.IsNullOrEmpty(teamName))
            {
                query.team = teamName;
                sql += "and Name=@team";
            }
            var result = DapperDBHelper.Instance.ExcuteQuery<dynamic, dynamic>(sql, query);
            return result;
        }
    }
}
