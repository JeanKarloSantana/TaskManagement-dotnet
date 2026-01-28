using ErrorOr;
using TaskManagement.Application.Common.Interfaces;

namespace TaskManagement.Application.ApplicationUsers.Commands

{
  public class CreateApplicationUserCommandHandler(IApplicationUserRepository applicationUserRepository/*, IUnitOfWork unitOfWork*/) : IRequestHandler<CreateApplicationUserCommand, ErrorOr<ApplicationUser>>
  {
    private readonly IApplicationUserRepository _applicationUserRepository = applicationUserRepository;
    // private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<ApplicationUser>> Handle(CreateApplicationUserCommand request, CancellationToken cancellationToken)
    {
      var applicationUser = new ApplicationUser(
        request.Username,
        request.Email,
        request.EmailConfirmed,
        request.Password
      );

      await _applicationUserRepository.AddApplicationUserAsync(applicationUser);
      //await _unitOfWork.CommitChangesAsync();

      return applicationUser;
    }
  }
}