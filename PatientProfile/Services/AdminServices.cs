using PatientProfile.DbContext.Entity;
using PatientProfile.DbContext.Repositories.Base.Interfaces;
using PatientProfile.Instructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientProfile.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IRepository<Admin> _adminRepository;

        public AdminServices(IRepository<Admin> adminRepository)
        {
            this._adminRepository = adminRepository;
        }
        public void AddAsync(Admin admin)
        {
            _adminRepository.AddAsync(admin);
        }

        public async Task DeleteAsync(Admin admin)
        {
            await _adminRepository.DeleteAsync(admin);
        }

        public List<Admin> GetAllAsync(string AdId)
        {
            return (List<Admin>)_adminRepository.GetAll().Where(x=>x.AdminId==AdId);
        }

        public async Task<Admin> GetByIdAsync(int id)
        {
             return await _adminRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Admin admin)
        {
            await _adminRepository.UpdateAsync(admin);
        }
    }
}
