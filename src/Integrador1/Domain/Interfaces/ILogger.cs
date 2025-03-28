using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Domain.Interfaces;

public interface ILogger
{
    void LogError(string message, Exception ex);
    void LogInformation(string message);
}
