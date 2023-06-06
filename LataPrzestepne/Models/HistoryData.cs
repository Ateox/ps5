using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace LataPrzestepne.Models
{
    public class HistoryData
    {
        [Display(Name = "Twój rok urodzenia")]
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1899, 2024, ErrorMessage = "Oczekiwany rok z zakresu {1} i {2}.")]
        public int? Year { get; set; }

        public string Result { get; set; }

        public string Name { get; set; } = "No name";

        [AllowNull]
        public string UserId { get; set; }

        public DateTime Time { get; set; }
        //public bool IsActive { get; set; }
    }
}
