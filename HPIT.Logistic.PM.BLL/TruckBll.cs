using HPIT.Logistic.PM.DAL;
using HPIT.Logistic.PM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.Logistic.PM.BLL
{
    public class TruckBll
    {
        public List<TruckModel> GetTrucksWithPage(int pageIndex, int pageSize, out int totalCount)
        {
            TruckDal dal = new TruckDal();
            return dal.GetTrucks(pageIndex,pageSize,out totalCount);
        }
    }
}
