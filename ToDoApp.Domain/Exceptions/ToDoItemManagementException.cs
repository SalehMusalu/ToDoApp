namespace ToDoApp.Domain.Exceptions
{
    public abstract class PersonManagementException : Exception
    {
        protected PersonManagementException(string message) : base(message)
        {

        }
    }
}
