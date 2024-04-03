using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Admin_Panel.Business.Implementations;
using Admin_Panel.Bussines.Extensions;

namespace Portfolio.Web.Areas.Admin.Components;

public class LeftSideBarViewComponent : ViewComponent
{
    #region Fields

    public readonly IUserService _UserService;

    #endregion

    #region Constructor

    public LeftSideBarViewComponent(IUserService userService)
    {
        _UserService = userService;
    }

    #endregion

    #region Methods

    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewData["User"] = await _UserService.GetInformationAsync(User.GetUserId());
        return View("LeftSideBar");
    }

    #endregion
}