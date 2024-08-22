namespace XuongMayBE.Models.RequestModels
{
    public sealed record UserRequestModel
    {
        public string ?Email { get; set; }
        public string ?Password { get; set; }
    }
}
