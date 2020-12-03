using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatientProfile.DbContext.Entity;
using PatientProfile.Instructor;
using System.Threading.Tasks;

namespace PatientProfile.Pages.MedicalCards
{
    public class DeleteModel : PageModel
    {
        private readonly IMedicalCardServices _cardServices;

        public DeleteModel(IMedicalCardServices cardServices)
        {
            _cardServices = cardServices;
        }

        [BindProperty]
        public MedicalCard MedicalCard { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            MedicalCard = await _cardServices.GetByIdAsync(id);

            if (MedicalCard == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            MedicalCard = await _cardServices.GetByIdAsync(id);
            if (MedicalCard != null)
            {
                await _cardServices.DeleteAsync(MedicalCard);
            }

            return RedirectToPage("./Index");
        }
    }
}
