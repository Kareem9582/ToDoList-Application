namespace ToDoList.Api.Middleware
{
    public class ProblemDetail
    {
        public string Message { get; set; }

        public   string ExceptionType { get; set; }

        public int Status { get; set; }

        public string TraceId { get; set; }
    }
}
