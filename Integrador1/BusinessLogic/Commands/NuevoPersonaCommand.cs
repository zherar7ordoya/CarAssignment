using Integrador.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.BusinessLogic.Commands;

public class NuevoPersonaCommand(BindingSource bindingSource, Button nuevoPersonaButton) : ICommand
{
    private readonly BindingSource _bindingSource = bindingSource;
    private readonly Button _nuevoPersonaButton = nuevoPersonaButton;

    public void Execute()
    {
        var nuevoPersona = new Persona();
        _bindingSource.Add(nuevoPersona);
        _bindingSource.MoveLast();
        _nuevoPersonaButton.Enabled = false;
    }

    public void Undo() { /* Opcional: Lógica para deshacer la creación del borrador. */ }
}