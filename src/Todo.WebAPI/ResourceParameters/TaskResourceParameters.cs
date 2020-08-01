using Todo.Application.Services.Models;

namespace Todo.WebAPI.ResourceParameters
{
    public class TaskResourceParameters : ITaskResourceParameters
    {
        /// <summary>
        /// What phrase should title contain?
        /// </summary>
        public string TitlePhrase { get; set; }
        /// <summary>
        /// What phrase should description contain?
        /// </summary>
        public string DescriptionPhrase { get; set; }
        /// <summary>
        /// Should tasks be only completed or only uncompleted? Values: "completed"/"uncompleted".
        /// </summary>
        public string CompletionCondition { get; set; }
        /// <summary>
        /// Page number (default: 1)
        /// </summary>
        public int PageNumber { get; set; } = 1;
        /// <summary>
        /// Tasks on page (default: 5)
        /// </summary>
        public int PageSize { get; set; } = 5;
    }
}