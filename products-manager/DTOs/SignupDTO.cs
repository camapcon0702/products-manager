using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.DTOs
{
    public class SignupDTO
    {
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public int IdQuyen { get; set; }

        public SignupDTO(string hoTen, string email, string matKhau, int quyen)
        {
            HoTen = hoTen;
            Email = email;
            MatKhau = matKhau;
            IdQuyen = quyen;
        }

        public override string? ToString()
        {
            return HoTen + ", " + Email + ", " + MatKhau + ", " + IdQuyen;
        }
    }
}
