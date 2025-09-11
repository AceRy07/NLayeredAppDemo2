using FluentValidation;
using Northwind.Entities.Concrete;
using Northwind.Bussiunes.ValidationRules.FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bussiunes.Utilities
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            // IValidationContext olması sebebi 9.0 dan sonra object imzası kaldırılmış olması bu sayede onuda kullanabiliriz.
            var result = validator.Validate((IValidationContext)entity);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
