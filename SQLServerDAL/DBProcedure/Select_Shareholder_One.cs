using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Select_Shareholder_One .
    /// </summary>
    public class Select_Shareholder_One
    {

        public string Text = "Select_Shareholder_One";

        public SqlParameter PARM_ShareholderNumber = new SqlParameter("@ShareholderNumber", SqlDbType.Int);
    }
}
