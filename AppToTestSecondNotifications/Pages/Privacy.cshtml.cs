using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppToTestSecondNotifications.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //secondNotificationsLine start
            //Examples of all notifications
            new SecondNotification().SetNotification("This are all bootstrap alerts. This is Danger", SecondNotification.NotificationEnum.danger.ToString());
            new SecondNotification().SetNotification("Success Saved", SecondNotification.NotificationEnum.success.ToString());
            new SecondNotification().SetNotification("Dark alert", SecondNotification.NotificationEnum.dark.ToString());
            new SecondNotification().SetNotification("Also secondary", SecondNotification.NotificationEnum.secondary.ToString());
            new SecondNotification().SetNotification("Warning", SecondNotification.NotificationEnum.warning.ToString());
            new SecondNotification().SetNotification("Show info", SecondNotification.NotificationEnum.info.ToString());
            new SecondNotification().SetNotification("Make it primary", SecondNotification.NotificationEnum.primary.ToString());
            new SecondNotification().SetNotification("Keep it light", SecondNotification.NotificationEnum.light.ToString());
            //secondNotificationsLine end
        }
        public IActionResult OnGetToHome()
        {
            //Examples of a notification
            new SecondNotification().SetNotification("You entered Home again. If you pres the home button, the message will disappear", "Danger"); //secondNotificationsLine
            return RedirectToPage("Index");
        }
    }
}
