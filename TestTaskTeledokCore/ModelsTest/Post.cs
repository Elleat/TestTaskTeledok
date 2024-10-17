using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskTeledokCore.ModelsTest
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Blog Blog { get; set; }
        public Guid BlogId { get; set; }
        public ICollection<Tag> Tags { get; set; }

    }
}
