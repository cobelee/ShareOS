using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Insert_EntrustedAgent .
    /// </summary>
    public class Insert_EntrustedAgent
    {

        public string Text = "Insert_EntrustedAgent";

        public SqlParameter PARM_ShareholderNumber = new SqlParameter("@ShareholderNumber", SqlDbType.Int);
    }
}
