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
	// Token: 0x02000129 RID: 297
	[DesignerGenerated]
	public class PageLoginMojang : Grid, IComponentConnector
	{
		// Token: 0x06000A90 RID: 2704 RVA: 0x00007DFF File Offset: 0x00005FFF
		public PageLoginMojang()
		{
			this._RuleExpression = true;
			this.InitializeComponent();
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x0005A844 File Offset: 0x00058A44
		public void Reload(bool KeepInput)
		{
			this.CheckRemember.Checked = Conversions.ToBoolean(ModBase._BaseRule.Get("LoginRemember", null));
			if (KeepInput && !this._RuleExpression)
			{
				string text = this.ComboName.Text;
				this.ComboName.ItemsSource = (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LoginMojangEmail", null), "", true) ? null : ModBase._BaseRule.Get("LoginMojangEmail", null).ToString().Split(new char[]
				{
					'¨'
				}));
				this.ComboName.Text = text;
			}
			else if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LoginMojangEmail", null), "", true))
			{
				this.ComboName.ItemsSource = null;
			}
			else
			{
				this.ComboName.ItemsSource = ModBase._BaseRule.Get("LoginMojangEmail", null).ToString().Split(new char[]
				{
					'¨'
				});
				this.ComboName.Text = ModBase._BaseRule.Get("LoginMojangEmail", null).ToString().Split(new char[]
				{
					'¨'
				})[0];
				if (Conversions.ToBoolean(ModBase._BaseRule.Get("LoginRemember", null)))
				{
					this.TextPass.Password = ModBase._BaseRule.Get("LoginMojangPass", null).ToString().Split(new char[]
					{
						'¨'
					})[0].Trim();
				}
			}
			this._RuleExpression = false;
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x0005A9DC File Offset: 0x00058BDC
		public ModLaunch.McLoginServer GetLoginData()
		{
			return new ModLaunch.McLoginServer(ModLaunch.McLoginType.Mojang)
			{
				_InitializerAlgo = "https://authserver.mojang.com",
				propertyAlgo = "Mojang",
				_DispatcherAlgo = (this.ComboName.Text ?? "").Replace("¨", "").Trim(),
				_TagAlgo = (this.TextPass.Password ?? "").Replace("¨", "").Trim(),
				Type = ModLaunch.McLoginType.Mojang,
				_WatcherAlgo = "Mojang 正版"
			};
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x0005AA74 File Offset: 0x00058C74
		public static string IsVaild(ModLaunch.McLoginServer LoginData)
		{
			string result;
			if (Operators.CompareString(LoginData._DispatcherAlgo, "", true) == 0)
			{
				result = "邮箱不能为空！";
			}
			else if (!LoginData._DispatcherAlgo.Contains("@"))
			{
				result = "邮箱格式错误！";
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

		// Token: 0x06000A94 RID: 2708 RVA: 0x00007E14 File Offset: 0x00006014
		public string IsVaild()
		{
			return PageLoginMojang.IsVaild(this.GetLoginData());
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x0005AAD8 File Offset: 0x00058CD8
		private void ComboMojangName_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(sender, null, "Text", new object[0], null, null, null), "", true))
			{
				this.TextPass.Password = "";
			}
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set("CacheMojangAccess", "", false, null);
			}
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x00007E21 File Offset: 0x00006021
		private void TextMojangPass_PasswordChanged(object sender, RoutedEventArgs e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set("CacheMojangAccess", "", false, null);
			}
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x0005AB34 File Offset: 0x00058D34
		private void ComboMojangName_SelectionChanged(MyComboBox sender, SelectionChangedEventArgs e)
		{
			if (Conversions.ToBoolean(sender.SelectedIndex == -1 || Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("LoginRemember", null)))))
			{
				this.TextPass.Password = "";
				return;
			}
			this.TextPass.Password = ModBase._BaseRule.Get("LoginMojangPass", null).ToString().Split(new char[]
			{
				'¨'
			})[sender.SelectedIndex].Trim();
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x00004FEE File Offset: 0x000031EE
		private void CheckRememberChange(MyCheckBox sender, object e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set(Conversions.ToString(sender.Tag), sender.Checked, false, null);
			}
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x0005ABC4 File Offset: 0x00058DC4
		private void InputChanged()
		{
			this.BtnLink.Content = ((Operators.CompareString(this.ComboName.Text, "", true) != 0 || Operators.CompareString(this.TextPass.Password, "", true) != 0) ? "找回密码" : "购买正版");
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x00007E40 File Offset: 0x00006040
		private void BtnMojang_Click(object sender, EventArgs e)
		{
			if (Operators.ConditionalCompareObjectEqual(this.BtnLink.Content, "购买正版", true))
			{
				ModBase.OpenWebsite("https://www.minecraft.net/store/minecraft-java-edition/buy");
				return;
			}
			ModBase.OpenWebsite("https://account.mojang.com/password");
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000A9B RID: 2715 RVA: 0x00007E6F File Offset: 0x0000606F
		// (set) Token: 0x06000A9C RID: 2716 RVA: 0x0005AC18 File Offset: 0x00058E18
		internal virtual MyComboBox ComboName
		{
			[CompilerGenerated]
			get
			{
				return this._AlgoExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyComboBox.TextChangedEventHandler obj = new MyComboBox.TextChangedEventHandler(this.ComboMojangName_TextChanged);
				SelectionChangedEventHandler value2 = delegate(object sender, SelectionChangedEventArgs e)
				{
					this.ComboMojangName_SelectionChanged((MyComboBox)sender, e);
				};
				MyComboBox.TextChangedEventHandler obj2 = delegate(object sender, TextChangedEventArgs e)
				{
					this.InputChanged();
				};
				MyComboBox algoExpression = this._AlgoExpression;
				if (algoExpression != null)
				{
					algoExpression.StartFactory(obj);
					algoExpression.SelectionChanged -= value2;
					algoExpression.StartFactory(obj2);
				}
				this._AlgoExpression = value;
				algoExpression = this._AlgoExpression;
				if (algoExpression != null)
				{
					algoExpression.GetFactory(obj);
					algoExpression.SelectionChanged += value2;
					algoExpression.GetFactory(obj2);
				}
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000A9D RID: 2717 RVA: 0x00007E77 File Offset: 0x00006077
		// (set) Token: 0x06000A9E RID: 2718 RVA: 0x0005AC94 File Offset: 0x00058E94
		internal virtual PasswordBox TextPass
		{
			[CompilerGenerated]
			get
			{
				return this.mapperExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = new RoutedEventHandler(this.TextMojangPass_PasswordChanged);
				RoutedEventHandler value3 = delegate(object sender, RoutedEventArgs e)
				{
					this.InputChanged();
				};
				PasswordBox passwordBox = this.mapperExpression;
				if (passwordBox != null)
				{
					passwordBox.PasswordChanged -= value2;
					passwordBox.PasswordChanged -= value3;
				}
				this.mapperExpression = value;
				passwordBox = this.mapperExpression;
				if (passwordBox != null)
				{
					passwordBox.PasswordChanged += value2;
					passwordBox.PasswordChanged += value3;
				}
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000A9F RID: 2719 RVA: 0x00007E7F File Offset: 0x0000607F
		// (set) Token: 0x06000AA0 RID: 2720 RVA: 0x0005ACF4 File Offset: 0x00058EF4
		internal virtual MyCheckBox CheckRemember
		{
			[CompilerGenerated]
			get
			{
				return this.paramsExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyCheckBox.ChangeEventHandler obj = delegate(object a0, bool a1)
				{
					this.CheckRememberChange((MyCheckBox)a0, a1);
				};
				MyCheckBox myCheckBox = this.paramsExpression;
				if (myCheckBox != null)
				{
					myCheckBox.SearchIterator(obj);
				}
				this.paramsExpression = value;
				myCheckBox = this.paramsExpression;
				if (myCheckBox != null)
				{
					myCheckBox.RunIterator(obj);
				}
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000AA1 RID: 2721 RVA: 0x00007E87 File Offset: 0x00006087
		// (set) Token: 0x06000AA2 RID: 2722 RVA: 0x0005AD38 File Offset: 0x00058F38
		internal virtual MyTextButton BtnLink
		{
			[CompilerGenerated]
			get
			{
				return this.globalExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyTextButton.ClickEventHandler obj = new MyTextButton.ClickEventHandler(this.BtnMojang_Click);
				MyTextButton myTextButton = this.globalExpression;
				if (myTextButton != null)
				{
					myTextButton.FindContainer(obj);
				}
				this.globalExpression = value;
				myTextButton = this.globalExpression;
				if (myTextButton != null)
				{
					myTextButton.CreateContainer(obj);
				}
			}
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x0005AD7C File Offset: 0x00058F7C
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this._IssuerExpression)
			{
				this._IssuerExpression = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagelaunch/pageloginmojang.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x0005ADAC File Offset: 0x00058FAC
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
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
			this._IssuerExpression = true;
		}

		// Token: 0x040005D3 RID: 1491
		private bool _RuleExpression;

		// Token: 0x040005D4 RID: 1492
		[CompilerGenerated]
		[AccessedThroughProperty("ComboName")]
		private MyComboBox _AlgoExpression;

		// Token: 0x040005D5 RID: 1493
		[AccessedThroughProperty("TextPass")]
		[CompilerGenerated]
		private PasswordBox mapperExpression;

		// Token: 0x040005D6 RID: 1494
		[CompilerGenerated]
		[AccessedThroughProperty("CheckRemember")]
		private MyCheckBox paramsExpression;

		// Token: 0x040005D7 RID: 1495
		[CompilerGenerated]
		[AccessedThroughProperty("BtnLink")]
		private MyTextButton globalExpression;

		// Token: 0x040005D8 RID: 1496
		private bool _IssuerExpression;
	}
}
