using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x02000157 RID: 343
	[DesignerGenerated]
	public class PageSetupAccount : AdornerDecorator, IComponentConnector
	{
		// Token: 0x06000DDB RID: 3547 RVA: 0x0000968B File Offset: 0x0000788B
		public PageSetupAccount()
		{
			base.Loaded += this.PageSetupSystem_Loaded;
			this.m_TokenUtils = false;
			this.InitializeComponent();
		}

		// Token: 0x06000DDC RID: 3548 RVA: 0x000096B2 File Offset: 0x000078B2
		private void PageSetupSystem_Loaded(object sender, RoutedEventArgs e)
		{
			this.PanBack.ScrollToHome();
			checked
			{
				if (!this.m_TokenUtils)
				{
					this.m_TokenUtils = true;
					ModAni.ListFactory(ModAni.InsertFactory() + 1);
					ModAni.ListFactory(ModAni.InsertFactory() - 1);
				}
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000DDD RID: 3549 RVA: 0x000096E6 File Offset: 0x000078E6
		// (set) Token: 0x06000DDE RID: 3550 RVA: 0x000096EE File Offset: 0x000078EE
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000DDF RID: 3551 RVA: 0x000096F7 File Offset: 0x000078F7
		// (set) Token: 0x06000DE0 RID: 3552 RVA: 0x000096FF File Offset: 0x000078FF
		internal virtual StackPanel PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x06000DE1 RID: 3553 RVA: 0x0006C80C File Offset: 0x0006AA0C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.valBase)
			{
				this.valBase = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagesetup/pagesetupaccount.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000DE2 RID: 3554 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000DE3 RID: 3555 RVA: 0x00009708 File Offset: 0x00007908
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (MyScrollViewer)target;
				return;
			}
			if (connectionId == 2)
			{
				this.PanMain = (StackPanel)target;
				return;
			}
			this.valBase = true;
		}

		// Token: 0x04000750 RID: 1872
		private bool m_TokenUtils;

		// Token: 0x04000751 RID: 1873
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private MyScrollViewer m_ProcUtils;

		// Token: 0x04000752 RID: 1874
		[AccessedThroughProperty("PanMain")]
		[CompilerGenerated]
		private StackPanel factoryBase;

		// Token: 0x04000753 RID: 1875
		private bool valBase;
	}
}
