namespace EmployeeManagementUIModels
{
    public class Message<T>
    {
        public string message { get; set; }
        public string result { get; set; }
        public T Data { get; set; }
    }
}