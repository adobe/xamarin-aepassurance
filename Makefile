# Makefile requires Visual Studio for Mac Community version to be installed
# Tested with 8.5.3 (build 16)
setup:
	cd src/Adobe.AEPAssurance.Android/ && msbuild -t:restore
	cd src/Adobe.AEPAssurance.iOS/ && msbuild -t:restore

msbuild-clean:
	cd src && msbuild -t:clean

clean-folders:
	rm -rf src/Adobe.AEPAssurance.Android/obj
	rm -rf src/Adobe.AEPAssurance.Android/bin/Debug
	rm -rf src/Adobe.AEPAssurance.iOS/obj
	rm -rf src/Adobe.AEPAssurance.iOS/bin/Debug
	rm -rf bin

clean: msbuild-clean clean-folders setup

# Makes AEPAssurance bindings and NuGet package. The binding (.dll) will be available in BindingDirectory/bin/Debug
# The NuGet package is created in the same directory but then moved to src/bin.
release:
	cd src/Adobe.AEPAssurance.Android/ && msbuild -t:pack
	cd src/Adobe.AEPAssurance.iOS/ && msbuild -t:build
	mkdir bin
	cp src/Adobe.AEPAssurance.Android/bin/Debug/*.nupkg ./bin
	cp src/Adobe.AEPAssurance.iOS/bin/Debug/*.nupkg ./bin
