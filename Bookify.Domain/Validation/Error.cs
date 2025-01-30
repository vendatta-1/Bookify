using Bookify.Domain.Validation.api.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Validation
{
    public record Error(string Code, string Message)
    {
        public static Error None = new Error(string.Empty ,string.Empty);
        public static Error NullValue = new Error(ErrorCode.NullValue.ToString(),"Null value was provided");
    }
 

}
