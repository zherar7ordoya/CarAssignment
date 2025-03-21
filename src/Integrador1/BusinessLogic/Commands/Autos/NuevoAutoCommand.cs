using Integrador.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.BusinessLogic.Commands.Autos;

public class NuevoAutoCommand(BindingSource bindingSource, Button nuevoAutoButton) : ICommand
{
    private readonly BindingSource _bindingSource = bindingSource;
    private readonly Button _nuevoAutoButton = nuevoAutoButton;

    public (bool Success, string ErrorMessage) Execute()
    {
        var nuevoAuto = new Auto();
        _bindingSource.Add(nuevoAuto);
        _bindingSource.MoveLast();
        _nuevoAutoButton.Enabled = false;
        return (true, string.Empty);
    }

    public void Undo() { /* Opcional: Lógica para deshacer la creación del borrador. */ }
}
