
def main
    dll_name = "MyDll.dll"
    main_name = "MyMain"

    # mono で csc.exe
    cmd = "mono /Library/Frameworks/Mono.framework/Versions/Current/lib/mono/4.5/csc.exe"
    # mono で Rosyln
    cmd = "mono /Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/msbuild/Current/bin/Roslyn/csc.exe"
    # Rosylin の実体と思われる
    cmd = "/Library/Frameworks/Mono.framework/Versions/Current/bin/csc"
    # Unity mcs @ MonoBleedingEdge
    cmd = "/Applications/Unity/Hub/Editor/2017.4.25f1/Unity.app/Contents/MonoBleedingEdge/bin/mcs"
    # cmd = "mcs"
    # cmd = "csc"
    # Unity mcs
    # cmd = "/Applications/Unity/Unity.app/Contents/Mono/bin/mcs"

    # VS のマネ
    op1 = "/reference:/Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/4.7-api/mscorlib.dll"
    # デフォルト
    # op1 = "/reference:/Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/4.5/mscorlib.dll"
    # 古い -api
    # op1 = "/reference:/Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/4.0-api/mscorlib.dll"
    # 古い
    # op1 = "/reference:/Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/4.0/mscorlib.dll"
    # Unity 内 mcs
    # op1 = "/reference:/Applications/Unity/Unity.app/Contents/Mono/lib/mono/unity/mscorlib.dll"
    # VS のマネ
    # op1 = "/reference:/Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/4.7-api/mscorlib.dll /reference:/Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/4.7-api/System.Core.dll /reference:/Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/4.7-api/System.dll"
    # VS のマネ前乗せ
    op1 = "/reference:/Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/4.7-api/mscorlib.dll /reference:/Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/4.7-api/System.dll"
    # Unity のやつ
    op1 = "/reference:/Applications/Unity/Hub/Editor/2017.4.25f1/Unity.app/Contents/MonoBleedingEdge/lib/mono/4.5/mscorlib.dll"
    op1 = ""

    # VS のマネ
    op2 = "/reference:/Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/4.7-api/System.Core.dll"
    # 上と似たようなやつ
    op2 = "/reference:/Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/4.6-api/mscorlib.dll"
    # -api なし
    op2 = "/reference:/Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/4.5/mscorlib.dll"
    # VS のマネ
    op2 = "/reference:/Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/4.7-api/System.dll /noconfig"
    # VS のマネ
    op2 = "/noconfig /reference:/Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/4.7-api/System.Core.dll"
    op2 = ""

    # VS のマネ
    op3 = "/reference:/Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/4.7-api/System.dll"
    # 参照解除
    op3 = "/nostdlib /nostdlib+"
    op3 = ""

    executor = "mono"
    executor = "/Applications/Unity/Hub/Editor/2017.4.25f1/Unity.app/Contents/MonoBleedingEdge/bin/mono"

    line = "----------"
    run "rm -f #{dll_name}"
    run "rm -f #{main_name}.exe"
    puts line
    run "#{cmd} #{op1} #{op2} #{op3} -target:library -out:#{dll_name} InDll.cs"
    puts line
    run "#{cmd} -r:#{dll_name} #{main_name}.cs"
    puts line
    run "#{executor} #{main_name}.exe"
end

def run(cmd)
    puts cmd
    system cmd
end

main
