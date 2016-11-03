using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html5CodeGenerator
{
    class Program
    {


        const string CLASS_FORMAT = "public class {0} : HtmlBase {{ public string Description {{ get {{ return \"{1}\"; }} }} public {0}() {{ }} }}";

        static void Main(string[] args)
        {
            new Program().MainImpl(args);        
        }

        void MainImpl(string[] args)
        {
            var tuples = this.ReadFile();
            this.GenerateCode(tuples);
        }

        private void GenerateCode(List<Tuple<string, string>> tuples)
        {
            foreach (var tuple in tuples)
            {
                var code = string.Format(CLASS_FORMAT, tuple.Item1, tuple.Item2);
                Debug.WriteLine(code);
            }
        }

        List<Tuple<string, string>> ReadFile()
        {
            var result = new List<Tuple<string, string>>();
            using (var sr = new StreamReader(@"c:\Dev\Proto\Html5 tags.csv"))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var arr = line.Split(',');
                    var tuple = new Tuple<string, string>(arr[0], arr[1]);
                    result.Add(tuple);
                }
            }
            return result;
        }

    }
}
