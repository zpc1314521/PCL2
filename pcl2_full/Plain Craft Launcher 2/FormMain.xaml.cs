using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PCL.My;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PCL
{
	// Token: 0x02000185 RID: 389
	[DesignerGenerated]
	public partial class FormMain : Window
	{
		// Token: 0x060010ED RID: 4333 RVA: 0x0000AD9B File Offset: 0x00008F9B
		// Note: this type is marked as 'beforefieldinit'.
		static FormMain()
		{
			FormMain.m_PolicyDecorator = false;
		}

		// Token: 0x060010EE RID: 4334 RVA: 0x00079C04 File Offset: 0x00077E04
		private void ShowUpdateLog(int LastVersion)
		{
			FormMain._Closure$__1-0 CS$<>8__locals1 = new FormMain._Closure$__1-0(CS$<>8__locals1);
			int num = 0;
			int num2 = 0;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			checked
			{
				if (LastVersion < 0xEA)
				{
					list.Add(new KeyValuePair<int, string>(6, "支持拖拽整合包文件到 PCL2 进行快捷安装"));
					list.Add(new KeyValuePair<int, string>(5, "支持安装 1.17 OptiFine + Forge"));
					list.Add(new KeyValuePair<int, string>(5, "Mod 详情页面支持跳转 MCBBS 介绍页"));
					num += 0xA;
					num2 += 0x11;
				}
				if (LastVersion < 0xE8)
				{
					list.Add(new KeyValuePair<int, string>(7, "微软账号支持更换皮肤与披风"));
					list.Add(new KeyValuePair<int, string>(6, "支持显示 Mod 与整合包对应的 MC 版本与 Mod 加载器名称"));
					list.Add(new KeyValuePair<int, string>(5, "使用 Mojang 账号登录将会显示迁移提醒"));
					num += 2;
					num2 += 9;
				}
				if (LastVersion < 0xE6)
				{
					if (LastVersion == 0xE3)
					{
						list.Add(new KeyValuePair<int, string>(6, "联机功能的小优化"));
					}
					list.Add(new KeyValuePair<int, string>(5, "添加 1.18 实验性快照 5 的特供下载，且支持列表的联网更新"));
					list.Add(new KeyValuePair<int, string>(2, "修复 Win7 上使用联机功能导致日志文件极大，占用硬盘空间的 Bug"));
					num += 0xC;
					num2 += 4;
				}
				if (LastVersion < 0xE3)
				{
					list.Add(new KeyValuePair<int, string>(9, "新增联机功能的早期测试版本"));
					num += 2;
					num2 += 2;
				}
				if (LastVersion < 0xE1)
				{
					list.Add(new KeyValuePair<int, string>(6, "支持 1.17.1 Forge、Fabric 的安装与启动"));
					list.Add(new KeyValuePair<int, string>(4, "优化 Forge 下载与安装速度，提高安装稳定性"));
					list.Add(new KeyValuePair<int, string>(4, "更新内置帮助库，添加数个指南页面与整合包、存档的安装教程"));
					list.Add(new KeyValuePair<int, string>(3, "支持将游戏文件夹压缩包作为游戏整合包导入"));
					num += 0xC;
					num2 += 0xD;
				}
				if (LastVersion < 0xDF)
				{
					num2 += 4;
				}
				if (LastVersion < 0xDE)
				{
					list.Add(new KeyValuePair<int, string>(4, "更新内置帮助库，添加光影、数据包、Mod 的安装教程"));
					list.Add(new KeyValuePair<int, string>(4, "游戏崩溃分析优化"));
					list.Add(new KeyValuePair<int, string>(2, "修复登录微软账号启动游戏时报错的 Bug"));
					num += 8;
					num2 += 0xB;
				}
				if (LastVersion < 0xDD)
				{
					list.Add(new KeyValuePair<int, string>(6, "界面与动画综合优化，重新制作主题配色"));
					list.Add(new KeyValuePair<int, string>(4, "若识别码不变，更新密钥在输入一次后会一直有效"));
					list.Add(new KeyValuePair<int, string>(4, "若设置为自动更新，PCL2 会在关闭时才替换文件"));
					num += 0xA;
					num2 += 5;
				}
				if (LastVersion < 0xDC)
				{
					list.Add(new KeyValuePair<int, string>(4, "追加大量千万████的可能性"));
					num += 0xF;
				}
				if (LastVersion < 0xDB)
				{
					list.Add(new KeyValuePair<int, string>(2, "修复无法使用 Mod、整合包搜索功能的 Bug"));
					num2 += 2;
				}
				if (LastVersion < 0xDA)
				{
					list.Add(new KeyValuePair<int, string>(6, "允许为不同版本独立设置 Java"));
					num2 += 0xC;
				}
				if (LastVersion < 0xD8)
				{
					list.Add(new KeyValuePair<int, string>(7, "可以根据游戏版本自动选择所需的 Java"));
					list.Add(new KeyValuePair<int, string>(6, "允许在 Java 版本检测不通过时强制指定使用 Java"));
					list.Add(new KeyValuePair<int, string>(5, "Java 选择与搜索的综合优化"));
					num += 8;
					num2 += 7;
				}
				if (LastVersion < 0xD7)
				{
					if (LastVersion == 0xD5)
					{
						list.Add(new KeyValuePair<int, string>(1, "修复账号切换、版本选择下拉框无法展开的严重 Bug"));
					}
					if (LastVersion == 0xD5)
					{
						list.Add(new KeyValuePair<int, string>(1, "修复误判部分客户端需要 Java 16，导致无法启动游戏的严重 Bug"));
					}
					list.Add(new KeyValuePair<int, string>(1, "修复 Windows 7 可能无法登录微软账号的严重 Bug"));
					num2++;
				}
				if (LastVersion < 0xD5)
				{
					list.Add(new KeyValuePair<int, string>(6, "添加一键关闭所有运行中的 Minecraft 的按钮"));
					list.Add(new KeyValuePair<int, string>(5, "增加对 MC 1.17 需要 Java 16 的检测与说明"));
					list.Add(new KeyValuePair<int, string>(4, "Minecraft 崩溃分析优化"));
					list.Add(new KeyValuePair<int, string>(1, "修复网络不稳定时安装整合包极易失败的严重 Bug"));
					num += 0xA;
					num2 += 0xC;
				}
				if (LastVersion < 0xD3)
				{
					list.Add(new KeyValuePair<int, string>(3, "适配适用于快照版 MC 的 OptiFine"));
					list.Add(new KeyValuePair<int, string>(2, "修复进入 OptiFine 下载页面导致卡死的严重 Bug"));
					num2 += 3;
				}
				if (LastVersion < 0xD2)
				{
					list.Add(new KeyValuePair<int, string>(3, "优化多个报错提示，更加人性化"));
					list.Add(new KeyValuePair<int, string>(2, "修复无法单独安装 OptiFine 的严重 Bug"));
					if (LastVersion == 0xD1)
					{
						list.Add(new KeyValuePair<int, string>(2, "修复无法安装部分 CurseForge 整合包的严重 Bug"));
					}
					num += 2;
					num2 += 7;
				}
				if (LastVersion < 0xD1)
				{
					list.Add(new KeyValuePair<int, string>(6, "支持安装 MCBBS 格式的整合包"));
					list.Add(new KeyValuePair<int, string>(4, "优化 CurseForge 搜索"));
					num += 7;
					num2 += 6;
				}
				if (LastVersion < 0xD0)
				{
					list.Add(new KeyValuePair<int, string>(4, "优化帮助页面功能与图标，完善帮助库"));
					list.Add(new KeyValuePair<int, string>(1, "修复无法启动部分 OptiFine+Forge 版本的 Bug"));
					num += 2;
					num2 += 0x10;
				}
				if (LastVersion < 0xCF)
				{
					if (LastVersion == 0xCE)
					{
						list.Add(new KeyValuePair<int, string>(4, "帮助库与帮助页面完善，添加数个页面"));
					}
					list.Add(new KeyValuePair<int, string>(5, "同时安装 OptiFine 与 Forge 时，OptiFine 将作为 Mod 安装"));
					list.Add(new KeyValuePair<int, string>(4, "活跃橙能够通过完善 PCL2 帮助库解锁了"));
					num += 5;
					num2 += 9;
				}
				if (LastVersion < 0xCE)
				{
					list.Add(new KeyValuePair<int, string>(9, "添加帮助页面，且可以自行添加、删除其中的内容"));
					list.Add(new KeyValuePair<int, string>(5, "自定义主页/帮助页面的 XAML 功能扩展"));
					num += 4;
					num2 += 2;
				}
				if (LastVersion < 0xCC)
				{
					list.Add(new KeyValuePair<int, string>(4, "优化启动器更新"));
					if (LastVersion == 0xCB)
					{
						list.Add(new KeyValuePair<int, string>(1, "修复无法导出错误报告的 Bug"));
					}
					num += 6;
					num2 += 5;
				}
				if (LastVersion < 0xCB)
				{
					list.Add(new KeyValuePair<int, string>(9, "游戏崩溃后，PCL2 会自动进行分析，并给出原因与处理建议"));
					list.Add(new KeyValuePair<int, string>(6, "可以将已有的错误报告或崩溃日志拖入 PCL2 的窗口内进行分析"));
					list.Add(new KeyValuePair<int, string>(5, "允许修改或删除已经提交的反馈"));
					num += 4;
					num2 += 3;
				}
				if (LastVersion < 0xCA)
				{
					list.Add(new KeyValuePair<int, string>(8, "重制背景音乐播放，暂停与下一曲现在通过右下角的按钮控制"));
					list.Add(new KeyValuePair<int, string>(6, "可以在设置页面手动检查更新了"));
					list.Add(new KeyValuePair<int, string>(4, "微软登录相关优化"));
					num += 9;
					num2 += 0xD;
				}
				List<string> list2 = new List<string>();
				List<KeyValuePair<int, string>> list3 = ModBase.Sort<KeyValuePair<int, string>>(list, (FormMain._Closure$__.$IR1-1 == null) ? (FormMain._Closure$__.$IR1-1 = ((object a0, object a1) => ((FormMain._Closure$__.$I1-0 == null) ? (FormMain._Closure$__.$I1-0 = ((KeyValuePair<int, string> Left, KeyValuePair<int, string> Right) => Left.Key > Right.Key)) : FormMain._Closure$__.$I1-0)((a0 != null) ? ((KeyValuePair<int, string>)a0) : default(KeyValuePair<int, string>), (a1 != null) ? ((KeyValuePair<int, string>)a1) : default(KeyValuePair<int, string>)))) : FormMain._Closure$__.$IR1-1);
				if (list3.Count == 0 && num == 0 && num2 == 0)
				{
					list2.Add("龙猫忘记写更新日志啦！可以去提醒他一下……");
				}
				int num3 = Math.Min(9, list3.Count - 1);
				for (int i = 0; i <= num3; i++)
				{
					list2.Add(list3[i].Value);
				}
				if (list3.Count > 0xA)
				{
					num += list3.Count - 0xA;
				}
				if (num > 0 || num2 > 0)
				{
					list2.Add(((num > 0) ? ("其他 " + Conversions.ToString(num) + " 项小调整与修改") : "") + ((num <= 0 || num2 <= 0) ? "" : "，") + ((num2 > 0) ? ("修复了 " + Conversions.ToString(num2) + " 个 Bug") : "") + "，详见完整更新日志");
				}
				CS$<>8__locals1.$VB$Local_Content = "· " + ModBase.Join(list2, "\r\n· ");
				ModBase.RunInNewThread(delegate
				{
					if (ModMain.MyMsgBox(CS$<>8__locals1.$VB$Local_Content, "PCL2 已更新至 Snapshot 2.2.3", "确定", "完整更新日志", "", false, true, false) == 2)
					{
						ModBase.OpenWebsite("https://afdian.net/@LTCat?tab=feed");
					}
				}, "UpdateLog Output", ThreadPriority.Normal);
			}
		}

		// Token: 0x060010EF RID: 4335 RVA: 0x0007A2A8 File Offset: 0x000784A8
		public FormMain()
		{
			base.Loaded += this.FormMain_Loaded;
			base.Closing += this.FormMain_Closing;
			base.SizeChanged += delegate(object sender, SizeChangedEventArgs e)
			{
				this.FormMain_SizeChanged();
			};
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.FormMain_SizeChanged();
			};
			base.KeyDown += this.FormMain_KeyDown;
			base.MouseDown += this.FormMain_MouseDown;
			base.Activated += delegate(object sender, EventArgs e)
			{
				this.FormMain_Activated();
			};
			base.PreviewDragOver += this.FrmMain_PreviewDragOver;
			base.PreviewDrop += this.FrmMain_Drop;
			base.MouseMove += this.FormMain_MouseMove;
			this._IdentifierDecorator = false;
			this.m_ClientDecorator = false;
			this.m_MapDecorator = false;
			this._ComposerDecorator = false;
			this.publisherDecorator = FormMain.PageType.Launch;
			this.m_MessageDecorator = new List<FormMain.PageStackData>();
			this._FactoryFilter = null;
			ModBase.decoratorRule = ModBase.GetTimeTick();
			ModMain.m_GetterFilter = this;
			ModMain.m_InvocationFilter = new PageLaunchLeft();
			ModMain.m_CandidateFilter = new PageLaunchRight();
			int num = Conversions.ToInteger(ModBase._BaseRule.Get("SystemLastVersionReg", null));
			if (num < 0xEA)
			{
				this.UpgradeSub(num);
			}
			else if (num > 0xEA)
			{
				this.DowngradeSub(num);
			}
			ModMain.ForgotIterator(false);
			ModBase._BaseRule.Load("UiLauncherTheme", false, null);
			this.InitializeComponent();
			base.Opacity = 0.0;
			if (!Information.IsNothing(ModMain.m_InvocationFilter.Parent))
			{
				ModMain.m_InvocationFilter.SetValue(ContentPresenter.ContentProperty, null);
			}
			if (!Information.IsNothing(ModMain.m_CandidateFilter.Parent))
			{
				ModMain.m_CandidateFilter.SetValue(ContentPresenter.ContentProperty, null);
			}
			this.PanMainLeft.Child = ModMain.m_InvocationFilter;
			this.PanMainRight.Child = ModMain.m_CandidateFilter;
			if (ModBase.errorRule)
			{
				ModMain.Hint("[调试模式] PCL 正以调试模式运行，这可能会造成性能的下降，若无必要请不要开启！", ModMain.HintType.Info, true);
			}
			ModMinecraft._TestsIterator.Start(0, false);
			ModBase.Log("[Start] 第二阶段加载用时：" + Conversions.ToString(checked(ModBase.GetTimeTick() - ModBase.decoratorRule)) + " ms", ModBase.LogLevel.Normal, "出现错误");
		}

		// Token: 0x060010F0 RID: 4336 RVA: 0x0007A4DC File Offset: 0x000786DC
		private void FormMain_Loaded(object sender, RoutedEventArgs e)
		{
			ModBase.decoratorRule = ModBase.GetTimeTick();
			ModBase.m_IteratorRule = new WindowInteropHelper(this).Handle;
			ModBase._BaseRule.Load("UiBackgroundOpacity", false, null);
			ModBase._BaseRule.Load("UiBackgroundBlur", false, null);
			ModBase._BaseRule.Load("UiLogoType", false, null);
			ModBase._BaseRule.Load("UiHiddenPageDownload", false, null);
			ModMain.BackgroundRefresh(false, true);
			ModMusic.MusicRefreshPlay(false, true);
			ModMinecraft.JavaListInit();
			this.BtnExtraDownload._Event = new MyExtraButton.ShowCheckDelegate(this.BtnExtraDownload_ShowCheck);
			this.BtnExtraBack._Event = new MyExtraButton.ShowCheckDelegate(this.BtnExtraBack_ShowCheck);
			this.BtnExtraApril._Event = new MyExtraButton.ShowCheckDelegate(this.BtnExtraApril_ShowCheck);
			this.BtnExtraShutdown._Event = new MyExtraButton.ShowCheckDelegate(this.BtnExtraShutdown_ShowCheck);
			this.BtnExtraApril.ShowRefresh();
			MyResizer myResizer = new MyResizer(this);
			myResizer.addResizerDown(this.ResizerB);
			myResizer.addResizerLeft(this.ResizerL);
			myResizer.addResizerLeftDown(this.ResizerLB);
			myResizer.addResizerLeftUp(this.ResizerLT);
			myResizer.addResizerRight(this.ResizerR);
			myResizer.addResizerRightDown(this.ResizerRB);
			myResizer.addResizerRightUp(this.ResizerRT);
			myResizer.addResizerUp(this.ResizerT);
			if (ModBase.RandomInteger(1, 0x3E8) == 0x17)
			{
				this.ShapeTitleLogo.Data = (Geometry)new GeometryConverter().ConvertFromString("M26,29 v-25 h5 a7,7 180 0 1 0,14 h-5 M80,6.5 a10,11.5 180 1 0 0,18   M47,2.5 v24.5 h12   M98,2 v27   M107,2 v27");
			}
			ModMain.CloneIterator();
			base.Height = Conversions.ToDouble(ModBase.ReadReg("WindowHeight", Conversions.ToString(base.MinHeight + 50.0)));
			base.Width = Conversions.ToDouble(ModBase.ReadReg("WindowWidth", Conversions.ToString(base.MinWidth + 50.0)));
			base.Topmost = false;
			if (ModMain.m_InterceptorFilter != null)
			{
				ModMain.m_InterceptorFilter.Close(new TimeSpan(0, 0, 0, 0, checked((int)Math.Round(400.0 / ModAni._Parameter))));
			}
			base.Top = (ModBase.smethod_4((double)MyWpfExtension.RunFactory().Screen.WorkingArea.Height) - base.Height) / 2.0;
			base.Left = (ModBase.smethod_4((double)MyWpfExtension.RunFactory().Screen.WorkingArea.Width) - base.Width) / 2.0;
			this.m_ClientDecorator = true;
			this.ShowWindowToTop();
			((HwndSource)PresentationSource.FromVisual(this)).AddHook(new HwndSourceHook(this.WndProc));
			checked
			{
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaOpacity(this, Conversions.ToDouble(Operators.AddObject(Operators.DivideObject(ModBase._BaseRule.Get("UiLauncherTransparent", null), 0x3E8), 0.4)), 0x15E, 0, null, false),
					ModAni.AaScaleTransform(this.PanBack, 0.05, 0x15E, 0, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Middle), false),
					ModAni.AaCode(delegate
					{
						ModAni.ListFactory(ModAni.InsertFactory() - 1);
						this.PanBack.RenderTransform = null;
						this._IdentifierDecorator = true;
						ModBase.Log(string.Concat(new string[]
						{
							"[System] DPI：",
							Conversions.ToString(ModBase._BridgeRule),
							"，工作区尺寸：",
							Conversions.ToString(MyWpfExtension.RunFactory().Screen.WorkingArea.Width),
							" x ",
							Conversions.ToString(MyWpfExtension.RunFactory().Screen.WorkingArea.Height),
							"，系统版本：",
							ModBase._ParamsRule.ToString()
						}), ModBase.LogLevel.Normal, "出现错误");
					}, 0, true)
				}, "Form Show", false);
				ModAni.AniStartRun();
				ModMain.TimerMainStartRun();
				ModBase.RunInNewThread(delegate
				{
					if (Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("SystemEula", null))))
					{
						for (;;)
						{
							switch (ModMain.MyMsgBox("在使用 PCL2 前，请同意 PCL2 的用户协议与免责声明。", "协议授权", "同意", "拒绝", "打开用户协议与免责声明页面", false, true, false))
							{
							case 1:
								goto IL_60;
							case 2:
								goto IL_79;
							case 3:
								ModBase.OpenWebsite("https://shimo.im/docs/rGrd8pY8xWkt6ryW");
								continue;
							}
							break;
						}
						goto IL_80;
						IL_60:
						ModBase._BaseRule.Set("SystemEula", true, false, null);
						goto IL_80;
						IL_79:
						this.EndProgram(false);
					}
					IL_80:
					try
					{
						Thread.Sleep(0x1F4);
						if (Conversions.ToBoolean(ModBase._BaseRule.Get("SystemDebugDelay", null)))
						{
							Thread.Sleep(ModBase.RandomInteger(0x1F4, 0xBB8));
						}
						if (Conversions.ToBoolean(ModBase._BaseRule.Get("LinkAuto", null)))
						{
							PageLinkRight.Init();
						}
						if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase._BaseRule.Get("HintFeedback", null), "", true))))
						{
							ModMain.connectionFilter.Start(1, false);
						}
						ModDownload.m_MapperIterator.Start(1, false);
						this.RunCountSub();
						ModMain.identifierFilter.Start(1, false);
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "初始化加载池运行失败", ModBase.LogLevel.Feedback, "出现错误");
					}
					try
					{
						if (File.Exists(ModBase.Path + "PCL\\Plain Craft Launcher 2.exe"))
						{
							File.Delete(ModBase.Path + "PCL\\Plain Craft Launcher 2.exe");
						}
					}
					catch (Exception ex2)
					{
						ModBase.Log(ex2, "清理自动更新文件失败", ModBase.LogLevel.Debug, "出现错误");
					}
				}, "Start Loader", ThreadPriority.Lowest);
				ModBase.Log("[Start] 第三阶段加载用时：" + Conversions.ToString(ModBase.GetTimeTick() - ModBase.decoratorRule) + " ms", ModBase.LogLevel.Normal, "出现错误");
			}
		}

		// Token: 0x060010F1 RID: 4337 RVA: 0x0007A864 File Offset: 0x00078A64
		private void RunCountSub()
		{
			ModBase._BaseRule.Set("SystemCount", Operators.AddObject(ModBase._BaseRule.Get("SystemCount", null), 1), false, null);
			if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("SystemCount", null), 1, true))
			{
				ModMain.MyMsgBox("欢迎使用 PCL2 快照版！\r\n快照版包含尚未正式版发布的测试性功能，仅用于赞助者本人尝鲜。所以请不要发给其他人或者用于制作整合包哦！\r\n如果你并非通过赞助或赞助者本人邀请进群获得的本程序，那么可能是有人在违规传播，记得提醒他一下啦。", "快照版使用说明", "确定", "", "", false, true, false);
			}
			if (Operators.ConditionalCompareObjectGreaterEqual(ModBase._BaseRule.Get("SystemCount", null), 0x63, true) && ModMain.ThemeUnlock(6, false, null))
			{
				ModMain.MyMsgBox("你已经使用了 99 次 PCL2 啦，感谢你长期以来的支持！\r\n隐藏主题 铁杆粉 已解锁！", "提示", "确定", "", "", false, true, false);
			}
		}

		// Token: 0x060010F2 RID: 4338 RVA: 0x0007A928 File Offset: 0x00078B28
		private void UpgradeSub(int LastVersionCode)
		{
			ModBase.Log("[Start] 版本号从 " + Conversions.ToString(LastVersionCode) + " 升高到 " + Conversions.ToString(0xEA), ModBase.LogLevel.Normal, "出现错误");
			ModBase._BaseRule.Set("SystemLastVersionReg", 0xEA, false, null);
			int num = Conversions.ToInteger(ModBase._BaseRule.Get("SystemHighestAlphaVersionReg", null));
			if (num < 0xEA)
			{
				ModBase._BaseRule.Set("SystemHighestAlphaVersionReg", 0xEA, false, null);
				ModBase.Log("[Start] 最高版本号从 " + Conversions.ToString(num) + " 升高到 " + Conversions.ToString(0xEA), ModBase.LogLevel.Normal, "出现错误");
			}
			if (num <= 0xCF)
			{
				List<string> list = new List<string>
				{
					"2"
				};
				list.AddRange(new List<string>(ModBase._BaseRule.Get("UiLauncherThemeHide", null).ToString().Split(new char[]
				{
					'|'
				})));
				list.AddRange(new List<string>(ModBase._BaseRule.Get("UiLauncherThemeHide2", null).ToString().Split(new char[]
				{
					'|'
				})));
				ModBase._BaseRule.Set("UiLauncherThemeHide2", ModBase.Join(ModBase.ArrayNoDouble<string>(list, null), "|"), false, null);
			}
			if (LastVersionCode <= 0x73 && ModBase._BaseRule.Get("UiLauncherThemeHide2", null).ToString().Split(new char[]
			{
				'|'
			}).Contains("13"))
			{
				ArrayList arrayList = new ArrayList(ModBase._BaseRule.Get("UiLauncherThemeHide2", null).ToString().Split(new char[]
				{
					'|'
				}));
				arrayList.Remove("13");
				ModBase._BaseRule.Set("UiLauncherThemeHide2", ModBase.Join(arrayList, "|"), false, null);
				ModMain.MyMsgBox("由于新版 PCL2 修改了欧皇彩的解锁方式，你需要重新解锁欧皇彩。\r\n多谢各位的理解啦！", "重新解锁提醒", "确定", "", "", false, true, false);
			}
			if (LastVersionCode <= 0x98 && ModBase._BaseRule.Get("UiLauncherThemeHide2", null).ToString().Split(new char[]
			{
				'|'
			}).Contains("12"))
			{
				ArrayList arrayList2 = new ArrayList(ModBase._BaseRule.Get("UiLauncherThemeHide2", null).ToString().Split(new char[]
				{
					'|'
				}));
				arrayList2.Remove("12");
				ModBase._BaseRule.Set("UiLauncherThemeHide2", ModBase.Join(arrayList2, "|"), false, null);
				ModMain.MyMsgBox("由于新版 PCL2 修改了滑稽彩的解锁方式，你需要重新解锁滑稽彩。\r\n多谢各位的理解啦！", "重新解锁提醒", "确定", "", "", false, true, false);
			}
			if (LastVersionCode <= 0xA1 && File.Exists(ModBase.Path + "PCL\\CustomSkin.png") && !File.Exists(ModBase.m_GlobalRule + "CustomSkin.png"))
			{
				File.Copy(ModBase.Path + "PCL\\CustomSkin.png", ModBase.m_GlobalRule + "CustomSkin.png");
				ModBase.Log("[Start] 已移动离线自定义皮肤", ModBase.LogLevel.Normal, "出现错误");
			}
			if (LastVersionCode <= 0xCD)
			{
				ModBase._BaseRule.Set("UiHiddenOtherHelp", false, false, null);
				ModBase.Log("[Start] 已解除帮助页面的隐藏", ModBase.LogLevel.Normal, "出现错误");
			}
			if (LastVersionCode != 0 && num < 0xEA)
			{
				this.ShowUpdateLog(num);
			}
		}

		// Token: 0x060010F3 RID: 4339 RVA: 0x0007AC80 File Offset: 0x00078E80
		private void DowngradeSub(int LastVersionCode)
		{
			ModBase.Log("[Start] 版本号从 " + Conversions.ToString(LastVersionCode) + " 降低到 " + Conversions.ToString(0xEA), ModBase.LogLevel.Normal, "出现错误");
			ModBase._BaseRule.Set("SystemLastVersionReg", 0xEA, false, null);
		}

		// Token: 0x060010F4 RID: 4340 RVA: 0x0000ADA3 File Offset: 0x00008FA3
		private void FormMain_Closing(object sender, CancelEventArgs e)
		{
			this.EndProgram(true);
			e.Cancel = true;
		}

		// Token: 0x060010F5 RID: 4341 RVA: 0x0007ACD4 File Offset: 0x00078ED4
		public void EndProgram(bool SendWarning)
		{
			if (SendWarning && ModNet.HasDownloadingTask(false))
			{
				if (ModMain.MyMsgBox("还有下载任务尚未完成，是否确定退出？", "提示", "确定", "取消", "", false, true, false) != 1)
				{
					return;
				}
				ModBase.RunInNewThread((FormMain._Closure$__.$I9-0 == null) ? (FormMain._Closure$__.$I9-0 = delegate()
				{
					ModBase.Log("[System] 正在强行停止任务", ModBase.LogLevel.Normal, "出现错误");
					try
					{
						foreach (object obj in ((IEnumerable)ModLoader.LoaderTaskbar.Clone()))
						{
							((ModLoader.LoaderBase<string>)obj).Abort();
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
				}) : FormMain._Closure$__.$I9-0, "强行停止下载任务", ThreadPriority.Normal);
			}
			ModBase.RunInUiWait(delegate()
			{
				base.IsHitTestVisible = false;
				if (this.PanBack.RenderTransform == null)
				{
					this.PanBack.RenderTransform = new ScaleTransform();
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaOpacity(this, -base.Opacity, 0xC8, 0, null, false),
						ModAni.AaScaleTransform(this.PanBack, -0.05, 0xC8, 0, new ModAni.AniEaseInBack(ModAni.AniEasePower.Middle), false),
						ModAni.AaCode(delegate
						{
							base.IsHitTestVisible = false;
							base.Top = -10000.0;
							base.ShowInTaskbar = false;
						}, 0xFA, false),
						ModAni.AaCode((FormMain._Closure$__.$IR9-5 == null) ? (FormMain._Closure$__.$IR9-5 = delegate()
						{
							FormMain.EndProgramForce(ModBase.Result.Success);
						}) : FormMain._Closure$__.$IR9-5, 0x12C, false)
					}, "Form Close", false);
				}
				else
				{
					FormMain.EndProgramForce(ModBase.Result.Success);
				}
				ModBase.Log("[System] 收到关闭指令", ModBase.LogLevel.Normal, "出现错误");
			});
		}

		// Token: 0x060010F6 RID: 4342 RVA: 0x0007AD54 File Offset: 0x00078F54
		public static void EndProgramForce(ModBase.Result ReturnCode = ModBase.Result.Success)
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_00:
				ProjectData.ClearProjectError();
				num = 1;
				IL_07:
				int num2 = 2;
				ModBase._AlgoRule = true;
				IL_0F:
				num2 = 3;
				ModAni.ListFactory(checked(ModAni.InsertFactory() + 1));
				IL_1D:
				num2 = 4;
				PageLinkRight.IoiStop(false);
				IL_26:
				num2 = 5;
				if (!ModMain.m_TokenFilter)
				{
					goto IL_37;
				}
				IL_2F:
				num2 = 6;
				ModMain.UpdateRestart(false);
				IL_37:
				num2 = 7;
				if (ReturnCode != ModBase.Result.Exception)
				{
					goto IL_9A;
				}
				IL_3D:
				num2 = 8;
				if (FormMain.m_PolicyDecorator)
				{
					goto IL_8D;
				}
				IL_46:
				num2 = 9;
				ModBase.FeedbackInfo();
				IL_4E:
				num2 = 0xA;
				ModBase.Log("请在 https://jinshuju.net/f/rP4b6E?x_field_1=crash 提交错误报告，以便于作者解决此问题！", ModBase.LogLevel.Normal, "出现错误");
				IL_61:
				num2 = 0xB;
				FormMain.m_PolicyDecorator = true;
				IL_6A:
				num2 = 0xC;
				ModBase.ShellAndGetExitCode(ModBase.Path + "PCL\\Log1.txt", "", false, 0xF4240);
				IL_8D:
				num2 = 0xD;
				Thread.Sleep(0x1F4);
				IL_9A:
				num2 = 0xE;
				ModBase.Log("[System] 程序已退出，返回值：" + ModBase.GetStringFromEnum(ReturnCode), ModBase.LogLevel.Normal, "出现错误");
				IL_BD:
				num2 = 0xF;
				ModBase.LogFlush();
				IL_C5:
				num2 = 0x10;
				if (ReturnCode != ModBase.Result.Success)
				{
					goto IL_DA;
				}
				IL_CB:
				num2 = 0x11;
				Process.GetCurrentProcess().Kill();
				goto IL_E3;
				IL_DA:
				num2 = 0x13;
				Environment.Exit((int)ReturnCode);
				IL_E3:
				goto IL_185;
				IL_E8:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_146:
				goto IL_17A;
				IL_148:
				num4 = num2;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_158:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_148;
			}
			IL_17A:
			throw ProjectData.CreateProjectError(-0x7FF5FFCD);
			IL_185:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x060010F7 RID: 4343 RVA: 0x0000ADB3 File Offset: 0x00008FB3
		private void BtnTitleClose_Click(object sender, RoutedEventArgs e)
		{
			this.EndProgram(true);
		}

		// Token: 0x060010F8 RID: 4344 RVA: 0x0007AF0C File Offset: 0x0007910C
		private void FormDragMove(object sender, MouseButtonEventArgs e)
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_00:
				ProjectData.ClearProjectError();
				num = 1;
				IL_07:
				int num2 = 2;
				if (!Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "IsMouseDirectlyOver", new object[0], null, null, null)))
				{
					goto IL_2D;
				}
				IL_25:
				num2 = 3;
				base.DragMove();
				IL_2D:
				goto IL_8C;
				IL_2F:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_4D:
				goto IL_81;
				IL_4F:
				num4 = num2;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_5F:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_4F;
			}
			IL_81:
			throw ProjectData.CreateProjectError(-0x7FF5FFCD);
			IL_8C:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x060010F9 RID: 4345 RVA: 0x0007AFC0 File Offset: 0x000791C0
		private void FormMain_SizeChanged()
		{
			if (this.m_ClientDecorator)
			{
				ModBase.WriteReg("WindowHeight", Conversions.ToString(base.Height), false);
				ModBase.WriteReg("WindowWidth", Conversions.ToString(base.Width), false);
			}
			this.RectForm.Rect = new Rect(0.0, 0.0, this.BorderForm.ActualWidth, this.BorderForm.ActualHeight);
			this.PanForm.Width = this.BorderForm.ActualWidth + 0.001;
			this.PanForm.Height = this.BorderForm.ActualHeight + 0.001;
			this.PanMain.Width = this.PanForm.Width;
			this.PanMain.Height = Math.Max(0.0, this.PanForm.Height - this.PanTitle.ActualHeight);
		}

		// Token: 0x060010FA RID: 4346 RVA: 0x0000ADBC File Offset: 0x00008FBC
		private void BtnTitleMin_Click()
		{
			base.WindowState = WindowState.Minimized;
		}

		// Token: 0x060010FB RID: 4347 RVA: 0x0007B0C0 File Offset: 0x000792C0
		private void FormMain_KeyDown(object sender, KeyEventArgs e)
		{
			if (!e.IsRepeat)
			{
				if (e.Key == Key.Return && this.PanMsg.Children.Count > 0)
				{
					NewLateBinding.LateCall(this.PanMsg.Children[0], null, "Btn1_Click", new object[0], null, null, null, true);
					return;
				}
				if (e.Key == Key.F11 && this.publisherDecorator == FormMain.PageType.VersionSelect)
				{
					ModMain.contextFilter.objectExpression = !ModMain.contextFilter.objectExpression;
					ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", false);
					return;
				}
				if (e.Key == Key.F12)
				{
					PageSetupUI.ConnectModel(!PageSetupUI.WriteModel());
					if (PageSetupUI.WriteModel())
					{
						ModMain.Hint("功能隐藏设置已暂时关闭！", ModMain.HintType.Finish, true);
					}
					else
					{
						ModMain.Hint("功能隐藏设置已重新开启！", ModMain.HintType.Finish, true);
					}
					PageSetupUI.HiddenRefresh();
					return;
				}
				if (e.Key == Key.Return && this.publisherDecorator == FormMain.PageType.Launch)
				{
					if (ModMain.policyFilter && !ModMain.m_ClientFilter)
					{
						ModMain.Hint("木大！", ModMain.HintType.Info, true);
					}
					else
					{
						ModMain.m_InvocationFilter.LaunchButtonClick("");
					}
				}
				if (e.SystemKey == Key.LeftAlt || e.SystemKey == Key.RightAlt)
				{
					e.Handled = true;
				}
			}
		}

		// Token: 0x060010FC RID: 4348 RVA: 0x0007B20C File Offset: 0x0007940C
		private void FormMain_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.XButton1 || e.ChangedButton == MouseButton.XButton2)
			{
				if (this.publisherDecorator == FormMain.PageType.Download && this.IncludeIterator() == FormMain.PageSubType.DownloadInstall)
				{
					ModMain.propertyFilter.ExitSelectPage();
					return;
				}
				this.PageBack();
			}
		}

		// Token: 0x060010FD RID: 4349 RVA: 0x0007B258 File Offset: 0x00079458
		private void FormMain_Activated()
		{
			try
			{
				if (this.publisherDecorator == FormMain.PageType.VersionSetup && this.IncludeIterator() == FormMain.PageSubType.SetupSystem)
				{
					if (ModMain.m_RulesFilter != null)
					{
						ModMain.m_RulesFilter.RefreshList(false);
					}
					else if (PageVersionLeft.m_OrderModel != null)
					{
						ModLoader.LoaderFolderRun(PageVersionMod.callbackModel, PageVersionLeft.m_OrderModel.ManageExpression() + "mods\\", ModLoader.LoaderFolderRunType.RunOnUpdated, 0, "", false);
					}
				}
				else if (this.publisherDecorator == FormMain.PageType.VersionSelect)
				{
					ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.RunOnUpdated, 1, "versions\\", false);
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "切回窗口时出错", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x060010FE RID: 4350 RVA: 0x0000ADC5 File Offset: 0x00008FC5
		private void FrmMain_PreviewDragOver(object sender, DragEventArgs e)
		{
			if (e.Data.GetFormats().Contains("FileDrop"))
			{
				e.Effects = DragDropEffects.Link;
				return;
			}
			e.Effects = DragDropEffects.None;
		}

		// Token: 0x060010FF RID: 4351 RVA: 0x0007B324 File Offset: 0x00079524
		private void FrmMain_Drop(object sender, DragEventArgs e)
		{
			try
			{
				List<string> list = new List<string>();
				try
				{
					list.AddRange((IEnumerable<string>)((Array)e.Data.GetData(DataFormats.FileDrop)));
					if (list.Count == 0)
					{
						return;
					}
					e.Handled = true;
					if (list.Count > 1)
					{
						ModMain.Hint("一次请只拖入一个文件！", ModMain.HintType.Critical, true);
						return;
					}
					if (Directory.Exists(list.First<string>()) && !File.Exists(list.First<string>()))
					{
						ModMain.Hint("请拖入一个文件，而非文件夹！", ModMain.HintType.Critical, true);
						return;
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "无法接取拖拽事件", ModBase.LogLevel.Developer, "出现错误");
					return;
				}
				string FilePath = list.First<string>();
				ModBase.Log("[System] 接受文件拖拽：" + FilePath, ModBase.LogLevel.Developer, "出现错误");
				ModBase.RunInNewThread(delegate
				{
					if (Operators.CompareString(FilePath.Split(new char[]
					{
						'.'
					}).Last<string>().ToLower(), "zip", true) == 0)
					{
						ModBase.Log("[System] 文件为 zip 压缩包，尝试作为整合包安装", ModBase.LogLevel.Normal, "出现错误");
						if (Conversions.ToBoolean(PageSelectLeft.StartInstall(FilePath, null, false)))
						{
							return;
						}
					}
					try
					{
						ModBase.Log("[System] 尝试进行错误报告分析", ModBase.LogLevel.Normal, "出现错误");
						ModCrash.CrashAnalyzer crashAnalyzer = new ModCrash.CrashAnalyzer(ModBase.GetUuid());
						crashAnalyzer.Import(FilePath);
						if (crashAnalyzer.Prepare() != 0)
						{
							crashAnalyzer.Analyze(null);
							crashAnalyzer.Output(true, new List<string>());
							return;
						}
					}
					catch (Exception ex3)
					{
						ModBase.Log(ex3, "自主错误报告分析失败", ModBase.LogLevel.Feedback, "出现错误");
					}
					ModMain.Hint("PCL2 无法确定应当执行的文件拖拽操作……", ModMain.HintType.Info, true);
				}, "文件拖拽", ThreadPriority.Normal);
			}
			catch (Exception ex2)
			{
				ModBase.Log(ex2, "接取拖拽事件失败", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x06001100 RID: 4352 RVA: 0x0007B454 File Offset: 0x00079654
		private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			if (msg == 0x1E)
			{
				DateTime now = DateTime.Now;
				if (DateTime.Compare(now.Date, ModBase._FilterRule.Date) == 0)
				{
					ModBase.Log("[System] 系统时间微调为：" + now.ToLongDateString() + " " + now.ToLongTimeString(), ModBase.LogLevel.Normal, "出现错误");
					this.m_MapDecorator = false;
				}
				else
				{
					ModBase.Log("[System] 系统时间修改为：" + now.ToLongDateString() + " " + now.ToLongTimeString(), ModBase.LogLevel.Normal, "出现错误");
					this.m_MapDecorator = true;
				}
			}
			else if (msg == 0x1902)
			{
				ModBase.Log("[System] 收到置顶信息：" + Conversions.ToString(hwnd.ToInt64()), ModBase.LogLevel.Normal, "出现错误");
				if (!this._IdentifierDecorator)
				{
					ModBase.Log("[System] 窗口尚未加载完成，忽略置顶请求", ModBase.LogLevel.Normal, "出现错误");
					return IntPtr.Zero;
				}
				this.ShowWindowToTop();
				handled = true;
			}
			return IntPtr.Zero;
		}

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06001101 RID: 4353 RVA: 0x0000ADED File Offset: 0x00008FED
		// (set) Token: 0x06001102 RID: 4354 RVA: 0x0007B548 File Offset: 0x00079748
		public bool Hidden
		{
			get
			{
				return this._ComposerDecorator;
			}
			set
			{
				if (this._ComposerDecorator != value)
				{
					this._ComposerDecorator = value;
					if (value)
					{
						base.Left -= 10000.0;
						base.ShowInTaskbar = false;
						base.Visibility = Visibility.Hidden;
						ModBase.Log(string.Concat(new string[]
						{
							"[System] 窗口已隐藏，位置：(",
							Conversions.ToString(base.Left),
							",",
							Conversions.ToString(base.Top),
							")"
						}), ModBase.LogLevel.Normal, "出现错误");
						return;
					}
					if (base.Left < -2000.0)
					{
						base.Left += 10000.0;
					}
					this.ShowWindowToTop();
				}
			}
		}

		// Token: 0x06001103 RID: 4355 RVA: 0x0000ADF5 File Offset: 0x00008FF5
		public void ShowWindowToTop()
		{
			ModBase.RunInUi(delegate()
			{
				base.Visibility = Visibility.Visible;
				base.ShowInTaskbar = true;
				base.WindowState = WindowState.Normal;
				this.Hidden = false;
				base.Topmost = true;
				base.Topmost = false;
				ModBase.SetForegroundWindow(ModBase.m_IteratorRule);
				base.Focus();
				ModBase.Log(string.Concat(new string[]
				{
					"[System] 窗口已置顶，位置：(",
					Conversions.ToString(base.Left),
					", ",
					Conversions.ToString(base.Top),
					"), ",
					Conversions.ToString(base.Width),
					" x ",
					Conversions.ToString(base.Height)
				}), ModBase.LogLevel.Normal, "出现错误");
			}, false);
		}

		// Token: 0x06001104 RID: 4356 RVA: 0x0007B608 File Offset: 0x00079808
		private string PageNameGet(FormMain.PageStackData Stack)
		{
			string result;
			switch (Stack._FieldMapper)
			{
			case FormMain.PageType.VersionSelect:
				result = "版本选择";
				break;
			case FormMain.PageType.DownloadManager:
				result = "下载管理";
				break;
			case FormMain.PageType.VersionSetup:
				result = "版本设置 - " + ((PageVersionLeft.m_OrderModel == null) ? "未知版本" : PageVersionLeft.m_OrderModel.Name);
				break;
			case FormMain.PageType.CfDetail:
				if (Stack.m_StatusMapper == null)
				{
					ModBase.Log("[Control] CurseForge 工程详情页面未提供关键项", ModBase.LogLevel.Feedback, "出现错误");
					result = "未知页面";
				}
				else
				{
					ModDownload.DlCfProject dlCfProject = (ModDownload.DlCfProject)Stack.m_StatusMapper;
					result = (dlCfProject.m_WrapperAlgo ? "整合包下载 - " : "Mod 下载 - ") + dlCfProject.NewExpression();
				}
				break;
			case FormMain.PageType.HelpDetail:
				if (Stack.m_StatusMapper == null)
				{
					ModBase.Log("[Control] 帮助详情页面未提供关键项", ModBase.LogLevel.Msgbox, "出现错误");
					result = "未知页面";
				}
				else
				{
					result = ((ModMain.HelpEntry)NewLateBinding.LateIndexGet(Stack.m_StatusMapper, new object[]
					{
						0
					}, null)).Title;
				}
				break;
			default:
				result = "";
				break;
			}
			return result;
		}

		// Token: 0x06001105 RID: 4357 RVA: 0x0000AE09 File Offset: 0x00009009
		public void PageNameRefresh(FormMain.PageStackData Type)
		{
			this.LabTitleInner.Text = this.PageNameGet(Type);
		}

		// Token: 0x06001106 RID: 4358 RVA: 0x0000AE1D File Offset: 0x0000901D
		public void PageNameRefresh()
		{
			this.PageNameRefresh(this.publisherDecorator);
		}

		// Token: 0x06001107 RID: 4359 RVA: 0x0007B718 File Offset: 0x00079918
		public FormMain.PageSubType IncludeIterator()
		{
			FormMain.PageStackData left = this.publisherDecorator;
			FormMain.PageSubType result;
			if (left == FormMain.PageType.Download)
			{
				if (ModMain._InitializerFilter == null)
				{
					ModMain._InitializerFilter = new PageDownloadLeft();
				}
				result = ModMain._InitializerFilter.paramsUtils;
			}
			else if (left == FormMain.PageType.Setup)
			{
				if (ModMain.m_TaskFilter == null)
				{
					ModMain.m_TaskFilter = new PageSetupLeft();
				}
				result = ModMain.m_TaskFilter.configurationUtils;
			}
			else if (left == FormMain.PageType.Other)
			{
				if (ModMain._TemplateFilter == null)
				{
					ModMain._TemplateFilter = new PageOtherLeft();
				}
				result = ModMain._TemplateFilter.infoUtils;
			}
			else if (left == FormMain.PageType.VersionSetup)
			{
				if (ModMain.producerFilter == null)
				{
					ModMain.producerFilter = new PageVersionLeft();
				}
				result = ModMain.producerFilter.m_ServiceModel;
			}
			else
			{
				result = FormMain.PageSubType.Default;
			}
			return result;
		}

		// Token: 0x06001108 RID: 4360 RVA: 0x0007B7E4 File Offset: 0x000799E4
		public void PageChange(FormMain.PageStackData Stack, FormMain.PageSubType SubType = FormMain.PageSubType.Default)
		{
			if (Operators.CompareString(this.PageNameGet(Stack), "", true) == 0)
			{
				this.PageChangeExit();
				((MyRadioButton)this.PanTitleSelect.Children[(int)Stack]).SetChecked(true, true, Operators.CompareString(this.PageNameGet(this.publisherDecorator), "", true) == 0);
				switch (Stack._FieldMapper)
				{
				case FormMain.PageType.Download:
					if (ModMain._InitializerFilter == null)
					{
						ModMain._InitializerFilter = new PageDownloadLeft();
					}
					((MyListItem)ModMain._InitializerFilter.PanItem.Children[(int)SubType]).SetChecked(true, true, Stack == this.publisherDecorator);
					break;
				case FormMain.PageType.Link:
					if (ModMain._DispatcherFilter == null)
					{
						ModMain._DispatcherFilter = new PageLinkLeft();
					}
					break;
				case FormMain.PageType.Setup:
					if (ModMain.m_TaskFilter == null)
					{
						ModMain.m_TaskFilter = new PageSetupLeft();
					}
					((MyListItem)ModMain.m_TaskFilter.PanItem.Children[(int)SubType]).SetChecked(true, true, Stack == this.publisherDecorator);
					break;
				case FormMain.PageType.Other:
					if (ModMain._TemplateFilter == null)
					{
						ModMain._TemplateFilter = new PageOtherLeft();
					}
					((MyListItem)ModMain._TemplateFilter.PanItem.Children[(int)SubType]).SetChecked(true, true, Stack == this.publisherDecorator);
					break;
				}
				this.PageChangeActual(Stack, SubType);
				return;
			}
			FormMain.PageType fieldMapper = Stack._FieldMapper;
			if (fieldMapper == FormMain.PageType.VersionSetup)
			{
				if (ModMain.producerFilter == null)
				{
					ModMain.producerFilter = new PageVersionLeft();
				}
				((MyListItem)ModMain.producerFilter.PanItem.Children[(int)SubType]).SetChecked(true, true, Stack == this.publisherDecorator);
			}
			this.PageChangeActual(Stack, SubType);
		}

		// Token: 0x06001109 RID: 4361 RVA: 0x0000AE2B File Offset: 0x0000902B
		private void BtnTitleSelect_Click(MyRadioButton sender, bool raiseByMouse)
		{
			this.PageChangeActual(checked((FormMain.PageType)Math.Round(ModBase.Val(RuntimeHelpers.GetObjectValue(sender.Tag)))), (FormMain.PageSubType)(-1));
		}

		// Token: 0x0600110A RID: 4362 RVA: 0x0000AE4F File Offset: 0x0000904F
		public void PageBack()
		{
			if (this.m_MessageDecorator.Count != 0)
			{
				this.PageChangeActual(this.m_MessageDecorator[0], (FormMain.PageSubType)(-1));
			}
		}

		// Token: 0x0600110B RID: 4363 RVA: 0x0007B9A0 File Offset: 0x00079BA0
		private void PageChangeActual(FormMain.PageStackData Stack, FormMain.PageSubType SubType = (FormMain.PageSubType)(-1))
		{
			if (!(this.publisherDecorator == Stack) || (this.IncludeIterator() != SubType && SubType != (FormMain.PageSubType)(-1)))
			{
				ModAni.ListFactory(checked(ModAni.InsertFactory() + 1));
				try
				{
					FormMain._Closure$__44-0 CS$<>8__locals1 = new FormMain._Closure$__44-0(CS$<>8__locals1);
					CS$<>8__locals1.$VB$Me = this;
					CS$<>8__locals1.$VB$Local_PageName = this.PageNameGet(Stack);
					if (Operators.CompareString(CS$<>8__locals1.$VB$Local_PageName, "", true) == 0)
					{
						this.PageChangeExit();
					}
					else if (this.m_MessageDecorator.Count == 0)
					{
						this.PanTitleInner.Visibility = Visibility.Visible;
						this.PanTitleMain.IsHitTestVisible = false;
						this.PanTitleInner.IsHitTestVisible = true;
						this.PageNameRefresh(Stack);
						ModAni.AniStart(new ModAni.AniData[]
						{
							ModAni.AaOpacity(this.PanTitleMain, -this.PanTitleMain.Opacity, 0x64, 0, null, false),
							ModAni.AaX(this.PanTitleMain, 9.0 - this.PanTitleMain.Margin.Left, 0x64, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
							ModAni.AaOpacity(this.PanTitleInner, 1.0 - this.PanTitleInner.Opacity, 0x96, 0x96, null, false),
							ModAni.AaX(this.PanTitleInner, -this.PanTitleInner.Margin.Left, 0xD2, 0x96, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Middle), false),
							ModAni.AaCode(delegate
							{
								this.PanTitleMain.Visibility = Visibility.Collapsed;
							}, 0, true)
						}, "FrmMain Titlebar FirstLayer", false);
						this.m_MessageDecorator.Insert(0, this.publisherDecorator);
					}
					else
					{
						ModAni.AniStart(new ModAni.AniData[]
						{
							ModAni.AaOpacity(this.LabTitleInner, -this.LabTitleInner.Opacity, 0x64, 0, null, false),
							ModAni.AaCode(delegate
							{
								CS$<>8__locals1.$VB$Me.LabTitleInner.Text = CS$<>8__locals1.$VB$Local_PageName;
							}, 0, true),
							ModAni.AaOpacity(this.LabTitleInner, 1.0, 0x64, 0x28, null, false)
						}, "FrmMain Titlebar SubLayer", false);
						if (this.m_MessageDecorator.Contains(Stack))
						{
							while (this.m_MessageDecorator.Contains(Stack))
							{
								this.m_MessageDecorator.RemoveAt(0);
							}
						}
						else
						{
							this.m_MessageDecorator.Insert(0, this.publisherDecorator);
						}
					}
					switch (Stack._FieldMapper)
					{
					case FormMain.PageType.Launch:
						this.PageChangeAnim(ModMain.m_InvocationFilter, ModMain.m_CandidateFilter);
						break;
					case FormMain.PageType.Download:
						if (ModMain._InitializerFilter == null)
						{
							ModMain._InitializerFilter = new PageDownloadLeft();
						}
						this.PageChangeAnim(ModMain._InitializerFilter, (FrameworkElement)ModMain._InitializerFilter.PageGet(SubType));
						break;
					case FormMain.PageType.Link:
						if (ModMain._DispatcherFilter == null)
						{
							ModMain._DispatcherFilter = new PageLinkLeft();
						}
						if (ModMain._TagFilter == null)
						{
							ModMain._TagFilter = new PageLinkRight();
						}
						this.PageChangeAnim(ModMain._DispatcherFilter, ModMain._TagFilter);
						break;
					case FormMain.PageType.Setup:
						if (ModMain.m_TaskFilter == null)
						{
							ModMain.m_TaskFilter = new PageSetupLeft();
						}
						this.PageChangeAnim(ModMain.m_TaskFilter, (FrameworkElement)ModMain.m_TaskFilter.PageGet(SubType));
						break;
					case FormMain.PageType.Other:
						if (ModMain._TemplateFilter == null)
						{
							ModMain._TemplateFilter = new PageOtherLeft();
						}
						this.PageChangeAnim(ModMain._TemplateFilter, (FrameworkElement)ModMain._TemplateFilter.PageGet(SubType));
						break;
					case FormMain.PageType.VersionSelect:
						if (ModMain.m_DescriptorFilter == null)
						{
							ModMain.m_DescriptorFilter = new PageSelectLeft();
						}
						if (ModMain.contextFilter == null)
						{
							ModMain.contextFilter = new PageSelectRight();
						}
						this.PageChangeAnim(ModMain.m_DescriptorFilter, ModMain.contextFilter);
						break;
					case FormMain.PageType.DownloadManager:
						if (ModMain.observerFilter == null)
						{
							ModMain.observerFilter = new PageSpeedLeft();
						}
						if (ModMain._TokenizerFilter == null)
						{
							ModMain._TokenizerFilter = new PageSpeedRight();
						}
						this.PageChangeAnim(ModMain.observerFilter, ModMain._TokenizerFilter);
						break;
					case FormMain.PageType.VersionSetup:
						if (ModMain.producerFilter == null)
						{
							ModMain.producerFilter = new PageVersionLeft();
						}
						this.PageChangeAnim(ModMain.producerFilter, (FrameworkElement)ModMain.producerFilter.PageGet(SubType));
						break;
					case FormMain.PageType.CfDetail:
						if (ModMain.m_ConfigFilter == null)
						{
							ModMain.m_ConfigFilter = new PageDownloadCfDetail();
						}
						this.PageChangeAnim(new MyPageLeft(), ModMain.m_ConfigFilter);
						break;
					case FormMain.PageType.HelpDetail:
						this.PageChangeAnim(new MyPageLeft(), (FrameworkElement)NewLateBinding.LateIndexGet(Stack.m_StatusMapper, new object[]
						{
							1
						}, null));
						break;
					}
					this.publisherDecorator = Stack;
					this.BtnExtraDownload.ShowRefresh();
					this.BtnExtraApril.ShowRefresh();
					ModBase.Log("[Control] 切换主要页面：" + ModBase.GetStringFromEnum(Stack) + ", " + Conversions.ToString((int)SubType), ModBase.LogLevel.Normal, "出现错误");
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "切换主要页面失败（ID " + Conversions.ToString((int)this.publisherDecorator._FieldMapper) + "）", ModBase.LogLevel.Feedback, "出现错误");
				}
				finally
				{
					ModAni.ListFactory(checked(ModAni.InsertFactory() - 1));
				}
			}
		}

		// Token: 0x0600110C RID: 4364 RVA: 0x0007BECC File Offset: 0x0007A0CC
		private void PageChangeAnim(FrameworkElement TargetLeft, FrameworkElement TargetRight)
		{
			ModAni.AniStop("FrmMain LeftChange");
			ModAni.AniStop("FrmMain PageChange");
			checked
			{
				ModAni.ListFactory(ModAni.InsertFactory() + 1);
				this.PanMainLeft.Width = this.PanMainLeft.ActualWidth;
				ModBase.ControlFreeze(this.PanMainRight);
				if (!Information.IsNothing(TargetLeft.Parent))
				{
					TargetLeft.SetValue(ContentPresenter.ContentProperty, null);
				}
				if (!Information.IsNothing(TargetRight) && !Information.IsNothing(TargetRight.Parent))
				{
					TargetRight.SetValue(ContentPresenter.ContentProperty, null);
				}
				this._TokenDecorator = (MyPageLeft)TargetLeft;
				this.m_ProcDecorator = TargetRight;
				((MyPageLeft)this.PanMainLeft.Child).TriggerHideAnimation();
				ModAni.ListFactory(ModAni.InsertFactory() - 1);
				base.Dispatcher.Invoke(delegate()
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaOpacity(this.PanMainRight, unchecked(-this.PanMainRight.Opacity), 0x82, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false),
						ModAni.AaCode(delegate
						{
							ModAni.ListFactory(ModAni.InsertFactory() + 1);
							this.PanMainLeft.Width = double.NaN;
							this.PanMainLeft.Child = this._TokenDecorator;
							this._TokenDecorator.TriggerShowAnimation();
							this.PanMainLeft.Background = null;
							this.PanMainRight.Child = this.m_ProcDecorator;
							this.PanMainRight.Background = null;
							ModAni.ListFactory(ModAni.InsertFactory() - 1);
							ModBase.RunInUi(delegate()
							{
								this.PanMainLeft_Resize(this.PanMainLeft.ActualWidth);
								this.BtnExtraBack.ShowRefresh();
							}, true);
						}, 0, true),
						ModAni.AaOpacity(this.PanMainRight, 1.0, 0xC8, 0x28, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false)
					}, "FrmMain PageChange", false);
				});
			}
		}

		// Token: 0x0600110D RID: 4365 RVA: 0x0007BFA0 File Offset: 0x0007A1A0
		private void PageChangeExit()
		{
			if (this.m_MessageDecorator.Count != 0)
			{
				this.PanTitleMain.Visibility = Visibility.Visible;
				this.PanTitleMain.IsHitTestVisible = true;
				this.PanTitleInner.IsHitTestVisible = false;
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaOpacity(this.PanTitleInner, -this.PanTitleInner.Opacity, 0x7D, 0, null, false),
					ModAni.AaX(this.PanTitleInner, -9.0 - this.PanTitleInner.Margin.Left, 0x7D, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaOpacity(this.PanTitleMain, 1.0 - this.PanTitleMain.Opacity, 0x96, 0x96, null, false),
					ModAni.AaX(this.PanTitleMain, -this.PanTitleMain.Margin.Left, 0x96, 0x96, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaCode(delegate
					{
						this.PanTitleInner.Visibility = Visibility.Collapsed;
					}, 0, true)
				}, "FrmMain Titlebar FirstLayer", false);
				this.m_MessageDecorator.Clear();
			}
		}

		// Token: 0x0600110E RID: 4366 RVA: 0x0007C0E0 File Offset: 0x0007A2E0
		private void PanMainLeft_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (e.WidthChanged)
			{
				this.PanMainLeft_Resize(e.NewSize.Width);
			}
		}

		// Token: 0x0600110F RID: 4367 RVA: 0x0007C10C File Offset: 0x0007A30C
		private void PanMainLeft_Resize(double NewWidth)
		{
			if (Math.Abs(NewWidth - this.RectLeftBackground.Width) >= 0.1)
			{
				if (ModAni.InsertFactory() == 0)
				{
					if (this.PanMain.Opacity < 0.1)
					{
						this.PanMainLeft.IsHitTestVisible = false;
					}
					if (NewWidth > 0.0)
					{
						ModAni.AniStart(new ModAni.AniData[]
						{
							ModAni.AaWidth(this.RectLeftBackground, NewWidth - this.RectLeftBackground.Width, 0x190, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.ExtraStrong), false),
							ModAni.AaOpacity(this.RectLeftShadow, 1.0 - this.RectLeftShadow.Opacity, 0xC8, 0, null, false),
							ModAni.AaCode(delegate
							{
								this.PanMainLeft.IsHitTestVisible = true;
							}, 0xFA, false)
						}, "FrmMain LeftChange", true);
						return;
					}
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaWidth(this.RectLeftBackground, -this.RectLeftBackground.Width, 0xC8, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
						ModAni.AaOpacity(this.RectLeftShadow, -this.RectLeftShadow.Opacity, 0xC8, 0, null, false),
						ModAni.AaCode(delegate
						{
							this.PanMainLeft.IsHitTestVisible = true;
						}, 0xAA, false)
					}, "FrmMain LeftChange", true);
					return;
				}
				else
				{
					this.RectLeftBackground.Width = NewWidth;
					this.PanMainLeft.IsHitTestVisible = true;
					ModAni.AniStop("FrmMain LeftChange");
				}
			}
		}

		// Token: 0x06001110 RID: 4368 RVA: 0x0000AE71 File Offset: 0x00009071
		public void DragTick()
		{
			if (ModMain.m_ValRule != null && Mouse.LeftButton != MouseButtonState.Pressed)
			{
				this.DragStop();
			}
		}

		// Token: 0x06001111 RID: 4369 RVA: 0x0000AE88 File Offset: 0x00009088
		public void DragDoing()
		{
			if (ModMain.m_ValRule != null)
			{
				if (Mouse.LeftButton == MouseButtonState.Pressed)
				{
					NewLateBinding.LateCall(ModMain.m_ValRule, null, "DragDoing", new object[0], null, null, null, true);
					return;
				}
				this.DragStop();
			}
		}

		// Token: 0x06001112 RID: 4370 RVA: 0x0000AEBB File Offset: 0x000090BB
		public void DragStop()
		{
			ModBase.RunInUi((FormMain._Closure$__.$I51-0 == null) ? (FormMain._Closure$__.$I51-0 = delegate()
			{
				if (ModMain.m_ValRule != null)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(ModMain.m_ValRule);
					ModMain.m_ValRule = null;
					NewLateBinding.LateCall(objectValue, null, "DragStop", new object[0], null, null, null, true);
				}
			}) : FormMain._Closure$__.$I51-0, false);
		}

		// Token: 0x06001113 RID: 4371 RVA: 0x0000AEE7 File Offset: 0x000090E7
		private void BtnExtraMusic_Click(object sender, EventArgs e)
		{
			ModMusic.MusicControlPause();
		}

		// Token: 0x06001114 RID: 4372 RVA: 0x0000AEEE File Offset: 0x000090EE
		private void BtnExtraMusic_RightClick(object sender, EventArgs e)
		{
			ModMusic.MusicControlNext();
		}

		// Token: 0x06001115 RID: 4373 RVA: 0x0000AEF5 File Offset: 0x000090F5
		private void BtnExtraDownload_Click(object sender, EventArgs e)
		{
			this.PageChange(FormMain.PageType.DownloadManager, FormMain.PageSubType.Default);
		}

		// Token: 0x06001116 RID: 4374 RVA: 0x0000AF04 File Offset: 0x00009104
		private bool BtnExtraDownload_ShowCheck()
		{
			return ModNet.HasDownloadingTask(false) && !(this.publisherDecorator == FormMain.PageType.DownloadManager);
		}

		// Token: 0x06001117 RID: 4375 RVA: 0x0007C2A4 File Offset: 0x0007A4A4
		public void AprilGiveup()
		{
			if (ModMain.policyFilter && !ModMain.m_ClientFilter)
			{
				ModMain.Hint("=D", ModMain.HintType.Finish, true);
				ModMain.m_ClientFilter = true;
				ModMain.m_InvocationFilter.AprilScaleTrans.ScaleX = 1.0;
				ModMain.m_InvocationFilter.AprilScaleTrans.ScaleY = 1.0;
				this.BtnExtraApril.ShowRefresh();
			}
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x0000AF24 File Offset: 0x00009124
		public bool BtnExtraApril_ShowCheck()
		{
			return ModMain.policyFilter && !ModMain.m_ClientFilter && this.publisherDecorator == FormMain.PageType.Launch;
		}

		// Token: 0x06001119 RID: 4377 RVA: 0x0007C30C File Offset: 0x0007A50C
		public void BtnExtraShutdown_Click()
		{
			try
			{
				if (ModLaunch.m_ManagerIterator != null)
				{
					ModLaunch.m_ManagerIterator.Abort();
				}
				try
				{
					foreach (ModWatcher.Watcher watcher in ModWatcher.m_TestsVal)
					{
						watcher.Kill();
					}
				}
				finally
				{
					List<ModWatcher.Watcher>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				ModMain.Hint("已关闭运行中的 Minecraft！", ModMain.HintType.Finish, true);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "强制关闭所有 Minecraft 失败", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x0600111A RID: 4378 RVA: 0x0000AF47 File Offset: 0x00009147
		public bool BtnExtraShutdown_ShowCheck()
		{
			return ModWatcher.m_FieldVal;
		}

		// Token: 0x0600111B RID: 4379 RVA: 0x0007C3A8 File Offset: 0x0007A5A8
		private void BtnExtraBack_Click(object sender, EventArgs e)
		{
			MyScrollViewer myScrollViewer = this.BtnExtraBack_GetRealChild();
			myScrollViewer.PerformVerticalOffsetDelta(-myScrollViewer.VerticalOffset);
		}

		// Token: 0x0600111C RID: 4380 RVA: 0x0007C3CC File Offset: 0x0007A5CC
		private bool BtnExtraBack_ShowCheck()
		{
			MyScrollViewer myScrollViewer = this.BtnExtraBack_GetRealChild();
			return myScrollViewer != null && myScrollViewer.VerticalOffset > base.Height + (double)(this.BtnExtraBack.Show ? 0 : 0x5DC);
		}

		// Token: 0x0600111D RID: 4381 RVA: 0x0007C40C File Offset: 0x0007A60C
		private MyScrollViewer BtnExtraBack_GetRealChild()
		{
			MyScrollViewer result;
			if (this.PanMainRight.Child == null)
			{
				result = null;
			}
			else
			{
				UIElement child = ((AdornerDecorator)this.PanMainRight.Child).Child;
				if (child == null)
				{
					result = null;
				}
				else if (child is MyScrollViewer)
				{
					result = (MyScrollViewer)child;
				}
				else if (child is Grid && ((Grid)child).Children[0] is MyScrollViewer)
				{
					result = (MyScrollViewer)((Grid)child).Children[0];
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x0600111E RID: 4382 RVA: 0x0000AF4E File Offset: 0x0000914E
		private void FormMain_MouseMove(object sender, MouseEventArgs e)
		{
			this._FactoryFilter = e;
		}

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x0600111F RID: 4383 RVA: 0x0000AF57 File Offset: 0x00009157
		// (set) Token: 0x06001120 RID: 4384 RVA: 0x0000AF5F File Offset: 0x0000915F
		internal virtual FormMain WindMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x06001121 RID: 4385 RVA: 0x0000AF68 File Offset: 0x00009168
		// (set) Token: 0x06001122 RID: 4386 RVA: 0x0007C494 File Offset: 0x0007A694
		internal virtual Grid PanBack
		{
			[CompilerGenerated]
			get
			{
				return this.m_ContainerFilter;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = delegate(object sender, MouseEventArgs e)
				{
					this.DragDoing();
				};
				Grid containerFilter = this.m_ContainerFilter;
				if (containerFilter != null)
				{
					containerFilter.MouseMove -= value2;
				}
				this.m_ContainerFilter = value;
				containerFilter = this.m_ContainerFilter;
				if (containerFilter != null)
				{
					containerFilter.MouseMove += value2;
				}
			}
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06001123 RID: 4387 RVA: 0x0000AF70 File Offset: 0x00009170
		// (set) Token: 0x06001124 RID: 4388 RVA: 0x0000AF78 File Offset: 0x00009178
		internal virtual Rectangle ResizerT { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x06001125 RID: 4389 RVA: 0x0000AF81 File Offset: 0x00009181
		// (set) Token: 0x06001126 RID: 4390 RVA: 0x0000AF89 File Offset: 0x00009189
		internal virtual Rectangle ResizerB { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x06001127 RID: 4391 RVA: 0x0000AF92 File Offset: 0x00009192
		// (set) Token: 0x06001128 RID: 4392 RVA: 0x0000AF9A File Offset: 0x0000919A
		internal virtual Rectangle ResizerR { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x06001129 RID: 4393 RVA: 0x0000AFA3 File Offset: 0x000091A3
		// (set) Token: 0x0600112A RID: 4394 RVA: 0x0000AFAB File Offset: 0x000091AB
		internal virtual Rectangle ResizerL { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x0600112B RID: 4395 RVA: 0x0000AFB4 File Offset: 0x000091B4
		// (set) Token: 0x0600112C RID: 4396 RVA: 0x0000AFBC File Offset: 0x000091BC
		internal virtual Rectangle ResizerLT { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x0600112D RID: 4397 RVA: 0x0000AFC5 File Offset: 0x000091C5
		// (set) Token: 0x0600112E RID: 4398 RVA: 0x0000AFCD File Offset: 0x000091CD
		internal virtual Rectangle ResizerLB { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x0600112F RID: 4399 RVA: 0x0000AFD6 File Offset: 0x000091D6
		// (set) Token: 0x06001130 RID: 4400 RVA: 0x0000AFDE File Offset: 0x000091DE
		internal virtual Rectangle ResizerRB { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06001131 RID: 4401 RVA: 0x0000AFE7 File Offset: 0x000091E7
		// (set) Token: 0x06001132 RID: 4402 RVA: 0x0000AFEF File Offset: 0x000091EF
		internal virtual Rectangle ResizerRT { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06001133 RID: 4403 RVA: 0x0000AFF8 File Offset: 0x000091F8
		// (set) Token: 0x06001134 RID: 4404 RVA: 0x0000B000 File Offset: 0x00009200
		internal virtual Border BorderForm { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06001135 RID: 4405 RVA: 0x0000B009 File Offset: 0x00009209
		// (set) Token: 0x06001136 RID: 4406 RVA: 0x0000B011 File Offset: 0x00009211
		internal virtual RectangleGeometry RectForm { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06001137 RID: 4407 RVA: 0x0000B01A File Offset: 0x0000921A
		// (set) Token: 0x06001138 RID: 4408 RVA: 0x0000B022 File Offset: 0x00009222
		internal virtual Grid PanForm { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06001139 RID: 4409 RVA: 0x0000B02B File Offset: 0x0000922B
		// (set) Token: 0x0600113A RID: 4410 RVA: 0x0000B033 File Offset: 0x00009233
		internal virtual Canvas ImgBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x0600113B RID: 4411 RVA: 0x0000B03C File Offset: 0x0000923C
		// (set) Token: 0x0600113C RID: 4412 RVA: 0x0007C4D8 File Offset: 0x0007A6D8
		internal virtual Grid PanTitle
		{
			[CompilerGenerated]
			get
			{
				return this.issuerFilter;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseButtonEventHandler value2 = new MouseButtonEventHandler(this.FormDragMove);
				Grid grid = this.issuerFilter;
				if (grid != null)
				{
					grid.MouseLeftButtonDown -= value2;
				}
				this.issuerFilter = value;
				grid = this.issuerFilter;
				if (grid != null)
				{
					grid.MouseLeftButtonDown += value2;
				}
			}
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x0600113D RID: 4413 RVA: 0x0000B044 File Offset: 0x00009244
		// (set) Token: 0x0600113E RID: 4414 RVA: 0x0000B04C File Offset: 0x0000924C
		internal virtual Image ImgTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x0600113F RID: 4415 RVA: 0x0000B055 File Offset: 0x00009255
		// (set) Token: 0x06001140 RID: 4416 RVA: 0x0007C51C File Offset: 0x0007A71C
		internal virtual MyIconButton BtnTitleClose
		{
			[CompilerGenerated]
			get
			{
				return this.m_ServiceFilter;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyIconButton.ClickEventHandler value2 = delegate(object sender, EventArgs e)
				{
					this.BtnTitleClose_Click(RuntimeHelpers.GetObjectValue(sender), (RoutedEventArgs)e);
				};
				MyIconButton serviceFilter = this.m_ServiceFilter;
				if (serviceFilter != null)
				{
					serviceFilter.Click -= value2;
				}
				this.m_ServiceFilter = value;
				serviceFilter = this.m_ServiceFilter;
				if (serviceFilter != null)
				{
					serviceFilter.Click += value2;
				}
			}
		}

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06001141 RID: 4417 RVA: 0x0000B05D File Offset: 0x0000925D
		// (set) Token: 0x06001142 RID: 4418 RVA: 0x0007C560 File Offset: 0x0007A760
		internal virtual MyIconButton BtnTitleMin
		{
			[CompilerGenerated]
			get
			{
				return this._FacadeFilter;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyIconButton.ClickEventHandler value2 = delegate(object sender, EventArgs e)
				{
					this.BtnTitleMin_Click();
				};
				MyIconButton facadeFilter = this._FacadeFilter;
				if (facadeFilter != null)
				{
					facadeFilter.Click -= value2;
				}
				this._FacadeFilter = value;
				facadeFilter = this._FacadeFilter;
				if (facadeFilter != null)
				{
					facadeFilter.Click += value2;
				}
			}
		}

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06001143 RID: 4419 RVA: 0x0000B065 File Offset: 0x00009265
		// (set) Token: 0x06001144 RID: 4420 RVA: 0x0000B06D File Offset: 0x0000926D
		internal virtual Grid PanTitleMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06001145 RID: 4421 RVA: 0x0000B076 File Offset: 0x00009276
		// (set) Token: 0x06001146 RID: 4422 RVA: 0x0000B07E File Offset: 0x0000927E
		internal virtual System.Windows.Shapes.Path ShapeTitleLogo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06001147 RID: 4423 RVA: 0x0000B087 File Offset: 0x00009287
		// (set) Token: 0x06001148 RID: 4424 RVA: 0x0000B08F File Offset: 0x0000928F
		internal virtual TextBlock LabTitleLogo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x06001149 RID: 4425 RVA: 0x0000B098 File Offset: 0x00009298
		// (set) Token: 0x0600114A RID: 4426 RVA: 0x0000B0A0 File Offset: 0x000092A0
		internal virtual Image ImageTitleLogo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x0600114B RID: 4427 RVA: 0x0000B0A9 File Offset: 0x000092A9
		// (set) Token: 0x0600114C RID: 4428 RVA: 0x0000B0B1 File Offset: 0x000092B1
		internal virtual StackPanel PanTitleSelect { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x0600114D RID: 4429 RVA: 0x0000B0BA File Offset: 0x000092BA
		// (set) Token: 0x0600114E RID: 4430 RVA: 0x0007C5A4 File Offset: 0x0007A7A4
		internal virtual MyRadioButton BtnTitleSelect0
		{
			[CompilerGenerated]
			get
			{
				return this.m_ObjectFilter;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyRadioButton.CheckEventHandler obj = delegate(object a0, bool a1)
				{
					this.BtnTitleSelect_Click((MyRadioButton)a0, a1);
				};
				MyRadioButton objectFilter = this.m_ObjectFilter;
				if (objectFilter != null)
				{
					objectFilter.CountIterator(obj);
				}
				this.m_ObjectFilter = value;
				objectFilter = this.m_ObjectFilter;
				if (objectFilter != null)
				{
					objectFilter.VisitIterator(obj);
				}
			}
		}

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x0600114F RID: 4431 RVA: 0x0000B0C2 File Offset: 0x000092C2
		// (set) Token: 0x06001150 RID: 4432 RVA: 0x0007C5E8 File Offset: 0x0007A7E8
		internal virtual MyRadioButton BtnTitleSelect1
		{
			[CompilerGenerated]
			get
			{
				return this.callbackFilter;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyRadioButton.CheckEventHandler obj = delegate(object a0, bool a1)
				{
					this.BtnTitleSelect_Click((MyRadioButton)a0, a1);
				};
				MyRadioButton myRadioButton = this.callbackFilter;
				if (myRadioButton != null)
				{
					myRadioButton.CountIterator(obj);
				}
				this.callbackFilter = value;
				myRadioButton = this.callbackFilter;
				if (myRadioButton != null)
				{
					myRadioButton.VisitIterator(obj);
				}
			}
		}

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06001151 RID: 4433 RVA: 0x0000B0CA File Offset: 0x000092CA
		// (set) Token: 0x06001152 RID: 4434 RVA: 0x0007C62C File Offset: 0x0007A82C
		internal virtual MyRadioButton BtnTitleSelect2
		{
			[CompilerGenerated]
			get
			{
				return this.workerFilter;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyRadioButton.CheckEventHandler obj = delegate(object a0, bool a1)
				{
					this.BtnTitleSelect_Click((MyRadioButton)a0, a1);
				};
				MyRadioButton myRadioButton = this.workerFilter;
				if (myRadioButton != null)
				{
					myRadioButton.CountIterator(obj);
				}
				this.workerFilter = value;
				myRadioButton = this.workerFilter;
				if (myRadioButton != null)
				{
					myRadioButton.VisitIterator(obj);
				}
			}
		}

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06001153 RID: 4435 RVA: 0x0000B0D2 File Offset: 0x000092D2
		// (set) Token: 0x06001154 RID: 4436 RVA: 0x0007C670 File Offset: 0x0007A870
		internal virtual MyRadioButton BtnTitleSelect3
		{
			[CompilerGenerated]
			get
			{
				return this._VisitorFilter;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyRadioButton.CheckEventHandler obj = delegate(object a0, bool a1)
				{
					this.BtnTitleSelect_Click((MyRadioButton)a0, a1);
				};
				MyRadioButton visitorFilter = this._VisitorFilter;
				if (visitorFilter != null)
				{
					visitorFilter.CountIterator(obj);
				}
				this._VisitorFilter = value;
				visitorFilter = this._VisitorFilter;
				if (visitorFilter != null)
				{
					visitorFilter.VisitIterator(obj);
				}
			}
		}

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x06001155 RID: 4437 RVA: 0x0000B0DA File Offset: 0x000092DA
		// (set) Token: 0x06001156 RID: 4438 RVA: 0x0007C6B4 File Offset: 0x0007A8B4
		internal virtual MyRadioButton BtnTitleSelect4
		{
			[CompilerGenerated]
			get
			{
				return this.m_IndexerFilter;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyRadioButton.CheckEventHandler obj = delegate(object a0, bool a1)
				{
					this.BtnTitleSelect_Click((MyRadioButton)a0, a1);
				};
				MyRadioButton indexerFilter = this.m_IndexerFilter;
				if (indexerFilter != null)
				{
					indexerFilter.CountIterator(obj);
				}
				this.m_IndexerFilter = value;
				indexerFilter = this.m_IndexerFilter;
				if (indexerFilter != null)
				{
					indexerFilter.VisitIterator(obj);
				}
			}
		}

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x06001157 RID: 4439 RVA: 0x0000B0E2 File Offset: 0x000092E2
		// (set) Token: 0x06001158 RID: 4440 RVA: 0x0000B0EA File Offset: 0x000092EA
		internal virtual Grid PanTitleInner { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x06001159 RID: 4441 RVA: 0x0000B0F3 File Offset: 0x000092F3
		// (set) Token: 0x0600115A RID: 4442 RVA: 0x0007C6F8 File Offset: 0x0007A8F8
		internal virtual MyIconButton BtnTitleInner
		{
			[CompilerGenerated]
			get
			{
				return this.m_DatabaseFilter;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyIconButton.ClickEventHandler value2 = delegate(object sender, EventArgs e)
				{
					this.PageBack();
				};
				MyIconButton databaseFilter = this.m_DatabaseFilter;
				if (databaseFilter != null)
				{
					databaseFilter.Click -= value2;
				}
				this.m_DatabaseFilter = value;
				databaseFilter = this.m_DatabaseFilter;
				if (databaseFilter != null)
				{
					databaseFilter.Click += value2;
				}
			}
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x0600115B RID: 4443 RVA: 0x0000B0FB File Offset: 0x000092FB
		// (set) Token: 0x0600115C RID: 4444 RVA: 0x0000B103 File Offset: 0x00009303
		internal virtual TextBlock LabTitleInner { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x0600115D RID: 4445 RVA: 0x0000B10C File Offset: 0x0000930C
		// (set) Token: 0x0600115E RID: 4446 RVA: 0x0000B114 File Offset: 0x00009314
		internal virtual Grid PanLeft { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x0600115F RID: 4447 RVA: 0x0000B11D File Offset: 0x0000931D
		// (set) Token: 0x06001160 RID: 4448 RVA: 0x0000B125 File Offset: 0x00009325
		internal virtual Rectangle RectLeftBackground { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06001161 RID: 4449 RVA: 0x0000B12E File Offset: 0x0000932E
		// (set) Token: 0x06001162 RID: 4450 RVA: 0x0000B136 File Offset: 0x00009336
		internal virtual Rectangle RectLeftShadow { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x06001163 RID: 4451 RVA: 0x0000B13F File Offset: 0x0000933F
		// (set) Token: 0x06001164 RID: 4452 RVA: 0x0000B147 File Offset: 0x00009347
		internal virtual Grid PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06001165 RID: 4453 RVA: 0x0000B150 File Offset: 0x00009350
		// (set) Token: 0x06001166 RID: 4454 RVA: 0x0000B158 File Offset: 0x00009358
		internal virtual Border PanMainRight { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06001167 RID: 4455 RVA: 0x0000B161 File Offset: 0x00009361
		// (set) Token: 0x06001168 RID: 4456 RVA: 0x0007C73C File Offset: 0x0007A93C
		internal virtual Border PanMainLeft
		{
			[CompilerGenerated]
			get
			{
				return this.m_RepositoryFilter;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SizeChangedEventHandler value2 = new SizeChangedEventHandler(this.PanMainLeft_SizeChanged);
				Border repositoryFilter = this.m_RepositoryFilter;
				if (repositoryFilter != null)
				{
					repositoryFilter.SizeChanged -= value2;
				}
				this.m_RepositoryFilter = value;
				repositoryFilter = this.m_RepositoryFilter;
				if (repositoryFilter != null)
				{
					repositoryFilter.SizeChanged += value2;
				}
			}
		}

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06001169 RID: 4457 RVA: 0x0000B169 File Offset: 0x00009369
		// (set) Token: 0x0600116A RID: 4458 RVA: 0x0000B171 File Offset: 0x00009371
		internal virtual StackPanel PanHint { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x0600116B RID: 4459 RVA: 0x0000B17A File Offset: 0x0000937A
		// (set) Token: 0x0600116C RID: 4460 RVA: 0x0007C780 File Offset: 0x0007A980
		internal virtual MyExtraButton BtnExtraBack
		{
			[CompilerGenerated]
			get
			{
				return this.proccesorFilter;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyExtraButton.ClickEventHandler obj = new MyExtraButton.ClickEventHandler(this.BtnExtraBack_Click);
				MyExtraButton myExtraButton = this.proccesorFilter;
				if (myExtraButton != null)
				{
					myExtraButton.ForgotFactory(obj);
				}
				this.proccesorFilter = value;
				myExtraButton = this.proccesorFilter;
				if (myExtraButton != null)
				{
					myExtraButton.CloneFactory(obj);
				}
			}
		}

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x0600116D RID: 4461 RVA: 0x0000B182 File Offset: 0x00009382
		// (set) Token: 0x0600116E RID: 4462 RVA: 0x0007C7C4 File Offset: 0x0007A9C4
		internal virtual MyExtraButton BtnExtraDownload
		{
			[CompilerGenerated]
			get
			{
				return this.prototypeFilter;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyExtraButton.ClickEventHandler obj = new MyExtraButton.ClickEventHandler(this.BtnExtraDownload_Click);
				MyExtraButton myExtraButton = this.prototypeFilter;
				if (myExtraButton != null)
				{
					myExtraButton.ForgotFactory(obj);
				}
				this.prototypeFilter = value;
				myExtraButton = this.prototypeFilter;
				if (myExtraButton != null)
				{
					myExtraButton.CloneFactory(obj);
				}
			}
		}

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x0600116F RID: 4463 RVA: 0x0000B18A File Offset: 0x0000938A
		// (set) Token: 0x06001170 RID: 4464 RVA: 0x0007C808 File Offset: 0x0007AA08
		internal virtual MyExtraButton BtnExtraApril
		{
			[CompilerGenerated]
			get
			{
				return this._RefFilter;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyExtraButton.ClickEventHandler obj = delegate(object sender, MouseButtonEventArgs e)
				{
					this.AprilGiveup();
				};
				MyExtraButton refFilter = this._RefFilter;
				if (refFilter != null)
				{
					refFilter.ForgotFactory(obj);
				}
				this._RefFilter = value;
				refFilter = this._RefFilter;
				if (refFilter != null)
				{
					refFilter.CloneFactory(obj);
				}
			}
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06001171 RID: 4465 RVA: 0x0000B192 File Offset: 0x00009392
		// (set) Token: 0x06001172 RID: 4466 RVA: 0x0007C84C File Offset: 0x0007AA4C
		internal virtual MyExtraButton BtnExtraShutdown
		{
			[CompilerGenerated]
			get
			{
				return this.m_ParameterFilter;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyExtraButton.ClickEventHandler obj = delegate(object sender, MouseButtonEventArgs e)
				{
					this.BtnExtraShutdown_Click();
				};
				MyExtraButton parameterFilter = this.m_ParameterFilter;
				if (parameterFilter != null)
				{
					parameterFilter.ForgotFactory(obj);
				}
				this.m_ParameterFilter = value;
				parameterFilter = this.m_ParameterFilter;
				if (parameterFilter != null)
				{
					parameterFilter.CloneFactory(obj);
				}
			}
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06001173 RID: 4467 RVA: 0x0000B19A File Offset: 0x0000939A
		// (set) Token: 0x06001174 RID: 4468 RVA: 0x0007C890 File Offset: 0x0007AA90
		internal virtual MyExtraButton BtnExtraMusic
		{
			[CompilerGenerated]
			get
			{
				return this.stubFilter;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyExtraButton.ClickEventHandler obj = new MyExtraButton.ClickEventHandler(this.BtnExtraMusic_Click);
				MyExtraButton.RightClickEventHandler obj2 = new MyExtraButton.RightClickEventHandler(this.BtnExtraMusic_RightClick);
				MyExtraButton myExtraButton = this.stubFilter;
				if (myExtraButton != null)
				{
					myExtraButton.ForgotFactory(obj);
					myExtraButton.EnableFactory(obj2);
				}
				this.stubFilter = value;
				myExtraButton = this.stubFilter;
				if (myExtraButton != null)
				{
					myExtraButton.CloneFactory(obj);
					myExtraButton.ManageFactory(obj2);
				}
			}
		}

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06001175 RID: 4469 RVA: 0x0000B1A2 File Offset: 0x000093A2
		// (set) Token: 0x06001176 RID: 4470 RVA: 0x0007C8F0 File Offset: 0x0007AAF0
		internal virtual Grid PanMsg
		{
			[CompilerGenerated]
			get
			{
				return this.accountFilter;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseButtonEventHandler value2 = new MouseButtonEventHandler(this.FormDragMove);
				Grid grid = this.accountFilter;
				if (grid != null)
				{
					grid.MouseLeftButtonDown -= value2;
				}
				this.accountFilter = value;
				grid = this.accountFilter;
				if (grid != null)
				{
					grid.MouseLeftButtonDown += value2;
				}
			}
		}

		// Token: 0x040008C6 RID: 2246
		private bool _IdentifierDecorator;

		// Token: 0x040008C7 RID: 2247
		private static bool m_PolicyDecorator;

		// Token: 0x040008C8 RID: 2248
		public bool m_ClientDecorator;

		// Token: 0x040008C9 RID: 2249
		public bool m_MapDecorator;

		// Token: 0x040008CA RID: 2250
		private bool _ComposerDecorator;

		// Token: 0x040008CB RID: 2251
		public FormMain.PageStackData publisherDecorator;

		// Token: 0x040008CC RID: 2252
		private readonly List<FormMain.PageStackData> m_MessageDecorator;

		// Token: 0x040008CD RID: 2253
		public MyPageLeft _TokenDecorator;

		// Token: 0x040008CE RID: 2254
		public FrameworkElement m_ProcDecorator;

		// Token: 0x040008CF RID: 2255
		public MouseEventArgs _FactoryFilter;

		// Token: 0x040008D0 RID: 2256
		[CompilerGenerated]
		[AccessedThroughProperty("WindMain")]
		private FormMain m_ValFilter;

		// Token: 0x040008D1 RID: 2257
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private Grid m_ContainerFilter;

		// Token: 0x040008D2 RID: 2258
		[AccessedThroughProperty("ResizerT")]
		[CompilerGenerated]
		private Rectangle m_ModelFilter;

		// Token: 0x040008D3 RID: 2259
		[CompilerGenerated]
		[AccessedThroughProperty("ResizerB")]
		private Rectangle m_IteratorFilter;

		// Token: 0x040008D4 RID: 2260
		[AccessedThroughProperty("ResizerR")]
		[CompilerGenerated]
		private Rectangle expressionFilter;

		// Token: 0x040008D5 RID: 2261
		[AccessedThroughProperty("ResizerL")]
		[CompilerGenerated]
		private Rectangle m_UtilsFilter;

		// Token: 0x040008D6 RID: 2262
		[CompilerGenerated]
		[AccessedThroughProperty("ResizerLT")]
		private Rectangle baseFilter;

		// Token: 0x040008D7 RID: 2263
		[CompilerGenerated]
		[AccessedThroughProperty("ResizerLB")]
		private Rectangle _DecoratorFilter;

		// Token: 0x040008D8 RID: 2264
		[AccessedThroughProperty("ResizerRB")]
		[CompilerGenerated]
		private Rectangle m_FilterFilter;

		// Token: 0x040008D9 RID: 2265
		[CompilerGenerated]
		[AccessedThroughProperty("ResizerRT")]
		private Rectangle m_RuleFilter;

		// Token: 0x040008DA RID: 2266
		[CompilerGenerated]
		[AccessedThroughProperty("BorderForm")]
		private Border _AlgoFilter;

		// Token: 0x040008DB RID: 2267
		[AccessedThroughProperty("RectForm")]
		[CompilerGenerated]
		private RectangleGeometry m_MapperFilter;

		// Token: 0x040008DC RID: 2268
		[CompilerGenerated]
		[AccessedThroughProperty("PanForm")]
		private Grid _ParamsFilter;

		// Token: 0x040008DD RID: 2269
		[AccessedThroughProperty("ImgBack")]
		[CompilerGenerated]
		private Canvas globalFilter;

		// Token: 0x040008DE RID: 2270
		[AccessedThroughProperty("PanTitle")]
		[CompilerGenerated]
		private Grid issuerFilter;

		// Token: 0x040008DF RID: 2271
		[CompilerGenerated]
		[AccessedThroughProperty("ImgTitle")]
		private Image _OrderFilter;

		// Token: 0x040008E0 RID: 2272
		[CompilerGenerated]
		[AccessedThroughProperty("BtnTitleClose")]
		private MyIconButton m_ServiceFilter;

		// Token: 0x040008E1 RID: 2273
		[CompilerGenerated]
		[AccessedThroughProperty("BtnTitleMin")]
		private MyIconButton _FacadeFilter;

		// Token: 0x040008E2 RID: 2274
		[AccessedThroughProperty("PanTitleMain")]
		[CompilerGenerated]
		private Grid m_CodeFilter;

		// Token: 0x040008E3 RID: 2275
		[AccessedThroughProperty("ShapeTitleLogo")]
		[CompilerGenerated]
		private System.Windows.Shapes.Path m_MappingFilter;

		// Token: 0x040008E4 RID: 2276
		[AccessedThroughProperty("LabTitleLogo")]
		[CompilerGenerated]
		private TextBlock _BridgeFilter;

		// Token: 0x040008E5 RID: 2277
		[AccessedThroughProperty("ImageTitleLogo")]
		[CompilerGenerated]
		private Image m_SingletonFilter;

		// Token: 0x040008E6 RID: 2278
		[AccessedThroughProperty("PanTitleSelect")]
		[CompilerGenerated]
		private StackPanel errorFilter;

		// Token: 0x040008E7 RID: 2279
		[CompilerGenerated]
		[AccessedThroughProperty("BtnTitleSelect0")]
		private MyRadioButton m_ObjectFilter;

		// Token: 0x040008E8 RID: 2280
		[AccessedThroughProperty("BtnTitleSelect1")]
		[CompilerGenerated]
		private MyRadioButton callbackFilter;

		// Token: 0x040008E9 RID: 2281
		[AccessedThroughProperty("BtnTitleSelect2")]
		[CompilerGenerated]
		private MyRadioButton workerFilter;

		// Token: 0x040008EA RID: 2282
		[AccessedThroughProperty("BtnTitleSelect3")]
		[CompilerGenerated]
		private MyRadioButton _VisitorFilter;

		// Token: 0x040008EB RID: 2283
		[AccessedThroughProperty("BtnTitleSelect4")]
		[CompilerGenerated]
		private MyRadioButton m_IndexerFilter;

		// Token: 0x040008EC RID: 2284
		[AccessedThroughProperty("PanTitleInner")]
		[CompilerGenerated]
		private Grid _MethodFilter;

		// Token: 0x040008ED RID: 2285
		[CompilerGenerated]
		[AccessedThroughProperty("BtnTitleInner")]
		private MyIconButton m_DatabaseFilter;

		// Token: 0x040008EE RID: 2286
		[AccessedThroughProperty("LabTitleInner")]
		[CompilerGenerated]
		private TextBlock m_AttrFilter;

		// Token: 0x040008EF RID: 2287
		[AccessedThroughProperty("PanLeft")]
		[CompilerGenerated]
		private Grid m_ThreadFilter;

		// Token: 0x040008F0 RID: 2288
		[AccessedThroughProperty("RectLeftBackground")]
		[CompilerGenerated]
		private Rectangle managerFilter;

		// Token: 0x040008F1 RID: 2289
		[AccessedThroughProperty("RectLeftShadow")]
		[CompilerGenerated]
		private Rectangle m_ItemFilter;

		// Token: 0x040008F2 RID: 2290
		[AccessedThroughProperty("PanMain")]
		[CompilerGenerated]
		private Grid _SerializerFilter;

		// Token: 0x040008F3 RID: 2291
		[AccessedThroughProperty("PanMainRight")]
		[CompilerGenerated]
		private Border m_InfoFilter;

		// Token: 0x040008F4 RID: 2292
		[CompilerGenerated]
		[AccessedThroughProperty("PanMainLeft")]
		private Border m_RepositoryFilter;

		// Token: 0x040008F5 RID: 2293
		[CompilerGenerated]
		[AccessedThroughProperty("PanHint")]
		private StackPanel m_SystemFilter;

		// Token: 0x040008F6 RID: 2294
		[AccessedThroughProperty("BtnExtraBack")]
		[CompilerGenerated]
		private MyExtraButton proccesorFilter;

		// Token: 0x040008F7 RID: 2295
		[AccessedThroughProperty("BtnExtraDownload")]
		[CompilerGenerated]
		private MyExtraButton prototypeFilter;

		// Token: 0x040008F8 RID: 2296
		[CompilerGenerated]
		[AccessedThroughProperty("BtnExtraApril")]
		private MyExtraButton _RefFilter;

		// Token: 0x040008F9 RID: 2297
		[AccessedThroughProperty("BtnExtraShutdown")]
		[CompilerGenerated]
		private MyExtraButton m_ParameterFilter;

		// Token: 0x040008FA RID: 2298
		[AccessedThroughProperty("BtnExtraMusic")]
		[CompilerGenerated]
		private MyExtraButton stubFilter;

		// Token: 0x040008FB RID: 2299
		[AccessedThroughProperty("PanMsg")]
		[CompilerGenerated]
		private Grid accountFilter;

		// Token: 0x02000186 RID: 390
		public enum PageType
		{
			// Token: 0x040008FE RID: 2302
			Launch,
			// Token: 0x040008FF RID: 2303
			Download,
			// Token: 0x04000900 RID: 2304
			Link,
			// Token: 0x04000901 RID: 2305
			Setup,
			// Token: 0x04000902 RID: 2306
			Other,
			// Token: 0x04000903 RID: 2307
			VersionSelect,
			// Token: 0x04000904 RID: 2308
			DownloadManager,
			// Token: 0x04000905 RID: 2309
			VersionSetup,
			// Token: 0x04000906 RID: 2310
			CfDetail,
			// Token: 0x04000907 RID: 2311
			HelpDetail
		}

		// Token: 0x02000187 RID: 391
		public enum PageSubType
		{
			// Token: 0x04000909 RID: 2313
			Default,
			// Token: 0x0400090A RID: 2314
			DownloadInstall,
			// Token: 0x0400090B RID: 2315
			DownloadClient = 4,
			// Token: 0x0400090C RID: 2316
			DownloadOptiFine,
			// Token: 0x0400090D RID: 2317
			DownloadForge,
			// Token: 0x0400090E RID: 2318
			DownloadFabric,
			// Token: 0x0400090F RID: 2319
			DownloadLiteLoader,
			// Token: 0x04000910 RID: 2320
			DownloadMod = 0xA,
			// Token: 0x04000911 RID: 2321
			DownloadPack,
			// Token: 0x04000912 RID: 2322
			SetupLaunch = 0,
			// Token: 0x04000913 RID: 2323
			SetupUI,
			// Token: 0x04000914 RID: 2324
			SetupSystem,
			// Token: 0x04000915 RID: 2325
			SetupAccount,
			// Token: 0x04000916 RID: 2326
			OtherHelp = 0,
			// Token: 0x04000917 RID: 2327
			OtherAbout,
			// Token: 0x04000918 RID: 2328
			OtherTest,
			// Token: 0x04000919 RID: 2329
			OtherFeedback,
			// Token: 0x0400091A RID: 2330
			VersionOverall = 0,
			// Token: 0x0400091B RID: 2331
			VersionSetup,
			// Token: 0x0400091C RID: 2332
			VersionMod,
			// Token: 0x0400091D RID: 2333
			VersionModDisabled
		}

		// Token: 0x02000188 RID: 392
		public class PageStackData
		{
			// Token: 0x06001195 RID: 4501 RVA: 0x0007D1CC File Offset: 0x0007B3CC
			public override bool Equals(object other)
			{
				bool result;
				if (other == null)
				{
					result = false;
				}
				else if (other is FormMain.PageStackData)
				{
					FormMain.PageStackData pageStackData = (FormMain.PageStackData)other;
					if (this._FieldMapper != pageStackData._FieldMapper)
					{
						result = false;
					}
					else if (this.m_StatusMapper == null)
					{
						result = (pageStackData.m_StatusMapper == null);
					}
					else
					{
						result = (pageStackData.m_StatusMapper != null && this.m_StatusMapper.Equals(RuntimeHelpers.GetObjectValue(pageStackData.m_StatusMapper)));
					}
				}
				else
				{
					result = (other is int && !Operators.ConditionalCompareObjectNotEqual(this._FieldMapper, other, true) && this.m_StatusMapper == null);
				}
				return result;
			}

			// Token: 0x06001196 RID: 4502 RVA: 0x0000B26C File Offset: 0x0000946C
			public static bool operator ==(FormMain.PageStackData left, FormMain.PageStackData right)
			{
				return EqualityComparer<FormMain.PageStackData>.Default.Equals(left, right);
			}

			// Token: 0x06001197 RID: 4503 RVA: 0x0000B27A File Offset: 0x0000947A
			public static bool operator !=(FormMain.PageStackData left, FormMain.PageStackData right)
			{
				return !(left == right);
			}

			// Token: 0x06001198 RID: 4504 RVA: 0x0000B286 File Offset: 0x00009486
			public static implicit operator FormMain.PageStackData(FormMain.PageType Value)
			{
				return new FormMain.PageStackData
				{
					_FieldMapper = Value
				};
			}

			// Token: 0x06001199 RID: 4505 RVA: 0x0000B294 File Offset: 0x00009494
			public static implicit operator FormMain.PageType(FormMain.PageStackData Value)
			{
				return Value._FieldMapper;
			}

			// Token: 0x0400091E RID: 2334
			public FormMain.PageType _FieldMapper;

			// Token: 0x0400091F RID: 2335
			public object[] m_StatusMapper;
		}
	}
}
