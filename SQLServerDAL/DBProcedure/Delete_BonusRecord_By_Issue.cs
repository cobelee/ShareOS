using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Delete_BonusRecord_By_Issue .
    /// </summary>
    public class Delete_BonusRecord_By_Issue
    {

        public string Text = "Delete_BonusRecord_By_Issue";

        public SqlParameter PARM_IssueNumber = new SqlParameter("@IssueNumber", SqlDbType.Int);
    }
}
