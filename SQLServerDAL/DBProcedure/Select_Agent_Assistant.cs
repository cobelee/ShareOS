using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Select_Agent_Assistant .
    /// </summary>
    public class Select_Agent_Assistant
    {

        public string Text = "Select_Agent_Assistant";

        public SqlParameter PARM_AgentShareholderNumber = new SqlParameter("@AgentShareholderNumber", SqlDbType.Int);
    }
}
