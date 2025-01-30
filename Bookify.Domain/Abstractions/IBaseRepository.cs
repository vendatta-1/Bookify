using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Abstractions
{
    public interface IBaseRepository<in T>:IDisposable where T : Entity
    {

    }
}
