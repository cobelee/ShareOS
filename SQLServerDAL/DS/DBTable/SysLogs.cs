using System;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DS.DBTable
{
    public class SysLogs
    {
        public string Text = "SysLogs";

        public Column LogId = new Column("LogId");
        public Column LogType = new Column("LogType");
        public Column LogDateTime = new Column("LogDateTime");
        public Column Source = new Column("Source");
        public Column Description = new Column("Description");
    }
}
