using System.Threading.Tasks;
using VelorusNet8.Application.Dto.User;

namespace VelorusNet8.Application.Interface;

public interface IUserAccountService
{
    Task<UserAccountDto> GetUserByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<UserAccountDto>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task CreateUserAsync(CreateUserDto createUserDto, CancellationToken cancellationToken);
    Task UpdateUserAsync(int id, UpdateUserDto updateUserDto, CancellationToken cancellationToken);
    Task DeactivateUserAsync(int id, CancellationToken cancellationToken);
    Task ReactivateUserAsync(int id, CancellationToken cancellationToken);
}