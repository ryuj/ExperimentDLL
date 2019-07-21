using System;
using System.Runtime.InteropServices;
// using System.Reflection;
using Sample;

class MyMain
{
    public static void Main(string[] args)
    {
        // アセンブリ位置
        if (false)
        {
            Console.WriteLine("-- out DLL --");
            Console.WriteLine(typeof(int).Assembly.Location);
            Console.WriteLine(typeof(Uri).Assembly.Location);
            Console.WriteLine(typeof(string).Assembly.Location);

            Console.WriteLine(InDll.GetAssemblyLocation());
        }

        // 関数一覧
        if (false)
        {
            // var s = "";
            // foreach (var v in typeof(string).GetMethods(BindingFlags.Public | BindingFlags.Instance))
            // {
            //     s += v.ToString();
            //     s += "\n";
            // }
            // Console.WriteLine(s);

            Console.WriteLine(InDll.GetMethodNames());
        }

        // string.Split 取得、リフレクション系はいったんコメントアウト
        if (false)
        {
            // var b = new Binder();
            // var a = typeof(string).GetMethod("Split", BindingFlags.Public | BindingFlags.Instance, b);
            // foreach (MethodInfo v in typeof(string).GetMethods(BindingFlags.Public | BindingFlags.Instance))
            // {
            //     if (v.ToString() == "System.String[] Split(Char, System.StringSplitOptions)")
            //     {
            //         Console.WriteLine(v);
            //     }
            // }
        }

        // string.Split 動かす
        if (true)
        {
            var s = "abc.def";
            {
                var a = s.Split('.', StringSplitOptions.None);
                foreach (var v in a)
                {
                    Console.WriteLine(v);
                }
            }
            {
                char[] sp = {'.'};
                var a = s.Split(sp);
                foreach (var v in a)
                {
                    Console.WriteLine(v);
                }
            }
        }
    }
}
