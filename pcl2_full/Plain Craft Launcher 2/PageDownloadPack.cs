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
	// Token: 0x0200008B RID: 139
	[DesignerGenerated]
	public class PageDownloadPack : AdornerDecorator, IComponentConnector
	{
		// Token: 0x060004A9 RID: 1193 RVA: 0x00004CCA File Offset: 0x00002ECA
		// Note: this type is marked as 'beforefieldinit'.
		static PageDownloadPack()
		{
			PageDownloadPack._ResolverContainer = new ModLoader.LoaderTask<ModDownload.DlCfProjectRequest, List<ModDownload.DlCfProject>>("DlCfProject Main", new ModLoader.LoaderTask<ModDownload.DlCfProjectRequest, List<ModDownload.DlCfProject>>.LoadDelegateSub(ModDownload.DlCfProjectSub), new ModLoader.LoaderTask<ModDownload.DlCfProjectRequest, List<ModDownload.DlCfProject>>.InputDelegateSub(PageDownloadPack.LoaderInput), ThreadPriority.Normal)
			{
				ReloadTimeout = 0xEA60
			};
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00004CFF File Offset: 0x00002EFF
		public PageDownloadPack()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.Init();
			};
			this.collectionContainer = false;
			this.InitializeComponent();
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00004D26 File Offset: 0x00002F26
		private static ModDownload.DlCfProjectRequest LoaderInput()
		{
			return new ModDownload.DlCfProjectRequest
			{
				m_RequestAlgo = true
			};
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x00004D34 File Offset: 0x00002F34
		private void Init()
		{
			if (!this.collectionContainer)
			{
				this.collectionContainer = true;
				PageDownloadPack._ResolverContainer.Start(PageDownloadPack._ResolverContainer.Input, false);
				this.Load.State = PageDownloadPack._ResolverContainer;
			}
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x00004D6A File Offset: 0x00002F6A
		public static void RefreshLoader()
		{
			PageDownloadPack._ResolverContainer.Abort();
			PageDownloadPack._ResolverContainer.LastFinishedTime = 0L;
			PageDownloadPack.StartSearch();
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00004D8E File Offset: 0x00002F8E
		private void Load_Click(object sender, MouseButtonEventArgs e)
		{
			if (this.Load.State.LoadingState == MyLoading.MyLoadingState.Error)
			{
				PageDownloadPack._ResolverContainer.Start(PageDownloadPack._ResolverContainer.Input, false);
			}
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0002917C File Offset: 0x0002737C
		private void Load_State(object sender, MyLoading.MyLoadingState state)
		{
			switch (PageDownloadPack._ResolverContainer.State)
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
					ModBase.Log("[Download] 下载的整合包列表 Json 文件损坏，已自动重试", ModBase.LogLevel.Debug, "出现错误");
					PageDownloadPack._ResolverContainer.Start(PageDownloadPack._ResolverContainer.Input, false);
				}
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x0002920C File Offset: 0x0002740C
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
			}, "FrmDownloadPack Load Switch", false);
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x000292A8 File Offset: 0x000274A8
		private void Load_OnFinish()
		{
			try
			{
				this.PanProjects.Children.Clear();
				if (Operators.CompareString(PageDownloadPack._ResolverContainer.Input.m_ProxyAlgo, "", true) == 0)
				{
					this.CardProjects.Title = ((PageDownloadPack._ResolverContainer.Input.merchantAlgo == 0) ? "热门" : (this.ComboSearchSort.Items[PageDownloadPack._ResolverContainer.Input.merchantAlgo].ToString() + "的")) + "整合包";
				}
				else
				{
					this.CardProjects.Title = "搜索结果";
				}
				try
				{
					foreach (ModDownload.DlCfProject dlCfProject in PageDownloadPack._ResolverContainer.Output)
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
				ModBase.Log(ex, "可视化整合包列表出错", ModBase.LogLevel.Feedback, "出现错误");
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
			}, "FrmDownloadPack Load Switch", false);
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00004108 File Offset: 0x00002308
		public void ProjectClick(MyCfItem sender, EventArgs e)
		{
			ModMain.m_GetterFilter.PageChange(new FormMain.PageStackData
			{
				_FieldMapper = FormMain.PageType.CfDetail,
				m_StatusMapper = RuntimeHelpers.GetObjectValue(sender.Tag)
			}, FormMain.PageSubType.Default);
			ModMain.m_ConfigFilter.Init();
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00004DB8 File Offset: 0x00002FB8
		private void TextSearchName_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				PageDownloadPack.StartSearch();
			}
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00029470 File Offset: 0x00027670
		private static void StartSearch()
		{
			ModDownload.DlCfProjectRequest input;
			if (ModMain.m_CustomerFilter == null)
			{
				input = PageDownloadPack.LoaderInput();
			}
			else
			{
				string text = ModMain.m_CustomerFilter.TextSearchName.Text;
				ModBase.Log("[Control] 整合包搜索请求输入文本：" + text, ModBase.LogLevel.Normal, "出现错误");
				input = checked(new ModDownload.DlCfProjectRequest
				{
					m_ProxyAlgo = text,
					poolAlgo = ModMain.m_CustomerFilter.TextSearchVersion.Text.Replace("全部", ""),
					statusAlgo = (int)Math.Round(ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(ModMain.m_CustomerFilter.ComboSearchTag.SelectedItem, null, "Tag", new object[0], null, null, null)))),
					m_RequestAlgo = true,
					setterAlgo = new int?((int)Math.Round(ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(ModMain.m_CustomerFilter.ComboSearchSort.SelectedItem, null, "Tag", new object[0], null, null, null))))),
					merchantAlgo = ModMain.m_CustomerFilter.ComboSearchSort.SelectedIndex
				});
			}
			PageDownloadPack._ResolverContainer.Start(input, false);
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x00029588 File Offset: 0x00027788
		private void BtnSearchReset_Click(object sender, EventArgs e)
		{
			this.TextSearchName.Text = "";
			this.TextSearchVersion.SelectedIndex = 0;
			this.TextSearchVersion.Text = "全部";
			this.ComboSearchTag.SelectedIndex = 0;
			this.ComboSearchSort.SelectedIndex = 0;
			PageDownloadPack._ResolverContainer.LastFinishedTime = 0L;
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00004DC8 File Offset: 0x00002FC8
		private void BtnSearchInstall_Click(object sender, EventArgs e)
		{
			PageSelectLeft.StartInstall();
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060004B7 RID: 1207 RVA: 0x00004DCF File Offset: 0x00002FCF
		// (set) Token: 0x060004B8 RID: 1208 RVA: 0x00004DD7 File Offset: 0x00002FD7
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060004B9 RID: 1209 RVA: 0x00004DE0 File Offset: 0x00002FE0
		// (set) Token: 0x060004BA RID: 1210 RVA: 0x000295EC File Offset: 0x000277EC
		internal virtual MyTextBox TextSearchName
		{
			[CompilerGenerated]
			get
			{
				return this.broadcasterContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyEventHandler value2 = new KeyEventHandler(this.TextSearchName_KeyUp);
				MyTextBox myTextBox = this.broadcasterContainer;
				if (myTextBox != null)
				{
					myTextBox.KeyUp -= value2;
				}
				this.broadcasterContainer = value;
				myTextBox = this.broadcasterContainer;
				if (myTextBox != null)
				{
					myTextBox.KeyUp += value2;
				}
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060004BB RID: 1211 RVA: 0x00004DE8 File Offset: 0x00002FE8
		// (set) Token: 0x060004BC RID: 1212 RVA: 0x00029630 File Offset: 0x00027830
		internal virtual MyComboBox TextSearchVersion
		{
			[CompilerGenerated]
			get
			{
				return this.m_FieldContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyEventHandler value2 = new KeyEventHandler(this.TextSearchName_KeyUp);
				MyComboBox fieldContainer = this.m_FieldContainer;
				if (fieldContainer != null)
				{
					fieldContainer.KeyUp -= value2;
				}
				this.m_FieldContainer = value;
				fieldContainer = this.m_FieldContainer;
				if (fieldContainer != null)
				{
					fieldContainer.KeyUp += value2;
				}
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060004BD RID: 1213 RVA: 0x00004DF0 File Offset: 0x00002FF0
		// (set) Token: 0x060004BE RID: 1214 RVA: 0x00004DF8 File Offset: 0x00002FF8
		internal virtual MyComboBox ComboSearchTag { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060004BF RID: 1215 RVA: 0x00004E01 File Offset: 0x00003001
		// (set) Token: 0x060004C0 RID: 1216 RVA: 0x00004E09 File Offset: 0x00003009
		internal virtual MyComboBox ComboSearchSort { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060004C1 RID: 1217 RVA: 0x00004E12 File Offset: 0x00003012
		// (set) Token: 0x060004C2 RID: 1218 RVA: 0x00029674 File Offset: 0x00027874
		internal virtual MyButton BtnSearchRun
		{
			[CompilerGenerated]
			get
			{
				return this.m_PoolContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = (PageDownloadPack._Closure$__.$IR38-3 == null) ? (PageDownloadPack._Closure$__.$IR38-3 = delegate(object sender, EventArgs e)
				{
					PageDownloadPack.StartSearch();
				}) : PageDownloadPack._Closure$__.$IR38-3;
				MyButton poolContainer = this.m_PoolContainer;
				if (poolContainer != null)
				{
					poolContainer.CancelModel(obj);
				}
				this.m_PoolContainer = value;
				poolContainer = this.m_PoolContainer;
				if (poolContainer != null)
				{
					poolContainer.ValidateModel(obj);
				}
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060004C3 RID: 1219 RVA: 0x00004E1A File Offset: 0x0000301A
		// (set) Token: 0x060004C4 RID: 1220 RVA: 0x000296D0 File Offset: 0x000278D0
		internal virtual MyButton BtnSearchReset
		{
			[CompilerGenerated]
			get
			{
				return this.parserContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnSearchReset_Click);
				MyButton myButton = this.parserContainer;
				if (myButton != null)
				{
					myButton.CancelModel(obj);
				}
				this.parserContainer = value;
				myButton = this.parserContainer;
				if (myButton != null)
				{
					myButton.ValidateModel(obj);
				}
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060004C5 RID: 1221 RVA: 0x00004E22 File Offset: 0x00003022
		// (set) Token: 0x060004C6 RID: 1222 RVA: 0x00029714 File Offset: 0x00027914
		internal virtual MyButton BtnSearchInstall
		{
			[CompilerGenerated]
			get
			{
				return this._ProxyContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnSearchInstall_Click);
				MyButton proxyContainer = this._ProxyContainer;
				if (proxyContainer != null)
				{
					proxyContainer.CancelModel(obj);
				}
				this._ProxyContainer = value;
				proxyContainer = this._ProxyContainer;
				if (proxyContainer != null)
				{
					proxyContainer.ValidateModel(obj);
				}
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060004C7 RID: 1223 RVA: 0x00004E2A File Offset: 0x0000302A
		// (set) Token: 0x060004C8 RID: 1224 RVA: 0x00004E32 File Offset: 0x00003032
		internal virtual MyCard CardProjects { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060004C9 RID: 1225 RVA: 0x00004E3B File Offset: 0x0000303B
		// (set) Token: 0x060004CA RID: 1226 RVA: 0x00004E43 File Offset: 0x00003043
		internal virtual StackPanel PanProjects { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060004CB RID: 1227 RVA: 0x00004E4C File Offset: 0x0000304C
		// (set) Token: 0x060004CC RID: 1228 RVA: 0x00004E54 File Offset: 0x00003054
		internal virtual MyCard PanLoad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x00004E5D File Offset: 0x0000305D
		// (set) Token: 0x060004CE RID: 1230 RVA: 0x00029758 File Offset: 0x00027958
		internal virtual MyLoading Load
		{
			[CompilerGenerated]
			get
			{
				return this.printerContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyLoading.ClickEventHandler obj = new MyLoading.ClickEventHandler(this.Load_Click);
				MyLoading.StateChangedEventHandler obj2 = new MyLoading.StateChangedEventHandler(this.Load_State);
				MyLoading myLoading = this.printerContainer;
				if (myLoading != null)
				{
					myLoading.UpdateVal(obj);
					myLoading.InitVal(obj2);
				}
				this.printerContainer = value;
				myLoading = this.printerContainer;
				if (myLoading != null)
				{
					myLoading.PrepareVal(obj);
					myLoading.FillVal(obj2);
				}
			}
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x000297B8 File Offset: 0x000279B8
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.m_ProductContainer)
			{
				this.m_ProductContainer = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagedownload/pagedownloadpack.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x000297E8 File Offset: 0x000279E8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
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
				this.BtnSearchInstall = (MyButton)target;
				return;
			}
			if (connectionId == 9)
			{
				this.CardProjects = (MyCard)target;
				return;
			}
			if (connectionId == 0xA)
			{
				this.PanProjects = (StackPanel)target;
				return;
			}
			if (connectionId == 0xB)
			{
				this.PanLoad = (MyCard)target;
				return;
			}
			if (connectionId == 0xC)
			{
				this.Load = (MyLoading)target;
				return;
			}
			this.m_ProductContainer = true;
		}

		// Token: 0x04000252 RID: 594
		public static ModLoader.LoaderTask<ModDownload.DlCfProjectRequest, List<ModDownload.DlCfProject>> _ResolverContainer;

		// Token: 0x04000253 RID: 595
		private bool collectionContainer;

		// Token: 0x04000254 RID: 596
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private MyScrollViewer m_TestsContainer;

		// Token: 0x04000255 RID: 597
		[CompilerGenerated]
		[AccessedThroughProperty("TextSearchName")]
		private MyTextBox broadcasterContainer;

		// Token: 0x04000256 RID: 598
		[AccessedThroughProperty("TextSearchVersion")]
		[CompilerGenerated]
		private MyComboBox m_FieldContainer;

		// Token: 0x04000257 RID: 599
		[CompilerGenerated]
		[AccessedThroughProperty("ComboSearchTag")]
		private MyComboBox statusContainer;

		// Token: 0x04000258 RID: 600
		[AccessedThroughProperty("ComboSearchSort")]
		[CompilerGenerated]
		private MyComboBox m_RequestContainer;

		// Token: 0x04000259 RID: 601
		[CompilerGenerated]
		[AccessedThroughProperty("BtnSearchRun")]
		private MyButton m_PoolContainer;

		// Token: 0x0400025A RID: 602
		[AccessedThroughProperty("BtnSearchReset")]
		[CompilerGenerated]
		private MyButton parserContainer;

		// Token: 0x0400025B RID: 603
		[AccessedThroughProperty("BtnSearchInstall")]
		[CompilerGenerated]
		private MyButton _ProxyContainer;

		// Token: 0x0400025C RID: 604
		[CompilerGenerated]
		[AccessedThroughProperty("CardProjects")]
		private MyCard _SetterContainer;

		// Token: 0x0400025D RID: 605
		[CompilerGenerated]
		[AccessedThroughProperty("PanProjects")]
		private StackPanel _MerchantContainer;

		// Token: 0x0400025E RID: 606
		[AccessedThroughProperty("PanLoad")]
		[CompilerGenerated]
		private MyCard m_EventContainer;

		// Token: 0x0400025F RID: 607
		[AccessedThroughProperty("Load")]
		[CompilerGenerated]
		private MyLoading printerContainer;

		// Token: 0x04000260 RID: 608
		private bool m_ProductContainer;
	}
}
