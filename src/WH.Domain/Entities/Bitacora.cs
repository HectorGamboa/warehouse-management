namespace WH.Domain.Entities
{
    public class Bitacora : BaseEntity
    {
        public string Message { get; set; } = null!;
        public int ModuleId { get; set; }
        public string Module { get; set; } = null!;
        public int UserId { get; set; }
        public string? Documento { get; set; }
        public string Action { get; set; } = null!;
        public bool ActionResult { get; set; } 
        public User User { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
