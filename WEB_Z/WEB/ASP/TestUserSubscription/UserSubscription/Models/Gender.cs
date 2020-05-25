using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserSubscription.Models
{
    public enum Gender
    {
        [Display(Name = "Muž")]
        Male = 0,
        [Display(Name = "Žena")]
        Female = 1,
        [Display(Name = "Jiné")]
        Other = 2
    }
}
