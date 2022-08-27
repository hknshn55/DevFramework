using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Postsharp.ValidationAspect
{
    [Serializable]
    public class FluentValidationAspect:OnMethodBoundaryAspect
    {
        private readonly Type _validatorType;
        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }

        //Metodun girişinde doğrulama yapar.
        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //Validatorun base argümanının ilk elemanı. Zaten AbstractValidator<T> dediğimiz için 1 argümanı var.
            var entities = args.Arguments.Where(x => x.GetType() == entityType); //Gelen tip entityType tipi olanları al   
            foreach (var item in entities)
            {
                ValidatorTool.FluentValidate(validator,item);
            }
        }
    }
}
