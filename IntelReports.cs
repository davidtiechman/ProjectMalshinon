using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectMalshinon
{
    
        internal class IntelReports
        {
            //public int id { get; set; }
            public int reporter_id { get; set; }
            public int target_id { get; set; }
            public string Text { get; set; }
            public DateTime timestamp { get; set; }
            public IntelReports(int reporter_id, int target_id, string text, DateTime timestamp)
            {
                this.reporter_id = reporter_id;
                this.target_id = target_id;
                this.Text = text;
                this.timestamp = timestamp;
            }
        }
    
}
