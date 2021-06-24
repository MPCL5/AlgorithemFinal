namespace AlgorithemFinal.Models.Requests
{
    public class EditUserRequest
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Password { get; set; }

        public string Code { get; set; }
    }
}