#pragma checksum "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Portal\Inicio.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eeda81497f9ca9a7d30dd4a7a3af567bf76ed557"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Portal_Inicio), @"mvc.1.0.view", @"/Views/Portal/Inicio.cshtml")]
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
#line 1 "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Portal\Inicio.cshtml"
using eInfrastructure.Languages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Portal\Inicio.cshtml"
using eInfrastructure.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Portal\Inicio.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eeda81497f9ca9a7d30dd4a7a3af567bf76ed557", @"/Views/Portal/Inicio.cshtml")]
    public class Views_Portal_Inicio : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 9 "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Portal\Inicio.cshtml"
  
    Localization language = new Localization(HttpContextAccessor);

    ViewBag.Title = language.getText("menuInicio");

    Layout = "~/Views/Shared/_Layout.cshtml";

    DatosUsuarioModel datosUsuario = (DatosUsuarioModel)ViewBag.DatosUsuario;


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 20 "E:\Proyectos\0-NetCore\eRestaurant\eWebApi\Views\Portal\Inicio.cshtml"
Write(await Html.PartialAsync("~/Views/Producto/ListaProductos.cshtml"));

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
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
