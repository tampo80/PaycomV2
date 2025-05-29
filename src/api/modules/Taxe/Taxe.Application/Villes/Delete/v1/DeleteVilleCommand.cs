using System;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Villes.Delete.v1;
public record DeleteVilleCommand(Guid Id) : IRequest; 
