using System;

class Program
{
    static void Main()
    {
        // Nhập tên
        Console.Write("Nhập tên: ");
        string ten = Console.ReadLine();

        // Nhập tuổi
        Console.Write("Nhập tuổi: ");
        int tuoi = int.Parse(Console.ReadLine());
        while (!int.TryParse(Console.ReadLine(), out tuoi))

        // Nhập điểm
        Console.Write("Nhập mã sinh viên: ");
        double msv  = double.Parse(Console.ReadLine());
        while (!double.TryParse(Console.ReadLine(), out msv))

        // Xuất dữ liệu
        Console.WriteLine("\n--- Thông tin đã nhập ---");
        Console.WriteLine("Tên: " + ten);
        Console.WriteLine("Tuổi: " + tuoi);
        Console.WriteLine("Điểm: " + msv);

    }
}