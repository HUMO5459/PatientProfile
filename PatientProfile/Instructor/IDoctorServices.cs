using PatientProfile.DbContext.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientProfile.Instructor
{
    public interface IDoctorServices
    {
        List<Doctor> GetAllAsync(string AdId);
        Task<Doctor> GetByIdAsync(int id);
        Task UpdateAsync(Doctor doctor);
        Task DeleteAsync(Doctor doctor);
        Task CreateAsync(Doctor doctor);
    }
}
