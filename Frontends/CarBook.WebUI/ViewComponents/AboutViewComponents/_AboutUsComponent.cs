using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
