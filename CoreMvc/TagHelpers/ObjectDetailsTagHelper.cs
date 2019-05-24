using Microsoft.AspNetCore.Razor.TagHelpers;
using PyaFramework.Core;
using System.Text;
using System.Threading.Tasks;

namespace PyaFramework.TagHelpers
{
    [HtmlTargetElement(tag: "ObjectDetails", Attributes = "Object")]
    public class ObjectDetailsTagHelper : TagHelper
    {
        public object Object { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            var existingContent = await output.GetChildContentAsync();

            var builder = new StringBuilder();

            builder.Append("<table style='width: 100%'>");
            builder.Append("<tbody>");
            foreach (var propertyInfo in Object.GetType().GetPublicInstancePropertyInfos())
            {
                builder.Append($"<tr data-elem=\"{propertyInfo.Name}\">");
                builder.Append($"<td style='width: 30%; border: 2px solid cornflowerblue'>{propertyInfo.Name}</td>");
                builder.Append($"<td style='width: 70%; border: 2px solid deepskyblue' data-elem=\"Value\">{propertyInfo.GetValue(Object)}</td>");
                builder.Append("</tr>");
            }
            builder.Append("</tbody>");
            builder.Append("</table>");

            output.Content.AppendHtml(existingContent);
            output.Content.AppendHtml(builder.ToString());
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
