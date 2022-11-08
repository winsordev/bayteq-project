using Microsoft.AspNetCore.Mvc.Rendering;

namespace PetstoreApp.Models
{
    public class MascotaUI
    {
        public List<Mascota> MascotaList { get; set; }
        public List<SelectListItem> SelectStatuses { set; get; }
        public string status { get; set; }
    }
}
