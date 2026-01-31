Nguyễn Hữu Đức 2221050211
    Tìm hiểu về cấu trúc thư mục của dự án .Net MVC
 1.Cấu trúc thư mục dự án Cấu trúc cơ bản của một dự án .NET MVC bao gồm: Controllers/: Chứa các lớp C# xử lý yêu cầu từ người dùng, tương tác với Model và chọn View để hiển thị. Models/: Chứa các lớp định nghĩa dữ liệu và logic nghiệp vụ của ứng dụng. Views/: Chứa các tệp giao diện (.cshtml). Đây là nơi hiển thị dữ liệu cho người dùng. wwwroot/: Thư mục chứa các tài nguyên tĩnh như CSS, JavaScript, hình ảnh và thư viện phía client (Bootstrap, jQuery). Program.cs**: Điểm khởi đầu của ứng dụng, nơi cấu hình các dịch vụ (Services) và các đường ống xử lý yêu cầu (Middleware/Pipeline). appsettings.json**: Tệp cấu hình ứng dụng (như chuỗi kết nối cơ sở dữ liệu, các biến môi trường).

2.Định tuyến (Routing) trong .Net MVC Routing là cơ chế ánh ánh các URL từ trình duyệt đến các hành động (Actions) tương ứng trong Controller. Định tuyến mặc định (Conventional Routing): Được cấu hình trong Program.cs. * Cấu trúc mặc định: {controller=Home}/{action=Index}/{id?}. * Ví dụ: URL /Product/Details/5 sẽ gọi đến ProductController, phương thức Details với tham số id = 5. Định tuyến thuộc tính (Attribute Routing): Sử dụng các thuộc tính như [Route("ten-duong-dan")] ngay trên đầu Controller hoặc Action để tùy chỉnh URL linh hoạt hơn.

3.Controller và View Controller**: Là lớp kế thừa từ Microsoft.AspNetCore.Mvc.Controller. Mỗi phương thức public trong Controller được gọi là một Action, thường trả về một IActionResult (phổ biến nhất là View()). View**: Sử dụng cú pháp Razor (kết hợp HTML và C#). View thường nằm trong thư mục Views/[TênController]/[TênAction].cshtml. Truyền dữ liệu**: Controller có thể truyền dữ liệu sang View thông qua ViewBag, ViewData, TempData hoặc sử dụng Strongly Typed Model.

    Tìm hiểu về nhập xuất dữ liệu TRONG PROJECT CONSOLE
Xuất dữ liệu ra màn hình (output) 
- Console.Write("2221050211, Nguyễn Hữu Đức") → không xuống dòng
- Console.WriteLine("2221050211, Nguyễn Hữu Đức") → có xuống dòng
Nhập dữ liệu từ bàn phím (input)
-   Console.Write("Nhập tên của bạn: ");
    string ten = Console.ReadLine();
    Console.WriteLine("Chào bạn, " + ten);
Nhập số và chuyển kiểu dữ liệu 
-   Console.Write("Nhập mã sinh viên: ");
    int tuoi = int.Parse(Console.ReadLine());
Đọc 1 ký tự từ bàn phím 
- int kytu = Console.Read();
- Giá trị trả về là mã ASCII/Unicode của ký tự nhập vào.
- Kiểu dữ liệu trả về là int.
ví dụ :
Console.Write("Nhập một ký tự: ");
int ch = Console.Read();
Console.WriteLine("Mã ký tự là: " + ch);
Console.WriteLine("Ký tự là: " + (char)ch);
