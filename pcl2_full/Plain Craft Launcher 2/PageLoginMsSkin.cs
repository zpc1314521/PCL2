using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x02000095 RID: 149
	[DesignerGenerated]
	public class PageLoginMsSkin : Grid, IComponentConnector
	{
		// Token: 0x0600054D RID: 1357 RVA: 0x000052D7 File Offset: 0x000034D7
		public PageLoginMsSkin()
		{
			base.Loaded += this.PageLoginLegacy_Loaded;
			this._AuthenticationContainer = false;
			this.InitializeComponent();
			this.Skin.m_ReponseIterator = PageLaunchLeft.m_ConfigurationExpression;
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x0000530E File Offset: 0x0000350E
		private void PageLoginLegacy_Loaded(object sender, RoutedEventArgs e)
		{
			this.Skin.m_ReponseIterator.Start(null, false);
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x00005322 File Offset: 0x00003522
		public void Reload(bool KeepInput)
		{
			this.TextName.Text = Conversions.ToString(ModBase._BaseRule.Get("CacheMsName", null));
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0002AC20 File Offset: 0x00028E20
		public ModLaunch.McLoginMs GetLoginData()
		{
			ModLaunch.McLoginMs result;
			if (ModLaunch.systemIterator.State == ModBase.LoadState.Finished)
			{
				result = new ModLaunch.McLoginMs
				{
					creatorAlgo = Conversions.ToString(ModBase._BaseRule.Get("CacheMsOAuthRefresh", null)),
					testAlgo = Conversions.ToString(ModBase._BaseRule.Get("CacheMsName", null)),
					_PageAlgo = Conversions.ToString(ModBase._BaseRule.Get("CacheMsAccess", null)),
					m_InstanceAlgo = Conversions.ToString(ModBase._BaseRule.Get("CacheMsUuid", null))
				};
			}
			else
			{
				result = new ModLaunch.McLoginMs
				{
					creatorAlgo = Conversions.ToString(ModBase._BaseRule.Get("CacheMsOAuthRefresh", null)),
					testAlgo = Conversions.ToString(ModBase._BaseRule.Get("CacheMsName", null))
				};
			}
			return result;
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0002ACEC File Offset: 0x00028EEC
		private void PageLoginMsSkin_MouseEnter(object sender, MouseEventArgs e)
		{
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.BtnEdit, 1.0 - this.BtnEdit.Opacity, 0x50, 0, null, false),
				ModAni.AaHeight(this.BtnEdit, 25.5 - this.BtnEdit.Height, 0x8C, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaHeight(this.BtnEdit, -1.5, 0x32, 0x8C, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaOpacity(this.BtnExit, 1.0 - this.BtnExit.Opacity, 0x50, 0, null, false),
				ModAni.AaHeight(this.BtnExit, 25.5 - this.BtnExit.Height, 0x8C, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaHeight(this.BtnExit, -1.5, 0x32, 0x8C, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false)
			}, "PageLoginMsSkin Button", false);
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0002AE1C File Offset: 0x0002901C
		private void PageLoginMsSkin_MouseLeave(object sender, MouseEventArgs e)
		{
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.BtnEdit, -this.BtnEdit.Opacity, 0x78, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaHeight(this.BtnEdit, 14.0 - this.BtnEdit.Height, 0x78, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaOpacity(this.BtnExit, -this.BtnExit.Opacity, 0x78, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaHeight(this.BtnExit, 14.0 - this.BtnExit.Height, 0x78, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false)
			}, "PageLoginMsSkin Button", false);
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x00005344 File Offset: 0x00003544
		private void BtnEdit_Click(object sender, EventArgs e)
		{
			ModBase.OpenWebsite("https://account.microsoft.com/security");
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0002AEEC File Offset: 0x000290EC
		private void BtnExit_Click()
		{
			ModBase._BaseRule.Set("CacheMsOAuthRefresh", "", false, null);
			ModBase._BaseRule.Set("CacheMsAccess", "", false, null);
			ModBase._BaseRule.Set("CacheMsUuid", "", false, null);
			ModBase._BaseRule.Set("CacheMsName", "", false, null);
			ModLaunch.systemIterator.Abort();
			ModMain.m_InvocationFilter.RefreshPage(false, true);
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x0002AF68 File Offset: 0x00029168
		private void Skin_Click(object sender, MouseButtonEventArgs e)
		{
			PageLoginMsSkin._Closure$__9-0 CS$<>8__locals1 = new PageLoginMsSkin._Closure$__9-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Me = this;
			if (this._AuthenticationContainer)
			{
				ModMain.Hint("正在更改皮肤中，请稍候！", ModMain.HintType.Info, true);
				return;
			}
			if (ModLaunch._InfoIterator.State == ModBase.LoadState.Failed)
			{
				ModMain.Hint("登录失败，无法更改皮肤！", ModMain.HintType.Critical, true);
				return;
			}
			CS$<>8__locals1.$VB$Local_SkinInfo = ModMinecraft.McSkinSelect(false);
			if (CS$<>8__locals1.$VB$Local_SkinInfo._ExpressionMapper)
			{
				ModMain.Hint("正在更改皮肤……", ModMain.HintType.Info, true);
				this._AuthenticationContainer = true;
				ModBase.RunInNewThread(delegate
				{
					PageLoginMsSkin._Closure$__9-0.VB$StateMachine___Lambda$__0 vb$StateMachine___Lambda$__ = default(PageLoginMsSkin._Closure$__9-0.VB$StateMachine___Lambda$__0);
					vb$StateMachine___Lambda$__.$VB$NonLocal__Closure$__9-0 = CS$<>8__locals1;
					vb$StateMachine___Lambda$__.$State = -1;
					vb$StateMachine___Lambda$__.$Builder = AsyncVoidMethodBuilder.Create();
					vb$StateMachine___Lambda$__.$Builder.Start<PageLoginMsSkin._Closure$__9-0.VB$StateMachine___Lambda$__0>(ref vb$StateMachine___Lambda$__);
				}, "Ms Skin Upload", ThreadPriority.Normal);
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000556 RID: 1366 RVA: 0x00005350 File Offset: 0x00003550
		// (set) Token: 0x06000557 RID: 1367 RVA: 0x0002AFF8 File Offset: 0x000291F8
		internal virtual Grid PanData
		{
			[CompilerGenerated]
			get
			{
				return this.processContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.PageLoginMsSkin_MouseEnter);
				MouseEventHandler value3 = new MouseEventHandler(this.PageLoginMsSkin_MouseLeave);
				Grid grid = this.processContainer;
				if (grid != null)
				{
					grid.MouseEnter -= value2;
					grid.MouseLeave -= value3;
				}
				this.processContainer = value;
				grid = this.processContainer;
				if (grid != null)
				{
					grid.MouseEnter += value2;
					grid.MouseLeave += value3;
				}
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000558 RID: 1368 RVA: 0x00005358 File Offset: 0x00003558
		// (set) Token: 0x06000559 RID: 1369 RVA: 0x00005360 File Offset: 0x00003560
		internal virtual TextBlock TextName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600055A RID: 1370 RVA: 0x00005369 File Offset: 0x00003569
		// (set) Token: 0x0600055B RID: 1371 RVA: 0x0002B058 File Offset: 0x00029258
		internal virtual MyIconButton BtnEdit
		{
			[CompilerGenerated]
			get
			{
				return this._ImporterContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyIconButton.ClickEventHandler value2 = new MyIconButton.ClickEventHandler(this.BtnEdit_Click);
				MyIconButton importerContainer = this._ImporterContainer;
				if (importerContainer != null)
				{
					importerContainer.Click -= value2;
				}
				this._ImporterContainer = value;
				importerContainer = this._ImporterContainer;
				if (importerContainer != null)
				{
					importerContainer.Click += value2;
				}
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600055C RID: 1372 RVA: 0x00005371 File Offset: 0x00003571
		// (set) Token: 0x0600055D RID: 1373 RVA: 0x0002B09C File Offset: 0x0002929C
		internal virtual MyIconButton BtnExit
		{
			[CompilerGenerated]
			get
			{
				return this.m_TemplateContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyIconButton.ClickEventHandler value2 = delegate(object sender, EventArgs e)
				{
					this.BtnExit_Click();
				};
				MyIconButton templateContainer = this.m_TemplateContainer;
				if (templateContainer != null)
				{
					templateContainer.Click -= value2;
				}
				this.m_TemplateContainer = value;
				templateContainer = this.m_TemplateContainer;
				if (templateContainer != null)
				{
					templateContainer.Click += value2;
				}
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600055E RID: 1374 RVA: 0x00005379 File Offset: 0x00003579
		// (set) Token: 0x0600055F RID: 1375 RVA: 0x0002B0E0 File Offset: 0x000292E0
		internal virtual MySkin Skin
		{
			[CompilerGenerated]
			get
			{
				return this._AdapterContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MySkin.ClickEventHandler obj = new MySkin.ClickEventHandler(this.Skin_Click);
				MySkin adapterContainer = this._AdapterContainer;
				if (adapterContainer != null)
				{
					adapterContainer.CollectModel(obj);
				}
				this._AdapterContainer = value;
				adapterContainer = this._AdapterContainer;
				if (adapterContainer != null)
				{
					adapterContainer.SearchModel(obj);
				}
			}
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x0002B124 File Offset: 0x00029324
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.annotationContainer)
			{
				this.annotationContainer = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagelaunch/pageloginmsskin.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x0002B154 File Offset: 0x00029354
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanData = (Grid)target;
				return;
			}
			if (connectionId == 2)
			{
				this.TextName = (TextBlock)target;
				return;
			}
			if (connectionId == 3)
			{
				this.BtnEdit = (MyIconButton)target;
				return;
			}
			if (connectionId == 4)
			{
				this.BtnExit = (MyIconButton)target;
				return;
			}
			if (connectionId == 5)
			{
				this.Skin = (MySkin)target;
				return;
			}
			this.annotationContainer = true;
		}

		// Token: 0x04000286 RID: 646
		private bool _AuthenticationContainer;

		// Token: 0x04000287 RID: 647
		[CompilerGenerated]
		[AccessedThroughProperty("PanData")]
		private Grid processContainer;

		// Token: 0x04000288 RID: 648
		[AccessedThroughProperty("TextName")]
		[CompilerGenerated]
		private TextBlock _ListenerContainer;

		// Token: 0x04000289 RID: 649
		[CompilerGenerated]
		[AccessedThroughProperty("BtnEdit")]
		private MyIconButton _ImporterContainer;

		// Token: 0x0400028A RID: 650
		[AccessedThroughProperty("BtnExit")]
		[CompilerGenerated]
		private MyIconButton m_TemplateContainer;

		// Token: 0x0400028B RID: 651
		[CompilerGenerated]
		[AccessedThroughProperty("Skin")]
		private MySkin _AdapterContainer;

		// Token: 0x0400028C RID: 652
		private bool annotationContainer;
	}
}
