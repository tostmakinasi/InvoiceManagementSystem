using AutoMapper;
using InvoiceManagement.Core.Models;
using InvoiceManagement.Core.OptionsModels;
using InvoiceManagement.Core.ResultModels;
using InvoiceManagement.Core.Services;
using InvoiceManagement.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace InvoiceManagement.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IApartmentService _apartmentService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        public UserService(UserManager<User> userManager, IMapper mapper, IApartmentService apartmentService, IEmailService emailService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _apartmentService = apartmentService;
            _emailService = emailService;
            _signInManager = signInManager;
        }

        public async Task<CustomServiceResult<NoContentResult>> RegistrationAsync(UserRegistrationViewModel model)
        {
            var user = _mapper.Map<User>(model);

            var userPassword = GenerateRandomPassword();
            var identityResult = await _userManager.CreateAsync(user, userPassword);

            if (identityResult.Succeeded)
            {
                await _apartmentService.ChangeAvaibleStatus(model.ApartmentId, false);

                await _emailService.SendAccountCompletionEmail("https://localhost:7064/Home", model.Email, model.FirstName, user.UserName, userPassword);

                return CustomServiceResult<NoContentResult>.Success();
            }

            return CustomServiceResult<NoContentResult>.Fail(identityResult.Errors.Select(x => x.Description).ToList());
        }

        public async Task<List<UserViewModel>> GetUserViewModelListAsync()
        {
            var userList = await _userManager.Users.Include(x => x.Apartment).ToListAsync();

            var userViewModelList = _mapper.Map<List<UserViewModel>>(userList);

            return userViewModelList;
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            await _userManager.DeleteAsync(user);


            var apartment = await _apartmentService.GetByIdAsync((int)user.ApartmentId);
            apartment.IsAvailable = true;
            await _apartmentService.UpdateAsync(apartment);


        }

        private string GenerateRandomPassword()
        {
            const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
            const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digit = "1234567890";
            const string nonAlphanumeric = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            var passwordOptions = _userManager.Options.Password;
            var requiredLength = passwordOptions.RequiredLength;
            string validChars = "";

            if(passwordOptions.RequireUppercase)
                validChars += upperCase;

            if(passwordOptions.RequireLowercase)
                validChars += lowerCase;

            if (passwordOptions.RequireDigit)
                validChars += digit;

            if (passwordOptions.RequireNonAlphanumeric)
                validChars += nonAlphanumeric;


            using (var rng = new RNGCryptoServiceProvider())
            {
                var result = new StringBuilder(requiredLength);
                var buffer = new byte[4];

                while (result.Length < requiredLength)
                {
                    rng.GetBytes(buffer);
                    uint randomValue = BitConverter.ToUInt32(buffer, 0);
                    int index = (int)(randomValue % (uint)validChars.Length);
                    result.Append(validChars[index]);
                }

                return result.ToString();
            }
        }

        public async Task<CustomServiceResult<NoContentResult>> SignInAsync(SignInViewModel model)
        {
            var hasUser = await _userManager.FindByEmailAsync(model.Email);
            if (hasUser == null)
            {
                return CustomServiceResult<NoContentResult>.Fail("Kullanıcı Adı veya Şifreniz Yanlış.");
            }

            var singinResult = await _signInManager.PasswordSignInAsync(hasUser, model.Password, model.RememberMe, true);

            if (singinResult.Succeeded)
            {
                return CustomServiceResult<NoContentResult>.Success();
            }

            if (singinResult.IsLockedOut)
            {
                return CustomServiceResult<NoContentResult>.Fail($"{_userManager.Options.Lockout.DefaultLockoutTimeSpan.Minutes} dakika boyunca giriş yapamazsınız.");
            }

            return CustomServiceResult<NoContentResult>.Fail(new List<string> { "Kullanıcı Adı veya Şifreniz Yanlış.", $" Başarısız Giriş Sayısı :{ await _userManager.GetAccessFailedCountAsync(hasUser)}"});
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
