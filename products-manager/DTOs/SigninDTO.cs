using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.DTOs
{
    public class SigninDTO
    {
        public string Email { get; set; }
        public string MatKhau { get; set; }

        public SigninDTO(string email, string matKhau)
        {
            Email = email;
            MatKhau = matKhau;
        }
    }
}
