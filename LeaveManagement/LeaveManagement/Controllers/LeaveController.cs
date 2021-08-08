using LeaveManagement.Models;
using LeaveManagement.Repository;
using LeaveManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Controllers
{
    [Authorize]
    public class LeaveController : Controller
    {
        private readonly ILeaveRepository _leaveRepository = null;
        private readonly IUserService _userService = null;

        public LeaveController(ILeaveRepository leaveRepository, IUserService userService)
        {
            _leaveRepository = leaveRepository;
            _userService = userService;
        }

        [Route("leave-applications")]
        public async Task<IActionResult> Index()
        {
            var data = await _leaveRepository.GetAllLeaveApplications();

            return View(data);
        }

        [Route("my-leave-applications")]
        public async Task<IActionResult> GetUserLeaveApplications(string id)
        {
            //var id = _userService.GetUserId();

            var data = await _leaveRepository.GetUserLeaveApplicationsById(id);

            return View(data);
        }

        [Route("leave-apply")]
        [HttpGet]
        public IActionResult Create(bool isSuccess = false, int applicationId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.ApplicationId = applicationId;
            ViewBag.UserId = _userService.GetUserId();

            var data = _leaveRepository.GetUserLeaveApplicationsById(ViewBag.UserId);
            return View();
        }

        [HttpPost]
        [Route("leave-apply")]
        public async Task<IActionResult> Create(LeaveApplicationModel model)
        {
            if (ModelState.IsValid)
            {
                int id = await _leaveRepository.AddNewLeaveApplication(model);

                if (id > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            //Send custom error message to validation summary
            ModelState.AddModelError("", "This is a custom error message");


            return View();
        }
    }
}
