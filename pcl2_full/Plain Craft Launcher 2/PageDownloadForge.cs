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
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace PCL
{
	// Token: 0x0200011A RID: 282
	[DesignerGenerated]
	public class PageDownloadForge : AdornerDecorator, IComponentConnector
	{
		// Token: 0x06000966 RID: 2406 RVA: 0x00007253 File Offset: 0x00005453
		public PageDownloadForge()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.Init();
			};
			this._EventIterator = false;
			this._PrinterIterator = 1;
			this.InitializeComponent();
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x00007281 File Offset: 0x00005481
		private void Init()
		{
			this.PanBack.ScrollToHome();
			ModDownload.facadeIterator.Start(this._PrinterIterator, false);
			if (!this._EventIterator)
			{
				this._EventIterator = true;
				this.Load.State = ModDownload.facadeIterator;
			}
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x000546FC File Offset: 0x000528FC
		public static void RefreshLoader()
		{
			if (ModMain.m_PageFilter != null)
			{
				PageDownloadForge pageFilter = ModMain.m_PageFilter;
				ref int ptr = ref pageFilter._PrinterIterator;
				pageFilter._PrinterIterator = checked(ptr + 1);
				ModDownload.facadeIterator.Start(ModMain.m_PageFilter._PrinterIterator, false);
				return;
			}
			ModDownload.facadeIterator.Start(ModBase.GetUuid(), false);
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x000072BE File Offset: 0x000054BE
		private void Load_Click(object sender, MouseButtonEventArgs e)
		{
			if (this.Load.State.LoadingState == MyLoading.MyLoadingState.Error)
			{
				PageDownloadForge.RefreshLoader();
			}
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x00054748 File Offset: 0x00052948
		private void Load_State(object sender, MyLoading.MyLoadingState state)
		{
			ModBase.LoadState state2 = ModDownload.facadeIterator.State;
			if (state2 == ModBase.LoadState.Loading)
			{
				this.Load_OnStart();
				return;
			}
			if (state2 != ModBase.LoadState.Finished)
			{
				return;
			}
			this.Load_OnFinish();
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x00054778 File Offset: 0x00052978
		private void Load_OnStart()
		{
			this.PanLoad.Visibility = Visibility.Visible;
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.PanLoad, 1.0 - this.PanLoad.Opacity, 0x96, 0, null, false),
				ModAni.AaOpacity(this.PanBack, -this.PanBack.Opacity, 0x96, 0, null, false),
				ModAni.AaCode(delegate
				{
					this.PanBack.Visibility = Visibility.Collapsed;
					this.PanMain.Children.Clear();
				}, 0, true)
			}, "FrmDownloadForge Load Switch", false);
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x00054814 File Offset: 0x00052A14
		private void Load_OnFinish()
		{
			try
			{
				List<string> list = ModBase.Sort<string>(ModDownload.facadeIterator.Output.Value, (PageDownloadForge._Closure$__.$IR8-2 == null) ? (PageDownloadForge._Closure$__.$IR8-2 = ((object a0, object a1) => ModMinecraft.VersionSortBoolean(Conversions.ToString(a0), Conversions.ToString(a1)))) : PageDownloadForge._Closure$__.$IR8-2);
				this.PanMain.Children.Clear();
				try
				{
					foreach (string text in list)
					{
						MyCard myCard = new MyCard();
						myCard.Title = text.Replace("_p", " P");
						myCard.Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
						myCard.InitFactory(5);
						MyCard myCard2 = myCard;
						StackPanel stackPanel = new StackPanel
						{
							Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
							VerticalAlignment = VerticalAlignment.Top,
							RenderTransform = new TranslateTransform(0.0, 0.0),
							Tag = text
						};
						myCard2.Children.Add(stackPanel);
						myCard2.thread = stackPanel;
						myCard2.IsSwaped = true;
						this.PanMain.Children.Add(myCard2);
					}
				}
				finally
				{
					List<string>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "可视化版本列表出错", ModBase.LogLevel.Feedback, "出现错误");
			}
			this.PanBack.Visibility = Visibility.Visible;
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.PanLoad, -this.PanLoad.Opacity, 0x96, 0, null, false),
				ModAni.AaOpacity(this.PanBack, 1.0 - this.PanBack.Opacity, 0x96, 0, null, false),
				ModAni.AaCode(delegate
				{
					this.PanLoad.Visibility = Visibility.Collapsed;
				}, 0, true)
			}, "FrmDownloadForge Load Switch", false);
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x000072D8 File Offset: 0x000054D8
		public void Forge_Click(MyLoading sender, MouseButtonEventArgs e)
		{
			if (sender.State.LoadingState == MyLoading.MyLoadingState.Error)
			{
				((ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>)sender.State).Start(Conversions.ToString(ModBase.GetUuid()), false);
			}
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x00054A60 File Offset: 0x00052C60
		public void Forge_StateChanged(MyLoading sender, MyLoading.MyLoadingState newState)
		{
			if (newState == MyLoading.MyLoadingState.Stop)
			{
				MyCard myCard = (MyCard)((FrameworkElement)sender.Parent).Parent;
				ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = (ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>)sender.State;
				NewLateBinding.LateCall(NewLateBinding.LateGet(myCard.thread, null, "Children", new object[0], null, null, null), null, "Clear", new object[0], null, null, null, true);
				NewLateBinding.LateSet(myCard.thread, null, "Tag", new object[]
				{
					loaderTask.Output
				}, null, null);
				myCard.InitFactory(6);
				myCard.StackInstall();
			}
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x00007303 File Offset: 0x00005503
		public void DownloadStart(MyListItem sender, object e)
		{
			ModDownloadLib.McDownloadForge((ModDownload.DlForgeVersionEntry)sender.Tag);
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x00007315 File Offset: 0x00005515
		private void BtnWeb_Click(object sender, EventArgs e)
		{
			ModBase.OpenWebsite("https://files.minecraftforge.net");
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000971 RID: 2417 RVA: 0x00007321 File Offset: 0x00005521
		// (set) Token: 0x06000972 RID: 2418 RVA: 0x00007329 File Offset: 0x00005529
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000973 RID: 2419 RVA: 0x00007332 File Offset: 0x00005532
		// (set) Token: 0x06000974 RID: 2420 RVA: 0x0000733A File Offset: 0x0000553A
		internal virtual MyCard CardTip { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06000975 RID: 2421 RVA: 0x00007343 File Offset: 0x00005543
		// (set) Token: 0x06000976 RID: 2422 RVA: 0x0000734B File Offset: 0x0000554B
		internal virtual TextBlock LabConnect { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06000977 RID: 2423 RVA: 0x00007354 File Offset: 0x00005554
		// (set) Token: 0x06000978 RID: 2424 RVA: 0x00054AF8 File Offset: 0x00052CF8
		internal virtual MyButton BtnWeb
		{
			[CompilerGenerated]
			get
			{
				return this.m_AttributeIterator;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnWeb_Click);
				MyButton attributeIterator = this.m_AttributeIterator;
				if (attributeIterator != null)
				{
					attributeIterator.CancelModel(obj);
				}
				this.m_AttributeIterator = value;
				attributeIterator = this.m_AttributeIterator;
				if (attributeIterator != null)
				{
					attributeIterator.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000979 RID: 2425 RVA: 0x0000735C File Offset: 0x0000555C
		// (set) Token: 0x0600097A RID: 2426 RVA: 0x00007364 File Offset: 0x00005564
		internal virtual StackPanel PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x0600097B RID: 2427 RVA: 0x0000736D File Offset: 0x0000556D
		// (set) Token: 0x0600097C RID: 2428 RVA: 0x00007375 File Offset: 0x00005575
		internal virtual MyCard PanLoad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x0600097D RID: 2429 RVA: 0x0000737E File Offset: 0x0000557E
		// (set) Token: 0x0600097E RID: 2430 RVA: 0x00054B3C File Offset: 0x00052D3C
		internal virtual MyLoading Load
		{
			[CompilerGenerated]
			get
			{
				return this.m_AdvisorIterator;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyLoading.ClickEventHandler obj = new MyLoading.ClickEventHandler(this.Load_Click);
				MyLoading.StateChangedEventHandler obj2 = new MyLoading.StateChangedEventHandler(this.Load_State);
				MyLoading advisorIterator = this.m_AdvisorIterator;
				if (advisorIterator != null)
				{
					advisorIterator.UpdateVal(obj);
					advisorIterator.InitVal(obj2);
				}
				this.m_AdvisorIterator = value;
				advisorIterator = this.m_AdvisorIterator;
				if (advisorIterator != null)
				{
					advisorIterator.PrepareVal(obj);
					advisorIterator.FillVal(obj2);
				}
			}
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x00054B9C File Offset: 0x00052D9C
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.m_StrategyIterator)
			{
				this.m_StrategyIterator = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagedownload/pagedownloadforge.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x00054BCC File Offset: 0x00052DCC
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
				this.CardTip = (MyCard)target;
				return;
			}
			if (connectionId == 3)
			{
				this.LabConnect = (TextBlock)target;
				return;
			}
			if (connectionId == 4)
			{
				this.BtnWeb = (MyButton)target;
				return;
			}
			if (connectionId == 5)
			{
				this.PanMain = (StackPanel)target;
				return;
			}
			if (connectionId == 6)
			{
				this.PanLoad = (MyCard)target;
				return;
			}
			if (connectionId == 7)
			{
				this.Load = (MyLoading)target;
				return;
			}
			this.m_StrategyIterator = true;
		}

		// Token: 0x0400056C RID: 1388
		private bool _EventIterator;

		// Token: 0x0400056D RID: 1389
		public int _PrinterIterator;

		// Token: 0x0400056E RID: 1390
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private MyScrollViewer productIterator;

		// Token: 0x0400056F RID: 1391
		[AccessedThroughProperty("CardTip")]
		[CompilerGenerated]
		private MyCard m_ComparatorIterator;

		// Token: 0x04000570 RID: 1392
		[CompilerGenerated]
		[AccessedThroughProperty("LabConnect")]
		private TextBlock _RegistryIterator;

		// Token: 0x04000571 RID: 1393
		[AccessedThroughProperty("BtnWeb")]
		[CompilerGenerated]
		private MyButton m_AttributeIterator;

		// Token: 0x04000572 RID: 1394
		[CompilerGenerated]
		[AccessedThroughProperty("PanMain")]
		private StackPanel m_ValueIterator;

		// Token: 0x04000573 RID: 1395
		[CompilerGenerated]
		[AccessedThroughProperty("PanLoad")]
		private MyCard _RoleIterator;

		// Token: 0x04000574 RID: 1396
		[AccessedThroughProperty("Load")]
		[CompilerGenerated]
		private MyLoading m_AdvisorIterator;

		// Token: 0x04000575 RID: 1397
		private bool m_StrategyIterator;
	}
}
