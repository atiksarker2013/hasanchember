namespace cornia.core.DTO
{
    public class LogInModel
    {
        //[Required]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        public string PIN { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassrord { get; set; }

        public string OldPIN { get; set; }
        public string NewPIN { get; set; }
        public string ConfirmPIN { get; set; }

        //[HiddenInput]
        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }

        public string ForgetPasswordEmail { get; set; }
    }
}
