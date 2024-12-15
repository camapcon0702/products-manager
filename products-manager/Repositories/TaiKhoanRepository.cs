using Microsoft.EntityFrameworkCore;
using products_manager.App_Data;
using products_manager.DTOs;
using products_manager.Interfaces;
using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace products_manager.Repositories
{
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        private readonly AppDataContext _context;
        private readonly IQuyenRepository _quyenRepository;
        public TaiKhoanRepository(AppDataContext context)
        {
            _context = context;
            _quyenRepository = new QuyenRepository(context);
        }
        public string EncodePassword(TaiKhoan taiKhoan, string plainPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainPassword);
        }

        public async Task<TaiKhoan> FindTaiKhoanByEmail(string email)
        {
            var user = await _context.taiKhoans
                .Include(t => t.Quyen)
                .FirstOrDefaultAsync(t => t.Email == email);
            return user;
        }

        public async Task<DataTable> GetAllUsers()
        {
            var users = await _context.taiKhoans
                .Include(t => t.Quyen)
                .ToListAsync();
            DataTable dataTable = DataTableHelper.ToDataTable(users);
            return dataTable;
        }

        public async Task<string> SignIn(SigninDTO signinDTO)
        {
            var user = await FindTaiKhoanByEmail(signinDTO.Email);
            if (user == null)
            {
                return "Invalid Email!";
            }

            bool isPasswordValid = VerifyPassword(user, signinDTO.MatKhau, user.MatKhau);
            if (!isPasswordValid)
            {
                return "Password is incorrect";
            }

            XmlAuthorize(user);

            return "Login successful!";
        }

        public async Task<string> SignUp(SignupDTO signupDTO)
        {
            var isExist = await FindTaiKhoanByEmail(signupDTO.Email);
            if (isExist != null)
            {
                return "This email already used with another account!";
            }

            var newUser = new TaiKhoan
            {
                HoTen = signupDTO.HoTen,
                Email = signupDTO.Email,
                MatKhau = EncodePassword(new TaiKhoan(), signupDTO.MatKhau),
                Quyen = await _quyenRepository.FindQuyenById(signupDTO.IdQuyen)
            };

            _context.taiKhoans.Add(newUser);
            await _context.SaveChangesAsync();

            return "Signup successful!";
        }

        public bool VerifyPassword(TaiKhoan taiKhoan, string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }

        public void XmlAuthorize(TaiKhoan taiKhoan)
        {
            XElement auth = new XElement("Auth",
                new XElement("Id", taiKhoan.Id),
                new XElement("HoTen", taiKhoan.HoTen),
                new XElement("Email", taiKhoan.Email),
                new XElement("MatKhau", taiKhoan.MatKhau),
                new XElement("Quyen", taiKhoan.Quyen.Id));

            string filePath = "../Data/auth.xml";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            auth.Save(filePath);
        }
    }
}
