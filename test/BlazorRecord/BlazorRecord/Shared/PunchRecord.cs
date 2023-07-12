using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRecord.Shared
{
    public class PunchRecord
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public DateTime PunchIn { get; set; }
        public DateTime PunchOut { get; set; }
        public string Hours { get; set; } = string.Empty;
    }
}
