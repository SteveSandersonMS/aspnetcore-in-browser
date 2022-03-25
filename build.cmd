@rem NOTE: Trimming breaks Razor Pages for some reason. Other aspects of ASP.NET Core work after trimming.

pushd MyWebApp
dotnet build
popd
cp MyWebApp\bin\Debug\net7.0\MyWebApp.wasm dist\
wasm-opt dist\MyWebApp.wasm -O3 -o dist\MyWebApp.opt.wasm
brotli -f dist\MyWebApp.opt.wasm
rm dist\*.wasm
