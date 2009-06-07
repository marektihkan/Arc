using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;
using System.Linq;

namespace Arc.Infrastructure.Validation.FluentValidation
{
    public class ValidationResultsAdapter : IValidationResults
    {
        private readonly ValidationResult _validationResult;

        public ValidationResultsAdapter(ValidationResult validationResult)
        {
            _validationResult = validationResult;
        }

        public bool IsValid
        {
            get { return _validationResult.IsValid; }
        }

        public string GetFirstMessageFor(string tag)
        {
            return _validationResult.Errors
                .Where(x => x.PropertyName == tag)
                .Select(x => x.ErrorMessage)
                .FirstOrDefault();           
        }

        public string[] GetMessagesFor(string tag)
        {
            return _validationResult.Errors
                .Where(x => x.PropertyName == tag)
                .Select(x => x.ErrorMessage)
                .ToArray();
        }

        public string Summary
        {
            get 
            {
                var summary = new StringBuilder();

                foreach (var error in _validationResult.Errors)
                {
                    summary.Append(error.PropertyName);
                    summary.Append(": ");
                    summary.Append(error.ErrorMessage);
                    summary.Append(Environment.NewLine);
                }
                return summary.ToString();
            }
        }

        public KeyValuePair<string, string>[] AllErrors
        {
            get
            {
                return _validationResult.Errors
                    .Select(x => new KeyValuePair<string, string>(x.PropertyName, x.ErrorMessage))
                    .ToArray();
            }
        }
    }
}