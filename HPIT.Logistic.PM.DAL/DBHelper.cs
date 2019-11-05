﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace HPIT.Logistic.PM.DAL
{
    public class DBHelper
    {
        //读取连接字符串
        public static readonly string connStr = ConfigurationManager.ConnectionStrings["LogisticsDB"].ConnectionString;
        /// <summary>
        /// 查询首行首列的方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static object ExcuteScalar(string sql,params SqlParameter[] sqlParameters)
        {
            //创建连接
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                //创建命令
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    //判断连接是否打开，如果关闭状态，则打开，如果打开状态，直接跳过，执行命令
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    //添加参数
                    command.Parameters.AddRange(sqlParameters);
                    //返回结果
                    return command.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 查询列表结果
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExcuteSqlDataReader(string sql,params SqlParameter[] sqlParameters)
        {
            //创建连接
                SqlConnection connection = new SqlConnection(connStr);
                //创建命令
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    //执行
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    //添加参数
                    command.Parameters.AddRange(sqlParameters);
                    //返回结果,及时关闭掉连接
                    return command.ExecuteReader(CommandBehavior.CloseConnection);
                }
        }

        /// <summary>
        /// 调用存储过程
        /// </summary>
        /// <param name="proName"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExcuteSqlDataReaderProc(string proName, SqlParameter[] sqlParameters)
        {
            //创建连接
            SqlConnection connection = new SqlConnection(connStr);
            //创建命令
            using (SqlCommand command = new SqlCommand(proName, connection))
            {
                //执行
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //设置查询方式是存储过程。
                command.CommandType = CommandType.StoredProcedure;
                //添加参数
                command.Parameters.AddRange(sqlParameters);
                //返回结果,及时关闭掉连接
                return command.ExecuteReader();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proName"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static DataTable ExcuteDataTableProc(string proName, SqlParameter[] sqlParameters)
        {
            //创建连接
            SqlConnection connection = new SqlConnection(connStr);
            //创建命令
            using (SqlCommand command = new SqlCommand(proName, connection))
            {
                //执行
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //设置查询方式是存储过程。
                command.CommandType = CommandType.StoredProcedure;
                //添加参数
                command.Parameters.AddRange(sqlParameters);
                //返回结果,及时关闭掉连接
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }




        /// <summary>
        /// 执行插入，删除，更新的方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static int ExcuteSqlNonQuery(string sql, SqlParameter[] sqlParameters)
        {
            //创建连接
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                //创建命令
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    //判断连接是否打开，如果连接是关闭状态，则需要打开连接
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    //添加参数
                    command.Parameters.AddRange(sqlParameters);
                    //返回结果,及时关闭掉连接
                    return command.ExecuteNonQuery();
                }
            }
        }



    }
}