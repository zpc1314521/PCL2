using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace PCL
{
	// Token: 0x02000060 RID: 96
	[StandardModule]
	public sealed class ModWatcher
	{
		// Token: 0x0600029A RID: 666 RVA: 0x00003A5E File Offset: 0x00001C5E
		// Note: this type is marked as 'beforefieldinit'.
		static ModWatcher()
		{
			ModWatcher.m_TestsVal = new List<ModWatcher.Watcher>();
			ModWatcher.broadcasterVal = false;
			ModWatcher.m_FieldVal = false;
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0001A238 File Offset: 0x00018438
		private static void WatcherStateChanged()
		{
			bool flag = false;
			bool hasMinecraftCrashed = false;
			try
			{
				foreach (ModWatcher.Watcher watcher in ModWatcher.m_TestsVal)
				{
					if (watcher.State != ModWatcher.Watcher.MinecraftState.Loading)
					{
						if (watcher.State != ModWatcher.Watcher.MinecraftState.Running)
						{
							if (watcher.State == ModWatcher.Watcher.MinecraftState.Crashed)
							{
								hasMinecraftCrashed = true;
								continue;
							}
							continue;
						}
					}
					flag = true;
					break;
				}
			}
			finally
			{
				List<ModWatcher.Watcher>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			if (ModWatcher.broadcasterVal != flag)
			{
				ModWatcher.broadcasterVal = flag;
				if (ModWatcher.broadcasterVal)
				{
					ModWatcher.MinecraftStart();
					return;
				}
				ModWatcher.MinecraftStop(hasMinecraftCrashed);
			}
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00003A76 File Offset: 0x00001C76
		private static void MinecraftStart()
		{
			ModLaunch.McLaunchLog("[全局] 出现运行中的 Minecraft");
			ModWatcher.m_FieldVal = true;
			ModMain.m_GetterFilter.BtnExtraShutdown.ShowRefresh();
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0001A2CC File Offset: 0x000184CC
		private static void MinecraftStop(bool HasMinecraftCrashed)
		{
			ModLaunch.McLaunchLog("[全局] 已无运行中的 Minecraft");
			ModWatcher.m_FieldVal = false;
			ModMain.m_GetterFilter.BtnExtraShutdown.ShowRefresh();
			if (Conversions.ToBoolean(ModBase._BaseRule.Get("UiMusicStop", null)))
			{
				ModBase.RunInUi((ModWatcher._Closure$__.$I6-0 == null) ? (ModWatcher._Closure$__.$I6-0 = delegate()
				{
					if (ModMusic.MusicResume())
					{
						ModBase.Log("[Music] 已根据设置，在结束后开始音乐播放", ModBase.LogLevel.Normal, "出现错误");
					}
				}) : ModWatcher._Closure$__.$I6-0, false);
			}
			else if (Conversions.ToBoolean(ModBase._BaseRule.Get("UiMusicStart", null)))
			{
				ModBase.RunInUi((ModWatcher._Closure$__.$I6-1 == null) ? (ModWatcher._Closure$__.$I6-1 = delegate()
				{
					if (ModMusic.MusicPause())
					{
						ModBase.Log("[Music] 已根据设置，在结束后暂停音乐播放", ModBase.LogLevel.Normal, "出现错误");
					}
				}) : ModWatcher._Closure$__.$I6-1, false);
			}
			object left = ModBase._BaseRule.Get("LaunchArgumentVisible", null);
			if (!Operators.ConditionalCompareObjectEqual(left, 2, true))
			{
				if (Operators.ConditionalCompareObjectEqual(left, 3, true))
				{
					ModBase.RunInUi((ModWatcher._Closure$__.$I6-4 == null) ? (ModWatcher._Closure$__.$I6-4 = delegate()
					{
						ModMain.m_GetterFilter.Hidden = false;
					}) : ModWatcher._Closure$__.$I6-4, false);
				}
				return;
			}
			if (HasMinecraftCrashed)
			{
				ModBase.RunInUi((ModWatcher._Closure$__.$I6-2 == null) ? (ModWatcher._Closure$__.$I6-2 = delegate()
				{
					ModMain.m_GetterFilter.Hidden = false;
				}) : ModWatcher._Closure$__.$I6-2, false);
				return;
			}
			ModBase.RunInUi((ModWatcher._Closure$__.$I6-3 == null) ? (ModWatcher._Closure$__.$I6-3 = delegate()
			{
				ModMain.m_GetterFilter.EndProgram(false);
			}) : ModWatcher._Closure$__.$I6-3, false);
		}

		// Token: 0x04000148 RID: 328
		public static List<ModWatcher.Watcher> m_TestsVal;

		// Token: 0x04000149 RID: 329
		private static bool broadcasterVal;

		// Token: 0x0400014A RID: 330
		public static bool m_FieldVal;

		// Token: 0x02000061 RID: 97
		public class Watcher
		{
			// Token: 0x0600029E RID: 670 RVA: 0x0001A430 File Offset: 0x00018630
			public Watcher(ModLoader.LoaderTask<Process, int> Loader, ModMinecraft.McVersion Version, string WindowTitle)
			{
				ModWatcher.Watcher._Closure$__5-0 CS$<>8__locals1 = new ModWatcher.Watcher._Closure$__5-0(CS$<>8__locals1);
				CS$<>8__locals1.$VB$Local_Loader = Loader;
				CS$<>8__locals1.$VB$Local_WindowTitle = WindowTitle;
				base..ctor();
				CS$<>8__locals1.$VB$Me = this;
				this.m_AttributeRule = "";
				this.advisorRule = ModWatcher.Watcher.MinecraftState.Loading;
				this._StrategyRule = new List<string>(0x3E8);
				this.m_WrapperRule = RuntimeHelpers.GetObjectValue(new object());
				this.m_WriterRule = new Queue<string>();
				this._ExporterRule = 0;
				this.recordRule = false;
				this.m_GetterRule = false;
				this._RoleRule = CS$<>8__locals1.$VB$Local_Loader;
				this.registryRule = Version;
				this.m_AttributeRule = CS$<>8__locals1.$VB$Local_WindowTitle;
				this._ValueRule = CS$<>8__locals1.$VB$Local_Loader.Input.Id;
				this.WatcherLog("开始 Minecraft 日志监控");
				if (Operators.CompareString(this.m_AttributeRule, "", true) != 0)
				{
					this.WatcherLog("要求窗口标题：" + CS$<>8__locals1.$VB$Local_WindowTitle);
				}
				List<ModWatcher.Watcher> list = new List<ModWatcher.Watcher>();
				try
				{
					foreach (ModWatcher.Watcher watcher in ModWatcher.m_TestsVal)
					{
						if (watcher.State != ModWatcher.Watcher.MinecraftState.Crashed && watcher.State != ModWatcher.Watcher.MinecraftState.Ended)
						{
							list.Add(watcher);
						}
					}
				}
				finally
				{
					List<ModWatcher.Watcher>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				list.Add(this);
				ModWatcher.m_TestsVal = list;
				ModWatcher.WatcherStateChanged();
				this.comparatorRule = CS$<>8__locals1.$VB$Local_Loader.Input;
				this.comparatorRule.BeginOutputReadLine();
				this.comparatorRule.BeginErrorReadLine();
				this.comparatorRule.OutputDataReceived += this.LogReceived;
				this.comparatorRule.ErrorDataReceived += this.LogReceived;
				ModBase.RunInNewThread(checked(delegate
				{
					try
					{
						CS$<>8__locals1.$VB$Me._InvocationRule = CS$<>8__locals1.$VB$Me.GetAllMinecraftWindowHandle(false).Keys.ToList<IntPtr>();
						while (CS$<>8__locals1.$VB$Me.State != ModWatcher.Watcher.MinecraftState.Ended && CS$<>8__locals1.$VB$Me.State != ModWatcher.Watcher.MinecraftState.Crashed)
						{
							if (CS$<>8__locals1.$VB$Local_Loader.State == ModBase.LoadState.Aborted)
							{
								break;
							}
							CS$<>8__locals1.$VB$Me.TimerWindow();
							CS$<>8__locals1.$VB$Me.TimerLog();
							if (CS$<>8__locals1.$VB$Me.State == ModWatcher.Watcher.MinecraftState.Loading)
							{
								CS$<>8__locals1.$VB$Me.ProgressUpdate();
							}
							int num = 1;
							do
							{
								if (CS$<>8__locals1.$VB$Me.m_GetterRule && Operators.CompareString(CS$<>8__locals1.$VB$Local_WindowTitle, "", true) != 0 && CS$<>8__locals1.$VB$Me.State == ModWatcher.Watcher.MinecraftState.Running && !CS$<>8__locals1.$VB$Me.comparatorRule.HasExited)
								{
									string text = CS$<>8__locals1.$VB$Local_WindowTitle.Replace("{time}", DateTime.Now.ToShortTimeString());
									int hWnd = (int)CS$<>8__locals1.$VB$Me.interceptorRule;
									string text2 = new string(text.ToCharArray());
									ModWatcher.Watcher.SetWindowTextA(hWnd, ref text2);
								}
								Thread.Sleep(0x40);
								num++;
							}
							while (num <= 3);
						}
						CS$<>8__locals1.$VB$Me.WatcherLog("Minecraft 日志监控已退出");
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "Minecraft 日志监控主循环出错", ModBase.LogLevel.Feedback, "出现错误");
						CS$<>8__locals1.$VB$Me.State = ModWatcher.Watcher.MinecraftState.Ended;
					}
				}), "Minecraft Watcher PID " + Conversions.ToString(this._ValueRule), ThreadPriority.Normal);
			}

			// Token: 0x1700005C RID: 92
			// (get) Token: 0x0600029F RID: 671 RVA: 0x00003A97 File Offset: 0x00001C97
			// (set) Token: 0x060002A0 RID: 672 RVA: 0x00003A9F File Offset: 0x00001C9F
			public ModWatcher.Watcher.MinecraftState State
			{
				get
				{
					return this.advisorRule;
				}
				set
				{
					if (this.advisorRule != value)
					{
						this.advisorRule = value;
						ModWatcher.WatcherStateChanged();
					}
				}
			}

			// Token: 0x060002A1 RID: 673 RVA: 0x0001A608 File Offset: 0x00018808
			private void LogReceived(object sender, DataReceivedEventArgs e)
			{
				object wrapperRule = this.m_WrapperRule;
				ObjectFlowControl.CheckForSyncLockOnValueType(wrapperRule);
				lock (wrapperRule)
				{
					this._StrategyRule.Add(e.Data);
				}
			}

			// Token: 0x060002A2 RID: 674 RVA: 0x0001A65C File Offset: 0x0001885C
			private void TimerLog()
			{
				try
				{
					List<string> list = new List<string>();
					object wrapperRule = this.m_WrapperRule;
					ObjectFlowControl.CheckForSyncLockOnValueType(wrapperRule);
					lock (wrapperRule)
					{
						if (this._StrategyRule.Count == 0)
						{
							return;
						}
						list = this._StrategyRule;
						this._StrategyRule = new List<string>(0x3E8);
					}
					try
					{
						foreach (string text in list)
						{
							this.GameLog(text);
						}
					}
					finally
					{
						List<string>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					if (this.comparatorRule.HasExited)
					{
						this.WatcherLog("Minecraft 已退出，返回值：" + Conversions.ToString(this.comparatorRule.ExitCode));
						if (this.State == ModWatcher.Watcher.MinecraftState.Loading)
						{
							this.WatcherLog("Minecraft 尚未加载完成，可能已崩溃");
							this.Crashed();
						}
						else if (this.comparatorRule.ExitCode != 0 && this.State == ModWatcher.Watcher.MinecraftState.Running && this.registryRule.m_RulesAlgo.Year >= 0x7DC)
						{
							this.WatcherLog("Minecraft 返回值异常，可能已崩溃");
							this.Crashed();
						}
						else
						{
							this.State = ModWatcher.Watcher.MinecraftState.Ended;
						}
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "输出 Minecraft 日志失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}

			// Token: 0x060002A3 RID: 675 RVA: 0x0001A7F0 File Offset: 0x000189F0
			private void GameLog(string Text)
			{
				if (Text != null)
				{
					Text = Text.Replace("\r\n", "\r").Replace("\n", "\r").Replace("\r", "\r\n");
					this.m_WriterRule.Enqueue(Text);
					if (this.m_WriterRule.Count >= 0xC9)
					{
						this.m_WriterRule.Dequeue();
					}
					if (this._ExporterRule < 1)
					{
						this.WatcherLog("日志 1/5：已出现日志输出");
						this._ExporterRule = 1;
					}
					if (this._ExporterRule < 2 && Text.Contains("Setting user:"))
					{
						this.WatcherLog("日志 2/5：游戏用户已设置");
						this._ExporterRule = 2;
					}
					else if (this._ExporterRule < 3 && Text.ToLower().Contains("lwjgl version"))
					{
						this.WatcherLog("日志 3/5：LWJGL 版本已确认");
						this._ExporterRule = 3;
					}
					else if (this._ExporterRule < 4 && (Text.Contains("OpenAL initialized") || Text.Contains("Starting up SoundSystem")))
					{
						this.WatcherLog("日志 4/5：OpenAL 已加载");
						this._ExporterRule = 4;
					}
					else if (this._ExporterRule < 5 && ((Text.Contains("Created") && Text.Contains("textures") && Text.Contains("-atlas")) || Text.Contains("Found animation info")))
					{
						this.WatcherLog("日志 5/5：材质已加载");
						this._ExporterRule = 5;
					}
					if (!Text.Contains("[CHAT]"))
					{
						if (Text.Contains("Someone is closing me!"))
						{
							this.WatcherLog("识别为关闭的 Log：" + Text);
							this.State = ModWatcher.Watcher.MinecraftState.Ended;
							return;
						}
						if (Text.Contains("Game crashed! Crash report saved to:") || Text.Contains("This crash report has been saved to:"))
						{
							this.WatcherLog("识别为崩溃的 Log：" + Text);
							this.Crashed();
							return;
						}
						if (Text.Contains("Could not save crash report to"))
						{
							this.WatcherLog("识别为崩溃的 Log：" + Text);
							this.Crashed();
							return;
						}
						if (Text.Contains("/ERROR]: Unable to launch") || Text.Contains("An exception was thrown, the game will display an error screen and halt."))
						{
							this.WatcherLog("识别为崩溃的 Log：" + Text);
							this.Crashed();
						}
					}
				}
			}

			// Token: 0x060002A4 RID: 676 RVA: 0x00003AB6 File Offset: 0x00001CB6
			private void WatcherLog(string Text)
			{
				ModLaunch.McLaunchLog("[" + Conversions.ToString(this._ValueRule) + "] " + Text);
			}

			// Token: 0x060002A5 RID: 677 RVA: 0x0001AA20 File Offset: 0x00018C20
			private void ProgressUpdate()
			{
				double progress;
				if (!this.recordRule)
				{
					if (this._ExporterRule != 5)
					{
						progress = (double)Math.Min(this._ExporterRule, 3) / 3.0 * 0.9;
						goto IL_53;
					}
				}
				progress = 0.95;
				this.WatcherLog("Minecraft 加载已完成");
				this.State = ModWatcher.Watcher.MinecraftState.Running;
				IL_53:
				this._RoleRule.Progress = progress;
			}

			// Token: 0x060002A6 RID: 678 RVA: 0x0001AA8C File Offset: 0x00018C8C
			private void TimerWindow()
			{
				try
				{
					if (!this.comparatorRule.HasExited)
					{
						if (!this.m_GetterRule)
						{
							Dictionary<IntPtr, bool> allMinecraftWindowHandle = this.GetAllMinecraftWindowHandle(true);
							try
							{
								foreach (IntPtr key in this._InvocationRule)
								{
									if (allMinecraftWindowHandle.ContainsKey(key))
									{
										allMinecraftWindowHandle.Remove(key);
									}
								}
							}
							finally
							{
								List<IntPtr>.Enumerator enumerator;
								((IDisposable)enumerator).Dispose();
							}
							if (allMinecraftWindowHandle.Count != 0)
							{
								if (allMinecraftWindowHandle.Values.ElementAtOrDefault(0))
								{
									this.interceptorRule = allMinecraftWindowHandle.Keys.ElementAtOrDefault(0);
									this.WatcherLog("Minecraft 窗口已加载：" + Conversions.ToString(this.interceptorRule.ToInt64()));
									this.m_GetterRule = true;
									Thread.Sleep(0xBB8);
									if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LaunchArgumentWindowType", null), 4, true))
									{
										ModWatcher.Watcher.ShowWindow(this.interceptorRule, 3U);
									}
								}
								else if (!this.recordRule)
								{
									this.WatcherLog("FML 窗口已加载：" + Conversions.ToString(allMinecraftWindowHandle.Keys.ElementAtOrDefault(0).ToInt64()));
								}
								this.recordRule = true;
							}
						}
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "检查 Minecraft 窗口失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}

			// Token: 0x060002A7 RID: 679 RVA: 0x00003AD8 File Offset: 0x00001CD8
			private Dictionary<IntPtr, bool> GetAllMinecraftWindowHandle(bool CanUseFml)
			{
				Dictionary<IntPtr, bool> AllList = new Dictionary<IntPtr, bool>();
				ModWatcher.Watcher.EnumWindows(delegate(IntPtr hwnd, int lParam)
				{
					StringBuilder stringBuilder = new StringBuilder(0x200);
					ModWatcher.Watcher.GetClassNameA((int)hwnd, stringBuilder, stringBuilder.Capacity);
					string left = stringBuilder.ToString();
					if (Operators.CompareString(left, "GLFW30", true) == 0 || Operators.CompareString(left, "LWJGL", true) == 0 || Operators.CompareString(left, "SunAwtFrame", true) == 0)
					{
						stringBuilder = new StringBuilder(0x200);
						ModWatcher.Watcher.GetWindowTextA((int)hwnd, stringBuilder, stringBuilder.Capacity);
						string text = stringBuilder.ToString();
						if (CanUseFml && text.StartsWith("FML"))
						{
							AllList.Add(hwnd, false);
							return;
						}
						if (!text.StartsWith("GLFW") && Operators.CompareString(text, "PopupMessageWindow", true) != 0)
						{
							AllList.Add(hwnd, true);
						}
					}
				}, 0);
				return AllList;
			}

			// Token: 0x060002A8 RID: 680
			[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
			private static extern bool EnumWindows(ModWatcher.Watcher.EnumWindowsSub hWnd, int lParam);

			// Token: 0x060002A9 RID: 681
			[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
			private static extern int GetClassNameA(int hWnd, StringBuilder str, int maxCount);

			// Token: 0x060002AA RID: 682
			[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
			private static extern int GetWindowTextA(int hWnd, StringBuilder str, int maxCount);

			// Token: 0x060002AB RID: 683
			[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
			private static extern bool SetWindowTextA(int hWnd, [MarshalAs(UnmanagedType.VBByRefStr)] ref string str);

			// Token: 0x060002AC RID: 684
			[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
			private static extern bool ShowWindow(IntPtr hWnd, uint cmdWindow);

			// Token: 0x060002AD RID: 685 RVA: 0x0001AC18 File Offset: 0x00018E18
			private void Crashed()
			{
				if (this.State != ModWatcher.Watcher.MinecraftState.Crashed && this.State != ModWatcher.Watcher.MinecraftState.Ended)
				{
					this.State = ModWatcher.Watcher.MinecraftState.Crashed;
					this.WatcherLog("Minecraft 已崩溃，将在 2 秒后开始崩溃分析");
					ModMain.Hint("检测到 Minecraft 出现错误，错误分析已开始……", ModMain.HintType.Info, true);
					ModBase.RunInNewThread(delegate
					{
						try
						{
							Thread.Sleep(0x7D0);
							this.WatcherLog("崩溃分析开始");
							ModCrash.CrashAnalyzer crashAnalyzer = new ModCrash.CrashAnalyzer(this._ValueRule);
							crashAnalyzer.Collect(this.registryRule.ManageExpression(), this.m_WriterRule.ToList<string>());
							crashAnalyzer.Prepare();
							crashAnalyzer.Analyze(this.registryRule);
							crashAnalyzer.Output(false, new List<string>
							{
								this.registryRule.Path + this.registryRule.Name + ".json",
								ModBase.Path + "PCL\\Log1.txt",
								ModBase.Path + "PCL\\LatestLaunch.bat"
							});
						}
						catch (Exception ex)
						{
							ModBase.Log(ex, "崩溃分析失败", ModBase.LogLevel.Feedback, "出现错误");
						}
					}, "Crash Analyzer", ThreadPriority.Normal);
				}
			}

			// Token: 0x060002AE RID: 686 RVA: 0x0001AC70 File Offset: 0x00018E70
			public void Kill()
			{
				this.State = ModWatcher.Watcher.MinecraftState.Ended;
				this.WatcherLog("尝试强制结束 Minecraft 进程");
				try
				{
					if (!this.comparatorRule.HasExited)
					{
						this.comparatorRule.Kill();
					}
					this.WatcherLog("已强制结束 Minecraft 进程");
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "强制结束 Minecraft 进程失败", ModBase.LogLevel.Hint, "出现错误");
				}
			}

			// Token: 0x0400014B RID: 331
			public Process comparatorRule;

			// Token: 0x0400014C RID: 332
			public ModMinecraft.McVersion registryRule;

			// Token: 0x0400014D RID: 333
			private string m_AttributeRule;

			// Token: 0x0400014E RID: 334
			private int _ValueRule;

			// Token: 0x0400014F RID: 335
			public ModLoader.LoaderTask<Process, int> _RoleRule;

			// Token: 0x04000150 RID: 336
			private ModWatcher.Watcher.MinecraftState advisorRule;

			// Token: 0x04000151 RID: 337
			public List<string> _StrategyRule;

			// Token: 0x04000152 RID: 338
			private readonly object m_WrapperRule;

			// Token: 0x04000153 RID: 339
			public Queue<string> m_WriterRule;

			// Token: 0x04000154 RID: 340
			private int _ExporterRule;

			// Token: 0x04000155 RID: 341
			private bool recordRule;

			// Token: 0x04000156 RID: 342
			private bool m_GetterRule;

			// Token: 0x04000157 RID: 343
			private IntPtr interceptorRule;

			// Token: 0x04000158 RID: 344
			private List<IntPtr> _InvocationRule;

			// Token: 0x02000062 RID: 98
			public enum MinecraftState
			{
				// Token: 0x0400015A RID: 346
				Loading,
				// Token: 0x0400015B RID: 347
				Running,
				// Token: 0x0400015C RID: 348
				Crashed,
				// Token: 0x0400015D RID: 349
				Ended
			}

			// Token: 0x02000063 RID: 99
			// (Invoke) Token: 0x060002B3 RID: 691
			private delegate void EnumWindowsSub(IntPtr hwnd, int lParam);
		}
	}
}
