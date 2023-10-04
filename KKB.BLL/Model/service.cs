using System;
using AutoMapper;
using KKB.DAL.Model;
using KKB.DAL;
using KKB.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BLL.Model
{
    public abstract class service<T>
    {
        protected readonly IRepository<T> repo = null;
        protected readonly IMapper iMapper = null;
        public service(string connectionString)
        {
            repo = new Repository<T>(connectionString);
            iMapper = new MapperConfiguration(
                 cfg =>
                 {
                     cfg.CreateMap<Client, ClientDTO>().ReverseMap();
                     cfg.CreateMap<Account, AccountDTO>().ReverseMap();
                 }).CreateMapper();
        }

        public service()
        {

        }

    }
}
