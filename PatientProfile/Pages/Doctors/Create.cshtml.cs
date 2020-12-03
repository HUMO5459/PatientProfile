using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatientProfile.DbContext.Entity;
using PatientProfile.Instructor;

namespace PatientProfile.Pages.Doctors
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDoctorServices _doctorServices;

        public CreateModel(UserManager<IdentityUser> userManager,
            IWebHostEnvironment webHostEnvironment, 
            IDoctorServices doctorServices)
        {
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _doctorServices = doctorServices;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Doctor Doctor { get; set; }

        public IFormFile ImageFile { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string wwwroot = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string extension = Path.GetExtension(ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            string path = Path.Combine(wwwroot + "/img/" + fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                 await ImageFile.CopyToAsync(fileStream);
            }
            Doctor.Photo = "/img/" + fileName;
            Doctor.AdminId = _userManager.GetUserId(this.User).ToString();

            await _doctorServices.CreateAsync(Doctor);
            
            return RedirectToPage("./Index");
        }
    }
}
