using System.ComponentModel.DataAnnotations;

namespace AfrikSokoApi.Models
{
    public class NewSectorCreate
    {   
            [Required]          
            public string SectorName { get; set; }        
    }
}
