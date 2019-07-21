using System;
// using System.Reflection;

namespace Sample
{
    public class InDll
    {
        public static void LogAssemblyLocation()
        {
            Console.WriteLine("-- in DLL --");
            Console.WriteLine(typeof(int).Assembly.Location);
            Console.WriteLine(typeof(Uri).Assembly.Location);
            Console.WriteLine(typeof(string).Assembly.Location);
        }

        public static string GetAssemblyLocation()
        {
            string s = typeof(int).Assembly.Location;
            s += "\n";
            s += typeof(Uri).Assembly.Location;
            s += "\n";
            s += typeof(string).Assembly.Location;
            return s;
        }

        public static void LogStringSplit()
        {
            var st = "abc.def";
            // string[] sa = st.Split('.');
            char[] at = {'.'};
            string[] sa = st.Split(at);
            foreach (var str in sa)
            {
                Console.WriteLine(str);
            }
        }

        public static string GetMethodNames()
        {
            var s = "";
            // foreach (var v in typeof(string).GetMethods(BindingFlags.Public | BindingFlags.Instance))
            // {
            //     s += v.ToString();
            //     s += "\n";
            // }
            return s;
        }
    }
}
