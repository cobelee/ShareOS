using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Update_Shareholder_AgentRelation .
    /// </summary>
    public class Update_Shareholder_AgentRelation
    {

        public string Text = "Update_Shareholder_AgentRelation";

        public SqlParameter PARM_ShareholderId = new SqlParameter("@ShareholderId", SqlDbType.Int);
        public SqlParameter PARM_EntrustedAgent = new SqlParameter("@EntrustedAgent", SqlDbType.Int);
    }
}
