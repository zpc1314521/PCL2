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
	// Token: 0x02000083 RID: 131
	[DesignerGenerated]
	public class PageDownloadMod : AdornerDecorator, IComponentConnector
	{
		// Token: 0x06000369 RID: 873 RVA: 0x0000401A File Offset: 0x0000221A
		// Note: this type is marked as 'beforefieldinit'.
		static PageDownloadMod()
		{
			PageDownloadMod.writerVal = new ModLoader.LoaderTask<ModDownload.DlCfProjectRequest, List<ModDownload.DlCfProject>>("DlCfProject Main", new ModLoader.LoaderTask<ModDownload.DlCfProjectRequest, List<ModDownload.DlCfProject>>.LoadDelegateSub(ModDownload.DlCfProjectSub), new ModLoader.LoaderTask<ModDownload.DlCfProjectRequest, List<ModDownload.DlCfProject>>.InputDelegateSub(PageDownloadMod.LoaderInput), ThreadPriority.Normal)
			{
				ReloadTimeout = 0xEA60
			};
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0000404F File Offset: 0x0000224F
		public PageDownloadMod()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.Init();
			};
			this._ExporterVal = false;
			this.InitializeComponent();
		}

		// Token: 0x0600036B RID: 875 RVA: 0x00004076 File Offset: 0x00002276
		private static ModDownload.DlCfProjectRequest LoaderInput()
		{
			return new ModDownload.DlCfProjectRequest
			{
				m_RequestAlgo = false
			};
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00004084 File Offset: 0x00002284
		private void Init()
		{
			if (!this._ExporterVal)
			{
				this._ExporterVal = true;
				PageDownloadMod.writerVal.Start(PageDownloadMod.writerVal.Input, false);
				this.Load.State = PageDownloadMod.writerVal;
			}
		}

		// Token: 0x0600036D RID: 877 RVA: 0x000040BA File Offset: 0x000022BA
		public static void RefreshLoader()
		{
			PageDownloadMod.writerVal.Abort();
			PageDownloadMod.writerVal.LastFinishedTime = 0L;
			PageDownloadMod.StartSearch();
		}

		// Token: 0x0600036E RID: 878 RVA: 0x000040DE File Offset: 0x000022DE
		private void Load_Click(object sender, MouseButtonEventArgs e)
		{
			if (this.Load.State.LoadingState == MyLoading.MyLoadingState.Error)
			{
				PageDownloadMod.writerVal.Start(PageDownloadMod.writerVal.Input, false);
			}
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00023EF8 File Offset: 0x000220F8
		private void Load_State(object sender, MyLoading.MyLoadingState state)
		{
			switch (PageDownloadMod.writerVal.State)
			{
			case ModBase.LoadState.Loading:
				this.Load_OnStart();
				return;
			case ModBase.LoadState.Finished:
				this.Load_OnFinish();
				return;
			case ModBase.LoadState.Failed:
			{
				string text = "";
				if (ModDownload._MethodIterator.Error != null)
				{
					text = ModDownload._MethodIterator.Error.Message;
				}
				if (text.Contains("不是有效的 Json 文件"))
				{
					ModBase.Log("[Download] 下载的 Mod 列表 Json 文件损坏，已自动重试", ModBase.LogLevel.Debug, "出现错误");
					PageDownloadMod.writerVal.Start(PageDownloadMod.writerVal.Input, false);
				}
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x06000370 RID: 880 RVA: 0x00023F88 File Offset: 0x00022188
		private void Load_OnStart()
		{
			this.PanLoad.Visibility = Visibility.Visible;
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.PanLoad, 1.0 - this.PanLoad.Opacity, 0x96, 0, null, false),
				ModAni.AaOpacity(this.CardProjects, -this.CardProjects.Opacity, 0x96, 0, null, false),
				ModAni.AaCode(delegate
				{
					this.CardProjects.Visibility = Visibility.Collapsed;
					this.PanProjects.Children.Clear();
				}, 0, true)
			}, "FrmDownloadMod Load Switch", false);
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00024024 File Offset: 0x00022224
		private void Load_OnFinish()
		{
			try
			{
				this.PanProjects.Children.Clear();
				if (Operators.CompareString(PageDownloadMod.writerVal.Input.m_ProxyAlgo, "", true) == 0)
				{
					this.CardProjects.Title = ((PageDownloadMod.writerVal.Input.merchantAlgo == 0) ? "热门" : (this.ComboSearchSort.Items[PageDownloadMod.writerVal.Input.merchantAlgo].ToString() + "的")) + " Mod";
				}
				else
				{
					this.CardProjects.Title = "搜索结果";
				}
				try
				{
					foreach (ModDownload.DlCfProject dlCfProject in PageDownloadMod.writerVal.Output)
					{
						this.PanProjects.Children.Add(dlCfProject.ToCfItem(delegate(object sender, MouseButtonEventArgs e)
						{
							this.ProjectClick((MyCfItem)sender, e);
						}));
					}
				}
				finally
				{
					List<ModDownload.DlCfProject>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "可视化 Mod 列表出错", ModBase.LogLevel.Feedback, "出现错误");
			}
			this.CardProjects.Visibility = Visibility.Visible;
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.PanLoad, -this.PanLoad.Opacity, 0x96, 0, null, false),
				ModAni.AaOpacity(this.CardProjects, 1.0 - this.CardProjects.Opacity, 0x96, 0, null, false),
				ModAni.AaCode(delegate
				{
					this.PanLoad.Visibility = Visibility.Collapsed;
				}, 0, true)
			}, "FrmDownloadMod Load Switch", false);
		}

		// Token: 0x06000372 RID: 882 RVA: 0x00004108 File Offset: 0x00002308
		public void ProjectClick(MyCfItem sender, EventArgs e)
		{
			ModMain.m_GetterFilter.PageChange(new FormMain.PageStackData
			{
				_FieldMapper = FormMain.PageType.CfDetail,
				m_StatusMapper = RuntimeHelpers.GetObjectValue(sender.Tag)
			}, FormMain.PageSubType.Default);
			ModMain.m_ConfigFilter.Init();
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0000413C File Offset: 0x0000233C
		private void TextSearchName_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				PageDownloadMod.StartSearch();
			}
		}

		// Token: 0x06000374 RID: 884 RVA: 0x000241EC File Offset: 0x000223EC
		private static void StartSearch()
		{
			ModDownload.DlCfProjectRequest input;
			if (ModMain.m_TestFilter == null)
			{
				input = PageDownloadMod.LoaderInput();
			}
			else
			{
				string text = ModMain.m_TestFilter.TextSearchName.Text;
				ModBase.Log("[Control] Mod 搜索请求输入文本：" + text, ModBase.LogLevel.Normal, "出现错误");
				input = checked(new ModDownload.DlCfProjectRequest
				{
					m_ProxyAlgo = text,
					poolAlgo = ModMain.m_TestFilter.TextSearchVersion.Text.Replace("全部", ""),
					statusAlgo = (int)Math.Round(ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(ModMain.m_TestFilter.ComboSearchTag.SelectedItem, null, "Tag", new object[0], null, null, null)))),
					m_RequestAlgo = false,
					setterAlgo = new int?((int)Math.Round(ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(ModMain.m_TestFilter.ComboSearchSort.SelectedItem, null, "Tag", new object[0], null, null, null))))),
					merchantAlgo = ModMain.m_TestFilter.ComboSearchSort.SelectedIndex
				});
			}
			PageDownloadMod.writerVal.Start(input, false);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00024304 File Offset: 0x00022504
		private void BtnSearchReset_Click(object sender, EventArgs e)
		{
			this.TextSearchName.Text = "";
			this.TextSearchVersion.SelectedIndex = 0;
			this.TextSearchVersion.Text = "全部";
			this.ComboSearchTag.SelectedIndex = 0;
			this.ComboSearchSort.SelectedIndex = 0;
			PageDownloadMod.writerVal.LastFinishedTime = 0L;
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000376 RID: 886 RVA: 0x0000414C File Offset: 0x0000234C
		// (set) Token: 0x06000377 RID: 887 RVA: 0x00004154 File Offset: 0x00002354
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000378 RID: 888 RVA: 0x0000415D File Offset: 0x0000235D
		// (set) Token: 0x06000379 RID: 889 RVA: 0x00024368 File Offset: 0x00022568
		internal virtual MyTextBox TextSearchName
		{
			[CompilerGenerated]
			get
			{
				return this._GetterVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyEventHandler value2 = new KeyEventHandler(this.TextSearchName_KeyUp);
				MyTextBox getterVal = this._GetterVal;
				if (getterVal != null)
				{
					getterVal.KeyUp -= value2;
				}
				this._GetterVal = value;
				getterVal = this._GetterVal;
				if (getterVal != null)
				{
					getterVal.KeyUp += value2;
				}
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600037A RID: 890 RVA: 0x00004165 File Offset: 0x00002365
		// (set) Token: 0x0600037B RID: 891 RVA: 0x000243AC File Offset: 0x000225AC
		internal virtual MyComboBox TextSearchVersion
		{
			[CompilerGenerated]
			get
			{
				return this.interceptorVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyEventHandler value2 = new KeyEventHandler(this.TextSearchName_KeyUp);
				MyComboBox myComboBox = this.interceptorVal;
				if (myComboBox != null)
				{
					myComboBox.KeyUp -= value2;
				}
				this.interceptorVal = value;
				myComboBox = this.interceptorVal;
				if (myComboBox != null)
				{
					myComboBox.KeyUp += value2;
				}
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600037C RID: 892 RVA: 0x0000416D File Offset: 0x0000236D
		// (set) Token: 0x0600037D RID: 893 RVA: 0x00004175 File Offset: 0x00002375
		internal virtual MyComboBox ComboSearchTag { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600037E RID: 894 RVA: 0x0000417E File Offset: 0x0000237E
		// (set) Token: 0x0600037F RID: 895 RVA: 0x00004186 File Offset: 0x00002386
		internal virtual MyComboBox ComboSearchSort { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000380 RID: 896 RVA: 0x0000418F File Offset: 0x0000238F
		// (set) Token: 0x06000381 RID: 897 RVA: 0x000243F0 File Offset: 0x000225F0
		internal virtual MyButton BtnSearchRun
		{
			[CompilerGenerated]
			get
			{
				return this.descriptorVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = (PageDownloadMod._Closure$__.$IR37-3 == null) ? (PageDownloadMod._Closure$__.$IR37-3 = delegate(object sender, EventArgs e)
				{
					PageDownloadMod.StartSearch();
				}) : PageDownloadMod._Closure$__.$IR37-3;
				MyButton myButton = this.descriptorVal;
				if (myButton != null)
				{
					myButton.CancelModel(obj);
				}
				this.descriptorVal = value;
				myButton = this.descriptorVal;
				if (myButton != null)
				{
					myButton.ValidateModel(obj);
				}
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000382 RID: 898 RVA: 0x00004197 File Offset: 0x00002397
		// (set) Token: 0x06000383 RID: 899 RVA: 0x0002444C File Offset: 0x0002264C
		internal virtual MyButton BtnSearchReset
		{
			[CompilerGenerated]
			get
			{
				return this.m_ContextVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnSearchReset_Click);
				MyButton contextVal = this.m_ContextVal;
				if (contextVal != null)
				{
					contextVal.CancelModel(obj);
				}
				this.m_ContextVal = value;
				contextVal = this.m_ContextVal;
				if (contextVal != null)
				{
					contextVal.ValidateModel(obj);
				}
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000384 RID: 900 RVA: 0x0000419F File Offset: 0x0000239F
		// (set) Token: 0x06000385 RID: 901 RVA: 0x000041A7 File Offset: 0x000023A7
		internal virtual MyCard CardProjects { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000386 RID: 902 RVA: 0x000041B0 File Offset: 0x000023B0
		// (set) Token: 0x06000387 RID: 903 RVA: 0x000041B8 File Offset: 0x000023B8
		internal virtual StackPanel PanProjects { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000388 RID: 904 RVA: 0x000041C1 File Offset: 0x000023C1
		// (set) Token: 0x06000389 RID: 905 RVA: 0x000041C9 File Offset: 0x000023C9
		internal virtual MyCard PanLoad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600038A RID: 906 RVA: 0x000041D2 File Offset: 0x000023D2
		// (set) Token: 0x0600038B RID: 907 RVA: 0x00024490 File Offset: 0x00022690
		internal virtual MyLoading Load
		{
			[CompilerGenerated]
			get
			{
				return this.tagVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyLoading.ClickEventHandler obj = new MyLoading.ClickEventHandler(this.Load_Click);
				MyLoading.StateChangedEventHandler obj2 = new MyLoading.StateChangedEventHandler(this.Load_State);
				MyLoading myLoading = this.tagVal;
				if (myLoading != null)
				{
					myLoading.UpdateVal(obj);
					myLoading.InitVal(obj2);
				}
				this.tagVal = value;
				myLoading = this.tagVal;
				if (myLoading != null)
				{
					myLoading.PrepareVal(obj);
					myLoading.FillVal(obj2);
				}
			}
		}

		// Token: 0x0600038C RID: 908 RVA: 0x000244F0 File Offset: 0x000226F0
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.m_InitializerVal)
			{
				this.m_InitializerVal = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagedownload/pagedownloadmod.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00024520 File Offset: 0x00022720
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
				this.TextSearchName = (MyTextBox)target;
				return;
			}
			if (connectionId == 3)
			{
				this.TextSearchVersion = (MyComboBox)target;
				return;
			}
			if (connectionId == 4)
			{
				this.ComboSearchTag = (MyComboBox)target;
				return;
			}
			if (connectionId == 5)
			{
				this.ComboSearchSort = (MyComboBox)target;
				return;
			}
			if (connectionId == 6)
			{
				this.BtnSearchRun = (MyButton)target;
				return;
			}
			if (connectionId == 7)
			{
				this.BtnSearchReset = (MyButton)target;
				return;
			}
			if (connectionId == 8)
			{
				this.CardProjects = (MyCard)target;
				return;
			}
			if (connectionId == 9)
			{
				this.PanProjects = (StackPanel)target;
				return;
			}
			if (connectionId == 0xA)
			{
				this.PanLoad = (MyCard)target;
				return;
			}
			if (connectionId == 0xB)
			{
				this.Load = (MyLoading)target;
				return;
			}
			this.m_InitializerVal = true;
		}

		// Token: 0x040001DA RID: 474
		public static ModLoader.LoaderTask<ModDownload.DlCfProjectRequest, List<ModDownload.DlCfProject>> writerVal;

		// Token: 0x040001DB RID: 475
		private bool _ExporterVal;

		// Token: 0x040001DC RID: 476
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private MyScrollViewer recordVal;

		// Token: 0x040001DD RID: 477
		[CompilerGenerated]
		[AccessedThroughProperty("TextSearchName")]
		private MyTextBox _GetterVal;

		// Token: 0x040001DE RID: 478
		[CompilerGenerated]
		[AccessedThroughProperty("TextSearchVersion")]
		private MyComboBox interceptorVal;

		// Token: 0x040001DF RID: 479
		[CompilerGenerated]
		[AccessedThroughProperty("ComboSearchTag")]
		private MyComboBox invocationVal;

		// Token: 0x040001E0 RID: 480
		[AccessedThroughProperty("ComboSearchSort")]
		[CompilerGenerated]
		private MyComboBox _CandidateVal;

		// Token: 0x040001E1 RID: 481
		[CompilerGenerated]
		[AccessedThroughProperty("BtnSearchRun")]
		private MyButton descriptorVal;

		// Token: 0x040001E2 RID: 482
		[CompilerGenerated]
		[AccessedThroughProperty("BtnSearchReset")]
		private MyButton m_ContextVal;

		// Token: 0x040001E3 RID: 483
		[AccessedThroughProperty("CardProjects")]
		[CompilerGenerated]
		private MyCard observerVal;

		// Token: 0x040001E4 RID: 484
		[CompilerGenerated]
		[AccessedThroughProperty("PanProjects")]
		private StackPanel tokenizerVal;

		// Token: 0x040001E5 RID: 485
		[AccessedThroughProperty("PanLoad")]
		[CompilerGenerated]
		private MyCard dispatcherVal;

		// Token: 0x040001E6 RID: 486
		[AccessedThroughProperty("Load")]
		[CompilerGenerated]
		private MyLoading tagVal;

		// Token: 0x040001E7 RID: 487
		private bool m_InitializerVal;
	}
}
