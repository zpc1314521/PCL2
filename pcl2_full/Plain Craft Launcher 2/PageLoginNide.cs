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
	// Token: 0x02000127 RID: 295
	[DesignerGenerated]
	public class PageLoginNide : Grid, IComponentConnector
	{
		// Token: 0x06000A67 RID: 2663 RVA: 0x00007C7B File Offset: 0x00005E7B
		public PageLoginNide()
		{
			this.m_FactoryExpression = true;
			this.InitializeComponent();
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x00059FB8 File Offset: 0x000581B8
		public void Reload(bool KeepInput)
		{
			this.CheckRemember.Checked = Conversions.ToBoolean(ModBase._BaseRule.Get("LoginRemember", null));
			if (KeepInput && !this.m_FactoryExpression)
			{
				string text = this.ComboName.Text;
				this.ComboName.ItemsSource = (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LoginNideEmail", null), "", true) ? null : ModBase._BaseRule.Get("LoginNideEmail", null).ToString().Split(new char[]
				{
					'¨'
				}));
				this.ComboName.Text = text;
			}
			else if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LoginNideEmail", null), "", true))
			{
				this.ComboName.ItemsSource = null;
			}
			else
			{
				this.ComboName.ItemsSource = ModBase._BaseRule.Get("LoginNideEmail", null).ToString().Split(new char[]
				{
					'¨'
				});
				this.ComboName.Text = ModBase._BaseRule.Get("LoginNideEmail", null).ToString().Split(new char[]
				{
					'¨'
				})[0];
				if (Conversions.ToBoolean(ModBase._BaseRule.Get("LoginRemember", null)))
				{
					this.TextPass.Password = ModBase._BaseRule.Get("LoginNidePass", null).ToString().Split(new char[]
					{
						'¨'
					})[0].Trim();
				}
			}
			this.m_FactoryExpression = false;
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x0005A150 File Offset: 0x00058350
		public ModLaunch.McLoginServer GetLoginData()
		{
			string str = Conversions.ToString(Information.IsNothing(ModMinecraft.ValidateContainer()) ? ModBase._BaseRule.Get("CacheNideServer", null) : ModBase._BaseRule.Get("VersionServerNide", ModMinecraft.ValidateContainer()));
			return new ModLaunch.McLoginServer(ModLaunch.McLoginType.Nide)
			{
				propertyAlgo = "Nide",
				_DispatcherAlgo = this.ComboName.Text.Replace("¨", "").Trim(),
				_TagAlgo = this.TextPass.Password.Replace("¨", "").Trim(),
				_WatcherAlgo = "统一通行证",
				Type = ModLaunch.McLoginType.Nide,
				_InitializerAlgo = "https://auth2.nide8.com:233/" + str + "/authserver"
			};
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x0002A0B4 File Offset: 0x000282B4
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

		// Token: 0x06000A6B RID: 2667 RVA: 0x00007C90 File Offset: 0x00005E90
		public string IsVaild()
		{
			return PageLoginNide.IsVaild(this.GetLoginData());
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x0005A218 File Offset: 0x00058418
		private void ComboName_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(sender, null, "Text", new object[0], null, null, null), "", true))
			{
				this.TextPass.Password = "";
			}
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set("CacheNideAccess", "", false, null);
			}
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x00007C9D File Offset: 0x00005E9D
		private void TextPass_PasswordChanged(object sender, RoutedEventArgs e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set("CacheNideAccess", "", false, null);
			}
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x0005A274 File Offset: 0x00058474
		private void ComboName_SelectionChanged(MyComboBox sender, SelectionChangedEventArgs e)
		{
			if (Conversions.ToBoolean(sender.SelectedIndex == -1 || Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("LoginRemember", null)))))
			{
				this.TextPass.Password = "";
				return;
			}
			this.TextPass.Password = ModBase._BaseRule.Get("LoginNidePass", null).ToString().Split(new char[]
			{
				'¨'
			})[sender.SelectedIndex].Trim();
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x00004FEE File Offset: 0x000031EE
		private void CheckBoxChange(MyCheckBox sender, object e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set(Conversions.ToString(sender.Tag), sender.Checked, false, null);
			}
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x00007CBC File Offset: 0x00005EBC
		private void ComboName_TextChanged()
		{
			this.BtnLink.Content = ((Operators.CompareString(this.ComboName.Text, "", true) == 0) ? "注册账号" : "找回密码");
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x0005A304 File Offset: 0x00058504
		private void Btn_Click(object sender, EventArgs e)
		{
			if (Operators.ConditionalCompareObjectEqual(this.BtnLink.Content, "注册账号", true))
			{
				ModBase.OpenWebsite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("https://login2.nide8.com:233/", ModBase._BaseRule.Get("VersionServerNide", ModMinecraft.ValidateContainer())), "/register")));
				return;
			}
			ModBase.OpenWebsite("https://login2.nide8.com:233/account/login");
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000A72 RID: 2674 RVA: 0x00007CED File Offset: 0x00005EED
		// (set) Token: 0x06000A73 RID: 2675 RVA: 0x0005A368 File Offset: 0x00058568
		internal virtual MyComboBox ComboName
		{
			[CompilerGenerated]
			get
			{
				return this.valExpression;
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
				MyComboBox myComboBox = this.valExpression;
				if (myComboBox != null)
				{
					myComboBox.StartFactory(obj);
					myComboBox.SelectionChanged -= value2;
					myComboBox.StartFactory(obj2);
				}
				this.valExpression = value;
				myComboBox = this.valExpression;
				if (myComboBox != null)
				{
					myComboBox.GetFactory(obj);
					myComboBox.SelectionChanged += value2;
					myComboBox.GetFactory(obj2);
				}
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000A74 RID: 2676 RVA: 0x00007CF5 File Offset: 0x00005EF5
		// (set) Token: 0x06000A75 RID: 2677 RVA: 0x0005A3E4 File Offset: 0x000585E4
		internal virtual PasswordBox TextPass
		{
			[CompilerGenerated]
			get
			{
				return this.m_ContainerExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = new RoutedEventHandler(this.TextPass_PasswordChanged);
				PasswordBox containerExpression = this.m_ContainerExpression;
				if (containerExpression != null)
				{
					containerExpression.PasswordChanged -= value2;
				}
				this.m_ContainerExpression = value;
				containerExpression = this.m_ContainerExpression;
				if (containerExpression != null)
				{
					containerExpression.PasswordChanged += value2;
				}
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000A76 RID: 2678 RVA: 0x00007CFD File Offset: 0x00005EFD
		// (set) Token: 0x06000A77 RID: 2679 RVA: 0x0005A428 File Offset: 0x00058628
		internal virtual MyCheckBox CheckRemember
		{
			[CompilerGenerated]
			get
			{
				return this._ModelExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyCheckBox.ChangeEventHandler obj = delegate(object a0, bool a1)
				{
					this.CheckBoxChange((MyCheckBox)a0, a1);
				};
				MyCheckBox modelExpression = this._ModelExpression;
				if (modelExpression != null)
				{
					modelExpression.SearchIterator(obj);
				}
				this._ModelExpression = value;
				modelExpression = this._ModelExpression;
				if (modelExpression != null)
				{
					modelExpression.RunIterator(obj);
				}
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000A78 RID: 2680 RVA: 0x00007D05 File Offset: 0x00005F05
		// (set) Token: 0x06000A79 RID: 2681 RVA: 0x0005A46C File Offset: 0x0005866C
		internal virtual MyTextButton BtnLink
		{
			[CompilerGenerated]
			get
			{
				return this._IteratorExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyTextButton.ClickEventHandler obj = new MyTextButton.ClickEventHandler(this.Btn_Click);
				MyTextButton iteratorExpression = this._IteratorExpression;
				if (iteratorExpression != null)
				{
					iteratorExpression.FindContainer(obj);
				}
				this._IteratorExpression = value;
				iteratorExpression = this._IteratorExpression;
				if (iteratorExpression != null)
				{
					iteratorExpression.CreateContainer(obj);
				}
			}
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x0005A4B0 File Offset: 0x000586B0
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this._ExpressionExpression)
			{
				this._ExpressionExpression = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagelaunch/pageloginnide.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x0005A4E0 File Offset: 0x000586E0
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
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
			this._ExpressionExpression = true;
		}

		// Token: 0x040005C9 RID: 1481
		private bool m_FactoryExpression;

		// Token: 0x040005CA RID: 1482
		[CompilerGenerated]
		[AccessedThroughProperty("ComboName")]
		private MyComboBox valExpression;

		// Token: 0x040005CB RID: 1483
		[CompilerGenerated]
		[AccessedThroughProperty("TextPass")]
		private PasswordBox m_ContainerExpression;

		// Token: 0x040005CC RID: 1484
		[AccessedThroughProperty("CheckRemember")]
		[CompilerGenerated]
		private MyCheckBox _ModelExpression;

		// Token: 0x040005CD RID: 1485
		[AccessedThroughProperty("BtnLink")]
		[CompilerGenerated]
		private MyTextButton _IteratorExpression;

		// Token: 0x040005CE RID: 1486
		private bool _ExpressionExpression;
	}
}
