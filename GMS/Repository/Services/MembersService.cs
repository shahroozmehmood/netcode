using GMS.Repository.Contract;
using GMS.Models;
using GMS.ViewModels;

namespace GMS.Repository.Services
{
    public class MembersService: IMembersService
    {
        private GMSDbContext _context;
        public MembersService(GMSDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// get list of all members
        /// </summary>
        /// <returns></returns>
        public List<Member> GetMembersList()
        {
            List<Member> memberList;
            try
            {
                memberList = _context.Set<Member>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return memberList;
        }
        /// <summary>
        /// get employee details by member id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Member GetMemberDetailsById(int id)
        {
            Member members;
            try
            {
                members = _context.Find<Member>(id);
            }
            catch (Exception)
            {
                throw;
            }
            return members;
        }
        /// <summary>
        ///  add edit member
        /// </summary>
        /// <param name="memberModel"></param>
        /// <returns></returns>
        public ResponseModel SaveMember(Member membersModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Member _temp = GetMemberDetailsById(membersModel.Id);
                if (_temp != null)
                {
                    _temp.Name = membersModel.Name;
                    _temp.FatherHusbandName = membersModel.FatherHusbandName;
                    _temp.MemberNo = membersModel.MemberNo;
                    _temp.RegisterAt = membersModel.RegisterAt;
                    _temp.DateOfBirth = membersModel.DateOfBirth;
                    _temp.Cnic = membersModel.Cnic;
                    _temp.Address = membersModel.Address;
                    _temp.ContactNo = membersModel.ContactNo;
                    _temp.Height = membersModel.Height;
                    _temp.Weight = membersModel.Weight;
                    _temp.Gender = membersModel.Gender;
                    _temp.ModifyBy = membersModel.ModifyBy;
                    _temp.ModifyAt = System.DateTime.Now;
                    _temp.VehicleNumber = membersModel.VehicleNumber;
                    _context.Update<Member>(_temp);
                    model.Messsage = "Member Update Successfully";
                }
                else
                {
                    membersModel.CreatedBy = membersModel.CreatedBy;
                    membersModel.CreatedAt = System.DateTime.Now;
                    _context.Add<Member>(membersModel);
                    model.Messsage = "Member Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}
