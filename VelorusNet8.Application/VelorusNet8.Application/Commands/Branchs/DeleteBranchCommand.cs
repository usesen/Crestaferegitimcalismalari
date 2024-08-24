using MediatR;

namespace VelorusNet8.Application.Commands.Branchs;

public class DeleteBranchCommand : IRequest 
{
    public string BranchCode { get; set; }
}