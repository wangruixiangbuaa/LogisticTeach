using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using HPIT.Logistic.PM.Model;

namespace HPIT.Logistic.PM.DAL
{
    public class PageDataHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryPageModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IList<T> QueryWithPage<T>(QueryPageModel queryPageModel, T model)
        {
            string sqlBase = @"select * from (select *,row_number()over(order by {0}) as rownmber from 
                               {1} result 
                               where result.rownmber>={2} and result.rownmber<= {3}";
            string finalSql = string.Format(sqlBase, queryPageModel.OrderBy, queryPageModel.QuerySql, queryPageModel.PageIndex * queryPageModel.PageSize, (queryPageModel.PageIndex + 1) * queryPageModel.PageSize);
            //用dapperDbHelper 查询数据
            IList<T> result = DapperDBHelper.Instance.ExcuteQuery<T>(finalSql, model);
            return result;
        }

        public static int QueryTotalCount(QueryPageModel queryPageModel,params SqlParameter[] sqlParameters)
        {
            string sqlBase = string.Format(@"(select count(*) from {0}",queryPageModel.QuerySql);
            object count = DBHelper.ExcuteScalar(sqlBase,sqlParameters);
            if (count != null)
            {
                return Convert.ToInt32(count);
            }
            else
            {
                return 0;
            }
        }
    }
}
