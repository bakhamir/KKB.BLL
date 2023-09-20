using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KKB.DAL.Model;

namespace KKB.BLL.Model
{
    public static class BllSettings
    {
        public static MapperConfiguration Init()
        {
            return  new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<Client,ClientDTO>().ReverseMap();
            });
        }
    }
}
