using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Insert_PersonType .
    /// </summary>
    public class Insert_PersonType
    {

        public string Text = "Insert_PersonType";

        public SqlParameter PARM_PersonTypeName = new SqlParameter("@PersonTypeName", SqlDbType.NVarChar, 64
);
    }
}
