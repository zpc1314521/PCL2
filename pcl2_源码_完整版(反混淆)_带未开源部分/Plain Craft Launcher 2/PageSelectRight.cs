using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x0200012D RID: 301
	[DesignerGenerated]
	public class PageSelectRight : AdornerDecorator, IComponentConnector
	{
		// Token: 0x06000AC8 RID: 2760 RVA: 0x0005B7D0 File Offset: 0x000599D0
		public PageSelectRight()
		{
			base.Loaded += this.PageSelectRight_Loaded;
			this._ErrorExpression = false;
			this.objectExpression = false;
			this.callbackExpression = true;
			this.m_WorkerExpression = new Queue<PageSelectRight.LoadPageStates>();
			this.visitorExpression = PageSelectRight.LoadPageStates.Loaded;
			this.InitializeComponent();
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x0005B824 File Offset: 0x00059A24
		private void PageSelectRight_Loaded(object sender, RoutedEventArgs e)
		{
			if (!this._ErrorExpression)
			{
				ModMinecraft._TestsIterator.Start(ModBase.GetUuid(), false);
			}
			else
			{
				ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.RunOnUpdated, 1, "versions\\", false);
			}
			while (this.m_WorkerExpression.Count > 0)
			{
				this.RateModel(this.m_WorkerExpression.Dequeue());
			}
			this.PanBack.ScrollToHome();
			if (!this._ErrorExpression)
			{
				this._ErrorExpression = true;
				this.Load.State.LoadingState = MyLoading.MyLoadingState.Run;
			}
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x00007F9A File Offset: 0x0000619A
		public PageSelectRight.LoadPageStates FindModel()
		{
			return this.visitorExpression;
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x0005B8B0 File Offset: 0x00059AB0
		public void RateModel(PageSelectRight.LoadPageStates value)
		{
			if (!base.IsLoaded)
			{
				this.m_WorkerExpression.Enqueue(value);
				return;
			}
			if (this.visitorExpression != value)
			{
				if (ModMain.contextFilter != null)
				{
					switch (value)
					{
					case PageSelectRight.LoadPageStates.Loading:
						if (this.visitorExpression == PageSelectRight.LoadPageStates.Loaded)
						{
							this.PanLoad.IsHitTestVisible = true;
							this.PanBack.IsHitTestVisible = false;
							this.callbackExpression = false;
							ModAni.AniStart(new ModAni.AniData[]
							{
								ModAni.AaOpacity(this.PanMain, -this.PanMain.Opacity, 0x64, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
								ModAni.AaCode(delegate
								{
									this.PanMain.Visibility = Visibility.Collapsed;
								}, 0, true)
							}, "Load VersionList - PanMain", false);
							ModAni.AniStart(new ModAni.AniData[]
							{
								ModAni.AaCode(delegate
								{
									this.callbackExpression = true;
								}, 0x5A, false),
								ModAni.AaCode(delegate
								{
									this.Load.State.LoadingState = MyLoading.MyLoadingState.Run;
									this.callbackExpression = false;
								}, 0x6E, false),
								ModAni.AaOpacity(this.PanLoad, 1.0 - this.PanLoad.Opacity, 0x6E, 0x6E, null, false),
								ModAni.AaCode(delegate
								{
									this.callbackExpression = true;
								}, 0xFA, false)
							}, "Load VersionList - PanLoad", false);
						}
						else
						{
							this.PanLoad.IsHitTestVisible = true;
							this.PanBack.IsHitTestVisible = false;
							this.callbackExpression = false;
							ModAni.AniStart(new ModAni.AniData[]
							{
								ModAni.AaOpacity(this.PanLoad, -this.PanLoad.Opacity, 0x64, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
								ModAni.AaCode(delegate
								{
									this.callbackExpression = true;
									this.Load.Opacity = 1.0;
									this.PanEmpty.Opacity = 0.0;
									this.PanEmpty.Visibility = Visibility.Collapsed;
									this.PanLoad.TriggerForceResize();
								}, 0x64, false),
								ModAni.AaCode(delegate
								{
									this.callbackExpression = false;
									this.Load.State.LoadingState = MyLoading.MyLoadingState.Run;
								}, 0x78, false),
								ModAni.AaOpacity(this.PanLoad, 1.0, 0x6E, 0x78, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
								ModAni.AaCode(delegate
								{
									this.callbackExpression = true;
								}, 0xFA, false)
							}, "Load VersionList - PanLoad", false);
						}
						break;
					case PageSelectRight.LoadPageStates.Loaded:
						this.PanLoad.IsHitTestVisible = false;
						this.PanBack.IsHitTestVisible = true;
						this.PanMain.Visibility = Visibility.Visible;
						this.PanBack.ScrollToHome();
						if (this.PanLoad.Opacity > 0.001)
						{
							ModAni.AniStart(ModAni.AaOpacity(this.PanMain, 1.0 - this.PanMain.Opacity, 0x96, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false), "Load VersionList - PanMain", false);
							ModAni.AniStart(new ModAni.AniData[]
							{
								ModAni.AaOpacity(this.PanLoad, -this.PanLoad.Opacity, 0x64, 0, null, false),
								ModAni.AaCode(delegate
								{
									this.Load.State.LoadingState = MyLoading.MyLoadingState.Stop;
								}, 0x96, false)
							}, "Load VersionList - PanLoad", false);
						}
						else
						{
							ModAni.AniStop("Load VersionList - PanLoad");
							ModAni.AniStart(ModAni.AaOpacity(this.PanMain, 1.0 - this.PanMain.Opacity, 0x96, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false), "Load VersionList - PanMain", false);
							this.Load.State.LoadingState = MyLoading.MyLoadingState.Stop;
						}
						break;
					case PageSelectRight.LoadPageStates.Empty:
						this.PanEmpty.Visibility = Visibility.Visible;
						this.PanLoad.TriggerForceResize();
						this.PanLoad.IsHitTestVisible = true;
						this.PanBack.IsHitTestVisible = false;
						if (this.PanLoad.Opacity < 0.01)
						{
							this.Load.Opacity = 0.0;
							this.PanEmpty.Opacity = 1.0;
						}
						else
						{
							ModAni.AniStart(new ModAni.AniData[]
							{
								ModAni.AaOpacity(this.Load, -this.Load.Opacity, 0x50, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
								ModAni.AaOpacity(this.PanEmpty, 1.0 - this.PanEmpty.Opacity, 0x50, 0x46, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false)
							}, "Load VersionList - Empty", false);
						}
						if (this.objectExpression)
						{
							this.LabEmptyTitle.Text = "无隐藏版本";
							this.LabEmptyContent.Text = "没有版本被隐藏，你可以在版本设置的版本分类选项中隐藏版本。\r\n再次按下 F11 即可退出隐藏版本查看模式。";
							this.BtnEmptyDownload.Visibility = Visibility.Collapsed;
						}
						else
						{
							this.LabEmptyTitle.Text = "无可用版本";
							this.LabEmptyContent.Text = "未找到任何版本的游戏，请先下载任意版本的游戏。\r\n若有已存在的游戏，请在左边的列表中选择添加文件夹，选择 .minecraft 文件夹将其导入。";
							this.BtnEmptyDownload.Visibility = (Conversions.ToBoolean(Conversions.ToBoolean(ModBase._BaseRule.Get("UiHiddenPageDownload", null)) && !PageSetupUI.WriteModel()) ? Visibility.Collapsed : Visibility.Visible);
						}
						break;
					}
				}
				this.visitorExpression = value;
			}
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x0005BD90 File Offset: 0x00059F90
		public void DeleteVersion(MyListItem Item, ModMinecraft.McVersion Version)
		{
			try
			{
				bool flag = Version.m_HelperAlgo != ModMinecraft.McVersionState.Error && Operators.CompareString(Version.ManageExpression(), ModMinecraft.m_ResolverIterator, true) != 0;
				if (ModMain.MyMsgBox("你确定要删除版本 " + Version.Name + " 吗？该操作不可撤销！" + (flag ? "\r\n由于该版本开启了版本隔离，删除版本时该版本对应的存档、资源包、Mod 等文件也将被一并删除！" : ""), "删除版本", "确定", "取消", "", true, true, false) != 2)
				{
					ModBase.DeleteDirectory(Version.Path, false);
					ModMain.Hint("版本 " + Version.Name + " 已删除！", ModMain.HintType.Finish, true);
					if (Version.producerAlgo != ModMinecraft.McVersionCardType.Hidden && Version.m_QueueAlgo)
					{
						ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", false);
					}
					else
					{
						StackPanel stackPanel = (StackPanel)Item.Parent;
						if (stackPanel.Children.Count > 2)
						{
							MyCard myCard = (MyCard)stackPanel.Parent;
							myCard.Title = checked(myCard.Title.Replace(Conversions.ToString(stackPanel.Children.Count - 1), Conversions.ToString(stackPanel.Children.Count - 2)));
							stackPanel.Children.Remove(Item);
							if (ModMinecraft.ValidateContainer() != null && Operators.CompareString(Version.Path, ModMinecraft.ValidateContainer().Path, true) == 0)
							{
								ModMinecraft.CancelContainer((ModMinecraft.McVersion)((MyListItem)stackPanel.Children[0]).Tag);
							}
							ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.UpdateOnly, 1, "versions\\", false);
						}
						else
						{
							ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", false);
						}
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "删除版本 " + Version.Name + " 失败", ModBase.LogLevel.Msgbox, "出现错误");
			}
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x0005BF84 File Offset: 0x0005A184
		public void Item_Click(MyListItem sender, EventArgs e)
		{
			ModMinecraft.McVersion mcVersion = (ModMinecraft.McVersion)sender.Tag;
			if (new ModMinecraft.McVersion(mcVersion.Path).Check())
			{
				ModMinecraft.CancelContainer(mcVersion);
				ModBase._BaseRule.Set("LaunchVersionSelect", ModMinecraft.ValidateContainer().Name, false, null);
				ModMain.m_GetterFilter.PageBack();
				return;
			}
			PageVersionOverall.OpenVersionFolder(mcVersion);
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x00005CE4 File Offset: 0x00003EE4
		private void BtnDownload_Click(object sender, EventArgs e)
		{
			ModMain.m_GetterFilter.PageChange(FormMain.PageType.Download, FormMain.PageSubType.DownloadInstall);
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x0005BFE4 File Offset: 0x0005A1E4
		public void BtnEmptyDownload_Loaded()
		{
			Visibility visibility = Conversions.ToBoolean((Conversions.ToBoolean(ModBase._BaseRule.Get("UiHiddenPageDownload", null)) && !PageSetupUI.WriteModel()) || this.objectExpression) ? Visibility.Collapsed : Visibility.Visible;
			if (this.BtnEmptyDownload.Visibility != visibility)
			{
				this.BtnEmptyDownload.Visibility = visibility;
				this.PanLoad.TriggerForceResize();
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000AD0 RID: 2768 RVA: 0x00007FA2 File Offset: 0x000061A2
		// (set) Token: 0x06000AD1 RID: 2769 RVA: 0x00007FAA File Offset: 0x000061AA
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000AD2 RID: 2770 RVA: 0x00007FB3 File Offset: 0x000061B3
		// (set) Token: 0x06000AD3 RID: 2771 RVA: 0x00007FBB File Offset: 0x000061BB
		internal virtual VirtualizingStackPanel PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000AD4 RID: 2772 RVA: 0x00007FC4 File Offset: 0x000061C4
		// (set) Token: 0x06000AD5 RID: 2773 RVA: 0x00007FCC File Offset: 0x000061CC
		internal virtual MyCard PanLoad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000AD6 RID: 2774 RVA: 0x00007FD5 File Offset: 0x000061D5
		// (set) Token: 0x06000AD7 RID: 2775 RVA: 0x00007FDD File Offset: 0x000061DD
		internal virtual MyLoading Load { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000AD8 RID: 2776 RVA: 0x00007FE6 File Offset: 0x000061E6
		// (set) Token: 0x06000AD9 RID: 2777 RVA: 0x00007FEE File Offset: 0x000061EE
		internal virtual StackPanel PanEmpty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000ADA RID: 2778 RVA: 0x00007FF7 File Offset: 0x000061F7
		// (set) Token: 0x06000ADB RID: 2779 RVA: 0x00007FFF File Offset: 0x000061FF
		internal virtual TextBlock LabEmptyTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000ADC RID: 2780 RVA: 0x00008008 File Offset: 0x00006208
		// (set) Token: 0x06000ADD RID: 2781 RVA: 0x00008010 File Offset: 0x00006210
		internal virtual TextBlock LabEmptyContent { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000ADE RID: 2782 RVA: 0x00008019 File Offset: 0x00006219
		// (set) Token: 0x06000ADF RID: 2783 RVA: 0x0005C050 File Offset: 0x0005A250
		internal virtual MyButton BtnEmptyDownload
		{
			[CompilerGenerated]
			get
			{
				return this.m_SerializerExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnDownload_Click);
				RoutedEventHandler value2 = delegate(object sender, RoutedEventArgs e)
				{
					this.BtnEmptyDownload_Loaded();
				};
				MyButton serializerExpression = this.m_SerializerExpression;
				if (serializerExpression != null)
				{
					serializerExpression.CancelModel(obj);
					serializerExpression.Loaded -= value2;
				}
				this.m_SerializerExpression = value;
				serializerExpression = this.m_SerializerExpression;
				if (serializerExpression != null)
				{
					serializerExpression.ValidateModel(obj);
					serializerExpression.Loaded += value2;
				}
			}
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x0005C0B0 File Offset: 0x0005A2B0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.infoExpression)
			{
				this.infoExpression = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pageselectright.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x0005C0E0 File Offset: 0x0005A2E0
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
				this.PanMain = (VirtualizingStackPanel)target;
				return;
			}
			if (connectionId == 3)
			{
				this.PanLoad = (MyCard)target;
				return;
			}
			if (connectionId == 4)
			{
				this.Load = (MyLoading)target;
				return;
			}
			if (connectionId == 5)
			{
				this.PanEmpty = (StackPanel)target;
				return;
			}
			if (connectionId == 6)
			{
				this.LabEmptyTitle = (TextBlock)target;
				return;
			}
			if (connectionId == 7)
			{
				this.LabEmptyContent = (TextBlock)target;
				return;
			}
			if (connectionId == 8)
			{
				this.BtnEmptyDownload = (MyButton)target;
				return;
			}
			this.infoExpression = true;
		}

		// Token: 0x040005E7 RID: 1511
		private bool _ErrorExpression;

		// Token: 0x040005E8 RID: 1512
		public bool objectExpression;

		// Token: 0x040005E9 RID: 1513
		public bool callbackExpression;

		// Token: 0x040005EA RID: 1514
		private Queue<PageSelectRight.LoadPageStates> m_WorkerExpression;

		// Token: 0x040005EB RID: 1515
		private PageSelectRight.LoadPageStates visitorExpression;

		// Token: 0x040005EC RID: 1516
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private MyScrollViewer m_IndexerExpression;

		// Token: 0x040005ED RID: 1517
		[AccessedThroughProperty("PanMain")]
		[CompilerGenerated]
		private VirtualizingStackPanel m_MethodExpression;

		// Token: 0x040005EE RID: 1518
		[AccessedThroughProperty("PanLoad")]
		[CompilerGenerated]
		private MyCard m_DatabaseExpression;

		// Token: 0x040005EF RID: 1519
		[CompilerGenerated]
		[AccessedThroughProperty("Load")]
		private MyLoading _AttrExpression;

		// Token: 0x040005F0 RID: 1520
		[AccessedThroughProperty("PanEmpty")]
		[CompilerGenerated]
		private StackPanel threadExpression;

		// Token: 0x040005F1 RID: 1521
		[AccessedThroughProperty("LabEmptyTitle")]
		[CompilerGenerated]
		private TextBlock m_ManagerExpression;

		// Token: 0x040005F2 RID: 1522
		[AccessedThroughProperty("LabEmptyContent")]
		[CompilerGenerated]
		private TextBlock m_ItemExpression;

		// Token: 0x040005F3 RID: 1523
		[CompilerGenerated]
		[AccessedThroughProperty("BtnEmptyDownload")]
		private MyButton m_SerializerExpression;

		// Token: 0x040005F4 RID: 1524
		private bool infoExpression;

		// Token: 0x0200012E RID: 302
		public enum LoadPageStates
		{
			// Token: 0x040005F6 RID: 1526
			Loading,
			// Token: 0x040005F7 RID: 1527
			Loaded,
			// Token: 0x040005F8 RID: 1528
			Empty
		}
	}
}
