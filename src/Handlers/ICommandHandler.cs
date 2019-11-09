using System.Threading.Tasks;
using Commands;

namespace Handlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}