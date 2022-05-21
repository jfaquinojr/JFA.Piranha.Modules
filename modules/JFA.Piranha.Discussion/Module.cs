using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piranha.Extend;
using Piranha;

namespace JFA.Piranha.Discussion
{
    public class Module : IModule
    {
        public string Author => "JFA";
        public string Name => "JFA.Piranha.Discussion";
        public string Version => Utils.GetAssemblyVersion(this.GetType().Assembly);
        public string Description => "Comments alternative for Piranha CMS.";
        public string PackageUrl => "https://www.nuget.org/packages/JFA.Piranha.Discussion";
        public string IconUrl => "https://piranhacms.org/assets/twitter-shield.png";

        public void Init() { }
    }
}
