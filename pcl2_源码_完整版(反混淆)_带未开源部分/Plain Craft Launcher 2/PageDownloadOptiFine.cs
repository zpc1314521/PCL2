using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
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
	// Token: 0x0200011D RID: 285
	[DesignerGenerated]
	public class PageDownloadOptiFine : AdornerDecorator, IComponentConnector
	{
		// Token: 0x060009A7 RID: 2471 RVA: 0x00007520 File Offset: 0x00005720
		// Note: this type is marked as 'beforefieldinit'.
		static PageDownloadOptiFine()
		{
			PageDownloadOptiFine.writerIterator = 1;
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x00007528 File Offset: 0x00005728
		public PageDownloadOptiFine()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.Init();
			};
			this.wrapperIterator = false;
			this.InitializeComponent();
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x0000754F File Offset: 0x0000574F
		private void Init()
		{
			this.PanBack.ScrollToHome();
			ModDownload.issuerIterator.Start(PageDownloadOptiFine.writerIterator, false);
			if (!this.wrapperIterator)
			{
				this.wrapperIterator = true;
				this.Load.State = ModDownload.issuerIterator;
			}
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x0000758B File Offset: 0x0000578B
		public static void RefreshLoader()
		{
			checked
			{
				PageDownloadOptiFine.writerIterator++;
				ModDownload.issuerIterator.Start(PageDownloadOptiFine.writerIterator, false);
			}
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x000075A9 File Offset: 0x000057A9
		private void Load_Click(object sender, MouseButtonEventArgs e)
		{
			if (this.Load.State.LoadingState == MyLoading.MyLoadingState.Error)
			{
				PageDownloadOptiFine.RefreshLoader();
			}
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x000552F4 File Offset: 0x000534F4
		private void Load_State(object sender, MyLoading.MyLoadingState state)
		{
			ModBase.LoadState state2 = ModDownload.issuerIterator.State;
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

		// Token: 0x060009AD RID: 2477 RVA: 0x00055324 File Offset: 0x00053524
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
			}, "FrmDownloadOptiFine Load Switch", false);
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x000553C0 File Offset: 0x000535C0
		private void Load_OnFinish()
		{
			checked
			{
				try
				{
					Dictionary<string, ArrayList> dictionary = new Dictionary<string, ArrayList>();
					dictionary.Add("快照版本", new ArrayList());
					int num = 0x1E;
					do
					{
						dictionary.Add("1." + Conversions.ToString(num), new ArrayList());
						num += -1;
					}
					while (num >= 0);
					try
					{
						foreach (ModDownload.DlOptiFineListEntry dlOptiFineListEntry in ModDownload.issuerIterator.Output.Value)
						{
							if (dlOptiFineListEntry.SetExpression().StartsWith("1."))
							{
								string key = "1." + dlOptiFineListEntry.m_RepositoryAlgo.Split(new char[]
								{
									'.'
								})[1].Split(new char[]
								{
									' '
								})[0];
								if (dictionary.ContainsKey(key))
								{
									dictionary[key].Add(dlOptiFineListEntry);
								}
								else
								{
									dictionary["快照版本"].Add(dlOptiFineListEntry);
								}
							}
							else
							{
								dictionary["快照版本"].Add(dlOptiFineListEntry);
							}
						}
					}
					finally
					{
						List<ModDownload.DlOptiFineListEntry>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					this.PanMain.Children.Clear();
					try
					{
						foreach (KeyValuePair<string, ArrayList> keyValuePair in dictionary)
						{
							if (keyValuePair.Value.Count != 0)
							{
								MyCard myCard = new MyCard();
								myCard.Title = keyValuePair.Key + " (" + Conversions.ToString(keyValuePair.Value.Count) + ")";
								myCard.Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
								myCard.InitFactory(3);
								MyCard myCard2 = myCard;
								StackPanel stackPanel = new StackPanel
								{
									Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
									VerticalAlignment = VerticalAlignment.Top,
									RenderTransform = new TranslateTransform(0.0, 0.0),
									Tag = keyValuePair.Value
								};
								myCard2.Children.Add(stackPanel);
								myCard2.thread = stackPanel;
								myCard2.IsSwaped = true;
								this.PanMain.Children.Add(myCard2);
							}
						}
					}
					finally
					{
						Dictionary<string, ArrayList>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "可视化版本列表出错", ModBase.LogLevel.Feedback, "出现错误");
				}
				this.PanBack.Visibility = Visibility.Visible;
			}
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.PanLoad, -this.PanLoad.Opacity, 0x96, 0, null, false),
				ModAni.AaOpacity(this.PanBack, 1.0 - this.PanBack.Opacity, 0x96, 0, null, false),
				ModAni.AaCode(delegate
				{
					this.PanLoad.Visibility = Visibility.Collapsed;
				}, 0, true)
			}, "FrmDownloadOptiFine Load Switch", false);
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x000075C3 File Offset: 0x000057C3
		public void DownloadStart(MyListItem sender, object e)
		{
			ModDownloadLib.McDownloadOptiFine((ModDownload.DlOptiFineListEntry)sender.Tag);
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x000075D5 File Offset: 0x000057D5
		private void BtnWeb_Click(object sender, EventArgs e)
		{
			ModBase.OpenWebsite("https://www.optifine.net/");
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x000075E1 File Offset: 0x000057E1
		private void BtnChina_Click(object sender, EventArgs e)
		{
			ModBase.OpenWebsite("https://optifine.cn/home");
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060009B2 RID: 2482 RVA: 0x000075ED File Offset: 0x000057ED
		// (set) Token: 0x060009B3 RID: 2483 RVA: 0x000075F5 File Offset: 0x000057F5
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060009B4 RID: 2484 RVA: 0x000075FE File Offset: 0x000057FE
		// (set) Token: 0x060009B5 RID: 2485 RVA: 0x00007606 File Offset: 0x00005806
		internal virtual MyCard CardTip { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060009B6 RID: 2486 RVA: 0x0000760F File Offset: 0x0000580F
		// (set) Token: 0x060009B7 RID: 2487 RVA: 0x00007617 File Offset: 0x00005817
		internal virtual TextBlock LabConnect { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060009B8 RID: 2488 RVA: 0x00007620 File Offset: 0x00005820
		// (set) Token: 0x060009B9 RID: 2489 RVA: 0x00055724 File Offset: 0x00053924
		internal virtual MyButton BtnChina
		{
			[CompilerGenerated]
			get
			{
				return this.interceptorIterator;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnChina_Click);
				MyButton myButton = this.interceptorIterator;
				if (myButton != null)
				{
					myButton.CancelModel(obj);
				}
				this.interceptorIterator = value;
				myButton = this.interceptorIterator;
				if (myButton != null)
				{
					myButton.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060009BA RID: 2490 RVA: 0x00007628 File Offset: 0x00005828
		// (set) Token: 0x060009BB RID: 2491 RVA: 0x00055768 File Offset: 0x00053968
		internal virtual MyButton BtnWeb
		{
			[CompilerGenerated]
			get
			{
				return this.m_InvocationIterator;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnWeb_Click);
				MyButton invocationIterator = this.m_InvocationIterator;
				if (invocationIterator != null)
				{
					invocationIterator.CancelModel(obj);
				}
				this.m_InvocationIterator = value;
				invocationIterator = this.m_InvocationIterator;
				if (invocationIterator != null)
				{
					invocationIterator.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060009BC RID: 2492 RVA: 0x00007630 File Offset: 0x00005830
		// (set) Token: 0x060009BD RID: 2493 RVA: 0x00007638 File Offset: 0x00005838
		internal virtual StackPanel PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060009BE RID: 2494 RVA: 0x00007641 File Offset: 0x00005841
		// (set) Token: 0x060009BF RID: 2495 RVA: 0x00007649 File Offset: 0x00005849
		internal virtual MyCard PanLoad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060009C0 RID: 2496 RVA: 0x00007652 File Offset: 0x00005852
		// (set) Token: 0x060009C1 RID: 2497 RVA: 0x000557AC File Offset: 0x000539AC
		internal virtual MyLoading Load
		{
			[CompilerGenerated]
			get
			{
				return this._ContextIterator;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyLoading.ClickEventHandler obj = new MyLoading.ClickEventHandler(this.Load_Click);
				MyLoading.StateChangedEventHandler obj2 = new MyLoading.StateChangedEventHandler(this.Load_State);
				MyLoading contextIterator = this._ContextIterator;
				if (contextIterator != null)
				{
					contextIterator.UpdateVal(obj);
					contextIterator.InitVal(obj2);
				}
				this._ContextIterator = value;
				contextIterator = this._ContextIterator;
				if (contextIterator != null)
				{
					contextIterator.PrepareVal(obj);
					contextIterator.FillVal(obj2);
				}
			}
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x0005580C File Offset: 0x00053A0C
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this._ObserverIterator)
			{
				this._ObserverIterator = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagedownload/pagedownloadoptifine.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x0005583C File Offset: 0x00053A3C
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
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
				this.BtnChina = (MyButton)target;
				return;
			}
			if (connectionId == 5)
			{
				this.BtnWeb = (MyButton)target;
				return;
			}
			if (connectionId == 6)
			{
				this.PanMain = (StackPanel)target;
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
			this._ObserverIterator = true;
		}

		// Token: 0x04000582 RID: 1410
		private bool wrapperIterator;

		// Token: 0x04000583 RID: 1411
		public static int writerIterator;

		// Token: 0x04000584 RID: 1412
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private MyScrollViewer exporterIterator;

		// Token: 0x04000585 RID: 1413
		[CompilerGenerated]
		[AccessedThroughProperty("CardTip")]
		private MyCard recordIterator;

		// Token: 0x04000586 RID: 1414
		[AccessedThroughProperty("LabConnect")]
		[CompilerGenerated]
		private TextBlock _GetterIterator;

		// Token: 0x04000587 RID: 1415
		[CompilerGenerated]
		[AccessedThroughProperty("BtnChina")]
		private MyButton interceptorIterator;

		// Token: 0x04000588 RID: 1416
		[AccessedThroughProperty("BtnWeb")]
		[CompilerGenerated]
		private MyButton m_InvocationIterator;

		// Token: 0x04000589 RID: 1417
		[AccessedThroughProperty("PanMain")]
		[CompilerGenerated]
		private StackPanel candidateIterator;

		// Token: 0x0400058A RID: 1418
		[AccessedThroughProperty("PanLoad")]
		[CompilerGenerated]
		private MyCard _DescriptorIterator;

		// Token: 0x0400058B RID: 1419
		[CompilerGenerated]
		[AccessedThroughProperty("Load")]
		private MyLoading _ContextIterator;

		// Token: 0x0400058C RID: 1420
		private bool _ObserverIterator;
	}
}
