using Microsoft.AspNetCore.Identity;
using XuongMayBE.Models;

namespace XuongMayBE.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}
