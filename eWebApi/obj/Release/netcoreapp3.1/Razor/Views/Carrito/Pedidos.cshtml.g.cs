#pragma checksum "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9fc3f6e1d8fe5857da8107a872e29b33a083b814"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Carrito_Pedidos), @"mvc.1.0.view", @"/Views/Carrito/Pedidos.cshtml")]
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
#line 1 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
using eInfrastructure.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
using eInfrastructure.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
using eInfrastructure.Models.Carrito;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
using eInfrastructure.Languages;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fc3f6e1d8fe5857da8107a872e29b33a083b814", @"/Views/Carrito/Pedidos.cshtml")]
    public class Views_Carrito_Pedidos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 13 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
  

    Localization language = new Localization(httpContextAccessor);

    Layout = "~/Views/Shared/_Layout.cshtml";

    ViewBag.Title = language.getText("lbTusPedidos", "Carrito");

    List<Carrito> ListaPedidos = ViewBag.ListaCarrito as List<Carrito>;

    string estadoDoc = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 26 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
 if (ListaPedidos.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""mt-2 border p-3 table-responsive"">
        <table class=""table table-striped displayDataTableSearch"" style=""width:100%"">
            <thead>
                <tr>
                    <th scope=""col"">#</th>
                    <th scope=""col"">");
#nullable restore
#line 33 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
                               Write(language.getText("lbTusPedidos", "Carrito"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th scope=\"col\">");
#nullable restore
#line 34 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
                               Write(language.getText("lbEstado", "Carrito"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                </tr>\r\n            </thead>\r\n            <tfoot>\r\n                <tr>\r\n                    <th scope=\"col\">#</th>\r\n                    <th scope=\"col\">");
#nullable restore
#line 40 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
                               Write(language.getText("lbTusPedidos", "Carrito"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th scope=\"col\">");
#nullable restore
#line 41 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
                               Write(language.getText("lbEstado", "Carrito"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                </tr>\r\n            </tfoot>\r\n            <tbody>\r\n");
#nullable restore
#line 45 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
                 foreach(var item in ListaPedidos.GroupBy(pp=> pp.DocIDAdamsPay))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 48 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
                       Write(item.Key.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            <ul>\r\n");
#nullable restore
#line 51 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
                             foreach(Carrito itemCarrito in ListaPedidos.Where(pp => pp.DocIDAdamsPay == item.Key.ToString()))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li>");
#nullable restore
#line 53 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
                                Write($"{itemCarrito.Producto.NombreProducto} - {itemCarrito.Producto.Precio.ToString("n0")}");

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 55 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
                            Write(estadoDoc = Enum.GetName(typeof(EstadoCarritoModel), itemCarrito.Estado));

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
                                                                                                           
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </ul>\r\n                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 60 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
                               
                                string background = "";

                                switch(estadoDoc.ToUpper())
                                {
                                    case "PAGADO":
                                        background = "success";
                                        break;
                                    case "PENDIENTE":
                                        background = "danger";
                                        break;
                                    case "CREADADEUDA":
                                        background = "info";
                                        break;
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                            \r\n                            ");
#nullable restore
#line 77 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
                       Write(Html.Raw($"<span class='me-3 badge bg-{background}'>{estadoDoc}</span>"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 79 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
                             if (estadoDoc.ToUpper() == "PENDIENTE" || estadoDoc.ToUpper() == "CREADADEUDA")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a");
            BeginWriteAttribute("href", " href=\"", 3205, "\"", 3250, 1);
#nullable restore
#line 81 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
WriteAttributeValue("", 3212, Url.Action("PrepararPago", "Carrito"), 3212, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"me-3 btn btn-secondary btn-sm\">");
#nullable restore
#line 81 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
                                                                                                                  Write(language.getText("lbFinalizarCompra", "Carrito"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 82 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 85 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
#nullable restore
#line 89 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-warning\" role=\"alert\">\r\n        ");
#nullable restore
#line 93 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
   Write(language.getText("msgNoExisteRegistro"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 95 "E:\Proyectos\0-NetCore\eRestaurtant.Project\0-eRestaurant.Desa\eWebApi\Views\Carrito\Pedidos.cshtml"
}

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
