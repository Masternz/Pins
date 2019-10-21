using System;
using System.Collections.Generic;

namespace Pins.Lib
{
    
    public interface IValidation
    {
        List<IValidator> Validators
        {
            get;
        }
        void Add(IValidator validator);
        
        bool Validate(string pin);
    }
    
    
    public class Validation:IValidation
    {
        private List<IValidator> _validators = null;

        public Validation()
        {
            _validators = new List<IValidator>();
        }

        public List<IValidator> Validators => _validators;

        public void Add(IValidator validator)
        {
            _validators.Add(validator);
        }

        public bool Validate(string pin)
        {
            return true;
        }

    }
}
