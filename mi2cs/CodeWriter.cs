﻿using System;
using System.Collections.Generic;
using System.Linq;
using mi2cs.Helpers;

namespace mi2cs
{
    public static class CodeWriter
    {
        public static string Write(IEnumerable<MaterialIcon> icons)
        {
            Console.WriteLine("Generating C# code...");

            var classTemplate = ResourcesHelper.ReadResourceContent("ClassTemplate.txt");
            var propertyTemplate = ResourcesHelper.ReadResourceContent("PropertyTemplate.txt");

            var properties = icons.Select(icon => propertyTemplate.Replace("$link$", icon.Url)
                    .Replace("$name$", icon.Name)
                    .Replace("$code$", icon.Unicode)
                    .Replace("$dotnet_name$", icon.DotNetName));

            var separator = Environment.NewLine + Environment.NewLine;
            var code = string.Join(separator, properties);

            return classTemplate.Replace("$properties$", code);
        }
    }
}
