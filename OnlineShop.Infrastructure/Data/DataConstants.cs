namespace OnlineShop.Infrastructure
{
    /// <summary>
    /// Data Constants
    /// </summary>
    public static class DataConstants
    {
        /// <summary>
        /// Size Data Constants
        /// </summary>
        public static class Size
        {

            /// <summary>
            /// Min Lenght
            /// </summary>
            public const int MinLenght = 1;

            /// <summary>
            /// Max Lenght
            /// </summary>
            public const int MaxLenght = 5;
        }

        /// <summary>
        /// Garment Data Constants
        /// </summary>
        public static class Garment
        {
            /// <summary>
            /// Min Model Lenght
            /// </summary>
            public const int MinModelLenght = 2;

            /// <summary>
            /// Max Model Lenght 
            /// </summary>
            public const int MaxModelLenght = 40;

            /// <summary>
            /// Min Color Lenght
            /// </summary>
            public const int MinColorLenght = 2;

            /// <summary>
            /// Max Color Lenght
            /// </summary>
            public const int MaxColorLenght = 15;

           
        }

        /// <summary>
        /// Shoe Data Constants
        /// </summary>
        public static class Shoe
        {
            /// <summary>
            /// Min Model Lenght
            /// </summary>
            public const int MinModelLenght = 2;

            /// <summary>
            /// Max Model Lenght
            /// </summary>
            public const int MaxModelLenght = 40;

            /// <summary>
            /// Min Color Lenght
            /// </summary>
            public const int MinColorLenght = 2;

            /// <summary>
            /// Max Color Lenght
            /// </summary>
            public const int MaxColorLenght = 15;
        }

        /// <summary>
        /// Accessory Data Constants
        /// </summary>
        public static class Accessory
        {
            /// <summary>
            /// Min Name Lenght
            /// </summary>
            public const int MinNameLenght = 2;

            /// <summary>
            /// Max Nam Lenght
            /// </summary>
            public const int MaxNameLenght = 35;

            /// <summary>
            /// Min Type Lenght
            /// </summary>
            public const int MinTypeLenght = 2;

            /// <summary>
            /// Max Type Lenght
            /// </summary>
            public const int MaxTypeLenght = 40;

        }
        
        /// <summary>
        /// Brand Data Constants
        /// </summary>
        public static class Brand
        {
            /// <summary>
            /// Min Name Lenght
            /// </summary>
            public const int MinNameLenght = 1;

            /// <summary>
            /// Max Name Lenght
            /// </summary>
            public const int MaxNameLenght = 50;
        }

        /// <summary>
        /// ShoeType Data Constants
        /// </summary>
        public static class ShoeType
        {
            /// <summary>
            /// Min Name Lenght
            /// </summary>
            public const int MinNameLenght = 1;

            /// <summary>
            /// Max Name Lenght
            /// </summary>
            public const int MaxNameLenght = 50;
        }

        /// <summary>
        /// Garment Type Data Constants
        /// </summary>
        public static class GarmentType
        {
            /// <summary>
            /// Min Name Lenght
            /// </summary>
            public const int MinNameLenght = 1;

            /// <summary>
            /// Max Name Lenght
            /// </summary>
            public const int MaxNameLenght = 15;
        }
        /// <summary>
        /// Order Data Constants
        /// </summary>
        public static class Order
        {
            /// <summary>
            /// Min PhoneNumber Lenght
            /// </summary>
            public const int MinPhoneNumberLenght = 10;

            /// <summary>
            /// Max PhoneNumber Lenght
            /// </summary>
            public const int MaxPhoneNumberLenght = 13;

            /// <summary>
            /// Min AddressLenght
            /// </summary>
            public const int MinAddressLenght = 10;

            /// <summary>
            /// Max AddressLenght
            /// </summary>
            public const int MaxAddressLenght = 20;
        }
        
        /// <summary>
        /// Custom user constants
        /// </summary>
        public static class User
        {
            public const int FirstNameMinLenght = 3;
            public const int FirstNameMaxLenght = 50;

            public const int LastNameMinLenght = 3;
            public const int LastNameMaxLenght = 50;
        }

        public static class AdminConstants
        {
            public const string AdminRoleName = "Admin";
            public const string AreaName = "Admin";


        }
    }
}
