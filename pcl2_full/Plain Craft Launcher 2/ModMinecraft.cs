using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PCL.My;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;

namespace PCL
{
	// Token: 0x020000FD RID: 253
	[StandardModule]
	public sealed class ModMinecraft
	{
		// Token: 0x060008AD RID: 2221 RVA: 0x00047FF0 File Offset: 0x000461F0
		// Note: this type is marked as 'beforefieldinit'.
		static ModMinecraft()
		{
			ModMinecraft.m_AccountIterator = 1;
			ModMinecraft._InterpreterIterator = null;
			ModMinecraft._PredicateIterator = new ModLoader.LoaderTask<int, int>("Java Search Loader", new ModLoader.LoaderTask<int, int>.LoadDelegateSub(ModMinecraft.JavaSearchLoaderSub), null, ThreadPriority.Normal);
			ModMinecraft._StructIterator = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\";
			ModMinecraft.collectionIterator = new List<ModMinecraft.McFolder>();
			ModMinecraft._TestsIterator = new ModLoader.LoaderTask<int, int>("Minecraft Folder List", delegate(ModLoader.LoaderTask<int, int> a0)
			{
				ModMinecraft.McFolderListLoadSub();
			}, null, ThreadPriority.AboveNormal);
			ModMinecraft.m_StatusIterator = 0;
			ModMinecraft.m_RequestIterator = new Dictionary<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>>();
			ModMinecraft.m_PoolIterator = false;
			ModMinecraft.m_ParserIterator = new ModLoader.LoaderTask<string, int>("Minecraft Version List", new ModLoader.LoaderTask<string, int>.LoadDelegateSub(ModMinecraft.McVersionListLoad), null, ThreadPriority.Normal)
			{
				ReloadTimeout = 1
			};
			ModMinecraft._ProxyIterator = RuntimeHelpers.GetObjectValue(new object());
			ModMinecraft.setterIterator = MyWpfExtension.RunFactory().Info.OSVersion;
			ModMinecraft._MerchantIterator = new ModLoader.LoaderTask<string, List<ModMinecraft.McMod>>("Mod List Loader", new ModLoader.LoaderTask<string, List<ModMinecraft.McMod>>.LoadDelegateSub(ModMinecraft.McModLoad), null, ThreadPriority.Normal);
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x000480E8 File Offset: 0x000462E8
		public static void JavaListInit()
		{
			ModMinecraft._ConfigurationIterator = new List<ModMinecraft.JavaEntry>();
			try
			{
				if (Operators.ConditionalCompareObjectLess(ModBase._BaseRule.Get("CacheJavaListVersion", null), ModMinecraft.m_AccountIterator, true))
				{
					ModBase.Log("[Java] 要求 Java 列表缓存更新", ModBase.LogLevel.Normal, "出现错误");
					ModBase._BaseRule.Set("CacheJavaListVersion", ModMinecraft.m_AccountIterator, false, null);
				}
				else
				{
					try
					{
						foreach (object obj in ((IEnumerable)ModBase.GetJson(Conversions.ToString(ModBase._BaseRule.Get("LaunchArgumentJavaAll", null)))))
						{
							object objectValue = RuntimeHelpers.GetObjectValue(obj);
							ModMinecraft._ConfigurationIterator.Add(ModMinecraft.JavaEntry.FromJson((JObject)objectValue));
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
				}
				if (ModMinecraft._ConfigurationIterator.Count == 0)
				{
					ModBase.Log("[Java] 初始化未找到可用的 Java，将自动触发搜索", ModBase.LogLevel.Developer, "出现错误");
					ModMinecraft._PredicateIterator.Start(0, false);
				}
				else
				{
					ModBase.Log("[Java] 缓存中有 " + Conversions.ToString(ModMinecraft._ConfigurationIterator.Count) + " 个可用的 Java", ModBase.LogLevel.Normal, "出现错误");
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "初始化 Java 列表失败", ModBase.LogLevel.Feedback, "出现错误");
				ModBase._BaseRule.Set("LaunchArgumentJavaAll", "[]", false, null);
			}
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x00006B0D File Offset: 0x00004D0D
		private static string ManageContainer()
		{
			if (ModMinecraft._InterpreterIterator == null)
			{
				ModMinecraft._InterpreterIterator = Environment.GetEnvironmentVariable("Path");
			}
			return ModMinecraft._InterpreterIterator;
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x00048274 File Offset: 0x00046474
		private static void JavaSearchLoaderSub(ModLoader.LoaderTask<int, int> Loader)
		{
			if (ModMain.m_AuthenticationFilter != null)
			{
				ModBase.RunInUiWait((ModMinecraft._Closure$__.$I9-0 == null) ? (ModMinecraft._Closure$__.$I9-0 = delegate()
				{
					ModMain.m_AuthenticationFilter.ComboArgumentJava.Items.Clear();
					ModMain.m_AuthenticationFilter.ComboArgumentJava.Items.Add(new ComboBoxItem
					{
						Content = "加载中……",
						IsSelected = true
					});
				}) : ModMinecraft._Closure$__.$I9-0);
			}
			if (ModMain._ServerFilter != null)
			{
				ModBase.RunInUiWait((ModMinecraft._Closure$__.$I9-1 == null) ? (ModMinecraft._Closure$__.$I9-1 = delegate()
				{
					ModMain._ServerFilter.ComboArgumentJava.Items.Clear();
					ModMain._ServerFilter.ComboArgumentJava.Items.Add(new ComboBoxItem
					{
						Content = "加载中……",
						IsSelected = true
					});
				}) : ModMinecraft._Closure$__.$I9-1);
			}
			checked
			{
				try
				{
					Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
					foreach (string text in Strings.Split(ModMinecraft.ManageContainer().Replace("\\\\", "\\").Replace("/", "\\"), ";", -1, CompareMethod.Text))
					{
						text = text.Trim(" \"".ToCharArray());
						if (!text.EndsWith("\\"))
						{
							text += "\\";
						}
						if (File.Exists(text + "javaw.exe"))
						{
							ModBase.DictionaryAdd<string, bool>(ref dictionary, text, false);
						}
					}
					DriveInfo[] drives = DriveInfo.GetDrives();
					for (int j = 0; j < drives.Length; j++)
					{
						ModMinecraft.JavaSearchFolder(drives[j].Name, ref dictionary, false, false);
					}
					ModMinecraft.JavaSearchFolder(ModMinecraft._StructIterator, ref dictionary, false, false);
					ModMinecraft.JavaSearchFolder(ModBase.Path, ref dictionary, false, true);
					if (!string.IsNullOrWhiteSpace(ModMinecraft.m_ResolverIterator) && Operators.CompareString(ModBase.Path, ModMinecraft.m_ResolverIterator, true) != 0)
					{
						ModMinecraft.JavaSearchFolder(ModMinecraft.m_ResolverIterator, ref dictionary, false, true);
					}
					Dictionary<string, bool> dictionary2 = new Dictionary<string, bool>();
					try
					{
						Dictionary<string, bool>.Enumerator enumerator = dictionary.GetEnumerator();
						IL_25F:
						while (enumerator.MoveNext())
						{
							KeyValuePair<string, bool> keyValuePair = enumerator.Current;
							string text2 = keyValuePair.Key.Replace("\\\\", "\\").Replace("/", "\\");
							FileSystemInfo fileSystemInfo = new FileInfo(text2 + "javaw.exe");
							while (!fileSystemInfo.Attributes.HasFlag(FileAttributes.ReparsePoint))
							{
								fileSystemInfo = ((fileSystemInfo is FileInfo) ? ((FileInfo)fileSystemInfo).Directory : ((DirectoryInfo)fileSystemInfo).Parent);
								if (fileSystemInfo == null)
								{
									ModBase.Log("[Java] 位于 " + text2 + " 的 Java 不含符号链接", ModBase.LogLevel.Normal, "出现错误");
									dictionary2.Add(keyValuePair.Key, keyValuePair.Value);
									goto IL_25F;
								}
							}
							ModBase.Log("[Java] 位于 " + text2 + " 的 Java 包含符号链接", ModBase.LogLevel.Normal, "出现错误");
						}
					}
					finally
					{
						Dictionary<string, bool>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					if (dictionary2.Count > 0)
					{
						dictionary = dictionary2;
					}
					Dictionary<string, bool> dictionary3 = new Dictionary<string, bool>();
					try
					{
						foreach (KeyValuePair<string, bool> keyValuePair2 in dictionary)
						{
							if (keyValuePair2.Key.Contains("javapath_target_"))
							{
								ModBase.Log("[Java] 位于 " + keyValuePair2.Key + " 的 Java 包含二重引用", ModBase.LogLevel.Normal, "出现错误");
							}
							else
							{
								ModBase.Log("[Java] 位于 " + keyValuePair2.Key + " 的 Java 不含二重引用", ModBase.LogLevel.Normal, "出现错误");
								dictionary3.Add(keyValuePair2.Key, keyValuePair2.Value);
							}
						}
					}
					finally
					{
						Dictionary<string, bool>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
					if (dictionary3.Count > 0)
					{
						dictionary = dictionary3;
					}
					string data = Conversions.ToString(ModBase._BaseRule.Get("LaunchArgumentJavaAll", null));
					try
					{
						try
						{
							foreach (object obj in ((IEnumerable)ModBase.GetJson(data)))
							{
								ModMinecraft.JavaEntry javaEntry = ModMinecraft.JavaEntry.FromJson((JObject)RuntimeHelpers.GetObjectValue(obj));
								if (javaEntry.readerAlgo)
								{
									ModBase.DictionaryAdd<string, bool>(ref dictionary, javaEntry.m_AnnotationAlgo, true);
								}
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
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "Java 列表已损坏", ModBase.LogLevel.Feedback, "出现错误");
						ModBase._BaseRule.Set("LaunchArgumentJavaAll", "[]", false, null);
					}
					List<ModMinecraft.JavaEntry> list = new List<ModMinecraft.JavaEntry>();
					try
					{
						foreach (KeyValuePair<string, bool> keyValuePair3 in dictionary)
						{
							list.Add(new ModMinecraft.JavaEntry(keyValuePair3.Key, keyValuePair3.Value));
						}
					}
					finally
					{
						Dictionary<string, bool>.Enumerator enumerator4;
						((IDisposable)enumerator4).Dispose();
					}
					list = ModBase.Sort<ModMinecraft.JavaEntry>(ModMinecraft.JavaCheckList(list), (ModMinecraft._Closure$__.$IR9-2 == null) ? (ModMinecraft._Closure$__.$IR9-2 = ((object a0, object a1) => ModMinecraft.JavaSorter((ModMinecraft.JavaEntry)a0, (ModMinecraft.JavaEntry)a1))) : ModMinecraft._Closure$__.$IR9-2);
					JArray jarray = new JArray();
					try
					{
						foreach (ModMinecraft.JavaEntry javaEntry2 in list)
						{
							jarray.Add(javaEntry2.ToJson());
						}
					}
					finally
					{
						List<ModMinecraft.JavaEntry>.Enumerator enumerator5;
						((IDisposable)enumerator5).Dispose();
					}
					ModBase._BaseRule.Set("LaunchArgumentJavaAll", jarray.ToString(Formatting.None, new JsonConverter[0]), false, null);
					ModMinecraft._ConfigurationIterator = list;
				}
				catch (Exception ex2)
				{
					ModBase.Log(ex2, "搜索 Java 时出错", ModBase.LogLevel.Feedback, "出现错误");
					ModMinecraft._ConfigurationIterator = new List<ModMinecraft.JavaEntry>();
				}
				ModBase.Log("[Java] Java 搜索完成，发现 " + Conversions.ToString(ModMinecraft._ConfigurationIterator.Count) + " 个 Java", ModBase.LogLevel.Normal, "出现错误");
				if (ModMain.m_AuthenticationFilter != null)
				{
					ModBase.RunInUi((ModMinecraft._Closure$__.$I9-2 == null) ? (ModMinecraft._Closure$__.$I9-2 = delegate()
					{
						ModMain.m_AuthenticationFilter.RefreshJavaComboBox();
					}) : ModMinecraft._Closure$__.$I9-2, false);
				}
				if (ModMain._ServerFilter != null)
				{
					ModBase.RunInUi((ModMinecraft._Closure$__.$I9-3 == null) ? (ModMinecraft._Closure$__.$I9-3 = delegate()
					{
						ModMain._ServerFilter.RefreshJavaComboBox();
					}) : ModMinecraft._Closure$__.$I9-3, false);
				}
			}
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x000488B0 File Offset: 0x00046AB0
		private static List<ModMinecraft.JavaEntry> JavaCheckList(List<ModMinecraft.JavaEntry> JavaEntries)
		{
			ModMinecraft._Closure$__10-1 CS$<>8__locals1 = new ModMinecraft._Closure$__10-1(CS$<>8__locals1);
			ModBase.Log("[Java] 开始确认列表 Java 状态", ModBase.LogLevel.Normal, "出现错误");
			CS$<>8__locals1.$VB$Local_JavaCheckList = new List<ModMinecraft.JavaEntry>();
			CS$<>8__locals1.$VB$Local_ListLock = RuntimeHelpers.GetObjectValue(new object());
			List<Thread> list = new List<Thread>();
			try
			{
				List<ModMinecraft.JavaEntry>.Enumerator enumerator = JavaEntries.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModMinecraft._Closure$__10-0 CS$<>8__locals2 = new ModMinecraft._Closure$__10-0(CS$<>8__locals2);
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2 = CS$<>8__locals1;
					CS$<>8__locals2.$VB$Local_Entry = enumerator.Current;
					Thread thread = new Thread(delegate()
					{
						try
						{
							CS$<>8__locals2.$VB$Local_Entry.Check();
							ModBase.Log("[Java] " + CS$<>8__locals2.$VB$Local_Entry.ToString(), ModBase.LogLevel.Normal, "出现错误");
							object $VB$Local_ListLock = CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_ListLock;
							ObjectFlowControl.CheckForSyncLockOnValueType($VB$Local_ListLock);
							lock ($VB$Local_ListLock)
							{
								CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_JavaCheckList.Add(CS$<>8__locals2.$VB$Local_Entry);
							}
						}
						catch (Exception ex)
						{
							if (CS$<>8__locals2.$VB$Local_Entry.readerAlgo)
							{
								ModBase.Log(ex, "位于 " + CS$<>8__locals2.$VB$Local_Entry.m_AnnotationAlgo + " 的 Java 存在异常，将被自动移除", ModBase.LogLevel.Hint, "出现错误");
							}
							else
							{
								ModBase.Log(ex, "位于 " + CS$<>8__locals2.$VB$Local_Entry.m_AnnotationAlgo + " 的 Java 存在异常", ModBase.LogLevel.Debug, "出现错误");
							}
						}
					});
					list.Add(thread);
					thread.Start();
				}
				goto IL_CA;
			}
			finally
			{
				List<ModMinecraft.JavaEntry>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			try
			{
				IL_97:
				List<Thread>.Enumerator enumerator2 = list.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.IsAlive)
					{
						goto IL_CA;
					}
				}
				goto IL_D3;
			}
			finally
			{
				List<Thread>.Enumerator enumerator2;
				((IDisposable)enumerator2).Dispose();
			}
			goto IL_CA;
			IL_D3:
			return CS$<>8__locals1.$VB$Local_JavaCheckList;
			IL_CA:
			Thread.Sleep(0xA);
			goto IL_97;
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x000489B4 File Offset: 0x00046BB4
		private static void JavaSearchFolder(string OriginalPath, ref Dictionary<string, bool> Results, bool Source, bool IsFullSearch = false)
		{
			try
			{
				ModBase.Log("[Java] 开始" + (IsFullSearch ? "完全" : "部分") + "遍历查找：" + OriginalPath, ModBase.LogLevel.Normal, "出现错误");
				ModMinecraft.JavaSearchFolder(new DirectoryInfo(OriginalPath), ref Results, Source, IsFullSearch);
			}
			catch (UnauthorizedAccessException ex)
			{
				ModBase.Log("[Java] 遍历查找 Java 时遭遇无权限的文件夹：" + OriginalPath, ModBase.LogLevel.Normal, "出现错误");
			}
			catch (Exception ex2)
			{
				ModBase.Log(ex2, "遍历查找 Java 时出错（" + OriginalPath + "）", ModBase.LogLevel.Debug, "出现错误");
			}
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x00048A68 File Offset: 0x00046C68
		private static void JavaSearchFolder(DirectoryInfo OriginalPath, ref Dictionary<string, bool> Results, bool Source, bool IsFullSearch = false)
		{
			try
			{
				if (OriginalPath.Exists)
				{
					string text = OriginalPath.FullName.Replace("\\\\", "\\");
					if (!text.EndsWith("\\"))
					{
						text += "\\";
					}
					if (File.Exists(text + "javaw.exe"))
					{
						ModBase.DictionaryAdd<string, bool>(ref Results, text, Source);
					}
					try
					{
						foreach (DirectoryInfo directoryInfo in OriginalPath.EnumerateDirectories())
						{
							if (!directoryInfo.Attributes.HasFlag(FileAttributes.ReparsePoint))
							{
								string text2 = ModBase.GetFolderNameFromPath(directoryInfo.Name).ToLower();
								if (IsFullSearch || text2.Contains("java") || text2.Contains("jdk") || text2.Contains("env") || text2.Contains("环境") || text2.Contains("run") || text2.Contains("软件") || text2.Contains("jre") || Operators.CompareString(text2, "bin", true) == 0 || text2.Contains("mc") || text2.Contains("software") || text2.Contains("cache") || text2.Contains("temp") || text2.Contains("minecraft") || text2.Contains("roaming") || text2.Contains("users") || text2.Contains("craft") || text2.Contains("program") || text2.Contains("世界") || text2.Contains("net") || text2.Contains("游戏") || text2.Contains("oracle") || text2.Contains("game") || text2.Contains("file") || text2.Contains("data") || text2.Contains("jvm") || text2.Contains("服务") || text2.Contains("server") || text2.Contains("客户") || text2.Contains("client") || text2.Contains("整合") || text2.Contains("应用") || text2.Contains("运行") || text2.Contains("前置") || text2.Contains("mojang") || text2.Contains("官启") || text2.Contains("新建文件夹") || text2.Contains("eclipse") || text2.Contains("runtime") || text2.Contains("x86") || text2.Contains("x64") || text2.Contains("forge") || text2.Contains("原版") || text2.Contains("optifine") || text2.Contains("官方") || text2.Contains("启动") || text2.Contains("hmcl") || text2.Contains("mod") || text2.Contains("高清") || text2.Contains("download") || text2.Contains("launch") || text2.Contains("程序") || text2.Contains("path") || text2.Contains("国服") || text2.Contains("网易") || text2.Contains("ext") || text2.Contains("netease") || text2.Contains("1.") || text2.Contains("启动"))
								{
									ModMinecraft.JavaSearchFolder(directoryInfo, ref Results, Source, false);
								}
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
			catch (UnauthorizedAccessException ex)
			{
				ModBase.Log("[Java] 遍历查找 Java 时遭遇无权限的文件夹：" + OriginalPath.FullName, ModBase.LogLevel.Normal, "出现错误");
			}
			catch (Exception ex2)
			{
				ModBase.Log(ex2, "遍历查找 Java 时出错（" + OriginalPath.FullName + "）", ModBase.LogLevel.Debug, "出现错误");
			}
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x00048F68 File Offset: 0x00047168
		public static ModMinecraft.JavaEntry JavaSelect(Version MinVersion = null, Version MaxVersion = null, ModMinecraft.McVersion RelatedVersion = null)
		{
			ModMinecraft.JavaEntry result;
			try
			{
				List<ModMinecraft.JavaEntry> list = new List<ModMinecraft.JavaEntry>();
				Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
				if (ModMinecraft.m_ResolverIterator.Split(new char[]
				{
					'\\'
				}).Count<string>() > 3)
				{
					ModMinecraft.JavaSearchFolder(ModBase.GetPathFromFullPath(ModMinecraft.m_ResolverIterator), ref dictionary, false, true);
				}
				ModMinecraft.JavaSearchFolder(ModMinecraft.m_ResolverIterator, ref dictionary, false, true);
				if (RelatedVersion != null)
				{
					ModMinecraft.JavaSearchFolder(RelatedVersion.Path, ref dictionary, false, true);
				}
				List<ModMinecraft.JavaEntry> list2 = new List<ModMinecraft.JavaEntry>();
				try
				{
					foreach (KeyValuePair<string, bool> keyValuePair in dictionary)
					{
						list2.Add(new ModMinecraft.JavaEntry(keyValuePair.Key, keyValuePair.Value));
					}
				}
				finally
				{
					Dictionary<string, bool>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				ModBase.Log("[Java] 找到 " + Conversions.ToString(list2.Count) + " 个特定目录下的 Java", ModBase.LogLevel.Normal, "出现错误");
				list2 = ModMinecraft.JavaCheckList(list2);
				ModMinecraft.JavaEntry javaEntry3;
				for (;;)
				{
					if (ModMinecraft._PredicateIterator.State == ModBase.LoadState.Loading)
					{
						goto IL_3D1;
					}
					IL_E5:
					List<ModMinecraft.JavaEntry> list3 = new List<ModMinecraft.JavaEntry>();
					list3.AddRange(list2);
					list3.AddRange(ModMinecraft._ConfigurationIterator);
					try
					{
						foreach (ModMinecraft.JavaEntry javaEntry in list3)
						{
							if ((MinVersion == null || !(javaEntry._RegAlgo < MinVersion)) && (MaxVersion == null || !(javaEntry._RegAlgo > MaxVersion)) && (!javaEntry.m_ParamAlgo || !ModBase.m_MapperRule))
							{
								list.Add(javaEntry);
							}
						}
					}
					finally
					{
						List<ModMinecraft.JavaEntry>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
					if (list.Count == 0 && ModMinecraft._PredicateIterator.State == ModBase.LoadState.Waiting)
					{
						ModBase.Log("[Java] 未找到满足条件的 Java，尝试进行搜索", ModBase.LogLevel.Normal, "出现错误");
						ModMinecraft._PredicateIterator.Start(0, false);
						continue;
					}
					if (list.Count != 0)
					{
						string text = Conversions.ToString(ModBase._BaseRule.Get("LaunchArgumentJavaSelect", null));
						if (RelatedVersion != null)
						{
							string text2 = Conversions.ToString(ModBase._BaseRule.Get("VersionArgumentJavaSelect", RelatedVersion));
							if (Operators.CompareString(text2, "使用全局设置", true) != 0)
							{
								text = text2;
							}
						}
						if (Operators.CompareString(text, "", true) == 0)
						{
							goto IL_2FE;
						}
						ModMinecraft.JavaEntry javaEntry2;
						try
						{
							javaEntry2 = ModMinecraft.JavaEntry.FromJson((JObject)ModBase.GetJson(text));
						}
						catch (Exception ex)
						{
							ModBase._BaseRule.Set("LaunchArgumentJavaSelect", "", false, null);
							ModBase.Log(ex, "获取储存的 Java 失败", ModBase.LogLevel.Debug, "出现错误");
							goto IL_361;
						}
						try
						{
							List<ModMinecraft.JavaEntry>.Enumerator enumerator3 = list.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								if (Operators.CompareString(enumerator3.Current.m_AnnotationAlgo, javaEntry2.m_AnnotationAlgo, true) == 0)
								{
									list = new List<ModMinecraft.JavaEntry>
									{
										javaEntry2
									};
									goto IL_361;
								}
							}
						}
						finally
						{
							List<ModMinecraft.JavaEntry>.Enumerator enumerator3;
							((IDisposable)enumerator3).Dispose();
						}
						ModBase.Log("[Java] 发现用户指定的不兼容 Java：" + javaEntry2.ToString(), ModBase.LogLevel.Normal, "出现错误");
						if (ModMain.MyMsgBox("你在设置中指定的 Java 可能不兼容当前环境，这可能会导致出错。\r\n是否要继续使用设置中强制指定的 Java？", "Java 兼容性警告", "取消，让 PCL2 自动选择", "继续", "", false, true, false) == 2)
						{
							ModBase.Log("[Java] 已强制使用用户指定的不兼容 Java", ModBase.LogLevel.Normal, "出现错误");
							list = new List<ModMinecraft.JavaEntry>
							{
								javaEntry2
							};
							goto IL_2FE;
						}
						goto IL_2FE;
						IL_361:
						list = ModBase.Sort<ModMinecraft.JavaEntry>(list, (ModMinecraft._Closure$__.$IR14-3 == null) ? (ModMinecraft._Closure$__.$IR14-3 = ((object a0, object a1) => ModMinecraft.JavaSorter((ModMinecraft.JavaEntry)a0, (ModMinecraft.JavaEntry)a1))) : ModMinecraft._Closure$__.$IR14-3);
						javaEntry3 = list.First<ModMinecraft.JavaEntry>();
						try
						{
							javaEntry3.Check();
							goto IL_3E7;
						}
						catch (Exception ex2)
						{
							ModBase.Log(ex2, "找到的 Java 已无法使用，尝试进行搜索", ModBase.LogLevel.Debug, "出现错误");
							ModMinecraft._PredicateIterator.Start(ModBase.GetUuid(), false);
							continue;
						}
						goto IL_3D1;
						IL_2FE:
						try
						{
							foreach (ModMinecraft.JavaEntry javaEntry4 in list)
							{
								if (list2.Contains(javaEntry4))
								{
									list = new List<ModMinecraft.JavaEntry>
									{
										javaEntry4
									};
									ModBase.Log("[Java] 使用特定目录下的 Java：" + javaEntry4.ToString(), ModBase.LogLevel.Normal, "出现错误");
									break;
								}
							}
						}
						finally
						{
							List<ModMinecraft.JavaEntry>.Enumerator enumerator4;
							((IDisposable)enumerator4).Dispose();
						}
						goto IL_361;
					}
					break;
					IL_3D1:
					ModMinecraft._PredicateIterator.WaitForExit(0, null, false);
					goto IL_E5;
				}
				return null;
				IL_3E7:
				ModBase.Log("[Java] 选定的 Java：" + javaEntry3.ToString(), ModBase.LogLevel.Normal, "出现错误");
				result = javaEntry3;
			}
			catch (Exception ex3)
			{
				ModBase.Log(ex3, "查找符合条件的 Java 失败", ModBase.LogLevel.Feedback, "出现错误");
				result = null;
			}
			return result;
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x00049450 File Offset: 0x00047650
		public static bool JavaUse64Bit(ModMinecraft.McVersion RelatedVersion = null)
		{
			bool result;
			try
			{
				string text = Conversions.ToString(ModBase._BaseRule.Get("LaunchArgumentJavaSelect", null));
				if (RelatedVersion != null)
				{
					string text2 = Conversions.ToString(ModBase._BaseRule.Get("VersionArgumentJavaSelect", RelatedVersion));
					if (Operators.CompareString(text2, "使用全局设置", true) != 0)
					{
						text = text2;
					}
				}
				if (Operators.CompareString(text, "", true) != 0)
				{
					ModMinecraft.JavaEntry javaEntry = ModMinecraft.JavaEntry.FromJson((JObject)ModBase.GetJson(text));
					try
					{
						List<ModMinecraft.JavaEntry>.Enumerator enumerator = ModMinecraft._ConfigurationIterator.GetEnumerator();
						while (enumerator.MoveNext())
						{
							if (Operators.CompareString(enumerator.Current.m_AnnotationAlgo, javaEntry.m_AnnotationAlgo, true) == 0)
							{
								return javaEntry.m_ParamAlgo;
							}
						}
					}
					finally
					{
						List<ModMinecraft.JavaEntry>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
				}
				try
				{
					List<ModMinecraft.JavaEntry>.Enumerator enumerator2 = ModMinecraft._ConfigurationIterator.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.m_ParamAlgo)
						{
							return true;
						}
					}
				}
				finally
				{
					List<ModMinecraft.JavaEntry>.Enumerator enumerator2;
					((IDisposable)enumerator2).Dispose();
				}
				result = false;
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "检查 Java 类别时出错", ModBase.LogLevel.Feedback, "出现错误");
				ModBase._BaseRule.Set("LaunchArgumentJavaSelect", "", false, null);
				ModBase._BaseRule.Set("VersionArgumentJavaSelect", "", false, RelatedVersion);
				result = true;
			}
			return result;
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x000495C0 File Offset: 0x000477C0
		public static bool JavaSorter(ModMinecraft.JavaEntry Left, ModMinecraft.JavaEntry Right)
		{
			string value = "";
			string fullName = (new DirectoryInfo(ModBase.Path).Parent ?? new DirectoryInfo(ModBase.Path)).FullName;
			if (Operators.CompareString(ModMinecraft.m_ResolverIterator, "", true) != 0)
			{
				value = (new DirectoryInfo(ModMinecraft.m_ResolverIterator).Parent ?? new DirectoryInfo(ModMinecraft.m_ResolverIterator)).FullName;
			}
			bool result;
			if (Left.m_AnnotationAlgo.StartsWith(fullName) && !Right.m_AnnotationAlgo.StartsWith(fullName))
			{
				result = true;
			}
			else if (!Left.m_AnnotationAlgo.StartsWith(fullName) && Right.m_AnnotationAlgo.StartsWith(fullName))
			{
				result = false;
			}
			else
			{
				if (Operators.CompareString(ModMinecraft.m_ResolverIterator, "", true) != 0)
				{
					if (Left.m_AnnotationAlgo.StartsWith(value) && !Right.m_AnnotationAlgo.StartsWith(value))
					{
						return true;
					}
					if (!Left.m_AnnotationAlgo.StartsWith(value) && Right.m_AnnotationAlgo.StartsWith(value))
					{
						return false;
					}
				}
				if (Left.m_ParamAlgo && !Right.m_ParamAlgo)
				{
					result = true;
				}
				else if (!Left.m_ParamAlgo && Right.m_ParamAlgo)
				{
					result = false;
				}
				else if (Left.m_DefinitionAlgo && !Right.m_DefinitionAlgo)
				{
					result = true;
				}
				else if (!Left.m_DefinitionAlgo && Right.m_DefinitionAlgo)
				{
					result = false;
				}
				else if (Left.ResetExpression() != Right.ResetExpression())
				{
					int[] source = new int[]
					{
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0x12,
						0x13,
						0xD,
						0xC,
						0xB,
						0xA,
						9,
						8,
						7,
						0x11,
						0x10,
						0xF,
						0xE
					};
					result = (source.ElementAtOrDefault(Left.ResetExpression()) >= source.ElementAtOrDefault(Right.ResetExpression()));
				}
				else
				{
					result = checked(Math.Abs(Left._RegAlgo.Revision - 0x33) <= Math.Abs(Right._RegAlgo.Revision - 0x33));
				}
			}
			return result;
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x00049790 File Offset: 0x00047990
		public static void JavaMissing(int VersionCode)
		{
			if (VersionCode == 7)
			{
				ModMain.MyMsgBox("PCL2 未找到 Java 7。\r\n请自行百度安装 Java 7，安装后在 PCL2 的 设置 → 启动设置 → 游戏 Java 中通过搜索或导入，确保安装的 Java 已列入 Java 列表。", "未找到 Java", "确定", "", "", false, true, false);
				return;
			}
			if (VersionCode == 8)
			{
				if (ModBase.m_MapperRule)
				{
					ModBase.OpenWebsite("https://wwa.lanzoui.com/i7RyXq0jbub");
				}
				else
				{
					ModBase.OpenWebsite("https://wwa.lanzoui.com/i2UyMq0jaqb");
				}
				ModMain.MyMsgBox("PCL2 未找到版本适宜的 Java 8。\r\n请在打开的网页中下载安装包并安装，安装后在 PCL2 的 设置 → 启动设置 → 游戏 Java 中通过搜索或导入，确保安装的 Java 已列入 Java 列表。", "未找到 Java", "确定", "", "", false, true, false);
				return;
			}
			if (VersionCode != 0x10)
			{
				return;
			}
			if (ModBase.m_MapperRule)
			{
				ModMain.MyMsgBox("该版本已不支持 32 位操作系统。你必须增加内存并重装为 64 位系统才能继续。", "系统兼容性提示", "确定", "", "", false, true, false);
				return;
			}
			ModBase.OpenWebsite("https://www.oracle.com/java/technologies/javase-jdk16-downloads.html");
			ModMain.MyMsgBox("PCL2 未找到 Java 16。\r\n请在打开的网页中下载 Windows x64 Installer 并安装。\r\n安装后在 PCL2 的 设置 → 启动设置 → 游戏 Java 中通过搜索或导入，确保安装的 Java 已列入 Java 列表。", "未找到 Java", "确定", "", "", false, true, false);
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x0004986C File Offset: 0x00047A6C
		private static void McFolderListLoadSub()
		{
			checked
			{
				try
				{
					List<ModMinecraft.McFolder> list = new List<ModMinecraft.McFolder>();
					if (ModBase.CheckPermission(ModBase.Path) && Directory.Exists(ModBase.Path + "versions\\"))
					{
						list.Add(new ModMinecraft.McFolder
						{
							Name = "当前文件夹",
							Path = ModBase.Path,
							Type = ModMinecraft.McFolderType.Original
						});
					}
					foreach (DirectoryInfo directoryInfo in new DirectoryInfo(ModBase.Path).GetDirectories())
					{
						if ((ModBase.CheckPermission(directoryInfo.FullName) && Directory.Exists(directoryInfo.FullName + "versions\\")) || Operators.CompareString(directoryInfo.Name, ".minecraft", true) == 0)
						{
							list.Add(new ModMinecraft.McFolder
							{
								Name = "当前文件夹",
								Path = directoryInfo.FullName + "\\",
								Type = ModMinecraft.McFolderType.Original
							});
						}
					}
					string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\";
					if ((list.Count == 0 || Operators.CompareString(text, list[0].Path, true) != 0) && ModBase.CheckPermission(text) && Directory.Exists(text + "versions\\"))
					{
						list.Add(new ModMinecraft.McFolder
						{
							Name = "官方启动器文件夹",
							Path = text,
							Type = ModMinecraft.McFolderType.Original
						});
					}
					try
					{
						foreach (object value in ((IEnumerable)NewLateBinding.LateGet(ModBase._BaseRule.Get("LaunchFolders", null), null, "Split", new object[]
						{
							"|"
						}, null, null, null)))
						{
							string text2 = Conversions.ToString(value);
							if (Operators.CompareString(text2, "", true) != 0)
							{
								if (text2.Contains(">") && text2.EndsWith("\\"))
								{
									string name = text2.Split(new char[]
									{
										'>'
									})[0];
									string text3 = text2.Split(new char[]
									{
										'>'
									})[1];
									if (ModBase.CheckPermission(text3))
									{
										bool flag = false;
										try
										{
											foreach (ModMinecraft.McFolder mcFolder in list)
											{
												if (Operators.CompareString(mcFolder.Path, text3, true) == 0)
												{
													mcFolder.Name = name;
													mcFolder.Type = ModMinecraft.McFolderType.RenamedOriginal;
													flag = true;
												}
											}
										}
										finally
										{
											List<ModMinecraft.McFolder>.Enumerator enumerator2;
											((IDisposable)enumerator2).Dispose();
										}
										if (!flag)
										{
											list.Add(new ModMinecraft.McFolder
											{
												Name = name,
												Path = text3,
												Type = ModMinecraft.McFolderType.Custom
											});
										}
									}
									else
									{
										ModMain.Hint("无效的 Minecraft 文件夹：" + text3, ModMain.HintType.Critical, true);
									}
								}
								else
								{
									ModMain.Hint("无效的 Minecraft 文件夹：" + text2, ModMain.HintType.Critical, true);
								}
							}
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
					ArrayList arrayList = new ArrayList();
					try
					{
						foreach (ModMinecraft.McFolder mcFolder2 in list)
						{
							if (mcFolder2.Type != ModMinecraft.McFolderType.Original)
							{
								arrayList.Add(mcFolder2.Name + ">" + mcFolder2.Path);
							}
						}
					}
					finally
					{
						List<ModMinecraft.McFolder>.Enumerator enumerator3;
						((IDisposable)enumerator3).Dispose();
					}
					if (arrayList.Count == 0)
					{
						arrayList.Add("");
					}
					ModBase._BaseRule.Set("LaunchFolders", ModBase.Join(arrayList.ToArray(), "|"), false, null);
					if (list.Count == 0)
					{
						Directory.CreateDirectory(ModBase.Path + ".minecraft\\versions\\");
						list.Add(new ModMinecraft.McFolder
						{
							Name = "当前文件夹",
							Path = ModBase.Path + ".minecraft\\",
							Type = ModMinecraft.McFolderType.Original
						});
					}
					try
					{
						foreach (ModMinecraft.McFolder mcFolder3 in list)
						{
							if (Directory.Exists(mcFolder3.Path + "versions\\"))
							{
								mcFolder3.mockAlgo = new DirectoryInfo(mcFolder3.Path + "versions\\").GetDirectories().Count<DirectoryInfo>();
								DirectoryInfo[] directories2 = new DirectoryInfo(mcFolder3.Path + "versions\\").GetDirectories();
								for (int j = 0; j < directories2.Length; j++)
								{
									if (Conversions.ToBoolean(ModBase.ReadIni(directories2[j].FullName + "\\PCL\\Setup.ini", "Hide", "False")))
									{
										ModMinecraft.McFolder mcFolder4 = mcFolder3;
										ref int ptr = ref mcFolder4.mockAlgo;
										mcFolder4.mockAlgo = ptr - 1;
									}
								}
							}
							ModMinecraft.McFolderLauncherProfilesJsonCreate(mcFolder3.Path);
						}
					}
					finally
					{
						List<ModMinecraft.McFolder>.Enumerator enumerator4;
						((IDisposable)enumerator4).Dispose();
					}
					if (Conversions.ToBoolean(ModBase._BaseRule.Get("SystemDebugDelay", null)))
					{
						Thread.Sleep(ModBase.RandomInteger(0xC8, 0x7D0));
					}
					ModMinecraft.collectionIterator = list;
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "加载 Minecraft 文件夹列表失败", ModBase.LogLevel.Feedback, "出现错误");
				}
				finally
				{
					ModBase.RunInUiWait(new ThreadStart(ModMinecraft.McFolderListUI));
				}
			}
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x00049E10 File Offset: 0x00048010
		private static void McFolderListUI()
		{
			checked
			{
				if (ModMain.m_DescriptorFilter != null)
				{
					try
					{
						if (ModMinecraft.broadcasterIterator != null && ModMinecraft.broadcasterIterator.SequenceEqual(ModMinecraft.collectionIterator))
						{
							bool flag = true;
							int num = ModMinecraft.broadcasterIterator.Count - 1;
							int i = 0;
							while (i <= num)
							{
								if (ModMinecraft.broadcasterIterator[i].Equals(ModMinecraft.collectionIterator[i]))
								{
									i++;
								}
								else
								{
									flag = false;
									IL_65:
									if (flag)
									{
										return;
									}
									goto IL_6D;
								}
							}
							goto IL_65;
						}
						IL_6D:
						if (!ModMinecraft._TestsIterator.IsAborted)
						{
							ModMinecraft.broadcasterIterator = ModMinecraft.collectionIterator;
							ModMain.m_DescriptorFilter.PanList.Children.Clear();
							ModMain.m_DescriptorFilter.PanList.Children.Add(new TextBlock
							{
								Text = "文件夹列表",
								Margin = new Thickness(13.0, 18.0, 5.0, 4.0),
								Opacity = 0.6,
								FontSize = 12.0
							});
							foreach (ModMinecraft.McFolder mcFolder in ModMinecraft.collectionIterator.ToArray())
							{
								ModMinecraft._Closure$__24-0 CS$<>8__locals1 = new ModMinecraft._Closure$__24-0(CS$<>8__locals1);
								CS$<>8__locals1.$VB$Local_ContMenu = null;
								switch (mcFolder.Type)
								{
								case ModMinecraft.McFolderType.Original:
								{
									ModMinecraft._Closure$__24-0 CS$<>8__locals2 = CS$<>8__locals1;
									XElement xelement = new XElement(XName.Get("ContextMenu", "http://schemas.microsoft.com/winfx/2006/xaml/presentation"));
									xelement.Add(new XAttribute(XName.Get("xmlns", ""), "http://schemas.microsoft.com/winfx/2006/xaml/presentation"));
									xelement.Add(new XAttribute(XName.Get("x", "http://www.w3.org/2000/xmlns/"), "http://schemas.microsoft.com/winfx/2006/xaml"));
									xelement.Add(new XAttribute(XName.Get("local", "http://www.w3.org/2000/xmlns/"), "clr-namespace:PCL;assembly=Plain Craft Launcher 2"));
									XElement xelement2 = new XElement(XName.Get("MyMenuItem", "clr-namespace:PCL;assembly=Plain Craft Launcher 2"));
									xelement2.Add(new XAttribute(XName.Get("Name", "http://schemas.microsoft.com/winfx/2006/xaml"), "Rename"));
									xelement2.Add(new XAttribute(XName.Get("Header", ""), "重命名"));
									xelement2.Add(new XAttribute(XName.Get("Padding", ""), "0,2,0,0"));
									xelement2.Add(new XAttribute(XName.Get("Icon", ""), "F1 M 53.2929,21.2929L 54.7071,22.7071C 56.4645,24.4645 56.4645,27.3137 54.7071,29.0711L 52.2323,31.5459L 44.4541,23.7677L 46.9289,21.2929C 48.6863,19.5355 51.5355,19.5355 53.2929,21.2929 Z M 31.7262,52.052L 23.948,44.2738L 43.0399,25.182L 50.818,32.9601L 31.7262,52.052 Z M 23.2409,47.1023L 28.8977,52.7591L 21.0463,54.9537L 23.2409,47.1023 Z"));
									xelement.Add(xelement2);
									XElement xelement3 = new XElement(XName.Get("MyMenuItem", "clr-namespace:PCL;assembly=Plain Craft Launcher 2"));
									xelement3.Add(new XAttribute(XName.Get("Name", "http://schemas.microsoft.com/winfx/2006/xaml"), "Open"));
									xelement3.Add(new XAttribute(XName.Get("Header", ""), "打开"));
									xelement3.Add(new XAttribute(XName.Get("Icon", ""), "F1 M 19,50L 28,34L 63,34L 54,50L 19,50 Z M 19,28.0001L 35,28C 36,25 37.4999,24.0001 37.4999,24.0001L 48.75,24C 49.3023,24 50,24.6977 50,25.25L 50,28L 54,28.0001L 54,32L 27,32L 19,46.4L 19,28.0001 Z"));
									xelement.Add(xelement3);
									XElement xelement4 = new XElement(XName.Get("MyMenuItem", "clr-namespace:PCL;assembly=Plain Craft Launcher 2"));
									xelement4.Add(new XAttribute(XName.Get("Name", "http://schemas.microsoft.com/winfx/2006/xaml"), "Refresh"));
									xelement4.Add(new XAttribute(XName.Get("Header", ""), "刷新"));
									xelement4.Add(new XAttribute(XName.Get("Icon", ""), "F1 M 38,20.5833C 42.9908,20.5833 47.4912,22.6825 50.6667,26.046L 50.6667,17.4167L 55.4166,22.1667L 55.4167,34.8333L 42.75,34.8333L 38,30.0833L 46.8512,30.0833C 44.6768,27.6539 41.517,26.125 38,26.125C 31.9785,26.125 27.0037,30.6068 26.2296,36.4167L 20.6543,36.4167C 21.4543,27.5397 28.9148,20.5833 38,20.5833 Z M 38,49.875C 44.0215,49.875 48.9963,45.3932 49.7703,39.5833L 55.3457,39.5833C 54.5457,48.4603 47.0852,55.4167 38,55.4167C 33.0092,55.4167 28.5088,53.3175 25.3333,49.954L 25.3333,58.5833L 20.5833,53.8333L 20.5833,41.1667L 33.25,41.1667L 38,45.9167L 29.1487,45.9167C 31.3231,48.3461 34.483,49.875 38,49.875 Z"));
									xelement.Add(xelement4);
									XElement xelement5 = new XElement(XName.Get("MyMenuItem", "clr-namespace:PCL;assembly=Plain Craft Launcher 2"));
									xelement5.Add(new XAttribute(XName.Get("Name", "http://schemas.microsoft.com/winfx/2006/xaml"), "Delete"));
									xelement5.Add(new XAttribute(XName.Get("Header", ""), "删除"));
									xelement5.Add(new XAttribute(XName.Get("Padding", ""), "0,0,0,2"));
									xelement5.Add(new XAttribute(XName.Get("Icon", ""), "F1 M 26.9166,22.1667L 37.9999,33.25L 49.0832,22.1668L 53.8332,26.9168L 42.7499,38L 53.8332,49.0834L 49.0833,53.8334L 37.9999,42.75L 26.9166,53.8334L 22.1666,49.0833L 33.25,38L 22.1667,26.9167L 26.9166,22.1667 Z "));
									xelement.Add(xelement5);
									CS$<>8__locals2.$VB$Local_ContMenu = (ContextMenu)ModBase.GetObjectFromXML(xelement);
									break;
								}
								case ModMinecraft.McFolderType.RenamedOriginal:
								{
									ModMinecraft._Closure$__24-0 CS$<>8__locals3 = CS$<>8__locals1;
									XElement xelement6 = new XElement(XName.Get("ContextMenu", "http://schemas.microsoft.com/winfx/2006/xaml/presentation"));
									xelement6.Add(new XAttribute(XName.Get("xmlns", ""), "http://schemas.microsoft.com/winfx/2006/xaml/presentation"));
									xelement6.Add(new XAttribute(XName.Get("x", "http://www.w3.org/2000/xmlns/"), "http://schemas.microsoft.com/winfx/2006/xaml"));
									xelement6.Add(new XAttribute(XName.Get("local", "http://www.w3.org/2000/xmlns/"), "clr-namespace:PCL;assembly=Plain Craft Launcher 2"));
									XElement xelement7 = new XElement(XName.Get("MyMenuItem", "clr-namespace:PCL;assembly=Plain Craft Launcher 2"));
									xelement7.Add(new XAttribute(XName.Get("Name", "http://schemas.microsoft.com/winfx/2006/xaml"), "Remove"));
									xelement7.Add(new XAttribute(XName.Get("Header", ""), "复原名称"));
									xelement7.Add(new XAttribute(XName.Get("Padding", ""), "0,2,0,0"));
									xelement7.Add(new XAttribute(XName.Get("Icon", ""), "F1 M 53.2929,21.2929L 54.7071,22.7071C 56.4645,24.4645 56.4645,27.3137 54.7071,29.0711L 52.2323,31.5459L 44.4541,23.7677L 46.9289,21.2929C 48.6863,19.5355 51.5355,19.5355 53.2929,21.2929 Z M 31.7262,52.052L 23.948,44.2738L 43.0399,25.182L 50.818,32.9601L 31.7262,52.052 Z M 23.2409,47.1023L 28.8977,52.7591L 21.0463,54.9537L 23.2409,47.1023 Z"));
									xelement6.Add(xelement7);
									XElement xelement8 = new XElement(XName.Get("MyMenuItem", "clr-namespace:PCL;assembly=Plain Craft Launcher 2"));
									xelement8.Add(new XAttribute(XName.Get("Name", "http://schemas.microsoft.com/winfx/2006/xaml"), "Rename"));
									xelement8.Add(new XAttribute(XName.Get("Header", ""), "重命名"));
									xelement8.Add(new XAttribute(XName.Get("Icon", ""), "F1 M 53.2929,21.2929L 54.7071,22.7071C 56.4645,24.4645 56.4645,27.3137 54.7071,29.0711L 52.2323,31.5459L 44.4541,23.7677L 46.9289,21.2929C 48.6863,19.5355 51.5355,19.5355 53.2929,21.2929 Z M 31.7262,52.052L 23.948,44.2738L 43.0399,25.182L 50.818,32.9601L 31.7262,52.052 Z M 23.2409,47.1023L 28.8977,52.7591L 21.0463,54.9537L 23.2409,47.1023 Z"));
									xelement6.Add(xelement8);
									XElement xelement9 = new XElement(XName.Get("MyMenuItem", "clr-namespace:PCL;assembly=Plain Craft Launcher 2"));
									xelement9.Add(new XAttribute(XName.Get("Name", "http://schemas.microsoft.com/winfx/2006/xaml"), "Open"));
									xelement9.Add(new XAttribute(XName.Get("Header", ""), "打开"));
									xelement9.Add(new XAttribute(XName.Get("Icon", ""), "F1 M 19,50L 28,34L 63,34L 54,50L 19,50 Z M 19,28.0001L 35,28C 36,25 37.4999,24.0001 37.4999,24.0001L 48.75,24C 49.3023,24 50,24.6977 50,25.25L 50,28L 54,28.0001L 54,32L 27,32L 19,46.4L 19,28.0001 Z"));
									xelement6.Add(xelement9);
									XElement xelement10 = new XElement(XName.Get("MyMenuItem", "clr-namespace:PCL;assembly=Plain Craft Launcher 2"));
									xelement10.Add(new XAttribute(XName.Get("Name", "http://schemas.microsoft.com/winfx/2006/xaml"), "Refresh"));
									xelement10.Add(new XAttribute(XName.Get("Header", ""), "刷新"));
									xelement10.Add(new XAttribute(XName.Get("Icon", ""), "F1 M 38,20.5833C 42.9908,20.5833 47.4912,22.6825 50.6667,26.046L 50.6667,17.4167L 55.4166,22.1667L 55.4167,34.8333L 42.75,34.8333L 38,30.0833L 46.8512,30.0833C 44.6768,27.6539 41.517,26.125 38,26.125C 31.9785,26.125 27.0037,30.6068 26.2296,36.4167L 20.6543,36.4167C 21.4543,27.5397 28.9148,20.5833 38,20.5833 Z M 38,49.875C 44.0215,49.875 48.9963,45.3932 49.7703,39.5833L 55.3457,39.5833C 54.5457,48.4603 47.0852,55.4167 38,55.4167C 33.0092,55.4167 28.5088,53.3175 25.3333,49.954L 25.3333,58.5833L 20.5833,53.8333L 20.5833,41.1667L 33.25,41.1667L 38,45.9167L 29.1487,45.9167C 31.3231,48.3461 34.483,49.875 38,49.875 Z"));
									xelement6.Add(xelement10);
									XElement xelement11 = new XElement(XName.Get("MyMenuItem", "clr-namespace:PCL;assembly=Plain Craft Launcher 2"));
									xelement11.Add(new XAttribute(XName.Get("Name", "http://schemas.microsoft.com/winfx/2006/xaml"), "Delete"));
									xelement11.Add(new XAttribute(XName.Get("Header", ""), "删除"));
									xelement11.Add(new XAttribute(XName.Get("Padding", ""), "0,0,0,2"));
									xelement11.Add(new XAttribute(XName.Get("Icon", ""), "F1 M 26.9166,22.1667L 37.9999,33.25L 49.0832,22.1668L 53.8332,26.9168L 42.7499,38L 53.8332,49.0834L 49.0833,53.8334L 37.9999,42.75L 26.9166,53.8334L 22.1666,49.0833L 33.25,38L 22.1667,26.9167L 26.9166,22.1667 Z "));
									xelement6.Add(xelement11);
									CS$<>8__locals3.$VB$Local_ContMenu = (ContextMenu)ModBase.GetObjectFromXML(xelement6);
									break;
								}
								case ModMinecraft.McFolderType.Custom:
								{
									ModMinecraft._Closure$__24-0 CS$<>8__locals4 = CS$<>8__locals1;
									XElement xelement12 = new XElement(XName.Get("ContextMenu", "http://schemas.microsoft.com/winfx/2006/xaml/presentation"));
									xelement12.Add(new XAttribute(XName.Get("xmlns", ""), "http://schemas.microsoft.com/winfx/2006/xaml/presentation"));
									xelement12.Add(new XAttribute(XName.Get("x", "http://www.w3.org/2000/xmlns/"), "http://schemas.microsoft.com/winfx/2006/xaml"));
									xelement12.Add(new XAttribute(XName.Get("local", "http://www.w3.org/2000/xmlns/"), "clr-namespace:PCL;assembly=Plain Craft Launcher 2"));
									XElement xelement13 = new XElement(XName.Get("MyMenuItem", "clr-namespace:PCL;assembly=Plain Craft Launcher 2"));
									xelement13.Add(new XAttribute(XName.Get("Name", "http://schemas.microsoft.com/winfx/2006/xaml"), "Rename"));
									xelement13.Add(new XAttribute(XName.Get("Header", ""), "重命名"));
									xelement13.Add(new XAttribute(XName.Get("Padding", ""), "0,2,0,0"));
									xelement13.Add(new XAttribute(XName.Get("Icon", ""), "F1 M 53.2929,21.2929L 54.7071,22.7071C 56.4645,24.4645 56.4645,27.3137 54.7071,29.0711L 52.2323,31.5459L 44.4541,23.7677L 46.9289,21.2929C 48.6863,19.5355 51.5355,19.5355 53.2929,21.2929 Z M 31.7262,52.052L 23.948,44.2738L 43.0399,25.182L 50.818,32.9601L 31.7262,52.052 Z M 23.2409,47.1023L 28.8977,52.7591L 21.0463,54.9537L 23.2409,47.1023 Z"));
									xelement12.Add(xelement13);
									XElement xelement14 = new XElement(XName.Get("MyMenuItem", "clr-namespace:PCL;assembly=Plain Craft Launcher 2"));
									xelement14.Add(new XAttribute(XName.Get("Name", "http://schemas.microsoft.com/winfx/2006/xaml"), "Open"));
									xelement14.Add(new XAttribute(XName.Get("Header", ""), "打开"));
									xelement14.Add(new XAttribute(XName.Get("Icon", ""), "F1 M 19,50L 28,34L 63,34L 54,50L 19,50 Z M 19,28.0001L 35,28C 36,25 37.4999,24.0001 37.4999,24.0001L 48.75,24C 49.3023,24 50,24.6977 50,25.25L 50,28L 54,28.0001L 54,32L 27,32L 19,46.4L 19,28.0001 Z"));
									xelement12.Add(xelement14);
									XElement xelement15 = new XElement(XName.Get("MyMenuItem", "clr-namespace:PCL;assembly=Plain Craft Launcher 2"));
									xelement15.Add(new XAttribute(XName.Get("Name", "http://schemas.microsoft.com/winfx/2006/xaml"), "Refresh"));
									xelement15.Add(new XAttribute(XName.Get("Header", ""), "刷新"));
									xelement15.Add(new XAttribute(XName.Get("Icon", ""), "F1 M 38,20.5833C 42.9908,20.5833 47.4912,22.6825 50.6667,26.046L 50.6667,17.4167L 55.4166,22.1667L 55.4167,34.8333L 42.75,34.8333L 38,30.0833L 46.8512,30.0833C 44.6768,27.6539 41.517,26.125 38,26.125C 31.9785,26.125 27.0037,30.6068 26.2296,36.4167L 20.6543,36.4167C 21.4543,27.5397 28.9148,20.5833 38,20.5833 Z M 38,49.875C 44.0215,49.875 48.9963,45.3932 49.7703,39.5833L 55.3457,39.5833C 54.5457,48.4603 47.0852,55.4167 38,55.4167C 33.0092,55.4167 28.5088,53.3175 25.3333,49.954L 25.3333,58.5833L 20.5833,53.8333L 20.5833,41.1667L 33.25,41.1667L 38,45.9167L 29.1487,45.9167C 31.3231,48.3461 34.483,49.875 38,49.875 Z"));
									xelement12.Add(xelement15);
									XElement xelement16 = new XElement(XName.Get("MyMenuItem", "clr-namespace:PCL;assembly=Plain Craft Launcher 2"));
									xelement16.Add(new XAttribute(XName.Get("Name", "http://schemas.microsoft.com/winfx/2006/xaml"), "Remove"));
									xelement16.Add(new XAttribute(XName.Get("Header", ""), "移出列表"));
									xelement16.Add(new XAttribute(XName.Get("Icon", ""), "F1 M 23.3428,25.205L 23.3805,25.4461C 23.9229,27.177 30.261,29.0992 38,29.0992C 45.7386,29.0992 52.0765,27.1771 52.6194,25.4463L 52.6571,25.205C 52.6571,23.3616 46.0949,21.3109 38,21.3109C 29.9051,21.3109 23.3428,23.3616 23.3428,25.205 Z M 23.3428,53.0204L 19.1571,26.2111C 19.0534,25.8817 19,25.5459 19,25.205C 19,20.9036 27.5066,17.4167 38,17.4167C 48.4934,17.4167 57,20.9036 57,25.205C 57,25.5459 56.9466,25.8818 56.8429,26.2112L 52.6571,53.0204L 52.5974,53.0204C 51.9241,56.1393 45.6457,58.5833 38,58.5833C 30.3543,58.5833 24.076,56.1393 23.4026,53.0204L 23.3428,53.0204 Z M 51.8228,30.5485C 48.3585,32.0537 43.4469,32.9933 38,32.9933C 32.5531,32.9933 27.6415,32.0537 24.1771,30.5484L 27.5988,52.464L 27.6857,52.464C 27.6857,53.3857 32.3036,54.6892 38,54.6892C 43.6964,54.6892 48.3143,53.3857 48.3143,52.464L 48.4011,52.464L 51.8228,30.5485 Z "));
									xelement12.Add(xelement16);
									XElement xelement17 = new XElement(XName.Get("MyMenuItem", "clr-namespace:PCL;assembly=Plain Craft Launcher 2"));
									xelement17.Add(new XAttribute(XName.Get("Name", "http://schemas.microsoft.com/winfx/2006/xaml"), "Delete"));
									xelement17.Add(new XAttribute(XName.Get("Header", ""), "删除"));
									xelement17.Add(new XAttribute(XName.Get("Padding", ""), "0,0,0,2"));
									xelement17.Add(new XAttribute(XName.Get("Icon", ""), "F1 M 26.9166,22.1667L 37.9999,33.25L 49.0832,22.1668L 53.8332,26.9168L 42.7499,38L 53.8332,49.0834L 49.0833,53.8334L 37.9999,42.75L 26.9166,53.8334L 22.1666,49.0833L 33.25,38L 22.1667,26.9167L 26.9166,22.1667 Z "));
									xelement12.Add(xelement17);
									CS$<>8__locals4.$VB$Local_ContMenu = (ContextMenu)ModBase.GetObjectFromXML(xelement12);
									break;
								}
								}
								if ((mcFolder.Type == ModMinecraft.McFolderType.Original || mcFolder.Type == ModMinecraft.McFolderType.RenamedOriginal) && Operators.CompareString(mcFolder.Path, ModBase.Path + ".minecraft\\", true) == 0 && ModMinecraft.collectionIterator.Count == 1)
								{
									((MyMenuItem)CS$<>8__locals1.$VB$Local_ContMenu.FindName("Delete")).Header = "清空";
								}
								if (mcFolder.Type != ModMinecraft.McFolderType.Original)
								{
									((MyMenuItem)CS$<>8__locals1.$VB$Local_ContMenu.FindName("Remove")).AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(ModMain.m_DescriptorFilter.Remove_Click));
								}
								((MyMenuItem)CS$<>8__locals1.$VB$Local_ContMenu.FindName("Open")).AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(ModMain.m_DescriptorFilter.Open_Click));
								((MyMenuItem)CS$<>8__locals1.$VB$Local_ContMenu.FindName("Delete")).AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(ModMain.m_DescriptorFilter.Delete_Click));
								((MyMenuItem)CS$<>8__locals1.$VB$Local_ContMenu.FindName("Rename")).AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(ModMain.m_DescriptorFilter.Rename_Click));
								((MyMenuItem)CS$<>8__locals1.$VB$Local_ContMenu.FindName("Refresh")).AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(ModMain.m_DescriptorFilter.Refresh_Click));
								CS$<>8__locals1.$VB$Local_NewItem = new MyListItem
								{
									IsScaleAnimationEnabled = false,
									Type = MyListItem.CheckType.RadioBox,
									PaddingRight = 0x1E,
									Title = mcFolder.Name,
									Info = mcFolder.Path,
									Height = 40.0,
									ContextMenu = CS$<>8__locals1.$VB$Local_ContMenu,
									Tag = mcFolder
								};
								MyListItem $VB$Local_NewItem = CS$<>8__locals1.$VB$Local_NewItem;
								ModMinecraft._Closure$__R24-3 CS$<>8__locals5 = new ModMinecraft._Closure$__R24-3(CS$<>8__locals5);
								CS$<>8__locals5.$VB$NonLocal_2 = ModMain.m_DescriptorFilter;
								$VB$Local_NewItem.Changed += delegate(object sender, ModBase.RouteEventArgs e)
								{
									CS$<>8__locals5.$VB$NonLocal_2.Folder_Change((MyListItem)sender, e);
								};
								MyIconButton myIconButton = new MyIconButton
								{
									Logo = "M651.946667 1001.813333c-22.186667 0-42.666667-10.24-61.44-27.306666-23.893333-23.893333-49.493333-35.84-75.093334-35.84-29.013333 0-56.32 11.946667-73.386666 30.72v3.413333c-17.066667 17.066667-42.666667 27.306667-66.56 27.306667h-6.826667c-6.826667 0-11.946667-1.706667-15.36-1.706667l-6.826667-1.706667c-64.853333-20.48-121.173333-54.613333-168.96-98.986666-29.013333-23.893333-37.546667-63.146667-25.6-95.573334 8.533333-23.893333 5.12-51.2-10.24-75.093333-15.36-27.306667-34.133333-40.96-59.733333-47.786667h-1.706667l-5.12-1.706666c-35.84-8.533333-61.44-34.133333-66.56-69.973334C1.706667 575.146667 0 537.6 0 512c0-32.426667 3.413333-63.146667 8.533333-93.866667v-6.826666l3.413334-8.533334c10.24-23.893333 23.893333-40.96 44.373333-51.2 5.12-3.413333 11.946667-6.826667 20.48-8.533333 27.306667-8.533333 51.2-25.6 63.146667-44.373333 13.653333-23.893333 17.066667-52.906667 10.24-81.92-11.946667-34.133333 0-71.68 30.72-93.866667 44.373333-37.546667 97.28-68.266667 158.72-93.866667l3.413333-1.706666c44.373333-13.653333 75.093333 3.413333 92.16 20.48 23.893333 23.893333 49.493333 35.84 75.093333 35.84 30.72 0 56.32-10.24 71.68-30.72l3.413334-3.413334c27.306667-27.306667 63.146667-35.84 93.866666-22.186666 63.146667 22.186667 117.76 54.613333 165.546667 97.28 29.013333 23.893333 37.546667 63.146667 25.6 95.573333-8.533333 23.893333-5.12 51.2 10.24 75.093333 15.36 27.306667 34.133333 40.96 59.733333 47.786667h1.706667l5.12 1.706667c35.84 8.533333 61.44 34.133333 66.56 71.68 6.826667 30.72 10.24 63.146667 11.946667 93.866666v3.413334c0 32.426667-3.413333 63.146667-8.533334 93.866666v6.826667l-3.413333 8.533333c-10.24 23.893333-23.893333 40.96-44.373333 51.2-5.12 3.413333-11.946667 6.826667-20.48 8.533334-27.306667 8.533333-51.2 25.6-63.146667 46.08-13.653333 23.893333-17.066667 52.906667-10.24 81.92 11.946667 35.84-1.706667 75.093333-30.72 95.573333-44.373333 35.84-95.573333 66.56-157.013333 92.16-15.36 3.413333-27.306667 3.413333-35.84 3.413333z m3.413333-83.626666z m1.706667 0zM517.12 853.333333c47.786667 0 93.866667 20.48 134.826667 59.733334 1.706667 1.706667 3.413333 1.706667 3.413333 3.413333 52.906667-22.186667 97.28-49.493333 136.533333-80.213333l1.706667-1.706667v-3.413333c-13.653333-52.906667-8.533333-104.106667 17.066667-148.48 23.893333-39.253333 64.853333-69.973333 114.346666-85.333334 1.706667 0 3.413333-1.706667 6.826667-6.826666 5.12-25.6 8.533333-51.2 8.533333-78.506667-1.706667-29.013333-3.413333-56.32-10.24-81.92v-5.12h-1.706666c-51.2-11.946667-90.453333-39.253333-119.466667-87.04-27.306667-44.373333-34.133333-100.693333-17.066667-148.48l-1.706666-1.706667h-3.413334c-39.253333-35.84-85.333333-63.146667-136.533333-80.213333H648.533333s-1.706667 1.706667-3.413333 1.706667c-32.426667 39.253333-80.213333 59.733333-136.533333 59.733333-47.786667 0-93.866667-20.48-134.826667-59.733333l-1.706667-1.706667h-1.706666c-54.613333 22.186667-98.986667 49.493333-136.533334 80.213333l-1.706666 1.706667v3.413333c13.653333 52.906667 8.533333 104.106667-17.066667 148.48-23.893333 39.253333-64.853333 69.973333-114.346667 85.333334-1.706667 0-3.413333 1.706667-6.826666 6.826666-6.826667 25.6-8.533333 51.2-8.533334 78.506667 0 30.72 3.413333 58.026667 6.826667 76.8l1.706667 5.12h1.706666c51.2 11.946667 90.453333 39.253333 119.466667 87.04 27.306667 44.373333 34.133333 100.693333 17.066667 148.48l1.706666 1.706667 1.706667 1.706666c37.546667 35.84 83.626667 63.146667 134.826667 80.213334 1.706667 0 3.413333 0 3.413333 1.706666h1.706667s1.706667 0 5.12-1.706666c34.133333-37.546667 81.92-59.733333 136.533333-59.733334z m-6.826667-146.773333c-110.933333 0-199.68-85.333333-199.68-196.266667 0-109.226667 87.04-196.266667 199.68-196.266666s199.68 85.333333 199.68 196.266666c-1.706667 109.226667-88.746667 196.266667-199.68 196.266667z m0-307.2c-63.146667 0-114.346667 49.493333-114.346666 110.933333 0 63.146667 49.493333 110.933333 114.346666 110.933334 30.72 0 59.733333-11.946667 80.213334-32.426667 20.48-20.48 32.426667-49.493333 32.426666-78.506667 0-63.146667-49.493333-110.933333-112.64-110.933333z",
									LogoScale = 1.1
								};
								myIconButton.Click += delegate(object sender, EventArgs e)
								{
									CS$<>8__locals1.$VB$Local_ContMenu.PlacementTarget = CS$<>8__locals1.$VB$Local_NewItem;
									CS$<>8__locals1.$VB$Local_ContMenu.IsOpen = true;
								};
								CS$<>8__locals1.$VB$Local_NewItem.Buttons = new MyIconButton[]
								{
									myIconButton
								};
								ModMain.m_DescriptorFilter.PanList.Children.Add(CS$<>8__locals1.$VB$Local_NewItem);
								ModBase.Log("[Minecraft] 有效的 Minecraft 文件夹：" + mcFolder.Name + " > " + mcFolder.Path, ModBase.LogLevel.Normal, "出现错误");
								if (ModMinecraft._TestsIterator.IsAborted)
								{
									return;
								}
							}
							ModMain.m_DescriptorFilter.PanList.Children.Add(new TextBlock
							{
								Text = "添加或导入",
								Margin = new Thickness(13.0, 18.0, 5.0, 4.0),
								Opacity = 0.6,
								FontSize = 12.0
							});
							if (!Directory.Exists(ModBase.Path + ".minecraft\\"))
							{
								MyListItem myListItem = new MyListItem
								{
									IsScaleAnimationEnabled = false,
									Type = MyListItem.CheckType.Clickable,
									Title = "新建 .minecraft 文件夹",
									Height = 34.0,
									ToolTip = "在 PCL 当前所在文件夹下创建新的 .minecraft 文件夹",
									LogoScale = 0.9,
									Logo = "M103.331925 384.978025l25.805736 0L129.137661 161.847132c0-18.313088 14.905478-33.718963 33.718963-33.718963l0.969071 0 253.006318 0c10.82044 0 20.218484 4.797259 26.500561 12.257162l117.579929 126.753869 297.819966 0c18.297738 0 33.736359 15.179724 33.736359 33.977859l0 0.952698 0 82.909292 25.547863 0c18.538215 0 34.187637 15.179724 34.187637 33.977859 0 2.163269-0.469698 3.617387-0.469698 5.539156l-54.437843 432.971086c-1.210571 10.382465-7.007601 19.056008-14.968923 24.352641-6.249331 5.765307-14.680351 9.624195-23.595394 9.624195l-0.969071 0-694.906773 0c-9.155521 0-17.344017-3.858888-23.626094-9.155521-8.67252-5.765307-14.453177-14.939247-15.389502-25.758664L69.597613 423.040922c-2.165316-18.313088 10.868535-35.414581 29.665647-38.062897L103.331925 384.978025 103.331925 384.978025zM196.576609 384.978025 196.576609 384.978025l627.938546 0 0-49.625234L546.461371 335.352791l0 0c-9.400091 0-18.329461-4.117784-25.048489-11.110035L402.363486 196.067514 196.576609 196.067514 196.576609 384.978025 196.576609 384.978025zM879.469767 452.916347 879.469767 452.916347l-20.267603 0-0.469698 0-0.969071 0-694.906773 0-0.984421 0-20.218484 0 45.781696 366.728382 646.218888 0L879.469767 452.916347 879.469767 452.916347z"
								};
								ToolTipService.SetPlacement(myListItem, PlacementMode.Right);
								ToolTipService.SetHorizontalOffset(myListItem, -50.0);
								ToolTipService.SetVerticalOffset(myListItem, 2.5);
								ToolTipService.SetShowDuration(myListItem, 0x239A95);
								ModMain.m_DescriptorFilter.PanList.Children.Add(myListItem);
								MyListItem myListItem2 = myListItem;
								ModMinecraft._Closure$__R24-4 CS$<>8__locals6 = new ModMinecraft._Closure$__R24-4(CS$<>8__locals6);
								CS$<>8__locals6.$VB$NonLocal_3 = ModMain.m_DescriptorFilter;
								myListItem2.QueryModel(delegate(object sender, MouseButtonEventArgs e)
								{
									CS$<>8__locals6.$VB$NonLocal_3.Create_Click();
								});
							}
							MyListItem myListItem3 = new MyListItem
							{
								IsScaleAnimationEnabled = false,
								Type = MyListItem.CheckType.Clickable,
								Title = "添加已有文件夹",
								Height = 34.0,
								ToolTip = "将一个已有的 Minecraft 文件夹添加到列表",
								Logo = "M512.277 954.412c-118.89 0-230.659-46.078-314.73-129.73S67.12 629.666 67.12 511.222s46.327-229.744 130.398-313.427 195.82-129.73 314.73-129.73 230.659 46.078 314.72 129.73S957.397 392.81 957.397 511.183 911.078 740.96 826.97 824.642s-195.8 129.77-314.692 129.77z m0-822.784c-101.972 0-197.809 39.494-269.865 111.222s-111.7 166.997-111.7 268.373 39.653 196.695 111.67 268.335S410.246 890.78 512.248 890.78s197.809-39.484 269.865-111.222 111.7-166.998 111.67-268.374c-0.03-101.375-39.654-196.665-111.67-268.303S614.22 131.628 512.277 131.628z m222.585 347.8H544.073V288.64c-0.76-17.561-15.613-31.18-33.173-30.419-16.495 0.714-29.704 13.924-30.419 30.419v190.787H289.703c-17.56 0.761-31.179 15.614-30.419 33.174 0.715 16.494 13.924 29.703 30.42 30.418H480.48v190.788c0.761 17.56 15.614 31.179 33.174 30.419 16.494-0.715 29.703-13.925 30.418-30.42V543.02h190.788c17.56 0.762 32.413-12.857 33.173-30.418 0.762-17.561-12.858-32.414-30.419-33.174a31.683 31.683 0 0 0-2.753 0z"
							};
							ToolTipService.SetPlacement(myListItem3, PlacementMode.Right);
							ToolTipService.SetHorizontalOffset(myListItem3, -50.0);
							ToolTipService.SetVerticalOffset(myListItem3, 2.5);
							ToolTipService.SetShowDuration(myListItem3, 0x239A95);
							ModMain.m_DescriptorFilter.PanList.Children.Add(myListItem3);
							MyListItem myListItem4 = myListItem3;
							ModMinecraft._Closure$__R24-5 CS$<>8__locals7 = new ModMinecraft._Closure$__R24-5(CS$<>8__locals7);
							CS$<>8__locals7.$VB$NonLocal_4 = ModMain.m_DescriptorFilter;
							myListItem4.QueryModel(delegate(object sender, MouseButtonEventArgs e)
							{
								CS$<>8__locals7.$VB$NonLocal_4.Add_Click();
							});
							MyListItem myListItem5 = new MyListItem
							{
								IsScaleAnimationEnabled = false,
								Type = MyListItem.CheckType.Clickable,
								Title = "导入整合包",
								Height = 34.0,
								ToolTip = "在当前选择的 Minecraft 文件夹下安装整合包",
								Logo = "M512 40.96C249.344 40.96 35.84 252.416 35.84 512s213.504 471.04 476.16 471.04c103.424 0 202.752-33.28 286.72-96.256l1.536-1.536c5.12-5.632 7.68-12.8 7.68-19.968 0-16.896-13.824-30.208-30.72-30.208-7.68 0-15.36 2.56-20.992 7.68h-0.512c-71.68 52.224-155.648 79.36-243.712 79.36-227.328 0-412.16-182.784-412.16-407.552 0-224.768 184.832-407.552 412.16-407.552s412.16 182.784 412.16 407.552c0 68.608-15.872 132.608-46.592 190.464-0.512 1.024-1.024 2.048-1.024 3.072-0.512 2.048-1.536 4.608-1.536 8.192 0 16.896 13.824 30.208 30.72 30.208 12.288 0 23.04-7.168 28.16-18.432 35.84-68.608 53.76-141.312 53.76-216.064 0.512-259.584-212.992-471.04-475.648-471.04z M812.032 483.328c-31.744-20.992-71.68 1.536-78.848 6.144-1.024 0.512-104.448 61.44-128 74.752-8.192 4.608-22.528-0.512-27.136-4.096-31.232-36.352-54.272-70.656-68.608-102.4-13.312-29.184 0.512-41.472 3.072-43.52 7.168-4.608 114.688-68.608 143.36-83.456 24.064-12.288 40.96-25.088 46.08-45.056 3.072-13.312 0-27.136-9.216-39.936-22.016-31.744-172.544-84.992-311.296-3.584-157.184 91.648-152.064 242.688-150.528 292.352v9.216c0 18.944-12.8 37.376-14.848 40.448l-20.992 21.504c-6.144 6.144-9.216 13.824-9.216 22.528 0 8.704 3.584 16.384 9.728 22.528 12.8 12.288 32.768 11.776 45.056-0.512l22.528-23.552 0.512-0.512c3.072-3.584 30.208-38.4 30.208-81.92l-0.512-11.264c-1.536-44.544-5.632-162.816 119.296-235.52 88.064-51.2 173.056-32.256 208.896-19.968-36.864 19.456-143.36 83.456-144.896 84.48-22.016 14.336-55.808 58.88-26.112 122.88 17.408 37.376 43.52 76.8 80.896 120.32 14.336 17.408 62.976 37.376 103.424 15.36 24.576-13.312 125.44-73.216 130.048-75.776 2.048-1.024 4.608-2.56 7.68-3.584 0 2.56-0.512 6.144-1.024 10.752-5.632 35.84-35.328 155.136-191.488 181.76-49.664 8.704-89.6 3.584-121.856-0.512h-0.512c-37.888-4.608-73.216-9.216-101.888 14.336-31.232 26.112-40.96 34.304-35.84 54.272 3.584 14.336 16.384 24.064 30.72 24.064 2.56 0 5.12-0.512 7.68-1.024 6.656-1.536 12.8-5.632 16.896-10.752 2.048-2.048 7.68-6.656 20.992-18.432 6.656-5.632 25.088-3.584 52.736 0 34.816 4.608 81.92 10.24 141.312 0.512 157.184-26.624 228.864-138.752 243.2-234.496 7.68-38.912 0-64.512-21.504-78.336z"
							};
							ToolTipService.SetPlacement(myListItem5, PlacementMode.Right);
							ToolTipService.SetHorizontalOffset(myListItem5, -50.0);
							ToolTipService.SetVerticalOffset(myListItem5, 2.5);
							ToolTipService.SetShowDuration(myListItem5, 0x239A95);
							ModMain.m_DescriptorFilter.PanList.Children.Add(myListItem5);
							myListItem5.QueryModel((ModMinecraft._Closure$__.$IR24-10 == null) ? (ModMinecraft._Closure$__.$IR24-10 = delegate(object sender, MouseButtonEventArgs e)
							{
								PageSelectLeft.StartInstall();
							}) : ModMinecraft._Closure$__.$IR24-10);
							ModMain.m_DescriptorFilter.PanList.Children.Add(new FrameworkElement
							{
								Height = 10.0,
								IsHitTestVisible = false
							});
							int num2 = ModMinecraft.collectionIterator.Count - 1;
							for (int k = 0; k <= num2; k++)
							{
								if (Operators.CompareString(ModMinecraft.collectionIterator[k].Path, ModMinecraft.m_ResolverIterator, true) == 0)
								{
									((MyListItem)ModMain.m_DescriptorFilter.PanList.Children[k + 1]).Checked = true;
									return;
								}
								if (ModMinecraft._TestsIterator.IsAborted)
								{
									return;
								}
							}
							if (ModMinecraft.collectionIterator.Count == 0)
							{
								throw new ArgumentNullException("没有可用的 Minecraft 文件夹");
							}
							ModBase._BaseRule.Set("LaunchFolderSelect", ModMinecraft.collectionIterator[0].Path.Replace(ModBase.Path, "$"), false, null);
							((MyListItem)ModMain.m_DescriptorFilter.PanList.Children[1]).Checked = true;
						}
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "构建 Minecraft 文件夹列表 UI 出错", ModBase.LogLevel.Feedback, "出现错误");
					}
					finally
					{
						ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", false);
					}
				}
			}
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x0004AF14 File Offset: 0x00049114
		public static void McFolderLauncherProfilesJsonCreate(string Folder)
		{
			try
			{
				if (!File.Exists(Folder + "launcher_profiles.json"))
				{
					string text = string.Concat(new string[]
					{
						"{\r\n    \"profiles\":  {\r\n        \"PCL2\": {\r\n            \"icon\": \"Grass\",\r\n            \"name\": \"PCL2\",\r\n            \"lastVersionId\": \"latest-release\",\r\n            \"type\": \"latest-release\",\r\n            \"lastUsed\": \"",
						DateTime.Now.ToString("yyyy-MM-dd"),
						"T",
						DateTime.Now.ToString("HH:mm:ss"),
						".0000Z\"\r\n        }\r\n    },\r\n    \"selectedProfile\": \"PCL2\",\r\n    \"clientToken\": \"23323323323323323323323323323333\"\r\n}"
					});
					ModBase.WriteFile(Folder + "launcher_profiles.json", text, false, Encoding.Default);
					ModBase.Log("[Minecraft] 已创建 launcher_profiles.json：" + Folder, ModBase.LogLevel.Normal, "出现错误");
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "创建 launcher_profiles.json 失败（" + Folder + "）", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x00006B2A File Offset: 0x00004D2A
		public static ModMinecraft.McVersion ValidateContainer()
		{
			return ModMinecraft._FieldIterator;
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x0004AFF0 File Offset: 0x000491F0
		public static void CancelContainer(ModMinecraft.McVersion value)
		{
			if (!object.ReferenceEquals(RuntimeHelpers.GetObjectValue(ModMinecraft.m_StatusIterator), value))
			{
				ModMinecraft._FieldIterator = value;
				ModMinecraft.m_StatusIterator = value;
				if (value != null)
				{
					if (ModAni.InsertFactory() == 0 && Operators.ConditionalCompareObjectNotEqual(ModBase._BaseRule.Get("VersionServerNide", value), ModBase._BaseRule.Get("CacheNideServer", null), true) && Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("VersionServerLogin", value), 3, true))
					{
						ModBase._BaseRule.Set("CacheNideAccess", "", false, null);
						ModBase.Log("[Launch] 服务器改变，要求重新登录统一通行证", ModBase.LogLevel.Normal, "出现错误");
					}
					if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("VersionServerLogin", value), 3, true))
					{
						ModBase._BaseRule.Set("CacheNideServer", RuntimeHelpers.GetObjectValue(ModBase._BaseRule.Get("VersionServerNide", value)), false, null);
					}
					if (ModAni.InsertFactory() == 0 && Operators.ConditionalCompareObjectNotEqual(ModBase._BaseRule.Get("VersionServerAuthServer", value), ModBase._BaseRule.Get("CacheAuthServerServer", null), true) && Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("VersionServerLogin", value), 4, true))
					{
						ModBase._BaseRule.Set("CacheNideServer", "", false, null);
						ModBase.Log("[Launch] 服务器改变，要求重新登录 Authlib-Injector", ModBase.LogLevel.Normal, "出现错误");
					}
					if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("VersionServerLogin", value), 4, true))
					{
						ModBase._BaseRule.Set("CacheAuthServerServer", RuntimeHelpers.GetObjectValue(ModBase._BaseRule.Get("VersionServerAuthServer", value)), false, null);
						ModBase._BaseRule.Set("CacheAuthServerName", RuntimeHelpers.GetObjectValue(ModBase._BaseRule.Get("VersionServerAuthName", value)), false, null);
						ModBase._BaseRule.Set("CacheAuthServerRegister", RuntimeHelpers.GetObjectValue(ModBase._BaseRule.Get("VersionServerAuthRegister", value)), false, null);
					}
				}
			}
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x0004B1E0 File Offset: 0x000493E0
		public static string GetMcFoolName(string Name)
		{
			Name = Name.ToLower();
			string result;
			if (Name.StartsWith("2.0"))
			{
				result = "这个秘密计划了两年的更新将游戏推向了一个新高度！";
			}
			else if (!Name.StartsWith("20w14inf") && Operators.CompareString(Name, "20w14∞", true) != 0)
			{
				if (Operators.CompareString(Name, "15w14a", true) == 0)
				{
					result = "作为一款全年龄向的游戏，我们需要和平，需要爱与拥抱。";
				}
				else if (Operators.CompareString(Name, "1.rv-pre1", true) == 0)
				{
					result = "是时候将现代科技带入 Minecraft 了！";
				}
				else if (Operators.CompareString(Name, "3d shareware v1.34", true) == 0)
				{
					result = "我们从地下室的废墟里找到了这个开发于 1994 年的杰作！";
				}
				else
				{
					result = "";
				}
			}
			else
			{
				result = "我们加入了 20 亿个新的世界，让无限的想象变成了现实！";
			}
			return result;
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x0004B278 File Offset: 0x00049478
		private static void McVersionListLoad(ModLoader.LoaderTask<string, int> Loader)
		{
			ModMinecraft._Closure$__40-0 CS$<>8__locals1 = new ModMinecraft._Closure$__40-0(CS$<>8__locals1);
			ModBase.RunInUiWait((ModMinecraft._Closure$__.$I40-0 == null) ? (ModMinecraft._Closure$__.$I40-0 = delegate()
			{
				if (ModMain.contextFilter != null)
				{
					ModMain.contextFilter.RateModel(PageSelectRight.LoadPageStates.Loading);
				}
			}) : ModMinecraft._Closure$__.$I40-0);
			CS$<>8__locals1.$VB$Local_Path = Loader.Input;
			try
			{
				ModMinecraft.m_RequestIterator.Clear();
				ArrayList arrayList = new ArrayList();
				if (Directory.Exists(CS$<>8__locals1.$VB$Local_Path + "versions"))
				{
					try
					{
						foreach (DirectoryInfo directoryInfo in new DirectoryInfo(CS$<>8__locals1.$VB$Local_Path + "versions").GetDirectories())
						{
							arrayList.Add(directoryInfo.Name);
						}
					}
					catch (Exception innerException)
					{
						throw new Exception("无法读取版本文件夹，可能是由于没有权限（" + CS$<>8__locals1.$VB$Local_Path + "versions）", innerException);
					}
				}
				if (arrayList.Count == 0)
				{
					ModBase.WriteIni(CS$<>8__locals1.$VB$Local_Path + "PCL.ini", "VersionCache", "");
					return;
				}
				int num = Convert.ToInt32(decimal.Remainder(new decimal(ModBase.GetHash(Conversions.ToString(0x16) + "#" + ModBase.Join(arrayList.ToArray(), "#"))), 2147483646m));
				if (!ModMinecraft.m_PoolIterator && ModBase.Val(ModBase.ReadIni(CS$<>8__locals1.$VB$Local_Path + "PCL.ini", "VersionCache", "")) == (double)num)
				{
					Dictionary<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>> dictionary = ModMinecraft.McVersionListLoadCache(CS$<>8__locals1.$VB$Local_Path);
					if (dictionary != null)
					{
						ModMinecraft.m_RequestIterator = dictionary;
						goto IL_1CA;
					}
				}
				ModMinecraft.m_PoolIterator = false;
				ModBase.Log("[Minecraft] 文件夹列表变更，重载所有版本", ModBase.LogLevel.Normal, "出现错误");
				ModBase.WriteIni(CS$<>8__locals1.$VB$Local_Path + "PCL.ini", "VersionCache", Conversions.ToString(num));
				ModMinecraft.m_RequestIterator = ModMinecraft.McVersionListLoadNoCache(CS$<>8__locals1.$VB$Local_Path);
				IL_1CA:;
			}
			catch (Exception ex)
			{
				ModBase.WriteIni(CS$<>8__locals1.$VB$Local_Path + "PCL.ini", "VersionCache", "");
				ModBase.Log(ex, "加载 .minecraft 版本列表失败", ModBase.LogLevel.Feedback, "出现错误");
			}
			finally
			{
				while (!Loader.IsAborted && !(ModMain.m_GetterFilter.publisherDecorator != FormMain.PageType.VersionSelect) && ModMain.contextFilter != null && !ModMain.contextFilter.callbackExpression)
				{
					Thread.Sleep(1);
				}
				if (!Loader.IsAborted)
				{
					ModBase.RunInUiWait(delegate()
					{
						ModMinecraft.McVersionListUI(CS$<>8__locals1.$VB$Local_Path);
					});
				}
			}
			if (Conversions.ToBoolean(ModBase._BaseRule.Get("SystemDebugDelay", null)))
			{
				Thread.Sleep(ModBase.RandomInteger(0xC8, 0xBB8));
			}
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x0004B560 File Offset: 0x00049760
		private static Dictionary<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>> McVersionListLoadCache(string Path)
		{
			Dictionary<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>> dictionary = new Dictionary<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>>();
			checked
			{
				Dictionary<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>> result;
				try
				{
					int num = Conversions.ToInteger(ModBase.ReadIni(Path + "PCL.ini", "CardCount", Conversions.ToString(-1)));
					if (num == -1)
					{
						result = null;
					}
					else
					{
						int num2 = num - 1;
						for (int i = 0; i <= num2; i++)
						{
							ModMinecraft.McVersionCardType key = (ModMinecraft.McVersionCardType)Conversions.ToInteger(ModBase.ReadIni(Path + "PCL.ini", "CardKey" + Conversions.ToString(i + 1), ":"));
							List<ModMinecraft.McVersion> list = new List<ModMinecraft.McVersion>();
							foreach (string text in ModBase.ReadIni(Path + "PCL.ini", "CardValue" + Conversions.ToString(i + 1), ":").Split(new char[]
							{
								':'
							}))
							{
								if (Operators.CompareString(text, "", true) != 0)
								{
									try
									{
										ModMinecraft.McVersion mcVersion = new ModMinecraft.McVersion(Path + "versions\\" + text + "\\");
										list.Add(mcVersion);
										mcVersion.m_SchemaAlgo = ModBase.ReadIni(mcVersion.Path + "PCL\\Setup.ini", "CustomInfo", "");
										if (Operators.CompareString(mcVersion.m_SchemaAlgo, "", true) == 0)
										{
											mcVersion.m_SchemaAlgo = ModBase.ReadIni(mcVersion.Path + "PCL\\Setup.ini", "Info", mcVersion.m_SchemaAlgo);
										}
										mcVersion.m_ConsumerAlgo = ModBase.ReadIni(mcVersion.Path + "PCL\\Setup.ini", "Logo", mcVersion.m_ConsumerAlgo);
										mcVersion.m_RulesAlgo = Conversions.ToDate(ModBase.ReadIni(mcVersion.Path + "PCL\\Setup.ini", "ReleaseTime", Conversions.ToString(mcVersion.m_RulesAlgo)));
										mcVersion.m_HelperAlgo = (ModMinecraft.McVersionState)Conversions.ToInteger(ModBase.ReadIni(mcVersion.Path + "PCL\\Setup.ini", "State", Conversions.ToString((int)mcVersion.m_HelperAlgo)));
										mcVersion.m_QueueAlgo = Conversions.ToBoolean(ModBase.ReadIni(mcVersion.Path + "PCL\\Setup.ini", "IsStar", Conversions.ToString(false)));
										mcVersion.producerAlgo = (ModMinecraft.McVersionCardType)Conversions.ToInteger(ModBase.ReadIni(Path + "PCL\\Setup.ini", "DisplayType", Conversions.ToString(0)));
										if (mcVersion.m_HelperAlgo != ModMinecraft.McVersionState.Error)
										{
											ModMinecraft.McVersionInfo mcVersionInfo = new ModMinecraft.McVersionInfo();
											mcVersionInfo.factoryMapper = ModBase.ReadIni(mcVersion.Path + "PCL\\Setup.ini", "VersionFabric", "");
											mcVersionInfo.m_TokenAlgo = ModBase.ReadIni(mcVersion.Path + "PCL\\Setup.ini", "VersionForge", "");
											mcVersionInfo.m_PublisherAlgo = ModBase.ReadIni(mcVersion.Path + "PCL\\Setup.ini", "VersionOptiFine", "");
											mcVersionInfo.m_ValMapper = Conversions.ToBoolean(ModBase.ReadIni(mcVersion.Path + "PCL\\Setup.ini", "VersionLiteLoader", Conversions.ToString(false)));
											mcVersionInfo.ExcludeUtils(Conversions.ToInteger(ModBase.ReadIni(mcVersion.Path + "PCL\\Setup.ini", "VersionApiCode", Conversions.ToString(-1))));
											mcVersionInfo.policyAlgo = ModBase.ReadIni(mcVersion.Path + "PCL\\Setup.ini", "VersionOriginal", "Unknown");
											mcVersionInfo.clientAlgo = Conversions.ToInteger(ModBase.ReadIni(mcVersion.Path + "PCL\\Setup.ini", "VersionOriginalMain", Conversions.ToString(-1)));
											mcVersionInfo._MapAlgo = Conversions.ToInteger(ModBase.ReadIni(mcVersion.Path + "PCL\\Setup.ini", "VersionOriginalSub", Conversions.ToString(-1)));
											mcVersionInfo.identifierAlgo = true;
											ModMinecraft.McVersionInfo mcVersionInfo2 = mcVersionInfo;
											mcVersionInfo2._ProcAlgo = (mcVersionInfo2.factoryMapper.Count<char>() > 1);
											mcVersionInfo2.messageAlgo = (mcVersionInfo2.m_TokenAlgo.Count<char>() > 1);
											mcVersionInfo2.m_ComposerAlgo = (mcVersionInfo2.m_PublisherAlgo.Count<char>() > 1);
											mcVersion.Version = mcVersionInfo2;
										}
										if (mcVersion.m_HelperAlgo == ModMinecraft.McVersionState.Error)
										{
											string schemaAlgo = mcVersion.m_SchemaAlgo;
											mcVersion.m_HelperAlgo = ModMinecraft.McVersionState.Original;
											mcVersion.Check();
											string left = ModBase.ReadIni(mcVersion.Path + "PCL\\Setup.ini", "CustomInfo", "");
											if (mcVersion.m_HelperAlgo == ModMinecraft.McVersionState.Original || (Operators.CompareString(left, "", true) == 0 && Operators.CompareString(schemaAlgo, mcVersion.m_SchemaAlgo, true) != 0))
											{
												ModBase.Log("[Minecraft] 版本 " + mcVersion.Name + " 的错误状态已变更，新的状态为：" + mcVersion.m_SchemaAlgo, ModBase.LogLevel.Normal, "出现错误");
												return null;
											}
										}
										if (Operators.CompareString(mcVersion.m_ConsumerAlgo, "", true) == 0)
										{
											ModBase.Log("[Minecraft] 版本 " + mcVersion.Name + " 未被加载", ModBase.LogLevel.Normal, "出现错误");
											return null;
										}
									}
									catch (Exception ex)
									{
										ModBase.Log(ex, "读取版本加载缓存失败（" + text + "）", ModBase.LogLevel.Debug, "出现错误");
										return null;
									}
								}
							}
							dictionary.Add(key, list);
						}
						result = dictionary;
					}
				}
				catch (Exception ex2)
				{
					ModBase.Log(ex2, "读取版本缓存失败", ModBase.LogLevel.Debug, "出现错误");
					result = null;
				}
				return result;
			}
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x0004BAE8 File Offset: 0x00049CE8
		private static Dictionary<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>> McVersionListLoadNoCache(string Path)
		{
			List<ModMinecraft.McVersion> list = new List<ModMinecraft.McVersion>();
			Dictionary<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>> dictionary = new Dictionary<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>>();
			foreach (DirectoryInfo directoryInfo in new DirectoryInfo(Path + "versions").GetDirectories())
			{
				if (Operators.CompareString(directoryInfo.Name, "cache", true) == 0 && !File.Exists(directoryInfo.FullName + "\\cache.json"))
				{
					ModBase.Log("[Minecraft] 跳过可能的缓存目录：" + directoryInfo.FullName, ModBase.LogLevel.Normal, "出现错误");
				}
				else
				{
					ModMinecraft.McVersion mcVersion = new ModMinecraft.McVersion(directoryInfo.FullName + "\\");
					list.Add(mcVersion);
					mcVersion.Load();
				}
			}
			try
			{
				Dictionary<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>> dictionary2 = new Dictionary<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>>();
				List<ModMinecraft.McVersion> list2 = new List<ModMinecraft.McVersion>();
				try
				{
					foreach (ModMinecraft.McVersion mcVersion2 in list)
					{
						if (mcVersion2.m_QueueAlgo && mcVersion2.producerAlgo != ModMinecraft.McVersionCardType.Hidden)
						{
							list2.Add(mcVersion2);
						}
					}
				}
				finally
				{
					List<ModMinecraft.McVersion>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				if (list2.Count > 0)
				{
					dictionary2.Add(ModMinecraft.McVersionCardType.Star, list2);
				}
				ModMinecraft.McVersionFilter(ref list, ref dictionary2, new ModMinecraft.McVersionState[1], ModMinecraft.McVersionCardType.Error);
				ModMinecraft.McVersionFilter(ref list, ref dictionary2, new ModMinecraft.McVersionState[]
				{
					ModMinecraft.McVersionState.Fool
				}, ModMinecraft.McVersionCardType.Fool);
				ModMinecraft.McVersionFilter(ref list, ref dictionary2, new ModMinecraft.McVersionState[]
				{
					ModMinecraft.McVersionState.Forge,
					ModMinecraft.McVersionState.LiteLoader,
					ModMinecraft.McVersionState.Fabric
				}, ModMinecraft.McVersionCardType.API);
				List<ModMinecraft.McVersion> list3 = new List<ModMinecraft.McVersion>();
				List<ModMinecraft.McVersion> list4 = new List<ModMinecraft.McVersion>();
				ModMinecraft.McVersionFilter(ref list, new ModMinecraft.McVersionState[]
				{
					ModMinecraft.McVersionState.Old
				}, ref list4);
				ModMinecraft.McVersion mcVersion3 = null;
				try
				{
					foreach (ModMinecraft.McVersion mcVersion4 in list)
					{
						if ((mcVersion4.m_HelperAlgo == ModMinecraft.McVersionState.Original || mcVersion4.m_HelperAlgo == ModMinecraft.McVersionState.Snapshot) && (mcVersion3 == null || DateTime.Compare(mcVersion4.m_RulesAlgo, mcVersion3.m_RulesAlgo) > 0))
						{
							mcVersion3 = mcVersion4;
						}
					}
				}
				finally
				{
					List<ModMinecraft.McVersion>.Enumerator enumerator2;
					((IDisposable)enumerator2).Dispose();
				}
				if (mcVersion3 != null && mcVersion3.m_HelperAlgo == ModMinecraft.McVersionState.Snapshot)
				{
					list3.Add(mcVersion3);
					list.Remove(mcVersion3);
				}
				ModMinecraft.McVersionFilter(ref list, new ModMinecraft.McVersionState[]
				{
					ModMinecraft.McVersionState.Snapshot
				}, ref list4);
				Dictionary<string, ModMinecraft.McVersion> dictionary3 = new Dictionary<string, ModMinecraft.McVersion>();
				ArrayList arrayList = new ArrayList();
				try
				{
					foreach (ModMinecraft.McVersion mcVersion5 in list)
					{
						if (mcVersion5.Version.clientAlgo >= 2)
						{
							if (!arrayList.Contains(mcVersion5.Version.clientAlgo))
							{
								arrayList.Add(mcVersion5.Version.clientAlgo);
							}
							if (dictionary3.ContainsKey(Conversions.ToString(mcVersion5.Version.clientAlgo) + "-" + Conversions.ToString((int)mcVersion5.m_HelperAlgo)))
							{
								if (mcVersion5.Version.m_ComposerAlgo)
								{
									if (mcVersion5.Version.SelectUtils() > dictionary3[Conversions.ToString(mcVersion5.Version.clientAlgo) + "-" + Conversions.ToString((int)mcVersion5.m_HelperAlgo)].Version.SelectUtils())
									{
										dictionary3[Conversions.ToString(mcVersion5.Version.clientAlgo) + "-" + Conversions.ToString((int)mcVersion5.m_HelperAlgo)] = mcVersion5;
									}
								}
								else if (DateTime.Compare(mcVersion5.m_RulesAlgo, dictionary3[Conversions.ToString(mcVersion5.Version.clientAlgo) + "-" + Conversions.ToString((int)mcVersion5.m_HelperAlgo)].m_RulesAlgo) > 0)
								{
									dictionary3[Conversions.ToString(mcVersion5.Version.clientAlgo) + "-" + Conversions.ToString((int)mcVersion5.m_HelperAlgo)] = mcVersion5;
								}
							}
							else
							{
								dictionary3.Add(Conversions.ToString(mcVersion5.Version.clientAlgo) + "-" + Conversions.ToString((int)mcVersion5.m_HelperAlgo), mcVersion5);
							}
						}
					}
				}
				finally
				{
					List<ModMinecraft.McVersion>.Enumerator enumerator3;
					((IDisposable)enumerator3).Dispose();
				}
				try
				{
					foreach (object value in arrayList)
					{
						int value2 = Conversions.ToInteger(value);
						if (dictionary3.ContainsKey(Conversions.ToString(value2) + "-" + Conversions.ToString(4)))
						{
							ModMinecraft.McVersion mcVersion6 = dictionary3[Conversions.ToString(value2) + "-" + Conversions.ToString(4)];
							if (dictionary3.ContainsKey(Conversions.ToString(value2) + "-" + Conversions.ToString(1)) && Operators.CompareString(dictionary3[Conversions.ToString(value2) + "-" + Conversions.ToString(1)].Version.policyAlgo, mcVersion6.PrintUtils(), true) != 0)
							{
								list3.Add(dictionary3[Conversions.ToString(value2) + "-" + Conversions.ToString(1)]);
								list.Remove(dictionary3[Conversions.ToString(value2) + "-" + Conversions.ToString(1)]);
							}
							list3.Add(mcVersion6);
							list.Remove(mcVersion6);
						}
						else
						{
							list3.Add(dictionary3[Conversions.ToString(value2) + "-" + Conversions.ToString(1)]);
							list.Remove(dictionary3[Conversions.ToString(value2) + "-" + Conversions.ToString(1)]);
						}
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
				list4.AddRange(list);
				if (list3.Count > 0)
				{
					dictionary2.Add(ModMinecraft.McVersionCardType.OriginalLike, list3);
				}
				if (list4.Count > 0)
				{
					dictionary2.Add(ModMinecraft.McVersionCardType.Rubbish, list4);
				}
				try
				{
					foreach (KeyValuePair<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>> keyValuePair in dictionary2)
					{
						try
						{
							foreach (ModMinecraft.McVersion mcVersion7 in keyValuePair.Value)
							{
								ModMinecraft.McVersionCardType key = (mcVersion7.producerAlgo == ModMinecraft.McVersionCardType.Auto || keyValuePair.Key == ModMinecraft.McVersionCardType.Star) ? keyValuePair.Key : mcVersion7.producerAlgo;
								if (!dictionary.ContainsKey(key))
								{
									dictionary.Add(key, new List<ModMinecraft.McVersion>());
								}
								dictionary[key].Add(mcVersion7);
							}
						}
						finally
						{
							List<ModMinecraft.McVersion>.Enumerator enumerator6;
							((IDisposable)enumerator6).Dispose();
						}
					}
				}
				finally
				{
					Dictionary<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>>.Enumerator enumerator5;
					((IDisposable)enumerator5).Dispose();
				}
			}
			catch (Exception ex)
			{
				dictionary.Clear();
				ModBase.Log(ex, "分类版本列表失败", ModBase.LogLevel.Feedback, "出现错误");
			}
			Dictionary<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>> dictionary4 = new Dictionary<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>>();
			ModMinecraft.McVersionCardType[] array = new ModMinecraft.McVersionCardType[]
			{
				ModMinecraft.McVersionCardType.Star,
				ModMinecraft.McVersionCardType.API,
				ModMinecraft.McVersionCardType.OriginalLike,
				ModMinecraft.McVersionCardType.Rubbish,
				ModMinecraft.McVersionCardType.Fool,
				ModMinecraft.McVersionCardType.Error,
				ModMinecraft.McVersionCardType.Hidden
			};
			checked
			{
				for (int j = 0; j < array.Length; j++)
				{
					string value3 = Conversions.ToString((int)array[j]);
					if (dictionary.ContainsKey((ModMinecraft.McVersionCardType)Conversions.ToInteger(value3)))
					{
						dictionary4.Add((ModMinecraft.McVersionCardType)Conversions.ToInteger(value3), dictionary[(ModMinecraft.McVersionCardType)Conversions.ToInteger(value3)]);
					}
				}
				dictionary = dictionary4;
				if (dictionary.ContainsKey(ModMinecraft.McVersionCardType.OriginalLike))
				{
					List<ModMinecraft.McVersion> list5 = dictionary[ModMinecraft.McVersionCardType.OriginalLike];
					ModMinecraft.McVersion mcVersion8 = null;
					try
					{
						foreach (ModMinecraft.McVersion mcVersion9 in list5)
						{
							if (mcVersion9.m_HelperAlgo == ModMinecraft.McVersionState.Snapshot)
							{
								mcVersion8 = mcVersion9;
								break;
							}
						}
					}
					finally
					{
						List<ModMinecraft.McVersion>.Enumerator enumerator7;
						((IDisposable)enumerator7).Dispose();
					}
					if (!Information.IsNothing(mcVersion8))
					{
						list5.Remove(mcVersion8);
					}
					List<ModMinecraft.McVersion> list6 = ModBase.Sort<ModMinecraft.McVersion>(list5, (ModMinecraft._Closure$__.$IR42-11 == null) ? (ModMinecraft._Closure$__.$IR42-11 = ((object a0, object a1) => ((ModMinecraft._Closure$__.$I42-0 == null) ? (ModMinecraft._Closure$__.$I42-0 = ((ModMinecraft.McVersion Left, ModMinecraft.McVersion Right) => Left.Version.clientAlgo > Right.Version.clientAlgo)) : ModMinecraft._Closure$__.$I42-0)((ModMinecraft.McVersion)a0, (ModMinecraft.McVersion)a1))) : ModMinecraft._Closure$__.$IR42-11);
					if (!Information.IsNothing(mcVersion8))
					{
						list6.Insert(0, mcVersion8);
					}
					dictionary[ModMinecraft.McVersionCardType.OriginalLike] = list6;
				}
				if (dictionary.ContainsKey(ModMinecraft.McVersionCardType.Rubbish))
				{
					dictionary[ModMinecraft.McVersionCardType.Rubbish] = ModBase.Sort<ModMinecraft.McVersion>(dictionary[ModMinecraft.McVersionCardType.Rubbish], (ModMinecraft._Closure$__.$IR42-12 == null) ? (ModMinecraft._Closure$__.$IR42-12 = ((object a0, object a1) => ((ModMinecraft._Closure$__.$I42-1 == null) ? (ModMinecraft._Closure$__.$I42-1 = delegate(ModMinecraft.McVersion Left, ModMinecraft.McVersion Right)
					{
						int year = Left.m_RulesAlgo.Year;
						int year2 = Right.m_RulesAlgo.Year;
						bool result;
						if (year > 0x7D0 && year2 > 0x7D0)
						{
							if (year != year2)
							{
								result = (year > year2);
							}
							else
							{
								result = (DateTime.Compare(Left.m_RulesAlgo, Right.m_RulesAlgo) > 0);
							}
						}
						else
						{
							result = ((year > 0x7D0 && year2 < 0x7D0) || ((year >= 0x7D0 || year2 <= 0x7D0) && Operators.CompareString(Left.Name, Right.Name, true) > 0));
						}
						return result;
					}) : ModMinecraft._Closure$__.$I42-1)((ModMinecraft.McVersion)a0, (ModMinecraft.McVersion)a1))) : ModMinecraft._Closure$__.$IR42-12);
				}
				if (dictionary.ContainsKey(ModMinecraft.McVersionCardType.API))
				{
					dictionary[ModMinecraft.McVersionCardType.API] = ModBase.Sort<ModMinecraft.McVersion>(dictionary[ModMinecraft.McVersionCardType.API], (ModMinecraft._Closure$__.$IR42-13 == null) ? (ModMinecraft._Closure$__.$IR42-13 = ((object a0, object a1) => ((ModMinecraft._Closure$__.$I42-2 == null) ? (ModMinecraft._Closure$__.$I42-2 = delegate(ModMinecraft.McVersion Left, ModMinecraft.McVersion Right)
					{
						int num2 = ModMinecraft.VersionSortInteger(Left.Version.policyAlgo, Right.Version.policyAlgo);
						bool result;
						if (num2 != 0)
						{
							result = (num2 > 0);
						}
						else if (Left.Version._ProcAlgo ^ Right.Version._ProcAlgo)
						{
							result = Left.Version._ProcAlgo;
						}
						else if (Left.Version.messageAlgo ^ Right.Version.messageAlgo)
						{
							result = Left.Version.messageAlgo;
						}
						else if (Left.Version.SelectUtils() == Right.Version.SelectUtils())
						{
							result = (Left.Version.SelectUtils() > Right.Version.SelectUtils());
						}
						else
						{
							result = (Operators.CompareString(Left.Name, Right.Name, true) > 0);
						}
						return result;
					}) : ModMinecraft._Closure$__.$I42-2)((ModMinecraft.McVersion)a0, (ModMinecraft.McVersion)a1))) : ModMinecraft._Closure$__.$IR42-13);
				}
				ModBase.WriteIni(Path + "PCL.ini", "CardCount", Conversions.ToString(dictionary.Count));
				int num = dictionary.Count - 1;
				for (int k = 0; k <= num; k++)
				{
					ModBase.WriteIni(Path + "PCL.ini", "CardKey" + Conversions.ToString(k + 1), Conversions.ToString((int)dictionary.Keys.ElementAtOrDefault(k)));
					string text = "";
					try
					{
						foreach (ModMinecraft.McVersion mcVersion10 in dictionary.Values.ElementAtOrDefault(k))
						{
							text = text + mcVersion10.Name + ":";
						}
					}
					finally
					{
						List<ModMinecraft.McVersion>.Enumerator enumerator8;
						((IDisposable)enumerator8).Dispose();
					}
					ModBase.WriteIni(Path + "PCL.ini", "CardValue" + Conversions.ToString(k + 1), text);
				}
				return dictionary;
			}
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x0004C4E0 File Offset: 0x0004A6E0
		private static void McVersionFilter(ref List<ModMinecraft.McVersion> VersionList, ref Dictionary<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>> Target, ModMinecraft.McVersionState[] Formula, ModMinecraft.McVersionCardType CardType)
		{
			List<ModMinecraft.McVersion> list = new List<ModMinecraft.McVersion>();
			checked
			{
				try
				{
					foreach (ModMinecraft.McVersion mcVersion in VersionList)
					{
						for (int i = 0; i < Formula.Length; i++)
						{
							if (Formula[i] == mcVersion.m_HelperAlgo)
							{
								list.Add(mcVersion);
								break;
							}
						}
					}
				}
				finally
				{
					List<ModMinecraft.McVersion>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				if (list.Count > 0)
				{
					Target.Add(CardType, list);
					try
					{
						foreach (ModMinecraft.McVersion item in list)
						{
							VersionList.Remove(item);
						}
					}
					finally
					{
						List<ModMinecraft.McVersion>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
				}
			}
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x0004C5B0 File Offset: 0x0004A7B0
		private static void McVersionFilter(ref List<ModMinecraft.McVersion> VersionList, ModMinecraft.McVersionState[] Formula, ref List<ModMinecraft.McVersion> KeepList)
		{
			checked
			{
				try
				{
					foreach (ModMinecraft.McVersion mcVersion in VersionList)
					{
						for (int i = 0; i < Formula.Length; i++)
						{
							if (Formula[i] == mcVersion.m_HelperAlgo)
							{
								KeepList.Add(mcVersion);
								break;
							}
						}
					}
				}
				finally
				{
					List<ModMinecraft.McVersion>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				if (KeepList.Count > 0)
				{
					try
					{
						foreach (ModMinecraft.McVersion item in KeepList)
						{
							VersionList.Remove(item);
						}
					}
					finally
					{
						List<ModMinecraft.McVersion>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
				}
			}
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x0004C66C File Offset: 0x0004A86C
		private static void McVersionListUI(string Path)
		{
			try
			{
				if (ModMain.contextFilter != null)
				{
					ModMain.contextFilter.PanMain.Children.Clear();
					foreach (KeyValuePair<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>> keyValuePair in ModMinecraft.m_RequestIterator.ToArray<KeyValuePair<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>>>())
					{
						if (!(keyValuePair.Key == ModMinecraft.McVersionCardType.Hidden ^ ModMain.contextFilter.objectExpression))
						{
							string text;
							switch (keyValuePair.Key)
							{
							case ModMinecraft.McVersionCardType.Star:
								text = "收藏夹";
								break;
							case ModMinecraft.McVersionCardType.Auto:
								goto IL_347;
							case ModMinecraft.McVersionCardType.Hidden:
								text = "隐藏的版本";
								break;
							case ModMinecraft.McVersionCardType.API:
							{
								bool flag = false;
								bool flag2 = false;
								bool flag3 = false;
								try
								{
									foreach (ModMinecraft.McVersion mcVersion in keyValuePair.Value)
									{
										if (mcVersion.Version._ProcAlgo)
										{
											flag2 = true;
										}
										if (mcVersion.Version.m_ValMapper)
										{
											flag3 = true;
										}
										if (mcVersion.Version.messageAlgo)
										{
											flag = true;
										}
									}
								}
								finally
								{
									List<ModMinecraft.McVersion>.Enumerator enumerator;
									((IDisposable)enumerator).Dispose();
								}
								if (checked((flag3 ? 1 : 0) + (flag ? 1 : 0) + (flag2 ? 1 : 0)) > 1)
								{
									text = "可安装 Mod";
								}
								else if (flag)
								{
									text = "Forge 版本";
								}
								else if (flag3)
								{
									text = "LiteLoader 版本";
								}
								else
								{
									text = "Fabric 版本";
								}
								break;
							}
							case ModMinecraft.McVersionCardType.OriginalLike:
								text = "常规版本";
								break;
							case ModMinecraft.McVersionCardType.Rubbish:
								text = "不常用版本";
								break;
							case ModMinecraft.McVersionCardType.Fool:
								text = "愚人节版本";
								break;
							case ModMinecraft.McVersionCardType.Error:
								text = "错误的版本";
								break;
							default:
								goto IL_347;
							}
							string text2 = text + ((Operators.CompareString(text, "收藏夹", true) == 0) ? "" : (" (" + Conversions.ToString(keyValuePair.Value.Count) + ")"));
							MyCard myCard = new MyCard();
							myCard.Title = text2;
							myCard.Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
							myCard.InitFactory(0);
							MyCard myCard2 = myCard;
							StackPanel stackPanel = new StackPanel
							{
								Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
								VerticalAlignment = VerticalAlignment.Top,
								RenderTransform = new TranslateTransform(0.0, 0.0),
								Tag = keyValuePair.Value
							};
							myCard2.Children.Add(stackPanel);
							myCard2.thread = stackPanel;
							ModMain.contextFilter.PanMain.Children.Add(myCard2);
							if (keyValuePair.Key != ModMinecraft.McVersionCardType.Rubbish && keyValuePair.Key != ModMinecraft.McVersionCardType.Error)
							{
								if (keyValuePair.Key != ModMinecraft.McVersionCardType.Fool)
								{
									MyCard.StackInstall(ref stackPanel, 0, text2);
									goto IL_2BC;
								}
							}
							myCard2.IsSwaped = true;
							goto IL_2BC;
							IL_347:
							throw new ArgumentException("未知的卡片种类（" + Conversions.ToString((int)keyValuePair.Key) + "）");
						}
						IL_2BC:;
					}
					if (ModMain.contextFilter.PanMain.Children.Count == 1 && ((MyCard)ModMain.contextFilter.PanMain.Children[0]).IsSwaped)
					{
						((MyCard)ModMain.contextFilter.PanMain.Children[0]).IsSwaped = false;
					}
					ModMain.contextFilter.RateModel((ModMain.contextFilter.PanMain.Children.Count == 0) ? PageSelectRight.LoadPageStates.Empty : PageSelectRight.LoadPageStates.Loaded);
				}
				if (ModMinecraft.m_RequestIterator.Count == 0)
				{
					ModMinecraft.CancelContainer(null);
					ModBase._BaseRule.Set("LaunchVersionSelect", "", false, null);
					ModBase.Log("[Minecraft] 未找到可用 Minecraft 版本", ModBase.LogLevel.Normal, "出现错误");
				}
				else
				{
					string text3 = ModBase.ReadIni(Path + "PCL.ini", "Version", "");
					if (Operators.CompareString(text3, "", true) != 0)
					{
						try
						{
							foreach (KeyValuePair<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>> keyValuePair2 in ModMinecraft.m_RequestIterator)
							{
								try
								{
									foreach (ModMinecraft.McVersion mcVersion2 in keyValuePair2.Value)
									{
										if (Operators.CompareString(mcVersion2.Name, text3, true) == 0 && !mcVersion2.m_ConsumerAlgo.Contains("RedstoneBlock"))
										{
											ModMinecraft.CancelContainer(mcVersion2);
											ModBase._BaseRule.Set("LaunchVersionSelect", ModMinecraft._FieldIterator.Name, false, null);
											ModBase.Log("[Minecraft] 选择该文件夹储存的 Minecraft 版本：" + ModMinecraft._FieldIterator.Path, ModBase.LogLevel.Normal, "出现错误");
											return;
										}
									}
								}
								finally
								{
									List<ModMinecraft.McVersion>.Enumerator enumerator3;
									((IDisposable)enumerator3).Dispose();
								}
							}
						}
						finally
						{
							Dictionary<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>>.Enumerator enumerator2;
							((IDisposable)enumerator2).Dispose();
						}
					}
					if (!ModMinecraft.m_RequestIterator.First<KeyValuePair<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>>>().Value[0].m_ConsumerAlgo.Contains("RedstoneBlock"))
					{
						ModMinecraft.CancelContainer(ModMinecraft.m_RequestIterator.First<KeyValuePair<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>>>().Value[0]);
						ModBase._BaseRule.Set("LaunchVersionSelect", ModMinecraft._FieldIterator.Name, false, null);
						ModBase.Log("[Launch] 自动选择 Minecraft 版本：" + ModMinecraft._FieldIterator.Path, ModBase.LogLevel.Normal, "出现错误");
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "将版本列表转换显示时失败", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x0004CC28 File Offset: 0x0004AE28
		public static MyListItem McVersionListItem(ModMinecraft.McVersion Version)
		{
			MyListItem myListItem = new MyListItem
			{
				Title = Version.Name,
				Info = Version.m_SchemaAlgo,
				Height = 42.0,
				Tag = Version,
				PaddingRight = 0x4E,
				SnapsToDevicePixels = true,
				Type = MyListItem.CheckType.Clickable
			};
			try
			{
				if (Version.m_ConsumerAlgo.EndsWith("PCL\\Logo.png"))
				{
					myListItem.Logo = Version.Path + "PCL\\Logo.png";
				}
				else
				{
					myListItem.Logo = Version.m_ConsumerAlgo;
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "加载版本图标失败", ModBase.LogLevel.Hint, "出现错误");
				myListItem.Logo = "pack://application:,,,/images/Blocks/RedstoneBlock.png";
			}
			myListItem.utilsDecorator = ((ModMinecraft._Closure$__.$IR47-14 == null) ? (ModMinecraft._Closure$__.$IR47-14 = delegate(object sender, EventArgs e)
			{
				ModMinecraft.McVersionListContent((MyListItem)sender, e);
			}) : ModMinecraft._Closure$__.$IR47-14);
			return myListItem;
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x0004CD1C File Offset: 0x0004AF1C
		public static void McVersionListContent(MyListItem sender, EventArgs e)
		{
			ModMinecraft.McVersion Version = (ModMinecraft.McVersion)sender2.Tag;
			MyListItem $VB$Local_sender = sender2;
			PageSelectRight $VB$NonLocal_2 = ModMain.contextFilter;
			$VB$Local_sender.QueryModel(delegate(object sender, MouseButtonEventArgs e)
			{
				$VB$NonLocal_2.Item_Click((MyListItem)sender, e);
			});
			MyIconButton myIconButton = new MyIconButton();
			if (Version.m_QueueAlgo)
			{
				myIconButton.ToolTip = "取消收藏";
				ToolTipService.SetPlacement(myIconButton, PlacementMode.Center);
				ToolTipService.SetVerticalOffset(myIconButton, 30.0);
				ToolTipService.SetHorizontalOffset(myIconButton, 2.0);
				myIconButton.LogoScale = 1.1;
				myIconButton.Logo = "M700.856 155.543c-74.769 0-144.295 72.696-190.046 127.26-45.737-54.576-115.247-127.26-190.056-127.26-134.79 0-244.443 105.78-244.443 235.799 0 77.57 39.278 131.988 70.845 175.713C238.908 694.053 469.62 852.094 479.39 858.757c9.41 6.414 20.424 9.629 31.401 9.629 11.006 0 21.998-3.215 31.398-9.63 9.782-6.662 240.514-164.703 332.238-291.701 31.587-43.724 70.874-98.143 70.874-175.713-0.001-130.02-109.656-235.8-244.445-235.8z m0 0";
			}
			else
			{
				myIconButton.ToolTip = "收藏";
				ToolTipService.SetPlacement(myIconButton, PlacementMode.Center);
				ToolTipService.SetVerticalOffset(myIconButton, 30.0);
				ToolTipService.SetHorizontalOffset(myIconButton, 2.0);
				myIconButton.LogoScale = 1.1;
				myIconButton.Logo = "M512 896a42.666667 42.666667 0 0 1-30.293333-12.373333l-331.52-331.946667a224.426667 224.426667 0 0 1 0-315.733333 223.573333 223.573333 0 0 1 315.733333 0L512 282.026667l46.08-46.08a223.573333 223.573333 0 0 1 315.733333 0 224.426667 224.426667 0 0 1 0 315.733333l-331.52 331.946667A42.666667 42.666667 0 0 1 512 896zM308.053333 256a136.533333 136.533333 0 0 0-97.28 40.106667 138.24 138.24 0 0 0 0 194.986666L512 792.746667l301.226667-301.653334a138.24 138.24 0 0 0 0-194.986666 141.653333 141.653333 0 0 0-194.56 0l-76.373334 76.8a42.666667 42.666667 0 0 1-60.586666 0L405.333333 296.106667A136.533333 136.533333 0 0 0 308.053333 256z";
			}
			myIconButton.Click += delegate(object sender, EventArgs e)
			{
				base._Lambda$__0();
			};
			MyIconButton myIconButton2 = new MyIconButton
			{
				LogoScale = 1.1,
				Logo = "M520.192 0C408.43 0 317.44 82.87 313.563 186.734H52.736c-29.038 0-52.663 21.943-52.663 49.079s23.625 49.152 52.663 49.152h58.075v550.473c0 103.35 75.118 187.757 167.717 187.757h472.43c92.599 0 167.716-83.894 167.716-187.757V285.477h52.59c29.038 0 52.59-21.943 52.663-49.08-0.073-27.135-23.625-49.151-52.663-49.151H726.235C723.237 83.017 631.955 0 520.192 0zM404.846 177.957c3.803-50.03 50.176-89.015 107.447-89.015 57.197 0 103.57 38.985 106.788 89.015H404.92zM284.379 933.669c-33.353 0-69.997-39.351-69.997-95.525v-549.01H833.39v549.522c0 56.247-36.645 95.525-69.998 95.525H284.379v-0.512z M357.23 800.695a48.274 48.274 0 0 0 47.616-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.69 49.006V751.69c0 27.282 20.846 49.006 47.617 49.006z m166.62 0a48.274 48.274 0 0 0 47.688-49.006V471.7a48.274 48.274 0 0 0-47.689-49.08 48.274 48.274 0 0 0-47.543 49.006V751.69c0 27.282 21.431 49.006 47.543 49.006z m142.92 0a48.274 48.274 0 0 0 47.543-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.616 49.006V751.69c0 27.282 20.773 49.006 47.543 49.006z"
			};
			myIconButton2.ToolTip = "删除";
			ToolTipService.SetPlacement(myIconButton2, PlacementMode.Center);
			ToolTipService.SetVerticalOffset(myIconButton2, 30.0);
			ToolTipService.SetHorizontalOffset(myIconButton2, 2.0);
			myIconButton2.Click += delegate(object sender, EventArgs e)
			{
				base._Lambda$__1();
			};
			if (Version.m_HelperAlgo != ModMinecraft.McVersionState.Error)
			{
				MyIconButton myIconButton3 = new MyIconButton
				{
					LogoScale = 1.1,
					Logo = "M651.946667 1001.813333c-22.186667 0-42.666667-10.24-61.44-27.306666-23.893333-23.893333-49.493333-35.84-75.093334-35.84-29.013333 0-56.32 11.946667-73.386666 30.72v3.413333c-17.066667 17.066667-42.666667 27.306667-66.56 27.306667h-6.826667c-6.826667 0-11.946667-1.706667-15.36-1.706667l-6.826667-1.706667c-64.853333-20.48-121.173333-54.613333-168.96-98.986666-29.013333-23.893333-37.546667-63.146667-25.6-95.573334 8.533333-23.893333 5.12-51.2-10.24-75.093333-15.36-27.306667-34.133333-40.96-59.733333-47.786667h-1.706667l-5.12-1.706666c-35.84-8.533333-61.44-34.133333-66.56-69.973334C1.706667 575.146667 0 537.6 0 512c0-32.426667 3.413333-63.146667 8.533333-93.866667v-6.826666l3.413334-8.533334c10.24-23.893333 23.893333-40.96 44.373333-51.2 5.12-3.413333 11.946667-6.826667 20.48-8.533333 27.306667-8.533333 51.2-25.6 63.146667-44.373333 13.653333-23.893333 17.066667-52.906667 10.24-81.92-11.946667-34.133333 0-71.68 30.72-93.866667 44.373333-37.546667 97.28-68.266667 158.72-93.866667l3.413333-1.706666c44.373333-13.653333 75.093333 3.413333 92.16 20.48 23.893333 23.893333 49.493333 35.84 75.093333 35.84 30.72 0 56.32-10.24 71.68-30.72l3.413334-3.413334c27.306667-27.306667 63.146667-35.84 93.866666-22.186666 63.146667 22.186667 117.76 54.613333 165.546667 97.28 29.013333 23.893333 37.546667 63.146667 25.6 95.573333-8.533333 23.893333-5.12 51.2 10.24 75.093333 15.36 27.306667 34.133333 40.96 59.733333 47.786667h1.706667l5.12 1.706667c35.84 8.533333 61.44 34.133333 66.56 71.68 6.826667 30.72 10.24 63.146667 11.946667 93.866666v3.413334c0 32.426667-3.413333 63.146667-8.533334 93.866666v6.826667l-3.413333 8.533333c-10.24 23.893333-23.893333 40.96-44.373333 51.2-5.12 3.413333-11.946667 6.826667-20.48 8.533334-27.306667 8.533333-51.2 25.6-63.146667 46.08-13.653333 23.893333-17.066667 52.906667-10.24 81.92 11.946667 35.84-1.706667 75.093333-30.72 95.573333-44.373333 35.84-95.573333 66.56-157.013333 92.16-15.36 3.413333-27.306667 3.413333-35.84 3.413333z m3.413333-83.626666z m1.706667 0zM517.12 853.333333c47.786667 0 93.866667 20.48 134.826667 59.733334 1.706667 1.706667 3.413333 1.706667 3.413333 3.413333 52.906667-22.186667 97.28-49.493333 136.533333-80.213333l1.706667-1.706667v-3.413333c-13.653333-52.906667-8.533333-104.106667 17.066667-148.48 23.893333-39.253333 64.853333-69.973333 114.346666-85.333334 1.706667 0 3.413333-1.706667 6.826667-6.826666 5.12-25.6 8.533333-51.2 8.533333-78.506667-1.706667-29.013333-3.413333-56.32-10.24-81.92v-5.12h-1.706666c-51.2-11.946667-90.453333-39.253333-119.466667-87.04-27.306667-44.373333-34.133333-100.693333-17.066667-148.48l-1.706666-1.706667h-3.413334c-39.253333-35.84-85.333333-63.146667-136.533333-80.213333H648.533333s-1.706667 1.706667-3.413333 1.706667c-32.426667 39.253333-80.213333 59.733333-136.533333 59.733333-47.786667 0-93.866667-20.48-134.826667-59.733333l-1.706667-1.706667h-1.706666c-54.613333 22.186667-98.986667 49.493333-136.533334 80.213333l-1.706666 1.706667v3.413333c13.653333 52.906667 8.533333 104.106667-17.066667 148.48-23.893333 39.253333-64.853333 69.973333-114.346667 85.333334-1.706667 0-3.413333 1.706667-6.826666 6.826666-6.826667 25.6-8.533333 51.2-8.533334 78.506667 0 30.72 3.413333 58.026667 6.826667 76.8l1.706667 5.12h1.706666c51.2 11.946667 90.453333 39.253333 119.466667 87.04 27.306667 44.373333 34.133333 100.693333 17.066667 148.48l1.706666 1.706667 1.706667 1.706666c37.546667 35.84 83.626667 63.146667 134.826667 80.213334 1.706667 0 3.413333 0 3.413333 1.706666h1.706667s1.706667 0 5.12-1.706666c34.133333-37.546667 81.92-59.733333 136.533333-59.733334z m-6.826667-146.773333c-110.933333 0-199.68-85.333333-199.68-196.266667 0-109.226667 87.04-196.266667 199.68-196.266666s199.68 85.333333 199.68 196.266666c-1.706667 109.226667-88.746667 196.266667-199.68 196.266667z m0-307.2c-63.146667 0-114.346667 49.493333-114.346666 110.933333 0 63.146667 49.493333 110.933333 114.346666 110.933334 30.72 0 59.733333-11.946667 80.213334-32.426667 20.48-20.48 32.426667-49.493333 32.426666-78.506667 0-63.146667-49.493333-110.933333-112.64-110.933333z"
				};
				myIconButton3.ToolTip = "设置";
				ToolTipService.SetPlacement(myIconButton3, PlacementMode.Center);
				ToolTipService.SetVerticalOffset(myIconButton3, 30.0);
				ToolTipService.SetHorizontalOffset(myIconButton3, 2.0);
				myIconButton3.Click += delegate(object sender, EventArgs e)
				{
					base._Lambda$__2();
				};
				sender2.MouseRightButtonUp += delegate(object sender, MouseButtonEventArgs e)
				{
					base._Lambda$__3();
				};
				sender2.Buttons = new MyIconButton[]
				{
					myIconButton,
					myIconButton2,
					myIconButton3
				};
				return;
			}
			MyIconButton myIconButton4 = new MyIconButton
			{
				LogoScale = 1.15,
				Logo = "M889.018182 418.909091H884.363636V316.509091a93.090909 93.090909 0 0 0-99.607272-89.832727h-302.545455l-93.090909-76.334546A46.545455 46.545455 0 0 0 358.865455 139.636364H146.152727A93.090909 93.090909 0 0 0 46.545455 229.469091V837.818182a46.545455 46.545455 0 0 0 46.545454 46.545454 46.545455 46.545455 0 0 0 16.756364-3.258181 109.381818 109.381818 0 0 0 25.134545 3.258181h586.472727a85.178182 85.178182 0 0 0 87.04-63.301818l163.374546-302.545454a46.545455 46.545455 0 0 0 5.585454-21.876364A82.385455 82.385455 0 0 0 889.018182 418.909091z m-744.727273-186.181818h198.283636l93.09091 76.334545a46.545455 46.545455 0 0 0 29.323636 10.705455h319.301818a12.101818 12.101818 0 0 1 6.516364 0V418.909091H302.545455a85.178182 85.178182 0 0 0-87.04 63.301818L139.636364 622.778182V232.727273a19.549091 19.549091 0 0 1 6.516363 0z m578.094546 552.029091a27.461818 27.461818 0 0 0-2.792728 6.516363H154.530909l147.083636-272.290909a27.461818 27.461818 0 0 0 2.792728-6.981818h565.061818z"
			};
			myIconButton4.ToolTip = "打开文件夹";
			ToolTipService.SetPlacement(myIconButton4, PlacementMode.Center);
			ToolTipService.SetVerticalOffset(myIconButton4, 30.0);
			ToolTipService.SetHorizontalOffset(myIconButton4, 2.0);
			myIconButton4.Click += delegate(object sender, EventArgs e)
			{
				base._Lambda$__4();
			};
			sender2.MouseRightButtonUp += delegate(object sender, MouseButtonEventArgs e)
			{
				base._Lambda$__5();
			};
			sender2.Buttons = new MyIconButton[]
			{
				myIconButton,
				myIconButton2,
				myIconButton4
			};
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x0004CFD4 File Offset: 0x0004B1D4
		public static ModMinecraft.McSkinInfo McSkinSelect(bool MustHaveTwoLayers)
		{
			string text = ModBase.SelectFile("皮肤文件(*.png)|*.png", "选择皮肤文件");
			ModMinecraft.McSkinInfo result;
			if (Operators.CompareString(text, "", true) == 0)
			{
				result = new ModMinecraft.McSkinInfo
				{
					_ExpressionMapper = false
				};
			}
			else
			{
				try
				{
					ModBitmap.MyBitmap myBitmap = new ModBitmap.MyBitmap(text);
					if (!MustHaveTwoLayers)
					{
						if (myBitmap.requestMapper.Width == 0x40)
						{
							if (myBitmap.requestMapper.Height == 0x20 || myBitmap.requestMapper.Height == 0x40)
							{
								goto IL_FF;
							}
						}
						ModMain.Hint("皮肤图片大小应为 64x32 像素或 64x64 像素！", ModMain.HintType.Critical, true);
						return new ModMinecraft.McSkinInfo
						{
							_ExpressionMapper = false
						};
					}
					if (myBitmap.requestMapper.Width == 0x40 && myBitmap.requestMapper.Height == 0x20)
					{
						ModMain.Hint("自定义离线皮肤只支持 64x64 像素的双层皮肤！", ModMain.HintType.Critical, true);
						return new ModMinecraft.McSkinInfo
						{
							_ExpressionMapper = false
						};
					}
					if (myBitmap.requestMapper.Width != 0x40 || myBitmap.requestMapper.Height != 0x40)
					{
						ModMain.Hint("自定义离线皮肤图片大小应为 64x64 像素！", ModMain.HintType.Critical, true);
						return new ModMinecraft.McSkinInfo
						{
							_ExpressionMapper = false
						};
					}
					IL_FF:
					FileInfo fileInfo = new FileInfo(text);
					if (fileInfo.Length > 0x6000L)
					{
						ModMain.Hint("皮肤文件大小需小于 24 KB，而所选文件大小为 " + Conversions.ToString(Math.Round((double)fileInfo.Length / 1024.0, 2)) + " KB", ModMain.HintType.Critical, true);
						return new ModMinecraft.McSkinInfo
						{
							_ExpressionMapper = false
						};
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "皮肤文件存在错误", ModBase.LogLevel.Hint, "出现错误");
					return new ModMinecraft.McSkinInfo
					{
						_ExpressionMapper = false
					};
				}
				int num = ModMain.MyMsgBox("此皮肤为 Steve 模型（粗手臂）还是 Alex 模型（细手臂）？", "选择皮肤种类", "Steve 模型", "Alex 模型", "我不知道", false, false, false);
				if (num == 3)
				{
					ModMain.Hint("请在皮肤下载页面确认皮肤种类后再使用此皮肤！", ModMain.HintType.Info, true);
					result = new ModMinecraft.McSkinInfo
					{
						_ExpressionMapper = false
					};
				}
				else
				{
					result = new ModMinecraft.McSkinInfo
					{
						_ExpressionMapper = true,
						m_ModelMapper = (num == 2),
						_IteratorMapper = text
					};
				}
			}
			return result;
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x0004D224 File Offset: 0x0004B424
		public static string McSkinGetAddress(string Uuid, string Type)
		{
			if (Operators.CompareString(Uuid, "", true) == 0)
			{
				throw new Exception("Uuid 为空。");
			}
			if (Uuid.StartsWith("000000"))
			{
				throw new Exception("离线 Uuid 无正版皮肤文件。");
			}
			string text = ModBase.ReadIni(ModBase.m_GlobalRule + "Cache\\Skin\\Index" + Type + ".ini", Uuid, "");
			string result;
			if (Operators.CompareString(text, "", true) != 0)
			{
				result = text;
			}
			else
			{
				string str;
				if (Operators.CompareString(Type, "Mojang", true) != 0 && Operators.CompareString(Type, "Ms", true) != 0)
				{
					if (Operators.CompareString(Type, "Nide", true) == 0)
					{
						str = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("https://auth2.nide8.com:233/", (ModMinecraft._FieldIterator == null) ? ModBase._BaseRule.Get("CacheNideServer", null) : ModBase._BaseRule.Get("VersionServerNide", ModMinecraft._FieldIterator)), "/sessionserver/session/minecraft/profile/"));
					}
					else
					{
						if (Operators.CompareString(Type, "Auth", true) != 0)
						{
							throw new ArgumentException("皮肤地址种类无效：" + (Type ?? "null"));
						}
						str = Conversions.ToString(Operators.ConcatenateObject((ModMinecraft._FieldIterator == null) ? ModBase._BaseRule.Get("CacheAuthServerServer", null) : ModBase._BaseRule.Get("VersionServerAuthServer", ModMinecraft._FieldIterator), "/sessionserver/session/minecraft/profile/"));
					}
				}
				else
				{
					str = "https://sessionserver.mojang.com/session/minecraft/profile/";
				}
				object obj = RuntimeHelpers.GetObjectValue(ModNet.NetGetCodeByRequestRetry(str + Uuid, null, "", false));
				if (Operators.ConditionalCompareObjectEqual(obj, "", true))
				{
					throw new Exception("皮肤返回值为空，可能是未设置自定义皮肤的用户");
				}
				string text2;
				try
				{
					JObject jobject = (JObject)ModBase.GetJson(Conversions.ToString(obj));
					try
					{
						foreach (JToken jtoken in ((IEnumerable<JToken>)jobject["properties"]))
						{
							if ((string)jtoken["name"] == "textures")
							{
								text2 = (string)jtoken["value"];
								goto IL_23D;
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
					throw new Exception("未从皮肤返回值中找到符合条件的 Property");
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, Conversions.ToString(Operators.ConcatenateObject("无法完成解析的皮肤返回值，可能是未设置自定义皮肤的用户：", obj)), ModBase.LogLevel.Developer, "出现错误");
					throw new Exception("皮肤返回值中不包含皮肤数据项，可能是未设置自定义皮肤的用户", ex);
				}
				IL_23D:
				obj = Encoding.GetEncoding("utf-8").GetString(Convert.FromBase64String(text2));
				try
				{
					text2 = ((JObject)ModBase.GetJson(Conversions.ToString(NewLateBinding.LateGet(obj, null, "ToLower", new object[0], null, null, null))))["textures"]["skin"]["url"].ToString();
				}
				catch (Exception ex2)
				{
					ModBase.Log(ex2, Conversions.ToString(Operators.ConcatenateObject("无法完成解析的皮肤解析值，可能是未设置自定义皮肤的用户：", obj)), ModBase.LogLevel.Developer, "出现错误");
					throw new Exception("皮肤解析值中不包含皮肤数据项，可能是未设置自定义皮肤的用户", ex2);
				}
				ModBase.WriteIni(ModBase.m_GlobalRule + "Cache\\Skin\\Index" + Type + ".ini", Uuid, text2);
				ModBase.Log("[Skin] UUID " + Uuid + " 对应的皮肤文件为 " + text2, ModBase.LogLevel.Normal, "出现错误");
				result = text2;
			}
			return result;
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x0004D568 File Offset: 0x0004B768
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public static string McSkinDownload(string Address)
		{
			ModBase.GetFileNameFromPath(Address);
			string text = ModBase.m_GlobalRule + "Cache\\Skin\\" + Conversions.ToString(ModBase.GetHash(Address)) + ".png";
			object proxyIterator = ModMinecraft._ProxyIterator;
			ObjectFlowControl.CheckForSyncLockOnValueType(proxyIterator);
			string result;
			lock (proxyIterator)
			{
				if (!File.Exists(text))
				{
					ModNet.NetDownload(Address, text + ".PCLDownloading");
					File.Delete(text);
					FileSystem.Rename(text + ".PCLDownloading", text);
					ModBase.Log("[Minecraft] 皮肤下载成功：" + text, ModBase.LogLevel.Normal, "出现错误");
				}
				result = text;
			}
			return result;
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x0004D618 File Offset: 0x0004B818
		public static string McSkinSex(string Uuid)
		{
			string result;
			if (Uuid.Length != 0x20)
			{
				result = "Steve";
			}
			else
			{
				int num = int.Parse(Conversions.ToString(Uuid[7]), NumberStyles.AllowHexSpecifier);
				int num2 = int.Parse(Conversions.ToString(Uuid[0xF]), NumberStyles.AllowHexSpecifier);
				int num3 = int.Parse(Conversions.ToString(Uuid[0x17]), NumberStyles.AllowHexSpecifier);
				int num4 = int.Parse(Conversions.ToString(Uuid[0x1F]), NumberStyles.AllowHexSpecifier);
				result = (((num ^ num2 ^ num3 ^ num4) % 2 != 0) ? "Alex" : "Steve");
			}
			return result;
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x0004D6B0 File Offset: 0x0004B8B0
		public static bool McJsonRuleCheck(JToken RuleToken)
		{
			bool result;
			if (RuleToken == null)
			{
				result = true;
			}
			else
			{
				bool flag = false;
				try
				{
					foreach (JToken jtoken in ((IEnumerable<JToken>)RuleToken))
					{
						bool flag2 = true;
						if (jtoken["os"] != null)
						{
							if (jtoken["os"]["name"] != null)
							{
								string left = jtoken["os"]["name"].ToString();
								if (Operators.CompareString(left, "unknown", true) != 0)
								{
									if (Operators.CompareString(left, "windows", true) == 0)
									{
										if (jtoken["os"]["version"] != null)
										{
											string regex = jtoken["os"]["version"].ToString();
											flag2 = (flag2 && ModBase.RegexCheck(ModMinecraft.setterIterator, regex, RegexOptions.None));
										}
									}
									else
									{
										flag2 = false;
									}
								}
							}
							if (jtoken["os"]["arch"] != null)
							{
								flag2 = (flag2 && Operators.CompareString(jtoken["os"]["arch"].ToString(), "x86", true) == 0 == ModBase.m_MapperRule);
							}
						}
						if (!Information.IsNothing(jtoken["features"]))
						{
							flag2 = (flag2 && Information.IsNothing(jtoken["features"]["is_demo_user"]));
						}
						if (Operators.CompareString(jtoken["action"].ToString(), "allow", true) == 0)
						{
							if (flag2)
							{
								flag = true;
							}
						}
						else if (flag2)
						{
							flag = false;
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
				result = flag;
			}
			return result;
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x0004D878 File Offset: 0x0004BA78
		public static List<ModMinecraft.McLibToken> McLibListGet(ModMinecraft.McVersion Version, bool IncludeVersionJar)
		{
			ModBase.Log("[Minecraft] 获取支持库列表：" + Version.Name, ModBase.LogLevel.Normal, "出现错误");
			List<ModMinecraft.McLibToken> list = ModMinecraft.McLibListGetWithJson(Version.VerifyUtils(), false, null, Version.ManageExpression() + ".jumploader\\");
			if (IncludeVersionJar)
			{
				JToken jtoken = Version.VerifyUtils()["jar"];
				string text = (jtoken != null) ? jtoken.ToString() : null;
				ModMinecraft.McVersion mcVersion;
				if (!Version.FindUtils() && text != null)
				{
					mcVersion = new ModMinecraft.McVersion(text);
				}
				else
				{
					ModMinecraft.McVersion mcVersion2 = Version;
					while (Operators.CompareString(mcVersion2.PrintUtils(), "", true) != 0 && Operators.CompareString(mcVersion2.PrintUtils(), mcVersion2.Name, true) != 0)
					{
						mcVersion2 = new ModMinecraft.McVersion(ModMinecraft.m_ResolverIterator + "versions\\" + mcVersion2.PrintUtils() + "\\");
					}
					mcVersion = new ModMinecraft.McVersion(mcVersion2.Path);
				}
				if (!File.Exists(mcVersion.Path + mcVersion.Name + ".json"))
				{
					mcVersion = Version;
					ModBase.Log("[Minecraft] 可能缺少前置版本 " + mcVersion.Name + "，找不到对应的 Json 文件", ModBase.LogLevel.Debug, "出现错误");
				}
				string value;
				string filterMapper;
				if (mcVersion.VerifyUtils()["downloads"] != null && mcVersion.VerifyUtils()["downloads"]["client"] != null)
				{
					value = (string)mcVersion.VerifyUtils()["downloads"]["client"]["url"];
					filterMapper = (string)mcVersion.VerifyUtils()["downloads"]["client"]["sha1"];
				}
				else
				{
					value = null;
					filterMapper = null;
				}
				List<ModMinecraft.McLibToken> list2 = list;
				ModMinecraft.McLibToken mcLibToken = new ModMinecraft.McLibToken();
				mcLibToken.m_UtilsMapper = mcVersion.Path + mcVersion.Name + ".jar";
				mcLibToken._BaseMapper = 0L;
				mcLibToken.m_DecoratorMapper = false;
				mcLibToken.CheckUtils(value);
				mcLibToken.filterMapper = filterMapper;
				list2.Add(mcLibToken);
			}
			return list;
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x0004DA6C File Offset: 0x0004BC6C
		public static List<ModMinecraft.McLibToken> McLibListGetWithJson(JObject JsonObject, bool KeepSameNameDifferentVersionResult = false, string CustomMcFolder = null, string JumpLoaderFolder = null)
		{
			CustomMcFolder = (CustomMcFolder ?? ModMinecraft.m_ResolverIterator);
			List<ModMinecraft.McLibToken> list = new List<ModMinecraft.McLibToken>();
			JArray jarray = (JArray)JsonObject["libraries"];
			if (JsonObject["jumploader"] != null && JsonObject["jumploader"]["jars"] != null && JsonObject["jumploader"]["jars"]["maven"] != null)
			{
				try
				{
					foreach (JToken item in ((IEnumerable<JToken>)JsonObject["jumploader"]["jars"]["maven"]))
					{
						jarray.Add(item);
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
			checked
			{
				try
				{
					foreach (JToken jtoken in jarray.Children())
					{
						JObject jobject = (JObject)jtoken;
						if (ModMinecraft.McJsonRuleCheck(jobject["rules"]))
						{
							bool flag = false;
							if (jobject["mavenPath"] != null)
							{
								flag = true;
								if (jobject["name"] == null)
								{
									jobject.Add("name", jobject["mavenPath"]);
								}
								if (jobject["repoUrl"] != null && jobject["url"] == null)
								{
									jobject.Add("url", jobject["repoUrl"]);
								}
							}
							string text = (string)jobject["url"];
							if (text != null)
							{
								text += ModMinecraft.McLibGet((string)jobject["name"], false, true, CustomMcFolder).Replace("\\", "/");
							}
							if (jobject["natives"] == null)
							{
								string utilsMapper;
								if (flag)
								{
									utilsMapper = ModMinecraft.McLibGet((string)jobject["name"], true, false, JumpLoaderFolder ?? CustomMcFolder);
								}
								else
								{
									utilsMapper = ModMinecraft.McLibGet((string)jobject["name"], true, false, CustomMcFolder);
								}
								try
								{
									if (jobject["downloads"] != null && jobject["downloads"]["artifact"] != null)
									{
										List<ModMinecraft.McLibToken> list2 = list;
										ModMinecraft.McLibToken mcLibToken = new ModMinecraft.McLibToken();
										mcLibToken._MapperMapper = flag;
										mcLibToken.algoMapper = (string)jobject["name"];
										mcLibToken.CheckUtils((string)((text != null) ? text : jobject["downloads"]["artifact"]["url"]));
										mcLibToken.m_UtilsMapper = ((jobject["downloads"]["artifact"]["path"] == null) ? ModMinecraft.McLibGet((string)jobject["name"], true, false, CustomMcFolder) : (CustomMcFolder + "libraries\\" + jobject["downloads"]["artifact"]["path"].ToString().Replace("/", "\\")));
										mcLibToken._BaseMapper = (long)Math.Round(ModBase.Val(jobject["downloads"]["artifact"]["size"].ToString()));
										mcLibToken.m_DecoratorMapper = false;
										ModMinecraft.McLibToken mcLibToken2 = mcLibToken;
										JToken jtoken2 = jobject["downloads"]["artifact"]["sha1"];
										mcLibToken2.filterMapper = ((jtoken2 != null) ? jtoken2.ToString() : null);
										list2.Add(mcLibToken);
									}
									else
									{
										List<ModMinecraft.McLibToken> list3 = list;
										ModMinecraft.McLibToken mcLibToken3 = new ModMinecraft.McLibToken();
										mcLibToken3._MapperMapper = flag;
										mcLibToken3.algoMapper = (string)jobject["name"];
										mcLibToken3.CheckUtils(text);
										mcLibToken3.m_UtilsMapper = utilsMapper;
										mcLibToken3._BaseMapper = 0L;
										mcLibToken3.m_DecoratorMapper = false;
										mcLibToken3.filterMapper = null;
										list3.Add(mcLibToken3);
									}
									continue;
								}
								catch (Exception ex)
								{
									ModBase.Log(ex, "处理实际支持库列表失败（无 Natives，" + (jobject["name"] ?? "Nothing").ToString() + "）", ModBase.LogLevel.Debug, "出现错误");
									List<ModMinecraft.McLibToken> list4 = list;
									ModMinecraft.McLibToken mcLibToken4 = new ModMinecraft.McLibToken();
									mcLibToken4._MapperMapper = flag;
									mcLibToken4.algoMapper = (string)jobject["name"];
									mcLibToken4.CheckUtils(text);
									mcLibToken4.m_UtilsMapper = utilsMapper;
									mcLibToken4._BaseMapper = 0L;
									mcLibToken4.m_DecoratorMapper = false;
									mcLibToken4.filterMapper = null;
									list4.Add(mcLibToken4);
									continue;
								}
							}
							if (jobject["natives"]["windows"] != null)
							{
								try
								{
									if (jobject["downloads"] != null && jobject["downloads"]["classifiers"] != null && jobject["downloads"]["classifiers"]["natives-windows"] != null)
									{
										List<ModMinecraft.McLibToken> list5 = list;
										ModMinecraft.McLibToken mcLibToken5 = new ModMinecraft.McLibToken();
										mcLibToken5._MapperMapper = flag;
										mcLibToken5.algoMapper = (string)jobject["name"];
										mcLibToken5.CheckUtils((string)((text != null) ? text : jobject["downloads"]["classifiers"]["natives-windows"]["url"]));
										mcLibToken5.m_UtilsMapper = ((jobject["downloads"]["classifiers"]["natives-windows"]["path"] == null) ? ModMinecraft.McLibGet((string)jobject["name"], true, false, CustomMcFolder).Replace(".jar", "-" + jobject["natives"]["windows"].ToString() + ".jar").Replace("${arch}", Environment.Is64BitOperatingSystem ? "64" : "32") : (CustomMcFolder + "libraries\\" + jobject["downloads"]["classifiers"]["natives-windows"]["path"].ToString().Replace("/", "\\")));
										mcLibToken5._BaseMapper = (long)Math.Round(ModBase.Val(jobject["downloads"]["classifiers"]["natives-windows"]["size"].ToString()));
										mcLibToken5.m_DecoratorMapper = true;
										mcLibToken5.filterMapper = jobject["downloads"]["classifiers"]["natives-windows"]["sha1"].ToString();
										list5.Add(mcLibToken5);
									}
									else
									{
										List<ModMinecraft.McLibToken> list6 = list;
										ModMinecraft.McLibToken mcLibToken6 = new ModMinecraft.McLibToken();
										mcLibToken6._MapperMapper = flag;
										mcLibToken6.algoMapper = (string)jobject["name"];
										mcLibToken6.CheckUtils(text);
										mcLibToken6.m_UtilsMapper = ModMinecraft.McLibGet((string)jobject["name"], true, false, CustomMcFolder).Replace(".jar", "-" + jobject["natives"]["windows"].ToString() + ".jar").Replace("${arch}", Environment.Is64BitOperatingSystem ? "64" : "32");
										mcLibToken6._BaseMapper = 0L;
										mcLibToken6.m_DecoratorMapper = true;
										mcLibToken6.filterMapper = null;
										list6.Add(mcLibToken6);
									}
								}
								catch (Exception ex2)
								{
									ModBase.Log(ex2, "处理实际支持库列表失败（有 Natives，" + (jobject["name"] ?? "Nothing").ToString() + "）", ModBase.LogLevel.Debug, "出现错误");
									List<ModMinecraft.McLibToken> list7 = list;
									ModMinecraft.McLibToken mcLibToken7 = new ModMinecraft.McLibToken();
									mcLibToken7._MapperMapper = flag;
									mcLibToken7.algoMapper = (string)jobject["name"];
									mcLibToken7.CheckUtils(text);
									mcLibToken7.m_UtilsMapper = ModMinecraft.McLibGet((string)jobject["name"], true, false, CustomMcFolder).Replace(".jar", "-" + jobject["natives"]["windows"].ToString() + ".jar").Replace("${arch}", Environment.Is64BitOperatingSystem ? "64" : "32");
									mcLibToken7._BaseMapper = 0L;
									mcLibToken7.m_DecoratorMapper = true;
									mcLibToken7.filterMapper = null;
									list7.Add(mcLibToken7);
								}
							}
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
				Dictionary<string, ModMinecraft.McLibToken> dictionary = new Dictionary<string, ModMinecraft.McLibToken>();
				int num = list.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string text2 = list[i].Name + list[i].m_DecoratorMapper.ToString() + list[i]._MapperMapper.ToString();
					if (dictionary.ContainsKey(text2))
					{
						if (Operators.CompareString(list[i].Version, dictionary[text2].Version, true) != 0 && KeepSameNameDifferentVersionResult)
						{
							dictionary.Add(text2 + Conversions.ToString(ModBase.GetUuid()), list[i]);
						}
						else if (ModMinecraft.VersionSortBoolean(list[i].Version, dictionary[text2].Version))
						{
							dictionary[text2] = list[i];
						}
					}
					else
					{
						dictionary.Add(text2, list[i]);
					}
				}
				return dictionary.Values.ToList<ModMinecraft.McLibToken>();
			}
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x0004E488 File Offset: 0x0004C688
		public static List<ModNet.NetFile> McLibFix(ModMinecraft.McVersion Version, bool CoreJarOnly = false)
		{
			if (!Version._ReponseAlgo)
			{
				Version.Load();
			}
			List<ModNet.NetFile> list = new List<ModNet.NetFile>();
			try
			{
				ModNet.NetFile netFile = ModDownload.DlClientJarGet(Version, true);
				if (netFile != null)
				{
					list.Add(netFile);
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "版本缺失主 Jar 文件所必须的信息", ModBase.LogLevel.Developer, "出现错误");
			}
			List<ModNet.NetFile> result;
			if (CoreJarOnly)
			{
				result = list;
			}
			else
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
				list.AddRange(ModMinecraft.McLibFixFromLibToken(ModMinecraft.McLibListGet(Version, false), null, Version.ManageExpression() + ".jumploader\\", flag));
				if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("VersionServerLogin", Version), 3, true))
				{
					string text = Version.ManageExpression() + "nide8auth.jar";
					ModBase.FileChecker fileChecker = new ModBase.FileChecker(0x2A3C8L, -1L, null, null, true, false);
					if ((flag && File.Exists(text)) || fileChecker.Check(text) != null)
					{
						list.Add(new ModNet.NetFile(new string[]
						{
							"https://login2.nide8.com:233/index/jar"
						}, text, fileChecker));
					}
				}
				if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("VersionServerLogin", Version), 4, true))
				{
					string text2 = Version.ManageExpression() + "authlib-injector.jar";
					ModBase.FileChecker fileChecker2 = new ModBase.FileChecker(0x3D090L, -1L, null, null, true, false);
					if ((flag && File.Exists(text2)) || fileChecker2.Check(text2) != null)
					{
						string text3 = "https://bmclapi2.bangbang93.com/mirrors/authlib-injector/artifact/38/authlib-injector-1.1.38.jar";
						try
						{
							ModBase.Log("[Minecraft] 开始获取 Authlib-Injector 下载地址", ModBase.LogLevel.Normal, "出现错误");
							text3 = (((JObject)ModBase.GetJson(ModNet.NetGetCodeByDownload(new string[]
							{
								"https://download.mcbbs.net/mirrors/authlib-injector/artifact/latest.json",
								"https://bmclapi2.bangbang93.com/mirrors/authlib-injector/artifact/latest.json"
							}, 0xAFC8, true)))["download_url"] ?? text3).ToString();
							ModBase.Log("[Minecraft] 最新版 Authlib-Injector 下载地址：" + text3, ModBase.LogLevel.Normal, "出现错误");
						}
						catch (Exception ex2)
						{
							ModBase.Log("获取 Authlib-Injector 下载地址失败", ModBase.LogLevel.Hint, "出现错误");
						}
						list.Add(new ModNet.NetFile(new string[]
						{
							text3.Replace("bmclapi2.bangbang93.com", "download.mcbbs.net"),
							text3
						}, text2, new ModBase.FileChecker(0x3D090L, -1L, null, null, true, false)));
					}
				}
				result = list;
			}
			return result;
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x0004E758 File Offset: 0x0004C958
		public static List<ModNet.NetFile> McLibFixFromLibToken(List<ModMinecraft.McLibToken> Libs, string CustomMcFolder = null, string JumpLoaderFolder = null, bool AllowUnsameFile = false)
		{
			CustomMcFolder = (CustomMcFolder ?? ModMinecraft.m_ResolverIterator);
			List<ModNet.NetFile> list = new List<ModNet.NetFile>();
			try
			{
				foreach (ModMinecraft.McLibToken mcLibToken in Libs)
				{
					ModBase.FileChecker fileChecker;
					if (AllowUnsameFile)
					{
						fileChecker = new ModBase.FileChecker(1L, -1L, null, null, true, false);
					}
					else
					{
						fileChecker = new ModBase.FileChecker(-1L, (mcLibToken._BaseMapper == 0L) ? -1L : mcLibToken._BaseMapper, null, mcLibToken.filterMapper, true, false);
					}
					if (fileChecker.Check(mcLibToken.m_UtilsMapper) != null)
					{
						List<string> list2 = new List<string>();
						if (mcLibToken.ReadUtils() != null)
						{
							string text = mcLibToken.ReadUtils();
							text = text.Replace("https://files.minecraftforge.net", "http://files.minecraftforge.net");
							list2.Add(text);
							if (mcLibToken.ReadUtils().Contains("launcher.mojang.com/v1/objects"))
							{
								list2 = ModDownload.DlSourceLauncherOrMetaGet(mcLibToken.ReadUtils(), true).ToList<string>();
							}
							if (mcLibToken.ReadUtils().Contains("maven"))
							{
								list2.Insert(0, mcLibToken.ReadUtils().Replace(Strings.Mid(mcLibToken.ReadUtils(), 1, mcLibToken.ReadUtils().IndexOf("maven")), "https://download.mcbbs.net/").Replace("maven.fabricmc.net", "maven").Replace("maven.minecraftforge.net", "maven"));
							}
						}
						if (mcLibToken.m_UtilsMapper.Contains("transformer-discovery-service"))
						{
							if (!File.Exists(mcLibToken.m_UtilsMapper))
							{
								ModBase.WriteFile(mcLibToken.m_UtilsMapper, ModBase.GetResources("Transformer"), false);
							}
							ModBase.Log("[Download] 已自动释放 Transformer Discovery Service", ModBase.LogLevel.Developer, "出现错误");
						}
						else
						{
							if (mcLibToken.m_UtilsMapper.Contains("optifine\\OptiFine"))
							{
								string text2 = mcLibToken.m_UtilsMapper.Replace((mcLibToken._MapperMapper ? JumpLoaderFolder : CustomMcFolder) + "libraries\\optifine\\OptiFine\\", "").Split(new char[]
								{
									'_'
								})[0] + "/" + ModBase.GetFileNameFromPath(mcLibToken.m_UtilsMapper).Replace("-", "_");
								text2 = "/maven/com/optifine/" + text2;
								if (text2.Contains("_pre"))
								{
									text2 = text2.Replace("com/optifine/", "com/optifine/preview_");
								}
								list2.Add("http://download.mcbbs.net" + text2);
								list2.Add("http://bmclapi2.bangbang93.com" + text2);
							}
							else if (list2.Count <= 2)
							{
								list2.AddRange(ModDownload.DlSourceLibraryGet("https://libraries.minecraft.net" + mcLibToken.m_UtilsMapper.Replace((mcLibToken._MapperMapper ? JumpLoaderFolder : CustomMcFolder) + "libraries", "").Replace("\\", "/")));
							}
							list.Add(new ModNet.NetFile(ModBase.ArrayNoDouble<string>(list2.ToArray(), null), mcLibToken.m_UtilsMapper, fileChecker));
						}
					}
				}
			}
			finally
			{
				List<ModMinecraft.McLibToken>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			return ModBase.ArrayNoDouble<ModNet.NetFile>(list, (ModMinecraft._Closure$__.$IR61-23 == null) ? (ModMinecraft._Closure$__.$IR61-23 = ((object a0, object a1) => ((ModMinecraft._Closure$__.$I61-0 == null) ? (ModMinecraft._Closure$__.$I61-0 = ((ModNet.NetFile Left, ModNet.NetFile Right) => Operators.CompareString(Left.mapRule, Right.mapRule, true) == 0)) : ModMinecraft._Closure$__.$I61-0)((ModNet.NetFile)a0, (ModNet.NetFile)a1))) : ModMinecraft._Closure$__.$IR61-23);
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x0004EA98 File Offset: 0x0004CC98
		public static string McLibGet(string Original, bool WithHead = true, bool IgnoreLiteLoader = false, string CustomMcFolder = null)
		{
			CustomMcFolder = (CustomMcFolder ?? ModMinecraft.m_ResolverIterator);
			string[] array = Original.Split(new char[]
			{
				':'
			});
			string text = string.Concat(new string[]
			{
				WithHead ? (CustomMcFolder + "libraries\\") : "",
				array[0].Replace(".", "\\"),
				"\\",
				array[1],
				"\\",
				array[2],
				"\\",
				array[1],
				"-",
				array[2],
				".jar"
			});
			if (text.Contains("optifine\\OptiFine\\1.12") && File.Exists(string.Concat(new string[]
			{
				CustomMcFolder,
				"libraries\\",
				array[0].Replace(".", "\\"),
				"\\",
				array[1],
				"\\",
				array[2],
				"\\",
				array[1],
				"-",
				array[2],
				"-installer.jar"
			})))
			{
				ModBase.Log("[Launch] 已将 " + Original + " 特判替换为对应的 Installer 文件", ModBase.LogLevel.Debug, "出现错误");
				text = text.Replace(".jar", "-installer.jar");
			}
			return text;
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x0004EBF4 File Offset: 0x0004CDF4
		public static JToken McAssetsGetIndex(ModMinecraft.McVersion Version, bool ReturnLegacyOnError = false, bool CheckURLEmpty = false)
		{
			try
			{
				JToken jtoken;
				for (;;)
				{
					jtoken = Version.VerifyUtils()["assetIndex"];
					if (jtoken != null && jtoken["id"] != null)
					{
						break;
					}
					if (Version.VerifyUtils()["assets"] != null)
					{
						Version.VerifyUtils()["assets"].ToString();
					}
					if (CheckURLEmpty && jtoken["url"] != null)
					{
						goto IL_8E;
					}
					if (Operators.CompareString(Version.PrintUtils(), "", true) == 0)
					{
						goto IL_92;
					}
					Version = new ModMinecraft.McVersion(ModMinecraft.m_ResolverIterator + "versions\\" + Version.PrintUtils());
				}
				return jtoken;
				IL_8E:
				return jtoken;
				IL_92:;
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "获取资源文件索引下载地址失败", ModBase.LogLevel.Debug, "出现错误");
			}
			if (!ReturnLegacyOnError)
			{
				throw new Exception("该版本不存在资源文件索引信息");
			}
			ModBase.Log("[Minecraft] 无法获取资源文件索引下载地址，使用缺省的 legacy 下载地址", ModBase.LogLevel.Normal, "出现错误");
			return (JToken)ModBase.GetJson("\r\n                    {\r\n                        \"id\": \"legacy\",\r\n                        \"sha1\": \"c0fd82e8ce9fbc93119e40d96d5a4e62cfa3f729\",\r\n                        \"size\": 134284,\r\n                        \"url\": \"https://launchermeta.mojang.com/mc-staging/assets/legacy/c0fd82e8ce9fbc93119e40d96d5a4e62cfa3f729/legacy.json\",\r\n                        \"totalSize\": 111220701\r\n                    }");
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x0004ECF8 File Offset: 0x0004CEF8
		public static string McAssetsGetIndexName(ModMinecraft.McVersion Version)
		{
			try
			{
				while (Version.VerifyUtils()["assetIndex"] == null || Version.VerifyUtils()["assetIndex"]["id"] == null)
				{
					if (Version.VerifyUtils()["assets"] != null)
					{
						return Version.VerifyUtils()["assets"].ToString();
					}
					if (Operators.CompareString(Version.PrintUtils(), "", true) == 0)
					{
						goto IL_CC;
					}
					Version = new ModMinecraft.McVersion(ModMinecraft.m_ResolverIterator + "versions\\" + Version.PrintUtils());
				}
				return Version.VerifyUtils()["assetIndex"]["id"].ToString();
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "获取资源文件索引名失败", ModBase.LogLevel.Debug, "出现错误");
			}
			IL_CC:
			return "legacy";
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x0004EDE8 File Offset: 0x0004CFE8
		private static List<ModMinecraft.McAssetsToken> McAssetsListGet(string Name)
		{
			List<ModMinecraft.McAssetsToken> list;
			try
			{
				if (!File.Exists(ModMinecraft.m_ResolverIterator + "assets\\indexes\\" + Name + ".json"))
				{
					throw new FileNotFoundException("Assets 索引文件未找到", ModMinecraft.m_ResolverIterator + "assets\\indexes\\" + Name + ".json");
				}
				list = new List<ModMinecraft.McAssetsToken>();
				object objectValue = RuntimeHelpers.GetObjectValue(ModBase.GetJson(ModBase.ReadFile(ModMinecraft.m_ResolverIterator + "assets\\indexes\\" + Name + ".json")));
				bool flag = false;
				if (NewLateBinding.LateIndexGet(objectValue, new object[]
				{
					"virtual"
				}, null) != null)
				{
					flag = Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[]
					{
						"virtual"
					}, null).ToString());
				}
				bool flag2 = false;
				if (NewLateBinding.LateIndexGet(objectValue, new object[]
				{
					"map_to_resources"
				}, null) != null)
				{
					flag2 = Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[]
					{
						"map_to_resources"
					}, null).ToString());
				}
				if (!flag && !flag2)
				{
					try
					{
						foreach (object obj in ((IEnumerable)NewLateBinding.LateGet(NewLateBinding.LateIndexGet(objectValue, new object[]
						{
							"objects"
						}, null), null, "Children", new object[0], null, null, null)))
						{
							JProperty jproperty = (JProperty)obj;
							list.Add(new ModMinecraft.McAssetsToken
							{
								orderMapper = false,
								_ParamsMapper = string.Concat(new string[]
								{
									ModMinecraft.m_ResolverIterator,
									"assets\\objects\\",
									Strings.Left(jproperty.Value["hash"].ToString(), 2),
									"\\",
									jproperty.Value["hash"].ToString()
								}),
								_GlobalMapper = jproperty.Name,
								m_ServiceMapper = jproperty.Value["hash"].ToString(),
								_IssuerMapper = Conversions.ToLong(jproperty.Value["size"].ToString())
							});
						}
						goto IL_31A;
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
				try
				{
					foreach (object obj2 in ((IEnumerable)NewLateBinding.LateGet(NewLateBinding.LateIndexGet(objectValue, new object[]
					{
						"objects"
					}, null), null, "Children", new object[0], null, null, null)))
					{
						JProperty jproperty2 = (JProperty)obj2;
						list.Add(new ModMinecraft.McAssetsToken
						{
							orderMapper = true,
							_ParamsMapper = ModMinecraft.m_ResolverIterator + "assets\\virtual\\legacy\\" + jproperty2.Name.Replace("/", "\\"),
							_GlobalMapper = jproperty2.Name,
							m_ServiceMapper = jproperty2.Value["hash"].ToString(),
							_IssuerMapper = Conversions.ToLong(jproperty2.Value["size"].ToString())
						});
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
				IL_31A:;
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "获取资源文件列表失败：" + Name, ModBase.LogLevel.Debug, "出现错误");
				throw;
			}
			return list;
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x0004F180 File Offset: 0x0004D380
		public static List<ModNet.NetFile> McAssetsFixList<T>(string IndexAddress, bool CheckHash, ref ModLoader.LoaderBase<T> ProgressFeed = null)
		{
			List<ModNet.NetFile> list = new List<ModNet.NetFile>();
			checked
			{
				try
				{
					List<ModMinecraft.McAssetsToken> list2 = ModMinecraft.McAssetsListGet(IndexAddress);
					if (ProgressFeed != null)
					{
						ProgressFeed.Progress = 0.04;
					}
					int num = list2.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						ModMinecraft.McAssetsToken mcAssetsToken = list2[i];
						if (ProgressFeed != null)
						{
							ProgressFeed.Progress = unchecked(0.05 + 0.94 * (double)i / (double)list2.Count);
						}
						FileInfo fileInfo = new FileInfo(mcAssetsToken._ParamsMapper);
						if (!fileInfo.Exists || (mcAssetsToken._IssuerMapper != 0L && mcAssetsToken._IssuerMapper != fileInfo.Length) || (CheckHash && mcAssetsToken.m_ServiceMapper != null && Operators.CompareString(mcAssetsToken.m_ServiceMapper, ModBase.smethod_1(mcAssetsToken._ParamsMapper), true) != 0))
						{
							list.Add(new ModNet.NetFile(ModDownload.DlSourceResourceGet("http://resources.download.minecraft.net/" + Strings.Left(mcAssetsToken.m_ServiceMapper, 2) + "/" + mcAssetsToken.m_ServiceMapper), mcAssetsToken._ParamsMapper, new ModBase.FileChecker(-1L, (mcAssetsToken._IssuerMapper == 0L) ? -1L : mcAssetsToken._IssuerMapper, null, mcAssetsToken.m_ServiceMapper, true, false)));
						}
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "获取版本缺失的资源文件下载列表失败", ModBase.LogLevel.Debug, "出现错误");
				}
				if (ProgressFeed != null)
				{
					ProgressFeed.Progress = 0.99;
				}
				return list;
			}
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x0004F314 File Offset: 0x0004D514
		private static void McModLoad(ModLoader.LoaderTask<string, List<ModMinecraft.McMod>> Loader)
		{
			try
			{
				ModBase.RunInUiWait((ModMinecraft._Closure$__.$I70-0 == null) ? (ModMinecraft._Closure$__.$I70-0 = delegate()
				{
					if (ModMain.m_RulesFilter != null)
					{
						ModMain.m_RulesFilter.Load.ShowProgress = false;
					}
				}) : ModMinecraft._Closure$__.$I70-0);
				List<FileInfo> list = new List<FileInfo>();
				if (Directory.Exists(Loader.Input))
				{
					try
					{
						foreach (FileInfo fileInfo in new DirectoryInfo(Loader.Input).EnumerateFiles("*.*", SearchOption.AllDirectories))
						{
							string text = fileInfo.DirectoryName.ToLower();
							if (!text.StartsWith(Loader.Input + "memory_repo") && (Operators.CompareString(text + "\\", Loader.Input, true) == 0 || !text.Contains("voxel")) && Conversions.ToBoolean(ModMinecraft.McMod.IsModFile(fileInfo.FullName)))
							{
								list.Add(fileInfo);
							}
						}
					}
					finally
					{
						IEnumerator<FileInfo> enumerator;
						if (enumerator != null)
						{
							enumerator.Dispose();
						}
					}
				}
				Loader.Progress = 0.03;
				if (list.Count > 0x64)
				{
					ModBase.RunInUi((ModMinecraft._Closure$__.$I70-1 == null) ? (ModMinecraft._Closure$__.$I70-1 = delegate()
					{
						if (ModMain.m_RulesFilter != null)
						{
							ModMain.m_RulesFilter.Load.ShowProgress = true;
						}
					}) : ModMinecraft._Closure$__.$I70-1, false);
				}
				List<ModMinecraft.McMod> list2 = new List<ModMinecraft.McMod>();
				try
				{
					foreach (FileInfo fileInfo2 in list)
					{
						ModMinecraft.McMod mcMod = new ModMinecraft.McMod(fileInfo2.FullName);
						mcMod.Load(false);
						list2.Add(mcMod);
						Loader.Progress += 0.9 / (double)list.Count;
					}
				}
				finally
				{
					List<FileInfo>.Enumerator enumerator2;
					((IDisposable)enumerator2).Dispose();
				}
				Loader.Progress = 0.93;
				list2 = ModBase.Sort<ModMinecraft.McMod>(list2, (ModMinecraft._Closure$__.$IR70-24 == null) ? (ModMinecraft._Closure$__.$IR70-24 = ((object a0, object a1) => ((ModMinecraft._Closure$__.$I70-2 == null) ? (ModMinecraft._Closure$__.$I70-2 = delegate(ModMinecraft.McMod Left, ModMinecraft.McMod Right)
				{
					bool result;
					if (Left.State == ModMinecraft.McMod.McModState.Unavaliable != (Right.State == ModMinecraft.McMod.McModState.Unavaliable))
					{
						result = (Left.State == ModMinecraft.McMod.McModState.Unavaliable);
					}
					else
					{
						result = (Operators.CompareString(Left.ViewUtils(), Right.ViewUtils(), true) < 0);
					}
					return result;
				}) : ModMinecraft._Closure$__.$I70-2)((ModMinecraft.McMod)a0, (ModMinecraft.McMod)a1))) : ModMinecraft._Closure$__.$IR70-24);
				Loader.Progress = 0.98;
				if (!Loader.IsAborted)
				{
					Loader.Output = list2;
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "Mod 列表加载失败", ModBase.LogLevel.Debug, "出现错误");
				throw;
			}
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x0004F57C File Offset: 0x0004D77C
		public static void McModListLoad(ModLoader.LoaderTask<List<ModMinecraft.McMod>, int> Loader)
		{
			ModMinecraft._Closure$__71-0 CS$<>8__locals1 = new ModMinecraft._Closure$__71-0(CS$<>8__locals1);
			if (ModMain.m_RulesFilter != null)
			{
				CS$<>8__locals1.$VB$Local_List = Loader.Input;
				ModBase.RunInUi(delegate()
				{
					try
					{
						ModMain.m_RulesFilter.PanList.Children.Clear();
						StackPanel stackPanel = new StackPanel
						{
							Margin = new Thickness(20.0, 40.0, 18.0, (double)((CS$<>8__locals1.$VB$Local_List.Count > 0) ? 0x14 : 0)),
							VerticalAlignment = VerticalAlignment.Top,
							RenderTransform = new TranslateTransform(0.0, 0.0)
						};
						try
						{
							foreach (ModMinecraft.McMod entry in CS$<>8__locals1.$VB$Local_List)
							{
								stackPanel.Children.Add(ModMinecraft.McModListItem(entry));
							}
						}
						finally
						{
							List<ModMinecraft.McMod>.Enumerator enumerator;
							((IDisposable)enumerator).Dispose();
						}
						MyCard myCard = new MyCard
						{
							Title = ModMinecraft.McModGetTitle(CS$<>8__locals1.$VB$Local_List),
							Margin = new Thickness(0.0, 0.0, 0.0, 15.0)
						};
						myCard.Children.Add(stackPanel);
						ModMain.m_RulesFilter.PanList.Children.Add(myCard);
						if (Conversions.ToBoolean(CS$<>8__locals1.$VB$Local_List.Count > 0 && Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("HintModDisable", null)))))
						{
							ModBase._BaseRule.Set("HintModDisable", true, false, null);
							ModMain.Hint("直接点击某个 Mod 项即可将它禁用！", ModMain.HintType.Info, true);
						}
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "加载 Mod 列表 UI 失败", ModBase.LogLevel.Feedback, "出现错误");
					}
				}, false);
			}
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x0004F5B8 File Offset: 0x0004D7B8
		public static string McModGetTitle(List<ModMinecraft.McMod> List)
		{
			int[] array = new int[3];
			try
			{
				foreach (ModMinecraft.McMod mcMod in List)
				{
					int[] array2 = array;
					ModMinecraft.McMod.McModState state = mcMod.State;
					ref int ptr = ref array2[(int)state];
					array2[(int)state] = checked(ptr + 1);
				}
			}
			finally
			{
				List<ModMinecraft.McMod>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			string result;
			if (List.Count == 0)
			{
				result = "未找到任何 Mod";
			}
			else if (array[1] == 0 && array[2] == 0)
			{
				result = "Mod 列表（" + Conversions.ToString(array[0]) + "）";
			}
			else
			{
				List<string> list = new List<string>();
				if (array[0] > 0)
				{
					list.Add("启用 " + Conversions.ToString(array[0]));
				}
				if (array[1] > 0)
				{
					list.Add("禁用 " + Conversions.ToString(array[1]));
				}
				if (array[2] > 0)
				{
					list.Add("错误 " + Conversions.ToString(array[2]));
				}
				result = "Mod 列表（" + ModBase.Join(list, "，") + "）";
			}
			return result;
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x0004F6D8 File Offset: 0x0004D8D8
		public static MyListItem McModListItem(ModMinecraft.McMod Entry)
		{
			ModMinecraft.McMod.McModState state = Entry.State;
			string logo;
			if (state != ModMinecraft.McMod.McModState.Fine)
			{
				if (state != ModMinecraft.McMod.McModState.Disabled)
				{
					logo = "pack://application:,,,/images/Blocks/RedstoneBlock.png";
				}
				else
				{
					logo = "pack://application:,,,/images/Blocks/RedstoneLampOff.png";
				}
			}
			else
			{
				logo = "pack://application:,,,/images/Blocks/RedstoneLampOn.png";
			}
			string title;
			if (Entry.State == ModMinecraft.McMod.McModState.Disabled)
			{
				title = ModBase.GetFileNameWithoutExtentionFromPath(Entry.Path.Substring(0, checked(Entry.Path.Count<char>() - ".disabled".Count<char>()))) + "（已禁用）";
			}
			else
			{
				title = ModBase.GetFileNameWithoutExtentionFromPath(Entry.Path);
			}
			string info;
			if (Entry.Version != null && Entry.Description == null)
			{
				if (Entry.RemoveUtils())
				{
					info = Entry.Path;
				}
				else
				{
					info = "存在错误 : " + Entry.Path;
				}
			}
			else
			{
				info = Entry.Name + ((Entry.Version == null) ? "" : (" (" + Entry.Version + ")")) + " : " + (Entry.Description ?? Entry.Path);
			}
			return new MyListItem
			{
				Logo = logo,
				SnapsToDevicePixels = true,
				Title = title,
				Info = info,
				Height = 42.0,
				Type = MyListItem.CheckType.Clickable,
				Tag = Entry,
				PaddingRight = (Entry.RemoveUtils() ? 0x49 : 0x37),
				utilsDecorator = ((ModMinecraft._Closure$__.$IR73-25 == null) ? (ModMinecraft._Closure$__.$IR73-25 = delegate(object sender, EventArgs e)
				{
					ModMinecraft.McModContent((MyListItem)sender, e);
				}) : ModMinecraft._Closure$__.$IR73-25)
			};
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x0004F848 File Offset: 0x0004DA48
		public static void McModContent(MyListItem sender, EventArgs e)
		{
			ModMinecraft.McMod mcMod = (ModMinecraft.McMod)sender2.Tag;
			PageVersionMod $VB$NonLocal_2 = ModMain.m_RulesFilter;
			sender2.QueryModel(delegate(object sender, MouseButtonEventArgs e)
			{
				$VB$NonLocal_2.Item_Click((MyListItem)sender, e);
			});
			MyIconButton myIconButton = new MyIconButton
			{
				LogoScale = 1.1,
				Logo = "M520.192 0C408.43 0 317.44 82.87 313.563 186.734H52.736c-29.038 0-52.663 21.943-52.663 49.079s23.625 49.152 52.663 49.152h58.075v550.473c0 103.35 75.118 187.757 167.717 187.757h472.43c92.599 0 167.716-83.894 167.716-187.757V285.477h52.59c29.038 0 52.59-21.943 52.663-49.08-0.073-27.135-23.625-49.151-52.663-49.151H726.235C723.237 83.017 631.955 0 520.192 0zM404.846 177.957c3.803-50.03 50.176-89.015 107.447-89.015 57.197 0 103.57 38.985 106.788 89.015H404.92zM284.379 933.669c-33.353 0-69.997-39.351-69.997-95.525v-549.01H833.39v549.522c0 56.247-36.645 95.525-69.998 95.525H284.379v-0.512z M357.23 800.695a48.274 48.274 0 0 0 47.616-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.69 49.006V751.69c0 27.282 20.846 49.006 47.617 49.006z m166.62 0a48.274 48.274 0 0 0 47.688-49.006V471.7a48.274 48.274 0 0 0-47.689-49.08 48.274 48.274 0 0 0-47.543 49.006V751.69c0 27.282 21.431 49.006 47.543 49.006z m142.92 0a48.274 48.274 0 0 0 47.543-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.616 49.006V751.69c0 27.282 20.773 49.006 47.543 49.006z",
				Tag = sender2
			};
			myIconButton.ToolTip = "删除";
			ToolTipService.SetPlacement(myIconButton, PlacementMode.Center);
			ToolTipService.SetVerticalOffset(myIconButton, 30.0);
			ToolTipService.SetHorizontalOffset(myIconButton, 2.0);
			MyIconButton myIconButton2 = myIconButton;
			PageVersionMod $VB$NonLocal_3 = ModMain.m_RulesFilter;
			myIconButton2.Click += delegate(object sender, EventArgs e)
			{
				$VB$NonLocal_3.Delete_Click((MyIconButton)sender, e);
			};
			MyIconButton myIconButton3 = new MyIconButton
			{
				LogoScale = 1.15,
				Logo = "M889.018182 418.909091H884.363636V316.509091a93.090909 93.090909 0 0 0-99.607272-89.832727h-302.545455l-93.090909-76.334546A46.545455 46.545455 0 0 0 358.865455 139.636364H146.152727A93.090909 93.090909 0 0 0 46.545455 229.469091V837.818182a46.545455 46.545455 0 0 0 46.545454 46.545454 46.545455 46.545455 0 0 0 16.756364-3.258181 109.381818 109.381818 0 0 0 25.134545 3.258181h586.472727a85.178182 85.178182 0 0 0 87.04-63.301818l163.374546-302.545454a46.545455 46.545455 0 0 0 5.585454-21.876364A82.385455 82.385455 0 0 0 889.018182 418.909091z m-744.727273-186.181818h198.283636l93.09091 76.334545a46.545455 46.545455 0 0 0 29.323636 10.705455h319.301818a12.101818 12.101818 0 0 1 6.516364 0V418.909091H302.545455a85.178182 85.178182 0 0 0-87.04 63.301818L139.636364 622.778182V232.727273a19.549091 19.549091 0 0 1 6.516363 0z m578.094546 552.029091a27.461818 27.461818 0 0 0-2.792728 6.516363H154.530909l147.083636-272.290909a27.461818 27.461818 0 0 0 2.792728-6.981818h565.061818z",
				Tag = sender2
			};
			myIconButton3.ToolTip = "打开文件位置";
			ToolTipService.SetPlacement(myIconButton3, PlacementMode.Center);
			ToolTipService.SetVerticalOffset(myIconButton3, 30.0);
			ToolTipService.SetHorizontalOffset(myIconButton3, 2.0);
			MyIconButton myIconButton4 = myIconButton3;
			PageVersionMod $VB$NonLocal_4 = ModMain.m_RulesFilter;
			myIconButton4.Click += delegate(object sender, EventArgs e)
			{
				$VB$NonLocal_4.Open_Click((MyIconButton)sender, e);
			};
			if (mcMod.RemoveUtils())
			{
				MyIconButton myIconButton5 = new MyIconButton
				{
					LogoScale = 1.05,
					Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z",
					Tag = sender2
				};
				myIconButton5.ToolTip = "详情";
				ToolTipService.SetPlacement(myIconButton5, PlacementMode.Center);
				ToolTipService.SetVerticalOffset(myIconButton5, 30.0);
				ToolTipService.SetHorizontalOffset(myIconButton5, 2.0);
				myIconButton5.Click += ModMain.m_RulesFilter.Info_Click;
				sender2.MouseRightButtonDown += new MouseButtonEventHandler(ModMain.m_RulesFilter.Info_Click);
				sender2.Buttons = new MyIconButton[]
				{
					myIconButton5,
					myIconButton3,
					myIconButton
				};
				return;
			}
			sender2.Buttons = new MyIconButton[]
			{
				myIconButton3,
				myIconButton
			};
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x0004FA2C File Offset: 0x0004DC2C
		public static void McDownloadClientUpdateHint(string VersionName, JObject Json)
		{
			try
			{
				JToken jtoken = null;
				try
				{
					foreach (JToken jtoken2 in ((IEnumerable<JToken>)Json["versions"]))
					{
						if (jtoken2["id"] != null && Operators.CompareString(jtoken2["id"].ToString(), VersionName, true) == 0)
						{
							jtoken = jtoken2;
							break;
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
				if (jtoken != null)
				{
					DateTime dateTime = (DateTime)jtoken["releaseTime"];
					int num;
					if ((DateTime.Now - dateTime).TotalDays > 1.0)
					{
						num = ModMain.MyMsgBox("新版本：" + VersionName + "\r\n更新时间：" + dateTime.ToString(), "Minecraft 更新提示", "下载", "更新日志", "取消", false, true, false);
					}
					else if ((DateTime.Now - dateTime).TotalHours > 3.0)
					{
						num = ModMain.MyMsgBox("新版本：" + VersionName + "\r\n更新于：" + ModBase.GetTimeSpanString(dateTime - DateTime.Now), "Minecraft 更新提示", "下载", "更新日志", "取消", false, true, false);
					}
					else
					{
						num = ModMain.MyMsgBox("新版本：" + VersionName + "\r\n更新于：" + ModBase.GetTimeSpanString(dateTime - DateTime.Now), "Minecraft 更新提示", "下载", "取消", "", false, true, false);
						if (num == 2)
						{
							num = 3;
						}
					}
					if (num != 1)
					{
						if (num == 2)
						{
							ModDownloadLib.McUpdateLogShow(jtoken);
						}
					}
					else
					{
						ModDownloadLib.McDownloadClient(ModNet.NetPreDownloadBehaviour.HintWhileExists, VersionName, jtoken["url"].ToString());
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "Minecraft 更新提示发送失败（" + (VersionName ?? "Nothing") + "）", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x00006B31 File Offset: 0x00004D31
		public static bool VersionSortBoolean(string Left, string Right)
		{
			return ModMinecraft.VersionSortInteger(Left, Right) >= 0;
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x0004FC40 File Offset: 0x0004DE40
		public static int VersionSortInteger(string Left, string Right)
		{
			if (Operators.CompareString(Left, "未知版本", true) == 0 || Operators.CompareString(Right, "未知版本", true) == 0)
			{
				if (Operators.CompareString(Left, "未知版本", true) == 0 && Operators.CompareString(Right, "未知版本", true) != 0)
				{
					return 1;
				}
				if (Operators.CompareString(Left, "未知版本", true) == 0 && Operators.CompareString(Right, "未知版本", true) == 0)
				{
					return 0;
				}
				if (Operators.CompareString(Left, "未知版本", true) != 0 && Operators.CompareString(Right, "未知版本", true) == 0)
				{
					return -1;
				}
			}
			List<string> list = ModBase.RegexSearch(Left.ToLower(), "[a-z]+|[0-9]+", RegexOptions.None);
			List<string> list2 = ModBase.RegexSearch(Right.ToLower(), "[a-z]+|[0-9]+", RegexOptions.None);
			int num = 0;
			checked
			{
				while (list.Count - 1 >= num || list2.Count - 1 >= num)
				{
					string text = (list.Count - 1 < num) ? "-1" : list[num];
					string text2 = (list2.Count - 1 < num) ? "-1" : list2[num];
					if (Operators.CompareString(text, text2, true) != 0)
					{
						if (Operators.CompareString(text, "pre", true) == 0 || Operators.CompareString(text, "snapshot", true) == 0)
						{
							text = "-3";
						}
						if (Operators.CompareString(text, "rc", true) == 0)
						{
							text = "-2";
						}
						if (Operators.CompareString(text, "experimental", true) == 0)
						{
							text = "-4";
						}
						double num2 = ModBase.Val(text);
						if (Operators.CompareString(text2, "pre", true) == 0 || Operators.CompareString(text2, "snapshot", true) == 0)
						{
							text2 = "-3";
						}
						if (Operators.CompareString(text2, "rc", true) == 0)
						{
							text2 = "-2";
						}
						if (Operators.CompareString(text2, "experimental", true) == 0)
						{
							text2 = "-4";
						}
						double num3 = ModBase.Val(text2);
						if (num2 == 0.0 && num3 == 0.0)
						{
							if (Operators.CompareString(text, text2, true) > 0)
							{
								return 1;
							}
							if (Operators.CompareString(text, text2, true) < 0)
							{
								return -1;
							}
						}
						else
						{
							if (num2 > num3)
							{
								return 1;
							}
							if (num2 < num3)
							{
								return -1;
							}
						}
					}
					num++;
				}
				int result;
				if (Operators.CompareString(Left, Right, true) > 0)
				{
					result = 1;
				}
				else if (Operators.CompareString(Left, Right, true) < 0)
				{
					result = -1;
				}
				else
				{
					result = 0;
				}
				return result;
			}
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x0004FE90 File Offset: 0x0004E090
		public static string AccountFilter(string Account)
		{
			string result;
			if (Account.Contains("@"))
			{
				string[] array = Account.Split(new char[]
				{
					'@'
				});
				result = "".PadLeft(array[0].Count<char>(), '*') + "@" + array[1];
			}
			else if (Account.Count<char>() >= 6)
			{
				result = Strings.Mid(Account, 1, checked(Account.Count<char>() - 4)) + "****";
			}
			else
			{
				result = "".PadLeft(Account.Count<char>(), '*');
			}
			return result;
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x0004FF1C File Offset: 0x0004E11C
		public static string ArgumentReplace(string Raw)
		{
			string result;
			if (Raw == null)
			{
				result = null;
			}
			else
			{
				Raw = Raw.Replace("{user}", Information.IsNothing(ModLaunch._InfoIterator.Output) ? "尚未登录" : ModLaunch._InfoIterator.Output.Name);
				if (Information.IsNothing(ModLaunch._InfoIterator.Input))
				{
					Raw = Raw.Replace("{login}", "尚未登录");
				}
				else
				{
					switch (ModLaunch._InfoIterator.Input.Type)
					{
					case ModLaunch.McLoginType.Legacy:
						Raw = Raw.Replace("{login}", "离线");
						break;
					case ModLaunch.McLoginType.Mojang:
						Raw = Raw.Replace("{login}", "Mojang 正版");
						break;
					case ModLaunch.McLoginType.Nide:
						Raw = Raw.Replace("{login}", "统一通行证");
						break;
					case ModLaunch.McLoginType.Auth:
						Raw = Raw.Replace("{login}", "Authlib-Injector");
						break;
					case ModLaunch.McLoginType.Ms:
						Raw = Raw.Replace("{login}", "微软正版");
						break;
					}
				}
				if (ModMinecraft._FieldIterator == null)
				{
					Raw = Raw.Replace("{name}", "无可用版本");
					Raw = Raw.Replace("{version}", "无可用版本");
				}
				else
				{
					Raw = Raw.Replace("{name}", ModMinecraft._FieldIterator.Name);
					if (!ModMinecraft._FieldIterator._ReponseAlgo)
					{
						ModMinecraft._FieldIterator.Load();
					}
					Raw = Raw.Replace("{version}", ModMinecraft._FieldIterator.Version.policyAlgo);
				}
				Raw = Raw.Replace("{path}", ModBase.Path);
				result = Raw;
			}
			return result;
		}

		// Token: 0x040004D2 RID: 1234
		public static int m_AccountIterator;

		// Token: 0x040004D3 RID: 1235
		public static List<ModMinecraft.JavaEntry> _ConfigurationIterator;

		// Token: 0x040004D4 RID: 1236
		private static string _InterpreterIterator;

		// Token: 0x040004D5 RID: 1237
		public static ModLoader.LoaderTask<int, int> _PredicateIterator;

		// Token: 0x040004D6 RID: 1238
		public static string _StructIterator;

		// Token: 0x040004D7 RID: 1239
		public static string m_ResolverIterator;

		// Token: 0x040004D8 RID: 1240
		public static List<ModMinecraft.McFolder> collectionIterator;

		// Token: 0x040004D9 RID: 1241
		public static ModLoader.LoaderTask<int, int> _TestsIterator;

		// Token: 0x040004DA RID: 1242
		private static List<ModMinecraft.McFolder> broadcasterIterator;

		// Token: 0x040004DB RID: 1243
		private static ModMinecraft.McVersion _FieldIterator;

		// Token: 0x040004DC RID: 1244
		private static ModMinecraft.McVersion m_StatusIterator;

		// Token: 0x040004DD RID: 1245
		public static Dictionary<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>> m_RequestIterator;

		// Token: 0x040004DE RID: 1246
		public static bool m_PoolIterator;

		// Token: 0x040004DF RID: 1247
		public static ModLoader.LoaderTask<string, int> m_ParserIterator;

		// Token: 0x040004E0 RID: 1248
		private static readonly object _ProxyIterator;

		// Token: 0x040004E1 RID: 1249
		private static string setterIterator;

		// Token: 0x040004E2 RID: 1250
		public static ModLoader.LoaderTask<string, List<ModMinecraft.McMod>> _MerchantIterator;

		// Token: 0x020000FE RID: 254
		public class JavaEntry
		{
			// Token: 0x060008DE RID: 2270 RVA: 0x00006B40 File Offset: 0x00004D40
			public string AwakeExpression()
			{
				return this.m_AnnotationAlgo + "java.exe";
			}

			// Token: 0x060008DF RID: 2271 RVA: 0x00006B52 File Offset: 0x00004D52
			public string DisableExpression()
			{
				return this.m_AnnotationAlgo + "javaw.exe";
			}

			// Token: 0x060008E0 RID: 2272 RVA: 0x00006B64 File Offset: 0x00004D64
			public int ResetExpression()
			{
				return this._RegAlgo.Minor;
			}

			// Token: 0x060008E1 RID: 2273 RVA: 0x000500B4 File Offset: 0x0004E2B4
			public bool CloneExpression()
			{
				return this.m_AnnotationAlgo != null && ModMinecraft.ManageContainer() != null && ModMinecraft.ManageContainer().Replace("\\", "").Replace("/", "").ToLower().Contains(this.m_AnnotationAlgo.Replace("\\", "").ToLower());
			}

			// Token: 0x060008E2 RID: 2274 RVA: 0x00050120 File Offset: 0x0004E320
			public JObject ToJson()
			{
				return new JObject(new object[]
				{
					new JProperty("Path", this.m_AnnotationAlgo),
					new JProperty("VersionString", this._RegAlgo.ToString()),
					new JProperty("IsJre", this.m_DefinitionAlgo),
					new JProperty("Is64Bit", this.m_ParamAlgo),
					new JProperty("IsUserImport", this.readerAlgo)
				});
			}

			// Token: 0x060008E3 RID: 2275 RVA: 0x000501AC File Offset: 0x0004E3AC
			public static ModMinecraft.JavaEntry FromJson(JObject Data)
			{
				return new ModMinecraft.JavaEntry((string)Data["Path"], (bool)Data["IsUserImport"])
				{
					_RegAlgo = new Version((string)Data["VersionString"]),
					m_DefinitionAlgo = (bool)Data["IsJre"],
					m_ParamAlgo = (bool)Data["Is64Bit"]
				};
			}

			// Token: 0x060008E4 RID: 2276 RVA: 0x00050228 File Offset: 0x0004E428
			public override string ToString()
			{
				string text = this._RegAlgo.ToString();
				if (text.StartsWith("1."))
				{
					text = Strings.Mid(text, 3);
				}
				return string.Concat(new string[]
				{
					this.m_DefinitionAlgo ? "Java " : "JDK ",
					Conversions.ToString(this.ResetExpression()),
					" (",
					text,
					")，",
					this.m_ParamAlgo ? "64" : "32",
					" 位",
					this.readerAlgo ? "，手动导入" : "",
					"：",
					this.m_AnnotationAlgo
				});
			}

			// Token: 0x060008E5 RID: 2277 RVA: 0x000502E4 File Offset: 0x0004E4E4
			public JavaEntry(string Folder, bool IsUserImport)
			{
				this.IsChecked = false;
				if (!Folder.EndsWith("\\"))
				{
					Folder += "\\";
				}
				this.m_AnnotationAlgo = Folder.Replace("/", "\\");
				this.readerAlgo = IsUserImport;
			}

			// Token: 0x060008E6 RID: 2278 RVA: 0x00050338 File Offset: 0x0004E538
			public void Check()
			{
				if (!this.IsChecked)
				{
					string text = null;
					try
					{
						if (!File.Exists(this.DisableExpression()))
						{
							throw new FileNotFoundException("未找到 javaw.exe 文件", this.DisableExpression());
						}
						if (!File.Exists(this.m_AnnotationAlgo + "java.exe"))
						{
							throw new FileNotFoundException("未找到 java.exe 文件", this.m_AnnotationAlgo + "java.exe");
						}
						this.m_DefinitionAlgo = !File.Exists(this.m_AnnotationAlgo + "javac.exe");
						text = ModBase.ShellAndGetOutput(this.m_AnnotationAlgo + "java.exe", "-version", 0x1F40, null).ToLower();
						if (ModBase.errorRule)
						{
							ModBase.Log("[Java] Java 检查输出：" + this.m_AnnotationAlgo + "java.exe\r\n" + text, ModBase.LogLevel.Normal, "出现错误");
						}
						string text2;
						if ((text2 = ModBase.RegexSeek(text, "(?<=version \")[^\"]+", RegexOptions.None)) == null)
						{
							text2 = (ModBase.RegexSeek(text, "(?<=openjdk )[0-9]+", RegexOptions.None) ?? "");
						}
						string text3 = text2.Replace("_", ".").Replace("-ea", "");
						while (text3.Split(new char[]
						{
							'.'
						}).Count<string>() < 4)
						{
							if (text3.StartsWith("1."))
							{
								text3 += ".0";
							}
							else
							{
								text3 = "1." + text3;
							}
						}
						this._RegAlgo = new Version(text3);
						if (this._RegAlgo.Minor == 0)
						{
							ModBase.Log("[Java] 疑似 X.0.X.X 格式版本号：" + this._RegAlgo.ToString(), ModBase.LogLevel.Normal, "出现错误");
							this._RegAlgo = new Version(1, this._RegAlgo.Major, this._RegAlgo.Build, this._RegAlgo.Revision);
						}
						this.m_ParamAlgo = text.Contains("64-bit");
						if (this._RegAlgo.Minor <= 6 || this._RegAlgo.Minor >= 0x19)
						{
							throw new Exception("分析详细信息失败，获取的版本为 " + this._RegAlgo.ToString());
						}
					}
					catch (Exception ex)
					{
						ModBase.Log("[Java] 检查失败的 Java 输出：" + this.m_AnnotationAlgo + "java.exe\r\n" + (text ?? "无程序输出"), ModBase.LogLevel.Normal, "出现错误");
						ex = new Exception("检查 Java 详细信息失败（" + (this.DisableExpression() ?? "Nothing") + "）", ex);
						throw ex;
					}
					this.IsChecked = true;
				}
			}

			// Token: 0x040004E3 RID: 1251
			public string m_AnnotationAlgo;

			// Token: 0x040004E4 RID: 1252
			public bool readerAlgo;

			// Token: 0x040004E5 RID: 1253
			public Version _RegAlgo;

			// Token: 0x040004E6 RID: 1254
			public bool m_DefinitionAlgo;

			// Token: 0x040004E7 RID: 1255
			public bool m_ParamAlgo;

			// Token: 0x040004E8 RID: 1256
			private bool IsChecked;
		}

		// Token: 0x020000FF RID: 255
		public class McFolder
		{
			// Token: 0x060008E8 RID: 2280 RVA: 0x000505C0 File Offset: 0x0004E7C0
			public override bool Equals(object obj)
			{
				bool result;
				if (!(obj is ModMinecraft.McFolder))
				{
					result = false;
				}
				else
				{
					ModMinecraft.McFolder mcFolder = (ModMinecraft.McFolder)obj;
					result = (Operators.CompareString(this.Name, mcFolder.Name, true) == 0 && Operators.CompareString(this.Path, mcFolder.Path, true) == 0 && this.Type == mcFolder.Type && this.mockAlgo == mcFolder.mockAlgo);
				}
				return result;
			}

			// Token: 0x060008E9 RID: 2281 RVA: 0x00006B71 File Offset: 0x00004D71
			public override string ToString()
			{
				return this.Path;
			}

			// Token: 0x040004E9 RID: 1257
			public string Name;

			// Token: 0x040004EA RID: 1258
			public string Path;

			// Token: 0x040004EB RID: 1259
			public ModMinecraft.McFolderType Type;

			// Token: 0x040004EC RID: 1260
			public int mockAlgo;
		}

		// Token: 0x02000100 RID: 256
		public enum McFolderType
		{
			// Token: 0x040004EE RID: 1262
			Original,
			// Token: 0x040004EF RID: 1263
			RenamedOriginal,
			// Token: 0x040004F0 RID: 1264
			Custom
		}

		// Token: 0x02000101 RID: 257
		public class McVersion
		{
			// Token: 0x17000159 RID: 345
			// (get) Token: 0x060008EA RID: 2282 RVA: 0x00006B79 File Offset: 0x00004D79
			public string Path { get; }

			// Token: 0x060008EB RID: 2283 RVA: 0x00006B81 File Offset: 0x00004D81
			public string ManageExpression()
			{
				return this.GetPathIndie(this.Version.LoginUtils());
			}

			// Token: 0x060008EC RID: 2284 RVA: 0x0005062C File Offset: 0x0004E82C
			public string GetPathIndie(bool Modable)
			{
				int num = Conversions.ToInteger(ModBase._BaseRule.Get("LaunchArgumentIndie", null));
				object left = ModBase._BaseRule.Get("VersionArgumentIndie", this);
				if (Operators.ConditionalCompareObjectEqual(left, -1, true))
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(this.Path + "mods\\");
					DirectoryInfo directoryInfo2 = new DirectoryInfo(this.Path + "saves\\");
					if ((directoryInfo.Exists && directoryInfo.EnumerateFiles().Count<FileInfo>() > 0) || (directoryInfo2.Exists && directoryInfo2.EnumerateFiles().Count<FileInfo>() > 0))
					{
						ModBase._BaseRule.Set("VersionArgumentIndie", 1, false, this);
						ModBase.Log("[Setup] 已自动开启单版本隔离：" + this.Name, ModBase.LogLevel.Normal, "出现错误");
						goto IL_1BF;
					}
					ModBase._BaseRule.Set("VersionArgumentIndie", 0, false, this);
					ModBase.Log("[Setup] 版本隔离使用全局设置：" + this.Name, ModBase.LogLevel.Normal, "出现错误");
				}
				else if (!Operators.ConditionalCompareObjectEqual(left, 0, true))
				{
					if (Operators.ConditionalCompareObjectEqual(left, 1, true))
					{
						goto IL_1BF;
					}
					if (Operators.ConditionalCompareObjectEqual(left, 2, true))
					{
						goto IL_1AE;
					}
				}
				switch (num)
				{
				case 1:
					if (Modable)
					{
						return this.Path;
					}
					break;
				case 2:
					if (this.m_HelperAlgo == ModMinecraft.McVersionState.Fool || this.m_HelperAlgo == ModMinecraft.McVersionState.Old || this.m_HelperAlgo == ModMinecraft.McVersionState.Snapshot)
					{
						return this.Path;
					}
					break;
				case 3:
					if (Modable)
					{
						return this.Path;
					}
					if (this.m_HelperAlgo != ModMinecraft.McVersionState.Fool && this.m_HelperAlgo != ModMinecraft.McVersionState.Old)
					{
						if (this.m_HelperAlgo != ModMinecraft.McVersionState.Snapshot)
						{
							break;
						}
					}
					return this.Path;
				case 4:
					IL_1BF:
					return this.Path;
				}
				IL_1AE:
				return ModMinecraft.m_ResolverIterator;
			}

			// Token: 0x1700015A RID: 346
			// (get) Token: 0x060008ED RID: 2285 RVA: 0x00006B94 File Offset: 0x00004D94
			public string Name
			{
				get
				{
					if (this._DicAlgo == null && Operators.CompareString(this.Path, "", true) != 0)
					{
						this._DicAlgo = ModBase.GetFolderNameFromPath(this.Path);
					}
					return this._DicAlgo;
				}
			}

			// Token: 0x1700015B RID: 347
			// (get) Token: 0x060008EE RID: 2286 RVA: 0x00050800 File Offset: 0x0004EA00
			// (set) Token: 0x060008EF RID: 2287 RVA: 0x00006BC8 File Offset: 0x00004DC8
			public ModMinecraft.McVersionInfo Version
			{
				get
				{
					if (this._ExceptionAlgo == null)
					{
						this._ExceptionAlgo = new ModMinecraft.McVersionInfo();
						try
						{
							try
							{
								if (this.VerifyUtils()["releaseTime"] == null)
								{
									this.m_RulesAlgo = new DateTime(0x7B2, 1, 1, 0xF, 0, 0);
								}
								else
								{
									this.m_RulesAlgo = this.VerifyUtils()["releaseTime"].ToObject<DateTime>();
								}
								if (this.m_RulesAlgo.Year > 0x7D0 && this.m_RulesAlgo.Year < 0x7DD)
								{
									this._ExceptionAlgo.policyAlgo = "Old";
									goto IL_3CA;
								}
							}
							catch (Exception ex)
							{
								ModBase.Log(ex, "判断是否为老版本失败", ModBase.LogLevel.Debug, "出现错误");
								this.m_RulesAlgo = new DateTime(0x7B2, 1, 1, 0xF, 0, 0);
							}
							if ((string)(this.VerifyUtils()["type"] ?? "") == "pending")
							{
								this._ExceptionAlgo.policyAlgo = "pending";
							}
							else
							{
								if (this.WriteUtils())
								{
									try
									{
										this._ExceptionAlgo.policyAlgo = (string)this.VerifyUtils()["jumploader"]["jars"]["minecraft"][0]["gameVersion"];
										goto IL_3CA;
									}
									catch (Exception ex2)
									{
									}
								}
								if (this.VerifyUtils()["clientVersion"] != null)
								{
									this._ExceptionAlgo.policyAlgo = (string)this.VerifyUtils()["clientVersion"];
								}
								else if (Operators.CompareString(this.PrintUtils(), "", true) != 0)
								{
									this._ExceptionAlgo.policyAlgo = (this.VerifyUtils()["jar"] ?? "").ToString();
									if (Operators.CompareString(this._ExceptionAlgo.policyAlgo, "", true) == 0)
									{
										this._ExceptionAlgo.policyAlgo = this.PrintUtils();
									}
								}
								else
								{
									List<string> list = ModBase.RegexSearch((this.VerifyUtils()["downloads"] ?? "").ToString(), "(?<=launcher.mojang.com/mc/game/)[^/]*", RegexOptions.None);
									if (list.Count != 0)
									{
										this._ExceptionAlgo.policyAlgo = list[0];
									}
									else
									{
										string str = this.VerifyUtils()["libraries"].ToString();
										list = ModBase.RegexSearch(str, "(?<=net.minecraftforge:forge:)[^-]*", RegexOptions.None);
										if (list.Count != 0)
										{
											this._ExceptionAlgo.policyAlgo = list[0];
										}
										else
										{
											list = ModBase.RegexSearch(str, "(?<=((fabricmc)|(quiltmc)):intermediary:)[^\"]*", RegexOptions.None);
											if (list.Count != 0)
											{
												this._ExceptionAlgo.policyAlgo = list[0];
											}
											else
											{
												ModBase.Log("[Minecraft] 无法完全确认 MC 版本号的版本：" + this.Name, ModBase.LogLevel.Normal, "出现错误");
												list = ModBase.RegexSearch(this.Name, "([0-9w]{5}[a-z]{1})|(1\\.[0-9]+(\\.[0-9]+)?(-(pre|rc)[1-9]?| Pre-Release( [1-9]{1})?)?)", RegexOptions.None);
												if (list.Count != 0)
												{
													this._ExceptionAlgo.policyAlgo = list[0];
												}
												else
												{
													JObject jobject = (JObject)this.VerifyUtils().DeepClone();
													jobject.Remove("libraries");
													list = ModBase.RegexSearch(jobject.ToString(), "([0-9w]{5}[a-z]{1})|(1\\.[0-9]+(\\.[0-9]+)?(-(pre|rc)[1-9]?| Pre-Release( [1-9]{1})?)?)", RegexOptions.None);
													if (list.Count != 0)
													{
														this._ExceptionAlgo.policyAlgo = list[0];
													}
													else
													{
														this._ExceptionAlgo.policyAlgo = "Unknown";
														this.m_SchemaAlgo = "PCL 无法识别该版本，请向作者反馈此问题";
													}
												}
											}
										}
									}
								}
							}
						}
						catch (Exception ex3)
						{
							ModBase.Log(ex3, "识别 Minecraft 版本时出错", ModBase.LogLevel.Debug, "出现错误");
							this._ExceptionAlgo.policyAlgo = "Unknown";
							this.m_SchemaAlgo = "无法识别：" + ex3.Message;
						}
						IL_3CA:
						if (this._ExceptionAlgo.policyAlgo.StartsWith("1."))
						{
							string[] array = this._ExceptionAlgo.policyAlgo.Split(new char[]
							{
								' ',
								'_',
								'-',
								'.'
							});
							string text = (array.Count<string>() >= 2) ? array[1] : "0";
							this._ExceptionAlgo.clientAlgo = Conversions.ToInteger((text.Length <= 2) ? ModBase.Val(text) : "0");
							text = ((array.Count<string>() >= 3) ? array[2] : "0");
							this._ExceptionAlgo._MapAlgo = Conversions.ToInteger((text.Length <= 2) ? ModBase.Val(text) : "0");
						}
						else if (this._ExceptionAlgo.policyAlgo.Contains("w") || Operators.CompareString(this._ExceptionAlgo.policyAlgo, "pending", true) == 0)
						{
							this._ExceptionAlgo.clientAlgo = 0x63;
							this._ExceptionAlgo._MapAlgo = 0x63;
						}
					}
					return this._ExceptionAlgo;
				}
				set
				{
					this._ExceptionAlgo = value;
				}
			}

			// Token: 0x060008F0 RID: 2288 RVA: 0x00050D3C File Offset: 0x0004EF3C
			public string RestartExpression()
			{
				if (this._ClassAlgo == null)
				{
					if (!File.Exists(this.Path + this.Name + ".json"))
					{
						throw new Exception("未找到版本 Json 文件");
					}
					this._ClassAlgo = ModBase.ReadFile(this.Path + this.Name + ".json");
					if (this._ClassAlgo.Length == 0)
					{
						if (ModBase.RunInUi())
						{
							ModBase.Log("[Minecraft] 版本 Json 文件为空或读取失败，由于代码在主线程运行，将不再进行重试", ModBase.LogLevel.Debug, "出现错误");
							throw new Exception("版本 Json 文件为空或读取失败");
						}
						ModBase.Log("[Minecraft] 版本 Json 文件为空或读取失败，将在 1s 后重试读取（" + this.Path + this.Name + ".json）", ModBase.LogLevel.Debug, "出现错误");
						Thread.Sleep(0x3E8);
						this._ClassAlgo = ModBase.ReadFile(this.Path + this.Name + ".json");
						if (this._ClassAlgo.Length == 0)
						{
							throw new Exception("版本 Json 文件为空或读取失败");
						}
					}
					if (this._ClassAlgo.Length < 0x64)
					{
						throw new Exception("版本 Json 文件有误，内容为：" + this._ClassAlgo);
					}
				}
				return this._ClassAlgo;
			}

			// Token: 0x060008F1 RID: 2289 RVA: 0x00006BD1 File Offset: 0x00004DD1
			public void RevertExpression(string value)
			{
				this._ClassAlgo = value;
			}

			// Token: 0x060008F2 RID: 2290 RVA: 0x00050E64 File Offset: 0x0004F064
			public JObject VerifyUtils()
			{
				if (this.serverAlgo == null)
				{
					string text = this.RestartExpression();
					try
					{
						this.serverAlgo = (JObject)ModBase.GetJson(text);
						if (this.serverAlgo.ContainsKey("patches") && !this.serverAlgo.ContainsKey("time"))
						{
							this.RateUtils(true);
							JObject jobject = null;
							List<JObject> list = new List<JObject>();
							try
							{
								foreach (JToken jtoken in ((IEnumerable<JToken>)this.serverAlgo["patches"]))
								{
									JObject item = (JObject)jtoken;
									list.Add(item);
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
							list = ModBase.Sort<JObject>(list, (ModMinecraft.McVersion._Closure$__.$IR24-1 == null) ? (ModMinecraft.McVersion._Closure$__.$IR24-1 = ((object a0, object a1) => ((ModMinecraft.McVersion._Closure$__.$I24-0 == null) ? (ModMinecraft.McVersion._Closure$__.$I24-0 = ((JObject Left, JObject Right) => ModBase.Val((Left["priority"] ?? "0").ToString()) < ModBase.Val((Right["priority"] ?? "0").ToString()))) : ModMinecraft.McVersion._Closure$__.$I24-0)((JObject)a0, (JObject)a1))) : ModMinecraft.McVersion._Closure$__.$IR24-1);
							try
							{
								foreach (JObject jobject2 in list)
								{
									string text2 = (string)jobject2["id"];
									if (text2 != null)
									{
										ModBase.Log("[Minecraft] 合并 HMCL 分支项：" + text2, ModBase.LogLevel.Normal, "出现错误");
										if (jobject != null)
										{
											jobject.Merge(jobject2);
										}
										else
										{
											jobject = jobject2;
										}
									}
									else
									{
										ModBase.Log("[Minecraft] 存在为空的 HMCL 分支项", ModBase.LogLevel.Normal, "出现错误");
									}
								}
							}
							finally
							{
								List<JObject>.Enumerator enumerator2;
								((IDisposable)enumerator2).Dispose();
							}
							this.serverAlgo = jobject;
							this.serverAlgo["id"] = this.Name;
							if (this.serverAlgo.ContainsKey("inheritsFrom"))
							{
								this.serverAlgo.Remove("inheritsFrom");
							}
						}
						object obj = null;
						try
						{
							obj = ((this.serverAlgo["inheritsFrom"] == null) ? "" : this.serverAlgo["inheritsFrom"].ToString());
							if (Operators.ConditionalCompareObjectEqual(obj, this.Name, true))
							{
								ModBase.Log("[Minecraft] 自引用的继承版本：" + this.Name, ModBase.LogLevel.Debug, "出现错误");
								obj = "";
							}
							else
							{
								while (Operators.ConditionalCompareObjectNotEqual(obj, "", true))
								{
									ModMinecraft.McVersion mcVersion = new ModMinecraft.McVersion(Conversions.ToString(obj));
									if (Operators.ConditionalCompareObjectEqual(mcVersion.PrintUtils(), obj, true))
									{
										throw new Exception(Conversions.ToString(Operators.ConcatenateObject("版本依赖项出现嵌套：", obj)));
									}
									obj = mcVersion.PrintUtils();
									mcVersion.VerifyUtils().Merge(this.serverAlgo);
									this.serverAlgo = mcVersion.VerifyUtils();
								}
							}
						}
						catch (Exception ex)
						{
							ModBase.Log(ex, "合并版本依赖项 Json 失败（" + (obj ?? "null").ToString() + "）", ModBase.LogLevel.Debug, "出现错误");
						}
					}
					catch (Exception innerException)
					{
						throw new Exception("版本 Json 不规范（" + (this.Name ?? "null") + "）", innerException);
					}
					try
					{
						if (text.Contains("minecraftforge") && File.Exists(this.ManageExpression() + "config\\jumploader.json"))
						{
							try
							{
								foreach (string filePath in Directory.EnumerateFiles(this.ManageExpression() + "mods"))
								{
									string text3 = ModBase.GetFileNameFromPath(filePath).ToLower();
									if (text3.EndsWith(".jar") && text3.Contains("jumploader"))
									{
										ModBase.Log("[Minecraft] 发现 JumpLoader 分支项：" + text3, ModBase.LogLevel.Normal, "出现错误");
										this.ConnectUtils(true);
										break;
									}
								}
							}
							finally
							{
								IEnumerator<string> enumerator3;
								if (enumerator3 != null)
								{
									enumerator3.Dispose();
								}
							}
						}
						if (this.WriteUtils())
						{
							this.serverAlgo.Remove("jumploader");
							this.serverAlgo.Add("jumploader", (JToken)ModBase.GetJson(ModBase.ReadFile(this.ManageExpression() + "config\\jumploader.json")));
						}
					}
					catch (Exception ex2)
					{
						ModBase.Log(ex2, "处理 JumpLoader 失败", ModBase.LogLevel.Debug, "出现错误");
					}
				}
				return this.serverAlgo;
			}

			// Token: 0x060008F3 RID: 2291 RVA: 0x00006BDA File Offset: 0x00004DDA
			public void RunUtils(JObject value)
			{
				this.serverAlgo = value;
			}

			// Token: 0x060008F4 RID: 2292 RVA: 0x00006BE3 File Offset: 0x00004DE3
			public bool CollectUtils()
			{
				return this.VerifyUtils()["minecraftArguments"] != null;
			}

			// Token: 0x060008F5 RID: 2293 RVA: 0x00006BF8 File Offset: 0x00004DF8
			[CompilerGenerated]
			public bool FindUtils()
			{
				return this._ConfigAlgo;
			}

			// Token: 0x060008F6 RID: 2294 RVA: 0x00006C00 File Offset: 0x00004E00
			[CompilerGenerated]
			public void RateUtils(bool AutoPropertyValue)
			{
				this._ConfigAlgo = AutoPropertyValue;
			}

			// Token: 0x060008F7 RID: 2295 RVA: 0x00006C09 File Offset: 0x00004E09
			[CompilerGenerated]
			public bool WriteUtils()
			{
				return this.m_ConnectionAlgo;
			}

			// Token: 0x060008F8 RID: 2296 RVA: 0x00006C11 File Offset: 0x00004E11
			[CompilerGenerated]
			public void ConnectUtils(bool AutoPropertyValue)
			{
				this.m_ConnectionAlgo = AutoPropertyValue;
			}

			// Token: 0x060008F9 RID: 2297 RVA: 0x000512F0 File Offset: 0x0004F4F0
			public string PrintUtils()
			{
				if (this._ListAlgo == null)
				{
					this._ListAlgo = (this.VerifyUtils()["inheritsFrom"] ?? "").ToString();
					if (this.RestartExpression().Contains("liteloader") && Operators.CompareString(this.Version.policyAlgo, this.Name, true) != 0 && !this.RestartExpression().Contains("logging") && Operators.CompareString((this.VerifyUtils()["jar"] ?? this.Version.policyAlgo).ToString(), this.Version.policyAlgo, true) == 0)
					{
						this._ListAlgo = this.Version.policyAlgo;
					}
					if (this.FindUtils())
					{
						this._ListAlgo = "";
					}
				}
				return this._ListAlgo;
			}

			// Token: 0x060008FA RID: 2298 RVA: 0x000513D4 File Offset: 0x0004F5D4
			public McVersion(string Path)
			{
				this._DicAlgo = null;
				this.m_SchemaAlgo = "该版本未被加载，请向作者反馈此问题";
				this.m_HelperAlgo = ModMinecraft.McVersionState.Error;
				this.m_QueueAlgo = false;
				this.producerAlgo = ModMinecraft.McVersionCardType.Auto;
				this._ExceptionAlgo = null;
				this.m_RulesAlgo = new DateTime(0x7B2, 1, 1, 0xF, 0, 0);
				this._ClassAlgo = null;
				this.serverAlgo = null;
				this.RateUtils(false);
				this.ConnectUtils(false);
				this._ListAlgo = null;
				this._ReponseAlgo = false;
				this.Path = (Path.Contains(":") ? "" : (ModMinecraft.m_ResolverIterator + "versions\\")) + Path + (Path.EndsWith("\\") ? "" : "\\");
			}

			// Token: 0x060008FB RID: 2299 RVA: 0x000514A0 File Offset: 0x0004F6A0
			public bool Check()
			{
				bool result;
				if (!Directory.Exists(this.Path))
				{
					this.m_HelperAlgo = ModMinecraft.McVersionState.Error;
					this.m_SchemaAlgo = "该文件夹不存在";
					result = false;
				}
				else
				{
					try
					{
						Directory.CreateDirectory(this.Path + "PCL\\");
						ModBase.CheckPermissionWithException(this.Path + "PCL\\");
					}
					catch (Exception ex)
					{
						this.m_HelperAlgo = ModMinecraft.McVersionState.Error;
						this.m_SchemaAlgo = "PCL2 没有对该文件夹的访问权限，请右键以管理员身份运行 PCL2";
						ModBase.Log(ex, "没有访问版本文件夹的权限", ModBase.LogLevel.Debug, "出现错误");
						return false;
					}
					try
					{
						this.VerifyUtils();
					}
					catch (Exception ex2)
					{
						ModBase.Log(ex2, "版本 Json 可用性检查失败（" + this.Name + "）", ModBase.LogLevel.Debug, "出现错误");
						this.RevertExpression("");
						this.RunUtils(null);
						this.m_SchemaAlgo = ex2.Message;
						this.m_HelperAlgo = ModMinecraft.McVersionState.Error;
						return false;
					}
					try
					{
						if (Operators.CompareString(this.PrintUtils(), "", true) != 0 && !File.Exists(string.Concat(new string[]
						{
							ModBase.GetPathFromFullPath(this.Path),
							this.PrintUtils(),
							"\\",
							this.PrintUtils(),
							".json"
						})))
						{
							this.m_HelperAlgo = ModMinecraft.McVersionState.Error;
							this.m_SchemaAlgo = "需要安装 " + this.PrintUtils() + " 作为前置版本";
							return false;
						}
					}
					catch (Exception ex3)
					{
						ModBase.Log(ex3, "依赖版本检查出错（" + this.Name + "）", ModBase.LogLevel.Debug, "出现错误");
						this.m_HelperAlgo = ModMinecraft.McVersionState.Error;
						this.m_SchemaAlgo = "未知错误：" + ModBase.GetString(ex3, true, false);
						return false;
					}
					this.m_HelperAlgo = ModMinecraft.McVersionState.Original;
					result = true;
				}
				return result;
			}

			// Token: 0x060008FC RID: 2300 RVA: 0x0005169C File Offset: 0x0004F89C
			public ModMinecraft.McVersion Load()
			{
				try
				{
					Directory.CreateDirectory(this.Path + "PCL");
					if (this.Check())
					{
						string policyAlgo = this.Version.policyAlgo;
						if (Operators.CompareString(policyAlgo, "Unknown", true) == 0)
						{
							this.m_HelperAlgo = ModMinecraft.McVersionState.Error;
						}
						else if (Operators.CompareString(policyAlgo, "Old", true) == 0)
						{
							this.m_HelperAlgo = ModMinecraft.McVersionState.Old;
						}
						else
						{
							string text = (this.VerifyUtils() ?? this.RestartExpression()).ToString();
							if (Operators.CompareString((this.VerifyUtils()["type"] ?? "").ToString(), "fool", true) != 0 && Operators.CompareString(ModMinecraft.GetMcFoolName(this.Name), "", true) == 0)
							{
								if (this.Version.policyAlgo.ToLower().Contains("w") || this.Name.ToLower().Contains("combat") || this.Version.policyAlgo.ToLower().Contains("rc") || this.Version.policyAlgo.ToLower().Contains("pre") || this.Version.policyAlgo.Contains("experimental") || Operators.CompareString((this.VerifyUtils()["type"] ?? "").ToString(), "snapshot", true) == 0 || Operators.CompareString((this.VerifyUtils()["type"] ?? "").ToString(), "pending", true) == 0)
								{
									this.m_HelperAlgo = ModMinecraft.McVersionState.Snapshot;
								}
							}
							else
							{
								this.m_HelperAlgo = ModMinecraft.McVersionState.Fool;
							}
							if (text.Contains("optifine"))
							{
								this.m_HelperAlgo = ModMinecraft.McVersionState.OptiFine;
								this.Version.m_PublisherAlgo = (ModBase.RegexSeek(text, "(?<=HD_U_)[^\":/]+", RegexOptions.None) ?? "未知版本");
								this.Version.m_ComposerAlgo = true;
							}
							if (text.Contains("liteloader"))
							{
								this.m_HelperAlgo = ModMinecraft.McVersionState.LiteLoader;
								this.Version.m_ValMapper = true;
							}
							if (!text.Contains("net.fabricmc:fabric-loader") && !text.Contains("org.quiltmc:quilt-loader"))
							{
								if (text.Contains("minecraftforge"))
								{
									this.m_HelperAlgo = ModMinecraft.McVersionState.Forge;
									this.Version.m_TokenAlgo = ModBase.RegexSeek(text, "(?<=forge:[0-9\\.]+(_pre[0-9]*)?\\-)[0-9\\.]+", RegexOptions.None);
									if (this.Version.m_TokenAlgo == null)
									{
										this.Version.m_TokenAlgo = ModBase.RegexSeek(text, "(?<=net\\.minecraftforge:minecraftforge:)[0-9\\.]+", RegexOptions.None);
									}
									if (this.Version.m_TokenAlgo == null)
									{
										this.Version.m_TokenAlgo = (ModBase.RegexSeek(text, "(?<=net\\.minecraftforge:fmlloader:[0-9\\.]+-)[0-9\\.]+", RegexOptions.None) ?? "未知版本");
									}
									this.Version.messageAlgo = true;
								}
							}
							else
							{
								this.m_HelperAlgo = ModMinecraft.McVersionState.Fabric;
								this.Version.factoryMapper = (ModBase.RegexSeek(text, "(?<=(net.fabricmc:fabric-loader:)|(org.quiltmc:quilt-loader:))[0-9\\.]+(\\+build.[0-9]+)?", RegexOptions.None) ?? "未知版本").Replace("+build", "");
								this.Version._ProcAlgo = true;
							}
							this.Version.identifierAlgo = true;
						}
					}
					this.m_ConsumerAlgo = ModBase.ReadIni(this.Path + "PCL\\Setup.ini", "Logo", "");
					if (Operators.CompareString(this.m_ConsumerAlgo, "", true) == 0 || Operators.CompareString(ModBase.ReadIni(this.Path + "PCL\\Setup.ini", "LogoCustom", "False"), "False", true) == 0)
					{
						switch (this.m_HelperAlgo)
						{
						case ModMinecraft.McVersionState.Original:
							this.m_ConsumerAlgo = "pack://application:,,,/images/Blocks/Grass.png";
							break;
						case ModMinecraft.McVersionState.Snapshot:
							this.m_ConsumerAlgo = "pack://application:,,,/images/Blocks/CommandBlock.png";
							break;
						case ModMinecraft.McVersionState.Fool:
							this.m_ConsumerAlgo = "pack://application:,,,/images/Blocks/GoldBlock.png";
							break;
						case ModMinecraft.McVersionState.OptiFine:
							this.m_ConsumerAlgo = "pack://application:,,,/images/Blocks/GrassPath.png";
							break;
						case ModMinecraft.McVersionState.Old:
							this.m_ConsumerAlgo = "pack://application:,,,/images/Blocks/CobbleStone.png";
							break;
						case ModMinecraft.McVersionState.Forge:
							this.m_ConsumerAlgo = "pack://application:,,,/images/Blocks/Anvil.png";
							break;
						case ModMinecraft.McVersionState.LiteLoader:
							this.m_ConsumerAlgo = "pack://application:,,,/images/Blocks/Egg.png";
							break;
						case ModMinecraft.McVersionState.Fabric:
							this.m_ConsumerAlgo = "pack://application:,,,/images/Blocks/Fabric.png";
							break;
						default:
							this.m_ConsumerAlgo = "pack://application:,,,/images/Blocks/RedstoneBlock.png";
							break;
						}
					}
					string text2 = ModBase.ReadIni(this.Path + "PCL\\Setup.ini", "CustomInfo", "");
					if (Operators.CompareString(text2, "", true) == 0)
					{
						switch (this.m_HelperAlgo)
						{
						case ModMinecraft.McVersionState.Error:
							break;
						case ModMinecraft.McVersionState.Original:
						case ModMinecraft.McVersionState.OptiFine:
						case ModMinecraft.McVersionState.Forge:
						case ModMinecraft.McVersionState.LiteLoader:
						case ModMinecraft.McVersionState.Fabric:
							this.m_SchemaAlgo = this.Version.ToString();
							break;
						case ModMinecraft.McVersionState.Snapshot:
							if (!this.Version.policyAlgo.ToLower().Contains("pre") && !this.Version.policyAlgo.ToLower().Contains("rc"))
							{
								if (!this.Version.policyAlgo.Contains("experimental") && Operators.CompareString(this.Version.policyAlgo, "pending", true) != 0)
								{
									this.m_SchemaAlgo = "快照 " + this.Version.policyAlgo;
								}
								else
								{
									this.m_SchemaAlgo = "实验性快照";
								}
							}
							else
							{
								this.m_SchemaAlgo = "预发布版 " + this.Version.policyAlgo;
							}
							break;
						case ModMinecraft.McVersionState.Fool:
							this.m_SchemaAlgo = ModMinecraft.GetMcFoolName(this.Name);
							break;
						case ModMinecraft.McVersionState.Old:
							this.m_SchemaAlgo = "远古版本";
							break;
						default:
							this.m_SchemaAlgo = "发生了未知错误，请向作者反馈此问题";
							break;
						}
						if (this.m_HelperAlgo != ModMinecraft.McVersionState.Error)
						{
							if (this.WriteUtils())
							{
								ref string ptr = ref this.m_SchemaAlgo;
								this.m_SchemaAlgo = ptr + ", JumpLoader";
							}
							if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("VersionServerLogin", this), 3, true))
							{
								ref string ptr = ref this.m_SchemaAlgo;
								this.m_SchemaAlgo = ptr + ", 统一通行证验证";
							}
							if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("VersionServerLogin", this), 4, true))
							{
								ref string ptr = ref this.m_SchemaAlgo;
								this.m_SchemaAlgo = ptr + ", Authlib 验证";
							}
						}
					}
					else
					{
						this.m_SchemaAlgo = text2;
					}
					this.m_QueueAlgo = Conversions.ToBoolean(ModBase.ReadIni(this.Path + "PCL\\Setup.ini", "IsStar", Conversions.ToString(false)));
					this.producerAlgo = (ModMinecraft.McVersionCardType)Conversions.ToInteger(ModBase.ReadIni(this.Path + "PCL\\Setup.ini", "DisplayType", Conversions.ToString(0)));
					ModBase.WriteIni(this.Path + "PCL\\Setup.ini", "State", Conversions.ToString((int)this.m_HelperAlgo));
					ModBase.WriteIni(this.Path + "PCL\\Setup.ini", "Info", this.m_SchemaAlgo);
					ModBase.WriteIni(this.Path + "PCL\\Setup.ini", "Logo", this.m_ConsumerAlgo);
					if (this.m_HelperAlgo != ModMinecraft.McVersionState.Error)
					{
						ModBase.WriteIni(this.Path + "PCL\\Setup.ini", "ReleaseTime", this.m_RulesAlgo.ToString("yyyy-MM-dd HH:mm:ss"));
						ModBase.WriteIni(this.Path + "PCL\\Setup.ini", "VersionFabric", this.Version.factoryMapper);
						ModBase.WriteIni(this.Path + "PCL\\Setup.ini", "VersionOptiFine", this.Version.m_PublisherAlgo);
						ModBase.WriteIni(this.Path + "PCL\\Setup.ini", "VersionLiteLoader", Conversions.ToString(this.Version.m_ValMapper));
						ModBase.WriteIni(this.Path + "PCL\\Setup.ini", "VersionForge", this.Version.m_TokenAlgo);
						ModBase.WriteIni(this.Path + "PCL\\Setup.ini", "VersionApiCode", Conversions.ToString(this.Version.SelectUtils()));
						ModBase.WriteIni(this.Path + "PCL\\Setup.ini", "VersionOriginal", this.Version.policyAlgo);
						ModBase.WriteIni(this.Path + "PCL\\Setup.ini", "VersionOriginalMain", Conversions.ToString(this.Version.clientAlgo));
						ModBase.WriteIni(this.Path + "PCL\\Setup.ini", "VersionOriginalSub", Conversions.ToString(this.Version._MapAlgo));
					}
				}
				catch (Exception ex)
				{
					this.m_SchemaAlgo = "未知错误：" + ModBase.GetString(ex, true, false);
					this.m_ConsumerAlgo = "pack://application:,,,/images/Blocks/RedstoneBlock.png";
					this.m_HelperAlgo = ModMinecraft.McVersionState.Error;
					ModBase.Log(ex, "加载版本失败（" + this.Name + "）", ModBase.LogLevel.Feedback, "出现错误");
				}
				finally
				{
					this._ReponseAlgo = true;
				}
				return this;
			}

			// Token: 0x060008FD RID: 2301 RVA: 0x00051F84 File Offset: 0x00050184
			public override bool Equals(object obj)
			{
				ModMinecraft.McVersion mcVersion = obj as ModMinecraft.McVersion;
				return mcVersion != null && Operators.CompareString(this.Path, mcVersion.Path, true) == 0;
			}

			// Token: 0x040004F1 RID: 1265
			[CompilerGenerated]
			private string _SpecificationAlgo;

			// Token: 0x040004F2 RID: 1266
			private string _DicAlgo;

			// Token: 0x040004F3 RID: 1267
			public string m_SchemaAlgo;

			// Token: 0x040004F4 RID: 1268
			public ModMinecraft.McVersionState m_HelperAlgo;

			// Token: 0x040004F5 RID: 1269
			public string m_ConsumerAlgo;

			// Token: 0x040004F6 RID: 1270
			public bool m_QueueAlgo;

			// Token: 0x040004F7 RID: 1271
			public ModMinecraft.McVersionCardType producerAlgo;

			// Token: 0x040004F8 RID: 1272
			private ModMinecraft.McVersionInfo _ExceptionAlgo;

			// Token: 0x040004F9 RID: 1273
			public DateTime m_RulesAlgo;

			// Token: 0x040004FA RID: 1274
			private string _ClassAlgo;

			// Token: 0x040004FB RID: 1275
			private JObject serverAlgo;

			// Token: 0x040004FC RID: 1276
			[CompilerGenerated]
			private bool _ConfigAlgo;

			// Token: 0x040004FD RID: 1277
			[CompilerGenerated]
			private bool m_ConnectionAlgo;

			// Token: 0x040004FE RID: 1278
			private string _ListAlgo;

			// Token: 0x040004FF RID: 1279
			public bool _ReponseAlgo;
		}

		// Token: 0x02000103 RID: 259
		public enum McVersionState
		{
			// Token: 0x04000504 RID: 1284
			Error,
			// Token: 0x04000505 RID: 1285
			Original,
			// Token: 0x04000506 RID: 1286
			Snapshot,
			// Token: 0x04000507 RID: 1287
			Fool,
			// Token: 0x04000508 RID: 1288
			OptiFine,
			// Token: 0x04000509 RID: 1289
			Old,
			// Token: 0x0400050A RID: 1290
			Forge,
			// Token: 0x0400050B RID: 1291
			LiteLoader,
			// Token: 0x0400050C RID: 1292
			Fabric
		}

		// Token: 0x02000104 RID: 260
		public class McVersionInfo
		{
			// Token: 0x06000902 RID: 2306 RVA: 0x0005200C File Offset: 0x0005020C
			public McVersionInfo()
			{
				this.identifierAlgo = false;
				this.clientAlgo = -1;
				this._MapAlgo = -1;
				this.m_ComposerAlgo = false;
				this.m_PublisherAlgo = "";
				this.messageAlgo = false;
				this.m_TokenAlgo = "";
				this._ProcAlgo = false;
				this.factoryMapper = "";
				this.m_ValMapper = false;
				this.m_ContainerMapper = -2;
			}

			// Token: 0x06000903 RID: 2307 RVA: 0x00006C5D File Offset: 0x00004E5D
			public bool LoginUtils()
			{
				return this._ProcAlgo || this.messageAlgo || this.m_ValMapper;
			}

			// Token: 0x06000904 RID: 2308 RVA: 0x0005207C File Offset: 0x0005027C
			public override string ToString()
			{
				string text = "";
				if (this.messageAlgo)
				{
					text = text + ", Forge" + ((Operators.CompareString(this.m_TokenAlgo, "未知版本", true) == 0) ? "" : (" " + this.m_TokenAlgo));
				}
				if (this._ProcAlgo)
				{
					text = text + ", Fabric" + ((Operators.CompareString(this.factoryMapper, "未知版本", true) == 0) ? "" : (" " + this.factoryMapper));
				}
				if (this.m_ComposerAlgo)
				{
					text = text + ", OptiFine" + ((Operators.CompareString(this.m_PublisherAlgo, "未知版本", true) == 0) ? "" : (" " + this.m_PublisherAlgo));
				}
				if (this.m_ValMapper)
				{
					text += ", LiteLoader";
				}
				if (Operators.CompareString(text, "", true) == 0)
				{
					text = "原版 " + this.policyAlgo;
				}
				else
				{
					text = this.policyAlgo + text + (ModBase.errorRule ? (" (" + Conversions.ToString(this.SelectUtils()) + "#)") : "");
				}
				return text;
			}

			// Token: 0x06000905 RID: 2309 RVA: 0x000521B4 File Offset: 0x000503B4
			public int SelectUtils()
			{
				checked
				{
					if (this.m_ContainerMapper == -2)
					{
						try
						{
							if (this._ProcAlgo)
							{
								if (Operators.CompareString(this.factoryMapper, "未知版本", true) == 0)
								{
									return 0;
								}
								string[] array = this.factoryMapper.Split(new char[]
								{
									'.'
								});
								if (array.Length < 3)
								{
									throw new Exception("无效的 Fabric 版本：" + this.m_TokenAlgo);
								}
								this.m_ContainerMapper = (int)Math.Round(unchecked(ModBase.Val(array[0]) * 10000.0 + ModBase.Val(array[1]) * 100.0 + ModBase.Val(array[2])));
							}
							else if (this.messageAlgo)
							{
								if (Operators.CompareString(this.m_TokenAlgo, "未知版本", true) == 0)
								{
									return 0;
								}
								string[] array2 = this.m_TokenAlgo.Split(new char[]
								{
									'.'
								});
								if (array2.Length == 4)
								{
									this.m_ContainerMapper = (int)Math.Round(unchecked(ModBase.Val(array2[0]) * 1000000.0 + ModBase.Val(array2[1]) * 10000.0 + ModBase.Val(array2[3])));
								}
								else
								{
									if (array2.Length != 3)
									{
										throw new Exception("无效的 Forge 版本：" + this.m_TokenAlgo);
									}
									this.m_ContainerMapper = (int)Math.Round(unchecked(ModBase.Val(array2[0]) * 1000000.0 + ModBase.Val(array2[1]) * 10000.0 + ModBase.Val(array2[2])));
								}
							}
							else if (this.m_ComposerAlgo)
							{
								if (Operators.CompareString(this.m_PublisherAlgo, "未知版本", true) == 0)
								{
									return 0;
								}
								this.m_ContainerMapper = (int)Math.Round(unchecked((double)(checked(((this._MapAlgo >= 0) ? this._MapAlgo : 0) * 0xF4240 + (Strings.Asc(Conversions.ToChar(Strings.Left(this.m_PublisherAlgo.ToUpper(), 1))) - 0x41 + 1) * 0x2710)) + ModBase.Val(ModBase.RegexSeek(Strings.Right(this.m_PublisherAlgo, checked(this.m_PublisherAlgo.Length - 1)), "[0-9]+", RegexOptions.None)) * 100.0));
								if (this.m_PublisherAlgo.ToLower().Contains("pre"))
								{
									ref int ptr = ref this.m_ContainerMapper;
									this.m_ContainerMapper = ptr + 0x32;
								}
								if (!this.m_PublisherAlgo.ToLower().Contains("pre") && !this.m_PublisherAlgo.ToLower().Contains("beta"))
								{
									ref int ptr = ref this.m_ContainerMapper;
									this.m_ContainerMapper = ptr + 0x63;
								}
								else if (ModBase.Val(Strings.Right(this.m_PublisherAlgo, 1)) == 0.0 && Operators.CompareString(Strings.Right(this.m_PublisherAlgo, 1), "0", true) != 0)
								{
									ref int ptr = ref this.m_ContainerMapper;
									this.m_ContainerMapper = ptr + 1;
								}
								else
								{
									ref int ptr = ref this.m_ContainerMapper;
									this.m_ContainerMapper = (int)Math.Round(unchecked((double)ptr + ModBase.Val(ModBase.RegexSeek(this.m_PublisherAlgo.ToLower(), "(?<=((pre)|(beta)))[0-9]+", RegexOptions.None))));
								}
							}
							else
							{
								this.m_ContainerMapper = -1;
							}
						}
						catch (Exception ex)
						{
							this.m_ContainerMapper = -1;
							ModBase.Log(ex, "获取 API 版本信息失败：" + this.ToString(), ModBase.LogLevel.Debug, "出现错误");
						}
					}
					return this.m_ContainerMapper;
				}
			}

			// Token: 0x06000906 RID: 2310 RVA: 0x00006C77 File Offset: 0x00004E77
			public void ExcludeUtils(int value)
			{
				this.m_ContainerMapper = value;
			}

			// Token: 0x0400050D RID: 1293
			public bool identifierAlgo;

			// Token: 0x0400050E RID: 1294
			public string policyAlgo;

			// Token: 0x0400050F RID: 1295
			public int clientAlgo;

			// Token: 0x04000510 RID: 1296
			public int _MapAlgo;

			// Token: 0x04000511 RID: 1297
			public bool m_ComposerAlgo;

			// Token: 0x04000512 RID: 1298
			public string m_PublisherAlgo;

			// Token: 0x04000513 RID: 1299
			public bool messageAlgo;

			// Token: 0x04000514 RID: 1300
			public string m_TokenAlgo;

			// Token: 0x04000515 RID: 1301
			public bool _ProcAlgo;

			// Token: 0x04000516 RID: 1302
			public string factoryMapper;

			// Token: 0x04000517 RID: 1303
			public bool m_ValMapper;

			// Token: 0x04000518 RID: 1304
			private int m_ContainerMapper;
		}

		// Token: 0x02000105 RID: 261
		public enum McVersionCardType
		{
			// Token: 0x0400051A RID: 1306
			Star = -1,
			// Token: 0x0400051B RID: 1307
			Auto,
			// Token: 0x0400051C RID: 1308
			Hidden,
			// Token: 0x0400051D RID: 1309
			API,
			// Token: 0x0400051E RID: 1310
			OriginalLike,
			// Token: 0x0400051F RID: 1311
			Rubbish,
			// Token: 0x04000520 RID: 1312
			Fool,
			// Token: 0x04000521 RID: 1313
			Error
		}

		// Token: 0x02000106 RID: 262
		public struct McSkinInfo
		{
			// Token: 0x04000522 RID: 1314
			public bool m_ModelMapper;

			// Token: 0x04000523 RID: 1315
			public string _IteratorMapper;

			// Token: 0x04000524 RID: 1316
			public bool _ExpressionMapper;
		}

		// Token: 0x02000107 RID: 263
		public class McLibToken
		{
			// Token: 0x06000907 RID: 2311 RVA: 0x00006C80 File Offset: 0x00004E80
			public McLibToken()
			{
				this._BaseMapper = 0L;
				this.m_DecoratorMapper = false;
				this.filterMapper = null;
				this._MapperMapper = false;
			}

			// Token: 0x06000908 RID: 2312 RVA: 0x00006CAC File Offset: 0x00004EAC
			public string ReadUtils()
			{
				return this.m_RuleMapper;
			}

			// Token: 0x06000909 RID: 2313 RVA: 0x00006CB4 File Offset: 0x00004EB4
			public void CheckUtils(string value)
			{
				this.m_RuleMapper = (string.IsNullOrWhiteSpace(value) ? null : value);
			}

			// Token: 0x1700015C RID: 348
			// (get) Token: 0x0600090A RID: 2314 RVA: 0x0005251C File Offset: 0x0005071C
			public string Name
			{
				get
				{
					string result;
					if (this.algoMapper == null)
					{
						result = null;
					}
					else
					{
						List<string> list = new List<string>(this.algoMapper.Split(new char[]
						{
							':'
						}));
						list.RemoveAt(checked(list.Count - 1));
						result = ModBase.Join(list, ":");
					}
					return result;
				}
			}

			// Token: 0x1700015D RID: 349
			// (get) Token: 0x0600090B RID: 2315 RVA: 0x00006CC8 File Offset: 0x00004EC8
			public string Version
			{
				get
				{
					string[] array = this.algoMapper.Split(new char[]
					{
						':'
					});
					return array[checked(array.Count<string>() - 1)];
				}
			}

			// Token: 0x0600090C RID: 2316 RVA: 0x00006CE9 File Offset: 0x00004EE9
			public override string ToString()
			{
				return (this.m_DecoratorMapper ? "[Native] " : "") + ModBase.GetString(this._BaseMapper) + " | " + this.m_UtilsMapper;
			}

			// Token: 0x04000525 RID: 1317
			public string m_UtilsMapper;

			// Token: 0x04000526 RID: 1318
			public long _BaseMapper;

			// Token: 0x04000527 RID: 1319
			public bool m_DecoratorMapper;

			// Token: 0x04000528 RID: 1320
			public string filterMapper;

			// Token: 0x04000529 RID: 1321
			private string m_RuleMapper;

			// Token: 0x0400052A RID: 1322
			public string algoMapper;

			// Token: 0x0400052B RID: 1323
			public bool _MapperMapper;
		}

		// Token: 0x02000108 RID: 264
		private struct McAssetsToken
		{
			// Token: 0x0600090D RID: 2317 RVA: 0x00006D1A File Offset: 0x00004F1A
			public override string ToString()
			{
				return (this.orderMapper ? "[Virtual] " : "") + ModBase.GetString(this._IssuerMapper) + " | " + this._ParamsMapper;
			}

			// Token: 0x0400052C RID: 1324
			public string _ParamsMapper;

			// Token: 0x0400052D RID: 1325
			public string _GlobalMapper;

			// Token: 0x0400052E RID: 1326
			public long _IssuerMapper;

			// Token: 0x0400052F RID: 1327
			public bool orderMapper;

			// Token: 0x04000530 RID: 1328
			public string m_ServiceMapper;
		}

		// Token: 0x02000109 RID: 265
		public class McMod
		{
			// Token: 0x0600090E RID: 2318 RVA: 0x0005256C File Offset: 0x0005076C
			public McMod(string Path)
			{
				this.m_FacadeMapper = null;
				this._CodeMapper = null;
				this._MappingMapper = null;
				this.bridgeMapper = null;
				this._SingletonMapper = new List<string>();
				this._ErrorMapper = null;
				this.m_ObjectMapper = null;
				this.m_CallbackMapper = new Dictionary<string, string>();
				this._WorkerMapper = false;
				this.m_VisitorMapper = null;
				this._IndexerMapper = false;
				this.methodMapper = false;
				this.m_DatabaseMapper = false;
				this.Path = (Path ?? "");
			}

			// Token: 0x0600090F RID: 2319 RVA: 0x00006D4B File Offset: 0x00004F4B
			public string ViewUtils()
			{
				return ModBase.GetFileNameFromPath(this.Path);
			}

			// Token: 0x1700015E RID: 350
			// (get) Token: 0x06000910 RID: 2320 RVA: 0x000525F4 File Offset: 0x000507F4
			public ModMinecraft.McMod.McModState State
			{
				get
				{
					this.Load(false);
					ModMinecraft.McMod.McModState result;
					if (!this.RemoveUtils())
					{
						result = ModMinecraft.McMod.McModState.Unavaliable;
					}
					else if (this.Path.EndsWith(".disabled"))
					{
						result = ModMinecraft.McMod.McModState.Disabled;
					}
					else
					{
						result = ModMinecraft.McMod.McModState.Fine;
					}
					return result;
				}
			}

			// Token: 0x1700015F RID: 351
			// (get) Token: 0x06000911 RID: 2321 RVA: 0x00052630 File Offset: 0x00050830
			// (set) Token: 0x06000912 RID: 2322 RVA: 0x00052680 File Offset: 0x00050880
			public string Name
			{
				get
				{
					if (this.m_FacadeMapper == null)
					{
						this.Load(false);
					}
					if (this.m_FacadeMapper == null)
					{
						this.m_FacadeMapper = this.bridgeMapper;
					}
					if (this.m_FacadeMapper == null)
					{
						this.m_FacadeMapper = ModBase.GetFileNameWithoutExtentionFromPath(this.Path);
					}
					return this.m_FacadeMapper;
				}
				set
				{
					if (this.m_FacadeMapper == null && value != null && Operators.CompareString(value.ToLower(), "name", true) != 0 && value.Count<char>() > 1 && Operators.CompareString(ModBase.Val(value).ToString(), value, true) != 0)
					{
						this.m_FacadeMapper = value;
					}
				}
			}

			// Token: 0x17000160 RID: 352
			// (get) Token: 0x06000913 RID: 2323 RVA: 0x00006D58 File Offset: 0x00004F58
			// (set) Token: 0x06000914 RID: 2324 RVA: 0x000526D4 File Offset: 0x000508D4
			public string Description
			{
				get
				{
					if (this._CodeMapper == null)
					{
						this.Load(false);
					}
					if (this._CodeMapper == null && this.QueryUtils() != null)
					{
						this._CodeMapper = this.QueryUtils().Message;
					}
					return this._CodeMapper;
				}
				set
				{
					if (this._CodeMapper == null && value != null && value.Count<char>() > 2)
					{
						this._CodeMapper = value.ToString().Trim(new char[]
						{
							'\n'
						});
						if (this._CodeMapper.ToLower().LastIndexOfAny(Conversions.ToCharArrayRankOne("qwertyuiopasdfghjklzxcvbnm0123456789")) == checked(this._CodeMapper.Count<char>() - 1))
						{
							ref string ptr = ref this._CodeMapper;
							this._CodeMapper = ptr + ".";
						}
					}
				}
			}

			// Token: 0x17000161 RID: 353
			// (get) Token: 0x06000915 RID: 2325 RVA: 0x00006D90 File Offset: 0x00004F90
			// (set) Token: 0x06000916 RID: 2326 RVA: 0x00052750 File Offset: 0x00050950
			public string Version
			{
				get
				{
					if (this._MappingMapper == null)
					{
						this.Load(false);
					}
					return this._MappingMapper;
				}
				set
				{
					if (this._MappingMapper == null || (!this._MappingMapper.Contains(".") && !this._MappingMapper.Contains("-")))
					{
						if (value != null && value.ToLower().Contains("version"))
						{
							value = "version";
						}
						this._MappingMapper = value;
					}
				}
			}

			// Token: 0x06000917 RID: 2327 RVA: 0x00006DA7 File Offset: 0x00004FA7
			public string InvokeUtils()
			{
				if (this.bridgeMapper == null)
				{
					this.Load(false);
				}
				return this.bridgeMapper;
			}

			// Token: 0x06000918 RID: 2328 RVA: 0x000527AC File Offset: 0x000509AC
			public void InterruptUtils(string value)
			{
				if (value != null)
				{
					value = ModBase.RegexSeek(value.ToLower(), "[0-9a-z_]+", RegexOptions.None);
					if (value != null && Operators.CompareString(value.ToLower(), "name", true) != 0 && value.Count<char>() > 1 && Operators.CompareString(ModBase.Val(value).ToString(), value, true) != 0)
					{
						if (!this._SingletonMapper.Contains(value))
						{
							this._SingletonMapper.Add(value);
						}
						if (this.bridgeMapper == null)
						{
							this.bridgeMapper = value;
						}
					}
				}
			}

			// Token: 0x06000919 RID: 2329 RVA: 0x00006DBE File Offset: 0x00004FBE
			public string FillUtils()
			{
				if (this._ErrorMapper == null)
				{
					this.Load(false);
				}
				return this._ErrorMapper;
			}

			// Token: 0x0600091A RID: 2330 RVA: 0x00006DD5 File Offset: 0x00004FD5
			public void InitUtils(string value)
			{
				if (this._ErrorMapper == null && value != null && value.StartsWith("http"))
				{
					this._ErrorMapper = value;
				}
			}

			// Token: 0x0600091B RID: 2331 RVA: 0x00006DF6 File Offset: 0x00004FF6
			public string PrepareUtils()
			{
				if (this.m_ObjectMapper == null)
				{
					this.Load(false);
				}
				return this.m_ObjectMapper;
			}

			// Token: 0x0600091C RID: 2332 RVA: 0x00006E0D File Offset: 0x0000500D
			public void UpdateUtils(string value)
			{
				if (this.m_ObjectMapper == null && !string.IsNullOrWhiteSpace(value))
				{
					this.m_ObjectMapper = value;
				}
			}

			// Token: 0x0600091D RID: 2333 RVA: 0x00006E26 File Offset: 0x00005026
			public Dictionary<string, string> DestroyUtils()
			{
				this.Load(false);
				return this.m_CallbackMapper;
			}

			// Token: 0x0600091E RID: 2334 RVA: 0x00052830 File Offset: 0x00050A30
			private void AddDependency(string ModID, string VersionRequirement = null)
			{
				if (ModID != null && ModID.Count<char>() >= 2)
				{
					ModID = ModID.ToLower();
					if (Operators.CompareString(ModID, "name", true) != 0 && Operators.CompareString(ModBase.Val(ModID).ToString(), ModID, true) != 0)
					{
						if (VersionRequirement != null && (VersionRequirement.Contains(".") || VersionRequirement.Contains("-")) && !VersionRequirement.Contains("$"))
						{
							if (!VersionRequirement.StartsWith("[") && !VersionRequirement.StartsWith("(") && !VersionRequirement.EndsWith("]") && !VersionRequirement.EndsWith(")"))
							{
								VersionRequirement = "[" + VersionRequirement + ",)";
							}
						}
						else
						{
							VersionRequirement = null;
						}
						if (this.m_CallbackMapper.ContainsKey(ModID))
						{
							if (this.m_CallbackMapper[ModID] == null)
							{
								this.m_CallbackMapper[ModID] = VersionRequirement;
								return;
							}
						}
						else
						{
							this.m_CallbackMapper.Add(ModID, VersionRequirement);
						}
					}
				}
			}

			// Token: 0x0600091F RID: 2335 RVA: 0x00006E35 File Offset: 0x00005035
			public bool RemoveUtils()
			{
				this.Load(false);
				return this.QueryUtils() == null;
			}

			// Token: 0x06000920 RID: 2336 RVA: 0x00006E47 File Offset: 0x00005047
			public Exception QueryUtils()
			{
				this.Load(false);
				return this.m_VisitorMapper;
			}

			// Token: 0x06000921 RID: 2337 RVA: 0x00052930 File Offset: 0x00050B30
			private void Init()
			{
				this.m_FacadeMapper = null;
				this._CodeMapper = null;
				this._MappingMapper = null;
				this.bridgeMapper = null;
				this._SingletonMapper = new List<string>();
				this.m_CallbackMapper = new Dictionary<string, string>();
				this._WorkerMapper = false;
				this.m_VisitorMapper = null;
				this._IndexerMapper = false;
				this.methodMapper = false;
				this.m_DatabaseMapper = false;
			}

			// Token: 0x06000922 RID: 2338 RVA: 0x00052994 File Offset: 0x00050B94
			public void Load(bool ForceReload = false)
			{
				if (!this._WorkerMapper || ForceReload)
				{
					this.Init();
					ZipArchive zipArchive;
					try
					{
						if (this.Path.Length < 2)
						{
							throw new FileNotFoundException("错误的 Mod 文件路径（" + (this.Path ?? "null") + "）");
						}
						if (!File.Exists(this.Path))
						{
							throw new FileNotFoundException("未找到 Mod 文件（" + this.Path + "）");
						}
						zipArchive = new ZipArchive(new FileStream(this.Path, FileMode.Open));
						if (zipArchive.Entries.Count == 0)
						{
							throw new FileFormatException("文件内容为空");
						}
					}
					catch (UnauthorizedAccessException ex)
					{
						ModBase.Log(ex, "Mod 文件由于无权限无法打开（" + this.Path + "）", ModBase.LogLevel.Developer, "出现错误");
						this.m_VisitorMapper = new UnauthorizedAccessException("没有读取此文件的权限，请尝试右键以管理员身份运行 PCL2", ex);
						zipArchive = null;
					}
					catch (Exception ex2)
					{
						ModBase.Log(ex2, "Mod 文件无法打开（" + this.Path + "）", ModBase.LogLevel.Developer, "出现错误");
						this.m_VisitorMapper = ex2;
						zipArchive = null;
					}
					if (zipArchive != null)
					{
						this.LoadWithoutClass(zipArchive);
					}
					if (zipArchive != null && !this._IndexerMapper)
					{
						this.LoadWithClass(zipArchive);
					}
					try
					{
						if (zipArchive != null)
						{
							zipArchive.Dispose();
						}
					}
					catch (Exception ex3)
					{
					}
					this._WorkerMapper = true;
				}
			}

			// Token: 0x06000923 RID: 2339 RVA: 0x00052B18 File Offset: 0x00050D18
			private void LoadWithoutClass(ZipArchive Jar)
			{
				checked
				{
					try
					{
						ZipArchiveEntry entry = Jar.GetEntry("mcmod.info");
						string text = null;
						if (entry != null)
						{
							text = ModBase.ReadFile(entry.Open(), null);
							if (text.Length < 0xF)
							{
								text = null;
							}
						}
						if (text != null)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(ModBase.GetJson(text));
							JObject jobject;
							if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue, null, "Type", new object[0], null, null, null), JTokenType.Array, true))
							{
								jobject = (JObject)NewLateBinding.LateIndexGet(objectValue, new object[]
								{
									0
								}, null);
							}
							else
							{
								jobject = (JObject)NewLateBinding.LateIndexGet(NewLateBinding.LateIndexGet(objectValue, new object[]
								{
									"modList"
								}, null), new object[]
								{
									0
								}, null);
							}
							this.Name = (string)jobject["name"];
							this.Description = (string)jobject["description"];
							this.Version = (string)jobject["version"];
							this.InitUtils((string)jobject["url"]);
							this.InterruptUtils((string)jobject["modid"]);
							JArray jarray = (JArray)jobject["authorList"];
							if (jarray != null)
							{
								List<string> list = new List<string>();
								try
								{
									foreach (JToken jtoken in jarray)
									{
										list.Add(jtoken.ToString());
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
								if (list.Count > 0)
								{
									this.UpdateUtils(ModBase.Join(list, ", "));
								}
							}
							JArray jarray2 = (JArray)jobject["requiredMods"];
							if (jarray2 != null)
							{
								try
								{
									foreach (JToken value in jarray2)
									{
										string text2 = (string)value;
										if (!string.IsNullOrEmpty(text2))
										{
											text2 = text2.Substring(text2.IndexOf(":") + 1);
											if (text2.Contains("@"))
											{
												this.AddDependency(text2.Split(new char[]
												{
													'@'
												})[0], text2.Split(new char[]
												{
													'@'
												})[1]);
											}
											else
											{
												this.AddDependency(text2, null);
											}
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
							}
							jarray2 = (JArray)jobject["dependancies"];
							if (jarray2 != null)
							{
								try
								{
									foreach (JToken value2 in jarray2)
									{
										string text3 = (string)value2;
										if (!string.IsNullOrEmpty(text3))
										{
											text3 = text3.Substring(text3.IndexOf(":") + 1);
											if (text3.Contains("@"))
											{
												this.AddDependency(text3.Split(new char[]
												{
													'@'
												})[0], text3.Split(new char[]
												{
													'@'
												})[1]);
											}
											else
											{
												this.AddDependency(text3, null);
											}
										}
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
							}
						}
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "读取 mcmod.info 时出现未知错误（" + this.Path + "）", ModBase.LogLevel.Developer, "出现错误");
					}
					try
					{
						ZipArchiveEntry entry2 = Jar.GetEntry("META-INF/mods.toml");
						string text4 = null;
						if (entry2 != null)
						{
							text4 = ModBase.ReadFile(entry2.Open(), null);
							if (text4.Length < 0xF)
							{
								text4 = null;
							}
						}
						if (text4 != null)
						{
							List<string> list2 = new List<string>();
							foreach (string text5 in text4.Replace("\r\n", "\n").Replace("\r", "\n").Split(new char[]
							{
								'\n'
							}))
							{
								if (!text5.StartsWith("#"))
								{
									if (text5.Contains("#"))
									{
										text5 = text5.Substring(0, text5.IndexOf("#"));
									}
									text5 = text5.Trim(new char[]
									{
										' ',
										'\t',
										'\u3000'
									});
									if (text5.Count<char>() > 0)
									{
										list2.Add(text5);
									}
								}
							}
							List<KeyValuePair<string, Dictionary<string, object>>> list3 = new List<KeyValuePair<string, Dictionary<string, object>>>
							{
								new KeyValuePair<string, Dictionary<string, object>>("", new Dictionary<string, object>())
							};
							int num = list2.Count - 1;
							for (int j = 0; j <= num; j++)
							{
								string text6 = list2[j];
								if (text6.StartsWith("[[") && text6.EndsWith("]]"))
								{
									string key = text6.Replace("[", "").Replace("]", "");
									list3.Add(new KeyValuePair<string, Dictionary<string, object>>(key, new Dictionary<string, object>()));
								}
								else
								{
									if (!text6.Contains("="))
									{
										goto IL_952;
									}
									string key2 = text6.Substring(0, text6.IndexOf("=")).TrimEnd(new char[]
									{
										' ',
										'\t',
										'\u3000'
									});
									string text7 = text6.Substring(text6.IndexOf("=") + 1).TrimStart(new char[]
									{
										' ',
										'\t',
										'\u3000'
									});
									object obj;
									if (text7.StartsWith("\"") && text7.EndsWith("\""))
									{
										obj = text7.Trim(new char[]
										{
											'"'
										});
									}
									else
									{
										if (text7.StartsWith("'''"))
										{
											List<string> list4 = new List<string>
											{
												text7.TrimStart(new char[]
												{
													'\''
												})
											};
											while (j < list2.Count - 1)
											{
												j++;
												string text8 = list2[j];
												if (text8.EndsWith("'''"))
												{
													list4.Add(text8.TrimEnd(new char[]
													{
														'\''
													}));
													IL_5C5:
													obj = ModBase.Join(list4, "\n").Trim(new char[]
													{
														'\n'
													}).Replace("\n", "\r\n");
													goto IL_668;
												}
												list4.Add(text8);
											}
											goto IL_5C5;
										}
										if (Operators.CompareString(text7.ToLower(), "true", true) != 0 && Operators.CompareString(text7.ToLower(), "false", true) != 0)
										{
											if (Operators.CompareString(ModBase.Val(text7).ToString(), text7, true) == 0)
											{
												obj = ModBase.Val(text7);
											}
											else
											{
												obj = text7;
											}
										}
										else
										{
											obj = (Operators.CompareString(text7.ToLower(), "true", true) == 0);
										}
									}
									IL_668:
									Dictionary<string, object> value3 = list3.Last<KeyValuePair<string, Dictionary<string, object>>>().Value;
									ModBase.DictionaryAdd<string, object>(ref value3, key2, RuntimeHelpers.GetObjectValue(obj));
								}
							}
							Dictionary<string, object> dictionary = null;
							try
							{
								foreach (KeyValuePair<string, Dictionary<string, object>> keyValuePair in list3)
								{
									if (Operators.CompareString(keyValuePair.Key, "mods", true) == 0)
									{
										dictionary = keyValuePair.Value;
										break;
									}
								}
							}
							finally
							{
								List<KeyValuePair<string, Dictionary<string, object>>>.Enumerator enumerator4;
								((IDisposable)enumerator4).Dispose();
							}
							if (dictionary != null && dictionary.ContainsKey("modId"))
							{
								this.InterruptUtils(Conversions.ToString(dictionary["modId"]));
								if (this.bridgeMapper != null)
								{
									if (dictionary.ContainsKey("displayName"))
									{
										this.Name = Conversions.ToString(dictionary["displayName"]);
									}
									if (dictionary.ContainsKey("description"))
									{
										this.Description = Conversions.ToString(dictionary["description"]);
									}
									if (dictionary.ContainsKey("version"))
									{
										this.Version = Conversions.ToString(dictionary["version"]);
									}
									if (list3[0].Value.ContainsKey("displayURL"))
									{
										this.InitUtils(Conversions.ToString(list3[0].Value["displayURL"]));
									}
									if (list3[0].Value.ContainsKey("authors"))
									{
										this.UpdateUtils(Conversions.ToString(list3[0].Value["authors"]));
									}
									try
									{
										foreach (KeyValuePair<string, Dictionary<string, object>> keyValuePair2 in list3)
										{
											if (keyValuePair2.Key.StartsWith("dependencies"))
											{
												Dictionary<string, object> value4 = keyValuePair2.Value;
												if (Conversions.ToBoolean(value4.ContainsKey("modId") && value4.ContainsKey("mandatory") && Conversions.ToBoolean(value4["mandatory"]) && (value4.ContainsKey("side") || Operators.CompareString(value4["side"].ToString().ToLower(), "server", true) != 0)))
												{
													this.AddDependency(Conversions.ToString(value4["modId"]), Conversions.ToString(value4.ContainsKey("versionRange") ? value4["versionRange"] : null));
												}
											}
										}
									}
									finally
									{
										List<KeyValuePair<string, Dictionary<string, object>>>.Enumerator enumerator5;
										((IDisposable)enumerator5).Dispose();
									}
									goto IL_F6E;
								}
							}
						}
					}
					catch (Exception ex2)
					{
						ModBase.Log(ex2, "读取 mods.toml 时出现未知错误（" + this.Path + "）", ModBase.LogLevel.Developer, "出现错误");
					}
					IL_952:
					try
					{
						ZipArchiveEntry entry3 = Jar.GetEntry("fabric.mod.json");
						string text9 = null;
						if (entry3 != null)
						{
							text9 = ModBase.ReadFile(entry3.Open(), Encoding.UTF8);
							if (!text9.Contains("schemaVersion"))
							{
								text9 = null;
							}
						}
						if (text9 != null)
						{
							JObject jobject2 = (JObject)ModBase.GetJson(text9);
							if (jobject2.ContainsKey("name"))
							{
								this.Name = (string)jobject2["name"];
							}
							if (jobject2.ContainsKey("version"))
							{
								this.Version = (string)jobject2["version"];
							}
							if (jobject2.ContainsKey("description"))
							{
								this.Description = (string)jobject2["description"];
							}
							if (jobject2.ContainsKey("id"))
							{
								this.InterruptUtils((string)jobject2["id"]);
							}
							if (jobject2.ContainsKey("contact"))
							{
								this.InitUtils((string)(jobject2["contact"]["homepage"] ?? ""));
							}
							JArray jarray3 = (JArray)jobject2["authors"];
							if (jarray3 != null)
							{
								List<string> list5 = new List<string>();
								try
								{
									foreach (JToken jtoken2 in jarray3)
									{
										list5.Add(jtoken2.ToString());
									}
								}
								finally
								{
									IEnumerator<JToken> enumerator6;
									if (enumerator6 != null)
									{
										enumerator6.Dispose();
									}
								}
								if (list5.Count > 0)
								{
									this.UpdateUtils(ModBase.Join(list5, ", "));
								}
							}
							goto IL_F6E;
						}
					}
					catch (Exception ex3)
					{
						ModBase.Log(ex3, "读取 fabric.mod.json 时出现未知错误（" + this.Path + "）", ModBase.LogLevel.Developer, "出现错误");
					}
					try
					{
						ZipArchiveEntry entry4 = Jar.GetEntry("META-INF/fml_cache_annotation.json");
						string text10 = null;
						if (entry4 != null)
						{
							text10 = ModBase.ReadFile(entry4.Open(), Encoding.UTF8);
							if (!text10.Contains("Lnet/minecraftforge/fml/common/Mod;"))
							{
								text10 = null;
							}
						}
						if (text10 != null)
						{
							JObject jobject3 = (JObject)ModBase.GetJson(text10);
							JObject jobject4 = null;
							try
							{
								foreach (KeyValuePair<string, JToken> keyValuePair3 in jobject3)
								{
									JArray jarray4 = (JArray)keyValuePair3.Value["annotations"];
									if (jarray4 != null)
									{
										try
										{
											foreach (JToken jtoken3 in jarray4)
											{
												if (Operators.CompareString((string)(jtoken3["name"] ?? ""), "Lnet/minecraftforge/fml/common/Mod;", true) == 0)
												{
													jobject4 = (JObject)jtoken3["values"];
													goto IL_C2D;
												}
											}
										}
										finally
										{
											IEnumerator<JToken> enumerator8;
											if (enumerator8 != null)
											{
												enumerator8.Dispose();
											}
										}
									}
								}
							}
							finally
							{
								IEnumerator<KeyValuePair<string, JToken>> enumerator7;
								if (enumerator7 != null)
								{
									enumerator7.Dispose();
								}
							}
							goto IL_F6E;
							IL_C2D:
							if (jobject4.ContainsKey("useMetadata") && Operators.CompareString((jobject4["useMetadata"]["value"] ?? "").ToString().ToLower(), "true", true) == 0)
							{
								string text11 = (string)jobject4["modid"]["value"];
								if (text11 != null)
								{
									text11 = ModBase.RegexSeek(text11.ToLower(), "[0-9a-z_]+", RegexOptions.None);
									if (text11 != null && Operators.CompareString(text11.ToLower(), "name", true) != 0 && text11.Count<char>() > 1 && Operators.CompareString(ModBase.Val(text11).ToString(), text11, true) != 0 && !this._SingletonMapper.Contains(text11))
									{
										this._SingletonMapper.Add(text11);
									}
								}
							}
							else
							{
								if (jobject4.ContainsKey("name"))
								{
									this.Name = (string)jobject4["name"]["value"];
								}
								if (jobject4.ContainsKey("version"))
								{
									this.Version = (string)jobject4["version"]["value"];
								}
								if (jobject4.ContainsKey("modid"))
								{
									this.InterruptUtils((string)jobject4["modid"]["value"]);
								}
								if (!jobject4.ContainsKey("serverSideOnly") || !jobject4["serverSideOnly"]["value"].ToObject<bool>())
								{
									JToken value5;
									if (jobject4["acceptedMinecraftVersions"] == null)
									{
										if ((value5 = "") != null)
										{
											goto IL_E0F;
										}
									}
									else if ((value5 = jobject4["acceptedMinecraftVersions"]["value"]) != null)
									{
										goto IL_E0F;
									}
									value5 = "";
									IL_E0F:
									string text12 = (string)value5;
									if (Operators.CompareString(text12, "", true) != 0)
									{
										this.AddDependency("minecraft", text12);
									}
									JToken value6;
									if (jobject4["dependencies"] == null)
									{
										if ((value6 = "") != null)
										{
											goto IL_E73;
										}
									}
									else if ((value6 = jobject4["dependencies"]["value"]) != null)
									{
										goto IL_E73;
									}
									value6 = "";
									IL_E73:
									string text13 = (string)value6;
									if (Operators.CompareString(text13, "", true) != 0)
									{
										foreach (string text14 in text13.Split(new char[]
										{
											';'
										}))
										{
											if (Operators.CompareString(text14, "", true) != 0 && text14.StartsWith("required-"))
											{
												text14 = text14.Substring(text14.IndexOf(":") + 1);
												if (text14.Contains("@"))
												{
													this.AddDependency(text14.Split(new char[]
													{
														'@'
													})[0], text14.Split(new char[]
													{
														'@'
													})[1]);
												}
												else
												{
													this.AddDependency(text14, null);
												}
											}
										}
									}
								}
							}
						}
					}
					catch (Exception ex4)
					{
						ModBase.Log(ex4, "读取 fml_cache_annotation.json 时出现未知错误（" + this.Path + "）", ModBase.LogLevel.Developer, "出现错误");
					}
					IL_F6E:
					if (Operators.CompareString(this._MappingMapper, "version", true) == 0)
					{
						try
						{
							ZipArchiveEntry entry5 = Jar.GetEntry("META-INF/MANIFEST.MF");
							if (entry5 != null)
							{
								string text15 = ModBase.ReadFile(entry5.Open(), null).Replace(" :", ":").Replace(": ", ":");
								if (text15.Contains("Implementation-Version:"))
								{
									text15 = text15.Substring(text15.IndexOf("Implementation-Version:") + "Implementation-Version:".Count<char>());
									text15 = text15.Substring(0, text15.IndexOfAny("\r\n".ToCharArray())).Trim();
									this.Version = text15;
								}
							}
						}
						catch (Exception ex5)
						{
							ModBase.Log("获取 META-INF 中的版本信息失败（" + this.Path + "）", ModBase.LogLevel.Developer, "出现错误");
							this.Version = null;
						}
					}
					if (this._MappingMapper != null && !this._MappingMapper.Contains(".") && !this._MappingMapper.Contains("-"))
					{
						this.Version = null;
					}
					this._IndexerMapper = (this.bridgeMapper != null && this._MappingMapper != null);
				}
			}

			// Token: 0x06000924 RID: 2340 RVA: 0x00053D00 File Offset: 0x00051F00
			private void LoadWithClass(ZipArchive Jar)
			{
				checked
				{
					try
					{
						string text = null;
						string text2 = null;
						try
						{
							foreach (ZipArchiveEntry zipArchiveEntry in Jar.Entries)
							{
								if (zipArchiveEntry.Name.EndsWith(".class"))
								{
									string text3 = ModBase.ReadFile(zipArchiveEntry.Open(), null).ToLower();
									if (text3.Contains("#lnet/minecraftforge/fml/common/mod;"))
									{
										text = text3;
										break;
									}
									if (text3.Contains("modid"))
									{
										text2 = text3;
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
						if (text == null)
						{
							text = text2;
						}
						if (text == null)
						{
							throw new FileNotFoundException("未找到 Mod 入口点");
						}
						text = text.Replace("ljava/lang/string;", "");
						if (text.Count<char>() > 0xBB8)
						{
							text = text.Substring(0, 0xBB8);
						}
						int num;
						if (this.bridgeMapper == null)
						{
							num = text.IndexOf("modid") + "modid".Length + 1;
							int num2 = 0;
							while (Convert.ToInt32(text[num]) < 0x20)
							{
								num++;
								num2++;
								if (num2 > 0xA)
								{
									throw new Exception("ModID 头匹配失败");
								}
							}
							int num3 = num + 1;
							num2 = 0;
							while (Convert.ToInt32(text[num3]) >= 0x20)
							{
								num3++;
								num2++;
								if (num2 > 0x32)
								{
									throw new Exception("ModID 尾匹配失败");
								}
							}
							this.InterruptUtils(text.Substring(num, num3 - num));
						}
						if (this._MappingMapper == null && text.Contains("version"))
						{
							num = text.IndexOf("version") + "version".Length + 1;
							int num2 = 0;
							while (Convert.ToInt32(text[num]) < 0x20)
							{
								num++;
								num2++;
								if (num2 > 0xA)
								{
									goto IL_223;
								}
							}
							int num3 = num + 1;
							num2 = 0;
							for (;;)
							{
								if (text[num3] != '.' && text[num3] != '-' && (text[num3] < '0' || text[num3] > '9'))
								{
									if (text[num3] < 'a')
									{
										break;
									}
									if (text[num3] > 'z')
									{
										break;
									}
								}
								num3++;
								num2++;
								if (num2 > 0x32)
								{
									goto IL_223;
								}
							}
							this._MappingMapper = text.Substring(num, num3 - num);
						}
						IL_223:
						num = text.IndexOf("dependencies");
						if (num > 0)
						{
							if (text.Count<char>() >= num + 0x12C)
							{
								text = text.Substring(num, 0x12B);
							}
							List<string> list = ModBase.RegexSearch(text, "(?<=required-((before|after|before-client|after-client)?):)[0-9a-z]+(@[\\(\\[]{1}[0-9.,]+[\\)\\]]{1})?", RegexOptions.None);
							try
							{
								foreach (string text4 in list)
								{
									if (!string.IsNullOrEmpty(text4))
									{
										if (text4.Contains("@"))
										{
											this.AddDependency(text4.Split(new char[]
											{
												'@'
											})[0], text4.Split(new char[]
											{
												'@'
											})[1]);
										}
										else
										{
											this.AddDependency(text4, null);
										}
									}
								}
							}
							finally
							{
								List<string>.Enumerator enumerator2;
								((IDisposable)enumerator2).Dispose();
							}
						}
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "Mod Class 信息不可用（" + (this.Path ?? "null") + "）", ModBase.LogLevel.Normal, "出现错误");
					}
					this.m_DatabaseMapper = (this.bridgeMapper != null && this._MappingMapper != null);
				}
			}

			// Token: 0x06000925 RID: 2341 RVA: 0x0005408C File Offset: 0x0005228C
			public bool IsPresetMod()
			{
				return this.DestroyUtils().Count == 0 && this.Name != null && (this.Name.ToLower().Contains("core") || this.Name.ToLower().Contains("lib"));
			}

			// Token: 0x06000926 RID: 2342 RVA: 0x000540E0 File Offset: 0x000522E0
			public static object IsModFile(string Path)
			{
				object result;
				if (Path != null && Path.Contains("."))
				{
					Path = Path.ToLower();
					if (!Path.EndsWith(".jar") && !Path.EndsWith(".zip") && !Path.EndsWith(".litemod") && !Path.EndsWith(".jar.disabled") && !Path.EndsWith(".zip.disabled") && !Path.EndsWith(".litemod.disabled"))
					{
						result = false;
					}
					else
					{
						result = true;
					}
				}
				else
				{
					result = false;
				}
				return result;
			}

			// Token: 0x04000531 RID: 1329
			public readonly string Path;

			// Token: 0x04000532 RID: 1330
			private string m_FacadeMapper;

			// Token: 0x04000533 RID: 1331
			private string _CodeMapper;

			// Token: 0x04000534 RID: 1332
			private string _MappingMapper;

			// Token: 0x04000535 RID: 1333
			private string bridgeMapper;

			// Token: 0x04000536 RID: 1334
			public List<string> _SingletonMapper;

			// Token: 0x04000537 RID: 1335
			private string _ErrorMapper;

			// Token: 0x04000538 RID: 1336
			private string m_ObjectMapper;

			// Token: 0x04000539 RID: 1337
			private Dictionary<string, string> m_CallbackMapper;

			// Token: 0x0400053A RID: 1338
			private bool _WorkerMapper;

			// Token: 0x0400053B RID: 1339
			private Exception m_VisitorMapper;

			// Token: 0x0400053C RID: 1340
			private bool _IndexerMapper;

			// Token: 0x0400053D RID: 1341
			private bool methodMapper;

			// Token: 0x0400053E RID: 1342
			private bool m_DatabaseMapper;

			// Token: 0x0200010A RID: 266
			public enum McModState
			{
				// Token: 0x04000540 RID: 1344
				Fine,
				// Token: 0x04000541 RID: 1345
				Disabled,
				// Token: 0x04000542 RID: 1346
				Unavaliable
			}
		}

		// Token: 0x0200010B RID: 267
		public class VersionSorter : IComparer<string>
		{
			// Token: 0x06000927 RID: 2343 RVA: 0x00006E56 File Offset: 0x00005056
			public int Compare(string x, string y)
			{
				return checked(ModMinecraft.VersionSortInteger(x, y) * (this.attrMapper ? -1 : 1));
			}

			// Token: 0x06000928 RID: 2344 RVA: 0x00006E6C File Offset: 0x0000506C
			public VersionSorter(bool IsDecreased = true)
			{
				this.attrMapper = true;
				this.attrMapper = IsDecreased;
			}

			// Token: 0x04000543 RID: 1347
			public bool attrMapper;
		}
	}
}
