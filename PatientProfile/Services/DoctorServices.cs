using PatientProfile.DbContext.Entity;
using PatientProfile.DbContext.Repositories.Base.Interfaces;
using PatientProfile.Instructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientProfile.Services
{
    public class DoctorServices : IDoctorServices
    {
        private readonly IRepository<Doctor> _repository;

        public DoctorServices(IRepository<Doctor> repository)
        {
            _repository = repository;
        }
        public async Task CreateAsync(Doctor doctor)
        {
            await _repository.AddAsync(doctor);
        }

        public async Task DeleteAsync(Doctor doctor)
        {
            if(doctor != null)
            {
                await _repository.DeleteAsync(doctor);
            }
        }

        public List<Doctor> GetAllAsync(string AdId)
        {

            var result = _repository.GetAll().Where(x=>x.AdminId == AdId).ToList();
            return result;
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return result;
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            await _repository.UpdateAsync(doctor);
        }
    }
}
