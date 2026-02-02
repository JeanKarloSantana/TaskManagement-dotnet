using ErrorOr;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.ApplicationUsers;

namespace TaskManagement.Application.ApplicationUsers.Commands

{
  public class CreateApplicationUserCommandHandler(IApplicationUserRepository applicationUserRepository, IUnitOfWork unitOfWork) //: IRequestHandler<CreateApplicationUserCommand, ErrorOr<ApplicationUser>>
  {
    private readonly IApplicationUserRepository _applicationUserRepository = applicationUserRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    /*public async Task<ErrorOr<ApplicationUser>> Handle(CreateApplicationUserCommand request, CancellationToken cancellationToken)
    {
      var user = new ApplicationUser
      {
        UserName = username,
        Email = email,
        EmailConfirmed = false
      };

      var result = await _userManager.CreateAsync(user, password);

      if (!result.Succeeded)
      {
        // handle errors
      }
    }*/
  }
}