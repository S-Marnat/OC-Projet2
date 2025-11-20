using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace P2FixAnAppDotNetCode.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        //Début MODIFICATION
        [Required(
            ErrorMessageResourceType = typeof(Resources.Models.ViewModels.Order),
            ErrorMessageResourceName = "ErrorMissingName"
        )]
        //Fin MODIFICATION
        // [Required(ErrorMessage = "ErrorMissingName")]
        public string Name { get; set; }

        //Début MODIFICATION
        [Required(
            ErrorMessageResourceType = typeof(Resources.Models.ViewModels.Order),
            ErrorMessageResourceName = "ErrorMissingAddress"
        )]
        //Fin MODIFICATION
        //[Required(ErrorMessage = "ErrorMissingAddress")]
        public string Address { get; set; }

        //Début MODIFICATION
        [Required(
            ErrorMessageResourceType = typeof(Resources.Models.ViewModels.Order),
            ErrorMessageResourceName = "ErrorMissingCity"
        )]
        //Fin MODIFICATION
        //[Required(ErrorMessage = "ErrorMissingCity")]
        public string City { get; set; }

        //Début MODIFICATION
        [Required(
            ErrorMessageResourceType = typeof(Resources.Models.ViewModels.Order),
            ErrorMessageResourceName = "ErrorMissingZip"
        )]
        //[Required(ErrorMessage = "ErrorMissingZip")]
        //Fin MODIFICATION
        public string Zip { get; set; }

        //Début MODIFICATION
        [Required(
            ErrorMessageResourceType = typeof(Resources.Models.ViewModels.Order),
            ErrorMessageResourceName = "ErrorMissingCountry"
        )]
        //Fin MODIFICATION
        //[Required(ErrorMessage = "ErrorMissingCountry")]
        public string Country { get; set; }

        [BindNever]
        public DateTime Date { get; set; }
    }
}
