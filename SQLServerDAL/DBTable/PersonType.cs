using System;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBTable
{
    public class PersonType
    {
        public string Text = "PersonType";
        public Column PersonTypeName = new Column("PersonTypeName");
    }
}
