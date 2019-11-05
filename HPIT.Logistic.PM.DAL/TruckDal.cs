using HPIT.Logistic.PM.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace HPIT.Logistic.PM.DAL
{
    public class TruckDal
    {
        public static TruckDal Instance = new TruckDal();
        public dynamic GetDynamicList(string teamName)
        {
            //定义一个扩展的动态对象
            dynamic query = new ExpandoObject();
            //var param = new DynamicParameters();
            string sql = "select * from Truck where 1=1 ";
            if (!string.IsNullOrEmpty(teamName))
            {
                query.team = teamName;
                sql += "and Type=@type";
            }
            var result = DapperDBHelper.Instance.ExcuteQuery<dynamic, dynamic>(sql, query);
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TruckModel> GetTrucks(int pageIndex,int pageSize,out int totalCount)
        {
            //初始化输出参数
            totalCount = 0;
            string proName = "QueryTruckProc";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                 new SqlParameter("@PageIndex",pageIndex),
                 new SqlParameter("@PageSize",pageSize),
                 new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            //设置参数是输出参数，Output
            sqlParameters[2].Direction = ParameterDirection.Output;
            //调用dbHelper 存储过程方法
            SqlDataReader reader = DBHelper.ExcuteSqlDataReaderProc(proName,sqlParameters);
            //获取参数的值
            //处理reader的内容，转换reader-》List
            List<TruckModel> truckList = new List<TruckModel>();
            //判断有没有数据
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TruckModel model = new TruckModel();
                    model.Number = reader["Number"].ToString();
                    model.Type = reader["Type"].ToString();
                    //将创建的model 添加到list里面
                    truckList.Add(model);
                }
            }
            //关闭reader游标
            reader.Close();
            //获取参数的值.
            totalCount = Convert.ToInt32(sqlParameters[2].Value);
            //返回结果list
            return truckList;
        }

        public DataTable GetDtTrucks(int pageIndex, int pageSize, out int totalCount)
        {
            //初始化输出参数
            totalCount = 0;
            string proName = "QueryTruckProc";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                 new SqlParameter("@PageIndex",pageIndex),
                 new SqlParameter("@PageSize",pageSize),
                 new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            //设置参数是输出参数，Output
            sqlParameters[2].Direction = ParameterDirection.Output;
            //调用dbHelper 存储过程方法
            DataTable dt = DBHelper.ExcuteDataTableProc(proName, sqlParameters);
            //获取参数的值
            totalCount = Convert.ToInt32(sqlParameters[2].Value);
            //返回结果list
            return dt;
        }
    }
}
