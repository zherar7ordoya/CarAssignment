﻿using MediatR;

namespace Integrador.Application.Commands;

public record DeletePersonCommand(int PersonId) : IRequest<Unit>;