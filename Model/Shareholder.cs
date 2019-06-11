using System;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.Model
{
    public class Shareholder
    {
        private int mShareholderId;
        private int mShareholderNumber;
        private string mJobNumber;
        private string mShareholderName;
        private bool mSex;
        private string mIdentityCard;
        private string mPersonType;
        private ShareholderStatus mStatus;
        private int mEntrustedAgent;

        public int ShareholderId
        {
            get { return mShareholderId; }
            set { mShareholderId = value; }
        }
        public int ShareholderNumber
        {
            get { return mShareholderNumber; }
            set { mShareholderNumber = value; }
        }
        public string JobNumber
        {
            get { return mJobNumber; }
            set { mJobNumber = value; }
        }

        public string ShareholderName
        {
            get { return mShareholderName; }
            set { mShareholderName = value; }
        }

        public bool Sex
        {
            get { return mSex; }
            set { mSex = value; }
        }

        public string IdentityCard
        {
            get { return mIdentityCard; }
            set { mIdentityCard = value; }
        }

        public string PersonType
        {
            get { return mPersonType; }
            set { mPersonType = value; }
        }

        public ShareholderStatus Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }

        public int EntrustedAgent
        {
            get { return mEntrustedAgent; }
            set { mEntrustedAgent = value; }
        }

        public override string ToString()
        {
            return mShareholderName;
        }

        public void CopyTo(Shareholder shareholder)
        {
            if (shareholder != null)
            {
                shareholder.ShareholderId = this.mShareholderId;
                shareholder.ShareholderNumber = this.mShareholderNumber;
                shareholder.JobNumber = this.mJobNumber;
                shareholder.ShareholderName = this.mShareholderName;
                shareholder.Sex = this.mSex;
                shareholder.IdentityCard = this.mIdentityCard;
                shareholder.PersonType = this.mPersonType;
                shareholder.Status = this.mStatus;
                shareholder.EntrustedAgent = this.mEntrustedAgent;
            }
        }
    }
}
