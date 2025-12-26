using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DoAnFinal.DAL;

namespace DoAnFinal.Helper
{
    // Class tĩnh để lưu biến toàn cục
    public static class Session
    {
        // Lưu toàn bộ đối tượng User đang đăng nhập
        public static user CurrentUser { get; set; }
    }
}
