using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace PCL
{
	// Token: 0x02000056 RID: 86
	[StandardModule]
	public sealed class ModCrash
	{
		// Token: 0x06000275 RID: 629 RVA: 0x00003963 File Offset: 0x00001B63
		// Note: this type is marked as 'beforefieldinit'.
		static ModCrash()
		{
			ModCrash._ConfigurationVal = false;
			ModCrash.m_InterpreterVal = RuntimeHelpers.GetObjectValue(new object());
		}

		// Token: 0x0400010B RID: 267
		private static bool _ConfigurationVal;

		// Token: 0x0400010C RID: 268
		private static object m_InterpreterVal;

		// Token: 0x02000057 RID: 87
		public class CrashAnalyzer
		{
			// Token: 0x06000276 RID: 630 RVA: 0x00016BF0 File Offset: 0x00014DF0
			public CrashAnalyzer(int UUID)
			{
				this._ParserRule = new List<KeyValuePair<string, string[]>>();
				this._ProxyRule = null;
				this.setterRule = null;
				this.merchantRule = null;
				this.printerRule = new Dictionary<ModCrash.CrashAnalyzer.CrashReason, List<string>>();
				this.productRule = new List<string>();
				object interpreterVal = ModCrash.m_InterpreterVal;
				ObjectFlowControl.CheckForSyncLockOnValueType(interpreterVal);
				lock (interpreterVal)
				{
					if (!ModCrash._ConfigurationVal)
					{
						try
						{
							ModBase.DeleteDirectory(ModBase.m_GlobalRule + "CrashAnalyzer", false);
						}
						catch (Exception ex)
						{
							ModBase.Log(ex, "清理崩溃分析缓存失败", ModBase.LogLevel.Debug, "出现错误");
						}
						ModCrash._ConfigurationVal = true;
					}
				}
				this.poolRule = string.Concat(new string[]
				{
					ModBase.m_GlobalRule,
					"CrashAnalyzer\\",
					Conversions.ToString(UUID),
					Conversions.ToString(ModBase.RandomInteger(0, 0x5F5E0FF)),
					"\\"
				});
				ModBase.DeleteDirectory(this.poolRule, false);
				Directory.CreateDirectory(this.poolRule + "Temp\\");
				Directory.CreateDirectory(this.poolRule + "Report\\");
				ModBase.Log("[Crash] 崩溃分析暂存文件夹：" + this.poolRule, ModBase.LogLevel.Normal, "出现错误");
			}

			// Token: 0x06000277 RID: 631 RVA: 0x00016D54 File Offset: 0x00014F54
			public void Collect(string VersionPathIndie, IList<string> LatestLog = null)
			{
				ModBase.Log("[Crash] 步骤 1：收集日志文件", ModBase.LogLevel.Normal, "出现错误");
				List<string> list = new List<string>();
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(VersionPathIndie + "crash-reports\\");
					if (directoryInfo.Exists)
					{
						try
						{
							foreach (FileInfo fileInfo in directoryInfo.EnumerateFiles())
							{
								list.Add(fileInfo.FullName);
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
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "收集 Minecraft 崩溃日志文件夹下的日志失败", ModBase.LogLevel.Debug, "出现错误");
				}
				try
				{
					try
					{
						foreach (FileInfo fileInfo2 in new DirectoryInfo(VersionPathIndie).Parent.Parent.EnumerateFiles())
						{
							if (Operators.CompareString(fileInfo2.Extension ?? "", ".log", true) == 0)
							{
								list.Add(fileInfo2.FullName);
							}
						}
					}
					finally
					{
						IEnumerator<FileInfo> enumerator2;
						if (enumerator2 != null)
						{
							enumerator2.Dispose();
						}
					}
				}
				catch (Exception ex2)
				{
					ModBase.Log(ex2, "收集 Minecraft 主文件夹下的日志失败", ModBase.LogLevel.Debug, "出现错误");
				}
				try
				{
					try
					{
						foreach (FileInfo fileInfo3 in new DirectoryInfo(VersionPathIndie).EnumerateFiles())
						{
							if (Operators.CompareString(fileInfo3.Extension ?? "", ".log", true) == 0)
							{
								list.Add(fileInfo3.FullName);
							}
						}
					}
					finally
					{
						IEnumerator<FileInfo> enumerator3;
						if (enumerator3 != null)
						{
							enumerator3.Dispose();
						}
					}
				}
				catch (Exception ex3)
				{
					ModBase.Log(ex3, "收集 Minecraft 隔离文件夹下的日志失败", ModBase.LogLevel.Debug, "出现错误");
				}
				list.Add(VersionPathIndie + "logs\\latest.log");
				list.Add(VersionPathIndie + "logs\\debug.log");
				list = ModBase.ArrayNoDouble<string>(list, null);
				List<string> list2 = new List<string>();
				try
				{
					foreach (string text in list)
					{
						try
						{
							FileInfo fileInfo4 = new FileInfo(text);
							if (fileInfo4.Exists)
							{
								double num = Math.Abs((fileInfo4.LastWriteTime - DateTime.Now).TotalMinutes);
								if (num < 5.0 && fileInfo4.Length > 0L)
								{
									list2.Add(text);
									ModBase.Log(string.Concat(new string[]
									{
										"[Crash] 可能可用的日志文件：",
										text,
										"（",
										Conversions.ToString(Math.Round(num, 1)),
										" 分钟）"
									}), ModBase.LogLevel.Normal, "出现错误");
								}
							}
						}
						catch (Exception ex4)
						{
							ModBase.Log(ex4, "确认崩溃日志时间失败（" + text + "）", ModBase.LogLevel.Debug, "出现错误");
						}
					}
				}
				finally
				{
					List<string>.Enumerator enumerator4;
					((IDisposable)enumerator4).Dispose();
				}
				if (list2.Count == 0)
				{
					ModBase.Log("[Crash] 未发现可能可用的日志文件", ModBase.LogLevel.Normal, "出现错误");
				}
				try
				{
					foreach (string text2 in list2)
					{
						try
						{
							if (text2.Contains("crash-"))
							{
								this._ParserRule.Add(new KeyValuePair<string, string[]>(text2, ModBase.ReadFile(text2).Replace("\r\n", "\r").Replace("\n", "\r").Split(new char[]
								{
									'\r'
								})));
							}
							else
							{
								this._ParserRule.Add(new KeyValuePair<string, string[]>(text2, File.ReadAllLines(text2, Encoding.UTF8)));
							}
						}
						catch (Exception ex5)
						{
							ModBase.Log(ex5, "读取可能的崩溃日志文件失败（" + text2 + "）", ModBase.LogLevel.Debug, "出现错误");
						}
					}
				}
				finally
				{
					List<string>.Enumerator enumerator5;
					((IDisposable)enumerator5).Dispose();
				}
				if (LatestLog != null && LatestLog.Count > 0)
				{
					string text3 = ModBase.Join((ICollection)LatestLog, "\r\n");
					ModBase.Log("[Crash] 以下为游戏输出的最后一段内容：\r\n" + text3, ModBase.LogLevel.Normal, "出现错误");
					ModBase.WriteFile(this.poolRule + "RawOutput.log", text3, false, null);
					this._ParserRule.Add(new KeyValuePair<string, string[]>(this.poolRule + "RawOutput.log", LatestLog.ToArray<string>()));
					LatestLog.Clear();
				}
				ModBase.Log("[Crash] 步骤 1：收集日志文件完成，收集到 " + Conversions.ToString(this._ParserRule.Count) + " 个文件", ModBase.LogLevel.Normal, "出现错误");
			}

			// Token: 0x06000278 RID: 632 RVA: 0x0001723C File Offset: 0x0001543C
			public void Import(string FilePath)
			{
				ModBase.Log("[Crash] 步骤 1：自主导入日志文件", ModBase.LogLevel.Normal, "出现错误");
				try
				{
					FileInfo fileInfo = new FileInfo(FilePath);
					if (fileInfo.Exists && fileInfo.Length != 0L)
					{
						if (ModBase.ExtractFile(FilePath, this.poolRule + "Temp\\", null))
						{
							ModBase.Log("[Crash] 已解压导入的日志文件：" + FilePath, ModBase.LogLevel.Normal, "出现错误");
						}
						else
						{
							File.Copy(FilePath, this.poolRule + "Temp\\" + ModBase.GetFileNameFromPath(FilePath));
							ModBase.Log("[Crash] 已复制导入的日志文件：" + FilePath, ModBase.LogLevel.Normal, "出现错误");
						}
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "解压导入文件中的压缩包失败", ModBase.LogLevel.Debug, "出现错误");
				}
				try
				{
					foreach (FileInfo fileInfo2 in new DirectoryInfo(this.poolRule + "Temp\\").EnumerateFiles())
					{
						try
						{
							if (fileInfo2.Exists && fileInfo2.Length != 0L)
							{
								string left = fileInfo2.Extension.ToLower();
								if (Operators.CompareString(left, ".log", true) == 0 || Operators.CompareString(left, ".txt", true) == 0)
								{
									if (fileInfo2.Name.StartsWith("crash-"))
									{
										this._ParserRule.Add(new KeyValuePair<string, string[]>(fileInfo2.FullName, ModBase.ReadFile(fileInfo2.FullName).Replace("\r\n", "\r").Replace("\n", "\r").Split(new char[]
										{
											'\r'
										})));
									}
									else
									{
										this._ParserRule.Add(new KeyValuePair<string, string[]>(fileInfo2.FullName, File.ReadAllLines(fileInfo2.FullName, Encoding.UTF8)));
									}
								}
							}
						}
						catch (Exception ex2)
						{
							ModBase.Log(ex2, "导入单个日志文件失败", ModBase.LogLevel.Debug, "出现错误");
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
				ModBase.Log("[Crash] 步骤 1：自主导入日志文件，收集到 " + Conversions.ToString(this._ParserRule.Count) + " 个文件", ModBase.LogLevel.Normal, "出现错误");
			}

			// Token: 0x06000279 RID: 633 RVA: 0x000174A4 File Offset: 0x000156A4
			public int Prepare()
			{
				ModBase.Log("[Crash] 步骤 2：准备日志文本", ModBase.LogLevel.Normal, "出现错误");
				List<KeyValuePair<ModCrash.CrashAnalyzer.AnalyzeFileType, KeyValuePair<string, string[]>>> list = new List<KeyValuePair<ModCrash.CrashAnalyzer.AnalyzeFileType, KeyValuePair<string, string[]>>>();
				try
				{
					foreach (KeyValuePair<string, string[]> value in this._ParserRule)
					{
						string fileNameFromPath = ModBase.GetFileNameFromPath(value.Key);
						ModCrash.CrashAnalyzer.AnalyzeFileType analyzeFileType;
						if (fileNameFromPath.StartsWith("hs_err"))
						{
							analyzeFileType = ModCrash.CrashAnalyzer.AnalyzeFileType.HsErr;
						}
						else if (fileNameFromPath.StartsWith("crash-"))
						{
							analyzeFileType = ModCrash.CrashAnalyzer.AnalyzeFileType.CrashReport;
						}
						else if (Operators.CompareString(fileNameFromPath, "latest.log", true) != 0 && Operators.CompareString(fileNameFromPath, "latest log.txt", true) != 0 && Operators.CompareString(fileNameFromPath, "debug.log", true) != 0 && Operators.CompareString(fileNameFromPath, "debug log.txt", true) != 0 && Operators.CompareString(fileNameFromPath, "rawoutput.log", true) != 0 && Operators.CompareString(fileNameFromPath, "启动器日志.txt", true) != 0 && Operators.CompareString(fileNameFromPath, "log1.txt", true) != 0)
						{
							if (!fileNameFromPath.EndsWith(".log") && !fileNameFromPath.EndsWith(".txt"))
							{
								ModBase.Log("[Crash] " + fileNameFromPath + " 分类为 Ignore", ModBase.LogLevel.Normal, "出现错误");
								continue;
							}
							analyzeFileType = ModCrash.CrashAnalyzer.AnalyzeFileType.ExtraLog;
						}
						else
						{
							analyzeFileType = ModCrash.CrashAnalyzer.AnalyzeFileType.MinecraftLog;
						}
						if (value.Value.Count<string>() == 0)
						{
							ModBase.Log("[Crash] " + fileNameFromPath + " 由于内容为空跳过", ModBase.LogLevel.Normal, "出现错误");
						}
						else
						{
							list.Add(new KeyValuePair<ModCrash.CrashAnalyzer.AnalyzeFileType, KeyValuePair<string, string[]>>(analyzeFileType, value));
							ModBase.Log("[Crash] " + fileNameFromPath + " 分类为 " + ModBase.GetStringFromEnum(analyzeFileType), ModBase.LogLevel.Normal, "出现错误");
						}
					}
				}
				finally
				{
					List<KeyValuePair<string, string[]>>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				checked
				{
					foreach (ModCrash.CrashAnalyzer.AnalyzeFileType analyzeFileType2 in new ModCrash.CrashAnalyzer.AnalyzeFileType[]
					{
						ModCrash.CrashAnalyzer.AnalyzeFileType.MinecraftLog,
						ModCrash.CrashAnalyzer.AnalyzeFileType.HsErr,
						ModCrash.CrashAnalyzer.AnalyzeFileType.ExtraLog,
						ModCrash.CrashAnalyzer.AnalyzeFileType.CrashReport
					})
					{
						List<KeyValuePair<string, string[]>> list2 = new List<KeyValuePair<string, string[]>>();
						try
						{
							foreach (KeyValuePair<ModCrash.CrashAnalyzer.AnalyzeFileType, KeyValuePair<string, string[]>> keyValuePair in list)
							{
								if (analyzeFileType2 == keyValuePair.Key)
								{
									list2.Add(keyValuePair.Value);
								}
							}
						}
						finally
						{
							List<KeyValuePair<ModCrash.CrashAnalyzer.AnalyzeFileType, KeyValuePair<string, string[]>>>.Enumerator enumerator2;
							((IDisposable)enumerator2).Dispose();
						}
						if (list2.Count != 0)
						{
							try
							{
								switch (analyzeFileType2)
								{
								case ModCrash.CrashAnalyzer.AnalyzeFileType.HsErr:
								case ModCrash.CrashAnalyzer.AnalyzeFileType.CrashReport:
									break;
								case ModCrash.CrashAnalyzer.AnalyzeFileType.MinecraftLog:
								{
									this._ProxyRule = "";
									Dictionary<string, KeyValuePair<string, string[]>> dictionary = new Dictionary<string, KeyValuePair<string, string[]>>();
									try
									{
										foreach (KeyValuePair<string, string[]> value2 in list2)
										{
											ModBase.DictionaryAdd<string, KeyValuePair<string, string[]>>(ref dictionary, ModBase.GetFileNameFromPath(value2.Key).ToLower(), value2);
											this.productRule.Add(value2.Key);
											ModBase.Log("[Crash] 输出报告：" + value2.Key + "，作为 Minecraft 或启动器日志", ModBase.LogLevel.Normal, "出现错误");
										}
									}
									finally
									{
										List<KeyValuePair<string, string[]>>.Enumerator enumerator3;
										((IDisposable)enumerator3).Dispose();
									}
									foreach (string key in new string[]
									{
										"rawoutput.log",
										"启动器日志.txt",
										"log1.txt"
									})
									{
										if (dictionary.ContainsKey(key))
										{
											KeyValuePair<string, string[]> keyValuePair2 = dictionary[key];
											bool flag = false;
											foreach (string text in keyValuePair2.Value)
											{
												if (flag)
												{
													ref string ptr = ref this._ProxyRule;
													this._ProxyRule = ptr + text + "\r\n";
												}
												else if (text.Contains("以下为游戏输出的最后一段内容"))
												{
													flag = true;
													ModBase.Log("[Crash] 找到 PCL2 输出的游戏实时日志头", ModBase.LogLevel.Normal, "出现错误");
												}
											}
											if (!flag)
											{
												ref string ptr = ref this._ProxyRule;
												this._ProxyRule = ptr + this.GetHeadTailLines(keyValuePair2.Value, 0, 0xC8);
											}
											this._ProxyRule = this._ProxyRule.TrimEnd("\r\n".ToCharArray()) + "\r\n[";
											ModBase.Log("[Crash] 导入分析：" + keyValuePair2.Key + "，作为启动器日志", ModBase.LogLevel.Normal, "出现错误");
											IL_3EB:
											string[] array3 = new string[]
											{
												"latest.log",
												"latest log.txt",
												"debug.log",
												"debug log.txt"
											};
											int l = 0;
											while (l < array3.Length)
											{
												string key2 = array3[l];
												if (!dictionary.ContainsKey(key2))
												{
													l++;
												}
												else
												{
													KeyValuePair<string, string[]> keyValuePair3 = dictionary[key2];
													ref string ptr = ref this._ProxyRule;
													this._ProxyRule = ptr + this.GetHeadTailLines(keyValuePair3.Value, 0xFA, 0x1F4) + "\r\n[";
													ModBase.Log("[Crash] 导入分析：" + keyValuePair3.Key + "，作为 Minecraft 日志", ModBase.LogLevel.Normal, "出现错误");
													IL_494:
													if (Operators.CompareString(this._ProxyRule, "", true) == 0)
													{
														this._ProxyRule = null;
														throw new Exception("无法找到匹配的 Minecraft Log");
													}
													goto IL_68B;
												}
											}
											goto IL_494;
										}
									}
									goto IL_3EB;
								}
								case ModCrash.CrashAnalyzer.AnalyzeFileType.ExtraLog:
									try
									{
										foreach (KeyValuePair<string, string[]> keyValuePair4 in list2)
										{
											this.productRule.Add(keyValuePair4.Key);
											ModBase.Log("[Crash] 输出报告：" + keyValuePair4.Key + "，作为额外日志", ModBase.LogLevel.Normal, "出现错误");
										}
										goto IL_68B;
									}
									finally
									{
										List<KeyValuePair<string, string[]>>.Enumerator enumerator4;
										((IDisposable)enumerator4).Dispose();
									}
									break;
								default:
									goto IL_68B;
								}
								SortedList<DateTime, KeyValuePair<string, string[]>> sortedList = new SortedList<DateTime, KeyValuePair<string, string[]>>();
								try
								{
									foreach (KeyValuePair<string, string[]> value4 in list2)
									{
										try
										{
											sortedList.Add(new FileInfo(value4.Key).LastWriteTime, value4);
										}
										catch (Exception ex)
										{
											ModBase.Log(ex, "获取日志文件修改时间失败", ModBase.LogLevel.Debug, "出现错误");
											sortedList.Add(new DateTime(0x76C, 1, 1), value4);
										}
									}
								}
								finally
								{
									List<KeyValuePair<string, string[]>>.Enumerator enumerator5;
									((IDisposable)enumerator5).Dispose();
								}
								KeyValuePair<string, string[]> value5 = sortedList.Last<KeyValuePair<DateTime, KeyValuePair<string, string[]>>>().Value;
								this.productRule.Add(value5.Key);
								if (analyzeFileType2 == ModCrash.CrashAnalyzer.AnalyzeFileType.HsErr)
								{
									this.setterRule = this.GetHeadTailLines(value5.Value, 0xC8, 0x64);
									ModBase.Log("[Crash] 输出报告：" + value5.Key + "，作为虚拟机错误信息", ModBase.LogLevel.Normal, "出现错误");
									ModBase.Log("[Crash] 导入分析：" + value5.Key + "，作为虚拟机错误信息", ModBase.LogLevel.Normal, "出现错误");
								}
								else
								{
									this.merchantRule = this.GetHeadTailLines(value5.Value, 0x12C, 0x2BC);
									ModBase.Log("[Crash] 输出报告：" + value5.Key + "，作为 Minecraft 崩溃报告", ModBase.LogLevel.Normal, "出现错误");
									ModBase.Log("[Crash] 导入分析：" + value5.Key + "，作为 Minecraft 崩溃报告", ModBase.LogLevel.Normal, "出现错误");
								}
								IL_68B:;
							}
							catch (Exception ex2)
							{
								ModBase.Log(ex2, "分类处理日志文件时出错", ModBase.LogLevel.Debug, "出现错误");
							}
						}
					}
					int num = ((this._ProxyRule == null) ? 0 : 1) + ((this.setterRule == null) ? 0 : 1) + ((this.merchantRule == null) ? 0 : 1);
					if (num == 0)
					{
						ModBase.Log("[Crash] 步骤 2：准备日志文本完成，没有任何可供分析的日志", ModBase.LogLevel.Normal, "出现错误");
					}
					else
					{
						ModBase.Log(("[Crash] 步骤 2：准备日志文本完成，找到" + ((this._ProxyRule == null) ? "" : "游戏日志、") + ((this.setterRule == null) ? "" : "虚拟机日志、") + ((this.merchantRule == null) ? "" : "崩溃日志、")).TrimEnd(new char[]
						{
							'、'
						}) + "用作分析", ModBase.LogLevel.Normal, "出现错误");
					}
					return num;
				}
			}

			// Token: 0x0600027A RID: 634 RVA: 0x00017CC4 File Offset: 0x00015EC4
			private string GetHeadTailLines(string[] Raw, int HeadLines, int TailLines)
			{
				checked
				{
					string result;
					if (Raw.Length <= HeadLines + TailLines)
					{
						result = ModBase.Join(Raw, "\r\n");
					}
					else
					{
						StringBuilder stringBuilder = new StringBuilder();
						int num = Raw.Count<string>() - 1;
						for (int i = 0; i <= num; i++)
						{
							if ((i < HeadLines || Raw.Count<string>() - i < TailLines) && Operators.CompareString(Raw[i], "", true) != 0)
							{
								stringBuilder.Append(Raw[i] + "\r\n");
							}
						}
						result = stringBuilder.ToString();
					}
					return result;
				}
			}

			// Token: 0x0600027B RID: 635 RVA: 0x00017D40 File Offset: 0x00015F40
			public void Analyze(ModMinecraft.McVersion Version = null)
			{
				ModBase.Log("[Crash] 步骤 3：分析崩溃原因", ModBase.LogLevel.Normal, "出现错误");
				this.eventRule = (this._ProxyRule + this.setterRule + this.merchantRule).ToLower();
				this.AnalyzeCrit1();
				if (this.printerRule.Count <= 0)
				{
					if (!this.eventRule.Contains("forge") && !this.eventRule.Contains("fabric") && !this.eventRule.Contains("liteloader"))
					{
						ModBase.Log("[Crash] 可能并未安装 Mod，不进行堆栈分析", ModBase.LogLevel.Normal, "出现错误");
					}
					else
					{
						if (this.merchantRule != null)
						{
							ModBase.Log("[Crash] 开始进行崩溃日志堆栈分析", ModBase.LogLevel.Normal, "出现错误");
							List<string> list = this.AnalyzeStackKeyword(this.merchantRule.Replace("A detailed walkthrough of the error", "¨").Split(new char[]
							{
								'¨'
							}).First<string>());
							if (list.Count > 0)
							{
								List<string> list2 = this.AnalyzeModName(list);
								if (list2 == null)
								{
									this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.崩溃日志堆栈分析发现关键字, list);
									goto IL_1BB;
								}
								this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.崩溃日志堆栈分析发现Mod名称, list2);
								goto IL_1BB;
							}
						}
						if (this._ProxyRule != null)
						{
							List<string> list3 = ModBase.RegexSearch(this._ProxyRule, "/FATAL] [\\w\\W]+?(?=[\\n\\r]+\\[)", RegexOptions.None);
							ModBase.Log("[Crash] 开始进行 Minecraft 日志堆栈分析，发现 " + Conversions.ToString(list3.Count) + " 个报错项", ModBase.LogLevel.Normal, "出现错误");
							if (list3.Count > 0)
							{
								List<string> list4 = new List<string>();
								try
								{
									foreach (string errorStack in list3)
									{
										list4.AddRange(this.AnalyzeStackKeyword(errorStack));
									}
								}
								finally
								{
									List<string>.Enumerator enumerator;
									((IDisposable)enumerator).Dispose();
								}
								if (list4.Count > 0)
								{
									this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.MC日志堆栈分析发现关键字, ModBase.ArrayNoDouble<string>(list4, null));
									goto IL_1BB;
								}
							}
						}
					}
					this.AnalyzeCrit2();
				}
				IL_1BB:
				if (this.printerRule.Count == 0)
				{
					ModBase.Log("[Crash] 步骤 3：分析崩溃原因完成，未找到可能的原因", ModBase.LogLevel.Normal, "出现错误");
					return;
				}
				ModBase.Log("[Crash] 步骤 3：分析崩溃原因完成，找到 " + Conversions.ToString(this.printerRule.Count) + " 条可能的原因", ModBase.LogLevel.Normal, "出现错误");
				try
				{
					foreach (KeyValuePair<ModCrash.CrashAnalyzer.CrashReason, List<string>> keyValuePair in this.printerRule)
					{
						ModBase.Log("[Crash]  - " + ModBase.GetStringFromEnum(keyValuePair.Key) + ((keyValuePair.Value.Count > 0) ? ("（" + ModBase.Join(keyValuePair.Value, "；") + "）") : ""), ModBase.LogLevel.Normal, "出现错误");
					}
				}
				finally
				{
					Dictionary<ModCrash.CrashAnalyzer.CrashReason, List<string>>.Enumerator enumerator2;
					((IDisposable)enumerator2).Dispose();
				}
			}

			// Token: 0x0600027C RID: 636 RVA: 0x00017FFC File Offset: 0x000161FC
			private void AppendReason(ModCrash.CrashAnalyzer.CrashReason Reason, ICollection<string> Additional = null)
			{
				if (this.printerRule.ContainsKey(Reason))
				{
					if (Additional != null)
					{
						this.printerRule[Reason].AddRange(Additional);
						this.printerRule[Reason] = ModBase.ArrayNoDouble<string>(this.printerRule[Reason], null);
					}
				}
				else
				{
					this.printerRule.Add(Reason, new List<string>(Additional ?? new string[0]));
				}
				ModBase.Log("[Crash] 可能的崩溃原因：" + ModBase.GetStringFromEnum(Reason) + ((Additional == null || Additional.Count <= 0) ? "" : ("（" + ModBase.Join((ICollection)Additional, "；") + "）")), ModBase.LogLevel.Normal, "出现错误");
			}

			// Token: 0x0600027D RID: 637 RVA: 0x0000397A File Offset: 0x00001B7A
			private void AppendReason(ModCrash.CrashAnalyzer.CrashReason Reason, string Additional)
			{
				List<string> additional;
				if (!string.IsNullOrEmpty(Additional))
				{
					(additional = new List<string>()).Add(Additional);
				}
				else
				{
					additional = null;
				}
				this.AppendReason(Reason, additional);
			}

			// Token: 0x0600027E RID: 638 RVA: 0x000180BC File Offset: 0x000162BC
			private void AnalyzeCrit1()
			{
				if (this._ProxyRule == null && this.setterRule == null && this.merchantRule == null)
				{
					this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.没有可用的分析文件, null);
					return;
				}
				if (this._ProxyRule != null)
				{
					if (this._ProxyRule.Contains("The driver does not appear to support OpenGL"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.显卡不支持OpenGL, null);
					}
					if (this._ProxyRule.Contains("java.lang.ClassCastException: java.base/jdk"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.使用JDK, null);
					}
					if (this._ProxyRule.Contains("java.lang.ClassCastException: class jdk."))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.使用JDK, null);
					}
					if (this._ProxyRule.Contains("Open J9 is not supported") || this._ProxyRule.Contains("OpenJ9 is incompatible") || this._ProxyRule.Contains(".J9VMInternals."))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.使用OpenJ9, null);
					}
					if (this._ProxyRule.Contains("because module java.base does not export"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.Java版本过高, null);
					}
					if (this._ProxyRule.Contains("java.lang.ClassNotFoundException: java.lang.invoke.LambdaMetafactory"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.Java版本过高, null);
					}
					if (this._ProxyRule.Contains("compiled by a more recent version of the Java Runtime"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.Java版本过低, null);
					}
					if (this._ProxyRule.Contains("The directories below appear to be extracted jar files. Fix this before you continue."))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.Mod文件被解压, null);
					}
					if (this._ProxyRule.Contains("Extracted mod jars found, loading will NOT continue"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.Mod文件被解压, null);
					}
					if (this._ProxyRule.Contains("Couldn't set pixel format"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.显卡驱动不支持导致无法设置像素格式, null);
					}
					if (this._ProxyRule.Contains("java.lang.OutOfMemoryError"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.内存不足, null);
					}
					if (this._ProxyRule.Contains("1282: Invalid operation"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.光影或资源包导致OpenGL1282错误, null);
					}
					if (this._ProxyRule.Contains("signer information does not match signer information of other classes in the same package"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.文件或内容校验失败, (ModBase.RegexSeek(this._ProxyRule, "(?<=class \")[^']+(?=\"'s signer information)", RegexOptions.None) ?? "").TrimEnd(new char[]
						{
							'\r'
						}));
					}
					if (this._ProxyRule.Contains("An exception was thrown, the game will display an error screen and halt."))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.Forge报错, (ModBase.RegexSeek(this._ProxyRule, "(?<=the game will display an error screen and halt[\\s\\S]+?Exception: )[\\s\\S]+?(?=\\n\\tat)", RegexOptions.None) ?? "").TrimEnd(new char[]
						{
							'\r'
						}));
					}
					if (this._ProxyRule.Contains("Maybe try a lower resolution resourcepack?"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.材质过大或显卡配置不足, null);
					}
					if (this._ProxyRule.Contains("java.lang.NoSuchMethodError: net.minecraft.world.server.ChunkManager$ProxyTicketManager.shouldForceTicks(J)Z") && this._ProxyRule.Contains("OptiFine"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.OptiFine导致无法加载世界, null);
					}
					if (this._ProxyRule.Contains("Could not reserve enough space"))
					{
						if (this._ProxyRule.Contains("for 1048576KB object heap"))
						{
							this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.使用32位Java导致JVM无法分配足够多的内存, null);
						}
						else
						{
							this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.内存不足, null);
						}
					}
					if (this._ProxyRule.Contains("DuplicateModsFoundException"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.Mod重复安装, ModBase.RegexSearch(this._ProxyRule, "(?<=\\n\\t[\\w]+ : [A-Z]{1}:[^\\n]+(/|\\\\))[^/\\\\\\n]+?.jar", RegexOptions.IgnoreCase));
					}
					if (this._ProxyRule.Contains("Found a duplicate mod"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.Mod重复安装, ModBase.RegexSearch(ModBase.RegexSeek(this._ProxyRule, "Found a duplicate mod[^\\n]+", RegexOptions.None) ?? "", "[^\\\\/]+.jar", RegexOptions.IgnoreCase));
					}
					if (this._ProxyRule.Contains("ModResolutionException: Duplicate"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.Mod重复安装, ModBase.RegexSearch(ModBase.RegexSeek(this._ProxyRule, "ModResolutionException: Duplicate[^\\n]+", RegexOptions.None) ?? "", "[^\\\\/]+.jar", RegexOptions.IgnoreCase));
					}
					if ((ModBase.RegexCheck(this._ProxyRule, "^[^\\n.]+.\\w+.[^\\n]+\\n\\[$", RegexOptions.None) || ModBase.RegexCheck(this._ProxyRule, "^\\[[^\\]]+\\] [^\\n.]+.\\w+.[^\\n]+\\n\\[", RegexOptions.None)) && !this._ProxyRule.Contains("at net.") && !this._ProxyRule.Contains("/INFO]") && this.setterRule == null && this.merchantRule == null)
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.路径包含中文且存在编码问题导致找不到或无法加载主类, null);
					}
					if (this._ProxyRule.Contains("Mixin prepare failed "))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.确定Mod导致游戏崩溃, this.TryAnalyzeModName((ModBase.RegexSeek(this._ProxyRule, "(?<=in )[^. ]+(?=.mixins.json)", RegexOptions.None) ?? "").TrimEnd("\r\n ".ToCharArray())));
					}
					if (this._ProxyRule.Contains("Caught exception from "))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.确定Mod导致游戏崩溃, this.TryAnalyzeModName((ModBase.RegexSeek(this._ProxyRule, "(?<=Caught exception from )[^\\n]+", RegexOptions.None) ?? "").TrimEnd("\r\n ".ToCharArray())));
					}
					if (this._ProxyRule.Contains("Failed to create Mod instance."))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.Mod初始化失败, this.TryAnalyzeModName((ModBase.RegexSeek(this._ProxyRule, "(?<=Failed to create mod instance. ModID: )[^,]+", RegexOptions.None) ?? "").TrimEnd(new char[]
						{
							'\r'
						})));
					}
				}
				if (this.setterRule != null)
				{
					if (this.setterRule.Contains("The system is out of physical RAM or swap space"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.内存不足, null);
					}
					if (this.setterRule.Contains("Out of Memory Error"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.内存不足, null);
					}
					if (this.setterRule.Contains("EXCEPTION_ACCESS_VIOLATION"))
					{
						if (this.setterRule.Contains("# C  [ig"))
						{
							this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.Intel驱动不兼容导致EXCEPTION_ACCESS_VIOLATION, null);
						}
						if (this.setterRule.Contains("# C  [atio"))
						{
							this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.AMD驱动不兼容导致EXCEPTION_ACCESS_VIOLATION, null);
						}
						if (this.setterRule.Contains("# C  [nvoglv"))
						{
							this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.Nvidia驱动不兼容导致EXCEPTION_ACCESS_VIOLATION, null);
						}
					}
				}
				if (this.merchantRule != null)
				{
					if (this.merchantRule.Contains("Entity being rendered") && this.merchantRule.Contains("\tEntity's Exact location: "))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.特定实体导致崩溃, ModBase.RegexSeek(this.merchantRule, "(?<=\\tEntity Type: )[^\\n]+(?= \\()", RegexOptions.None) + " (" + (ModBase.RegexSeek(this.merchantRule, "(?<=\\tEntity's Exact location: )[^\\n]+", RegexOptions.None) ?? "").TrimEnd("\r\n".ToCharArray()) + ")");
					}
					if (this.merchantRule.Contains("java.lang.OutOfMemoryError"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.内存不足, null);
					}
					if (this.merchantRule.Contains("Pixel format not accelerated"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.显卡驱动不支持导致无法设置像素格式, null);
					}
					if (this.merchantRule.Contains("Manually triggered debug crash"))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.玩家手动触发调试崩溃, null);
					}
					if (this.merchantRule.Contains("Multiple entries with same key: "))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.确定Mod导致游戏崩溃, this.TryAnalyzeModName((ModBase.RegexSeek(this.merchantRule, "(?<=Multiple entries with same key: )[^=]+", RegexOptions.None) ?? "").TrimEnd("\r\n ".ToCharArray())));
					}
					if (this.merchantRule.Contains("LoaderExceptionModCrash: Caught exception from "))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.确定Mod导致游戏崩溃, this.TryAnalyzeModName((ModBase.RegexSeek(this.merchantRule, "(?<=LoaderExceptionModCrash: Caught exception from )[^\\n]+", RegexOptions.None) ?? "").TrimEnd("\r\n ".ToCharArray())));
					}
					if (this.merchantRule.Contains("Failed loading config file "))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.Mod配置文件导致游戏崩溃, new string[]
						{
							this.TryAnalyzeModName((ModBase.RegexSeek(this.merchantRule, "(?<=Failed loading config file .+ for modid )[^\\n]+", RegexOptions.None) ?? "").TrimEnd(new char[]
							{
								'\r'
							})).First<string>(),
							(ModBase.RegexSeek(this.merchantRule, "(?<=Failed loading config file ).+(?= of type)", RegexOptions.None) ?? "").TrimEnd(new char[]
							{
								'\r'
							})
						});
					}
				}
			}

			// Token: 0x0600027F RID: 639 RVA: 0x000187CC File Offset: 0x000169CC
			private void AnalyzeCrit2()
			{
				if (this._ProxyRule != null && this._ProxyRule.Contains("]: Warnings were found!"))
				{
					this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.Fabric报错, (ModBase.RegexSeek(this._ProxyRule, "(?<=\\]: Warnings were found! ?[\\n\\r]+)[\\w\\W]+?(?=[\\n\\r]+\\[)", RegexOptions.None) ?? "").Trim("\r\n".ToCharArray()));
				}
				if (this.merchantRule != null)
				{
					if (this.merchantRule.Contains("\tBlock location: World: "))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.特定方块导致崩溃, ModBase.RegexSeek(this.merchantRule, "(?<=\\tBlock: Block\\{)[^\\}]+", RegexOptions.None) + " " + ModBase.RegexSeek(this.merchantRule, "(?<=\\tBlock location: World: )\\([^\\)]+\\)", RegexOptions.None));
					}
					if (this.merchantRule.Contains("\tEntity's Exact location: "))
					{
						this.AppendReason(ModCrash.CrashAnalyzer.CrashReason.特定实体导致崩溃, ModBase.RegexSeek(this.merchantRule, "(?<=\\tEntity Type: )[^\\n]+(?= \\()", RegexOptions.None) + " (" + (ModBase.RegexSeek(this.merchantRule, "(?<=\\tEntity's Exact location: )[^\\n]+", RegexOptions.None) ?? "").TrimEnd("\r\n".ToCharArray()) + ")");
					}
				}
			}

			// Token: 0x06000280 RID: 640 RVA: 0x000188D8 File Offset: 0x00016AD8
			private List<string> AnalyzeStackKeyword(string ErrorStack)
			{
				List<string> list = ModBase.RegexSearch(ErrorStack + "\r\n", "(?<=\\n[^{]+)[a-zA-Z]+\\w+\\.[a-zA-Z]+[\\w\\.]+(?=\\.[\\w\\.$]+\\.)", RegexOptions.None);
				List<string> list2 = new List<string>();
				try
				{
					List<string>.Enumerator enumerator = list.GetEnumerator();
					IL_FE:
					while (enumerator.MoveNext())
					{
						string text = enumerator.Current;
						foreach (string value in new string[]
						{
							"java",
							"sun",
							"javax",
							"jdk",
							"org.lwjgl",
							"com.sun",
							"net.minecraftforge",
							"com.mojang",
							"net.minecraft",
							"cpw.mods",
							"com.google",
							"org.apache",
							"org.spongepowered",
							"net.fabricmc",
							"com.mumfrey",
							"com.electronwill.nightconfig",
							"MojangTricksIntelDriversForPerformance_javaw"
						})
						{
							if (text.StartsWith(value))
							{
								goto IL_FE;
							}
						}
						list2.Add(text.Trim());
					}
				}
				finally
				{
					List<string>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				list2 = ModBase.ArrayNoDouble<string>(list2, null);
				ModBase.Log("[Crash] 找到 " + Conversions.ToString(list2.Count) + " 条可能的堆栈信息", ModBase.LogLevel.Normal, "出现错误");
				checked
				{
					List<string> result;
					if (list2.Count == 0)
					{
						result = new List<string>();
					}
					else
					{
						try
						{
							foreach (string str in list2)
							{
								ModBase.Log("[Crash]  - " + str, ModBase.LogLevel.Normal, "出现错误");
							}
						}
						finally
						{
							List<string>.Enumerator enumerator2;
							((IDisposable)enumerator2).Dispose();
						}
						List<string> list3 = new List<string>();
						try
						{
							foreach (string text2 in list2)
							{
								string[] array2 = text2.Split(new char[]
								{
									'.'
								});
								int num = Math.Min(3, array2.Count<string>() - 1);
								for (int j = 0; j <= num; j++)
								{
									string text3 = array2[j];
									if (text3.Length > 2 && !text3.StartsWith("func_") && !new string[]
									{
										"com",
										"org",
										"net",
										"asm",
										"fml",
										"mod",
										"jar",
										"sun",
										"lib",
										"map",
										"gui",
										"dev",
										"nio",
										"api",
										"core",
										"init",
										"mods",
										"main",
										"file",
										"game",
										"load",
										"read",
										"done",
										"util",
										"tile",
										"item",
										"forge",
										"setup",
										"block",
										"model",
										"mixin",
										"event",
										"common",
										"server",
										"config",
										"loader",
										"launch",
										"entity",
										"assist",
										"client",
										"modapi",
										"mojang",
										"shader",
										"events",
										"github",
										"preinit",
										"preload",
										"machine",
										"reflect",
										"channel",
										"general",
										"optifine",
										"minecraft",
										"transformers",
										"universal",
										"internal"
									}.Contains(text3.ToLower()))
									{
										list3.Add(text3.Trim());
									}
								}
							}
						}
						finally
						{
							List<string>.Enumerator enumerator3;
							((IDisposable)enumerator3).Dispose();
						}
						list3 = ModBase.ArrayNoDouble<string>(list3, null);
						ModBase.Log("[Crash] 从堆栈信息中找到 " + Conversions.ToString(list3.Count) + " 个可能的 Mod ID 关键词", ModBase.LogLevel.Normal, "出现错误");
						if (list3.Count > 0)
						{
							ModBase.Log("[Crash]  - " + ModBase.Join(list3, ", "), ModBase.LogLevel.Normal, "出现错误");
						}
						if (list3.Count > 0xA)
						{
							ModBase.Log("[Crash] 关键词过多，考虑匹配出错，不纳入考虑", ModBase.LogLevel.Normal, "出现错误");
							result = new List<string>();
						}
						else
						{
							result = list3;
						}
					}
					return result;
				}
			}

			// Token: 0x06000281 RID: 641 RVA: 0x00018DF0 File Offset: 0x00016FF0
			private List<string> AnalyzeModName(List<string> Keywords)
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				try
				{
					foreach (string text in Keywords)
					{
						foreach (string text2 in text.Split(new char[]
						{
							'('
						}))
						{
							list2.Add(text2.Trim(" )".ToCharArray()));
						}
					}
				}
				finally
				{
					List<string>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				Keywords = list2;
				List<string> result;
				if (this.merchantRule == null)
				{
					result = null;
				}
				else if (!this.merchantRule.Contains("A detailed walkthrough of the error"))
				{
					result = null;
				}
				else
				{
					string text3 = this.merchantRule.Replace("A detailed walkthrough of the error", "¨");
					bool flag;
					if (flag = text3.Contains("Fabric Mods"))
					{
						text3 = text3.Replace("Fabric Mods", "¨");
						ModBase.Log("[Crash] 检测到 Fabric Mod 信息格式", ModBase.LogLevel.Normal, "出现错误");
					}
					text3 = text3.Split(new char[]
					{
						'¨'
					}).Last<string>();
					List<string> list3 = new List<string>();
					foreach (string text4 in text3.Replace("\r\n", "\r").Split(new char[]
					{
						'\r'
					}))
					{
						if (text4.ToLower().Contains(".jar") || (flag && text4.StartsWith("\t\t") && !ModBase.RegexCheck(text4, "\\t\\tfabric[\\w-]*: Fabric", RegexOptions.None)))
						{
							list3.Add(text4);
						}
					}
					ModBase.Log("[Crash] 找到 " + Conversions.ToString(list3.Count) + " 个可能的 Mod 项目行", ModBase.LogLevel.Normal, "出现错误");
					List<string> list4 = new List<string>();
					try
					{
						foreach (string text5 in Keywords)
						{
							try
							{
								foreach (string text6 in list3)
								{
									string text7 = text6.ToLower().Replace("_", "");
									if (text7.Contains(text5.ToLower().Replace("_", "")) && !text7.Contains("minecraft.jar") && !text7.Contains(" forge-"))
									{
										list4.Add(text6.Trim("\r\n".ToCharArray()));
										break;
									}
								}
							}
							finally
							{
								List<string>.Enumerator enumerator3;
								((IDisposable)enumerator3).Dispose();
							}
						}
					}
					finally
					{
						List<string>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
					list4 = ModBase.ArrayNoDouble<string>(list4, null);
					ModBase.Log("[Crash] 找到 " + Conversions.ToString(list4.Count) + " 个可能的崩溃 Mod 匹配行", ModBase.LogLevel.Normal, "出现错误");
					try
					{
						foreach (string str in list4)
						{
							ModBase.Log("[Crash]  - " + str, ModBase.LogLevel.Normal, "出现错误");
						}
					}
					finally
					{
						List<string>.Enumerator enumerator4;
						((IDisposable)enumerator4).Dispose();
					}
					try
					{
						foreach (string str2 in list4)
						{
							string text8;
							if (flag)
							{
								text8 = ModBase.RegexSeek(str2, "(?<=: )[^\\n]+(?= [^\\n]+)", RegexOptions.None);
							}
							else
							{
								text8 = ModBase.RegexSeek(str2, "(?<=\\()[^\\t]+.jar(?=\\))|(?<=(\\t\\t)|(\\| ))[^\\t\\|]+.jar", RegexOptions.IgnoreCase);
							}
							if (text8 != null)
							{
								list.Add(text8);
							}
						}
					}
					finally
					{
						List<string>.Enumerator enumerator5;
						((IDisposable)enumerator5).Dispose();
					}
					list = ModBase.ArrayNoDouble<string>(list, null);
					ModBase.Log("[Crash] 找到 " + Conversions.ToString(list.Count) + " 个可能的崩溃 Mod 文件名", ModBase.LogLevel.Normal, "出现错误");
					try
					{
						foreach (string str3 in list)
						{
							ModBase.Log("[Crash]  - " + str3, ModBase.LogLevel.Normal, "出现错误");
						}
					}
					finally
					{
						List<string>.Enumerator enumerator6;
						((IDisposable)enumerator6).Dispose();
					}
					result = ((list.Count == 0) ? null : list);
				}
				return result;
			}

			// Token: 0x06000282 RID: 642 RVA: 0x00019218 File Offset: 0x00017418
			private List<string> TryAnalyzeModName(string Keywords)
			{
				List<string> list = new List<string>
				{
					Keywords
				};
				List<string> result;
				if (string.IsNullOrEmpty(Keywords))
				{
					result = list;
				}
				else
				{
					result = (this.AnalyzeModName(list) ?? list);
				}
				return result;
			}

			// Token: 0x06000283 RID: 643 RVA: 0x0001924C File Offset: 0x0001744C
			public void Output(bool IsHandAnalyze, List<string> ExtraFiles = null)
			{
				ModMain.m_GetterFilter.ShowWindowToTop();
				int num = ModMain.MyMsgBox(this.GetAnalyzeResult(IsHandAnalyze), IsHandAnalyze ? "错误报告分析结果" : "Minecraft 出现错误", "确定", IsHandAnalyze ? "" : "导出错误报告", "", false, true, false);
				if (num == 2)
				{
					ModCrash.CrashAnalyzer._Closure$__23-0 CS$<>8__locals1 = new ModCrash.CrashAnalyzer._Closure$__23-0(CS$<>8__locals1);
					CS$<>8__locals1.$VB$Local_FileAddress = null;
					try
					{
						ModBase.RunInUiWait(delegate()
						{
							CS$<>8__locals1.$VB$Local_FileAddress = ModBase.SelectAs("选择保存位置", "错误报告-" + DateTime.Now.ToString("G").Replace("/", "-").Replace(":", ".").Replace(" ", "_") + ".zip", "Minecraft 错误报告(*.zip)|*.zip", null);
						});
						if (string.IsNullOrEmpty(CS$<>8__locals1.$VB$Local_FileAddress))
						{
							return;
						}
						if (File.Exists(CS$<>8__locals1.$VB$Local_FileAddress))
						{
							File.Delete(CS$<>8__locals1.$VB$Local_FileAddress);
						}
						ModBase.FeedbackInfo();
						ModBase.LogFlush();
						if (ExtraFiles != null)
						{
							this.productRule.AddRange(ExtraFiles);
						}
						try
						{
							foreach (string text in this.productRule)
							{
								try
								{
									string text2 = ModBase.GetFileNameFromPath(text);
									string left = text2;
									if (Operators.CompareString(left, "LatestLaunch.bat", true) == 0)
									{
										text2 = "启动脚本.bat";
									}
									else if (Operators.CompareString(left, "Log1.txt", true) == 0)
									{
										text2 = "PCL2 启动器日志.txt";
									}
									else if (Operators.CompareString(left, "RawOutput.log", true) == 0)
									{
										text2 = "游戏崩溃前的输出.txt";
									}
									File.Copy(text, this.poolRule + "Report\\" + text2, true);
								}
								catch (Exception ex)
								{
									ModBase.Log(ex, "复制错误报告文件失败（" + text + "）", ModBase.LogLevel.Debug, "出现错误");
								}
							}
						}
						finally
						{
							List<string>.Enumerator enumerator;
							((IDisposable)enumerator).Dispose();
						}
						ZipFile.CreateFromDirectory(this.poolRule + "Report\\", CS$<>8__locals1.$VB$Local_FileAddress);
						ModBase.DeleteDirectory(this.poolRule + "Report\\", false);
						ModMain.Hint("错误报告已导出！", ModMain.HintType.Finish, true);
					}
					catch (Exception ex2)
					{
						ModBase.Log(ex2, "导出错误报告失败", ModBase.LogLevel.Feedback, "出现错误");
						return;
					}
					try
					{
						Process.Start("explorer", "/select," + CS$<>8__locals1.$VB$Local_FileAddress);
					}
					catch (Exception ex3)
					{
						ModBase.Log(ex3, "打开错误报告的存放文件夹失败", ModBase.LogLevel.Debug, "出现错误");
					}
				}
			}

			// Token: 0x06000284 RID: 644 RVA: 0x000194D8 File Offset: 0x000176D8
			private string GetAnalyzeResult(bool IsHandAnalyze)
			{
				string result;
				if (this.printerRule.Count == 0)
				{
					if (IsHandAnalyze)
					{
						result = "很抱歉，PCL2 无法确定错误原因。";
					}
					else
					{
						result = "很抱歉，你的游戏出现了一些问题……\r\n如果要寻求帮助，请向他人发送错误报告文件，而不是发送这个窗口的截图。\r\n你也可以查看错误报告，其中可能会有出错的原因。";
					}
				}
				else
				{
					if (this.printerRule.Count >= 2)
					{
						ModMain.Hint("错误分析时发现数个可能的原因，窗口中仅显示了第一条，你可以在启动器日志中检查更多可能的原因！", ModMain.HintType.Finish, true);
					}
					List<string> value = this.printerRule.First<KeyValuePair<ModCrash.CrashAnalyzer.CrashReason, List<string>>>().Value;
					string text;
					switch (this.printerRule.First<KeyValuePair<ModCrash.CrashAnalyzer.CrashReason, List<string>>>().Key)
					{
					case ModCrash.CrashAnalyzer.CrashReason.Mod文件被解压:
						text = "由于 Mod 文件被解压了，导致游戏无法继续运行。\\n直接把整个 Mod 文件放进 Mod 文件夹中即可，若解压就会导致游戏出错。\\n\\n请删除 Mod 文件夹中已被解压的 Mod，然后再启动游戏。";
						break;
					case ModCrash.CrashAnalyzer.CrashReason.内存不足:
						text = "Minecraft 内存不足，导致其无法继续运行。\\n这很可能是由于你为游戏分配的内存不足，或是游戏的配置要求过高。\\n\\n你可以在启动设置中增加为游戏分配的内存，删除配置要求较高的材质、Mod、光影。\\n如果这依然不奏效，请在开始游戏前尽量关闭其他软件，或者……换台电脑？\\h";
						break;
					case ModCrash.CrashAnalyzer.CrashReason.使用JDK:
						text = "游戏似乎因为使用 JDK，或 Java 版本过高而崩溃了。\\n请在启动设置的 Java 选择一项中改用 JRE 8（Java 8），然后再启动游戏。\\n如果你没有安装 JRE 8，你可以从网络中下载、安装一个。";
						break;
					case ModCrash.CrashAnalyzer.CrashReason.显卡不支持OpenGL:
					case ModCrash.CrashAnalyzer.CrashReason.显卡驱动不支持导致无法设置像素格式:
					case ModCrash.CrashAnalyzer.CrashReason.Intel驱动不兼容导致EXCEPTION_ACCESS_VIOLATION:
					case ModCrash.CrashAnalyzer.CrashReason.AMD驱动不兼容导致EXCEPTION_ACCESS_VIOLATION:
					case ModCrash.CrashAnalyzer.CrashReason.Nvidia驱动不兼容导致EXCEPTION_ACCESS_VIOLATION:
						if (this.eventRule.Contains("hd graphics "))
						{
							text = "你的显卡驱动存在问题，或未使用独立显卡，导致游戏无法正常运行。\\n\\n如果你的电脑存在独立显卡，请使用独立显卡而非 Intel 核显启动 PCL2 与 Minecraft。\\n如果问题依然存在，请尝试升级你的显卡驱动到最新版本，或回退到出厂版本。\\h";
						}
						else
						{
							text = "你的显卡驱动存在问题，导致游戏无法正常运行。\\n\\n请尝试升级你的显卡驱动到最新版本，或回退到出厂版本，然后再启动游戏。\\n如果问题依然存在，那么你可能需要换个更好的显卡……\\h";
						}
						break;
					case ModCrash.CrashAnalyzer.CrashReason.使用OpenJ9:
						text = "游戏因为使用 Open J9 而崩溃了。\\n请在启动设置的 Java 选择一项中改用非 OpenJ9 的 Java 8，然后再启动游戏。\\n如果你没有安装 JRE 8，你可以从网络中下载、安装一个。";
						break;
					case ModCrash.CrashAnalyzer.CrashReason.Java版本过高:
						text = "游戏似乎因为你所使用的 Java 版本过高而崩溃了。\\n请在启动设置的 Java 选择一项中改用 JRE 8（Java 8），然后再启动游戏。\\n如果你没有安装 JRE 8，你可以从网络中下载、安装一个。";
						break;
					case ModCrash.CrashAnalyzer.CrashReason.Java版本过低:
						text = "游戏因为你所使用的 Java 版本过低而崩溃了。\\n请在启动设置的 Java 选择一项中改用适宜版本的 Java，然后再启动游戏。";
						break;
					case ModCrash.CrashAnalyzer.CrashReason.路径包含中文且存在编码问题导致找不到或无法加载主类:
						text = "由于游戏路径含有中文字符，且 Java 或系统编码存在错误，导致游戏无法运行。\\n\\n解决这一问题的最简单方法是检查游戏的完整路径，并删除各个文件夹名中的中文字符。\\n这包括了游戏的版本名、它所处的 .minecraft 文件夹及其之前的文件夹名。\\h";
						break;
					case ModCrash.CrashAnalyzer.CrashReason.玩家手动触发调试崩溃:
						text = "* 事实上，你的游戏没有任何问题，这是你自己触发的崩溃。\\n* 你难道没有更重要的事要做吗？";
						break;
					case ModCrash.CrashAnalyzer.CrashReason.光影或资源包导致OpenGL1282错误:
						text = "你所使用的光影或材质导致游戏出现了一些问题……\\n\\n请尝试删除你所添加的这些额外资源。\\h";
						break;
					case ModCrash.CrashAnalyzer.CrashReason.文件或内容校验失败:
						text = "部分文件或内容校验失败，导致游戏出现了问题。\\n\\n请尝试删除游戏（包括 Mod）并重新下载，或尝试在重新下载时使用 VPN。\\h";
						break;
					case ModCrash.CrashAnalyzer.CrashReason.确定Mod导致游戏崩溃:
						if (value.Count == 1)
						{
							text = "名称或 ID 为 " + value.First<string>() + " 的 Mod 导致了游戏出错。\\n\\e\\h";
						}
						else
						{
							text = "以下 Mod 导致了游戏出错：\\n - " + ModBase.Join(value, "\\n - ") + "\\n\\e\\h";
						}
						break;
					case ModCrash.CrashAnalyzer.CrashReason.Mod配置文件导致游戏崩溃:
						if (value[1] == null)
						{
							text = "名称或 ID 为 " + value.First<string>() + " 的 Mod 导致了游戏出错。\\n\\e\\h";
						}
						else
						{
							text = string.Concat(new string[]
							{
								"名称或 ID 为 ",
								value.First<string>(),
								" 的 Mod 导致了游戏出错：\\n其配置文件 ",
								value[1],
								" 存在异常，无法读取。"
							});
						}
						break;
					case ModCrash.CrashAnalyzer.CrashReason.Mod初始化失败:
						if (value.Count == 1)
						{
							text = "名为 " + value.First<string>() + " 的 Mod 初始化失败，导致游戏无法继续加载。\\n\\e\\h";
						}
						else
						{
							text = "以下 Mod 初始化失败，导致游戏无法继续加载：\\n - " + ModBase.Join(value, "\\n - ") + "\\n\\e\\h";
						}
						break;
					case ModCrash.CrashAnalyzer.CrashReason.崩溃日志堆栈分析发现关键字:
					case ModCrash.CrashAnalyzer.CrashReason.MC日志堆栈分析发现关键字:
						if (value.Count == 1)
						{
							text = "你的游戏遇到了一些问题，这可能是某些 Mod 所引起的，PCL2 找到了一个可疑的关键词：" + value.First<string>() + "。\\n\\n如果你知道它对应的 Mod，那么有可能就是它引起的错误，你也可以查看错误报告获取详情。\\h";
						}
						else
						{
							text = "你的游戏遇到了一些问题，这可能是某些 Mod 所引起的，PCL2 找到了以下可疑的关键词：\\n - " + ModBase.Join(value, ", ") + "\\n\\n如果你知道这些关键词对应的 Mod，那么有可能就是它引起的错误，你也可以查看错误报告获取详情。\\h";
						}
						break;
					case ModCrash.CrashAnalyzer.CrashReason.崩溃日志堆栈分析发现Mod名称:
						if (value.Count == 1)
						{
							text = "名为 " + value.First<string>() + " 的 Mod 可能导致了游戏出错。\\n\\e\\h";
						}
						else
						{
							text = "可能是以下 Mod 导致了游戏出错：\\n - " + ModBase.Join(value, "\\n - ") + "\\n\\e\\h";
						}
						break;
					case ModCrash.CrashAnalyzer.CrashReason.OptiFine导致无法加载世界:
						text = "你所使用的 OptiFine 可能导致了你的游戏出现问题。\\n\\n该问题只在特定 OptiFine 版本中出现，你可以尝试更换 OptiFine 的版本。\\h";
						break;
					case ModCrash.CrashAnalyzer.CrashReason.特定方块导致崩溃:
						if (value.Count == 1)
						{
							text = "游戏似乎因为方块 " + value.First<string>() + " 出现了问题。\\n\\n你可以创建一个新世界，并观察游戏的运行情况：\\n - 若正常运行，则是该方块导致出错，你或许需要使用一些方式删除此方块。\\n - 若仍然出错，问题就可能来自其他原因……\\h";
						}
						else
						{
							text = "游戏似乎因为世界中的某些方块出现了问题。\\n\\n你可以创建一个新世界，并观察游戏的运行情况：\\n - 若正常运行，则是某些方块导致出错，你或许需要删除该世界。\\n - 若仍然出错，问题就可能来自其他原因……\\h";
						}
						break;
					case ModCrash.CrashAnalyzer.CrashReason.特定实体导致崩溃:
						if (value.Count == 1)
						{
							text = "游戏似乎因为实体 " + value.First<string>() + " 出现了问题。\\n\\n你可以创建一个新世界，并生成一个该实体，然后观察游戏的运行情况：\\n - 若正常运行，则是该实体导致出错，你或许需要使用一些方式删除此实体。\\n - 若仍然出错，问题就可能来自其他原因……\\h";
						}
						else
						{
							text = "游戏似乎因为世界中的某些实体出现了问题。\\n\\n你可以创建一个新世界，并生成各种实体，观察游戏的运行情况：\\n - 若正常运行，则是某些实体导致出错，你或许需要删除该世界。\\n - 若仍然出错，问题就可能来自其他原因……\\h";
						}
						break;
					case ModCrash.CrashAnalyzer.CrashReason.材质过大或显卡配置不足:
						text = "你所使用的材质分辨率过高，或显卡配置不足，导致游戏无法继续运行。\\n\\n如果你正在使用高清材质，请将它移除。\\n如果你没有使用材质，那么你可能需要更新显卡驱动，或者换个更好的显卡……\\h";
						break;
					case ModCrash.CrashAnalyzer.CrashReason.没有可用的分析文件:
						text = "你的游戏出现了一些问题，但 PCL2 未能找到相关记录文件，因此无法进行分析。\\h";
						break;
					case ModCrash.CrashAnalyzer.CrashReason.使用32位Java导致JVM无法分配足够多的内存:
						if (Environment.Is64BitOperatingSystem)
						{
							text = "你似乎正在使用 32 位 Java，这会导致 Minecraft 无法使用 1GB 以上的内存，进而造成崩溃。\\n\\n请在启动设置的 Java 选择一项中改用 64 位的 Java 再启动游戏，然后再启动游戏。\\n如果你没有安装 64 位的 Java，你可以从网络中下载、安装一个。";
						}
						else
						{
							text = "你正在使用 32 位的操作系统，这会导致 Minecraft 无法使用 1GB 以上的内存，进而造成崩溃。\\n\\n你或许只能重装 64 位的操作系统来解决此问题。\\n如果你的电脑内存在 2GB 以内，那或许只能换台电脑了……\\h";
						}
						break;
					case ModCrash.CrashAnalyzer.CrashReason.Mod重复安装:
						if (value.Count >= 2)
						{
							text = "你重复安装了多个相同的 Mod：\\n - " + ModBase.Join(value, "\\n - ") + "\\n\\n每个 Mod 只能出现一次，请删除重复的 Mod，然后再启动游戏。";
						}
						else
						{
							text = "你可能重复安装了多个相同的 Mod，导致游戏无法继续加载。\\n\\n每个 Mod 只能出现一次，请删除重复的 Mod，然后再启动游戏。\\e\\h";
						}
						break;
					case ModCrash.CrashAnalyzer.CrashReason.Fabric报错:
						if (value.Count == 1)
						{
							text = "Fabric 提供了以下错误信息：\\n" + value.First<string>() + "\\n\\n请根据上述信息进行对应处理，如果看不懂英文可以使用翻译软件。";
						}
						else
						{
							text = "Fabric 可能已经提供了报错信息，请根据信息进行对应处理，如果看不懂英文可以使用翻译软件。\\n如果没有看到报错信息，可以查看错误报告了解错误具体是如何发生的。\\h";
						}
						break;
					case ModCrash.CrashAnalyzer.CrashReason.Forge报错:
						if (value.Count == 1)
						{
							text = "Forge 提供了以下错误信息：\\n" + value.First<string>() + "\\n\\n请根据上述信息进行对应处理，如果看不懂英文可以使用翻译软件。";
						}
						else
						{
							text = "Forge 可能已经提供了报错信息，请根据信息进行对应处理，如果看不懂英文可以使用翻译软件。\\n如果没有看到报错信息，可以查看错误报告了解错误具体是如何发生的。\\h";
						}
						break;
					default:
						text = "PCL2 获取到了没有详细信息的错误原因（" + Conversions.ToString((int)this.printerRule.First<KeyValuePair<ModCrash.CrashAnalyzer.CrashReason, List<string>>>().Key) + "），请向 PCL2 作者提交反馈以获取详情。\\h";
						break;
					}
					text = text.Replace("\\n", "\r\n").Replace("\\h", IsHandAnalyze ? "" : "\r\n如果要寻求帮助，请向他人发送错误报告文件，而不是发送这个窗口的截图。").Replace("\\e", IsHandAnalyze ? "" : "\r\n你可以查看错误报告了解错误具体是如何发生的。");
					result = text.Trim("\r\n".ToCharArray());
				}
				return result;
			}

			// Token: 0x0400010D RID: 269
			private string poolRule;

			// Token: 0x0400010E RID: 270
			private List<KeyValuePair<string, string[]>> _ParserRule;

			// Token: 0x0400010F RID: 271
			private string _ProxyRule;

			// Token: 0x04000110 RID: 272
			private string setterRule;

			// Token: 0x04000111 RID: 273
			private string merchantRule;

			// Token: 0x04000112 RID: 274
			private string eventRule;

			// Token: 0x04000113 RID: 275
			private Dictionary<ModCrash.CrashAnalyzer.CrashReason, List<string>> printerRule;

			// Token: 0x04000114 RID: 276
			private List<string> productRule;

			// Token: 0x02000058 RID: 88
			private enum AnalyzeFileType
			{
				// Token: 0x04000116 RID: 278
				HsErr,
				// Token: 0x04000117 RID: 279
				MinecraftLog,
				// Token: 0x04000118 RID: 280
				ExtraLog,
				// Token: 0x04000119 RID: 281
				CrashReport
			}

			// Token: 0x02000059 RID: 89
			private enum CrashReason
			{
				// Token: 0x0400011B RID: 283
				Mod文件被解压,
				// Token: 0x0400011C RID: 284
				内存不足,
				// Token: 0x0400011D RID: 285
				使用JDK,
				// Token: 0x0400011E RID: 286
				显卡不支持OpenGL,
				// Token: 0x0400011F RID: 287
				使用OpenJ9,
				// Token: 0x04000120 RID: 288
				Java版本过高,
				// Token: 0x04000121 RID: 289
				Java版本过低,
				// Token: 0x04000122 RID: 290
				显卡驱动不支持导致无法设置像素格式,
				// Token: 0x04000123 RID: 291
				路径包含中文且存在编码问题导致找不到或无法加载主类,
				// Token: 0x04000124 RID: 292
				Intel驱动不兼容导致EXCEPTION_ACCESS_VIOLATION,
				// Token: 0x04000125 RID: 293
				AMD驱动不兼容导致EXCEPTION_ACCESS_VIOLATION,
				// Token: 0x04000126 RID: 294
				Nvidia驱动不兼容导致EXCEPTION_ACCESS_VIOLATION,
				// Token: 0x04000127 RID: 295
				玩家手动触发调试崩溃,
				// Token: 0x04000128 RID: 296
				光影或资源包导致OpenGL1282错误,
				// Token: 0x04000129 RID: 297
				文件或内容校验失败,
				// Token: 0x0400012A RID: 298
				确定Mod导致游戏崩溃,
				// Token: 0x0400012B RID: 299
				Mod配置文件导致游戏崩溃,
				// Token: 0x0400012C RID: 300
				Mod初始化失败,
				// Token: 0x0400012D RID: 301
				崩溃日志堆栈分析发现关键字,
				// Token: 0x0400012E RID: 302
				崩溃日志堆栈分析发现Mod名称,
				// Token: 0x0400012F RID: 303
				MC日志堆栈分析发现关键字,
				// Token: 0x04000130 RID: 304
				OptiFine导致无法加载世界,
				// Token: 0x04000131 RID: 305
				特定方块导致崩溃,
				// Token: 0x04000132 RID: 306
				特定实体导致崩溃,
				// Token: 0x04000133 RID: 307
				材质过大或显卡配置不足,
				// Token: 0x04000134 RID: 308
				没有可用的分析文件,
				// Token: 0x04000135 RID: 309
				使用32位Java导致JVM无法分配足够多的内存,
				// Token: 0x04000136 RID: 310
				Mod重复安装,
				// Token: 0x04000137 RID: 311
				Fabric报错,
				// Token: 0x04000138 RID: 312
				Forge报错
			}
		}
	}
}
