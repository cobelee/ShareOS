using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShareOS.IDAL;

namespace ShareOS.BLL
{
    public class ShareOwnershipManage
    {
        private IShareOwnership dal = ShareOS.DALFactory.DataAccess.CreateShareOwnership();
        private Tiyi.ShareOS.SQLServerDAL.ShareOwnershipDA daShareOwnership = new Tiyi.ShareOS.SQLServerDAL.ShareOwnershipDA();
        private Tiyi.ShareOS.SQLServerDAL.ShareIssueConfigDA daConfig = new Tiyi.ShareOS.SQLServerDAL.ShareIssueConfigDA();
        public void Dispose()
        {
            daShareOwnership.Dispose();
            daConfig.Dispose();
        }

        protected bool Change(int shareholderNumber, decimal sharesChanges, decimal originalSharePrice, string causeOfChange, bool isPrincipal, string operatorName)
        {
            return daShareOwnership.ChangeGuQuanShu(shareholderNumber, sharesChanges, originalSharePrice, causeOfChange, isPrincipal, operatorName);
        }

        /// <summary>
        /// �Թɶ����еĹ���Ϊ��������һ�����ɹɱ��������йɶ��ɷ���ɡ�
        /// </summary>
        /// <param name="issueNumber">��Ȩ����������</param>
        /// <param name="rationScale">�ɹɱ�������100������8�ɣ����ɹɱ�����0.08��</param>
        /// <param name="sharePrice">�ɹɵĹɼۣ�Ҳ���ǵ��ڵĹɼۡ�</param>
        /// <param name="operatorName">������Ա��</param>
        public void ScalRationedShares(int issueNumber, decimal rationScale, decimal sharePrice, string operatorName)
        {
            dal.ScalRationedShares(issueNumber, rationScale, sharePrice, operatorName);
        }

        /// <summary>
        /// ������Ȩ����������
        /// </summary>
        /// <param name="regId">��Ȩ������¼�š�</param>
        /// <returns></returns>
        public bool CancelChange(int regId)
        {
            return dal.CancelChange(regId);
        }

        /// <summary>
        /// ��ȡ���йɶ���Ȩ���档
        /// </summary>
        /// <returns></returns>
        public DataTable GetShareOwnershipReport(int issueNumber)
        {
            return daShareOwnership.GetShareOwnershipReport(issueNumber);
        }

        /// <summary>
        /// ��ȡѡ���ɶ��Ĺ�Ȩ����
        /// </summary>
        /// <param name="shareholderNumbers">�ɶ����б�</param>
        /// <returns></returns>
        public DataTable GetShareOwnershipReport(int[] shareholderNumbers)
        {
            return daShareOwnership.GetShareOwnershipReportTable(shareholderNumbers);
        }

        /// <summary>
        /// ��ȡָ���ɶ������˹�Ȩ��¼��
        /// </summary>
        /// <param name="sharehoderNumber">�ɶ��š�</param>
        /// <returns></returns>
        public Tiyi.ShareOS.SQLServerDAL.ShareOwnership GetPersonalClearingRecord(int sharehoderNumber)
        {
            return daShareOwnership.GetPersonalClearingRecord(sharehoderNumber);
        }

        /// <summary>
        /// ��ȡ�����Ȩ�����ܳ��ʶ�
        /// </summary>
        /// <param name="shareholderNumber">�ɶ���</param>
        /// <returns></returns>
        public decimal GetPersonalSharesOriginalValue(int shareholderNumber)
        {
            return daShareOwnership.GetPersonalSharesOriginalValue(shareholderNumber);
        }

        public List<PersonClearingReportItem> GetPersonClearingReport(int[] shareholderNumbers)
        {
            List<Tiyi.ShareOS.SQLServerDAL.ShareholderCurrentShares> personShareReport = daShareOwnership.GetShareOwnershipReport(shareholderNumbers);

            List<PersonClearingReportItem> clearingReport = new List<PersonClearingReportItem>();
            foreach (Tiyi.ShareOS.SQLServerDAL.ShareholderCurrentShares sh in personShareReport)
            {
                PersonClearingReportItem item = new PersonClearingReportItem();
                item.���� = sh.ShareholderName;
                item.�ɶ��� = sh.ShareholderNumber;
                item.BarCode = sh.BarCode;
                item.���� = sh.JobNumber;
                item.�Ա� = sh.Sex ? "��" : "Ů";
                item.����֤�� = sh.IdentityCard;
                item.��Ա��� = sh.PersonType;
                item.������ = sh.EntrustedAgentName;
                item.���ڵ�λ = sh.Department;

                Tiyi.ShareOS.SQLServerDAL.ShareOwnership record = this.GetPersonalClearingRecord(item.�ɶ���);
                if (record != null)
                {
                    item.�˳�ʱ�� = record.RegDate.Value;
                    item.�˳���Ȩ�� = System.Math.Abs(record.SharesChanges.Value);
                    item.���׼۸� = record.OriginalSharePrice.Value;
                    item.�ܹ�ֵ = item.�˳���Ȩ�� * item.���׼۸�;
                    item.���˳��� = this.GetPersonalSharesOriginalValue(item.�ɶ���);
                    item.˰ǰ���� = item.�ܹ�ֵ - item.���˳���;
                    item.��������˰ = item.˰ǰ���� * 0.2m;  // ��������˰���������
                    item.ʵ�ʻؿ� = item.�ܹ�ֵ - item.��������˰;
                }
                else
                {
                    item.�˳�ʱ�� = DateTime.Now;
                    item.�˳���Ȩ�� = 0m;
                    item.���׼۸� = 0m;
                    item.�ܹ�ֵ = 0m;
                    item.���˳��� = 0m;
                    item.˰ǰ���� = 0m;
                    item.��������˰ = 0m;  // ��������˰���������
                    item.ʵ�ʻؿ� = 0m;
                }
                clearingReport.Add(item);

            }
            return clearingReport;
        }

