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
    public class DeleteModel : PageModel
    {
        private readonly IDoctorServices _doctorServices;

        public DeleteModel(IDoctorServices doctorServices)
        {
            _doctorServices = doctorServices;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Doctor = await _doctorServices.GetByIdAsync(id);

            if (Doctor != null)
            {
                await _doctorServices.DeleteAsync(Doctor);
            }

            return RedirectToPage("./Index");
        }
    }
}
