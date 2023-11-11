using InvoiceManagement.Core.OptionsModels;
using InvoiceManagement.Core.ResultModels;
using InvoiceManagement.Core.ViewModels;

namespace InvoiceManagement.Core.Services
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetUserViewModelListAsync();

        Task<CustomServiceResult<NoContentResult>> RegistrationAsync(UserRegistrationViewModel model);

        Task<CustomServiceResult<NoContentResult>> SignInAsync(SignInViewModel model);

        Task DeleteUserAsync(string id);

        Task SignOutAsync();

    }
}
