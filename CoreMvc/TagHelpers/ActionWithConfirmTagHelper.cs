using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Py.Core;
using Py.CoreMvc;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Py.CoreMvc.TagHelpers
{
    [HtmlTargetElement(tag: "ActionWithConfirm", TagStructure = TagStructure.WithoutEndTag, Attributes = "controller-type, method-name")]
    public class ActionWithConfirmTagHelper : TagHelper
    {
        public Type ControllerType { get; set; }
        public string MethodName { get; set; }
        public string Message { get; set; }
        public string ItemName { get; set; }
        public string RouteParameter { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            var confirmationMessage = Message ?? "Are you sure you want to do this";
            if (ItemName != null && ItemName != string.Empty)
                confirmationMessage += $" {ItemName}?";
            else
                confirmationMessage += "?";

            var areaPrefix = "/" + Area.Of(ControllerType);

            var controllerShortName = Short.NameOf(ControllerType);
            var requestPath = $"{areaPrefix}/{controllerShortName}/{MethodName}/{RouteParameter}";
            var randomSuffix = new Random().Next(100);

            var content = $@"<button id='ActionWithConfirm{randomSuffix}' probe='Delete'>Delete</button>
                            <script>
                             var deleteButton = document.getElementById('ActionWithConfirm{randomSuffix}');
                             deleteButton.onclick = function() {{
                              var confirmed = confirm('{confirmationMessage}');
                              if (confirmed) {{
                               var url = window.location.origin + '{requestPath}';
                               window.location.href = url;
                              }}
                             }};
                            </script>";
            output.Content.SetHtmlContent(content);
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
