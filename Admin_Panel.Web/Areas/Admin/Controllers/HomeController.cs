
using Microsoft.AspNetCore.Mvc;

namespace Admin_Panel.Web.Areas.Admin.Controllers;
public class HomeController:adminBaseController
{
    #region Actions
    public IActionResult Index()
    {
        return View();
    }
    
    #endregion
}
