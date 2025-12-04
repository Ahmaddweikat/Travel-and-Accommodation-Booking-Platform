using TABP.Domain.Enums;

namespace TABP.Domain.Entities
{
    public class User : AuditEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.Customer;
    }
}