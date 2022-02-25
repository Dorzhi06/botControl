using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botControl.Classes.getMe
{
    internal class Result
    {
        public long id { get; set; }
        public bool is_bot { get; set; }
        public string first_name { get; set; }
        public string username { get; set; }
        public bool can_join_groups { get; set; }
        public bool can_read_all_group_messages { get; set; }
        public bool supports_inline_queries { get; set; }
    }
}
