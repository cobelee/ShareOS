using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinUI.Dialog
{
    public partial class GetInteger : Form
    {
        private int shareOwnershipAmount;

        public int ShareOwnershipAmount
        {
            get { return shareOwnershipAmount; }
            set { shareOwnershipAmount = value; }
        }

        public GetInteger()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            shareOwnershipAmount = Convert.ToInt32(nudShareOwnership.Value);
        }
    }
}