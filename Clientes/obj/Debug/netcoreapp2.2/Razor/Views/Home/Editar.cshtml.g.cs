#pragma checksum "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c5fabd6052f803ef98b7cba0362ddbe49e947380"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Editar), @"mvc.1.0.view", @"/Views/Home/Editar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Editar.cshtml", typeof(AspNetCore.Views_Home_Editar))]
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
#line 1 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\_ViewImports.cshtml"
using Clientes;

#line default
#line hidden
#line 2 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\_ViewImports.cshtml"
using Clientes.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5fabd6052f803ef98b7cba0362ddbe49e947380", @"/Views/Home/Editar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d580f61b3253ded3bf36e9e9e910957fdfd5af3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Editar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Clientes>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(121, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(147, 19, true);
            WriteLiteral("\r\n<h1>Editar</h1>\r\n");
            EndContext();
            BeginContext(166, 2135, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5fabd6052f803ef98b7cba0362ddbe49e9473803588", async() => {
                BeginContext(172, 163, true);
                WriteLiteral("\r\n    <div class=\"form-group\">\r\n        <label for=\"exampleFormControlInput1\">Nombre</label>\r\n    </div>        <input id=\"Nombre\" type=\"text\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 335, "\"", 362, 1);
#line 12 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 349, Model.Nombre, 349, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 363, "\"", 384, 1);
#line 12 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 371, Model.Nombre, 371, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(385, 156, true);
                WriteLiteral(">\r\n\r\n    <div class=\"form-group\">\r\n        <label for=\"exampleFormControlInput1\">Cuenta</label>\r\n        <input id=\"Cuenta\" type=\"text\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 541, "\"", 568, 1);
#line 16 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 555, Model.Cuenta, 555, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("value", "value=\"", 569, "\"", 589, 1);
#line 16 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 576, Model.Cuenta, 576, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(590, 165, true);
                WriteLiteral(">\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"exampleFormControlInput1\">Email</label>\r\n        <input id=\"Email\" type=\"email\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 755, "\"", 781, 1);
#line 20 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 769, Model.Email, 769, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("value", "value=\"", 782, "\"", 801, 1);
#line 20 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 789, Model.Email, 789, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(802, 174, true);
                WriteLiteral(">\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"exampleFormControlInput1\">Contraseña</label>\r\n        <input id=\"Contraseña\" type=\"text\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 976, "\"", 1007, 1);
#line 24 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 990, Model.Contraseña, 990, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1008, "\"", 1033, 1);
#line 24 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 1016, Model.Contraseña, 1016, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1034, 132, true);
                WriteLiteral(">\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"exampleFormControlInput1\">Fecha de vencimiento de la Cuenta</label>");
                EndContext();
                BeginContext(1189, 71, true);
                WriteLiteral("\r\n        <input id=\"VencimientoC\" type=\"datetime\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 1260, "\"", 1293, 1);
#line 28 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 1274, Model.VencimientoC, 1274, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1294, "\"", 1321, 1);
#line 28 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 1302, Model.VencimientoC, 1302, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1322, 128, true);
                WriteLiteral(">\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"exampleFormControlInput1\">Fecha de vencimiento del pago</label>");
                EndContext();
                BeginContext(1473, 71, true);
                WriteLiteral("\r\n        <input id=\"VencimientoP\" type=\"datetime\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 1544, "\"", 1577, 1);
#line 32 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 1558, Model.VencimientoP, 1558, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1578, "\"", 1605, 1);
#line 32 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 1586, Model.VencimientoP, 1586, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1606, 152, true);
                WriteLiteral(">\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"exampleFormControlSelect1\">Tipo</label>\r\n        <select id=\"Tipo\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1758, "\"", 1777, 1);
#line 36 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 1766, Model.Tipo, 1766, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1778, 15, true);
                WriteLiteral(">\r\n            ");
                EndContext();
                BeginContext(1793, 18, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5fabd6052f803ef98b7cba0362ddbe49e94738010401", async() => {
                    BeginContext(1801, 1, true);
                    WriteLiteral("1");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1811, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(1825, 18, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5fabd6052f803ef98b7cba0362ddbe49e94738011665", async() => {
                    BeginContext(1833, 1, true);
                    WriteLiteral("2");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1843, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(1857, 18, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5fabd6052f803ef98b7cba0362ddbe49e94738012929", async() => {
                    BeginContext(1865, 1, true);
                    WriteLiteral("3");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1875, 194, true);
                WriteLiteral("\r\n\r\n        </select>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"exampleFormControlSelect1\">Cantidad de pantallas</label>\r\n        <select id=\"Pantallas\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2069, "\"", 2093, 1);
#line 45 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 2077, Model.Pantallas, 2077, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2094, 15, true);
                WriteLiteral(">\r\n            ");
                EndContext();
                BeginContext(2109, 18, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5fabd6052f803ef98b7cba0362ddbe49e94738014832", async() => {
                    BeginContext(2117, 1, true);
                    WriteLiteral("1");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2127, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(2141, 18, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5fabd6052f803ef98b7cba0362ddbe49e94738016096", async() => {
                    BeginContext(2149, 1, true);
                    WriteLiteral("2");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2159, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(2173, 18, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5fabd6052f803ef98b7cba0362ddbe49e94738017360", async() => {
                    BeginContext(2181, 1, true);
                    WriteLiteral("3");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2191, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(2205, 18, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5fabd6052f803ef98b7cba0362ddbe49e94738018624", async() => {
                    BeginContext(2213, 1, true);
                    WriteLiteral("4");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2223, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(2237, 18, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5fabd6052f803ef98b7cba0362ddbe49e94738019888", async() => {
                    BeginContext(2245, 1, true);
                    WriteLiteral("5");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2255, 39, true);
                WriteLiteral("\r\n        </select>\r\n    </div>\r\n\r\n\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2301, 9, true);
            WriteLiteral("\r\n<button");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2310, "\"", 2346, 3);
            WriteAttributeValue("", 2320, "EnviarEdicion(\'", 2320, 15, true);
#line 57 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 2335, Model.Id, 2335, 9, false);

#line default
#line hidden
            WriteAttributeValue("", 2344, "\')", 2344, 2, true);
            EndWriteAttribute();
            BeginContext(2347, 16, true);
            WriteLiteral(">Enviar</button>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Clientes> Html { get; private set; }
    }
}
#pragma warning restore 1591
