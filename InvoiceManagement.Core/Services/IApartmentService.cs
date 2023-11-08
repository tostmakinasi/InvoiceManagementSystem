using InvoiceManagement.Core.Models;
using InvoiceManagement.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Core.Services
{
    public interface IApartmentService : IService<Apartment>
    {
        Task<List<ApartmentListViewModel>> GetApartmentsWithListViewModel();

        Task<bool> CreateAsync(ApartmentCreateViewModel viewModel);
        Task<List<ApartmentSelectionListViewModel>> GetApartmentSelectionListViewModels();

        Task ChangeAvaibleStatus(int id, bool isAvaible);
    }
}
