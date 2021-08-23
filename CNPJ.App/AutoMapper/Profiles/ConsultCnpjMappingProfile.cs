using AutoMapper;
using CNPJ.App.ViewModels;
using CNPJ.Domain.DTO;
using System.Collections.Generic;

namespace CNPJ.App.AutoMapper.Profiles
{
    public class ConsultCnpjMappingProfile : Profile
    {
        public ConsultCnpjMappingProfile()
        {
            CreateMap<CnpjVM, CnpjApiDTO>(MemberList.None);

            CreateMap<ResponseApiWsDTO,ResponseApiWsVM>(MemberList.None);
            CreateMap<ResponseApiWsVM, ResponseApiWsDTO>(MemberList.None);

            CreateMap<ResponseApApiWsDTO, ResponseApApiWsVM>(MemberList.None);
            CreateMap<ResponseApApiWsVM, ResponseApApiWsDTO>(MemberList.None);

            CreateMap<ResponseAsApiWsDTO, ResponseAsApiWsVM>(MemberList.None);
            CreateMap<ResponseAsApiWsVM, ResponseAsApiWsDTO>(MemberList.None);

            CreateMap<ResponseQsaApiWsDTO, ResponseQsaApiWsVM>(MemberList.None);
            CreateMap<ResponseQsaApiWsVM, ResponseQsaApiWsDTO>(MemberList.None);

        }
    }
}
