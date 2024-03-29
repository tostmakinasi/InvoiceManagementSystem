﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InvoiceManagement.Web.Extensions
{
    public static class ModelStateExtension
    {
        public static void AddModelErrorList(this ModelStateDictionary modelState, List<string> errors)
        {
            errors.ForEach(item =>
            {
                modelState.AddModelError(string.Empty, item);
            });
        }

        public static void AddModelErrorList(this ModelStateDictionary modelState, IEnumerable<IdentityError> Errors)
        {
            modelState.AddModelErrorList(Errors.Select(x => x.Description).ToList());
        }
    }
}
