using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.BusinessLogic.Commands
{
    public interface IReadCommand<T>
    {
        (bool Success, T? Result, string ErrorMessage) Execute();
        void Undo();
    }
}
