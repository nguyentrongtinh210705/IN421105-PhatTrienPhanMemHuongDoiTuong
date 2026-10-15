namespace EduHub.Console.Domain;

public class CheckIn
{
    public Guid Id { get; private set; }
    public Guid RegistrationId { get; private set; }
    public DateTime CheckedInAt { get; private set; }
    public string Method { get; private set; }

    private CheckIn(Guid id, Guid registrationId,
        DateTime checkedInAt, string method)
    {
        Id = id;
        RegistrationId = registrationId;
        CheckedInAt = checkedInAt;
        Method = method;
    }

    public static CheckIn Create(
        Registration registration, string method)
    {
        if (registration == null)
            throw new ArgumentNullException(nameof(registration));

        if (registration.Status != "Confirmed")
            throw new InvalidOperationException(
                "Chỉ đăng ký đã xác nhận mới được điểm danh.");

        if (string.IsNullOrWhiteSpace(method))
            throw new ArgumentException(
                "Phương thức điểm danh không được để trống.");

        return new CheckIn(
            Guid.NewGuid(),
            registration.Id,
            DateTime.Now,
            method.Trim());
    }

    public string Summary()
    {
        return $"Mã điểm danh: {Id} | " +
               $"Mã đăng ký: {RegistrationId} | " +
               $"Thời gian: {CheckedInAt:dd/MM/yyyy HH:mm} | " +
               $"Phương thức: {Method}";
    }
}