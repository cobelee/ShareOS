using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Select_ShareIssueConfig_One .
    /// </summary>
    public class Select_ShareIssueConfig_One
    {

        public string Text = "Select_ShareIssueConfig_One";

        public SqlParameter PARM_IssueNumber = new SqlParameter("@IssueNumber", SqlDbType.Int);
    }
}
