namespace Model
{
    public class Response
    {
        public bool? IsSuccessful { get; set; }
        public String? Message { get; set; }
        public dynamic? Data { get; set; }
    }
}