using System;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBTable
{
    public class SharesIssueConfig
    {
        public string Text = "SharesIssueConfig";

        public Column SICId = new Column("SICId");
        public Column IssueNumber = new Column("IssueNumber");
        public Column IssueYear = new Column("IssueYear");
        public Column Bonus = new Column("Bonus");
        public Column DPD = new Column("DPD");
        public Column SharePrice = new Column("SharePrice");
        public Column IsDistributed = new Column("IsDistributed");
    }
}
