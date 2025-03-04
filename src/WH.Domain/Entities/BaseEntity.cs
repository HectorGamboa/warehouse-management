namespace WH.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool State { get; set; } = false;
        public bool IsDelete { get; set; } = false;
        public DateTime AuditCreateDate { get; set; }
        public DateTime? AuditUpdateDate { get; set; }
        public DateTime? AuditDeleteDate { get; set; }
    }
}
