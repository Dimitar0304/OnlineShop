using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.Type
{
    /// <summary>
    /// Type view model to display all types
    /// </summary>
    public class TypeAllViewModel
    {
        /// <summary>
        /// type all view model identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// type name
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
