using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IErrorLogRepo
    {
        Task<bool> Create(ApplicationsErrorlog products);
        Task<ApplicationsErrorlog> GetbyId(string id);
        Task<IEnumerable<ApplicationsErrorlog>> GetAll();
    }
}
