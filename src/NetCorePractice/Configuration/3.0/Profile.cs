namespace NetCorePractice.Configuration._3._0
{
    public class Profile
    {
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }

    public class ContactInfo
    {
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}