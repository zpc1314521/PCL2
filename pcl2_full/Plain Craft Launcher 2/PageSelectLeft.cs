using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCL.My;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x0200012F RID: 303
	[DesignerGenerated]
	public class PageSelectLeft : MyPageLeft, IComponentConnector
	{
		// Token: 0x06000AEC RID: 2796 RVA: 0x00008087 File Offset: 0x00006287
		// Note: this type is marked as 'beforefieldinit'.
		static PageSelectLeft()
		{
			PageSelectLeft.repositoryExpression = false;
			PageSelectLeft.m_SystemExpression = false;
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x00008095 File Offset: 0x00006295
		public PageSelectLeft()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x0005C1D0 File Offset: 0x0005A3D0
		public static void StartInstall()
		{
			string File = ModBase.SelectFile("压缩包文件(*.rar;*.zip)|*.rar;*.zip", "选择整合包压缩文件");
			if (!string.IsNullOrEmpty(File))
			{
				ModBase.RunInThread(delegate
				{
					PageSelectLeft.StartInstall(File, null, true);
				});
			}
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x0005C218 File Offset: 0x0005A418
		public static object StartInstall(string File, string VersionName = null, bool ShowHint = true)
		{
			ZipArchive zipArchive = null;
			string archiveBaseFolder = "";
			object result;
			try
			{
				int num = -1;
				try
				{
					zipArchive = new ZipArchive(new FileStream(File, FileMode.Open));
					if (zipArchive.GetEntry("manifest.json") != null)
					{
						if (((JObject)ModBase.GetJson(ModBase.ReadFile(zipArchive.GetEntry("manifest.json").Open(), Encoding.UTF8)))["addons"] == null)
						{
							num = 0;
						}
						else
						{
							num = 3;
						}
					}
					else if (zipArchive.GetEntry("modpack.json") != null)
					{
						num = 1;
					}
					else if (zipArchive.GetEntry("mmc-pack.json") != null)
					{
						num = 2;
					}
					else if (zipArchive.GetEntry("mcbbs.packmeta") != null)
					{
						num = 3;
					}
					else
					{
						try
						{
							foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
							{
								string[] array = zipArchiveEntry.FullName.Split(new char[]
								{
									'/'
								});
								archiveBaseFolder = array[0] + "/";
								if (zipArchiveEntry.FullName.EndsWith("/versions/") && array.Count<string>() == 3)
								{
									num = 9;
									break;
								}
								if (array.Count<string>() == 2)
								{
									if (Operators.CompareString(array[1], "manifest.json", true) != 0)
									{
										if (Operators.CompareString(array[1], "modpack.json", true) == 0)
										{
											num = 1;
											break;
										}
										if (Operators.CompareString(array[1], "mmc-pack.json", true) == 0)
										{
											num = 2;
											break;
										}
										if (Operators.CompareString(array[1], "mcbbs.packmeta", true) == 0)
										{
											num = 3;
											break;
										}
									}
									else
									{
										if (((JObject)ModBase.GetJson(ModBase.ReadFile(zipArchiveEntry.Open(), Encoding.UTF8)))["addons"] == null)
										{
											num = 0;
											break;
										}
										num = 3;
										archiveBaseFolder = "overrides/";
										break;
									}
								}
							}
						}
						finally
						{
							IEnumerator<ZipArchiveEntry> enumerator;
							if (enumerator != null)
							{
								enumerator.Dispose();
							}
						}
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "打开整合包文件失败，文件可能损坏或为不支持的压缩包格式", ShowHint ? ModBase.LogLevel.Hint : ModBase.LogLevel.Normal, "出现错误");
					return false;
				}
				switch (num)
				{
				case 0:
					ModBase.Log("[Download] 整合包种类：CurseForge", ModBase.LogLevel.Normal, "出现错误");
					PageSelectLeft.InstallPackCurseForge(File, zipArchive, archiveBaseFolder, VersionName);
					break;
				case 1:
					ModBase.Log("[Download] 整合包种类：HMCL", ModBase.LogLevel.Normal, "出现错误");
					PageSelectLeft.InstallPackHMCL(File, zipArchive, archiveBaseFolder);
					break;
				case 2:
					ModBase.Log("[Download] 整合包种类：MMC", ModBase.LogLevel.Normal, "出现错误");
					PageSelectLeft.InstallPackMMC(File, zipArchive, archiveBaseFolder);
					break;
				case 3:
					ModBase.Log("[Download] 整合包种类：MCBBS", ModBase.LogLevel.Normal, "出现错误");
					PageSelectLeft.InstallPackMCBBS(File, zipArchive, archiveBaseFolder);
					break;
				default:
					if (num != 9)
					{
						if (ShowHint)
						{
							ModMain.Hint("未能识别该整合包的种类，无法安装！", ModMain.HintType.Critical, true);
						}
						else
						{
							ModBase.Log("[Download] 未能识别该整合包的种类，无法安装！", ModBase.LogLevel.Normal, "出现错误");
						}
						return false;
					}
					ModBase.Log("[Download] 整合包种类：压缩包", ModBase.LogLevel.Normal, "出现错误");
					zipArchive.Dispose();
					zipArchive = null;
					PageSelectLeft.InstallPackCompress(File, archiveBaseFolder);
					break;
				}
				result = true;
			}
			catch (Exception ex2)
			{
				ModBase.Log(ex2, "准备安装整合包失败", ModBase.LogLevel.Feedback, "出现错误");
				result = false;
			}
			finally
			{
				if (zipArchive != null)
				{
					zipArchive.Dispose();
				}
			}
			return result;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x0005C57C File Offset: 0x0005A77C
		private static void UnpackFiles(string InstallTemp, string FileAddress)
		{
			if (!PageSelectLeft.repositoryExpression)
			{
				PageSelectLeft.repositoryExpression = true;
				PageSelectLeft.m_SystemExpression = true;
				try
				{
					ModBase.Log("[Download] 开始清理整合包安装缓存", ModBase.LogLevel.Normal, "出现错误");
					ModBase.DeleteDirectory(ModBase.m_GlobalRule + "PackInstall\\", false);
					ModBase.Log("[Download] 已清理整合包安装缓存", ModBase.LogLevel.Normal, "出现错误");
					goto IL_86;
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "清理整合包安装缓存失败", ModBase.LogLevel.Debug, "出现错误");
					goto IL_86;
				}
				finally
				{
					PageSelectLeft.m_SystemExpression = false;
				}
			}
			if (PageSelectLeft.m_SystemExpression)
			{
				while (PageSelectLeft.m_SystemExpression)
				{
					Thread.Sleep(1);
				}
			}
			IL_86:
			Directory.CreateDirectory(InstallTemp + "modsinfo\\");
			int num = 1;
			Encoding entryNameEncoding = Encoding.Default;
			checked
			{
				try
				{
					IL_9F:
					Directory.CreateDirectory(InstallTemp);
					ModBase.DeleteDirectory(InstallTemp, false);
					ZipFile.ExtractToDirectory(FileAddress, InstallTemp, entryNameEncoding);
				}
				catch (Exception ex2)
				{
					ModBase.Log(ex2, "第 " + Conversions.ToString(num) + " 次解压尝试失败", ModBase.LogLevel.Debug, "出现错误");
					if (ex2 is ArgumentException)
					{
						entryNameEncoding = Encoding.UTF8;
						ModBase.Log("[Download] 已切换压缩包解压编码", ModBase.LogLevel.Normal, "出现错误");
					}
					if (num >= 5)
					{
						throw;
					}
					Thread.Sleep(num * 0x7D0);
					num++;
					goto IL_9F;
				}
			}
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x0005C6CC File Offset: 0x0005A8CC
		private static ModLoader.LoaderCombo<string> InstallPackCurseForgeLoader(string FileAddress, ZipArchive Archive, string ArchiveBaseFolder, string VersionName)
		{
			PageSelectLeft._Closure$__7-0 CS$<>8__locals1 = new PageSelectLeft._Closure$__7-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_FileAddress = FileAddress;
			CS$<>8__locals1.$VB$Local_ArchiveBaseFolder = ArchiveBaseFolder;
			CS$<>8__locals1.$VB$Local_VersionName = VersionName;
			JObject jobject;
			try
			{
				jobject = (JObject)ModBase.GetJson(ModBase.ReadFile(Archive.GetEntry(CS$<>8__locals1.$VB$Local_ArchiveBaseFolder + "manifest.json").Open(), null));
				if (jobject["minecraft"] == null || jobject["minecraft"]["version"] == null)
				{
					throw new Exception("整合包未提供 Minecraft 版本信息");
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "整合包安装信息存在问题", ModBase.LogLevel.Hint, "出现错误");
				return null;
			}
			string dispatcherRule = null;
			string initializerRule = null;
			try
			{
				foreach (JToken jtoken in ((IEnumerable<JToken>)(jobject["minecraft"]["modLoaders"] ?? new byte[0])))
				{
					string text = (jtoken["id"] ?? "").ToString().ToLower();
					if (text.StartsWith("forge-"))
					{
						if (text.Contains("recommended"))
						{
							ModBase.Log("[Download] 该整合包版本过老，已不支持进行安装！", ModBase.LogLevel.Hint, "出现错误");
							return null;
						}
						try
						{
							ModBase.Log("[Download] 整合包 Forge 版本：" + text, ModBase.LogLevel.Normal, "出现错误");
							dispatcherRule = text.Split(new char[]
							{
								'-'
							})[1];
							break;
						}
						catch (Exception ex2)
						{
							ModBase.Log(ex2, "读取整合包 Forge 版本失败：" + text, ModBase.LogLevel.Debug, "出现错误");
							continue;
						}
					}
					if (text.StartsWith("fabric-"))
					{
						try
						{
							ModBase.Log("[Download] 整合包 Fabric 版本：" + text, ModBase.LogLevel.Normal, "出现错误");
							initializerRule = text.Split(new char[]
							{
								'-'
							})[1];
							break;
						}
						catch (Exception ex3)
						{
							ModBase.Log(ex3, "读取整合包 Fabric 版本失败：" + text, ModBase.LogLevel.Debug, "出现错误");
						}
					}
				}
			}
			finally
			{
				IEnumerator<JToken> enumerator;
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}
			CS$<>8__locals1.$VB$Local_InstallTemp = ModBase.m_GlobalRule + "PackInstall\\" + Conversions.ToString(ModBase.RandomInteger(0, 0x186A0)) + "\\";
			ArrayList arrayList = new ArrayList();
			CS$<>8__locals1.$VB$Local_OverrideHome = (string)(jobject["overrides"] ?? "");
			if (Operators.CompareString(CS$<>8__locals1.$VB$Local_OverrideHome, "", true) != 0)
			{
				arrayList.Add(new ModLoader.LoaderTask<string, int>("解压整合包文件", delegate(ModLoader.LoaderTask<string, int> Task)
				{
					PageSelectLeft.UnpackFiles(CS$<>8__locals1.$VB$Local_InstallTemp, CS$<>8__locals1.$VB$Local_FileAddress);
					Task.Progress = 0.5;
					if (Directory.Exists(CS$<>8__locals1.$VB$Local_InstallTemp + CS$<>8__locals1.$VB$Local_ArchiveBaseFolder + CS$<>8__locals1.$VB$Local_OverrideHome))
					{
						MyWpfExtension.RunFactory().FileSystem.CopyDirectory(CS$<>8__locals1.$VB$Local_InstallTemp + CS$<>8__locals1.$VB$Local_ArchiveBaseFolder + CS$<>8__locals1.$VB$Local_OverrideHome, ModMinecraft.m_ResolverIterator + "versions\\" + CS$<>8__locals1.$VB$Local_VersionName);
					}
					else
					{
						ModBase.Log("[Download] 整合包中未找到 override 目录，已跳过", ModBase.LogLevel.Normal, "出现错误");
					}
					Task.Progress = 0.9;
					ModBase.WriteIni(ModMinecraft.m_ResolverIterator + "versions\\" + CS$<>8__locals1.$VB$Local_VersionName + "\\PCL\\Setup.ini", "VersionArgumentIndie", Conversions.ToString(1));
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = (double)new FileInfo(CS$<>8__locals1.$VB$Local_FileAddress).Length / 1024.0 / 1024.0 / 6.0,
					Block = false
				});
			}
			CS$<>8__locals1.$VB$Local_ModFileList = new List<ModNet.NetFile>();
			try
			{
				foreach (JToken jtoken2 in ((IEnumerable<JToken>)(jobject["files"] ?? new byte[0])))
				{
					if (jtoken2["projectID"] != null && jtoken2["fileID"] != null)
					{
						if (jtoken2["required"] == null || jtoken2["required"].ToObject<bool>())
						{
							int value = (int)jtoken2["projectID"];
							int value2 = (int)jtoken2["fileID"];
							if (ModBase.errorRule)
							{
								ModBase.Log("[Download] 需要的 Mod：" + Conversions.ToString(value) + "-" + Conversions.ToString(value2), ModBase.LogLevel.Normal, "出现错误");
							}
							CS$<>8__locals1.$VB$Local_ModFileList.Add(new ModNet.NetFile(new string[]
							{
								string.Concat(new string[]
								{
									"https://addons-ecs.forgesvc.net/api/v2/addon/",
									Conversions.ToString(value),
									"/file/",
									Conversions.ToString(value2),
									"/"
								}),
								string.Concat(new string[]
								{
									"https://cursemeta.dries007.net/",
									Conversions.ToString(value),
									"/",
									Conversions.ToString(value2),
									".json"
								})
							}, string.Concat(new string[]
							{
								CS$<>8__locals1.$VB$Local_InstallTemp,
								"modsinfo\\",
								Conversions.ToString(value),
								"-",
								Conversions.ToString(value2),
								".json"
							}), null));
						}
					}
					else
					{
						ModMain.Hint("某项 Mod 缺少必要信息，已跳过：" + jtoken2.ToString(), ModMain.HintType.Info, true);
					}
				}
			}
			finally
			{
				IEnumerator<JToken> enumerator2;
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
			if (CS$<>8__locals1.$VB$Local_ModFileList.Count > 0)
			{
				arrayList.Add(new ModLoader.LoaderTask<int, List<JObject>>("获取 Mod 下载信息", delegate(ModLoader.LoaderTask<int, List<JObject>> Task)
				{
					Directory.CreateDirectory(CS$<>8__locals1.$VB$Local_InstallTemp + "modsinfo\\");
					int count = CS$<>8__locals1.$VB$Local_ModFileList.Count;
					List<ModNet.NetFile> list = new List<ModNet.NetFile>();
					List<JObject> list2 = new List<JObject>();
					list.AddRange(CS$<>8__locals1.$VB$Local_ModFileList);
					int num4 = 1;
					while (list.Count > 0)
					{
						List<ModNet.NetFile> list3 = new List<ModNet.NetFile>();
						try
						{
							foreach (ModNet.NetFile netFile in list)
							{
								list3.Add(new ModNet.NetFile(new string[]
								{
									netFile.identifierRule[0].regRule
								}, netFile.mapRule, netFile.iteratorAlgo));
							}
						}
						finally
						{
							List<ModNet.NetFile>.Enumerator enumerator5;
							((IDisposable)enumerator5).Dispose();
						}
						list = list3;
						ModBase.Log(string.Format("[Download] 开始第 {0} 次 Mod 信息读取，剩余 {1} 个文件", num4, list.Count), ModBase.LogLevel.Normal, "出现错误");
						ModNet.LoaderDownload loaderDownload = new ModNet.LoaderDownload("获取 Mod 下载信息（内部）", list);
						loaderDownload.Start(null, false);
						while (loaderDownload.State == ModBase.LoadState.Loading)
						{
							Task.Progress = (double)list2.Count / (double)count + (double)list.Count / (double)count * loaderDownload.Progress * 0.85;
							Thread.Sleep(0xA);
						}
						if (loaderDownload.State == ModBase.LoadState.Failed)
						{
							throw loaderDownload.Error;
						}
						List<ModNet.NetFile> list4 = new List<ModNet.NetFile>();
						list4.AddRange(list);
						try
						{
							foreach (ModNet.NetFile netFile2 in list4)
							{
								string text3 = ModBase.ReadFile(netFile2.mapRule);
								if (text3.EndsWith("}"))
								{
									try
									{
										JObject item = (JObject)ModBase.GetJson(text3);
										list2.Add(item);
										list.Remove(netFile2);
									}
									catch (Exception ex4)
									{
										ModBase.Log("[Download] 错误的 Mod 文件信息：" + netFile2.m_ComposerRule, ModBase.LogLevel.Normal, "出现错误");
									}
								}
							}
						}
						finally
						{
							List<ModNet.NetFile>.Enumerator enumerator6;
							((IDisposable)enumerator6).Dispose();
						}
						checked
						{
							num4++;
							if (num4 > 0xA)
							{
								throw new Exception("无法获取 Mod 下载信息，十次重试后文件仍有 " + Conversions.ToString(list.Count) + " 个损坏文件！");
							}
						}
					}
					Task.Output = list2;
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = (double)CS$<>8__locals1.$VB$Local_ModFileList.Count / 2.0
				});
				arrayList.Add(new ModLoader.LoaderTask<List<JObject>, List<ModNet.NetFile>>("构造 Mod 下载信息", delegate(ModLoader.LoaderTask<List<JObject>, List<ModNet.NetFile>> Task)
				{
					List<ModNet.NetFile> list = new List<ModNet.NetFile>();
					try
					{
						foreach (JObject data in Task.Input)
						{
							list.Add(new ModDownload.DlCfFile(data, false).GetDownloadFile(ModMinecraft.m_ResolverIterator + "versions\\" + CS$<>8__locals1.$VB$Local_VersionName + "\\mods\\", false));
							Task.Progress += 1.0 / (double)(checked(1 + CS$<>8__locals1.$VB$Local_ModFileList.Count));
						}
					}
					finally
					{
						List<JObject>.Enumerator enumerator5;
						((IDisposable)enumerator5).Dispose();
					}
					Task.Output = list;
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = (double)CS$<>8__locals1.$VB$Local_ModFileList.Count / 30.0,
					Show = false
				});
				arrayList.Add(new ModNet.LoaderDownload("下载 Mod", new List<ModNet.NetFile>())
				{
					ProgressWeight = (double)CS$<>8__locals1.$VB$Local_ModFileList.Count * 1.5
				});
			}
			ModDownloadLib.McInstallRequest request = new ModDownloadLib.McInstallRequest
			{
				m_CandidateRule = CS$<>8__locals1.$VB$Local_VersionName,
				m_DescriptorRule = jobject["minecraft"]["version"].ToString(),
				_DispatcherRule = dispatcherRule,
				_InitializerRule = initializerRule
			};
			double num = 0.0;
			try
			{
				foreach (object obj in arrayList)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(obj);
					num = Conversions.ToDouble(Operators.AddObject(num, NewLateBinding.LateGet(objectValue, null, "ProgressWeight", new object[0], null, null, null)));
				}
			}
			finally
			{
				IEnumerator enumerator3;
				if (enumerator3 is IDisposable)
				{
					(enumerator3 as IDisposable).Dispose();
				}
			}
			ArrayList arrayList2 = ModDownloadLib.McInstallLoader(request, true);
			checked
			{
				ModLoader.LoaderCombo<string> result;
				if (arrayList2 == null)
				{
					result = null;
				}
				else
				{
					double num2 = 0.0;
					try
					{
						foreach (object obj2 in arrayList2)
						{
							object objectValue2 = RuntimeHelpers.GetObjectValue(obj2);
							num2 = Conversions.ToDouble(Operators.AddObject(num2, NewLateBinding.LateGet(objectValue2, null, "ProgressWeight", new object[0], null, null, null)));
						}
					}
					finally
					{
						IEnumerator enumerator4;
						if (enumerator4 is IDisposable)
						{
							(enumerator4 as IDisposable).Dispose();
						}
					}
					ArrayList arrayList3 = new ArrayList();
					arrayList3.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析游戏支持库文件（副加载器）", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
					{
						Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McVersion(CS$<>8__locals1.$VB$Local_VersionName), false);
					}, null, ThreadPriority.Normal)
					{
						ProgressWeight = 1.0,
						Show = false
					});
					arrayList3.Add(new ModNet.LoaderDownload("下载游戏支持库文件（副加载器）", new List<ModNet.NetFile>())
					{
						ProgressWeight = 7.0,
						Show = false
					});
					ArrayList arrayList4 = new ArrayList();
					arrayList4.Add(new ModLoader.LoaderCombo<string>("整合包安装", arrayList)
					{
						Show = false,
						Block = false,
						ProgressWeight = num
					});
					arrayList4.Add(new ModLoader.LoaderCombo<string>("游戏安装", arrayList2)
					{
						Show = false,
						ProgressWeight = num2
					});
					arrayList4.Add(new ModLoader.LoaderCombo<string>("下载游戏支持库文件", arrayList3)
					{
						ProgressWeight = 8.0
					});
					string text2 = "CurseForge 整合包安装：" + CS$<>8__locals1.$VB$Local_VersionName + " ";
					object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
					ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
					lock (loaderTaskbarLock)
					{
						int num3 = ModLoader.LoaderTaskbar.Count - 1;
						for (int i = 0; i <= num3; i++)
						{
							if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(ModLoader.LoaderTaskbar[i], null, "Name", new object[0], null, null, null), text2, true))
							{
								ModMain.Hint("该整合包正在安装中！", ModMain.HintType.Critical, true);
								return null;
							}
						}
					}
					result = new ModLoader.LoaderCombo<string>(text2, arrayList4)
					{
						OnStateChanged = new ModLoader.LoaderStateDelegate(ModDownloadLib.McInstallState)
					};
				}
				return result;
			}
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x0005CFD0 File Offset: 0x0005B1D0
		private static void InstallPackCurseForge(string FileAddress, ZipArchive Archive, string ArchiveBaseFolder, string VersionName = null)
		{
			bool flag = VersionName == null;
			if (VersionName == null)
			{
				JObject jobject;
				try
				{
					jobject = (JObject)ModBase.GetJson(ModBase.ReadFile(Archive.GetEntry(ArchiveBaseFolder + "manifest.json").Open(), null));
					if (jobject["minecraft"] == null || jobject["minecraft"]["version"] == null)
					{
						throw new Exception("整合包未提供 Minecraft 版本信息");
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "整合包安装信息存在问题", ModBase.LogLevel.Hint, "出现错误");
					return;
				}
				string text = (string)(jobject["name"] ?? "");
				ValidateFolderName validateFolderName = new ValidateFolderName(ModMinecraft.m_ResolverIterator + "versions", true, true);
				if (Operators.CompareString(validateFolderName.Validate(text), "", true) != 0)
				{
					text = "";
				}
				VersionName = ModMain.MyMsgBoxInput(text, new Collection<Validate>
				{
					validateFolderName
				}, "", "输入版本名", "确定", "取消", false);
				if (string.IsNullOrEmpty(VersionName))
				{
					return;
				}
			}
			ModLoader.LoaderCombo<string> loaderCombo = PageSelectLeft.InstallPackCurseForgeLoader(FileAddress, Archive, ArchiveBaseFolder, VersionName);
			if (loaderCombo != null)
			{
				loaderCombo.Start(ModMinecraft.m_ResolverIterator + "versions\\" + VersionName + "\\", false);
				ModLoader.LoaderTaskbarAdd(loaderCombo);
				ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
				if (flag)
				{
					ModMain.m_GetterFilter.BtnExtraDownload.Ribble();
				}
			}
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x0005D148 File Offset: 0x0005B348
		private static void InstallPackHMCL(string FileAddress, ZipArchive Archive, string ArchiveBaseFolder)
		{
			PageSelectLeft._Closure$__9-0 CS$<>8__locals1 = new PageSelectLeft._Closure$__9-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_FileAddress = FileAddress;
			CS$<>8__locals1.$VB$Local_ArchiveBaseFolder = ArchiveBaseFolder;
			JObject jobject;
			try
			{
				jobject = (JObject)ModBase.GetJson(ModBase.ReadFile(Archive.GetEntry(CS$<>8__locals1.$VB$Local_ArchiveBaseFolder + "modpack.json").Open(), Encoding.UTF8));
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "整合包安装信息存在问题", ModBase.LogLevel.Hint, "出现错误");
				return;
			}
			string text = (string)(jobject["name"] ?? "");
			ValidateFolderName validateFolderName = new ValidateFolderName(ModMinecraft.m_ResolverIterator + "versions", true, true);
			if (Operators.CompareString(validateFolderName.Validate(text), "", true) != 0)
			{
				text = "";
			}
			CS$<>8__locals1.$VB$Local_VersionName = ModMain.MyMsgBoxInput(text, new Collection<Validate>
			{
				validateFolderName
			}, "", "输入版本名", "确定", "取消", false);
			checked
			{
				if (CS$<>8__locals1.$VB$Local_VersionName != null)
				{
					CS$<>8__locals1.$VB$Local_InstallTemp = ModBase.m_GlobalRule + "PackInstall\\" + Conversions.ToString(ModBase.RandomInteger(0, 0x186A0)) + "\\";
					ArrayList arrayList = new ArrayList();
					arrayList.Add(new ModLoader.LoaderTask<string, int>("解压整合包文件", delegate(ModLoader.LoaderTask<string, int> Task)
					{
						PageSelectLeft.UnpackFiles(CS$<>8__locals1.$VB$Local_InstallTemp, CS$<>8__locals1.$VB$Local_FileAddress);
						Task.Progress = 0.5;
						if (Directory.Exists(CS$<>8__locals1.$VB$Local_InstallTemp + CS$<>8__locals1.$VB$Local_ArchiveBaseFolder + "minecraft"))
						{
							MyWpfExtension.RunFactory().FileSystem.CopyDirectory(CS$<>8__locals1.$VB$Local_InstallTemp + CS$<>8__locals1.$VB$Local_ArchiveBaseFolder + "minecraft", ModMinecraft.m_ResolverIterator + "versions\\" + CS$<>8__locals1.$VB$Local_VersionName);
						}
						else
						{
							ModBase.Log("[Download] 整合包中未找到 minecraft override 目录，已跳过", ModBase.LogLevel.Normal, "出现错误");
						}
						Task.Progress = 0.9;
						ModBase.WriteIni(ModMinecraft.m_ResolverIterator + "versions\\" + CS$<>8__locals1.$VB$Local_VersionName + "\\PCL\\Setup.ini", "VersionArgumentIndie", Conversions.ToString(1));
					}, null, ThreadPriority.Normal)
					{
						ProgressWeight = (double)new FileInfo(CS$<>8__locals1.$VB$Local_FileAddress).Length / 1024.0 / 1024.0 / 6.0,
						Block = false
					});
					if (jobject["gameVersion"] == null)
					{
						throw new Exception("整合包未提供游戏版本信息");
					}
					ModDownloadLib.McInstallRequest request = new ModDownloadLib.McInstallRequest
					{
						m_CandidateRule = CS$<>8__locals1.$VB$Local_VersionName,
						m_DescriptorRule = jobject["gameVersion"].ToString()
					};
					double num = 0.0;
					try
					{
						foreach (object obj in arrayList)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(obj);
							num = Conversions.ToDouble(Operators.AddObject(num, NewLateBinding.LateGet(objectValue, null, "ProgressWeight", new object[0], null, null, null)));
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					ArrayList arrayList2 = ModDownloadLib.McInstallLoader(request, true);
					if (arrayList2 != null)
					{
						double num2 = 0.0;
						try
						{
							foreach (object obj2 in arrayList2)
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(obj2);
								num2 = Conversions.ToDouble(Operators.AddObject(num2, NewLateBinding.LateGet(objectValue2, null, "ProgressWeight", new object[0], null, null, null)));
							}
						}
						finally
						{
							IEnumerator enumerator2;
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
						ArrayList arrayList3 = new ArrayList();
						arrayList3.Add(new ModLoader.LoaderTask<string, string>("重命名版本 Json（副加载器）", delegate(ModLoader.LoaderTask<string, string> a0)
						{
							base._Lambda$__1();
						}, null, ThreadPriority.Normal)
						{
							ProgressWeight = 0.1,
							Show = false
						});
						arrayList3.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析游戏支持库文件（副加载器）", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
						{
							Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McVersion(CS$<>8__locals1.$VB$Local_VersionName), false);
						}, null, ThreadPriority.Normal)
						{
							ProgressWeight = 1.0,
							Show = false
						});
						arrayList3.Add(new ModNet.LoaderDownload("下载游戏支持库文件（副加载器）", new List<ModNet.NetFile>())
						{
							ProgressWeight = 7.0,
							Show = false
						});
						ArrayList arrayList4 = new ArrayList();
						arrayList4.Add(new ModLoader.LoaderCombo<string>("游戏安装", arrayList2)
						{
							Show = false,
							Block = false,
							ProgressWeight = num2
						});
						arrayList4.Add(new ModLoader.LoaderCombo<string>("整合包安装", arrayList)
						{
							Show = false,
							ProgressWeight = num
						});
						arrayList4.Add(new ModLoader.LoaderCombo<string>("下载游戏支持库文件", arrayList3)
						{
							ProgressWeight = 8.0
						});
						string text2 = "HMCL 整合包安装：" + CS$<>8__locals1.$VB$Local_VersionName + " ";
						object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
						ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
						lock (loaderTaskbarLock)
						{
							int num3 = ModLoader.LoaderTaskbar.Count - 1;
							for (int i = 0; i <= num3; i++)
							{
								if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(ModLoader.LoaderTaskbar[i], null, "Name", new object[0], null, null, null), text2, true))
								{
									ModMain.Hint("该整合包正在安装中！", ModMain.HintType.Critical, true);
									return;
								}
							}
						}
						ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(text2, arrayList4);
						loaderCombo.OnStateChanged = new ModLoader.LoaderStateDelegate(ModDownloadLib.McInstallState);
						loaderCombo.Start(ModMinecraft.m_ResolverIterator + "versions\\" + CS$<>8__locals1.$VB$Local_VersionName + "\\", false);
						ModLoader.LoaderTaskbarAdd(loaderCombo);
						ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
						ModMain.m_GetterFilter.BtnExtraDownload.Ribble();
					}
				}
			}
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x0005D644 File Offset: 0x0005B844
		private static void InstallPackMMC(string FileAddress, ZipArchive Archive, string ArchiveBaseFolder)
		{
			PageSelectLeft._Closure$__10-0 CS$<>8__locals1 = new PageSelectLeft._Closure$__10-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_FileAddress = FileAddress;
			CS$<>8__locals1.$VB$Local_ArchiveBaseFolder = ArchiveBaseFolder;
			JObject jobject;
			string str;
			try
			{
				jobject = (JObject)ModBase.GetJson(ModBase.ReadFile(Archive.GetEntry(CS$<>8__locals1.$VB$Local_ArchiveBaseFolder + "mmc-pack.json").Open(), Encoding.UTF8));
				str = ModBase.ReadFile(Archive.GetEntry(CS$<>8__locals1.$VB$Local_ArchiveBaseFolder + "instance.cfg").Open(), Encoding.UTF8);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "整合包安装信息存在问题", ModBase.LogLevel.Hint, "出现错误");
				return;
			}
			string text = ModBase.RegexSeek(str, "(?<=\\nname\\=)[^\\n]+", RegexOptions.None) ?? "";
			ValidateFolderName validateFolderName = new ValidateFolderName(ModMinecraft.m_ResolverIterator + "versions", true, true);
			if (Operators.CompareString(validateFolderName.Validate(text), "", true) != 0)
			{
				text = "";
			}
			CS$<>8__locals1.$VB$Local_VersionName = ModMain.MyMsgBoxInput(text, new Collection<Validate>
			{
				validateFolderName
			}, "", "输入版本名", "确定", "取消", false);
			checked
			{
				if (CS$<>8__locals1.$VB$Local_VersionName != null)
				{
					CS$<>8__locals1.$VB$Local_InstallTemp = ModBase.m_GlobalRule + "PackInstall\\" + Conversions.ToString(ModBase.RandomInteger(0, 0x186A0)) + "\\";
					ArrayList arrayList = new ArrayList();
					arrayList.Add(new ModLoader.LoaderTask<string, int>("解压整合包文件", delegate(ModLoader.LoaderTask<string, int> Task)
					{
						PageSelectLeft.UnpackFiles(CS$<>8__locals1.$VB$Local_InstallTemp, CS$<>8__locals1.$VB$Local_FileAddress);
						Task.Progress = 0.5;
						if (Directory.Exists(CS$<>8__locals1.$VB$Local_InstallTemp + CS$<>8__locals1.$VB$Local_ArchiveBaseFolder + ".minecraft"))
						{
							MyWpfExtension.RunFactory().FileSystem.CopyDirectory(CS$<>8__locals1.$VB$Local_InstallTemp + CS$<>8__locals1.$VB$Local_ArchiveBaseFolder + ".minecraft", ModMinecraft.m_ResolverIterator + "versions\\" + CS$<>8__locals1.$VB$Local_VersionName);
						}
						else
						{
							ModBase.Log("[Download] 整合包中未找到 override .minecraft 目录，已跳过", ModBase.LogLevel.Normal, "出现错误");
						}
						Task.Progress = 0.9;
						ModBase.WriteIni(ModMinecraft.m_ResolverIterator + "versions\\" + CS$<>8__locals1.$VB$Local_VersionName + "\\PCL\\Setup.ini", "VersionArgumentIndie", Conversions.ToString(1));
					}, null, ThreadPriority.Normal)
					{
						ProgressWeight = (double)new FileInfo(CS$<>8__locals1.$VB$Local_FileAddress).Length / 1024.0 / 1024.0 / 6.0,
						Block = false
					});
					if (jobject["components"] == null)
					{
						throw new Exception("整合包未提供游戏版本信息");
					}
					ModDownloadLib.McInstallRequest mcInstallRequest = new ModDownloadLib.McInstallRequest
					{
						m_CandidateRule = CS$<>8__locals1.$VB$Local_VersionName
					};
					try
					{
						foreach (JToken jtoken in ((IEnumerable<JToken>)jobject["components"]))
						{
							string left = (jtoken["uid"] ?? "").ToString();
							if (Operators.CompareString(left, "org.lwjgl", true) == 0)
							{
								ModBase.Log("[Download] 已跳过 LWJGL 项", ModBase.LogLevel.Normal, "出现错误");
							}
							else if (Operators.CompareString(left, "net.minecraft", true) == 0)
							{
								mcInstallRequest.m_DescriptorRule = (string)jtoken["version"];
							}
							else if (Operators.CompareString(left, "net.minecraftforge", true) == 0)
							{
								mcInstallRequest._DispatcherRule = (string)jtoken["version"];
							}
						}
					}
					finally
					{
						IEnumerator<JToken> enumerator;
						if (enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					double num = 0.0;
					try
					{
						foreach (object obj in arrayList)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(obj);
							num = Conversions.ToDouble(Operators.AddObject(num, NewLateBinding.LateGet(objectValue, null, "ProgressWeight", new object[0], null, null, null)));
						}
					}
					finally
					{
						IEnumerator enumerator2;
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
					ArrayList arrayList2 = ModDownloadLib.McInstallLoader(mcInstallRequest, true);
					if (arrayList2 != null)
					{
						double num2 = 0.0;
						try
						{
							foreach (object obj2 in arrayList2)
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(obj2);
								num2 = Conversions.ToDouble(Operators.AddObject(num2, NewLateBinding.LateGet(objectValue2, null, "ProgressWeight", new object[0], null, null, null)));
							}
						}
						finally
						{
							IEnumerator enumerator3;
							if (enumerator3 is IDisposable)
							{
								(enumerator3 as IDisposable).Dispose();
							}
						}
						ArrayList arrayList3 = new ArrayList();
						arrayList3.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析游戏支持库文件（副加载器）", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
						{
							Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McVersion(CS$<>8__locals1.$VB$Local_VersionName), false);
						}, null, ThreadPriority.Normal)
						{
							ProgressWeight = 1.0,
							Show = false
						});
						arrayList3.Add(new ModNet.LoaderDownload("下载游戏支持库文件（副加载器）", new List<ModNet.NetFile>())
						{
							ProgressWeight = 7.0,
							Show = false
						});
						ArrayList arrayList4 = new ArrayList();
						arrayList4.Add(new ModLoader.LoaderCombo<string>("游戏安装", arrayList2)
						{
							Show = false,
							Block = false,
							ProgressWeight = num2
						});
						arrayList4.Add(new ModLoader.LoaderCombo<string>("整合包安装", arrayList)
						{
							Show = false,
							ProgressWeight = num
						});
						arrayList4.Add(new ModLoader.LoaderCombo<string>("下载游戏支持库文件", arrayList3)
						{
							ProgressWeight = 8.0
						});
						string text2 = "MMC 整合包安装：" + CS$<>8__locals1.$VB$Local_VersionName + " ";
						object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
						ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
						lock (loaderTaskbarLock)
						{
							int num3 = ModLoader.LoaderTaskbar.Count - 1;
							for (int i = 0; i <= num3; i++)
							{
								if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(ModLoader.LoaderTaskbar[i], null, "Name", new object[0], null, null, null), text2, true))
								{
									ModMain.Hint("该整合包正在安装中！", ModMain.HintType.Critical, true);
									return;
								}
							}
						}
						ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(text2, arrayList4);
						loaderCombo.OnStateChanged = new ModLoader.LoaderStateDelegate(ModDownloadLib.McInstallState);
						loaderCombo.Start(ModMinecraft.m_ResolverIterator + "versions\\" + CS$<>8__locals1.$VB$Local_VersionName + "\\", false);
						ModLoader.LoaderTaskbarAdd(loaderCombo);
						ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
						ModMain.m_GetterFilter.BtnExtraDownload.Ribble();
					}
				}
			}
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x0005DBEC File Offset: 0x0005BDEC
		private static void InstallPackMCBBS(string FileAddress, ZipArchive Archive, string ArchiveBaseFolder)
		{
			PageSelectLeft._Closure$__11-0 CS$<>8__locals1 = new PageSelectLeft._Closure$__11-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_FileAddress = FileAddress;
			CS$<>8__locals1.$VB$Local_ArchiveBaseFolder = ArchiveBaseFolder;
			JObject jobject;
			try
			{
				jobject = (JObject)ModBase.GetJson(ModBase.ReadFile((Archive.GetEntry(CS$<>8__locals1.$VB$Local_ArchiveBaseFolder + "mcbbs.packmeta") ?? Archive.GetEntry(CS$<>8__locals1.$VB$Local_ArchiveBaseFolder + "manifest.json")).Open(), Encoding.UTF8));
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "整合包安装信息存在问题", ModBase.LogLevel.Hint, "出现错误");
				return;
			}
			string text = (string)(jobject["name"] ?? "");
			ValidateFolderName validateFolderName = new ValidateFolderName(ModMinecraft.m_ResolverIterator + "versions", true, true);
			if (Operators.CompareString(validateFolderName.Validate(text), "", true) != 0)
			{
				text = "";
			}
			CS$<>8__locals1.$VB$Local_VersionName = ModMain.MyMsgBoxInput(text, new Collection<Validate>
			{
				validateFolderName
			}, "", "输入版本名", "确定", "取消", false);
			checked
			{
				if (CS$<>8__locals1.$VB$Local_VersionName != null)
				{
					CS$<>8__locals1.$VB$Local_InstallTemp = ModBase.m_GlobalRule + "PackInstall\\" + Conversions.ToString(ModBase.RandomInteger(0, 0x186A0)) + "\\";
					ArrayList arrayList = new ArrayList();
					arrayList.Add(new ModLoader.LoaderTask<string, int>("解压整合包文件", delegate(ModLoader.LoaderTask<string, int> Task)
					{
						PageSelectLeft.UnpackFiles(CS$<>8__locals1.$VB$Local_InstallTemp, CS$<>8__locals1.$VB$Local_FileAddress);
						Task.Progress = 0.5;
						if (Directory.Exists(CS$<>8__locals1.$VB$Local_InstallTemp + CS$<>8__locals1.$VB$Local_ArchiveBaseFolder + "overrides"))
						{
							MyWpfExtension.RunFactory().FileSystem.CopyDirectory(CS$<>8__locals1.$VB$Local_InstallTemp + CS$<>8__locals1.$VB$Local_ArchiveBaseFolder + "overrides", ModMinecraft.m_ResolverIterator + "versions\\" + CS$<>8__locals1.$VB$Local_VersionName);
						}
						else
						{
							ModBase.Log("[Download] 整合包中未找到 overrides 目录，已跳过", ModBase.LogLevel.Normal, "出现错误");
						}
						Task.Progress = 0.9;
						ModBase.WriteIni(ModMinecraft.m_ResolverIterator + "versions\\" + CS$<>8__locals1.$VB$Local_VersionName + "\\PCL\\Setup.ini", "VersionArgumentIndie", Conversions.ToString(1));
					}, null, ThreadPriority.Normal)
					{
						ProgressWeight = (double)new FileInfo(CS$<>8__locals1.$VB$Local_FileAddress).Length / 1024.0 / 1024.0 / 6.0,
						Block = false
					});
					if (jobject["addons"] == null)
					{
						throw new Exception("整合包未提供游戏版本信息");
					}
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					try
					{
						foreach (JToken jtoken in ((IEnumerable<JToken>)jobject["addons"]))
						{
							dictionary.Add((string)jtoken["id"], (string)jtoken["version"]);
						}
					}
					finally
					{
						IEnumerator<JToken> enumerator;
						if (enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					if (!dictionary.ContainsKey("game"))
					{
						throw new Exception("整合包未提供游戏版本信息");
					}
					ModDownloadLib.McInstallRequest request = new ModDownloadLib.McInstallRequest
					{
						m_CandidateRule = CS$<>8__locals1.$VB$Local_VersionName,
						m_DescriptorRule = dictionary["game"],
						m_ObserverRule = (dictionary.ContainsKey("optifine") ? dictionary["optifine"] : null),
						_DispatcherRule = (dictionary.ContainsKey("forge") ? dictionary["forge"] : null),
						_InitializerRule = (dictionary.ContainsKey("fabric") ? dictionary["fabric"] : null)
					};
					double num = 0.0;
					try
					{
						foreach (object obj in arrayList)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(obj);
							num = Conversions.ToDouble(Operators.AddObject(num, NewLateBinding.LateGet(objectValue, null, "ProgressWeight", new object[0], null, null, null)));
						}
					}
					finally
					{
						IEnumerator enumerator2;
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
					ArrayList arrayList2 = ModDownloadLib.McInstallLoader(request, true);
					if (arrayList2 != null)
					{
						double num2 = 0.0;
						try
						{
							foreach (object obj2 in arrayList2)
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(obj2);
								num2 = Conversions.ToDouble(Operators.AddObject(num2, NewLateBinding.LateGet(objectValue2, null, "ProgressWeight", new object[0], null, null, null)));
							}
						}
						finally
						{
							IEnumerator enumerator3;
							if (enumerator3 is IDisposable)
							{
								(enumerator3 as IDisposable).Dispose();
							}
						}
						ArrayList arrayList3 = new ArrayList();
						arrayList3.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析游戏支持库文件（副加载器）", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
						{
							Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McVersion(CS$<>8__locals1.$VB$Local_VersionName), false);
						}, null, ThreadPriority.Normal)
						{
							ProgressWeight = 1.0,
							Show = false
						});
						arrayList3.Add(new ModNet.LoaderDownload("下载游戏支持库文件（副加载器）", new List<ModNet.NetFile>())
						{
							ProgressWeight = 7.0,
							Show = false
						});
						ArrayList arrayList4 = new ArrayList();
						arrayList4.Add(new ModLoader.LoaderCombo<string>("游戏安装", arrayList2)
						{
							Show = false,
							Block = false,
							ProgressWeight = num2
						});
						arrayList4.Add(new ModLoader.LoaderCombo<string>("整合包安装", arrayList)
						{
							Show = false,
							ProgressWeight = num
						});
						arrayList4.Add(new ModLoader.LoaderCombo<string>("下载游戏支持库文件", arrayList3)
						{
							ProgressWeight = 8.0
						});
						string text2 = "MCBBS 整合包安装：" + CS$<>8__locals1.$VB$Local_VersionName + " ";
						object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
						ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
						lock (loaderTaskbarLock)
						{
							int num3 = ModLoader.LoaderTaskbar.Count - 1;
							for (int i = 0; i <= num3; i++)
							{
								if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(ModLoader.LoaderTaskbar[i], null, "Name", new object[0], null, null, null), text2, true))
								{
									ModMain.Hint("该整合包正在安装中！", ModMain.HintType.Critical, true);
									return;
								}
							}
						}
						ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(text2, arrayList4);
						loaderCombo.OnStateChanged = new ModLoader.LoaderStateDelegate(ModDownloadLib.McInstallState);
						loaderCombo.Start(ModMinecraft.m_ResolverIterator + "versions\\" + CS$<>8__locals1.$VB$Local_VersionName + "\\", false);
						ModLoader.LoaderTaskbarAdd(loaderCombo);
						ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
						ModMain.m_GetterFilter.BtnExtraDownload.Ribble();
					}
				}
			}
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x0005E1BC File Offset: 0x0005C3BC
		private static void InstallPackCompress(string FileAddress, string ArchiveBaseFolder)
		{
			try
			{
				ModMain.MyMsgBox("请在接下来打开的窗口中选择想要安装的目标文件夹。", "安装提示", "继续", "", "", false, true, true);
				string text = ModBase.SelectFolder("选择安装目标文件夹");
				if (!string.IsNullOrEmpty(text))
				{
					if (!text.Contains("!") && !text.Contains(";"))
					{
						string text2 = ModMain.MyMsgBoxInput(ModBase.GetFolderNameFromPath(text), new Collection<Validate>
						{
							new ValidateNullOrWhiteSpace(),
							new ValidateLength(1, 0x1E),
							new ValidateExcept(new string[]
							{
								">",
								"|"
							}, "输入内容不能包含 %！")
						}, "", "输入它在列表中的显示名称", "确定", "取消", false);
						if (!string.IsNullOrWhiteSpace(text2))
						{
							ModMain.Hint("正在解压压缩包……", ModMain.HintType.Info, true);
							PageSelectLeft.UnpackFiles(text, FileAddress);
							PageSelectLeft.AddFolder(text, text2, false);
							ModMain.Hint("已加入游戏文件夹列表：" + text2, ModMain.HintType.Finish, true);
						}
					}
					else
					{
						ModMain.Hint("Minecraft 文件夹路径中不能含有感叹号或分号！", ModMain.HintType.Critical, true);
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "解压游戏压缩包失败", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x0005E30C File Offset: 0x0005C50C
		public void Add_Click()
		{
			string text = "";
			if (ModNet.HasDownloadingTask(false))
			{
				ModMain.Hint("请不要在下载过程中添加游戏文件夹！", ModMain.HintType.Critical, true);
				return;
			}
			try
			{
				text = ModBase.SelectFolder("选择文件夹");
				if (Operators.CompareString(text, "", true) != 0)
				{
					if (!text.Contains("!") && !text.Contains(";"))
					{
						string text2 = ModMain.MyMsgBoxInput(ModBase.GetFolderNameFromPath(text), new Collection<Validate>
						{
							new ValidateNullOrWhiteSpace(),
							new ValidateLength(1, 0x1E),
							new ValidateExcept(new string[]
							{
								">",
								"|"
							}, "输入内容不能包含 %！")
						}, "", "输入显示名称", "确定", "取消", false);
						if (!string.IsNullOrWhiteSpace(text2))
						{
							PageSelectLeft.AddFolder(text, text2, true);
						}
					}
					else
					{
						ModMain.Hint("Minecraft 文件夹路径中不能含有感叹号或分号！", ModMain.HintType.Critical, true);
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "添加文件夹失败（" + text + "）", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x0005E434 File Offset: 0x0005C634
		private static void AddFolder(string FolderPath, string DisplayName, bool ShowHint)
		{
			PageSelectLeft._Closure$__14-0 CS$<>8__locals1 = new PageSelectLeft._Closure$__14-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_FolderPath = FolderPath;
			if (!CS$<>8__locals1.$VB$Local_FolderPath.EndsWith("\\"))
			{
				CS$<>8__locals1.$VB$Local_FolderPath += "\\";
			}
			checked
			{
				if (ModBase.CheckPermission(CS$<>8__locals1.$VB$Local_FolderPath))
				{
					if (!ModBase.CheckPermission(CS$<>8__locals1.$VB$Local_FolderPath + "versions\\"))
					{
						foreach (DirectoryInfo directoryInfo in new DirectoryInfo(CS$<>8__locals1.$VB$Local_FolderPath).GetDirectories())
						{
							if (ModBase.CheckPermission(directoryInfo.FullName + "\\versions\\"))
							{
								CS$<>8__locals1.$VB$Local_FolderPath = directoryInfo.FullName + "\\";
								break;
							}
						}
					}
					ArrayList arrayList = new ArrayList(ModBase._BaseRule.Get("LaunchFolders", null).ToString().Split(new char[]
					{
						'|'
					}));
					bool flag = false;
					bool flag2 = false;
					int num = arrayList.Count - 1;
					for (int j = 0; j <= num; j++)
					{
						string text = Conversions.ToString(arrayList[j]);
						if (Operators.CompareString(text, "", true) != 0 && Operators.CompareString(text.Split(new char[]
						{
							'>'
						})[1], CS$<>8__locals1.$VB$Local_FolderPath, true) == 0)
						{
							flag = true;
							if (Operators.CompareString(text.Split(new char[]
							{
								'>'
							})[0], DisplayName, true) == 0)
							{
								if (ShowHint)
								{
									ModMain.Hint("此文件夹已在列表中！", ModMain.HintType.Info, true);
									return;
								}
							}
							else
							{
								arrayList[j] = DisplayName + ">" + CS$<>8__locals1.$VB$Local_FolderPath;
								flag2 = true;
								if (ShowHint)
								{
									ModMain.Hint("文件夹名称已更新为 " + DisplayName + " ！", ModMain.HintType.Finish, true);
								}
								IL_1D0:
								if (!flag)
								{
									arrayList.Add(DisplayName + ">" + CS$<>8__locals1.$VB$Local_FolderPath);
								}
								ModBase._BaseRule.Set("LaunchFolders", ModBase.Join(arrayList.ToArray(), "|"), false, null);
								ModBase._BaseRule.Set("LaunchFolderSelect", CS$<>8__locals1.$VB$Local_FolderPath.Replace(ModBase.Path, "$"), false, null);
								ModMinecraft._TestsIterator.Start(ModBase.GetUuid(), false);
								if (!flag2)
								{
									if (ShowHint)
									{
										ModMain.Hint("文件夹 " + DisplayName + " 已添加！", ModMain.HintType.Finish, true);
									}
									ModBase.RunInThread(delegate
									{
										DirectoryInfo directoryInfo2 = new DirectoryInfo(CS$<>8__locals1.$VB$Local_FolderPath + "mods\\");
										if (directoryInfo2.Exists && directoryInfo2.EnumerateFiles().Count<FileInfo>() >= 3)
										{
											DirectoryInfo directoryInfo3 = new DirectoryInfo(CS$<>8__locals1.$VB$Local_FolderPath + "versions\\");
											if (directoryInfo3.Exists && directoryInfo3.EnumerateDirectories().Count<DirectoryInfo>() <= 3)
											{
												try
												{
													foreach (DirectoryInfo directoryInfo4 in directoryInfo3.EnumerateDirectories())
													{
														ModMinecraft.McVersion mcVersion = new ModMinecraft.McVersion(directoryInfo4.FullName);
														mcVersion.Load();
														if (mcVersion.Version.LoginUtils())
														{
															DirectoryInfo directoryInfo5 = new DirectoryInfo(mcVersion.Path + "mods\\");
															if (directoryInfo5.Exists && directoryInfo5.EnumerateFiles().Count<FileInfo>() > 0)
															{
																break;
															}
															ModBase._BaseRule.Set("VersionArgumentIndie", 2, false, mcVersion);
															ModBase.Log("[Setup] 已自动关闭单版本隔离：" + mcVersion.Name, ModBase.LogLevel.Debug, "出现错误");
														}
													}
												}
												finally
												{
													IEnumerator<DirectoryInfo> enumerator;
													if (enumerator != null)
													{
														enumerator.Dispose();
													}
												}
											}
										}
									});
								}
							}
							return;
						}
					}
					goto IL_1D0;
				}
				if (ShowHint)
				{
					ModMain.Hint("添加文件夹失败：PCL 没有访问该文件夹的权限！", ModMain.HintType.Critical, true);
					return;
				}
				throw new Exception("PCL 没有访问文件夹的权限：" + CS$<>8__locals1.$VB$Local_FolderPath);
			}
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x0005E6B4 File Offset: 0x0005C8B4
		public void Create_Click()
		{
			if (ModNet.HasDownloadingTask(false))
			{
				ModMain.Hint("请不要在下载过程中创建游戏文件夹！", ModMain.HintType.Critical, true);
				return;
			}
			if (!Directory.Exists(ModBase.Path + ".minecraft\\"))
			{
				Directory.CreateDirectory(ModBase.Path + ".minecraft\\");
				Directory.CreateDirectory(ModBase.Path + ".minecraft\\versions\\");
				ModBase._BaseRule.Set("LaunchFolderSelect", "$.minecraft\\", false, null);
				ModMain.Hint("新建 .minecraft 文件夹成功！", ModMain.HintType.Finish, true);
			}
			ModMinecraft._TestsIterator.Start(ModBase.GetUuid(), false);
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x0005E748 File Offset: 0x0005C948
		public void Remove_Click(object sender, RoutedEventArgs e)
		{
			checked
			{
				try
				{
					ModMinecraft.McFolder mcFolder = (ModMinecraft.McFolder)((MyListItem)((Popup)((ContextMenu)NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null)).Parent).PlacementTarget).Tag;
					if (mcFolder.Type == ModMinecraft.McFolderType.Custom)
					{
						switch (ModMain.MyMsgBox("是否需要清理 PCL 在该文件夹中的配置文件？\r\n这包括各个版本的独立设置（如自定义图标、第三方登录配置）等，对游戏本身没有影响。", "配置文件清理", "删除", "保留", "取消", false, true, false))
						{
						case 1:
							if (File.Exists(mcFolder.Path + "PCL.ini"))
							{
								File.Delete(mcFolder.Path + "PCL.ini");
							}
							if (!Directory.Exists(mcFolder.Path + "versions\\"))
							{
								goto IL_13A;
							}
							try
							{
								foreach (DirectoryInfo directoryInfo in new DirectoryInfo(mcFolder.Path + "versions\\").EnumerateDirectories())
								{
									if (Directory.Exists(directoryInfo.FullName + "\\PCL\\"))
									{
										Directory.Delete(directoryInfo.FullName + "\\PCL\\", true);
									}
								}
								goto IL_13A;
							}
							finally
							{
								IEnumerator<DirectoryInfo> enumerator;
								if (enumerator != null)
								{
									enumerator.Dispose();
								}
							}
							break;
						case 2:
							goto IL_13A;
						case 3:
							break;
						default:
							goto IL_13A;
						}
						return;
					}
					IL_13A:
					ArrayList arrayList = new ArrayList(ModBase._BaseRule.Get("LaunchFolders", null).ToString().Split(new char[]
					{
						'|'
					}));
					string str = "";
					int num = arrayList.Count - 1;
					int i = 0;
					while (i <= num)
					{
						if (!Operators.ConditionalCompareObjectEqual(arrayList[i], "", true))
						{
							if (!arrayList[i].ToString().EndsWith(mcFolder.Path))
							{
								i++;
								continue;
							}
							str = arrayList[i].ToString().Split(new char[]
							{
								'>'
							})[0];
							arrayList.RemoveAt(i);
						}
						IL_1DF:
						ModBase._BaseRule.Set("LaunchFolders", (arrayList.Count == 0) ? "" : ModBase.Join(arrayList.ToArray(), "|"), false, null);
						ModMain.Hint((mcFolder.Type == ModMinecraft.McFolderType.Custom) ? ("文件夹 " + str + " 已从列表中移除！") : "文件夹名称已复原！", ModMain.HintType.Finish, true);
						ModMinecraft._TestsIterator.Start(ModBase.GetUuid(), false);
						return;
					}
					goto IL_1DF;
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "从列表中移除游戏文件夹失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x0005E9F4 File Offset: 0x0005CBF4
		public void Delete_Click(object sender, RoutedEventArgs e)
		{
			PageSelectLeft._Closure$__17-0 CS$<>8__locals1 = new PageSelectLeft._Closure$__17-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_Folder = (ModMinecraft.McFolder)((MyListItem)((Popup)((ContextMenu)NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null)).Parent).PlacementTarget).Tag;
			PageSelectLeft._Closure$__17-0 CS$<>8__locals2 = CS$<>8__locals1;
			string $VB$Local_DeleteText;
			if ((CS$<>8__locals1.$VB$Local_Folder.Type == ModMinecraft.McFolderType.Original || CS$<>8__locals1.$VB$Local_Folder.Type == ModMinecraft.McFolderType.RenamedOriginal) && Operators.CompareString(CS$<>8__locals1.$VB$Local_Folder.Path, ModBase.Path + ".minecraft\\", true) == 0)
			{
				if (ModMinecraft.collectionIterator.Count == 1)
				{
					$VB$Local_DeleteText = "清空";
					goto IL_9E;
				}
			}
			$VB$Local_DeleteText = "删除";
			IL_9E:
			CS$<>8__locals2.$VB$Local_DeleteText = $VB$Local_DeleteText;
			checked
			{
				if (ModMain.MyMsgBox("你确定要" + CS$<>8__locals1.$VB$Local_DeleteText + "这个文件夹吗？\r\n这会导致该文件夹中的所有存档与其他文件永久消失，且不可恢复！", "删除警告", "取消", "继续", "", false, true, false) != 1 && ModMain.MyMsgBox(CS$<>8__locals1.$VB$Local_DeleteText + "这个文件夹会导致该文件夹中的所有文件永久消失，且不可恢复！\r\n这是最后一次警告！", "删除警告", CS$<>8__locals1.$VB$Local_DeleteText, "取消", "", true, true, false) != 2)
				{
					if (CS$<>8__locals1.$VB$Local_Folder.Type == ModMinecraft.McFolderType.Custom)
					{
						ArrayList arrayList = new ArrayList(ModBase._BaseRule.Get("LaunchFolders", null).ToString().Split(new char[]
						{
							'|'
						}));
						int num = arrayList.Count - 1;
						int i = 0;
						while (i <= num)
						{
							if (!Operators.ConditionalCompareObjectEqual(arrayList[i], "", true))
							{
								if (!arrayList[i].ToString().EndsWith(CS$<>8__locals1.$VB$Local_Folder.Path))
								{
									i++;
									continue;
								}
								arrayList.RemoveAt(i);
							}
							IL_199:
							ModBase._BaseRule.Set("LaunchFolders", (arrayList.Count == 0) ? "" : ModBase.Join(arrayList.ToArray(), "|"), false, null);
							goto IL_1C9;
						}
						goto IL_199;
					}
					IL_1C9:
					ModBase.RunInNewThread(delegate
					{
						try
						{
							ModMain.Hint(string.Concat(new string[]
							{
								"正在",
								CS$<>8__locals1.$VB$Local_DeleteText,
								"文件夹 ",
								CS$<>8__locals1.$VB$Local_Folder.Name,
								"！"
							}), ModMain.HintType.Info, true);
							ModBase.DeleteDirectory(CS$<>8__locals1.$VB$Local_Folder.Path, false);
							if (Operators.CompareString(CS$<>8__locals1.$VB$Local_DeleteText, "清空", true) == 0)
							{
								Directory.CreateDirectory(CS$<>8__locals1.$VB$Local_Folder.Path);
							}
							ModMain.Hint(string.Concat(new string[]
							{
								"已",
								CS$<>8__locals1.$VB$Local_DeleteText,
								"文件夹 ",
								CS$<>8__locals1.$VB$Local_Folder.Name,
								"！"
							}), ModMain.HintType.Finish, true);
						}
						catch (Exception ex)
						{
							ModBase.Log(ex, CS$<>8__locals1.$VB$Local_DeleteText + "文件夹 " + CS$<>8__locals1.$VB$Local_Folder.Name + " 失败", ModBase.LogLevel.Hint, "出现错误");
						}
						finally
						{
							ModMinecraft._TestsIterator.Start(ModBase.GetUuid(), false);
						}
					}, "Folder Delete " + Conversions.ToString(ModBase.GetUuid()), ThreadPriority.BelowNormal);
				}
			}
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x0005EBF4 File Offset: 0x0005CDF4
		public void Open_Click(object sender, RoutedEventArgs e)
		{
			ModBase.OpenExplorer("\"" + ((MyListItem)((Popup)((ContextMenu)NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null)).Parent).PlacementTarget).Info + "\"");
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x0005EC48 File Offset: 0x0005CE48
		public void Refresh_Click(object sender, RoutedEventArgs e)
		{
			ModBase.WriteIni(((MyListItem)((Popup)((ContextMenu)NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null)).Parent).PlacementTarget).Info + "PCL.ini", "VersionCache", "");
			ModMinecraft._TestsIterator.Start(ModBase.GetUuid(), false);
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x0005ECB4 File Offset: 0x0005CEB4
		public void Rename_Click(object sender, RoutedEventArgs e)
		{
			ModMinecraft.McFolder mcFolder = (ModMinecraft.McFolder)((MyListItem)((Popup)((ContextMenu)NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null)).Parent).PlacementTarget).Tag;
			checked
			{
				try
				{
					string text = ModMain.MyMsgBoxInput(mcFolder.Name, new Collection<Validate>
					{
						new ValidateNullOrWhiteSpace(),
						new ValidateLength(1, 0x1E),
						new ValidateExcept(new string[]
						{
							">",
							"|"
						}, "输入内容不能包含 %！")
					}, "", "输入新名称", "确定", "取消", false);
					if (!string.IsNullOrWhiteSpace(text))
					{
						ArrayList arrayList = new ArrayList(ModBase._BaseRule.Get("LaunchFolders", null).ToString().Split(new char[]
						{
							'|'
						}));
						bool flag = false;
						int num = arrayList.Count - 1;
						int i = 0;
						while (i <= num)
						{
							string text2 = Conversions.ToString(arrayList[i]);
							if (Operators.CompareString(text2, "", true) == 0 || Operators.CompareString(text2.Split(new char[]
							{
								'>'
							})[1], mcFolder.Path, true) != 0)
							{
								i++;
							}
							else
							{
								flag = true;
								if (Operators.CompareString(text2.Split(new char[]
								{
									'>'
								})[0], text, true) == 0)
								{
									return;
								}
								arrayList[i] = text + ">" + mcFolder.Path;
								IL_179:
								if (!flag)
								{
									arrayList.Add(text + ">" + mcFolder.Path);
								}
								ModMain.Hint("文件夹名称已更新为 " + text + " ！", ModMain.HintType.Finish, true);
								ModBase._BaseRule.Set("LaunchFolders", ModBase.Join(arrayList.ToArray(), "|"), false, null);
								ModMinecraft._TestsIterator.Start(ModBase.GetUuid(), false);
								return;
							}
						}
						goto IL_179;
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "重命名文件夹失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x0005EEDC File Offset: 0x0005D0DC
		public void Folder_Change(MyListItem sender, ModBase.RouteEventArgs e)
		{
			if (e.schemaMapper && sender.Checked)
			{
				if (ModNet.HasDownloadingTask(true))
				{
					ModMain.Hint("请不要在下载过程中切换游戏文件夹！", ModMain.HintType.Critical, true);
					e._HelperMapper = true;
					return;
				}
				ModBase._BaseRule.Set("LaunchFolderSelect", ((ModMinecraft.McFolder)sender.Tag).Path.Replace(ModBase.Path, "$"), false, null);
				ModMinecraft._TestsIterator.Start(ModBase.GetUuid(), false);
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000B00 RID: 2816 RVA: 0x000080A3 File Offset: 0x000062A3
		// (set) Token: 0x06000B01 RID: 2817 RVA: 0x000080AB File Offset: 0x000062AB
		internal virtual StackPanel PanList { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x06000B02 RID: 2818 RVA: 0x0005EF58 File Offset: 0x0005D158
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.m_PrototypeExpression)
			{
				this.m_PrototypeExpression = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pageselectleft.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x000080B4 File Offset: 0x000062B4
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanList = (StackPanel)target;
				return;
			}
			this.m_PrototypeExpression = true;
		}

		// Token: 0x040005F9 RID: 1529
		private static bool repositoryExpression;

		// Token: 0x040005FA RID: 1530
		private static bool m_SystemExpression;

		// Token: 0x040005FB RID: 1531
		[CompilerGenerated]
		[AccessedThroughProperty("PanList")]
		private StackPanel proccesorExpression;

		// Token: 0x040005FC RID: 1532
		private bool m_PrototypeExpression;
	}
}
