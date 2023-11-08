using InvoiceManagement.Core.OptionsModels;
using InvoiceManagement.Core.ResultModels;
using InvoiceManagement.Core.ViewModels;

namespace InvoiceManagement.Core.Services
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetUserViewModelList();

        Task<CustomServiceResult<TokenResult>> PreRegistration(UserPreRegistrationViewModel model);

        Task DeleteUser(string id);
    }
}
