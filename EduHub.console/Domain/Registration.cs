namespace EduHub.Console.Domain;

public class Registration
{
    public Guid Id { get; private set; }
    public Guid MemberId { get; private set; }
    public Guid EventId { get; private set; }
    public DateTime RegisteredAt { get; private set; }
    public string Status { get; private set; }

    private Registration(Guid id, Guid memberId,
        Guid eventId, DateTime registeredAt, string status)
    {
        Id = id;
        MemberId = memberId;
        EventId = eventId;
        RegisteredAt = registeredAt;
        Status = status;
    }

    public static Registration Create(Member member, Event ev)
    {
        if (member == null)
            throw new ArgumentNullException(nameof(member));

        if (ev == null)
            throw new ArgumentNullException(nameof(ev));

        if (!member.IsActive())
            throw new InvalidOperationException(
                "Thành viên không hoạt động.");

        if (ev.Date <= DateTime.Now)
            throw new InvalidOperationException(
                "Sự kiện đã diễn ra hoặc đã bắt đầu.");

        return new Registration(
            Guid.NewGuid(),
            member.Id,
            ev.Id,
            DateTime.Now,
            "Pending");
    }

    public void Confirm()
    {
        if (Status != "Pending")
            throw new InvalidOperationException(
                "Chỉ đăng ký đang chờ mới được xác nhận.");

        Status = "Confirmed";
    }

    public void Cancel()
    {
        if (Status == "Cancelled")
            throw new InvalidOperationException(
                "Đăng ký đã bị hủy.");

        Status = "Cancelled";
    }
}