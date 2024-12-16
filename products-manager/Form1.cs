using products_manager.App_Data;
using products_manager.DTOs;
using products_manager.Interfaces;
using products_manager.Models;
using products_manager.Repositories;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace products_manager
{
    public partial class Form1 : Form
    {

        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();

        private ITaiKhoanRepository _taiKhoanRepository;
        private AppDataContext _context;
        XDocument doc;


        public Form1()
        {
            InitializeComponent();
            //AllocConsole();
            _context = new AppDataContext();
            _taiKhoanRepository = new TaiKhoanRepository(_context);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "\\Resources\\images\\laptop.png";
            //Console.WriteLine(projectPath);
            //string path = "./Resources/images/laptop.png";
            //Console.WriteLine(path);

            //string hoten = Console.ReadLine();
            //string email = Console.ReadLine();
            //string matkhau = Console.ReadLine();

            //SignupDTO signup = new SignupDTO(hoten, email, matkhau, 1);
            //Console.WriteLine(signup.ToString());


            //SigninDTO signinDTO = new SigninDTO(email, matkhau);

            //string result = await _taiKhoanRepository.SignUp(signup);
            //string result = await _taiKhoanRepository.SignIn(signinDTO);

            //Console.WriteLine(result);
            //dataGridView1.DataSource = await _taiKhoanRepository.GetAllUsers();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FreeConsole();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private async void button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            SigninDTO signinDTO = new SigninDTO(email, password);
            MsgResponse result = await _taiKhoanRepository.SignIn(signinDTO);
            doc = XDocument.Load("../Data/auth.xml");
            if (result.Success)
            {
                MessageBox.Show(result.Message, "Thông báo");

                int quyen = int.Parse(doc.Root.Element("Quyen")?.Value);
                if (quyen == 1)
                {
                    FormNhanVien formNhanVien = new FormNhanVien();
                    formNhanVien.Show();
                }
                else if (quyen == 2)
                {
                    FormKhachHang formKhachHang = new FormKhachHang();
                    formKhachHang.Show();
                }
            }
            else
            {
                MessageBox.Show(result.Message, "Thông báo");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDangKy formDangKy = new FormDangKy();
            formDangKy.Show();
        }
    }
}
