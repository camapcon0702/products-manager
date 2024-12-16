using Microsoft.EntityFrameworkCore;
using products_manager.App_Data;
using products_manager.Control;
using products_manager.Interfaces;
using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Repositories
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly AppDataContext _context;
        public SanPhamRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task<List<SanPham>> GetAllSanPhams()
        {
            return await _context.sanPhams.ToListAsync();
        }

        public async Task<List<SanPhamItem>> SanPhamsToControls()
        {
            var sanPhams = await GetAllSanPhams();
            var items = new List<SanPhamItem>();
            foreach (var item in sanPhams) {
                items.Add(new SanPhamItem(item));
            }
            return items;
        }
    }
}