        /// <summary>
        /// ��ȡ���йɶ��ڳ���Ȩ���档
        /// </summary>
        /// <param name="issueNumber">��Ȩ��������</param>
        /// <returns></returns>
        //public DataTable GetQichuShareOwnership(int issueNumber)
        //{
        //    return daShareOwnership.GetQichuShareOwnership(issueNumber);
        //}

        /// <summary>
        /// ��ȡ�ɶ����˵Ĺ�Ȩ������ʷ��¼���档
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <returns></returns>
        public DataTable GetPersonalShareOwnershipReport(int shareholderNumber)
        {
            return dal.GetPersonalShareOwnershipReport(shareholderNumber);
        }

        /// <summary>
        /// ��ȡ��Ȩί�д����˳ֹ�ͳ�Ʊ���
        /// </summary>
        /// <returns></returns>
        public DataTable GetShareOwnershipStatisticsReportByEntrustedAgent()
        {
            return dal.GetShareOwnershipStatisticsReportByEntrustedAgent();
        }

        /// <summary>
        /// ��ȡָ����Ȩ���������Ĺ�Ȩ�仯���档
        /// </summary>
        /// <param name="issueNumber">��Ȩ��������.</param>
        /// <returns></returns>
        public DataTable GetShareOwnershipChange(int issueNumber)
        {
            return dal.GetShareOwnershipChange(issueNumber);
        }

        /// <summary>
        /// ���˹����Ȩ��
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <param name="increaseAmount">��Ȩ��������������Ϊ�������������</param>
        /// <param name="operatorName">�����ߡ�</param>
        /// <returns></returns>
        public bool BuyShares(int shareholderNumber, decimal increaseAmount, decimal originalSharePrice, string operatorName)
        {
            bool returnValue = false;
            if (increaseAmount > 0)
            {
                returnValue = Change(shareholderNumber, increaseAmount, originalSharePrice, "���˹���", true, operatorName);
            }
            return returnValue;
        }

        /// <summary>
        /// �ɷ���ɡ�
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <param name="increaseAmount">��Ȩ��������������Ϊ�������������</param>
        /// <param name="operatorName">�����ߡ�</param>
        /// <returns></returns>
        public bool PeiguShares(int shareholderNumber, decimal increaseAmount, decimal originalSharePrice, string operatorName)
        {
            bool returnValue = false;
            if (increaseAmount > 0)
            {
                returnValue = Change(shareholderNumber, increaseAmount, originalSharePrice, "�ɷ����", false, operatorName);
            }
            return returnValue;
        }

        /// <summary>
        /// ���ֹ�Ȩ��
        /// <para>�÷���Ҳ�����������˹�Ȩ��</para>
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <param name="decreaseAmount">��Ȩ��������������Ϊ�������������</param>
        /// <param name="operatorName">�����ߡ�</param>
        /// <returns></returns>
        public bool Tuigu(int shareholderNumber, decimal decreaseAmount, decimal originalSharePrice, string operatorName)
        {
            bool returnValue = false;
            if (decreaseAmount > 0)
            {
                returnValue = Change(shareholderNumber, -decreaseAmount, originalSharePrice, "�˹�", false, operatorName);
            }
            return returnValue;
        }

        /// <summary>
        /// �������˹�Ȩ
        /// <para>ֻ�����˵����Ȩ��</para>
        /// </summary>
        /// <param name="sharehoderNumbers">�ɶ����б�</param>
        /// <param name="opeName">����Ա</param>
        public void QingtuiShares_Bat(int[] sharehoderNumbers, string opeName)
        {
            daShareOwnership.QingtuiShares_Bat(sharehoderNumbers, opeName);
        }

