using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x0200013D RID: 317
	[DesignerGenerated]
	public class PageLaunchRight : AdornerDecorator, IComponentConnector
	{
		// Token: 0x06000B95 RID: 2965 RVA: 0x000086D4 File Offset: 0x000068D4
		public PageLaunchRight()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.Init();
			};
			this._PageExpression = "";
			this._InstanceExpression = null;
			this.testExpression = false;
			this.customerExpression = true;
			this.InitializeComponent();
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x00062B64 File Offset: 0x00060D64
		private void Init()
		{
			this.PanBack.ScrollToHome();
			this.PanLog.Visibility = (ModBase.errorRule ? Visibility.Visible : Visibility.Collapsed);
			if (this.customerExpression)
			{
				this.customerExpression = false;
				this.RefreshCustom();
			}
			this.PanHint.Title = "快照版提示";
			this.PanHint.Visibility = (ModMain.ManageIterator(null) ? Visibility.Collapsed : Visibility.Visible);
			this.LabHint1.Text = "快照版包含尚未正式版发布的测试性功能，仅用于赞助者本人尝鲜。所以请不要发给其他人或者用于制作整合包哦！如果发现了 Bug，可以在 更多 → 反馈 中提交！";
			this.LabHint2.Text = "你可以通过赞助￥23.33 档位换取解锁码来隐藏这个提示。";
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x00062BF0 File Offset: 0x00060DF0
		private void RefreshCustom()
		{
			if (this.testExpression)
			{
				this.customerExpression = true;
				return;
			}
			try
			{
				this.testExpression = true;
				this.PanCustom.Children.Clear();
				ModBase.RunInNewThread(delegate
				{
					string FileContent = "";
					object left = ModBase._BaseRule.Get("UiCustomType", null);
					if (!Operators.ConditionalCompareObjectEqual(left, 0, true))
					{
						if (Operators.ConditionalCompareObjectEqual(left, 1, true))
						{
							FileContent = ModBase.ReadFile(ModBase.Path + "PCL\\Custom.xaml");
							ModBase.Log("[System] 尝试从本地文件读取主页自定义数据（" + Conversions.ToString(FileContent.Length) + "）", ModBase.LogLevel.Normal, "出现错误");
						}
						else if (Operators.ConditionalCompareObjectEqual(left, 2, true))
						{
							try
							{
								string text = Conversions.ToString(ModBase._BaseRule.Get("UiCustomNet", null));
								if (Operators.CompareString(text, this._InstanceExpression, true) == 0)
								{
									FileContent = this._PageExpression;
									ModBase.Log("[System] 尝试缓存加载主页自定义数据（" + Conversions.ToString(FileContent.Length) + "）", ModBase.LogLevel.Normal, "出现错误");
								}
								else if (!string.IsNullOrWhiteSpace(text))
								{
									ModBase.Log("[System] 开始从网络读取主页自定义数据（" + text + "）", ModBase.LogLevel.Normal, "出现错误");
									FileContent = Conversions.ToString(ModNet.NetGetCodeByRequestRetry(text, null, "", false));
									ModBase.Log("[System] 尝试从网络读取主页自定义数据（" + Conversions.ToString(FileContent.Length) + "）", ModBase.LogLevel.Normal, "出现错误");
								}
								this._InstanceExpression = text;
								this._PageExpression = FileContent;
							}
							catch (Exception ex2)
							{
								ModBase.Log(ex2, "获取 PCL2 主页自定义信息失败", ModBase.LogLevel.Msgbox, "出现错误");
								this._InstanceExpression = "";
							}
						}
					}
					if (Operators.CompareString(FileContent, "", true) == 0)
					{
						this.testExpression = false;
						return;
					}
					FileContent = "<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" xmlns:local=\"clr-namespace:PCL;assembly=Plain Craft Launcher 2\">" + FileContent + "</StackPanel>";
					FileContent = FileContent.Replace("{path}", ModBase.Path);
					ModBase.RunInUi(delegate()
					{
						try
						{
							ModBase.Log("[System] 加载主页自定义数据", ModBase.LogLevel.Normal, "出现错误");
							this.PanCustom.Children.Add((UIElement)ModBase.GetObjectFromXML(FileContent));
							this.testExpression = false;
						}
						catch (Exception ex3)
						{
							this.testExpression = false;
							ModBase.Log("[System] 自定义信息内容：\r\n" + FileContent, ModBase.LogLevel.Normal, "出现错误");
							if (ModMain.MyMsgBox(ex3.Message, "加载自定义主页失败", "重试", "取消", "", false, true, false) == 1)
							{
								this._InstanceExpression = null;
								this._PageExpression = "";
								this.RefreshCustom();
							}
						}
					}, false);
				}, "主页自定义刷新", ThreadPriority.Normal);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "加载 PCL2 主页自定义信息失败", ModBase.LogLevel.Msgbox, "出现错误");
				this.testExpression = false;
			}
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x00062C78 File Offset: 0x00060E78
		public void ForceRefresh(bool ShowHint = true)
		{
			this.customerExpression = true;
			this._PageExpression = "";
			this._InstanceExpression = null;
			if (ShowHint)
			{
				ModMain.Hint("已刷新主页！", ModMain.HintType.Finish, true);
			}
			ModMain.m_GetterFilter.PageChange(FormMain.PageType.Launch, FormMain.PageSubType.Default);
			this.Init();
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x00008714 File Offset: 0x00006914
		private void BtnMsStart_Click()
		{
			ModMain.MyMsgBox("在迁移过程中，你可能需要设置你的档案信息。\r\n在输入年龄或生日时，请注意让你的年龄大于 18 岁，否则可能导致无法登录！", "迁移提示", "继续", "", "", false, true, true);
			ModBase.OpenWebsite("https://www.minecraft.net/zh-hans/account-security");
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x00008742 File Offset: 0x00006942
		private void BtnMsFaq_Click()
		{
			ModBase.OpenWebsite("https://www.mcbbs.net/thread-1129357-1-9.html");
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000B9B RID: 2971 RVA: 0x0000874E File Offset: 0x0000694E
		// (set) Token: 0x06000B9C RID: 2972 RVA: 0x00008756 File Offset: 0x00006956
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06000B9D RID: 2973 RVA: 0x0000875F File Offset: 0x0000695F
		// (set) Token: 0x06000B9E RID: 2974 RVA: 0x00008767 File Offset: 0x00006967
		internal virtual StackPanel PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000B9F RID: 2975 RVA: 0x00008770 File Offset: 0x00006970
		// (set) Token: 0x06000BA0 RID: 2976 RVA: 0x00008778 File Offset: 0x00006978
		internal virtual StackPanel PanCustom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000BA1 RID: 2977 RVA: 0x00008781 File Offset: 0x00006981
		// (set) Token: 0x06000BA2 RID: 2978 RVA: 0x00008789 File Offset: 0x00006989
		internal virtual MyCard PanMs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000BA3 RID: 2979 RVA: 0x00008792 File Offset: 0x00006992
		// (set) Token: 0x06000BA4 RID: 2980 RVA: 0x00062CC4 File Offset: 0x00060EC4
		internal virtual MyButton BtnMsStart
		{
			[CompilerGenerated]
			get
			{
				return this._ImporterExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.BtnMsStart_Click();
				};
				MyButton importerExpression = this._ImporterExpression;
				if (importerExpression != null)
				{
					importerExpression.CancelModel(obj);
				}
				this._ImporterExpression = value;
				importerExpression = this._ImporterExpression;
				if (importerExpression != null)
				{
					importerExpression.ValidateModel(obj);
				}
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000BA5 RID: 2981 RVA: 0x0000879A File Offset: 0x0000699A
		// (set) Token: 0x06000BA6 RID: 2982 RVA: 0x00062D08 File Offset: 0x00060F08
		internal virtual MyButton BtnMsFaq
		{
			[CompilerGenerated]
			get
			{
				return this.templateExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.BtnMsFaq_Click();
				};
				MyButton myButton = this.templateExpression;
				if (myButton != null)
				{
					myButton.CancelModel(obj);
				}
				this.templateExpression = value;
				myButton = this.templateExpression;
				if (myButton != null)
				{
					myButton.ValidateModel(obj);
				}
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000BA7 RID: 2983 RVA: 0x000087A2 File Offset: 0x000069A2
		// (set) Token: 0x06000BA8 RID: 2984 RVA: 0x000087AA File Offset: 0x000069AA
		internal virtual MyCard PanHint { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000BA9 RID: 2985 RVA: 0x000087B3 File Offset: 0x000069B3
		// (set) Token: 0x06000BAA RID: 2986 RVA: 0x000087BB File Offset: 0x000069BB
		internal virtual TextBlock LabHint1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000BAB RID: 2987 RVA: 0x000087C4 File Offset: 0x000069C4
		// (set) Token: 0x06000BAC RID: 2988 RVA: 0x000087CC File Offset: 0x000069CC
		internal virtual TextBlock LabHint2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000BAD RID: 2989 RVA: 0x000087D5 File Offset: 0x000069D5
		// (set) Token: 0x06000BAE RID: 2990 RVA: 0x000087DD File Offset: 0x000069DD
		internal virtual MyCard PanLog { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000BAF RID: 2991 RVA: 0x000087E6 File Offset: 0x000069E6
		// (set) Token: 0x06000BB0 RID: 2992 RVA: 0x000087EE File Offset: 0x000069EE
		internal virtual TextBlock LabLog { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x06000BB1 RID: 2993 RVA: 0x00062D4C File Offset: 0x00060F4C
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.paramExpression)
			{
				this.paramExpression = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagelaunch/pagelaunchright.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x00062D7C File Offset: 0x00060F7C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
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
				this.PanMain = (StackPanel)target;
				return;
			}
			if (connectionId == 3)
			{
				this.PanCustom = (StackPanel)target;
				return;
			}
			if (connectionId == 4)
			{
				this.PanMs = (MyCard)target;
				return;
			}
			if (connectionId == 5)
			{
				this.BtnMsStart = (MyButton)target;
				return;
			}
			if (connectionId == 6)
			{
				this.BtnMsFaq = (MyButton)target;
				return;
			}
			if (connectionId == 7)
			{
				this.PanHint = (MyCard)target;
				return;
			}
			if (connectionId == 8)
			{
				this.LabHint1 = (TextBlock)target;
				return;
			}
			if (connectionId == 9)
			{
				this.LabHint2 = (TextBlock)target;
				return;
			}
			if (connectionId == 0xA)
			{
				this.PanLog = (MyCard)target;
				return;
			}
			if (connectionId == 0xB)
			{
				this.LabLog = (TextBlock)target;
				return;
			}
			this.paramExpression = true;
		}

		// Token: 0x0400065D RID: 1629
		private string _PageExpression;

		// Token: 0x0400065E RID: 1630
		private string _InstanceExpression;

		// Token: 0x0400065F RID: 1631
		private bool testExpression;

		// Token: 0x04000660 RID: 1632
		public bool customerExpression;

		// Token: 0x04000661 RID: 1633
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private MyScrollViewer m_TaskExpression;

		// Token: 0x04000662 RID: 1634
		[CompilerGenerated]
		[AccessedThroughProperty("PanMain")]
		private StackPanel m_AuthenticationExpression;

		// Token: 0x04000663 RID: 1635
		[AccessedThroughProperty("PanCustom")]
		[CompilerGenerated]
		private StackPanel m_ProcessExpression;

		// Token: 0x04000664 RID: 1636
		[AccessedThroughProperty("PanMs")]
		[CompilerGenerated]
		private MyCard _ListenerExpression;

		// Token: 0x04000665 RID: 1637
		[AccessedThroughProperty("BtnMsStart")]
		[CompilerGenerated]
		private MyButton _ImporterExpression;

		// Token: 0x04000666 RID: 1638
		[AccessedThroughProperty("BtnMsFaq")]
		[CompilerGenerated]
		private MyButton templateExpression;

		// Token: 0x04000667 RID: 1639
		[AccessedThroughProperty("PanHint")]
		[CompilerGenerated]
		private MyCard adapterExpression;

		// Token: 0x04000668 RID: 1640
		[AccessedThroughProperty("LabHint1")]
		[CompilerGenerated]
		private TextBlock annotationExpression;

		// Token: 0x04000669 RID: 1641
		[CompilerGenerated]
		[AccessedThroughProperty("LabHint2")]
		private TextBlock readerExpression;

		// Token: 0x0400066A RID: 1642
		[AccessedThroughProperty("PanLog")]
		[CompilerGenerated]
		private MyCard regExpression;

		// Token: 0x0400066B RID: 1643
		[CompilerGenerated]
		[AccessedThroughProperty("LabLog")]
		private TextBlock _DefinitionExpression;

		// Token: 0x0400066C RID: 1644
		private bool paramExpression;
	}
}
