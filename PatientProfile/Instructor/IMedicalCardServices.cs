using PatientProfile.DbContext.Entity;
using PatientProfile.DbContext.Repositories.Base.Interfaces;
using PatientProfile.Pages.MedicalCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientProfile.Instructor
{
    public interface IMedicalCardServices
    {
        List<MedicalCard> GetAllAsync(string AdId);
        Task<MedicalCard> GetByIdAsync(int id);
        Task UpdateAsync(MedicalCard medicalCard);
        Task DeleteAsync(MedicalCard medicalCard);
        Task CreateAsync(MedicalCard medicalCard);
    }
}
