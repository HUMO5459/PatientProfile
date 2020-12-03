using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatientProfile.DbContext.Entity;
using PatientProfile.Instructor;

namespace PatientProfile.Pages.Doctors
{
    public class EditModel : PageModel
    {
        private readonly PatientProfileDataContext _context;
        private readonly IDoctorServices _doctorServices;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(PatientProfileDataContext context,
            IDoctorServices doctorServices,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _doctorServices = doctorServices;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Doctor Doctor { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Doctor = await _doctorServices.GetByIdAsync(id);

            if (Doctor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string oldPhotoPath = Doctor.Photo;

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
            System.IO.File.Delete(wwwroot + oldPhotoPath);

            await _doctorServices.UpdateAsync(Doctor);

            return RedirectToPage("./Index");
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
