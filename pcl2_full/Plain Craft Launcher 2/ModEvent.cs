using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace PCL
{
	// Token: 0x02000036 RID: 54
	[StandardModule]
	public sealed class ModEvent
	{
		// Token: 0x060000F7 RID: 247 RVA: 0x00011B38 File Offset: 0x0000FD38
		public static void TryStartEvent(string Type, string Data)
		{
			if (!string.IsNullOrWhiteSpace(Type))
			{
				string[] data = new string[]
				{
					""
				};
				if (Data != null)
				{
					data = Data.Split(new char[]
					{
						'|'
					});
				}
				ModEvent.StartEvent(Type, data);
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00011B78 File Offset: 0x0000FD78
		public static void StartEvent(string Type, string[] Data)
		{
			try
			{
				ModBase.Log("[Control] 执行自定义事件：" + Type + ", " + ModBase.Join(Data, ", "), ModBase.LogLevel.Normal, "出现错误");
				string $VB$Local_Type = Type;
				if (Operators.CompareString($VB$Local_Type, "打开网页", true) == 0)
				{
					Data[0] = Data[0].Replace("\\", "/");
					if (!Data[0].StartsWith("http://") && !Data[0].StartsWith("https://"))
					{
						ModMain.MyMsgBox("EventData 必须为以 http:// 或 https:// 开头的网址。\r\n如果想要启动程序，请将 EventType 改为 打开文件。", "事件执行失败", "确定", "", "", false, true, false);
					}
					else
					{
						ModMain.Hint("正在打开网页，请稍候……", ModMain.HintType.Info, true);
						ModBase.OpenWebsite(Data[0]);
					}
				}
				else if (Operators.CompareString($VB$Local_Type, "打开文件", true) != 0 && Operators.CompareString($VB$Local_Type, "打开帮助", true) != 0)
				{
					if (Operators.CompareString($VB$Local_Type, "启动游戏", true) == 0)
					{
						if (ModMain.m_InvocationFilter.BtnLaunch.IsEnabled && ModMain.m_InvocationFilter.BtnLaunch.Visibility == Visibility.Visible && ModMain.m_InvocationFilter.BtnLaunch.IsHitTestVisible)
						{
							if (!Directory.Exists(ModMinecraft.m_ResolverIterator + "versions\\" + Data[0]))
							{
								ModMain.Hint("未在当前 Minecraft 文件夹找到版本 " + Data[0] + "！", ModMain.HintType.Critical, true);
							}
							else
							{
								ModMinecraft.McVersion mcVersion = new ModMinecraft.McVersion(Data[0]);
								mcVersion.Load();
								if (mcVersion.m_HelperAlgo == ModMinecraft.McVersionState.Error)
								{
									ModMain.Hint("无法启动 " + Data[0] + "：" + mcVersion.m_SchemaAlgo, ModMain.HintType.Critical, true);
								}
								else
								{
									ModMinecraft.CancelContainer(mcVersion);
									ModBase._BaseRule.Set("LaunchVersionSelect", ModMinecraft.ValidateContainer().Name, false, null);
									ModMain.m_InvocationFilter.PageLaunchLeft_Loaded();
									ModMain.m_InvocationFilter.RefreshButtonsUI();
									ModMain.m_GetterFilter.AprilGiveup();
									ModMain.m_InvocationFilter.LaunchButtonClick((Data.Length >= 2) ? Data[1] : "");
									ModMain.m_GetterFilter.PageChange(FormMain.PageType.Launch, FormMain.PageSubType.Default);
								}
							}
						}
						else
						{
							ModMain.Hint("已有游戏正在启动中！", ModMain.HintType.Critical, true);
						}
					}
					else if (Operators.CompareString($VB$Local_Type, "复制文本", true) == 0)
					{
						ModBase.ClipboardSet(ModBase.Join(Data, "|"), true);
					}
					else if (Operators.CompareString($VB$Local_Type, "刷新主页", true) == 0)
					{
						ModMain.m_CandidateFilter.ForceRefresh(true);
					}
					else if (Operators.CompareString($VB$Local_Type, "刷新帮助", true) == 0)
					{
						PageOtherLeft.RefreshHelp();
					}
					else if (Operators.CompareString($VB$Local_Type, "弹出窗口", true) == 0)
					{
						ModMain.MyMsgBox(Data[1].Replace("\\n", "\r\n"), Data[0].Replace("\\n", "\r\n"), "确定", "", "", false, true, false);
					}
					else if (Operators.CompareString($VB$Local_Type, "下载文件", true) == 0)
					{
						Data[0] = Data[0].Replace("\\", "/");
						if (!Data[0].StartsWith("http://") && !Data[0].StartsWith("https://"))
						{
							ModMain.MyMsgBox("EventData 必须为以 http:// 或 https:// 开头的网址。\r\nPCL2 不支持其他乱七八糟的协议。", "事件执行失败", "确定", "", "", false, true, false);
						}
						else
						{
							PageOtherTest.StartCustomDownload(Data[0], null);
						}
					}
					else
					{
						ModMain.MyMsgBox("未知的事件类型：" + Type + "\r\n请检查事件类型填写是否正确，或者 PCL2 是否为最新版本。", "事件执行失败", "确定", "", "", false, true, false);
					}
				}
				else
				{
					ModBase.RunInThread(delegate
					{
						try
						{
							string[] eventAbsoluteUrls = ModEvent.GetEventAbsoluteUrls(Data[0], Type);
							string text = eventAbsoluteUrls[0];
							string workingDirectory = eventAbsoluteUrls[1];
							if (Operators.CompareString(Type, "打开文件", true) == 0)
							{
								Process.Start(new ProcessStartInfo
								{
									Arguments = ((Data.Length >= 2) ? Data[1] : ""),
									FileName = text,
									WorkingDirectory = workingDirectory
								});
							}
							else
							{
								PageOtherHelp.EnterHelpPage(text);
							}
						}
						catch (Exception ex2)
						{
							ModBase.Log(ex2, "执行打开类自定义事件失败", ModBase.LogLevel.Msgbox, "出现错误");
						}
					});
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "事件执行失败", ModBase.LogLevel.Msgbox, "出现错误");
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00011FB0 File Offset: 0x000101B0
		public static string[] GetEventAbsoluteUrls(string RelativeUrl, string EventType)
		{
			if (RelativeUrl.ToLower().StartsWith("http"))
			{
				if (ModBase.RunInUi())
				{
					throw new Exception("MyListItem 在界面初始化时就需要获取帮助标题等信息，这会导致程序在网络请求时卡死。\r\n因此，请换用 MyListItem 以外的控件（例如 MyButton）作为联网帮助页面的入口！");
				}
				string fileNameFromPath;
				try
				{
					fileNameFromPath = ModBase.GetFileNameFromPath(RelativeUrl);
					if (!fileNameFromPath.ToLower().EndsWith(".json"))
					{
						throw new Exception("未指向 .json 后缀的文件");
					}
				}
				catch (Exception innerException)
				{
					throw new Exception("联网帮助页面须指向一个帮助 JSON 文件，并在同路径下包含相应 XAML 文件！\r\n例如：\r\n - https://www.baidu.com/test.json（填写这个路径）\r\n - https://www.baidu.com/test.xaml（同时也需要包含这个文件）", innerException);
				}
				string text = ModBase.m_GlobalRule + "CustomEvent\\" + fileNameFromPath;
				ModBase.m_GlobalRule + "CustomEvent\\" + fileNameFromPath.Replace(".json", ".xaml");
				ModBase.Log("[Event] 转换网络资源：" + RelativeUrl + " -> " + text, ModBase.LogLevel.Normal, "出现错误");
				ModMain.Hint("正在获取资源，请稍候……", ModMain.HintType.Info, true);
				try
				{
					ModNet.NetDownload(RelativeUrl, text);
					ModNet.NetDownload(RelativeUrl.Replace(".json", ".xaml"), text.Replace(".json", ".xaml"));
				}
				catch (Exception innerException2)
				{
					throw new Exception("下载指定的文件失败！\r\n注意，联网帮助页面须指向一个帮助 JSON 文件，并在同路径下包含相应 XAML 文件！\r\n例如：\r\n - https://www.baidu.com/test.json（填写这个路径）\r\n - https://www.baidu.com/test.xaml（同时也需要包含这个文件）", innerException2);
				}
				RelativeUrl = text;
			}
			RelativeUrl = RelativeUrl.Replace("/", "\\").ToLower().TrimStart(new char[]
			{
				'\\'
			});
			string text2 = ModBase.Path + "PCL";
			string text3;
			if (RelativeUrl.Contains(":\\"))
			{
				text3 = RelativeUrl;
				ModBase.Log("[Control] 自定义事件中由绝对路径" + EventType + "：" + text3, ModBase.LogLevel.Normal, "出现错误");
			}
			else if (File.Exists(ModBase.Path + "PCL\\" + RelativeUrl))
			{
				text3 = ModBase.Path + "PCL\\" + RelativeUrl;
				ModBase.Log("[Control] 自定义事件中由相对 PCL 文件夹的路径" + EventType + "：" + text3, ModBase.LogLevel.Normal, "出现错误");
			}
			else if (File.Exists(ModBase.Path + "PCL\\Help\\" + RelativeUrl))
			{
				text3 = ModBase.Path + "PCL\\Help\\" + RelativeUrl;
				text2 = ModBase.Path + "PCL\\Help\\";
				ModBase.Log("[Control] 自定义事件中由相对 PCL 本地帮助文件夹的路径" + EventType + "：" + text3, ModBase.LogLevel.Normal, "出现错误");
			}
			else if (Operators.CompareString(EventType, "打开帮助", true) == 0 && File.Exists(ModBase.m_GlobalRule + "Help\\" + RelativeUrl))
			{
				text3 = ModBase.m_GlobalRule + "Help\\" + RelativeUrl;
				text2 = ModBase.m_GlobalRule + "Help\\";
				ModBase.Log("[Control] 自定义事件中由相对 PCL 自带帮助文件夹的路径" + EventType + "：" + text3, ModBase.LogLevel.Normal, "出现错误");
			}
			else
			{
				if (Operators.CompareString(EventType, "打开文件", true) != 0)
				{
					throw new FileNotFoundException("未找到 EventData 指向的本地 xaml 文件：" + RelativeUrl, RelativeUrl);
				}
				text3 = RelativeUrl;
				ModBase.Log("[Control] 自定义事件中直接" + EventType + "：" + text3, ModBase.LogLevel.Normal, "出现错误");
			}
			return new string[]
			{
				text3,
				text2
			};
		}
	}
}
