using Microsoft.AspNetCore.Razor.TagHelpers;
using PyaFramework.Core;
using System.Linq;
using System.Threading.Tasks;

namespace PyaFramework.TagHelpers
{
    [HtmlTargetElement(tag: "ModelDetails")]
    public class ModelDetailsTagHelper : TagHelper
    {
        public Thing TagModel { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            var existingContent = await output.GetChildContentAsync();
            //Task: Use StringBuilder or make this a single interpolated literal string
            var content = $"<table style='width: 100%'>" +
                            "<tbody>" +
                             TagModel.GetType().GetPublicInstancePropertyInfos().Select(pi =>
                              $"<tr>" +
                               $"<td style='width: 30%; border: 2px solid cornflowerblue'>{pi.Name}</td>" +
                               $"<td style='width: 70%; border: 2px solid deepskyblue'>{pi.GetValue(TagModel)}</td>" +
                              $"</tr>").ToString("") +
                            "</tbody>" +
                            "</table>";

            output.Content.AppendHtml(existingContent);
            output.Content.AppendHtml(content);
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
