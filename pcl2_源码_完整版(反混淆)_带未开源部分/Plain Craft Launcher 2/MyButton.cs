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
using System.Windows.Media;

namespace PCL
{
	// Token: 0x02000166 RID: 358
	[DesignerGenerated]
	public class MyButton : Border, IComponentConnector
	{
		// Token: 0x06000FA2 RID: 4002 RVA: 0x0007404C File Offset: 0x0007224C
		// Note: this type is marked as 'beforefieldinit'.
		static MyButton()
		{
			MyButton.m_BridgeDecorator = DependencyProperty.Register("Text", typeof(string), typeof(MyButton), new PropertyMetadata(delegate(DependencyObject sender, DependencyPropertyChangedEventArgs e)
			{
				if (!Information.IsNothing(sender))
				{
					((MyButton)sender).LabText.Text = Conversions.ToString(e.NewValue);
				}
			}));
			MyButton.errorDecorator = DependencyProperty.Register("Padding", typeof(Thickness), typeof(MyButton), new PropertyMetadata(delegate(DependencyObject a0, DependencyPropertyChangedEventArgs a1)
			{
				((MyButton._Closure$__.$I0-1 == null) ? (MyButton._Closure$__.$I0-1 = delegate(MyButton sender, DependencyPropertyChangedEventArgs e)
				{
					if (sender != null)
					{
						Border panFore = sender.PanFore;
						object newValue = e.NewValue;
						panFore.Padding = ((newValue != null) ? ((Thickness)newValue) : default(Thickness));
					}
				}) : MyButton._Closure$__.$I0-1)((MyButton)a0, a1);
			}));
			MyButton.objectDecorator = DependencyProperty.Register("EventType", typeof(string), typeof(MyButton), new PropertyMetadata(null));
			MyButton.m_CallbackDecorator = DependencyProperty.Register("EventData", typeof(string), typeof(MyButton), new PropertyMetadata(null));
		}

		// Token: 0x06000FA3 RID: 4003 RVA: 0x0007411C File Offset: 0x0007231C
		public MyButton()
		{
			base.MouseEnter += new MouseEventHandler(this.RefreshColor);
			base.MouseLeave += new MouseEventHandler(this.RefreshColor);
			base.Loaded += new RoutedEventHandler(this.RefreshColor);
			base.IsEnabledChanged += delegate(object sender, DependencyPropertyChangedEventArgs e)
			{
				this.RefreshColor(RuntimeHelpers.GetObjectValue(sender), e);
			};
			base.MouseLeftButtonUp += this.Button_MouseUp;
			base.MouseLeftButtonDown += this.Button_MouseDown;
			base.MouseEnter += delegate(object sender, MouseEventArgs e)
			{
				this.Button_MouseEnter();
			};
			base.MouseLeftButtonUp += delegate(object sender, MouseButtonEventArgs e)
			{
				this.Button_MouseUp();
			};
			base.MouseLeave += delegate(object sender, MouseEventArgs e)
			{
				this.Button_MouseLeave();
			};
			this.m_MappingDecorator = ModBase.GetUuid();
			this.singletonDecorator = MyButton.ColorState.Normal;
			this._WorkerDecorator = false;
			this.InitializeComponent();
		}

