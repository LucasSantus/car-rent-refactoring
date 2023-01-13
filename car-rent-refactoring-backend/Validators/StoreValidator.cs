
using car_rent_refactoring_backend.Models;

namespace car_rent_refactoring_backend.Validators
{
   

    public class StoreValidator
    {
        public Store Context { get; set; }

        public bool isValid { get; set; }

        public StoreValidator(Store context) { 
            isValid = true;
            Context = context;
        }

        public StoreValidator CheckCnpj()
        {
            //isValid = Context.Cnpj.ValidateCnpj();
            return this;
        }

    }
}
