using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x0200004C RID: 76
	[DesignerGenerated]
	public class MySearchBox : MyCard, IComponentConnector
	{
		// Token: 0x06000213 RID: 531 RVA: 0x000035E9 File Offset: 0x000017E9
		public MySearchBox()
		{
			base.Loaded += this.MySearchBox_Loaded;
			this.InitializeComponent();
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00015C20 File Offset: 0x00013E20
		[CompilerGenerated]
		public void MapVal(MySearchBox.TextChangedEventHandler obj)
		{
			MySearchBox.TextChangedEventHandler textChangedEventHandler = this.m_SingletonVal;
			MySearchBox.TextChangedEventHandler textChangedEventHandler2;
			do
			{
				textChangedEventHandler2 = textChangedEventHandler;
				MySearchBox.TextChangedEventHandler value = (MySearchBox.TextChangedEventHandler)Delegate.Combine(textChangedEventHandler2, obj);
				textChangedEventHandler = Interlocked.CompareExchange<MySearchBox.TextChangedEventHandler>(ref this.m_SingletonVal, value, textChangedEventHandler2);
			}
			while (textChangedEventHandler != textChangedEventHandler2);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00015C58 File Offset: 0x00013E58
		[CompilerGenerated]
		public void VisitVal(MySearchBox.TextChangedEventHandler obj)
		{
			MySearchBox.TextChangedEventHandler textChangedEventHandler = this.m_SingletonVal;
			MySearchBox.TextChangedEventHandler textChangedEventHandler2;
			do
			{
				textChangedEventHandler2 = textChangedEventHandler;
				MySearchBox.TextChangedEventHandler value = (MySearchBox.TextChangedEventHandler)Delegate.Remove(textChangedEventHandler2, obj);
				textChangedEventHandler = Interlocked.CompareExchange<MySearchBox.TextChangedEventHandler>(ref this.m_SingletonVal, value, textChangedEventHandler2);
			}
			while (textChangedEventHandler != textChangedEventHandler2);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00003609 File Offset: 0x00001809
		private void MySearchBox_Loaded(object sender, RoutedEventArgs e)
		{
			this.TextBox.Focus();
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000217 RID: 535 RVA: 0x00003617 File Offset: 0x00001817
		// (set) Token: 0x06000218 RID: 536 RVA: 0x00003624 File Offset: 0x00001824
		public string HintText
		{
			get
			{
				return this.TextBox.HintText;
			}
			set
			{
				this.TextBox.HintText = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000219 RID: 537 RVA: 0x00003632 File Offset: 0x00001832
		// (set) Token: 0x0600021A RID: 538 RVA: 0x0000363F File Offset: 0x0000183F
		public string Text
		{
			get
			{
				return this.TextBox.Text;
			}
			set
			{
				this.TextBox.Text = value;
			}
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00015C90 File Offset: 0x00013E90
		private void Text_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.TextBox.Text))
			{
				ModAni.AniStart(ModAni.AaOpacity(this.BtnClear, -this.BtnClear.Opacity, 0x5A, 0, null, false), "MySearchBox ClearBtn " + Conversions.ToString(this._Object), false);
				this.BtnClear.IsHitTestVisible = false;
			}
			else
			{
				ModAni.AniStart(ModAni.AaOpacity(this.BtnClear, 1.0 - this.BtnClear.Opacity, 0x5A, 0, null, false), "MySearchBox ClearBtn " + Conversions.ToString(this._Object), false);
				this.BtnClear.IsHitTestVisible = true;
			}
			MySearchBox.TextChangedEventHandler singletonVal = this.m_SingletonVal;
			if (singletonVal != null)
			{
				singletonVal(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000364D File Offset: 0x0000184D
		private void BtnClear_Click(object sender, EventArgs e)
		{
			this.TextBox.Text = "";
			this.TextBox.Focus();
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600021D RID: 541 RVA: 0x0000366B File Offset: 0x0000186B
		// (set) Token: 0x0600021E RID: 542 RVA: 0x00015D58 File Offset: 0x00013F58
		internal virtual MyTextBox TextBox
		{
			[CompilerGenerated]
			get
			{
				return this.m_ErrorVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				System.Windows.Controls.TextChangedEventHandler value2 = new System.Windows.Controls.TextChangedEventHandler(this.Text_TextChanged);
				MyTextBox errorVal = this.m_ErrorVal;
				if (errorVal != null)
				{
					errorVal.TextChanged -= value2;
				}
				this.m_ErrorVal = value;
				errorVal = this.m_ErrorVal;
				if (errorVal != null)
				{
					errorVal.TextChanged += value2;
				}
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600021F RID: 543 RVA: 0x00003673 File Offset: 0x00001873
		// (set) Token: 0x06000220 RID: 544 RVA: 0x00015D9C File Offset: 0x00013F9C
		internal virtual MyIconButton BtnClear
		{
			[CompilerGenerated]
			get
			{
				return this.m_ObjectVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyIconButton.ClickEventHandler value2 = new MyIconButton.ClickEventHandler(this.BtnClear_Click);
				MyIconButton objectVal = this.m_ObjectVal;
				if (objectVal != null)
				{
					objectVal.Click -= value2;
				}
				this.m_ObjectVal = value;
				objectVal = this.m_ObjectVal;
				if (objectVal != null)
				{
					objectVal.Click += value2;
				}
			}
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00015DE0 File Offset: 0x00013FE0
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.callbackVal)
			{
				this.callbackVal = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/controls/mysearchbox.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000367B File Offset: 0x0000187B
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.TextBox = (MyTextBox)target;
				return;
			}
			if (connectionId == 2)
			{
				this.BtnClear = (MyIconButton)target;
				return;
			}
			this.callbackVal = true;
		}

		// Token: 0x040000EB RID: 235
		[CompilerGenerated]
		private MySearchBox.TextChangedEventHandler m_SingletonVal;

		// Token: 0x040000EC RID: 236
		[CompilerGenerated]
		[AccessedThroughProperty("TextBox")]
		private MyTextBox m_ErrorVal;

		// Token: 0x040000ED RID: 237
		[CompilerGenerated]
		[AccessedThroughProperty("BtnClear")]
		private MyIconButton m_ObjectVal;

		// Token: 0x040000EE RID: 238
		private bool callbackVal;

		// Token: 0x0200004D RID: 77
		// (Invoke) Token: 0x06000227 RID: 551
		public delegate void TextChangedEventHandler(object sender, EventArgs e);
	}
}
