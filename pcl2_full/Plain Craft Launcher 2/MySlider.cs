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
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PCL
{
	// Token: 0x0200017D RID: 381
	[DesignerGenerated]
	public class MySlider : Border, IComponentConnector
	{
		// Token: 0x06001092 RID: 4242 RVA: 0x0007845C File Offset: 0x0007665C
		public MySlider()
		{
			base.SizeChanged += this.RefreshWidth;
			base.MouseLeftButtonDown += this.DragStart;
			base.IsEnabledChanged += delegate(object sender, DependencyPropertyChangedEventArgs e)
			{
				this.RefreshColor();
			};
			base.MouseEnter += delegate(object sender, MouseEventArgs e)
			{
				this.RefreshColor();
			};
			base.MouseLeave += delegate(object sender, MouseEventArgs e)
			{
				this.RefreshColor();
			};
			base.MouseEnter += delegate(object sender, MouseEventArgs e)
			{
				this.MySlider_MouseEnter();
			};
			base.KeyDown += this.MySlider_KeyDown;
			this._TaskDecorator = ModBase.GetUuid();
			this.m_ListenerDecorator = 0x64;
			this.importerDecorator = false;
			this._TemplateDecorator = 0;
			this.ValueByKey = 1U;
			this.InitializeComponent();
		}

		// Token: 0x06001093 RID: 4243 RVA: 0x0007851C File Offset: 0x0007671C
		[CompilerGenerated]
		public void InterruptIterator(MySlider.ChangeEventHandler obj)
		{
			MySlider.ChangeEventHandler changeEventHandler = this.m_AuthenticationDecorator;
			MySlider.ChangeEventHandler changeEventHandler2;
			do
			{
				changeEventHandler2 = changeEventHandler;
				MySlider.ChangeEventHandler value = (MySlider.ChangeEventHandler)Delegate.Combine(changeEventHandler2, obj);
				changeEventHandler = Interlocked.CompareExchange<MySlider.ChangeEventHandler>(ref this.m_AuthenticationDecorator, value, changeEventHandler2);
			}
			while (changeEventHandler != changeEventHandler2);
		}

		// Token: 0x06001094 RID: 4244 RVA: 0x00078554 File Offset: 0x00076754
		[CompilerGenerated]
		public void InstantiateIterator(MySlider.ChangeEventHandler obj)
		{
			MySlider.ChangeEventHandler changeEventHandler = this.m_AuthenticationDecorator;
			MySlider.ChangeEventHandler changeEventHandler2;
			do
			{
				changeEventHandler2 = changeEventHandler;
				MySlider.ChangeEventHandler value = (MySlider.ChangeEventHandler)Delegate.Remove(changeEventHandler2, obj);
				changeEventHandler = Interlocked.CompareExchange<MySlider.ChangeEventHandler>(ref this.m_AuthenticationDecorator, value, changeEventHandler2);
			}
			while (changeEventHandler != changeEventHandler2);
		}

		// Token: 0x06001095 RID: 4245 RVA: 0x0007858C File Offset: 0x0007678C
		[CompilerGenerated]
		public void InitIterator(MySlider.PreviewChangeEventHandler obj)
		{
			MySlider.PreviewChangeEventHandler previewChangeEventHandler = this.processDecorator;
			MySlider.PreviewChangeEventHandler previewChangeEventHandler2;
			do
			{
				previewChangeEventHandler2 = previewChangeEventHandler;
				MySlider.PreviewChangeEventHandler value = (MySlider.PreviewChangeEventHandler)Delegate.Combine(previewChangeEventHandler2, obj);
				previewChangeEventHandler = Interlocked.CompareExchange<MySlider.PreviewChangeEventHandler>(ref this.processDecorator, value, previewChangeEventHandler2);
			}
			while (previewChangeEventHandler != previewChangeEventHandler2);
		}

		// Token: 0x06001096 RID: 4246 RVA: 0x000785C4 File Offset: 0x000767C4
		[CompilerGenerated]
		public void RegisterIterator(MySlider.PreviewChangeEventHandler obj)
		{
			MySlider.PreviewChangeEventHandler previewChangeEventHandler = this.processDecorator;
			MySlider.PreviewChangeEventHandler previewChangeEventHandler2;
			do
			{
				previewChangeEventHandler2 = previewChangeEventHandler;
				MySlider.PreviewChangeEventHandler value = (MySlider.PreviewChangeEventHandler)Delegate.Remove(previewChangeEventHandler2, obj);
				previewChangeEventHandler = Interlocked.CompareExchange<MySlider.PreviewChangeEventHandler>(ref this.processDecorator, value, previewChangeEventHandler2);
			}
			while (previewChangeEventHandler != previewChangeEventHandler2);
		}

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06001097 RID: 4247 RVA: 0x0000AAAF File Offset: 0x00008CAF
		// (set) Token: 0x06001098 RID: 4248 RVA: 0x0000AAB7 File Offset: 0x00008CB7
		public int MaxValue
		{
			get
			{
				return this.m_ListenerDecorator;
			}
			set
			{
				if (value != this.m_ListenerDecorator)
				{
					this.m_ListenerDecorator = value;
					this.RefreshWidth(null, null);
				}
			}
		}

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06001099 RID: 4249 RVA: 0x0000AAD1 File Offset: 0x00008CD1
		// (set) Token: 0x0600109A RID: 4250 RVA: 0x000785FC File Offset: 0x000767FC
		public int Value
		{
			get
			{
				return this._TemplateDecorator;
			}
			set
			{
				try
				{
					value = checked((int)Math.Round(ModBase.MathRange((double)value, 0.0, (double)this.MaxValue)));
					if (this._TemplateDecorator != value)
					{
						int templateDecorator = this._TemplateDecorator;
						this._TemplateDecorator = value;
						if (ModAni.InsertFactory() == 0)
						{
							ModBase.RouteEventArgs routeEventArgs = new ModBase.RouteEventArgs(false);
							MySlider.PreviewChangeEventHandler previewChangeEventHandler = this.processDecorator;
							if (previewChangeEventHandler != null)
							{
								previewChangeEventHandler(this, routeEventArgs);
							}
							if (routeEventArgs._HelperMapper)
							{
								this._TemplateDecorator = templateDecorator;
								this.DragStop();
								return;
							}
						}
						if (base.IsLoaded && ModAni.InsertFactory() == 0)
						{
							if (base.ActualWidth < 16.0)
							{
								return;
							}
							double num = (double)this._TemplateDecorator / (double)this.MaxValue * (base.ActualWidth - 16.0);
							double num2 = Math.Abs(this.LineFore.Width / (base.ActualWidth - 16.0) - (double)this._TemplateDecorator / (double)this.MaxValue);
							double num3 = (1.0 - Math.Pow(1.0 - num2, 3.0)) * 300.0 + (double)(this.importerDecorator ? 0x64 : 0);
							ModAni.AniStart(new ModAni.AniData[]
							{
								ModAni.AaWidth(this.LineFore, Math.Max(0.0, num + ((num < 0.5) ? 0.0 : 0.5)) - this.LineFore.Width, checked((int)Math.Round(num3)), 0, (ModAni.AniEase)((num3 > 50.0) ? new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle) : new ModAni.AniEaseLinear()), false),
								ModAni.AaWidth(this.LineBack, Math.Max(0.0, base.ActualWidth - 16.0 - num + ((base.ActualWidth - 16.0 - num < 0.5) ? 0.0 : 0.5)) - this.LineBack.Width, checked((int)Math.Round(num3)), 0, (ModAni.AniEase)((num3 > 50.0) ? new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle) : new ModAni.AniEaseLinear()), false),
								ModAni.AaX(this.ShapeDot, num - this.ShapeDot.Margin.Left, checked((int)Math.Round(num3)), 0, (ModAni.AniEase)((num3 > 50.0) ? new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle) : new ModAni.AniEaseLinear()), false)
							}, "MySlider Progress " + Conversions.ToString(this._TaskDecorator), false);
						}
						else
						{
							this.RefreshWidth(null, null);
						}
						if (ModAni.InsertFactory() == 0)
						{
							MySlider.ChangeEventHandler authenticationDecorator = this.m_AuthenticationDecorator;
							if (authenticationDecorator != null)
							{
								authenticationDecorator(this, false);
							}
						}
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "滑动条进度改变出错", ModBase.LogLevel.Hint, "出现错误");
				}
			}
		}

		// Token: 0x0600109B RID: 4251 RVA: 0x00078924 File Offset: 0x00076B24
		private void RefreshWidth(object sender, SizeChangedEventArgs e)
		{
			if (!Information.IsNothing(e))
			{
				this.PanMain.Width = e.NewSize.Width;
			}
			ModAni.AniStop("MySlider Progress " + Conversions.ToString(this._TaskDecorator));
			double num = (double)this._TemplateDecorator / (double)this.MaxValue * (base.ActualWidth - 16.0);
			this.LineFore.Width = Math.Max(0.0, num + ((num < 0.5) ? 0.0 : 0.5));
			this.LineBack.Width = Math.Max(0.0, base.ActualWidth - 16.0 - num + ((base.ActualWidth - 16.0 - num < 0.5) ? 0.0 : 0.5));
			ModBase.SetLeft(this.ShapeDot, num);
		}

		// Token: 0x0600109C RID: 4252 RVA: 0x00078A34 File Offset: 0x00076C34
		private void DragStart(object sender, MouseButtonEventArgs e)
		{
			e.Handled = true;
			ModMain.m_ValRule = this;
			ModMain.m_GetterFilter.DragDoing();
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaScaleTransform(this.ShapeDot, 0.8 - ((ScaleTransform)this.ShapeDot.RenderTransform).ScaleX, 0x4B, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false)
			}, "MySlider Scale " + Conversions.ToString(this._TaskDecorator), false);
			if (this._AdapterDecorator != null)
			{
				this.TextHint.Text = Conversions.ToString(this._AdapterDecorator.DynamicInvoke(new object[]
				{
					this.Value
				}));
				this.Popup.IsOpen = true;
				ModAni.AniStop("MySlider KeyPopup " + Conversions.ToString(this._TaskDecorator));
			}
		}

		// Token: 0x0600109D RID: 4253 RVA: 0x00078B14 File Offset: 0x00076D14
		public void DragDoing()
		{
			int num = checked((int)Math.Round(unchecked(ModBase.MathRange((Mouse.GetPosition(this.PanMain).X - 8.0) / (base.ActualWidth - 16.0), 0.0, 1.0) * (double)this.MaxValue)));
			if (num != this.Value)
			{
				this.Value = num;
			}
			if (this._AdapterDecorator != null)
			{
				this.TextHint.Text = Conversions.ToString(this._AdapterDecorator.DynamicInvoke(new object[]
				{
					num
				}));
			}
		}

		// Token: 0x0600109E RID: 4254 RVA: 0x00078BB8 File Offset: 0x00076DB8
		public void DragStop()
		{
			this.RefreshColor();
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaScaleTransform(this.ShapeDot, 1.0 - ((ScaleTransform)this.ShapeDot.RenderTransform).ScaleX, 0xC8, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false)
			}, "MySlider Scale " + Conversions.ToString(this._TaskDecorator), false);
			if (this._AdapterDecorator != null)
			{
				this.Popup.IsOpen = false;
			}
		}

		// Token: 0x0600109F RID: 4255 RVA: 0x00078C40 File Offset: 0x00076E40
		private void RefreshColor()
		{
			try
			{
				string text;
				int time;
				if (base.IsEnabled)
				{
					if (!base.IsMouseOver && (Information.IsNothing(RuntimeHelpers.GetObjectValue(ModMain.m_ValRule)) || !ModMain.m_ValRule.Equals(this)))
					{
						text = "ColorBrush1";
						time = 0xC8;
					}
					else
					{
						text = "ColorBrush3";
						time = 0x64;
					}
				}
				else
				{
					text = "ColorBrushGray4";
					time = 0xC8;
				}
				if (base.IsLoaded && ModAni.InsertFactory() == 0)
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaColor(this, Border.BorderBrushProperty, text, time, 0, null, false)
					}, "MySlider Color " + Conversions.ToString(this._TaskDecorator), false);
				}
				else
				{
					ModAni.AniStop("MySlider Color " + Conversions.ToString(this._TaskDecorator));
					base.SetResourceReference(Border.BorderBrushProperty, text);
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "滑动条颜色改变出错", ModBase.LogLevel.Debug, "出现错误");
			}
		}

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x060010A0 RID: 4256 RVA: 0x0000AAD9 File Offset: 0x00008CD9
		// (set) Token: 0x060010A1 RID: 4257 RVA: 0x0000AAE1 File Offset: 0x00008CE1
		public uint ValueByKey { get; set; }

		// Token: 0x060010A2 RID: 4258 RVA: 0x0000AAEA File Offset: 0x00008CEA
		private void MySlider_MouseEnter()
		{
			base.Focus();
		}

		// Token: 0x060010A3 RID: 4259 RVA: 0x00078D40 File Offset: 0x00076F40
		private void MySlider_KeyDown(object sender, KeyEventArgs e)
		{
			checked
			{
				if (!object.ReferenceEquals(this, RuntimeHelpers.GetObjectValue(ModMain.m_ValRule)))
				{
					if (e.Key == Key.Left)
					{
						this.importerDecorator = true;
						this.Value = (int)(unchecked((long)this.Value) - (long)(unchecked((ulong)this.ValueByKey)));
						this.importerDecorator = false;
						e.Handled = true;
					}
					else
					{
						if (e.Key != Key.Right)
						{
							return;
						}
						this.importerDecorator = true;
						this.Value = (int)(unchecked((long)this.Value) + (long)(unchecked((ulong)this.ValueByKey)));
						this.importerDecorator = false;
						e.Handled = true;
					}
					if (this._AdapterDecorator != null)
					{
						this.TextHint.Text = Conversions.ToString(this._AdapterDecorator.DynamicInvoke(new object[]
						{
							this.Value
						}));
						this.Popup.IsOpen = true;
						ModAni.AniStop("MySlider KeyPopup " + Conversions.ToString(this._TaskDecorator));
						ModAni.AniStart(ModAni.AaCode(delegate
						{
							this.Popup.IsOpen = false;
						}, (int)Math.Round(unchecked(700.0 * ModAni._Parameter)), false), "MySlider KeyPopup " + Conversions.ToString(this._TaskDecorator), false);
					}
				}
			}
		}

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x060010A4 RID: 4260 RVA: 0x0000AAF3 File Offset: 0x00008CF3
		// (set) Token: 0x060010A5 RID: 4261 RVA: 0x0000AAFB File Offset: 0x00008CFB
		internal virtual MySlider PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x060010A6 RID: 4262 RVA: 0x0000AB04 File Offset: 0x00008D04
		// (set) Token: 0x060010A7 RID: 4263 RVA: 0x0000AB0C File Offset: 0x00008D0C
		internal virtual Grid PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x060010A8 RID: 4264 RVA: 0x0000AB15 File Offset: 0x00008D15
		// (set) Token: 0x060010A9 RID: 4265 RVA: 0x0000AB1D File Offset: 0x00008D1D
		internal virtual Line LineBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x060010AA RID: 4266 RVA: 0x0000AB26 File Offset: 0x00008D26
		// (set) Token: 0x060010AB RID: 4267 RVA: 0x0000AB2E File Offset: 0x00008D2E
		internal virtual Line LineFore { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x060010AC RID: 4268 RVA: 0x0000AB37 File Offset: 0x00008D37
		// (set) Token: 0x060010AD RID: 4269 RVA: 0x0000AB3F File Offset: 0x00008D3F
		internal virtual Ellipse ShapeDot { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x060010AE RID: 4270 RVA: 0x0000AB48 File Offset: 0x00008D48
		// (set) Token: 0x060010AF RID: 4271 RVA: 0x0000AB50 File Offset: 0x00008D50
		internal virtual Popup Popup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x060010B0 RID: 4272 RVA: 0x0000AB59 File Offset: 0x00008D59
		// (set) Token: 0x060010B1 RID: 4273 RVA: 0x0000AB61 File Offset: 0x00008D61
		internal virtual TextBlock TextHint { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x060010B2 RID: 4274 RVA: 0x00078E74 File Offset: 0x00077074
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.m_SchemaDecorator)
			{
				this.m_SchemaDecorator = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/controls/myslider.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x060010B3 RID: 4275 RVA: 0x00078EA4 File Offset: 0x000770A4
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (MySlider)target;
				return;
			}
			if (connectionId == 2)
			{
				this.PanMain = (Grid)target;
				return;
			}
			if (connectionId == 3)
			{
				this.LineBack = (Line)target;
				return;
			}
			if (connectionId == 4)
			{
				this.LineFore = (Line)target;
				return;
			}
			if (connectionId == 5)
			{
				this.ShapeDot = (Ellipse)target;
				return;
			}
			if (connectionId == 6)
			{
				this.Popup = (Popup)target;
				return;
			}
			if (connectionId == 7)
			{
				this.TextHint = (TextBlock)target;
				return;
			}
			this.m_SchemaDecorator = true;
		}

		// Token: 0x040008A6 RID: 2214
		public int _TaskDecorator;

		// Token: 0x040008A7 RID: 2215
		[CompilerGenerated]
		private MySlider.ChangeEventHandler m_AuthenticationDecorator;

		// Token: 0x040008A8 RID: 2216
		[CompilerGenerated]
		private MySlider.PreviewChangeEventHandler processDecorator;

		// Token: 0x040008A9 RID: 2217
		private int m_ListenerDecorator;

		// Token: 0x040008AA RID: 2218
		private bool importerDecorator;

		// Token: 0x040008AB RID: 2219
		private int _TemplateDecorator;

		// Token: 0x040008AC RID: 2220
		public Delegate _AdapterDecorator;

		// Token: 0x040008AD RID: 2221
		[CompilerGenerated]
		private uint m_AnnotationDecorator;

		// Token: 0x040008AE RID: 2222
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private MySlider readerDecorator;

		// Token: 0x040008AF RID: 2223
		[AccessedThroughProperty("PanMain")]
		[CompilerGenerated]
		private Grid m_RegDecorator;

		// Token: 0x040008B0 RID: 2224
		[AccessedThroughProperty("LineBack")]
		[CompilerGenerated]
		private Line m_DefinitionDecorator;

		// Token: 0x040008B1 RID: 2225
		[CompilerGenerated]
		[AccessedThroughProperty("LineFore")]
		private Line _ParamDecorator;

		// Token: 0x040008B2 RID: 2226
		[AccessedThroughProperty("ShapeDot")]
		[CompilerGenerated]
		private Ellipse m_MockDecorator;

		// Token: 0x040008B3 RID: 2227
		[AccessedThroughProperty("Popup")]
		[CompilerGenerated]
		private Popup m_SpecificationDecorator;

		// Token: 0x040008B4 RID: 2228
		[AccessedThroughProperty("TextHint")]
		[CompilerGenerated]
		private TextBlock m_DicDecorator;

		// Token: 0x040008B5 RID: 2229
		private bool m_SchemaDecorator;

		// Token: 0x0200017E RID: 382
		// (Invoke) Token: 0x060010BC RID: 4284
		public delegate void ChangeEventHandler(object sender, bool user);

		// Token: 0x0200017F RID: 383
		// (Invoke) Token: 0x060010C0 RID: 4288
		public delegate void PreviewChangeEventHandler(object sender, ModBase.RouteEventArgs e);
	}
}
