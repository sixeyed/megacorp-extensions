using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MarkdownWikiGenerator
{
    class Program
    {
        // 0 = dll src path, 1 = dest root
        static void Main(string[] args)
        {
            // put dll & xml on same diretory.
            var target = "UniRx.dll"; // :)
            string dest = "md";
            string namespaceMatch = string.Empty;
            if (args.Length == 1)
            {
                target = args[0];
            }
            else if (args.Length == 2)
            {
                target = args[0];
                dest = args[1];
            }
            else if (args.Length == 3) 
            {
                target = args[0];
                dest = args[1];
                namespaceMatch = args[2];
            }

            var types = new List<MarkdownableType>();
            if (target.EndsWith(".dll"))
            {
                types.AddRange(MarkdownGenerator.Load(target, namespaceMatch).Where(x => x.Name.EndsWith("Extensions")));
            }
            else
            {
                //assume directory:
                var assemblies = Directory.GetFiles(target, namespaceMatch);
                foreach (var assembly in assemblies)
                {
                    if (!assembly.EndsWith(".Tests.dll"))
                    {
                        types.AddRange(MarkdownGenerator.Load(assembly, "").Where(x => x.Name.EndsWith("Extensions")));
                    }
                }
            }

            // Home Markdown Builder
            var homeBuilder = new MarkdownBuilder();
            homeBuilder.Header(1, "Extension Method Library");
            homeBuilder.AppendLine();

            foreach (var g in types.GroupBy(x => x.Namespace).OrderBy(x => x.Key))
            {
                if (!Directory.Exists(dest)) Directory.CreateDirectory(dest);

                homeBuilder.HeaderWithLink(2, g.Key, g.Key);
                homeBuilder.AppendLine();

                var sb = new StringBuilder();
                foreach (var item in g.OrderBy(x => x.Name))
                {
                    homeBuilder.ListLink(MarkdownBuilder.MarkdownCodeQuote(item.BeautifyName), g.Key + "#" + item.BeautifyName.Replace("<", "").Replace(">", "").Replace(",", "").Replace(" ", "-").ToLower());

                    sb.Append(item.ToString());
                }

                File.WriteAllText(Path.Combine(dest, g.Key + ".md"), sb.ToString());
                homeBuilder.AppendLine();
            }

            // Gen Home
            File.WriteAllText(Path.Combine(dest, "Home.md"), homeBuilder.ToString());
        }
    }
}
