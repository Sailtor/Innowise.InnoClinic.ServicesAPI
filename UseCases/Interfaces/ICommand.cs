using MediatR;

namespace UseCases.Interfaces
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
    public interface ICommand : IRequest
    {
    }
}
