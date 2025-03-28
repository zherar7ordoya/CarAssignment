using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Shared.Exceptions;

public interface IExceptionHandler
{
    void Handle(Exception ex, string message);
}
