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

namespace PatientProfile.Pages.MedicalCards
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMedicalCardServices _cardServices;

        public IndexModel(UserManager<IdentityUser> userManager,
            IMedicalCardServices cardServices)
        {
            _userManager = userManager;
            _cardServices = cardServices;
        }

        public IList<MedicalCard> MedicalCard { get;set; }

        public IActionResult OnGetAsync()
        {
            string AdminId = _userManager.GetUserId(this.User);
            MedicalCard = _cardServices.GetAllAsync(AdminId);
            return Page();
        }
    }
}
