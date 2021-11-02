using QLST.Presenters;
using QLST.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLST
{
    public partial class LoginForm : Form, ILoginView
    {
        private LoginPresenter _presenter;

        public LoginForm()
        {
            InitializeComponent();
            _presenter = new LoginPresenter(this);
        }

        public string Username
        {
            get => tbUsername.Text;
            set => tbUsername.Text = value;
        }

        public string Password
        {
            get => tbPassword.Text;
            set => tbPassword.Text = value;
        }

        public void LoginError()
        {
            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
        }

        public void ShowNhanVienView()
        {
            MessageBox.Show("NhanVienView");
        }

        public void ShowQuanLyView()
        {
            MessageBox.Show("QuanLyView");
        }

        public void ShowThuKhoView()
        {
            MessageBox.Show("ThuKhoView");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _presenter.Login();
        }
    }
}
