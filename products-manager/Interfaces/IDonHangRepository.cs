using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Interfaces
{
    public interface IDonHangRepository
    {
        public DataTable GetDonHangByUser();
    }
}
