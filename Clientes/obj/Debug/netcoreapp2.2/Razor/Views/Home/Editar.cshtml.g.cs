#pragma checksum "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6feeab64f1458eddc8c640378f96a98fe3cb466c"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6feeab64f1458eddc8c640378f96a98fe3cb466c", @"/Views/Home/Editar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d580f61b3253ded3bf36e9e9e910957fdfd5af3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Editar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Clientes>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "5", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "4", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "6", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(166, 2349, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6feeab64f1458eddc8c640378f96a98fe3cb466c5334", async() => {
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
                BeginContext(385, 165, true);
                WriteLiteral(" required>\r\n\r\n    <div class=\"form-group\">\r\n        <label for=\"exampleFormControlInput1\">Cuenta</label>\r\n        <input id=\"Cuenta\" type=\"text\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 550, "\"", 577, 1);
#line 16 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 564, Model.Cuenta, 564, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 578, "\"", 599, 1);
#line 16 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 586, Model.Cuenta, 586, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(600, 176, true);
                WriteLiteral(">\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <label for=\"exampleFormControlInput1\">Contraseña</label>\r\n        <input id=\"Contraseña\" type=\"text\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 776, "\"", 807, 1);
#line 21 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 790, Model.Contraseña, 790, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 808, "\"", 833, 1);
#line 21 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 816, Model.Contraseña, 816, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(834, 132, true);
                WriteLiteral(">\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"exampleFormControlInput1\">Fecha de vencimiento de la Cuenta</label>");
                EndContext();
                BeginContext(989, 71, true);
                WriteLiteral("\r\n        <input id=\"VencimientoC\" type=\"datetime\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 1060, "\"", 1093, 1);
#line 25 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 1074, Model.VencimientoC, 1074, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1094, "\"", 1121, 1);
#line 25 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 1102, Model.VencimientoC, 1102, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1122, 131, true);
                WriteLiteral(">\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"exampleFormControlInput1\">Fecha de vencimiento del Cliente</label>");
                EndContext();
                BeginContext(1276, 71, true);
                WriteLiteral("\r\n        <input id=\"VencimientoP\" type=\"datetime\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 1347, "\"", 1380, 1);
#line 29 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 1361, Model.VencimientoP, 1361, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1381, "\"", 1408, 1);
#line 29 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 1389, Model.VencimientoP, 1389, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1409, 167, true);
                WriteLiteral(">\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"exampleFormControlSelect1\">Tipo</label>\r\n        <select id=\"Tipo\" class=\"form-control\">\r\n            ");
                EndContext();
                BeginContext(1576, 69, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6feeab64f1458eddc8c640378f96a98fe3cb466c10828", async() => {
                    BeginContext(1606, 29, false);
#line 34 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
                                    Write(((Tipo)Model.Tipo).ToString());

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 34 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
               WriteLiteral(Model.Tipo);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1645, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(1659, 37, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6feeab64f1458eddc8c640378f96a98fe3cb466c12879", async() => {
                    BeginContext(1678, 9, false);
#line 35 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
                         Write(Tipo.Flow);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1696, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(1710, 37, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6feeab64f1458eddc8c640378f96a98fe3cb466c14482", async() => {
                    BeginContext(1729, 9, false);
#line 36 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
                         Write(Tipo.IPTV);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1747, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(1761, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6feeab64f1458eddc8c640378f96a98fe3cb466c16085", async() => {
                    BeginContext(1780, 12, false);
#line 37 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
                         Write(Tipo.Netflix);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1801, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(1815, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6feeab64f1458eddc8c640378f96a98fe3cb466c17692", async() => {
                    BeginContext(1834, 16, false);
#line 38 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
                         Write(Tipo.AmazonPrime);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1859, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(1873, 42, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6feeab64f1458eddc8c640378f96a98fe3cb466c19303", async() => {
                    BeginContext(1892, 14, false);
#line 39 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
                         Write(Tipo.DirecTVGo);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1915, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(1929, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6feeab64f1458eddc8c640378f96a98fe3cb466c20912", async() => {
                    BeginContext(1948, 12, false);
#line 40 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
                         Write(Tipo.Spotify);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1969, 209, true);
                WriteLiteral("\r\n\r\n        </select>\r\n    </div>\r\n\r\n\r\n    <div class=\"form-group\">\r\n        <label for=\"exampleFormControlSelect1\">Cantidad de pantallas</label>\r\n        <input id=\"Pantallas\" type=\"text\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 2178, "\"", 2208, 1);
#line 48 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 2192, Model.Pantallas, 2192, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 2209, "\"", 2233, 1);
#line 48 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 2217, Model.Pantallas, 2217, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2234, 202, true);
                WriteLiteral(">\r\n    </div>\r\n\r\n    <div>\r\n        <div class=\"form-group\">\r\n            <label for=\"exampleFormControlTextarea1\">Comentario</label>\r\n            <textarea class=\"form-control\" id=\"Comentario\" rows=\"3\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2436, "\"", 2461, 1);
#line 54 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 2444, Model.Comentario, 2444, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2462, 46, true);
                WriteLiteral("></textarea>\r\n        </div>\r\n    </div>\r\n\r\n\r\n");
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
            BeginContext(2515, 9, true);
            WriteLiteral("\r\n<button");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2524, "\"", 2560, 3);
            WriteAttributeValue("", 2534, "EnviarEdicion(\'", 2534, 15, true);
#line 60 "C:\Users\Ivan Bonfigli\Desktop\ClientesBonfigli\Clientes\Views\Home\Editar.cshtml"
WriteAttributeValue("", 2549, Model.Id, 2549, 9, false);

#line default
#line hidden
            WriteAttributeValue("", 2558, "\')", 2558, 2, true);
            EndWriteAttribute();
            BeginContext(2561, 54, true);
            WriteLiteral("class=\"btn btn-outline-success btn-lg\">Enviar</button>");
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
