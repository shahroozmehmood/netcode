using GMS.Models;
using GMS.ViewModels;

namespace GMS.Repository.Contract
{
    public interface IMembersService
    {
        /// <summary>
        /// get list of all members
        /// </summary>
        /// <returns></returns>
        List<Member> GetMembersList();

        /// <summary>
        /// get member details by member id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Member GetMemberDetailsById(int id);

        /// <summary>
        ///  add edit members
        /// </summary>
        /// <param name="membersModel"></param>
        /// <returns></returns>
        ResponseModel SaveMember(Member membersModel);


        /// <summary>
        /// delete member
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
      //  ResponseModel DeleteMember(int id);
    }
}
