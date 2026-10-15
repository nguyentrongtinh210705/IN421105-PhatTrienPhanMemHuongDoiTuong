namespace EduHub.Console.Domain;

public class Club
{
    private readonly List<Member> _members = new();

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public IReadOnlyList<Member> Members => _members.AsReadOnly();

    private Club(Guid id, string name, string description,
        DateTime createdAt)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
    }

    public static Club Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên câu lạc bộ không được để trống.");

        return new Club(
            Guid.NewGuid(),
            name.Trim(),
            description?.Trim() ?? string.Empty,
            DateTime.Now);
    }

    public void AddMember(Member member)
    {
        if (member == null)
            throw new ArgumentNullException(nameof(member));

        if (!member.IsActive())
            throw new InvalidOperationException(
                "Thành viên không hoạt động.");

        if (_members.Any(m => m.Id == member.Id))
            throw new InvalidOperationException(
                "Thành viên đã có trong câu lạc bộ.");

        _members.Add(member);
    }

    public int MemberCount()
    {
        return _members.Count;
    }
}