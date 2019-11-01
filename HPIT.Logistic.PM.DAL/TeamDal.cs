using HPIT.Logistic.PM.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.Logistic.PM.DAL
{
    public class TeamDal
    {
        public static TeamDal Instance = new TeamDal();
        public dynamic GetDynamicList(string teamName)
        {
            dynamic query = new System.Dynamic.ExpandoObject();
            string sql = "select * from TruckTeam where 1=1 ";
            if (!string.IsNullOrEmpty(teamName))
            {
                query.team = teamName;
                sql += "and TeamName=@team";
            }
            var result = DapperDBHelper.Instance.ExcuteQuery<dynamic, dynamic>(sql, query);
            return result;
        }
    }
}
