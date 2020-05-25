using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using second.Data;

namespace second.Pages
{
    public class Set : PageModel
    {
        [Required]
        [Display(Name = "Operace")]
        public Calculation Input { get; set; }
        [Required]
        [Display(Name = "První číslo")]
        public float? a { get; set; }
        [Required]
        [Display(Name = "Druhé číslo")]
        public float? b { get; set; }

        public float? result { get; set; }
        public string error { get; set; }
        
        public void OnGet()
        {
            error = "";
            Input = new Calculation();
            Input.a = 3;
            Input.b = 4;
            Input.op = Operation.Addition;
        }

        public void OnPost(Calculation input)
        {
            if (input.a != null && input.b != null &&ModelState.IsValid)
            {
                error = "";
                switch (input.op)
                {
                    case Operation.Addition: 
                    {
                        result = input.a + input.b;
                        break;
                    }
                    case Operation.Subtraction: 
                    {
                        result = input.a - input.b;
                        break;
                    }
                    case Operation.Division:
                    {
                        if (input.b != 0)
                            result = input.a / input.b;
                        else
                            error = "Nelze dělit nulou";
                        break;
                    }
                    case Operation.Multiplication: 
                    {
                        result = input.a * input.b;
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            else
            {
                if (input.a == null)
                    error = "Zadejte první číslo. ";
                if (input.b == null)
                    error += "Zadejte druhé číslo.";
            }
        }
    }
}