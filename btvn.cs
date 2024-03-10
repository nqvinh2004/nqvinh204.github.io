using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    internal class Program
    {
        class Vehical
        {
            public String vehicalType { get; set; }
            public String vehicalName { get; set; }
            public int year { get; set; }
            public String company { get; set; }
            public float price { get; set; }
            public void input()
            {
                Console.WriteLine("Nhập loại xe ");
                vehicalType = Console.ReadLine();
                Console.WriteLine("Nhập tên xe ");
                vehicalName = Console.ReadLine();
                Console.WriteLine("Nhập năm sản xuất");
                year = int.Parse(Console.ReadLine());
                Console.WriteLine("Nhập công ty ");
                company = Console.ReadLine();
                Console.WriteLine("Nhập giá ");
                price = float.Parse(Console.ReadLine());
            }
            public void output()
            {
                Console.WriteLine("Type: " + vehicalType);
                Console.WriteLine("Name: " + vehicalName);
                Console.WriteLine("Year: " + year);
                Console.WriteLine("Company: " + company);
                Console.WriteLine("Price: " + price);
            }
        }
        class car : Vehical
        {
            private int numberOfSeats;
            public new void input()
            {
                base.input();
                Console.WriteLine("Nhập số chỗ ngồi ");
                numberOfSeats = int.Parse(Console.ReadLine());
            }
            public new void output()
            {
                base.output();
                Console.WriteLine("number of seats: " + numberOfSeats);
            }
        }
        class truck : Vehical
        {
            public String CompanyOwner { get; set; }
            public new void input()
            {
                base.input();
                Console.WriteLine("Nhập tên công ty chủ quản");
                CompanyOwner = Console.ReadLine();
            }
            public new void output()
            {
                base.output();
                Console.WriteLine("Company Owner: " + CompanyOwner);
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<car> cars = new List<car>();
            List<truck> trucks = new List<truck>();

            Console.WriteLine("Nhập số lượng Car muốn thêm");
            int quantity = int.Parse(Console.ReadLine());
            for (int i = 0; i < quantity; i++)
            {
                car newcar = new car();
                newcar.input();
                cars.Add(newcar);
            }
            Console.WriteLine("Nhập số lượng truck muốn thêm");
            int quantity2 = int.Parse(Console.ReadLine());
            for (int i = 0; i < quantity2; i++)
            {
                truck newtruck = new truck();
                newtruck.input();
                trucks.Add(newtruck);
            }

            Console.WriteLine("Danh sách các Car có giá từ 100000 đến 250000 và năm sản xuất > 1990 là:");
            var carItems = cars.Where(car => car.price >= 100000 && car.price <= 250000);
            foreach (var carItem in carItems)
            {
                carItem.output();
            }

            Console.WriteLine("\nDanh sách các Car có năm sản xuất lớn hơn 1990 là:");
            var CarYear = cars.Where(car => car.year > 1990);
            foreach (var carItem in CarYear)
            {
                Console.WriteLine("Year: " + carItem.year);
            }

            var Group = cars.GroupBy(car => car.vehicalName)
                            .Select(group => new
                            {
                                Name = group.Key,
                                TotalPrice = group.Sum(car => car.price)
                            });
            Console.WriteLine("\nTổng giá trị các xe theo nhóm hãng sản xuất:");
            foreach (var item in Group)
            {
                Console.WriteLine($"Name: {item.Name}, Total Price: {item.TotalPrice}");
            }

            // Sắp xếp các xe tải theo năm sản xuất từ cao đến thấp
            var orderedTrucks = trucks.OrderByDescending(truck => truck.year);
            Console.WriteLine("\nDanh sách Truck theo thứ tự năm sản xuất từ cao đến thấp:");
            foreach (var truck in orderedTrucks)
            {
                truck.output();
            }

            Console.WriteLine("\nTên cty chủ quản của Truck:");
            foreach (var truck in trucks)
            {
                Console.WriteLine($"Manufacturer: {truck.company}, Company Owner: {truck.CompanyOwner}");
            }
            Console.ReadLine();
        }
    }
}
