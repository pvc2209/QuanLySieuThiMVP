using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLST.Models
{
    public enum ChucVu
    {
        QuanLy,
        NhanVien,
        ThuKho,
    }

    public class User
    {
        public int Uid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ChucVu ChucVu { get; set; }
        public string FullName { get; set; }


        public User(int uid, string username, string password, ChucVu chucVu, string fullName)
        {
            Uid = uid;
            Username = username;
            Password = password;
            ChucVu = chucVu;
            FullName = fullName;
        }
    }
}
