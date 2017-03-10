using adamtarling.web.ViewModels.Components.Interfaces;

namespace adamtarling.web.ViewModels.Components
{
    public class ComponentBaseViewModel : IComponent
    {
        public string DocumentTypeAlias { get; set; }
        public string AnchorTag { get; set; }
    }
}