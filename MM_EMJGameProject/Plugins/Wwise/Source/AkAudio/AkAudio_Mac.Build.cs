// Copyright (c) 2006-2019 Audiokinetic Inc. / All Rights Reserved
using UnrealBuildTool;
using System;
using System.IO;
using System.Collections.Generic;

public class AkUEPlatform_Mac : AkUEPlatform
{
	private string akLibPath = string.Empty;

	public AkUEPlatform_Mac(ReadOnlyTargetRules in_TargetRules, string in_ThirdPartyFolder) : base(in_TargetRules, in_ThirdPartyFolder)
	{
		akLibPath = Path.Combine(ThirdPartyFolder, AkPlatformLibDir, AkConfigurationDir, "lib");
	}

#if !UE_4_24_OR_LATER
	public override string SanitizeLibName(string in_libName)
	{
		return Path.Combine(akLibPath, "lib" + in_libName + ".a");
	}
#endif

	public override string GetLibraryFullPath(string LibName, string LibPath)
	{
		return Path.Combine(LibPath, "lib" + LibName + ".a");
	}

	public override bool SupportsAkAutobahn { get { return Target.Configuration != UnrealTargetConfiguration.Shipping; } }

	public override bool SupportsCommunication { get { return true; } }

	public override string AkPlatformLibDir { get { return "Mac"; } }

	public override string DynamicLibExtension { get { return "dylib"; } }

	public override List<string> GetAdditionalWwiseLibs()
	{
		return new List<string>
		{
			"AkAACDecoder"
		};
	}
	
	public override List<string> GetPublicSystemLibraries()
	{
		return new List<string>();
	}

	public override List<string> GetPublicDelayLoadDLLs()
	{
		return new List<string>();
	}

	public override List<string> GetPublicDefinitions()
	{
		return new List<string>();
	}

	public override Tuple<string, string> GetAdditionalPropertyForReceipt(string ModuleDirectory)
	{
		return null;
	}

	public override List<string> GetPublicAdditionalFrameworks()
	{
		return new List<string>
		{
			"AudioUnit",
			"AudioToolbox",
			"CoreAudio"
		};
	}
}
