using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskTeledokCore.ModelsTest
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set;}
        public BlogSettings BlogSettings { get; set; }
    }
}
