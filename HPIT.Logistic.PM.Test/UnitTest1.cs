using System;
using System.Collections.Generic;
using HPIT.Logistic.PM.DAL;
using HPIT.Logistic.PM.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HPIT.Logistic.PM.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserDal dal = new UserDal();
            int total = 0;
            var result = dal.GetTeams(0,3,out total);
        }


        [TestMethod]
        public void TestMethodPage()
        {
            TruckDal dal = new TruckDal();
            int totalCount = 0;
            List<TruckModel> result = dal.GetTrucks(1,5,out totalCount);
        }

        [TestMethod]
        public void TestMethoddtPage()
        {
            TruckDal dal = new TruckDal();
            int totalCount = 0;
            var result = dal.GetDtTrucks(1, 5, out totalCount);
        }



        [TestMethod]
        public void TestMethod2()
        {
            UserDal dal = new UserDal();
            int total = 0;
            var result = dal.GetUsersWithPage(0, 5, out total);
        }


        [TestMethod]
        public void TestInsert()
        {
            UserModel model = new UserModel()
            {
                Email = "627730788@qq.com",
                Account = "wrx",
                CheckInTime = DateTime.Now,
                IsDelete = 0,
                Phone = "17700611332",
                AlertTime = DateTime.Now,
                PassWord = "123",
                RoleId = 1,
                FK_RoleID = 1,
                Sex = 1,
                UserName = "李白"

            };
            var result = DapperDBHelper.Instance.ExcuteInsert<UserModel>(@"insert into [LogisticsDB].[dbo].[User] 
                                                                        (UserName,Sex,Account,Phone,Email,PassWord,CheckInTime,FK_RoleID,IsDelete,AlterTime) values 
                                                                        (@UserName,@Sex,@Account,@Phone,@Email,@PassWord,
                                                                         @CheckInTime,@FK_RoleID,@IsDelete,@AlertTime)", model);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void TestDelete()
        {
            var result = DapperDBHelper.Instance.ExcuteInsert<dynamic>(@"delete from  [User] 
                                                                       where UserID=@ID", new { ID = 83 });
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void TestMethodQuery()
        {
            var result = DapperDBHelper.Instance.ExcuteQuery<UserModel>("select * from [User] where Email like @Email", new UserModel { Email = "%cn" });
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void TestMethodQuery2()
        {
            Int32[] ids = new Int32[] { 1, 4, 5 };
            var result = DapperDBHelper.Instance.ExcuteQuery<dynamic,UserModel>("select * from [User] where UserID in @ids", new { ids });
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void TestMethodQuery3()
        {
            Int32[] ids = new Int32[] { 1, 4, 5 };
            var result = DapperDBHelper.Instance.ExcuteQuery<dynamic, dynamic>(@"select * from (select *,(select RoleName from [Role] where RoleID = u.FK_RoleID ) as RoleName  from [User] u) t
                                                                                 where t.UserID not in @ids and t.RoleName=@roleName", new { ids,roleName="系统管理员" });
            Assert.AreNotEqual(0, result);
        }
    }
}
