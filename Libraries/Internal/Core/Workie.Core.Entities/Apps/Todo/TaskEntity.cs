namespace Workie.Core.Entities.Apps.Todo
{
    public class TaskEntity
    {
        /// <summary>
        /// Gets or sets the _id.
        /// </summary>
        public string _id { get; set; }

        /// <summary>
        /// Gets or sets the _teamId.
        /// </summary>
        public string _teamId { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the SubTask.
        /// </summary>
        public SubtaskEntity SubTask { get; set; }

    }
}
