using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x0200012A RID: 298
	[DesignerGenerated]
	public class PageLoginMojangSkin : Grid, IComponentConnector
	{
		// Token: 0x06000AAA RID: 2730 RVA: 0x00007EBA File Offset: 0x000060BA
		public PageLoginMojangSkin()
		{
			base.Loaded += this.PageLoginLegacy_Loaded;
			this.InitializeComponent();
			this.Skin.m_ReponseIterator = PageLaunchLeft.m_AccountExpression;
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x00007EEA File Offset: 0x000060EA
		private void PageLoginLegacy_Loaded(object sender, RoutedEventArgs e)
		{
			this.Skin.m_ReponseIterator.Start(null, false);
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x0005AE04 File Offset: 0x00059004
		public void Reload(bool KeepInput)
		{
			this.TextName.Text = Conversions.ToString(ModBase._BaseRule.Get("CacheMojangName", null));
			this.TextEmail.Text = Conversions.ToString(ModBase._BaseRule.Get("CacheMojangUsername", null));
			this.TextEmail.Visibility = (Conversions.ToBoolean(ModBase._BaseRule.Get("UiLauncherEmail", null)) ? Visibility.Collapsed : Visibility.Visible);
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x0005AE78 File Offset: 0x00059078
		public ModLaunch.McLoginServer GetLoginData()
		{
			return new ModLaunch.McLoginServer(ModLaunch.McLoginType.Mojang)
			{
				_InitializerAlgo = "https://authserver.mojang.com",
				propertyAlgo = "Mojang",
				_DispatcherAlgo = Conversions.ToString(ModBase._BaseRule.Get("CacheMojangUsername", null)),
				_TagAlgo = Conversions.ToString(ModBase._BaseRule.Get("CacheMojangPass", null)),
				_WatcherAlgo = "Mojang 正版",
				Type = ModLaunch.McLoginType.Mojang
			};
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x0005AEEC File Offset: 0x000590EC
		private void PageLoginMojangSkin_MouseEnter(object sender, MouseEventArgs e)
		{
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.BtnEdit, 1.0 - this.BtnEdit.Opacity, 0x50, 0, null, false),
				ModAni.AaHeight(this.BtnEdit, 25.5 - this.BtnEdit.Height, 0x8C, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaHeight(this.BtnEdit, -1.5, 0x32, 0x8C, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaOpacity(this.BtnExit, 1.0 - this.BtnExit.Opacity, 0x50, 0, null, false),
				ModAni.AaHeight(this.BtnExit, 25.5 - this.BtnExit.Height, 0x8C, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaHeight(this.BtnExit, -1.5, 0x32, 0x8C, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false)
			}, "PageLoginMojangSkin Button", false);
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x0005B01C File Offset: 0x0005921C
		private void PageLoginMojangSkin_MouseLeave(object sender, MouseEventArgs e)
		{
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.BtnEdit, -this.BtnEdit.Opacity, 0x78, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaHeight(this.BtnEdit, 14.0 - this.BtnEdit.Height, 0x78, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaOpacity(this.BtnExit, -this.BtnExit.Opacity, 0x78, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaHeight(this.BtnExit, 14.0 - this.BtnExit.Height, 0x78, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false)
			}, "PageLoginMojangSkin Button", false);
		}

		// Token: 0x06000AB0 RID: 2736 RVA: 0x0005B0EC File Offset: 0x000592EC
		private void BtnEdit_Click(object sender, EventArgs e)
		{
			switch (ModMain.MyMsgBox("你希望通过哪种途径更改密码？\r\n首次通过个人档案修改密码可能需要验证你的密保问题。", "更改密码", "个人档案", "密保邮箱", "取消", false, true, false))
			{
			case 1:
				ModBase.OpenWebsite("https://www.minecraft.net/zh-hans/profile/");
				return;
			case 2:
				ModBase.OpenWebsite("https://account.mojang.com/password");
				break;
			case 3:
				break;
			default:
				return;
			}
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x00007EFE File Offset: 0x000060FE
		private void BtnExit_Click()
		{
			ModBase._BaseRule.Set("CacheMojangAccess", "", false, null);
			ModMain.m_InvocationFilter.RefreshPage(false, true);
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x0005B148 File Offset: 0x00059348
		private void Skin_Click(object sender, MouseButtonEventArgs e)
		{
			if (ModLaunch._InfoIterator.State == ModBase.LoadState.Failed)
			{
				ModMain.Hint("登录失败，无法更改皮肤！", ModMain.HintType.Critical, true);
				return;
			}
			ModMinecraft.McSkinInfo SkinInfo = ModMinecraft.McSkinSelect(false);
			if (SkinInfo._ExpressionMapper)
			{
				ModMain.Hint("正在更改皮肤……", ModMain.HintType.Info, true);
				ModBase.RunInNewThread(async delegate
				{
					try
					{
						if (ModLaunch._InfoIterator.State == ModBase.LoadState.Loading)
						{
							ModLaunch._InfoIterator.WaitForExit(null, null, false);
						}
						string parameter = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase._BaseRule.Get("CacheMojangAccess", null)));
						string str = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase._BaseRule.Get("CacheMojangUuid", null)));
						HttpClient httpClient = new HttpClient();
						httpClient.Timeout = new TimeSpan(0, 0, 0xA);
						httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", parameter);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
						httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("MojangSharp", "0.1"));
						MultipartFormDataContent content = new MultipartFormDataContent
						{
							{
								new StringContent(SkinInfo.m_ModelMapper ? "slim" : ""),
								"model"
							},
							{
								new ByteArrayContent(File.ReadAllBytes(SkinInfo._IteratorMapper)),
								"file",
								ModBase.GetFileNameFromPath(SkinInfo._IteratorMapper)
							}
						};
						TaskAwaiter<string> taskAwaiter = (await httpClient.PutAsync(new Uri("https://api.mojang.com/user/profile/" + str + "/skin"), content)).Content.ReadAsStringAsync().GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							await taskAwaiter;
							TaskAwaiter<string> taskAwaiter2;
							taskAwaiter = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter<string>);
						}
						string result = taskAwaiter.GetResult();
						taskAwaiter = default(TaskAwaiter<string>);
						string text = result;
						if (ModBase.RegexCheck(text, "^[0-9a-f]{59,64}$", RegexOptions.None))
						{
							MySkin.ReloadCache("http://textures.minecraft.net/texture/" + text, false);
						}
						else if (text.ToLower().Contains("ip not secured"))
						{
							if (ModMain.MyMsgBox("首次操作需要在官网验证密保问题。\r\n验证完成后，你即可使用 PCL 更改皮肤，且无需再次验证。", "验证密保问题", "开始验证", "取消", "", false, true, false) == 1)
							{
								ModBase.OpenWebsite("https://www.minecraft.net/zh-hans/profile/skin");
							}
						}
						else if (text.Contains("request requires user authentication"))
						{
							ModMain.Hint("正在重新登录，请稍后再次尝试更改皮肤！", ModMain.HintType.Info, true);
							ModBase.RunInUi(delegate()
							{
								this.BtnExit_Click();
								if (string.IsNullOrEmpty(ModLaunch.McLoginAble()))
								{
									ModLaunch._InfoIterator.Start(null, false);
								}
							}, false);
						}
						else
						{
							if (!text.Contains("\"errorMessage\""))
							{
								throw new Exception("未知错误（" + text + "）");
							}
							ModMain.Hint(Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject("更改皮肤失败：", NewLateBinding.LateIndexGet(ModBase.GetJson(text), new object[]
							{
								"errorMessage"
							}, null)))), ModMain.HintType.Critical, true);
						}
					}
					catch (Exception ex)
					{
						if (ex.GetType().Equals(typeof(TaskCanceledException)))
						{
							ModMain.Hint("更改皮肤失败：与 Mojang 皮肤服务器的连接超时，请检查你的网络是否通畅！", ModMain.HintType.Critical, true);
						}
						else
						{
							ModBase.Log(ex, "更改皮肤失败", ModBase.LogLevel.Hint, "出现错误");
						}
					}
				}, "Mojang Skin Upload", ThreadPriority.Normal);
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000AB3 RID: 2739 RVA: 0x00007F22 File Offset: 0x00006122
		// (set) Token: 0x06000AB4 RID: 2740 RVA: 0x0005B1BC File Offset: 0x000593BC
		internal virtual Grid PanData
		{
			[CompilerGenerated]
			get
			{
				return this.m_OrderExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.PageLoginMojangSkin_MouseEnter);
				MouseEventHandler value3 = new MouseEventHandler(this.PageLoginMojangSkin_MouseLeave);
				Grid orderExpression = this.m_OrderExpression;
				if (orderExpression != null)
				{
					orderExpression.MouseEnter -= value2;
					orderExpression.MouseLeave -= value3;
				}
				this.m_OrderExpression = value;
				orderExpression = this.m_OrderExpression;
				if (orderExpression != null)
				{
					orderExpression.MouseEnter += value2;
					orderExpression.MouseLeave += value3;
				}
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000AB5 RID: 2741 RVA: 0x00007F2A File Offset: 0x0000612A
		// (set) Token: 0x06000AB6 RID: 2742 RVA: 0x00007F32 File Offset: 0x00006132
		internal virtual TextBlock TextName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000AB7 RID: 2743 RVA: 0x00007F3B File Offset: 0x0000613B
		// (set) Token: 0x06000AB8 RID: 2744 RVA: 0x00007F43 File Offset: 0x00006143
		internal virtual TextBlock TextEmail { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000AB9 RID: 2745 RVA: 0x00007F4C File Offset: 0x0000614C
		// (set) Token: 0x06000ABA RID: 2746 RVA: 0x0005B21C File Offset: 0x0005941C
		internal virtual MyIconButton BtnEdit
		{
			[CompilerGenerated]
			get
			{
				return this.codeExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyIconButton.ClickEventHandler value2 = new MyIconButton.ClickEventHandler(this.BtnEdit_Click);
				MyIconButton myIconButton = this.codeExpression;
				if (myIconButton != null)
				{
					myIconButton.Click -= value2;
				}
				this.codeExpression = value;
				myIconButton = this.codeExpression;
				if (myIconButton != null)
				{
					myIconButton.Click += value2;
				}
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000ABB RID: 2747 RVA: 0x00007F54 File Offset: 0x00006154
		// (set) Token: 0x06000ABC RID: 2748 RVA: 0x0005B260 File Offset: 0x00059460
		internal virtual MyIconButton BtnExit
		{
			[CompilerGenerated]
			get
			{
				return this._MappingExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyIconButton.ClickEventHandler value2 = delegate(object sender, EventArgs e)
				{
					this.BtnExit_Click();
				};
				MyIconButton mappingExpression = this._MappingExpression;
				if (mappingExpression != null)
				{
					mappingExpression.Click -= value2;
				}
				this._MappingExpression = value;
				mappingExpression = this._MappingExpression;
				if (mappingExpression != null)
				{
					mappingExpression.Click += value2;
				}
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000ABD RID: 2749 RVA: 0x00007F5C File Offset: 0x0000615C
		// (set) Token: 0x06000ABE RID: 2750 RVA: 0x0005B2A4 File Offset: 0x000594A4
		internal virtual MySkin Skin
		{
			[CompilerGenerated]
			get
			{
				return this._BridgeExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MySkin.ClickEventHandler obj = new MySkin.ClickEventHandler(this.Skin_Click);
				MySkin bridgeExpression = this._BridgeExpression;
				if (bridgeExpression != null)
				{
					bridgeExpression.CollectModel(obj);
				}
				this._BridgeExpression = value;
				bridgeExpression = this._BridgeExpression;
				if (bridgeExpression != null)
				{
					bridgeExpression.SearchModel(obj);
				}
			}
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x0005B2E8 File Offset: 0x000594E8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.singletonExpression)
			{
				this.singletonExpression = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagelaunch/pageloginmojangskin.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x0005B318 File Offset: 0x00059518
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
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
			this.singletonExpression = true;
		}

		// Token: 0x040005D9 RID: 1497
		[CompilerGenerated]
		[AccessedThroughProperty("PanData")]
		private Grid m_OrderExpression;

		// Token: 0x040005DA RID: 1498
		[CompilerGenerated]
		[AccessedThroughProperty("TextName")]
		private TextBlock _ServiceExpression;

		// Token: 0x040005DB RID: 1499
		[CompilerGenerated]
		[AccessedThroughProperty("TextEmail")]
		private TextBlock _FacadeExpression;

		// Token: 0x040005DC RID: 1500
		[CompilerGenerated]
		[AccessedThroughProperty("BtnEdit")]
		private MyIconButton codeExpression;

		// Token: 0x040005DD RID: 1501
		[AccessedThroughProperty("BtnExit")]
		[CompilerGenerated]
		private MyIconButton _MappingExpression;

		// Token: 0x040005DE RID: 1502
		[CompilerGenerated]
		[AccessedThroughProperty("Skin")]
		private MySkin _BridgeExpression;

		// Token: 0x040005DF RID: 1503
		private bool singletonExpression;
	}
}
