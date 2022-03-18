using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFTest2
{
    class Program
    {
        private static readonly AppDbContext s_context = new();

        static void Main()
        {
            Console.WriteLine("Hello World from EFTest!");
            var apple = new Brand { Name = "Apple" };
            var seedPhone = new Phone { Brand = apple, Type = "IPhone XX" };

            //Console.WriteLine(apple);
            //TestPhone(seedPhone);
            //Console.WriteLine(apple);
            //var myPhone = s_context.Find<Phone>(12L);
            //ShowPhone("GOTTEN", myPhone);
            //options 1: Brand = null, BrandId = 0 
            //var nnPhone = new Phone { Brand = null, BrandId = 0, Type = "Apple1" };
            //TestPhone(nnPhone); // WILL THROW ERROR
            //options 2: Brand = null, BrandId = 1 
            /*var niPhone = new Phone { Brand = null, BrandId = 7, Type = "Apple2" };
            TestPhone(niPhone);
            var reinierPhone = new Phone { Brand = apple, BrandId = 7, Type = "RApple" };
            var reinierBrand = s_context.Set<Brand>().Single(x => x.Name == reinierPhone.Brand.Name);
            Console.WriteLine(s_context.Entry(reinierBrand).State);
            reinierPhone.Brand = reinierBrand;
            TestPhone(reinierPhone);
            //options 3: Brand = apple, BrandId = 0 
            //var inPhone = new Phone { Brand = apple, BrandId = 0, Type = "Apple3" };
            //TestPhone(inPhone);
            //options 4: Brand = apple, BrandId = 2 
            //var iiPhone = new Phone { Brand = apple, BrandId = 2, Type = "Apple4" };
            //TestPhone(iiPhone);

            /*
             * PRE:   Apple2 0
                POST:   Apple2 5
PRE: Apple 3 Apple3 0
POST: Apple 3 Apple3 6
PRE: Apple 3 Apple4 0
POST: Apple 3 Apple4 7 */
        }

        static void TestPhone(Phone phone)
        {
            ShowPhone("PRE", phone);
            s_context.Phones.Add(phone);
            ShowPhone("MID", phone);
            s_context.SaveChanges();
            ShowPhone("POST", phone);
        }

        private static void ShowPhone(string prefix, Phone phone)
        {
            Console.Write(prefix + ": ");
            var phoneState = s_context.Entry(phone).State;
            Console.WriteLine($"PHONE (State={phoneState}): Id={phone.PhoneId}, Type={phone.Type}, BrandId={phone.BrandId}");
            ShowBrand(phone.Brand);
        }

        private static void ShowBrand(Brand brand)
        {
            if (brand == null)
            {
                Console.WriteLine("BRAND UNDEFINED");
            }
            else
            {
                var brandState = s_context.Entry(brand).State;
                Console.WriteLine($"BRAND (State={brandState}: Id={brand.BrandId}, Name={brand.Name}");
            }
        }
    }
}
