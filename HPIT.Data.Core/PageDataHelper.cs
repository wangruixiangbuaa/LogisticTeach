using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HPIT.Data.Core
{
    public class PageDataHelper
    {
        /// <summary>
        /// 查询总数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryPageModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IList<T> QueryWithPage<T>(QueryPageModel queryPageModel, T model)
        {
            string sqlBase = @"select * from (select *,row_number()over(order by {0}) as rownmber from 
                               {1} result 
                               where result.rownmber>{2} and result.rownmber<= {3}";
            string finalSql = string.Format(sqlBase, queryPageModel.OrderBy, queryPageModel.QuerySql, queryPageModel.PageIndex * queryPageModel.PageSize, (queryPageModel.PageIndex + 1) * queryPageModel.PageSize);
            //用dapperDbHelper 查询数据
            IList<T> result = DapperDBHelper.Instance.ExcuteQuery<T>(finalSql, model);
            return result;
        }


        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="queryPageModel"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static int QueryTotalCount<T>(QueryPageModel queryPageModel,T model)
        {
            string sqlBase = string.Format(@"(select count(*) from {0}",queryPageModel.QuerySql);
            int count = DapperDBHelper.Instance.ExcuteScalarQuery<T>(sqlBase, model);
            return count;
        }

        /// <summary>
        /// 获取分页的列表
        /// </summary>
        /// <param name="total"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static List<PageModel> GetPageList(int total,int pageSize)
        {
            int pageCount = total % pageSize == 0 ? total / pageSize : total / pageSize + 1;
            List<PageModel> pages = new List<PageModel>();
            for (int i = 0; i < pageCount; i++)
            {
                pages.Add(new PageModel()
                {
                    PageIndex = i,
                    PageSize = pageSize
                });
            }
            return pages;
        }
    }
}
