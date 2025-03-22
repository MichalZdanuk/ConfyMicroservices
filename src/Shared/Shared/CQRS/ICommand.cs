using MediatR;

namespace Shared.CQRS;

public interface ICommand : IRequest { }
public interface ICommand<TResponse> : IRequest<TResponse> { }
