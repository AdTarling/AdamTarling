using adamtarling.web.Models;
using System.Collections.Generic;

namespace adamtarling.web.ViewModels.Components
{
    public class ContactDetailsViewModel : ComponentBaseViewModel
    {
        public string Title { get; set; }
        public string Copy { get; set; }
        public IEnumerable<ContactDetailBlock> ContactDetailBlocks { get; set; }
    }
}