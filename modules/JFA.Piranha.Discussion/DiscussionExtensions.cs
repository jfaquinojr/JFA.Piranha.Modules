using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Piranha;
using Piranha.Manager.Editor;

namespace JFA.Piranha.Discussion
{
    public static class DiscussionExtensions
    {
        public static IServiceCollection AddPiranhaTinyMCE(this IServiceCollection services)
        {
            // Add the manager module
            App.Modules.Register<Module>();

            // Return the service collection
            return services;
        }

        public static IApplicationBuilder UsePiranhaTinyMCE(this IApplicationBuilder builder)
        {
            //
            // Register the editor scripts.
            //
            EditorScripts.MainScriptUrl = "~/manager/jfa/discussion.min.js";
            EditorScripts.EditorScriptUrl = "~/manager/jfa/discussion.editor.js";

            //
            // Add the embedded resources
            //
            return builder.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new EmbeddedFileProvider(typeof(DiscussionExtensions).Assembly, "JFA.Piranha.Discussion.assets"),
                RequestPath = "/manager/jfa"
            });
        }
    }
}
