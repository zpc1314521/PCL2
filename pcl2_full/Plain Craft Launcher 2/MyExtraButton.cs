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
using System.Windows.Shapes;

namespace PCL
{
	// Token: 0x02000038 RID: 56
	[DesignerGenerated]
	public class MyExtraButton : Grid, IComponentConnector
	{
		// Token: 0x060000FC RID: 252 RVA: 0x00012344 File Offset: 0x00010544
		public MyExtraButton()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.RefreshColor();
			};
			this.parser = ModBase.GetUuid();
			this.m_Proxy = "";
			this.setter = 1.0;
			this.merchant = false;
			this._Event = null;
			this._Comparator = false;
			this.m_Attribute = false;
			this.role = false;
			this.InitializeComponent();
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000123B8 File Offset: 0x000105B8
		[CompilerGenerated]
		public void CloneFactory(MyExtraButton.ClickEventHandler obj)
		{
			MyExtraButton.ClickEventHandler clickEventHandler = this.request;
			MyExtraButton.ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				MyExtraButton.ClickEventHandler value = (MyExtraButton.ClickEventHandler)Delegate.Combine(clickEventHandler2, obj);
				clickEventHandler = Interlocked.CompareExchange<MyExtraButton.ClickEventHandler>(ref this.request, value, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x000123F0 File Offset: 0x000105F0
		[CompilerGenerated]
		public void ForgotFactory(MyExtraButton.ClickEventHandler obj)
		{
			MyExtraButton.ClickEventHandler clickEventHandler = this.request;
			MyExtraButton.ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				MyExtraButton.ClickEventHandler value = (MyExtraButton.ClickEventHandler)Delegate.Remove(clickEventHandler2, obj);
				clickEventHandler = Interlocked.CompareExchange<MyExtraButton.ClickEventHandler>(ref this.request, value, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00012428 File Offset: 0x00010628
		[CompilerGenerated]
		public void ManageFactory(MyExtraButton.RightClickEventHandler obj)
		{
			MyExtraButton.RightClickEventHandler rightClickEventHandler = this._Pool;
			MyExtraButton.RightClickEventHandler rightClickEventHandler2;
			do
			{
				rightClickEventHandler2 = rightClickEventHandler;
				MyExtraButton.RightClickEventHandler value = (MyExtraButton.RightClickEventHandler)Delegate.Combine(rightClickEventHandler2, obj);
				rightClickEventHandler = Interlocked.CompareExchange<MyExtraButton.RightClickEventHandler>(ref this._Pool, value, rightClickEventHandler2);
			}
			while (rightClickEventHandler != rightClickEventHandler2);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00012460 File Offset: 0x00010660
		[CompilerGenerated]
		public void EnableFactory(MyExtraButton.RightClickEventHandler obj)
		{
			MyExtraButton.RightClickEventHandler rightClickEventHandler = this._Pool;
			MyExtraButton.RightClickEventHandler rightClickEventHandler2;
			do
			{
				rightClickEventHandler2 = rightClickEventHandler;
				MyExtraButton.RightClickEventHandler value = (MyExtraButton.RightClickEventHandler)Delegate.Remove(rightClickEventHandler2, obj);
				rightClickEventHandler = Interlocked.CompareExchange<MyExtraButton.RightClickEventHandler>(ref this._Pool, value, rightClickEventHandler2);
			}
			while (rightClickEventHandler != rightClickEventHandler2);
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00002DA3 File Offset: 0x00000FA3
		// (set) Token: 0x06000102 RID: 258 RVA: 0x00002DAB File Offset: 0x00000FAB
		public string Logo
		{
			get
			{
				return this.m_Proxy;
			}
			set
			{
				if (Operators.CompareString(value, this.m_Proxy, true) != 0)
				{
					this.m_Proxy = value;
					this.Path.Data = (Geometry)new GeometryConverter().ConvertFromString(value);
				}
			}
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00002DDE File Offset: 0x00000FDE
		public double SortFactory()
		{
			return this.setter;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00002DE6 File Offset: 0x00000FE6
		public void AwakeFactory(double value)
		{
			this.setter = value;
			if (!Information.IsNothing(this.Path))
			{
				this.Path.RenderTransform = new ScaleTransform
				{
					ScaleX = this.SortFactory(),
					ScaleY = this.SortFactory()
				};
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00002E24 File Offset: 0x00001024
		// (set) Token: 0x06000106 RID: 262 RVA: 0x00012498 File Offset: 0x00010698
		public bool Show
		{
			get
			{
				return this.merchant;
			}
			set
			{
				if (this.merchant != value)
				{
					this.merchant = value;
					ModBase.RunInUi(delegate()
					{
						if (value)
						{
							this.Visibility = Visibility.Visible;
							ModAni.AniStart(new ModAni.AniData[]
							{
								ModAni.AaScaleTransform(this, 0.3 - ((ScaleTransform)this.RenderTransform).ScaleX, 0x1F4, 0x3C, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false),
								ModAni.AaScaleTransform(this, 0.7, 0x1F4, 0x3C, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Weak), false),
								ModAni.AaHeight(this, 50.0 - this.Height, 0xC8, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false)
							}, "MyExtraButton MainScale " + Conversions.ToString(this.parser), false);
						}
						else
						{
							ModAni.AniStart(new ModAni.AniData[]
							{
								ModAni.AaScaleTransform(this, -((ScaleTransform)this.RenderTransform).ScaleX, 0x64, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Weak), false),
								ModAni.AaHeight(this, -this.Height, 0x190, 0x64, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
								ModAni.AaCode(delegate
								{
									base.Visibility = Visibility.Collapsed;
								}, 0, true)
							}, "MyExtraButton MainScale " + Conversions.ToString(this.parser), false);
						}
						this.IsHitTestVisible = value;
					}, false);
				}
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00002E2C File Offset: 0x0000102C
		public void ShowRefresh()
		{
			if (this._Event != null)
			{
				this.Show = this._Event();
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000124E8 File Offset: 0x000106E8
		private void Button_LeftMouseUp(object sender, MouseButtonEventArgs e)
		{
			if (this.m_Attribute)
			{
				ModBase.Log("[Control] 按下附加按钮" + (Operators.ConditionalCompareObjectEqual(base.ToolTip, "", true) ? "" : ("：" + base.ToolTip.ToString())), ModBase.LogLevel.Normal, "出现错误");
				MyExtraButton.ClickEventHandler clickEventHandler = this.request;
				if (clickEventHandler != null)
				{
					clickEventHandler(RuntimeHelpers.GetObjectValue(sender), e);
				}
				e.Handled = true;
				this.Button_LeftMouseUp();
			}
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00012568 File Offset: 0x00010768
		private void Button_RightMouseUp(object sender, MouseButtonEventArgs e)
		{
			if (this.role)
			{
				ModBase.Log("[Control] 右键按下附加按钮" + (Operators.ConditionalCompareObjectEqual(base.ToolTip, "", true) ? "" : ("：" + base.ToolTip.ToString())), ModBase.LogLevel.Normal, "出现错误");
				MyExtraButton.RightClickEventHandler pool = this._Pool;
				if (pool != null)
				{
					pool(RuntimeHelpers.GetObjectValue(sender), e);
				}
				e.Handled = true;
				this.Button_RightMouseUp();
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600010A RID: 266 RVA: 0x00002E47 File Offset: 0x00001047
		// (set) Token: 0x0600010B RID: 267 RVA: 0x00002E4F File Offset: 0x0000104F
		public bool CanRightClick
		{
			get
			{
				return this._Comparator;
			}
			set
			{
				this._Comparator = value;
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000125E8 File Offset: 0x000107E8
		private void Button_LeftMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (!this.m_Attribute && !this.role)
			{
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaScaleTransform(this.PanScale, 0.85 - ((ScaleTransform)this.PanScale.RenderTransform).ScaleX, 0x320, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false),
					ModAni.AaScaleTransform(this.PanScale, -0.05, 0x3C, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false)
				}, "MyExtraButton Scale " + Conversions.ToString(this.parser), false);
			}
			this.m_Attribute = true;
			base.Focus();
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000126A0 File Offset: 0x000108A0
		private void Button_RightMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (this.CanRightClick)
			{
				if (!this.m_Attribute && !this.role)
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaScaleTransform(this.PanScale, 0.85 - ((ScaleTransform)this.PanScale.RenderTransform).ScaleX, 0x320, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false),
						ModAni.AaScaleTransform(this.PanScale, -0.05, 0x3C, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false)
					}, "MyExtraButton Scale " + Conversions.ToString(this.parser), false);
				}
				this.role = true;
				base.Focus();
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00012760 File Offset: 0x00010960
		private void Button_LeftMouseUp()
		{
			if (!this.role)
			{
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaScaleTransform(this.PanScale, 1.0 - ((ScaleTransform)this.PanScale.RenderTransform).ScaleX, 0x12C, 0, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Middle), false)
				}, "MyExtraButton Scale " + Conversions.ToString(this.parser), false);
			}
			this.m_Attribute = false;
			this.RefreshColor();
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000127E4 File Offset: 0x000109E4
		private void Button_RightMouseUp()
		{
			if (this.CanRightClick)
			{
				if (!this.m_Attribute)
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaScaleTransform(this.PanScale, 1.0 - ((ScaleTransform)this.PanScale.RenderTransform).ScaleX, 0x12C, 0, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Middle), false)
					}, "MyExtraButton Scale " + Conversions.ToString(this.parser), false);
				}
				this.role = false;
				this.RefreshColor();
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00012870 File Offset: 0x00010A70
		private void Button_MouseLeave()
		{
			this.m_Attribute = false;
			this.role = false;
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaScaleTransform(this.PanScale, 1.0 - ((ScaleTransform)this.PanScale.RenderTransform).ScaleX, 0x1F4, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false)
			}, "MyExtraButton Scale " + Conversions.ToString(this.parser), false);
			this.RefreshColor();
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000128F0 File Offset: 0x00010AF0
		public void RefreshColor()
		{
			try
			{
				if (base.IsLoaded && ModAni.InsertFactory() == 0)
				{
					if (base.IsMouseOver)
					{
						ModAni.AniStart(ModAni.AaColor(this.PanColor, Panel.BackgroundProperty, "ColorBrush4", 0x78, 0, null, false), "MyExtraButton Color " + Conversions.ToString(this.parser), false);
					}
					else
					{
						ModAni.AniStart(ModAni.AaColor(this.PanColor, Panel.BackgroundProperty, "ColorBrush3", 0x96, 0, null, false), "MyExtraButton Color " + Conversions.ToString(this.parser), false);
					}
				}
				else
				{
					ModAni.AniStop("MyExtraButton Color " + Conversions.ToString(this.parser));
					if (base.IsMouseOver)
					{
						this.PanColor.SetResourceReference(Panel.BackgroundProperty, "ColorBrush2");
					}
					else
					{
						this.PanColor.SetResourceReference(Panel.BackgroundProperty, "ColorBrush3");
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "刷新图标按钮颜色出错", ModBase.LogLevel.Debug, "出现错误");
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00002E58 File Offset: 0x00001058
		public void Ribble()
		{
			ModBase.RunInUi(delegate()
			{
				Border Shape = new Border
				{
					CornerRadius = new CornerRadius(1000.0),
					BorderThickness = new Thickness(0.001),
					Opacity = 0.5,
					RenderTransformOrigin = new Point(0.5, 0.5),
					RenderTransform = new ScaleTransform()
				};
				Shape.SetResourceReference(Border.BackgroundProperty, "ColorBrush5");
				this.PanScale.Children.Insert(0, Shape);
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaScaleTransform(Shape, 13.0, 0x3E8, 0, new ModAni.AniEaseInoutFluent(ModAni.AniEasePower.Strong, 0.3), false),
					ModAni.AaOpacity(Shape, -Shape.Opacity, 0x3E8, 0, null, false),
					ModAni.AaCode(delegate
					{
						this.PanScale.Children.Remove(Shape);
					}, 0, true)
				}, "ExtraButton Ribble " + Conversions.ToString(ModBase.GetUuid()), false);
			}, false);
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00002E6C File Offset: 0x0000106C
		// (set) Token: 0x06000114 RID: 276 RVA: 0x00002E74 File Offset: 0x00001074
		internal virtual MyExtraButton PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00002E7D File Offset: 0x0000107D
		// (set) Token: 0x06000116 RID: 278 RVA: 0x00012A0C File Offset: 0x00010C0C
		internal virtual Border PanClick
		{
			[CompilerGenerated]
			get
			{
				return this.m_Wrapper;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseButtonEventHandler value2 = new MouseButtonEventHandler(this.Button_LeftMouseUp);
				MouseButtonEventHandler value3 = new MouseButtonEventHandler(this.Button_RightMouseUp);
				MouseButtonEventHandler value4 = new MouseButtonEventHandler(this.Button_LeftMouseDown);
				MouseButtonEventHandler value5 = new MouseButtonEventHandler(this.Button_RightMouseDown);
				MouseButtonEventHandler value6 = delegate(object sender, MouseButtonEventArgs e)
				{
					this.Button_LeftMouseUp();
				};
				MouseButtonEventHandler value7 = delegate(object sender, MouseButtonEventArgs e)
				{
					this.Button_RightMouseUp();
				};
				MouseEventHandler value8 = delegate(object sender, MouseEventArgs e)
				{
					this.Button_MouseLeave();
				};
				MouseEventHandler value9 = delegate(object sender, MouseEventArgs e)
				{
					this.RefreshColor();
				};
				MouseEventHandler value10 = delegate(object sender, MouseEventArgs e)
				{
					this.RefreshColor();
				};
				Border wrapper = this.m_Wrapper;
				if (wrapper != null)
				{
					wrapper.MouseLeftButtonUp -= value2;
					wrapper.MouseRightButtonUp -= value3;
					wrapper.MouseLeftButtonDown -= value4;
					wrapper.MouseRightButtonDown -= value5;
					wrapper.MouseLeftButtonUp -= value6;
					wrapper.MouseRightButtonUp -= value7;
					wrapper.MouseLeave -= value8;
					wrapper.MouseEnter -= value9;
					wrapper.MouseLeave -= value10;
				}
				this.m_Wrapper = value;
				wrapper = this.m_Wrapper;
				if (wrapper != null)
				{
					wrapper.MouseLeftButtonUp += value2;
					wrapper.MouseRightButtonUp += value3;
					wrapper.MouseLeftButtonDown += value4;
					wrapper.MouseRightButtonDown += value5;
					wrapper.MouseLeftButtonUp += value6;
					wrapper.MouseRightButtonUp += value7;
					wrapper.MouseLeave += value8;
					wrapper.MouseEnter += value9;
					wrapper.MouseLeave += value10;
				}
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00002E85 File Offset: 0x00001085
		// (set) Token: 0x06000118 RID: 280 RVA: 0x00002E8D File Offset: 0x0000108D
		internal virtual Grid PanScale { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000119 RID: 281 RVA: 0x00002E96 File Offset: 0x00001096
		// (set) Token: 0x0600011A RID: 282 RVA: 0x00002E9E File Offset: 0x0000109E
		internal virtual Border PanColor { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00002EA7 File Offset: 0x000010A7
		// (set) Token: 0x0600011C RID: 284 RVA: 0x00002EAF File Offset: 0x000010AF
		internal virtual Path Path { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x0600011D RID: 285 RVA: 0x00012B4C File Offset: 0x00010D4C
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.m_Getter)
			{
				this.m_Getter = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/controls/myextrabutton.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00012B7C File Offset: 0x00010D7C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (MyExtraButton)target;
				return;
			}
			if (connectionId == 2)
			{
				this.PanClick = (Border)target;
				return;
			}
			if (connectionId == 3)
			{
				this.PanScale = (Grid)target;
				return;
			}
			if (connectionId == 4)
			{
				this.PanColor = (Border)target;
				return;
			}
			if (connectionId == 5)
			{
				this.Path = (Path)target;
				return;
			}
			this.m_Getter = true;
		}

		// Token: 0x0400008B RID: 139
		[CompilerGenerated]
		private MyExtraButton.ClickEventHandler request;

		// Token: 0x0400008C RID: 140
		[CompilerGenerated]
		private MyExtraButton.RightClickEventHandler _Pool;

		// Token: 0x0400008D RID: 141
		public int parser;

		// Token: 0x0400008E RID: 142
		private string m_Proxy;

		// Token: 0x0400008F RID: 143
		private double setter;

		// Token: 0x04000090 RID: 144
		private bool merchant;

		// Token: 0x04000091 RID: 145
		public MyExtraButton.ShowCheckDelegate _Event;

		// Token: 0x04000092 RID: 146
		private bool _Comparator;

		// Token: 0x04000093 RID: 147
		private bool m_Attribute;

		// Token: 0x04000094 RID: 148
		private bool role;

		// Token: 0x04000095 RID: 149
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private MyExtraButton strategy;

		// Token: 0x04000096 RID: 150
		[AccessedThroughProperty("PanClick")]
		[CompilerGenerated]
		private Border m_Wrapper;

		// Token: 0x04000097 RID: 151
		[AccessedThroughProperty("PanScale")]
		[CompilerGenerated]
		private Grid writer;

		// Token: 0x04000098 RID: 152
		[AccessedThroughProperty("PanColor")]
		[CompilerGenerated]
		private Border m_Exporter;

		// Token: 0x04000099 RID: 153
		[AccessedThroughProperty("Path")]
		[CompilerGenerated]
		private Path record;

		// Token: 0x0400009A RID: 154
		private bool m_Getter;

		// Token: 0x02000039 RID: 57
		// (Invoke) Token: 0x0600012A RID: 298
		public delegate void ClickEventHandler(object sender, MouseButtonEventArgs e);

		// Token: 0x0200003A RID: 58
		// (Invoke) Token: 0x0600012E RID: 302
		public delegate void RightClickEventHandler(object sender, MouseButtonEventArgs e);

		// Token: 0x0200003B RID: 59
		// (Invoke) Token: 0x06000132 RID: 306
		public delegate bool ShowCheckDelegate();
	}
}
