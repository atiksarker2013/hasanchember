using System;

namespace cornia.core.DTO
{
    [Serializable]
    public class UserProfileSessionDTO
    {
        public int UserId { get; set; }

        public string EMail { get; set; }

        public string Note { get; set; }

        public string Token { get; set; }

        public Guid BarrierToken { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public bool isLocked { get; set; }

    }
}
