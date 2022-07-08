namespace HotDeskSystemApi.Business.ViewModels
{
    public class AdminModel
    {
        public int AdminId { get; set; }
        public string AdminLogin { get; set; } = string.Empty;
        public string AdminPassword { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
