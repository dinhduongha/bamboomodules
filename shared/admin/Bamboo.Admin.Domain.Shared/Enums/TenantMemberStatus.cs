namespace Bamboo.Admin.Domain.Shared.Enums
{

    public enum TenantMemberStatus
    {
        Pending = 0,
        Active = 1,     // Đang hoạt động
        Leaved = 2,     // Đã rời khỏi Tenant này
        Suspended = 3,  // Bị chặn khỏi Tenant này (nhưng user gốc vẫn sống), vẫn có thể  khôi phục.
        Disabled = 9    // Ngừng hoạt động, không thể khôi phục
    }

    public enum InvitationStatus
    {
        Pending = 0,    // Chưa chấp nhận
        Accepted = 1,   // Người dùng /Admin chấp nhận tham gia hệ thống
        Rejected = 2,   // Người dùng từ chối tham gia hệ thống
        UserRequest = 3, // Người dùng yêu cầu tham gia hệ thống. Admin sẽ chuyển về Accepted, hoặc AdminRejected
        AdminRejected = 4,
        Disabled = 9    // Ngưng hoạt động, không thể  re-invite user này vào hệ thống
    }
}
