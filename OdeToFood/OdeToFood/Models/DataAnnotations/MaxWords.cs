using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models.DataAnnotations
{
    public class MaxWords : ValidationAttribute
    {
        private int _maxWords;
        public MaxWords(int maxWords) : base(String.Format("{0} is the maximum number of words.", maxWords))
        {
            _maxWords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string[] values = value.ToString().Split(' ');
                if (values.Length > _maxWords)
                {
                    string formattedErrorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(formattedErrorMessage);
                }
            }
            return ValidationResult.Success;
        }


    }
}