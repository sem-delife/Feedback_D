namespace Feedback_Application.Areas.Identity.Pages.Account.Manage.Models
{
    public class AdminDataTableViewModel
    {
        public string Title { get; set; }
        public List<object> Items { get; set; }
        public string NameField { get; set; }
        public string IdField { get; set; }
    }
}
