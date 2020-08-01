namespace Todo.Domain
{
    public static class Constants
    {
        public const int TaskInput_Title_MinLength = 1;
        public const int TaskInput_Title_MaxLength = 50;
        public const int TaskInput_Description_MaxLength = 100;

        public const int TaskParameters_TitlePhrase_MinLength = 1;
        public const int TaskParameters_TitlePhrase_MaxLength = 25;
        public const int TaskParameters_DescriptionPhrase_MinLength = 1;
        public const int TaskParameters_DescriptionPhrase_MaxLength = 25;

        public const int PageNumber_Default = 1;
        public const int PageSize_Default = 5;
        public const int PageSize_Max = 20;

        public const string CompletionCondition_Completed = "completed";
        public const string CompletionCondition_Uncompleted = "uncompleted";
        public const string CompletionCondition_ErrorTitle = "CompletionCondition";
        public const string CompletionCondition_ErrorMessage = "Incorrent Value.";

        public const string Pagination_Header_Name = "X-Pagination";

        public const string Swagger_Version = "1.0";
        public const string Swagger_Endpoint_Name = "TodoListOpenAPISpecification";
        public const string Swagger_Endpoint = 
            "/swagger/" + Swagger_Endpoint_Name + "/swagger.json";
        public const string Swagger_Title = "ToDo List Api";
        public const string Swagger_Description =
            "Through this API you can create your own TO-DO list and manage it.";
        public const string Swagger_Contact_Name = "Emil Olszewski";
        public const string Swagger_Contact_Email = 
            "emil.olszewski@protonmail.com";
        public const string Swagger_Contact_Website =
            "https://github.com/Emil-Olszewski";

    }
}
