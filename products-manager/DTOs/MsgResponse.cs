using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.DTOs
{
    public class MsgResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public MsgResponse() { }
        public MsgResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
