﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AfrikSokoApi.Models
{
    public class NewProductTypeCreate
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
