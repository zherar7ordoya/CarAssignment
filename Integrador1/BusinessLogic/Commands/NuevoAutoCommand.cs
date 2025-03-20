using Integrador.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.BusinessLogic.Commands;

public class NuevoAutoCommand(BindingSource bindingSource, Button nuevoAutoButton) : ICommand
{
    private readonly BindingSource _bindingSource = bindingSource;
    private readonly Button _nuevoAutoButton = nuevoAutoButton;

    public void Execute()
    {
        var nuevoAuto = new Auto();
        _bindingSource.Add(nuevoAuto);
        _bindingSource.MoveLast();
        _nuevoAutoButton.Enabled = false;
    }

    public void Undo() { /* Opcional: Lógica para deshacer la creación del borrador. */ }
}
