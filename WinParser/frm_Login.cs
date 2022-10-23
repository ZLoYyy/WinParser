using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinParser.Data;

namespace WinParser
{
    public partial class frm_Login : Form
    {
        private User _user;

        public User CurrentUser => _user;
        public frm_Login()
        {
            InitializeComponent();
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Login.Text))
            {
                MessageBox.Show("Введите логин", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tb_Password.Text))
            {
                MessageBox.Show("Введите пароль", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _user = Executor.Login(tb_Login.Text, tb_Password.Text);

            if (_user == null)
            {
                MessageBox.Show("Введите пароль или пароль не верный", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
