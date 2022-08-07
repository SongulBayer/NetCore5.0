#pragma checksum "C:\Users\songül bayer\source\repos\NetCore5.0\Areas\Admin\Views\Writer\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99b03150cec0c294926c358276374c7b1e14812f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Writer_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Writer/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99b03150cec0c294926c358276374c7b1e14812f", @"/Areas/Admin/Views/Writer/Index.cshtml")]
    public class Areas_Admin_Views_Writer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\songül bayer\source\repos\NetCore5.0\Areas\Admin\Views\Writer\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<br />
<div id=""writerlist"">
    Buraya yazarlar gelicek
</div>
<div id=""writerget"">
    Buraya 1 yazar gelecek
</div>
<div>
    <input type=""text"" id=""writerid"" placeholder=""Yazar Id Değerini Girin"" class=""form-control""/>
</div>
<button type=""button"" id=""btngetlist"" class=""btn btn-outline-primary"">Yazar Listesi</button>
<button type=""button"" id=""btngetbyid"" class=""btn btn-outline-success"">Yazar Geti</button>
");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
    $(""#btngetlist"").click(function () {
        $.ajax({
            contentType: ""application/json"",
            dataType: ""json"",
            type: ""Get"",
            url: ""/Admin/Writer/WriterList"",
            success: function (func) {
                let w = jQuery.parseJSON(func);
                console.log(w);
                let tablehtml = ""<table class=table table bordered><tr><th>Yazar Id</th><th>Yazar Adı </th></tr> "";
                $.each(w, (index, value) => {
                    tablehtml += `<tr><td>${value.Id}</td> <td>${value.Name}</td></tr>`
                });
                tablehtml += ""</table>"";
                $(""#writerlist"").html(tablehtml)
                
                console.log(func);
            }
        });
    });
        $(""#btngetbyid"").click(x => {
            let id = $(""#writerid"").val();
            $.ajax({
                contentType: ""application/json"",
                dataType: ""json"",
                type: ""get"",
");
                WriteLiteral(@"                url: ""/Admin/Writer/GetWriterById/"",
                data: { Writerid:id},
                success: function (func) {
                    let w = jQuery.parseJSON(func);
                    console.log(w);

                    let getvalue = `<table class=table table-bordered> <tr><th>Yazar Id </th> <th> Yazar Adı</th></tr> <tr><td>${w.Id}</td><td>${w.Name}</td></tr></table>`;
                    $('#writerget').html(getvalue);
                }
            });
        });
    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
