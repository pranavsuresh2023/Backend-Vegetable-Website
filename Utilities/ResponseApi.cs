namespace AssignmentProject.Utilities
{
    public class ResponseApi<T>
    {
        public T? Value { get; set; }
        public bool Status { get; set; }
        public string Msg { get; set; }
    }
}
