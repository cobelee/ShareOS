using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Delete_EntrustedAgent .
    /// </summary>
    public class Delete_EntrustedAgent
    {

        public string Text = "Delete_EntrustedAgent";

        public SqlParameter PARM_ShareholderNumber = new SqlParameter("@ShareholderNumber", SqlDbType.Int);
    }
}
