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
	// Token: 0x0200014A RID: 330
	[DesignerGenerated]
	public class PageOtherLeft : MyPageLeft, IComponentConnector
	{
		// Token: 0x06000C81 RID: 3201 RVA: 0x00065710 File Offset: 0x00063910
		public PageOtherLeft()
		{
			base.Loaded += this.PageOtherLeft_Loaded;
			base.Unloaded += this.PageOtherLeft_Unloaded;
			this._ItemUtils = false;
			this.serializerUtils = false;
			this.infoUtils = FormMain.PageSubType.Default;
			this.InitializeComponent();
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x00065764 File Offset: 0x00063964
		private void PageOtherLeft_Loaded(object sender, RoutedEventArgs e)
		{
			bool flag = false;
			if (Conversions.ToBoolean(this.ItemHelp.Checked && Conversions.ToBoolean(ModBase._BaseRule.Get("UiHiddenOtherHelp", null))))
			{
				flag = true;
			}
			if (Conversions.ToBoolean(this.ItemFeedback.Checked && Conversions.ToBoolean(ModBase._BaseRule.Get("UiHiddenOtherFeedback", null))))
			{
				flag = true;
			}
			if (Conversions.ToBoolean(this.ItemAbout.Checked && Conversions.ToBoolean(ModBase._BaseRule.Get("UiHiddenOtherAbout", null))))
			{
				flag = true;
			}
			if (Conversions.ToBoolean(this.ItemTest.Checked && Conversions.ToBoolean(ModBase._BaseRule.Get("UiHiddenOtherTest", null))))
			{
				flag = true;
			}
			if (PageSetupUI.WriteModel())
			{
				flag = false;
			}
			if (!this._ItemUtils || flag)
			{
				this._ItemUtils = true;
				PageSetupUI.HiddenRefresh();
				if (!this.serializerUtils)
				{
					if (Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("UiHiddenOtherHelp", null))))
					{
						this.ItemHelp.SetChecked(true, false, false);
						return;
					}
					if (Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("UiHiddenOtherAbout", null))))
					{
						this.ItemAbout.SetChecked(true, false, false);
						return;
					}
					if (Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("UiHiddenOtherTest", null))))
					{
						this.ItemTest.SetChecked(true, false, false);
						return;
					}
					this.ItemFeedback.SetChecked(true, false, false);
				}
			}
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x00008ECF File Offset: 0x000070CF
		private void PageOtherLeft_Unloaded(object sender, RoutedEventArgs e)
		{
			this.serializerUtils = false;
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x00008ED8 File Offset: 0x000070D8
		private void PageCheck(MyListItem sender, ModBase.RouteEventArgs e)
		{
			if (sender.Tag != null)
			{
				this.PageChange(checked((FormMain.PageSubType)Math.Round(ModBase.Val(RuntimeHelpers.GetObjectValue(sender.Tag)))));
			}
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x000658FC File Offset: 0x00063AFC
		public object PageGet(FormMain.PageSubType ID = (FormMain.PageSubType)(-1))
		{
			if (ID == (FormMain.PageSubType)(-1))
			{
				ID = this.infoUtils;
			}
			object result;
			switch (ID)
			{
			case FormMain.PageSubType.Default:
				if (ModMain.m_AdapterFilter == null)
				{
					ModMain.m_AdapterFilter = new PageOtherHelp();
				}
				result = ModMain.m_AdapterFilter;
				break;
			case FormMain.PageSubType.DownloadInstall:
				if (ModMain._AnnotationFilter == null)
				{
					ModMain._AnnotationFilter = new PageOtherAbout();
				}
				result = ModMain._AnnotationFilter;
				break;
			case FormMain.PageSubType.SetupSystem:
				if (ModMain._RegFilter == null)
				{
					ModMain._RegFilter = new PageOtherTest();
				}
				result = ModMain._RegFilter;
				break;
			case FormMain.PageSubType.SetupAccount:
				if (ModMain.readerFilter == null)
				{
					ModMain.readerFilter = new PageOtherFeedback();
				}
				result = ModMain.readerFilter;
				break;
			default:
				throw new Exception("未知的更多子页面种类：" + Conversions.ToString((int)ID));
			}
			return result;
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x000659A8 File Offset: 0x00063BA8
		public void PageChange(FormMain.PageSubType ID)
		{
			checked
			{
				if (this.infoUtils != ID)
				{
					ModAni.ListFactory(ModAni.InsertFactory() + 1);
					this.serializerUtils = true;
					try
					{
						switch (ID)
						{
						case FormMain.PageSubType.Default:
							if (Information.IsNothing(ModMain.m_AdapterFilter))
							{
								ModMain.m_AdapterFilter = new PageOtherHelp();
							}
							this.PageChangeRun(ModMain.m_AdapterFilter);
							break;
						case FormMain.PageSubType.DownloadInstall:
							if (Information.IsNothing(ModMain._AnnotationFilter))
							{
								ModMain._AnnotationFilter = new PageOtherAbout();
							}
							this.PageChangeRun(ModMain._AnnotationFilter);
							break;
						case FormMain.PageSubType.SetupSystem:
							if (Information.IsNothing(ModMain._RegFilter))
							{
								ModMain._RegFilter = new PageOtherTest();
							}
							this.PageChangeRun(ModMain._RegFilter);
							break;
						case FormMain.PageSubType.SetupAccount:
							if (Information.IsNothing(ModMain.readerFilter))
							{
								ModMain.readerFilter = new PageOtherFeedback();
							}
							this.PageChangeRun(ModMain.readerFilter);
							break;
						default:
							throw new Exception("未知的更多子页面种类：" + Conversions.ToString((int)ID));
						}
						this.infoUtils = ID;
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "切换设置分页面失败（ID " + Conversions.ToString((int)ID) + "）", ModBase.LogLevel.Feedback, "出现错误");
					}
					finally
					{
						ModAni.ListFactory(ModAni.InsertFactory() - 1);
					}
				}
			}
		}

		// Token: 0x06000C87 RID: 3207 RVA: 0x00065AF0 File Offset: 0x00063CF0
		private void PageChangeRun(FrameworkElement Target)
		{
			if (!Information.IsNothing(Target.Parent))
			{
				Target.SetValue(ContentPresenter.ContentProperty, null);
			}
			ModMain.m_GetterFilter.m_ProcDecorator = Target;
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(ModMain.m_GetterFilter.PanMainRight, -ModMain.m_GetterFilter.PanMainRight.Opacity, 0x64, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaCode((PageOtherLeft._Closure$__.$I9-0 == null) ? (PageOtherLeft._Closure$__.$I9-0 = delegate()
				{
					ModMain.m_GetterFilter.PanMainRight.Child = ModMain.m_GetterFilter.m_ProcDecorator;
				}) : PageOtherLeft._Closure$__.$I9-0, 0, true),
				ModAni.AaOpacity(ModMain.m_GetterFilter.PanMainRight, 1.0, 0x96, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false)
			}, "PageOtherLeft PageChange", false);
		}

		// Token: 0x06000C88 RID: 3208 RVA: 0x00065BC0 File Offset: 0x00063DC0
		public void Refresh(object sender, EventArgs e)
		{
			double num = ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null)));
			if (num == 0.0)
			{
				PageOtherLeft.RefreshHelp();
				return;
			}
			if (num == 3.0)
			{
				if (ModMain.readerFilter != null)
				{
					PageOtherFeedback readerFilter = ModMain.readerFilter;
					ref int ptr = ref readerFilter.m_DispatcherIterator;
					readerFilter.m_DispatcherIterator = checked(ptr + 1);
					PageOtherFeedback._TagIterator.Start(ModMain.readerFilter.m_DispatcherIterator, false);
					ModMain.readerFilter.SearchBox.Text = "";
					return;
				}
				PageOtherFeedback._TagIterator.Start(ModBase.GetUuid(), false);
			}
		}

		// Token: 0x06000C89 RID: 3209 RVA: 0x00065C60 File Offset: 0x00063E60
		public static void RefreshHelp()
		{
			ModBase._BaseRule.Set("SystemHelpVersion", 0, false, null);
			if (ModMain.m_AdapterFilter != null)
			{
				PageOtherHelp adapterFilter = ModMain.m_AdapterFilter;
				ref int ptr = ref adapterFilter.m_ContainerUtils;
				adapterFilter.m_ContainerUtils = checked(ptr + 1);
				PageOtherHelp.modelUtils.Start(ModMain.m_AdapterFilter.m_ContainerUtils, false);
				ModMain.m_AdapterFilter.SearchBox.Text = "";
				return;
			}
			PageOtherHelp.modelUtils.Start(ModBase.GetUuid(), false);
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000C8A RID: 3210 RVA: 0x00008EFE File Offset: 0x000070FE
		// (set) Token: 0x06000C8B RID: 3211 RVA: 0x00008F06 File Offset: 0x00007106
		internal virtual StackPanel PanItem { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000C8C RID: 3212 RVA: 0x00008F0F File Offset: 0x0000710F
		// (set) Token: 0x06000C8D RID: 3213 RVA: 0x00065CD8 File Offset: 0x00063ED8
		internal virtual MyListItem ItemHelp
		{
			[CompilerGenerated]
			get
			{
				return this.systemUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem myListItem = this.systemUtils;
				if (myListItem != null)
				{
					myListItem.Check -= value2;
				}
				this.systemUtils = value;
				myListItem = this.systemUtils;
				if (myListItem != null)
				{
					myListItem.Check += value2;
				}
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000C8E RID: 3214 RVA: 0x00008F17 File Offset: 0x00007117
		// (set) Token: 0x06000C8F RID: 3215 RVA: 0x00065D1C File Offset: 0x00063F1C
		internal virtual MyListItem ItemAbout
		{
			[CompilerGenerated]
			get
			{
				return this.proccesorUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem myListItem = this.proccesorUtils;
				if (myListItem != null)
				{
					myListItem.Check -= value2;
				}
				this.proccesorUtils = value;
				myListItem = this.proccesorUtils;
				if (myListItem != null)
				{
					myListItem.Check += value2;
				}
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000C90 RID: 3216 RVA: 0x00008F1F File Offset: 0x0000711F
		// (set) Token: 0x06000C91 RID: 3217 RVA: 0x00065D60 File Offset: 0x00063F60
		internal virtual MyListItem ItemTest
		{
			[CompilerGenerated]
			get
			{
				return this._PrototypeUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem prototypeUtils = this._PrototypeUtils;
				if (prototypeUtils != null)
				{
					prototypeUtils.Check -= value2;
				}
				this._PrototypeUtils = value;
				prototypeUtils = this._PrototypeUtils;
				if (prototypeUtils != null)
				{
					prototypeUtils.Check += value2;
				}
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000C92 RID: 3218 RVA: 0x00008F27 File Offset: 0x00007127
		// (set) Token: 0x06000C93 RID: 3219 RVA: 0x00065DA4 File Offset: 0x00063FA4
		internal virtual MyListItem ItemFeedback
		{
			[CompilerGenerated]
			get
			{
				return this.m_RefUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem refUtils = this.m_RefUtils;
				if (refUtils != null)
				{
					refUtils.Check -= value2;
				}
				this.m_RefUtils = value;
				refUtils = this.m_RefUtils;
				if (refUtils != null)
				{
					refUtils.Check += value2;
				}
			}
		}

		// Token: 0x06000C94 RID: 3220 RVA: 0x00065DE8 File Offset: 0x00063FE8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.parameterUtils)
			{
				this.parameterUtils = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pageother/pageotherleft.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000C95 RID: 3221 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000C96 RID: 3222 RVA: 0x00065E18 File Offset: 0x00064018
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanItem = (StackPanel)target;
				return;
			}
			if (connectionId == 2)
			{
				this.ItemHelp = (MyListItem)target;
				return;
			}
			if (connectionId == 3)
			{
				this.ItemAbout = (MyListItem)target;
				return;
			}
			if (connectionId == 4)
			{
				this.ItemTest = (MyListItem)target;
				return;
			}
			if (connectionId == 5)
			{
				this.ItemFeedback = (MyListItem)target;
				return;
			}
			this.parameterUtils = true;
		}

		// Token: 0x040006B9 RID: 1721
		private bool _ItemUtils;

		// Token: 0x040006BA RID: 1722
		private bool serializerUtils;

		// Token: 0x040006BB RID: 1723
		public FormMain.PageSubType infoUtils;

		// Token: 0x040006BC RID: 1724
		[CompilerGenerated]
		[AccessedThroughProperty("PanItem")]
		private StackPanel repositoryUtils;

		// Token: 0x040006BD RID: 1725
		[CompilerGenerated]
		[AccessedThroughProperty("ItemHelp")]
		private MyListItem systemUtils;

		// Token: 0x040006BE RID: 1726
		[AccessedThroughProperty("ItemAbout")]
		[CompilerGenerated]
		private MyListItem proccesorUtils;

		// Token: 0x040006BF RID: 1727
		[AccessedThroughProperty("ItemTest")]
		[CompilerGenerated]
		private MyListItem _PrototypeUtils;

		// Token: 0x040006C0 RID: 1728
		[AccessedThroughProperty("ItemFeedback")]
		[CompilerGenerated]
		private MyListItem m_RefUtils;

		// Token: 0x040006C1 RID: 1729
		private bool parameterUtils;
	}
}
