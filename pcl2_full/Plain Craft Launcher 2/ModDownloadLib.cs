using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCL.My;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace PCL
{
	// Token: 0x02000068 RID: 104
	[StandardModule]
	public sealed class ModDownloadLib
	{
		// Token: 0x060002C6 RID: 710 RVA: 0x00003BC6 File Offset: 0x00001DC6
		// Note: this type is marked as 'beforefieldinit'.
		static ModDownloadLib()
		{
			ModDownloadLib.m_PoolVal = false;
			ModDownloadLib.parserVal = false;
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0001B144 File Offset: 0x00019344
		public static ModLoader.LoaderCombo<string> McDownloadClient(ModNet.NetPreDownloadBehaviour Behaviour, string Id, string JsonUrl = null)
		{
			checked
			{
				ModLoader.LoaderCombo<string> result;
				try
				{
					string text = ModMinecraft.m_ResolverIterator + "versions\\" + Id + "\\";
					object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
					ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
					lock (loaderTaskbarLock)
					{
						int num = ModLoader.LoaderTaskbar.Count - 1;
						int i = 0;
						while (i <= num)
						{
							if (!Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(ModLoader.LoaderTaskbar[i], null, "Name", new object[0], null, null, null), "Minecraft " + Id + " 下载", true))
							{
								i++;
							}
							else
							{
								if (Behaviour == ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading)
								{
									return (ModLoader.LoaderCombo<string>)ModLoader.LoaderTaskbar[i];
								}
								ModMain.Hint("该版本正在下载中！", ModMain.HintType.Critical, true);
								return (ModLoader.LoaderCombo<string>)ModLoader.LoaderTaskbar[i];
							}
						}
					}
					if (Behaviour != ModNet.NetPreDownloadBehaviour.IgnoreCheck && File.Exists(text + Id + ".json") && File.Exists(text + Id + ".jar"))
					{
						if (Behaviour == ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading)
						{
							return null;
						}
						if (ModMain.MyMsgBox("版本 " + Id + " 已存在，是否重新下载？\r\n这会覆盖版本的 Json 与 Jar 文件，但不会影响版本隔离的文件。", "版本已存在", "继续", "取消", "", false, true, false) != 1)
						{
							return null;
						}
						File.Delete(text + Id + ".jar");
						File.Delete(text + Id + ".json");
					}
					ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("Minecraft " + Id + " 下载", ModDownloadLib.McDownloadClientLoader(Id, JsonUrl, null));
					loaderCombo.OnStateChanged = new ModLoader.LoaderStateDelegate(ModDownloadLib.McInstallState);
					loaderCombo.Start(text, false);
					ModLoader.LoaderTaskbarAdd(loaderCombo);
					ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
					ModMain.m_GetterFilter.BtnExtraDownload.Ribble();
					result = loaderCombo;
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "开始 Minecraft 下载失败", ModBase.LogLevel.Feedback, "出现错误");
					result = null;
				}
				return result;
			}
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0001B368 File Offset: 0x00019568
		public static void McDownloadClientCore(string Id, string JsonUrl, ModNet.NetPreDownloadBehaviour Behaviour)
		{
			checked
			{
				try
				{
					ModDownloadLib._Closure$__2-0 CS$<>8__locals1 = new ModDownloadLib._Closure$__2-0(CS$<>8__locals1);
					CS$<>8__locals1.$VB$Local_VersionFolder = ModBase.SelectFolder("选择文件夹");
					if (CS$<>8__locals1.$VB$Local_VersionFolder.Contains("\\"))
					{
						CS$<>8__locals1.$VB$Local_VersionFolder = CS$<>8__locals1.$VB$Local_VersionFolder + Id + "\\";
						object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
						ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
						lock (loaderTaskbarLock)
						{
							int num = ModLoader.LoaderTaskbar.Count - 1;
							int i = 0;
							while (i <= num)
							{
								if (!Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(ModLoader.LoaderTaskbar[i], null, "Name", new object[0], null, null, null), "Minecraft " + Id + " 下载", true))
								{
									i++;
								}
								else
								{
									if (Behaviour == ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading)
									{
										return;
									}
									ModMain.Hint("该版本正在下载中！", ModMain.HintType.Critical, true);
									return;
								}
							}
						}
						ArrayList arrayList = new ArrayList();
						arrayList.Add(new ModNet.LoaderDownload("下载版本 Json 文件", new List<ModNet.NetFile>
						{
							new ModNet.NetFile(ModDownload.DlSourceLauncherOrMetaGet(JsonUrl, true), CS$<>8__locals1.$VB$Local_VersionFolder + Id + ".json", new ModBase.FileChecker(-1L, -1L, null, null, false, true))
						})
						{
							ProgressWeight = 2.0
						});
						arrayList.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析核心 Jar 文件下载地址", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
						{
							Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McVersion(CS$<>8__locals1.$VB$Local_VersionFolder), true);
						}, null, ThreadPriority.Normal)
						{
							ProgressWeight = 0.5,
							Show = false
						});
						arrayList.Add(new ModNet.LoaderDownload("下载核心 Jar 文件", new List<ModNet.NetFile>())
						{
							ProgressWeight = 5.0
						});
						ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("Minecraft " + Id + " 下载", arrayList);
						loaderCombo.OnStateChanged = new ModLoader.LoaderStateDelegate(ModDownloadLib.DownloadStateSave);
						loaderCombo.Start(Id, false);
						ModLoader.LoaderTaskbarAdd(loaderCombo);
						ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
						ModMain.m_GetterFilter.BtnExtraDownload.Ribble();
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "开始 Minecraft 下载失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0001B5BC File Offset: 0x000197BC
		private static ArrayList McDownloadClientLoader(string Id, string JsonUrl = null, string VersionName = null)
		{
			VersionName = (VersionName ?? Id);
			string VersionFolder = ModMinecraft.m_ResolverIterator + "versions\\" + VersionName + "\\";
			ArrayList arrayList = new ArrayList();
			if (JsonUrl == null)
			{
				arrayList.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("获取原版 Json 文件下载地址", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
				{
					string mojangBase = Conversions.ToString(ModDownload.DlClientListGet(Id));
					Task.Output = new List<ModNet.NetFile>
					{
						new ModNet.NetFile(ModDownload.DlSourceLauncherOrMetaGet(mojangBase, true), VersionFolder + VersionName + ".json", null)
					};
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 2.0,
					Show = false
				});
			}
			arrayList.Add(new ModNet.LoaderDownload("下载原版 Json 文件", new List<ModNet.NetFile>
			{
				new ModNet.NetFile(ModDownload.DlSourceLauncherOrMetaGet(JsonUrl ?? "", true), VersionFolder + VersionName + ".json", new ModBase.FileChecker(-1L, -1L, null, null, false, true))
			})
			{
				ProgressWeight = 3.0
			});
			arrayList.Add(new ModLoader.LoaderCombo<string>("下载原版支持库文件", new ArrayList
			{
				new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析原版支持库文件（副加载器）", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
				{
					Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McVersion(VersionFolder), false);
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 1.0,
					Show = false
				},
				new ModNet.LoaderDownload("下载原版支持库文件（副加载器）", new List<ModNet.NetFile>())
				{
					ProgressWeight = 13.0,
					Show = false
				}
			})
			{
				Block = false,
				ProgressWeight = 14.0
			});
			arrayList.Add(new ModLoader.LoaderCombo<string>("下载原版资源文件", new ArrayList
			{
				new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析资源文件索引地址（副加载器）", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
				{
					try
					{
						ModMinecraft.McVersion version = new ModMinecraft.McVersion(VersionFolder);
						Task.Output = new List<ModNet.NetFile>
						{
							ModDownload.DlClientAssetIndexGet(version)
						};
					}
					catch (Exception innerException)
					{
						throw new Exception("分析资源文件索引地址失败", innerException);
					}
					try
					{
						JObject jobject = (JObject)ModBase.GetJson(ModBase.ReadFile(VersionFolder + VersionName + ".json"));
						jobject.Add("clientVersion", Id);
						ModBase.WriteFile(VersionFolder + VersionName + ".json", jobject.ToString(), false, null);
					}
					catch (Exception innerException2)
					{
						throw new Exception("添加客户端版本失败", innerException2);
					}
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 1.0,
					Show = false
				},
				new ModNet.LoaderDownload("下载资源文件索引（副加载器）", new List<ModNet.NetFile>())
				{
					ProgressWeight = 3.0,
					Show = false
				},
				new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析所需资源文件（副加载器）", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
				{
					ModLoader.LoaderTask<string, List<ModNet.NetFile>> loaderTask = Task;
					string indexAddress = ModMinecraft.McAssetsGetIndexName(new ModMinecraft.McVersion(VersionFolder));
					bool checkHash = true;
					ModLoader.LoaderBase<string> loaderBase = Task;
					List<ModNet.NetFile> output = ModMinecraft.McAssetsFixList<string>(indexAddress, checkHash, ref loaderBase);
					Task = (ModLoader.LoaderTask<string, List<ModNet.NetFile>>)loaderBase;
					loaderTask.Output = output;
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 3.0,
					Show = false
				},
				new ModNet.LoaderDownload("下载资源文件（副加载器）", new List<ModNet.NetFile>())
				{
					ProgressWeight = 14.0,
					Show = false
				}
			})
			{
				Block = false,
				ProgressWeight = 21.0
			});
			return arrayList;
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0001B844 File Offset: 0x00019A44
		public static MyListItem McDownloadListItem(JObject Entry, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
		{
			JToken value = Entry["type"];
			string logo;
			if ((string)value == "release")
			{
				logo = "pack://application:,,,/images/Blocks/Grass.png";
			}
			else if ((string)value == "snapshot")
			{
				logo = "pack://application:,,,/images/Blocks/CommandBlock.png";
			}
			else if ((string)value == "special")
			{
				logo = "pack://application:,,,/images/Blocks/GoldBlock.png";
			}
			else
			{
				logo = "pack://application:,,,/images/Blocks/CobbleStone.png";
			}
			MyListItem myListItem = new MyListItem
			{
				Logo = logo,
				SnapsToDevicePixels = true,
				Title = Entry["id"].ToString(),
				Height = 42.0,
				Type = MyListItem.CheckType.Clickable,
				Tag = Entry,
				PaddingRight = 0x3C
			};
			if (Entry["lore"] == null)
			{
				myListItem.Info = Entry["releaseTime"].Value<DateTime>().ToString("yyyy/MM/dd");
			}
			else
			{
				myListItem.Info = Entry["lore"].ToString();
			}
			if (Entry["url"].ToString().Contains("pcl"))
			{
				myListItem.Info = "[PCL2 特别提供] " + myListItem.Info;
			}
			myListItem.QueryModel(OnClick);
			if (IsSaveOnly)
			{
				myListItem.utilsDecorator = new ModBase.EventDelegate(ModDownloadLib.McDownloadSaveMenuBuild);
			}
			else
			{
				myListItem.utilsDecorator = new ModBase.EventDelegate(ModDownloadLib.McDownloadMenuBuild);
			}
			return myListItem;
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0001B9AC File Offset: 0x00019BAC
		private static void McDownloadSaveMenuBuild(object sender, EventArgs e)
		{
			MyIconButton myIconButton = new MyIconButton
			{
				LogoScale = 1.05,
				Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z",
				ToolTip = "更新日志"
			};
			ToolTipService.SetPlacement(myIconButton, PlacementMode.Center);
			ToolTipService.SetVerticalOffset(myIconButton, 30.0);
			ToolTipService.SetHorizontalOffset(myIconButton, 2.0);
			myIconButton.Click += ((ModDownloadLib._Closure$__.$IR6-1 == null) ? (ModDownloadLib._Closure$__.$IR6-1 = delegate(object sender, EventArgs e)
			{
				ModDownloadLib.McDownloadMenuLog(RuntimeHelpers.GetObjectValue(sender), (RoutedEventArgs)e);
			}) : ModDownloadLib._Closure$__.$IR6-1);
			NewLateBinding.LateSet(sender2, null, "Buttons", new object[]
			{
				new MyIconButton[]
				{
					myIconButton
				}
			}, null, null);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0001BA54 File Offset: 0x00019C54
		private static void McDownloadMenuBuild(object sender, EventArgs e)
		{
			MyIconButton myIconButton = new MyIconButton
			{
				Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z",
				ToolTip = "另存为"
			};
			ToolTipService.SetPlacement(myIconButton, PlacementMode.Center);
			ToolTipService.SetVerticalOffset(myIconButton, 30.0);
			ToolTipService.SetHorizontalOffset(myIconButton, 2.0);
			myIconButton.Click += ((ModDownloadLib._Closure$__.$IR7-2 == null) ? (ModDownloadLib._Closure$__.$IR7-2 = delegate(object sender, EventArgs e)
			{
				ModDownloadLib.McDownloadMenuSave(RuntimeHelpers.GetObjectValue(sender), (RoutedEventArgs)e);
			}) : ModDownloadLib._Closure$__.$IR7-2);
			MyIconButton myIconButton2 = new MyIconButton
			{
				LogoScale = 1.05,
				Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z",
				ToolTip = "更新日志"
			};
			ToolTipService.SetPlacement(myIconButton2, PlacementMode.Center);
			ToolTipService.SetVerticalOffset(myIconButton2, 30.0);
			ToolTipService.SetHorizontalOffset(myIconButton2, 2.0);
			myIconButton2.Click += ((ModDownloadLib._Closure$__.$IR7-3 == null) ? (ModDownloadLib._Closure$__.$IR7-3 = delegate(object sender, EventArgs e)
			{
				ModDownloadLib.McDownloadMenuLog(RuntimeHelpers.GetObjectValue(sender), (RoutedEventArgs)e);
			}) : ModDownloadLib._Closure$__.$IR7-3);
			NewLateBinding.LateSet(sender2, null, "Buttons", new object[]
			{
				new MyIconButton[]
				{
					myIconButton,
					myIconButton2
				}
			}, null, null);
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0001BB6C File Offset: 0x00019D6C
		private static void McDownloadMenuLog(object sender, RoutedEventArgs e)
		{
			JToken versionJson;
			if (NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) != null)
			{
				versionJson = (JToken)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null);
			}
			else if (NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null) != null)
			{
				versionJson = (JToken)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null);
			}
			else
			{
				versionJson = (JToken)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null);
			}
			ModDownloadLib.McUpdateLogShow(versionJson);
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0001BC58 File Offset: 0x00019E58
		public static void McDownloadMenuSave(MyListItem sender, RoutedEventArgs e)
		{
			MyListItem myListItem;
			if (sender is MyListItem)
			{
				myListItem = (MyListItem)sender;
			}
			else if (NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null) is MyListItem)
			{
				myListItem = (MyListItem)NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null);
			}
			else
			{
				myListItem = (MyListItem)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Parent", new object[0], null, null, null);
			}
			ModDownloadLib.McDownloadClientCore(myListItem.Title, NewLateBinding.LateIndexGet(myListItem.Tag, new object[]
			{
				"url"
			}, null).ToString(), ModNet.NetPreDownloadBehaviour.HintWhileExists);
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0001BD0C File Offset: 0x00019F0C
		public static void McUpdateLogShow(JToken VersionJson)
		{
			string text = VersionJson["id"].ToString().ToLower();
			string text2;
			if (Operators.CompareString(text, "3d shareware v1.34", true) == 0)
			{
				text2 = "3D_Shareware_v1.34";
			}
			else if (Operators.CompareString(text, "2.0", true) == 0)
			{
				text2 = "Java版2.0";
			}
			else if (Operators.CompareString(text, "1.rv-pre1", true) == 0)
			{
				text2 = "Java版1.RV-Pre1";
			}
			else if (Operators.CompareString(text, "combat test 1", true) != 0 && !text.Contains("combat-1") && !text.Contains("combat-212796"))
			{
				if (Operators.CompareString(text, "combat test 2", true) != 0 && !text.Contains("combat-2") && !text.Contains("combat-0"))
				{
					if (Operators.CompareString(text, "combat test 3", true) != 0 && Operators.CompareString(text, "1.14_combat-3", true) != 0)
					{
						if (Operators.CompareString(text, "combat test 4", true) != 0 && Operators.CompareString(text, "1.15_combat-1", true) != 0)
						{
							if (Operators.CompareString(text, "combat test 5", true) != 0 && Operators.CompareString(text, "1.15_combat-6", true) != 0)
							{
								if (Operators.CompareString(text, "combat test 6", true) != 0 && Operators.CompareString(text, "1.16_combat-0", true) != 0)
								{
									if (Operators.CompareString(text, "combat test 7c", true) != 0 && Operators.CompareString(text, "1.16_combat-3", true) != 0)
									{
										if (Operators.CompareString(text, "combat test 8b", true) != 0 && Operators.CompareString(text, "1.16_combat-5", true) != 0)
										{
											if (Operators.CompareString(text, "combat test 8c", true) != 0 && Operators.CompareString(text, "1.16_combat-6", true) != 0)
											{
												if (Operators.CompareString(text, "1.0.0-rc2-2", true) == 0)
												{
													text2 = "Java版RC2";
												}
												else if (Operators.CompareString(text, "b1.9-pre6", true) == 0)
												{
													text2 = "Java版Beta_1.9_Prerelease_6";
												}
												else if (text.Contains("b1.9"))
												{
													text2 = "Java版Beta_1.9_Prerelease";
												}
												else if (!((string)VersionJson["type"] == "release") && !((string)VersionJson["type"] == "snapshot") && !((string)VersionJson["type"] == "special"))
												{
													if (text.StartsWith("b"))
													{
														text2 = "Java版" + text.TrimEnd(new char[]
														{
															'a',
															'b',
															'c',
															'd',
															'e'
														}).Replace("b", "Beta_");
													}
													else if (text.StartsWith("a"))
													{
														text2 = "Java版" + text.TrimEnd(new char[]
														{
															'a',
															'b',
															'c',
															'd',
															'e'
														}).Replace("a", "Alpha_v");
													}
													else if (Operators.CompareString(text, "inf-20100618", true) == 0)
													{
														text2 = "Java版Infdev_20100618";
													}
													else if (Operators.CompareString(text, "c0.30_01c", true) != 0 && Operators.CompareString(text, "c0.30_survival", true) != 0 && !text.Contains("生存测试"))
													{
														if (Operators.CompareString(text, "c0.31", true) == 0)
														{
															text2 = "Java版Indev_0.31（2010年1月30日）";
														}
														else if (text.StartsWith("c"))
														{
															text2 = "Java版" + text.Replace("c", "Classic_");
														}
														else
														{
															if (!text.StartsWith("rd-"))
															{
																ModBase.Log("[Error] 未知的版本格式：" + text + "。", ModBase.LogLevel.Feedback, "出现错误");
																return;
															}
															text2 = "Java版Pre-classic_" + text;
														}
													}
													else
													{
														text2 = "Java版Classic_0.30（生存模式）";
													}
												}
												else
												{
													text2 = (text.Contains("w") ? "" : "Java版") + text.Replace(" Pre-Release ", "-pre");
												}
											}
											else
											{
												text2 = "Java版Combat_Test_8c";
											}
										}
										else
										{
											text2 = "Java版Combat_Test_8b";
										}
									}
									else
									{
										text2 = "Java版Combat_Test_7c";
									}
								}
								else
								{
									text2 = "Java版Combat_Test_6";
								}
							}
							else
							{
								text2 = "Java版Combat_Test_5";
							}
						}
						else
						{
							text2 = "Java版Combat_Test_4";
						}
					}
					else
					{
						text2 = "Java版Combat_Test_3";
					}
				}
				else
				{
					text2 = "Java版Combat_Test_2";
				}
			}
			else
			{
				text2 = "Java版1.14.3_-_Combat_Test";
			}
			ModBase.OpenWebsite("https://minecraft-zh.gamepedia.com/" + text2.Replace("_experimental-snapshot-", "-exp"));
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0001C160 File Offset: 0x0001A360
		public static void McDownloadOptiFine(ModDownload.DlOptiFineListEntry DownloadInfo)
		{
			checked
			{
				try
				{
					string proccesorAlgo = DownloadInfo.m_ProccesorAlgo;
					string text = ModMinecraft.m_ResolverIterator + "versions\\" + proccesorAlgo + "\\";
					if (ModBase.Val(DownloadInfo.SetExpression().Split(new char[]
					{
						'.'
					})[1]) < 14.0)
					{
						string.Concat(new string[]
						{
							ModMinecraft.m_ResolverIterator,
							"libraries\\optifine\\OptiFine\\",
							DownloadInfo.m_SystemAlgo.Replace("OptiFine_", "").Replace(".jar", "").Replace("preview_", ""),
							"\\",
							DownloadInfo.m_SystemAlgo.Replace("OptiFine_", "OptiFine-").Replace("preview_", "")
						});
					}
					else
					{
						string.Concat(new string[]
						{
							ModBase.m_GlobalRule,
							"Cache\\Code\\",
							DownloadInfo.m_ProccesorAlgo,
							"_",
							Conversions.ToString(ModBase.GetUuid())
						});
					}
					object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
					ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
					lock (loaderTaskbarLock)
					{
						int num = ModLoader.LoaderTaskbar.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(ModLoader.LoaderTaskbar[i], null, "Name", new object[0], null, null, null), "OptiFine " + DownloadInfo.m_RepositoryAlgo + " 下载", true))
							{
								ModMain.Hint("该版本正在下载中！", ModMain.HintType.Critical, true);
								return;
							}
						}
					}
					if (File.Exists(text + proccesorAlgo + ".json"))
					{
						if (ModMain.MyMsgBox("版本 " + proccesorAlgo + " 已存在，是否重新下载？\r\n这会覆盖版本的 Json 文件，但不会影响版本隔离的文件。", "版本已存在", "继续", "取消", "", false, true, false) != 1)
						{
							return;
						}
						File.Delete(text + proccesorAlgo + ".jar");
						File.Delete(text + proccesorAlgo + ".json");
					}
					ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("OptiFine " + DownloadInfo.m_RepositoryAlgo + " 下载", ModDownloadLib.McDownloadOptiFineLoader(DownloadInfo, null, null, true));
					loaderCombo.OnStateChanged = new ModLoader.LoaderStateDelegate(ModDownloadLib.McInstallState);
					loaderCombo.Start(text, false);
					ModLoader.LoaderTaskbarAdd(loaderCombo);
					ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
					ModMain.m_GetterFilter.BtnExtraDownload.Ribble();
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "开始 OptiFine 下载失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0001C428 File Offset: 0x0001A628
		private static void McDownloadOptiFineSave(ModDownload.DlOptiFineListEntry DownloadInfo)
		{
			checked
			{
				try
				{
					string text = ModBase.SelectAs("选择保存位置", DownloadInfo.m_SystemAlgo, "OptiFine Jar (*.jar)|*.jar", null);
					if (text.Contains("\\"))
					{
						object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
						ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
						lock (loaderTaskbarLock)
						{
							int num = ModLoader.LoaderTaskbar.Count - 1;
							for (int i = 0; i <= num; i++)
							{
								if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(ModLoader.LoaderTaskbar[i], null, "Name", new object[0], null, null, null), "OptiFine " + DownloadInfo.m_RepositoryAlgo + " 下载", true))
								{
									ModMain.Hint("该版本正在下载中！", ModMain.HintType.Critical, true);
									return;
								}
							}
						}
						ModLoader.LoaderCombo<ModDownload.DlOptiFineListEntry> loaderCombo = new ModLoader.LoaderCombo<ModDownload.DlOptiFineListEntry>("OptiFine " + DownloadInfo.m_RepositoryAlgo + " 下载", ModDownloadLib.McDownloadOptiFineSaveLoader(DownloadInfo, text));
						loaderCombo.OnStateChanged = new ModLoader.LoaderStateDelegate(ModDownloadLib.DownloadStateSave);
						loaderCombo.Start(DownloadInfo, false);
						ModLoader.LoaderTaskbarAdd(loaderCombo);
						ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
						ModMain.m_GetterFilter.BtnExtraDownload.Ribble();
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "开始 OptiFine 下载失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0001C5A0 File Offset: 0x0001A7A0
		private static void McDownloadOptiFineInstall(string BaseMcFolderHome, string Target, ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task)
		{
			ModDownloadLib._Closure$__13-2 CS$<>8__locals1 = new ModDownloadLib._Closure$__13-2(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_Task = Task;
			ModMinecraft.JavaEntry javaEntry = ModMinecraft.JavaSelect(new Version(1, 8, 0, 0), null, null);
			if (javaEntry == null)
			{
				ModMinecraft.JavaMissing(8);
				throw new Exception("未找到用于安装 OptiFine 的 Java");
			}
			ProcessStartInfo processStartInfo = new ProcessStartInfo
			{
				FileName = javaEntry.DisableExpression(),
				Arguments = string.Concat(new string[]
				{
					"-Duser.home=\"",
					BaseMcFolderHome,
					"\" -cp \"",
					Target,
					"\" optifine.Installer"
				}),
				UseShellExecute = false,
				CreateNoWindow = true,
				RedirectStandardError = true,
				RedirectStandardOutput = true,
				WorkingDirectory = BaseMcFolderHome
			};
			if (processStartInfo.EnvironmentVariables.ContainsKey("appdata"))
			{
				processStartInfo.EnvironmentVariables["appdata"] = BaseMcFolderHome;
			}
			else
			{
				processStartInfo.EnvironmentVariables.Add("appdata", BaseMcFolderHome);
			}
			ModBase.Log("[Download] 开始安装 OptiFine：" + Target, ModBase.LogLevel.Normal, "出现错误");
			CS$<>8__locals1.$VB$Local_TotalLength = 0;
			using (Process process = new Process
			{
				StartInfo = processStartInfo
			})
			{
				ModDownloadLib._Closure$__13-1 CS$<>8__locals2 = new ModDownloadLib._Closure$__13-1(CS$<>8__locals2);
				CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2 = CS$<>8__locals1;
				CS$<>8__locals2.$VB$Local_LastResult = "";
				ModDownloadLib._Closure$__13-0 CS$<>8__locals3 = new ModDownloadLib._Closure$__13-0(CS$<>8__locals3);
				CS$<>8__locals3.$VB$NonLocal_$VB$Closure_3 = CS$<>8__locals2;
				CS$<>8__locals3.$VB$Local_outputWaitHandle = new AutoResetEvent(false);
				try
				{
					ModDownloadLib._Closure$__13-3 CS$<>8__locals4 = new ModDownloadLib._Closure$__13-3(CS$<>8__locals4);
					CS$<>8__locals4.$VB$NonLocal_$VB$Closure_4 = CS$<>8__locals3;
					CS$<>8__locals4.$VB$Local_errorWaitHandle = new AutoResetEvent(false);
					try
					{
						process.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e)
						{
							base._Lambda$__0(RuntimeHelpers.GetObjectValue(sender), e);
						};
						process.ErrorDataReceived += delegate(object sender, DataReceivedEventArgs e)
						{
							base._Lambda$__1(RuntimeHelpers.GetObjectValue(sender), e);
						};
						process.Start();
						process.BeginOutputReadLine();
						process.BeginErrorReadLine();
						while (!process.HasExited)
						{
							if (CS$<>8__locals4.$VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_Task.IsAborted)
							{
								ModBase.Log("[Installer] 由于任务取消，OptiFine 安装已中止", ModBase.LogLevel.Normal, "出现错误");
								process.Kill();
							}
							Thread.Sleep(0xA);
						}
						CS$<>8__locals4.$VB$NonLocal_$VB$Closure_4.$VB$Local_outputWaitHandle.WaitOne(0x2710);
						CS$<>8__locals4.$VB$Local_errorWaitHandle.WaitOne(0x2710);
						if (CS$<>8__locals4.$VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_TotalLength < 0x3E8)
						{
							throw new Exception("安装器运行出错，末行为 " + CS$<>8__locals4.$VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$Local_LastResult);
						}
					}
					finally
					{
						if (CS$<>8__locals4.$VB$Local_errorWaitHandle != null)
						{
							((IDisposable)CS$<>8__locals4.$VB$Local_errorWaitHandle).Dispose();
						}
					}
				}
				finally
				{
					if (CS$<>8__locals3.$VB$Local_outputWaitHandle != null)
					{
						((IDisposable)CS$<>8__locals3.$VB$Local_outputWaitHandle).Dispose();
					}
				}
			}
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0001C87C File Offset: 0x0001AA7C
		private static ArrayList McDownloadOptiFineLoader(ModDownload.DlOptiFineListEntry DownloadInfo, string McFolder = null, ModLoader.LoaderCombo<string> ClientDownloadLoader = null, bool FixLibrary = true)
		{
			ModDownloadLib._Closure$__14-0 CS$<>8__locals1 = new ModDownloadLib._Closure$__14-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_DownloadInfo = DownloadInfo;
			CS$<>8__locals1.$VB$Local_McFolder = McFolder;
			CS$<>8__locals1.$VB$Local_ClientDownloadLoader = ClientDownloadLoader;
			CS$<>8__locals1.$VB$Local_McFolder = (CS$<>8__locals1.$VB$Local_McFolder ?? ModMinecraft.m_ResolverIterator);
			CS$<>8__locals1.$VB$Local_IsCustomFolder = (Operators.CompareString(CS$<>8__locals1.$VB$Local_McFolder, ModMinecraft.m_ResolverIterator, true) != 0);
			CS$<>8__locals1.$VB$Local_Id = CS$<>8__locals1.$VB$Local_DownloadInfo.m_ProccesorAlgo;
			CS$<>8__locals1.$VB$Local_VersionFolder = CS$<>8__locals1.$VB$Local_McFolder + "versions\\" + CS$<>8__locals1.$VB$Local_Id + "\\";
			bool flag = CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression().Contains("w") || ModBase.Val(CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression().Split(new char[]
			{
				'.'
			})[1]) >= 14.0;
			CS$<>8__locals1.$VB$Local_Target = (flag ? string.Concat(new string[]
			{
				ModBase.m_GlobalRule,
				"Cache\\Code\\",
				CS$<>8__locals1.$VB$Local_DownloadInfo.m_ProccesorAlgo,
				"_",
				Conversions.ToString(ModBase.GetUuid())
			}) : string.Concat(new string[]
			{
				CS$<>8__locals1.$VB$Local_McFolder,
				"libraries\\optifine\\OptiFine\\",
				CS$<>8__locals1.$VB$Local_DownloadInfo.m_SystemAlgo.Replace("OptiFine_", "").Replace(".jar", "").Replace("preview_", ""),
				"\\",
				CS$<>8__locals1.$VB$Local_DownloadInfo.m_SystemAlgo.Replace("OptiFine_", "OptiFine-").Replace("preview_", "")
			}));
			ArrayList arrayList = new ArrayList();
			arrayList.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("获取 OptiFine 主文件下载地址", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
			{
				if (CS$<>8__locals1.$VB$Local_ClientDownloadLoader == null)
				{
					if (CS$<>8__locals1.$VB$Local_IsCustomFolder)
					{
						throw new Exception("如果没有指定原版下载器，则不能指定 MC 安装文件夹");
					}
					CS$<>8__locals1.$VB$Local_ClientDownloadLoader = ModDownloadLib.McDownloadClient(ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading, CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(), null);
				}
				Task.Progress = 0.1;
				List<string> list = new List<string>();
				if (CS$<>8__locals1.$VB$Local_DownloadInfo.m_PrototypeAlgo)
				{
					list.Add("https://download.mcbbs.net/optifine/" + CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression() + "/HD_U_" + CS$<>8__locals1.$VB$Local_DownloadInfo.m_RepositoryAlgo.Replace(CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression() + " ", "").Replace(" ", "/"));
					list.Add("https://bmclapi2.bangbang93.com/optifine/" + CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression() + "/HD_U_" + CS$<>8__locals1.$VB$Local_DownloadInfo.m_RepositoryAlgo.Replace(CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression() + " ", "").Replace(" ", "/"));
				}
				else
				{
					list.Add("https://download.mcbbs.net/optifine/" + CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression() + "/HD_U/" + CS$<>8__locals1.$VB$Local_DownloadInfo.m_RepositoryAlgo.Replace(CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression() + " ", ""));
					list.Add("https://bmclapi2.bangbang93.com/optifine/" + CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression() + "/HD_U/" + CS$<>8__locals1.$VB$Local_DownloadInfo.m_RepositoryAlgo.Replace(CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression() + " ", ""));
				}
				try
				{
					string str = ModNet.NetGetCodeByClient("https://optifine.net/adloadx?f=" + CS$<>8__locals1.$VB$Local_DownloadInfo.m_SystemAlgo, new UTF8Encoding(false), 0x3A98, "text/html");
					Task.Progress = 0.8;
					list.Add("https://optifine.net/" + ModBase.RegexSearch(str, "downloadx\\?f=[^\"']+", RegexOptions.None)[0]);
					ModBase.Log("[Download] OptiFine " + CS$<>8__locals1.$VB$Local_DownloadInfo.m_RepositoryAlgo + " 官方下载地址：" + list[0], ModBase.LogLevel.Normal, "出现错误");
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "获取 OptiFine " + CS$<>8__locals1.$VB$Local_DownloadInfo.m_RepositoryAlgo + " 官方下载地址失败", ModBase.LogLevel.Debug, "出现错误");
				}
				Task.Progress = 0.9;
				list.Add("https://optifine.cn/download/" + CS$<>8__locals1.$VB$Local_DownloadInfo.m_SystemAlgo);
				Task.Output = new List<ModNet.NetFile>
				{
					new ModNet.NetFile(list.ToArray(), CS$<>8__locals1.$VB$Local_Target, new ModBase.FileChecker(0x10000L, -1L, null, null, true, false))
				};
			}, null, ThreadPriority.Normal)
			{
				ProgressWeight = 8.0
			});
			arrayList.Add(new ModNet.LoaderDownload("下载 OptiFine 主文件", new List<ModNet.NetFile>())
			{
				ProgressWeight = 8.0
			});
			arrayList.Add(new ModLoader.LoaderTask<List<ModNet.NetFile>, bool>("等待原版下载", delegate(ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task)
			{
				if (CS$<>8__locals1.$VB$Local_ClientDownloadLoader != null)
				{
					try
					{
						foreach (object obj in CS$<>8__locals1.$VB$Local_ClientDownloadLoader.GetLoaderList(true))
						{
							object objectValue = RuntimeHelpers.GetObjectValue(obj);
							if (!Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null), "下载原版支持库文件", true))
							{
								NewLateBinding.LateCall(objectValue, null, "WaitForExit", new object[0], null, null, null, true);
								break;
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
					if (CS$<>8__locals1.$VB$Local_IsCustomFolder)
					{
						try
						{
							string name = new DirectoryInfo(CS$<>8__locals1.$VB$Local_ClientDownloadLoader.Input).Name;
							Directory.CreateDirectory(CS$<>8__locals1.$VB$Local_McFolder + "versions\\" + CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression());
							if (!File.Exists(string.Concat(new string[]
							{
								CS$<>8__locals1.$VB$Local_McFolder,
								"versions\\",
								CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
								"\\",
								CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
								".json"
							})))
							{
								File.Copy(CS$<>8__locals1.$VB$Local_ClientDownloadLoader.Input + name + ".json", string.Concat(new string[]
								{
									CS$<>8__locals1.$VB$Local_McFolder,
									"versions\\",
									CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
									"\\",
									CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
									".json"
								}));
							}
							if (!File.Exists(string.Concat(new string[]
							{
								CS$<>8__locals1.$VB$Local_McFolder,
								"versions\\",
								CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
								"\\",
								CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
								".jar"
							})))
							{
								File.Copy(CS$<>8__locals1.$VB$Local_ClientDownloadLoader.Input + name + ".jar", string.Concat(new string[]
								{
									CS$<>8__locals1.$VB$Local_McFolder,
									"versions\\",
									CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
									"\\",
									CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
									".jar"
								}));
							}
						}
						catch (Exception ex)
						{
							ModBase.Log(ex, "安装 OptiFine 拷贝原版文件时出错", ModBase.LogLevel.Debug, "出现错误");
						}
					}
				}
			}, null, ThreadPriority.Normal)
			{
				ProgressWeight = 0.1,
				Show = false
			});
			if (flag)
			{
				ModBase.Log("[Download] 检测为新版 OptiFine：" + CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(), ModBase.LogLevel.Normal, "出现错误");
				arrayList.Add(new ModLoader.LoaderTask<List<ModNet.NetFile>, bool>("安装 OptiFine（方式 A）", delegate(ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task)
				{
					string text = ModBase.m_GlobalRule + "InstallOptiFine" + Conversions.ToString(ModBase.RandomInteger(0, 0x186A0));
					string text2 = text + "\\.minecraft\\";
					try
					{
						if (Directory.Exists(text2 + "versions\\" + CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression()))
						{
							ModBase.DeleteDirectory(text2 + "versions\\" + CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(), false);
						}
						MyWpfExtension.RunFactory().FileSystem.CreateDirectory(text2 + "versions\\" + CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression() + "\\");
						ModMinecraft.McFolderLauncherProfilesJsonCreate(text2);
						File.Copy(string.Concat(new string[]
						{
							CS$<>8__locals1.$VB$Local_McFolder,
							"versions\\",
							CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
							"\\",
							CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
							".json"
						}), string.Concat(new string[]
						{
							text2,
							"versions\\",
							CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
							"\\",
							CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
							".json"
						}));
						File.Copy(string.Concat(new string[]
						{
							CS$<>8__locals1.$VB$Local_McFolder,
							"versions\\",
							CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
							"\\",
							CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
							".jar"
						}), string.Concat(new string[]
						{
							text2,
							"versions\\",
							CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
							"\\",
							CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
							".jar"
						}));
						Task.Progress = 0.06;
						ModDownloadLib.McDownloadOptiFineInstall(text, CS$<>8__locals1.$VB$Local_Target, Task);
						Task.Progress = 0.96;
						File.Delete(text2 + "launcher_profiles.json");
						MyWpfExtension.RunFactory().FileSystem.CopyDirectory(text2, CS$<>8__locals1.$VB$Local_McFolder, true);
						Task.Progress = 0.98;
						MyWpfExtension.RunFactory().FileSystem.DeleteFile(CS$<>8__locals1.$VB$Local_Target);
						ModBase.DeleteDirectory(text, false);
					}
					catch (Exception innerException)
					{
						throw new Exception("安装新版 OptiFine 版本失败", innerException);
					}
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 8.0
				});
			}
			else
			{
				ModBase.Log("[Download] 检测为旧版 OptiFine：" + CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(), ModBase.LogLevel.Normal, "出现错误");
				arrayList.Add(new ModLoader.LoaderTask<List<ModNet.NetFile>, bool>("安装 OptiFine（方式 B）", delegate(ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task)
				{
					try
					{
						Directory.CreateDirectory(CS$<>8__locals1.$VB$Local_VersionFolder);
						Task.Progress = 0.1;
						if (File.Exists(CS$<>8__locals1.$VB$Local_VersionFolder + CS$<>8__locals1.$VB$Local_Id + ".jar"))
						{
							File.Delete(CS$<>8__locals1.$VB$Local_VersionFolder + CS$<>8__locals1.$VB$Local_Id + ".jar");
						}
						File.Copy(string.Concat(new string[]
						{
							CS$<>8__locals1.$VB$Local_McFolder,
							"versions\\",
							CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
							"\\",
							CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
							".jar"
						}), CS$<>8__locals1.$VB$Local_VersionFolder + CS$<>8__locals1.$VB$Local_Id + ".jar");
						Task.Progress = 0.7;
						ModMinecraft.McVersion mcVersion = new ModMinecraft.McVersion(CS$<>8__locals1.$VB$Local_McFolder + "versions\\" + CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression());
						string text = string.Concat(new string[]
						{
							"{\r\n    \"id\": \"",
							CS$<>8__locals1.$VB$Local_Id,
							"\",\r\n    \"inheritsFrom\": \"",
							CS$<>8__locals1.$VB$Local_DownloadInfo.SetExpression(),
							"\",\r\n    \"time\": \"",
							(Operators.CompareString(CS$<>8__locals1.$VB$Local_DownloadInfo.m_ParameterAlgo, "", true) == 0) ? mcVersion.m_RulesAlgo.ToString("yyyy-MM-dd") : CS$<>8__locals1.$VB$Local_DownloadInfo.m_ParameterAlgo.Replace("/", "-"),
							"T23:33:33+08:00\",\r\n    \"releaseTime\": \"",
							(Operators.CompareString(CS$<>8__locals1.$VB$Local_DownloadInfo.m_ParameterAlgo, "", true) == 0) ? mcVersion.m_RulesAlgo.ToString("yyyy-MM-dd") : CS$<>8__locals1.$VB$Local_DownloadInfo.m_ParameterAlgo.Replace("/", "-"),
							"T23:33:33+08:00\",\r\n    \"type\": \"release\",\r\n    \"libraries\": [\r\n        {\"name\": \"optifine:OptiFine:",
							CS$<>8__locals1.$VB$Local_DownloadInfo.m_SystemAlgo.Replace("OptiFine_", "").Replace(".jar", "").Replace("preview_", ""),
							"\"},\r\n        {\"name\": \"net.minecraft:launchwrapper:1.12\"}\r\n    ],\r\n    \"mainClass\": \"net.minecraft.launchwrapper.Launch\","
						});
						Task.Progress = 0.8;
						if (mcVersion.CollectUtils())
						{
							text = text + "\r\n    \"minimumLauncherVersion\": 18,\r\n    \"minecraftArguments\": \"" + mcVersion.VerifyUtils()["minecraftArguments"].ToString() + "  --tweakClass optifine.OptiFineTweaker\"\r\n}";
						}
						else
						{
							text += "\r\n    \"minimumLauncherVersion\": \"21\",\r\n    \"arguments\": {\r\n        \"game\": [\r\n            \"--tweakClass\",\r\n            \"optifine.OptiFineTweaker\"\r\n        ]\r\n    }\r\n}";
						}
						ModBase.WriteFile(CS$<>8__locals1.$VB$Local_VersionFolder + CS$<>8__locals1.$VB$Local_Id + ".json", text, false, null);
					}
					catch (Exception innerException)
					{
						throw new Exception("安装旧版 OptiFine 版本失败", innerException);
					}
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 1.0
				});
			}
			if (FixLibrary)
			{
				arrayList.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析 OptiFine 支持库文件", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
				{
					Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McVersion(CS$<>8__locals1.$VB$Local_VersionFolder), false);
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 1.0,
					Show = false
				});
				arrayList.Add(new ModNet.LoaderDownload("下载 OptiFine 支持库文件", new List<ModNet.NetFile>())
				{
					ProgressWeight = 4.0
				});
			}
			return arrayList;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0001CBB8 File Offset: 0x0001ADB8
		private static ArrayList McDownloadOptiFineSaveLoader(ModDownload.DlOptiFineListEntry DownloadInfo, string TargetFolder)
		{
			return new ArrayList
			{
				new ModLoader.LoaderTask<ModDownload.DlOptiFineListEntry, List<ModNet.NetFile>>("获取 OptiFine 下载地址", delegate(ModLoader.LoaderTask<ModDownload.DlOptiFineListEntry, List<ModNet.NetFile>> Task)
				{
					List<string> list = new List<string>();
					if (DownloadInfo.m_PrototypeAlgo)
					{
						list.Add("https://download.mcbbs.net/optifine/" + DownloadInfo.SetExpression() + "/HD_U_" + DownloadInfo.m_RepositoryAlgo.Replace(DownloadInfo.SetExpression() + " ", "").Replace(" ", "/"));
						list.Add("https://bmclapi2.bangbang93.com/optifine/" + DownloadInfo.SetExpression() + "/HD_U_" + DownloadInfo.m_RepositoryAlgo.Replace(DownloadInfo.SetExpression() + " ", "").Replace(" ", "/"));
					}
					else
					{
						list.Add("https://download.mcbbs.net/optifine/" + DownloadInfo.SetExpression() + "/HD_U/" + DownloadInfo.m_RepositoryAlgo.Replace(DownloadInfo.SetExpression() + " ", ""));
						list.Add("https://bmclapi2.bangbang93.com/optifine/" + DownloadInfo.SetExpression() + "/HD_U/" + DownloadInfo.m_RepositoryAlgo.Replace(DownloadInfo.SetExpression() + " ", ""));
					}
					try
					{
						string str = ModNet.NetGetCodeByClient("https://optifine.net/adloadx?f=" + DownloadInfo.m_SystemAlgo, new UTF8Encoding(false), 0x3A98, "text/html");
						Task.Progress = 0.8;
						list.Add("https://optifine.net/" + ModBase.RegexSearch(str, "downloadx\\?f=[^\"']+", RegexOptions.None)[0]);
						ModBase.Log("[Download] OptiFine " + DownloadInfo.m_RepositoryAlgo + " 官方下载地址：" + list[0], ModBase.LogLevel.Normal, "出现错误");
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "获取 OptiFine " + DownloadInfo.m_RepositoryAlgo + " 官方下载地址失败", ModBase.LogLevel.Debug, "出现错误");
					}
					Task.Progress = 0.9;
					Task.Output = new List<ModNet.NetFile>
					{
						new ModNet.NetFile(list.ToArray(), TargetFolder, new ModBase.FileChecker(0x10000L, -1L, null, null, true, false))
					};
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 6.0
				},
				new ModNet.LoaderDownload("下载 OptiFine 主文件", new List<ModNet.NetFile>())
				{
					ProgressWeight = 10.0,
					Block = true
				}
			};
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0001CC38 File Offset: 0x0001AE38
		public static MyListItem OptiFineDownloadListItem(ModDownload.DlOptiFineListEntry Entry, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
		{
			MyListItem myListItem = new MyListItem
			{
				Title = Entry.m_RepositoryAlgo,
				SnapsToDevicePixels = true,
				Height = 42.0,
				Type = MyListItem.CheckType.Clickable,
				Tag = Entry,
				PaddingRight = 0x3C,
				Info = (Entry.m_PrototypeAlgo ? "测试版" : "正式版") + ((Operators.CompareString(Entry.m_ParameterAlgo, "", true) == 0) ? "" : ("，发布于 " + Entry.m_ParameterAlgo)),
				Logo = "pack://application:,,,/images/Blocks/GrassPath.png"
			};
			myListItem.QueryModel(OnClick);
			if (IsSaveOnly)
			{
				myListItem.utilsDecorator = new ModBase.EventDelegate(ModDownloadLib.OptiFineSaveContMenuBuild);
			}
			else
			{
				myListItem.utilsDecorator = new ModBase.EventDelegate(ModDownloadLib.OptiFineContMenuBuild);
			}
			return myListItem;
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0001CD08 File Offset: 0x0001AF08
		private static void OptiFineSaveContMenuBuild(object sender, EventArgs e)
		{
			MyIconButton myIconButton = new MyIconButton
			{
				LogoScale = 1.05,
				Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z",
				ToolTip = "更新日志"
			};
			ToolTipService.SetPlacement(myIconButton, PlacementMode.Center);
			ToolTipService.SetVerticalOffset(myIconButton, 30.0);
			ToolTipService.SetHorizontalOffset(myIconButton, 2.0);
			myIconButton.Click += ((ModDownloadLib._Closure$__.$IR17-6 == null) ? (ModDownloadLib._Closure$__.$IR17-6 = delegate(object sender, EventArgs e)
			{
				ModDownloadLib.OptiFineLog_Click(RuntimeHelpers.GetObjectValue(sender), (RoutedEventArgs)e);
			}) : ModDownloadLib._Closure$__.$IR17-6);
			NewLateBinding.LateSet(sender2, null, "Buttons", new object[]
			{
				new MyIconButton[]
				{
					myIconButton
				}
			}, null, null);
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0001CDB0 File Offset: 0x0001AFB0
		private static void OptiFineContMenuBuild(object sender, EventArgs e)
		{
			MyIconButton myIconButton = new MyIconButton
			{
				Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z",
				ToolTip = "另存为"
			};
			ToolTipService.SetPlacement(myIconButton, PlacementMode.Center);
			ToolTipService.SetVerticalOffset(myIconButton, 30.0);
			ToolTipService.SetHorizontalOffset(myIconButton, 2.0);
			myIconButton.Click += ((ModDownloadLib._Closure$__.$IR18-7 == null) ? (ModDownloadLib._Closure$__.$IR18-7 = delegate(object sender, EventArgs e)
			{
				ModDownloadLib.OptiFineSave_Click(RuntimeHelpers.GetObjectValue(sender), (RoutedEventArgs)e);
			}) : ModDownloadLib._Closure$__.$IR18-7);
			MyIconButton myIconButton2 = new MyIconButton
			{
				LogoScale = 1.05,
				Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z",
				ToolTip = "更新日志"
			};
			ToolTipService.SetPlacement(myIconButton2, PlacementMode.Center);
			ToolTipService.SetVerticalOffset(myIconButton2, 30.0);
			ToolTipService.SetHorizontalOffset(myIconButton2, 2.0);
			myIconButton2.Click += ((ModDownloadLib._Closure$__.$IR18-8 == null) ? (ModDownloadLib._Closure$__.$IR18-8 = delegate(object sender, EventArgs e)
			{
				ModDownloadLib.OptiFineLog_Click(RuntimeHelpers.GetObjectValue(sender), (RoutedEventArgs)e);
			}) : ModDownloadLib._Closure$__.$IR18-8);
			NewLateBinding.LateSet(sender2, null, "Buttons", new object[]
			{
				new MyIconButton[]
				{
					myIconButton,
					myIconButton2
				}
			}, null, null);
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0001CEC8 File Offset: 0x0001B0C8
		private static void OptiFineLog_Click(object sender, RoutedEventArgs e)
		{
			ModDownload.DlOptiFineListEntry dlOptiFineListEntry;
			if (NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) != null)
			{
				dlOptiFineListEntry = (ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null);
			}
			else if (NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null) != null)
			{
				dlOptiFineListEntry = (ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null);
			}
			else
			{
				dlOptiFineListEntry = (ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null);
			}
			ModBase.OpenWebsite("https://optifine.net/changelog?f=" + dlOptiFineListEntry.m_SystemAlgo);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0001CFC0 File Offset: 0x0001B1C0
		public static void OptiFineSave_Click(object sender, RoutedEventArgs e)
		{
			ModDownload.DlOptiFineListEntry downloadInfo;
			if (NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) != null)
			{
				downloadInfo = (ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null);
			}
			else if (NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null) != null)
			{
				downloadInfo = (ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null);
			}
			else
			{
				downloadInfo = (ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null);
			}
			ModDownloadLib.McDownloadOptiFineSave(downloadInfo);
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0001D0AC File Offset: 0x0001B2AC
		public static void McDownloadLiteLoader(ModDownload.DlLiteLoaderListEntry DownloadInfo)
		{
			checked
			{
				try
				{
					string inherit = DownloadInfo.Inherit;
					ModBase.m_GlobalRule + "Download\\" + inherit + "-Liteloader.jar";
					string text = DownloadInfo.Inherit + "-LiteLoader";
					string text2 = ModMinecraft.m_ResolverIterator + "versions\\" + text + "\\";
					object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
					ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
					lock (loaderTaskbarLock)
					{
						int num = ModLoader.LoaderTaskbar.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(ModLoader.LoaderTaskbar[i], null, "Name", new object[0], null, null, null), "LiteLoader " + inherit + " 下载", true))
							{
								ModMain.Hint("该版本正在下载中！", ModMain.HintType.Critical, true);
								return;
							}
						}
					}
					if (File.Exists(text2 + text + ".json"))
					{
						if (ModMain.MyMsgBox("版本 " + text + " 已存在，是否重新下载？\r\n这会覆盖版本的 Json 文件，但不会影响版本隔离的文件。", "版本已存在", "继续", "取消", "", false, true, false) != 1)
						{
							return;
						}
						File.Delete(text2 + text + ".jar");
						File.Delete(text2 + text + ".json");
					}
					ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("LiteLoader " + inherit + " 下载", ModDownloadLib.McDownloadLiteLoaderLoader(DownloadInfo, null, null, true));
					loaderCombo.OnStateChanged = new ModLoader.LoaderStateDelegate(ModDownloadLib.McInstallState);
					loaderCombo.Start(text2, false);
					ModLoader.LoaderTaskbarAdd(loaderCombo);
					ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
					ModMain.m_GetterFilter.BtnExtraDownload.Ribble();
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "开始 LiteLoader 下载失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0001D2A4 File Offset: 0x0001B4A4
		private static void McDownloadLiteLoaderSave(ModDownload.DlLiteLoaderListEntry DownloadInfo)
		{
			checked
			{
				try
				{
					string inherit = DownloadInfo.Inherit;
					string text = ModBase.SelectAs("选择保存位置", DownloadInfo.FileName.Replace("-SNAPSHOT", ""), "LiteLoader 安装器 (*.jar)|*.jar", null);
					if (text.Contains("\\"))
					{
						object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
						ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
						lock (loaderTaskbarLock)
						{
							int num = ModLoader.LoaderTaskbar.Count - 1;
							for (int i = 0; i <= num; i++)
							{
								if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(ModLoader.LoaderTaskbar[i], null, "Name", new object[0], null, null, null), "LiteLoader " + inherit + " 下载", true))
								{
									ModMain.Hint("该版本正在下载中！", ModMain.HintType.Critical, true);
									return;
								}
							}
						}
						ArrayList arrayList = new ArrayList();
						List<string> list = new List<string>();
						if (DownloadInfo.IsLegacy)
						{
							string inherit2 = DownloadInfo.Inherit;
							if (Operators.CompareString(inherit2, "1.7.10", true) == 0)
							{
								list.Add("http://dl.liteloader.com/redist/1.7.10/liteloader-installer-1.7.10-04.jar");
							}
							else if (Operators.CompareString(inherit2, "1.7.2", true) == 0)
							{
								list.Add("http://dl.liteloader.com/redist/1.7.2/liteloader-installer-1.7.2-04.jar");
							}
							else if (Operators.CompareString(inherit2, "1.6.4", true) == 0)
							{
								list.Add("http://dl.liteloader.com/redist/1.6.4/liteloader-installer-1.6.4-01.jar");
							}
							else if (Operators.CompareString(inherit2, "1.6.2", true) == 0)
							{
								list.Add("http://dl.liteloader.com/redist/1.6.2/liteloader-installer-1.6.2-04.jar");
							}
							else
							{
								if (Operators.CompareString(inherit2, "1.5.2", true) != 0)
								{
									throw new NotSupportedException("未知的 Minecraft 版本（" + DownloadInfo.Inherit + "）");
								}
								list.Add("http://dl.liteloader.com/redist/1.5.2/liteloader-installer-1.5.2-01.jar");
							}
						}
						else
						{
							list.Add(string.Concat(new string[]
							{
								"http://jenkins.liteloader.com/job/LiteLoaderInstaller%20",
								DownloadInfo.Inherit,
								"/lastSuccessfulBuild/artifact/",
								(Operators.CompareString(DownloadInfo.Inherit, "1.8", true) == 0) ? "ant/dist/" : "build/libs/",
								DownloadInfo.FileName
							}));
						}
						arrayList.Add(new ModNet.LoaderDownload("下载主文件", new List<ModNet.NetFile>
						{
							new ModNet.NetFile(list.ToArray(), text, new ModBase.FileChecker(0x100000L, -1L, null, null, true, false))
						})
						{
							ProgressWeight = 15.0
						});
						ModLoader.LoaderCombo<ModDownload.DlLiteLoaderListEntry> loaderCombo = new ModLoader.LoaderCombo<ModDownload.DlLiteLoaderListEntry>("LiteLoader " + inherit + " 安装器下载", arrayList);
						loaderCombo.OnStateChanged = new ModLoader.LoaderStateDelegate(ModDownloadLib.DownloadStateSave);
						loaderCombo.Start(DownloadInfo, false);
						ModLoader.LoaderTaskbarAdd(loaderCombo);
						ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
						ModMain.m_GetterFilter.BtnExtraDownload.Ribble();
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "开始 LiteLoader 安装器下载失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0001D5A4 File Offset: 0x0001B7A4
		private static ArrayList McDownloadLiteLoaderLoader(ModDownload.DlLiteLoaderListEntry DownloadInfo, string McFolder = null, ModLoader.LoaderCombo<string> ClientDownloadLoader = null, bool FixLibrary = true)
		{
			McFolder = (McFolder ?? ModMinecraft.m_ResolverIterator);
			bool IsCustomFolder = Operators.CompareString(McFolder, ModMinecraft.m_ResolverIterator, true) != 0;
			string inherit = DownloadInfo.Inherit;
			ModBase.m_GlobalRule + "Download\\" + inherit + "-Liteloader.jar";
			string VersionName = DownloadInfo.Inherit + "-LiteLoader";
			string VersionFolder = McFolder + "versions\\" + VersionName + "\\";
			ArrayList arrayList = new ArrayList();
			if (ClientDownloadLoader == null)
			{
				arrayList.Add(new ModLoader.LoaderTask<string, string>("启动 LiteLoader 依赖版本下载", delegate(ModLoader.LoaderTask<string, string> a0)
				{
					base._Lambda$__0();
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 0.2,
					Show = false,
					Block = false
				});
			}
			arrayList.Add(new ModLoader.LoaderTask<string, string>("安装 LiteLoader", delegate(ModLoader.LoaderTask<string, string> Task)
			{
				try
				{
					Directory.CreateDirectory(VersionFolder);
					JObject jobject = new JObject();
					jobject.Add("id", VersionName);
					jobject.Add("time", DateTime.ParseExact(DownloadInfo.ReleaseTime, "yyyy/MM/dd HH:mm:ss", CultureInfo.CurrentCulture));
					jobject.Add("releaseTime", DateTime.ParseExact(DownloadInfo.ReleaseTime, "yyyy/MM/dd HH:mm:ss", CultureInfo.CurrentCulture));
					jobject.Add("type", "release");
					jobject.Add("arguments", (JToken)ModBase.GetJson("{\"game\":[\"--tweakClass\",\"" + DownloadInfo.JsonToken["tweakClass"].ToString() + "\"]}"));
					jobject.Add("libraries", DownloadInfo.JsonToken["libraries"]);
					((JContainer)jobject["libraries"]).Add(RuntimeHelpers.GetObjectValue(ModBase.GetJson("{\"name\": \"com.mumfrey:liteloader:" + DownloadInfo.JsonToken["version"].ToString() + "\",\"url\": \"http://dl.liteloader.com/versions/\"}")));
					jobject.Add("mainClass", "net.minecraft.launchwrapper.Launch");
					jobject.Add("minimumLauncherVersion", 0x12);
					jobject.Add("inheritsFrom", DownloadInfo.Inherit);
					jobject.Add("jar", DownloadInfo.Inherit);
					ModBase.WriteFile(VersionFolder + VersionName + ".json", jobject.ToString(), false, null);
				}
				catch (Exception innerException)
				{
					throw new Exception("安装新 LiteLoader 版本失败", innerException);
				}
			}, null, ThreadPriority.Normal)
			{
				ProgressWeight = 1.0
			});
			if (FixLibrary)
			{
				arrayList.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析 LiteLoader 支持库文件", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
				{
					Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McVersion(VersionFolder), false);
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 1.0,
					Show = false
				});
				arrayList.Add(new ModNet.LoaderDownload("下载 LiteLoader 支持库文件", new List<ModNet.NetFile>())
				{
					ProgressWeight = 6.0
				});
			}
			return arrayList;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0001D718 File Offset: 0x0001B918
		public static MyListItem LiteLoaderDownloadListItem(ModDownload.DlLiteLoaderListEntry Entry, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
		{
			MyListItem myListItem = new MyListItem
			{
				Title = Entry.Inherit,
				SnapsToDevicePixels = true,
				Height = 42.0,
				Type = MyListItem.CheckType.Clickable,
				Tag = Entry,
				PaddingRight = 0x1E,
				Info = (Entry.IsPreview ? "测试版" : "稳定版") + ((Operators.CompareString(Entry.ReleaseTime, "", true) == 0) ? "" : ("，发布于 " + Entry.ReleaseTime)),
				Logo = "pack://application:,,,/images/Blocks/Egg.png"
			};
			myListItem.QueryModel(OnClick);
			if (IsSaveOnly)
			{
				myListItem.utilsDecorator = ((ModDownloadLib._Closure$__.$IR24-10 == null) ? (ModDownloadLib._Closure$__.$IR24-10 = delegate(object sender, EventArgs e)
				{
					ModDownloadLib.LiteLoaderSaveContMenuBuild((MyListItem)sender, e);
				}) : ModDownloadLib._Closure$__.$IR24-10);
			}
			else
			{
				myListItem.utilsDecorator = ((ModDownloadLib._Closure$__.$IR24-11 == null) ? (ModDownloadLib._Closure$__.$IR24-11 = delegate(object sender, EventArgs e)
				{
					ModDownloadLib.LiteLoaderContMenuBuild((MyListItem)sender, e);
				}) : ModDownloadLib._Closure$__.$IR24-11);
			}
			return myListItem;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0001D818 File Offset: 0x0001BA18
		private static void LiteLoaderSaveContMenuBuild(MyListItem sender, EventArgs e)
		{
			if (Conversions.ToBoolean(NewLateBinding.LateGet(sender2.Tag, null, "IsLegacy", new object[0], null, null, null)))
			{
				sender2.PaddingRight = 0;
				sender2.Buttons = new object[0];
				return;
			}
			sender2.PaddingRight = 0x1E;
			MyIconButton myIconButton = new MyIconButton
			{
				Logo = "M384 128h640v128H384zM160 192m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0ZM384 448h640v128H384zM160 512m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0ZM384 768h640v128H384zM160 832m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0Z",
				ToolTip = "查看全部版本",
				Tag = sender2
			};
			ToolTipService.SetPlacement(myIconButton, PlacementMode.Center);
			ToolTipService.SetVerticalOffset(myIconButton, 30.0);
			ToolTipService.SetHorizontalOffset(myIconButton, 2.0);
			myIconButton.Click += ((ModDownloadLib._Closure$__.$IR25-12 == null) ? (ModDownloadLib._Closure$__.$IR25-12 = delegate(object sender, EventArgs e)
			{
				ModDownloadLib.LiteLoaderAll_Click(RuntimeHelpers.GetObjectValue(sender), (RoutedEventArgs)e);
			}) : ModDownloadLib._Closure$__.$IR25-12);
			sender2.Buttons = new MyIconButton[]
			{
				myIconButton
			};
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0001D8E4 File Offset: 0x0001BAE4
		private static void LiteLoaderContMenuBuild(MyListItem sender, EventArgs e)
		{
			MyIconButton myIconButton = new MyIconButton
			{
				Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z",
				ToolTip = "保存安装器",
				Tag = sender2
			};
			ToolTipService.SetPlacement(myIconButton, PlacementMode.Center);
			ToolTipService.SetVerticalOffset(myIconButton, 30.0);
			ToolTipService.SetHorizontalOffset(myIconButton, 2.0);
			myIconButton.Click += ((ModDownloadLib._Closure$__.$IR26-13 == null) ? (ModDownloadLib._Closure$__.$IR26-13 = delegate(object sender, EventArgs e)
			{
				ModDownloadLib.LiteLoaderSave_Click(RuntimeHelpers.GetObjectValue(sender), (RoutedEventArgs)e);
			}) : ModDownloadLib._Closure$__.$IR26-13);
			if (Conversions.ToBoolean(NewLateBinding.LateGet(sender2.Tag, null, "IsLegacy", new object[0], null, null, null)))
			{
				sender2.PaddingRight = 0x1E;
				sender2.Buttons = new MyIconButton[]
				{
					myIconButton
				};
				return;
			}
			sender2.PaddingRight = 0x3C;
			MyIconButton myIconButton2 = new MyIconButton
			{
				Logo = "M384 128h640v128H384zM160 192m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0ZM384 448h640v128H384zM160 512m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0ZM384 768h640v128H384zM160 832m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0Z",
				ToolTip = "查看全部版本",
				Tag = sender2
			};
			ToolTipService.SetPlacement(myIconButton2, PlacementMode.Center);
			ToolTipService.SetVerticalOffset(myIconButton2, 30.0);
			ToolTipService.SetHorizontalOffset(myIconButton2, 2.0);
			myIconButton2.Click += ((ModDownloadLib._Closure$__.$IR26-14 == null) ? (ModDownloadLib._Closure$__.$IR26-14 = delegate(object sender, EventArgs e)
			{
				ModDownloadLib.LiteLoaderAll_Click(RuntimeHelpers.GetObjectValue(sender), (RoutedEventArgs)e);
			}) : ModDownloadLib._Closure$__.$IR26-14);
			sender2.Buttons = new MyIconButton[]
			{
				myIconButton,
				myIconButton2
			};
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0001DA2C File Offset: 0x0001BC2C
		private static void LiteLoaderAll_Click(object sender, RoutedEventArgs e)
		{
			ModDownload.DlLiteLoaderListEntry dlLiteLoaderListEntry;
			if (NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) is ModDownload.DlLiteLoaderListEntry)
			{
				dlLiteLoaderListEntry = (ModDownload.DlLiteLoaderListEntry)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null);
			}
			else
			{
				dlLiteLoaderListEntry = (ModDownload.DlLiteLoaderListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null), null, "Tag", new object[0], null, null, null);
			}
			ModBase.OpenWebsite("http://jenkins.liteloader.com/view/" + dlLiteLoaderListEntry.Inherit);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0001DAB8 File Offset: 0x0001BCB8
		public static void LiteLoaderSave_Click(object sender, RoutedEventArgs e)
		{
			ModDownload.DlLiteLoaderListEntry downloadInfo;
			if (NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) is ModDownload.DlLiteLoaderListEntry)
			{
				downloadInfo = (ModDownload.DlLiteLoaderListEntry)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null);
			}
			else
			{
				downloadInfo = (ModDownload.DlLiteLoaderListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null), null, "Tag", new object[0], null, null, null);
			}
			ModDownloadLib.McDownloadLiteLoaderSave(downloadInfo);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0001DB34 File Offset: 0x0001BD34
		public static void McDownloadForge(ModDownload.DlForgeVersionEntry DownloadInfo)
		{
			checked
			{
				if (Operators.CompareString(DownloadInfo._CollectionAlgo, "client", true) == 0)
				{
					if (ModMain.MyMsgBox("该 Forge 版本过于古老，PCL2 暂不支持该版本的自动安装。\r\n若你仍然希望继续，PCL2 将把安装程序下载到你指定的位置，但不会进行安装。", "版本过老", "继续", "取消", "", false, true, false) == 1)
					{
						ModDownloadLib.McDownloadForgeSave(DownloadInfo);
						return;
					}
				}
				else
				{
					if (Operators.CompareString(DownloadInfo._CollectionAlgo, "universal", true) != 0 && !DownloadInfo.interpreterAlgo.StartsWith("1.5"))
					{
						string text = DownloadInfo.interpreterAlgo + "-forge-" + DownloadInfo._ConfigurationAlgo;
						string path = string.Concat(new string[]
						{
							ModBase.m_GlobalRule,
							"Cache\\Code\\ForgeInstall-",
							DownloadInfo._ConfigurationAlgo,
							"_",
							Conversions.ToString(ModBase.GetUuid()),
							".",
							DownloadInfo.DeleteExpression()
						});
						string text2 = ModMinecraft.m_ResolverIterator + "versions\\" + text + "\\";
						string str = "Forge " + DownloadInfo.interpreterAlgo + " - " + DownloadInfo._ConfigurationAlgo;
						try
						{
							object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
							ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
							lock (loaderTaskbarLock)
							{
								int num = ModLoader.LoaderTaskbar.Count - 1;
								for (int i = 0; i <= num; i++)
								{
									if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(ModLoader.LoaderTaskbar[i], null, "Name", new object[0], null, null, null), str + " 下载", true))
									{
										ModMain.Hint("该版本正在下载中！", ModMain.HintType.Critical, true);
										return;
									}
								}
							}
							if (File.Exists(text2 + text + ".json"))
							{
								if (ModMain.MyMsgBox("版本 " + text + " 已存在，是否重新下载？\r\n这会覆盖版本的 Json 文件，但不会影响版本隔离的文件。", "版本已存在", "继续", "取消", "", false, true, false) != 1)
								{
									return;
								}
								File.Delete(text2 + text + ".jar");
								File.Delete(text2 + text + ".json");
							}
							ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(str + " 下载", ModDownloadLib.McDownloadForgeLoader(DownloadInfo._ConfigurationAlgo, DownloadInfo.interpreterAlgo, DownloadInfo, null, null, true));
							loaderCombo.OnStateChanged = new ModLoader.LoaderStateDelegate(ModDownloadLib.McInstallState);
							loaderCombo.Start(text2, false);
							ModLoader.LoaderTaskbarAdd(loaderCombo);
							ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
							ModMain.m_GetterFilter.BtnExtraDownload.Ribble();
							return;
						}
						catch (Exception ex)
						{
							ModBase.Log(ex, "开始 Forge 下载失败", ModBase.LogLevel.Feedback, "出现错误");
							return;
						}
						finally
						{
							try
							{
								if (File.Exists(path))
								{
									File.Delete(path);
								}
							}
							catch (Exception ex2)
							{
							}
						}
					}
					if (ModMain.MyMsgBox("该 Forge 版本过于古老，PCL2 暂不支持该版本的自动安装。\r\n若你仍然希望继续，PCL2 将把安装程序下载到你指定的位置，但不会进行安装。", "版本过老", "继续", "取消", "", false, true, false) == 1)
					{
						ModDownloadLib.McDownloadForgeSave(DownloadInfo);
						return;
					}
				}
			}
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0001DE6C File Offset: 0x0001C06C
		public static void McDownloadForgeSave(ModDownload.DlForgeVersionEntry DownloadInfo)
		{
			ModDownloadLib._Closure$__30-0 CS$<>8__locals1 = new ModDownloadLib._Closure$__30-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_DownloadInfo = DownloadInfo;
			checked
			{
				try
				{
					ModDownloadLib._Closure$__30-1 CS$<>8__locals2 = new ModDownloadLib._Closure$__30-1(CS$<>8__locals2);
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2 = CS$<>8__locals1;
					CS$<>8__locals2.$VB$Local_Target = ModBase.SelectAs("选择保存位置", CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_DownloadInfo.FlushExpression(), "Forge 文件 (*." + CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_DownloadInfo.DeleteExpression() + ")|*." + CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_DownloadInfo.DeleteExpression(), null);
					string str = "Forge " + CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_DownloadInfo.interpreterAlgo + " - " + CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_DownloadInfo._ConfigurationAlgo;
					if (CS$<>8__locals2.$VB$Local_Target.Contains("\\"))
					{
						object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
						ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
						lock (loaderTaskbarLock)
						{
							int num = ModLoader.LoaderTaskbar.Count - 1;
							for (int i = 0; i <= num; i++)
							{
								if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(ModLoader.LoaderTaskbar[i], null, "Name", new object[0], null, null, null), str + " 下载", true))
								{
									ModMain.Hint("该版本正在下载中！", ModMain.HintType.Critical, true);
									return;
								}
							}
						}
						ArrayList arrayList = new ArrayList();
						arrayList.Add(new ModLoader.LoaderTask<ModDownload.DlForgeVersionEntry, List<ModNet.NetFile>>("获取下载地址", delegate(ModLoader.LoaderTask<ModDownload.DlForgeVersionEntry, List<ModNet.NetFile>> Task)
						{
							Task.Output = new List<ModNet.NetFile>
							{
								new ModNet.NetFile(new string[]
								{
									string.Concat(new string[]
									{
										"https://download.mcbbs.net/maven/net/minecraftforge/forge/",
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_DownloadInfo.interpreterAlgo,
										"-",
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_DownloadInfo.PrepareExpression(),
										"/",
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_DownloadInfo.FlushExpression()
									}),
									string.Concat(new string[]
									{
										"https://bmclapi2.bangbang93.com/maven/net/minecraftforge/forge/",
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_DownloadInfo.interpreterAlgo,
										"-",
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_DownloadInfo.PrepareExpression(),
										"/",
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_DownloadInfo.FlushExpression()
									}),
									string.Concat(new string[]
									{
										"http://files.minecraftforge.net/maven/net/minecraftforge/forge/",
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_DownloadInfo.interpreterAlgo,
										"-",
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_DownloadInfo.PrepareExpression(),
										"/",
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_DownloadInfo.FlushExpression()
									})
								}, CS$<>8__locals2.$VB$Local_Target, new ModBase.FileChecker(0x10000L, -1L, CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_DownloadInfo.structAlgo, null, true, false))
							};
						}, null, ThreadPriority.Normal)
						{
							ProgressWeight = 0.1,
							Show = false
						});
						arrayList.Add(new ModNet.LoaderDownload("下载主文件", new List<ModNet.NetFile>())
						{
							ProgressWeight = 6.0
						});
						ModLoader.LoaderCombo<ModDownload.DlForgeVersionEntry> loaderCombo = new ModLoader.LoaderCombo<ModDownload.DlForgeVersionEntry>(str + " 下载", arrayList);
						loaderCombo.OnStateChanged = new ModLoader.LoaderStateDelegate(ModDownloadLib.DownloadStateSave);
						loaderCombo.Start(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_DownloadInfo, false);
						ModLoader.LoaderTaskbarAdd(loaderCombo);
						ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
						ModMain.m_GetterFilter.BtnExtraDownload.Ribble();
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "开始 Forge 下载失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0001E0C8 File Offset: 0x0001C2C8
		private static void ForgeInjector(string Target, ModLoader.LoaderTask<bool, bool> Task, string McFolder)
		{
			ModDownloadLib._Closure$__31-2 CS$<>8__locals1 = new ModDownloadLib._Closure$__31-2(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_Task = Task;
			ModMinecraft.JavaEntry javaEntry = ModMinecraft.JavaSelect(new Version(1, 8, 0, 0x3C), null, null);
			if (javaEntry == null)
			{
				ModMinecraft.JavaMissing(8);
				throw new Exception("未找到用于安装 Forge 的 Java");
			}
			string text = string.Format("-cp \"{0};{1}\" com.bangbang93.ForgeInstaller \"{2}", ModBase.m_GlobalRule + "Cache\\forge_installer.jar", Target, McFolder);
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				FileName = javaEntry.DisableExpression(),
				Arguments = text,
				UseShellExecute = false,
				CreateNoWindow = true,
				RedirectStandardError = true,
				RedirectStandardOutput = true
			};
			ModBase.Log("[Download] 开始安装 Forge：" + text, ModBase.LogLevel.Normal, "出现错误");
			using (Process process = new Process
			{
				StartInfo = startInfo
			})
			{
				ModDownloadLib._Closure$__31-1 CS$<>8__locals2 = new ModDownloadLib._Closure$__31-1(CS$<>8__locals2);
				CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2 = CS$<>8__locals1;
				CS$<>8__locals2.$VB$Local_LastResults = new Queue<string>();
				ModDownloadLib._Closure$__31-0 CS$<>8__locals3 = new ModDownloadLib._Closure$__31-0(CS$<>8__locals3);
				CS$<>8__locals3.$VB$NonLocal_$VB$Closure_3 = CS$<>8__locals2;
				CS$<>8__locals3.$VB$Local_outputWaitHandle = new AutoResetEvent(false);
				try
				{
					ModDownloadLib._Closure$__31-3 CS$<>8__locals4 = new ModDownloadLib._Closure$__31-3(CS$<>8__locals4);
					CS$<>8__locals4.$VB$NonLocal_$VB$Closure_4 = CS$<>8__locals3;
					CS$<>8__locals4.$VB$Local_errorWaitHandle = new AutoResetEvent(false);
					try
					{
						process.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e)
						{
							base._Lambda$__0(RuntimeHelpers.GetObjectValue(sender), e);
						};
						process.ErrorDataReceived += delegate(object sender, DataReceivedEventArgs e)
						{
							base._Lambda$__1(RuntimeHelpers.GetObjectValue(sender), e);
						};
						process.Start();
						process.BeginOutputReadLine();
						process.BeginErrorReadLine();
						while (!process.HasExited)
						{
							if (CS$<>8__locals4.$VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_Task.IsAborted)
							{
								ModBase.Log("[Installer] 由于任务取消，Forge 安装已中止", ModBase.LogLevel.Normal, "出现错误");
								process.Kill();
							}
							Thread.Sleep(0xA);
						}
						CS$<>8__locals4.$VB$NonLocal_$VB$Closure_4.$VB$Local_outputWaitHandle.WaitOne(0x2710);
						CS$<>8__locals4.$VB$Local_errorWaitHandle.WaitOne(0x2710);
						if (Operators.CompareString(CS$<>8__locals4.$VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$Local_LastResults.Last<string>(), "true", true) != 0)
						{
							ModBase.Log(ModBase.Join(CS$<>8__locals4.$VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$Local_LastResults, "\r\n"), ModBase.LogLevel.Normal, "出现错误");
							throw new Exception("Forge 安装器出错，末行为 " + CS$<>8__locals4.$VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$Local_LastResults.Last<string>());
						}
					}
					finally
					{
						if (CS$<>8__locals4.$VB$Local_errorWaitHandle != null)
						{
							((IDisposable)CS$<>8__locals4.$VB$Local_errorWaitHandle).Dispose();
						}
					}
				}
				finally
				{
					if (CS$<>8__locals3.$VB$Local_outputWaitHandle != null)
					{
						((IDisposable)CS$<>8__locals3.$VB$Local_outputWaitHandle).Dispose();
					}
				}
			}
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0001E380 File Offset: 0x0001C580
		private static void ForgeInjectorLine(string Content, ModLoader.LoaderTask<bool, bool> Task)
		{
			if (!Content.StartsWith("  Data") && !Content.StartsWith("  Slim"))
			{
				if (Content.StartsWith("  Reading patch "))
				{
					if (ModBase.errorRule)
					{
						ModBase.Log("[Installer] " + Content, ModBase.LogLevel.Normal, "出现错误");
					}
					Task.Progress = 0.86;
					return;
				}
				if (Operators.CompareString(Content, "Extracting json", true) == 0)
				{
					ModBase.Log("[Installer] " + Content, ModBase.LogLevel.Normal, "出现错误");
					Task.Progress = 0.07;
				}
				else if (Operators.CompareString(Content, "Downloading libraries", true) == 0)
				{
					ModBase.Log("[Installer] " + Content, ModBase.LogLevel.Normal, "出现错误");
					Task.Progress = 0.08;
				}
				else if (Operators.CompareString(Content, "  File exists: Checksum validated.", true) == 0)
				{
					if (ModBase.errorRule)
					{
						ModBase.Log("[Installer] " + Content, ModBase.LogLevel.Normal, "出现错误");
					}
					Task.Progress += 0.003;
				}
				else if (Operators.CompareString(Content, "Building Processors", true) == 0)
				{
					Task.Progress = 0.38;
				}
				else if (Operators.CompareString(Content, "Task: DOWNLOAD_MOJMAPS", true) == 0)
				{
					Task.Progress = 0.4;
				}
				else if (Operators.CompareString(Content, "Task: MERGE_MAPPING", true) == 0)
				{
					Task.Progress = 0.6;
				}
				else if (Operators.CompareString(Content, "Splitting: ", true) == 0)
				{
					Task.Progress = 0.62;
				}
				else if (Operators.CompareString(Content, "Parameter Annotations", true) == 0)
				{
					Task.Progress = 0.66;
				}
				else if (Operators.CompareString(Content, "Processing Complete", true) == 0)
				{
					Task.Progress = 0.7;
				}
				else if (Operators.CompareString(Content, "Remapping final jar", true) == 0)
				{
					Task.Progress = 0.72;
				}
				else if (Operators.CompareString(Content, "Remapping jar... 50%", true) == 0)
				{
					Task.Progress = 0.76;
				}
				else if (Operators.CompareString(Content, "Remapping jar... 100%", true) == 0)
				{
					Task.Progress = 0.81;
				}
				else if (Operators.CompareString(Content, "Injecting profile", true) == 0)
				{
					Task.Progress = 0.91;
				}
				else
				{
					if (ModBase.errorRule)
					{
						ModBase.Log("[Installer] " + Content, ModBase.LogLevel.Normal, "出现错误");
						return;
					}
					return;
				}
				ModBase.Log("[Installer] " + Content, ModBase.LogLevel.Normal, "出现错误");
			}
			else if (ModBase.errorRule)
			{
				ModBase.Log("[Installer] " + Content, ModBase.LogLevel.Normal, "出现错误");
				return;
			}
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0001E638 File Offset: 0x0001C838
		private static ArrayList McDownloadForgeLoader(string Version, string Inherit, ModDownload.DlForgeVersionEntry DownloadInfo = null, string McFolder = null, ModLoader.LoaderCombo<string> ClientDownloadLoader = null, bool FixLibrary = true)
		{
			ModDownloadLib._Closure$__33-0 CS$<>8__locals1 = new ModDownloadLib._Closure$__33-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_Version = Version;
			CS$<>8__locals1.$VB$Local_Inherit = Inherit;
			CS$<>8__locals1.$VB$Local_DownloadInfo = DownloadInfo;
			CS$<>8__locals1.$VB$Local_McFolder = McFolder;
			CS$<>8__locals1.$VB$Local_ClientDownloadLoader = ClientDownloadLoader;
			CS$<>8__locals1.$VB$Local_McFolder = (CS$<>8__locals1.$VB$Local_McFolder ?? ModMinecraft.m_ResolverIterator);
			CS$<>8__locals1.$VB$Local_IsCustomFolder = (Operators.CompareString(CS$<>8__locals1.$VB$Local_McFolder, ModMinecraft.m_ResolverIterator, true) != 0);
			CS$<>8__locals1.$VB$Local_Id = CS$<>8__locals1.$VB$Local_Inherit + "-forge-" + CS$<>8__locals1.$VB$Local_Version;
			CS$<>8__locals1.$VB$Local_InstallerAddress = string.Concat(new string[]
			{
				ModBase.m_GlobalRule,
				"Cache\\Code\\ForgeInstall-",
				CS$<>8__locals1.$VB$Local_Version,
				"_",
				Conversions.ToString(ModBase.RandomInteger(0, 0x186A0))
			});
			CS$<>8__locals1.$VB$Local_VersionFolder = CS$<>8__locals1.$VB$Local_McFolder + "versions\\" + CS$<>8__locals1.$VB$Local_Id + "\\";
			"Forge " + CS$<>8__locals1.$VB$Local_Inherit + " - " + CS$<>8__locals1.$VB$Local_Version;
			ArrayList arrayList = new ArrayList();
			ModMinecraft.m_ResolverIterator + "versions\\" + CS$<>8__locals1.$VB$Local_Id + "\\";
			if (CS$<>8__locals1.$VB$Local_DownloadInfo == null)
			{
				arrayList.Add(new ModLoader.LoaderTask<string, string>("获取 Mod 加载器详细信息", delegate(ModLoader.LoaderTask<string, string> Task)
				{
					ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>("McDownloadForgeLoader " + CS$<>8__locals1.$VB$Local_Inherit, new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>.LoadDelegateSub(ModDownload.DlForgeVersionMain), null, ThreadPriority.Normal);
					loaderTask.WaitForExit(CS$<>8__locals1.$VB$Local_Inherit, null, false);
					Task.Progress = 0.8;
					try
					{
						foreach (ModDownload.DlForgeVersionEntry dlForgeVersionEntry in loaderTask.Output)
						{
							if (Operators.CompareString(dlForgeVersionEntry._ConfigurationAlgo, CS$<>8__locals1.$VB$Local_Version, true) == 0)
							{
								CS$<>8__locals1.$VB$Local_DownloadInfo = dlForgeVersionEntry;
								return;
							}
						}
					}
					finally
					{
						List<ModDownload.DlForgeVersionEntry>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					throw new Exception(string.Concat(new string[]
					{
						"未能找到 Forge ",
						CS$<>8__locals1.$VB$Local_Inherit,
						"-",
						CS$<>8__locals1.$VB$Local_Version,
						" 的详细信息！"
					}));
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 3.0
				});
			}
			arrayList.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("准备 Mod 加载器下载", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
			{
				if (CS$<>8__locals1.$VB$Local_ClientDownloadLoader == null)
				{
					if (CS$<>8__locals1.$VB$Local_IsCustomFolder)
					{
						throw new Exception("如果没有指定原版下载器，则不能指定 MC 安装文件夹");
					}
					CS$<>8__locals1.$VB$Local_ClientDownloadLoader = ModDownloadLib.McDownloadClient(ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading, CS$<>8__locals1.$VB$Local_Inherit, null);
				}
				List<ModNet.NetFile> output = new List<ModNet.NetFile>
				{
					new ModNet.NetFile(new string[]
					{
						string.Concat(new string[]
						{
							"https://bmclapi2.bangbang93.com/maven/net/minecraftforge/forge/",
							CS$<>8__locals1.$VB$Local_Inherit,
							"-",
							CS$<>8__locals1.$VB$Local_DownloadInfo.PrepareExpression(),
							"/",
							CS$<>8__locals1.$VB$Local_DownloadInfo.FlushExpression()
						}),
						string.Concat(new string[]
						{
							"http://files.minecraftforge.net/maven/net/minecraftforge/forge/",
							CS$<>8__locals1.$VB$Local_Inherit,
							"-",
							CS$<>8__locals1.$VB$Local_DownloadInfo.PrepareExpression(),
							"/",
							CS$<>8__locals1.$VB$Local_DownloadInfo.FlushExpression()
						}),
						string.Concat(new string[]
						{
							"https://download.mcbbs.net/maven/net/minecraftforge/forge/",
							CS$<>8__locals1.$VB$Local_Inherit,
							"-",
							CS$<>8__locals1.$VB$Local_DownloadInfo.PrepareExpression(),
							"/",
							CS$<>8__locals1.$VB$Local_DownloadInfo.FlushExpression()
						})
					}, CS$<>8__locals1.$VB$Local_InstallerAddress, new ModBase.FileChecker(0x10000L, -1L, CS$<>8__locals1.$VB$Local_DownloadInfo.structAlgo, null, true, false))
				};
				Task.Output = output;
			}, null, ThreadPriority.Normal)
			{
				ProgressWeight = 0.5,
				Show = false
			});
			arrayList.Add(new ModNet.LoaderDownload("下载 Mod 加载器主文件", new List<ModNet.NetFile>())
			{
				ProgressWeight = 9.0
			});
			if (Conversions.ToDouble(CS$<>8__locals1.$VB$Local_Version.Split(new char[]
			{
				'.'
			})[0]) >= 20.0)
			{
				ModDownloadLib._Closure$__33-1 CS$<>8__locals2 = new ModDownloadLib._Closure$__33-1(CS$<>8__locals2);
				CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2 = CS$<>8__locals1;
				ModBase.Log("[Download] 检测为新版 Forge：" + CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Version, ModBase.LogLevel.Normal, "出现错误");
				CS$<>8__locals2.$VB$Local_Libs = null;
				arrayList.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析 Mod 加载器支持库文件", checked(delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
				{
					Task.Output = new List<ModNet.NetFile>();
					ZipArchive zipArchive = null;
					try
					{
						zipArchive = new ZipArchive(new FileStream(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_InstallerAddress, FileMode.Open));
						Task.Progress = 0.2;
						JObject jobject = (JObject)ModBase.GetJson(ModBase.ReadFile(zipArchive.GetEntry("install_profile.json").Open(), null));
						JObject content = (JObject)ModBase.GetJson(ModBase.ReadFile(zipArchive.GetEntry("version.json").Open(), null));
						jobject.Merge(content);
						CS$<>8__locals2.$VB$Local_Libs = ModMinecraft.McLibListGetWithJson(jobject, true, null, null);
						if (jobject["data"] != null && jobject["data"]["MOJMAPS"] != null)
						{
							Task.Progress = 0.4;
							ModBase.Log("[Download] 需要 Mappings 下载信息，开始获取原版 Json 文件", ModBase.LogLevel.Normal, "出现错误");
							JObject jobject2 = (JObject)ModBase.GetJson(ModNet.NetGetCodeByDownload(ModDownload.DlSourceLauncherOrMetaGet(Conversions.ToString(ModDownload.DlClientListGet(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Inherit)), true), 0xAFC8, true));
							string text = jobject["data"]["MOJMAPS"]["client"].ToString().Trim("[]".ToCharArray()).Split(new char[]
							{
								'@'
							})[0];
							string utilsMapper = ModMinecraft.McLibGet(text, true, false, null).Replace(".jar", "-mappings.txt");
							List<ModMinecraft.McLibToken> $VB$Local_Libs = CS$<>8__locals2.$VB$Local_Libs;
							ModMinecraft.McLibToken mcLibToken = new ModMinecraft.McLibToken();
							mcLibToken._MapperMapper = false;
							mcLibToken.m_DecoratorMapper = false;
							mcLibToken.m_UtilsMapper = utilsMapper;
							mcLibToken.algoMapper = text;
							mcLibToken.CheckUtils((string)jobject2["downloads"]["client_mappings"]["url"]);
							mcLibToken._BaseMapper = (long)jobject2["downloads"]["client_mappings"]["size"];
							mcLibToken.filterMapper = (string)jobject2["downloads"]["client_mappings"]["sha1"];
							$VB$Local_Libs.Add(mcLibToken);
						}
						Task.Progress = 0.8;
						int num = CS$<>8__locals2.$VB$Local_Libs.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							if (CS$<>8__locals2.$VB$Local_Libs[i].m_UtilsMapper.EndsWith(string.Concat(new string[]
							{
								"forge-",
								CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Inherit,
								"-",
								CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Version,
								".jar"
							})))
							{
								CS$<>8__locals2.$VB$Local_Libs.RemoveAt(i);
								IL_2A9:
								Task.Output = ModMinecraft.McLibFixFromLibToken(CS$<>8__locals2.$VB$Local_Libs, ModMinecraft.m_ResolverIterator, null, false);
								return;
							}
						}
						goto IL_2A9;
					}
					catch (Exception innerException)
					{
						throw new Exception("获取新版 Forge 支持库列表失败", innerException);
					}
					finally
					{
						if (zipArchive != null)
						{
							zipArchive.Dispose();
						}
					}
				}), null, ThreadPriority.Normal)
				{
					ProgressWeight = 2.0
				});
				arrayList.Add(new ModNet.LoaderDownload("下载 Mod 加载器支持库文件", new List<ModNet.NetFile>())
				{
					ProgressWeight = 12.0
				});
				arrayList.Add(new ModLoader.LoaderTask<List<ModNet.NetFile>, bool>("获取 Mod 下载器支持库文件", delegate(ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task)
				{
					if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_IsCustomFolder)
					{
						try
						{
							foreach (ModMinecraft.McLibToken mcLibToken in CS$<>8__locals2.$VB$Local_Libs)
							{
								string text = mcLibToken.m_UtilsMapper.Replace(ModMinecraft.m_ResolverIterator, CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_McFolder);
								if (!File.Exists(text))
								{
									Directory.CreateDirectory(Path.GetDirectoryName(text));
									File.Copy(mcLibToken.m_UtilsMapper, text);
								}
								if (ModBase.errorRule)
								{
									ModBase.Log("[Download] 复制的 Forge 支持库文件：" + mcLibToken.m_UtilsMapper, ModBase.LogLevel.Normal, "出现错误");
								}
							}
						}
						finally
						{
							List<ModMinecraft.McLibToken>.Enumerator enumerator;
							((IDisposable)enumerator).Dispose();
						}
					}
					if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_ClientDownloadLoader != null)
					{
						try
						{
							foreach (object obj in CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_ClientDownloadLoader.GetLoaderList(true))
							{
								object objectValue = RuntimeHelpers.GetObjectValue(obj);
								if (!Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null), "下载原版支持库文件", true))
								{
									NewLateBinding.LateCall(objectValue, null, "WaitForExit", new object[0], null, null, null, true);
									break;
								}
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
						if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_IsCustomFolder)
						{
							try
							{
								string name = new DirectoryInfo(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_ClientDownloadLoader.Input).Name;
								Directory.CreateDirectory(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_McFolder + "versions\\" + CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Inherit);
								if (!File.Exists(string.Concat(new string[]
								{
									CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_McFolder,
									"versions\\",
									CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Inherit,
									"\\",
									CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Inherit,
									".json"
								})))
								{
									File.Copy(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_ClientDownloadLoader.Input + name + ".json", string.Concat(new string[]
									{
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_McFolder,
										"versions\\",
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Inherit,
										"\\",
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Inherit,
										".json"
									}));
								}
								if (!File.Exists(string.Concat(new string[]
								{
									CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_McFolder,
									"versions\\",
									CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Inherit,
									"\\",
									CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Inherit,
									".jar"
								})))
								{
									File.Copy(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_ClientDownloadLoader.Input + name + ".jar", string.Concat(new string[]
									{
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_McFolder,
										"versions\\",
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Inherit,
										"\\",
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Inherit,
										".jar"
									}));
								}
							}
							catch (Exception ex)
							{
								ModBase.Log(ex, "安装 Forge 拷贝原版文件时出错", ModBase.LogLevel.Debug, "出现错误");
							}
						}
					}
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 0.1,
					Show = false
				});
				arrayList.Add(new ModLoader.LoaderTask<bool, bool>("安装 Mod 加载器（方式 A）", delegate(ModLoader.LoaderTask<bool, bool> Task)
				{
					ZipArchive zipArchive = null;
					try
					{
						ModDownloadLib._Closure$__33-2 CS$<>8__locals3 = new ModDownloadLib._Closure$__33-2(CS$<>8__locals3);
						ModBase.Log("[Download] 开始进行新版方式 Forge 安装：" + CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_InstallerAddress, ModBase.LogLevel.Normal, "出现错误");
						zipArchive = new ZipArchive(new FileStream(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_InstallerAddress, FileMode.Open));
						JObject jobject = (JObject)ModBase.GetJson(ModBase.ReadFile(zipArchive.GetEntry("install_profile.json").Open(), null));
						Directory.CreateDirectory(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_VersionFolder);
						CS$<>8__locals3.$VB$Local_OldList = new DirectoryInfo(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_McFolder + "versions\\").EnumerateDirectories().Select((ModDownloadLib._Closure$__.$I33-5 == null) ? (ModDownloadLib._Closure$__.$I33-5 = ((DirectoryInfo Info) => Info.FullName)) : ModDownloadLib._Closure$__.$I33-5).ToList<string>();
						Task.Progress = 0.04;
						ModMinecraft.McFolderLauncherProfilesJsonCreate(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_McFolder);
						Task.Progress = 0.05;
						ModBase.WriteFile(ModBase.m_GlobalRule + "Cache\\forge_installer.jar", ModBase.GetResources("ForgeInstaller"), false);
						Task.Progress = 0.06;
						ModDownloadLib.ForgeInjector(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_InstallerAddress, Task, CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_McFolder);
						Task.Progress = 0.97;
						List<DirectoryInfo> list = new DirectoryInfo(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_McFolder + "versions\\").EnumerateDirectories().SkipWhile((DirectoryInfo Info) => CS$<>8__locals3.$VB$Local_OldList.Contains(Info.FullName)).ToList<DirectoryInfo>();
						if (list.Count == 1)
						{
							list[0].EnumerateFiles().First<FileInfo>().CopyTo(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_VersionFolder + CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Id + ".json", true);
						}
						Directory.CreateDirectory(new ModMinecraft.McVersion(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_VersionFolder).GetPathIndie(true) + "mods\\");
					}
					catch (Exception innerException)
					{
						throw new Exception("安装新 Forge 版本失败", innerException);
					}
					try
					{
						if (zipArchive != null)
						{
							zipArchive.Dispose();
						}
						if (File.Exists(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_InstallerAddress))
						{
							MyWpfExtension.RunFactory().FileSystem.DeleteFile(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_InstallerAddress);
						}
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "安装 Forge 清理文件时出错", ModBase.LogLevel.Debug, "出现错误");
					}
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 10.0
				});
			}
			else
			{
				ModBase.Log("[Download] 检测为非新版 Forge：" + CS$<>8__locals1.$VB$Local_Version, ModBase.LogLevel.Normal, "出现错误");
				arrayList.Add(new ModLoader.LoaderTask<List<ModNet.NetFile>, bool>("安装 Mod 加载器（方式 B）", delegate(ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task)
				{
					ZipArchive zipArchive = null;
					try
					{
						zipArchive = new ZipArchive(new FileStream(CS$<>8__locals1.$VB$Local_InstallerAddress, FileMode.Open));
						Task.Progress = 0.2;
						JObject jobject = (JObject)ModBase.GetJson(ModBase.ReadFile(zipArchive.GetEntry("install_profile.json").Open(), null));
						Task.Progress = 0.4;
						Directory.CreateDirectory(CS$<>8__locals1.$VB$Local_VersionFolder);
						Task.Progress = 0.5;
						if (jobject["install"] == null)
						{
							ModBase.Log("[Download] 进行中版方式安装：" + CS$<>8__locals1.$VB$Local_InstallerAddress, ModBase.LogLevel.Normal, "出现错误");
							JObject jobject2 = (JObject)ModBase.GetJson(ModBase.ReadFile(zipArchive.GetEntry(jobject["json"].ToString().TrimStart(new char[]
							{
								'/'
							})).Open(), null));
							jobject2["id"] = CS$<>8__locals1.$VB$Local_Id;
							ModBase.WriteFile(CS$<>8__locals1.$VB$Local_VersionFolder + CS$<>8__locals1.$VB$Local_Id + ".json", jobject2.ToString(), false, null);
							Task.Progress = 0.6;
							zipArchive.Dispose();
							ZipFile.ExtractToDirectory(CS$<>8__locals1.$VB$Local_InstallerAddress, CS$<>8__locals1.$VB$Local_InstallerAddress + "_unrar\\");
							MyWpfExtension.RunFactory().FileSystem.CopyDirectory(CS$<>8__locals1.$VB$Local_InstallerAddress + "_unrar\\maven\\", CS$<>8__locals1.$VB$Local_McFolder + "libraries\\", true);
							ModBase.DeleteDirectory(CS$<>8__locals1.$VB$Local_InstallerAddress + "_unrar\\", false);
						}
						else
						{
							ModBase.Log("[Download] 进行旧版方式安装：" + CS$<>8__locals1.$VB$Local_InstallerAddress, ModBase.LogLevel.Normal, "出现错误");
							string text = ModMinecraft.McLibGet((string)jobject["install"]["path"], true, false, CS$<>8__locals1.$VB$Local_McFolder);
							if (File.Exists(text))
							{
								File.Delete(text);
							}
							ModBase.WriteFile(text, zipArchive.GetEntry((string)jobject["install"]["filePath"]).Open());
							Task.Progress = 0.9;
							jobject["versionInfo"]["id"] = CS$<>8__locals1.$VB$Local_Id;
							if (jobject["versionInfo"]["inheritsFrom"] == null)
							{
								((JObject)jobject["versionInfo"]).Add("inheritsFrom", CS$<>8__locals1.$VB$Local_Inherit);
							}
							ModBase.WriteFile(CS$<>8__locals1.$VB$Local_VersionFolder + CS$<>8__locals1.$VB$Local_Id + ".json", jobject["versionInfo"].ToString(), false, null);
						}
						Directory.CreateDirectory(new ModMinecraft.McVersion(CS$<>8__locals1.$VB$Local_VersionFolder).GetPathIndie(true) + "mods\\");
					}
					catch (Exception innerException)
					{
						throw new Exception("非新版方式安装 Forge 失败", innerException);
					}
					try
					{
						if (zipArchive != null)
						{
							zipArchive.Dispose();
						}
						if (File.Exists(CS$<>8__locals1.$VB$Local_InstallerAddress))
						{
							MyWpfExtension.RunFactory().FileSystem.DeleteFile(CS$<>8__locals1.$VB$Local_InstallerAddress);
						}
						if (Directory.Exists(CS$<>8__locals1.$VB$Local_InstallerAddress + "_unrar\\"))
						{
							ModBase.DeleteDirectory(CS$<>8__locals1.$VB$Local_InstallerAddress + "_unrar\\", false);
						}
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "非新版方式安装 Forge 清理文件时出错", ModBase.LogLevel.Debug, "出现错误");
					}
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 1.0
				});
				if (FixLibrary)
				{
					if (CS$<>8__locals1.$VB$Local_IsCustomFolder)
					{
						throw new Exception("若需要补全支持库，就不能自定义 MC 文件夹");
					}
					arrayList.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析 Mod 加载器支持库文件", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
					{
						Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McVersion(CS$<>8__locals1.$VB$Local_VersionFolder), false);
					}, null, ThreadPriority.Normal)
					{
						ProgressWeight = 1.0,
						Show = false
					});
					arrayList.Add(new ModNet.LoaderDownload("下载 Mod 加载器支持库文件", new List<ModNet.NetFile>())
					{
						ProgressWeight = 11.0
					});
				}
			}
			return arrayList;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0001E9CC File Offset: 0x0001CBCC
		public static void ForgeDownloadListItemPreload(StackPanel Stack, List<ModDownload.DlForgeVersionEntry> Entrys, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
		{
			ModDownload.DlForgeVersionEntry dlForgeVersionEntry = null;
			if (Entrys.Count > 0)
			{
				dlForgeVersionEntry = Entrys[0];
			}
			else
			{
				ModBase.Log("[System] 未找到可用的 Forge 版本", ModBase.LogLevel.Debug, "出现错误");
			}
			ModDownload.DlForgeVersionEntry dlForgeVersionEntry2 = null;
			try
			{
				foreach (ModDownload.DlForgeVersionEntry dlForgeVersionEntry3 in Entrys)
				{
					if (dlForgeVersionEntry3.resolverAlgo)
					{
						dlForgeVersionEntry2 = dlForgeVersionEntry3;
					}
				}
			}
			finally
			{
				List<ModDownload.DlForgeVersionEntry>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			if (dlForgeVersionEntry != null && dlForgeVersionEntry == dlForgeVersionEntry2)
			{
				dlForgeVersionEntry = null;
			}
			if (dlForgeVersionEntry2 != null)
			{
				MyListItem myListItem = ModDownloadLib.ForgeDownloadListItem(dlForgeVersionEntry2, OnClick, IsSaveOnly);
				myListItem.Info = "推荐版" + ((Operators.CompareString(myListItem.Info, "", true) == 0) ? "" : ("，" + myListItem.Info));
				Stack.Children.Add(myListItem);
			}
			if (dlForgeVersionEntry != null)
			{
				MyListItem myListItem2 = ModDownloadLib.ForgeDownloadListItem(dlForgeVersionEntry, OnClick, IsSaveOnly);
				myListItem2.Info = "最新版" + ((Operators.CompareString(myListItem2.Info, "", true) == 0) ? "" : ("，" + myListItem2.Info));
				Stack.Children.Add(myListItem2);
			}
			Stack.Children.Add(new TextBlock
			{
				Text = "全部版本 (" + Conversions.ToString(Entrys.Count) + ")",
				HorizontalAlignment = HorizontalAlignment.Left,
				Margin = new Thickness(6.0, 13.0, 0.0, 4.0)
			});
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0001EB64 File Offset: 0x0001CD64
		public static MyListItem ForgeDownloadListItem(ModDownload.DlForgeVersionEntry Entry, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
		{
			MyListItem myListItem = new MyListItem
			{
				Title = Entry._ConfigurationAlgo,
				SnapsToDevicePixels = true,
				Height = 42.0,
				Type = MyListItem.CheckType.Clickable,
				Tag = Entry,
				PaddingRight = 0x3C,
				Info = ((Operators.CompareString(Entry.m_PredicateAlgo, "", true) == 0) ? (ModBase.errorRule ? ("种类：" + Entry._CollectionAlgo + ((Entry.testsAlgo == null) ? "" : ("，开发分支：" + Entry.testsAlgo))) : "") : ("发布于 " + Entry.m_PredicateAlgo + (ModBase.errorRule ? ("，种类：" + Entry._CollectionAlgo + ((Entry.testsAlgo == null) ? "" : ("，开发分支：" + Entry.testsAlgo))) : ""))),
				Logo = "pack://application:,,,/images/Blocks/Anvil.png"
			};
			myListItem.QueryModel(OnClick);
			if (IsSaveOnly)
			{
				myListItem.utilsDecorator = ((ModDownloadLib._Closure$__.$IR35-17 == null) ? (ModDownloadLib._Closure$__.$IR35-17 = delegate(object sender, EventArgs e)
				{
					ModDownloadLib.ForgeSaveContMenuBuild((MyListItem)sender, e);
				}) : ModDownloadLib._Closure$__.$IR35-17);
			}
			else
			{
				myListItem.utilsDecorator = ((ModDownloadLib._Closure$__.$IR35-18 == null) ? (ModDownloadLib._Closure$__.$IR35-18 = delegate(object sender, EventArgs e)
				{
					ModDownloadLib.ForgeContMenuBuild((MyListItem)sender, e);
				}) : ModDownloadLib._Closure$__.$IR35-18);
			}
			return myListItem;
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0001ECC0 File Offset: 0x0001CEC0
		private static void ForgeContMenuBuild(MyListItem sender, EventArgs e)
		{
			MyIconButton myIconButton = new MyIconButton
			{
				Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z",
				ToolTip = "另存为"
			};
			ToolTipService.SetPlacement(myIconButton, PlacementMode.Center);
			ToolTipService.SetVerticalOffset(myIconButton, 30.0);
			ToolTipService.SetHorizontalOffset(myIconButton, 2.0);
			myIconButton.Click += ((ModDownloadLib._Closure$__.$IR36-19 == null) ? (ModDownloadLib._Closure$__.$IR36-19 = delegate(object sender, EventArgs e)
			{
				ModDownloadLib.ForgeSave_Click(RuntimeHelpers.GetObjectValue(sender), (RoutedEventArgs)e);
			}) : ModDownloadLib._Closure$__.$IR36-19);
			MyIconButton myIconButton2 = new MyIconButton
			{
				LogoScale = 1.05,
				Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z",
				ToolTip = "更新日志"
			};
			ToolTipService.SetPlacement(myIconButton2, PlacementMode.Center);
			ToolTipService.SetVerticalOffset(myIconButton2, 30.0);
			ToolTipService.SetHorizontalOffset(myIconButton2, 2.0);
			myIconButton2.Click += ((ModDownloadLib._Closure$__.$IR36-20 == null) ? (ModDownloadLib._Closure$__.$IR36-20 = delegate(object sender, EventArgs e)
			{
				ModDownloadLib.ForgeLog_Click(RuntimeHelpers.GetObjectValue(sender), (RoutedEventArgs)e);
			}) : ModDownloadLib._Closure$__.$IR36-20);
			sender2.Buttons = new MyIconButton[]
			{
				myIconButton,
				myIconButton2
			};
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0001EDC8 File Offset: 0x0001CFC8
		private static void ForgeSaveContMenuBuild(MyListItem sender, EventArgs e)
		{
			MyIconButton myIconButton = new MyIconButton
			{
				LogoScale = 1.05,
				Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z",
				ToolTip = "更新日志"
			};
			ToolTipService.SetPlacement(myIconButton, PlacementMode.Center);
			ToolTipService.SetVerticalOffset(myIconButton, 30.0);
			ToolTipService.SetHorizontalOffset(myIconButton, 2.0);
			myIconButton.Click += ((ModDownloadLib._Closure$__.$IR37-21 == null) ? (ModDownloadLib._Closure$__.$IR37-21 = delegate(object sender, EventArgs e)
			{
				ModDownloadLib.ForgeLog_Click(RuntimeHelpers.GetObjectValue(sender), (RoutedEventArgs)e);
			}) : ModDownloadLib._Closure$__.$IR37-21);
			sender2.Buttons = new MyIconButton[]
			{
				myIconButton
			};
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0001EE60 File Offset: 0x0001D060
		private static void ForgeLog_Click(object sender, RoutedEventArgs e)
		{
			ModDownload.DlForgeVersionEntry dlForgeVersionEntry;
			if (NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) != null)
			{
				dlForgeVersionEntry = (ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null);
			}
			else if (NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null) != null)
			{
				dlForgeVersionEntry = (ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null);
			}
			else
			{
				dlForgeVersionEntry = (ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null);
			}
			ModBase.OpenWebsite(string.Concat(new string[]
			{
				"http://files.minecraftforge.net/maven/net/minecraftforge/forge/",
				dlForgeVersionEntry.interpreterAlgo,
				"-",
				dlForgeVersionEntry._ConfigurationAlgo,
				"/forge-",
				dlForgeVersionEntry.interpreterAlgo,
				"-",
				dlForgeVersionEntry._ConfigurationAlgo,
				"-changelog.txt"
			}));
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0001EFA0 File Offset: 0x0001D1A0
		public static void ForgeSave_Click(object sender, RoutedEventArgs e)
		{
			ModDownload.DlForgeVersionEntry downloadInfo;
			if (NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) != null)
			{
				downloadInfo = (ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null);
			}
			else if (NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null) != null)
			{
				downloadInfo = (ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null);
			}
			else
			{
				downloadInfo = (ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null);
			}
			ModDownloadLib.McDownloadForgeSave(downloadInfo);
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00003BD4 File Offset: 0x00001DD4
		public static void McDownloadForgeRecommendedRefresh()
		{
			if (!ModDownloadLib.m_PoolVal)
			{
				ModDownloadLib.m_PoolVal = true;
				ModBase.RunInNewThread((ModDownloadLib._Closure$__.$I40-0 == null) ? (ModDownloadLib._Closure$__.$I40-0 = delegate()
				{
					try
					{
						ModBase.Log("[Download] 刷新 Forge 推荐版本缓存开始", ModBase.LogLevel.Normal, "出现错误");
						string text = ModNet.NetGetCodeByDownload(new string[]
						{
							"https://bmclapi2.bangbang93.com/forge/promos",
							"https://download.mcbbs.net/forge/promos"
						}, 0xAFC8, false);
						if (text.Length < 0x3E8)
						{
							throw new Exception("获取的结果过短（" + text + "）");
						}
						JContainer jcontainer = (JContainer)ModBase.GetJson(text);
						List<string> list = new List<string>();
						try
						{
							foreach (JToken jtoken in ((IEnumerable<JToken>)jcontainer))
							{
								JObject jobject = (JObject)jtoken;
								if (jobject["name"] != null && jobject["build"] != null)
								{
									string text2 = (string)jobject["name"];
									if (text2.EndsWith("-recommended"))
									{
										list.Add("\"" + text2.Replace("-recommended", "\":\"" + jobject["build"]["version"].ToString() + "\""));
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
						if (list.Count < 5)
						{
							throw new Exception("获取的推荐版本数过少（" + text + "）");
						}
						string text3 = "{" + ModBase.Join(list, ",") + "}";
						ModBase.WriteFile(ModBase.m_GlobalRule + "Cache\\ForgeRecommendedList.json", text3, false, null);
						ModBase.Log("[Download] 刷新 Forge 推荐版本缓存成功", ModBase.LogLevel.Normal, "出现错误");
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "刷新 Forge 推荐版本缓存失败", ModBase.LogLevel.Debug, "出现错误");
					}
				}) : ModDownloadLib._Closure$__.$I40-0, "ForgeRecommendedRefresh", ThreadPriority.Normal);
			}
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0001F08C File Offset: 0x0001D28C
		public static string McDownloadForgeRecommendedGet(string McVersion)
		{
			string result;
			try
			{
				if (McVersion == null)
				{
					result = null;
				}
				else
				{
					string text = ModBase.ReadFile(ModBase.m_GlobalRule + "Cache\\ForgeRecommendedList.json");
					if (text != null && Operators.CompareString(text, "", true) != 0)
					{
						JObject jobject = (JObject)ModBase.GetJson(text);
						if (jobject != null && (McVersion ?? "null").Contains(".") && jobject.ContainsKey(McVersion))
						{
							result = (jobject[McVersion] ?? "").ToString();
						}
						else
						{
							result = null;
						}
					}
					else
					{
						ModBase.Log("[Download] 没有 Forge 推荐版本缓存文件", ModBase.LogLevel.Normal, "出现错误");
						result = null;
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "获取 Forge 推荐版本失败（" + (McVersion ?? "null") + "）", ModBase.LogLevel.Feedback, "出现错误");
				result = null;
			}
			return result;
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0001F174 File Offset: 0x0001D374
		public static void McDownloadFabricLoaderSave(JObject DownloadInfo)
		{
			checked
			{
				try
				{
					string text = DownloadInfo["url"].ToString();
					string fileNameFromPath = ModBase.GetFileNameFromPath(text);
					string fileNameFromPath2 = ModBase.GetFileNameFromPath(DownloadInfo["version"].ToString());
					string text2 = ModBase.SelectAs("选择保存位置", fileNameFromPath, "Fabric 安装器 (*.jar)|*.jar", null);
					if (text2.Contains("\\"))
					{
						object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
						ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
						lock (loaderTaskbarLock)
						{
							int num = ModLoader.LoaderTaskbar.Count - 1;
							for (int i = 0; i <= num; i++)
							{
								if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(ModLoader.LoaderTaskbar[i], null, "Name", new object[0], null, null, null), "Fabric " + fileNameFromPath2 + " 安装器下载", true))
								{
									ModMain.Hint("该版本正在下载中！", ModMain.HintType.Critical, true);
									return;
								}
							}
						}
						ArrayList arrayList = new ArrayList();
						List<string> list = new List<string>();
						list.Add(text);
						arrayList.Add(new ModNet.LoaderDownload("下载主文件", new List<ModNet.NetFile>
						{
							new ModNet.NetFile(list.ToArray(), text2, new ModBase.FileChecker(0x10000L, -1L, null, null, true, false))
						})
						{
							ProgressWeight = 15.0
						});
						ModLoader.LoaderCombo<JObject> loaderCombo = new ModLoader.LoaderCombo<JObject>("Fabric " + fileNameFromPath2 + " 安装器下载", arrayList);
						loaderCombo.OnStateChanged = new ModLoader.LoaderStateDelegate(ModDownloadLib.DownloadStateSave);
						loaderCombo.Start(DownloadInfo, false);
						ModLoader.LoaderTaskbarAdd(loaderCombo);
						ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
						ModMain.m_GetterFilter.BtnExtraDownload.Ribble();
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "开始 Fabric 安装器下载失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0001F378 File Offset: 0x0001D578
		private static ArrayList McDownloadFabricLoader(string FabricVersion, string MinecraftName, string McFolder = null, bool FixLibrary = true)
		{
			McFolder = (McFolder ?? ModMinecraft.m_ResolverIterator);
			Operators.CompareString(McFolder, ModMinecraft.m_ResolverIterator, true);
			string Id = "fabric-loader-" + FabricVersion + "-" + MinecraftName;
			string VersionFolder = McFolder + "versions\\" + Id + "\\";
			ArrayList arrayList = new ArrayList();
			arrayList.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("获取 Fabric 主文件下载地址", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
			{
				if (FixLibrary)
				{
					ModDownloadLib.McDownloadClient(ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading, MinecraftName, null);
				}
				Task.Progress = 0.5;
				Task.Output = new List<ModNet.NetFile>
				{
					new ModNet.NetFile(new string[]
					{
						string.Concat(new string[]
						{
							"https://download.mcbbs.net/fabric-meta/v2/versions/loader/",
							MinecraftName,
							"/",
							FabricVersion,
							"/profile/json"
						}),
						string.Concat(new string[]
						{
							"https://meta.fabricmc.net/v2/versions/loader/",
							MinecraftName,
							"/",
							FabricVersion,
							"/profile/json"
						})
					}, VersionFolder + Id + ".json", new ModBase.FileChecker(-1L, -1L, null, null, true, true))
				};
				Directory.CreateDirectory(new ModMinecraft.McVersion(VersionFolder).GetPathIndie(true) + "mods\\");
			}, null, ThreadPriority.Normal)
			{
				ProgressWeight = 0.5
			});
			arrayList.Add(new ModNet.LoaderDownload("下载 Fabric 主文件", new List<ModNet.NetFile>())
			{
				ProgressWeight = 2.5
			});
			if (FixLibrary)
			{
				arrayList.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析 Fabric 支持库文件", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
				{
					Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McVersion(VersionFolder), false);
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 1.0,
					Show = false
				});
				arrayList.Add(new ModNet.LoaderDownload("下载 Fabric 支持库文件", new List<ModNet.NetFile>())
				{
					ProgressWeight = 8.0
				});
			}
			return arrayList;
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0001F4B4 File Offset: 0x0001D6B4
		public static MyListItem FabricDownloadListItem(JObject Entry, MyListItem.ClickEventHandler OnClick)
		{
			MyListItem myListItem = new MyListItem();
			myListItem.Title = Entry["version"].ToString().Replace("+build", "");
			myListItem.SnapsToDevicePixels = true;
			myListItem.Height = 42.0;
			myListItem.Type = MyListItem.CheckType.Clickable;
			myListItem.Tag = Entry;
			myListItem.PaddingRight = 0x3C;
			myListItem.Info = (Entry["stable"].ToObject<bool>() ? "稳定版" : "测试版");
			myListItem.Logo = "pack://application:,,,/images/Blocks/Fabric.png";
			myListItem.QueryModel(OnClick);
			return myListItem;
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x0001F550 File Offset: 0x0001D750
		public static MyListItem FabricApiDownloadListItem(ModDownload.DlCfFile Entry, MyListItem.ClickEventHandler OnClick)
		{
			MyListItem myListItem = new MyListItem
			{
				Title = Entry.m_InterceptorAlgo.Split(new char[]
				{
					']'
				})[1].Replace("Fabric API ", "").Replace(" build ", ".").Trim(),
				SnapsToDevicePixels = true,
				Height = 42.0,
				Type = MyListItem.CheckType.Clickable,
				Tag = Entry,
				PaddingRight = 0x3C,
				Info = Entry.CountExpression() + "，发布于 " + Entry.invocationAlgo.ToString("yyyy/MM/dd HH:mm"),
				Logo = "pack://application:,,,/images/Blocks/Fabric.png"
			};
			myListItem.QueryModel(OnClick);
			return myListItem;
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0001F60C File Offset: 0x0001D80C
		public static void McInstallState(object Loader)
		{
			object left = NewLateBinding.LateGet(Loader, null, "State", new object[0], null, null, null);
			if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Finished, true))
			{
				ModBase.WriteIni(ModMinecraft.m_ResolverIterator + "PCL.ini", "VersionCache", "");
				ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, null, "Name", new object[0], null, null, null), "成功！")), ModMain.HintType.Finish, true);
			}
			else if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Failed, true))
			{
				object left2 = Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, null, "Name", new object[0], null, null, null), "失败：");
				object[] array;
				bool[] array2;
				object right = NewLateBinding.LateGet(null, typeof(ModBase), "GetString", array = new object[]
				{
					NewLateBinding.LateGet(Loader, null, "Error", new object[0], null, null, null)
				}, null, null, array2 = new bool[]
				{
					true
				});
				if (array2[0])
				{
					NewLateBinding.LateSetComplex(Loader, null, "Error", new object[]
					{
						array[0]
					}, null, null, true, false);
				}
				ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject(left2, right)), ModMain.HintType.Critical, true);
			}
			else if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Aborted, true))
			{
				ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, null, "Name", new object[0], null, null, null), "已取消！")), ModMain.HintType.Info, true);
			}
			else if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Loading, true))
			{
				return;
			}
			ModDownloadLib.McInstallFailedClearFolder(RuntimeHelpers.GetObjectValue(Loader));
			ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", false);
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0001F7A8 File Offset: 0x0001D9A8
		public static void DownloadStateSave(object Loader)
		{
			object left = NewLateBinding.LateGet(Loader, null, "State", new object[0], null, null, null);
			if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Finished, true))
			{
				ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, null, "Name", new object[0], null, null, null), "成功！")), ModMain.HintType.Finish, true);
				return;
			}
			if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Failed, true))
			{
				object left2 = Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, null, "Name", new object[0], null, null, null), "失败：");
				object[] array;
				bool[] array2;
				object right = NewLateBinding.LateGet(null, typeof(ModBase), "GetString", array = new object[]
				{
					NewLateBinding.LateGet(Loader, null, "Error", new object[0], null, null, null)
				}, null, null, array2 = new bool[]
				{
					true
				});
				if (array2[0])
				{
					NewLateBinding.LateSetComplex(Loader, null, "Error", new object[]
					{
						array[0]
					}, null, null, true, false);
				}
				ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject(left2, right)), ModMain.HintType.Critical, true);
				return;
			}
			if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Aborted, true))
			{
				ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, null, "Name", new object[0], null, null, null), "已取消！")), ModMain.HintType.Info, true);
				return;
			}
			Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Loading, true);
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0001F8FC File Offset: 0x0001DAFC
		public static void McInstallFailedClearFolder(object Loader)
		{
			try
			{
				if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(Loader, null, "State", new object[0], null, null, null), ModBase.LoadState.Failed, true) || Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(Loader, null, "State", new object[0], null, null, null), ModBase.LoadState.Aborted, true))
				{
					if (Directory.Exists(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, null, "Input", new object[0], null, null, null), "saves\\"))))
					{
						ModBase.Log(Conversions.ToString(Operators.ConcatenateObject("[Download] 由于版本已被独立启动，不清理版本文件夹：", NewLateBinding.LateGet(Loader, null, "Input", new object[0], null, null, null))), ModBase.LogLevel.Developer, "出现错误");
					}
					else
					{
						ModBase.Log(Conversions.ToString(Operators.ConcatenateObject("[Download] 由于下载失败或取消，清理版本文件夹：", NewLateBinding.LateGet(Loader, null, "Input", new object[0], null, null, null))), ModBase.LogLevel.Developer, "出现错误");
						ModBase.DeleteDirectory(Conversions.ToString(NewLateBinding.LateGet(Loader, null, "Input", new object[0], null, null, null)), false);
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "下载失败或取消后清理版本文件夹失败", ModBase.LogLevel.Debug, "出现错误");
			}
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0001FA30 File Offset: 0x0001DC30
		public static bool McInstall(ModDownloadLib.McInstallRequest Request)
		{
			bool result;
			try
			{
				ArrayList arrayList = ModDownloadLib.McInstallLoader(Request, false);
				if (arrayList == null)
				{
					result = false;
				}
				else
				{
					ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(Request.m_CandidateRule + " 安装", arrayList);
					loaderCombo.OnStateChanged = new ModLoader.LoaderStateDelegate(ModDownloadLib.McInstallState);
					loaderCombo.Start(ModMinecraft.m_ResolverIterator + "versions\\" + Request.m_CandidateRule + "\\", false);
					ModLoader.LoaderTaskbarAdd(loaderCombo);
					ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
					ModMain.m_GetterFilter.BtnExtraDownload.Ribble();
					result = true;
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "开始合并安装失败", ModBase.LogLevel.Feedback, "出现错误");
				result = false;
			}
			return result;
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0001FAF4 File Offset: 0x0001DCF4
		public static ArrayList McInstallLoader(ModDownloadLib.McInstallRequest Request, bool DontFixLibraries = false)
		{
			try
			{
				if (!ModDownloadLib.parserVal)
				{
					ModDownloadLib.parserVal = true;
					ModBase.DeleteDirectory(ModBase.m_GlobalRule + "Install\\", true);
					ModBase.Log("[Download] 已清理合并安装缓存", ModBase.LogLevel.Normal, "出现错误");
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "清理合并安装缓存失败", ModBase.LogLevel.Debug, "出现错误");
			}
			string OutputFolder = ModMinecraft.m_ResolverIterator + "versions\\" + Request.m_CandidateRule + "\\";
			string TempMcFolder = ModBase.m_GlobalRule + "Install\\" + Request.m_CandidateRule + "\\";
			if (Directory.Exists(TempMcFolder))
			{
				ModBase.DeleteDirectory(TempMcFolder, false);
			}
			string OptiFineFolder = null;
			if (Request.m_ObserverRule != null)
			{
				ModDownloadLib.McInstallRequest $VB$Local_Request = Request;
				ModDownload.DlOptiFineListEntry dlOptiFineListEntry = new ModDownload.DlOptiFineListEntry();
				dlOptiFineListEntry.m_RepositoryAlgo = Request.m_DescriptorRule + " " + Request.m_ObserverRule.Replace("HD_U_", "").Replace("_", "");
				dlOptiFineListEntry.InvokeExpression(Request.m_DescriptorRule);
				dlOptiFineListEntry.m_PrototypeAlgo = Request.m_ObserverRule.ToLower().Contains("pre");
				dlOptiFineListEntry.m_ProccesorAlgo = Request.m_DescriptorRule + "-OptiFine_" + Request.m_ObserverRule;
				dlOptiFineListEntry.m_SystemAlgo = string.Concat(new string[]
				{
					Request.m_ObserverRule.ToLower().Contains("pre") ? "preview_" : "",
					"OptiFine_",
					Request.m_DescriptorRule,
					"_",
					Request.m_ObserverRule,
					".jar"
				});
				$VB$Local_Request._TokenizerRule = dlOptiFineListEntry;
			}
			if (Request._TokenizerRule != null)
			{
				OptiFineFolder = TempMcFolder + "versions\\" + Request._TokenizerRule.m_ProccesorAlgo;
			}
			string ForgeFolder = null;
			if (Request.tagRule != null)
			{
				Request._DispatcherRule = (Request._DispatcherRule ?? Request.tagRule._ConfigurationAlgo);
			}
			if (Request._DispatcherRule != null)
			{
				ForgeFolder = string.Concat(new string[]
				{
					TempMcFolder,
					"versions\\",
					Request.m_DescriptorRule,
					"-forge-",
					Request._DispatcherRule
				});
			}
			string FabricFolder = null;
			if (Request._InitializerRule != null)
			{
				FabricFolder = string.Concat(new string[]
				{
					TempMcFolder,
					"versions\\fabric-loader-",
					Request._InitializerRule,
					"-",
					Request.m_DescriptorRule
				});
			}
			string LiteLoaderFolder = null;
			if (Request.m_WatcherRule != null)
			{
				LiteLoaderFolder = TempMcFolder + "versions\\" + Request.m_DescriptorRule + "-LiteLoader";
			}
			bool OptiFineAsMod = (Request._TokenizerRule != null || Request.m_ObserverRule != null) && (Request._DispatcherRule != null || Request._InitializerRule != null) && Request.m_DescriptorRule.StartsWith("1.") && ModBase.Val(Request.m_DescriptorRule.Split(new char[]
			{
				'.'
			})[1]) < 17.0;
			if (OptiFineAsMod)
			{
				ModBase.Log("[Download] OptiFine 将作为 Mod 进行下载", ModBase.LogLevel.Normal, "出现错误");
				OptiFineFolder = new ModMinecraft.McVersion(OutputFolder).GetPathIndie(true) + "mods\\";
			}
			if (OptiFineFolder != null)
			{
				ModBase.Log("[Download] OptiFine 缓存：" + OptiFineFolder, ModBase.LogLevel.Normal, "出现错误");
			}
			if (ForgeFolder != null)
			{
				ModBase.Log("[Download] Forge 缓存：" + ForgeFolder, ModBase.LogLevel.Normal, "出现错误");
			}
			if (FabricFolder != null)
			{
				ModBase.Log("[Download] Fabric 缓存：" + FabricFolder, ModBase.LogLevel.Normal, "出现错误");
			}
			if (LiteLoaderFolder != null)
			{
				ModBase.Log("[Download] LiteLoader 缓存：" + LiteLoaderFolder, ModBase.LogLevel.Normal, "出现错误");
			}
			ModBase.Log("[Download] 对应的原版版本：" + Request.m_DescriptorRule, ModBase.LogLevel.Normal, "出现错误");
			ArrayList result;
			if (File.Exists(OutputFolder + Request.m_CandidateRule + ".json"))
			{
				ModMain.Hint("版本 " + Request.m_CandidateRule + " 已经存在！", ModMain.HintType.Critical, true);
				result = null;
			}
			else
			{
				ArrayList arrayList = new ArrayList();
				if (Request._PropertyRule != null)
				{
					arrayList.Add(new ModNet.LoaderDownload("下载 Fabric API", new List<ModNet.NetFile>
					{
						Request._PropertyRule.GetDownloadFile(new ModMinecraft.McVersion(OutputFolder).GetPathIndie(true) + "mods\\", false)
					})
					{
						ProgressWeight = 3.0,
						Block = false
					});
				}
				ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("下载原版 " + Request.m_DescriptorRule, ModDownloadLib.McDownloadClientLoader(Request.m_DescriptorRule, Request.contextRule, Request.m_CandidateRule))
				{
					Show = false,
					ProgressWeight = 39.0,
					Block = (Request._DispatcherRule == null && Request._TokenizerRule == null && Request._InitializerRule == null && Request.m_WatcherRule == null)
				};
				arrayList.Add(loaderCombo);
				if (Request._TokenizerRule != null)
				{
					if (OptiFineAsMod)
					{
						arrayList.Add(new ModLoader.LoaderCombo<string>("下载 OptiFine " + Request._TokenizerRule.m_RepositoryAlgo, ModDownloadLib.McDownloadOptiFineSaveLoader(Request._TokenizerRule, OptiFineFolder + Request._TokenizerRule.m_SystemAlgo))
						{
							Show = false,
							ProgressWeight = 16.0,
							Block = (Request._DispatcherRule == null && Request._InitializerRule == null && Request.m_WatcherRule == null)
						});
					}
					else
					{
						arrayList.Add(new ModLoader.LoaderCombo<string>("下载 OptiFine " + Request._TokenizerRule.m_RepositoryAlgo, ModDownloadLib.McDownloadOptiFineLoader(Request._TokenizerRule, TempMcFolder, loaderCombo, false))
						{
							Show = false,
							ProgressWeight = 24.0,
							Block = (Request._DispatcherRule == null && Request._InitializerRule == null && Request.m_WatcherRule == null)
						});
					}
				}
				if (Request._DispatcherRule != null)
				{
					arrayList.Add(new ModLoader.LoaderCombo<string>("下载 Forge " + Request._DispatcherRule, ModDownloadLib.McDownloadForgeLoader(Request._DispatcherRule, Request.m_DescriptorRule, Request.tagRule, TempMcFolder, loaderCombo, false))
					{
						Show = false,
						ProgressWeight = 25.0,
						Block = (Request._InitializerRule == null && Request.m_WatcherRule == null)
					});
				}
				if (Request.m_WatcherRule != null)
				{
					arrayList.Add(new ModLoader.LoaderCombo<string>("下载 LiteLoader " + Request.m_DescriptorRule, ModDownloadLib.McDownloadLiteLoaderLoader(Request.m_WatcherRule, TempMcFolder, loaderCombo, false))
					{
						Show = false,
						ProgressWeight = 1.0,
						Block = (Request._InitializerRule == null)
					});
				}
				if (Request._InitializerRule != null)
				{
					arrayList.Add(new ModLoader.LoaderCombo<string>("下载 Fabric " + Request._InitializerRule, ModDownloadLib.McDownloadFabricLoader(Request._InitializerRule, Request.m_DescriptorRule, TempMcFolder, false))
					{
						Show = false,
						ProgressWeight = 2.0,
						Block = true
					});
				}
				arrayList.Add(new ModLoader.LoaderTask<string, string>("安装游戏", delegate(ModLoader.LoaderTask<string, string> Task)
				{
					ModDownloadLib.InstallMerge(OutputFolder, OutputFolder, OptiFineFolder, OptiFineAsMod, ForgeFolder, Request._DispatcherRule, FabricFolder, LiteLoaderFolder);
					Task.Progress = 0.3;
					if (Directory.Exists(TempMcFolder + "libraries"))
					{
						MyWpfExtension.RunFactory().FileSystem.CopyDirectory(TempMcFolder + "libraries", ModMinecraft.m_ResolverIterator + "libraries", true);
					}
					if (Directory.Exists(TempMcFolder + "mods"))
					{
						MyWpfExtension.RunFactory().FileSystem.CopyDirectory(TempMcFolder + "mods", ModMinecraft.m_ResolverIterator + "mods", true);
					}
				}, null, ThreadPriority.Normal)
				{
					ProgressWeight = 2.0,
					Block = true
				});
				if (!DontFixLibraries && (Request._TokenizerRule != null || (Request._DispatcherRule != null && Conversions.ToDouble(Request._DispatcherRule.Split(new char[]
				{
					'.'
				})[0]) >= 20.0) || Request._InitializerRule != null || Request.m_WatcherRule != null))
				{
					arrayList.Add(new ModLoader.LoaderCombo<string>("下载游戏支持库文件", new ArrayList
					{
						new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析游戏支持库文件（副加载器）", delegate(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
						{
							Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McVersion(OutputFolder), false);
						}, null, ThreadPriority.Normal)
						{
							ProgressWeight = 1.0,
							Show = false
						},
						new ModNet.LoaderDownload("下载游戏支持库文件（副加载器）", new List<ModNet.NetFile>())
						{
							ProgressWeight = 7.0,
							Show = false
						}
					})
					{
						ProgressWeight = 8.0
					});
				}
				result = arrayList;
			}
			return result;
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00020508 File Offset: 0x0001E708
		private static void InstallMerge(string OutputFolder, string MinecraftFolder, string OptiFineFolder = null, bool OptiFineAsMod = false, string ForgeFolder = null, string ForgeVersion = null, string FabricFolder = null, string LiteLoaderFolder = null)
		{
			ModBase.Log(string.Concat(new string[]
			{
				"[Download] 开始进行版本合并，输出：",
				OutputFolder,
				"，Minecraft：",
				MinecraftFolder,
				(OptiFineFolder != null) ? ("，OptiFine：" + OptiFineFolder) : "",
				(ForgeFolder != null) ? ("，Forge：" + ForgeFolder) : "",
				(LiteLoaderFolder != null) ? ("，LiteLoader：" + LiteLoaderFolder) : "",
				(FabricFolder != null) ? ("，Fabric：" + FabricFolder) : ""
			}), ModBase.LogLevel.Normal, "出现错误");
			Directory.CreateDirectory(OutputFolder);
			bool flag = OptiFineFolder != null && !OptiFineAsMod;
			bool flag2 = ForgeFolder != null;
			bool flag3 = LiteLoaderFolder != null;
			bool flag4 = FabricFolder != null;
			string text = null;
			string text2 = null;
			string text3 = null;
			string text4 = null;
			if (!OutputFolder.EndsWith("\\"))
			{
				OutputFolder += "\\";
			}
			string folderNameFromPath = ModBase.GetFolderNameFromPath(OutputFolder);
			string filePath = OutputFolder + folderNameFromPath + ".json";
			string text5 = OutputFolder + folderNameFromPath + ".jar";
			if (!MinecraftFolder.EndsWith("\\"))
			{
				MinecraftFolder += "\\";
			}
			string folderNameFromPath2 = ModBase.GetFolderNameFromPath(MinecraftFolder);
			string text6 = MinecraftFolder + folderNameFromPath2 + ".json";
			string text7 = MinecraftFolder + folderNameFromPath2 + ".jar";
			if (flag)
			{
				if (!OptiFineFolder.EndsWith("\\"))
				{
					OptiFineFolder += "\\";
				}
				string folderNameFromPath3 = ModBase.GetFolderNameFromPath(OptiFineFolder);
				text = OptiFineFolder + folderNameFromPath3 + ".json";
			}
			if (flag2)
			{
				if (!ForgeFolder.EndsWith("\\"))
				{
					ForgeFolder += "\\";
				}
				string folderNameFromPath4 = ModBase.GetFolderNameFromPath(ForgeFolder);
				text2 = ForgeFolder + folderNameFromPath4 + ".json";
			}
			if (flag3)
			{
				if (!LiteLoaderFolder.EndsWith("\\"))
				{
					LiteLoaderFolder += "\\";
				}
				string folderNameFromPath5 = ModBase.GetFolderNameFromPath(LiteLoaderFolder);
				text3 = LiteLoaderFolder + folderNameFromPath5 + ".json";
			}
			if (flag4)
			{
				if (!FabricFolder.EndsWith("\\"))
				{
					FabricFolder += "\\";
				}
				string folderNameFromPath6 = ModBase.GetFolderNameFromPath(FabricFolder);
				text4 = FabricFolder + folderNameFromPath6 + ".json";
			}
			JObject jobject = null;
			JObject jobject2 = null;
			JObject jobject3 = null;
			JObject jobject4 = null;
			string text8 = ModBase.ReadFile(text6);
			if (!text8.StartsWith("{"))
			{
				throw new Exception("Minecraft Json 有误，地址：" + text6 + "，前段内容：" + text8.Substring(0, 0x3E8));
			}
			JObject jobject5 = (JObject)ModBase.GetJson(text8);
			if (flag)
			{
				string text9 = ModBase.ReadFile(text);
				if (!text9.StartsWith("{"))
				{
					throw new Exception("OptiFine Json 有误，地址：" + text + "，前段内容：" + text9.Substring(0, 0x3E8));
				}
				jobject = (JObject)ModBase.GetJson(text9);
			}
			if (flag2)
			{
				string text10 = ModBase.ReadFile(text2);
				if (!text10.StartsWith("{"))
				{
					throw new Exception("Forge Json 有误，地址：" + text2 + "，前段内容：" + text10.Substring(0, 0x3E8));
				}
				jobject2 = (JObject)ModBase.GetJson(text10);
			}
			if (flag3)
			{
				string text11 = ModBase.ReadFile(text3);
				if (!text11.StartsWith("{"))
				{
					throw new Exception("LiteLoader Json 有误，地址：" + text3 + "，前段内容：" + text11.Substring(0, 0x3E8));
				}
				jobject3 = (JObject)ModBase.GetJson(text11);
			}
			if (flag4)
			{
				string text12 = ModBase.ReadFile(text4);
				if (!text12.StartsWith("{"))
				{
					throw new Exception("Fabric Json 有误，地址：" + text4 + "，前段内容：" + text12.Substring(0, 0x3E8));
				}
				jobject4 = (JObject)ModBase.GetJson(text12);
			}
			string text13 = (jobject5["minecraftArguments"] ?? " ").ToString() + ((jobject != null) ? (jobject["minecraftArguments"] ?? " ").ToString() : " ") + ((jobject2 != null) ? (jobject2["minecraftArguments"] ?? " ").ToString() : " ") + ((jobject3 != null) ? (jobject3["minecraftArguments"] ?? " ").ToString() : " ");
			List<string> list = new List<string>();
			foreach (string text14 in text13.Split(new char[]
			{
				'-'
			}))
			{
				text14 = text14.Trim();
				if (Operators.CompareString(text14, "", true) != 0)
				{
					list.Add(text14);
				}
			}
			list = ModBase.ArrayNoDouble<string>(list, null);
			string text15 = null;
			if (list.Count > 0)
			{
				text15 = "--" + ModBase.Join(list, " --");
			}
			JObject jobject6 = jobject5;
			if (flag)
			{
				jobject.Remove("releaseTime");
				jobject.Remove("time");
				jobject6.Merge(jobject);
			}
			if (flag2)
			{
				jobject2.Remove("releaseTime");
				jobject2.Remove("time");
				jobject6.Merge(jobject2);
			}
			if (flag3)
			{
				jobject3.Remove("releaseTime");
				jobject3.Remove("time");
				jobject6.Merge(jobject3);
			}
			if (flag4)
			{
				jobject4.Remove("releaseTime");
				jobject4.Remove("time");
				jobject6.Merge(jobject4);
			}
			if (text15 != null)
			{
				jobject6["minecraftArguments"] = text15;
			}
			jobject6.Remove("_comment_");
			jobject6.Remove("inheritsFrom");
			jobject6.Remove("jar");
			jobject6["id"] = folderNameFromPath;
			ModBase.WriteFile(filePath, jobject6.ToString(), false, null);
			if (Operators.CompareString(text7, text5, true) != 0)
			{
				if (File.Exists(text5))
				{
					File.Delete(text5);
				}
				File.Copy(text7, text5);
			}
			ModBase.Log("[Download] 版本合并 " + folderNameFromPath + " 完成", ModBase.LogLevel.Normal, "出现错误");
		}

		// Token: 0x0400016B RID: 363
		private static bool m_PoolVal;

		// Token: 0x0400016C RID: 364
		private static bool parserVal;

		// Token: 0x02000069 RID: 105
		public class McInstallRequest
		{
			// Token: 0x060002F9 RID: 761 RVA: 0x00020B20 File Offset: 0x0001ED20
			public McInstallRequest()
			{
				this.m_DescriptorRule = null;
				this.contextRule = null;
				this.m_ObserverRule = null;
				this._TokenizerRule = null;
				this._DispatcherRule = null;
				this.tagRule = null;
				this._InitializerRule = null;
				this._PropertyRule = null;
				this.m_WatcherRule = null;
			}

			// Token: 0x0400016D RID: 365
			public string m_CandidateRule;

			// Token: 0x0400016E RID: 366
			public string m_DescriptorRule;

			// Token: 0x0400016F RID: 367
			public string contextRule;

			// Token: 0x04000170 RID: 368
			public string m_ObserverRule;

			// Token: 0x04000171 RID: 369
			public ModDownload.DlOptiFineListEntry _TokenizerRule;

			// Token: 0x04000172 RID: 370
			public string _DispatcherRule;

			// Token: 0x04000173 RID: 371
			public ModDownload.DlForgeVersionEntry tagRule;

			// Token: 0x04000174 RID: 372
			public string _InitializerRule;

			// Token: 0x04000175 RID: 373
			public ModDownload.DlCfFile _PropertyRule;

			// Token: 0x04000176 RID: 374
			public ModDownload.DlLiteLoaderListEntry m_WatcherRule;
		}
	}
}
