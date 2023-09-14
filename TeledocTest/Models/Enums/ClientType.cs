using System.ComponentModel.DataAnnotations;

namespace TeledocTest.Models.Enums
{
    public enum ClientType
    {
        [Display(Name = "ЮЛ")]
        JuridicalPerson,
        [Display(Name = "ИП")]
        IndividualEntrepreneur
    }
}
