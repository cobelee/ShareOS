using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Insert_SharesIssueConfig .
    /// </summary>
    public class Insert_SharesIssueConfig
    {

        public string Text = "Insert_SharesIssueConfig";

        public SqlParameter PARM_IssueNumber = new SqlParameter("@IssueNumber", SqlDbType.Int);
        public SqlParameter PARM_IssueYear = new SqlParameter("@IssueYear", SqlDbType.Int);
        public SqlParameter PARM_Bonus = new SqlParameter("@Bonus", SqlDbType.Decimal, 9
);
        public SqlParameter PARM_DPD = new SqlParameter("@DPD", SqlDbType.DateTime, 8
);
        public SqlParameter PARM_SharePrice = new SqlParameter("@SharePrice", SqlDbType.Decimal, 9
);
    }
}
