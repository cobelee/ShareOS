using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Select_Person_Bonus_Record .
    /// </summary>
    public class Select_Person_Bonus_Record
    {

        public string Text = "Select_Person_Bonus_Record";

        public SqlParameter PARM_ShareholderNumber = new SqlParameter("@ShareholderNumber", SqlDbType.Int);
    }
}
