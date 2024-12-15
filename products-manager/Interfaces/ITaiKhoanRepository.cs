using Microsoft.VisualBasic.ApplicationServices;
using products_manager.DTOs;
using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Interfaces
{
    public interface ITaiKhoanRepository
    {
        public string EncodePassword(TaiKhoan taiKhoan, string plainPassword);
        public bool VerifyPassword(TaiKhoan taiKhoan, string plainPassword, string hashedPassword);
        public Task<MsgResponse> SignUp(SignupDTO signupDTO);
        public Task<MsgResponse> SignIn(SigninDTO signinDTO);
        public Task<TaiKhoan> FindTaiKhoanByEmail(string email);
        public void XmlAuthorize(TaiKhoan taiKhoan);
        public Task<DataTable> GetAllUsers();
    }
}
