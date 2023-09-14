using System.ComponentModel.DataAnnotations;

namespace TeledocTest.Models
{
    public class FounderModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [Display(Name = "ИНН")]
        public long Inn { get; set; }
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
