using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShareOS.BLL;

namespace ShareOS.SysConfig
{
    public partial class SettingMain : Form
    {
        ShareOS.BLL.Account bllAccount;
        
        public SettingMain()
        {
            InitializeComponent();
            InitSetting();

            gvAccountBind();
            
        }

        public void InitSetting()
        {
            bllAccount = new ShareOS.BLL.Account();
        }

        protected void gvAccountBind()
        {
            gvAccount.DataSource = bllAccount.GetAccountAll();
            gvAccount.Columns[2].Visible = false;
        }



        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string UserType = "管理员";

            if (tbPassword1.Text == tbPassword2.Text)
            {
                bllAccount.AddAccount(tbUserName.Text, tbPassword1.Text, UserType, tbTrueName.Text);

                gvAccountBind();
                tbUserName.Text = "";
                tbPassword1.Text = "";
                tbPassword2.Text = "";
            }
            else
            {
                MessageBox.Show("输入密码与确认密码不一致，请重新输入！", "输入错误",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("将要删除账号，是否继续？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int accountId;
                accountId = Convert.ToInt32(gvAccount.SelectedRows[0].Cells[2].Value);
                bllAccount.DeleteAccount(accountId);
                gvAccountBind();

            }
        }


    }
}