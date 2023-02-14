using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using QAForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QAForum.TagHelpers
{
    public enum DisplayOptions
    {
        EmailOnly,
        NameOnly,
        Both
    }


    [HtmlTargetElement("company-details", Attributes = "display-options")]
    public class CompanyDetailsTagHelper : TagHelper
    {

        public DisplayOptions DisplayOptions { get; set; }

        private readonly CompanyDetails companyDetails;

        public CompanyDetailsTagHelper(CompanyDetails companyDetails)
        {
            this.companyDetails = companyDetails;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string content = "";
            switch (DisplayOptions)
            {
                case (DisplayOptions.EmailOnly):
                    content = companyDetails.Email;
                    break;
                case (DisplayOptions.NameOnly):
                    content = companyDetails.CompanyName;
                    break;
                case (DisplayOptions.Both):
                    content = $"{companyDetails.CompanyName} [{companyDetails.Email}]";
                    break;
            }

            output.TagName = "a";
            output.Content.SetContent(content);
            output.Attributes.Add("href", "mailto:" + companyDetails.Email);
        }
    }
}
