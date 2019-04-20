using System.Collections.Generic;

namespace Workie.Core.Entities.Group
{
    public class RoleEntity
    {
        /// <summary>
        /// Gets or sets the _id.
        /// </summary>
        public string _id { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public List<string> PermissionIdsList { get; set; }
    }
}
