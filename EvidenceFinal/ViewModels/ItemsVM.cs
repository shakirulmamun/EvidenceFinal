using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvidenceFinal.ViewModels
{
    public class ItemsVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Cannot be empty")]
        public string Name { get; set; }

        public string Price { get; set; }
    }
}