using AutoMapper;
using InvoiceManagement.Core.Models;
using InvoiceManagement.Core.OptionsModels;
using InvoiceManagement.Core.ResultModels;
using InvoiceManagement.Core.Services;
using InvoiceManagement.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IApartmentService _apartmentService;
        private readonly IMapper _mapper;
        public UserService(UserManager<User> userManager, IMapper mapper, IApartmentService apartmentService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _apartmentService = apartmentService;
          
        }

        public async Task<CustomServiceResult<TokenResult>> PreRegistration(UserPreRegistrationViewModel model)
        {
            var user = _mapper.Map<User>(model);

            var identityResult = await _userManager.CreateAsync(user);

            if(identityResult.Succeeded)
            {
                await _apartmentService.ChangeAvaibleStatus(model.ApartmentId, false);

                string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                return CustomServiceResult<TokenResult>.Success(new TokenResult { Id = user.Id, Token = token });
            }

            return CustomServiceResult<TokenResult>.Fail(identityResult.Errors.Select(x => x.Description).ToList());
        }

        public async Task<List<UserViewModel>> GetUserViewModelList()
        {
            var userList = await _userManager.Users.Include(x=> x.Apartment).ToListAsync();

            var userViewModelList = _mapper.Map<List<UserViewModel>>(userList);

            return userViewModelList;
        }

        public async Task DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            await _userManager.DeleteAsync(user);

            var apartment = await _apartmentService.GetByIdAsync((int)user.ApartmentId);
            apartment.IsAvailable = true;
            await _apartmentService.UpdateAsync(apartment);
        }
    }
}
