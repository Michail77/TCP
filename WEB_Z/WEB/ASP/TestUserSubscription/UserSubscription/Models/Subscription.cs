using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserSubscription.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Jméno musí být vyplněno.")]
        [Display(Name = "Jméno")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Příjmení musí být vyplněno.")]
        [Display(Name = "Příjmení")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Emailová adresa musí být vyplněna.")]
        [Display(Name = "Emailová adresa")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Je nutné vybrat si pohlaví.")]
        [Display(Name = "Pohlaví")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Je nutné vybrat si zemi, kde bydlíte.")]
        [Display(Name = "Země")]
        public string CountryCode { get; set; }
        [Required(ErrorMessage = "Se zpracováním osobních údajů musíte souhlasit.")]
        [Display(Name = "Souhlas se zpracováním osobních údajů")]
        public bool Agreed { get; set; }
        [Display(Name = "Potvrzený email")]
        public bool Confirmed { get; set; }
        [Display(Name = "Kód pro potvrzení emailu")]
        public string ConfirmationCode { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }       
    }
}
