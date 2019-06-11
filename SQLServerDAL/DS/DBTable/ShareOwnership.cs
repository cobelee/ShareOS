using System;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DS.DBTable
{
    public class ShareOwnership
    {
        public string Text = "ShareOwnership";

        public Column RegId = new Column("RegId");
        public Column ShareholderNumber = new Column("ShareholderNumber");
        public Column SharesChanges = new Column("SharesChanges");
        public Column ShareTotals = new Column("ShareTotals");
        public Column RegDate = new Column("RegDate");
        public Column Operator = new Column("Operator");
    }
}
