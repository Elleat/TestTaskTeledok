using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskTeledokCore.ModelsTest
{
    public class BlogSettings
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public Blog Blog { get; set; }
        public Guid Blogid { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
