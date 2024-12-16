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
        public Task<List<SanPham>> GetAllSanPhams();
        public Task<List<SanPhamItem>> SanPhamsToControls();
    }
}
