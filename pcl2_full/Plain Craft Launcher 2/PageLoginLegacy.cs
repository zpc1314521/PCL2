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
	// Token: 0x02000128 RID: 296
	[DesignerGenerated]
	public class PageLoginLegacy : Grid, IComponentConnector
	{
		// Token: 0x06000A80 RID: 2688 RVA: 0x00007D38 File Offset: 0x00005F38
		public PageLoginLegacy()
		{
			base.Loaded += this.PageLoginLegacy_Loaded;
			this.utilsExpression = false;
			this.InitializeComponent();
			this.Skin.m_ReponseIterator = PageLaunchLeft.m_InterpreterExpression;
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x00007D6F File Offset: 0x00005F6F
		private void PageLoginLegacy_Loaded(object sender, RoutedEventArgs e)
		{
			this.Skin.m_ReponseIterator.Start(null, false);
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x0005A538 File Offset: 0x00058738
		public void Reload(bool KeepInput)
		{
			if (KeepInput && this.utilsExpression)
			{
				string text = this.ComboName.Text;
				this.ComboName.ItemsSource = (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LoginLegacyName", null), "", true) ? null : ModBase._BaseRule.Get("LoginLegacyName", null).ToString().Split(new char[]
				{
					'¨'
				}));
				this.ComboName.Text = text;
			}
			else if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LoginLegacyName", null), "", true))
			{
				this.ComboName.ItemsSource = null;
			}
			else
			{
				this.ComboName.ItemsSource = ModBase._BaseRule.Get("LoginLegacyName", null).ToString().Split(new char[]
				{
					'¨'
				});
				this.ComboName.Text = ModBase._BaseRule.Get("LoginLegacyName", null).ToString().Split(new char[]
				{
					'¨'
				})[0];
			}
			this.utilsExpression = true;
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x0005A65C File Offset: 0x0005885C
		public ModLaunch.McLoginLegacy GetLoginData()
		{
			return new ModLaunch.McLoginLegacy
			{
				m_CustomerAlgo = this.ComboName.Text.Replace("¨", "").Trim(),
				taskAlgo = Conversions.ToInteger(ModBase._BaseRule.Get("LaunchSkinType", null)),
				_AuthenticationAlgo = Conversions.ToString(ModBase._BaseRule.Get("LaunchSkinID", null))
			};
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x0005A6CC File Offset: 0x000588CC
		public static string IsVaild(ModLaunch.McLoginLegacy LoginData)
		{
			string result;
			if (Operators.CompareString(LoginData.m_CustomerAlgo.Trim(), "", true) == 0)
			{
				result = "玩家名不能为空！";
			}
			else if (LoginData.m_CustomerAlgo.Contains("\""))
			{
				result = "玩家名不能包含英文引号！";
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x00007D83 File Offset: 0x00005F83
		public string IsVaild()
		{
			return PageLoginLegacy.IsVaild(this.GetLoginData());
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x00007D90 File Offset: 0x00005F90
		private void ComboLegacy_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LaunchSkinType", null), 0, true))
			{
				PageLaunchLeft.m_InterpreterExpression.Start(null, true);
			}
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x0005A71C File Offset: 0x0005891C
		private void Skin_Click()
		{
			if (Conversions.ToBoolean((Conversions.ToBoolean(ModBase._BaseRule.Get("UiHiddenPageSetup", null)) || Conversions.ToBoolean(ModBase._BaseRule.Get("UiHiddenSetupLaunch", null))) && !PageSetupUI.WriteModel()))
			{
				ModMain.Hint("启动设置已被禁用！", ModMain.HintType.Critical, true);
				return;
			}
			ModMain.m_GetterFilter.PageChange(FormMain.PageType.Setup, FormMain.PageSubType.Default);
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000A88 RID: 2696 RVA: 0x00007DBC File Offset: 0x00005FBC
		// (set) Token: 0x06000A89 RID: 2697 RVA: 0x0005A78C File Offset: 0x0005898C
		internal virtual MyComboBox ComboName
		{
			[CompilerGenerated]
			get
			{
				return this.m_BaseExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyComboBox.TextChangedEventHandler obj = new MyComboBox.TextChangedEventHandler(this.ComboLegacy_TextChanged);
				MyComboBox baseExpression = this.m_BaseExpression;
				if (baseExpression != null)
				{
					baseExpression.StartFactory(obj);
				}
				this.m_BaseExpression = value;
				baseExpression = this.m_BaseExpression;
				if (baseExpression != null)
				{
					baseExpression.GetFactory(obj);
				}
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000A8A RID: 2698 RVA: 0x00007DC4 File Offset: 0x00005FC4
		// (set) Token: 0x06000A8B RID: 2699 RVA: 0x0005A7D0 File Offset: 0x000589D0
		internal virtual MySkin Skin
		{
			[CompilerGenerated]
			get
			{
				return this.m_DecoratorExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MySkin.ClickEventHandler obj = delegate(object sender, MouseButtonEventArgs e)
				{
					this.Skin_Click();
				};
				MySkin decoratorExpression = this.m_DecoratorExpression;
				if (decoratorExpression != null)
				{
					decoratorExpression.CollectModel(obj);
				}
				this.m_DecoratorExpression = value;
				decoratorExpression = this.m_DecoratorExpression;
				if (decoratorExpression != null)
				{
					decoratorExpression.SearchModel(obj);
				}
			}
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x0005A814 File Offset: 0x00058A14
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this._FilterExpression)
			{
				this._FilterExpression = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagelaunch/pageloginlegacy.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x00007DCC File Offset: 0x00005FCC
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
				this.Skin = (MySkin)target;
				return;
			}
			this._FilterExpression = true;
		}

		// Token: 0x040005CF RID: 1487
		public bool utilsExpression;

		// Token: 0x040005D0 RID: 1488
		[CompilerGenerated]
		[AccessedThroughProperty("ComboName")]
		private MyComboBox m_BaseExpression;

		// Token: 0x040005D1 RID: 1489
		[CompilerGenerated]
		[AccessedThroughProperty("Skin")]
		private MySkin m_DecoratorExpression;

		// Token: 0x040005D2 RID: 1490
		private bool _FilterExpression;
	}
}
