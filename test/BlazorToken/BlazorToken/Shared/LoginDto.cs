using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorToken.Shared
{
    public class LoginDto
    {
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }
    }
}
