using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: GenerateSettlementRecord_Mass .
    /// </summary>
    public class GenerateSettlementRecord_Mass
    {
        public string Text = "GenerateSettlementRecord_Mass";

        public SqlParameter PARM_IssueNumber = new SqlParameter("@IssueNumber", SqlDbType.Int);
    }
}
