using Bulky.Application.AppModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Bulky.Models.ViewModels
{
    public class AuthorViewModel
    {
        public AuthorAppModel Author { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> PublishingHouseList { get; set; }
    }
}