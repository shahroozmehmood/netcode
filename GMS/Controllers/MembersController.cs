using GMS.Repository.Contract;
using GMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GMS.Common;

namespace GMS.Controllers
{
   
    public class MembersController : ParentAPIController
    {
        IMembersService _memberService;
        public MembersController(IMembersService service)
        {
            _memberService = service;
        }

        /// <summary>
        /// save members
        /// </summary>
        /// <param name="membersModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveMembers")]
        [AuthorizeUserFilter]
        public IActionResult SaveMembers(Members membersModel)
        {
            try
            {
                var model = _memberService.SaveMember(membersModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }

}
