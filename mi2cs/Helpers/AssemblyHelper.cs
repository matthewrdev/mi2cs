﻿using System;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace mi2cs.Helpers
{
    public static class AssemblyHelper
    {
        public static Assembly EntryAssembly => Assembly.GetEntryAssembly();

        public static string EntryAssemblyDirectory => DirectoryForAssembly(EntryAssembly);

        public static string DirectoryForAssembly(Assembly assembly)
        {
            var codeBase = assembly.CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        public static Assembly GetAssemblyByName(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies().
                   SingleOrDefault(assembly => assembly.GetName().Name == name);
        }

        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }
    }
}

