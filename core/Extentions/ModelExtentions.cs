using OnlineShop.Core.Services.Contracts;
using System.Text.RegularExpressions;

namespace OnlineShop.Core.Extentions
{
    public static class ModelExtentions
    {
        public static string GetInformation(this IProductModel product)
        {
            string info = product.Name.Replace(" ", "-") + GetBrand(product.BrandName);
            info = Regex.Replace(info,@"[^a-zA-z0-9\-]",string.Empty);
            return info;
        }

        private static string GetBrand(string brandName)
        {


            brandName = brandName.Replace(" ","-");

            return brandName;
        }
    }
}
