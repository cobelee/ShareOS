using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Delete_Agent_Assistant .
    /// </summary>
    public class Delete_Agent_Assistant
    {

        public string Text = "Delete_Agent_Assistant";

        public SqlParameter PARM_AgentShareholderNumber = new SqlParameter("@AgentShareholderNumber", SqlDbType.Int);
        public SqlParameter PARM_AssistantJobNumber = new SqlParameter("@AssistantJobNumber", SqlDbType.NChar, 12
);
    }
}
