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
	// Token: 0x0200015F RID: 351
	[DesignerGenerated]
	public class PageSpeedRight : AdornerDecorator, IComponentConnector
	{
		// Token: 0x06000F3D RID: 3901 RVA: 0x00009EA6 File Offset: 0x000080A6
		public PageSpeedRight()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.Init();
			};
			this.InitializeComponent();
		}

		// Token: 0x06000F3E RID: 3902 RVA: 0x00009EC6 File Offset: 0x000080C6
		private void Init()
		{
			this.PanBack.ScrollToHome();
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06000F3F RID: 3903 RVA: 0x00009ED3 File Offset: 0x000080D3
		// (set) Token: 0x06000F40 RID: 3904 RVA: 0x00009EDB File Offset: 0x000080DB
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06000F41 RID: 3905 RVA: 0x00009EE4 File Offset: 0x000080E4
		// (set) Token: 0x06000F42 RID: 3906 RVA: 0x00009EEC File Offset: 0x000080EC
		internal virtual StackPanel PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x06000F43 RID: 3907 RVA: 0x000719EC File Offset: 0x0006FBEC
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this._SpecificationBase)
			{
				this._SpecificationBase = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagespeedright.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000F44 RID: 3908 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000F45 RID: 3909 RVA: 0x00009EF5 File Offset: 0x000080F5
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
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
			this._SpecificationBase = true;
		}

		// Token: 0x04000805 RID: 2053
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private MyScrollViewer m_ParamBase;

		// Token: 0x04000806 RID: 2054
		[AccessedThroughProperty("PanMain")]
		[CompilerGenerated]
		private StackPanel mockBase;

		// Token: 0x04000807 RID: 2055
		private bool _SpecificationBase;
	}
}
