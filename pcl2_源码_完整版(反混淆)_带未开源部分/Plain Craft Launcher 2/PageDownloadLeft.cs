using Microsoft.VisualBasic;
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
	// Token: 0x02000146 RID: 326
	[DesignerGenerated]
	public class PageDownloadLeft : MyPageLeft, IComponentConnector
	{
		// Token: 0x06000C33 RID: 3123 RVA: 0x00008BFF File Offset: 0x00006DFF
		public PageDownloadLeft()
		{
			this.paramsUtils = FormMain.PageSubType.DownloadInstall;
			this.InitializeComponent();
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x00008C14 File Offset: 0x00006E14
		private void PageCheck(MyListItem sender, ModBase.RouteEventArgs e)
		{
			if (sender.Tag != null)
			{
				this.PageChange(checked((FormMain.PageSubType)Math.Round(ModBase.Val(RuntimeHelpers.GetObjectValue(sender.Tag)))));
			}
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x00064334 File Offset: 0x00062534
		public object PageGet(FormMain.PageSubType ID = (FormMain.PageSubType)(-1))
		{
			if (ID == (FormMain.PageSubType)(-1))
			{
				ID = this.paramsUtils;
			}
			switch (ID)
			{
			case FormMain.PageSubType.DownloadInstall:
				if (ModMain.propertyFilter == null)
				{
					ModMain.propertyFilter = new PageDownloadInstall();
				}
				return ModMain.propertyFilter;
			case FormMain.PageSubType.DownloadClient:
				if (ModMain.m_WatcherFilter == null)
				{
					ModMain.m_WatcherFilter = new PageDownloadClient();
				}
				return ModMain.m_WatcherFilter;
			case FormMain.PageSubType.DownloadOptiFine:
				if (ModMain.m_StateFilter == null)
				{
					ModMain.m_StateFilter = new PageDownloadOptiFine();
				}
				return ModMain.m_StateFilter;
			case FormMain.PageSubType.DownloadForge:
				if (ModMain.m_PageFilter == null)
				{
					ModMain.m_PageFilter = new PageDownloadForge();
				}
				return ModMain.m_PageFilter;
			case FormMain.PageSubType.DownloadFabric:
				if (ModMain.instanceFilter == null)
				{
					ModMain.instanceFilter = new PageDownloadFabric();
				}
				return ModMain.instanceFilter;
			case FormMain.PageSubType.DownloadLiteLoader:
				if (ModMain.creatorFilter == null)
				{
					ModMain.creatorFilter = new PageDownloadLiteLoader();
				}
				return ModMain.creatorFilter;
			case FormMain.PageSubType.DownloadMod:
				if (ModMain.m_TestFilter == null)
				{
					ModMain.m_TestFilter = new PageDownloadMod();
				}
				return ModMain.m_TestFilter;
			case FormMain.PageSubType.DownloadPack:
				if (ModMain.m_CustomerFilter == null)
				{
					ModMain.m_CustomerFilter = new PageDownloadPack();
				}
				return ModMain.m_CustomerFilter;
			}
			throw new Exception("未知的下载子页面种类：" + Conversions.ToString((int)ID));
		}

		// Token: 0x06000C36 RID: 3126 RVA: 0x00064470 File Offset: 0x00062670
		public void PageChange(FormMain.PageSubType ID)
		{
			checked
			{
				if (this.paramsUtils != ID)
				{
					ModAni.ListFactory(ModAni.InsertFactory() + 1);
					try
					{
						switch (ID)
						{
						case FormMain.PageSubType.DownloadInstall:
							if (Information.IsNothing(ModMain.propertyFilter))
							{
								ModMain.propertyFilter = new PageDownloadInstall();
							}
							this.PageChangeRun(ModMain.propertyFilter);
							goto IL_18B;
						case FormMain.PageSubType.DownloadClient:
							if (Information.IsNothing(ModMain.m_WatcherFilter))
							{
								ModMain.m_WatcherFilter = new PageDownloadClient();
							}
							this.PageChangeRun(ModMain.m_WatcherFilter);
							goto IL_18B;
						case FormMain.PageSubType.DownloadOptiFine:
							if (Information.IsNothing(ModMain.m_StateFilter))
							{
								ModMain.m_StateFilter = new PageDownloadOptiFine();
							}
							this.PageChangeRun(ModMain.m_StateFilter);
							goto IL_18B;
						case FormMain.PageSubType.DownloadForge:
							if (Information.IsNothing(ModMain.m_PageFilter))
							{
								ModMain.m_PageFilter = new PageDownloadForge();
							}
							this.PageChangeRun(ModMain.m_PageFilter);
							goto IL_18B;
						case FormMain.PageSubType.DownloadFabric:
							if (Information.IsNothing(ModMain.instanceFilter))
							{
								ModMain.instanceFilter = new PageDownloadFabric();
							}
							this.PageChangeRun(ModMain.instanceFilter);
							goto IL_18B;
						case FormMain.PageSubType.DownloadLiteLoader:
							if (Information.IsNothing(ModMain.creatorFilter))
							{
								ModMain.creatorFilter = new PageDownloadLiteLoader();
							}
							this.PageChangeRun(ModMain.creatorFilter);
							goto IL_18B;
						case FormMain.PageSubType.DownloadMod:
							if (Information.IsNothing(ModMain.m_TestFilter))
							{
								ModMain.m_TestFilter = new PageDownloadMod();
							}
							this.PageChangeRun(ModMain.m_TestFilter);
							goto IL_18B;
						case FormMain.PageSubType.DownloadPack:
							if (Information.IsNothing(ModMain.m_CustomerFilter))
							{
								ModMain.m_CustomerFilter = new PageDownloadPack();
							}
							this.PageChangeRun(ModMain.m_CustomerFilter);
							goto IL_18B;
						}
						throw new Exception("未知的下载子页面种类：" + Conversions.ToString((int)ID));
						IL_18B:
						this.paramsUtils = ID;
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

		// Token: 0x06000C37 RID: 3127 RVA: 0x00064684 File Offset: 0x00062884
		private void PageChangeRun(object Target)
		{
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Target, null, "Parent", new object[0], null, null, null))))
			{
				Type type = null;
				string memberName = "SetValue";
				object[] array = new object[2];
				array[0] = ContentPresenter.ContentProperty;
				NewLateBinding.LateCall(Target, type, memberName, array, null, null, null, true);
			}
			ModMain.m_GetterFilter.m_ProcDecorator = (FrameworkElement)Target;
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(ModMain.m_GetterFilter.PanMainRight, -ModMain.m_GetterFilter.PanMainRight.Opacity, 0x64, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaCode((PageDownloadLeft._Closure$__.$I5-0 == null) ? (PageDownloadLeft._Closure$__.$I5-0 = delegate()
				{
					ModMain.m_GetterFilter.PanMainRight.Child = ModMain.m_GetterFilter.m_ProcDecorator;
				}) : PageDownloadLeft._Closure$__.$I5-0, 0, true),
				ModAni.AaOpacity(ModMain.m_GetterFilter.PanMainRight, 1.0, 0x96, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false)
			}, "PageOtherLeft PageChange", false);
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x00064780 File Offset: 0x00062980
		public void Refresh(object sender, EventArgs e)
		{
			double num = ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null)));
			if (num == 1.0)
			{
				PageDownloadClient.RefreshLoader();
				PageDownloadOptiFine.RefreshLoader();
				PageDownloadForge.RefreshLoader();
				PageDownloadLiteLoader.RefreshLoader();
				return;
			}
			if (num == 10.0)
			{
				PageDownloadMod.RefreshLoader();
				return;
			}
			if (num == 11.0)
			{
				PageDownloadPack.RefreshLoader();
				return;
			}
			if (num == 4.0)
			{
				PageDownloadClient.RefreshLoader();
				return;
			}
			if (num == 5.0)
			{
				PageDownloadOptiFine.RefreshLoader();
				return;
			}
			if (num == 6.0)
			{
				PageDownloadForge.RefreshLoader();
				return;
			}
			if (num == 8.0)
			{
				PageDownloadLiteLoader.RefreshLoader();
				return;
			}
			if (num == 7.0)
			{
				PageDownloadFabric.RefreshLoader();
			}
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x00008C3A File Offset: 0x00006E3A
		private void ItemInstall_Click(object sender, MouseButtonEventArgs e)
		{
			if (this.ItemInstall.Checked)
			{
				ModMain.propertyFilter.ExitSelectPage();
			}
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x0006484C File Offset: 0x00062A4C
		private void ItemHand_Click(object sender, ModBase.RouteEventArgs e)
		{
			checked
			{
				if (this.ItemHand.Checked)
				{
					e._HelperMapper = true;
					ModAni.ListFactory(ModAni.InsertFactory() + 1);
					if (Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("HintHandInstall", null))))
					{
						ModBase._BaseRule.Set("HintHandInstall", true, false, null);
						if (ModMain.MyMsgBox("手动安装包功能提供了 OptiFine、Forge 等组件的 .jar 安装文件下载，但无法自动安装。\r\n在自动安装页面先选择 MC 版本，然后就可以选择 OptiFine、Forge 等组件，让 PCL2 自动进行安装了。", "自动安装提示", "返回自动安装", "继续下载手动安装包", "", false, true, false) == 1)
						{
							ModMain.m_GetterFilter.PageChange(new FormMain.PageStackData
							{
								_FieldMapper = FormMain.PageType.Download
							}, FormMain.PageSubType.DownloadInstall);
							ModAni.ListFactory(ModAni.InsertFactory() - 1);
							return;
						}
					}
					this.ItemHand.Visibility = Visibility.Collapsed;
					this.LabGame.Visibility = Visibility.Collapsed;
					this.LabHand.Visibility = Visibility.Visible;
					this.ItemClient.Visibility = Visibility.Visible;
					this.ItemOptiFine.Visibility = Visibility.Visible;
					this.ItemFabric.Visibility = Visibility.Visible;
					this.ItemForge.Visibility = Visibility.Visible;
					this.ItemLiteLoader.Visibility = Visibility.Visible;
					ModBase.RunInThread(delegate
					{
						Thread.Sleep(0x14);
						ModBase.RunInUiWait(delegate()
						{
							this.ItemClient.SetChecked(true, true, true);
						});
						ModAni.ListFactory(ModAni.InsertFactory() - 1);
					});
				}
			}
		}

		// Token: 0x06000C3B RID: 3131 RVA: 0x00064968 File Offset: 0x00062B68
		private void LabHand_Click(object sender, MouseButtonEventArgs e)
		{
			e.Handled = true;
			checked
			{
				ModAni.ListFactory(ModAni.InsertFactory() + 1);
				this.ItemHand.Visibility = Visibility.Visible;
				this.LabGame.Visibility = Visibility.Visible;
				this.LabHand.Visibility = Visibility.Collapsed;
				this.ItemClient.Visibility = Visibility.Collapsed;
				this.ItemOptiFine.Visibility = Visibility.Collapsed;
				this.ItemFabric.Visibility = Visibility.Collapsed;
				this.ItemForge.Visibility = Visibility.Collapsed;
				this.ItemLiteLoader.Visibility = Visibility.Collapsed;
				ModBase.RunInThread(delegate
				{
					Thread.Sleep(0x14);
					ModBase.RunInUiWait(delegate()
					{
						this.ItemInstall.SetChecked(true, true, true);
					});
					ModAni.ListFactory(ModAni.InsertFactory() - 1);
				});
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000C3C RID: 3132 RVA: 0x00008C53 File Offset: 0x00006E53
		// (set) Token: 0x06000C3D RID: 3133 RVA: 0x00008C5B File Offset: 0x00006E5B
		internal virtual StackPanel PanItem { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000C3E RID: 3134 RVA: 0x00008C64 File Offset: 0x00006E64
		// (set) Token: 0x06000C3F RID: 3135 RVA: 0x00008C6C File Offset: 0x00006E6C
		internal virtual TextBlock LabGame { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000C40 RID: 3136 RVA: 0x00008C75 File Offset: 0x00006E75
		// (set) Token: 0x06000C41 RID: 3137 RVA: 0x000649FC File Offset: 0x00062BFC
		internal virtual MyListItem ItemInstall
		{
			[CompilerGenerated]
			get
			{
				return this._OrderUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem.ClickEventHandler obj = new MyListItem.ClickEventHandler(this.ItemInstall_Click);
				MyListItem orderUtils = this._OrderUtils;
				if (orderUtils != null)
				{
					orderUtils.Check -= value2;
					orderUtils.PushModel(obj);
				}
				this._OrderUtils = value;
				orderUtils = this._OrderUtils;
				if (orderUtils != null)
				{
					orderUtils.Check += value2;
					orderUtils.QueryModel(obj);
				}
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000C42 RID: 3138 RVA: 0x00008C7D File Offset: 0x00006E7D
		// (set) Token: 0x06000C43 RID: 3139 RVA: 0x00064A5C File Offset: 0x00062C5C
		internal virtual MyListItem ItemHand
		{
			[CompilerGenerated]
			get
			{
				return this.serviceUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.ChangedEventHandler value2 = new IMyRadio.ChangedEventHandler(this.ItemHand_Click);
				MyListItem myListItem = this.serviceUtils;
				if (myListItem != null)
				{
					myListItem.Changed -= value2;
				}
				this.serviceUtils = value;
				myListItem = this.serviceUtils;
				if (myListItem != null)
				{
					myListItem.Changed += value2;
				}
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000C44 RID: 3140 RVA: 0x00008C85 File Offset: 0x00006E85
		// (set) Token: 0x06000C45 RID: 3141 RVA: 0x00064AA0 File Offset: 0x00062CA0
		internal virtual TextBlock LabHand
		{
			[CompilerGenerated]
			get
			{
				return this._FacadeUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseButtonEventHandler value2 = new MouseButtonEventHandler(this.LabHand_Click);
				TextBlock facadeUtils = this._FacadeUtils;
				if (facadeUtils != null)
				{
					facadeUtils.MouseLeftButtonUp -= value2;
				}
				this._FacadeUtils = value;
				facadeUtils = this._FacadeUtils;
				if (facadeUtils != null)
				{
					facadeUtils.MouseLeftButtonUp += value2;
				}
			}
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000C46 RID: 3142 RVA: 0x00008C8D File Offset: 0x00006E8D
		// (set) Token: 0x06000C47 RID: 3143 RVA: 0x00064AE4 File Offset: 0x00062CE4
		internal virtual MyListItem ItemClient
		{
			[CompilerGenerated]
			get
			{
				return this.m_CodeUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem codeUtils = this.m_CodeUtils;
				if (codeUtils != null)
				{
					codeUtils.Check -= value2;
				}
				this.m_CodeUtils = value;
				codeUtils = this.m_CodeUtils;
				if (codeUtils != null)
				{
					codeUtils.Check += value2;
				}
			}
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000C48 RID: 3144 RVA: 0x00008C95 File Offset: 0x00006E95
		// (set) Token: 0x06000C49 RID: 3145 RVA: 0x00064B28 File Offset: 0x00062D28
		internal virtual MyListItem ItemOptiFine
		{
			[CompilerGenerated]
			get
			{
				return this.m_MappingUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem mappingUtils = this.m_MappingUtils;
				if (mappingUtils != null)
				{
					mappingUtils.Check -= value2;
				}
				this.m_MappingUtils = value;
				mappingUtils = this.m_MappingUtils;
				if (mappingUtils != null)
				{
					mappingUtils.Check += value2;
				}
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000C4A RID: 3146 RVA: 0x00008C9D File Offset: 0x00006E9D
		// (set) Token: 0x06000C4B RID: 3147 RVA: 0x00064B6C File Offset: 0x00062D6C
		internal virtual MyListItem ItemForge
		{
			[CompilerGenerated]
			get
			{
				return this.bridgeUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem myListItem = this.bridgeUtils;
				if (myListItem != null)
				{
					myListItem.Check -= value2;
				}
				this.bridgeUtils = value;
				myListItem = this.bridgeUtils;
				if (myListItem != null)
				{
					myListItem.Check += value2;
				}
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000C4C RID: 3148 RVA: 0x00008CA5 File Offset: 0x00006EA5
		// (set) Token: 0x06000C4D RID: 3149 RVA: 0x00064BB0 File Offset: 0x00062DB0
		internal virtual MyListItem ItemFabric
		{
			[CompilerGenerated]
			get
			{
				return this.singletonUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem myListItem = this.singletonUtils;
				if (myListItem != null)
				{
					myListItem.Check -= value2;
				}
				this.singletonUtils = value;
				myListItem = this.singletonUtils;
				if (myListItem != null)
				{
					myListItem.Check += value2;
				}
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000C4E RID: 3150 RVA: 0x00008CAD File Offset: 0x00006EAD
		// (set) Token: 0x06000C4F RID: 3151 RVA: 0x00064BF4 File Offset: 0x00062DF4
		internal virtual MyListItem ItemLiteLoader
		{
			[CompilerGenerated]
			get
			{
				return this.m_ErrorUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem errorUtils = this.m_ErrorUtils;
				if (errorUtils != null)
				{
					errorUtils.Check -= value2;
				}
				this.m_ErrorUtils = value;
				errorUtils = this.m_ErrorUtils;
				if (errorUtils != null)
				{
					errorUtils.Check += value2;
				}
			}
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06000C50 RID: 3152 RVA: 0x00008CB5 File Offset: 0x00006EB5
		// (set) Token: 0x06000C51 RID: 3153 RVA: 0x00064C38 File Offset: 0x00062E38
		internal virtual MyListItem ItemMod
		{
			[CompilerGenerated]
			get
			{
				return this._ObjectUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem objectUtils = this._ObjectUtils;
				if (objectUtils != null)
				{
					objectUtils.Check -= value2;
				}
				this._ObjectUtils = value;
				objectUtils = this._ObjectUtils;
				if (objectUtils != null)
				{
					objectUtils.Check += value2;
				}
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000C52 RID: 3154 RVA: 0x00008CBD File Offset: 0x00006EBD
		// (set) Token: 0x06000C53 RID: 3155 RVA: 0x00064C7C File Offset: 0x00062E7C
		internal virtual MyListItem ItemPack
		{
			[CompilerGenerated]
			get
			{
				return this._CallbackUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.PageCheck((MyListItem)sender, e);
				};
				MyListItem callbackUtils = this._CallbackUtils;
				if (callbackUtils != null)
				{
					callbackUtils.Check -= value2;
				}
				this._CallbackUtils = value;
				callbackUtils = this._CallbackUtils;
				if (callbackUtils != null)
				{
					callbackUtils.Check += value2;
				}
			}
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x00064CC0 File Offset: 0x00062EC0
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.m_WorkerUtils)
			{
				this.m_WorkerUtils = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagedownload/pagedownloadleft.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x00064CF0 File Offset: 0x00062EF0
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanItem = (StackPanel)target;
				return;
			}
			if (connectionId == 2)
			{
				this.LabGame = (TextBlock)target;
				return;
			}
			if (connectionId == 3)
			{
				this.ItemInstall = (MyListItem)target;
				return;
			}
			if (connectionId == 4)
			{
				this.ItemHand = (MyListItem)target;
				return;
			}
			if (connectionId == 5)
			{
				this.LabHand = (TextBlock)target;
				return;
			}
			if (connectionId == 6)
			{
				this.ItemClient = (MyListItem)target;
				return;
			}
			if (connectionId == 7)
			{
				this.ItemOptiFine = (MyListItem)target;
				return;
			}
			if (connectionId == 8)
			{
				this.ItemForge = (MyListItem)target;
				return;
			}
			if (connectionId == 9)
			{
				this.ItemFabric = (MyListItem)target;
				return;
			}
			if (connectionId == 0xA)
			{
				this.ItemLiteLoader = (MyListItem)target;
				return;
			}
			if (connectionId == 0xB)
			{
				this.ItemMod = (MyListItem)target;
				return;
			}
			if (connectionId == 0xC)
			{
				this.ItemPack = (MyListItem)target;
				return;
			}
			this.m_WorkerUtils = true;
		}

		// Token: 0x0400069F RID: 1695
		public FormMain.PageSubType paramsUtils;

		// Token: 0x040006A0 RID: 1696
		[AccessedThroughProperty("PanItem")]
		[CompilerGenerated]
		private StackPanel _GlobalUtils;

		// Token: 0x040006A1 RID: 1697
		[CompilerGenerated]
		[AccessedThroughProperty("LabGame")]
		private TextBlock m_IssuerUtils;

		// Token: 0x040006A2 RID: 1698
		[AccessedThroughProperty("ItemInstall")]
		[CompilerGenerated]
		private MyListItem _OrderUtils;

		// Token: 0x040006A3 RID: 1699
		[CompilerGenerated]
		[AccessedThroughProperty("ItemHand")]
		private MyListItem serviceUtils;

		// Token: 0x040006A4 RID: 1700
		[CompilerGenerated]
		[AccessedThroughProperty("LabHand")]
		private TextBlock _FacadeUtils;

		// Token: 0x040006A5 RID: 1701
		[AccessedThroughProperty("ItemClient")]
		[CompilerGenerated]
		private MyListItem m_CodeUtils;

		// Token: 0x040006A6 RID: 1702
		[CompilerGenerated]
		[AccessedThroughProperty("ItemOptiFine")]
		private MyListItem m_MappingUtils;

		// Token: 0x040006A7 RID: 1703
		[CompilerGenerated]
		[AccessedThroughProperty("ItemForge")]
		private MyListItem bridgeUtils;

		// Token: 0x040006A8 RID: 1704
		[CompilerGenerated]
		[AccessedThroughProperty("ItemFabric")]
		private MyListItem singletonUtils;

		// Token: 0x040006A9 RID: 1705
		[AccessedThroughProperty("ItemLiteLoader")]
		[CompilerGenerated]
		private MyListItem m_ErrorUtils;

		// Token: 0x040006AA RID: 1706
		[CompilerGenerated]
		[AccessedThroughProperty("ItemMod")]
		private MyListItem _ObjectUtils;

		// Token: 0x040006AB RID: 1707
		[CompilerGenerated]
		[AccessedThroughProperty("ItemPack")]
		private MyListItem _CallbackUtils;

		// Token: 0x040006AC RID: 1708
		private bool m_WorkerUtils;
	}
}
