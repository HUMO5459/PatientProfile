using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatientProfile.DbContext.Entity;
using PatientProfile.Instructor;

namespace PatientProfile.Pages.MedicalCards
{
    public class DetailsModel : PageModel
    {
        private readonly IMedicalCardServices _cardServices;

        public DetailsModel(IMedicalCardServices cardServices)
        {
            _cardServices = cardServices;
        }

        public MedicalCard MedicalCard { get; set; }

        public async System.Threading.Tasks.Task<IActionResult> OnGetAsync(int id)
        {
            MedicalCard = await _cardServices.GetByIdAsync(id);

            if (MedicalCard == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
