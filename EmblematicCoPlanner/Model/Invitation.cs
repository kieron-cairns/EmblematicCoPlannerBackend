namespace EmblematicCoPlanner.Model;

public class Invitation
{
    public Guid InvitationId { get; set; }
    public Guid TenantId { get; set; }
    public string InvitedEmail { get; set; }
    public string InvitationCode { get; set; }
    public bool IsAccepted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
}