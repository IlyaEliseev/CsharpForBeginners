using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Issue
    {
        public Issue()
        {
            CreationDate = DateTime.Now;
            Status = Status.New;
        }

        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public Status Status { get; set; }
    }
}
