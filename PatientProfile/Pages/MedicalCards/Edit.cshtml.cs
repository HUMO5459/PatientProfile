using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatientProfile.DbContext.Entity;
using PatientProfile.Instructor;

namespace PatientProfile.Pages.MedicalCards
{
    public class EditModel : PageModel
    {
        private readonly IMedicalCardServices _cardServices;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IMedicalCardServices cardServices,
            IWebHostEnvironment webHostEnvironment)
        {
            _cardServices = cardServices;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public MedicalCard MedicalCard { get; set; }
        public IFormFile InputFile { get; set; }

        public IActionResult OnGetAsync(int id)
        {
           MedicalCard = _cardServices.GetByIdAsync(id).Result;

            if (MedicalCard == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostAsync()
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
                InputFile.CopyToAsync(fileStream);
            }
            MedicalCard.AdditionalFiles = "/UploadFiles/" + fileName;
            _cardServices.UpdateAsync(MedicalCard);

            return RedirectToPage("./Index");
        }
    }
}
