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
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAppModel, Category>(MemberList.None).ReverseMap();
        }
    }
}
