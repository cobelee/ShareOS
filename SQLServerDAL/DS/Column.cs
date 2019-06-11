using System;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL
{
    public class Column
    {
        private string mText;

        public string Text
        {
            get { return mText; }
            set { mText = value; }
        }

        public override string ToString()
        {
            return mText;
        }

        public Column(string columnName)
        {
            mText = columnName;
        }
    }
}
