using System.Collections.Generic;
using Workie.Core.Entities.Apps.Todo;

namespace Workie.Web.Admin.Areas.Apps.Models.Todo.QuickbarControls
{
    public class QuickbarControlsTodoViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public List<SubtaskEntity> SubtaskList { get; set; }
    }
}
