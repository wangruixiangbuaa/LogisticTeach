using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPIT.Logistics.PM.Model
{
    public class TruckTeamModel
    {
        /// <summary>
        /// 车队Id
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// 车队名称
        /// </summary>
        public string TeamName { get; set; }

        /// <summary>
        /// 车队负责人
        /// </summary>
        public string Leader { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CheckInTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime AlterTime { get; set; }
    }
}
