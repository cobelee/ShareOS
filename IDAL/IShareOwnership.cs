using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.IDAL
{
    /// <summary>
    /// ��Ȩ�����ӿڡ�
    /// </summary>
    public interface IShareOwnership
    {
        /// <summary>
        /// ��Ȩ������
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <param name="sharesChanges">��Ȩ�ı���������������Ȩ���ӣ�����������Ȩ���١�</param>
        /// <param name="originalSharePrice">ԭʼ�ɼۣ���Ϊ�����Ȩʱ�۸�</param>
        /// <param name="operatorName">��Ȩ�䶯�����ߡ�</param>
        /// <returns></returns>
        bool Change(int shareholderNumber, decimal sharesChanges, decimal originalSharePrice, string causeOfChange, bool isPrincipal, string operatorName);

        /// <summary>
        /// �Թɶ����еĹ���Ϊ��������һ�����ɹɱ��������йɶ��ɹɡ�
        /// </summary>
        /// <param name="issueNumber">��Ȩ����������</param>
        /// <param name="rationScale">�ɹɱ�������100������8�ɣ����ɹɱ�����0.08��</param>
        /// <param name="sharePrice">�ɹɵĹɼۣ�Ҳ���ǵ��ڵĹɼۡ�</param>
        /// <param name="operatorName">������Ա��</param>
        void ScalRationedShares(int issueNumber, decimal rationScale, decimal sharePrice, string operatorName);

        /// <summary>
        /// ������Ȩ����������
        /// </summary>
        /// <param name="regId">��Ȩ������¼�š�</param>
        /// <returns></returns>
        bool CancelChange(int regId);

        /// <summary>
        /// ��ȡ���йɶ���Ȩ���档
        /// </summary>
        /// <returns></returns>
        DataTable GetShareOwnershipReport();

        /// <summary>
        /// ��ȡ�ɶ����˵Ĺ�Ȩ������ʷ��¼���档
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <returns></returns>
        DataTable GetPersonalShareOwnershipReport(int shareholderNumber);

        /// <summary>
        /// ��ȡĳ��ʱ����ڹ�Ȩ�˳���¼��
        /// </summary>
        /// <param name="beginDate">ʱ��ο�ʼ���ڣ�ʱ��ΰ��������ڡ�</param>
        /// <param name="endDate">ʱ��ν������ڣ�ʱ��ΰ��������ڡ�</param>
        /// <returns></returns>
        DataTable GetShareOwnershipWithdrawal(DateTime beginDate, DateTime endDate);

        /// <summary>
        /// ��ȡĳָ����Ȩ�����ڵĹ�Ȩ���˱��档
        /// </summary>
        /// <param name="issueNumber">��Ȩ�����ڡ�</param>
        /// <returns></returns>
        DataTable GetSharesWithdrawal(int issueNumber);

        /// <summary>
        /// ��ȡ���˹�Ȩ�˳����㱨�档
        /// </summary>
        /// <param name="regId">��Ȩ�˳���¼�š�</param>
        /// <returns>�������ݱ����͡�</returns>
        DataTable GetPersonWithdrawalReportTable(int regId);

        /// <summary>
        /// ��ȡ���˹�Ȩ�˳����㱨�档
        /// </summary>
        /// <param name="regId">��Ȩ�˳���¼�š�</param>
        /// <returns>���� SharesWithDrawalReport �ࡣ</returns>
        ShareOS.Model.SharesWithdrawalReport GetPersonWithdrawalReport(int regId);

        /// <summary>
        /// ��ȡָ����Ȩ���������Ĺ�Ȩ�仯���档
        /// </summary>
        /// <param name="issueNumber">��Ȩ��������.</param>
        /// <returns></returns>
        DataTable GetShareOwnershipChange(int issueNumber);

        /// <summary>
        /// ��ȡ��ǰ�ɼ�.
        /// </summary>
        /// <returns></returns>
        decimal GetCurrentSharePrice();

        /// <summary>
        /// ��ȡ�ɶ���ǰ�ֹ�������
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <returns></returns>
        decimal GetPersonalShareTotals(int shareholderNumber);

        /// <summary>
        /// ��ȡȫ���Ȩ������
        /// </summary>
        /// <returns></returns>
        int GetCorporateShareTotals();

        /// <summary>
        /// ��Ȩ�������롣
        /// </summary>
        /// <param name="issueNumber">��Ȩ����������</param>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <param name="sharesAmount">�������ù�Ȩ������</param>
        /// <param name="dateForApply">�������ڡ�</param>
        /// <returns></returns>
        bool ApplyFor(int issueNumber, int shareholderNumber, int sharesAmount);

        /// <summary>
        /// ������Ȩ�������롣
        /// </summary>
        /// <param name="issueNumber">��Ȩ����������</param>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <returns></returns>
        bool CancelApplyFor(int issueNumber, int shareholderNumber);


        /// <summary>
        /// ��ȡ��Ȩ�������ñ��档
        /// </summary>
        /// <param name="issueNumber">ָ����Ȩ����������</param>
        /// <returns></returns>
        DataTable GetShareOwnershipApplyReport(int issueNumber);

        /// <summary>
        /// ��ȡ��Ȩί�д����˳ֹ�ͳ�Ʊ���
        /// </summary>
        /// <returns></returns>
        DataTable GetShareOwnershipStatisticsReportByEntrustedAgent();

        /// <summary>
        /// ���¹�Ȩ�����������
        /// </summary>
        /// <param name="issueNumber">��Ȩ����������</param>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <param name="sharesAmount">�������ù�Ȩ������</param>
        /// <param name="dateForApply">�������ڡ�</param>
        /// <returns></returns>
        bool UpdateSharesAmountApplyFor(int issueNumber, int shareholderNumber, int sharesAmount);
    }
}