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
	// Token: 0x02000092 RID: 146
	[DesignerGenerated]
	public class PageLoginAuthSkin : Grid, IComponentConnector
	{
		// Token: 0x0600051E RID: 1310 RVA: 0x000050CE File Offset: 0x000032CE
		public PageLoginAuthSkin()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.PageLoginLegacy_Loaded();
			};
			this.InitializeComponent();
			this.Skin.m_ReponseIterator = PageLaunchLeft._StructExpression;
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x000050FE File Offset: 0x000032FE
		private void PageLoginLegacy_Loaded()
		{
			this.Skin.m_ReponseIterator.Start(null, false);
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x0002A3BC File Offset: 0x000285BC
		public void Reload(bool KeepInput)
		{
			this.TextName.Text = Conversions.ToString(ModBase._BaseRule.Get("CacheAuthName", null));
			this.TextEmail.Text = Conversions.ToString(ModBase._BaseRule.Get("CacheAuthUsername", null));
			this.TextEmail.Visibility = (Conversions.ToBoolean(ModBase._BaseRule.Get("UiLauncherEmail", null)) ? Visibility.Collapsed : Visibility.Visible);
			this.PageLoginLegacy_Loaded();
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0002A438 File Offset: 0x00028638
		public ModLaunch.McLoginServer GetLoginData()
		{
			string initializerAlgo = Conversions.ToString(Operators.ConcatenateObject(Information.IsNothing(ModMinecraft.ValidateContainer()) ? ModBase._BaseRule.Get("CacheAuthServerServer", null) : ModBase._BaseRule.Get("VersionServerAuthServer", ModMinecraft.ValidateContainer()), "/authserver"));
			return new ModLaunch.McLoginServer(ModLaunch.McLoginType.Auth)
			{
				propertyAlgo = "Auth",
				_InitializerAlgo = initializerAlgo,
				_DispatcherAlgo = Conversions.ToString(ModBase._BaseRule.Get("CacheAuthUsername", null)),
				_TagAlgo = Conversions.ToString(ModBase._BaseRule.Get("CacheAuthPass", null)),
				_WatcherAlgo = "Authlib-Injector",
				Type = ModLaunch.McLoginType.Auth
			};
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0002A4E8 File Offset: 0x000286E8
		private void PageLoginAuthSkin_MouseEnter(object sender, MouseEventArgs e)
		{
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.BtnEdit, 1.0 - this.BtnEdit.Opacity, 0x50, 0, null, false),
				ModAni.AaHeight(this.BtnEdit, 25.5 - this.BtnEdit.Height, 0x8C, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaHeight(this.BtnEdit, -1.5, 0x32, 0x8C, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaOpacity(this.BtnExit, 1.0 - this.BtnExit.Opacity, 0x50, 0, null, false),
				ModAni.AaHeight(this.BtnExit, 25.5 - this.BtnExit.Height, 0x8C, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaHeight(this.BtnExit, -1.5, 0x32, 0x8C, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false)
			}, "PageLoginAuthSkin Button", false);
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0002A618 File Offset: 0x00028818
		private void PageLoginAuthSkin_MouseLeave(object sender, MouseEventArgs e)
		{
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.BtnEdit, -this.BtnEdit.Opacity, 0x78, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaHeight(this.BtnEdit, 14.0 - this.BtnEdit.Height, 0x78, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaOpacity(this.BtnExit, -this.BtnExit.Opacity, 0x78, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaHeight(this.BtnExit, 14.0 - this.BtnExit.Height, 0x78, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false)
			}, "PageLoginAuthSkin Button", false);
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0002A6E8 File Offset: 0x000288E8
		private void BtnEdit_Click(object sender, EventArgs e)
		{
			if (ModLaunch._InfoIterator.State != ModBase.LoadState.Loading)
			{
				ModMain.Hint("正在尝试更换，请稍候！", ModMain.HintType.Info, true);
				ModBase._BaseRule.Set("CacheAuthUuid", "", false, null);
				ModBase._BaseRule.Set("CacheAuthName", "", false, null);
				ModBase.RunInThread(delegate
				{
					try
					{
						ModLaunch.McLoginServer loginData = this.GetLoginData();
						loginData.m_StateAlgo = true;
						ModLaunch._InfoIterator.WaitForExit(loginData, null, true);
						ModBase.RunInUi(delegate()
						{
							this.Reload(true);
						}, false);
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "更换角色失败", ModBase.LogLevel.Hint, "出现错误");
					}
				});
				return;
			}
			ModBase.Log("[Launch] 要求更换角色，但登录加载器繁忙", ModBase.LogLevel.Debug, "出现错误");
			if (((ModLaunch.McLoginServer)ModLaunch._InfoIterator.Input).m_StateAlgo)
			{
				ModMain.Hint("正在尝试更换，请稍候！", ModMain.HintType.Info, true);
				return;
			}
			ModMain.Hint("正在登录中，请稍后再更换角色！", ModMain.HintType.Critical, true);
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x00005112 File Offset: 0x00003312
		private void BtnExit_Click()
		{
			ModBase._BaseRule.Set("CacheAuthAccess", "", false, null);
			ModMain.m_InvocationFilter.RefreshPage(false, true);
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0000504A File Offset: 0x0000324A
		private void Skin_Click(object sender, MouseButtonEventArgs e)
		{
			ModBase.OpenWebsite(Conversions.ToString((ModMinecraft.ValidateContainer() == null) ? ModBase._BaseRule.Get("VersionServerAuthRegister", ModMinecraft.ValidateContainer()) : ModBase._BaseRule.Get("CacheAuthServerRegister", null)));
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000527 RID: 1319 RVA: 0x00005136 File Offset: 0x00003336
		// (set) Token: 0x06000528 RID: 1320 RVA: 0x0002A78C File Offset: 0x0002898C
		internal virtual Grid PanData
		{
			[CompilerGenerated]
			get
			{
				return this.m_TagContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.PageLoginAuthSkin_MouseEnter);
				MouseEventHandler value3 = new MouseEventHandler(this.PageLoginAuthSkin_MouseLeave);
				Grid tagContainer = this.m_TagContainer;
				if (tagContainer != null)
				{
					tagContainer.MouseEnter -= value2;
					tagContainer.MouseLeave -= value3;
				}
				this.m_TagContainer = value;
				tagContainer = this.m_TagContainer;
				if (tagContainer != null)
				{
					tagContainer.MouseEnter += value2;
					tagContainer.MouseLeave += value3;
				}
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000529 RID: 1321 RVA: 0x0000513E File Offset: 0x0000333E
		// (set) Token: 0x0600052A RID: 1322 RVA: 0x00005146 File Offset: 0x00003346
		internal virtual TextBlock TextName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600052B RID: 1323 RVA: 0x0000514F File Offset: 0x0000334F
		// (set) Token: 0x0600052C RID: 1324 RVA: 0x00005157 File Offset: 0x00003357
		internal virtual TextBlock TextEmail { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x0600052D RID: 1325 RVA: 0x00005160 File Offset: 0x00003360
		// (set) Token: 0x0600052E RID: 1326 RVA: 0x0002A7EC File Offset: 0x000289EC
		internal virtual MyIconButton BtnEdit
		{
			[CompilerGenerated]
			get
			{
				return this._WatcherContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyIconButton.ClickEventHandler value2 = new MyIconButton.ClickEventHandler(this.BtnEdit_Click);
				MyIconButton watcherContainer = this._WatcherContainer;
				if (watcherContainer != null)
				{
					watcherContainer.Click -= value2;
				}
				this._WatcherContainer = value;
				watcherContainer = this._WatcherContainer;
				if (watcherContainer != null)
				{
					watcherContainer.Click += value2;
				}
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x0600052F RID: 1327 RVA: 0x00005168 File Offset: 0x00003368
		// (set) Token: 0x06000530 RID: 1328 RVA: 0x0002A830 File Offset: 0x00028A30
		internal virtual MyIconButton BtnExit
		{
			[CompilerGenerated]
			get
			{
				return this.stateContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyIconButton.ClickEventHandler value2 = delegate(object sender, EventArgs e)
				{
					this.BtnExit_Click();
				};
				MyIconButton myIconButton = this.stateContainer;
				if (myIconButton != null)
				{
					myIconButton.Click -= value2;
				}
				this.stateContainer = value;
				myIconButton = this.stateContainer;
				if (myIconButton != null)
				{
					myIconButton.Click += value2;
				}
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000531 RID: 1329 RVA: 0x00005170 File Offset: 0x00003370
		// (set) Token: 0x06000532 RID: 1330 RVA: 0x0002A874 File Offset: 0x00028A74
		internal virtual MySkin Skin
		{
			[CompilerGenerated]
			get
			{
				return this.m_CreatorContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MySkin.ClickEventHandler obj = new MySkin.ClickEventHandler(this.Skin_Click);
				MySkin creatorContainer = this.m_CreatorContainer;
				if (creatorContainer != null)
				{
					creatorContainer.CollectModel(obj);
				}
				this.m_CreatorContainer = value;
				creatorContainer = this.m_CreatorContainer;
				if (creatorContainer != null)
				{
					creatorContainer.SearchModel(obj);
				}
			}
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x0002A8B8 File Offset: 0x00028AB8
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this._PageContainer)
			{
				this._PageContainer = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagelaunch/pageloginauthskin.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x0002A8E8 File Offset: 0x00028AE8
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
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
			this._PageContainer = true;
		}

		// Token: 0x0400027A RID: 634
		[CompilerGenerated]
		[AccessedThroughProperty("PanData")]
		private Grid m_TagContainer;

		// Token: 0x0400027B RID: 635
		[CompilerGenerated]
		[AccessedThroughProperty("TextName")]
		private TextBlock m_InitializerContainer;

		// Token: 0x0400027C RID: 636
		[CompilerGenerated]
		[AccessedThroughProperty("TextEmail")]
		private TextBlock _PropertyContainer;

		// Token: 0x0400027D RID: 637
		[AccessedThroughProperty("BtnEdit")]
		[CompilerGenerated]
		private MyIconButton _WatcherContainer;

		// Token: 0x0400027E RID: 638
		[AccessedThroughProperty("BtnExit")]
		[CompilerGenerated]
		private MyIconButton stateContainer;

		// Token: 0x0400027F RID: 639
		[AccessedThroughProperty("Skin")]
		[CompilerGenerated]
		private MySkin m_CreatorContainer;

		// Token: 0x04000280 RID: 640
		private bool _PageContainer;
	}
}
