using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Update_FundAccount .
    /// </summary>
    public class Update_FundAccount
    {

        public string Text = "Update_FundAccount";

        public SqlParameter PARM_FundAccountId = new SqlParameter("@FundAccountId", SqlDbType.Int);
        public SqlParameter PARM_IssueNumber = new SqlParameter("@IssueNumber", SqlDbType.Int);
        public SqlParameter PARM_ShareholderNumber = new SqlParameter("@ShareholderNumber", SqlDbType.Int);
        public SqlParameter PARM_ChangeMoney = new SqlParameter("@ChangeMoney", SqlDbType.Decimal, 5
);
        public SqlParameter PARM_ChangeReason = new SqlParameter("@ChangeReason", SqlDbType.NVarChar, 128
);
        public SqlParameter PARM_ChangeDate = new SqlParameter("@ChangeDate", SqlDbType.DateTime, 8
);
    }
}
