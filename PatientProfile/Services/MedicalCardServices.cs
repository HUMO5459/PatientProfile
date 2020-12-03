using Microsoft.AspNetCore.Identity;
using PatientProfile.DbContext.Entity;
using PatientProfile.DbContext.Repositories.Base.Interfaces;
using PatientProfile.Instructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientProfile.Services
{
    public class MedicalCardServices : IMedicalCardServices
    {
        private readonly IRepository<MedicalCard> _repositoryCard;

        public MedicalCardServices(IRepository<MedicalCard> repositoryCard)
        {
            _repositoryCard = repositoryCard;
        }

        public  async Task CreateAsync(MedicalCard medicalCard)
        {
              await _repositoryCard.AddAsync(medicalCard);
        }

        public List<MedicalCard> GetAllAsync(string AdId)
        {
            var card = _repositoryCard.GetAll().Where(x => x.AdminId == AdId).ToList();
            return card;
        }

        public async Task<MedicalCard> GetByIdAsync(int id)
        {
            var result = await _repositoryCard.GetByIdAsync(id);
            return result;
        }

        public async Task DeleteAsync(MedicalCard medicalCard)
        {
            if(medicalCard != null)
            {
                await _repositoryCard.DeleteAsync(medicalCard);
            }
        }
        public async Task UpdateAsync(MedicalCard medicalCard)
        {
            await _repositoryCard.UpdateAsync(medicalCard);
        }
    }
}
