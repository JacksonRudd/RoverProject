namespace Controller
{
    public class UserResponse<T>
    {
        public T Data;
        public bool Success;
        public string Message;

        public UserResponse(T data, bool success, string message)
        {
            this.Data = data;
            this.Success = success;
            this.Message = message;
        }
    }
}