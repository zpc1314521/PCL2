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
	// Token: 0x0200016A RID: 362
	[DesignerGenerated]
	public class MyCheckBox : Grid, IComponentConnector
	{
		// Token: 0x06000FCF RID: 4047 RVA: 0x0000A3D8 File Offset: 0x000085D8
		// Note: this type is marked as 'beforefieldinit'.
		static MyCheckBox()
		{
			MyCheckBox._SerializerDecorator = DependencyProperty.Register("Text", typeof(string), typeof(MyCheckBox), new PropertyMetadata(delegate(DependencyObject sender, DependencyPropertyChangedEventArgs e)
			{
				if (!Information.IsNothing(sender))
				{
					((MyCheckBox)sender).LabText.Text = Conversions.ToString(e.NewValue);
				}
			}));
		}

		// Token: 0x06000FD0 RID: 4048 RVA: 0x0007493C File Offset: 0x00072B3C
		public MyCheckBox()
		{
			base.MouseLeftButtonUp += delegate(object sender, MouseButtonEventArgs e)
			{
				this.Checkbox_MouseUp();
			};
			base.MouseLeftButtonDown += delegate(object sender, MouseButtonEventArgs e)
			{
				this.Checkbox_MouseDown();
			};
			base.MouseLeave += delegate(object sender, MouseEventArgs e)
			{
				this.Checkbox_MouseLeave();
			};
			base.IsEnabledChanged += delegate(object sender, DependencyPropertyChangedEventArgs e)
			{
				this.Checkbox_IsEnabledChanged();
			};
			base.MouseEnter += delegate(object sender, MouseEventArgs e)
			{
				this.Checkbox_MouseEnterAnimation();
			};
			base.MouseLeave += delegate(object sender, MouseEventArgs e)
			{
				this.Checkbox_MouseLeaveAnimation();
			};
			this.m_AttrDecorator = ModBase.GetUuid();
			this._ItemDecorator = false;
			this.m_InfoDecorator = false;
			this.m_RepositoryDecorator = true;
			this.InitializeComponent();
		}

		// Token: 0x06000FD1 RID: 4049 RVA: 0x000749E4 File Offset: 0x00072BE4
		[CompilerGenerated]
		public void RunIterator(MyCheckBox.ChangeEventHandler obj)
		{
			MyCheckBox.ChangeEventHandler changeEventHandler = this._ThreadDecorator;
			MyCheckBox.ChangeEventHandler changeEventHandler2;
			do
			{
				changeEventHandler2 = changeEventHandler;
				MyCheckBox.ChangeEventHandler value = (MyCheckBox.ChangeEventHandler)Delegate.Combine(changeEventHandler2, obj);
				changeEventHandler = Interlocked.CompareExchange<MyCheckBox.ChangeEventHandler>(ref this._ThreadDecorator, value, changeEventHandler2);
			}
			while (changeEventHandler != changeEventHandler2);
		}

		// Token: 0x06000FD2 RID: 4050 RVA: 0x00074A1C File Offset: 0x00072C1C
		[CompilerGenerated]
		public void SearchIterator(MyCheckBox.ChangeEventHandler obj)
		{
			MyCheckBox.ChangeEventHandler changeEventHandler = this._ThreadDecorator;
			MyCheckBox.ChangeEventHandler changeEventHandler2;
			do
			{
				changeEventHandler2 = changeEventHandler;
				MyCheckBox.ChangeEventHandler value = (MyCheckBox.ChangeEventHandler)Delegate.Remove(changeEventHandler2, obj);
				changeEventHandler = Interlocked.CompareExchange<MyCheckBox.ChangeEventHandler>(ref this._ThreadDecorator, value, changeEventHandler2);
			}
			while (changeEventHandler != changeEventHandler2);
		}

		// Token: 0x06000FD3 RID: 4051 RVA: 0x00074A54 File Offset: 0x00072C54
		[CompilerGenerated]
		public void CreateIterator(MyCheckBox.PreviewChangeEventHandler obj)
		{
			MyCheckBox.PreviewChangeEventHandler previewChangeEventHandler = this._ManagerDecorator;
			MyCheckBox.PreviewChangeEventHandler previewChangeEventHandler2;
			do
			{
				previewChangeEventHandler2 = previewChangeEventHandler;
				MyCheckBox.PreviewChangeEventHandler value = (MyCheckBox.PreviewChangeEventHandler)Delegate.Combine(previewChangeEventHandler2, obj);
				previewChangeEventHandler = Interlocked.CompareExchange<MyCheckBox.PreviewChangeEventHandler>(ref this._ManagerDecorator, value, previewChangeEventHandler2);
			}
			while (previewChangeEventHandler != previewChangeEventHandler2);
		}

		// Token: 0x06000FD4 RID: 4052 RVA: 0x00074A8C File Offset: 0x00072C8C
		[CompilerGenerated]
		public void FindIterator(MyCheckBox.PreviewChangeEventHandler obj)
		{
			MyCheckBox.PreviewChangeEventHandler previewChangeEventHandler = this._ManagerDecorator;
			MyCheckBox.PreviewChangeEventHandler previewChangeEventHandler2;
			do
			{
				previewChangeEventHandler2 = previewChangeEventHandler;
				MyCheckBox.PreviewChangeEventHandler value = (MyCheckBox.PreviewChangeEventHandler)Delegate.Remove(previewChangeEventHandler2, obj);
				previewChangeEventHandler = Interlocked.CompareExchange<MyCheckBox.PreviewChangeEventHandler>(ref this._ManagerDecorator, value, previewChangeEventHandler2);
			}
			while (previewChangeEventHandler != previewChangeEventHandler2);
		}

		// Token: 0x06000FD5 RID: 4053 RVA: 0x00074AC4 File Offset: 0x00072CC4
		public void RaiseChange()
		{
			MyCheckBox.ChangeEventHandler threadDecorator = this._ThreadDecorator;
			if (threadDecorator != null)
			{
				threadDecorator(this, false);
			}
		}

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x06000FD6 RID: 4054 RVA: 0x0000A412 File Offset: 0x00008612
		// (set) Token: 0x06000FD7 RID: 4055 RVA: 0x0000A41A File Offset: 0x0000861A
		public bool Checked
		{
			get
			{
				return this._ItemDecorator;
			}
			set
			{
				this.SetChecked(value, false, true);
			}
		}

		// Token: 0x06000FD8 RID: 4056 RVA: 0x00074AE4 File Offset: 0x00072CE4
		public void SetChecked(bool value, bool user, bool anime)
		{
			try
			{
				if (value != this._ItemDecorator)
				{
					if (value && user)
					{
						ModBase.RouteEventArgs routeEventArgs = new ModBase.RouteEventArgs(user);
						MyCheckBox.PreviewChangeEventHandler managerDecorator = this._ManagerDecorator;
						if (managerDecorator != null)
						{
							managerDecorator(this, routeEventArgs);
						}
						if (routeEventArgs._HelperMapper)
						{
							this.m_InfoDecorator = true;
							this.Checkbox_MouseLeave();
							this.m_InfoDecorator = false;
							return;
						}
					}
					this._ItemDecorator = value;
					if (base.IsLoaded)
					{
						MyCheckBox.ChangeEventHandler threadDecorator = this._ThreadDecorator;
						if (threadDecorator != null)
						{
							threadDecorator(this, user);
						}
					}
					if (base.IsLoaded && ModAni.InsertFactory() == 0 && anime)
					{
						this.m_RepositoryDecorator = false;
						if (this.Checked)
						{
							ModAni.AniStart(new ModAni.AniData[]
							{
								ModAni.AaScale(this.ShapeBorder, 12.0 - this.ShapeBorder.Width, 0x96, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false, true),
								ModAni.AaScaleTransform(this.ShapeCheck, 1.0 - ((ScaleTransform)this.ShapeCheck.RenderTransform).ScaleX, 0x12C, 0x69, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Weak), false),
								ModAni.AaScale(this.ShapeBorder, 6.0, 0x12C, 0x69, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Middle), false, true)
							}, "MyCheckBox Scale " + Conversions.ToString(this.m_AttrDecorator), false);
							ModAni.AniStart(new ModAni.AniData[]
							{
								ModAni.AaColor(this.ShapeBorder, Border.BorderBrushProperty, base.IsEnabled ? (base.IsMouseOver ? "ColorBrush3" : "ColorBrush2") : "ColorBrushGray4", 0x96, 0, null, false)
							}, "MyCheckBox BorderColor " + Conversions.ToString(this.m_AttrDecorator), false);
							ModAni.AniStart(new ModAni.AniData[]
							{
								ModAni.AaCode(delegate
								{
									this.m_RepositoryDecorator = true;
								}, 0x12C, false)
							}, "MyCheckBox AllowMouseDown " + Conversions.ToString(this.m_AttrDecorator), false);
						}
						else
						{
							ModAni.AniStart(new ModAni.AniData[]
							{
								ModAni.AaScale(this.ShapeBorder, 12.0 - this.ShapeBorder.Width, 0x96, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false, true),
								ModAni.AaScaleTransform(this.ShapeCheck, -((ScaleTransform)this.ShapeCheck.RenderTransform).ScaleX, 0x87, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Weak), false),
								ModAni.AaScale(this.ShapeBorder, 6.0, 0x12C, 0x69, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Middle), false, true)
							}, "MyCheckBox Scale " + Conversions.ToString(this.m_AttrDecorator), false);
							ModAni.AniStart(new ModAni.AniData[]
							{
								ModAni.AaColor(this.ShapeBorder, Border.BorderBrushProperty, base.IsEnabled ? (base.IsMouseOver ? "ColorBrush3" : "ColorBrush1") : "ColorBrushGray4", 0x96, 0, null, false)
							}, "MyCheckBox BorderColor " + Conversions.ToString(this.m_AttrDecorator), false);
							ModAni.AniStart(new ModAni.AniData[]
							{
								ModAni.AaCode(delegate
								{
									this.m_RepositoryDecorator = true;
								}, 0x12C, false)
							}, "MyCheckBox AllowMouseDown " + Conversions.ToString(this.m_AttrDecorator), false);
						}
					}
					else
					{
						ModAni.AniStop("MyCheckBox Scale " + Conversions.ToString(this.m_AttrDecorator));
						ModAni.AniStop("MyCheckBox BorderColor " + Conversions.ToString(this.m_AttrDecorator));
						ModAni.AniStop("MyCheckBox AllowMouseDown " + Conversions.ToString(this.m_AttrDecorator));
						if (this.Checked)
						{
							((ScaleTransform)this.ShapeCheck.RenderTransform).ScaleX = 1.0;
							((ScaleTransform)this.ShapeCheck.RenderTransform).ScaleY = 1.0;
							this.ShapeBorder.SetResourceReference(Border.BorderBrushProperty, base.IsEnabled ? "ColorBrush2" : "ColorBrushGray4");
						}
						else
						{
							((ScaleTransform)this.ShapeCheck.RenderTransform).ScaleX = 0.0;
							((ScaleTransform)this.ShapeCheck.RenderTransform).ScaleY = 0.0;
							this.ShapeBorder.SetResourceReference(Border.BorderBrushProperty, base.IsEnabled ? "ColorBrush1" : "ColorBrushGray4");
						}
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "设置 Checked 失败", ModBase.LogLevel.Debug, "出现错误");
			}
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x06000FD9 RID: 4057 RVA: 0x0000A425 File Offset: 0x00008625
		// (set) Token: 0x06000FDA RID: 4058 RVA: 0x0000A437 File Offset: 0x00008637
		public string Text
		{
			get
			{
				return Conversions.ToString(base.GetValue(MyCheckBox._SerializerDecorator));
			}
			set
			{
				base.SetValue(MyCheckBox._SerializerDecorator, value);
			}
		}

		// Token: 0x06000FDB RID: 4059 RVA: 0x00074FA4 File Offset: 0x000731A4
		private void Checkbox_MouseUp()
		{
			if (this.m_InfoDecorator)
			{
				ModBase.Log("[Control] 按下复选框（" + (!this.Checked).ToString() + "）：" + this.Text, ModBase.LogLevel.Normal, "出现错误");
				this.m_InfoDecorator = false;
				this.SetChecked(!this.Checked, true, true);
				ModAni.AniStart(ModAni.AaColor(this.ShapeBorder, Border.BackgroundProperty, "ColorBrushHalfWhite", 0x64, 0, null, false), "MyCheckBox Background " + Conversions.ToString(this.m_AttrDecorator), false);
			}
		}

		// Token: 0x06000FDC RID: 4060 RVA: 0x00075038 File Offset: 0x00073238
		private void Checkbox_MouseDown()
		{
			if (this.m_RepositoryDecorator)
			{
				this.m_InfoDecorator = true;
				base.Focus();
				ModAni.AniStart(ModAni.AaColor(this.ShapeBorder, Border.BackgroundProperty, "ColorBrush9", 0x64, 0, null, false), "MyCheckBox Background " + Conversions.ToString(this.m_AttrDecorator), false);
				if (this.Checked)
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaScale(this.ShapeBorder, 16.5 - this.ShapeBorder.Width, 0x3E8, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false, true),
						ModAni.AaScaleTransform(this.ShapeCheck, 0.9 - ((ScaleTransform)this.ShapeCheck.RenderTransform).ScaleX, 0x3E8, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false)
					}, "MyCheckBox Scale " + Conversions.ToString(this.m_AttrDecorator), false);
					return;
				}
				ModAni.AniStart(ModAni.AaScale(this.ShapeBorder, 16.5 - this.ShapeBorder.Width, 0x3E8, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false, true), "MyCheckBox Scale " + Conversions.ToString(this.m_AttrDecorator), false);
			}
		}

		// Token: 0x06000FDD RID: 4061 RVA: 0x0007517C File Offset: 0x0007337C
		private void Checkbox_MouseLeave()
		{
			if (this.m_InfoDecorator)
			{
				this.m_InfoDecorator = false;
				ModAni.AniStart(ModAni.AaColor(this.ShapeBorder, Border.BackgroundProperty, "ColorBrushHalfWhite", 0x64, 0, null, false), "MyCheckBox Background " + Conversions.ToString(this.m_AttrDecorator), false);
				if (this.Checked)
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaScale(this.ShapeBorder, 18.0 - this.ShapeBorder.Width, 0x190, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false, true),
						ModAni.AaScaleTransform(this.ShapeCheck, 1.0 - ((ScaleTransform)this.ShapeCheck.RenderTransform).ScaleX, 0x1F4, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false)
					}, "MyCheckBox Scale " + Conversions.ToString(this.m_AttrDecorator), false);
					return;
				}
				ModAni.AniStart(ModAni.AaScale(this.ShapeBorder, 18.0 - this.ShapeBorder.Width, 0x190, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false, true), "MyCheckBox Scale " + Conversions.ToString(this.m_AttrDecorator), false);
			}
		}

		// Token: 0x06000FDE RID: 4062 RVA: 0x000752BC File Offset: 0x000734BC
		private void Checkbox_IsEnabledChanged()
		{
			if (!base.IsLoaded || ModAni.InsertFactory() != 0)
			{
				ModAni.AniStop("MyCheckBox TextColor " + Conversions.ToString(this.m_AttrDecorator));
				ModAni.AniStop("MyCheckBox BorderColor " + Conversions.ToString(this.m_AttrDecorator));
				this.LabText.SetResourceReference(TextBlock.ForegroundProperty, base.IsEnabled ? "ColorBrush1" : "ColorBrushGray4");
				this.ShapeBorder.SetResourceReference(Border.BorderBrushProperty, base.IsEnabled ? (this.Checked ? "ColorBrush2" : "ColorBrush1") : "ColorBrushGray4");
				return;
			}
			if (base.IsEnabled)
			{
				this.Checkbox_MouseLeaveAnimation();
				return;
			}
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaColor(this.ShapeBorder, Border.BorderBrushProperty, ModMain._EventFilter - this.ShapeBorder.BorderBrush, 0xC8, 0, null, false)
			}, "MyCheckBox BorderColor " + Conversions.ToString(this.m_AttrDecorator), false);
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaColor(this.LabText, TextBlock.ForegroundProperty, ModMain._EventFilter - this.LabText.Foreground, 0xC8, 0, null, false)
			}, "MyCheckBox TextColor " + Conversions.ToString(this.m_AttrDecorator), false);
		}

		// Token: 0x06000FDF RID: 4063 RVA: 0x00075430 File Offset: 0x00073630
		private void Checkbox_MouseEnterAnimation()
		{
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaColor(this.LabText, TextBlock.ForegroundProperty, "ColorBrush3", 0x64, 0, null, false)
			}, "MyCheckBox TextColor " + Conversions.ToString(this.m_AttrDecorator), false);
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaColor(this.ShapeBorder, Border.BorderBrushProperty, "ColorBrush3", 0x64, 0, null, false)
			}, "MyCheckBox BorderColor " + Conversions.ToString(this.m_AttrDecorator), false);
		}

		// Token: 0x06000FE0 RID: 4064 RVA: 0x000754C4 File Offset: 0x000736C4
		private void Checkbox_MouseLeaveAnimation()
		{
			if (base.IsEnabled)
			{
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaColor(this.LabText, TextBlock.ForegroundProperty, base.IsEnabled ? "ColorBrush1" : "ColorBrushGray4", 0xC8, 0, null, false)
				}, "MyCheckBox TextColor " + Conversions.ToString(this.m_AttrDecorator), false);
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaColor(this.ShapeBorder, Border.BorderBrushProperty, base.IsEnabled ? (this.Checked ? "ColorBrush2" : "ColorBrush1") : "ColorBrushGray4", 0xC8, 0, null, false)
				}, "MyCheckBox BorderColor " + Conversions.ToString(this.m_AttrDecorator), false);
			}
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x06000FE1 RID: 4065 RVA: 0x0000A445 File Offset: 0x00008645
		// (set) Token: 0x06000FE2 RID: 4066 RVA: 0x0000A44D File Offset: 0x0000864D
		internal virtual MyCheckBox PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x06000FE3 RID: 4067 RVA: 0x0000A456 File Offset: 0x00008656
		// (set) Token: 0x06000FE4 RID: 4068 RVA: 0x0000A45E File Offset: 0x0000865E
		internal virtual TextBlock LabText { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x06000FE5 RID: 4069 RVA: 0x0000A467 File Offset: 0x00008667
		// (set) Token: 0x06000FE6 RID: 4070 RVA: 0x0000A46F File Offset: 0x0000866F
		internal virtual Border ShapeBorder { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06000FE7 RID: 4071 RVA: 0x0000A478 File Offset: 0x00008678
		// (set) Token: 0x06000FE8 RID: 4072 RVA: 0x0000A480 File Offset: 0x00008680
		internal virtual Path ShapeCheck { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x06000FE9 RID: 4073 RVA: 0x00075594 File Offset: 0x00073794
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.parameterDecorator)
			{
				this.parameterDecorator = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/controls/mycheckbox.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000FEA RID: 4074 RVA: 0x000755C4 File Offset: 0x000737C4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (MyCheckBox)target;
				return;
			}
			if (connectionId == 2)
			{
				this.LabText = (TextBlock)target;
				return;
			}
			if (connectionId == 3)
			{
				this.ShapeBorder = (Border)target;
				return;
			}
			if (connectionId == 4)
			{
				this.ShapeCheck = (Path)target;
				return;
			}
			this.parameterDecorator = true;
		}

		// Token: 0x0400084E RID: 2126
		public int m_AttrDecorator;

		// Token: 0x0400084F RID: 2127
		[CompilerGenerated]
		private MyCheckBox.ChangeEventHandler _ThreadDecorator;

		// Token: 0x04000850 RID: 2128
		[CompilerGenerated]
		private MyCheckBox.PreviewChangeEventHandler _ManagerDecorator;

		// Token: 0x04000851 RID: 2129
		private bool _ItemDecorator;

		// Token: 0x04000852 RID: 2130
		public static readonly DependencyProperty _SerializerDecorator;

		// Token: 0x04000853 RID: 2131
		private bool m_InfoDecorator;

		// Token: 0x04000854 RID: 2132
		private bool m_RepositoryDecorator;

		// Token: 0x04000855 RID: 2133
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private MyCheckBox systemDecorator;

		// Token: 0x04000856 RID: 2134
		[CompilerGenerated]
		[AccessedThroughProperty("LabText")]
		private TextBlock _ProccesorDecorator;

		// Token: 0x04000857 RID: 2135
		[CompilerGenerated]
		[AccessedThroughProperty("ShapeBorder")]
		private Border m_PrototypeDecorator;

		// Token: 0x04000858 RID: 2136
		[CompilerGenerated]
		[AccessedThroughProperty("ShapeCheck")]
		private Path refDecorator;

		// Token: 0x04000859 RID: 2137
		private bool parameterDecorator;

		// Token: 0x0200016B RID: 363
		// (Invoke) Token: 0x06000FF6 RID: 4086
		public delegate void ChangeEventHandler(object sender, bool user);

		// Token: 0x0200016C RID: 364
		// (Invoke) Token: 0x06000FFA RID: 4090
		public delegate void PreviewChangeEventHandler(object sender, ModBase.RouteEventArgs e);
	}
}
