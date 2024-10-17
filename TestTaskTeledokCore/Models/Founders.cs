using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestTaskTeledokCore.Models
{
    public class Founders
    {

        [Key]
        [Required]
        [Range(100000000000, 999999999999, ErrorMessage = "ИНН должен состоять из 12 цифр")]
        public ulong ИНН { get; set; }

        [Required]
        [StringLength(100)]
        public string ФИО { get; set; }

        [Required]
        public DateTime ДатаСоздания { get; set; }

        [Required]
        public DateTime ДатаОбновления { get; set; }

        public ClientsFounders Компании { get; set; }
        //public List<Course> Courses { get; set; } = new List<Course>();
/*[ForeignKey("ИНН_компании")]
public ICollection<Clients> Clients { get; set; } */
}
}