using System;

namespace MyTobaccoShop.Logic
{
    /// <summary>
    /// Get Admin User Class.
    /// </summary>
    public class GetAdminUser
    {
        /// <summary>
        /// Gets or sets user Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets User Type.
        /// </summary>
        public string User_type { get; set; }

        // override object.Equals

        /// <summary>
        /// Equals Method.
        /// </summary>
        /// <param name="obj">object.</param>
        /// <returns>equals True or False.</returns>
        public override bool Equals(object obj)
        {
            if (obj is GetAdminUser)
            {
                GetAdminUser other = obj as GetAdminUser;
                return this.Name == other.Name && this.User_type == other.User_type;
            }

            return false;
        }

    }
}
