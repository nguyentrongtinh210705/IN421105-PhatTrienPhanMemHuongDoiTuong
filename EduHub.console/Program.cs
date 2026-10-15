using EduHub.Console.Domain;

// 1. Tao Tech Club
Club club = Club.Create(
    "Tech Club",
    "Cau lac bo cong nghe"
);

// 2. Tao 3 thanh vien
Member m1 = Member.Create(
    "Nguyen Van An", "an@example.com", "SV001");

Member m2 = Member.Create(
    "Tran Thi Binh", "binh@example.com", "SV002");

Member m3 = Member.Create(
    "Le Van Cuong", "cuong@example.com", "SV003");

// Them 3 thanh vien vao CLB
club.AddMember(m1);
club.AddMember(m2);
club.AddMember(m3);

// 3. Tao 1 su kien
Event ev = Event.Create(
    club.Id,
    "Workshop Lap trinh C#",
    DateTime.Now.AddDays(7),
    30,
    false
);

// 4. Tao 3 dang ky
// Hai dang ky giu trang thai Pending
Registration r1 = Registration.Create(m1, ev);
Registration r2 = Registration.Create(m2, ev);

// Dang ky thu ba va xac nhan de duoc Check-in
Registration r3 = Registration.Create(m3, ev);
r3.Confirm();

// 5. Check-in cho thanh vien thu ba
CheckIn c1 = CheckIn.Create(r3, "QR Code");

// 6. In bao cao
Console.WriteLine("========== BAO CAO TECH CLUB ==========");
Console.WriteLine($"Ten CLB: {club.Name}");
Console.WriteLine($"Ten su kien: {ev.Title}");
Console.WriteLine($"Ngay to chuc: {ev.Date:dd/MM/yyyy}");
Console.WriteLine($"Suc chua: {ev.Capacity}");
Console.WriteLine($"Tong thanh vien CLB: {club.MemberCount()}");

Console.WriteLine("\n--- DANH SACH DANG KY ---");

Console.WriteLine(
    $"{m1.StudentCode} - {m1.Name} - {r1.Status}");

Console.WriteLine(
    $"{m2.StudentCode} - {m2.Name} - {r2.Status}");

Console.WriteLine(
    $"{m3.StudentCode} - {m3.Name} - {r3.Status}");

Console.WriteLine("\n--- BAO CAO DIEM DANH ---");
Console.WriteLine("Tong so thanh vien: 3");
Console.WriteLine("Dang cho (Pending): 2");
Console.WriteLine("Da xac nhan: 1");
Console.WriteLine("Da Check-in: 1");

Console.WriteLine("\nChi tiet Check-in:");
Console.WriteLine(c1.Summary());

Console.WriteLine("\n======================================");