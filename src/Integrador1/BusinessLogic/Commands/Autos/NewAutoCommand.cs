using Integrador.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.BusinessLogic.Commands.Autos;

public class NewAutoCommand(BindingSource bindingSource, Button nuevoAutoButton) : ICommand
{
    public (bool Success, string ErrorMessage) Execute()
    {
        var nuevoAuto = new Auto();
        bindingSource.Add(nuevoAuto);
        bindingSource.MoveLast();
        nuevoAutoButton.Enabled = false;
        return (true, string.Empty);
    }

    public void Undo() { /* Opcional: Lógica para deshacer la creación del borrador. */ }
}
