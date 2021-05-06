using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareOS.SQLServerDAL.DBProcedure
{
    /// <summary>
    /// 存储过程: Report_Finance_BankPaymentSlip_By_IssueNumber .
    /// </summary>
    public class Report_Finance_BankPaymentSlip_By_IssueNumber
    {
        public string Text = "Report_Finance_BankPaymentSlip_By_IssueNumber";

        public SqlParameter PARM_IssueNumber = new SqlParameter("@IssueNumber", SqlDbType.Int);

    }
}
