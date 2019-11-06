using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.Data.Core
{
    public class QueryPageModel
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int PageCount { get; set; }

        public int CurrentPageIndex { get; set; }

        public string OrderBy { get; set; }

        public string OrderByType { get; set; }

        public string QuerySql { get; set; }
    }
}
