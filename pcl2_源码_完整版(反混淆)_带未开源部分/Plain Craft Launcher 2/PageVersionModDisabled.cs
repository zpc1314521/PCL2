using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x020000AF RID: 175
	[DesignerGenerated]
	public class PageVersionModDisabled : AdornerDecorator, IComponentConnector
	{
		// Token: 0x06000672 RID: 1650 RVA: 0x00005CD6 File Offset: 0x00003ED6
		public PageVersionModDisabled()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x00005CE4 File Offset: 0x00003EE4
		private void BtnDownload_Click(object sender, EventArgs e)
		{
			ModMain.m_GetterFilter.PageChange(FormMain.PageType.Download, FormMain.PageSubType.DownloadInstall);
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x00005CF7 File Offset: 0x00003EF7
		private void BtnVersion_Click(object sender, EventArgs e)
		{
			ModMain.m_GetterFilter.PageChange(FormMain.PageType.Launch, FormMain.PageSubType.Default);
			ModMain.m_GetterFilter.PageChange(FormMain.PageType.VersionSelect, FormMain.PageSubType.Default);
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x00030CC8 File Offset: 0x0002EEC8
		public void BtnDownload_Loaded()
		{
			Visibility visibility = Conversions.ToBoolean((Conversions.ToBoolean(ModBase._BaseRule.Get("UiHiddenPageDownload", null)) && !PageSetupUI.WriteModel()) || (ModMain.contextFilter != null && ModMain.contextFilter.objectExpression)) ? Visibility.Collapsed : Visibility.Visible;
			if (this.BtnDownload.Visibility != visibility)
			{
				this.BtnDownload.Visibility = visibility;
				this.PanMain.TriggerForceResize();
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000676 RID: 1654 RVA: 0x00005D1B File Offset: 0x00003F1B
		// (set) Token: 0x06000677 RID: 1655 RVA: 0x00005D23 File Offset: 0x00003F23
		internal virtual MyCard PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000678 RID: 1656 RVA: 0x00005D2C File Offset: 0x00003F2C
		// (set) Token: 0x06000679 RID: 1657 RVA: 0x00030D40 File Offset: 0x0002EF40
		internal virtual MyButton BtnDownload
		{
			[CompilerGenerated]
			get
			{
				return this._StubModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnDownload_Click);
				RoutedEventHandler value2 = delegate(object sender, RoutedEventArgs e)
				{
					this.BtnDownload_Loaded();
				};
				MyButton stubModel = this._StubModel;
				if (stubModel != null)
				{
					stubModel.CancelModel(obj);
					stubModel.Loaded -= value2;
				}
				this._StubModel = value;
				stubModel = this._StubModel;
				if (stubModel != null)
				{
					stubModel.ValidateModel(obj);
					stubModel.Loaded += value2;
				}
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600067A RID: 1658 RVA: 0x00005D34 File Offset: 0x00003F34
		// (set) Token: 0x0600067B RID: 1659 RVA: 0x00030DA0 File Offset: 0x0002EFA0
		internal virtual MyButton BtnVersion
		{
			[CompilerGenerated]
			get
			{
				return this.accountModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnVersion_Click);
				MyButton myButton = this.accountModel;
				if (myButton != null)
				{
					myButton.CancelModel(obj);
				}
				this.accountModel = value;
				myButton = this.accountModel;
				if (myButton != null)
				{
					myButton.ValidateModel(obj);
				}
			}
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x00030DE4 File Offset: 0x0002EFE4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.configurationModel)
			{
				this.configurationModel = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pageversion/pageversionmoddisabled.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x00005D3C File Offset: 0x00003F3C
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanMain = (MyCard)target;
				return;
			}
			if (connectionId == 2)
			{
				this.BtnDownload = (MyButton)target;
				return;
			}
			if (connectionId == 3)
			{
				this.BtnVersion = (MyButton)target;
				return;
			}
			this.configurationModel = true;
		}

		// Token: 0x0400030B RID: 779
		[CompilerGenerated]
		[AccessedThroughProperty("PanMain")]
		private MyCard _ParameterModel;

		// Token: 0x0400030C RID: 780
		[AccessedThroughProperty("BtnDownload")]
		[CompilerGenerated]
		private MyButton _StubModel;

		// Token: 0x0400030D RID: 781
		[CompilerGenerated]
		[AccessedThroughProperty("BtnVersion")]
		private MyButton accountModel;

		// Token: 0x0400030E RID: 782
		private bool configurationModel;
	}
}
