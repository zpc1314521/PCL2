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
	// Token: 0x0200011C RID: 284
	[DesignerGenerated]
	public class PageDownloadLiteLoader : AdornerDecorator, IComponentConnector
	{
		// Token: 0x06000988 RID: 2440 RVA: 0x000073C6 File Offset: 0x000055C6
		// Note: this type is marked as 'beforefieldinit'.
		static PageDownloadLiteLoader()
		{
			PageDownloadLiteLoader.LoadInput = 1;
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x000073CE File Offset: 0x000055CE
		public PageDownloadLiteLoader()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.Init();
			};
			this.IsLoad = false;
			this.InitializeComponent();
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x000073F5 File Offset: 0x000055F5
		private void Init()
		{
			this.PanBack.ScrollToHome();
			ModDownload.m_BridgeIterator.Start(PageDownloadLiteLoader.LoadInput, false);
			if (!this.IsLoad)
			{
				this.IsLoad = true;
				this.Load.State = ModDownload.m_BridgeIterator;
			}
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x00007431 File Offset: 0x00005631
		public static void RefreshLoader()
		{
			checked
			{
				PageDownloadLiteLoader.LoadInput++;
				ModDownload.m_BridgeIterator.Start(PageDownloadLiteLoader.LoadInput, false);
			}
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x0000744F File Offset: 0x0000564F
		private void Load_Click(object sender, MouseButtonEventArgs e)
		{
			if (this.Load.State.LoadingState == MyLoading.MyLoadingState.Error)
			{
				PageDownloadLiteLoader.RefreshLoader();
			}
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x00054C58 File Offset: 0x00052E58
		private void Load_State(object sender, MyLoading.MyLoadingState state)
		{
			ModBase.LoadState state2 = ModDownload.m_BridgeIterator.State;
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

		// Token: 0x0600098E RID: 2446 RVA: 0x00054C88 File Offset: 0x00052E88
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
			}, "FrmDownloadLiteLoader Load Switch", false);
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x00054D24 File Offset: 0x00052F24
		private void Load_OnFinish()
		{
			checked
			{
				try
				{
					Dictionary<string, List<ModDownload.DlLiteLoaderListEntry>> dictionary = new Dictionary<string, List<ModDownload.DlLiteLoaderListEntry>>();
					int num = 0x1E;
					do
					{
						dictionary.Add("1." + Conversions.ToString(num), new List<ModDownload.DlLiteLoaderListEntry>());
						num += -1;
					}
					while (num >= 0);
					dictionary.Add("未知版本", new List<ModDownload.DlLiteLoaderListEntry>());
					try
					{
						foreach (ModDownload.DlLiteLoaderListEntry dlLiteLoaderListEntry in ModDownload.m_BridgeIterator.Output.Value)
						{
							string key = "1." + dlLiteLoaderListEntry.Inherit.Split(new char[]
							{
								'.'
							})[1];
							if (dictionary.ContainsKey(key))
							{
								dictionary[key].Add(dlLiteLoaderListEntry);
							}
							else
							{
								dictionary["未知版本"].Add(dlLiteLoaderListEntry);
							}
						}
					}
					finally
					{
						List<ModDownload.DlLiteLoaderListEntry>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					this.PanMain.Children.Clear();
					try
					{
						foreach (KeyValuePair<string, List<ModDownload.DlLiteLoaderListEntry>> keyValuePair in dictionary)
						{
							if (keyValuePair.Value.Count != 0)
							{
								MyCard myCard = new MyCard();
								myCard.Title = keyValuePair.Key + " (" + Conversions.ToString(keyValuePair.Value.Count) + ")";
								myCard.Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
								myCard.InitFactory(0xA);
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
						Dictionary<string, List<ModDownload.DlLiteLoaderListEntry>>.Enumerator enumerator2;
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
			}, "FrmDownloadLiteLoader Load Switch", false);
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x00007469 File Offset: 0x00005669
		public void DownloadStart(MyListItem sender, object e)
		{
			ModDownloadLib.McDownloadLiteLoader((ModDownload.DlLiteLoaderListEntry)sender.Tag);
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x00055048 File Offset: 0x00053248
		private static void DownloadState(ModLoader.LoaderCombo<ModDownload.DlLiteLoaderListEntry> Loader)
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
				switch (Loader.State)
				{
				case ModBase.LoadState.Loading:
					IL_A1:
					goto IL_127;
				case ModBase.LoadState.Finished:
					IL_2A:
					num2 = 4;
					ModMain.Hint(Loader.Name + "成功！", ModMain.HintType.Finish, true);
					break;
				case ModBase.LoadState.Failed:
					IL_45:
					num2 = 6;
					ModMain.Hint(Loader.Name + "失败：" + ModBase.GetString(Loader.Error, true, false), ModMain.HintType.Critical, true);
					break;
				case ModBase.LoadState.Aborted:
					IL_6D:
					num2 = 8;
					ModMain.Hint(Loader.Name + "已取消！", ModMain.HintType.Info, true);
					break;
				}
				IL_86:
				num2 = 0xC;
				ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", false);
				goto IL_A1;
				IL_A6:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_E8:
				goto IL_11C;
				IL_EA:
				num4 = num2;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_FA:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_EA;
			}
			IL_11C:
			throw ProjectData.CreateProjectError(-0x7FF5FFCD);
			IL_127:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x0000747B File Offset: 0x0000567B
		private void BtnWeb_Click(object sender, EventArgs e)
		{
			ModBase.OpenWebsite("https://www.liteloader.com");
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000993 RID: 2451 RVA: 0x00007487 File Offset: 0x00005687
		// (set) Token: 0x06000994 RID: 2452 RVA: 0x0000748F File Offset: 0x0000568F
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000995 RID: 2453 RVA: 0x00007498 File Offset: 0x00005698
		// (set) Token: 0x06000996 RID: 2454 RVA: 0x000074A0 File Offset: 0x000056A0
		internal virtual MyCard CardTip { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000997 RID: 2455 RVA: 0x000074A9 File Offset: 0x000056A9
		// (set) Token: 0x06000998 RID: 2456 RVA: 0x000074B1 File Offset: 0x000056B1
		internal virtual TextBlock LabConnect { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000999 RID: 2457 RVA: 0x000074BA File Offset: 0x000056BA
		// (set) Token: 0x0600099A RID: 2458 RVA: 0x00055194 File Offset: 0x00053394
		internal virtual MyButton BtnWeb
		{
			[CompilerGenerated]
			get
			{
				return this._BtnWeb;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnWeb_Click);
				MyButton btnWeb = this._BtnWeb;
				if (btnWeb != null)
				{
					btnWeb.CancelModel(obj);
				}
				this._BtnWeb = value;
				btnWeb = this._BtnWeb;
				if (btnWeb != null)
				{
					btnWeb.ValidateModel(obj);
				}
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x0600099B RID: 2459 RVA: 0x000074C2 File Offset: 0x000056C2
		// (set) Token: 0x0600099C RID: 2460 RVA: 0x000074CA File Offset: 0x000056CA
		internal virtual StackPanel PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x0600099D RID: 2461 RVA: 0x000074D3 File Offset: 0x000056D3
		// (set) Token: 0x0600099E RID: 2462 RVA: 0x000074DB File Offset: 0x000056DB
		internal virtual MyCard PanLoad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x0600099F RID: 2463 RVA: 0x000074E4 File Offset: 0x000056E4
		// (set) Token: 0x060009A0 RID: 2464 RVA: 0x000551D8 File Offset: 0x000533D8
		internal virtual MyLoading Load
		{
			[CompilerGenerated]
			get
			{
				return this._Load;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyLoading.ClickEventHandler obj = new MyLoading.ClickEventHandler(this.Load_Click);
				MyLoading.StateChangedEventHandler obj2 = new MyLoading.StateChangedEventHandler(this.Load_State);
				MyLoading load = this._Load;
				if (load != null)
				{
					load.UpdateVal(obj);
					load.InitVal(obj2);
				}
				this._Load = value;
				load = this._Load;
				if (load != null)
				{
					load.PrepareVal(obj);
					load.FillVal(obj2);
				}
			}
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x00055238 File Offset: 0x00053438
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this._contentLoaded)
			{
				this._contentLoaded = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagedownload/pagedownloadliteloader.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x00055268 File Offset: 0x00053468
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
			this._contentLoaded = true;
		}

		// Token: 0x04000578 RID: 1400
		private bool IsLoad;

		// Token: 0x04000579 RID: 1401
		public static int LoadInput;

		// Token: 0x04000581 RID: 1409
		private bool _contentLoaded;
	}
}
