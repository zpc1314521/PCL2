using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x02000098 RID: 152
	[DesignerGenerated]
	public class PageLoginNideSkin : Grid, IComponentConnector
	{
		// Token: 0x06000568 RID: 1384 RVA: 0x000053AE File Offset: 0x000035AE
		public PageLoginNideSkin()
		{
			base.Loaded += this.PageLoginLegacy_Loaded;
			this.InitializeComponent();
			this.Skin.m_ReponseIterator = PageLaunchLeft._PredicateExpression;
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x000053DE File Offset: 0x000035DE
		private void PageLoginLegacy_Loaded(object sender, RoutedEventArgs e)
		{
			this.Skin.m_ReponseIterator.Start(null, false);
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0002B684 File Offset: 0x00029884
		public void Reload(bool KeepInput)
		{
			this.TextName.Text = Conversions.ToString(ModBase._BaseRule.Get("CacheNideName", null));
			this.TextEmail.Text = Conversions.ToString(ModBase._BaseRule.Get("CacheNideUsername", null));
			this.TextEmail.Visibility = (Conversions.ToBoolean(ModBase._BaseRule.Get("UiLauncherEmail", null)) ? Visibility.Collapsed : Visibility.Visible);
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0002B6F8 File Offset: 0x000298F8
		public ModLaunch.McLoginServer GetLoginData()
		{
			string str = Conversions.ToString(Information.IsNothing(ModMinecraft.ValidateContainer()) ? ModBase._BaseRule.Get("CacheNideServer", null) : ModBase._BaseRule.Get("VersionServerNide", ModMinecraft.ValidateContainer()));
			return new ModLaunch.McLoginServer(ModLaunch.McLoginType.Nide)
			{
				propertyAlgo = "Nide",
				_DispatcherAlgo = Conversions.ToString(ModBase._BaseRule.Get("CacheNideUsername", null)),
				_TagAlgo = Conversions.ToString(ModBase._BaseRule.Get("CacheNidePass", null)),
				_WatcherAlgo = "统一通行证",
				Type = ModLaunch.McLoginType.Nide,
				_InitializerAlgo = "https://auth2.nide8.com:233/" + str + "/authserver"
			};
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0002B7AC File Offset: 0x000299AC
		private void PageLoginNideSkin_MouseEnter(object sender, MouseEventArgs e)
		{
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.BtnEdit, 1.0 - this.BtnEdit.Opacity, 0x50, 0, null, false),
				ModAni.AaHeight(this.BtnEdit, 25.5 - this.BtnEdit.Height, 0x8C, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaHeight(this.BtnEdit, -1.5, 0x32, 0x8C, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaOpacity(this.BtnExit, 1.0 - this.BtnExit.Opacity, 0x50, 0, null, false),
				ModAni.AaHeight(this.BtnExit, 25.5 - this.BtnExit.Height, 0x8C, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaHeight(this.BtnExit, -1.5, 0x32, 0x8C, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false)
			}, "PageLoginNideSkin Button", false);
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0002B8DC File Offset: 0x00029ADC
		private void PageLoginNideSkin_MouseLeave(object sender, MouseEventArgs e)
		{
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.BtnEdit, -this.BtnEdit.Opacity, 0x78, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaHeight(this.BtnEdit, 14.0 - this.BtnEdit.Height, 0x78, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaOpacity(this.BtnExit, -this.BtnExit.Opacity, 0x78, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaHeight(this.BtnExit, 14.0 - this.BtnExit.Height, 0x78, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false)
			}, "PageLoginNideSkin Button", false);
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x000053F2 File Offset: 0x000035F2
		private void BtnEdit_Click(object sender, EventArgs e)
		{
			ModBase.OpenWebsite("https://login2.nide8.com:233/account/changepw");
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x000053FE File Offset: 0x000035FE
		private void BtnExit_Click()
		{
			ModBase._BaseRule.Set("CacheNideAccess", "", false, null);
			ModMain.m_InvocationFilter.RefreshPage(false, true);
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x0002B9AC File Offset: 0x00029BAC
		private void Skin_Click(object sender, MouseButtonEventArgs e)
		{
			ModBase.OpenWebsite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("https://login2.nide8.com:233/", Information.IsNothing(ModMinecraft.ValidateContainer()) ? ModBase._BaseRule.Get("CacheNideServer", null) : ModBase._BaseRule.Get("VersionServerNide", ModMinecraft.ValidateContainer())), "/skin")));
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000571 RID: 1393 RVA: 0x00005422 File Offset: 0x00003622
		// (set) Token: 0x06000572 RID: 1394 RVA: 0x0002BA0C File Offset: 0x00029C0C
		internal virtual Grid PanData
		{
			[CompilerGenerated]
			get
			{
				return this._ReaderContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.PageLoginNideSkin_MouseEnter);
				MouseEventHandler value3 = new MouseEventHandler(this.PageLoginNideSkin_MouseLeave);
				Grid readerContainer = this._ReaderContainer;
				if (readerContainer != null)
				{
					readerContainer.MouseEnter -= value2;
					readerContainer.MouseLeave -= value3;
				}
				this._ReaderContainer = value;
				readerContainer = this._ReaderContainer;
				if (readerContainer != null)
				{
					readerContainer.MouseEnter += value2;
					readerContainer.MouseLeave += value3;
				}
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000573 RID: 1395 RVA: 0x0000542A File Offset: 0x0000362A
		// (set) Token: 0x06000574 RID: 1396 RVA: 0x00005432 File Offset: 0x00003632
		internal virtual TextBlock TextName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000575 RID: 1397 RVA: 0x0000543B File Offset: 0x0000363B
		// (set) Token: 0x06000576 RID: 1398 RVA: 0x00005443 File Offset: 0x00003643
		internal virtual TextBlock TextEmail { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000577 RID: 1399 RVA: 0x0000544C File Offset: 0x0000364C
		// (set) Token: 0x06000578 RID: 1400 RVA: 0x0002BA6C File Offset: 0x00029C6C
		internal virtual MyIconButton BtnEdit
		{
			[CompilerGenerated]
			get
			{
				return this.m_ParamContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyIconButton.ClickEventHandler value2 = new MyIconButton.ClickEventHandler(this.BtnEdit_Click);
				MyIconButton paramContainer = this.m_ParamContainer;
				if (paramContainer != null)
				{
					paramContainer.Click -= value2;
				}
				this.m_ParamContainer = value;
				paramContainer = this.m_ParamContainer;
				if (paramContainer != null)
				{
					paramContainer.Click += value2;
				}
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000579 RID: 1401 RVA: 0x00005454 File Offset: 0x00003654
		// (set) Token: 0x0600057A RID: 1402 RVA: 0x0002BAB0 File Offset: 0x00029CB0
		internal virtual MyIconButton BtnExit
		{
			[CompilerGenerated]
			get
			{
				return this._MockContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyIconButton.ClickEventHandler value2 = delegate(object sender, EventArgs e)
				{
					this.BtnExit_Click();
				};
				MyIconButton mockContainer = this._MockContainer;
				if (mockContainer != null)
				{
					mockContainer.Click -= value2;
				}
				this._MockContainer = value;
				mockContainer = this._MockContainer;
				if (mockContainer != null)
				{
					mockContainer.Click += value2;
				}
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x0000545C File Offset: 0x0000365C
		// (set) Token: 0x0600057C RID: 1404 RVA: 0x0002BAF4 File Offset: 0x00029CF4
		internal virtual MySkin Skin
		{
			[CompilerGenerated]
			get
			{
				return this.specificationContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MySkin.ClickEventHandler obj = new MySkin.ClickEventHandler(this.Skin_Click);
				MySkin mySkin = this.specificationContainer;
				if (mySkin != null)
				{
					mySkin.CollectModel(obj);
				}
				this.specificationContainer = value;
				mySkin = this.specificationContainer;
				if (mySkin != null)
				{
					mySkin.SearchModel(obj);
				}
			}
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x0002BB38 File Offset: 0x00029D38
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.m_DicContainer)
			{
				this.m_DicContainer = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagelaunch/pageloginnideskin.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x0002BB68 File Offset: 0x00029D68
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
				this.TextEmail = (TextBlock)target;
				return;
			}
			if (connectionId == 4)
			{
				this.BtnEdit = (MyIconButton)target;
				return;
			}
			if (connectionId == 5)
			{
				this.BtnExit = (MyIconButton)target;
				return;
			}
			if (connectionId == 6)
			{
				this.Skin = (MySkin)target;
				return;
			}
			this.m_DicContainer = true;
		}

		// Token: 0x04000295 RID: 661
		[AccessedThroughProperty("PanData")]
		[CompilerGenerated]
		private Grid _ReaderContainer;

		// Token: 0x04000296 RID: 662
		[AccessedThroughProperty("TextName")]
		[CompilerGenerated]
		private TextBlock _RegContainer;

		// Token: 0x04000297 RID: 663
		[AccessedThroughProperty("TextEmail")]
		[CompilerGenerated]
		private TextBlock _DefinitionContainer;

		// Token: 0x04000298 RID: 664
		[CompilerGenerated]
		[AccessedThroughProperty("BtnEdit")]
		private MyIconButton m_ParamContainer;

		// Token: 0x04000299 RID: 665
		[CompilerGenerated]
		[AccessedThroughProperty("BtnExit")]
		private MyIconButton _MockContainer;

		// Token: 0x0400029A RID: 666
		[AccessedThroughProperty("Skin")]
		[CompilerGenerated]
		private MySkin specificationContainer;

		// Token: 0x0400029B RID: 667
		private bool m_DicContainer;
	}
}
