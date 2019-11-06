using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.Data.Core
{
    public class PageModel
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int CurrentIndex { get; set; }

        public int ShowIndex { get; set; }
    }
}
