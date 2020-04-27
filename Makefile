# Makefile requires Visual Studio for Mac Community version to be installed
# Tested with 8.5.3 (build 16)
setup:
	cd src/ACPGriffon.XamarinAndroidBinding/ && msbuild -t:restore

msbuild-clean:
	cd src && msbuild -t:clean

clean-folders:
	cd src/ACPGriffon.XamarinAndroidBinding/ && rm -rf obj
	cd src/ACPGriffon.XamarinAndroidBinding/bin && rm -rf Debug
	rm -rf bin

clean: msbuild-clean clean-folders setup

# Makes ACPGriffon android bindings and NuGet package. The android binding (.dll) will be available in src/ACPGriffon.XamarinAndroidBinding/bin/Debug
# The NuGet package is created in the same directory but then moved to src/bin.
all:
	cd src && msbuild -t:pack
	mkdir bin
	cp src/ACPGriffon.XamarinAndroidBinding/bin/Debug/*.nupkg ./bin
	