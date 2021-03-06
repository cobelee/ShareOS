using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Insert_SysLogs .
    /// </summary>
    public class Insert_SysLogs
    {

        public string Text = "Insert_SysLogs";

        public SqlParameter PARM_LogType = new SqlParameter("@LogType", SqlDbType.NVarChar, 32
);
        public SqlParameter PARM_LogDateTime = new SqlParameter("@LogDateTime", SqlDbType.DateTime, 8
);
        public SqlParameter PARM_Source = new SqlParameter("@Source", SqlDbType.NVarChar, 32
);
        public SqlParameter PARM_Description = new SqlParameter("@Description", SqlDbType.NVarChar, 256
);
    }
}
