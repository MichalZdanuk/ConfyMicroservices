global using MediatR;
global using MassTransit;

global using Shared.CQRS;
global using Shared.Pagination;
global using Shared.Messaging.Consumers;
global using Shared.Messaging.Events;

global using ConferenceManagement.Domain.Repositories;
global using ConferenceManagement.Domain.Exceptions;
global using ConferenceManagement.Domain.ValueObjects;
global using ConferenceManagement.Domain.Events;
global using ConferenceManagement.Domain.Entities;