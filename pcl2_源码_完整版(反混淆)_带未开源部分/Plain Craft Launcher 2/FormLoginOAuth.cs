using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Navigation;

namespace PCL
{
	// Token: 0x0200008D RID: 141
	[DesignerGenerated]
	public class FormLoginOAuth : Window, IComponentConnector
	{
		// Token: 0x060004D9 RID: 1241 RVA: 0x00004EBB File Offset: 0x000030BB
		// Note: this type is marked as 'beforefieldinit'.
		static FormLoginOAuth()
		{
			FormLoginOAuth.strategyContainer = "https://login.microsoftonline.com/consumers/oauth2/v2.0/authorize?prompt=login&client_id=00000000402b5328&response_type=code&scope=service%3A%3Auser.auth.xboxlive.com%3A%3AMBI_SSL&redirect_uri=https:%2F%2Flogin.live.com%2Foauth20_desktop.srf";
			FormLoginOAuth.wrapperContainer = "https://login.live.com/oauth20_authorize.srf?prompt=login&client_id=00000000402b5328&response_type=code&scope=service%3A%3Auser.auth.xboxlive.com%3A%3AMBI_SSL&redirect_uri=https:%2F%2Flogin.live.com%2Foauth20_desktop.srf";
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x000298CC File Offset: 0x00027ACC
		public FormLoginOAuth()
		{
			base.Loaded += this.FrmLoginOAuth_Loaded;
			base.Closed += delegate(object sender, EventArgs e)
			{
				this.FormLoginOAuth_Closed();
			};
			this._AttributeContainer = false;
			this._ValueContainer = false;
			this._RoleContainer = false;
			this.advisorContainer = RuntimeHelpers.GetObjectValue(new object());
			this.InitializeComponent();
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00029930 File Offset: 0x00027B30
		[CompilerGenerated]
		public void SelectContainer(FormLoginOAuth.OnLoginSuccessEventHandler obj)
		{
			FormLoginOAuth.OnLoginSuccessEventHandler onLoginSuccessEventHandler = this.m_ComparatorContainer;
			FormLoginOAuth.OnLoginSuccessEventHandler onLoginSuccessEventHandler2;
			do
			{
				onLoginSuccessEventHandler2 = onLoginSuccessEventHandler;
				FormLoginOAuth.OnLoginSuccessEventHandler value = (FormLoginOAuth.OnLoginSuccessEventHandler)Delegate.Combine(onLoginSuccessEventHandler2, obj);
				onLoginSuccessEventHandler = Interlocked.CompareExchange<FormLoginOAuth.OnLoginSuccessEventHandler>(ref this.m_ComparatorContainer, value, onLoginSuccessEventHandler2);
			}
			while (onLoginSuccessEventHandler != onLoginSuccessEventHandler2);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00029968 File Offset: 0x00027B68
		[CompilerGenerated]
		public void ExcludeContainer(FormLoginOAuth.OnLoginSuccessEventHandler obj)
		{
			FormLoginOAuth.OnLoginSuccessEventHandler onLoginSuccessEventHandler = this.m_ComparatorContainer;
			FormLoginOAuth.OnLoginSuccessEventHandler onLoginSuccessEventHandler2;
			do
			{
				onLoginSuccessEventHandler2 = onLoginSuccessEventHandler;
				FormLoginOAuth.OnLoginSuccessEventHandler value = (FormLoginOAuth.OnLoginSuccessEventHandler)Delegate.Remove(onLoginSuccessEventHandler2, obj);
				onLoginSuccessEventHandler = Interlocked.CompareExchange<FormLoginOAuth.OnLoginSuccessEventHandler>(ref this.m_ComparatorContainer, value, onLoginSuccessEventHandler2);
			}
			while (onLoginSuccessEventHandler != onLoginSuccessEventHandler2);
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x000299A0 File Offset: 0x00027BA0
		[CompilerGenerated]
		public void TestContainer(FormLoginOAuth.OnLoginCanceledEventHandler obj)
		{
			FormLoginOAuth.OnLoginCanceledEventHandler onLoginCanceledEventHandler = this._RegistryContainer;
			FormLoginOAuth.OnLoginCanceledEventHandler onLoginCanceledEventHandler2;
			do
			{
				onLoginCanceledEventHandler2 = onLoginCanceledEventHandler;
				FormLoginOAuth.OnLoginCanceledEventHandler value = (FormLoginOAuth.OnLoginCanceledEventHandler)Delegate.Combine(onLoginCanceledEventHandler2, obj);
				onLoginCanceledEventHandler = Interlocked.CompareExchange<FormLoginOAuth.OnLoginCanceledEventHandler>(ref this._RegistryContainer, value, onLoginCanceledEventHandler2);
			}
			while (onLoginCanceledEventHandler != onLoginCanceledEventHandler2);
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x000299D8 File Offset: 0x00027BD8
		[CompilerGenerated]
		public void ReadContainer(FormLoginOAuth.OnLoginCanceledEventHandler obj)
		{
			FormLoginOAuth.OnLoginCanceledEventHandler onLoginCanceledEventHandler = this._RegistryContainer;
			FormLoginOAuth.OnLoginCanceledEventHandler onLoginCanceledEventHandler2;
			do
			{
				onLoginCanceledEventHandler2 = onLoginCanceledEventHandler;
				FormLoginOAuth.OnLoginCanceledEventHandler value = (FormLoginOAuth.OnLoginCanceledEventHandler)Delegate.Remove(onLoginCanceledEventHandler2, obj);
				onLoginCanceledEventHandler = Interlocked.CompareExchange<FormLoginOAuth.OnLoginCanceledEventHandler>(ref this._RegistryContainer, value, onLoginCanceledEventHandler2);
			}
			while (onLoginCanceledEventHandler != onLoginCanceledEventHandler2);
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00029A10 File Offset: 0x00027C10
		private void Browser_Navigating(WebBrowser sender, NavigatingCancelEventArgs e)
		{
			string absoluteUri = e.Uri.AbsoluteUri;
			if (ModBase.errorRule)
			{
				ModBase.Log(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("[Login] 登录浏览器 ", sender.Tag), " 导向："), absoluteUri)), ModBase.LogLevel.Normal, "出现错误");
			}
			if (absoluteUri.Contains("code="))
			{
				string text = ModBase.RegexSeek(absoluteUri, "(?<=code\\=)[^&]+", RegexOptions.None);
				ModBase.Log("[Login] 抓取到 OAuth 返回码：" + text, ModBase.LogLevel.Normal, "出现错误");
				this._AttributeContainer = true;
				FormLoginOAuth.OnLoginSuccessEventHandler comparatorContainer = this.m_ComparatorContainer;
				if (comparatorContainer != null)
				{
					comparatorContainer(text);
					return;
				}
			}
			else if (absoluteUri.Contains("github."))
			{
				ModMain.Hint("PCL2 不支持使用 GitHub 登录微软账号！", ModMain.HintType.Critical, true);
				this._ValueContainer = true;
				base.Close();
			}
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00029AD0 File Offset: 0x00027CD0
		private void Browser_Navigated(WebBrowser sender, NavigationEventArgs e)
		{
			object obj = this.advisorContainer;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			lock (obj)
			{
				if (this._RoleContainer)
				{
					return;
				}
				this._RoleContainer = true;
			}
			Action $I1;
			ModBase.RunInThread(delegate
			{
				Thread.Sleep(0x3E8);
				ModBase.RunInUi(($I1 == null) ? ($I1 = delegate()
				{
					sender.Visibility = Visibility.Visible;
					this.PanLoading.Visibility = Visibility.Collapsed;
				}) : $I1, false);
			});
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00004ED1 File Offset: 0x000030D1
		private void FrmLoginOAuth_Loaded(object sender, RoutedEventArgs e)
		{
			this.Browser1.Navigate(FormLoginOAuth.strategyContainer);
			ModBase.RunInThread(delegate
			{
				Thread.Sleep(0x5DC);
				ModBase.RunInUi(delegate()
				{
					try
					{
						if (!this._RoleContainer)
						{
							this.Browser2.Navigate(FormLoginOAuth.strategyContainer);
						}
					}
					catch (Exception ex)
					{
					}
				}, false);
				Thread.Sleep(0x5DC);
				ModBase.RunInUi(delegate()
				{
					try
					{
						if (!this._RoleContainer)
						{
							this.Browser3.Navigate(FormLoginOAuth.wrapperContainer);
						}
					}
					catch (Exception ex)
					{
					}
				}, false);
			});
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00029B48 File Offset: 0x00027D48
		private void FormLoginOAuth_Closed()
		{
			try
			{
				this.Browser1.Dispose();
				this.Browser2.Dispose();
				this.Browser3.Dispose();
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "释放微软登录浏览器失败", ModBase.LogLevel.Debug, "出现错误");
			}
			if (!this._AttributeContainer)
			{
				FormLoginOAuth.OnLoginCanceledEventHandler registryContainer = this._RegistryContainer;
				if (registryContainer != null)
				{
					registryContainer(this._ValueContainer);
				}
			}
			ModMain.m_GetterFilter.Focus();
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060004E3 RID: 1251 RVA: 0x00004EF4 File Offset: 0x000030F4
		// (set) Token: 0x060004E4 RID: 1252 RVA: 0x00004EFC File Offset: 0x000030FC
		internal virtual StackPanel PanLoading { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060004E5 RID: 1253 RVA: 0x00004F05 File Offset: 0x00003105
		// (set) Token: 0x060004E6 RID: 1254 RVA: 0x00004F0D File Offset: 0x0000310D
		internal virtual MyLoading Loading { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060004E7 RID: 1255 RVA: 0x00004F16 File Offset: 0x00003116
		// (set) Token: 0x060004E8 RID: 1256 RVA: 0x00029BD0 File Offset: 0x00027DD0
		internal virtual WebBrowser Browser1
		{
			[CompilerGenerated]
			get
			{
				return this.m_RecordContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				NavigatingCancelEventHandler value2 = delegate(object sender, NavigatingCancelEventArgs e)
				{
					this.Browser_Navigating((WebBrowser)sender, e);
				};
				NavigatedEventHandler value3 = delegate(object sender, NavigationEventArgs e)
				{
					this.Browser_Navigated((WebBrowser)sender, e);
				};
				WebBrowser recordContainer = this.m_RecordContainer;
				if (recordContainer != null)
				{
					recordContainer.Navigating -= value2;
					recordContainer.Navigated -= value3;
				}
				this.m_RecordContainer = value;
				recordContainer = this.m_RecordContainer;
				if (recordContainer != null)
				{
					recordContainer.Navigating += value2;
					recordContainer.Navigated += value3;
				}
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060004E9 RID: 1257 RVA: 0x00004F1E File Offset: 0x0000311E
		// (set) Token: 0x060004EA RID: 1258 RVA: 0x00029C30 File Offset: 0x00027E30
		internal virtual WebBrowser Browser2
		{
			[CompilerGenerated]
			get
			{
				return this.m_GetterContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				NavigatingCancelEventHandler value2 = delegate(object sender, NavigatingCancelEventArgs e)
				{
					this.Browser_Navigating((WebBrowser)sender, e);
				};
				NavigatedEventHandler value3 = delegate(object sender, NavigationEventArgs e)
				{
					this.Browser_Navigated((WebBrowser)sender, e);
				};
				WebBrowser getterContainer = this.m_GetterContainer;
				if (getterContainer != null)
				{
					getterContainer.Navigating -= value2;
					getterContainer.Navigated -= value3;
				}
				this.m_GetterContainer = value;
				getterContainer = this.m_GetterContainer;
				if (getterContainer != null)
				{
					getterContainer.Navigating += value2;
					getterContainer.Navigated += value3;
				}
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x00004F26 File Offset: 0x00003126
		// (set) Token: 0x060004EC RID: 1260 RVA: 0x00029C90 File Offset: 0x00027E90
		internal virtual WebBrowser Browser3
		{
			[CompilerGenerated]
			get
			{
				return this._InterceptorContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				NavigatingCancelEventHandler value2 = delegate(object sender, NavigatingCancelEventArgs e)
				{
					this.Browser_Navigating((WebBrowser)sender, e);
				};
				NavigatedEventHandler value3 = delegate(object sender, NavigationEventArgs e)
				{
					this.Browser_Navigated((WebBrowser)sender, e);
				};
				WebBrowser interceptorContainer = this._InterceptorContainer;
				if (interceptorContainer != null)
				{
					interceptorContainer.Navigating -= value2;
					interceptorContainer.Navigated -= value3;
				}
				this._InterceptorContainer = value;
				interceptorContainer = this._InterceptorContainer;
				if (interceptorContainer != null)
				{
					interceptorContainer.Navigating += value2;
					interceptorContainer.Navigated += value3;
				}
			}
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x00029CF0 File Offset: 0x00027EF0
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this._InvocationContainer)
			{
				this._InvocationContainer = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagelaunch/formloginoauth.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x00029D20 File Offset: 0x00027F20
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanLoading = (StackPanel)target;
				return;
			}
			if (connectionId == 2)
			{
				this.Loading = (MyLoading)target;
				return;
			}
			if (connectionId == 3)
			{
				this.Browser1 = (WebBrowser)target;
				return;
			}
			if (connectionId == 4)
			{
				this.Browser2 = (WebBrowser)target;
				return;
			}
			if (connectionId == 5)
			{
				this.Browser3 = (WebBrowser)target;
				return;
			}
			this._InvocationContainer = true;
		}

		// Token: 0x04000263 RID: 611
		[CompilerGenerated]
		private FormLoginOAuth.OnLoginSuccessEventHandler m_ComparatorContainer;

		// Token: 0x04000264 RID: 612
		[CompilerGenerated]
		private FormLoginOAuth.OnLoginCanceledEventHandler _RegistryContainer;

		// Token: 0x04000265 RID: 613
		private bool _AttributeContainer;

		// Token: 0x04000266 RID: 614
		private bool _ValueContainer;

		// Token: 0x04000267 RID: 615
		private bool _RoleContainer;

		// Token: 0x04000268 RID: 616
		private object advisorContainer;

		// Token: 0x04000269 RID: 617
		public static string strategyContainer;

		// Token: 0x0400026A RID: 618
		public static string wrapperContainer;

		// Token: 0x0400026B RID: 619
		[CompilerGenerated]
		[AccessedThroughProperty("PanLoading")]
		private StackPanel _WriterContainer;

		// Token: 0x0400026C RID: 620
		[AccessedThroughProperty("Loading")]
		[CompilerGenerated]
		private MyLoading _ExporterContainer;

		// Token: 0x0400026D RID: 621
		[AccessedThroughProperty("Browser1")]
		[CompilerGenerated]
		private WebBrowser m_RecordContainer;

		// Token: 0x0400026E RID: 622
		[AccessedThroughProperty("Browser2")]
		[CompilerGenerated]
		private WebBrowser m_GetterContainer;

		// Token: 0x0400026F RID: 623
		[CompilerGenerated]
		[AccessedThroughProperty("Browser3")]
		private WebBrowser _InterceptorContainer;

		// Token: 0x04000270 RID: 624
		private bool _InvocationContainer;

		// Token: 0x0200008E RID: 142
		// (Invoke) Token: 0x060004FD RID: 1277
		public delegate void OnLoginSuccessEventHandler(string code);

		// Token: 0x0200008F RID: 143
		// (Invoke) Token: 0x06000501 RID: 1281
		public delegate void OnLoginCanceledEventHandler(bool IsForceExit);
	}
}
