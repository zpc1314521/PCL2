using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PCL
{
	// Token: 0x02000052 RID: 82
	public class MyTextButton : Label
	{
		// Token: 0x06000257 RID: 599 RVA: 0x0001681C File Offset: 0x00014A1C
		// Note: this type is marked as 'beforefieldinit'.
		static MyTextButton()
		{
			MyTextButton.prototypeVal = DependencyProperty.Register("Text", typeof(string), typeof(MyTextButton), new PropertyMetadata("", delegate(DependencyObject a0, DependencyPropertyChangedEventArgs a1)
			{
				((MyTextButton._Closure$__.$I0-0 == null) ? (MyTextButton._Closure$__.$I0-0 = delegate(MyTextButton sender, DependencyPropertyChangedEventArgs e)
				{
					if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(e.OldValue, e.NewValue, true))))
					{
						ModAni.AniStart(new ModAni.AniData[]
						{
							ModAni.AaOpacity(sender, -sender.Opacity, 0x32, 0, null, false),
							ModAni.AaCode(delegate
							{
								sender.Content = RuntimeHelpers.GetObjectValue(e.NewValue);
							}, 0, true),
							ModAni.AaOpacity(sender, 1.0, 0xAA, 0, null, false)
						}, "MyTextButton Text " + Conversions.ToString(sender.proccesorVal), false);
					}
				}) : MyTextButton._Closure$__.$I0-0)((MyTextButton)a0, a1);
			}));
			MyTextButton._StubVal = DependencyProperty.Register("EventType", typeof(string), typeof(MyTextButton), new PropertyMetadata(null));
			MyTextButton._AccountVal = DependencyProperty.Register("EventData", typeof(string), typeof(MyTextButton), new PropertyMetadata(null));
		}

		// Token: 0x06000258 RID: 600 RVA: 0x000168B8 File Offset: 0x00014AB8
		[CompilerGenerated]
		public void CreateContainer(MyTextButton.ClickEventHandler obj)
		{
			MyTextButton.ClickEventHandler clickEventHandler = this.systemVal;
			MyTextButton.ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				MyTextButton.ClickEventHandler value = (MyTextButton.ClickEventHandler)Delegate.Combine(clickEventHandler2, obj);
				clickEventHandler = Interlocked.CompareExchange<MyTextButton.ClickEventHandler>(ref this.systemVal, value, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}

		// Token: 0x06000259 RID: 601 RVA: 0x000168F0 File Offset: 0x00014AF0
		[CompilerGenerated]
		public void FindContainer(MyTextButton.ClickEventHandler obj)
		{
			MyTextButton.ClickEventHandler clickEventHandler = this.systemVal;
			MyTextButton.ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				MyTextButton.ClickEventHandler value = (MyTextButton.ClickEventHandler)Delegate.Remove(clickEventHandler2, obj);
				clickEventHandler = Interlocked.CompareExchange<MyTextButton.ClickEventHandler>(ref this.systemVal, value, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00016928 File Offset: 0x00014B28
		public MyTextButton()
		{
			base.PreviewMouseLeftButtonDown += this.MyTextButton_MouseLeftButtonDown;
			base.MouseLeave += delegate(object sender, MouseEventArgs e)
			{
				this.MyTextButton_MouseLeave();
			};
			base.PreviewMouseLeftButtonUp += this.MyTextButton_MouseLeftButtonUp;
			base.MouseEnter += delegate(object sender, MouseEventArgs e)
			{
				this.RefreshColor();
			};
			base.MouseLeave += delegate(object sender, MouseEventArgs e)
			{
				this.RefreshColor();
			};
			base.IsEnabledChanged += delegate(object sender, DependencyPropertyChangedEventArgs e)
			{
				this.RefreshColor();
			};
			base.MouseLeftButtonDown += delegate(object sender, MouseButtonEventArgs e)
			{
				this.RefreshColor();
			};
			base.MouseLeftButtonUp += delegate(object sender, MouseButtonEventArgs e)
			{
				this.RefreshColor();
			};
			this.proccesorVal = ModBase.GetUuid();
			this._RefVal = false;
			base.SetResourceReference(Control.ForegroundProperty, "ColorBrush1");
			base.Background = ModMain.m_AttributeFilter;
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600025B RID: 603 RVA: 0x0000387F File Offset: 0x00001A7F
		// (set) Token: 0x0600025C RID: 604 RVA: 0x00003891 File Offset: 0x00001A91
		public string Text
		{
			get
			{
				return Conversions.ToString(base.GetValue(MyTextButton.prototypeVal));
			}
			set
			{
				base.SetValue(MyTextButton.prototypeVal, value);
			}
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000389F File Offset: 0x00001A9F
		private void MyTextButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			this._RefVal = true;
			e.Handled = true;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x000038AF File Offset: 0x00001AAF
		private void MyTextButton_MouseLeave()
		{
			this._RefVal = false;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00016A00 File Offset: 0x00014C00
		private void MyTextButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (this._RefVal)
			{
				this._RefVal = false;
				ModBase.Log("[Control] 按下文本按钮：" + this.Text, ModBase.LogLevel.Normal, "出现错误");
				MyTextButton.ClickEventHandler clickEventHandler = this.systemVal;
				if (clickEventHandler != null)
				{
					clickEventHandler(this, null);
				}
				ModEvent.TryStartEvent(this.EventType, this.EventData);
				e.Handled = true;
			}
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00016A64 File Offset: 0x00014C64
		private void RefreshColor()
		{
			string text;
			int time;
			if (this._RefVal)
			{
				text = "ColorBrush4";
				time = 0x1E;
			}
			else if (base.IsMouseOver)
			{
				text = "ColorBrush3";
				time = 0x64;
			}
			else
			{
				text = "ColorBrush1";
				time = 0xC8;
			}
			if (Operators.CompareString(this._ParameterVal, text, true) != 0)
			{
				this._ParameterVal = text;
				if (base.IsLoaded && ModAni.InsertFactory() == 0)
				{
					ModAni.AniStart(ModAni.AaColor(this, Control.ForegroundProperty, text, time, 0, null, false), "MyTextButton Color " + Conversions.ToString(this.proccesorVal), false);
					return;
				}
				ModAni.AniStop("MyTextButton Color " + Conversions.ToString(this.proccesorVal));
				base.SetResourceReference(Control.ForegroundProperty, text);
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000261 RID: 609 RVA: 0x000038B8 File Offset: 0x00001AB8
		// (set) Token: 0x06000262 RID: 610 RVA: 0x000038CA File Offset: 0x00001ACA
		public string EventType
		{
			get
			{
				return Conversions.ToString(base.GetValue(MyTextButton._StubVal));
			}
			set
			{
				base.SetValue(MyTextButton._StubVal, value);
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000263 RID: 611 RVA: 0x000038D8 File Offset: 0x00001AD8
		// (set) Token: 0x06000264 RID: 612 RVA: 0x000038EA File Offset: 0x00001AEA
		public string EventData
		{
			get
			{
				return Conversions.ToString(base.GetValue(MyTextButton._AccountVal));
			}
			set
			{
				base.SetValue(MyTextButton._AccountVal, value);
			}
		}

		// Token: 0x04000100 RID: 256
		[CompilerGenerated]
		private MyTextButton.ClickEventHandler systemVal;

		// Token: 0x04000101 RID: 257
		public int proccesorVal;

		// Token: 0x04000102 RID: 258
		public static readonly DependencyProperty prototypeVal;

		// Token: 0x04000103 RID: 259
		public bool _RefVal;

		// Token: 0x04000104 RID: 260
		private string _ParameterVal;

		// Token: 0x04000105 RID: 261
		public static readonly DependencyProperty _StubVal;

		// Token: 0x04000106 RID: 262
		public static readonly DependencyProperty _AccountVal;

		// Token: 0x02000053 RID: 83
		// (Invoke) Token: 0x0600026E RID: 622
		public delegate void ClickEventHandler(object sender, EventArgs e);
	}
}
