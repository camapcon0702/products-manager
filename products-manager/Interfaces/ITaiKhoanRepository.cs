using Microsoft.VisualBasic.ApplicationServices;
using products_manager.DTOs;
using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Interfaces
{
    public interface ITaiKhoanRepository
    {
        public string EncodePassword(TaiKhoan taiKhoan, string plainPassword);
        public bool VerifyPassword(TaiKhoan taiKhoan, string plainPassword, string hashedPassword);
        public Task<string> SignUp(SignupDTO signupDTO);
        public Task<string> SignIn(SigninDTO signinDTO);
        public Task<TaiKhoan> FindTaiKhoanByEmail(string email);
        public void XmlAuthorize(TaiKhoan taiKhoan);
    }
}
