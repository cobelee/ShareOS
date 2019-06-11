using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareOS.BLL
{
    public class PersonClearingReportItem
    {

        public string 姓名 { get; set; }
        public int 股东号 { get; set; }
        public System.Data.Linq.Binary BarCode { get; set; }
        public string 工号 { get; set; }
        public string 性别 { get; set; }
        public string 身份证号 { get; set; }
        public string 人员类别 { get; set; }
        public string 代理人 { get; set; }
        public string 所在单位 { get; set; }

        public DateTime 退出时间 { get; set; }
        public decimal 退出股权数 { get; set; }
        public decimal 交易价格 { get; set; }
        public decimal 总股值 { get; set; }
        public decimal 个人出资 { get; set; }
        public decimal 税前收益 { get; set; }
        public decimal 个人所得税 { get; set; }
        public decimal 实际回款 { get; set; }

    }
}
