using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace PCL
{
	// Token: 0x020000DC RID: 220
	[StandardModule]
	public sealed class ModDownload
	{
		// Token: 0x06000811 RID: 2065 RVA: 0x0003D744 File Offset: 0x0003B944
		// Note: this type is marked as 'beforefieldinit'.
		static ModDownload()
		{
			ModDownload._AlgoIterator = new ModLoader.LoaderTask<int, ModDownload.DlClientListResult>("DlClientList Main", new ModLoader.LoaderTask<int, ModDownload.DlClientListResult>.LoadDelegateSub(ModDownload.DlClientListMain), null, ThreadPriority.Normal);
			ModDownload.m_MapperIterator = new ModLoader.LoaderTask<int, ModDownload.DlClientListResult>("DlClientList Mojang", new ModLoader.LoaderTask<int, ModDownload.DlClientListResult>.LoadDelegateSub(ModDownload.DlClientListMojangMain), null, ThreadPriority.Normal);
			ModDownload.paramsIterator = false;
			ModDownload.globalIterator = new ModLoader.LoaderTask<int, ModDownload.DlClientListResult>("DlClientList Bmclapi", new ModLoader.LoaderTask<int, ModDownload.DlClientListResult>.LoadDelegateSub(ModDownload.DlClientListBmclapiMain), null, ThreadPriority.Normal);
			ModDownload.issuerIterator = new ModLoader.LoaderTask<int, ModDownload.DlOptiFineListResult>("DlOptiFineList Main", new ModLoader.LoaderTask<int, ModDownload.DlOptiFineListResult>.LoadDelegateSub(ModDownload.DlOptiFineListMain), null, ThreadPriority.Normal);
			ModDownload._OrderIterator = new ModLoader.LoaderTask<int, ModDownload.DlOptiFineListResult>("DlOptiFineList Official", new ModLoader.LoaderTask<int, ModDownload.DlOptiFineListResult>.LoadDelegateSub(ModDownload.DlOptiFineListOfficialMain), null, ThreadPriority.Normal);
			ModDownload.serviceIterator = new ModLoader.LoaderTask<int, ModDownload.DlOptiFineListResult>("DlOptiFineList Bmclapi", new ModLoader.LoaderTask<int, ModDownload.DlOptiFineListResult>.LoadDelegateSub(ModDownload.DlOptiFineListBmclapiMain), null, ThreadPriority.Normal);
			ModDownload.facadeIterator = new ModLoader.LoaderTask<int, ModDownload.DlForgeListResult>("DlForgeList Main", new ModLoader.LoaderTask<int, ModDownload.DlForgeListResult>.LoadDelegateSub(ModDownload.DlForgeListMain), null, ThreadPriority.Normal);
			ModDownload.codeIterator = new ModLoader.LoaderTask<int, ModDownload.DlForgeListResult>("DlForgeList Official", new ModLoader.LoaderTask<int, ModDownload.DlForgeListResult>.LoadDelegateSub(ModDownload.DlForgeListOfficialMain), null, ThreadPriority.Normal);
			ModDownload._MappingIterator = new ModLoader.LoaderTask<int, ModDownload.DlForgeListResult>("DlForgeList Bmclapi", new ModLoader.LoaderTask<int, ModDownload.DlForgeListResult>.LoadDelegateSub(ModDownload.DlForgeListBmclapiMain), null, ThreadPriority.Normal);
			ModDownload.m_BridgeIterator = new ModLoader.LoaderTask<int, ModDownload.DlLiteLoaderListResult>("DlLiteLoaderList Main", new ModLoader.LoaderTask<int, ModDownload.DlLiteLoaderListResult>.LoadDelegateSub(ModDownload.DlLiteLoaderListMain), null, ThreadPriority.Normal);
			ModDownload._SingletonIterator = new ModLoader.LoaderTask<int, ModDownload.DlLiteLoaderListResult>("DlLiteLoaderList Official", new ModLoader.LoaderTask<int, ModDownload.DlLiteLoaderListResult>.LoadDelegateSub(ModDownload.DlLiteLoaderListOfficialMain), null, ThreadPriority.Normal);
			ModDownload._ErrorIterator = new ModLoader.LoaderTask<int, ModDownload.DlLiteLoaderListResult>("DlLiteLoaderList Bmclapi", new ModLoader.LoaderTask<int, ModDownload.DlLiteLoaderListResult>.LoadDelegateSub(ModDownload.DlLiteLoaderListBmclapiMain), null, ThreadPriority.Normal);
			ModDownload.m_ObjectIterator = new ModLoader.LoaderTask<int, ModDownload.DlFabricListResult>("DlFabricList Main", new ModLoader.LoaderTask<int, ModDownload.DlFabricListResult>.LoadDelegateSub(ModDownload.DlFabricListMain), null, ThreadPriority.Normal);
			ModDownload.callbackIterator = new ModLoader.LoaderTask<int, ModDownload.DlFabricListResult>("DlFabricList Official", new ModLoader.LoaderTask<int, ModDownload.DlFabricListResult>.LoadDelegateSub(ModDownload.DlFabricListOfficialMain), null, ThreadPriority.Normal);
			ModDownload.m_WorkerIterator = new ModLoader.LoaderTask<int, ModDownload.DlFabricListResult>("DlFabricList Bmclapi", new ModLoader.LoaderTask<int, ModDownload.DlFabricListResult>.LoadDelegateSub(ModDownload.DlFabricListBmclapiMain), null, ThreadPriority.Normal);
			ModDownload._VisitorIterator = new ModLoader.LoaderTask<int, List<ModDownload.DlCfFile>>("Fabric API List Loader", delegate(ModLoader.LoaderTask<int, List<ModDownload.DlCfFile>> Task)
			{
				Task.Output = ModDownload.DlCfGetFiles(0x4ADB4, false);
			}, null, ThreadPriority.Normal);
			ModDownload._IndexerIterator = null;
			ModDownload._MethodIterator = new ModLoader.LoaderTask<KeyValuePair<int, bool>, List<ModDownload.DlCfFile>>("DlCfFile Main", delegate(ModLoader.LoaderTask<KeyValuePair<int, bool>, List<ModDownload.DlCfFile>> Task)
			{
				Task.Output = ModDownload.DlCfGetFiles(Task.Input.Key, Task.Input.Value);
			}, null, ThreadPriority.Normal);
			ModDownload.m_DatabaseIterator = new Dictionary<int, ModDownload.DlCfProject>();
			ModDownload.attrIterator = new Dictionary<int, List<ModDownload.DlCfFile>>();
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x0003D968 File Offset: 0x0003BB68
		public static ModNet.NetFile DlClientJarGet(ModMinecraft.McVersion Version, bool ReturnNothingOnFileUseable)
		{
			while (!string.IsNullOrEmpty(Version.PrintUtils()))
			{
				Version = new ModMinecraft.McVersion(Version.PrintUtils());
			}
			if (Version.VerifyUtils()["downloads"] != null && Version.VerifyUtils()["downloads"]["client"] != null && Version.VerifyUtils()["downloads"]["client"]["url"] != null)
			{
				ModBase.FileChecker fileChecker = new ModBase.FileChecker(0x400L, (long)(Version.VerifyUtils()["downloads"]["client"]["size"] ?? -1), null, (string)Version.VerifyUtils()["downloads"]["client"]["sha1"], true, false);
				if (ReturnNothingOnFileUseable)
				{
					bool flag = Conversions.ToBoolean(ModBase._BaseRule.Get("LaunchAdvanceAssets", null));
					object left = ModBase._BaseRule.Get("VersionAdvanceAssets", Version);
					if (!Operators.ConditionalCompareObjectEqual(left, 0, true))
					{
						if (Operators.ConditionalCompareObjectEqual(left, 1, true))
						{
							flag = false;
						}
						else if (Operators.ConditionalCompareObjectEqual(left, 2, true))
						{
							flag = true;
						}
					}
					if (flag && File.Exists(Version.Path + Version.Name + ".jar"))
					{
						return null;
					}
					if (fileChecker.Check(Version.Path + Version.Name + ".jar") == null)
					{
						return null;
					}
				}
				string mojangBase = (string)Version.VerifyUtils()["downloads"]["client"]["url"];
				return new ModNet.NetFile(ModDownload.DlSourceLauncherOrMetaGet(mojangBase, true), Version.Path + Version.Name + ".jar", fileChecker);
			}
			throw new Exception("底层版本 " + Version.Name + " 中无 Jar 文件下载信息");
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x0003DB78 File Offset: 0x0003BD78
		public static ModNet.NetFile DlClientAssetIndexGet(ModMinecraft.McVersion Version)
		{
			while (!string.IsNullOrEmpty(Version.PrintUtils()))
			{
				Version = new ModMinecraft.McVersion(Version.PrintUtils());
			}
			JToken jtoken = ModMinecraft.McAssetsGetIndex(Version, true, true);
			string localPath = ModMinecraft.m_ResolverIterator + "assets\\indexes\\" + jtoken["id"].ToString() + ".json";
			ModBase.Log("[Download] 版本 " + Version.Name + " 对应的资源文件索引为 " + jtoken["id"].ToString(), ModBase.LogLevel.Normal, "出现错误");
			string text = (string)(jtoken["url"] ?? "");
			ModNet.NetFile result;
			if (Operators.CompareString(text, "", true) == 0)
			{
				result = null;
			}
			else
			{
				result = new ModNet.NetFile(ModDownload.DlSourceLauncherOrMetaGet(text, false), localPath, new ModBase.FileChecker(-1L, -1L, null, null, false, true));
			}
			return result;
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x0003DC5C File Offset: 0x0003BE5C
		public static ArrayList DlClientFix(ModMinecraft.McVersion Version, bool CheckAssetsHash, ModDownload.AssetsIndexExistsBehaviour AssetsIndexBehaviour, bool SkipAssetsDownloadWhileSetupRequired)
		{
			ArrayList arrayList = new ArrayList();
			ArrayList loaders = new ArrayList
			{
				new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析缺失支持库文件", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
				{
					Task.Output = ModMinecraft.McLibFix(Version, false);
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 1.0
				},
				new ModNet.LoaderDownload("下载支持库文件", new List<ModNet.NetFile>())
				{
					ProgressWeight = 15.0
				}
			};
			arrayList.Add(new ModLoader.LoaderCombo<string>("下载支持库文件（主加载器）", loaders)
			{
				Block = false,
				Show = false,
				ProgressWeight = 16.0
			});
			bool flag = Conversions.ToBoolean(ModBase._BaseRule.Get("LaunchAdvanceAssets", null));
			object left = ModBase._BaseRule.Get("VersionAdvanceAssets", Version);
			if (!Operators.ConditionalCompareObjectEqual(left, 0, true))
			{
				if (Operators.ConditionalCompareObjectEqual(left, 1, true))
				{
					flag = false;
				}
				else if (Operators.ConditionalCompareObjectEqual(left, 2, true))
				{
					flag = true;
				}
			}
			if (flag)
			{
				ModBase.Log("[Download] 已跳过 Assets 下载", ModBase.LogLevel.Normal, "出现错误");
			}
			if (!SkipAssetsDownloadWhileSetupRequired || !flag)
			{
				ArrayList arrayList2 = new ArrayList();
				arrayList2.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析资源文件索引地址", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
				{
					try
					{
						ModNet.NetFile netFile = ModDownload.DlClientAssetIndexGet(Version);
						new FileInfo(netFile.mapRule);
						if (AssetsIndexBehaviour != ModDownload.AssetsIndexExistsBehaviour.AlwaysDownload && netFile.iteratorAlgo.Check(netFile.mapRule) == null)
						{
							Task.Output = new List<ModNet.NetFile>();
						}
						else
						{
							Task.Output = new List<ModNet.NetFile>
							{
								netFile
							};
						}
					}
					catch (Exception innerException)
					{
						throw new Exception("分析资源文件索引地址失败", innerException);
					}
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 0.5,
					Show = false
				});
				arrayList2.Add(new ModNet.LoaderDownload("下载资源文件索引", new List<ModNet.NetFile>())
				{
					ProgressWeight = 2.0
				});
				if (AssetsIndexBehaviour == ModDownload.AssetsIndexExistsBehaviour.DownloadInBackground)
				{
					ArrayList arrayList3 = new ArrayList();
					string TempAddress = null;
					string RealAddress = null;
					arrayList3.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("后台分析资源文件索引地址", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
					{
						ModNet.NetFile netFile = ModDownload.DlClientAssetIndexGet(Version);
						RealAddress = netFile.mapRule;
						TempAddress = ModBase.m_GlobalRule + "Cache\\" + netFile.m_ComposerRule;
						netFile.mapRule = TempAddress;
						Task.Output = new List<ModNet.NetFile>
						{
							netFile
						};
					}, null, ThreadPriority.Normal));
					arrayList3.Add(new ModNet.LoaderDownload("后台下载资源文件索引", new List<ModNet.NetFile>()));
					arrayList3.Add(new ModLoader.LoaderTask<List<ModNet.NetFile>, string>("后台复制资源文件索引", delegate(ModLoader.LoaderTask<List<ModNet.NetFile>, string> Task)
					{
						try
						{
							File.Copy(TempAddress, RealAddress, true);
							ModLaunch.McLaunchLog("后台更新资源文件索引成功：" + TempAddress);
						}
						catch (Exception ex)
						{
							ModBase.Log(ex, "后台更新资源文件索引失败", ModBase.LogLevel.Debug, "出现错误");
							ModLaunch.McLaunchLog("后台更新资源文件索引失败：" + TempAddress);
						}
					}, null, ThreadPriority.Normal));
					ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("后台更新资源文件索引", arrayList3);
					ModBase.Log("[Download] 开始后台更新资源文件索引", ModBase.LogLevel.Normal, "出现错误");
					loaderCombo.Start(null, false);
				}
				arrayList2.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析缺失资源文件", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
				{
					ModLoader.LoaderTask<string, List<ModNet.NetFile>> loaderTask = Task;
					string indexAddress = ModMinecraft.McAssetsGetIndexName(Version);
					bool $VB$Local_CheckAssetsHash = CheckAssetsHash;
					ModLoader.LoaderBase<string> loaderBase = Task;
					List<ModNet.NetFile> output = ModMinecraft.McAssetsFixList<string>(indexAddress, $VB$Local_CheckAssetsHash, ref loaderBase);
					Task = (ModLoader.LoaderTask<string, List<ModNet.NetFile>>)loaderBase;
					loaderTask.Output = output;
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 3.0
				});
				arrayList2.Add(new ModNet.LoaderDownload("下载资源文件", new List<ModNet.NetFile>())
				{
					ProgressWeight = 25.0
				});
				arrayList.Add(new ModLoader.LoaderCombo<string>("下载资源文件（主加载器）", arrayList2)
				{
					Block = false,
					Show = false,
					ProgressWeight = 30.5
				});
			}
			return arrayList;
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x0003DF28 File Offset: 0x0003C128
		private static void DlClientListMain(ModLoader.LoaderTask<int, ModDownload.DlClientListResult> Loader)
		{
			object left = ModBase._BaseRule.Get("ToolDownloadVersion", null);
			if (Operators.ConditionalCompareObjectEqual(left, 0, true))
			{
				ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
				{
					new KeyValuePair<object, int>(ModDownload.globalIterator, 0x1E),
					new KeyValuePair<object, int>(ModDownload.m_MapperIterator, 0x3C)
				});
				return;
			}
			if (Operators.ConditionalCompareObjectEqual(left, 1, true))
			{
				ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
				{
					new KeyValuePair<object, int>(ModDownload.m_MapperIterator, 5),
					new KeyValuePair<object, int>(ModDownload.globalIterator, 0x23)
				});
				return;
			}
			ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
			{
				new KeyValuePair<object, int>(ModDownload.m_MapperIterator, 0x3C),
				new KeyValuePair<object, int>(ModDownload.globalIterator, 0x3C)
			});
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x0003DFF4 File Offset: 0x0003C1F4
		private static void DlClientListMojangMain(ModLoader.LoaderTask<int, ModDownload.DlClientListResult> Loader)
		{
			JObject jobject = (JObject)ModNet.NetGetCodeByRequestRetry("https://launchermeta.mojang.com/mc/game/version_manifest.json", null, "", true);
			try
			{
				JArray jarray = (JArray)jobject["versions"];
				if (jarray.Count < 0xC8)
				{
					throw new Exception("获取到的版本列表长度不足（" + jobject.ToString() + "）");
				}
				if (File.Exists(ModBase.m_GlobalRule + "Cache\\download.json"))
				{
					jarray.Merge(RuntimeHelpers.GetObjectValue(ModBase.GetJson(ModBase.ReadFile(ModBase.m_GlobalRule + "Cache\\download.json"))));
				}
				Loader.Output = new ModDownload.DlClientListResult
				{
					m_ItemAlgo = true,
					m_ManagerAlgo = "Mojang 官方源",
					Value = jobject
				};
				string text = (string)jobject["latest"]["release"];
				if (Conversions.ToBoolean(Conversions.ToBoolean(ModBase._BaseRule.Get("ToolUpdateRelease", null)) && Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase._BaseRule.Get("ToolUpdateReleaseLast", null), "", true))) && text != null && Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase._BaseRule.Get("ToolUpdateReleaseLast", null), text, true)))))
				{
					ModMinecraft.McDownloadClientUpdateHint(text, jobject);
					ModDownload.paramsIterator = true;
				}
				ModBase._BaseRule.Set("ToolUpdateReleaseLast", text, false, null);
				text = (string)jobject["latest"]["snapshot"];
				if (Conversions.ToBoolean(Conversions.ToBoolean(ModBase._BaseRule.Get("ToolUpdateSnapshot", null)) && Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase._BaseRule.Get("ToolUpdateSnapshotLast", null), "", true))) && text != null && Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase._BaseRule.Get("ToolUpdateSnapshotLast", null), text, true))) && !ModDownload.paramsIterator))
				{
					ModMinecraft.McDownloadClientUpdateHint(text, jobject);
				}
				ModBase._BaseRule.Set("ToolUpdateSnapshotLast", text ?? "Nothing", false, null);
			}
			catch (Exception innerException)
			{
				throw new Exception("版本列表解析失败", innerException);
			}
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x0003E24C File Offset: 0x0003C44C
		private static void DlClientListBmclapiMain(ModLoader.LoaderTask<int, ModDownload.DlClientListResult> Loader)
		{
			JObject jobject = (JObject)ModNet.NetGetCodeByRequestRetry("https://bmclapi2.bangbang93.com/mc/game/version_manifest.json", null, "", true);
			try
			{
				JArray jarray = (JArray)jobject["versions"];
				if (jarray.Count < 0xC8)
				{
					throw new Exception("获取到的版本列表长度不足（" + jobject.ToString() + "）");
				}
				if (File.Exists(ModBase.m_GlobalRule + "Cache\\download.json"))
				{
					jarray.Merge(RuntimeHelpers.GetObjectValue(ModBase.GetJson(ModBase.ReadFile(ModBase.m_GlobalRule + "Cache\\download.json"))));
				}
				Loader.Output = new ModDownload.DlClientListResult
				{
					m_ItemAlgo = false,
					m_ManagerAlgo = "BMCLAPI",
					Value = jobject
				};
			}
			catch (Exception innerException)
			{
				throw new Exception("版本列表解析失败（" + jobject.ToString() + "）", innerException);
			}
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x0003E344 File Offset: 0x0003C544
		public static object DlClientListGet(string Id)
		{
			checked
			{
				object result;
				try
				{
					switch (ModDownload._AlgoIterator.State)
					{
					case ModBase.LoadState.Waiting:
					case ModBase.LoadState.Failed:
					case ModBase.LoadState.Aborted:
						PageDownloadClient._IndexerUtils++;
						ModDownload._AlgoIterator.WaitForExit(PageDownloadClient._IndexerUtils, null, false);
						break;
					case ModBase.LoadState.Loading:
						ModDownload._AlgoIterator.WaitForExit(0, null, false);
						break;
					}
					Id = Id.Replace("_", "-");
					if (Operators.CompareString(Id, "1.0", true) != 0 && Id.EndsWith(".0"))
					{
						Id = Strings.Left(Id, Id.Length - 2);
					}
					try
					{
						foreach (JToken jtoken in ((IEnumerable<JToken>)ModDownload._AlgoIterator.Output.Value["versions"]))
						{
							JObject jobject = (JObject)jtoken;
							if ((string)jobject["id"] == Id)
							{
								return jobject["url"].ToString();
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
					ModBase.Log("未发现版本 " + Id + " 的 Json 下载地址，版本列表返回为：\r\n" + ModDownload._AlgoIterator.Output.Value.ToString(), ModBase.LogLevel.Debug, "出现错误");
					result = null;
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "获取版本 " + Id + " 的 Json 下载地址失败", ModBase.LogLevel.Debug, "出现错误");
					result = null;
				}
				return result;
			}
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x0003E4E4 File Offset: 0x0003C6E4
		private static void DlOptiFineListMain(ModLoader.LoaderTask<int, ModDownload.DlOptiFineListResult> Loader)
		{
			object left = ModBase._BaseRule.Get("ToolDownloadVersion", null);
			if (Operators.ConditionalCompareObjectEqual(left, 0, true))
			{
				ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
				{
					new KeyValuePair<object, int>(ModDownload.serviceIterator, 0x1E),
					new KeyValuePair<object, int>(ModDownload._OrderIterator, 0x3C)
				});
				return;
			}
			if (Operators.ConditionalCompareObjectEqual(left, 1, true))
			{
				ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
				{
					new KeyValuePair<object, int>(ModDownload._OrderIterator, 5),
					new KeyValuePair<object, int>(ModDownload.serviceIterator, 0x23)
				});
				return;
			}
			ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
			{
				new KeyValuePair<object, int>(ModDownload._OrderIterator, 0x3C),
				new KeyValuePair<object, int>(ModDownload.serviceIterator, 0x3C)
			});
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x0003E5B0 File Offset: 0x0003C7B0
		private static void DlOptiFineListOfficialMain(ModLoader.LoaderTask<int, ModDownload.DlOptiFineListResult> Loader)
		{
			string text = ModNet.NetGetCodeByClient("https://optifine.net/downloads", Encoding.Default, "application/json, text/javascript, */*; q=0.01");
			if (text.Length < 0xC8)
			{
				throw new Exception("获取到的版本列表长度不足（" + text + "）");
			}
			List<string> list = ModBase.RegexSearch(text, "(?<=Date'>)[^<]+", RegexOptions.None);
			List<string> list2 = ModBase.RegexSearch(text, "(?<=OptiFine_)[0-9A-Za-z_.]+(?=.jar\")", RegexOptions.None);
			if (list.Count != list2.Count)
			{
				throw new Exception("版本与发布时间数据无法对应");
			}
			if (list.Count < 0xA)
			{
				throw new Exception("获取到的版本数量不足（" + text + "）");
			}
			List<ModDownload.DlOptiFineListEntry> list3 = new List<ModDownload.DlOptiFineListEntry>();
			checked
			{
				int num = list.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					list2[i] = list2[i].Replace("_", " ");
					ModDownload.DlOptiFineListEntry dlOptiFineListEntry = new ModDownload.DlOptiFineListEntry();
					dlOptiFineListEntry.m_RepositoryAlgo = list2[i].ToString().Replace("HD U ", "").Replace(".0 ", " ");
					dlOptiFineListEntry.m_ParameterAlgo = ModBase.Join(new string[]
					{
						list[i].Split(new char[]
						{
							'.'
						})[2],
						list[i].Split(new char[]
						{
							'.'
						})[1],
						list[i].Split(new char[]
						{
							'.'
						})[0]
					}, "/");
					dlOptiFineListEntry.m_PrototypeAlgo = list2[i].ToString().ToLower().Contains("pre");
					dlOptiFineListEntry.InvokeExpression(list2[i].ToString().Split(new char[]
					{
						' '
					})[0]);
					dlOptiFineListEntry.m_SystemAlgo = (list2[i].ToString().ToLower().Contains("pre") ? "preview_" : "") + "OptiFine_" + list2[i].ToString().Replace(" ", "_") + ".jar";
					ModDownload.DlOptiFineListEntry dlOptiFineListEntry2 = dlOptiFineListEntry;
					if (Operators.CompareString(dlOptiFineListEntry2.m_RepositoryAlgo, "1.17.1 G9", true) != 0)
					{
						dlOptiFineListEntry2.m_ProccesorAlgo = dlOptiFineListEntry2.SetExpression() + "-OptiFine_" + list2[i].ToString().Replace(" ", "_").Replace(dlOptiFineListEntry2.SetExpression() + "_", "");
						list3.Add(dlOptiFineListEntry2);
					}
				}
				Loader.Output = new ModDownload.DlOptiFineListResult
				{
					_InfoAlgo = true,
					m_SerializerAlgo = "OptiFine 官方源",
					Value = list3
				};
			}
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x0003E878 File Offset: 0x0003CA78
		private static void DlOptiFineListBmclapiMain(ModLoader.LoaderTask<int, ModDownload.DlOptiFineListResult> Loader)
		{
			JArray jarray = (JArray)ModNet.NetGetCodeByRequestRetry("https://bmclapi2.bangbang93.com/optifine/versionList", null, "", true);
			try
			{
				List<ModDownload.DlOptiFineListEntry> list = new List<ModDownload.DlOptiFineListEntry>();
				try
				{
					foreach (JToken jtoken in jarray)
					{
						JObject jobject = (JObject)jtoken;
						ModDownload.DlOptiFineListEntry dlOptiFineListEntry = new ModDownload.DlOptiFineListEntry();
						dlOptiFineListEntry.m_RepositoryAlgo = (jobject["mcversion"].ToString() + jobject["type"].ToString().Replace("HD_U", "").Replace("_", " ") + " " + jobject["patch"].ToString()).Replace(".0 ", " ");
						dlOptiFineListEntry.m_ParameterAlgo = "";
						dlOptiFineListEntry.m_PrototypeAlgo = jobject["patch"].ToString().ToLower().Contains("pre");
						dlOptiFineListEntry.InvokeExpression(jobject["mcversion"].ToString());
						dlOptiFineListEntry.m_SystemAlgo = jobject["filename"].ToString();
						ModDownload.DlOptiFineListEntry dlOptiFineListEntry2 = dlOptiFineListEntry;
						if (Operators.CompareString(dlOptiFineListEntry2.m_RepositoryAlgo, "1.17.1 G9", true) != 0)
						{
							dlOptiFineListEntry2.m_ProccesorAlgo = dlOptiFineListEntry2.SetExpression() + "-OptiFine_" + (jobject["type"].ToString() + " " + jobject["patch"].ToString()).Replace(".0 ", " ").Replace(" ", "_").Replace(dlOptiFineListEntry2.SetExpression() + "_", "");
							list.Add(dlOptiFineListEntry2);
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
				Loader.Output = new ModDownload.DlOptiFineListResult
				{
					_InfoAlgo = false,
					m_SerializerAlgo = "BMCLAPI",
					Value = list
				};
			}
			catch (Exception innerException)
			{
				throw new Exception("版本列表解析失败（" + jarray.ToString() + "）", innerException);
			}
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x0003EAC4 File Offset: 0x0003CCC4
		private static void DlForgeListMain(ModLoader.LoaderTask<int, ModDownload.DlForgeListResult> Loader)
		{
			object left = ModBase._BaseRule.Get("ToolDownloadVersion", null);
			if (Operators.ConditionalCompareObjectEqual(left, 0, true))
			{
				ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
				{
					new KeyValuePair<object, int>(ModDownload._MappingIterator, 0x1E),
					new KeyValuePair<object, int>(ModDownload.codeIterator, 0x3C)
				});
				return;
			}
			if (Operators.ConditionalCompareObjectEqual(left, 1, true))
			{
				ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
				{
					new KeyValuePair<object, int>(ModDownload.codeIterator, 5),
					new KeyValuePair<object, int>(ModDownload._MappingIterator, 0x23)
				});
				return;
			}
			ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
			{
				new KeyValuePair<object, int>(ModDownload.codeIterator, 0x3C),
				new KeyValuePair<object, int>(ModDownload._MappingIterator, 0x3C)
			});
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x0003EB90 File Offset: 0x0003CD90
		private static void DlForgeListOfficialMain(ModLoader.LoaderTask<int, ModDownload.DlForgeListResult> Loader)
		{
			string text = Conversions.ToString(ModNet.NetGetCodeByRequestRetry("http://files.minecraftforge.net/maven/net/minecraftforge/forge/index_1.2.4.html", Encoding.Default, "text/html", false));
			if (text.Length < 0xC8)
			{
				throw new Exception("获取到的版本列表长度不足（" + text + "）");
			}
			List<string> list = ModBase.RegexSearch(text, "(?<=a href=\"index_)[0-9.]+(_pre[0-9]?)?(?=.html)", RegexOptions.None);
			list.Add("1.2.4");
			if (list.Count < 0xA)
			{
				throw new Exception("获取到的版本数量不足（" + text + "）");
			}
			Loader.Output = new ModDownload.DlForgeListResult
			{
				m_AccountAlgo = true,
				stubAlgo = "Forge 官方源",
				Value = list
			};
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x0003EC40 File Offset: 0x0003CE40
		private static void DlForgeListBmclapiMain(ModLoader.LoaderTask<int, ModDownload.DlForgeListResult> Loader)
		{
			string text = Conversions.ToString(ModNet.NetGetCodeByRequestRetry("https://bmclapi2.bangbang93.com/forge/minecraft", Encoding.Default, "", false));
			if (text.Length < 0xC8)
			{
				throw new Exception("获取到的版本列表长度不足（" + text + "）");
			}
			List<string> list = ModBase.RegexSearch(text, "[0-9.]+(_pre[0-9]?)?", RegexOptions.None);
			if (list.Count < 0xA)
			{
				throw new Exception("获取到的版本数量不足（" + text + "）");
			}
			Loader.Output = new ModDownload.DlForgeListResult
			{
				m_AccountAlgo = false,
				stubAlgo = "BMCLAPI",
				Value = list
			};
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x0003ECE4 File Offset: 0x0003CEE4
		public static void DlForgeVersionMain(ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> Loader)
		{
			ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> key = new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>("DlForgeVersion Official", new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>.LoadDelegateSub(ModDownload.DlForgeVersionOfficialMain), null, ThreadPriority.Normal);
			ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> key2 = new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>("DlForgeVersion Bmclapi", new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>.LoadDelegateSub(ModDownload.DlForgeVersionBmclapiMain), null, ThreadPriority.Normal);
			object left = ModBase._BaseRule.Get("ToolDownloadVersion", null);
			if (Operators.ConditionalCompareObjectEqual(left, 0, true))
			{
				ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
				{
					new KeyValuePair<object, int>(key2, 0x1E),
					new KeyValuePair<object, int>(key, 0x3C)
				});
				return;
			}
			if (Operators.ConditionalCompareObjectEqual(left, 1, true))
			{
				ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
				{
					new KeyValuePair<object, int>(key, 5),
					new KeyValuePair<object, int>(key2, 0x23)
				});
				return;
			}
			ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
			{
				new KeyValuePair<object, int>(key, 0x3C),
				new KeyValuePair<object, int>(key2, 0x3C)
			});
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x0003EDC8 File Offset: 0x0003CFC8
		public static void DlForgeVersionOfficialMain(ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> Loader)
		{
			string text;
			try
			{
				text = ModNet.NetGetCodeByDownload("http://files.minecraftforge.net/maven/net/minecraftforge/forge/index_" + Loader.Input + ".html", 0xAFC8, false);
			}
			catch (Exception ex)
			{
				if (ModBase.GetString(ex, true, false).Contains("(404)"))
				{
					throw new Exception("没有可用版本");
				}
				throw;
			}
			if (text.Length < 0x3E8)
			{
				throw new Exception("获取到的版本列表长度不足（" + text + "）");
			}
			List<ModDownload.DlForgeVersionEntry> list = new List<ModDownload.DlForgeVersionEntry>();
			checked
			{
				try
				{
					string[] array = Strings.Mid(text, 1, text.LastIndexOf("</table>")).Replace("<td class=\"download-version", "¨").Split(new char[]
					{
						'¨'
					});
					int num = array.Count<string>() - 1;
					for (int i = 1; i <= num; i++)
					{
						string text2 = array[i];
						try
						{
							string text3 = ModBase.RegexSeek(text2, "(?<=[^(0-9)]+)[0-9\\.]+", RegexOptions.None);
							bool resolverAlgo = text2.Contains("fa promo-recommended");
							string input = Loader.Input;
							string text4 = ModBase.RegexSeek(text2, "(?<=Branch:</strong>[\\s]*)[^<]+", RegexOptions.None);
							text4 = ModBase.RegexSeek(text4 ?? "", "[^\\s]+", RegexOptions.None);
							if (string.IsNullOrWhiteSpace(text4))
							{
								text4 = null;
							}
							if (Operators.CompareString(text3, "11.15.1.2318", true) == 0 || Operators.CompareString(text3, "11.15.1.1902", true) == 0 || Operators.CompareString(text3, "11.15.1.1890", true) == 0)
							{
								text4 = "1.8.9";
							}
							if (text4 == null && Operators.CompareString(input, "1.7.10", true) == 0 && Conversions.ToDouble(text3.Split(new char[]
							{
								'.'
							})[3]) >= 1300.0)
							{
								text4 = "1.7.10";
							}
							string[] array2 = ModBase.RegexSeek(text2, "(?<=\"download-time\" title=\")[^\"]+", RegexOptions.None).Split(" -:".ToCharArray());
							string predicateAlgo = new DateTime(Conversions.ToInteger(array2[0]), Conversions.ToInteger(array2[1]), Conversions.ToInteger(array2[2]), Conversions.ToInteger(array2[3]), Conversions.ToInteger(array2[4]), Conversions.ToInteger(array2[5]), 0, DateTimeKind.Utc).ToLocalTime().ToString("yyyy/MM/dd HH:mm");
							string text5;
							string collectionAlgo;
							if (text2.Contains("classifier-installer\""))
							{
								text2 = text2.Substring(text2.IndexOf("installer.jar"));
								text5 = ModBase.RegexSeek(text2, "(?<=MD5:</strong> )[^<]+", RegexOptions.None);
								collectionAlgo = "installer";
							}
							else if (text2.Contains("classifier-universal\""))
							{
								text2 = text2.Substring(text2.IndexOf("universal.zip"));
								text5 = ModBase.RegexSeek(text2, "(?<=MD5:</strong> )[^<]+", RegexOptions.None);
								collectionAlgo = "universal";
							}
							else
							{
								text2 = text2.Substring(text2.IndexOf("client.zip"));
								text5 = ModBase.RegexSeek(text2, "(?<=MD5:</strong> )[^<]+", RegexOptions.None);
								collectionAlgo = "client";
							}
							list.Add(new ModDownload.DlForgeVersionEntry
							{
								_CollectionAlgo = collectionAlgo,
								_ConfigurationAlgo = text3,
								resolverAlgo = resolverAlgo,
								structAlgo = text5.Trim(new char[]
								{
									'\r',
									'\n'
								}),
								interpreterAlgo = input,
								m_PredicateAlgo = predicateAlgo,
								testsAlgo = text4
							});
						}
						catch (Exception innerException)
						{
							throw new Exception("版本信息提取失败（" + text2 + "）", innerException);
						}
					}
				}
				catch (Exception innerException2)
				{
					throw new Exception("版本列表解析失败（" + text + "）", innerException2);
				}
				if (list.Count == 0)
				{
					throw new Exception("没有可用版本");
				}
				Loader.Output = list;
			}
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x0003F194 File Offset: 0x0003D394
		public static void DlForgeVersionBmclapiMain(ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> Loader)
		{
			JArray jarray = (JArray)ModNet.NetGetCodeByRequestRetry("https://bmclapi2.bangbang93.com/forge/minecraft/" + Loader.Input, null, "", true);
			List<ModDownload.DlForgeVersionEntry> list = new List<ModDownload.DlForgeVersionEntry>();
			try
			{
				string left = ModDownloadLib.McDownloadForgeRecommendedGet(Loader.Input);
				try
				{
					foreach (JToken jtoken in jarray)
					{
						JObject jobject = (JObject)jtoken;
						string structAlgo = null;
						string collectionAlgo = "unknown";
						int num = -1;
						try
						{
							foreach (JToken jtoken2 in ((IEnumerable<JToken>)jobject["files"]))
							{
								JObject jobject2 = (JObject)jtoken2;
								string left2 = jobject2["category"].ToString();
								if (Operators.CompareString(left2, "installer", true) == 0)
								{
									if (Operators.CompareString(jobject2["format"].ToString(), "jar", true) == 0)
									{
										structAlgo = (string)jobject2["hash"];
										collectionAlgo = "installer";
										num = 2;
									}
								}
								else if (Operators.CompareString(left2, "universal", true) == 0)
								{
									if (num <= 1 && Operators.CompareString(jobject2["format"].ToString(), "zip", true) == 0)
									{
										structAlgo = (string)jobject2["hash"];
										collectionAlgo = "universal";
										num = 1;
									}
								}
								else if (Operators.CompareString(left2, "client", true) == 0 && num <= 0 && Operators.CompareString(jobject2["format"].ToString(), "zip", true) == 0)
								{
									structAlgo = (string)jobject2["hash"];
									collectionAlgo = "client";
									num = 0;
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
						string input = Loader.Input;
						string text = (string)jobject["branch"];
						string text2 = (string)jobject["version"];
						if (Operators.CompareString(text2, "11.15.1.2318", true) == 0 || Operators.CompareString(text2, "11.15.1.1902", true) == 0 || Operators.CompareString(text2, "11.15.1.1890", true) == 0)
						{
							text = "1.8.9";
						}
						if (text == null && Operators.CompareString(input, "1.7.10", true) == 0 && Conversions.ToDouble(text2.Split(new char[]
						{
							'.'
						})[3]) >= 1300.0)
						{
							text = "1.7.10";
						}
						ModDownload.DlForgeVersionEntry dlForgeVersionEntry = new ModDownload.DlForgeVersionEntry
						{
							structAlgo = structAlgo,
							_CollectionAlgo = collectionAlgo,
							_ConfigurationAlgo = text2,
							testsAlgo = text,
							interpreterAlgo = input,
							resolverAlgo = (Operators.CompareString(left, text2, true) == 0)
						};
						jobject["modified"].ToString().Split(new char[]
						{
							'-',
							'T',
							':',
							'.',
							' ',
							'/'
						});
						dlForgeVersionEntry.m_PredicateAlgo = jobject["modified"].ToObject<DateTime>().ToLocalTime().ToString("yyyy/MM/dd HH:mm");
						list.Add(dlForgeVersionEntry);
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
			}
			catch (Exception innerException)
			{
				throw new Exception("版本列表解析失败（" + jarray.ToString() + "）", innerException);
			}
			if (list.Count == 0)
			{
				throw new Exception("没有可用版本");
			}
			Loader.Output = list;
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x0003F528 File Offset: 0x0003D728
		private static void DlLiteLoaderListMain(ModLoader.LoaderTask<int, ModDownload.DlLiteLoaderListResult> Loader)
		{
			object left = ModBase._BaseRule.Get("ToolDownloadVersion", null);
			if (Operators.ConditionalCompareObjectEqual(left, 0, true))
			{
				ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
				{
					new KeyValuePair<object, int>(ModDownload._ErrorIterator, 0x1E),
					new KeyValuePair<object, int>(ModDownload._SingletonIterator, 0x3C)
				});
				return;
			}
			if (Operators.ConditionalCompareObjectEqual(left, 1, true))
			{
				ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
				{
					new KeyValuePair<object, int>(ModDownload._SingletonIterator, 5),
					new KeyValuePair<object, int>(ModDownload._ErrorIterator, 0x23)
				});
				return;
			}
			ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
			{
				new KeyValuePair<object, int>(ModDownload._SingletonIterator, 0x3C),
				new KeyValuePair<object, int>(ModDownload._ErrorIterator, 0x3C)
			});
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x0003F5F4 File Offset: 0x0003D7F4
		private static void DlLiteLoaderListOfficialMain(ModLoader.LoaderTask<int, ModDownload.DlLiteLoaderListResult> Loader)
		{
			JObject jobject = (JObject)ModNet.NetGetCodeByRequestRetry("http://dl.liteloader.com/versions/versions.json", null, "", true);
			try
			{
				JObject jobject2 = (JObject)jobject["versions"];
				List<ModDownload.DlLiteLoaderListEntry> list = new List<ModDownload.DlLiteLoaderListEntry>();
				try
				{
					foreach (KeyValuePair<string, JToken> keyValuePair in jobject2)
					{
						if (!keyValuePair.Key.StartsWith("1.6") && !keyValuePair.Key.StartsWith("1.5"))
						{
							JToken jtoken = (keyValuePair.Value["artefacts"] ?? keyValuePair.Value["snapshots"])["com.mumfrey:liteloader"]["latest"];
							list.Add(new ModDownload.DlLiteLoaderListEntry
							{
								Inherit = keyValuePair.Key,
								IsLegacy = (Conversions.ToDouble(keyValuePair.Key.Split(new char[]
								{
									'.'
								})[1]) < 8.0),
								IsPreview = (Operators.CompareString(jtoken["stream"].ToString().ToLower(), "snapshot", true) == 0),
								FileName = "liteloader-installer-" + keyValuePair.Key + ((Operators.CompareString(keyValuePair.Key, "1.8", true) == 0 || Operators.CompareString(keyValuePair.Key, "1.9", true) == 0) ? ".0" : "") + "-00-SNAPSHOT.jar",
								MD5 = (string)jtoken["md5"],
								ReleaseTime = ModBase.GetLocalTime(ModBase.GetDate((int)jtoken["timestamp"])).ToString("yyyy/MM/dd HH:mm:ss"),
								JsonToken = jtoken
							});
						}
					}
				}
				finally
				{
					IEnumerator<KeyValuePair<string, JToken>> enumerator;
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
				Loader.Output = new ModDownload.DlLiteLoaderListResult
				{
					IsOfficial = true,
					SourceName = "LiteLoader 官方源",
					Value = list
				};
			}
			catch (Exception innerException)
			{
				throw new Exception("版本列表解析失败（" + jobject.ToString() + "）", innerException);
			}
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x0003F864 File Offset: 0x0003DA64
		private static void DlLiteLoaderListBmclapiMain(ModLoader.LoaderTask<int, ModDownload.DlLiteLoaderListResult> Loader)
		{
			JObject jobject = (JObject)ModNet.NetGetCodeByRequestRetry("https://bmclapi2.bangbang93.com/maven/com/mumfrey/liteloader/versions.json", null, "", true);
			try
			{
				JObject jobject2 = (JObject)jobject["versions"];
				List<ModDownload.DlLiteLoaderListEntry> list = new List<ModDownload.DlLiteLoaderListEntry>();
				try
				{
					foreach (KeyValuePair<string, JToken> keyValuePair in jobject2)
					{
						if (!keyValuePair.Key.StartsWith("1.6") && !keyValuePair.Key.StartsWith("1.5"))
						{
							JToken jtoken = (keyValuePair.Value["artefacts"] ?? keyValuePair.Value["snapshots"])["com.mumfrey:liteloader"]["latest"];
							list.Add(new ModDownload.DlLiteLoaderListEntry
							{
								Inherit = keyValuePair.Key,
								IsLegacy = (Conversions.ToDouble(keyValuePair.Key.Split(new char[]
								{
									'.'
								})[1]) < 8.0),
								IsPreview = (Operators.CompareString(jtoken["stream"].ToString().ToLower(), "snapshot", true) == 0),
								FileName = "liteloader-installer-" + keyValuePair.Key + ((Operators.CompareString(keyValuePair.Key, "1.8", true) == 0 || Operators.CompareString(keyValuePair.Key, "1.9", true) == 0) ? ".0" : "") + "-00-SNAPSHOT.jar",
								MD5 = (string)jtoken["md5"],
								ReleaseTime = ModBase.GetLocalTime(ModBase.GetDate((int)jtoken["timestamp"])).ToString("yyyy/MM/dd HH:mm:ss"),
								JsonToken = jtoken
							});
						}
					}
				}
				finally
				{
					IEnumerator<KeyValuePair<string, JToken>> enumerator;
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
				Loader.Output = new ModDownload.DlLiteLoaderListResult
				{
					IsOfficial = false,
					SourceName = "BMCLAPI",
					Value = list
				};
			}
			catch (Exception innerException)
			{
				throw new Exception("版本列表解析失败（" + jobject.ToString() + "）", innerException);
			}
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0003FAD4 File Offset: 0x0003DCD4
		private static void DlFabricListMain(ModLoader.LoaderTask<int, ModDownload.DlFabricListResult> Loader)
		{
			object left = ModBase._BaseRule.Get("ToolDownloadVersion", null);
			if (Operators.ConditionalCompareObjectEqual(left, 0, true))
			{
				ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
				{
					new KeyValuePair<object, int>(ModDownload.m_WorkerIterator, 0x1E),
					new KeyValuePair<object, int>(ModDownload.callbackIterator, 0x3C)
				});
				return;
			}
			if (Operators.ConditionalCompareObjectEqual(left, 1, true))
			{
				ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
				{
					new KeyValuePair<object, int>(ModDownload.callbackIterator, 5),
					new KeyValuePair<object, int>(ModDownload.m_WorkerIterator, 0x23)
				});
				return;
			}
			ModDownload.DlSourceLoader(Loader, new List<KeyValuePair<object, int>>
			{
				new KeyValuePair<object, int>(ModDownload.callbackIterator, 0x3C),
				new KeyValuePair<object, int>(ModDownload.m_WorkerIterator, 0x3C)
			});
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x0003FBA0 File Offset: 0x0003DDA0
		private static void DlFabricListOfficialMain(ModLoader.LoaderTask<int, ModDownload.DlFabricListResult> Loader)
		{
			JObject jobject = (JObject)ModNet.NetGetCodeByRequestRetry("https://meta.fabricmc.net/v2/versions", null, "", true);
			try
			{
				ModDownload.DlFabricListResult dlFabricListResult = new ModDownload.DlFabricListResult
				{
					fieldAlgo = true,
					m_BroadcasterAlgo = "Fabric 官方源",
					Value = jobject
				};
				if (dlFabricListResult.Value["game"] == null || dlFabricListResult.Value["loader"] == null || dlFabricListResult.Value["installer"] == null)
				{
					throw new Exception("获取到的列表缺乏必要项");
				}
				Loader.Output = dlFabricListResult;
			}
			catch (Exception innerException)
			{
				throw new Exception("列表解析失败（" + jobject.ToString() + "）", innerException);
			}
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x0003FC68 File Offset: 0x0003DE68
		private static void DlFabricListBmclapiMain(ModLoader.LoaderTask<int, ModDownload.DlFabricListResult> Loader)
		{
			JObject jobject = (JObject)ModNet.NetGetCodeByRequestRetry("https://bmclapi2.bangbang93.com/fabric-meta/v2/versions", null, "", true);
			try
			{
				ModDownload.DlFabricListResult dlFabricListResult = new ModDownload.DlFabricListResult
				{
					fieldAlgo = false,
					m_BroadcasterAlgo = "BMCLAPI",
					Value = jobject
				};
				if (dlFabricListResult.Value["game"] == null || dlFabricListResult.Value["loader"] == null || dlFabricListResult.Value["installer"] == null)
				{
					throw new Exception("获取到的列表缺乏必要项");
				}
				Loader.Output = dlFabricListResult;
			}
			catch (Exception innerException)
			{
				throw new Exception("列表解析失败（" + jobject.ToString() + "）", innerException);
			}
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x0003FD30 File Offset: 0x0003DF30
		public static void DlCfProjectSub(ModLoader.LoaderTask<ModDownload.DlCfProjectRequest, List<ModDownload.DlCfProject>> Task)
		{
			string text = Task.Input.m_ProxyAlgo ?? "";
			Task.Input.m_ProxyAlgo = text;
			ModBase.Log("[Download] CurseForge 工程列表搜索原始文本：" + text, ModBase.LogLevel.Normal, "出现错误");
			checked
			{
				bool flag;
				if ((flag = ModBase.RegexCheck(text, "[\\u4e00-\\u9fbb]", RegexOptions.None)) && !string.IsNullOrEmpty(text))
				{
					if (Task.Input.m_RequestAlgo)
					{
						throw new Exception("整合包搜索仅支持英文");
					}
					if (ModDownload._IndexerIterator == null)
					{
						ModDownload._IndexerIterator = (JObject)ModBase.GetJson(ModBase.DecodeBytes(ModBase.GetResources("ModData")));
					}
					List<ModBase.SearchEntry<string>> list = new List<ModBase.SearchEntry<string>>();
					try
					{
						foreach (KeyValuePair<string, JToken> keyValuePair in ModDownload._IndexerIterator)
						{
							if (!keyValuePair.Value.ToString().Contains("动态的树"))
							{
								list.Add(new ModBase.SearchEntry<string>
								{
									m_ParamMapper = keyValuePair.Value.ToString().Split(new char[]
									{
										'|'
									})[1],
									mockMapper = new List<KeyValuePair<string, double>>
									{
										new KeyValuePair<string, double>(keyValuePair.Value.ToString().Replace(" (", "|").Split(new char[]
										{
											'|'
										})[1], 1.0)
									}
								});
							}
						}
					}
					finally
					{
						IEnumerator<KeyValuePair<string, JToken>> enumerator;
						if (enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					List<ModBase.SearchEntry<string>> list2 = ModBase.Search<string>(list, Task.Input.m_ProxyAlgo, 3, 0.1);
					if (list2.Count == 0)
					{
						throw new Exception("无搜索结果，请尝试搜索英文名称");
					}
					string text2 = "";
					int num = Math.Min(2, list2.Count - 1);
					for (int i = 0; i <= num; i++)
					{
						text2 = text2 + list2[i].m_ParamMapper.Replace(" (", "|").Split(new char[]
						{
							'|'
						}).Last<string>().TrimEnd(new char[]
						{
							')'
						}) + " ";
					}
					ModBase.Log("[Download] CurseForge 工程列表中文搜索原始关键词：" + text2, ModBase.LogLevel.Developer, "出现错误");
					string text3 = "";
					foreach (string text4 in text2.Split(new char[]
					{
						' '
					}))
					{
						if (!new string[]
						{
							"the",
							"of",
							"a"
						}.Contains(text4.ToLower()))
						{
							text3 = text3 + text4 + " ";
						}
					}
					Task.Input.m_ProxyAlgo = text3;
					ModBase.Log("[Download] CurseForge 工程列表中文搜索最终关键词：" + text3, ModBase.LogLevel.Developer, "出现错误");
				}
				string str = ModBase.RegexReplace(Task.Input.m_ProxyAlgo, "$& ", "([A-Z]+|[a-z]+?)(?=[A-Z]+[a-z]+[a-z ]*)", RegexOptions.None);
				string str2 = Task.Input.m_ProxyAlgo.Replace(" ", "");
				string text5 = str + " " + (flag ? Task.Input.m_ProxyAlgo : (str2 + " " + text));
				List<string> list3 = new List<string>();
				foreach (string text6 in text5.Split(new char[]
				{
					' '
				}))
				{
					if (Operators.CompareString(text6.Trim(), "", true) != 0)
					{
						list3.Add(text6);
					}
				}
				Task.Input.m_ProxyAlgo = ModBase.Join(ModBase.ArrayNoDouble<string>(list3, null), " ").ToLower();
				ModBase.Log("[Download] CurseForge 工程列表搜索最终文本：" + Task.Input.m_ProxyAlgo, ModBase.LogLevel.Developer, "出现错误");
				string address = Task.Input.GetAddress();
				ModBase.Log("[Download] 开始获取 CurseForge 工程列表：" + address, ModBase.LogLevel.Normal, "出现错误");
				List<ModDownload.DlCfProject> list4 = ModDownload.GetCfProjectListFromJson((JArray)ModNet.NetGetCodeByRequestMuity(address, Encoding.UTF8, "", true), Task.Input.m_RequestAlgo);
				if (list4.Count == 0)
				{
					throw new Exception("无搜索结果");
				}
				if (Task.Input.merchantAlgo == 0 && !string.IsNullOrEmpty(Task.Input.m_ProxyAlgo))
				{
					Dictionary<ModDownload.DlCfProject, double> dictionary = new Dictionary<ModDownload.DlCfProject, double>();
					List<ModBase.SearchEntry<ModDownload.DlCfProject>> list5 = new List<ModBase.SearchEntry<ModDownload.DlCfProject>>();
					int count = list4.Count;
					for (int l = 1; l <= count; l++)
					{
						ModDownload.DlCfProject dlCfProject = list4[l - 1];
						dictionary.Add(dlCfProject, unchecked(1.0 - (double)l / (double)list4.Count));
						list5.Add(new ModBase.SearchEntry<ModDownload.DlCfProject>
						{
							m_ParamMapper = dlCfProject,
							mockMapper = new List<KeyValuePair<string, double>>
							{
								new KeyValuePair<string, double>(flag ? dlCfProject.NewExpression() : dlCfProject.Name, 1.0),
								new KeyValuePair<string, double>(dlCfProject._ComparatorAlgo, 0.05)
							}
						});
					}
					List<ModBase.SearchEntry<ModDownload.DlCfProject>> list6 = ModBase.Search<ModDownload.DlCfProject>(list5, text, 0x65, -1.0);
					try
					{
						foreach (ModBase.SearchEntry<ModDownload.DlCfProject> searchEntry in list6)
						{
							Dictionary<ModDownload.DlCfProject, double> dictionary2;
							ModDownload.DlCfProject paramMapper;
							(dictionary2 = dictionary)[paramMapper = searchEntry.m_ParamMapper] = unchecked(dictionary2[paramMapper] + searchEntry.specificationMapper / list6[0].specificationMapper);
						}
					}
					finally
					{
						List<ModBase.SearchEntry<ModDownload.DlCfProject>>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
					List<KeyValuePair<ModDownload.DlCfProject, double>> list7 = ModBase.Sort<KeyValuePair<ModDownload.DlCfProject, double>>(dictionary.ToList<KeyValuePair<ModDownload.DlCfProject, double>>(), (ModDownload._Closure$__.$IR52-1 == null) ? (ModDownload._Closure$__.$IR52-1 = ((object a0, object a1) => ((ModDownload._Closure$__.$I52-0 == null) ? (ModDownload._Closure$__.$I52-0 = ((KeyValuePair<ModDownload.DlCfProject, double> Left, KeyValuePair<ModDownload.DlCfProject, double> Right) => Left.Value > Right.Value)) : ModDownload._Closure$__.$I52-0)((a0 != null) ? ((KeyValuePair<ModDownload.DlCfProject, double>)a0) : default(KeyValuePair<ModDownload.DlCfProject, double>), (a1 != null) ? ((KeyValuePair<ModDownload.DlCfProject, double>)a1) : default(KeyValuePair<ModDownload.DlCfProject, double>)))) : ModDownload._Closure$__.$IR52-1);
					list4 = new List<ModDownload.DlCfProject>();
					try
					{
						foreach (KeyValuePair<ModDownload.DlCfProject, double> keyValuePair2 in list7)
						{
							list4.Add(keyValuePair2.Key);
						}
					}
					finally
					{
						List<KeyValuePair<ModDownload.DlCfProject, double>>.Enumerator enumerator3;
						((IDisposable)enumerator3).Dispose();
					}
				}
				Task.Output = list4;
			}
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x00040348 File Offset: 0x0003E548
		private static List<ModDownload.DlCfProject> GetCfProjectListFromJson(JArray Json, bool IsModPack)
		{
			List<ModDownload.DlCfProject> list = new List<ModDownload.DlCfProject>();
			try
			{
				foreach (JToken jtoken in Json)
				{
					JObject jobject = (JObject)jtoken;
					if (jobject["isAvailable"] != null && jobject["websiteUrl"] != null)
					{
						if (jobject["isAvailable"].ToObject<bool>())
						{
							if (IsModPack == jobject["websiteUrl"].ToString().Contains("curseforge.com/minecraft/mc-mods"))
							{
								ModBase.Log("[Download] 返回的工程与要求的类别不一致：" + jobject["websiteUrl"].ToString(), ModBase.LogLevel.Debug, "出现错误");
							}
							else
							{
								list.Add(new ModDownload.DlCfProject(jobject));
							}
						}
					}
					else
					{
						ModBase.Log("[Download] 发现关键项为 Nothing 的工程：" + (jobject ?? "").ToString(), ModBase.LogLevel.Debug, "出现错误");
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
			return list;
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x00040440 File Offset: 0x0003E640
		public static List<ModDownload.DlCfFile> DlCfGetFiles(int ProjectId, bool IsModPack)
		{
			List<ModDownload.DlCfFile> result;
			if (ModDownload.attrIterator.ContainsKey(ProjectId))
			{
				result = ModDownload.attrIterator[ProjectId];
			}
			else
			{
				ModBase.Log("[Download] 开始获取 CurseForge 工程 ID 为 " + Conversions.ToString(ProjectId) + " 的文件列表", ModBase.LogLevel.Normal, "出现错误");
				JArray jarray = (JArray)ModNet.NetGetCodeByRequestMuity("https://addons-ecs.forgesvc.net/api/v2/addon/" + Conversions.ToString(ProjectId) + "/files", Encoding.UTF8, "", true);
				List<ModDownload.DlCfFile> list = new List<ModDownload.DlCfFile>();
				try
				{
					foreach (JToken jtoken in jarray)
					{
						JObject jobject = (JObject)jtoken;
						JToken jtoken2 = jobject["isAvailable"];
						if (jtoken2 != null && jtoken2.ToObject<bool>())
						{
							ModDownload.DlCfFile dlCfFile = new ModDownload.DlCfFile(jobject, IsModPack);
							if (dlCfFile.AssetExpression())
							{
								list.Add(dlCfFile);
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
				if (!IsModPack)
				{
					List<int> list2 = new List<int>();
					try
					{
						foreach (ModDownload.DlCfFile dlCfFile2 in list)
						{
							try
							{
								foreach (int num in dlCfFile2.observerAlgo)
								{
									if (!list2.Contains(num) && !ModDownload.m_DatabaseIterator.ContainsKey(num))
									{
										list2.Add(num);
									}
								}
							}
							finally
							{
								List<int>.Enumerator enumerator3;
								((IDisposable)enumerator3).Dispose();
							}
						}
					}
					finally
					{
						List<ModDownload.DlCfFile>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
					if (list2.Count != 0)
					{
						ModBase.Log("[Download] 文件列表中需要获取的前置 Mod：" + ModBase.Join(list2, "，"), ModBase.LogLevel.Normal, "出现错误");
						List<ModDownload.DlCfProject> cfProjectListFromJson = ModDownload.GetCfProjectListFromJson((JArray)ModBase.GetJson(Conversions.ToString(ModNet.NetRequestMuity("https://addons-ecs.forgesvc.net/api/v2/addon", "POST", "[" + ModBase.Join(list2, ",") + "]", "application/json", 5, null))), false);
						try
						{
							foreach (ModDownload.DlCfProject dlCfProject in cfProjectListFromJson)
							{
								ModBase.Log("[Download] 获取到的前置 Mod 信息：" + Conversions.ToString(dlCfProject._PrinterAlgo) + " - " + dlCfProject.Name, ModBase.LogLevel.Normal, "出现错误");
								ModBase.DictionaryAdd<int, ModDownload.DlCfProject>(ref ModDownload.m_DatabaseIterator, dlCfProject._PrinterAlgo, dlCfProject);
							}
						}
						finally
						{
							List<ModDownload.DlCfProject>.Enumerator enumerator4;
							((IDisposable)enumerator4).Dispose();
						}
					}
				}
				ModBase.DictionaryAdd<int, List<ModDownload.DlCfFile>>(ref ModDownload.attrIterator, ProjectId, list);
				result = list;
			}
			return result;
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x000406D0 File Offset: 0x0003E8D0
		public static void DlCfFilesPreload(StackPanel Stack, List<ModDownload.DlCfFile> Entrys, MyListItem.ClickEventHandler OnClick)
		{
			List<int> list = new List<int>();
			try
			{
				foreach (ModDownload.DlCfFile dlCfFile in Entrys)
				{
					try
					{
						foreach (int num in (dlCfFile.observerAlgo ?? new List<int>()))
						{
							if (!list.Contains(num))
							{
								if (!ModDownload.m_DatabaseIterator.ContainsKey(num))
								{
									ModBase.Log("[Download] 未找到 ID 为 " + Conversions.ToString(num) + " 的前置 Mod 信息", ModBase.LogLevel.Developer, "出现错误");
								}
								else
								{
									list.Add(num);
								}
							}
						}
					}
					finally
					{
						List<int>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
				}
			}
			finally
			{
				List<ModDownload.DlCfFile>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			list.Remove(0x4ADB4);
			if (list.Count != 0)
			{
				list.Sort();
				Stack.Children.Add(new TextBlock
				{
					Text = "前置 Mod",
					FontSize = 14.0,
					HorizontalAlignment = HorizontalAlignment.Left,
					Margin = new Thickness(6.0, 2.0, 0.0, 5.0)
				});
				try
				{
					foreach (int key in list)
					{
						ModDownload.DlCfProject dlCfProject = ModDownload.m_DatabaseIterator[key];
						ModDownload._Closure$__R59-1 CS$<>8__locals1 = new ModDownload._Closure$__R59-1(CS$<>8__locals1);
						CS$<>8__locals1.$VB$NonLocal_2 = ModMain.m_TestFilter;
						MyCfItem element = dlCfProject.ToCfItem(delegate(object sender, MouseButtonEventArgs e)
						{
							CS$<>8__locals1.$VB$NonLocal_2.ProjectClick((MyCfItem)sender, e);
						});
						Stack.Children.Add(element);
					}
				}
				finally
				{
					List<int>.Enumerator enumerator3;
					((IDisposable)enumerator3).Dispose();
				}
				Stack.Children.Add(new TextBlock
				{
					Text = "可选版本",
					FontSize = 14.0,
					HorizontalAlignment = HorizontalAlignment.Left,
					Margin = new Thickness(6.0, 12.0, 0.0, 5.0)
				});
			}
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x00040908 File Offset: 0x0003EB08
		public static string[] DlSourceResourceGet(string MojangBase)
		{
			return new string[]
			{
				MojangBase.Replace("http://resources.download.minecraft.net", "https://download.mcbbs.net/assets"),
				MojangBase,
				MojangBase.Replace("http://resources.download.minecraft.net", "https://mcres.mirrors.tmysam.top"),
				MojangBase.Replace("http://resources.download.minecraft.net", "https://bmclapi2.bangbang93.com/assets")
			};
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x00040958 File Offset: 0x0003EB58
		public static string[] DlSourceLibraryGet(string MojangBase)
		{
			return new string[]
			{
				MojangBase.Replace("https://libraries.minecraft.net", "https://download.mcbbs.net/maven"),
				MojangBase.Replace("https://libraries.minecraft.net", "https://download.mcbbs.net/libraries"),
				MojangBase,
				MojangBase.Replace("https://libraries.minecraft.net", "https://mclib.mirrors.tmysam.top"),
				MojangBase.Replace("https://libraries.minecraft.net", "https://bmclapi2.bangbang93.com/maven"),
				MojangBase.Replace("https://libraries.minecraft.net", "https://bmclapi2.bangbang93.com/libraries")
			};
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x000409D0 File Offset: 0x0003EBD0
		public static string[] DlSourceLauncherOrMetaGet(string MojangBase, bool IsStatic = true)
		{
			if (MojangBase == null)
			{
				throw new Exception("无对应的 Json 下载地址");
			}
			string[] result;
			if (IsStatic)
			{
				result = new string[]
				{
					MojangBase.Replace("https://launcher.mojang.com", "https://download.mcbbs.net").Replace("https://launchermeta.mojang.com", "https://download.mcbbs.net"),
					MojangBase,
					MojangBase.Replace("https://launcher.mojang.com", "https://mc.mirrors.tmysam.top").Replace("https://launchermeta.mojang.com", "https://mc.mirrors.tmysam.top"),
					MojangBase.Replace("https://launcher.mojang.com", "https://bmclapi2.bangbang93.com").Replace("https://launchermeta.mojang.com", "https://bmclapi2.bangbang93.com")
				};
			}
			else
			{
				result = new string[]
				{
					MojangBase.Replace("https://launcher.mojang.com", "https://download.mcbbs.net").Replace("https://launchermeta.mojang.com", "https://download.mcbbs.net"),
					MojangBase,
					MojangBase.Replace("https://launcher.mojang.com", "https://bmclapi2.bangbang93.com").Replace("https://launchermeta.mojang.com", "https://bmclapi2.bangbang93.com")
				};
			}
			return result;
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x00040AB4 File Offset: 0x0003ECB4
		private static void DlSourceLoader(object MainLoader, List<KeyValuePair<object, int>> LoaderList)
		{
			int num = 0;
			checked
			{
				for (;;)
				{
					IL_312:
					bool flag = true;
					try
					{
						foreach (KeyValuePair<object, int> keyValuePair in LoaderList)
						{
							if (!Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(keyValuePair.Key, null, "Input", new object[0], null, null, null), NewLateBinding.LateGet(MainLoader, null, "Input", new object[0], null, null, null), true))
							{
								if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(keyValuePair.Key, null, "State", new object[0], null, null, null), ModBase.LoadState.Failed, true))
								{
									flag = false;
								}
								if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(keyValuePair.Key, null, "State", new object[0], null, null, null), ModBase.LoadState.Finished, true))
								{
									NewLateBinding.LateSet(MainLoader, null, "Output", new object[]
									{
										NewLateBinding.LateGet(keyValuePair.Key, null, "Output", new object[0], null, null, null)
									}, null, null);
									ModDownload.DlSourceLoaderAbort(LoaderList);
									return;
								}
								if (flag && num < keyValuePair.Value * 0x64)
								{
									num = keyValuePair.Value * 0x64;
								}
								if (NewLateBinding.LateGet(keyValuePair.Key, null, "Error", new object[0], null, null, null) != null && ((Exception)NewLateBinding.LateGet(keyValuePair.Key, null, "Error", new object[0], null, null, null)).Message.Contains("没有可用版本"))
								{
									try
									{
										foreach (KeyValuePair<object, int> keyValuePair2 in LoaderList)
										{
											if (num < keyValuePair2.Value * 0x64)
											{
												num = keyValuePair2.Value * 0x64;
											}
										}
									}
									finally
									{
										List<KeyValuePair<object, int>>.Enumerator enumerator2;
										((IDisposable)enumerator2).Dispose();
									}
								}
							}
						}
					}
					finally
					{
						List<KeyValuePair<object, int>>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					if (num == 0)
					{
						object[] array;
						bool[] array2;
						NewLateBinding.LateCall(LoaderList[0].Key, null, "Start", array = new object[]
						{
							NewLateBinding.LateGet(MainLoader, null, "Input", new object[0], null, null, null)
						}, null, null, array2 = new bool[]
						{
							true
						}, true);
						if (array2[0])
						{
							NewLateBinding.LateSetComplex(MainLoader, null, "Input", new object[]
							{
								array[0]
							}, null, null, true, false);
						}
					}
					int num2 = LoaderList.Count - 1;
					int i = 0;
					while (i <= num2)
					{
						if (num == LoaderList[i].Value * 0x64)
						{
							if (i >= LoaderList.Count - 1)
							{
								goto IL_320;
							}
							object[] array;
							bool[] array2;
							NewLateBinding.LateCall(LoaderList[i + 1].Key, null, "Start", array = new object[]
							{
								NewLateBinding.LateGet(MainLoader, null, "Input", new object[0], null, null, null)
							}, null, null, array2 = new bool[]
							{
								true
							}, true);
							if (array2[0])
							{
								NewLateBinding.LateSetComplex(MainLoader, null, "Input", new object[]
								{
									array[0]
								}, null, null, true, false);
							}
							IL_2EB:
							if (!Conversions.ToBoolean(NewLateBinding.LateGet(MainLoader, null, "IsAborted", new object[0], null, null, null)))
							{
								Thread.Sleep(0xA);
								num++;
								goto IL_312;
							}
							goto IL_319;
						}
						else
						{
							i++;
						}
					}
					goto IL_2EB;
				}
				IL_319:
				ModDownload.DlSourceLoaderAbort(LoaderList);
				return;
				IL_320:
				Exception ex = null;
				int num3 = LoaderList.Count - 1;
				for (int j = 0; j <= num3; j++)
				{
					NewLateBinding.LateSetComplex(LoaderList[j].Key, null, "Input", new object[]
					{
						-1
					}, null, null, false, true);
					if (NewLateBinding.LateGet(LoaderList[j].Key, null, "Error", new object[0], null, null, null) != null && (ex == null || ((Exception)NewLateBinding.LateGet(LoaderList[j].Key, null, "Error", new object[0], null, null, null)).Message.Contains("没有可用版本")))
					{
						ex = (Exception)NewLateBinding.LateGet(LoaderList[j].Key, null, "Error", new object[0], null, null, null);
					}
				}
				if (ex == null)
				{
					ex = new TimeoutException("下载源连接超时");
				}
				ModDownload.DlSourceLoaderAbort(LoaderList);
				throw ex;
			}
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x00040F14 File Offset: 0x0003F114
		private static void DlSourceLoaderAbort(List<KeyValuePair<object, int>> LoaderList)
		{
			try
			{
				foreach (KeyValuePair<object, int> keyValuePair in LoaderList)
				{
					if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(keyValuePair.Key, null, "State", new object[0], null, null, null), ModBase.LoadState.Loading, true))
					{
						NewLateBinding.LateCall(keyValuePair.Key, null, "Abort", new object[0], null, null, null, true);
					}
				}
			}
			finally
			{
				List<KeyValuePair<object, int>>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x04000427 RID: 1063
		public static ModLoader.LoaderTask<int, ModDownload.DlClientListResult> _AlgoIterator;

		// Token: 0x04000428 RID: 1064
		public static ModLoader.LoaderTask<int, ModDownload.DlClientListResult> m_MapperIterator;

		// Token: 0x04000429 RID: 1065
		private static bool paramsIterator;

		// Token: 0x0400042A RID: 1066
		public static ModLoader.LoaderTask<int, ModDownload.DlClientListResult> globalIterator;

		// Token: 0x0400042B RID: 1067
		public static ModLoader.LoaderTask<int, ModDownload.DlOptiFineListResult> issuerIterator;

		// Token: 0x0400042C RID: 1068
		public static ModLoader.LoaderTask<int, ModDownload.DlOptiFineListResult> _OrderIterator;

		// Token: 0x0400042D RID: 1069
		public static ModLoader.LoaderTask<int, ModDownload.DlOptiFineListResult> serviceIterator;

		// Token: 0x0400042E RID: 1070
		public static ModLoader.LoaderTask<int, ModDownload.DlForgeListResult> facadeIterator;

		// Token: 0x0400042F RID: 1071
		public static ModLoader.LoaderTask<int, ModDownload.DlForgeListResult> codeIterator;

		// Token: 0x04000430 RID: 1072
		public static ModLoader.LoaderTask<int, ModDownload.DlForgeListResult> _MappingIterator;

		// Token: 0x04000431 RID: 1073
		public static ModLoader.LoaderTask<int, ModDownload.DlLiteLoaderListResult> m_BridgeIterator;

		// Token: 0x04000432 RID: 1074
		public static ModLoader.LoaderTask<int, ModDownload.DlLiteLoaderListResult> _SingletonIterator;

		// Token: 0x04000433 RID: 1075
		public static ModLoader.LoaderTask<int, ModDownload.DlLiteLoaderListResult> _ErrorIterator;

		// Token: 0x04000434 RID: 1076
		public static ModLoader.LoaderTask<int, ModDownload.DlFabricListResult> m_ObjectIterator;

		// Token: 0x04000435 RID: 1077
		public static ModLoader.LoaderTask<int, ModDownload.DlFabricListResult> callbackIterator;

		// Token: 0x04000436 RID: 1078
		public static ModLoader.LoaderTask<int, ModDownload.DlFabricListResult> m_WorkerIterator;

		// Token: 0x04000437 RID: 1079
		public static ModLoader.LoaderTask<int, List<ModDownload.DlCfFile>> _VisitorIterator;

		// Token: 0x04000438 RID: 1080
		private static JObject _IndexerIterator;

		// Token: 0x04000439 RID: 1081
		public static ModLoader.LoaderTask<KeyValuePair<int, bool>, List<ModDownload.DlCfFile>> _MethodIterator;

		// Token: 0x0400043A RID: 1082
		private static Dictionary<int, ModDownload.DlCfProject> m_DatabaseIterator;

		// Token: 0x0400043B RID: 1083
		private static Dictionary<int, List<ModDownload.DlCfFile>> attrIterator;

		// Token: 0x020000DD RID: 221
		public enum AssetsIndexExistsBehaviour
		{
			// Token: 0x0400043D RID: 1085
			DontDownload,
			// Token: 0x0400043E RID: 1086
			DownloadInBackground,
			// Token: 0x0400043F RID: 1087
			AlwaysDownload
		}

		// Token: 0x020000DE RID: 222
		public struct DlClientListResult
		{
			// Token: 0x04000440 RID: 1088
			public string m_ManagerAlgo;

			// Token: 0x04000441 RID: 1089
			public bool m_ItemAlgo;

			// Token: 0x04000442 RID: 1090
			public JObject Value;
		}

		// Token: 0x020000DF RID: 223
		public struct DlOptiFineListResult
		{
			// Token: 0x04000443 RID: 1091
			public string m_SerializerAlgo;

			// Token: 0x04000444 RID: 1092
			public bool _InfoAlgo;

			// Token: 0x04000445 RID: 1093
			public List<ModDownload.DlOptiFineListEntry> Value;
		}

		// Token: 0x020000E0 RID: 224
		public class DlOptiFineListEntry
		{
			// Token: 0x06000832 RID: 2098 RVA: 0x00006718 File Offset: 0x00004918
			public string SetExpression()
			{
				return this.m_RefAlgo;
			}

			// Token: 0x06000833 RID: 2099 RVA: 0x00006720 File Offset: 0x00004920
			public void InvokeExpression(string value)
			{
				if (value.EndsWith(".0"))
				{
					value = Strings.Left(value, checked(value.Length - 2));
				}
				this.m_RefAlgo = value;
			}

			// Token: 0x04000446 RID: 1094
			public string m_RepositoryAlgo;

			// Token: 0x04000447 RID: 1095
			public string m_SystemAlgo;

			// Token: 0x04000448 RID: 1096
			public string m_ProccesorAlgo;

			// Token: 0x04000449 RID: 1097
			public bool m_PrototypeAlgo;

			// Token: 0x0400044A RID: 1098
			private string m_RefAlgo;

			// Token: 0x0400044B RID: 1099
			public string m_ParameterAlgo;
		}

		// Token: 0x020000E1 RID: 225
		public struct DlForgeListResult
		{
			// Token: 0x0400044C RID: 1100
			public string stubAlgo;

			// Token: 0x0400044D RID: 1101
			public bool m_AccountAlgo;

			// Token: 0x0400044E RID: 1102
			public List<string> Value;
		}

		// Token: 0x020000E2 RID: 226
		public class DlForgeVersionEntry
		{
			// Token: 0x06000834 RID: 2100 RVA: 0x00006746 File Offset: 0x00004946
			public DlForgeVersionEntry()
			{
				this.structAlgo = null;
				this.testsAlgo = null;
			}

			// Token: 0x06000835 RID: 2101 RVA: 0x0000675C File Offset: 0x0000495C
			public bool InstantiateExpression()
			{
				return Conversions.ToDouble(this._ConfigurationAlgo.Split(new char[]
				{
					'.'
				})[0]) >= 20.0;
			}

			// Token: 0x06000836 RID: 2102 RVA: 0x00040FA4 File Offset: 0x0003F1A4
			public int InitExpression()
			{
				string[] array = this._ConfigurationAlgo.Split(new char[]
				{
					'.'
				});
				checked
				{
					int result;
					if (Conversions.ToDouble(array[0]) < 15.0)
					{
						result = Conversions.ToInteger(array[array.Count<string>() - 1]);
					}
					else
					{
						result = (int)Math.Round(unchecked(Conversions.ToDouble(array[checked(array.Count<string>() - 1)]) + 10000.0));
					}
					return result;
				}
			}

			// Token: 0x06000837 RID: 2103 RVA: 0x00006789 File Offset: 0x00004989
			public string PrepareExpression()
			{
				return this._ConfigurationAlgo + ((this.testsAlgo == null) ? "" : ("-" + this.testsAlgo));
			}

			// Token: 0x06000838 RID: 2104 RVA: 0x00041010 File Offset: 0x0003F210
			public string FlushExpression()
			{
				return string.Concat(new string[]
				{
					"forge-",
					this.interpreterAlgo,
					"-",
					this.PrepareExpression(),
					"-",
					this._CollectionAlgo,
					".",
					this.DeleteExpression()
				});
			}

			// Token: 0x06000839 RID: 2105 RVA: 0x0004106C File Offset: 0x0003F26C
			public string DeleteExpression()
			{
				string result;
				if (Operators.CompareString(this._CollectionAlgo, "installer", true) == 0)
				{
					result = "jar";
				}
				else
				{
					result = "zip";
				}
				return result;
			}

			// Token: 0x0400044F RID: 1103
			public string _ConfigurationAlgo;

			// Token: 0x04000450 RID: 1104
			public string interpreterAlgo;

			// Token: 0x04000451 RID: 1105
			public string m_PredicateAlgo;

			// Token: 0x04000452 RID: 1106
			public string structAlgo;

			// Token: 0x04000453 RID: 1107
			public bool resolverAlgo;

			// Token: 0x04000454 RID: 1108
			public string _CollectionAlgo;

			// Token: 0x04000455 RID: 1109
			public string testsAlgo;
		}

		// Token: 0x020000E3 RID: 227
		public struct DlLiteLoaderListResult
		{
			// Token: 0x04000456 RID: 1110
			public string SourceName;

			// Token: 0x04000457 RID: 1111
			public bool IsOfficial;

			// Token: 0x04000458 RID: 1112
			public List<ModDownload.DlLiteLoaderListEntry> Value;

			// Token: 0x04000459 RID: 1113
			public Exception OfficialError;
		}

		// Token: 0x020000E4 RID: 228
		public class DlLiteLoaderListEntry
		{
			// Token: 0x0400045A RID: 1114
			public string FileName;

			// Token: 0x0400045B RID: 1115
			public bool IsPreview;

			// Token: 0x0400045C RID: 1116
			public string Inherit;

			// Token: 0x0400045D RID: 1117
			public bool IsLegacy;

			// Token: 0x0400045E RID: 1118
			public string ReleaseTime;

			// Token: 0x0400045F RID: 1119
			public string MD5;

			// Token: 0x04000460 RID: 1120
			public JToken JsonToken;
		}

		// Token: 0x020000E5 RID: 229
		public struct DlFabricListResult
		{
			// Token: 0x04000461 RID: 1121
			public string m_BroadcasterAlgo;

			// Token: 0x04000462 RID: 1122
			public bool fieldAlgo;

			// Token: 0x04000463 RID: 1123
			public JObject Value;
		}

		// Token: 0x020000E6 RID: 230
		public class DlCfProjectRequest
		{
			// Token: 0x0600083B RID: 2107 RVA: 0x0004109C File Offset: 0x0003F29C
			public DlCfProjectRequest()
			{
				this.statusAlgo = 0;
				this.m_RequestAlgo = false;
				this.poolAlgo = null;
				this.parserAlgo = Conversions.ToString(0x32);
				this.m_ProxyAlgo = null;
				this.setterAlgo = new int?(5);
				this.merchantAlgo = 0;
				this._EventAlgo = null;
			}

			// Token: 0x0600083C RID: 2108 RVA: 0x000410F8 File Offset: 0x0003F2F8
			public string GetAddress()
			{
				string[] array = new string[9];
				array[0] = "https://addons-ecs.forgesvc.net/api/v2/addon/search?gameId=432&pageSize=";
				array[1] = this.parserAlgo;
				array[2] = "&categoryId=";
				array[3] = Conversions.ToString(this.statusAlgo);
				array[4] = (this.m_RequestAlgo ? "&sectionId=4471" : "&sectionId=6");
				array[5] = (string.IsNullOrEmpty(this.poolAlgo) ? "" : ("&gameVersion=" + this.poolAlgo));
				array[6] = (string.IsNullOrEmpty(this.m_ProxyAlgo) ? "" : ("&searchFilter=" + WebUtility.UrlEncode(this.m_ProxyAlgo)));
				int num = 7;
				string text;
				if (this.setterAlgo == null)
				{
					text = "";
				}
				else
				{
					string str = "&sort=";
					int? eventAlgo;
					int? num2 = eventAlgo = this.setterAlgo;
					text = str + ((eventAlgo != null) ? Conversions.ToString(num2.GetValueOrDefault()) : null);
				}
				array[num] = text;
				int num3 = 8;
				string text2;
				if (this._EventAlgo == null)
				{
					text2 = "";
				}
				else
				{
					string str2 = "&index=";
					int? eventAlgo;
					int? num2 = eventAlgo = this._EventAlgo;
					text2 = str2 + ((eventAlgo != null) ? Conversions.ToString(num2.GetValueOrDefault()) : null);
				}
				array[num3] = text2;
				return string.Concat(array);
			}

			// Token: 0x0600083D RID: 2109 RVA: 0x00041228 File Offset: 0x0003F428
			public override bool Equals(object obj)
			{
				ModDownload.DlCfProjectRequest dlCfProjectRequest = obj as ModDownload.DlCfProjectRequest;
				return dlCfProjectRequest != null && Operators.CompareString(dlCfProjectRequest.GetAddress(), this.GetAddress(), true) == 0 && dlCfProjectRequest.merchantAlgo == this.merchantAlgo;
			}

			// Token: 0x0600083E RID: 2110 RVA: 0x000067B5 File Offset: 0x000049B5
			public static bool operator ==(ModDownload.DlCfProjectRequest left, ModDownload.DlCfProjectRequest right)
			{
				return EqualityComparer<ModDownload.DlCfProjectRequest>.Default.Equals(left, right);
			}

			// Token: 0x0600083F RID: 2111 RVA: 0x000067C3 File Offset: 0x000049C3
			public static bool operator !=(ModDownload.DlCfProjectRequest left, ModDownload.DlCfProjectRequest right)
			{
				return !(left == right);
			}

			// Token: 0x04000464 RID: 1124
			public int statusAlgo;

			// Token: 0x04000465 RID: 1125
			public bool m_RequestAlgo;

			// Token: 0x04000466 RID: 1126
			public string poolAlgo;

			// Token: 0x04000467 RID: 1127
			public string parserAlgo;

			// Token: 0x04000468 RID: 1128
			public string m_ProxyAlgo;

			// Token: 0x04000469 RID: 1129
			public int? setterAlgo;

			// Token: 0x0400046A RID: 1130
			public int merchantAlgo;

			// Token: 0x0400046B RID: 1131
			public int? _EventAlgo;
		}

		// Token: 0x020000E7 RID: 231
		public class DlCfProject
		{
			// Token: 0x06000840 RID: 2112 RVA: 0x00041264 File Offset: 0x0003F464
			public string PublishExpression()
			{
				if (ModDownload._IndexerIterator == null)
				{
					ModDownload._IndexerIterator = (JObject)ModBase.GetJson(ModBase.DecodeBytes(ModBase.GetResources("ModData")));
				}
				if (this.m_WriterAlgo == null && this._RegistryAlgo != null)
				{
					string propertyName = this._RegistryAlgo.TrimEnd(new char[]
					{
						'/'
					}).Split(new char[]
					{
						'/'
					}).Last<string>();
					if (ModDownload._IndexerIterator.ContainsKey(propertyName))
					{
						string[] array = ModDownload._IndexerIterator[propertyName].ToString().Split(new char[]
						{
							'|'
						});
						if (array.Length == 3)
						{
							this.m_WriterAlgo = array.Last<string>();
						}
					}
				}
				return this.m_WriterAlgo;
			}

			// Token: 0x06000841 RID: 2113 RVA: 0x000067CF File Offset: 0x000049CF
			public void QueryExpression(string value)
			{
				this.m_WriterAlgo = value;
			}

			// Token: 0x06000842 RID: 2114 RVA: 0x00041318 File Offset: 0x0003F518
			public string NewExpression()
			{
				if (ModDownload._IndexerIterator == null)
				{
					ModDownload._IndexerIterator = (JObject)ModBase.GetJson(ModBase.DecodeBytes(ModBase.GetResources("ModData")));
				}
				if (this.exporterAlgo == null)
				{
					this.exporterAlgo = this.Name;
					if (this._RegistryAlgo != null)
					{
						string propertyName = this._RegistryAlgo.TrimEnd(new char[]
						{
							'/'
						}).Split(new char[]
						{
							'/'
						}).Last<string>();
						if (ModDownload._IndexerIterator.ContainsKey(propertyName))
						{
							string text = (string)ModDownload._IndexerIterator[propertyName];
							this.productAlgo = Conversions.ToInteger(text.Split(new char[]
							{
								'|'
							})[0]);
							this.exporterAlgo = text.Split(new char[]
							{
								'|'
							})[1];
						}
					}
				}
				return this.exporterAlgo;
			}

			// Token: 0x06000843 RID: 2115 RVA: 0x000067D8 File Offset: 0x000049D8
			public void InsertExpression(string value)
			{
				this.exporterAlgo = value;
			}

			// Token: 0x06000844 RID: 2116 RVA: 0x000413F4 File Offset: 0x0003F5F4
			public DlCfProject(JObject Data)
			{
				this.productAlgo = 0;
				this._PrinterAlgo = (int)Data["id"];
				this.Name = (string)Data["name"];
				this._ComparatorAlgo = (string)Data["summary"];
				this._RegistryAlgo = (string)Data["websiteUrl"];
				this.m_AttributeAlgo = (DateTime)Data["dateModified"];
				this._ValueAlgo = (int)Data["downloadCount"];
				this.m_WrapperAlgo = !this._RegistryAlgo.Contains("/mc-mods/");
				List<int> list = new List<int>();
				try
				{
					foreach (JToken jtoken in ((IEnumerable<JToken>)(Data["gameVersionLatestFiles"] ?? new byte[0])))
					{
						string text = (string)jtoken["gameVersion"];
						if (text.Contains("1."))
						{
							list.Add(Conversions.ToInteger(text.Split(new char[]
							{
								'.'
							})[1].Split(new char[]
							{
								'-'
							}).First<string>()));
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
				list = ModBase.Sort<int>(ModBase.ArrayNoDouble<int>(list, null), (ModDownload.DlCfProject._Closure$__.$IR20-1 == null) ? (ModDownload.DlCfProject._Closure$__.$IR20-1 = ((object a0, object a1) => ModMinecraft.VersionSortBoolean(Conversions.ToString(a0), Conversions.ToString(a1)))) : ModDownload.DlCfProject._Closure$__.$IR20-1);
				checked
				{
					if (list.Count == 0)
					{
						this.advisorAlgo = "";
					}
					else
					{
						List<string> list2 = new List<string>();
						int num = list.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							int num2 = list[i];
							int num3 = list[i];
							int num4 = i + 1;
							int num5 = list.Count - 1;
							int num6 = num4;
							while (num6 <= num5 && list[num6] == num3 - 1)
							{
								num3 = list[num6];
								i = num6;
								num6++;
							}
							if (num2 == num3)
							{
								list2.Add("1." + Conversions.ToString(num2));
							}
							else
							{
								list2.Add("1." + Conversions.ToString(num2) + "-1." + Conversions.ToString(num3));
							}
						}
						this.advisorAlgo = "[" + ModBase.Join(list2, ", ") + "] ";
					}
					this.roleAlgo = new List<string>();
					try
					{
						foreach (JToken jtoken2 in ((IEnumerable<JToken>)(Data["modLoaders"] ?? new byte[0])))
						{
							this.roleAlgo.Add(jtoken2.ToString());
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
					JToken jtoken3 = Data["categories"];
					List<int> list3 = new List<int>();
					try
					{
						foreach (JToken jtoken4 in ((IEnumerable<JToken>)jtoken3))
						{
							list3.Add((int)jtoken4["categoryId"]);
						}
					}
					finally
					{
						IEnumerator<JToken> enumerator3;
						if (enumerator3 != null)
						{
							enumerator3.Dispose();
						}
					}
					list3 = ModBase.ArrayNoDouble<int>(list3, null);
					list3.Sort();
					this._StrategyAlgo = new List<string>();
					try
					{
						foreach (int num7 in list3)
						{
							string item;
							if (num7 <= 0x1187)
							{
								switch (num7)
								{
								case 0x196:
									item = "世界生成";
									break;
								case 0x197:
									item = "生物群系";
									break;
								case 0x198:
								case 0x19D:
								case 0x1A2:
								case 0x1AA:
								case 0x1AB:
								case 0x1AC:
								case 0x1AD:
								case 0x1AE:
								case 0x1AF:
								case 0x1B0:
								case 0x1B1:
									continue;
								case 0x199:
									item = "天然结构";
									break;
								case 0x19A:
									item = "维度";
									break;
								case 0x19B:
									item = "生物";
									break;
								case 0x19C:
									item = "科技";
									break;
								case 0x19E:
									item = "交通与移动";
									break;
								case 0x19F:
									item = "管道与物流";
									break;
								case 0x1A0:
									item = "农业";
									break;
								case 0x1A1:
									item = "能源";
									break;
								case 0x1A3:
									item = "魔法";
									break;
								case 0x1A4:
									item = "仓储";
									break;
								case 0x1A5:
									item = "支持库";
									break;
								case 0x1A6:
									item = "冒险与探索";
									break;
								case 0x1A7:
									item = "信息显示";
									break;
								case 0x1A8:
									item = "建筑与装饰";
									break;
								case 0x1A9:
									item = "杂项";
									break;
								case 0x1B2:
									item = "装备与工具";
									break;
								case 0x1B3:
									item = "服务器";
									break;
								case 0x1B4:
									item = "食物";
									break;
								default:
									switch (num7)
									{
									case 0x1177:
										item = "科幻";
										break;
									case 0x1178:
										item = "科技";
										break;
									case 0x1179:
										item = "魔法";
										break;
									case 0x117A:
									case 0x1185:
									case 0x1186:
										continue;
									case 0x117B:
										item = "冒险";
										break;
									case 0x117C:
										item = "探索";
										break;
									case 0x117D:
										item = "小游戏";
										break;
									case 0x117E:
										item = "任务";
										break;
									case 0x117F:
										item = "硬核";
										break;
									case 0x1180:
										item = "基于地图";
										break;
									case 0x1181:
										item = "小型整合";
										break;
									case 0x1182:
										item = "大型整合";
										break;
									case 0x1183:
										item = "战斗";
										break;
									case 0x1184:
										item = "多人";
										break;
									case 0x1187:
										item = "FTB";
										break;
									default:
										continue;
									}
									break;
								}
							}
							else if (num7 != 0x11CE)
							{
								if (num7 != 0x1280)
								{
									continue;
								}
								item = "空岛";
							}
							else
							{
								item = "红石";
							}
							this._StrategyAlgo.Add(item);
						}
					}
					finally
					{
						List<int>.Enumerator enumerator4;
						((IDisposable)enumerator4).Dispose();
					}
					if (this._StrategyAlgo.Count == 0)
					{
						this._StrategyAlgo.Add("杂类");
					}
					JToken jtoken5 = Data["attachments"];
					try
					{
						foreach (JToken jtoken6 in ((IEnumerable<JToken>)jtoken5))
						{
							if (((bool?)(jtoken6["isDefault"] ?? false)).GetValueOrDefault())
							{
								if (ModBase.GetPixelSize(1.0) > 1.25)
								{
									this.Thumb = jtoken6["thumbnailUrl"].ToString();
									break;
								}
								this.Thumb = jtoken6["thumbnailUrl"].ToString().Replace("/256/256/", "/64/64/");
								break;
							}
						}
					}
					finally
					{
						IEnumerator<JToken> enumerator5;
						if (enumerator5 != null)
						{
							enumerator5.Dispose();
						}
					}
				}
			}

			// Token: 0x06000845 RID: 2117 RVA: 0x00041B4C File Offset: 0x0003FD4C
			public MyCfItem ToCfItem(MyCfItem.ClickEventHandler OnClick = null)
			{
				MyCfItem myCfItem = new MyCfItem
				{
					Tag = this
				};
				myCfItem.LabTitle.Text = this.NewExpression();
				myCfItem.LabInfo.Text = this._ComparatorAlgo.Replace("\r", "").Replace("\n", "");
				myCfItem.LabLeft.Text = string.Concat(new string[]
				{
					(this.roleAlgo.Count == 0) ? "" : ("[" + ModBase.Join(this.roleAlgo, " & ") + "] "),
					this.advisorAlgo,
					ModBase.Join(this._StrategyAlgo, "，"),
					" (",
					ModBase.GetTimeSpanString(this.m_AttributeAlgo - DateTime.Now),
					"更新，",
					(this._ValueAlgo > 0x186A0) ? (Conversions.ToString(Math.Round((double)this._ValueAlgo / 10000.0)) + " 万下载）") : (Conversions.ToString(this._ValueAlgo) + " 次下载）")
				});
				if (this.Thumb == null)
				{
					myCfItem.Logo = "pack://application:,,,/images/Icons/NoIcon.png";
				}
				else
				{
					myCfItem.Logo = this.Thumb;
				}
				if (OnClick != null)
				{
					myCfItem.ReflectContainer(OnClick);
				}
				myCfItem.m_ComparatorVal = (OnClick != null);
				return myCfItem;
			}

			// Token: 0x06000846 RID: 2118 RVA: 0x00041CB8 File Offset: 0x0003FEB8
			public override bool Equals(object obj)
			{
				ModDownload.DlCfProject dlCfProject = obj as ModDownload.DlCfProject;
				return dlCfProject != null && this._PrinterAlgo == dlCfProject._PrinterAlgo;
			}

			// Token: 0x06000847 RID: 2119 RVA: 0x000067E1 File Offset: 0x000049E1
			public static bool operator ==(ModDownload.DlCfProject left, ModDownload.DlCfProject right)
			{
				return EqualityComparer<ModDownload.DlCfProject>.Default.Equals(left, right);
			}

			// Token: 0x06000848 RID: 2120 RVA: 0x000067EF File Offset: 0x000049EF
			public static bool operator !=(ModDownload.DlCfProject left, ModDownload.DlCfProject right)
			{
				return !(left == right);
			}

			// Token: 0x0400046C RID: 1132
			public int _PrinterAlgo;

			// Token: 0x0400046D RID: 1133
			public string Name;

			// Token: 0x0400046E RID: 1134
			public int productAlgo;

			// Token: 0x0400046F RID: 1135
			public string _ComparatorAlgo;

			// Token: 0x04000470 RID: 1136
			public string _RegistryAlgo;

			// Token: 0x04000471 RID: 1137
			public DateTime m_AttributeAlgo;

			// Token: 0x04000472 RID: 1138
			public int _ValueAlgo;

			// Token: 0x04000473 RID: 1139
			public List<string> roleAlgo;

			// Token: 0x04000474 RID: 1140
			public string advisorAlgo;

			// Token: 0x04000475 RID: 1141
			private List<string> _StrategyAlgo;

			// Token: 0x04000476 RID: 1142
			private string Thumb;

			// Token: 0x04000477 RID: 1143
			public bool m_WrapperAlgo;

			// Token: 0x04000478 RID: 1144
			private string m_WriterAlgo;

			// Token: 0x04000479 RID: 1145
			private string exporterAlgo;
		}

		// Token: 0x020000E9 RID: 233
		public class DlCfFile
		{
			// Token: 0x0600084C RID: 2124 RVA: 0x00041CE0 File Offset: 0x0003FEE0
			public string CountExpression()
			{
				int descriptorAlgo = this.m_DescriptorAlgo;
				string result;
				if (descriptorAlgo != 1)
				{
					if (descriptorAlgo != 2)
					{
						result = (ModBase.errorRule ? "Alpha 测试版" : "测试版");
					}
					else
					{
						result = (ModBase.errorRule ? "Beta 测试版" : "测试版");
					}
				}
				else
				{
					result = "正式版";
				}
				return result;
			}

			// Token: 0x0600084D RID: 2125 RVA: 0x0000681A File Offset: 0x00004A1A
			public bool AssetExpression()
			{
				return this.m_InterceptorAlgo != null && this.candidateAlgo != null && this._ContextAlgo != null && this._TokenizerAlgo[0].StartsWith("http");
			}

			// Token: 0x0600084E RID: 2126 RVA: 0x00041D30 File Offset: 0x0003FF30
			public DlCfFile(JObject Data, bool IsModPack)
			{
				this.observerAlgo = new List<int>();
				this._GetterAlgo = (int)Data["id"];
				this.m_InterceptorAlgo = Data["displayName"].ToString().Replace("\t", "").Trim(new char[]
				{
					' '
				});
				this.invocationAlgo = (DateTime)Data["fileDate"];
				this.m_DescriptorAlgo = (int)Data["releaseType"];
				this._ContextAlgo = (string)Data["fileName"];
				this._RecordAlgo = IsModPack;
				string text = Data["downloadUrl"].ToString();
				text = text.Replace(this._ContextAlgo, WebUtility.UrlEncode(this._ContextAlgo));
				this._TokenizerAlgo = ModBase.ArrayNoDouble<string>(new string[]
				{
					text.Replace("-service.overwolf.wtf", ".forgecdn.net").Replace("://edge", "://media"),
					text.Replace("-service.overwolf.wtf", ".forgecdn.net"),
					text.Replace("://edge", "://media"),
					text
				}, null);
				if (!IsModPack)
				{
					try
					{
						foreach (JToken jtoken in ((IEnumerable<JToken>)Data["dependencies"]))
						{
							if (jtoken["type"].ToObject<int>() == 3)
							{
								this.observerAlgo.Add((int)jtoken["addonId"]);
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
				}
				List<string> list = new List<string>();
				try
				{
					foreach (JToken jtoken2 in ((IEnumerable<JToken>)Data["gameVersion"]))
					{
						if (jtoken2.ToString().StartsWith("1.") || jtoken2.ToString().Contains("w"))
						{
							list.Add(jtoken2.ToString().Trim().ToLower());
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
				if (list.Count > 1)
				{
					this.candidateAlgo = ModBase.Sort<string>(list, (ModDownload.DlCfFile._Closure$__.$IR13-1 == null) ? (ModDownload.DlCfFile._Closure$__.$IR13-1 = ((object a0, object a1) => ModMinecraft.VersionSortBoolean(Conversions.ToString(a0), Conversions.ToString(a1)))) : ModDownload.DlCfFile._Closure$__.$IR13-1).ToArray();
					if (IsModPack)
					{
						this.candidateAlgo = new string[]
						{
							this.candidateAlgo[0]
						};
						return;
					}
				}
				else
				{
					if (list.Count == 1)
					{
						this.candidateAlgo = list.ToArray();
						return;
					}
					this.candidateAlgo = new string[]
					{
						"未知版本"
					};
				}
			}

			// Token: 0x0600084F RID: 2127 RVA: 0x00006848 File Offset: 0x00004A48
			public ModNet.NetFile GetDownloadFile(string LocalAddress, bool IsFullPath)
			{
				return new ModNet.NetFile(this._TokenizerAlgo, LocalAddress + (IsFullPath ? "" : this._ContextAlgo), null);
			}

			// Token: 0x06000850 RID: 2128 RVA: 0x00041FE0 File Offset: 0x000401E0
			public MyListItem ToListItem(MyListItem.ClickEventHandler OnClick, MyIconButton.ClickEventHandler OnSaveClick = null)
			{
				string text = "";
				if (!this._RecordAlgo)
				{
					text = text + "适用于 " + ModBase.Join(this.candidateAlgo, "、").Replace("-snapshot", " 快照") + ((!ModBase.errorRule || this.observerAlgo.Count <= 0) ? "，" : ("，" + Conversions.ToString(this.observerAlgo.Count) + " 个前置，"));
				}
				text = text + ModBase.GetTimeSpanString(this.invocationAlgo - DateTime.Now) + "更新，";
				text += this.CountExpression();
				MyListItem myListItem = new MyListItem
				{
					Title = this.m_InterceptorAlgo,
					SnapsToDevicePixels = true,
					Height = 42.0,
					Type = MyListItem.CheckType.Clickable,
					Tag = this,
					Info = text
				};
				int descriptorAlgo = this.m_DescriptorAlgo;
				if (descriptorAlgo != 1)
				{
					if (descriptorAlgo != 2)
					{
						myListItem.Logo = "pack://application:,,,/images/Icons/A.png";
					}
					else
					{
						myListItem.Logo = "pack://application:,,,/images/Icons/B.png";
					}
				}
				else
				{
					myListItem.Logo = "pack://application:,,,/images/Icons/R.png";
				}
				myListItem.QueryModel(OnClick);
				if (OnSaveClick != null)
				{
					MyIconButton myIconButton = new MyIconButton
					{
						Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z",
						ToolTip = "另存为"
					};
					ToolTipService.SetPlacement(myIconButton, PlacementMode.Center);
					ToolTipService.SetVerticalOffset(myIconButton, 30.0);
					ToolTipService.SetHorizontalOffset(myIconButton, 2.0);
					myIconButton.Click += OnSaveClick;
					myListItem.Buttons = new MyIconButton[]
					{
						myIconButton
					};
					myListItem.PaddingRight = 0x23;
				}
				return myListItem;
			}

			// Token: 0x06000851 RID: 2129 RVA: 0x0000686C File Offset: 0x00004A6C
			public override string ToString()
			{
				return this.m_InterceptorAlgo;
			}

			// Token: 0x0400047C RID: 1148
			public bool _RecordAlgo;

			// Token: 0x0400047D RID: 1149
			public int _GetterAlgo;

			// Token: 0x0400047E RID: 1150
			public string m_InterceptorAlgo;

			// Token: 0x0400047F RID: 1151
			public DateTime invocationAlgo;

			// Token: 0x04000480 RID: 1152
			public string[] candidateAlgo;

			// Token: 0x04000481 RID: 1153
			public int m_DescriptorAlgo;

			// Token: 0x04000482 RID: 1154
			public string _ContextAlgo;

			// Token: 0x04000483 RID: 1155
			public List<int> observerAlgo;

			// Token: 0x04000484 RID: 1156
			private string[] _TokenizerAlgo;
		}
	}
}
