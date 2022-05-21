using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piranha;
using Piranha.AspNetCore;

namespace JFA.Piranha.Discussion
{
    public static class DiscussionStartupExtensions
    {
        public static PiranhaServiceBuilder UseTinyMCE(this PiranhaServiceBuilder serviceBuilder)
        {
            serviceBuilder.Services.AddPiranhaTinyMCE();

            return serviceBuilder;
        }

        public static PiranhaApplicationBuilder UseTinyMCE(this PiranhaApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Builder.UsePiranhaTinyMCE();

            return applicationBuilder;
        }
    }
}
