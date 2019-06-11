using System;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.Model
{
    /// <summary>
    /// 系统登陆账户。
    /// </summary>
    [Serializable]
    public class Account
    {
        /// <summary>
        /// 用户帐户Id.
        /// </summary>
        private int mId;
        
        /// <summary>
        /// 用户帐户名称。
        /// </summary>
        private string mUserName;
        
        /// <summary>
        /// 用户帐户密码。
        /// </summary>
        private string mPassword;
        
        /// <summary>
        /// 用户账户类型。
        /// </summary>
        private string mUserType;

        /// <summary>
        /// 账户使用人员真实姓名。
        /// </summary>
        private string mTrueName;

        public Account()
        {
            InitAccount();
        }

        private void InitAccount()
        {
            mUserName = string.Empty;
            mPassword = string.Empty;
            mUserType = string.Empty;
            mTrueName = string.Empty;
        }

        public int Id
        {
            get { return mId; }
            set { mId = value; }
        }

        public string UserName
        {
            get { return mUserName; }
            set { mUserName = value; }
        }

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public string UserType
        {
            get { return mUserType; }
            set { mUserType = value; }
        }

        public string TrueName
        {
            get { return mTrueName; }
            set { mTrueName = value; }
        }

    }
}
