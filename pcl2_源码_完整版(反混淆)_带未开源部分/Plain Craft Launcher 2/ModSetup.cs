using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PCL
{
	// Token: 0x0200014E RID: 334
	public class ModSetup
	{
		// Token: 0x06000CBA RID: 3258 RVA: 0x0006662C File Offset: 0x0006482C
		public ModSetup()
		{
			this.broadcasterUtils = new Dictionary<string, ModSetup.SetupEntry>
			{
				{
					"Identify",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, false)
				},
				{
					"HintDownloadThread",
					new ModSetup.SetupEntry(false, ModSetup.SetupSource.Registry, false)
				},
				{
					"HintNotice",
					new ModSetup.SetupEntry(0, ModSetup.SetupSource.Registry, false)
				},
				{
					"HintDownload",
					new ModSetup.SetupEntry(0, ModSetup.SetupSource.Registry, false)
				},
				{
					"HintFeedbackDelete",
					new ModSetup.SetupEntry(false, ModSetup.SetupSource.Registry, false)
				},
				{
					"HintFeedback",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, false)
				},
				{
					"HintModDisable",
					new ModSetup.SetupEntry(false, ModSetup.SetupSource.Registry, false)
				},
				{
					"HintInstallBack",
					new ModSetup.SetupEntry(false, ModSetup.SetupSource.Registry, false)
				},
				{
					"HintInstallFabricApi",
					new ModSetup.SetupEntry(false, ModSetup.SetupSource.Registry, false)
				},
				{
					"HintHide",
					new ModSetup.SetupEntry(false, ModSetup.SetupSource.Registry, false)
				},
				{
					"HintHandInstall",
					new ModSetup.SetupEntry(false, ModSetup.SetupSource.Registry, false)
				},
				{
					"TestSetupReader",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"SystemEula",
					new ModSetup.SetupEntry(false, ModSetup.SetupSource.Registry, false)
				},
				{
					"SystemCount",
					new ModSetup.SetupEntry(0, ModSetup.SetupSource.Registry, true)
				},
				{
					"SystemLaunchCount",
					new ModSetup.SetupEntry(0, ModSetup.SetupSource.Registry, true)
				},
				{
					"SystemLastVersionReg",
					new ModSetup.SetupEntry(0, ModSetup.SetupSource.Registry, true)
				},
				{
					"SystemHighestBetaVersionReg",
					new ModSetup.SetupEntry(0, ModSetup.SetupSource.Registry, true)
				},
				{
					"SystemHighestAlphaVersionReg",
					new ModSetup.SetupEntry(0, ModSetup.SetupSource.Registry, true)
				},
				{
					"SystemSetupVersionReg",
					new ModSetup.SetupEntry(1, ModSetup.SetupSource.Registry, false)
				},
				{
					"SystemSetupVersionIni",
					new ModSetup.SetupEntry(1, 0, false)
				},
				{
					"SystemHelpVersion",
					new ModSetup.SetupEntry(0, ModSetup.SetupSource.Registry, false)
				},
				{
					"SystemDebugMode",
					new ModSetup.SetupEntry(false, ModSetup.SetupSource.Registry, false)
				},
				{
					"SystemDebugAnim",
					new ModSetup.SetupEntry(9, ModSetup.SetupSource.Registry, false)
				},
				{
					"SystemDebugDelay",
					new ModSetup.SetupEntry(false, ModSetup.SetupSource.Registry, false)
				},
				{
					"SystemDebugSkipCopy",
					new ModSetup.SetupEntry(false, ModSetup.SetupSource.Registry, false)
				},
				{
					"SystemSystemCache",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, false)
				},
				{
					"SystemSystemUpdate",
					new ModSetup.SetupEntry(0, 0, false)
				},
				{
					"SystemSystemActivity",
					new ModSetup.SetupEntry(0, 0, false)
				},
				{
					"CacheMsOAuthRefresh",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheMsAccess",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheMsUuid",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheMsName",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheMojangAccess",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheMojangClient",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheMojangUuid",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheMojangName",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheMojangUsername",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheMojangPass",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheNideAccess",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheNideClient",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheNideUuid",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheNideName",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheNideUsername",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheNidePass",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheNideServer",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheAuthAccess",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheAuthClient",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheAuthUuid",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheAuthName",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheAuthUsername",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheAuthPass",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheAuthServerServer",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheAuthServerName",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheAuthServerRegister",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"CacheDownloadFolder",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, false)
				},
				{
					"CacheJavaListVersion",
					new ModSetup.SetupEntry(0, ModSetup.SetupSource.Registry, false)
				},
				{
					"LoginRemember",
					new ModSetup.SetupEntry(true, ModSetup.SetupSource.Registry, true)
				},
				{
					"LoginLegacyName",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"LoginMojangEmail",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"LoginMojangPass",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"LoginNideEmail",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"LoginNidePass",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"LoginAuthEmail",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"LoginAuthPass",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"LoginType",
					new ModSetup.SetupEntry(ModLaunch.McLoginType.Legacy, ModSetup.SetupSource.Registry, false)
				},
				{
					"LoginPageType",
					new ModSetup.SetupEntry(0, 0, false)
				},
				{
					"LaunchSkinID",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, false)
				},
				{
					"LaunchSkinType",
					new ModSetup.SetupEntry(0, ModSetup.SetupSource.Registry, false)
				},
				{
					"LaunchSkinSlim",
					new ModSetup.SetupEntry(false, ModSetup.SetupSource.Registry, false)
				},
				{
					"LaunchVersionSelect",
					new ModSetup.SetupEntry("", 0, false)
				},
				{
					"LaunchFolderSelect",
					new ModSetup.SetupEntry("", 0, false)
				},
				{
					"LaunchFolders",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, false)
				},
				{
					"LaunchArgumentTitle",
					new ModSetup.SetupEntry("", 0, false)
				},
				{
					"LaunchArgumentInfo",
					new ModSetup.SetupEntry("PCL2", 0, false)
				},
				{
					"LaunchArgumentJavaSelect",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, false)
				},
				{
					"LaunchArgumentJavaAll",
					new ModSetup.SetupEntry("[]", ModSetup.SetupSource.Registry, false)
				},
				{
					"LaunchArgumentIndie",
					new ModSetup.SetupEntry(0, 0, false)
				},
				{
					"LaunchArgumentVisible",
					new ModSetup.SetupEntry(5, ModSetup.SetupSource.Registry, false)
				},
				{
					"LaunchArgumentPriority",
					new ModSetup.SetupEntry(1, ModSetup.SetupSource.Registry, false)
				},
				{
					"LaunchArgumentWindowWidth",
					new ModSetup.SetupEntry(0x356, 0, false)
				},
				{
					"LaunchArgumentWindowHeight",
					new ModSetup.SetupEntry(0x1E0, 0, false)
				},
				{
					"LaunchArgumentWindowType",
					new ModSetup.SetupEntry(1, 0, false)
				},
				{
					"LaunchAdvanceJvm",
					new ModSetup.SetupEntry("-XX:+UseG1GC -XX:-UseAdaptiveSizePolicy -XX:-OmitStackTraceInFastThrow -Dfml.ignoreInvalidMinecraftCertificates=True -Dfml.ignorePatchDiscrepancies=True", 0, false)
				},
				{
					"LaunchAdvanceGame",
					new ModSetup.SetupEntry("", 0, false)
				},
				{
					"LaunchAdvanceAssets",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"LaunchRamType",
					new ModSetup.SetupEntry(0, 0, false)
				},
				{
					"LaunchRamCustom",
					new ModSetup.SetupEntry(0xF, 0, false)
				},
				{
					"LinkAuto",
					new ModSetup.SetupEntry(false, ModSetup.SetupSource.Registry, false)
				},
				{
					"LinkName",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, false)
				},
				{
					"LinkIoiVersion",
					new ModSetup.SetupEntry(0, ModSetup.SetupSource.Registry, true)
				},
				{
					"ToolHelpChinese",
					new ModSetup.SetupEntry(true, ModSetup.SetupSource.Registry, false)
				},
				{
					"ToolDownloadThread",
					new ModSetup.SetupEntry(0x3F, ModSetup.SetupSource.Registry, false)
				},
				{
					"ToolDownloadSpeed",
					new ModSetup.SetupEntry(0x2A, ModSetup.SetupSource.Registry, false)
				},
				{
					"ToolDownloadVersion",
					new ModSetup.SetupEntry(0, ModSetup.SetupSource.Registry, false)
				},
				{
					"ToolUpdateAlpha",
					new ModSetup.SetupEntry(0, ModSetup.SetupSource.Registry, true)
				},
				{
					"ToolUpdateRelease",
					new ModSetup.SetupEntry(false, ModSetup.SetupSource.Registry, false)
				},
				{
					"ToolUpdateSnapshot",
					new ModSetup.SetupEntry(false, ModSetup.SetupSource.Registry, false)
				},
				{
					"ToolUpdateReleaseLast",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, false)
				},
				{
					"ToolUpdateSnapshotLast",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, false)
				},
				{
					"UiLauncherTransparent",
					new ModSetup.SetupEntry(0x258, 0, false)
				},
				{
					"UiLauncherHue",
					new ModSetup.SetupEntry(0xB4, 0, false)
				},
				{
					"UiLauncherSat",
					new ModSetup.SetupEntry(0x50, 0, false)
				},
				{
					"UiLauncherDelta",
					new ModSetup.SetupEntry(0x5A, 0, false)
				},
				{
					"UiLauncherLight",
					new ModSetup.SetupEntry(0x14, 0, false)
				},
				{
					"UiLauncherTheme",
					new ModSetup.SetupEntry(0, 0, false)
				},
				{
					"UiLauncherThemeGold",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Registry, true)
				},
				{
					"UiLauncherThemeHide",
					new ModSetup.SetupEntry("0|1|2|3|4", ModSetup.SetupSource.Registry, true)
				},
				{
					"UiLauncherThemeHide2",
					new ModSetup.SetupEntry("0|1|2|3|4", ModSetup.SetupSource.Registry, true)
				},
				{
					"UiLauncherLogo",
					new ModSetup.SetupEntry(true, 0, false)
				},
				{
					"UiLauncherEmail",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"UiBackgroundColorful",
					new ModSetup.SetupEntry(true, 0, false)
				},
				{
					"UiBackgroundOpacity",
					new ModSetup.SetupEntry(0x3E8, 0, false)
				},
				{
					"UiBackgroundBlur",
					new ModSetup.SetupEntry(0, 0, false)
				},
				{
					"UiBackgroundSuit",
					new ModSetup.SetupEntry(0, 0, false)
				},
				{
					"UiCustomType",
					new ModSetup.SetupEntry(0, 0, false)
				},
				{
					"UiCustomNet",
					new ModSetup.SetupEntry("", 0, false)
				},
				{
					"UiLogoType",
					new ModSetup.SetupEntry(1, 0, false)
				},
				{
					"UiLogoText",
					new ModSetup.SetupEntry("", 0, false)
				},
				{
					"UiLogoLeft",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"UiMusicVolume",
					new ModSetup.SetupEntry(0x1F4, 0, false)
				},
				{
					"UiMusicStop",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"UiMusicStart",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"UiMusicAuto",
					new ModSetup.SetupEntry(true, 0, false)
				},
				{
					"UiHiddenPageDownload",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"UiHiddenPageLink",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"UiHiddenPageSetup",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"UiHiddenPageOther",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"UiHiddenFunctionSelect",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"UiHiddenFunctionHidden",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"UiHiddenSetupLaunch",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"UiHiddenSetupUi",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"UiHiddenSetupTool",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"UiHiddenSetupSystem",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"UiHiddenOtherHelp",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"UiHiddenOtherFeedback",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"UiHiddenOtherAbout",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"UiHiddenOtherTest",
					new ModSetup.SetupEntry(false, 0, false)
				},
				{
					"VersionAdvanceJvm",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Version, false)
				},
				{
					"VersionAdvanceGame",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Version, false)
				},
				{
					"VersionAdvanceAssets",
					new ModSetup.SetupEntry(0, ModSetup.SetupSource.Version, false)
				},
				{
					"VersionRamType",
					new ModSetup.SetupEntry(2, ModSetup.SetupSource.Version, false)
				},
				{
					"VersionRamCustom",
					new ModSetup.SetupEntry(0xF, ModSetup.SetupSource.Version, false)
				},
				{
					"VersionArgumentTitle",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Version, false)
				},
				{
					"VersionArgumentInfo",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Version, false)
				},
				{
					"VersionArgumentIndie",
					new ModSetup.SetupEntry(-1, ModSetup.SetupSource.Version, false)
				},
				{
					"VersionArgumentJavaSelect",
					new ModSetup.SetupEntry("使用全局设置", ModSetup.SetupSource.Version, false)
				},
				{
					"VersionServerEnter",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Version, false)
				},
				{
					"VersionServerLogin",
					new ModSetup.SetupEntry(0, ModSetup.SetupSource.Version, false)
				},
				{
					"VersionServerNide",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Version, false)
				},
				{
					"VersionServerAuthRegister",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Version, false)
				},
				{
					"VersionServerAuthName",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Version, false)
				},
				{
					"VersionServerAuthServer",
					new ModSetup.SetupEntry("", ModSetup.SetupSource.Version, false)
				}
			};
		}

		// Token: 0x06000CBB RID: 3259 RVA: 0x00008FC5 File Offset: 0x000071C5
		public void Set(string Key, object Value, bool ForceReload = false, ModMinecraft.McVersion Version = null)
		{
			this.Set(Key, RuntimeHelpers.GetObjectValue(Value), this.broadcasterUtils[Key], ForceReload, Version);
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x00067A58 File Offset: 0x00065C58
		private void Set(string Key, object Value, ModSetup.SetupEntry E, bool ForceReload, ModMinecraft.McVersion Version)
		{
			try
			{
				Value = RuntimeHelpers.GetObjectValue(Conversion.CTypeDynamic(RuntimeHelpers.GetObjectValue(Value), (Type)E.Type));
				if (E._SerializerMapper == 2)
				{
					if (Operators.ConditionalCompareObjectEqual(E.Value, Value, true) && !ForceReload)
					{
						return;
					}
				}
				else if (E.Source != ModSetup.SetupSource.Version)
				{
					E._SerializerMapper = 2;
				}
				E.Value = RuntimeHelpers.GetObjectValue(Value);
				if (E._ThreadMapper)
				{
					try
					{
						if (Value == null)
						{
							Value = "";
						}
						Value = ModBase.ValidateIterator(Conversions.ToString(Value), "PCL" + ModBase.ruleRule);
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "加密设置失败：" + Key, ModBase.LogLevel.Developer, "出现错误");
					}
				}
				switch (E.Source)
				{
				case ModSetup.SetupSource.Normal:
					ModBase.WriteIni("Setup", Key, Conversions.ToString(Value));
					break;
				case ModSetup.SetupSource.Registry:
					ModBase.WriteReg(Key, Conversions.ToString(Value), false);
					break;
				case ModSetup.SetupSource.Version:
					if (Version == null)
					{
						throw new Exception("更改版本设置 " + Key + " 时未提供目标版本");
					}
					ModBase.WriteIni(Version.Path + "PCL\\Setup.ini", Key, Conversions.ToString(Value));
					break;
				}
				MethodInfo method = typeof(ModSetup).GetMethod(Key);
				if (method != null)
				{
					method.Invoke(this, new object[]
					{
						Value
					});
				}
			}
			catch (Exception ex2)
			{
				ModBase.Log(ex2, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("设置设置项时出错（" + Key + ", ", Value), "）")), ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x00008FE3 File Offset: 0x000071E3
		public object Load(string Key, bool ForceReload = false, ModMinecraft.McVersion Version = null)
		{
			return this.Load(Key, this.broadcasterUtils[Key], ForceReload, Version);
		}

		// Token: 0x06000CBE RID: 3262 RVA: 0x00067C24 File Offset: 0x00065E24
		private object Load(string Key, ModSetup.SetupEntry E, bool ForceReload, ModMinecraft.McVersion Version)
		{
			object value;
			if (E._SerializerMapper == 2 && !ForceReload)
			{
				value = E.Value;
			}
			else
			{
				this.Read(Key, ref E, Version);
				if (E.Source != ModSetup.SetupSource.Version)
				{
					E._SerializerMapper = 2;
				}
				MethodInfo method = typeof(ModSetup).GetMethod(Key);
				if (method != null)
				{
					method.Invoke(this, new object[]
					{
						E.Value
					});
				}
				value = E.Value;
			}
			return value;
		}

		// Token: 0x06000CBF RID: 3263 RVA: 0x00008FFA File Offset: 0x000071FA
		public object Get(string Key, ModMinecraft.McVersion Version = null)
		{
			if (!this.broadcasterUtils.ContainsKey(Key))
			{
				throw new KeyNotFoundException("未找到设置项：" + Key)
				{
					Source = Key
				};
			}
			return this.Get(Key, this.broadcasterUtils[Key], Version);
		}

		// Token: 0x06000CC0 RID: 3264 RVA: 0x00067C94 File Offset: 0x00065E94
		private object Get(string Key, ModSetup.SetupEntry E, ModMinecraft.McVersion Version)
		{
			string text = this.ForceValue(Key);
			if (text != null)
			{
				E.Value = RuntimeHelpers.GetObjectValue(Conversion.CTypeDynamic(text, (Type)E.Type));
				E._SerializerMapper = 1;
			}
			if (E._SerializerMapper == 0)
			{
				this.Read(Key, ref E, Version);
				if (E.Source != ModSetup.SetupSource.Version)
				{
					E._SerializerMapper = 1;
				}
			}
			return E.Value;
		}

		// Token: 0x06000CC1 RID: 3265 RVA: 0x00067CF8 File Offset: 0x00065EF8
		public void Reset(string Key, bool ForceReload = false, ModMinecraft.McVersion Version = null)
		{
			ModSetup.SetupEntry setupEntry = this.broadcasterUtils[Key];
			this.Set(Key, RuntimeHelpers.GetObjectValue(setupEntry._ManagerMapper), setupEntry, ForceReload, Version);
		}

		// Token: 0x06000CC2 RID: 3266 RVA: 0x00067D28 File Offset: 0x00065F28
		private void Read(string Key, ref ModSetup.SetupEntry E, ModMinecraft.McVersion Version)
		{
			try
			{
				if (E._SerializerMapper == 0)
				{
					ModSetup.SetupSource source = E.Source;
					string text;
					if (source != ModSetup.SetupSource.Normal)
					{
						if (source != ModSetup.SetupSource.Registry)
						{
							if (Version == null)
							{
								throw new Exception("读取版本设置 " + Key + " 时未提供目标版本");
							}
							text = ModBase.ReadIni(Version.Path + "PCL\\Setup.ini", Key, Conversions.ToString(E.m_ItemMapper));
						}
						else
						{
							text = ModBase.ReadReg(Key, Conversions.ToString(E.m_ItemMapper));
						}
					}
					else
					{
						text = ModBase.ReadIni("Setup", Key, Conversions.ToString(E.m_ItemMapper));
					}
					if (E._ThreadMapper)
					{
						if (text.Equals(RuntimeHelpers.GetObjectValue(E.m_ItemMapper)))
						{
							text = Conversions.ToString(E._ManagerMapper);
						}
						else
						{
							try
							{
								text = ModBase.CancelIterator(text, "PCL" + ModBase.ruleRule);
							}
							catch (Exception ex)
							{
								ModBase.Log(ex, "解密设置失败：" + Key, ModBase.LogLevel.Developer, "出现错误");
								text = Conversions.ToString(E._ManagerMapper);
								ModBase._BaseRule.Set(Key, RuntimeHelpers.GetObjectValue(E._ManagerMapper), true, null);
							}
						}
					}
					E.Value = RuntimeHelpers.GetObjectValue(Conversion.CTypeDynamic(text, (Type)E.Type));
				}
			}
			catch (Exception ex2)
			{
				ModBase.Log(ex2, "读取设置失败：" + Key, ModBase.LogLevel.Hint, "出现错误");
				E.Value = RuntimeHelpers.GetObjectValue(Conversion.CTypeDynamic(RuntimeHelpers.GetObjectValue(E._ManagerMapper), (Type)E.Type));
			}
		}

		// Token: 0x06000CC3 RID: 3267 RVA: 0x00009036 File Offset: 0x00007236
		private string ForceValue(string Key)
		{
			return null;
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x00067EF4 File Offset: 0x000660F4
		public void LaunchVersionSelect(string Value)
		{
			ModBase.Log("[Setup] 当前选择的 Minecraft 版本：" + Value, ModBase.LogLevel.Normal, "出现错误");
			ModBase.WriteIni(ModMinecraft.m_ResolverIterator + "PCL.ini", "Version", Information.IsNothing(ModMinecraft.ValidateContainer()) ? "" : ModMinecraft.ValidateContainer().Name);
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x00067F50 File Offset: 0x00066150
		public void LaunchFolderSelect(string Value)
		{
			ModBase.Log("[Setup] 当前选择的 Minecraft 文件夹：" + Value.ToString().Replace("$", ModBase.Path), ModBase.LogLevel.Normal, "出现错误");
			ModMinecraft.m_ResolverIterator = Value.ToString().Replace("$", ModBase.Path);
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x00009039 File Offset: 0x00007239
		public void LaunchRamType(int Type)
		{
			if (ModMain.m_AuthenticationFilter != null)
			{
				ModMain.m_AuthenticationFilter.RamType(Type);
			}
		}

		// Token: 0x06000CC7 RID: 3271 RVA: 0x00067FA4 File Offset: 0x000661A4
		public Size GetLaunchArgumentWindowSize()
		{
			object left = ModBase._BaseRule.Get("LaunchArgumentWindowType", null);
			Size $VB$Local_Result;
			if (Conversions.ToBoolean(Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 1, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 4, true))))
			{
				$VB$Local_Result = new Size(854.0, 480.0);
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 2, true))
			{
				Size Result;
				ModBase.RunInUiWait(delegate()
				{
					Result = new Size(Math.Round(ModBase.GetPixelSize(ModMain.m_GetterFilter.PanForm.ActualWidth)), Math.Round(ModBase.GetPixelSize(ModMain.m_GetterFilter.PanForm.ActualHeight) - 38.0));
				});
				$VB$Local_Result = Result;
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 3, true))
			{
				$VB$Local_Result = new Size(Conversions.ToDouble(ModBase._BaseRule.Get("LaunchArgumentWindowWidth", null)), Conversions.ToDouble(ModBase._BaseRule.Get("LaunchArgumentWindowHeight", null)));
			}
			else
			{
				$VB$Local_Result = new Size(100.0, 100.0);
			}
			return $VB$Local_Result;
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x0000904D File Offset: 0x0000724D
		public void LaunchSkinType(int Value)
		{
			ModBase.RunInUi(delegate()
			{
				if (!Information.IsNothing(ModMain.m_AuthenticationFilter))
				{
					switch (Value)
					{
					case 0:
					case 1:
					case 2:
						ModMain.m_AuthenticationFilter.PanSkinID.Visibility = Visibility.Collapsed;
						ModMain.m_AuthenticationFilter.PanSkinChange.Visibility = Visibility.Collapsed;
						break;
					case 3:
						ModMain.m_AuthenticationFilter.PanSkinID.Visibility = Visibility.Visible;
						ModMain.m_AuthenticationFilter.PanSkinChange.Visibility = Visibility.Collapsed;
						break;
					case 4:
						ModMain.m_AuthenticationFilter.PanSkinID.Visibility = Visibility.Collapsed;
						ModMain.m_AuthenticationFilter.PanSkinChange.Visibility = Visibility.Visible;
						break;
					}
					ModMain.m_AuthenticationFilter.CardSkin.TriggerForceResize();
				}
				PageLaunchLeft.m_InterpreterExpression.Start(null, false);
			}, false);
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x0000906C File Offset: 0x0000726C
		public void LaunchSkinID(string Value)
		{
			PageLaunchLeft.m_InterpreterExpression.Start(null, false);
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x0000907A File Offset: 0x0000727A
		public void ToolDownloadThread(int Value)
		{
			ModNet.m_ClassModel = checked(Value + 1);
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x000680B4 File Offset: 0x000662B4
		public void ToolDownloadSpeed(int Value)
		{
			checked
			{
				if (Value <= 0xE)
				{
					ModNet._ConfigModel = (long)Math.Round(unchecked((double)(checked(Value + 1)) * 0.1 * 1024.0 * 1024.0));
					return;
				}
				if (Value <= 0x1F)
				{
					ModNet._ConfigModel = (long)Math.Round(unchecked((double)(checked(Value - 0xB)) * 0.5 * 1024.0 * 1024.0));
					return;
				}
				if (Value <= 0x29)
				{
					ModNet._ConfigModel = unchecked((long)(checked((Value - 0x15) * 0x400))) * 0x400L;
					return;
				}
				ModNet._ConfigModel = -1L;
			}
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x00009084 File Offset: 0x00007284
		public void UiLauncherTransparent(int Value)
		{
			ModMain.m_GetterFilter.Opacity = (double)Value / 1000.0 + 0.4;
		}

		// Token: 0x06000CCD RID: 3277 RVA: 0x000090A6 File Offset: 0x000072A6
		public void UiLauncherTheme(int Value)
		{
			ModMain.CompareIterator(Value);
		}

		// Token: 0x06000CCE RID: 3278 RVA: 0x000090AE File Offset: 0x000072AE
		public void UiBackgroundColorful(bool Value)
		{
			ModMain.CompareIterator(-1);
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x000090B6 File Offset: 0x000072B6
		public void UiBackgroundOpacity(int Value)
		{
			ModMain.m_GetterFilter.ImgBack.Opacity = (double)Value / 1000.0;
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x00068158 File Offset: 0x00066358
		public void UiBackgroundBlur(int Value)
		{
			checked
			{
				if (Value == 0)
				{
					ModMain.m_GetterFilter.ImgBack.Effect = null;
				}
				else
				{
					ModMain.m_GetterFilter.ImgBack.Effect = new BlurEffect
					{
						Radius = (double)(Value + 1)
					};
				}
				ModMain.m_GetterFilter.ImgBack.Margin = new Thickness((double)(0 - (Value + 1)) / 1.8);
			}
		}

		// Token: 0x06000CD1 RID: 3281 RVA: 0x000681BC File Offset: 0x000663BC
		public void UiBackgroundSuit(int Value)
		{
			if (!Information.IsNothing(ModMain.m_GetterFilter.ImgBack.Background))
			{
				double width = ((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).ImageSource.Width;
				double height = ((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).ImageSource.Height;
				if (Value == 0)
				{
					if (width <= ModMain.m_GetterFilter.PanMain.ActualWidth - 10.0 && height <= ModMain.m_GetterFilter.PanMain.ActualHeight - 10.0)
					{
						if (width < ModMain.m_GetterFilter.PanMain.ActualWidth / 3.0 && height < ModMain.m_GetterFilter.PanMain.ActualHeight / 3.0)
						{
							Value = 4;
						}
						else
						{
							Value = 1;
						}
					}
					else
					{
						Value = 2;
					}
				}
				((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).TileMode = TileMode.None;
				((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).Viewport = new Rect(0.0, 0.0, 1.0, 1.0);
				((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).ViewportUnits = BrushMappingMode.RelativeToBoundingBox;
				switch (Value)
				{
				case 1:
					ModMain.m_GetterFilter.ImgBack.HorizontalAlignment = HorizontalAlignment.Center;
					ModMain.m_GetterFilter.ImgBack.VerticalAlignment = VerticalAlignment.Center;
					((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).Stretch = Stretch.None;
					ModMain.m_GetterFilter.ImgBack.Width = ((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).ImageSource.Width;
					ModMain.m_GetterFilter.ImgBack.Height = ((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).ImageSource.Height;
					return;
				case 2:
					ModMain.m_GetterFilter.ImgBack.HorizontalAlignment = HorizontalAlignment.Stretch;
					ModMain.m_GetterFilter.ImgBack.VerticalAlignment = VerticalAlignment.Stretch;
					((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).Stretch = Stretch.UniformToFill;
					ModMain.m_GetterFilter.ImgBack.Width = double.NaN;
					ModMain.m_GetterFilter.ImgBack.Height = double.NaN;
					return;
				case 3:
					ModMain.m_GetterFilter.ImgBack.HorizontalAlignment = HorizontalAlignment.Stretch;
					ModMain.m_GetterFilter.ImgBack.VerticalAlignment = VerticalAlignment.Stretch;
					((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).Stretch = Stretch.Fill;
					ModMain.m_GetterFilter.ImgBack.Width = double.NaN;
					ModMain.m_GetterFilter.ImgBack.Height = double.NaN;
					return;
				case 4:
					ModMain.m_GetterFilter.ImgBack.HorizontalAlignment = HorizontalAlignment.Stretch;
					ModMain.m_GetterFilter.ImgBack.VerticalAlignment = VerticalAlignment.Stretch;
					((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).Stretch = Stretch.None;
					((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).TileMode = TileMode.Tile;
					((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).Viewport = new Rect(0.0, 0.0, ((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).ImageSource.Width, ((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).ImageSource.Height);
					((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).ViewportUnits = BrushMappingMode.Absolute;
					ModMain.m_GetterFilter.ImgBack.Width = double.NaN;
					ModMain.m_GetterFilter.ImgBack.Height = double.NaN;
					return;
				case 5:
					ModMain.m_GetterFilter.ImgBack.HorizontalAlignment = HorizontalAlignment.Left;
					ModMain.m_GetterFilter.ImgBack.VerticalAlignment = VerticalAlignment.Top;
					((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).Stretch = Stretch.None;
					ModMain.m_GetterFilter.ImgBack.Width = ((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).ImageSource.Width;
					ModMain.m_GetterFilter.ImgBack.Height = ((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).ImageSource.Height;
					return;
				case 6:
					ModMain.m_GetterFilter.ImgBack.HorizontalAlignment = HorizontalAlignment.Right;
					ModMain.m_GetterFilter.ImgBack.VerticalAlignment = VerticalAlignment.Top;
					((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).Stretch = Stretch.None;
					ModMain.m_GetterFilter.ImgBack.Width = ((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).ImageSource.Width;
					ModMain.m_GetterFilter.ImgBack.Height = ((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).ImageSource.Height;
					return;
				case 7:
					ModMain.m_GetterFilter.ImgBack.HorizontalAlignment = HorizontalAlignment.Left;
					ModMain.m_GetterFilter.ImgBack.VerticalAlignment = VerticalAlignment.Bottom;
					((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).Stretch = Stretch.None;
					ModMain.m_GetterFilter.ImgBack.Width = ((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).ImageSource.Width;
					ModMain.m_GetterFilter.ImgBack.Height = ((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).ImageSource.Height;
					return;
				case 8:
					ModMain.m_GetterFilter.ImgBack.HorizontalAlignment = HorizontalAlignment.Right;
					ModMain.m_GetterFilter.ImgBack.VerticalAlignment = VerticalAlignment.Bottom;
					((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).Stretch = Stretch.None;
					ModMain.m_GetterFilter.ImgBack.Width = ((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).ImageSource.Width;
					ModMain.m_GetterFilter.ImgBack.Height = ((ImageBrush)ModMain.m_GetterFilter.ImgBack.Background).ImageSource.Height;
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x0006880C File Offset: 0x00066A0C
		public void UiCustomType(int Value)
		{
			ModMain.m_CandidateFilter.customerExpression = true;
			if (ModMain.processFilter != null)
			{
				switch (Value)
				{
				case 0:
					ModMain.processFilter.PanCustomLocal.Visibility = Visibility.Collapsed;
					ModMain.processFilter.PanCustomNet.Visibility = Visibility.Collapsed;
					break;
				case 1:
					ModMain.processFilter.PanCustomLocal.Visibility = Visibility.Visible;
					ModMain.processFilter.PanCustomNet.Visibility = Visibility.Collapsed;
					break;
				case 2:
					ModMain.processFilter.PanCustomLocal.Visibility = Visibility.Collapsed;
					ModMain.processFilter.PanCustomNet.Visibility = Visibility.Visible;
					break;
				}
				ModMain.processFilter.CardCustom.TriggerForceResize();
			}
		}

		// Token: 0x06000CD3 RID: 3283 RVA: 0x000090D3 File Offset: 0x000072D3
		public void UiCustomNet(string Value)
		{
			ModMain.m_CandidateFilter.customerExpression = true;
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x000688B8 File Offset: 0x00066AB8
		public void UiLogoType(int Value)
		{
			switch (Value)
			{
			case 0:
				ModMain.m_GetterFilter.ShapeTitleLogo.Visibility = Visibility.Collapsed;
				ModMain.m_GetterFilter.LabTitleLogo.Visibility = Visibility.Collapsed;
				ModMain.m_GetterFilter.ImageTitleLogo.Visibility = Visibility.Collapsed;
				if (!Information.IsNothing(ModMain.processFilter))
				{
					ModMain.processFilter.CheckLogoLeft.Visibility = Visibility.Visible;
					ModMain.processFilter.PanLogoText.Visibility = Visibility.Collapsed;
					ModMain.processFilter.PanLogoChange.Visibility = Visibility.Collapsed;
				}
				break;
			case 1:
				ModMain.m_GetterFilter.ShapeTitleLogo.Visibility = Visibility.Visible;
				ModMain.m_GetterFilter.LabTitleLogo.Visibility = Visibility.Collapsed;
				ModMain.m_GetterFilter.ImageTitleLogo.Visibility = Visibility.Collapsed;
				if (!Information.IsNothing(ModMain.processFilter))
				{
					ModMain.processFilter.CheckLogoLeft.Visibility = Visibility.Collapsed;
					ModMain.processFilter.PanLogoText.Visibility = Visibility.Collapsed;
					ModMain.processFilter.PanLogoChange.Visibility = Visibility.Collapsed;
				}
				break;
			case 2:
				ModMain.m_GetterFilter.ShapeTitleLogo.Visibility = Visibility.Collapsed;
				ModMain.m_GetterFilter.LabTitleLogo.Visibility = Visibility.Visible;
				ModMain.m_GetterFilter.ImageTitleLogo.Visibility = Visibility.Collapsed;
				if (!Information.IsNothing(ModMain.processFilter))
				{
					ModMain.processFilter.CheckLogoLeft.Visibility = Visibility.Collapsed;
					ModMain.processFilter.PanLogoText.Visibility = Visibility.Visible;
					ModMain.processFilter.PanLogoChange.Visibility = Visibility.Collapsed;
				}
				ModBase._BaseRule.Load("UiLogoText", true, null);
				break;
			case 3:
				ModMain.m_GetterFilter.ShapeTitleLogo.Visibility = Visibility.Collapsed;
				ModMain.m_GetterFilter.LabTitleLogo.Visibility = Visibility.Collapsed;
				ModMain.m_GetterFilter.ImageTitleLogo.Visibility = Visibility.Visible;
				if (!Information.IsNothing(ModMain.processFilter))
				{
					ModMain.processFilter.CheckLogoLeft.Visibility = Visibility.Collapsed;
					ModMain.processFilter.PanLogoText.Visibility = Visibility.Collapsed;
					ModMain.processFilter.PanLogoChange.Visibility = Visibility.Visible;
				}
				try
				{
					ModMain.m_GetterFilter.ImageTitleLogo.Source = new ModBitmap.MyBitmap(ModBase.Path + "PCL\\Logo.png");
				}
				catch (Exception ex)
				{
					ModMain.m_GetterFilter.ImageTitleLogo.Source = null;
					ModBase.Log(ex, "显示标题栏图片失败", ModBase.LogLevel.Msgbox, "出现错误");
				}
				break;
			}
			ModBase._BaseRule.Load("UiLogoLeft", true, null);
			if (!Information.IsNothing(ModMain.processFilter))
			{
				ModMain.processFilter.CardLogo.TriggerForceResize();
			}
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x000090E0 File Offset: 0x000072E0
		public void UiLogoText(string Value)
		{
			ModMain.m_GetterFilter.LabTitleLogo.Text = Value;
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x00068B50 File Offset: 0x00066D50
		public void UiLogoLeft(bool Value)
		{
			ModMain.m_GetterFilter.PanTitleMain.ColumnDefinitions[0].Width = new GridLength((double)((!Value || !Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("UiLogoType", null), 0, true)) ? 1 : 0), GridUnitType.Star);
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x000090F2 File Offset: 0x000072F2
		public void UiHiddenPageLink(bool Value)
		{
			PageSetupUI.HiddenRefresh();
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x000090F2 File Offset: 0x000072F2
		public void UiHiddenPageDownload(bool Value)
		{
			PageSetupUI.HiddenRefresh();
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x000090F2 File Offset: 0x000072F2
		public void UiHiddenPageSetup(bool Value)
		{
			PageSetupUI.HiddenRefresh();
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x000090F2 File Offset: 0x000072F2
		public void UiHiddenPageOther(bool Value)
		{
			PageSetupUI.HiddenRefresh();
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x000090F2 File Offset: 0x000072F2
		public void UiHiddenFunctionSelect(bool Value)
		{
			PageSetupUI.HiddenRefresh();
		}

		// Token: 0x06000CDC RID: 3292 RVA: 0x000090F2 File Offset: 0x000072F2
		public void UiHiddenFunctionHidden(bool Value)
		{
			PageSetupUI.HiddenRefresh();
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x000090F2 File Offset: 0x000072F2
		public void UiHiddenSetupLaunch(bool Value)
		{
			PageSetupUI.HiddenRefresh();
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x000090F2 File Offset: 0x000072F2
		public void UiHiddenSetupUi(bool Value)
		{
			PageSetupUI.HiddenRefresh();
		}

		// Token: 0x06000CDF RID: 3295 RVA: 0x000090F2 File Offset: 0x000072F2
		public void UiHiddenSetupTool(bool Value)
		{
			PageSetupUI.HiddenRefresh();
		}

		// Token: 0x06000CE0 RID: 3296 RVA: 0x000090F2 File Offset: 0x000072F2
		public void UiHiddenSetupSystem(bool Value)
		{
			PageSetupUI.HiddenRefresh();
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x000090F2 File Offset: 0x000072F2
		public void UiHiddenOtherHelp(bool Value)
		{
			PageSetupUI.HiddenRefresh();
		}

		// Token: 0x06000CE2 RID: 3298 RVA: 0x000090F2 File Offset: 0x000072F2
		public void UiHiddenOtherFeedback(bool Value)
		{
			PageSetupUI.HiddenRefresh();
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x000090F2 File Offset: 0x000072F2
		public void UiHiddenOtherAbout(bool Value)
		{
			PageSetupUI.HiddenRefresh();
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x000090F2 File Offset: 0x000072F2
		public void UiHiddenOtherTest(bool Value)
		{
			PageSetupUI.HiddenRefresh();
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x000090F9 File Offset: 0x000072F9
		public void SystemDebugMode(bool Value)
		{
			ModBase.errorRule = Value;
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x00068BA4 File Offset: 0x00066DA4
		public void SystemDebugAnim(int Value)
		{
			ModAni._Parameter = ((Value >= 0x1E) ? 200.0 : ModBase.MathRange((double)Value * 0.1 + 0.1, 0.1, 3.0));
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x00009101 File Offset: 0x00007301
		public void VersionRamType(int Type)
		{
			if (ModMain._ServerFilter != null)
			{
				ModMain._ServerFilter.RamType(Type);
			}
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x00068BF4 File Offset: 0x00066DF4
		public void VersionServerLogin(int Type)
		{
			if (ModMain._ServerFilter != null)
			{
				ModBase.WriteIni(ModMinecraft.m_ResolverIterator + "PCL.ini", "VersionCache", "");
				if (PageVersionLeft.m_OrderModel != null)
				{
					PageVersionLeft.m_OrderModel = new ModMinecraft.McVersion(PageVersionLeft.m_OrderModel.Name).Load();
					ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", false);
				}
			}
		}

		// Token: 0x040006CF RID: 1743
		private readonly Dictionary<string, ModSetup.SetupEntry> broadcasterUtils;

		// Token: 0x0200014F RID: 335
		private enum SetupSource
		{
			// Token: 0x040006D1 RID: 1745
			Normal,
			// Token: 0x040006D2 RID: 1746
			Registry,
			// Token: 0x040006D3 RID: 1747
			Version
		}

		// Token: 0x02000150 RID: 336
		private class SetupEntry
		{
			// Token: 0x06000CE9 RID: 3305 RVA: 0x00068C60 File Offset: 0x00066E60
			public SetupEntry(object Value, object Source = 0, object Encoded = false)
			{
				this._SerializerMapper = 0;
				this._ManagerMapper = RuntimeHelpers.GetObjectValue(Value);
				this.m_ItemMapper = RuntimeHelpers.GetObjectValue(Conversions.ToBoolean(Encoded) ? ModBase.ValidateIterator(Conversions.ToString(Value), "PCL" + ModBase.ruleRule) : Value);
				this._ThreadMapper = Conversions.ToBoolean(Encoded);
				this.Value = RuntimeHelpers.GetObjectValue(Value);
				this.Source = (ModSetup.SetupSource)Conversions.ToInteger(Source);
				this.Type = (Value ?? new object()).GetType();
			}

			// Token: 0x040006D4 RID: 1748
			public bool _ThreadMapper;

			// Token: 0x040006D5 RID: 1749
			public object _ManagerMapper;

			// Token: 0x040006D6 RID: 1750
			public object m_ItemMapper;

			// Token: 0x040006D7 RID: 1751
			public object Value;

			// Token: 0x040006D8 RID: 1752
			public ModSetup.SetupSource Source;

			// Token: 0x040006D9 RID: 1753
			public byte _SerializerMapper;

			// Token: 0x040006DA RID: 1754
			public Type Type;
		}
	}
}
