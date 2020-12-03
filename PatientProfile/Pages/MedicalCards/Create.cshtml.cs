using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatientProfile.DbContext.Entity;
using PatientProfile.Instructor;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PatientProfile.Pages.MedicalCards
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMedicalCardServices _cardServices;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(UserManager<IdentityUser> userManager,
            IMedicalCardServices cardServices,
            IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _cardServices = cardServices;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MedicalCard MedicalCard { get; set; }
        public IFormFile InputFile { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string wwwroot = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(InputFile.FileName);
            string extension = Path.GetExtension(InputFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            string path = Path.Combine(wwwroot + "/UploadFiles/" + fileName);
            
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await InputFile.CopyToAsync(fileStream);
            }

            MedicalCard.AdditionalFiles = "/UploadFiles/" + fileName;
            MedicalCard.AdminId = _userManager.GetUserId(this.User).ToString();
            
            await _cardServices.CreateAsync(MedicalCard);

            return RedirectToPage("./Index");
        }
    }
}
