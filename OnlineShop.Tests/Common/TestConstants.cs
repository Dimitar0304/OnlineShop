using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Tests.Common
{
    public static class TestConstants
    {
        public static class AccessoryConstants
        {
            public const string Name = "AccessoryTestName";
            public const string Type = "AccessoryTestType";
            public const decimal Price = 10.00m;
            public const int BrandId = 1;
            public const string ImageUrl = "https://i.pinimg.com/564x/80/99/0a/80990a58b79edaf9ae83578d19a39a38.jpg";
            public const bool IsActive = true;
            public const int Quantity = 10;
        }
        public static class GarmentConstants
        {
            public const string Name = "GarmentTestName";
            public const int TypeId = 2;
            public const int BrandId = 1;
            public const decimal Price = 49.99m;
            public const string Color = "Black";
            public const bool IsActive = true;
            public const string ImageUrl = "https://i.pinimg.com/564x/80/99/0a/80990a58b79edaf9ae83578d19a39a";
        }
        public static class ShoeConstants
        {
            public const string Name = "ShoeTestName";
            public const int TypeId = 2;
            
            public const int BrandId = 1;
            public const decimal Price = 49.99m;
            public const string Color = "Black";
            public const bool IsActive = true;
            public const string ImageUrl = "https://i.pinimg.com/564x/80/99/0a/80990a58b79edaf9ae83578d19a39a";
        }
    }
}
