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
	// Token: 0x020000AC RID: 172
	[DesignerGenerated]
	public class PageVersionLeft : MyPageLeft, IComponentConnector
	{
		// Token: 0x0600061F RID: 1567 RVA: 0x00005A0F File Offset: 0x00003C0F
		public PageVersionLeft()
		{
			base.Loaded += this.PageVersionLeft_Loaded;
			this.m_ServiceModel = FormMain.PageSubType.Default;
			this.InitializeComponent();
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x0002F39C File Offset: 0x0002D59C
		private void PageVersionLeft_Loaded(object sender, RoutedEventArgs e)
		{
			if (PageVersionLeft.m_OrderModel != null && PageVersionLeft.m_OrderModel.Version.LoginUtils())
			{
				this.ItemMod.Visibility = Visibility.Visible;
				this.ItemModDisabled.Visibility = Visibility.Collapsed;
				return;
			}
			this.ItemMod.Visibility = Visibility.Collapsed;
			this.ItemModDisabled.Visibility = Visibility.Visible;
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00005A36 File Offset: 0x00003C36
		private void PageCheck(MyListItem sender, ModBase.RouteEventArgs e)
		{
			if (sender.Tag != null)
			{
				this.PageChange(checked((FormMain.PageSubType)Math.Round(ModBase.Val(RuntimeHelpers.GetObjectValue(sender.Tag)))));
			}
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x0002F3F4 File Offset: 0x0002D5F4
		public object PageGet(FormMain.PageSubType ID = (FormMain.PageSubType)(-1))
		{
			if (ID == (FormMain.PageSubType)(-1))
			{
				ID = this.m_ServiceModel;
			}
			object result;
			switch (ID)
			{
			case FormMain.PageSubType.Default:
				if (ModMain._ExceptionFilter == null)
				{
					ModMain._ExceptionFilter = new PageVersionOverall();
				}
				result = ModMain._ExceptionFilter;
				break;
			case FormMain.PageSubType.DownloadInstall:
				if (Information.IsNothing(ModMain._ServerFilter))
				{
					ModMain._ServerFilter = new PageVersionSetup();
				}
				result = ModMain._ServerFilter;
				break;
			case FormMain.PageSubType.SetupSystem:
				if (ModMain.m_RulesFilter == null)
				{
					ModMain.m_RulesFilter = new PageVersionMod();
				}
				result = ModMain.m_RulesFilter;
				break;
			case FormMain.PageSubType.SetupAccount:
				if (ModMain.m_ClassFilter == null)
				{
					ModMain.m_ClassFilter = new PageVersionModDisabled();
				}
				result = ModMain.m_ClassFilter;
				break;
			default:
				throw new Exception("未知的版本设置子页面种类：" + Conversions.ToString((int)ID));
			}
			return result;
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x0002F4A4 File Offset: 0x0002D6A4
		public void PageChange(FormMain.PageSubType ID)
		{
			checked
			{
				if (this.m_ServiceModel != ID)
				{
					ModAni.ListFactory(ModAni.InsertFactory() + 1);
					try
					{
						switch (ID)
						{
						case FormMain.PageSubType.Default:
							if (Information.IsNothing(ModMain._ExceptionFilter))
							{
								ModMain._ExceptionFilter = new PageVersionOverall();
							}
							this.PageChangeRun(ModMain._ExceptionFilter);
							break;
						case FormMain.PageSubType.DownloadInstall:
							if (Information.IsNothing(ModMain._ServerFilter))
							{
								ModMain._ServerFilter = new PageVersionSetup();
							}
							this.PageChangeRun(ModMain._ServerFilter);
							break;
						case FormMain.PageSubType.SetupSystem:
							if (Information.IsNothing(ModMain.m_RulesFilter))
							{
								ModMain.m_RulesFilter = new PageVersionMod();
							}
							this.PageChangeRun(ModMain.m_RulesFilter);
							break;
						case FormMain.PageSubType.SetupAccount:
							if (Information.IsNothing(ModMain.m_ClassFilter))
							{
								ModMain.m_ClassFilter = new PageVersionModDisabled();
							}
							this.PageChangeRun(ModMain.m_ClassFilter);
							break;
						default:
							throw new Exception("未知的版本设置子页面种类：" + Conversions.ToString((int)ID));
						}
						this.m_ServiceModel = ID;
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

		// Token: 0x06000624 RID: 1572 RVA: 0x0002F5E4 File Offset: 0x0002D7E4
		private void PageChangeRun(FrameworkElement Target)
		{
			if (!Information.IsNothing(Target.Parent))
			{
				Target.SetValue(ContentPresenter.ContentProperty, null);
			}
			ModMain.m_GetterFilter.m_ProcDecorator = Target;
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(ModMain.m_GetterFilter.PanMainRight, -ModMain.m_GetterFilter.PanMainRight.Opacity, 0x64, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaCode((PageVersionLeft._Closure$__.$I7-0 == null) ? (PageVersionLeft._Closure$__.$I7-0 = delegate()
				{
					ModMain.m_GetterFilter.PanMainRight.Child = ModMain.m_GetterFilter.m_ProcDecorator;
				}) : PageVersionLeft._Closure$__.$I7-0, 0, true),
				ModAni.AaOpacity(ModMain.m_GetterFilter.PanMainRight, 1.0, 0x96, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false)
			}, "PageVersionLeft PageChange", false);
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x00005A5C File Offset: 0x00003C5C
		public void Refresh(object sender, EventArgs e)
		{
			if (ModMain.m_RulesFilter != null)
			{
				ModMain.m_RulesFilter.RefreshList(true);
			}
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0002F6B4 File Offset: 0x0002D8B4
		public void Reset(object sender, EventArgs e)
		{
			if (ModMain.MyMsgBox("是否要初始化该版本的版本独立设置？该操作不可撤销。", "初始化确认", "确定", "取消", "", true, true, false) == 1)
			{
				if (Information.IsNothing(ModMain._ServerFilter))
				{
					ModMain._ServerFilter = new PageVersionSetup();
				}
				ModMain._ServerFilter.Reset();
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000627 RID: 1575 RVA: 0x00005A70 File Offset: 0x00003C70
		// (set) Token: 0x06000628 RID: 1576 RVA: 0x00005A78 File Offset: 0x00003C78
		internal virtual StackPanel PanItem { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000629 RID: 1577 RVA: 0x00005A81 File Offset: 0x00003C81
		// (set) Token: 0x0600062A RID: 1578 RVA: 0x0002F708 File Offset: 0x0002D908
		internal virtual MyListItem ItemOverall
		{
			[CompilerGenerated]
			get
			{
				return this.m_CodeModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem codeModel = this.m_CodeModel;
				if (codeModel != null)
				{
					codeModel.Check -= value2;
				}
				this.m_CodeModel = value;
				codeModel = this.m_CodeModel;
				if (codeModel != null)
				{
					codeModel.Check += value2;
				}
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600062B RID: 1579 RVA: 0x00005A89 File Offset: 0x00003C89
		// (set) Token: 0x0600062C RID: 1580 RVA: 0x0002F74C File Offset: 0x0002D94C
		internal virtual MyListItem ItemSetup
		{
			[CompilerGenerated]
			get
			{
				return this.m_MappingModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem mappingModel = this.m_MappingModel;
				if (mappingModel != null)
				{
					mappingModel.Check -= value2;
				}
				this.m_MappingModel = value;
				mappingModel = this.m_MappingModel;
				if (mappingModel != null)
				{
					mappingModel.Check += value2;
				}
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600062D RID: 1581 RVA: 0x00005A91 File Offset: 0x00003C91
		// (set) Token: 0x0600062E RID: 1582 RVA: 0x0002F790 File Offset: 0x0002D990
		internal virtual MyListItem ItemMod
		{
			[CompilerGenerated]
			get
			{
				return this.m_BridgeModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem bridgeModel = this.m_BridgeModel;
				if (bridgeModel != null)
				{
					bridgeModel.Check -= value2;
				}
				this.m_BridgeModel = value;
				bridgeModel = this.m_BridgeModel;
				if (bridgeModel != null)
				{
					bridgeModel.Check += value2;
				}
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x0600062F RID: 1583 RVA: 0x00005A99 File Offset: 0x00003C99
		// (set) Token: 0x06000630 RID: 1584 RVA: 0x0002F7D4 File Offset: 0x0002D9D4
		internal virtual MyListItem ItemModDisabled
		{
			[CompilerGenerated]
			get
			{
				return this.singletonModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem myListItem = this.singletonModel;
				if (myListItem != null)
				{
					myListItem.Check -= value2;
				}
				this.singletonModel = value;
				myListItem = this.singletonModel;
				if (myListItem != null)
				{
					myListItem.Check += value2;
				}
			}
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0002F818 File Offset: 0x0002DA18
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.errorModel)
			{
				this.errorModel = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pageversion/pageversionleft.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0002F848 File Offset: 0x0002DA48
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
				this.ItemOverall = (MyListItem)target;
				return;
			}
			if (connectionId == 3)
			{
				this.ItemSetup = (MyListItem)target;
				return;
			}
			if (connectionId == 4)
			{
				this.ItemMod = (MyListItem)target;
				return;
			}
			if (connectionId == 5)
			{
				this.ItemModDisabled = (MyListItem)target;
				return;
			}
			this.errorModel = true;
		}

		// Token: 0x040002EF RID: 751
		public static ModMinecraft.McVersion m_OrderModel;

		// Token: 0x040002F0 RID: 752
		public FormMain.PageSubType m_ServiceModel;

		// Token: 0x040002F1 RID: 753
		[CompilerGenerated]
		[AccessedThroughProperty("PanItem")]
		private StackPanel facadeModel;

		// Token: 0x040002F2 RID: 754
		[CompilerGenerated]
		[AccessedThroughProperty("ItemOverall")]
		private MyListItem m_CodeModel;

		// Token: 0x040002F3 RID: 755
		[CompilerGenerated]
		[AccessedThroughProperty("ItemSetup")]
		private MyListItem m_MappingModel;

		// Token: 0x040002F4 RID: 756
		[AccessedThroughProperty("ItemMod")]
		[CompilerGenerated]
		private MyListItem m_BridgeModel;

		// Token: 0x040002F5 RID: 757
		[AccessedThroughProperty("ItemModDisabled")]
		[CompilerGenerated]
		private MyListItem singletonModel;

		// Token: 0x040002F6 RID: 758
		private bool errorModel;
	}
}
