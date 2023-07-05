using Microsoft.AspNetCore.Identity;

namespace InvoiceManagement.Core.Models
{
    public abstract class BaseModel : IdentityUser, IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? UpdatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
