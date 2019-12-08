using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTobaccoShop.Logic.Products_Logic
{
    /// <summary>
    /// AVG Price Class.
    /// </summary>
    public class GetAveragePrice
    {
        /// <summary>
        /// Gets or sets Category Name .
        /// </summary>
        public int CategorytID { get; set; }

        /// <summary>
        /// Gets or sets Avg Price  .
        /// </summary>
        public decimal AvgPrice { get; set; }

        /// <summary>
        /// To Sting() Method.
        /// </summary>
        /// <returns>string format.</returns>
        public override string ToString()
        {
            return $"Category ID : {this.CategorytID}\nAvg Price {this.AvgPrice}";
        }

        /// <summary>
        /// Equals Method.
        /// </summary>
        /// <param name="obj">object.</param>
        /// <returns>equals True or False.</returns>
        public override bool Equals(object obj)
        {
            if (obj is GetAveragePrice)
            {
                GetAveragePrice other = obj as GetAveragePrice;
                return this.CategorytID == other.CategorytID && this.AvgPrice == other.AvgPrice;
            }

            return false;
        }
    }
}
