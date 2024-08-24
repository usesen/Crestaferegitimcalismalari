using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Exceptions;
using VelorusNet8.Domain.Repositories;

namespace VelorusNet8.Domain.Services.UserAccountService;

public class UserAccountDomainService : IUserAccountDomainService
{
    private readonly IUserAccountRepository _userAccountRepository;

    public UserAccountDomainService(IUserAccountRepository userAccountRepository)
    {
        _userAccountRepository = userAccountRepository;
    }

    public async Task CreateAsync(UserAccount entity, CancellationToken cancellationToken)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        // İlgili iş mantığını burada gerçekleştirin
        // Örneğin, kullanıcı var mı kontrol edin, vs.

        await _userAccountRepository.CreateAsync(entity, cancellationToken);
    }

    public async Task DeleteAsync(UserAccount entity, CancellationToken cancellationToken)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        // Kullanıcıyı silme işlemine başlamadan önce iş mantığı burada yapılabilir
        // Örneğin, kullanıcı mevcut mu kontrol edin, vs.

        await _userAccountRepository.DeleteAsync(entity, cancellationToken);
    }

    public async Task<IEnumerable<UserAccount>> GetAllAsync(CancellationToken cancellationToken)
    {
        // Kullanıcıları almak için repository metodunu çağırıyoruz
        return await _userAccountRepository.GetAllAsync(cancellationToken);
    }

    public async Task<UserAccount> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be null or empty.", nameof(email));
        }

        // Kullanıcıyı email ile almak için repository metodunu çağırıyoruz
        var user = await _userAccountRepository.GetByEmailAsync(email, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException($"User with email {email} not found.");
        }

        return user;
    }

    public async Task<UserAccount> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        if (id <= 0)
        {
            throw new ArgumentException("ID must be greater than zero.", nameof(id));
        }

        // Kullanıcıyı ID ile almak için repository metodunu çağırıyoruz
        var user = await _userAccountRepository.GetByIdAsync(id, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException($"User with ID {id} not found.");
        }

        return user;
    }

    public async Task<UserAccount> GetByUserNameAsync(string username, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Username cannot be null or empty.", nameof(username));
        }

        // Kullanıcıyı kullanıcı adı ile almak için repository metodunu çağırıyoruz
        var user = await _userAccountRepository.GetByUserNameAsync(username, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException($"User with username {username} not found.");
        }

        return user;
    }

    public async Task UpdateAsync(UserAccount entity, CancellationToken cancellationToken)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        // Kullanıcıyı güncellemeden önce iş mantığı burada yapılabilir
        // Örneğin, kullanıcı var mı kontrol edin, vs.

        await _userAccountRepository.UpdateAsync(entity, cancellationToken);
    }
}
