using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TeledocTest.Models.Enums;

namespace TeledocTest.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        [Display(Name = "ИНН")]
        public long Inn { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Тип (ЮЛ / ИП)")]
        public ClientType Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
