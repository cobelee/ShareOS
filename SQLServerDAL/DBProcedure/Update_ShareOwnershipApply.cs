using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Update_ShareOwnershipApply .
    /// </summary>
    public class Update_ShareOwnershipApply
    {

        public string Text = "Update_ShareOwnershipApply";

        public SqlParameter PARM_IssueNumber = new SqlParameter("@IssueNumber", SqlDbType.Int);
        public SqlParameter PARM_ShareholderNumber = new SqlParameter("@ShareholderNumber", SqlDbType.Int);
        public SqlParameter PARM_SharesAmount = new SqlParameter("@SharesAmount", SqlDbType.Int);
        public SqlParameter PARM_DateOfApply = new SqlParameter("@DateOfApply", SqlDbType.DateTime, 8
);
    }
}
