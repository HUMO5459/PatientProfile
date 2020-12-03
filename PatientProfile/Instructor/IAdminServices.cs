using PatientProfile.DbContext.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientProfile.Instructor
{
    public interface IAdminServices
    {
        List<Admin> GetAllAsync(string AdId);
        Task<Admin> GetByIdAsync(int id);
        Task UpdateAsync(Admin admin);
        Task DeleteAsync(Admin admin);
        void AddAsync(Admin admin);
    }
}
