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
	// Token: 0x02000099 RID: 153
	[DesignerGenerated]
	public class PageOtherHelpDetail : AdornerDecorator, IComponentConnector
	{
		// Token: 0x06000581 RID: 1409 RVA: 0x0000546C File Offset: 0x0000366C
		public PageOtherHelpDetail()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x0002BBE4 File Offset: 0x00029DE4
		public bool Init(ModMain.HelpEntry Entry)
		{
			string text = "<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" xmlns:local=\"clr-namespace:PCL;assembly=Plain Craft Launcher 2\">" + Entry.stateMapper + "</StackPanel>";
			bool result;
			try
			{
				if (string.IsNullOrEmpty(Entry.stateMapper))
				{
					throw new Exception("帮助 xaml 文件为空");
				}
				this._SchemaContainer = Entry;
				this.PanCustom.Children.Clear();
				text = text.Replace("{path}", ModBase.Path);
				this.PanCustom.Children.Add((UIElement)ModBase.GetObjectFromXML(text));
				result = true;
			}
			catch (Exception ex)
			{
				ModBase.Log("[System] 自定义信息内容：\r\n" + text, ModBase.LogLevel.Normal, "出现错误");
				ModBase.Log(ex, "加载帮助 xaml 文件失败", ModBase.LogLevel.Msgbox, "出现错误");
				result = false;
			}
			return result;
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000583 RID: 1411 RVA: 0x0000547A File Offset: 0x0000367A
		// (set) Token: 0x06000584 RID: 1412 RVA: 0x00005482 File Offset: 0x00003682
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000585 RID: 1413 RVA: 0x0000548B File Offset: 0x0000368B
		// (set) Token: 0x06000586 RID: 1414 RVA: 0x00005493 File Offset: 0x00003693
		internal virtual StackPanel PanCustom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x06000587 RID: 1415 RVA: 0x0002BCB0 File Offset: 0x00029EB0
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.queueContainer)
			{
				this.queueContainer = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pageother/pageotherhelpdetail.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x0000549C File Offset: 0x0000369C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (MyScrollViewer)target;
				return;
			}
			if (connectionId == 2)
			{
				this.PanCustom = (StackPanel)target;
				return;
			}
			this.queueContainer = true;
		}

		// Token: 0x0400029C RID: 668
		public ModMain.HelpEntry _SchemaContainer;

		// Token: 0x0400029D RID: 669
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private MyScrollViewer helperContainer;

		// Token: 0x0400029E RID: 670
		[CompilerGenerated]
		[AccessedThroughProperty("PanCustom")]
		private StackPanel _ConsumerContainer;

		// Token: 0x0400029F RID: 671
		private bool queueContainer;
	}
}
