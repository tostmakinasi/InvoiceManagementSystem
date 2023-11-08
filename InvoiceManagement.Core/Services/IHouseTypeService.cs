using InvoiceManagement.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Core.Services
{
    public interface IHouseTypeService
    {
        Task<List<HouseTypeViewModel>> GetHouseTypes();
        

    }
}
