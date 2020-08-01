namespace Todo.Application.Services.Models
{
    public interface ITaskResourceParameters
    {
        string TitlePhrase { get; set; }
        string DescriptionPhrase { get; set; }
        string CompletionCondition { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}