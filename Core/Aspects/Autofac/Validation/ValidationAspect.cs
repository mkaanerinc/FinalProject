using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.FluentValidation.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception // Aspect
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            // defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) // Verilen tip IValidator mı?
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation) // Methodun başında çalışır
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // reflection. Arka planda instance oluşturur.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // Verilen Validator'un base'inde verilen argümanını alır. 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // method argümanlarında verilen argüman ile attribute'da verilen argümanı karşılaştırır.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity); // Validation için oluşturduğumuz statik methoda gidip doğrulama işlemi yapar.
            }
        }
    }
}
