using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Update_PersonType .
    /// </summary>
    public class Update_PersonType
    {

        public string Text = "Update_PersonType";

        public SqlParameter PARM_OldPersonTypeName = new SqlParameter("@OldPersonTypeName", SqlDbType.NVarChar, 64
);
        public SqlParameter PARM_NewPersonTypeName = new SqlParameter("@NewPersonTypeName", SqlDbType.NVarChar, 64
);
    }
}
