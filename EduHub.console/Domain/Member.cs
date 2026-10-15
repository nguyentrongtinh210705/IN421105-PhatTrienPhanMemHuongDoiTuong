namespace EduHub.Console.Domain;

public class Member
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string StudentCode { get; private set; }
    public DateTime JoinedAt { get; private set; }
    public string Status { get; private set; }

    private Member(
        Guid id,
        string name,
        string email,
        string studentCode,
        DateTime joinedAt,
        string status)
    {
        Id = id;
        Name = name;
        Email = email;
        StudentCode = studentCode;
        JoinedAt = joinedAt;
        Status = status;
    }

    public static Member Create(
        string name,
        string email,
        string studentCode)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên không được để trống.");

        if (string.IsNullOrWhiteSpace(email) ||
            !email.Contains('@'))
            throw new ArgumentException("Email không hợp lệ.");

        if (string.IsNullOrWhiteSpace(studentCode))
            throw new ArgumentException("Mã sinh viên không được để trống.");

        return new Member(
            Guid.NewGuid(),
            name.Trim(),
            email.Trim(),
            studentCode.Trim(),
            DateTime.Now,
            "Active");
    }

    public bool IsActive()
    {
        return Status == "Active";
    }

    public void Deactivate()
    {
        Status = "Inactive";
    }
}