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


AEPASSURANCE_SDK_PATH = ./acp-sdk
AEPASSURANCE_SDK_IOS_ASSURANCE_PATH = ./acp-sdk/iOS/AEPASSURANCE
UNIVERSAL_ASSURANCE_IOS_PATH = ./acp-sdk/universal-assurance-ios
UNIVERSAL_ASSURANCE_IOS_AEPASSURANCE_PATH = ./acp-sdk/universal-assurance-ios/AEPASSURANCE
SIMULATOR_DIRECTORY_NAME = ios-arm64_i386_x86_64-simulator
DEVICE_DIRECTORY_NAME = ios-arm64_armv7_armv7s

download-acp-sdk:
	mkdir -p $(AEPASSURANCE_SDK_PATH)
	git clone --depth 1 https://github.com/Adobe-Marketing-Cloud/acp-sdks.git $(AEPASSURANCE_SDK_PATH)

update-assurance-ios-static-libraries:
	mkdir -p $(UNIVERSAL_ASSURANCE_IOS_PATH)
	mv $(AEPASSURANCE_SDK_IOS_ASSURANCE_PATH) $(UNIVERSAL_ASSURANCE_IOS_PATH)
	lipo -remove arm64 -output $(UNIVERSAL_ASSURANCE_IOS_AEPASSURANCE_PATH)/AEPASSURANCE.xcframework/$(SIMULATOR_DIRECTORY_NAME)/libAEPASSURANCE_iOS_clean.a $(UNIVERSAL_ASSURANCE_IOS_AEPASSURANCE_PATH)/AEPASSURANCE.xcframework/$(SIMULATOR_DIRECTORY_NAME)/libAEPASSURANCE_iOS.a
	lipo -create $(UNIVERSAL_ASSURANCE_IOS_AEPASSURANCE_PATH)/AEPASSURANCE.xcframework/$(DEVICE_DIRECTORY_NAME)/libAEPASSURANCE_iOS.a $(UNIVERSAL_ASSURANCE_IOS_AEPASSURANCE_PATH)/AEPASSURANCE.xcframework/$(SIMULATOR_DIRECTORY_NAME)/libAEPASSURANCE_iOS_clean.a  -output $(UNIVERSAL_ASSURANCE_IOS_PATH)/libAEPASSURANCE_iOS.a
	mv $(UNIVERSAL_ASSURANCE_IOS_PATH)/libAEPASSURANCE_iOS.a ./src/Adobe.AEPASSURANCE.iOS
