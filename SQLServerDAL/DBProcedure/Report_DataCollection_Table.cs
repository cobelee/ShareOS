using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Report_DataCollection_Table .
    /// </summary>
    public class Report_DataCollection_Table
    {
        public string Text = "Report_DataCollection_Table";

        public SqlParameter PARM_IssueNumber = new SqlParameter("@IssueNumber", SqlDbType.Int);
    }
}
