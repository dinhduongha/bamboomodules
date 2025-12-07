namespace Bamboo.Admin.Domain.Shared.Enums
{

    public enum TenantMemberStatus
    {
        Pending = 0,
        Active = 1,     // Đang hoạt động
        Invited = 2,    // Đã gửi email mời, chưa click link
        Rejected = 3,
        Suspended = 4   // Bị chặn khỏi Tenant này (nhưng user gốc vẫn sống)
    }

    public enum InvitationStatus
    {
        Pending = 0,
        Accepted = 1,
        Rejected = 2,
        Leaved = 3,
        Suspended = 4,
        Disabled = 5
    }
}
