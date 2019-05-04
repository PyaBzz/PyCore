using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PyaFramework.Core;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PyaFramework.TagHelpers
{
    [HtmlTargetElement(tag: "ButtonWithConfirmation", TagStructure = TagStructure.WithoutEndTag)]
    public class ButtonWithConfirmationTagHelper : TagHelper
    {
        public Type ControllerType { get; set; }
        public string MethodName { get; set; }
        public Type ItemType { get; set; }
        public string RouteParameter { get; set; }
        public string Message { get; set; }
        //Task: Minimise and simplify the parameters of this tag
        //Task: Use this tag everywhere a button needs confirmation
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            var confirmationMessage = Message ?? "Are you sure you want to delete this";
            var itemTypeName = ItemType?.Name ?? "item";

            var controllerAreaAttribute = ControllerType.GetCustomAttribute(typeof(AreaAttribute));
            var areaPrefix = string.Empty;
            if (controllerAreaAttribute != null)
                areaPrefix += "/" + typeof(AreaAttribute).GetProperty("RouteValue").GetValue(controllerAreaAttribute);

            var controllerShortName = ControllerType.Name.TrimEnd("Controller");
            var requestPath = $"{areaPrefix}/{controllerShortName}/{MethodName}/{RouteParameter}";

            //Task: Use StringBuilder or make this a single interpolated literal string
            var content =
                            "<button id='delete'>Delete</button>" +

                            "<script>" +
                             "var deleteButton = document.getElementById('delete');" +
                             "deleteButton.onclick = function() {" +
                              $"var confirmed = confirm('{confirmationMessage} {itemTypeName}?');" +
                              "if (confirmed) {" +
                               $"var url = window.location.origin + '{requestPath}';" +
                               "window.location.href = url;" +
                              "}" +
                             "};" +
                            "</script>";
            output.Content.SetHtmlContent(content);
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
