using Microsoft.AspNetCore.Mvc;

namespace Admin_Panel.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class adminBaseController:Controller
{
    protected string SuccessMessage = "SuccessMessage";
    protected string ErrorMessage = "ErrorMessage";

}