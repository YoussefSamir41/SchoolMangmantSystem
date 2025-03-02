﻿using Data.Entities.Sec;
using Data.Requests;
using Microsoft.AspNetCore.Identity;
namespace Service.Abstracts
{
    public interface IAuthorizationService
    {
        public Task<string> AddRoleAsync(string roleName);
        public Task<bool> IsRoleExistByName(string roleName);
        public Task<string> EditRoleAsync(EditRoleRequest request);
        public Task<string> DeleteRoleAsync(int roleId);
        public Task<bool> IsRoleExistById(int roleId);
        public Task<List<IdentityRole<int>>> GetRolesList();
        public Task<IdentityRole<int>> GetRoleById(int id);
        public Task<ManageUserRolesResultTemp> ManageUserRolesData(User user);


        //public Task<string> UpdateUserRoles(UpdateUserRolesRequest request);
        //public Task<ManageUserClaimsResult> ManageUserClaimData(User user);
        //public Task<string> UpdateUserClaims(UpdateUserClaimsRequest request);

    }
}
