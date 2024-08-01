using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace BookingSystem.WEB.Helpers
{
    [HtmlTargetElement("pagination")]
    public class TableFootTagHelper : TagHelper
    {
        [HtmlAttributeName("page")]
        public int Page { get; set; }

        [HtmlAttributeName("total-pages")]
        public int TotalPages { get; set; }

        [HtmlAttributeName("parameters")]
        public object Parameters { get; set; }

        [HtmlAttributeName("controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("action")]
        public string Action { get; set; }

        [HtmlAttributeName("id")]
        public string Id { get; set; }

        [HtmlAttributeName("colspan")]
        public int Colspan { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "tfoot";
            output.TagMode = TagMode.StartTagAndEndTag;
            var content = GetPaginationDOM();
            output.Content.AppendHtml(content);
        }

        public string GetPaginationDOM()
        {
            var paginationBuilder = new StringBuilder();
            paginationBuilder.Append($@"
<tr>
    <td colspan=""{this.Colspan}"">
        <div class=""pagination-container"">
            <div class=""pagination-button"">");

            if (Page > 1)
            {
                paginationBuilder.Append($@"<button class=""button-page"" onclick=""location.href='{GetActionLink(Page - 1)}'"">&lt;</button>");
            }

            if (Page > 3)
            {
                paginationBuilder.Append($@"<button class=""button-page"" onclick=""location.href='{GetActionLink(1)}'"">1</button>");
                if (Page > 4)
                {
                    paginationBuilder.Append("<span>...</span>");
                }
            }

            for (int i = 1; i <= TotalPages; i++)
            {
                if (i >= Page - 2 && i <= Page + 2)
                {
                    paginationBuilder.Append($@"<button class="" button-page {(Page == i ? "on-page" : "")}"" onclick=""location.href='{GetActionLink(i)}'"">{i}</button>");
                }
            }

            if (Page < TotalPages - 3)
            {
                if (Page < TotalPages - 4)
                {
                    paginationBuilder.Append("<span>...</span>");
                }
                paginationBuilder.Append($@"<button class=""button-page"" onclick=""location.href='{GetActionLink(TotalPages)}'"">{TotalPages}</button>");
            }

            if (Page != TotalPages)
            {
                paginationBuilder.Append($@"<button class=""button-page"" onclick=""location.href='{GetActionLink(Page + 1)}'"">&gt;</button>");
            }

            paginationBuilder.Append($@"
                <select class=""""items-per-page"""" onchange=""""location.href='{{GetActionLink(Page)}}&itemsPerPage=' + this.value"""">
                    <option value=""""10"""" "" + (ItemsPerPage == 10 ? ""selected"" : """") + @"">10</option>
                    <option value=""""20"""" "" + (ItemsPerPage == 20 ? ""selected"" : """") + @"">20</option>
                    <option value=""""50"""" "" + (ItemsPerPage == 50 ? ""selected"" : """") + @"">50</option>
                </select>         
            </div>
            <div>Page ""{this.Page}"" of ""{this.TotalPages}""</div>
        </div>
    </td>
</tr>");

            return paginationBuilder.ToString();
        }

        public string GetActionLink(int pageNumber)
        {
            var controllerPath = (this.Controller != null) ? $"/{this.Controller}" : "/";
            var actionPath = (this.Action != null) ? $"/{this.Action}" : "";
            var idPath = (this.Id != null) ? $"/{this.Id}" : "";
            var pagePath = $"?page={pageNumber}";
            var parametersPath = GetParametersPath();
            var actionLink = $"{controllerPath}{actionPath}{idPath}{pagePath}{parametersPath}";
            return actionLink;
        }

        public string GetParametersPath()
        {
            var parametersPath = "";
            if (this.Parameters != null)
            {
                var properties = this.Parameters.GetType().GetProperties();
                var parametersBuilder = new StringBuilder();
                foreach (var property in properties)
                {
                    var name = property.Name;
                    var value = property.GetValue(this.Parameters);
                    parametersBuilder.Append($"&{name}={value}");
                }
                parametersPath = parametersBuilder.ToString();
            }
            return parametersPath;
        }
    }
}
