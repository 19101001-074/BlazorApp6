using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp6
{
    public class ProductReview
    {
        [Required(ErrorMessage = "Product Name is required.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [MinLength(20, ErrorMessage = "Review Description must be at least 20 characters long.")]
        public string ReviewDescription { get; set; }

        [Required(ErrorMessage = "Purchase Date is required.")]
        [DataType(DataType.Date)]
        [FutureDateNotAllowed]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "Recommendation is required.")]
        public bool WouldRecommend { get; set; }

        [Required(ErrorMessage = "You must agree to the terms.")]
        public bool AgreeToTerms { get; set; }
    }

    public class FutureDateNotAllowedAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.Date <= DateTime.Now.Date;
            }
            return true;
        }
    }
}
