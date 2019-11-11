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

        [TestMethod]
        public void TestMethod2()
        {
            string str1 = "hello {0} world {1}";
            string str2 = "欢迎 来到";
            string str3 = "参数";
            string str4 = string.Format(str1,str2,str3);
        }
    }
}