        /// <summary>
        /// ���ת�ã����ֹ�Ȩ����
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <param name="decreaseAmount">��Ȩ��������������Ϊ�������������</param>
        /// <param name="operatorName">�����ߡ�</param>
        /// <returns></returns>
        public bool HongguZhuanrang(int shareholderNumber, decimal decreaseAmount, decimal originalSharePrice, string operatorName)
        {
            bool returnValue = false;
            if (decreaseAmount > 0)
            {
                returnValue = Change(shareholderNumber, -decreaseAmount, originalSharePrice, "���ת��", false, operatorName);
            }
            return returnValue;
        }

        /// <summary>
        /// ��ȡ��ǰ�ɼ�.
        /// </summary>
        /// <returns></returns>
        public decimal GetCurrentSharePrice()
        {
            return dal.GetCurrentSharePrice();
        }

        /// <summary>
        /// [���]��ȡĳ��ʱ����ڹ�Ȩ�˳���¼��
        /// </summary>
        /// <param name="beginDate">ʱ��ο�ʼ���ڣ�ʱ��ΰ��������ڡ�</param>
        /// <param name="endDate">ʱ��ν������ڣ�ʱ��ΰ��������ڡ�</param>
        /// <returns></returns>
        public DataTable GetShareOwnershipWithdrawal(DateTime beginDate, DateTime endDate)
        {
            return dal.GetShareOwnershipWithdrawal(beginDate, endDate);
        }

        /// <summary>
        /// ��ȡĳָ����Ȩ�����ڵĹ�Ȩ���˱��档
        /// </summary>
        /// <param name="issueNumber">��Ȩ�����ڡ�</param>
        /// <returns></returns>
        public DataTable GetSharesWithdrawal(int issueNumber)
        {
            return dal.GetSharesWithdrawal(issueNumber);
        }

        /// <summary>
        /// ��ȡ���˹�Ȩ�˳����㱨�档
        /// </summary>
        /// <param name="regId">��Ȩ�˳���¼�š�</param>
        /// <returns>�������ݱ����͡�</returns>
        public DataTable GetPersonWithdrawalReportTable(int regId)
        {
            return dal.GetPersonWithdrawalReportTable(regId);
        }



        /// <summary>
        /// ��ȡ���˹�Ȩ�˳����㱨�档
        /// </summary>
        /// <param name="regId">��Ȩ�˳���¼�š�</param>
        /// <returns>���� SharesWithDrawalReport �ࡣ</returns>
        public ShareOS.Model.SharesWithdrawalReport GetPersonWithdrawalReport(int regId)
        {
            return dal.GetPersonWithdrawalReport(regId);
        }

        /// <summary>
        /// ��ȡ�ɶ���ǰ�ֹ�������
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <returns></returns>
        public decimal GetPersonalShareTotals(int shareholderNumber)
        {
            return daShareOwnership.GetPersonalShareTotals(shareholderNumber);
        }

        /// <summary>
        /// ��ȡȫ���Ȩ������
        /// ���㷽�������������йɶ������Ĺ�Ȩ�����
        /// </summary>
        /// <returns></returns>
        public int GetCorporateShareTotals()
        {
            return dal.GetCorporateShareTotals();
        }

        /// <summary>
        /// ��Ȩ�������롣
        /// </summary>
        /// <param name="issueNumber">��Ȩ����������</param>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <param name="sharesAmount">�������ù�Ȩ������</param>
        /// <param name="dateForApply">�������ڡ�</param>
        /// <returns></returns>
        public bool ApplyFor(int issueNumber, int shareholderNumber, int sharesAmount)
        {
            return dal.ApplyFor(issueNumber, shareholderNumber, sharesAmount);
        }

        /// <summary>
        /// ������Ȩ�������롣
        /// </summary>
        /// <param name="issueNumber">��Ȩ����������</param>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <returns></returns>
        public bool CancelApplyFor(int issueNumber, int shareholderNumber)
        {
            return dal.CancelApplyFor(issueNumber, shareholderNumber);
        }


        /// <summary>
        /// ��ȡ��Ȩ�������ñ��档
        /// </summary>
        /// <param name="issueNumber">ָ����Ȩ����������</param>
        /// <returns></returns>
        public DataTable GetShareOwnershipApplyReport(int issueNumber)
        {
            return dal.GetShareOwnershipApplyReport(issueNumber);
        }

        /// <summary>
        /// ���¹�Ȩ�����������
        /// </summary>
        /// <param name="issueNumber">��Ȩ����������</param>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <param name="sharesAmount">�������ù�Ȩ������</param>
        /// <param name="dateForApply">�������ڡ�</param>
        /// <returns></returns>
        public bool UpdateSharesAmountApplyFor(int issueNumber, int shareholderNumber, int sharesAmount)
        {
            return dal.UpdateSharesAmountApplyFor(issueNumber, shareholderNumber, sharesAmount);
        }
    }
}