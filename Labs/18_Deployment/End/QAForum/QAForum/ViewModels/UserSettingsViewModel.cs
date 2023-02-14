using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace QAForum.ViewModels
{
    public class UserSettingsViewModel
    {
        [Display(Name = "Dark Mode")]
        public bool DarkMode { get; set; }
    }

}
