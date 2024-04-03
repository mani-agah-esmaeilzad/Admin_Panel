using Microsoft.AspNetCore.Mvc;
using Admin_Panel.Business.Implementations;
using Admin_Panel.DAL.ViewModels.ContactUs;
using Admin_Panel.Web.Areas.Admin.Controllers;

namespace Admin_Panel.Web.Areas.Admin;

public class ContactUsController : adminBaseController
{
    #region Fields

    private readonly IContactUsService _contactUsService;

    #endregion

    #region Constructor

    public ContactUsController(IContactUsService contactUsService)
    {
        _contactUsService = contactUsService;
    }

    #endregion

    #region Actions

    #region List

    public async Task<IActionResult> List(FilterContactUsViewModel model)
    {
        var filter = await _contactUsService.FilterAsync(model);
        return View(filter);
    }

    #endregion

    #region Details

    public async Task<IActionResult> Details(string id)
    {
        var contact = await _contactUsService.GetByIdAsync(id);

        if (contact == null)
            return NotFound();

        return View(contact);
    }

    [HttpPost]
    public async Task<IActionResult> Details(DetailContactUsViewModel model)
    {
        #region validations

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        #endregion

        var result = await _contactUsService.AnswerAsync(model);

        switch (result)
        {
            case AnswerResult.Success:
                TempData[SuccessMessage] = "The answer was well sent";
                break;
            case AnswerResult.ContactUsNotFound:
                TempData[ErrorMessage] = "answer is not found";
                break;
            case AnswerResult.AnswerIsNull:
                TempData[ErrorMessage] = "answer is empty";
                break;
            default:
                break;
        }

        return View(model);
    }

    #endregion

    #endregion
}