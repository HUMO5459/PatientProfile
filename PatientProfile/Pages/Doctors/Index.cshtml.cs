using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PatientProfile.DbContext.Entity;
using PatientProfile.DbContext.Repositories.Base.Interfaces;
using PatientProfile.Instructor;

namespace PatientProfile.Pages.Doctors
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IDoctorServices _doctorServices;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(IDoctorServices doctorServices,
            UserManager<IdentityUser> userManager)
        {
            _doctorServices = doctorServices;
            _userManager = userManager;
        }

        public IList<Doctor> Doctor { get; set; }

        public IActionResult OnGetAsync()
        {
            string AdminId = _userManager.GetUserId(this.User);
            
            Doctor = _doctorServices.GetAllAsync(AdminId).ToList();

            return Page();
        }
    }
}
