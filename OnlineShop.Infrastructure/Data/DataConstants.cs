namespace OnlineShop.Infrastructure
{
    public static class DataConstants
    {
        public static class Size
        {

            public const int MinLenght = 1;
            public const int MaxLenght = 5;
        }
        public static class Garment
        {
            public const int MinModelLenght = 2;
            public const int MaxModelLenght = 40;
            public const int MinColorLenght = 2;
            public const int MaxColorLenght = 15;
        }
        public static class Shoe
        {
            public const int MinModelLenght = 2;
            public const int MaxModelLenght = 40;
            public const int MinColorLenght = 2;
            public const int MaxColorLenght = 15;
        }
        public static class Accessory
        {
            public const int MinNameLenght = 2;
            public const int MaxNameLenght = 35;
            public const int MinTypeLenght = 2;
            public const int MaxTypeLenght = 40;
        }
        public static class Brand
        {
            public const int MinNameLenght = 1;
            public const int MaxNameLenght = 50;
        }
        public static class ShoeType
        {
            public const int MinNameLenght = 1;
            public const int MaxNameLenght = 50;
        }
        public static class GarmentType
        {
            public const int MinNameLenght = 1;
            public const int MaxNameLenght = 15;
        }
        public static class Order
        {
            public const int MinPhoneNumberLenght = 10;
            public const int MaxPhoneNumberLenght = 13;

            public const int MinAddressLenght = 10;
            public const int MaxAddressLenght = 20;
        }
    }
}
