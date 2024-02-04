using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Equipment
    {
        [Key]
        public int? EquipmentID { get; set; }  // Zimmetli mal ID'si
        public string? EquipmentName { get; set; } // Zimmetli mal adı
    }
}