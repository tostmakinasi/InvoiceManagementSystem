using Microsoft.AspNetCore.Identity;

namespace InvoiceManagement.Core.Models
{
    public abstract class BaseModel:IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
