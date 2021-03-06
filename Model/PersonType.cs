using System;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.Model
{
    /// <summary>
    /// 股东人员类别。
    /// </summary>
    [Serializable]
    public class PersonType
    {
        private String mPersonTypeName;        // 人员类别名称

        public PersonType()
        {
            InitPersonType();
        }

        private void InitPersonType()
        {
            mPersonTypeName = string.Empty;
        }

        /// <summary>
        /// 人员类别名称
        /// </summary>
        public string PersonTypeName
        {
            get { return mPersonTypeName; }
            set { mPersonTypeName = value; }
        }

        public override string ToString()
        {
            return mPersonTypeName;
        }
    }
}
