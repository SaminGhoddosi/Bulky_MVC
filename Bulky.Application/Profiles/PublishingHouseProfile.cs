using AutoMapper;
using Bulky.Application.AppModel;
using Bulky.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Application.Profiles
{
    public class PublishingHouseProfile : Profile
    {
        public PublishingHouseProfile()
        {
            CreateMap<PublishingHouseAppModel, PublishingHouse>(MemberList.None).ReverseMap();
        }
    }
}
