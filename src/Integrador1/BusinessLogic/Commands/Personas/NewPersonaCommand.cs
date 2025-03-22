using Integrador.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.BusinessLogic.Commands.Personas;

public class NewPersonaCommand(BindingSource bindingSource, Button nuevoPersonaButton) : ICommand
{
    public (bool Success, string ErrorMessage) Execute()
    {
        var nuevoPersona = new Persona();
        bindingSource.Add(nuevoPersona);
        bindingSource.MoveLast();
        nuevoPersonaButton.Enabled = false;
        return (true, string.Empty);
    }

    public void Undo() { /* Opcional: Lógica para deshacer la creación del borrador. */ }
}
