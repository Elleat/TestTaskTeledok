using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestTaskTeledokCore.Models
{
    public class Clients
    {
        [Key]
        [Required]
        [Range(100000000000, 999999999999, ErrorMessage = "ИНН должен состоять из 12 цифр")]
        public ulong ИНН { get; set; }

        [Required]
        [StringLength(100)]
        public string Наименование { get; set; }

        [Required]
        public bool ЮЛИП { get; set; }

        [Required]
        public DateTime ДатаСоздания { get; set; }

        [Required]
        public DateTime ДатаОбновления { get; set; }

        public ClientsFounders Учредители { get; set; }
        //public List<Course> Courses { get; set; } = new List<Course>();
        /*[ForeignKey("ИНН")]
 public ICollection<Founders> Founders { get; set; } */
    }
}
