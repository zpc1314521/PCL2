using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x02000091 RID: 145
	[DesignerGenerated]
	public class PageLoginAuth : Grid, IComponentConnector
	{
		// Token: 0x06000505 RID: 1285 RVA: 0x00004FAD File Offset: 0x000031AD
		public PageLoginAuth()
		{
			this._CandidateContainer = true;
			this.InitializeComponent();
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x00029E58 File Offset: 0x00028058
		public void Reload(bool KeepInput)
		{
			this.CheckRemember.Checked = Conversions.ToBoolean(ModBase._BaseRule.Get("LoginRemember", null));
			if (KeepInput && !this._CandidateContainer)
			{
				string text = this.ComboName.Text;
				this.ComboName.ItemsSource = (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LoginAuthEmail", null), "", true) ? null : ModBase._BaseRule.Get("LoginAuthEmail", null).ToString().Split(new char[]
				{
					'¨'
				}));
				this.ComboName.Text = text;
			}
			else if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LoginAuthEmail", null), "", true))
			{
				this.ComboName.ItemsSource = null;
			}
			else
			{
				this.ComboName.ItemsSource = ModBase._BaseRule.Get("LoginAuthEmail", null).ToString().Split(new char[]
				{
					'¨'
				});
				this.ComboName.Text = ModBase._BaseRule.Get("LoginAuthEmail", null).ToString().Split(new char[]
				{
					'¨'
				})[0];
				if (Conversions.ToBoolean(ModBase._BaseRule.Get("LoginRemember", null)))
				{
					this.TextPass.Password = ModBase._BaseRule.Get("LoginAuthPass", null).ToString().Split(new char[]
					{
						'¨'
					})[0].Trim();
				}
			}
			this._CandidateContainer = false;
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x00029FF0 File Offset: 0x000281F0
		public ModLaunch.McLoginServer GetLoginData()
		{
			string initializerAlgo = Conversions.ToString(Operators.ConcatenateObject(Information.IsNothing(ModMinecraft.ValidateContainer()) ? ModBase._BaseRule.Get("CacheAuthServerServer", null) : ModBase._BaseRule.Get("VersionServerAuthServer", ModMinecraft.ValidateContainer()), "/authserver"));
			return new ModLaunch.McLoginServer(ModLaunch.McLoginType.Auth)
			{
				propertyAlgo = "Auth",
				_InitializerAlgo = initializerAlgo,
				_DispatcherAlgo = this.ComboName.Text.Replace("¨", "").Trim(),
				_TagAlgo = this.TextPass.Password.Replace("¨", "").Trim(),
				_WatcherAlgo = "Authlib-Injector",
				Type = ModLaunch.McLoginType.Auth
			};
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x0002A0B4 File Offset: 0x000282B4
		public static string IsVaild(ModLaunch.McLoginServer LoginData)
		{
			string result;
			if (Operators.CompareString(LoginData._DispatcherAlgo, "", true) == 0)
			{
				result = "账号不能为空！";
			}
			else if (Operators.CompareString(LoginData._TagAlgo, "", true) == 0)
			{
				result = "密码不能为空！";
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x00004FC2 File Offset: 0x000031C2
		public string IsVaild()
		{
			return PageLoginAuth.IsVaild(this.GetLoginData());
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x0002A100 File Offset: 0x00028300
		private void ComboName_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(sender, null, "Text", new object[0], null, null, null), "", true))
			{
				this.TextPass.Password = "";
			}
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set("CacheAuthAccess", "", false, null);
			}
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x00004FCF File Offset: 0x000031CF
		private void TextPass_PasswordChanged(object sender, RoutedEventArgs e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set("CacheAuthAccess", "", false, null);
			}
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0002A15C File Offset: 0x0002835C
		private void ComboName_SelectionChanged(MyComboBox sender, SelectionChangedEventArgs e)
		{
			if (Conversions.ToBoolean(sender.SelectedIndex == -1 || Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("LoginRemember", null)))))
			{
				this.TextPass.Password = "";
				return;
			}
			this.TextPass.Password = ModBase._BaseRule.Get("LoginAuthPass", null).ToString().Split(new char[]
			{
				'¨'
			})[sender.SelectedIndex].Trim();
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x00004FEE File Offset: 0x000031EE
		private void CheckBoxChange(MyCheckBox sender, object e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set(Conversions.ToString(sender.Tag), sender.Checked, false, null);
			}
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x00005019 File Offset: 0x00003219
		private void ComboName_TextChanged()
		{
			this.BtnLink.Content = ((Operators.CompareString(this.ComboName.Text, "", true) == 0) ? "注册账号" : "找回密码");
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x0000504A File Offset: 0x0000324A
		private void Btn_Click(object sender, EventArgs e)
		{
			ModBase.OpenWebsite(Conversions.ToString((ModMinecraft.ValidateContainer() == null) ? ModBase._BaseRule.Get("VersionServerAuthRegister", ModMinecraft.ValidateContainer()) : ModBase._BaseRule.Get("CacheAuthServerRegister", null)));
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000510 RID: 1296 RVA: 0x00005083 File Offset: 0x00003283
		// (set) Token: 0x06000511 RID: 1297 RVA: 0x0002A1EC File Offset: 0x000283EC
		internal virtual MyComboBox ComboName
		{
			[CompilerGenerated]
			get
			{
				return this._DescriptorContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyComboBox.TextChangedEventHandler obj = new MyComboBox.TextChangedEventHandler(this.ComboName_TextChanged);
				SelectionChangedEventHandler value2 = delegate(object sender, SelectionChangedEventArgs e)
				{
					this.ComboName_SelectionChanged((MyComboBox)sender, e);
				};
				MyComboBox.TextChangedEventHandler obj2 = delegate(object sender, TextChangedEventArgs e)
				{
					this.ComboName_TextChanged();
				};
				MyComboBox descriptorContainer = this._DescriptorContainer;
				if (descriptorContainer != null)
				{
					descriptorContainer.StartFactory(obj);
					descriptorContainer.SelectionChanged -= value2;
					descriptorContainer.StartFactory(obj2);
				}
				this._DescriptorContainer = value;
				descriptorContainer = this._DescriptorContainer;
				if (descriptorContainer != null)
				{
					descriptorContainer.GetFactory(obj);
					descriptorContainer.SelectionChanged += value2;
					descriptorContainer.GetFactory(obj2);
				}
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000512 RID: 1298 RVA: 0x0000508B File Offset: 0x0000328B
		// (set) Token: 0x06000513 RID: 1299 RVA: 0x0002A268 File Offset: 0x00028468
		internal virtual PasswordBox TextPass
		{
			[CompilerGenerated]
			get
			{
				return this._ContextContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = new RoutedEventHandler(this.TextPass_PasswordChanged);
				PasswordBox contextContainer = this._ContextContainer;
				if (contextContainer != null)
				{
					contextContainer.PasswordChanged -= value2;
				}
				this._ContextContainer = value;
				contextContainer = this._ContextContainer;
				if (contextContainer != null)
				{
					contextContainer.PasswordChanged += value2;
				}
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000514 RID: 1300 RVA: 0x00005093 File Offset: 0x00003293
		// (set) Token: 0x06000515 RID: 1301 RVA: 0x0002A2AC File Offset: 0x000284AC
		internal virtual MyCheckBox CheckRemember
		{
			[CompilerGenerated]
			get
			{
				return this.observerContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyCheckBox.ChangeEventHandler obj = delegate(object a0, bool a1)
				{
					this.CheckBoxChange((MyCheckBox)a0, a1);
				};
				MyCheckBox myCheckBox = this.observerContainer;
				if (myCheckBox != null)
				{
					myCheckBox.SearchIterator(obj);
				}
				this.observerContainer = value;
				myCheckBox = this.observerContainer;
				if (myCheckBox != null)
				{
					myCheckBox.RunIterator(obj);
				}
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000516 RID: 1302 RVA: 0x0000509B File Offset: 0x0000329B
		// (set) Token: 0x06000517 RID: 1303 RVA: 0x0002A2F0 File Offset: 0x000284F0
		internal virtual MyTextButton BtnLink
		{
			[CompilerGenerated]
			get
			{
				return this.m_TokenizerContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyTextButton.ClickEventHandler obj = new MyTextButton.ClickEventHandler(this.Btn_Click);
				MyTextButton tokenizerContainer = this.m_TokenizerContainer;
				if (tokenizerContainer != null)
				{
					tokenizerContainer.FindContainer(obj);
				}
				this.m_TokenizerContainer = value;
				tokenizerContainer = this.m_TokenizerContainer;
				if (tokenizerContainer != null)
				{
					tokenizerContainer.CreateContainer(obj);
				}
			}
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x0002A334 File Offset: 0x00028534
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this._DispatcherContainer)
			{
				this._DispatcherContainer = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagelaunch/pageloginauth.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x0002A364 File Offset: 0x00028564
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.ComboName = (MyComboBox)target;
				return;
			}
			if (connectionId == 2)
			{
				this.TextPass = (PasswordBox)target;
				return;
			}
			if (connectionId == 3)
			{
				this.CheckRemember = (MyCheckBox)target;
				return;
			}
			if (connectionId == 4)
			{
				this.BtnLink = (MyTextButton)target;
				return;
			}
			this._DispatcherContainer = true;
		}

		// Token: 0x04000274 RID: 628
		private bool _CandidateContainer;

		// Token: 0x04000275 RID: 629
		[AccessedThroughProperty("ComboName")]
		[CompilerGenerated]
		private MyComboBox _DescriptorContainer;

		// Token: 0x04000276 RID: 630
		[AccessedThroughProperty("TextPass")]
		[CompilerGenerated]
		private PasswordBox _ContextContainer;

		// Token: 0x04000277 RID: 631
		[CompilerGenerated]
		[AccessedThroughProperty("CheckRemember")]
		private MyCheckBox observerContainer;

		// Token: 0x04000278 RID: 632
		[AccessedThroughProperty("BtnLink")]
		[CompilerGenerated]
		private MyTextButton m_TokenizerContainer;

		// Token: 0x04000279 RID: 633
		private bool _DispatcherContainer;
	}
}
