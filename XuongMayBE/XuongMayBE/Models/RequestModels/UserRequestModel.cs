﻿namespace XuongMayBE.Models.RequestModels
{
    public sealed record UserRequestModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
