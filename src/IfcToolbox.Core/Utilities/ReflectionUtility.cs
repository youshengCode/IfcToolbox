using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace IfcToolbox.Core.Utilities
{
    public class ReflectionUtility
    {
        public static string GetExecutingAssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static void CopyEmbeddedResource(Assembly sourceAssembly, string fileName)
        {
            var resourceFileName = sourceAssembly.GetManifestResourceNames().ToList().Where(x => x.EndsWith(fileName));
            if (!resourceFileName.Any())
                return;
            using var stream = sourceAssembly.GetManifestResourceStream(resourceFileName.FirstOrDefault());
            CopyBinaryFileToAssemblyDirectory(fileName, stream);
        }

        public static void CopyBinaryFileToAssemblyDirectory(string filename, Stream stream)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                string path = Path.Combine(GetExecutingAssemblyDirectory, filename);
                if (File.Exists(path)) return;
                File.WriteAllBytes(path, memoryStream.ToArray());
            }
        }

        public static Dictionary<string, object> DictionaryFromType(object atype)
        {
            if (atype == null) return new Dictionary<string, object>();
            PropertyInfo[] props;
            if (atype is Type t)
                props = t.GetProperties();
            else
                props = atype.GetType().GetProperties();
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (PropertyInfo prop in props)
            {
                if (atype is Type)
                {
                    dict.Add(prop.Name, string.Empty);
                    continue;
                }
                object value = prop.GetValue(atype, new object[] { });
                dict.Add(prop.Name, value);
            }
            return dict;
        }

    }
}
