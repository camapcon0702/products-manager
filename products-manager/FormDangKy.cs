using products_manager.App_Data;
using products_manager.DTOs;
using products_manager.Interfaces;
using products_manager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace products_manager
{
    public partial class FormDangKy : Form
    {
        private ITaiKhoanRepository _taikhoanRepo;
        //private AppDataContext _context;
        public FormDangKy()
        {
            InitializeComponent();
            _taikhoanRepo = new TaiKhoanRepository(new AppDataContext());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.Close();
        }

        private void FormDangKy_Load(object sender, EventArgs e)
        {
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string hoten = txtHoten.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            SignupDTO signupDTO = new SignupDTO(hoten, email, password, 2);
            MsgResponse response = await _taikhoanRepo.SignUp(signupDTO);

            MessageBox.Show(response.Message);
        }
    }
}
