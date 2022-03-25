@rem NOTE: Trimming breaks Razor Pages for some reason. Other aspects of ASP.NET Core work after trimming.

pushd MyWebApp
dotnet build
popd
cp MyWebApp\bin\Debug\net7.0\MyWebApp.wasm docs\
wasm-opt docs\MyWebApp.wasm -O3 -o docs\MyWebApp.opt.wasm
brotli -f docs\MyWebApp.opt.wasm
rm docs\*.wasm
