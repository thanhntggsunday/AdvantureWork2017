using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.Portal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AdvantureWork.Portal.Areas.Admin.Controllers
{
    public class UsersController : AminBaseController
    {
        private readonly IUserApiClient _userApiClient;

        public UsersController(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllPaging()
        {
            var result = new DataTableViewModel<AppUserDTO>();
            // Request.Query["oauth_verifier"]
            var draw = Request.Query["draw"].FirstOrDefault();
            var start = Request.Query["start"].FirstOrDefault();
            var length = Request.Query["length"].FirstOrDefault();
            var search = Request.Query["search[value]"].FirstOrDefault();

            var request = new DataTableRequest();

            request.Draw = draw;
            request.Length = length;
            request.Search = search;
            request.Start = start;

            result = _userApiClient.GetAllPaging(request).GetAwaiter().GetResult();

            return Ok(result);
        }

        public ActionResult Edit(string userId)
        {
            AppUserDTO viewModel = new AppUserDTO();
            viewModel.Id = Guid.Parse(userId);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditSave(AppUserRequest vm)
        {
            var result = _userApiClient.Update(vm);

            return Ok(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSave(AppUserRequest vm)
        {
            var result = _userApiClient.Create(vm);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult Delete(AppUserRequest vm)
        {
            var result = _userApiClient.Delete(vm);

            return Ok(result);
        }

        public ActionResult GetById(AppUserRequest request)
        {
            var result = _userApiClient.GetById(request);

            return Ok(result);
        }
    }
}