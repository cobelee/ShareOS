using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: GenerateClearingRecord_Mass .
    /// </summary>
    public class GenerateClearingRecord_Mass
    {
        public string Text = "GenerateClearingRecord_Mass";

        public SqlParameter PARM_IssueNumber = new SqlParameter("@IssueNumber", SqlDbType.Int);
    }
}
