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
	// Token: 0x020000AB RID: 171
	[DesignerGenerated]
	public class PageLinkLeft : MyPageLeft, IComponentConnector
	{
		// Token: 0x06000609 RID: 1545 RVA: 0x0000597E File Offset: 0x00003B7E
		public PageLinkLeft()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x0000598C File Offset: 0x00003B8C
		private void BtnLeftCreate_Click()
		{
			PageLinkRight.BtnLeftCreate_Click();
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x00005993 File Offset: 0x00003B93
		private void BtnLeftCopy_Click()
		{
			PageLinkRight.BtnLeftCopy_Click();
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x0600060C RID: 1548 RVA: 0x0000599A File Offset: 0x00003B9A
		// (set) Token: 0x0600060D RID: 1549 RVA: 0x000059A2 File Offset: 0x00003BA2
		internal virtual Grid PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x0600060E RID: 1550 RVA: 0x000059AB File Offset: 0x00003BAB
		// (set) Token: 0x0600060F RID: 1551 RVA: 0x000059B3 File Offset: 0x00003BB3
		internal virtual TextBlock LabTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000610 RID: 1552 RVA: 0x000059BC File Offset: 0x00003BBC
		// (set) Token: 0x06000611 RID: 1553 RVA: 0x000059C4 File Offset: 0x00003BC4
		internal virtual MyScrollViewer PanListHost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000612 RID: 1554 RVA: 0x000059CD File Offset: 0x00003BCD
		// (set) Token: 0x06000613 RID: 1555 RVA: 0x000059D5 File Offset: 0x00003BD5
		internal virtual MyListItem ItemMe { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000614 RID: 1556 RVA: 0x000059DE File Offset: 0x00003BDE
		// (set) Token: 0x06000615 RID: 1557 RVA: 0x000059E6 File Offset: 0x00003BE6
		internal virtual StackPanel PanList { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000616 RID: 1558 RVA: 0x000059EF File Offset: 0x00003BEF
		// (set) Token: 0x06000617 RID: 1559 RVA: 0x0002F258 File Offset: 0x0002D458
		internal virtual MyListItem BtnLeftCreate
		{
			[CompilerGenerated]
			get
			{
				return this._ParamsModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyListItem.ClickEventHandler obj = delegate(object sender, MouseButtonEventArgs e)
				{
					this.BtnLeftCreate_Click();
				};
				MyListItem paramsModel = this._ParamsModel;
				if (paramsModel != null)
				{
					paramsModel.PushModel(obj);
				}
				this._ParamsModel = value;
				paramsModel = this._ParamsModel;
				if (paramsModel != null)
				{
					paramsModel.QueryModel(obj);
				}
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000618 RID: 1560 RVA: 0x000059F7 File Offset: 0x00003BF7
		// (set) Token: 0x06000619 RID: 1561 RVA: 0x0002F29C File Offset: 0x0002D49C
		internal virtual MyListItem BtnLeftCopy
		{
			[CompilerGenerated]
			get
			{
				return this.globalModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyListItem.ClickEventHandler obj = delegate(object sender, MouseButtonEventArgs e)
				{
					this.BtnLeftCopy_Click();
				};
				MyListItem myListItem = this.globalModel;
				if (myListItem != null)
				{
					myListItem.PushModel(obj);
				}
				this.globalModel = value;
				myListItem = this.globalModel;
				if (myListItem != null)
				{
					myListItem.QueryModel(obj);
				}
			}
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x0002F2E0 File Offset: 0x0002D4E0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.m_IssuerModel)
			{
				this.m_IssuerModel = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagelinkleft.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x0002F310 File Offset: 0x0002D510
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (Grid)target;
				return;
			}
			if (connectionId == 2)
			{
				this.LabTitle = (TextBlock)target;
				return;
			}
			if (connectionId == 3)
			{
				this.PanListHost = (MyScrollViewer)target;
				return;
			}
			if (connectionId == 4)
			{
				this.ItemMe = (MyListItem)target;
				return;
			}
			if (connectionId == 5)
			{
				this.PanList = (StackPanel)target;
				return;
			}
			if (connectionId == 6)
			{
				this.BtnLeftCreate = (MyListItem)target;
				return;
			}
			if (connectionId == 7)
			{
				this.BtnLeftCopy = (MyListItem)target;
				return;
			}
			this.m_IssuerModel = true;
		}

		// Token: 0x040002E7 RID: 743
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private Grid decoratorModel;

		// Token: 0x040002E8 RID: 744
		[AccessedThroughProperty("LabTitle")]
		[CompilerGenerated]
		private TextBlock m_FilterModel;

		// Token: 0x040002E9 RID: 745
		[CompilerGenerated]
		[AccessedThroughProperty("PanListHost")]
		private MyScrollViewer _RuleModel;

		// Token: 0x040002EA RID: 746
		[AccessedThroughProperty("ItemMe")]
		[CompilerGenerated]
		private MyListItem m_AlgoModel;

		// Token: 0x040002EB RID: 747
		[CompilerGenerated]
		[AccessedThroughProperty("PanList")]
		private StackPanel m_MapperModel;

		// Token: 0x040002EC RID: 748
		[CompilerGenerated]
		[AccessedThroughProperty("BtnLeftCreate")]
		private MyListItem _ParamsModel;

		// Token: 0x040002ED RID: 749
		[CompilerGenerated]
		[AccessedThroughProperty("BtnLeftCopy")]
		private MyListItem globalModel;

		// Token: 0x040002EE RID: 750
		private bool m_IssuerModel;
	}
}
