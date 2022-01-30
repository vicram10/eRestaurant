#pragma checksum "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Producto\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3664551cb0adb0e3897a096453dd545f3d3fa5f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Producto_Index), @"mvc.1.0.view", @"/Views/Producto/Index.cshtml")]
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
#nullable restore
#line 1 "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Producto\Index.cshtml"
using eInfrastructure.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Producto\Index.cshtml"
using eInfrastructure.Languages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Producto\Index.cshtml"
using eInfrastructure.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Producto\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3664551cb0adb0e3897a096453dd545f3d3fa5f", @"/Views/Producto/Index.cshtml")]
    public class Views_Producto_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 11 "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Producto\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

    Localization language = new Localization(httpContextAccessor);

    ViewBag.Title = language.getText("menuProducto");

    string MensajeAlta = ViewBag.MensajeAlta;

    string CodigoMensaje = ViewBag.CodigoMensaje;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 23 "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Producto\Index.cshtml"
 if (CodigoMensaje == "OK")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success d-flex align-items-center\" role=\"alert\">\r\n        <i class=\"bi bi-check-circle fw-bold me-3\"></i>\r\n        <div>\r\n            ");
#nullable restore
#line 28 "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Producto\Index.cshtml"
        Write(String.IsNullOrEmpty(MensajeAlta) ? language.getText("msgRegistroOK") : MensajeAlta);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 31 "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Producto\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"mb-2\">\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 818, "\"", 856, 1);
#nullable restore
#line 34 "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Producto\Index.cshtml"
WriteAttributeValue("", 825, Url.Action("Alta", "Producto"), 825, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-success btn-sm\"><i class=\"bi bi-plus-circle-fill me-2\"></i>");
#nullable restore
#line 34 "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Producto\Index.cshtml"
                                                                                                                           Write(language.getText("btnAgregar"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n</div>\r\n\r\n");
#nullable restore
#line 37 "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Producto\Index.cshtml"
Write(await Html.PartialAsync("ListaProductos.cshtml"));

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor httpContextAccessor { get; private set; }
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