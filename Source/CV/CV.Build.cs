// Fill out your copyright notice in the Description page of Project Settings.

using System.IO;
using UnrealBuildTool;

public class CV : ModuleRules
{
    private string ThirdPartyPath
    {
        get { return Path.GetFullPath(Path.Combine(ModuleDirectory, "../../ThirdParty")); }
    }

    public CV(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

        PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore" });

        PrivateDependencyModuleNames.AddRange(new string[] { "RHI", "RenderCore" });

        // Uncomment if you are using Slate UI
        // PrivateDependencyModuleNames.AddRange(new string[] { "Slate", "SlateCore" });

        // Uncomment if you are using online features
        // PrivateDependencyModuleNames.Add("OnlineSubsystem");

        // To include OnlineSubsystemSteam, add it to the plugins section in your uproject file with the Enabled attribute set to true

        string OpenCVPath = Path.Combine(ThirdPartyPath, "OpenCV");

        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            string OpenCVIncludePath = Path.Combine(OpenCVPath, "Includes");
            string OpenCVLibPath = Path.Combine(OpenCVPath, "Libraries", "Win64");

            PublicIncludePaths.Add(OpenCVIncludePath);
            PublicLibraryPaths.Add(OpenCVLibPath);

            //Add Static Libraries
            PublicAdditionalLibraries.Add("opencv_world346.lib");
            
            //Add Dynamic Libraries
            PublicDelayLoadDLLs.Add("opencv_world346.dll");
            PublicDelayLoadDLLs.Add("opencv_ffmpeg346_64.dll");
        }
    }
}
