using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x0200014C RID: 332
	[DesignerGenerated]
	public class PageSetupLeft : MyPageLeft, IComponentConnector
	{
		// Token: 0x06000C9E RID: 3230 RVA: 0x00065E84 File Offset: 0x00064084
		public PageSetupLeft()
		{
			base.Loaded += this.PageSetupLeft_Loaded;
			base.Unloaded += this.PageOtherLeft_Unloaded;
			this.m_StubUtils = false;
			this.accountUtils = false;
			this.configurationUtils = FormMain.PageSubType.Default;
			this.InitializeComponent();
		}

		// Token: 0x06000C9F RID: 3231 RVA: 0x00065ED8 File Offset: 0x000640D8
		private void PageSetupLeft_Loaded(object sender, RoutedEventArgs e)
		{
			bool flag = false;
			if (Conversions.ToBoolean(this.ItemLaunch.Checked && Conversions.ToBoolean(ModBase._BaseRule.Get("UiHiddenSetupLaunch", null))))
			{
				flag = true;
			}
			if (Conversions.ToBoolean(this.ItemUI.Checked && Conversions.ToBoolean(ModBase._BaseRule.Get("UiHiddenSetupUi", null))))
			{
				flag = true;
			}
			if (Conversions.ToBoolean(this.ItemSystem.Checked && Conversions.ToBoolean(ModBase._BaseRule.Get("UiHiddenSetupSystem", null))))
			{
				flag = true;
			}
			if (Conversions.ToBoolean(this.ItemAccount.Checked && Conversions.ToBoolean(ModBase._BaseRule.Get("UiHiddenSetupTool", null))))
			{
				flag = true;
			}
			if (PageSetupUI.WriteModel())
			{
				flag = false;
			}
			if (!this.m_StubUtils || flag)
			{
				this.m_StubUtils = true;
				PageSetupUI.HiddenRefresh();
				if (!this.accountUtils)
				{
					if (Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("UiHiddenSetupLaunch", null))))
					{
						this.ItemLaunch.SetChecked(true, false, false);
						return;
					}
					if (Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("UiHiddenSetupUi", null))))
					{
						this.ItemUI.SetChecked(true, false, false);
						return;
					}
					if (Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("UiHiddenSetupSystem", null))))
					{
						this.ItemSystem.SetChecked(true, false, false);
						return;
					}
					this.ItemLaunch.SetChecked(true, false, false);
				}
			}
		}

		// Token: 0x06000CA0 RID: 3232 RVA: 0x00008F4A File Offset: 0x0000714A
		private void PageOtherLeft_Unloaded(object sender, RoutedEventArgs e)
		{
			this.accountUtils = false;
		}

		// Token: 0x06000CA1 RID: 3233 RVA: 0x00008F53 File Offset: 0x00007153
		private void PageCheck(MyListItem sender, EventArgs e)
		{
			if (sender.Tag != null)
			{
				this.PageChange(checked((FormMain.PageSubType)Math.Round(ModBase.Val(RuntimeHelpers.GetObjectValue(sender.Tag)))));
			}
		}

		// Token: 0x06000CA2 RID: 3234 RVA: 0x00066070 File Offset: 0x00064270
		public object PageGet(FormMain.PageSubType ID = (FormMain.PageSubType)(-1))
		{
			if (ID == (FormMain.PageSubType)(-1))
			{
				ID = this.configurationUtils;
			}
			object result;
			switch (ID)
			{
			case FormMain.PageSubType.Default:
				if (ModMain.m_AuthenticationFilter == null)
				{
					ModMain.m_AuthenticationFilter = new PageSetupLaunch();
				}
				result = ModMain.m_AuthenticationFilter;
				break;
			case FormMain.PageSubType.DownloadInstall:
				if (ModMain.processFilter == null)
				{
					ModMain.processFilter = new PageSetupUI();
				}
				result = ModMain.processFilter;
				break;
			case FormMain.PageSubType.SetupSystem:
				if (ModMain._ListenerFilter == null)
				{
					ModMain._ListenerFilter = new PageSetupSystem();
				}
				result = ModMain._ListenerFilter;
				break;
			case FormMain.PageSubType.SetupAccount:
				if (ModMain.m_ImporterFilter == null)
				{
					ModMain.m_ImporterFilter = new PageSetupAccount();
				}
				result = ModMain.m_ImporterFilter;
				break;
			default:
				throw new Exception("未知的设置子页面种类：" + Conversions.ToString((int)ID));
			}
			return result;
		}

		// Token: 0x06000CA3 RID: 3235 RVA: 0x0006611C File Offset: 0x0006431C
		public void PageChange(FormMain.PageSubType ID)
		{
			checked
			{
				if (this.configurationUtils != ID)
				{
					ModAni.ListFactory(ModAni.InsertFactory() + 1);
					this.accountUtils = true;
					try
					{
						switch (ID)
						{
						case FormMain.PageSubType.Default:
							if (Information.IsNothing(ModMain.m_AuthenticationFilter))
							{
								ModMain.m_AuthenticationFilter = new PageSetupLaunch();
							}
							PageSetupLeft.PageChangeRun(ModMain.m_AuthenticationFilter);
							break;
						case FormMain.PageSubType.DownloadInstall:
							if (Information.IsNothing(ModMain.processFilter))
							{
								ModMain.processFilter = new PageSetupUI();
							}
							PageSetupLeft.PageChangeRun(ModMain.processFilter);
							break;
						case FormMain.PageSubType.SetupSystem:
							if (Information.IsNothing(ModMain._ListenerFilter))
							{
								ModMain._ListenerFilter = new PageSetupSystem();
							}
							PageSetupLeft.PageChangeRun(ModMain._ListenerFilter);
							break;
						case FormMain.PageSubType.SetupAccount:
							if (Information.IsNothing(ModMain.m_ImporterFilter))
							{
								ModMain.m_ImporterFilter = new PageSetupAccount();
							}
							PageSetupLeft.PageChangeRun(ModMain.m_ImporterFilter);
							break;
						default:
							throw new Exception("未知的设置子页面种类：" + Conversions.ToString((int)ID));
						}
						this.configurationUtils = ID;
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "切换设置分页面失败（ID " + Conversions.ToString((int)ID) + "）", ModBase.LogLevel.Feedback, "出现错误");
					}
					finally
					{
						ModAni.ListFactory(ModAni.InsertFactory() - 1);
					}
				}
			}
		}

		// Token: 0x06000CA4 RID: 3236 RVA: 0x00066260 File Offset: 0x00064460
		private static void PageChangeRun(FrameworkElement Target)
		{
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Target, null, "Parent", new object[0], null, null, null))))
			{
				Type type = null;
				string memberName = "SetValue";
				object[] array = new object[2];
				array[0] = ContentPresenter.ContentProperty;
				NewLateBinding.LateCall(Target, type, memberName, array, null, null, null, true);
			}
			ModMain.m_GetterFilter.m_ProcDecorator = (FrameworkElement)Target;
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(ModMain.m_GetterFilter.PanMainRight, -ModMain.m_GetterFilter.PanMainRight.Opacity, 0x64, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaCode((PageSetupLeft._Closure$__.$I9-0 == null) ? (PageSetupLeft._Closure$__.$I9-0 = delegate()
				{
					ModMain.m_GetterFilter.PanMainRight.Child = ModMain.m_GetterFilter.m_ProcDecorator;
				}) : PageSetupLeft._Closure$__.$I9-0, 0, true),
				ModAni.AaOpacity(ModMain.m_GetterFilter.PanMainRight, 1.0, 0x96, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false)
			}, "PageSetupLeft PageChange", false);
		}

		// Token: 0x06000CA5 RID: 3237 RVA: 0x0006635C File Offset: 0x0006455C
		public void Reset(object sender, EventArgs e)
		{
			double num = ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null)));
			if (num == 0.0)
			{
				if (ModMain.MyMsgBox("是否要初始化启动页的所有设置？该操作不可撤销。", "初始化确认", "确定", "取消", "", true, true, false) == 1)
				{
					if (Information.IsNothing(ModMain.m_AuthenticationFilter))
					{
						ModMain.m_AuthenticationFilter = new PageSetupLaunch();
					}
					ModMain.m_AuthenticationFilter.Reset();
					return;
				}
			}
			else if (num == 1.0)
			{
				if (ModMain.MyMsgBox("是否要初始化个性化页的所有设置？该操作不可撤销。\r\n（背景图片与音乐、自定义主页等外部文件不会被删除）", "初始化确认", "确定", "取消", "", true, true, false) == 1)
				{
					if (Information.IsNothing(ModMain.processFilter))
					{
						ModMain.processFilter = new PageSetupUI();
					}
					ModMain.processFilter.Reset();
					return;
				}
			}
			else if (num == 2.0 && ModMain.MyMsgBox("是否要初始化启动器页的所有设置？该操作不可撤销。", "初始化确认", "确定", "取消", "", true, true, false) == 1)
			{
				if (Information.IsNothing(ModMain._ListenerFilter))
				{
					ModMain._ListenerFilter = new PageSetupSystem();
				}
				ModMain._ListenerFilter.Reset();
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000CA6 RID: 3238 RVA: 0x00008F79 File Offset: 0x00007179
		// (set) Token: 0x06000CA7 RID: 3239 RVA: 0x00008F81 File Offset: 0x00007181
		internal virtual StackPanel PanItem { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000CA8 RID: 3240 RVA: 0x00008F8A File Offset: 0x0000718A
		// (set) Token: 0x06000CA9 RID: 3241 RVA: 0x00066480 File Offset: 0x00064680
		internal virtual MyListItem ItemLaunch
		{
			[CompilerGenerated]
			get
			{
				return this.predicateUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem myListItem = this.predicateUtils;
				if (myListItem != null)
				{
					myListItem.Check -= value2;
				}
				this.predicateUtils = value;
				myListItem = this.predicateUtils;
				if (myListItem != null)
				{
					myListItem.Check += value2;
				}
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000CAA RID: 3242 RVA: 0x00008F92 File Offset: 0x00007192
		// (set) Token: 0x06000CAB RID: 3243 RVA: 0x000664C4 File Offset: 0x000646C4
		internal virtual MyListItem ItemUI
		{
			[CompilerGenerated]
			get
			{
				return this.m_StructUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem structUtils = this.m_StructUtils;
				if (structUtils != null)
				{
					structUtils.Check -= value2;
				}
				this.m_StructUtils = value;
				structUtils = this.m_StructUtils;
				if (structUtils != null)
				{
					structUtils.Check += value2;
				}
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000CAC RID: 3244 RVA: 0x00008F9A File Offset: 0x0000719A
		// (set) Token: 0x06000CAD RID: 3245 RVA: 0x00066508 File Offset: 0x00064708
		internal virtual MyListItem ItemSystem
		{
			[CompilerGenerated]
			get
			{
				return this.m_ResolverUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem resolverUtils = this.m_ResolverUtils;
				if (resolverUtils != null)
				{
					resolverUtils.Check -= value2;
				}
				this.m_ResolverUtils = value;
				resolverUtils = this.m_ResolverUtils;
				if (resolverUtils != null)
				{
					resolverUtils.Check += value2;
				}
			}
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000CAE RID: 3246 RVA: 0x00008FA2 File Offset: 0x000071A2
		// (set) Token: 0x06000CAF RID: 3247 RVA: 0x0006654C File Offset: 0x0006474C
		internal virtual MyListItem ItemAccount
		{
			[CompilerGenerated]
			get
			{
				return this.m_CollectionUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem collectionUtils = this.m_CollectionUtils;
				if (collectionUtils != null)
				{
					collectionUtils.Check -= value2;
				}
				this.m_CollectionUtils = value;
				collectionUtils = this.m_CollectionUtils;
				if (collectionUtils != null)
				{
					collectionUtils.Check += value2;
				}
			}
		}

		// Token: 0x06000CB0 RID: 3248 RVA: 0x00066590 File Offset: 0x00064790
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.m_TestsUtils)
			{
				this.m_TestsUtils = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagesetup/pagesetupleft.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000CB1 RID: 3249 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000CB2 RID: 3250 RVA: 0x000665C0 File Offset: 0x000647C0
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanItem = (StackPanel)target;
				return;
			}
			if (connectionId == 2)
			{
				this.ItemLaunch = (MyListItem)target;
				return;
			}
			if (connectionId == 3)
			{
				this.ItemUI = (MyListItem)target;
				return;
			}
			if (connectionId == 4)
			{
				this.ItemSystem = (MyListItem)target;
				return;
			}
			if (connectionId == 5)
			{
				this.ItemAccount = (MyListItem)target;
				return;
			}
			this.m_TestsUtils = true;
		}

		// Token: 0x040006C4 RID: 1732
		private bool m_StubUtils;

		// Token: 0x040006C5 RID: 1733
		private bool accountUtils;

		// Token: 0x040006C6 RID: 1734
		public FormMain.PageSubType configurationUtils;

		// Token: 0x040006C7 RID: 1735
		[CompilerGenerated]
		[AccessedThroughProperty("PanItem")]
		private StackPanel interpreterUtils;

		// Token: 0x040006C8 RID: 1736
		[AccessedThroughProperty("ItemLaunch")]
		[CompilerGenerated]
		private MyListItem predicateUtils;

		// Token: 0x040006C9 RID: 1737
		[AccessedThroughProperty("ItemUI")]
		[CompilerGenerated]
		private MyListItem m_StructUtils;

		// Token: 0x040006CA RID: 1738
		[CompilerGenerated]
		[AccessedThroughProperty("ItemSystem")]
		private MyListItem m_ResolverUtils;

		// Token: 0x040006CB RID: 1739
		[AccessedThroughProperty("ItemAccount")]
		[CompilerGenerated]
		private MyListItem m_CollectionUtils;

		// Token: 0x040006CC RID: 1740
		private bool m_TestsUtils;
	}
}
