using GMS.Common;
using GMS.Serializer;
//using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
//using GMS.Models;
using System.Text.Json.Nodes;
using GMS.Models;

namespace GMS.Manager
{
    public class UserAuthenticationManager
    {
      //  private readonly IUserService _IUserService;
        private Utilities utilities;
        
        private GMSDbContext _context;
        //public UserAuthenticationManager(IUserService IUserService)
        //{
        //    _IUserService = IUserService;
        //}
        public UserAuthenticationManager()
        {
         
        }

        public UserRoleSerializer AuthorizeUser(string apiKey)
        {
            _context = new GMSDbContext(); 
            try
            {

                var userRoleModel = (from e in _context.Users
                                     join p in _context.UserRoles on e.Id equals p.UserId
                                     join d in _context.Roles on p.RoleId equals d.Id
                                     where e.Token == apiKey && e.IsActive==true && e.IsDeleted==false
                                     select new UserRoleSerializer
                                     {
                                         user_id = e.Id,
                                         user_role = d.Name
                                     }).FirstOrDefault();
                return userRoleModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}
