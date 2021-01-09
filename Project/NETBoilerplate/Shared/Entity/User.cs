using AdvancedSoftware.DataAccess.Entity;
using NETBoilerplate.Shared.Enums;

namespace NETBoilerplate.Shared.Entity
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public string APIKey { get; set; }
        public string WalletAddress { get; set; }
    }
}