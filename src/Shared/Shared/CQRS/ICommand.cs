using MediatR;

namespace Shared.CQRS;

public interface ICommand : ICommand<Unit>, IRequest { }
public interface ICommand<TResponse> : IRequest<TResponse> { }
