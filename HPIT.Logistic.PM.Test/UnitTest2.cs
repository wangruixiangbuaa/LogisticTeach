using HPIT.Logistic.PM.DAL;
using HPIT.Logistic.PM.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.Logistic.PM.Test
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserDal dal = new UserDal();
            int total = 0;
            UserModel userModel = new UserModel();
            var result = dal.GetNewUserPageList(1, 5,userModel, out total);
        }
    }
}
