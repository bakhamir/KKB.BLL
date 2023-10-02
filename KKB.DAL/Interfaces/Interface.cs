using System;
using KKB.DAL.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.DAL.Interfaces
{
    public interface IRepository<T> 
    {
        ReturnResult<T> Get();
        ReturnResult<T> Create(T data);
    }
}
