using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Select_ShareOwnership_Withdrawal_Record .
    /// </summary>
    public class Select_ShareOwnership_Withdrawal_Record
    {

        public string Text = "Select_ShareOwnership_Withdrawal_Record";

        public SqlParameter PARM_BeginDate = new SqlParameter("@BeginDate", SqlDbType.DateTime, 8
);
        public SqlParameter PARM_EndDate = new SqlParameter("@EndDate", SqlDbType.DateTime, 8
);
    }
}
