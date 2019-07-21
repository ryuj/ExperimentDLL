using System;
using System.Runtime.InteropServices;
using System.Reflection;
using Sample;

class MyMain
{
    public static void Main(string[] args)
    {
        if (true)
        {
            InDll.LogStringSplit();
        }

        // アセンブリ位置
        if (false)
        {
            Console.WriteLine("-- out DLL --");
            Console.WriteLine(typeof(int).Assembly.Location);
            // Console.WriteLine(typeof(Uri).Assembly.Location);
            Console.WriteLine(typeof(string).Assembly.Location);

            Console.WriteLine(InDll.GetAssemblyLocation());
        }

        // 関数一覧
        if (false)
        {
            var s = "";
            foreach (var v in typeof(string).GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                s += v.ToString();
                s += "\n";
            }
            Console.WriteLine(s);

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
        if (false)
        {
            var s = "abc.def";
            {
                // どっちかで呼ばれる
                var a = s.Split('.');
                foreach (var v in a)
                {
                    Console.WriteLine(v);
                }
            }
            // {
            //     // .NET には存在しない
            //     var a = s.Split('.', StringSplitOptions.None);
            //     foreach (var v in a)
            //     {
            //         Console.WriteLine(v);
            //     }
            // }
            {
                // params
                char[] sp = {'.'};
                var a = s.Split(sp);
                foreach (var v in a)
                {
                    Console.WriteLine(v);
                }
            }
            {
                // params 付き関数が存在
                var a = s.Split('.', ',', ',', ',', ',', ',');
                foreach (var v in a)
                {
                    Console.WriteLine(v);
                }
            }
        }
    }
}
