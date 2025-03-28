using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Domain.Interfaces;

public interface IMessageBus
{
    void PublishError(string message);
    void PublishInfo(string message);
}
