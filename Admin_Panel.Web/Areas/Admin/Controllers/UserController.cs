using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Admin_Panel.Business.Implementations;
using Admin_Panel.DAL.ViewModels.User;
using Admin_Panel.Web.Areas.Admin.Controllers;

namespace Portfolio.Web.Areas.Admin
{
    public class UserController : adminBaseController
    {
        #region Fields

        private readonly IUserService _UserService;


        #endregion

        #region  Constructor

        public UserController(IUserService userService)
        {
            _UserService = userService;
        }

        #endregion

        #region Actions

        #region List

        public async Task<IActionResult> List(FilterUserViewModel filter)
        {
            var result = await _UserService.FilterAsync(filter);

            return View(result);
        }

        #endregion

        #region  Create

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _UserService.CreateAsync(model);

            #region check result

            switch (result)
            {
                case CreateUserResult.Success:
                    break;
                case CreateUserResult.Error:
                    break;
                default:
                    break;
            }

            #endregion

            return View();
        }

        #endregion

        #region  Update

        public async Task<IActionResult> Update(string id)
        {
            var user = await _UserService.GetForEditByIdAsync(id);

            if (user == null)
                return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditUserViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _UserService.UpdateAsync(model);

            return View();
        }

        #endregion

        #endregion
    }
}