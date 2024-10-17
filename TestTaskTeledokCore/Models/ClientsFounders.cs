using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestTaskTeledokCore.Models
{
    public class ClientsFounders
    {
        [Key]
        public ulong ИНН_Компании { get; set; }
        [Key]
        public ulong ИНН_Учредителя { get; set; }
        
        public Clients Компании { get; set; }
       
        public Founders Учредители { get; set; }
    }
}
