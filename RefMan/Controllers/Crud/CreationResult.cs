namespace RefMan.Controllers.Crud
{
    public class CreationResult<T>
    {
        public CreationResult(string url, T value)
        {
            Url = url;
            Value = value;
        }

        public string Url { get; }

        public T Value { get; }
    }
}