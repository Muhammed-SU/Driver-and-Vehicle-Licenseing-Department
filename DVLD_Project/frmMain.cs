using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Project.Login;
using DVLD_Project.People;
using DVLD_Project.Global_Classes;

namespace DVLD_Project
{
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;

        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm1 = new frmListPeople();
            frm1.ShowDialog();
        }
    }
}
