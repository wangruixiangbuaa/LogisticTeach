﻿using HPIT.Logistic.PM.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.Logistic.PM.DAL
{
    public class UserDal
    {
        /// <summary>
        /// 登录验证的方法
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public object LoginIn(string userName, string passWord)
        {
            //与数据库操作的步骤
            string sql = "select * from[LogisticsDB].[dbo].[User] where UserName=@username AND Password=@password ";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@username", userName);
            sqlParameters[1] = new SqlParameter("@password", passWord);
            //5.执行命令，返回结果
            object result = DBHelper.ExcuteScalar(sql, sqlParameters);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserModel GetUserById(string id)
        {
            UserModel model = new UserModel();
            //根据用户id 查询用户信息
            string sql = "select * from[LogisticsDB].[dbo].[User] where UserID=@ID ";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", id);
            //5.执行命令，返回结果
            SqlDataReader reader = DBHelper.ExcuteSqlDataReader(sql, sqlParameters);
            //判断有没有读到数据，hasRows 有没有行数据
            if (reader.HasRows)
            {
                //读取第一条数据
                while (reader.Read())
                {
                    model.UserName = reader["UserName"].ToString();
                    model.PassWord = reader["Password"].ToString();
                    model.UserID = int.Parse(reader["UserID"].ToString());
                    model.Sex = Convert.ToInt32(reader["Sex"]);
                    model.Account = reader["Account"].ToString();
                    model.Phone = reader["Phone"].ToString();
                    model.Email = reader["Email"].ToString();
                    model.CheckInTime = Convert.ToDateTime(reader["CheckInTime"]);
                }
            }
            //返回结果
            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UserModel> GetUserList(string account,DateTime dateTime,string roleName)
        {
            string sql = @"select *,(select RoleName from [LogisticsDB].[dbo].[Role] where RoleID = u.FK_RoleID ) as roleName 
                         from[LogisticsDB].[dbo].[User] u where IsDelete != 1 And CheckInTime<@time ";
            //SqlParameter[] sqlParameters = new SqlParameter[3];
            List<SqlParameter> parmsList = new List<SqlParameter>();
            //不是空或null字符串添加参数
            if (!string.IsNullOrEmpty(account))
            {
                sql += " and Account=@account ";
                parmsList.Add(new SqlParameter("@account", account));
            }
            if (!string.IsNullOrEmpty(roleName))
            {
                sql += " and FK_RoleID=@roleId ";
                parmsList.Add(new SqlParameter("@roleID", roleName));
            }
            parmsList.Add(new SqlParameter("@time",dateTime));
            SqlDataReader reader = DBHelper.ExcuteSqlDataReader(sql,parmsList.ToArray());
            //判断有没有读到数据，hasRows 有没有行数据
            List<UserModel> users = new List<UserModel>();
            if (reader.HasRows)
            {
                //读取第一条数据
                while (reader.Read())
                {
                    UserModel model = new UserModel();
                    model.UserName = reader["UserName"].ToString();
                    model.PassWord = reader["Password"].ToString();
                    model.Phone = reader["Phone"].ToString();
                    model.Account = reader["Account"].ToString();
                    model.UserID = int.Parse(reader["UserID"].ToString());
                    model.CheckInTime = Convert.ToDateTime(reader["CheckInTime"]);
                    model.ImagePath = reader["ImagePath"].ToString();
                    model.Sex = Convert.ToInt32(reader["Sex"]);
                    model.RoleName = reader["roleName"].ToString();
                    users.Add(model);
                }
            }
            return users;
        }

        public int AddUser(UserModel model)
        {
            //定义一个插入语句
            string sql = @"insert into [LogisticsDB].[dbo].[User] 
                          (UserName,Account,Sex,Phone,Email,Password,FK_RoleID,CheckInTime,AlterTime,IsDelete)
                   values (@name,@account,@sex,@phone,@email,@password,@roleid,@check,@alter,@isdelete)";
            //添加参数
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@name", model.UserName));
            parameters.Add(new SqlParameter("@account", model.Account));
            parameters.Add(new SqlParameter("@sex", model.Sex));
            parameters.Add(new SqlParameter("@phone", model.Phone));
            parameters.Add(new SqlParameter("@email", model.Email));
            parameters.Add(new SqlParameter("@password", model.PassWord));
            parameters.Add(new SqlParameter("@roleid", model.RoleId));
            parameters.Add(new SqlParameter("@check", model.CheckInTime));
            parameters.Add(new SqlParameter("@alter", model.AlertTime));
            parameters.Add(new SqlParameter("@isdelete", model.IsDelete));
            //调用DBhelper执行插入语句
            //去重，判断又没有相同的用户
            string sqlExist = "select UserID from [LogisticsDB].[dbo].[User] where UserName=@name";
            SqlParameter[] exPam = new SqlParameter[1];
            exPam[0] = new SqlParameter("@name",model.UserName);
            object exObj = DBHelper.ExcuteScalar(sqlExist,exPam);
            int result = 0;
            //存在已经有的用户,不=null 存在用户
            if (exObj != null)
            {
                result = 100;
                return result;
            }
            result = DBHelper.ExcuteSqlNonQuery(sql,parameters.ToArray());
            //返回结果
            return result;
        }

        public int UpdateUser(UserModel model)
        {
            //定义一个插入语句
            string sql = @"update [LogisticsDB].[dbo].[User] 
                          set UserName=@name,Account=@account,Sex=@sex,Phone=@phone,Email=@email,
                          Password=@password,FK_RoleID=@roleid,CheckInTime=@check,AlterTime=@alter,IsDelete=@isdelete where UserID=@id";
            //添加参数
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@name", model.UserName));
            parameters.Add(new SqlParameter("@account", model.Account));
            parameters.Add(new SqlParameter("@sex", model.Sex));
            parameters.Add(new SqlParameter("@phone", model.Phone));
            parameters.Add(new SqlParameter("@email", model.Email));
            parameters.Add(new SqlParameter("@password", model.PassWord));
            parameters.Add(new SqlParameter("@roleid", model.RoleId));
            parameters.Add(new SqlParameter("@check", model.CheckInTime));
            parameters.Add(new SqlParameter("@alter", model.AlertTime));
            parameters.Add(new SqlParameter("@isdelete", model.IsDelete));
            parameters.Add(new SqlParameter("@id", model.UserID));
            //执行更新 返回结果
            int result = DBHelper.ExcuteSqlNonQuery(sql,parameters.ToArray());
            return result;
        }

        /// <summary>
        /// 数据软删除，更新IsDelete为1则为删除
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int DeleteUser(int userID)
        {
            string sql = "update [LogisticsDB].[dbo].[User] set IsDelete = 1 where UserID=@id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", userID);
            int result = DBHelper.ExcuteSqlNonQuery(sql,sqlParameters);
            return result;
        }

    }
}
