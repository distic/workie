using System.Collections.Generic;

namespace Workie.Core.Entities.SubTask
{
    public class SubtaskEntity
    {
        public string _id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List <string> Owner_userIdsList { get; set; }
    }
}