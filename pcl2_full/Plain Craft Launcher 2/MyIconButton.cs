using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
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
	// Token: 0x0200016E RID: 366
	[DesignerGenerated]
	public class MyIconButton : Border, IComponentConnector
	{
		// Token: 0x06000FFE RID: 4094 RVA: 0x0007561C File Offset: 0x0007381C
		public MyIconButton()
		{
			base.MouseLeftButtonUp += this.Button_MouseUp;
			base.MouseLeftButtonDown += this.Button_MouseDown;
			base.MouseLeftButtonUp += delegate(object sender, MouseButtonEventArgs e)
			{
				this.Button_MouseUp();
			};
			base.MouseLeave += delegate(object sender, MouseEventArgs e)
			{
				this.Button_MouseLeave();
			};
			base.MouseEnter += delegate(object sender, MouseEventArgs e)
			{
				this.RefreshAnim();
			};
			base.MouseLeave += delegate(object sender, MouseEventArgs e)
			{
				this.RefreshAnim();
			};
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.RefreshAnim();
			};
			this._AccountDecorator = ModBase.GetUuid();
			this.configurationDecorator = 1.0;
			this.Theme = MyIconButton.Themes.Color;
			this.predicateDecorator = new SolidColorBrush(Color.FromRgb(0x80, 0x80, 0x80));
			this.structDecorator = false;
			this.InitializeComponent();
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000FFF RID: 4095 RVA: 0x000756FC File Offset: 0x000738FC
		// (remove) Token: 0x06001000 RID: 4096 RVA: 0x00075734 File Offset: 0x00073934
		public event MyIconButton.ClickEventHandler Click
		{
			[CompilerGenerated]
			add
			{
				MyIconButton.ClickEventHandler clickEventHandler = this.m_StubDecorator;
				MyIconButton.ClickEventHandler clickEventHandler2;
				do
				{
					clickEventHandler2 = clickEventHandler;
					MyIconButton.ClickEventHandler value2 = (MyIconButton.ClickEventHandler)Delegate.Combine(clickEventHandler2, value);
					clickEventHandler = Interlocked.CompareExchange<MyIconButton.ClickEventHandler>(ref this.m_StubDecorator, value2, clickEventHandler2);
				}
				while (clickEventHandler != clickEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				MyIconButton.ClickEventHandler clickEventHandler = this.m_StubDecorator;
				MyIconButton.ClickEventHandler clickEventHandler2;
				do
				{
					clickEventHandler2 = clickEventHandler;
					MyIconButton.ClickEventHandler value2 = (MyIconButton.ClickEventHandler)Delegate.Remove(clickEventHandler2, value);
					clickEventHandler = Interlocked.CompareExchange<MyIconButton.ClickEventHandler>(ref this.m_StubDecorator, value2, clickEventHandler2);
				}
				while (clickEventHandler != clickEventHandler2);
			}
		}

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x06001001 RID: 4097 RVA: 0x0000A4F4 File Offset: 0x000086F4
		// (set) Token: 0x06001002 RID: 4098 RVA: 0x0000A506 File Offset: 0x00008706
		public string Logo
		{
			get
			{
				return this.Path.Data.ToString();
			}
			set
			{
				this.Path.Data = (Geometry)new GeometryConverter().ConvertFromString(value);
			}
		}

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06001003 RID: 4099 RVA: 0x0000A523 File Offset: 0x00008723
		// (set) Token: 0x06001004 RID: 4100 RVA: 0x0000A52B File Offset: 0x0000872B
		public double LogoScale
		{
			get
			{
				return this.configurationDecorator;
			}
			set
			{
				this.configurationDecorator = value;
				if (!Information.IsNothing(this.Path))
				{
					this.Path.RenderTransform = new ScaleTransform
					{
						ScaleX = this.LogoScale,
						ScaleY = this.LogoScale
					};
				}
			}
		}

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06001005 RID: 4101 RVA: 0x0000A569 File Offset: 0x00008769
		// (set) Token: 0x06001006 RID: 4102 RVA: 0x0000A571 File Offset: 0x00008771
		public MyIconButton.Themes Theme { get; set; }

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06001007 RID: 4103 RVA: 0x0000A57A File Offset: 0x0000877A
		// (set) Token: 0x06001008 RID: 4104 RVA: 0x0000A582 File Offset: 0x00008782
		public SolidColorBrush Foreground
		{
			get
			{
				return this.predicateDecorator;
			}
			set
			{
				this.predicateDecorator = value;
				checked
				{
					ModAni.ListFactory(ModAni.InsertFactory() + 1);
					this.RefreshAnim();
					ModAni.ListFactory(ModAni.InsertFactory() - 1);
				}
			}
		}

		// Token: 0x06001009 RID: 4105 RVA: 0x0007576C File Offset: 0x0007396C
		private void Button_MouseUp(object sender, MouseButtonEventArgs e)
		{
			if (this.structDecorator)
			{
				ModBase.Log("[Control] 按下图标按钮" + (string.IsNullOrEmpty(base.Name) ? "" : ("：" + base.Name)), ModBase.LogLevel.Normal, "出现错误");
				MyIconButton.ClickEventHandler stubDecorator = this.m_StubDecorator;
				if (stubDecorator != null)
				{
					stubDecorator(RuntimeHelpers.GetObjectValue(sender), e);
				}
				e.Handled = true;
				this.Button_MouseUp();
			}
		}

		// Token: 0x0600100A RID: 4106 RVA: 0x000757E0 File Offset: 0x000739E0
		private void Button_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.structDecorator = true;
			base.Focus();
			ModAni.AniStart(ModAni.AaScaleTransform(this.PanBack, 0.8 - ((ScaleTransform)this.PanBack.RenderTransform).ScaleX, 0x190, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false), "MyIconButton Scale " + Conversions.ToString(this._AccountDecorator), false);
		}

		// Token: 0x0600100B RID: 4107 RVA: 0x00075850 File Offset: 0x00073A50
		private void Button_MouseUp()
		{
			if (this.structDecorator)
			{
				this.structDecorator = false;
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaScaleTransform(this.PanBack, 1.05 - ((ScaleTransform)this.PanBack.RenderTransform).ScaleX, 0xFA, 0, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Weak), false),
					ModAni.AaScaleTransform(this.PanBack, -0.05, 0xFA, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false)
				}, "MyIconButton Scale " + Conversions.ToString(this._AccountDecorator), false);
			}
			this.RefreshAnim();
		}

		// Token: 0x0600100C RID: 4108 RVA: 0x000758FC File Offset: 0x00073AFC
		private void Button_MouseLeave()
		{
			this.structDecorator = false;
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaScaleTransform(this.PanBack, 1.0 - ((ScaleTransform)this.PanBack.RenderTransform).ScaleX, 0xFA, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false)
			}, "MyIconButton Scale " + Conversions.ToString(this._AccountDecorator), false);
			this.RefreshAnim();
		}

		// Token: 0x0600100D RID: 4109 RVA: 0x00075978 File Offset: 0x00073B78
		public void RefreshAnim()
		{
			try
			{
				if (base.IsLoaded && ModAni.InsertFactory() == 0)
				{
					if (this.PanBack.Background == null)
					{
						this.PanBack.Background = new ModBase.MyColor(0.0, 255.0, 255.0, 255.0);
					}
					if (this.Path.Fill == null && this.Theme == MyIconButton.Themes.Black)
					{
						this.Path.Fill = new ModBase.MyColor(140.0, 0.0, 0.0, 0.0);
					}
					if (base.IsMouseOver)
					{
						ArrayList arrayList = new ArrayList();
						switch (this.Theme)
						{
						case MyIconButton.Themes.Color:
							arrayList.Add(ModAni.AaColor(this.Path, Shape.FillProperty, "ColorBrush2", 0x78, 0, null, false));
							break;
						case MyIconButton.Themes.White:
							arrayList.Add(ModAni.AaColor(this.PanBack, Border.BackgroundProperty, new ModBase.MyColor(50.0, 255.0, 255.0, 255.0) - this.PanBack.Background, 0x78, 0, null, false));
							break;
						case MyIconButton.Themes.Black:
							arrayList.Add(ModAni.AaColor(this.Path, Shape.FillProperty, new ModBase.MyColor(230.0, 0.0, 0.0, 0.0) - this.Path.Fill, 0x78, 0, null, false));
							break;
						case MyIconButton.Themes.Custom:
							arrayList.Add(ModAni.AaColor(this.Path, Shape.FillProperty, new ModBase.MyColor(255.0, this.Foreground) - this.Path.Fill, 0x78, 0, null, false));
							break;
						}
						ModAni.AniStart(arrayList, "MyIconButton Color " + Conversions.ToString(this._AccountDecorator), false);
					}
					else
					{
						ArrayList arrayList2 = new ArrayList();
						switch (this.Theme)
						{
						case MyIconButton.Themes.Color:
							arrayList2.Add(ModAni.AaColor(this.Path, Shape.FillProperty, "ColorBrush4", 0x96, 0, null, false));
							this.PanBack.Background = new ModBase.MyColor(0.0, 255.0, 255.0, 255.0);
							break;
						case MyIconButton.Themes.White:
							arrayList2.Add(ModAni.AaColor(this.Path, Shape.FillProperty, "ColorBrush8", 0x96, 0, null, false));
							arrayList2.Add(ModAni.AaColor(this.PanBack, Border.BackgroundProperty, new ModBase.MyColor(0.0, 255.0, 255.0, 255.0) - this.PanBack.Background, 0x96, 0, null, false));
							break;
						case MyIconButton.Themes.Black:
							arrayList2.Add(ModAni.AaColor(this.Path, Shape.FillProperty, new ModBase.MyColor(160.0, 0.0, 0.0, 0.0) - this.Path.Fill, 0x96, 0, null, false));
							this.PanBack.Background = new ModBase.MyColor(0.0, 255.0, 255.0, 255.0);
							break;
						case MyIconButton.Themes.Custom:
							arrayList2.Add(ModAni.AaColor(this.Path, Shape.FillProperty, new ModBase.MyColor(160.0, this.Foreground) - this.Path.Fill, 0x96, 0, null, false));
							this.PanBack.Background = new ModBase.MyColor(0.0, 255.0, 255.0, 255.0);
							break;
						}
						ModAni.AniStart(arrayList2, "MyIconButton Color " + Conversions.ToString(this._AccountDecorator), false);
					}
				}
				else
				{
					ModAni.AniStop("MyIconButton Color " + Conversions.ToString(this._AccountDecorator));
					switch (this.Theme)
					{
					case MyIconButton.Themes.Color:
						this.Path.SetResourceReference(Shape.FillProperty, "ColorBrush5");
						break;
					case MyIconButton.Themes.White:
						this.Path.SetResourceReference(Shape.FillProperty, "ColorBrush8");
						break;
					case MyIconButton.Themes.Black:
						this.Path.Fill = new ModBase.MyColor(160.0, 0.0, 0.0, 0.0);
						break;
					case MyIconButton.Themes.Custom:
						this.Path.Fill = new ModBase.MyColor(160.0, this.Foreground);
						break;
					}
					this.PanBack.Background = new ModBase.MyColor(0.0, 255.0, 255.0, 255.0);
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "刷新图标按钮动画状态出错", ModBase.LogLevel.Debug, "出现错误");
			}
		}

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x0600100E RID: 4110 RVA: 0x0000A5A9 File Offset: 0x000087A9
		// (set) Token: 0x0600100F RID: 4111 RVA: 0x0000A5B1 File Offset: 0x000087B1
		internal virtual Border PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06001010 RID: 4112 RVA: 0x0000A5BA File Offset: 0x000087BA
		// (set) Token: 0x06001011 RID: 4113 RVA: 0x0000A5C2 File Offset: 0x000087C2
		internal virtual Path Path { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x06001012 RID: 4114 RVA: 0x00075F78 File Offset: 0x00074178
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.testsDecorator)
			{
				this.testsDecorator = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/controls/myiconbutton.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x0000A5CB File Offset: 0x000087CB
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (Border)target;
				return;
			}
			if (connectionId == 2)
			{
				this.Path = (Path)target;
				return;
			}
			this.testsDecorator = true;
		}

		// Token: 0x0400085B RID: 2139
		[CompilerGenerated]
		private MyIconButton.ClickEventHandler m_StubDecorator;

		// Token: 0x0400085C RID: 2140
		public int _AccountDecorator;

		// Token: 0x0400085D RID: 2141
		private double configurationDecorator;

		// Token: 0x0400085E RID: 2142
		[CompilerGenerated]
		private MyIconButton.Themes m_InterpreterDecorator;

		// Token: 0x0400085F RID: 2143
		private SolidColorBrush predicateDecorator;

		// Token: 0x04000860 RID: 2144
		private bool structDecorator;

		// Token: 0x04000861 RID: 2145
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private Border _ResolverDecorator;

		// Token: 0x04000862 RID: 2146
		[AccessedThroughProperty("Path")]
		[CompilerGenerated]
		private Path collectionDecorator;

		// Token: 0x04000863 RID: 2147
		private bool testsDecorator;

		// Token: 0x0200016F RID: 367
		// (Invoke) Token: 0x0600101C RID: 4124
		public delegate void ClickEventHandler(object sender, EventArgs e);

		// Token: 0x02000170 RID: 368
		public enum Themes
		{
			// Token: 0x04000865 RID: 2149
			Color,
			// Token: 0x04000866 RID: 2150
			White,
			// Token: 0x04000867 RID: 2151
			Black,
			// Token: 0x04000868 RID: 2152
			Custom
		}
	}
}
