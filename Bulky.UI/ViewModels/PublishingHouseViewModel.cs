using Bulky.Application.AppModel;
using System.Collections.Generic;

namespace Bulky.Models.ViewModels
{
    public class PublishingHouseViewModel
    {
        public PublishingHouseAppModel PublishingHouse { get; set; }
        public IEnumerable<AuthorAppModel> Authors { get; set; }
    }
}