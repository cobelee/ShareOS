using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Select_ShareOwnership_Change_By_IssueNumber .
    /// </summary>
    public class Select_ShareOwnership_Change_By_IssueNumber
    {

        public string Text = "Select_ShareOwnership_Change_By_IssueNumber";

        public SqlParameter PARM_IssueNumber = new SqlParameter("@IssueNumber", SqlDbType.Int);
    }
}
