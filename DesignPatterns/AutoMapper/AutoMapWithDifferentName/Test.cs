using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace DesignPatterns.AutoMapper.AutoMapWithDifferentName
{
    public class Test
    {
        static void Main()
        {
            Aurthor aur = new Aurthor("sanju", "Giri", 152454554);
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<Aurthor, AurthorDTO>()
                .ForMember(dest=>dest.FN,opt=>opt.MapFrom(src=>src.FirstName))
                .ForMember(dest=>dest.LN,opt=>opt.MapFrom(src=>src.LastName))
                .ForMember(dest=>dest.PN,opt=>opt.MapFrom(src=>src.PhoneNumber)); });
            IMapper mapper=config.CreateMapper();
            AurthorDTO a=mapper.Map<Aurthor, AurthorDTO>(aur);
            Console.WriteLine($"AurthorName: {a.FN}\nLastName: {a.LN}\nPhoneNumber:{a.PN}");
        }
    }
}
