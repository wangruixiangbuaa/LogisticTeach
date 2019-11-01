using System;
using HPIT.Logistic.PM.DAL;
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
        public void TestMethod2()
        {
            UserDal dal = new UserDal();
            int total = 0;
            var result = dal.GetUsersWithPage(0, 5, out total);
        }
    }
}
