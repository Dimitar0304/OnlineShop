namespace OnlineShop.Validations
{
    /// <summary>
    /// Error messages 
    /// </summary>
    public static class ErrorMessages
    {
        /// <summary>
        /// Required field error message
        /// </summary>
        public const string RequiredField = "{0} is required";
        /// <summary>
        /// String lenght error message
        /// </summary>
        public const string StringLenghtError = "{0} must be between {2} and {1}";

        /// <summary>
        /// The current user is in that role error message
        /// </summary>
        public const string UserIsInThatRoleError = "The user is in that role";

        /// <summary>
        /// Price range error message
        /// </summary>
        public const string PriceRangeErrorMessage = "Range must be between 0.00 and 5000.00";
    }
}
