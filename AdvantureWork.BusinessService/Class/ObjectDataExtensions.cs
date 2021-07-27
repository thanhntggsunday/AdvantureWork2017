using AdvantureWork.Common.DTO;
using AdvantureWork.Model.Entities;

namespace AdvantureWork.BusinessService.Class
{
    public static class ObjectDataExtensions
    {
        public static void CopyFromAppRoleDataModel(this AppRoleDTO roleDTO, AppRole appRole)
        {
            roleDTO.Id = appRole.Id;
            roleDTO.Name = appRole.Name;
            roleDTO.Description = appRole.Description;
        }

        //public static void CopyFromAppRoleDataModel(this RoleViewModel vm, AppRole appRole)
        //{
        //    vm.Id = appRole.Id;
        //    vm.Name = appRole.Name;
        //    vm.Description = appRole.Description;
        //}

        public static void CopyFromUserDTO(this AppUser appUser, AppUserDTO appUserDto)
        {
            appUser.Id = appUserDto.Id;
            appUser.FullName = appUserDto.FullName;
            appUser.BirthDay = appUserDto.BirthDay;
            appUser.Email = appUserDto.Email;
            appUser.Address = appUserDto.Address;
            appUser.UserName = appUserDto.Email;
            appUser.PhoneNumber = appUserDto.PhoneNumber;
            appUser.Gender = appUserDto.Gender;
            appUser.Status = appUserDto.Status;
            appUser.Address = appUserDto.Address;
            appUser.Avatar = appUserDto.Avatar;
            appUser.City = appUserDto.City;
            appUser.Country = appUserDto.Country;
            appUser.Postcode = appUserDto.Postcode;
            appUser.CountryRegionCode = appUserDto.CountryRegionCode;
        }

        public static void CopyFromUserDataModel(this AppUserDTO appUserDto, AppUser appUser)
        {
            appUserDto.Id = appUser.Id;
            appUserDto.FullName = appUser.FullName;
            appUserDto.BirthDay = appUser.BirthDay;
            appUserDto.Email = appUser.Email;
            appUserDto.Address = appUser.Address;
            appUserDto.UserName = appUser.UserName;
            appUserDto.PhoneNumber = appUser.PhoneNumber;
            appUserDto.Gender = appUser.Gender;
            appUserDto.Status = appUser.Status;
            appUserDto.Address = appUser.Address;
            appUserDto.Avatar = appUser.Avatar;
            appUserDto.PasswordHash = appUser.PasswordHash;
            appUserDto.PasswordHash = appUser.PasswordHash;
            appUserDto.City = appUser.City;
            appUserDto.Country = appUser.Country;
            appUserDto.Postcode = appUser.Postcode;
            appUserDto.CountryRegionCode = appUser.CountryRegionCode;
        }

     

       
    }
}