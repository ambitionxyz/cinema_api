- đầu tiên vào appsetting.json tìm đến phần ConnectionStrings MyDB: thay User ID=SA;Password=123123 cho giống vói sql sever của mình
- tiếp theo thì xóa folder Migrations đi để nó tạo lại dữ liệu trong sql
- vào program.cs dòng 99 // PrepDb.PrepPopulation(app); bỏ dấu "//" đi.
- dotnet ef migrations add init : tạo db
- dotnet ef detabase update init : push db lên sql(push xong comment cái dòng 99 lại hoặc nhác quá thì vứt vậy cũng éo sao, nên comment)
- dotnet build
- dotnet run sẽ thấy cái host ở dưới terminal để ý cái host ấy
- rồi vào web http://localhost:{cổng host vừa nãy}/swagger/index.html

ở đây còn có phần authentication, muốn bảo mệt api nào thì thêm [Authorize], chỉ cần copy [Authorize] thì sẽ thấy, nó còn phân quyền, như thu hồi revoke quyền sử dụng thì phải thêm [Authorize("Admin")], có thêm tính năng nhập 5 lần ko đúng pass thì phải chờ 5p sau mới được nhập, có thể tắt nó đi bằng cách bỏ dòng này

builder.Services.Configure<IdentityOptions>(options =>
{
options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(0.15); // Sai pas thì chờ 5p
options.Lockout.MaxFailedAccessAttempts = 5; // số lần thử đăng nhập tối đa
options.Lockout.AllowedForNewUsers = true;
}); nó ở file programs
