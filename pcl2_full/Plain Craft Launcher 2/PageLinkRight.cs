using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x0200009A RID: 154
	[DesignerGenerated]
	public class PageLinkRight : AdornerDecorator, IComponentConnector
	{
		// Token: 0x0600058A RID: 1418 RVA: 0x0002BCE0 File Offset: 0x00029EE0
		// Note: this type is marked as 'beforefieldinit'.
		static PageLinkRight()
		{
			PageLinkRight.serverContainer = null;
			PageLinkRight.configContainer = ModBase.LoadState.Waiting;
			PageLinkRight.connectionContainer = 0;
			PageLinkRight._ListContainer = null;
			PageLinkRight.m_ReponseContainer = "";
			PageLinkRight.identifierContainer = "";
			PageLinkRight.m_PolicyContainer = "";
			PageLinkRight.m_ClientContainer = new Dictionary<string, PageLinkRight.UserEntry>();
			PageLinkRight.mapContainer = new List<PageLinkRight.RoomEntry>();
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x000054C7 File Offset: 0x000036C7
		public PageLinkRight()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.MeLoaded();
			};
			this.producerContainer = false;
			this.InitializeComponent();
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x0002BD38 File Offset: 0x00029F38
		private void MeLoaded()
		{
			this.PanBack.ScrollToHome();
			this.RefreshUi();
			checked
			{
				if (!this.producerContainer)
				{
					this.producerContainer = true;
					ModAni.ListFactory(ModAni.InsertFactory() + 1);
					this.SetupReload();
					ModAni.ListFactory(ModAni.InsertFactory() - 1);
					PageLinkRight.Init();
					this.Load.State = PageLinkRight.exceptionContainer;
					ModBase.RunInNewThread(delegate
					{
						for (;;)
						{
							Thread.Sleep(0xC8);
							if (ModMain.m_GetterFilter.publisherDecorator._FieldMapper == FormMain.PageType.Link)
							{
								ModBase.RunInUiWait((PageLinkRight._Closure$__.$I5-1 == null) ? (PageLinkRight._Closure$__.$I5-1 = delegate()
								{
									ModMain._TagFilter.RefreshUi();
								}) : PageLinkRight._Closure$__.$I5-1);
							}
							this.RefreshWorker();
						}
					}, "Link Timer", ThreadPriority.Normal);
				}
			}
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x000054EE File Offset: 0x000036EE
		public static ModBase.LoadState StopContainer()
		{
			if (PageLinkRight.exceptionContainer != null)
			{
				return PageLinkRight.exceptionContainer.State;
			}
			return ModBase.LoadState.Waiting;
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x0002BDB0 File Offset: 0x00029FB0
		public static void Init()
		{
			if (PageLinkRight.StopContainer() != ModBase.LoadState.Finished && PageLinkRight.StopContainer() != ModBase.LoadState.Loading)
			{
				ModBase.Log("[Link] 联机模块初始化开始", ModBase.LogLevel.Normal, "出现错误");
				PageLinkRight.exceptionContainer = new ModLoader.LoaderCombo<int>("联机模块初始化", new ArrayList
				{
					new ModLoader.LoaderTask<int, List<ModNet.NetFile>>("初次启动尝试", new ModLoader.LoaderTask<int, List<ModNet.NetFile>>.LoadDelegateSub(PageLinkRight.InitFirst), null, ThreadPriority.Normal)
					{
						ProgressWeight = 3.0
					},
					new ModNet.LoaderDownload("下载更新文件", new List<ModNet.NetFile>())
					{
						ProgressWeight = 6.0
					},
					new ModLoader.LoaderTask<List<ModNet.NetFile>, bool>("二次启动尝试", new ModLoader.LoaderTask<List<ModNet.NetFile>, bool>.LoadDelegateSub(PageLinkRight.InitSecond), null, ThreadPriority.Normal)
					{
						ProgressWeight = 2.0
					}
				});
				PageLinkRight.exceptionContainer.Start(0, false);
			}
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x0002BE84 File Offset: 0x0002A084
		private static void InitFirst(ModLoader.LoaderTask<int, List<ModNet.NetFile>> Task)
		{
			Task.Progress = 0.1;
			PageLinkRight.IoiStop(true);
			Task.Progress = 0.2;
			foreach (IPEndPoint ipendPoint in IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners())
			{
				if (ipendPoint.Port == 0xD903)
				{
					ModBase.Log("[Link] 发现端口 " + Conversions.ToString(ipendPoint.Port) + " 被占用", ModBase.LogLevel.Normal, "出现错误");
					foreach (string text in ModBase.ShellAndGetOutput("netstat", "-ano", 0x7530, null).Split(new string[]
					{
						"\r\n"
					}, StringSplitOptions.RemoveEmptyEntries))
					{
						if (text.Contains("127.0.0.1:55555"))
						{
							string processName;
							try
							{
								processName = Process.GetProcessById(Conversions.ToInteger(text.Split(new char[]
								{
									' '
								}).Last<string>())).ProcessName;
								goto IL_226;
							}
							catch (Exception ex)
							{
								ModBase.Log(ex, "获取占用端口的进程信息失败，假定进程已结束", ModBase.LogLevel.Debug, "出现错误");
							}
							goto IL_11B;
							IL_226:
							throw new Exception("端口被程序 " + processName + " 占用，无法启动联机模块，请在任务管理器关闭此程序后再试");
						}
					}
					goto IL_BD;
					IL_11B:
					if (Operators.ConditionalCompareObjectNotEqual(0xA, ModBase._BaseRule.Get("LinkIoiVersion", null), true))
					{
						ModBase.Log("[Link] 设置版本强制要求联机模块更新", ModBase.LogLevel.Normal, "出现错误");
						ModBase._BaseRule.Set("LinkIoiVersion", 0xA, false, null);
					}
					else if (File.Exists(ModBase.m_GlobalRule + "联机模块.exe"))
					{
						Task.Progress = 0.3;
						if (PageLinkRight.IoiStart())
						{
							Task.Output = new List<ModNet.NetFile>();
							return;
						}
						PageLinkRight.IoiStop(true);
						File.Delete(ModBase.m_GlobalRule + "联机模块.exe");
					}
					Task.Progress = 0.8;
					ModBase.Log("[Link] 需要下载联机模块", ModBase.LogLevel.Normal, "出现错误");
					if (File.Exists(ModBase.m_GlobalRule + "联机模块.zip"))
					{
						File.Delete(ModBase.m_GlobalRule + "联机模块.zip");
					}
					Task.Output = new List<ModNet.NetFile>
					{
						new ModNet.NetFile(new string[]
						{
							"https://pcl2-server-1253424809.file.myqcloud.com/link/ioi_v2_x" + Conversions.ToString(ModBase.m_MapperRule ? 0x20 : 0x40) + ".zip{CDN}"
						}, ModBase.m_GlobalRule + "联机模块.zip", null)
					};
					return;
				}
				IL_BD:;
			}
			goto IL_11B;
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x0002C110 File Offset: 0x0002A310
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private static void InitSecond(ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task)
		{
			if (PageLinkRight.configContainer != ModBase.LoadState.Finished)
			{
				ModBase.Log("[Link] 解压联机模块以完成下载", ModBase.LogLevel.Normal, "出现错误");
				if (File.Exists(ModBase.m_GlobalRule + "ioi.exe"))
				{
					File.Delete(ModBase.m_GlobalRule + "ioi.exe");
				}
				if (File.Exists(ModBase.m_GlobalRule + "联机模块.exe"))
				{
					File.Delete(ModBase.m_GlobalRule + "联机模块.exe");
				}
				ZipFile.ExtractToDirectory(ModBase.m_GlobalRule + "联机模块.zip", ModBase.m_GlobalRule);
				File.Delete(ModBase.m_GlobalRule + "联机模块.zip");
				FileSystem.Rename(ModBase.m_GlobalRule + "ioi.exe", ModBase.m_GlobalRule + "联机模块.exe");
				Task.Progress = 0.4;
				if (!PageLinkRight.IoiStart())
				{
					PageLinkRight.IoiStop(true);
					throw new Exception("联机模块初始化失败");
				}
			}
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x0002C204 File Offset: 0x0002A404
		private void Load_State(object sender, MyLoading.MyLoadingState state)
		{
			switch (state)
			{
			case MyLoading.MyLoadingState.Run:
			case MyLoading.MyLoadingState.Error:
				this.PanLoad.Visibility = Visibility.Visible;
				if (ModMain._DispatcherFilter != null)
				{
					ModMain._DispatcherFilter.Width = 0.0;
					ModMain._DispatcherFilter.MinWidth = 0.0;
				}
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaOpacity(this.PanLoad, 1.0 - this.PanLoad.Opacity, 0x96, 0, null, false),
					ModAni.AaOpacity(this.PanBack, -this.PanBack.Opacity, 0x96, 0, null, false),
					ModAni.AaCode(delegate
					{
						this.PanBack.Visibility = Visibility.Collapsed;
					}, 0, true)
				}, "FrmLinkRight Load Switch", false);
				return;
			case MyLoading.MyLoadingState.Stop:
				this.PanBack.Visibility = Visibility.Visible;
				if (ModMain._DispatcherFilter != null)
				{
					ModMain._DispatcherFilter.Width = double.NaN;
					ModMain._DispatcherFilter.MinWidth = 220.0;
				}
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaOpacity(this.PanLoad, -this.PanLoad.Opacity, 0x96, 0, null, false),
					ModAni.AaOpacity(this.PanBack, 1.0 - this.PanBack.Opacity, 0x96, 0, null, false),
					ModAni.AaCode(delegate
					{
						this.PanLoad.Visibility = Visibility.Collapsed;
					}, 0, true)
				}, "FrmLinkRight Load Switch", false);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x00005503 File Offset: 0x00003703
		private void Load_Click(object sender, MouseButtonEventArgs e)
		{
			if (PageLinkRight.exceptionContainer.State == ModBase.LoadState.Failed)
			{
				ModBase.Log("[Link] 用户手动点击加载环触发重试", ModBase.LogLevel.Normal, "出现错误");
				PageLinkRight.Init();
				this.Load.State = PageLinkRight.exceptionContainer;
			}
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x0002C39C File Offset: 0x0002A59C
		public static bool IoiStop(bool SleepWhenKilled)
		{
			bool result = false;
			checked
			{
				if (PageLinkRight.serverContainer != null && !PageLinkRight.serverContainer.HasExited)
				{
					int num = PageLinkRight.m_ClientContainer.Count - 1;
					int num2 = 0;
					while (num2 <= num && num2 <= PageLinkRight.m_ClientContainer.Count - 1)
					{
						PageLinkRight.SendDisconnectRequest(PageLinkRight.m_ClientContainer.Values.ElementAtOrDefault(num2), null, false);
						num2++;
					}
				}
				foreach (Process process in Process.GetProcesses())
				{
					if (Operators.CompareString(process.ProcessName, "联机模块", true) == 0)
					{
						result = true;
						try
						{
							process.Kill();
							ModBase.Log("[Link] 已关闭联机模块：" + Conversions.ToString(process.Id), ModBase.LogLevel.Normal, "出现错误");
							if (SleepWhenKilled)
							{
								Thread.Sleep(0xBB8);
							}
						}
						catch (Exception ex)
						{
							ModBase.Log(ex, "关闭联机模块失败（" + Conversions.ToString(process.Id) + "）", ModBase.LogLevel.Debug, "出现错误");
						}
					}
				}
				PageLinkRight.serverContainer = null;
				PageLinkRight._RulesContainer = null;
				PageLinkRight._ListContainer = null;
				PageLinkRight.classContainer = null;
				PageLinkRight.configContainer = ModBase.LoadState.Waiting;
				PageLinkRight.m_ClientContainer = new Dictionary<string, PageLinkRight.UserEntry>();
				PageLinkRight.mapContainer = new List<PageLinkRight.RoomEntry>();
				return result;
			}
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x0002C4E8 File Offset: 0x0002A6E8
		public static bool IoiStart()
		{
			PageLinkRight.IoiStop(true);
			PageLinkRight.configContainer = ModBase.LoadState.Loading;
			ModBase.Log("[Link] 启动联机模块进程", ModBase.LogLevel.Normal, "出现错误");
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				FileName = ModBase.m_GlobalRule + "联机模块.exe",
				UseShellExecute = false,
				CreateNoWindow = true,
				RedirectStandardError = true,
				RedirectStandardOutput = true,
				WorkingDirectory = ModBase.m_GlobalRule
			};
			PageLinkRight.serverContainer = new Process
			{
				StartInfo = startInfo
			};
			PageLinkRight._Closure$__19-0 CS$<>8__locals1 = new PageLinkRight._Closure$__19-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_outputWaitHandle = new AutoResetEvent(false);
			bool result;
			try
			{
				PageLinkRight._Closure$__19-1 CS$<>8__locals2 = new PageLinkRight._Closure$__19-1(CS$<>8__locals2);
				CS$<>8__locals2.$VB$Local_errorWaitHandle = new AutoResetEvent(false);
				try
				{
					PageLinkRight.serverContainer.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e)
					{
						base._Lambda$__0(RuntimeHelpers.GetObjectValue(sender), e);
					};
					PageLinkRight.serverContainer.ErrorDataReceived += delegate(object sender, DataReceivedEventArgs e)
					{
						base._Lambda$__1(RuntimeHelpers.GetObjectValue(sender), e);
					};
					PageLinkRight.serverContainer.Start();
					PageLinkRight.serverContainer.BeginOutputReadLine();
					PageLinkRight.serverContainer.BeginErrorReadLine();
					while (!PageLinkRight.serverContainer.HasExited)
					{
						if (PageLinkRight.configContainer != ModBase.LoadState.Loading)
						{
							break;
						}
						Thread.Sleep(0xA);
					}
					switch (PageLinkRight.configContainer)
					{
					case ModBase.LoadState.Finished:
						ModBase.Log("[Link] 联机模块启动成功", ModBase.LogLevel.Normal, "出现错误");
						result = true;
						break;
					case ModBase.LoadState.Failed:
						ModBase.Log("[Link] 联机模块启动出现异常", ModBase.LogLevel.Normal, "出现错误");
						result = false;
						break;
					case ModBase.LoadState.Aborted:
						ModBase.Log("[Link] 联机模块要求更新", ModBase.LogLevel.Normal, "出现错误");
						result = false;
						break;
					default:
						throw new Exception("联机模块启动失败，请检查你的网络连接");
					}
				}
				finally
				{
					if (CS$<>8__locals2.$VB$Local_errorWaitHandle != null)
					{
						((IDisposable)CS$<>8__locals2.$VB$Local_errorWaitHandle).Dispose();
					}
				}
			}
			finally
			{
				if (CS$<>8__locals1.$VB$Local_outputWaitHandle != null)
				{
					((IDisposable)CS$<>8__locals1.$VB$Local_outputWaitHandle).Dispose();
				}
			}
			return result;
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x0002C6A0 File Offset: 0x0002A8A0
		private static void IoiLogLine(string Content)
		{
			if (Content.StartsWith("PCL - "))
			{
				try
				{
					string text = WebUtility.UrlDecode(ModBase.CancelIterator(Content.Substring(6), ""));
					ModBase.Log("[Link] 接收到数据包：" + text, ModBase.LogLevel.Normal, "出现错误");
					PageLinkRight.ReceiveJson((JObject)ModBase.GetJson(text));
					return;
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "解码联机数据包失败", ModBase.LogLevel.Debug, "出现错误");
				}
			}
			checked
			{
				if (!Content.Contains(" > http://127.0.0.1:55555/"))
				{
					if (Content.Contains("All done"))
					{
						if (PageLinkRight._RulesContainer != null && PageLinkRight.classContainer != null)
						{
							PageLinkRight.configContainer = ModBase.LoadState.Finished;
							return;
						}
						ModBase.Log("[Link] 联机模块汇报初始化完成，但未提供账户信息", ModBase.LogLevel.Normal, "出现错误");
						PageLinkRight.configContainer = ModBase.LoadState.Failed;
						return;
					}
					else
					{
						if (Content.Contains("Password :: "))
						{
							PageLinkRight.classContainer = Content.Split(new string[]
							{
								"Password :: "
							}, StringSplitOptions.None)[1];
							return;
						}
						if (PageLinkRight.connectionContainer < (ModBase.errorRule ? 0x1388 : 0x1F4))
						{
							PageLinkRight.connectionContainer++;
							ModBase.Log("[Link] " + Content, ModBase.LogLevel.Normal, "出现错误");
						}
						if (Content.Contains("ID :: "))
						{
							PageLinkRight._RulesContainer = Content.Split(new string[]
							{
								"ID :: "
							}, StringSplitOptions.None)[1];
						}
						if (Content.Contains("Initialization failed") || Content.Contains("The version is "))
						{
							PageLinkRight.configContainer = ModBase.LoadState.Aborted;
						}
						if (Content.Contains("[INF]"))
						{
							if (Content.Contains("[INF]Your IP is public"))
							{
								PageLinkRight._ListContainer = "S";
							}
							else if (Content.Contains("[INF]Full Cone"))
							{
								PageLinkRight._ListContainer = "A";
							}
							else if (Content.Contains("[INF]Address Restrict Cone"))
							{
								PageLinkRight._ListContainer = "B";
							}
							else if (Content.Contains("[INF]Port Restrict Cone"))
							{
								PageLinkRight._ListContainer = "C";
							}
							else if (Content.Contains("[INF]Symmetric"))
							{
								PageLinkRight._ListContainer = "D";
							}
							else if (Content.Contains("[INF]Firewall"))
							{
								PageLinkRight._ListContainer = "F";
							}
						}
						if (Content.Contains("'portssub' from "))
						{
							PageLinkRight.m_ReponseContainer = Content.Split(new char[]
							{
								' '
							}).Last<string>();
						}
						if (Content.Contains("Listening tcp ") && PageLinkRight.m_ClientContainer.ContainsKey(PageLinkRight.m_ReponseContainer))
						{
							ModBase.DictionaryAdd<int, string>(ref PageLinkRight.m_ClientContainer[PageLinkRight.m_ReponseContainer].pageRule, Conversions.ToInteger(Content.Split(new char[]
							{
								' '
							}).Last<string>()), ModBase.RegexSeek(Content, "(?<=Listening tcp )[^:]+", RegexOptions.None));
						}
					}
				}
			}
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x0002C950 File Offset: 0x0002AB50
		public void SetupReload()
		{
			this.CheckLinkAuto.Checked = Conversions.ToBoolean(ModBase._BaseRule.Get("LinkAuto", null));
			this.TextLinkName.Text = Conversions.ToString(ModBase._BaseRule.Get("LinkName", null));
			this.DisplayNameChange();
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x00004FEE File Offset: 0x000031EE
		private void CheckBoxChange(MyCheckBox sender, object e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set(Conversions.ToString(sender.Tag), sender.Checked, false, null);
			}
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x00005537 File Offset: 0x00003737
		private void TextBoxChange(MyTextBox sender, object e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set(Conversions.ToString(sender.Tag), sender.Text, false, null);
			}
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x0000555D File Offset: 0x0000375D
		private void DisplayNameChange()
		{
			ModMain._DispatcherFilter.ItemMe.Title = PageLinkRight.GetSelfDisplayName();
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x0002C9A4 File Offset: 0x0002ABA4
		private static string GetSelfDisplayName()
		{
			string text = Conversions.ToString(ModBase._BaseRule.Get("LinkName", null));
			string result;
			if (Operators.CompareString(text, "", true) != 0)
			{
				result = text.Trim();
			}
			else
			{
				result = Convert.ToInt32(decimal.Remainder(new decimal(ModBase.GetHash(PageLinkRight._RulesContainer ?? "")), 1048576m)).ToString("x5").ToUpper();
			}
			return result;
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x0002CA24 File Offset: 0x0002AC24
		public void RefreshUi()
		{
			checked
			{
				try
				{
					if (Operators.CompareString(ModMain._DispatcherFilter.ItemMe.Info, "网络环境检测中……", true) == 0 && PageLinkRight._ListContainer != null)
					{
						ModMain._DispatcherFilter.ItemMe.Info = "网络环境评级：" + PageLinkRight._ListContainer;
						string listContainer = PageLinkRight._ListContainer;
						if (Operators.CompareString(listContainer, "S", true) == 0)
						{
							ModMain._DispatcherFilter.ItemMe.ToolTip = "你的 IP 处于公网，具有最佳的网络环境";
						}
						else if (Operators.CompareString(listContainer, "A", true) == 0)
						{
							ModMain._DispatcherFilter.ItemMe.ToolTip = "你的 NAT 类型为 Type A，网络环境良好";
						}
						else if (Operators.CompareString(listContainer, "B", true) == 0)
						{
							ModMain._DispatcherFilter.ItemMe.ToolTip = "你的 NAT 类型为 Type B，网络环境一般";
						}
						else if (Operators.CompareString(listContainer, "C", true) == 0)
						{
							ModMain._DispatcherFilter.ItemMe.ToolTip = "你的 NAT 类型为 Type C，网络环境较差";
						}
						else if (Operators.CompareString(listContainer, "D", true) == 0)
						{
							ModMain._DispatcherFilter.ItemMe.ToolTip = "你的 NAT 类型为 Type D，网络环境很差";
						}
						else if (Operators.CompareString(listContainer, "F", true) == 0)
						{
							ModMain._DispatcherFilter.ItemMe.ToolTip = "无法检测你的 NAT 类型，很可能无法正常连接";
						}
					}
					else if (Operators.CompareString(ModMain._DispatcherFilter.ItemMe.Info, "网络环境检测中……", true) != 0 && PageLinkRight._ListContainer == null)
					{
						ModMain._DispatcherFilter.ItemMe.Info = "网络环境检测中……";
						ModMain._DispatcherFilter.ItemMe.ToolTip = null;
					}
					string left = ModBase.Join(PageLinkRight.m_ClientContainer, "\r\n");
					if (Operators.CompareString(left, PageLinkRight.identifierContainer, true) != 0)
					{
						PageLinkRight.identifierContainer = left;
						ModMain._DispatcherFilter.PanList.Children.Clear();
						int num = PageLinkRight.m_ClientContainer.Count - 1;
						int num2 = 0;
						while (num2 <= num && num2 <= PageLinkRight.m_ClientContainer.Count - 1)
						{
							ModMain._DispatcherFilter.PanList.Children.Add(PageLinkRight.m_ClientContainer.Values.ElementAtOrDefault(num2).ToListItem());
							num2++;
						}
						if (ModMain._DispatcherFilter.PanList.Children.Count == 0)
						{
							ModMain._DispatcherFilter.LabTitle.Text = "未连接";
						}
						else
						{
							ModMain._DispatcherFilter.LabTitle.Text = "连接列表 (" + Conversions.ToString(ModMain._DispatcherFilter.PanList.Children.Count + 1) + ")";
						}
					}
					try
					{
						foreach (object obj in ModMain._DispatcherFilter.PanList.Children)
						{
							MyListItem myListItem = (MyListItem)obj;
							((PageLinkRight.UserEntry)myListItem.Tag).RefreshUi(myListItem);
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
					string text = ModBase.Join(this.GetRoomList(), "\r\n");
					if (Operators.CompareString(text, PageLinkRight.m_PolicyContainer, true) != 0)
					{
						PageLinkRight.m_PolicyContainer = text;
						this.PanRoom.Children.Clear();
						try
						{
							foreach (PageLinkRight.RoomEntry roomEntry in this.GetRoomList())
							{
								this.PanRoom.Children.Add(roomEntry.ToListItem());
							}
						}
						finally
						{
							List<PageLinkRight.RoomEntry>.Enumerator enumerator2;
							((IDisposable)enumerator2).Dispose();
						}
					}
					try
					{
						foreach (object obj2 in this.PanRoom.Children)
						{
							MyListItem myListItem2 = (MyListItem)obj2;
							((PageLinkRight.RoomEntry)myListItem2.Tag).RefreshUi(myListItem2);
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
					if (PageLinkRight.m_ClientContainer.Count == 0)
					{
						if (PageLinkRight.mapContainer.Count == 0)
						{
							this.LabHint.Text = "若想创建房间，请点击下方的创建房间按钮。\r\n若想加入他人的房间，请点击左侧的建立连接按钮，然后输入对方的连接码。";
						}
						else
						{
							this.LabHint.Text = "若想让其他人加入你的房间，请点击左侧的复制连接码按钮，然后让你的朋友输入你的连接码以建立连接。";
						}
					}
					else if (this.GetRoomList().Count == 0)
					{
						this.LabHint.Text = "若想创建房间，请点击下方的创建房间按钮，然后输入对局域网开放后 MC 显示的端口号，或本地服务端的端口号。";
					}
					else if (PageLinkRight.mapContainer.Count == 0)
					{
						this.LabHint.Text = "若想加入某个房间，直接点击该房间即可获取说明。";
					}
					else
					{
						this.LabHint.Text = "指向你所创建的房间，能在右侧找到修改房间名称、关闭房间等选项。" + ((PageLinkRight.mapContainer.Count != this.GetRoomList().Count) ? "\r\n若想加入其他人的房间，直接点击该房间即可获取说明。" : "");
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "联机模块 UI 时钟运行失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x0002CF0C File Offset: 0x0002B10C
		public void RefreshWorker()
		{
			checked
			{
				try
				{
					if (PageLinkRight.StopContainer() == ModBase.LoadState.Finished && PageLinkRight.serverContainer.HasExited)
					{
						ModBase.Log("[Link] 联机模块出现异常！", ModBase.LogLevel.Hint, "出现错误");
						PageLinkRight.IoiAbort();
					}
					int num = PageLinkRight.m_ClientContainer.Values.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						PageLinkRight._Closure$__32-0 CS$<>8__locals1 = new PageLinkRight._Closure$__32-0(CS$<>8__locals1);
						if (i > PageLinkRight.m_ClientContainer.Values.Count - 1)
						{
							break;
						}
						CS$<>8__locals1.$VB$Local_User = PageLinkRight.m_ClientContainer.Values.ElementAtOrDefault(i);
						if (CS$<>8__locals1.$VB$Local_User.m_ProcessRule >= 1.0)
						{
							if (DateTime.Now - CS$<>8__locals1.$VB$Local_User._TaskRule > new TimeSpan(0, 0, ModBase.RandomInteger(0x3C, 0x14)))
							{
								ModBase.RunInNewThread(delegate
								{
									try
									{
										PageLinkRight.SendUpdateRequest(CS$<>8__locals1.$VB$Local_User, 1, -1L);
									}
									catch (Exception ex2)
									{
										ModBase.Log(ex2, "心跳包发送失败（" + CS$<>8__locals1.$VB$Local_User.creatorRule + "）", ModBase.LogLevel.Normal, "出现错误");
									}
								}, "Link Heartbeat " + CS$<>8__locals1.$VB$Local_User.stateRule, ThreadPriority.Normal);
							}
							if (DateTime.Now - CS$<>8__locals1.$VB$Local_User.authenticationRule > new TimeSpan(0, 0, 0x28))
							{
								PageLinkRight.SendDisconnectRequest(CS$<>8__locals1.$VB$Local_User, null, false);
								ModMain.Hint("与 " + CS$<>8__locals1.$VB$Local_User.creatorRule + " 的连接已中断！", ModMain.HintType.Info, true);
							}
						}
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "联机模块工作时钟运行失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x0002D098 File Offset: 0x0002B298
		private static void SendPortsubRequest(PageLinkRight.UserEntry User)
		{
			ModBase.Log("[Link] 尝试建立连接：" + User.stateRule, ModBase.LogLevel.Normal, "出现错误");
			int num = 0;
			string text;
			for (;;)
			{
				JObject jobject = (JObject)ModBase.GetJson(ModNet.NetRequestOnce("http://127.0.0.1:55555/api/link?id=" + User.stateRule + "&password=" + PageLinkRight.classContainer, "PUT", "", "", 0x186A0, null, true));
				if (jobject["msg"] == null)
				{
					goto IL_25E;
				}
				text = jobject["msg"].ToString();
				string left = text;
				checked
				{
					if (Operators.CompareString(left, "failed to find any peer in table", true) == 0)
					{
						num++;
						text = "我方网络环境不佳，连接失败。";
						ModBase.Log("[Link] 未找到对等机，第 " + Conversions.ToString(num) + " 级重试", ModBase.LogLevel.Normal, "出现错误");
					}
					else if (Operators.CompareString(left, "routing: not found", true) == 0)
					{
						num += 4;
						text = "我方或对方网络环境不佳，或对方已关闭联机模块，未找到路由。";
						ModBase.Log("[Link] 无法连接到路由，第 " + Conversions.ToString(num) + " 级重试", ModBase.LogLevel.Normal, "出现错误");
					}
					else if (Operators.CompareString(left, "you are already connected to specified host", true) == 0)
					{
						num++;
						ModNet.NetRequestOnce("http://127.0.0.1:55555/api/link?id=" + User.stateRule + "&password=" + PageLinkRight.classContainer, "DELETE", "", "", 0x186A0, null, true);
						text = "已与对方连接。";
						ModBase.Log("[Link] 已与对方连接，尝试中断现有连接，第 " + Conversions.ToString(num) + " 级重试", ModBase.LogLevel.Normal, "出现错误");
					}
					else if (Operators.CompareString(left, "dial backoff", true) == 0)
					{
						num += 0x14;
						text = "对方网络环境不佳，或对方已关闭联机模块。请尝试让对方主动连接你，而不是你去连接对方。";
						ModBase.Log("[Link] NAT 异常，第 " + Conversions.ToString(num) + " 级重试", ModBase.LogLevel.Normal, "出现错误");
					}
					else if (text.Contains("all dials failed"))
					{
						num += 8;
						text = "我方或对方网络环境不佳，或对方已关闭联机模块，连接失败。";
						ModBase.Log("[Link] 连接失败，第 " + Conversions.ToString(num) + " 级重试", ModBase.LogLevel.Normal, "出现错误");
					}
					else
					{
						num += 8;
						ModBase.Log(string.Concat(new string[]
						{
							"[Link] 未知错误（",
							text,
							"），第 ",
							Conversions.ToString(num),
							" 级重试"
						}), ModBase.LogLevel.Normal, "出现错误");
					}
					if (num > 0x40)
					{
						break;
					}
				}
				User.m_ProcessRule = (double)num * 0.01 + 0.05;
				Thread.Sleep(0xBB8);
			}
			throw new InvalidOperationException(text);
			IL_25E:
			int num2 = 0;
			while (!User.pageRule.ContainsKey(0xD903))
			{
				checked
				{
					num2++;
				}
				User.m_ProcessRule = 0.7 + (double)num2 / 200.0 * 0.1;
				if (num2 == 0x64)
				{
					throw new Exception("连接超时，请尝试重新连接（未收到端口回报）！");
				}
				Thread.Sleep(0x96);
			}
			User.m_ProcessRule = 0.8;
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x0002D370 File Offset: 0x0002B570
		private static void SendConnectRequest(PageLinkRight.UserEntry User)
		{
			JObject jobject = new JObject();
			jobject["version"] = 3;
			jobject["name"] = PageLinkRight.GetSelfDisplayName();
			jobject["id"] = PageLinkRight._RulesContainer;
			jobject["type"] = "connect";
			User._TaskRule = DateTime.Now;
			ModNet.NetRequestOnce("http://" + User.pageRule[0xD903] + ":55555/api/echo?msg=PCL - " + WebUtility.UrlEncode(ModBase.ValidateIterator(jobject.ToString(Formatting.None, new JsonConverter[0]), "")), "PUT", "", "", 0x186A0, null, true);
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0002D438 File Offset: 0x0002B638
		private static void SendUpdateRequest(PageLinkRight.UserEntry User, int Stage, long Unique = -1L)
		{
			if (Unique == -1L)
			{
				Unique = ModBase.GetTimeTick();
			}
			JObject jobject = new JObject();
			jobject["name"] = PageLinkRight.GetSelfDisplayName();
			jobject["id"] = PageLinkRight._RulesContainer;
			jobject["type"] = "update";
			jobject["stage"] = Stage;
			jobject["unique"] = Unique;
			if (Stage < 3)
			{
				JArray jarray = new JArray();
				try
				{
					foreach (PageLinkRight.RoomEntry roomEntry in PageLinkRight.mapContainer)
					{
						JObject jobject2 = new JObject();
						jobject2["name"] = roomEntry.m_TemplateRule;
						jobject2["port"] = roomEntry._ImporterRule;
						jarray.Add(jobject2);
					}
				}
				finally
				{
					List<PageLinkRight.RoomEntry>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				jobject["rooms"] = jarray;
				ModBase.DictionaryAdd<long, DateTime>(ref User._TestRule, Unique, DateTime.Now);
			}
			User._TaskRule = DateTime.Now;
			ModNet.NetRequestOnce("http://" + User.pageRule[0xD903] + ":55555/api/echo?msg=PCL - " + WebUtility.UrlEncode(ModBase.ValidateIterator(jobject.ToString(Formatting.None, new JsonConverter[0]), "")), "PUT", "", "", 0x186A0, null, true);
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x0002D5C8 File Offset: 0x0002B7C8
		private static void SendDisconnectRequest(PageLinkRight.UserEntry User, string Message = null, bool IsError = false)
		{
			JObject jobject = new JObject();
			jobject["id"] = PageLinkRight._RulesContainer;
			jobject["type"] = "disconnect";
			if (Message != null)
			{
				jobject["message"] = Message;
				jobject["isError"] = IsError;
			}
			try
			{
				ModNet.NetRequestOnce("http://" + User.pageRule[0xD903] + ":55555/api/echo?msg=PCL - " + WebUtility.UrlEncode(ModBase.ValidateIterator(jobject.ToString(Formatting.None, new JsonConverter[0]), "")), "PUT", "", "", 0x3E8, null, true);
			}
			catch (Exception ex)
			{
			}
			ModNet.NetRequestOnce("http://127.0.0.1:55555/api/link?id=" + User.stateRule + "&password=" + PageLinkRight.classContainer, "DELETE", "", "", 0x3E8, null, true);
			PageLinkRight.m_ClientContainer.Remove(User.stateRule);
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x0002D6E8 File Offset: 0x0002B8E8
		private static void BtnListRefresh_Click(MyIconButton sender, EventArgs e)
		{
			PageLinkRight.UserEntry User = (PageLinkRight.UserEntry)sender.Tag;
			User._CustomerRule.Clear();
			ModMain._TagFilter.RefreshUi();
			ModBase.RunInThread(delegate
			{
				try
				{
					PageLinkRight.SendUpdateRequest(User, 1, -1L);
				}
				catch (Exception ex)
				{
					if (PageLinkRight.StopContainer() == ModBase.LoadState.Finished)
					{
						ModBase.Log(ex, "刷新与 " + User.creatorRule + " 的连接失败", ModBase.LogLevel.Hint, "出现错误");
					}
				}
			});
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x00005573 File Offset: 0x00003773
		private static void BtnListDisconnect_Click(MyIconButton sender, EventArgs e)
		{
			PageLinkRight.UserEntry User = (PageLinkRight.UserEntry)sender.Tag;
			sender.IsEnabled = false;
			ModBase.RunInThread(delegate
			{
				if (User.m_ProcessRule < 1.0 && User.m_ListenerRule != null && User.m_ListenerRule.IsAlive)
				{
					User.m_ListenerRule.Abort();
					PageLinkRight.m_ClientContainer.Remove(User.stateRule);
					return;
				}
				PageLinkRight.SendDisconnectRequest(User, PageLinkRight.GetSelfDisplayName() + " 主动断开了与你的连接！", true);
			});
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x000055A2 File Offset: 0x000037A2
		public static void BtnLeftCopy_Click()
		{
			ModBase.ClipboardSet(PageLinkRight._RulesContainer.Substring(4) + ModBase.ValidateIterator(PageLinkRight.GetSelfDisplayName(), ""), false);
			ModMain.Hint("已复制连接码！", ModMain.HintType.Finish, true);
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x0002D738 File Offset: 0x0002B938
		private List<PageLinkRight.RoomEntry> GetRoomList()
		{
			List<PageLinkRight.RoomEntry> list = new List<PageLinkRight.RoomEntry>(PageLinkRight.mapContainer);
			checked
			{
				int num = PageLinkRight.m_ClientContainer.Count - 1;
				int num2 = 0;
				while (num2 <= num && num2 <= PageLinkRight.m_ClientContainer.Count - 1)
				{
					list.AddRange(PageLinkRight.m_ClientContainer.Values.ElementAtOrDefault(num2).m_InstanceRule);
					num2++;
				}
				return list;
			}
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x0002D794 File Offset: 0x0002B994
		public static void BtnLeftCreate_Click()
		{
			PageLinkRight._Closure$__45-0 CS$<>8__locals1 = new PageLinkRight._Closure$__45-0(CS$<>8__locals1);
			string text = ModMain.MyMsgBoxInput("", new Collection<Validate>
			{
				new ValidateLength(0x31, 0x1869F)
			}, "", "输入对方的连接码", "确定", "取消", false);
			if (text != null)
			{
				CS$<>8__locals1.$VB$Local_Id = "12D3" + text.Substring(0, 0x30);
				try
				{
					CS$<>8__locals1.$VB$Local_DisplayName = ModBase.CancelIterator(text.Substring(0x30), "");
				}
				catch (Exception ex)
				{
					ModMain.Hint("你输入的连接码有误！", ModMain.HintType.Critical, true);
					return;
				}
				if (Operators.CompareString(CS$<>8__locals1.$VB$Local_Id, PageLinkRight._RulesContainer, true) == 0)
				{
					ModMain.Hint("我连我自己？搁这卡 Bug 呢？", ModMain.HintType.Critical, true);
					return;
				}
				CS$<>8__locals1.$VB$Local_User = new PageLinkRight.UserEntry(CS$<>8__locals1.$VB$Local_Id, CS$<>8__locals1.$VB$Local_DisplayName);
				CS$<>8__locals1.$VB$Local_User.m_ListenerRule = ModBase.RunInNewThread(delegate
				{
					try
					{
						if (PageLinkRight.m_ClientContainer.ContainsKey(CS$<>8__locals1.$VB$Local_Id))
						{
							ModMain.Hint("你已经与 " + PageLinkRight.m_ClientContainer[CS$<>8__locals1.$VB$Local_Id].creatorRule + " 建立了连接！", ModMain.HintType.Critical, true);
						}
						else
						{
							PageLinkRight.m_ClientContainer.Add(CS$<>8__locals1.$VB$Local_Id, CS$<>8__locals1.$VB$Local_User);
							PageLinkRight.SendPortsubRequest(CS$<>8__locals1.$VB$Local_User);
							PageLinkRight.SendConnectRequest(CS$<>8__locals1.$VB$Local_User);
							CS$<>8__locals1.$VB$Local_User.m_ProcessRule = 0.85;
							ModBase.Log("[Link] 加入成功，等待反向请求", ModBase.LogLevel.Normal, "出现错误");
							while (CS$<>8__locals1.$VB$Local_User.m_ProcessRule < 0.9999)
							{
								PageLinkRight.UserEntry $VB$Local_User = CS$<>8__locals1.$VB$Local_User;
								ref double ptr = ref $VB$Local_User.m_ProcessRule;
								$VB$Local_User.m_ProcessRule = ptr + 0.0002;
								if (CS$<>8__locals1.$VB$Local_User.m_ProcessRule > 0.98 && CS$<>8__locals1.$VB$Local_User.m_ProcessRule < 0.9999)
								{
									throw new Exception("对方未回应连接请求！");
								}
								Thread.Sleep(0x64);
							}
							ModMain.Hint("已连接到 " + CS$<>8__locals1.$VB$Local_User.creatorRule + "！", ModMain.HintType.Finish, true);
						}
					}
					catch (ThreadAbortException ex)
					{
						PageLinkRight.m_ClientContainer.Remove(CS$<>8__locals1.$VB$Local_User.stateRule);
					}
					catch (InvalidOperationException ex2)
					{
						PageLinkRight.m_ClientContainer.Remove(CS$<>8__locals1.$VB$Local_Id);
						if (PageLinkRight.StopContainer() == ModBase.LoadState.Finished)
						{
							ModBase.Log("与 " + CS$<>8__locals1.$VB$Local_DisplayName + " 建立连接失败：" + ex2.Message, ModBase.LogLevel.Msgbox, "出现错误");
						}
					}
					catch (Exception ex3)
					{
						PageLinkRight.m_ClientContainer.Remove(CS$<>8__locals1.$VB$Local_Id);
						if (ex3.InnerException == null || !(ex3.InnerException is ThreadAbortException))
						{
							if (PageLinkRight.StopContainer() == ModBase.LoadState.Finished)
							{
								ModBase.Log(ex3, "与 " + CS$<>8__locals1.$VB$Local_DisplayName + " 建立连接失败", ModBase.LogLevel.Msgbox, "出现错误");
							}
						}
					}
				}, "Link Create " + CS$<>8__locals1.$VB$Local_DisplayName, ThreadPriority.Normal);
			}
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x0002D8A4 File Offset: 0x0002BAA4
		private static void SendPortsubBack(PageLinkRight.UserEntry User, int TargetVersion)
		{
			try
			{
				PageLinkRight.SendPortsubRequest(User);
				User.m_ProcessRule = 0.9;
				if (TargetVersion > 3)
				{
					PageLinkRight.SendDisconnectRequest(User, "无法连接到 " + PageLinkRight.GetSelfDisplayName() + "：对方的 PCL2 版本过低！", true);
					throw new InvalidOperationException("你的 PCL2 版本过低！");
				}
				if (TargetVersion < 3)
				{
					PageLinkRight.SendDisconnectRequest(User, "无法连接到 " + PageLinkRight.GetSelfDisplayName() + "：你的 PCL2 版本过低！", true);
					throw new InvalidOperationException("对方的 PCL2 版本过低！");
				}
				PageLinkRight.SendUpdateRequest(User, 1, -1L);
				User.m_ProcessRule = 1.0;
				ModMain.Hint(User.creatorRule + " 已与你建立连接！", ModMain.HintType.Info, true);
			}
			catch (ThreadAbortException ex)
			{
				PageLinkRight.m_ClientContainer.Remove(User.stateRule);
			}
			catch (InvalidOperationException ex2)
			{
				PageLinkRight.m_ClientContainer.Remove(User.stateRule);
				if (PageLinkRight.StopContainer() == ModBase.LoadState.Finished)
				{
					ModBase.Log("与 " + User.creatorRule + " 建立连接失败：" + ex2.Message, ModBase.LogLevel.Hint, "出现错误");
				}
			}
			catch (Exception ex3)
			{
				PageLinkRight.m_ClientContainer.Remove(User.stateRule);
				if (PageLinkRight.StopContainer() == ModBase.LoadState.Finished)
				{
					ModBase.Log(ex3, "与 " + User.creatorRule + " 建立连接失败", ModBase.LogLevel.Hint, "出现错误");
				}
			}
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x0002DA34 File Offset: 0x0002BC34
		private void LinkCreate()
		{
			if (ModMain.MyMsgBox("请先进入 MC 并暂停游戏，在暂停页面选择对局域网开放，然后在下一个窗口输入 MC 显示的端口号。\r\n若使用服务端开服，则直接在下一个窗口输入服务器配置中的端口号即可。", "提示", "继续", "取消", "", false, true, false) != 2)
			{
				string Port = ModMain.MyMsgBoxInput("", new Collection<Validate>
				{
					new ValidateInteger(0, 0xFFFF),
					new ValidateExceptSame(new string[]
					{
						"55555"
					}, "端口不能为 %！", false),
					new ValidateExceptSame(PageLinkRight.mapContainer.Select(new Func<PageLinkRight.RoomEntry, int>(PageLinkRight.RoomEntry.SelectPort)), "端口 % 已创建过房间，请在删除该房间后继续！", false)
				}, "", "输入端口号", "确定", "取消", false);
				if (Port != null)
				{
					string DisplayName = ModMain.MyMsgBoxInput(PageLinkRight.GetSelfDisplayName() + " 的房间 - " + Port, new Collection<Validate>
					{
						new ValidateNullOrWhiteSpace(),
						new ValidateLength(1, 0x28),
						new ValidateFilter()
					}, "", "输入房间名（建议包含游戏版本等信息）", "确定", "取消", false);
					if (DisplayName != null)
					{
						DisplayName = DisplayName.Trim();
						ModBase.RunInThread(delegate
						{
							try
							{
								JObject jobject = (JObject)ModBase.GetJson(ModNet.NetRequestOnce("http://127.0.0.1:55555/api/port?proto=tcp&port=" + Port + "&password=" + PageLinkRight.classContainer, "PUT", "", "", 0x186A0, null, true));
								if (jobject["msg"] != null)
								{
									throw new InvalidOperationException(jobject["msg"].ToString());
								}
								PageLinkRight.mapContainer.Add(new PageLinkRight.RoomEntry(Conversions.ToInteger(Port), DisplayName, null));
								ModMain.Hint("房间 " + DisplayName + " 已创建！", ModMain.HintType.Finish, true);
								PageLinkRight.SendUpdateRequestToAllUsers();
							}
							catch (InvalidOperationException ex)
							{
								ModBase.Log("创建房间失败：" + ex.Message, ModBase.LogLevel.Msgbox, "出现错误");
							}
							catch (Exception ex2)
							{
								ModBase.Log(ex2, "创建房间失败", ModBase.LogLevel.Msgbox, "出现错误");
							}
						});
					}
				}
			}
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x000055D5 File Offset: 0x000037D5
		private static void SendUpdateRequestToAllUsers()
		{
			ModBase.RunInNewThread((PageLinkRight._Closure$__.$I48-0 == null) ? (PageLinkRight._Closure$__.$I48-0 = checked(delegate()
			{
				try
				{
					int num = PageLinkRight.m_ClientContainer.Count - 1;
					int num2 = 0;
					while (num2 <= num && num2 <= PageLinkRight.m_ClientContainer.Count - 1)
					{
						PageLinkRight.UserEntry userEntry = PageLinkRight.m_ClientContainer.Values.ElementAtOrDefault(num2);
						if (userEntry.m_ProcessRule >= 1.0)
						{
							PageLinkRight.SendUpdateRequest(userEntry, 1, -1L);
						}
						num2++;
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "发送全局刷新请求失败", ModBase.LogLevel.Debug, "出现错误");
				}
			})) : PageLinkRight._Closure$__.$I48-0, "Link Refresh All", ThreadPriority.Normal);
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x0002DB84 File Offset: 0x0002BD84
		private static void BtnRoomEdit_Click(MyIconButton sender, EventArgs e)
		{
			PageLinkRight.RoomEntry roomEntry = (PageLinkRight.RoomEntry)sender.Tag;
			string text = ModMain.MyMsgBoxInput(roomEntry.m_TemplateRule, new Collection<Validate>
			{
				new ValidateNullOrWhiteSpace(),
				new ValidateLength(1, 0x28)
			}, "", "输入房间名（建议包含游戏版本等信息）", "确定", "取消", false);
			if (text != null)
			{
				text = text.Trim();
				roomEntry.m_TemplateRule = text;
				ModMain._TagFilter.RefreshUi();
				PageLinkRight.SendUpdateRequestToAllUsers();
			}
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x0002DBFC File Offset: 0x0002BDFC
		private static void BtnRoom_Click(MyListItem sender, EventArgs e)
		{
			PageLinkRight.RoomEntry roomEntry = (PageLinkRight.RoomEntry)sender.Tag;
			if (ModMain.MyMsgBox("请在多人游戏页面点击直接连接，输入 " + roomEntry.SetupExpression() + " 以进入服务器！", "加入房间", "复制地址", "确定", "", false, true, false) == 1)
			{
				ModBase.ClipboardSet(roomEntry.SetupExpression(), true);
			}
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x00005607 File Offset: 0x00003807
		private static void BtnRoomClose_Click(MyIconButton sender, EventArgs e)
		{
			PageLinkRight.RoomEntry Room = (PageLinkRight.RoomEntry)sender.Tag;
			ModBase.RunInThread(delegate
			{
				try
				{
					JObject jobject = (JObject)ModBase.GetJson(ModNet.NetRequestOnce("http://127.0.0.1:55555/api/port?proto=tcp&port=" + Conversions.ToString(Room._ImporterRule) + "&password=" + PageLinkRight.classContainer, "DELETE", "", "", 0x186A0, null, true));
					if (jobject["msg"] != null)
					{
						throw new InvalidOperationException(jobject["msg"].ToString());
					}
					PageLinkRight.mapContainer.Remove(Room);
					ModBase.RunInUi((PageLinkRight._Closure$__.$I51-1 == null) ? (PageLinkRight._Closure$__.$I51-1 = delegate()
					{
						ModMain._TagFilter.RefreshUi();
					}) : PageLinkRight._Closure$__.$I51-1, false);
					PageLinkRight.SendUpdateRequestToAllUsers();
				}
				catch (InvalidOperationException ex)
				{
					if (PageLinkRight.StopContainer() == ModBase.LoadState.Finished)
					{
						ModBase.Log("移除房间失败：" + ex.Message, ModBase.LogLevel.Msgbox, "出现错误");
					}
				}
				catch (Exception ex2)
				{
					if (PageLinkRight.StopContainer() == ModBase.LoadState.Finished)
					{
						ModBase.Log(ex2, "移除房间失败", ModBase.LogLevel.Msgbox, "出现错误");
					}
				}
			});
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x0002DC58 File Offset: 0x0002BE58
		private static void ReceiveJson(JObject JsonData)
		{
			PageLinkRight._Closure$__52-1 CS$<>8__locals1 = new PageLinkRight._Closure$__52-1(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_JsonData = JsonData;
			string text = (string)CS$<>8__locals1.$VB$Local_JsonData["id"];
			string text2 = (string)CS$<>8__locals1.$VB$Local_JsonData["type"];
			string left = text2;
			if (Operators.CompareString(left, "connect", true) == 0)
			{
				PageLinkRight._Closure$__52-0 CS$<>8__locals2 = new PageLinkRight._Closure$__52-0(CS$<>8__locals2);
				CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2 = CS$<>8__locals1;
				string text3 = (string)CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_JsonData["name"];
				if (PageLinkRight.m_ClientContainer.ContainsKey(text))
				{
					PageLinkRight.m_ClientContainer[text].creatorRule = text3;
				}
				else
				{
					PageLinkRight.m_ClientContainer.Add(text, new PageLinkRight.UserEntry(text, text3));
				}
				CS$<>8__locals2.$VB$Local_User = PageLinkRight.m_ClientContainer[text];
				CS$<>8__locals2.$VB$Local_User.m_ListenerRule = ModBase.RunInNewThread(delegate
				{
					PageLinkRight.SendPortsubBack(CS$<>8__locals2.$VB$Local_User, CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_JsonData["version"].ToObject<int>());
				}, "Link Connect " + text3, ThreadPriority.Normal);
				CS$<>8__locals2.$VB$Local_User.authenticationRule = DateTime.Now;
				return;
			}
			checked
			{
				if (Operators.CompareString(left, "update", true) == 0)
				{
					PageLinkRight._Closure$__52-2 CS$<>8__locals3 = new PageLinkRight._Closure$__52-2(CS$<>8__locals3);
					if (!PageLinkRight.m_ClientContainer.ContainsKey(text))
					{
						throw new Exception("未在列表中的用户发送了更新请求：" + text);
					}
					CS$<>8__locals3.$VB$Local_User = PageLinkRight.m_ClientContainer[text];
					CS$<>8__locals3.$VB$Local_User.m_ProcessRule = 1.0;
					string text4 = (string)CS$<>8__locals1.$VB$Local_JsonData["name"];
					CS$<>8__locals3.$VB$Local_User.creatorRule = text4;
					if (CS$<>8__locals1.$VB$Local_JsonData["rooms"] != null)
					{
						CS$<>8__locals3.$VB$Local_User.m_InstanceRule = new List<PageLinkRight.RoomEntry>();
						try
						{
							foreach (JToken jtoken in ((IEnumerable<JToken>)CS$<>8__locals1.$VB$Local_JsonData["rooms"]))
							{
								CS$<>8__locals3.$VB$Local_User.m_InstanceRule.Add(new PageLinkRight.RoomEntry((int)jtoken["port"], (string)jtoken["name"], CS$<>8__locals3.$VB$Local_User));
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
					CS$<>8__locals3.$VB$Local_Stage = (int)CS$<>8__locals1.$VB$Local_JsonData["stage"];
					CS$<>8__locals3.$VB$Local_Unique = (long)CS$<>8__locals1.$VB$Local_JsonData["unique"];
					if (CS$<>8__locals3.$VB$Local_Stage > 1)
					{
						CS$<>8__locals3.$VB$Local_User._CustomerRule.Enqueue((int)Math.Round((DateTime.Now - CS$<>8__locals3.$VB$Local_User._TestRule[CS$<>8__locals3.$VB$Local_Unique]).TotalMilliseconds / 2.0));
						if (CS$<>8__locals3.$VB$Local_User._CustomerRule.Count > 5)
						{
							CS$<>8__locals3.$VB$Local_User._CustomerRule.Dequeue();
						}
						CS$<>8__locals3.$VB$Local_User._TestRule.Remove(CS$<>8__locals3.$VB$Local_Unique);
					}
					if (CS$<>8__locals3.$VB$Local_Stage > 0 && CS$<>8__locals3.$VB$Local_Stage < 3)
					{
						ModBase.RunInNewThread(delegate
						{
							try
							{
								PageLinkRight.SendUpdateRequest(CS$<>8__locals3.$VB$Local_User, CS$<>8__locals3.$VB$Local_Stage + 1, CS$<>8__locals3.$VB$Local_Unique);
							}
							catch (Exception ex)
							{
								ModBase.Log(ex, "发送回程请求失败", ModBase.LogLevel.Debug, "出现错误");
							}
						}, "Link Update " + text4, ThreadPriority.Normal);
					}
					CS$<>8__locals3.$VB$Local_User.authenticationRule = DateTime.Now;
					return;
				}
				else
				{
					if (Operators.CompareString(left, "disconnect", true) != 0)
					{
						throw new Exception("未知的操作种类：" + text2);
					}
					if (PageLinkRight.m_ClientContainer.ContainsKey(text))
					{
						PageLinkRight.UserEntry userEntry = PageLinkRight.m_ClientContainer[text];
						if (userEntry.m_ProcessRule < 1.0 && userEntry.m_ListenerRule != null && userEntry.m_ListenerRule.IsAlive)
						{
							userEntry.m_ListenerRule.Abort();
						}
						if (CS$<>8__locals1.$VB$Local_JsonData["message"] == null)
						{
							ModMain.Hint(userEntry.creatorRule + " 已离开！", ModMain.HintType.Info, true);
						}
						else
						{
							ModMain.Hint(CS$<>8__locals1.$VB$Local_JsonData["message"].ToString(), CS$<>8__locals1.$VB$Local_JsonData["isError"].ToObject<bool>() ? ModMain.HintType.Critical : ModMain.HintType.Info, true);
						}
						PageLinkRight.m_ClientContainer.Remove(text);
						return;
					}
					return;
				}
			}
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x0000562F File Offset: 0x0000382F
		private static void IoiAbort()
		{
			PageLinkRight.IoiStop(false);
			PageLinkRight.exceptionContainer.Error = new Exception("联机模块已关闭，点击以重新启动");
			PageLinkRight.exceptionContainer.State = ModBase.LoadState.Failed;
			PageLinkRight.configContainer = ModBase.LoadState.Failed;
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x0000565D File Offset: 0x0000385D
		private static void BtnFaq_Click()
		{
			PageOtherHelp.EnterHelpPage(ModBase.m_GlobalRule + "Help\\启动器\\联机.json");
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00005673 File Offset: 0x00003873
		private static void BtnPolice_Click()
		{
			ModBase.OpenWebsite("https://shimo.im/docs/rGrd8pY8xWkt6ryW#anchor-7x6P");
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x0000567F File Offset: 0x0000387F
		// (set) Token: 0x060005B1 RID: 1457 RVA: 0x00005687 File Offset: 0x00003887
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060005B2 RID: 1458 RVA: 0x00005690 File Offset: 0x00003890
		// (set) Token: 0x060005B3 RID: 1459 RVA: 0x00005698 File Offset: 0x00003898
		internal virtual MyCard CardRoom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060005B4 RID: 1460 RVA: 0x000056A1 File Offset: 0x000038A1
		// (set) Token: 0x060005B5 RID: 1461 RVA: 0x000056A9 File Offset: 0x000038A9
		internal virtual MyHint LabHint { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060005B6 RID: 1462 RVA: 0x000056B2 File Offset: 0x000038B2
		// (set) Token: 0x060005B7 RID: 1463 RVA: 0x000056BA File Offset: 0x000038BA
		internal virtual StackPanel PanRoom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x000056C3 File Offset: 0x000038C3
		// (set) Token: 0x060005B9 RID: 1465 RVA: 0x0002E090 File Offset: 0x0002C290
		internal virtual MyListItem BtnCreate
		{
			[CompilerGenerated]
			get
			{
				return this.procContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyListItem.ClickEventHandler obj = delegate(object sender, MouseButtonEventArgs e)
				{
					this.LinkCreate();
				};
				MyListItem myListItem = this.procContainer;
				if (myListItem != null)
				{
					myListItem.PushModel(obj);
				}
				this.procContainer = value;
				myListItem = this.procContainer;
				if (myListItem != null)
				{
					myListItem.QueryModel(obj);
				}
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060005BA RID: 1466 RVA: 0x000056CB File Offset: 0x000038CB
		// (set) Token: 0x060005BB RID: 1467 RVA: 0x0002E0D4 File Offset: 0x0002C2D4
		internal virtual MyTextBox TextLinkName
		{
			[CompilerGenerated]
			get
			{
				return this._FactoryModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = delegate(object sender, RoutedEventArgs e)
				{
					this.TextBoxChange((MyTextBox)sender, e);
				};
				RoutedEventHandler value3 = delegate(object sender, RoutedEventArgs e)
				{
					this.DisplayNameChange();
				};
				MyTextBox factoryModel = this._FactoryModel;
				if (factoryModel != null)
				{
					factoryModel.ResolveVal(value2);
					factoryModel.ResolveVal(value3);
				}
				this._FactoryModel = value;
				factoryModel = this._FactoryModel;
				if (factoryModel != null)
				{
					factoryModel.CancelVal(value2);
					factoryModel.CancelVal(value3);
				}
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x000056D3 File Offset: 0x000038D3
		// (set) Token: 0x060005BD RID: 1469 RVA: 0x0002E134 File Offset: 0x0002C334
		internal virtual MyCheckBox CheckLinkAuto
		{
			[CompilerGenerated]
			get
			{
				return this.valModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyCheckBox.ChangeEventHandler obj = delegate(object a0, bool a1)
				{
					this.CheckBoxChange((MyCheckBox)a0, a1);
				};
				MyCheckBox myCheckBox = this.valModel;
				if (myCheckBox != null)
				{
					myCheckBox.SearchIterator(obj);
				}
				this.valModel = value;
				myCheckBox = this.valModel;
				if (myCheckBox != null)
				{
					myCheckBox.RunIterator(obj);
				}
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060005BE RID: 1470 RVA: 0x000056DB File Offset: 0x000038DB
		// (set) Token: 0x060005BF RID: 1471 RVA: 0x0002E178 File Offset: 0x0002C378
		internal virtual MyTextButton BtnStop
		{
			[CompilerGenerated]
			get
			{
				return this._ContainerModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyTextButton.ClickEventHandler obj = (PageLinkRight._Closure$__.$IR86-8 == null) ? (PageLinkRight._Closure$__.$IR86-8 = delegate(object sender, EventArgs e)
				{
					PageLinkRight.IoiAbort();
				}) : PageLinkRight._Closure$__.$IR86-8;
				MyTextButton containerModel = this._ContainerModel;
				if (containerModel != null)
				{
					containerModel.FindContainer(obj);
				}
				this._ContainerModel = value;
				containerModel = this._ContainerModel;
				if (containerModel != null)
				{
					containerModel.CreateContainer(obj);
				}
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060005C0 RID: 1472 RVA: 0x000056E3 File Offset: 0x000038E3
		// (set) Token: 0x060005C1 RID: 1473 RVA: 0x0002E1D4 File Offset: 0x0002C3D4
		internal virtual MyTextButton BtnFaq
		{
			[CompilerGenerated]
			get
			{
				return this._ModelModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyTextButton.ClickEventHandler obj = (PageLinkRight._Closure$__.$IR90-9 == null) ? (PageLinkRight._Closure$__.$IR90-9 = delegate(object sender, EventArgs e)
				{
					PageLinkRight.BtnFaq_Click();
				}) : PageLinkRight._Closure$__.$IR90-9;
				MyTextButton modelModel = this._ModelModel;
				if (modelModel != null)
				{
					modelModel.FindContainer(obj);
				}
				this._ModelModel = value;
				modelModel = this._ModelModel;
				if (modelModel != null)
				{
					modelModel.CreateContainer(obj);
				}
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060005C2 RID: 1474 RVA: 0x000056EB File Offset: 0x000038EB
		// (set) Token: 0x060005C3 RID: 1475 RVA: 0x0002E230 File Offset: 0x0002C430
		internal virtual MyTextButton BtnPolice
		{
			[CompilerGenerated]
			get
			{
				return this._IteratorModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyTextButton.ClickEventHandler obj = (PageLinkRight._Closure$__.$IR94-10 == null) ? (PageLinkRight._Closure$__.$IR94-10 = delegate(object sender, EventArgs e)
				{
					PageLinkRight.BtnPolice_Click();
				}) : PageLinkRight._Closure$__.$IR94-10;
				MyTextButton iteratorModel = this._IteratorModel;
				if (iteratorModel != null)
				{
					iteratorModel.FindContainer(obj);
				}
				this._IteratorModel = value;
				iteratorModel = this._IteratorModel;
				if (iteratorModel != null)
				{
					iteratorModel.CreateContainer(obj);
				}
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060005C4 RID: 1476 RVA: 0x000056F3 File Offset: 0x000038F3
		// (set) Token: 0x060005C5 RID: 1477 RVA: 0x000056FB File Offset: 0x000038FB
		internal virtual MyCard PanLoad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060005C6 RID: 1478 RVA: 0x00005704 File Offset: 0x00003904
		// (set) Token: 0x060005C7 RID: 1479 RVA: 0x0002E28C File Offset: 0x0002C48C
		internal virtual MyLoading Load
		{
			[CompilerGenerated]
			get
			{
				return this.utilsModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyLoading.StateChangedEventHandler obj = new MyLoading.StateChangedEventHandler(this.Load_State);
				MyLoading.ClickEventHandler obj2 = new MyLoading.ClickEventHandler(this.Load_Click);
				MyLoading myLoading = this.utilsModel;
				if (myLoading != null)
				{
					myLoading.InitVal(obj);
					myLoading.UpdateVal(obj2);
				}
				this.utilsModel = value;
				myLoading = this.utilsModel;
				if (myLoading != null)
				{
					myLoading.FillVal(obj);
					myLoading.PrepareVal(obj2);
				}
			}
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0002E2EC File Offset: 0x0002C4EC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.m_BaseModel)
			{
				this.m_BaseModel = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagelinkright.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0002E31C File Offset: 0x0002C51C
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (MyScrollViewer)target;
				return;
			}
			if (connectionId == 2)
			{
				this.CardRoom = (MyCard)target;
				return;
			}
			if (connectionId == 3)
			{
				this.LabHint = (MyHint)target;
				return;
			}
			if (connectionId == 4)
			{
				this.PanRoom = (StackPanel)target;
				return;
			}
			if (connectionId == 5)
			{
				this.BtnCreate = (MyListItem)target;
				return;
			}
			if (connectionId == 6)
			{
				this.TextLinkName = (MyTextBox)target;
				return;
			}
			if (connectionId == 7)
			{
				this.CheckLinkAuto = (MyCheckBox)target;
				return;
			}
			if (connectionId == 8)
			{
				this.BtnStop = (MyTextButton)target;
				return;
			}
			if (connectionId == 9)
			{
				this.BtnFaq = (MyTextButton)target;
				return;
			}
			if (connectionId == 0xA)
			{
				this.BtnPolice = (MyTextButton)target;
				return;
			}
			if (connectionId == 0xB)
			{
				this.PanLoad = (MyCard)target;
				return;
			}
			if (connectionId == 0xC)
			{
				this.Load = (MyLoading)target;
				return;
			}
			this.m_BaseModel = true;
		}

		// Token: 0x040002A0 RID: 672
		private bool producerContainer;

		// Token: 0x040002A1 RID: 673
		private static ModLoader.LoaderCombo<int> exceptionContainer;

		// Token: 0x040002A2 RID: 674
		private static string _RulesContainer;

		// Token: 0x040002A3 RID: 675
		private static string classContainer;

		// Token: 0x040002A4 RID: 676
		private static Process serverContainer;

		// Token: 0x040002A5 RID: 677
		private static ModBase.LoadState configContainer;

		// Token: 0x040002A6 RID: 678
		private static int connectionContainer;

		// Token: 0x040002A7 RID: 679
		private static string _ListContainer;

		// Token: 0x040002A8 RID: 680
		private static string m_ReponseContainer;

		// Token: 0x040002A9 RID: 681
		private static string identifierContainer;

		// Token: 0x040002AA RID: 682
		private static string m_PolicyContainer;

		// Token: 0x040002AB RID: 683
		private static Dictionary<string, PageLinkRight.UserEntry> m_ClientContainer;

		// Token: 0x040002AC RID: 684
		private static List<PageLinkRight.RoomEntry> mapContainer;

		// Token: 0x040002AD RID: 685
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private MyScrollViewer composerContainer;

		// Token: 0x040002AE RID: 686
		[CompilerGenerated]
		[AccessedThroughProperty("CardRoom")]
		private MyCard _PublisherContainer;

		// Token: 0x040002AF RID: 687
		[AccessedThroughProperty("LabHint")]
		[CompilerGenerated]
		private MyHint messageContainer;

		// Token: 0x040002B0 RID: 688
		[AccessedThroughProperty("PanRoom")]
		[CompilerGenerated]
		private StackPanel tokenContainer;

		// Token: 0x040002B1 RID: 689
		[AccessedThroughProperty("BtnCreate")]
		[CompilerGenerated]
		private MyListItem procContainer;

		// Token: 0x040002B2 RID: 690
		[AccessedThroughProperty("TextLinkName")]
		[CompilerGenerated]
		private MyTextBox _FactoryModel;

		// Token: 0x040002B3 RID: 691
		[CompilerGenerated]
		[AccessedThroughProperty("CheckLinkAuto")]
		private MyCheckBox valModel;

		// Token: 0x040002B4 RID: 692
		[CompilerGenerated]
		[AccessedThroughProperty("BtnStop")]
		private MyTextButton _ContainerModel;

		// Token: 0x040002B5 RID: 693
		[CompilerGenerated]
		[AccessedThroughProperty("BtnFaq")]
		private MyTextButton _ModelModel;

		// Token: 0x040002B6 RID: 694
		[CompilerGenerated]
		[AccessedThroughProperty("BtnPolice")]
		private MyTextButton _IteratorModel;

		// Token: 0x040002B7 RID: 695
		[AccessedThroughProperty("PanLoad")]
		[CompilerGenerated]
		private MyCard _ExpressionModel;

		// Token: 0x040002B8 RID: 696
		[AccessedThroughProperty("Load")]
		[CompilerGenerated]
		private MyLoading utilsModel;

		// Token: 0x040002B9 RID: 697
		private bool m_BaseModel;

		// Token: 0x0200009B RID: 155
		private class UserEntry
		{
			// Token: 0x060005D3 RID: 1491 RVA: 0x0002E460 File Offset: 0x0002C660
			public UserEntry(string Id, string DisplayName)
			{
				this.pageRule = new Dictionary<int, string>();
				this.m_InstanceRule = new List<PageLinkRight.RoomEntry>();
				this._TestRule = new Dictionary<long, DateTime>();
				this._CustomerRule = new Queue<int>();
				this._TaskRule = DateTime.Now;
				this.authenticationRule = DateTime.Now;
				this.m_ProcessRule = 0.0;
				this.m_ListenerRule = null;
				this.stateRule = Id;
				this.creatorRule = DisplayName;
				ModBase.Log("[Link] 新用户对象：" + this.ToString(), ModBase.LogLevel.Normal, "出现错误");
			}

			// Token: 0x060005D4 RID: 1492 RVA: 0x00005763 File Offset: 0x00003963
			public override string ToString()
			{
				return this.creatorRule + " @ " + this.stateRule;
			}

			// Token: 0x060005D5 RID: 1493 RVA: 0x0000577B File Offset: 0x0000397B
			public static implicit operator string(PageLinkRight.UserEntry User)
			{
				return User.ToString();
			}

			// Token: 0x060005D6 RID: 1494 RVA: 0x0002E4F4 File Offset: 0x0002C6F4
			public string GetDescription()
			{
				if (this.m_ProcessRule >= 1.0)
				{
					return "已连接，" + ((this._CustomerRule.Count == 0) ? "检查延迟中" : (Conversions.ToString(Math.Round(this._CustomerRule.Average())) + "ms"));
				}
				return "正在连接，" + Conversions.ToString(Math.Round(this.m_ProcessRule * 100.0)) + "%";
			}

			// Token: 0x060005D7 RID: 1495 RVA: 0x0002E57C File Offset: 0x0002C77C
			public MyListItem ToListItem()
			{
				MyListItem myListItem = new MyListItem
				{
					Title = this.creatorRule,
					Height = 40.0,
					Tag = this,
					Type = MyListItem.CheckType.None,
					IsScaleAnimationEnabled = false,
					PaddingLeft = 6,
					PaddingRight = 0x3C,
					Logo = "pack://application:,,,/images/Blocks/Grass.png"
				};
				MyIconButton myIconButton = new MyIconButton
				{
					Logo = "M875.52 148.48C783.36 56.32 655.36 0 512 0 291.84 0 107.52 138.24 30.72 332.8l122.88 46.08C204.8 230.4 348.16 128 512 128c107.52 0 199.68 40.96 271.36 112.64L640 384h384V0L875.52 148.48zM512 896c-107.52 0-199.68-40.96-271.36-112.64L384 640H0v384l148.48-148.48C240.64 967.68 368.64 1024 512 1024c220.16 0 404.48-138.24 481.28-332.8L870.4 645.12C819.2 793.6 675.84 896 512 896z",
					LogoScale = 0.85,
					ToolTip = "刷新",
					Tag = this
				};
				myIconButton.Click += ((PageLinkRight.UserEntry._Closure$__.$IR14-1 == null) ? (PageLinkRight.UserEntry._Closure$__.$IR14-1 = delegate(object sender, EventArgs e)
				{
					PageLinkRight.BtnListRefresh_Click((MyIconButton)sender, e);
				}) : PageLinkRight.UserEntry._Closure$__.$IR14-1);
				ToolTipService.SetPlacement(myIconButton, PlacementMode.Bottom);
				ToolTipService.SetHorizontalOffset(myIconButton, -10.0);
				ToolTipService.SetVerticalOffset(myIconButton, 5.0);
				ToolTipService.SetShowDuration(myIconButton, 0x239A95);
				ToolTipService.SetInitialShowDelay(myIconButton, 0xC8);
				MyIconButton myIconButton2 = new MyIconButton
				{
					Logo = "F1 M 26.9166,22.1667L 37.9999,33.25L 49.0832,22.1668L 53.8332,26.9168L 42.7499,38L 53.8332,49.0834L 49.0833,53.8334L 37.9999,42.75L 26.9166,53.8334L 22.1666,49.0833L 33.25,38L 22.1667,26.9167L 26.9166,22.1667 Z",
					LogoScale = 0.85,
					ToolTip = "断开",
					Tag = this
				};
				myIconButton2.Click += ((PageLinkRight.UserEntry._Closure$__.$IR14-2 == null) ? (PageLinkRight.UserEntry._Closure$__.$IR14-2 = delegate(object sender, EventArgs e)
				{
					PageLinkRight.BtnListDisconnect_Click((MyIconButton)sender, e);
				}) : PageLinkRight.UserEntry._Closure$__.$IR14-2);
				ToolTipService.SetPlacement(myIconButton2, PlacementMode.Bottom);
				ToolTipService.SetHorizontalOffset(myIconButton2, -10.0);
				ToolTipService.SetVerticalOffset(myIconButton2, 5.0);
				ToolTipService.SetShowDuration(myIconButton2, 0x239A95);
				ToolTipService.SetInitialShowDelay(myIconButton2, 0xC8);
				myListItem.Buttons = new MyIconButton[]
				{
					myIconButton,
					myIconButton2
				};
				this.RefreshUi(myListItem);
				return myListItem;
			}

			// Token: 0x060005D8 RID: 1496 RVA: 0x0002E724 File Offset: 0x0002C924
			public void RefreshUi(MyListItem RelatedListItem)
			{
				RelatedListItem.Title = this.creatorRule;
				RelatedListItem.Info = this.GetDescription();
				NewLateBinding.LateSetComplex(RelatedListItem.Buttons.Cast<object>().ElementAtOrDefault(0), null, "Visibility", new object[]
				{
					(this.m_ProcessRule == 1.0) ? Visibility.Visible : Visibility.Collapsed
				}, null, null, false, true);
			}

			// Token: 0x040002BA RID: 698
			public string stateRule;

			// Token: 0x040002BB RID: 699
			public string creatorRule;

			// Token: 0x040002BC RID: 700
			public Dictionary<int, string> pageRule;

			// Token: 0x040002BD RID: 701
			public List<PageLinkRight.RoomEntry> m_InstanceRule;

			// Token: 0x040002BE RID: 702
			public Dictionary<long, DateTime> _TestRule;

			// Token: 0x040002BF RID: 703
			public Queue<int> _CustomerRule;

			// Token: 0x040002C0 RID: 704
			public DateTime _TaskRule;

			// Token: 0x040002C1 RID: 705
			public DateTime authenticationRule;

			// Token: 0x040002C2 RID: 706
			public double m_ProcessRule;

			// Token: 0x040002C3 RID: 707
			public Thread m_ListenerRule;
		}

		// Token: 0x0200009D RID: 157
		private class RoomEntry
		{
			// Token: 0x060005DD RID: 1501 RVA: 0x0002E78C File Offset: 0x0002C98C
			public string SetupExpression()
			{
				string result;
				if (this.annotationRule)
				{
					result = "localhost:" + Conversions.ToString(this._ImporterRule);
				}
				else
				{
					result = this.m_AdapterRule.pageRule[this._ImporterRule] + ":" + Conversions.ToString(this._ImporterRule);
				}
				return result;
			}

			// Token: 0x060005DE RID: 1502 RVA: 0x000057AB File Offset: 0x000039AB
			public RoomEntry(int Port, string DisplayName, PageLinkRight.UserEntry User = null)
			{
				this.m_AdapterRule = null;
				this.annotationRule = (User == null);
				this.m_AdapterRule = User;
				this.m_TemplateRule = DisplayName;
				this._ImporterRule = Port;
			}

			// Token: 0x060005DF RID: 1503 RVA: 0x0002E7E8 File Offset: 0x0002C9E8
			public override string ToString()
			{
				return string.Concat(new string[]
				{
					this.m_TemplateRule,
					" - ",
					Conversions.ToString(this._ImporterRule),
					" - ",
					Conversions.ToString(this.annotationRule)
				});
			}

			// Token: 0x060005E0 RID: 1504 RVA: 0x000057D9 File Offset: 0x000039D9
			public static implicit operator string(PageLinkRight.RoomEntry Room)
			{
				return Room.ToString();
			}

			// Token: 0x060005E1 RID: 1505 RVA: 0x000057E1 File Offset: 0x000039E1
			public static int SelectPort(PageLinkRight.RoomEntry Room)
			{
				return Room._ImporterRule;
			}

			// Token: 0x060005E2 RID: 1506 RVA: 0x0002E838 File Offset: 0x0002CA38
			public string GetDescription()
			{
				string result;
				if (this.annotationRule)
				{
					result = "由我创建，端口 " + Conversions.ToString(this._ImporterRule);
				}
				else
				{
					result = "由 " + this.m_AdapterRule.creatorRule + " 创建，端口 " + Conversions.ToString(this._ImporterRule);
				}
				return result;
			}

			// Token: 0x060005E3 RID: 1507 RVA: 0x0002E88C File Offset: 0x0002CA8C
			public MyListItem ToListItem()
			{
				MyListItem myListItem = new MyListItem
				{
					Title = this.m_TemplateRule,
					Height = 42.0,
					Info = this.GetDescription(),
					Tag = this,
					PaddingRight = (this.annotationRule ? 0x3C : 0),
					Type = (this.annotationRule ? MyListItem.CheckType.None : MyListItem.CheckType.Clickable),
					Logo = "pack://application:,,,/images/Blocks/" + (this.annotationRule ? "GrassPath" : "Grass") + ".png"
				};
				if (this.annotationRule)
				{
					MyIconButton myIconButton = new MyIconButton
					{
						Logo = "M732.64 64.32C688.576 21.216 613.696 21.216 569.6 64.32L120.128 499.52c-17.6 12.896-26.432 30.144-30.848 51.68L32 870.048c0 25.856 8.8 56 26.432 73.248 17.632 17.216 17.632 48.704 88.64 48.704h13.248l326.08-56c22.016-4.32 39.68-12.928 52.864-30.176l449.472-435.2c22.048-21.536 35.264-47.36 35.264-77.536 0-30.176-13.216-56-35.264-77.568l-256.096-251.2zM139.712 903.776l56-326.912 311.04-295.136 267.104 269.44-310.976 295.168-323.168 57.44zM844.576 467.84l-273.984-260.672 61.856-59.84c8.832-8.512 26.528-8.512 39.776 0l234.24 226.496c4.384 4.288 8.832 12.8 8.832 17.088s-4.416 8.544-8.864 12.8l-61.856 64.128z",
						LogoScale = 1.0,
						ToolTip = "修改名称",
						Tag = this
					};
					myIconButton.Click += ((PageLinkRight.RoomEntry._Closure$__.$IR11-1 == null) ? (PageLinkRight.RoomEntry._Closure$__.$IR11-1 = delegate(object sender, EventArgs e)
					{
						PageLinkRight.BtnRoomEdit_Click((MyIconButton)sender, e);
					}) : PageLinkRight.RoomEntry._Closure$__.$IR11-1);
					ToolTipService.SetPlacement(myIconButton, PlacementMode.Bottom);
					ToolTipService.SetHorizontalOffset(myIconButton, -22.0);
					ToolTipService.SetVerticalOffset(myIconButton, 5.0);
					ToolTipService.SetShowDuration(myIconButton, 0x239A95);
					ToolTipService.SetInitialShowDelay(myIconButton, 0xC8);
					MyIconButton myIconButton2 = new MyIconButton
					{
						Logo = "F1 M 26.9166,22.1667L 37.9999,33.25L 49.0832,22.1668L 53.8332,26.9168L 42.7499,38L 53.8332,49.0834L 49.0833,53.8334L 37.9999,42.75L 26.9166,53.8334L 22.1666,49.0833L 33.25,38L 22.1667,26.9167L 26.9166,22.1667 Z",
						LogoScale = 0.85,
						ToolTip = "关闭",
						Tag = this
					};
					myIconButton2.Click += ((PageLinkRight.RoomEntry._Closure$__.$IR11-2 == null) ? (PageLinkRight.RoomEntry._Closure$__.$IR11-2 = delegate(object sender, EventArgs e)
					{
						PageLinkRight.BtnRoomClose_Click((MyIconButton)sender, e);
					}) : PageLinkRight.RoomEntry._Closure$__.$IR11-2);
					ToolTipService.SetPlacement(myIconButton2, PlacementMode.Bottom);
					ToolTipService.SetHorizontalOffset(myIconButton2, -10.0);
					ToolTipService.SetVerticalOffset(myIconButton2, 5.0);
					ToolTipService.SetShowDuration(myIconButton2, 0x239A95);
					ToolTipService.SetInitialShowDelay(myIconButton2, 0xC8);
					myListItem.Buttons = new MyIconButton[]
					{
						myIconButton,
						myIconButton2
					};
				}
				else
				{
					myListItem.QueryModel((PageLinkRight.RoomEntry._Closure$__.$IR11-3 == null) ? (PageLinkRight.RoomEntry._Closure$__.$IR11-3 = delegate(object sender, MouseButtonEventArgs e)
					{
						PageLinkRight.BtnRoom_Click((MyListItem)sender, e);
					}) : PageLinkRight.RoomEntry._Closure$__.$IR11-3);
				}
				return myListItem;
			}

			// Token: 0x060005E4 RID: 1508 RVA: 0x000057E9 File Offset: 0x000039E9
			public void RefreshUi(MyListItem RelatedListItem)
			{
				RelatedListItem.Title = this.m_TemplateRule;
				RelatedListItem.Info = this.GetDescription();
			}

			// Token: 0x040002C7 RID: 711
			public int _ImporterRule;

			// Token: 0x040002C8 RID: 712
			public string m_TemplateRule;

			// Token: 0x040002C9 RID: 713
			public PageLinkRight.UserEntry m_AdapterRule;

			// Token: 0x040002CA RID: 714
			public bool annotationRule;
		}
	}
}
