using MediatR;
using VelorusNet8.Application.Dto.User;

namespace VelorusNet8.Application.Queries.UserAccount;

public class GetUserAcountByIdQuery : IRequest<UserAccountDto>
{
    public int userId { get; set; }

    public GetUserAcountByIdQuery(int userId)
    {
        this.userId = userId;
    }
}
