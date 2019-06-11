using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinUI
{
    public partial class MDIMain : Form
    {
        private int childFormNumber = 0;

        public MDIMain()
        {
            InitializeComponent();
            ShowCurrentSharePrice();
        }

        private void ShowCurrentSharePrice()
        {
            ShareOS.BLL.ShareOwnershipManage som = new ShareOS.BLL.ShareOwnershipManage();
            tlbCurrentSharePrice.Text = som.GetCurrentSharePrice().ToString();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            // 创建此子窗体的一个新实例。
            Form childForm = new Form();
            // 在显示该窗体前使其成为此 MDI 窗体的子窗体。
            childForm.MdiParent = this;
            childForm.Text = "窗口" + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                // TODO: 在此处添加打开文件的代码。
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
                // TODO: 在此处添加代码，将窗体的当前内容保存到一个文件中。
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: 使用 System.Windows.Forms.Clipboard 将所选的文本或图像插入到剪贴板
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: 使用 System.Windows.Forms.Clipboard 将所选的文本或图像插入到剪贴板
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: 使用 System.Windows.Forms.Clipboard.GetText() 或 System.Windows.Forms.GetData 从剪贴板中检索信息。
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void adminConfig_Click(object sender, EventArgs e)
        {
            ShareOS.SysConfig.SettingMain adminConfig = new ShareOS.SysConfig.SettingMain();
            adminConfig.MdiParent = this;
            adminConfig.Show();
            adminConfig.WindowState = FormWindowState.Maximized;
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog(this);
        }

        private void 股东名册RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareholderRegister register = new ShareholderRegister();
            register.MdiParent = this;
            register.Show();
            register.WindowState = FormWindowState.Maximized;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Option optionForm = new Option();
            optionForm.ShowDialog(this);
        }

        private void menuItemPersonTypeConfig_Click(object sender, EventArgs e)
        {
            PersonTypeManage personType = new PersonTypeManage();
            personType.ShowDialog(this);
        }


        private void menuItemShareOwnership_Click(object sender, EventArgs e)
        {
            ShareOwnershipManage ownershipManage = new ShareOwnershipManage();
            ownershipManage.MdiParent = this;
            ownershipManage.Show();
            ownershipManage.WindowState = FormWindowState.Maximized;
        }

        private void 分红参数配置CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SharesIssueConfig config = new SharesIssueConfig();
            config.MdiParent = this;
            config.Show();
            config.WindowState = FormWindowState.Maximized;
        }

        private void 红利查询QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BonusQuery bq = new BonusQuery();
            bq.MdiParent = this;
            bq.Show();
            bq.WindowState = FormWindowState.Maximized;
        }

        private void MDIMain_Load(object sender, EventArgs e)
        {

        }

        private void 股权退出管理EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareOwnershipWithdrawal sow = new ShareOwnershipWithdrawal();
            sow.MdiParent = this;
            sow.Show();
            sow.WindowState = FormWindowState.Maximized;
        }

        private void 打印出资证明书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print.InvestmentCertification ic = new WinUI.Print.InvestmentCertification();
            ic.MdiParent = this;
            ic.Show();
            ic.WindowState = FormWindowState.Maximized;
        }

        private void 股权受让申请表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print.BuySharesApplication buyShare = new WinUI.Print.BuySharesApplication();
            buyShare.MdiParent = this;
            buyShare.Show();
            buyShare.WindowState = FormWindowState.Maximized;
        }

        private void 股权受让申请录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareOwnershipApplyFor apply = new ShareOwnershipApplyFor();
            apply.MdiParent = this;
            apply.Show();
            apply.WindowState = FormWindowState.Maximized;
        }

        private void menuItemEntrustedAgentManage_Click(object sender, EventArgs e)
        {
            EntrustedAgentManage eam = new EntrustedAgentManage();
            eam.MdiParent = this;
            eam.Show();
            eam.WindowState = FormWindowState.Maximized;
        }

        private void 按委托代理人统计股权ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print.ShareOwnershipStatistics sos = new WinUI.Print.ShareOwnershipStatistics();
            sos.MdiParent = this;
            sos.Show();
            sos.WindowState = FormWindowState.Maximized;
        }

        private void menuItemBarCode_Click(object sender, EventArgs e)
        {
            ShareholderBarCode barCode = new ShareholderBarCode();
            barCode.MdiParent = this;
            barCode.Show();
            barCode.WindowState = FormWindowState.Maximized;
        }

        private void 比例派股ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScaleRationedShares ration = new ScaleRationedShares();
            ration.MdiParent = this;
            ration.Show();
            ration.WindowState = FormWindowState.Maximized;
        }
    }
}
