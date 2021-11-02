using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLST.Models
{
    public class LoginDB
    {
        private string _connectionString = @"Data Source=DESKTOP-T9HTG8E\SQLEXPRESS;Initial Catalog=QLSTDB;Integrated Security=True;";
        private SqlConnection _connection;

        public LoginDB()
        {
            _connection = new SqlConnection(_connectionString);
        }

        public bool CheckLogin(string username, string password)
        {
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = $"SELECT COUNT(*) FROM users WHERE username = '{username}' AND password = '{password}'";

            int count = (int)cmd.ExecuteScalar();

            _connection.Close();

            return count != 0;
        }

        public User GetUser(string username)
        {
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM users WHERE username = '{username}'";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            int uid = (int)reader["uid"];
            string password = (string)reader["password"];
            string hoTen = (string)reader["hoten"];

            bool isQuanLy = (bool)reader["is_quanly"];
            bool isNhanVien = (bool)reader["is_nhanvien"];
            bool isThuKho = (bool)reader["is_thukho"];

            _connection.Close();


            ChucVu chucVu = ChucVu.ThuKho;
            if (isQuanLy)
            {
                chucVu = ChucVu.QuanLy;
            }
            else if (isNhanVien)
            {
                chucVu = ChucVu.NhanVien;
            }

            var user = new User(uid, username, password, chucVu, hoTen);

            return user;
        }
    }
}