		// Token: 0x06000FA4 RID: 4004 RVA: 0x000741F0 File Offset: 0x000723F0
		[CompilerGenerated]
		public void ValidateModel(MyButton.ClickEventHandler obj)
		{
			MyButton.ClickEventHandler clickEventHandler = this.m_CodeDecorator;
			MyButton.ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				MyButton.ClickEventHandler value = (MyButton.ClickEventHandler)Delegate.Combine(clickEventHandler2, obj);
				clickEventHandler = Interlocked.CompareExchange<MyButton.ClickEventHandler>(ref this.m_CodeDecorator, value, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}

		// Token: 0x06000FA5 RID: 4005 RVA: 0x00074228 File Offset: 0x00072428
		[CompilerGenerated]
		public void CancelModel(MyButton.ClickEventHandler obj)
		{
			MyButton.ClickEventHandler clickEventHandler = this.m_CodeDecorator;
			MyButton.ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				MyButton.ClickEventHandler value = (MyButton.ClickEventHandler)Delegate.Remove(clickEventHandler2, obj);
				clickEventHandler = Interlocked.CompareExchange<MyButton.ClickEventHandler>(ref this.m_CodeDecorator, value, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06000FA6 RID: 4006 RVA: 0x0000A214 File Offset: 0x00008414
		// (set) Token: 0x06000FA7 RID: 4007 RVA: 0x0000A221 File Offset: 0x00008421
		public string Text
		{
			get
			{
				return this.LabText.Text;
			}
			set
			{
				this.LabText.Text = value;
			}
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x06000FA8 RID: 4008 RVA: 0x0000A22F File Offset: 0x0000842F
		// (set) Token: 0x06000FA9 RID: 4009 RVA: 0x0000A23C File Offset: 0x0000843C
		public Thickness TextPadding
		{
			get
			{
				return this.LabText.Padding;
			}
			set
			{
				this.LabText.Padding = value;
			}
		}

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x06000FAA RID: 4010 RVA: 0x0000A24A File Offset: 0x0000844A
		// (set) Token: 0x06000FAB RID: 4011 RVA: 0x0000A252 File Offset: 0x00008452
		public MyButton.ColorState ColorType
		{
			get
			{
				return this.singletonDecorator;
			}
			set
			{
				this.singletonDecorator = value;
				this.RefreshColor(null, null);
			}
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06000FAC RID: 4012 RVA: 0x0000A263 File Offset: 0x00008463
		// (set) Token: 0x06000FAD RID: 4013 RVA: 0x0000A270 File Offset: 0x00008470
		public new Thickness Padding
		{
			get
			{
				return this.PanFore.Padding;
			}
			set
			{
				this.PanFore.Padding = value;
			}
		}

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x06000FAE RID: 4014 RVA: 0x0000A27E File Offset: 0x0000847E
		// (set) Token: 0x06000FAF RID: 4015 RVA: 0x0000A28B File Offset: 0x0000848B
		public Transform RealRenderTransform
		{
			get
			{
				return this.PanFore.RenderTransform;
			}
			set
			{
				this.PanFore.RenderTransform = value;
			}
		}

		// Token: 0x06000FB0 RID: 4016 RVA: 0x00074260 File Offset: 0x00072460
		private void RefreshColor(object obj = null, object e = null)
		{
			try
			{
				if (base.IsLoaded && ModAni.InsertFactory() == 0)
				{
					if (base.IsEnabled)
					{
						switch (this.ColorType)
						{
						case MyButton.ColorState.Normal:
							if (base.IsMouseOver)
							{
								ModAni.AniStart(new ModAni.AniData[]
								{
									ModAni.AaColor(this.PanFore, Border.BorderBrushProperty, "ColorBrush3", 0x64, 0, null, false)
								}, "MyButton Color " + Conversions.ToString(this.m_MappingDecorator), false);
							}
							else
							{
								ModAni.AniStart(new ModAni.AniData[]
								{
									ModAni.AaColor(this.PanFore, Border.BorderBrushProperty, "ColorBrush1", 0xC8, 0, null, false)
								}, "MyButton Color " + Conversions.ToString(this.m_MappingDecorator), false);
							}
							break;
						case MyButton.ColorState.Highlight:
							if (base.IsMouseOver)
							{
								ModAni.AniStart(new ModAni.AniData[]
								{
									ModAni.AaColor(this.PanFore, Border.BorderBrushProperty, "ColorBrush3", 0x64, 0, null, false)
								}, "MyButton Color " + Conversions.ToString(this.m_MappingDecorator), false);
							}
							else
							{
								ModAni.AniStart(new ModAni.AniData[]
								{
									ModAni.AaColor(this.PanFore, Border.BorderBrushProperty, "ColorBrush2", 0xC8, 0, null, false)
								}, "MyButton Color " + Conversions.ToString(this.m_MappingDecorator), false);
							}
							break;
						case MyButton.ColorState.Red:
							if (base.IsMouseOver)
							{
								ModAni.AniStart(new ModAni.AniData[]
								{
									ModAni.AaColor(this.PanFore, Border.BorderBrushProperty, "ColorBrushRedLight", 0x64, 0, null, false)
								}, "MyButton Color " + Conversions.ToString(this.m_MappingDecorator), false);
							}
							else
							{
								ModAni.AniStart(new ModAni.AniData[]
								{
									ModAni.AaColor(this.PanFore, Border.BorderBrushProperty, "ColorBrushRedDark", 0xC8, 0, null, false)
								}, "MyButton Color " + Conversions.ToString(this.m_MappingDecorator), false);
							}
							break;
						}
					}
					else
					{
						ModAni.AniStart(new ModAni.AniData[]
						{
							ModAni.AaColor(this.PanFore, Border.BorderBrushProperty, ModMain._EventFilter - this.PanFore.BorderBrush, 0xC8, 0, null, false)
						}, "MyButton Color " + Conversions.ToString(this.m_MappingDecorator), false);
					}
				}
				else
				{
					ModAni.AniStop("MyButton Color " + Conversions.ToString(this.m_MappingDecorator));
					if (base.IsEnabled)
					{
						switch (this.ColorType)
						{
						case MyButton.ColorState.Normal:
							if (base.IsMouseOver)
							{
								this.PanFore.SetResourceReference(Border.BorderBrushProperty, "ColorBrush3");
							}
							else
							{
								this.PanFore.SetResourceReference(Border.BorderBrushProperty, "ColorBrush1");
							}
							break;
						case MyButton.ColorState.Highlight:
							if (base.IsMouseOver)
							{
								this.PanFore.SetResourceReference(Border.BorderBrushProperty, "ColorBrush3");
							}
							else
							{
								this.PanFore.SetResourceReference(Border.BorderBrushProperty, "ColorBrush2");
							}
							break;
						case MyButton.ColorState.Red:
							if (base.IsMouseOver)
							{
								this.PanFore.SetResourceReference(Border.BorderBrushProperty, "ColorBrushRedLight");
							}
							else
							{
								this.PanFore.SetResourceReference(Border.BorderBrushProperty, "ColorBrushRedDark");
							}
							break;
						}
					}
					else
					{
						this.PanFore.BorderBrush = ModMain._EventFilter;
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "刷新按钮颜色出错", ModBase.LogLevel.Debug, "出现错误");
			}
		}

		// Token: 0x06000FB1 RID: 4017 RVA: 0x00074614 File Offset: 0x00072814
		private void Button_MouseUp(object sender, MouseButtonEventArgs e)
		{
			if (this._WorkerDecorator)
			{
				ModBase.Log("[Control] 按下按钮：" + this.Text, ModBase.LogLevel.Normal, "出现错误");
				MyButton.ClickEventHandler codeDecorator = this.m_CodeDecorator;
				if (codeDecorator != null)
				{
					codeDecorator(RuntimeHelpers.GetObjectValue(sender), e);
				}
				if (!string.IsNullOrEmpty(Conversions.ToString(base.Tag)) && (base.Tag.ToString().StartsWith("链接-") || base.Tag.ToString().StartsWith("启动-")))
				{
					ModMain.Hint("主页自定义按钮语法已更新，且不再兼容老版本语法，请查看新的自定义示例！", ModMain.HintType.Info, true);
				}
				ModEvent.TryStartEvent(this.EventType, this.EventData);
			}
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x06000FB2 RID: 4018 RVA: 0x0000A299 File Offset: 0x00008499
		// (set) Token: 0x06000FB3 RID: 4019 RVA: 0x0000A2AB File Offset: 0x000084AB
		public string EventType
		{
			get
			{
				return Conversions.ToString(base.GetValue(MyButton.objectDecorator));
			}
			set
			{
				base.SetValue(MyButton.objectDecorator, value);
			}
		}

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x06000FB4 RID: 4020 RVA: 0x0000A2B9 File Offset: 0x000084B9
		// (set) Token: 0x06000FB5 RID: 4021 RVA: 0x0000A2CB File Offset: 0x000084CB
		public string EventData
		{
			get
			{
				return Conversions.ToString(base.GetValue(MyButton.m_CallbackDecorator));
			}
			set
			{
				base.SetValue(MyButton.m_CallbackDecorator, value);
			}
		}

		// Token: 0x06000FB6 RID: 4022 RVA: 0x000746BC File Offset: 0x000728BC
		private void Button_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this._WorkerDecorator = true;
			base.Focus();
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaScaleTransform(this.PanFore, 0.955 - ((ScaleTransform)this.PanFore.RenderTransform).ScaleX, 0x50, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.ExtraStrong), false),
				ModAni.AaScaleTransform(this.PanFore, -0.01, 0x2BC, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false)
			}, "MyButton Scale " + Conversions.ToString(this.m_MappingDecorator), false);
		}

		// Token: 0x06000FB7 RID: 4023 RVA: 0x0007475C File Offset: 0x0007295C
		private void Button_MouseEnter()
		{
			ModAni.AniStart(ModAni.AaColor(this.PanFore, Border.BackgroundProperty, (this.singletonDecorator == MyButton.ColorState.Red) ? "ColorBrushRedBack" : "ColorBrush9", 0x64, 0, null, false), "MyButton Background " + Conversions.ToString(this.m_MappingDecorator), false);
		}

		// Token: 0x06000FB8 RID: 4024 RVA: 0x000747B0 File Offset: 0x000729B0
		private void Button_MouseUp()
		{
			if (this._WorkerDecorator)
			{
				this._WorkerDecorator = false;
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaScaleTransform(this.PanFore, 1.0 - ((ScaleTransform)this.PanFore.RenderTransform).ScaleX, 0x12C, 0xA, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false)
				}, "MyButton Scale " + Conversions.ToString(this.m_MappingDecorator), false);
			}
		}

		// Token: 0x06000FB9 RID: 4025 RVA: 0x0007482C File Offset: 0x00072A2C
		private void Button_MouseLeave()
		{
			ModAni.AniStart(ModAni.AaColor(this.PanFore, Border.BackgroundProperty, "ColorBrushHalfWhite", 0xC8, 0, null, false), "MyButton Background " + Conversions.ToString(this.m_MappingDecorator), false);
			if (this._WorkerDecorator)
			{
				this._WorkerDecorator = false;
				ModAni.AniStart(ModAni.AaScaleTransform(this.PanFore, 1.0 - ((ScaleTransform)this.PanFore.RenderTransform).ScaleX, 0x320, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false), "MyButton Scale " + Conversions.ToString(this.m_MappingDecorator), false);
			}
		}

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x06000FBA RID: 4026 RVA: 0x0000A2D9 File Offset: 0x000084D9
		// (set) Token: 0x06000FBB RID: 4027 RVA: 0x0000A2E1 File Offset: 0x000084E1
		internal virtual MyButton PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x06000FBC RID: 4028 RVA: 0x0000A2EA File Offset: 0x000084EA
		// (set) Token: 0x06000FBD RID: 4029 RVA: 0x0000A2F2 File Offset: 0x000084F2
		internal virtual Border PanFore { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x06000FBE RID: 4030 RVA: 0x0000A2FB File Offset: 0x000084FB
		// (set) Token: 0x06000FBF RID: 4031 RVA: 0x0000A303 File Offset: 0x00008503
		internal virtual TextBlock LabText { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x06000FC0 RID: 4032 RVA: 0x000748D4 File Offset: 0x00072AD4
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.databaseDecorator)
			{
				this.databaseDecorator = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/controls/mybutton.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000FC1 RID: 4033 RVA: 0x0000A30C File Offset: 0x0000850C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (MyButton)target;
				return;
			}
			if (connectionId == 2)
			{
				this.PanFore = (Border)target;
				return;
			}
			if (connectionId == 3)
			{
				this.LabText = (TextBlock)target;
				return;
			}
			this.databaseDecorator = true;
		}

		// Token: 0x0400083C RID: 2108
		[CompilerGenerated]
		private MyButton.ClickEventHandler m_CodeDecorator;

		// Token: 0x0400083D RID: 2109
		public int m_MappingDecorator;

		// Token: 0x0400083E RID: 2110
		public static readonly DependencyProperty m_BridgeDecorator;

		// Token: 0x0400083F RID: 2111
		private MyButton.ColorState singletonDecorator;

		// Token: 0x04000840 RID: 2112
		public static readonly DependencyProperty errorDecorator;

		// Token: 0x04000841 RID: 2113
		public static readonly DependencyProperty objectDecorator;

		// Token: 0x04000842 RID: 2114
		public static readonly DependencyProperty m_CallbackDecorator;

		// Token: 0x04000843 RID: 2115
		private bool _WorkerDecorator;

		// Token: 0x04000844 RID: 2116
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private MyButton m_VisitorDecorator;

		// Token: 0x04000845 RID: 2117
		[AccessedThroughProperty("PanFore")]
		[CompilerGenerated]
		private Border indexerDecorator;

		// Token: 0x04000846 RID: 2118
		[AccessedThroughProperty("LabText")]
		[CompilerGenerated]
		private TextBlock _MethodDecorator;

		// Token: 0x04000847 RID: 2119
		private bool databaseDecorator;

		// Token: 0x02000167 RID: 359
		// (Invoke) Token: 0x06000FC9 RID: 4041
		public delegate void ClickEventHandler(object sender, EventArgs e);

		// Token: 0x02000168 RID: 360
		public enum ColorState
		{
			// Token: 0x04000849 RID: 2121
			Normal,
			// Token: 0x0400084A RID: 2122
			Highlight,
			// Token: 0x0400084B RID: 2123
			Red
		}
	}
}
