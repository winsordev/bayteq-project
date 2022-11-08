using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetstoreApp.Models;
using PetstoreApp.Services;
using PetstoreApp.Utils;

namespace PetstoreApp.Controllers
{
    public class MascotaController : Controller
    {
        private readonly IMascotaServices _mascotaService;
        public MascotaController(IMascotaServices mascotaService)
        {
            _mascotaService = mascotaService;
        }
        public async Task<IActionResult> Index()
        {
            var statusId = Request.Query["MascotaStatus"].FirstOrDefault();
            var mascotaUI = new MascotaUI();

            mascotaUI.SelectStatuses = new List<SelectListItem>();

            foreach (var status in (Utilities.Status[])Enum.GetValues(typeof(Utilities.Status)))
            {
                mascotaUI.SelectStatuses.Add(new SelectListItem()
                {
                    Value = ((int)status).ToString(),
                    Text = status.ToString(),
                    Selected = statusId == ((int)status).ToString()
                });
            }

            if (!String.IsNullOrEmpty(statusId))
            {
                mascotaUI.status = statusId;
            }
            else
            {
                mascotaUI.status = "0";
            }

            var mascotas = await _mascotaService.GetByStatus(mascotaUI.status);
            if (mascotas != null)
                mascotaUI.MascotaList = mascotas;

            return View(mascotaUI);
        }
    }
}
