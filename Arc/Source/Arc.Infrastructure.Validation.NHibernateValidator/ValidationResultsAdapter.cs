using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Validator.Engine;
using System.Linq;

namespace Arc.Infrastructure.Validation.NHibernateValidator
{
    public class ValidationResultsAdapter : IValidationResults
    {
        private readonly InvalidValue[] _values;

        public ValidationResultsAdapter(InvalidValue[] values)
        {
            _values = values;
        }

        public bool IsValid
        {
            get { return _values.Length == 0; }
        }

        public string GetFirstMessageFor(string tag)
        {
            return _values.Where(x => x.PropertyName == tag).Select(x => x.Message).FirstOrDefault();
        }

        public string[] GetMessagesFor(string tag)
        {
            return _values.Where(x => x.PropertyName == tag).Select(x => x.Message).ToArray();
        }

        public string Summary
        {
            get
            {
                var summary = new StringBuilder();

                foreach (var error in _values)
                {
                    summary.Append(error.PropertyName);
                    summary.Append(": ");
                    summary.Append(error.Message);
                    summary.Append(Environment.NewLine);
                }
                return summary.ToString();
            }
        }

        public KeyValuePair<string, string>[] AllErrors
        {
            get
            {
                return _values.Select(x => new KeyValuePair<string, string>(x.PropertyName, x.Message))
                    .ToArray();
            }
        }
    }
}