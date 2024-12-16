using products_manager.Control;
using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Interfaces
{
    public interface ISanPhamRepository
    {
        public List<SanPham> GetAllSanPhams();
        public List<SanPhamItem> SanPhamsToControls();
        public SanPham GetSanPhamById(int idSanPham);
    }
}
