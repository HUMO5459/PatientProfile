using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PatientProfile.DbContext.Entity;
using PatientProfile.DbContext.Repositories.Base.Interfaces;
using PatientProfile.Instructor;

namespace PatientProfile.Pages.Doctors
{
    public class DetailsModel : PageModel
    {
        private readonly IDoctorServices _doctorServices;

        public DetailsModel(IDoctorServices doctorServices)
        {
            _doctorServices = doctorServices;
        }

        public Doctor Doctor { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
           Doctor = await _doctorServices.GetByIdAsync(id);

            if (Doctor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
