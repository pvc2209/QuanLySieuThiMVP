using QLST.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLST.Views
{
    public interface ILoginView
    {
        string Username { get; set; }
        string Password { get; set; }

        void LoginError();
        void ShowQuanLyView();
        void ShowNhanVienView();
        void ShowThuKhoView();
    }
}
