using LeaveManagement.Models;
using LeaveManagement.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Controllers
{
    [Route("leave-type")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class LeaveTypeController : Controller
    {
        private readonly ILeaveRepository _leaveRepository = null;

        public LeaveTypeController(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }


        public async Task<IActionResult> Index()
        {
            var model = await _leaveRepository.GetAllLeaveTypes();
            return View(model);
        }

        [Route("add-leave-type")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("add-leave-type")]
        public async Task<IActionResult> Create(LeaveTypeModel model)
        {
            if (ModelState.IsValid)
            {
                int id = await _leaveRepository.AddNewLeaveType(model);

                if(id > 0)
                {
                    return RedirectToAction(nameof(Create));
                }
            }

            //Send custom error message to validation summary
            ModelState.AddModelError("", "This is a custom error message");


            return View();
        }

        [Route("edit-leave-type")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _leaveRepository.GetLeaveTypeById(id);
            return View(model);
        }

        [HttpPost]
        [Route("edit-leave-type")]
        public async Task<IActionResult> Edit(LeaveTypeModel model)
        {
            if (ModelState.IsValid)
            {
                //Write your code
                var result = await _leaveRepository.EditLeaveType(model);

                if (result < 0)
                {                    

                    return View();
                }

                ModelState.Clear();

                return RedirectToAction("Index");
            }

            return View();
        }


        [Route("delete-leave-type")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                //Write your code
                var result = await _leaveRepository.DeleteLeaveType(id);

                if (result < 0)
                {

                    return View();
                }

                ModelState.Clear();

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
