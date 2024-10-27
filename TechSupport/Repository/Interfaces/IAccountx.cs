using TechSupport.Models.Dto;

namespace TechSupport.Repository.Interfaces
{
    public interface IAccountx
    {
        public Task<AccountDto> Register(RegisterdAccountDto registerdAccountDto);
        public Task<AccountDto> AccountAuthentication(string username, string password);
        public Task LogOut(string username);
    }
}
