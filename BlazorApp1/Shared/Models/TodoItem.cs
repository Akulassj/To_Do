using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{

        public class TodoItem
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string? Description { get; set; }
            public bool IsDone { get; set; }
            public DateTime AddedTime { get; set; }
            public DateTime? CompletionTime { get; set; }
        }
 
}
