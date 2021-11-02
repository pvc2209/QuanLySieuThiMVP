using QLST.Models;
using QLST.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLST.Presenters
{
    public class LoginPresenter
    {
        private ILoginView _view;

        public LoginPresenter(ILoginView view)
        {
            _view = view;
        }

        public void Login()
        {
            string username = _view.Username;
            string password = _view.Password;

            LoginDB db = new LoginDB();

            if (db.CheckLogin(username, password))
            {
                var user = db.GetUser(username);

                switch (user.ChucVu)
                {
                    case ChucVu.NhanVien:
                        _view.ShowNhanVienView();
                        break;
                    case ChucVu.QuanLy:
                        _view.ShowQuanLyView();
                        break;
                    case ChucVu.ThuKho:
                        _view.ShowThuKhoView();
                        break;
                }
            }
            else
            {
                _view.LoginError();
            }
        }
    }
}
