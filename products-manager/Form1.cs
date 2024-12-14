using products_manager.App_Data;
using products_manager.DTOs;
using products_manager.Interfaces;
using products_manager.Models;
using products_manager.Repositories;
using System.Runtime.InteropServices;

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
        public Form1()
        {
            InitializeComponent();
            AllocConsole();
            _context = new AppDataContext();
            _taiKhoanRepository = new TaiKhoanRepository(_context);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            
            Console.WriteLine("Thom phuc");

            //string hoten = Console.ReadLine();
            string email = Console.ReadLine();
            string matkhau = Console.ReadLine();

            //SignupDTO signup = new SignupDTO(hoten, email, matkhau, 1);
            //Console.WriteLine(signup.ToString());


            SigninDTO signinDTO = new SigninDTO(email, matkhau);

            //string result = await _taiKhoanRepository.SignUp(signup);
            string result = await _taiKhoanRepository.SignIn(signinDTO);

            Console.WriteLine(result);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FreeConsole();
        }
    }
}
