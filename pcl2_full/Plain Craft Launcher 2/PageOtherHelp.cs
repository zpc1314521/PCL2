using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x02000141 RID: 321
	[DesignerGenerated]
	public class PageOtherHelp : AdornerDecorator, IComponentConnector
	{
		// Token: 0x06000C07 RID: 3079 RVA: 0x000089FD File Offset: 0x00006BFD
		// Note: this type is marked as 'beforefieldinit'.
		static PageOtherHelp()
		{
			PageOtherHelp.modelUtils = new ModLoader.LoaderTask<int, int>("Help List UI Loader", new ModLoader.LoaderTask<int, int>.LoadDelegateSub(PageOtherHelp.HelpListSub), null, ThreadPriority.Normal);
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x00008A1C File Offset: 0x00006C1C
		public PageOtherHelp()
		{
			base.Loaded += this.PageOther_Loaded;
			this._ValUtils = false;
			this.m_ContainerUtils = 1;
			this.InitializeComponent();
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x00008A4A File Offset: 0x00006C4A
		private void PageOther_Loaded(object sender, RoutedEventArgs e)
		{
			this.PanBack.ScrollToHome();
			PageOtherHelp.modelUtils.Start(this.m_ContainerUtils, false);
			if (!this._ValUtils)
			{
				this._ValUtils = true;
				this.Load.State = PageOtherHelp.modelUtils;
			}
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x00008A87 File Offset: 0x00006C87
		private static void HelpListSub(ModLoader.LoaderTask<int, int> Loader)
		{
			ModMain._ReponseFilter.WaitForExit(Loader.Input, null, false);
			ModBase.RunInUi((PageOtherHelp._Closure$__.$I6-0 == null) ? (PageOtherHelp._Closure$__.$I6-0 = delegate()
			{
				ModMain.HelpListLoad(ModMain._ReponseFilter.Output);
			}) : PageOtherHelp._Closure$__.$I6-0, false);
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x00063B18 File Offset: 0x00061D18
		private void Load_State(object sender, MyLoading.MyLoadingState state)
		{
			switch (state)
			{
			case MyLoading.MyLoadingState.Run:
			case MyLoading.MyLoadingState.Error:
				this.PanLoad.Visibility = Visibility.Visible;
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaOpacity(this.PanLoad, 1.0 - this.PanLoad.Opacity, 0x96, 0, null, false),
					ModAni.AaOpacity(this.PanBack, -this.PanBack.Opacity, 0x96, 0, null, false),
					ModAni.AaCode(delegate
					{
						this.PanBack.Visibility = Visibility.Collapsed;
					}, 0, true)
				}, "FrmOtherHelp Load Switch", false);
				return;
			case MyLoading.MyLoadingState.Stop:
				this.PanBack.Visibility = Visibility.Visible;
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaOpacity(this.PanLoad, -this.PanLoad.Opacity, 0x96, 0, null, false),
					ModAni.AaOpacity(this.PanBack, 1.0 - this.PanBack.Opacity, 0x96, 0, null, false),
					ModAni.AaCode(delegate
					{
						this.PanLoad.Visibility = Visibility.Collapsed;
					}, 0, true)
				}, "FrmOtherHelp Load Switch", false);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x00063C54 File Offset: 0x00061E54
		private void Load_Click(object sender, MouseButtonEventArgs e)
		{
			if (PageOtherHelp.modelUtils.State == ModBase.LoadState.Failed)
			{
				ref int ptr = ref this.m_ContainerUtils;
				this.m_ContainerUtils = checked(ptr + 1);
				PageOtherHelp.modelUtils.Start(this.m_ContainerUtils, false);
			}
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x00063C8C File Offset: 0x00061E8C
		public static void OnItemClick(ModMain.HelpEntry Entry)
		{
			try
			{
				if (Entry._InitializerMapper)
				{
					ModEvent.TryStartEvent(Entry.m_PropertyMapper, Entry._WatcherMapper);
				}
				else
				{
					PageOtherHelp.EnterHelpPage(Entry);
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "处理帮助项目点击时发生意外错误", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x06000C0E RID: 3086 RVA: 0x00008AC5 File Offset: 0x00006CC5
		public static void EnterHelpPage(string Location)
		{
			ModBase.RunInThread(delegate
			{
				if (ModMain._ReponseFilter.State != ModBase.LoadState.Finished)
				{
					ModMain._ReponseFilter.WaitForExit(ModBase.GetUuid(), null, false);
				}
				ModMain.HelpEntry Entry = new ModMain.HelpEntry(Location);
				ModBase.RunInUi(delegate()
				{
					PageOtherHelpDetail pageOtherHelpDetail = new PageOtherHelpDetail();
					if (pageOtherHelpDetail.Init(Entry))
					{
						ModMain.m_GetterFilter.PageChange(new FormMain.PageStackData
						{
							_FieldMapper = FormMain.PageType.HelpDetail,
							m_StatusMapper = new object[]
							{
								Entry,
								pageOtherHelpDetail
							}
						}, FormMain.PageSubType.Default);
						return;
					}
					ModBase.Log("[Help] 已取消进入帮助项目，这一般是由于 xaml 初始化失败，且用户在弹窗中手动放弃", ModBase.LogLevel.Debug, "出现错误");
				}, false);
			});
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x00008AE3 File Offset: 0x00006CE3
		public static void EnterHelpPage(ModMain.HelpEntry Entry)
		{
			Action $I1;
			ModBase.RunInThread(delegate
			{
				if (ModMain._ReponseFilter.State != ModBase.LoadState.Finished)
				{
					ModMain._ReponseFilter.WaitForExit(ModBase.GetUuid(), null, false);
				}
				ModBase.RunInUi(($I1 == null) ? ($I1 = delegate()
				{
					PageOtherHelpDetail pageOtherHelpDetail = new PageOtherHelpDetail();
					if (pageOtherHelpDetail.Init(Entry))
					{
						ModMain.m_GetterFilter.PageChange(new FormMain.PageStackData
						{
							_FieldMapper = FormMain.PageType.HelpDetail,
							m_StatusMapper = new object[]
							{
								Entry,
								pageOtherHelpDetail
							}
						}, FormMain.PageSubType.Default);
						return;
					}
					ModBase.Log("[Help] 已取消进入帮助项目，这一般是由于 xaml 初始化失败，且用户在弹窗中手动放弃", ModBase.LogLevel.Debug, "出现错误");
				}) : $I1, false);
			});
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x00063CEC File Offset: 0x00061EEC
		public void SearchRun()
		{
			if (string.IsNullOrWhiteSpace(this.SearchBox.Text))
			{
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaOpacity(this.PanSearch, -this.PanSearch.Opacity, 0x64, 0, null, false),
					ModAni.AaCode(delegate
					{
						this.PanSearch.Height = 0.0;
						this.PanList.Visibility = Visibility.Visible;
					}, 0, true),
					ModAni.AaOpacity(this.PanList, 1.0 - this.PanList.Opacity, 0x96, 0x1E, null, false)
				}, "FrmOtherHelp Search Switch", false);
				return;
			}
			List<ModBase.SearchEntry<ModMain.HelpEntry>> list = new List<ModBase.SearchEntry<ModMain.HelpEntry>>();
			try
			{
				foreach (ModMain.HelpEntry helpEntry in ModMain._ReponseFilter.Output)
				{
					if (helpEntry.m_TokenizerMapper && (ModBase.Val("0") != 50.0 || helpEntry.dispatcherMapper) && helpEntry.m_TokenizerMapper && (ModBase.Val("0") == 50.0 || helpEntry.m_TagMapper))
					{
						list.Add(new ModBase.SearchEntry<ModMain.HelpEntry>
						{
							m_ParamMapper = helpEntry,
							mockMapper = new List<KeyValuePair<string, double>>
							{
								new KeyValuePair<string, double>(helpEntry.Title, 1.0),
								new KeyValuePair<string, double>(helpEntry._CandidateMapper, 0.5),
								new KeyValuePair<string, double>(helpEntry.descriptorMapper, 1.5)
							}
						});
					}
				}
			}
			finally
			{
				List<ModMain.HelpEntry>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			List<ModBase.SearchEntry<ModMain.HelpEntry>> list2 = ModBase.Search<ModMain.HelpEntry>(list, this.SearchBox.Text, 5, 0.08);
			this.PanSearchList.Children.Clear();
			if (list2.Count == 0)
			{
				this.PanSearch.Title = "无搜索结果";
				this.PanSearchList.Visibility = Visibility.Collapsed;
			}
			else
			{
				this.PanSearch.Title = "搜索结果";
				try
				{
					foreach (ModBase.SearchEntry<ModMain.HelpEntry> searchEntry in list2)
					{
						MyListItem myListItem = searchEntry.m_ParamMapper.ToListItem();
						if (ModBase.errorRule)
						{
							myListItem.Info = string.Concat(new string[]
							{
								searchEntry.m_DicMapper ? "完全匹配，" : "",
								"相似度：",
								Conversions.ToString(Math.Round(searchEntry.specificationMapper, 3)),
								"，",
								myListItem.Info
							});
						}
						this.PanSearchList.Children.Add(myListItem);
					}
				}
				finally
				{
					List<ModBase.SearchEntry<ModMain.HelpEntry>>.Enumerator enumerator2;
					((IDisposable)enumerator2).Dispose();
				}
				this.PanSearchList.Visibility = Visibility.Visible;
			}
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.PanList, -this.PanList.Opacity, 0x64, 0, null, false),
				ModAni.AaCode(delegate
				{
					this.PanList.Visibility = Visibility.Collapsed;
					this.PanSearch.Visibility = Visibility.Visible;
					this.PanSearch.TriggerForceResize();
				}, 0, true),
				ModAni.AaOpacity(this.PanSearch, 1.0 - this.PanSearch.Opacity, 0x96, 0x1E, null, false)
			}, "FrmOtherHelp Search Switch", false);
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000C11 RID: 3089 RVA: 0x00008B01 File Offset: 0x00006D01
		// (set) Token: 0x06000C12 RID: 3090 RVA: 0x00008B09 File Offset: 0x00006D09
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000C13 RID: 3091 RVA: 0x00008B12 File Offset: 0x00006D12
		// (set) Token: 0x06000C14 RID: 3092 RVA: 0x00008B1A File Offset: 0x00006D1A
		internal virtual StackPanel PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000C15 RID: 3093 RVA: 0x00008B23 File Offset: 0x00006D23
		// (set) Token: 0x06000C16 RID: 3094 RVA: 0x00064048 File Offset: 0x00062248
		internal virtual MySearchBox SearchBox
		{
			[CompilerGenerated]
			get
			{
				return this.m_UtilsUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MySearchBox.TextChangedEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.SearchRun();
				};
				MySearchBox utilsUtils = this.m_UtilsUtils;
				if (utilsUtils != null)
				{
					utilsUtils.VisitVal(obj);
				}
				this.m_UtilsUtils = value;
				utilsUtils = this.m_UtilsUtils;
				if (utilsUtils != null)
				{
					utilsUtils.MapVal(obj);
				}
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000C17 RID: 3095 RVA: 0x00008B2B File Offset: 0x00006D2B
		// (set) Token: 0x06000C18 RID: 3096 RVA: 0x00008B33 File Offset: 0x00006D33
		internal virtual MyCard PanSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000C19 RID: 3097 RVA: 0x00008B3C File Offset: 0x00006D3C
		// (set) Token: 0x06000C1A RID: 3098 RVA: 0x00008B44 File Offset: 0x00006D44
		internal virtual StackPanel PanSearchList { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000C1B RID: 3099 RVA: 0x00008B4D File Offset: 0x00006D4D
		// (set) Token: 0x06000C1C RID: 3100 RVA: 0x00008B55 File Offset: 0x00006D55
		internal virtual StackPanel PanList { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000C1D RID: 3101 RVA: 0x00008B5E File Offset: 0x00006D5E
		// (set) Token: 0x06000C1E RID: 3102 RVA: 0x00008B66 File Offset: 0x00006D66
		internal virtual MyCard PanLoad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000C1F RID: 3103 RVA: 0x00008B6F File Offset: 0x00006D6F
		// (set) Token: 0x06000C20 RID: 3104 RVA: 0x0006408C File Offset: 0x0006228C
		internal virtual MyLoading Load
		{
			[CompilerGenerated]
			get
			{
				return this.algoUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyLoading.StateChangedEventHandler obj = new MyLoading.StateChangedEventHandler(this.Load_State);
				MyLoading.ClickEventHandler obj2 = new MyLoading.ClickEventHandler(this.Load_Click);
				MyLoading myLoading = this.algoUtils;
				if (myLoading != null)
				{
					myLoading.InitVal(obj);
					myLoading.UpdateVal(obj2);
				}
				this.algoUtils = value;
				myLoading = this.algoUtils;
				if (myLoading != null)
				{
					myLoading.FillVal(obj);
					myLoading.PrepareVal(obj2);
				}
			}
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x000640EC File Offset: 0x000622EC
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this._MapperUtils)
			{
				this._MapperUtils = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pageother/pageotherhelp.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000C23 RID: 3107 RVA: 0x0006411C File Offset: 0x0006231C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
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
				this.SearchBox = (MySearchBox)target;
				return;
			}
			if (connectionId == 4)
			{
				this.PanSearch = (MyCard)target;
				return;
			}
			if (connectionId == 5)
			{
				this.PanSearchList = (StackPanel)target;
				return;
			}
			if (connectionId == 6)
			{
				this.PanList = (StackPanel)target;
				return;
			}
			if (connectionId == 7)
			{
				this.PanLoad = (MyCard)target;
				return;
			}
			if (connectionId == 8)
			{
				this.Load = (MyLoading)target;
				return;
			}
			this._MapperUtils = true;
		}

		// Token: 0x0400068D RID: 1677
		private bool _ValUtils;

		// Token: 0x0400068E RID: 1678
		public int m_ContainerUtils;

		// Token: 0x0400068F RID: 1679
		public static ModLoader.LoaderTask<int, int> modelUtils;

		// Token: 0x04000690 RID: 1680
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private MyScrollViewer iteratorUtils;

		// Token: 0x04000691 RID: 1681
		[AccessedThroughProperty("PanMain")]
		[CompilerGenerated]
		private StackPanel m_ExpressionUtils;

		// Token: 0x04000692 RID: 1682
		[CompilerGenerated]
		[AccessedThroughProperty("SearchBox")]
		private MySearchBox m_UtilsUtils;

		// Token: 0x04000693 RID: 1683
		[AccessedThroughProperty("PanSearch")]
		[CompilerGenerated]
		private MyCard m_BaseUtils;

		// Token: 0x04000694 RID: 1684
		[CompilerGenerated]
		[AccessedThroughProperty("PanSearchList")]
		private StackPanel decoratorUtils;

		// Token: 0x04000695 RID: 1685
		[CompilerGenerated]
		[AccessedThroughProperty("PanList")]
		private StackPanel m_FilterUtils;

		// Token: 0x04000696 RID: 1686
		[AccessedThroughProperty("PanLoad")]
		[CompilerGenerated]
		private MyCard _RuleUtils;

		// Token: 0x04000697 RID: 1687
		[AccessedThroughProperty("Load")]
		[CompilerGenerated]
		private MyLoading algoUtils;

		// Token: 0x04000698 RID: 1688
		private bool _MapperUtils;
	}
}
