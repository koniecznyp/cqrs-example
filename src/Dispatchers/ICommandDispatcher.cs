using System.Threading.Tasks;
using Commands;

namespace Dispatchers
{
    public interface ICommandDispatcher
    {
        Task DispachAsync<T>(T command) where T : ICommand;
    }
}