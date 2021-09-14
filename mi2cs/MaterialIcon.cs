using System.Diagnostics;
using mi2cs.Helpers;

namespace mi2cs
{
    [DebuggerDisplay("{Name} - {DotNetName}")]
    public class MaterialIcon
    {
        public MaterialIcon(string name, string codepoint)
        {
            Name = name;
            DotNetName = DotNetNameHelper.ToDotNetName(Name);
            Unicode = codepoint;
            Url = "https://github.com/Templarian/MaterialDesign/blob/master/svg/" + name + ".svg";
        }

        public string Name { get; }
        public string Unicode { get; }
        public string Url { get; }
        public string DotNetName { get; }
    }
}
