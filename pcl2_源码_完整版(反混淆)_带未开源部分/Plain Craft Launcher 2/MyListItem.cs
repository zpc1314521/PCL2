using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PCL
{
	// Token: 0x02000162 RID: 354
	[DesignerGenerated]
	public class MyListItem : Grid, IMyRadio, IComponentConnector
	{
		// Token: 0x06000F56 RID: 3926 RVA: 0x00072220 File Offset: 0x00070420
		// Note: this type is marked as 'beforefieldinit'.
		static MyListItem()
		{
			MyListItem.m_PublisherBase = DependencyProperty.Register("Title", typeof(string), typeof(MyListItem));
			MyListItem.m_MessageBase = DependencyProperty.Register("FontSize", typeof(double), typeof(MyListItem), new PropertyMetadata(14.0));
			MyListItem._ExpressionDecorator = DependencyProperty.Register("Foreground", typeof(Brush), typeof(MyListItem), new PropertyMetadata(ModMain.resolverFilter));
			MyListItem.m_DecoratorDecorator = DependencyProperty.Register("EventType", typeof(string), typeof(MyListItem), new PropertyMetadata(null));
			MyListItem._FilterDecorator = DependencyProperty.Register("EventData", typeof(string), typeof(MyListItem), new PropertyMetadata(null));
		}

		// Token: 0x06000F57 RID: 3927 RVA: 0x0007230C File Offset: 0x0007050C
		public MyListItem()
		{
			base.SizeChanged += delegate(object sender, SizeChangedEventArgs e)
			{
				this.OnSizeChanged();
			};
			base.PreviewMouseLeftButtonUp += this.Button_MouseUp;
			base.PreviewMouseLeftButtonDown += this.Button_MouseDown;
			base.MouseLeave += new MouseEventHandler(this.Button_MouseLeave);
			base.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(this.Button_MouseLeave);
			base.MouseEnter += new MouseEventHandler(this.RefreshColor);
			base.MouseLeave += new MouseEventHandler(this.RefreshColor);
			base.MouseLeftButtonDown += new MouseButtonEventHandler(this.RefreshColor);
			base.MouseLeftButtonUp += new MouseButtonEventHandler(this.RefreshColor);
			base.Loaded += this.MyListItem_Loaded;
			this.m_ListBase = null;
			this.policyBase = null;
			this._ClientBase = ModBase.GetUuid();
			this._MapBase = true;
			this.m_TokenBase = "";
			this.procBase = "";
			this.m_FactoryDecorator = 1.0;
			this.InterruptModel(false);
			this.containerDecorator = false;
			this.m_ModelDecorator = MyListItem.CheckType.None;
			this.iteratorDecorator = false;
			this.m_BaseDecorator = false;
			this.m_AlgoDecorator = true;
			this.InitializeComponent();
		}

		// Token: 0x06000F58 RID: 3928 RVA: 0x00072448 File Offset: 0x00070648
		[CompilerGenerated]
		public void QueryModel(MyListItem.ClickEventHandler obj)
		{
			MyListItem.ClickEventHandler clickEventHandler = this.classBase;
			MyListItem.ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				MyListItem.ClickEventHandler value = (MyListItem.ClickEventHandler)Delegate.Combine(clickEventHandler2, obj);
				clickEventHandler = Interlocked.CompareExchange<MyListItem.ClickEventHandler>(ref this.classBase, value, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}

		// Token: 0x06000F59 RID: 3929 RVA: 0x00072480 File Offset: 0x00070680
		[CompilerGenerated]
		public void PushModel(MyListItem.ClickEventHandler obj)
		{
			MyListItem.ClickEventHandler clickEventHandler = this.classBase;
			MyListItem.ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				MyListItem.ClickEventHandler value = (MyListItem.ClickEventHandler)Delegate.Remove(clickEventHandler2, obj);
				clickEventHandler = Interlocked.CompareExchange<MyListItem.ClickEventHandler>(ref this.classBase, value, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}

		// Token: 0x06000F5A RID: 3930 RVA: 0x000724B8 File Offset: 0x000706B8
		[CompilerGenerated]
		public void InsertModel(MyListItem.LogoClickEventHandler obj)
		{
			MyListItem.LogoClickEventHandler logoClickEventHandler = this._ServerBase;
			MyListItem.LogoClickEventHandler logoClickEventHandler2;
			do
			{
				logoClickEventHandler2 = logoClickEventHandler;
				MyListItem.LogoClickEventHandler value = (MyListItem.LogoClickEventHandler)Delegate.Combine(logoClickEventHandler2, obj);
				logoClickEventHandler = Interlocked.CompareExchange<MyListItem.LogoClickEventHandler>(ref this._ServerBase, value, logoClickEventHandler2);
			}
			while (logoClickEventHandler != logoClickEventHandler2);
		}

		// Token: 0x06000F5B RID: 3931 RVA: 0x000724F0 File Offset: 0x000706F0
		[CompilerGenerated]
		public void VisitModel(MyListItem.LogoClickEventHandler obj)
		{
			MyListItem.LogoClickEventHandler logoClickEventHandler = this._ServerBase;
			MyListItem.LogoClickEventHandler logoClickEventHandler2;
			do
			{
				logoClickEventHandler2 = logoClickEventHandler;
				MyListItem.LogoClickEventHandler value = (MyListItem.LogoClickEventHandler)Delegate.Remove(logoClickEventHandler2, obj);
				logoClickEventHandler = Interlocked.CompareExchange<MyListItem.LogoClickEventHandler>(ref this._ServerBase, value, logoClickEventHandler2);
			}
			while (logoClickEventHandler != logoClickEventHandler2);
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000F5C RID: 3932 RVA: 0x00072528 File Offset: 0x00070728
		// (remove) Token: 0x06000F5D RID: 3933 RVA: 0x00072560 File Offset: 0x00070760
		public event IMyRadio.CheckEventHandler Check
		{
			[CompilerGenerated]
			add
			{
				IMyRadio.CheckEventHandler checkEventHandler = this.m_ConfigBase;
				IMyRadio.CheckEventHandler checkEventHandler2;
				do
				{
					checkEventHandler2 = checkEventHandler;
					IMyRadio.CheckEventHandler value2 = (IMyRadio.CheckEventHandler)Delegate.Combine(checkEventHandler2, value);
					checkEventHandler = Interlocked.CompareExchange<IMyRadio.CheckEventHandler>(ref this.m_ConfigBase, value2, checkEventHandler2);
				}
				while (checkEventHandler != checkEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				IMyRadio.CheckEventHandler checkEventHandler = this.m_ConfigBase;
				IMyRadio.CheckEventHandler checkEventHandler2;
				do
				{
					checkEventHandler2 = checkEventHandler;
					IMyRadio.CheckEventHandler value2 = (IMyRadio.CheckEventHandler)Delegate.Remove(checkEventHandler2, value);
					checkEventHandler = Interlocked.CompareExchange<IMyRadio.CheckEventHandler>(ref this.m_ConfigBase, value2, checkEventHandler2);
				}
				while (checkEventHandler != checkEventHandler2);
			}
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000F5E RID: 3934 RVA: 0x00072598 File Offset: 0x00070798
		// (remove) Token: 0x06000F5F RID: 3935 RVA: 0x000725D0 File Offset: 0x000707D0
		public event IMyRadio.ChangedEventHandler Changed
		{
			[CompilerGenerated]
			add
			{
				IMyRadio.ChangedEventHandler changedEventHandler = this._ConnectionBase;
				IMyRadio.ChangedEventHandler changedEventHandler2;
				do
				{
					changedEventHandler2 = changedEventHandler;
					IMyRadio.ChangedEventHandler value2 = (IMyRadio.ChangedEventHandler)Delegate.Combine(changedEventHandler2, value);
					changedEventHandler = Interlocked.CompareExchange<IMyRadio.ChangedEventHandler>(ref this._ConnectionBase, value2, changedEventHandler2);
				}
				while (changedEventHandler != changedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				IMyRadio.ChangedEventHandler changedEventHandler = this._ConnectionBase;
				IMyRadio.ChangedEventHandler changedEventHandler2;
				do
				{
					changedEventHandler2 = changedEventHandler;
					IMyRadio.ChangedEventHandler value2 = (IMyRadio.ChangedEventHandler)Delegate.Remove(changedEventHandler2, value);
					changedEventHandler = Interlocked.CompareExchange<IMyRadio.ChangedEventHandler>(ref this._ConnectionBase, value2, changedEventHandler2);
				}
				while (changedEventHandler != changedEventHandler2);
			}
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x06000F60 RID: 3936 RVA: 0x00072608 File Offset: 0x00070808
		public Border RectBack
		{
			get
			{
				if (this.m_ListBase == null)
				{
					Border border = new Border
					{
						Name = "RectBack",
						CornerRadius = new CornerRadius((double)(this.IsScaleAnimationEnabled ? 6 : 0)),
						RenderTransform = (this.IsScaleAnimationEnabled ? new ScaleTransform(0.8, 0.8) : null),
						RenderTransformOrigin = new Point(0.5, 0.5),
						BorderThickness = new Thickness(ModBase.smethod_4(1.0)),
						SnapsToDevicePixels = true,
						IsHitTestVisible = false,
						Opacity = 0.0
					};
					border.SetResourceReference(Border.BackgroundProperty, "ColorBrush7");
					border.SetResourceReference(Border.BorderBrushProperty, "ColorBrush6");
					Grid.SetColumnSpan(border, 0x3E7);
					Grid.SetRowSpan(border, 0x3E7);
					base.Children.Insert(0, border);
					this.m_ListBase = border;
				}
				return this.m_ListBase;
			}
		}

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x06000F61 RID: 3937 RVA: 0x00072714 File Offset: 0x00070914
		public TextBlock LabInfo
		{
			get
			{
				if (this.policyBase == null)
				{
					TextBlock element = new TextBlock
					{
						Name = "LabInfo",
						SnapsToDevicePixels = false,
						UseLayoutRounding = false,
						HorizontalAlignment = HorizontalAlignment.Left,
						IsHitTestVisible = false,
						TextTrimming = TextTrimming.CharacterEllipsis,
						Visibility = Visibility.Collapsed,
						FontSize = 12.0,
						Margin = new Thickness(4.0, 0.0, 0.0, 0.0),
						Opacity = 0.6
					};
					Grid.SetColumn(element, 3);
					Grid.SetRow(element, 2);
					base.Children.Add(element);
					this.policyBase = element;
				}
				return this.policyBase;
			}
		}

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x06000F62 RID: 3938 RVA: 0x00009FB0 File Offset: 0x000081B0
		// (set) Token: 0x06000F63 RID: 3939 RVA: 0x00009FB8 File Offset: 0x000081B8
		public bool IsScaleAnimationEnabled
		{
			get
			{
				return this._MapBase;
			}
			set
			{
				this._MapBase = value;
				if (this.m_ListBase != null)
				{
					this.RectBack.CornerRadius = new CornerRadius((double)(value ? 6 : 0));
				}
			}
		}

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x06000F64 RID: 3940 RVA: 0x000727DC File Offset: 0x000709DC
		// (set) Token: 0x06000F65 RID: 3941 RVA: 0x00009FE1 File Offset: 0x000081E1
		public int PaddingLeft
		{
			get
			{
				return checked((int)Math.Round(this.ColumnPaddingLeft.Width.Value));
			}
			set
			{
				this.ColumnPaddingLeft.Width = new GridLength((double)value);
			}
		}

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x06000F66 RID: 3942 RVA: 0x00072804 File Offset: 0x00070A04
		// (set) Token: 0x06000F67 RID: 3943 RVA: 0x00009FF5 File Offset: 0x000081F5
		public int PaddingRight
		{
			get
			{
				return checked((int)Math.Round(this.ColumnPaddingRight.Width.Value));
			}
			set
			{
				this.ColumnPaddingRight.Width = new GridLength((double)value);
			}
		}

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x06000F68 RID: 3944 RVA: 0x0000A009 File Offset: 0x00008209
		// (set) Token: 0x06000F69 RID: 3945 RVA: 0x0007282C File Offset: 0x00070A2C
		public IEnumerable Buttons
		{
			get
			{
				return this.m_ComposerBase;
			}
			set
			{
				this.m_ComposerBase = value;
				if (!Information.IsNothing(this.m_ReponseBase))
				{
					base.Children.Remove(this.m_ReponseBase);
					this.m_ReponseBase = null;
				}
				int num = 0;
				checked
				{
					try
					{
						foreach (object obj in value)
						{
							RuntimeHelpers.GetObjectValue(obj);
							num++;
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					if (num != 0)
					{
						if (num == 1)
						{
							try
							{
								foreach (object obj2 in value)
								{
									MyIconButton myIconButton = (MyIconButton)obj2;
									if (myIconButton.Height.Equals(double.NaN))
									{
										myIconButton.Height = 23.0;
									}
									if (myIconButton.Width.Equals(double.NaN))
									{
										myIconButton.Width = 23.0;
									}
									MyIconButton myIconButton2 = myIconButton;
									myIconButton2.Opacity = 0.0;
									myIconButton2.Margin = new Thickness(0.0, 0.0, 5.0, 0.0);
									myIconButton2.SnapsToDevicePixels = false;
									myIconButton2.HorizontalAlignment = HorizontalAlignment.Right;
									myIconButton2.VerticalAlignment = VerticalAlignment.Center;
									myIconButton2.SnapsToDevicePixels = false;
									myIconButton2.UseLayoutRounding = false;
									Grid.SetColumn(myIconButton, 4);
									Grid.SetColumnSpan(myIconButton, 4);
									Grid.SetRowSpan(myIconButton, 4);
									base.Children.Add(myIconButton);
									this.m_ReponseBase = myIconButton;
								}
								return;
							}
							finally
							{
								IEnumerator enumerator2;
								if (enumerator2 is IDisposable)
								{
									(enumerator2 as IDisposable).Dispose();
								}
							}
						}
						this.m_ReponseBase = new StackPanel
						{
							Opacity = 0.0,
							Margin = new Thickness(0.0, 0.0, 5.0, 0.0),
							SnapsToDevicePixels = false,
							Orientation = Orientation.Horizontal,
							HorizontalAlignment = HorizontalAlignment.Right,
							VerticalAlignment = VerticalAlignment.Center,
							UseLayoutRounding = false
						};
						Grid.SetColumn(this.m_ReponseBase, 4);
						Grid.SetColumnSpan(this.m_ReponseBase, 4);
						Grid.SetRowSpan(this.m_ReponseBase, 4);
						try
						{
							foreach (object obj3 in value)
							{
								MyIconButton myIconButton3 = (MyIconButton)obj3;
								if (myIconButton3.Height.Equals(double.NaN))
								{
									myIconButton3.Height = 23.0;
								}
								if (myIconButton3.Width.Equals(double.NaN))
								{
									myIconButton3.Width = 23.0;
								}
								((StackPanel)this.m_ReponseBase).Children.Add(myIconButton3);
							}
						}
						finally
						{
							IEnumerator enumerator3;
							if (enumerator3 is IDisposable)
							{
								(enumerator3 as IDisposable).Dispose();
							}
						}
						base.Children.Add(this.m_ReponseBase);
					}
				}
			}
		}

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06000F6A RID: 3946 RVA: 0x0000A011 File Offset: 0x00008211
		// (set) Token: 0x06000F6B RID: 3947 RVA: 0x0000A023 File Offset: 0x00008223
		public string Title
		{
			get
			{
				return Conversions.ToString(base.GetValue(MyListItem.m_PublisherBase));
			}
			set
			{
				base.SetValue(MyListItem.m_PublisherBase, value);
			}
		}

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000F6C RID: 3948 RVA: 0x0000A031 File Offset: 0x00008231
		// (set) Token: 0x06000F6D RID: 3949 RVA: 0x0000A043 File Offset: 0x00008243
		public double FontSize
		{
			get
			{
				return Conversions.ToDouble(base.GetValue(MyListItem.m_MessageBase));
			}
			set
			{
				base.SetValue(MyListItem.m_MessageBase, value);
			}
		}

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000F6E RID: 3950 RVA: 0x0000A056 File Offset: 0x00008256
		// (set) Token: 0x06000F6F RID: 3951 RVA: 0x00072B5C File Offset: 0x00070D5C
		public string Info
		{
			get
			{
				return this.m_TokenBase;
			}
			set
			{
				if (Operators.CompareString(this.m_TokenBase, value, true) != 0)
				{
					value = value.Replace("\r", "").Replace("\n", "");
					this.m_TokenBase = value;
					this.LabInfo.Text = value;
					this.LabInfo.Visibility = ((Operators.CompareString(value, "", true) == 0) ? Visibility.Collapsed : Visibility.Visible);
				}
			}
		}

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000F70 RID: 3952 RVA: 0x0000A05E File Offset: 0x0000825E
		// (set) Token: 0x06000F71 RID: 3953 RVA: 0x00072BCC File Offset: 0x00070DCC
		public string Logo
		{
			get
			{
				return this.procBase;
			}
			set
			{
				if (Operators.CompareString(this.procBase, value, true) != 0)
				{
					this.procBase = value;
					if (!Information.IsNothing(this.PathLogo))
					{
						base.Children.Remove(this.PathLogo);
					}
					if (Operators.CompareString(this.procBase, "", true) != 0)
					{
						if (this.procBase.ToLower().StartsWith("http"))
						{
							this.PathLogo = new Image
							{
								IsHitTestVisible = this.InvokeModel(),
								Source = (ImageSource)new ImageSourceConverter().ConvertFromString(this.procBase),
								RenderTransformOrigin = new Point(0.5, 0.5),
								RenderTransform = new ScaleTransform
								{
									ScaleX = this.LogoScale,
									ScaleY = this.LogoScale
								},
								SnapsToDevicePixels = true,
								UseLayoutRounding = false
							};
							RenderOptions.SetBitmapScalingMode(this.PathLogo, BitmapScalingMode.LowQuality);
						}
						else if (this.procBase.ToLower().EndsWith(".png"))
						{
							ModBitmap.MyBitmap image = new ModBitmap.MyBitmap(this.procBase);
							this.PathLogo = new Canvas
							{
								IsHitTestVisible = this.InvokeModel(),
								Background = image,
								RenderTransformOrigin = new Point(0.5, 0.5),
								RenderTransform = new ScaleTransform
								{
									ScaleX = this.LogoScale,
									ScaleY = this.LogoScale
								},
								SnapsToDevicePixels = true,
								UseLayoutRounding = false
							};
							this.PathLogo.HorizontalAlignment = HorizontalAlignment.Stretch;
							this.PathLogo.VerticalAlignment = VerticalAlignment.Stretch;
							RenderOptions.SetBitmapScalingMode(this.PathLogo, BitmapScalingMode.HighQuality);
						}
						else
						{
							this.PathLogo = new Path
							{
								IsHitTestVisible = this.InvokeModel(),
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Center,
								Stretch = Stretch.Uniform,
								Data = (Geometry)new GeometryConverter().ConvertFromString(this.procBase),
								RenderTransformOrigin = new Point(0.5, 0.5),
								RenderTransform = new ScaleTransform
								{
									ScaleX = this.LogoScale,
									ScaleY = this.LogoScale
								},
								SnapsToDevicePixels = false,
								UseLayoutRounding = false
							};
							this.PathLogo.SetBinding(Shape.FillProperty, new Binding("Foreground")
							{
								Source = this
							});
						}
						Grid.SetColumn(this.PathLogo, 2);
						Grid.SetRowSpan(this.PathLogo, 4);
						this.OnSizeChanged();
						base.Children.Add(this.PathLogo);
						if (this.InvokeModel())
						{
							this.PathLogo.MouseLeave += delegate(object sender, MouseEventArgs e)
							{
								this.containerDecorator = false;
							};
							this.PathLogo.MouseLeftButtonDown += delegate(object sender, MouseButtonEventArgs e)
							{
								this.containerDecorator = true;
							};
							this.PathLogo.MouseLeftButtonUp += delegate(object sender, MouseButtonEventArgs e)
							{
								if (this.containerDecorator)
								{
									this.containerDecorator = false;
									MyListItem.LogoClickEventHandler serverBase = this._ServerBase;
									if (serverBase != null)
									{
										serverBase(RuntimeHelpers.GetObjectValue(sender), e);
									}
								}
							};
						}
					}
					this.ColumnLogo.Width = new GridLength((double)(checked(((Operators.CompareString(this.procBase, "", true) == 0) ? 0 : 0x22) + ((base.Height < 40.0) ? 0 : 4))));
				}
			}
		}

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06000F72 RID: 3954 RVA: 0x0000A066 File Offset: 0x00008266
		// (set) Token: 0x06000F73 RID: 3955 RVA: 0x0000A06E File Offset: 0x0000826E
		public double LogoScale
		{
			get
			{
				return this.m_FactoryDecorator;
			}
			set
			{
				this.m_FactoryDecorator = value;
				if (!Information.IsNothing(this.PathLogo))
				{
					this.PathLogo.RenderTransform = new ScaleTransform
					{
						ScaleX = this.LogoScale,
						ScaleY = this.LogoScale
					};
				}
			}
		}

		// Token: 0x06000F74 RID: 3956 RVA: 0x0000A0AC File Offset: 0x000082AC
		[CompilerGenerated]
		public bool InvokeModel()
		{
			return this._ValDecorator;
		}

		// Token: 0x06000F75 RID: 3957 RVA: 0x0000A0B4 File Offset: 0x000082B4
		[CompilerGenerated]
		public void InterruptModel(bool AutoPropertyValue)
		{
			this._ValDecorator = AutoPropertyValue;
		}

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06000F76 RID: 3958 RVA: 0x0000A0BD File Offset: 0x000082BD
		// (set) Token: 0x06000F77 RID: 3959 RVA: 0x00072F04 File Offset: 0x00071104
		public MyListItem.CheckType Type
		{
			get
			{
				return this.m_ModelDecorator;
			}
			set
			{
				if (this.m_ModelDecorator != value)
				{
					this.m_ModelDecorator = value;
					this.ColumnCheck.Width = new GridLength((double)((this.m_ModelDecorator == MyListItem.CheckType.None || this.m_ModelDecorator == MyListItem.CheckType.Clickable) ? ((base.Height < 40.0) ? 4 : 2) : 6));
					if (this.m_ModelDecorator != MyListItem.CheckType.None)
					{
						if (this.m_ModelDecorator != MyListItem.CheckType.Clickable)
						{
							if (Information.IsNothing(this._IdentifierBase))
							{
								this._IdentifierBase = new Border
								{
									Width = 5.0,
									Height = (this.Checked ? double.NaN : 0.0),
									CornerRadius = new CornerRadius(2.0, 2.0, 2.0, 2.0),
									VerticalAlignment = (this.Checked ? VerticalAlignment.Stretch : VerticalAlignment.Center),
									HorizontalAlignment = HorizontalAlignment.Left,
									UseLayoutRounding = false,
									SnapsToDevicePixels = false,
									Margin = (this.Checked ? new Thickness(-1.0, 6.0, 0.0, 6.0) : new Thickness(-1.0, 0.0, 0.0, 0.0))
								};
								this._IdentifierBase.SetResourceReference(Border.BackgroundProperty, "ColorBrush3");
								Grid.SetRowSpan(this._IdentifierBase, 4);
								base.Children.Add(this._IdentifierBase);
								return;
							}
							return;
						}
					}
					if (!Information.IsNothing(this._IdentifierBase))
					{
						base.Children.Remove(this._IdentifierBase);
						this._IdentifierBase = null;
					}
					this.SetChecked(false, false, false);
					return;
				}
			}
		}

		// Token: 0x06000F78 RID: 3960 RVA: 0x000730E0 File Offset: 0x000712E0
		private void OnSizeChanged()
		{
			this.ColumnCheck.Width = new GridLength((double)((this.m_ModelDecorator == MyListItem.CheckType.None || this.m_ModelDecorator == MyListItem.CheckType.Clickable) ? ((base.Height < 40.0) ? 4 : 2) : 6));
			this.ColumnLogo.Width = new GridLength((double)(checked(((Operators.CompareString(this.procBase, "", true) == 0) ? 0 : 0x22) + ((base.Height < 40.0) ? 0 : 4))));
			if (!Information.IsNothing(this.PathLogo))
			{
				if (this.procBase.EndsWith(".png"))
				{
					this.PathLogo.Margin = new Thickness(4.0, 5.0, 3.0, 5.0);
				}
				else
				{
					this.PathLogo.Margin = new Thickness((double)((base.Height < 40.0) ? 6 : 8), 8.0, (double)((base.Height < 40.0) ? 4 : 6), 8.0);
				}
			}
			this.LabTitle.Margin = new Thickness(4.0, 0.0, 0.0, (double)((base.Height < 40.0) ? 0 : 2));
		}

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06000F79 RID: 3961 RVA: 0x0000A0C5 File Offset: 0x000082C5
		// (set) Token: 0x06000F7A RID: 3962 RVA: 0x0000A0CD File Offset: 0x000082CD
		public bool Checked
		{
			get
			{
				return this.iteratorDecorator;
			}
			set
			{
				this.SetChecked(value, false, true);
			}
		}

		// Token: 0x06000F7B RID: 3963 RVA: 0x00073250 File Offset: 0x00071450
		public void SetChecked(bool value, bool user, bool anime)
		{
			try
			{
				ModBase.RouteEventArgs routeEventArgs = new ModBase.RouteEventArgs(user);
				bool flag = this.iteratorDecorator;
				if (this.Type == MyListItem.CheckType.RadioBox)
				{
					if (base.IsInitialized && value != this.iteratorDecorator)
					{
						this.iteratorDecorator = value;
						IMyRadio.ChangedEventHandler connectionBase = this._ConnectionBase;
						if (connectionBase != null)
						{
							connectionBase(this, routeEventArgs);
						}
						if (routeEventArgs._HelperMapper)
						{
							this.iteratorDecorator = flag;
							return;
						}
					}
					this.iteratorDecorator = value;
				}
				else
				{
					if (value == this.iteratorDecorator)
					{
						return;
					}
					this.iteratorDecorator = value;
					if (base.IsInitialized)
					{
						IMyRadio.ChangedEventHandler connectionBase2 = this._ConnectionBase;
						if (connectionBase2 != null)
						{
							connectionBase2(this, routeEventArgs);
						}
						if (routeEventArgs._HelperMapper)
						{
							this.iteratorDecorator = flag;
							return;
						}
					}
				}
				if (value)
				{
					ModBase.RouteEventArgs routeEventArgs2 = new ModBase.RouteEventArgs(user);
					IMyRadio.CheckEventHandler configBase = this.m_ConfigBase;
					if (configBase != null)
					{
						configBase(this, routeEventArgs2);
					}
					if (routeEventArgs2._HelperMapper)
					{
						return;
					}
				}
				checked
				{
					if (this.Type == MyListItem.CheckType.RadioBox)
					{
						if (Information.IsNothing(base.Parent))
						{
							return;
						}
						ArrayList arrayList = new ArrayList();
						int num = 0;
						try
						{
							foreach (object obj in ((IEnumerable)NewLateBinding.LateGet(base.Parent, null, "Children", new object[0], null, null, null)))
							{
								object objectValue = RuntimeHelpers.GetObjectValue(obj);
								if (Operators.CompareString(objectValue.GetType().Name, "MyListItem", true) == 0 && Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue, null, "Type", new object[0], null, null, null), MyListItem.CheckType.RadioBox, true))
								{
									arrayList.Add(RuntimeHelpers.GetObjectValue(objectValue));
									if (Conversions.ToBoolean(NewLateBinding.LateGet(objectValue, null, "Checked", new object[0], null, null, null)))
									{
										num++;
									}
								}
							}
						}
						finally
						{
							IEnumerator enumerator;
							if (enumerator is IDisposable)
							{
								(enumerator as IDisposable).Dispose();
							}
						}
						int num2 = num;
						if (num2 == 0)
						{
							NewLateBinding.LateSetComplex(arrayList[0], null, "Checked", new object[]
							{
								true
							}, null, null, false, true);
						}
						else if (num2 > 1)
						{
							if (this.Checked)
							{
								try
								{
									foreach (object obj2 in arrayList)
									{
										MyListItem myListItem = (MyListItem)obj2;
										if (myListItem.Checked && !myListItem.Equals(this))
										{
											myListItem.Checked = false;
										}
									}
									goto IL_2B0;
								}
								finally
								{
									IEnumerator enumerator2;
									if (enumerator2 is IDisposable)
									{
										(enumerator2 as IDisposable).Dispose();
									}
								}
							}
							bool flag2 = false;
							try
							{
								foreach (object obj3 in arrayList)
								{
									MyListItem myListItem2 = (MyListItem)obj3;
									if (myListItem2.Checked)
									{
										if (flag2)
										{
											myListItem2.Checked = false;
										}
										else
										{
											flag2 = true;
										}
									}
								}
							}
							finally
							{
								IEnumerator enumerator3;
								if (enumerator3 is IDisposable)
								{
									(enumerator3 as IDisposable).Dispose();
								}
							}
						}
					}
					IL_2B0:;
				}
				if (base.IsLoaded && ModAni.InsertFactory() == 0 && anime)
				{
					ArrayList arrayList2 = new ArrayList();
					if (this.Checked)
					{
						if (!Information.IsNothing(this._IdentifierBase))
						{
							double num3 = base.ActualHeight - this._IdentifierBase.ActualHeight - 12.0;
							arrayList2.Add(ModAni.AaHeight(this._IdentifierBase, num3 * 0.4, 0xC8, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false));
							arrayList2.Add(ModAni.AaHeight(this._IdentifierBase, num3 * 0.6, 0x12C, 0, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Weak), false));
							arrayList2.Add(ModAni.AaOpacity(this._IdentifierBase, 1.0 - this._IdentifierBase.Opacity, 0x1E, 0, null, false));
							this._IdentifierBase.VerticalAlignment = VerticalAlignment.Center;
							this._IdentifierBase.Margin = new Thickness(-1.0, 0.0, 0.0, 0.0);
						}
						arrayList2.Add(ModAni.AaColor(this, MyListItem._ExpressionDecorator, "ColorBrush3", 0xC8, 0, null, false));
					}
					else
					{
						if (!Information.IsNothing(this._IdentifierBase))
						{
							arrayList2.Add(ModAni.AaHeight(this._IdentifierBase, -this._IdentifierBase.ActualHeight, 0x78, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Weak), false));
							arrayList2.Add(ModAni.AaOpacity(this._IdentifierBase, -this._IdentifierBase.Opacity, 0x46, 0x28, null, false));
							this._IdentifierBase.VerticalAlignment = VerticalAlignment.Center;
						}
						arrayList2.Add(ModAni.AaColor(this, MyListItem._ExpressionDecorator, "ColorBrush1", 0x78, 0, null, false));
					}
					ModAni.AniStart(arrayList2, "MyListItem Checked " + Conversions.ToString(this._ClientBase), false);
				}
				else if (this.Checked)
				{
					if (!Information.IsNothing(this._IdentifierBase))
					{
						this._IdentifierBase.Height = double.NaN;
						this._IdentifierBase.Margin = new Thickness(-1.0, 6.0, 0.0, 6.0);
						this._IdentifierBase.Opacity = 1.0;
						this._IdentifierBase.VerticalAlignment = VerticalAlignment.Stretch;
					}
					base.SetResourceReference(MyListItem._ExpressionDecorator, "ColorBrush3");
				}
				else
				{
					if (!Information.IsNothing(this._IdentifierBase))
					{
						this._IdentifierBase.Height = 0.0;
						this._IdentifierBase.Margin = new Thickness(-1.0, 0.0, 0.0, 0.0);
						this._IdentifierBase.Opacity = 0.0;
						this._IdentifierBase.VerticalAlignment = VerticalAlignment.Center;
					}
					base.SetResourceReference(MyListItem._ExpressionDecorator, "ColorBrush1");
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "设置 Checked 失败", ModBase.LogLevel.Debug, "出现错误");
			}
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06000F7C RID: 3964 RVA: 0x0000A0D8 File Offset: 0x000082D8
		// (set) Token: 0x06000F7D RID: 3965 RVA: 0x0000A0EA File Offset: 0x000082EA
		public Brush Foreground
		{
			get
			{
				return (Brush)base.GetValue(MyListItem._ExpressionDecorator);
			}
			set
			{
				base.SetValue(MyListItem._ExpressionDecorator, value);
			}
		}

		// Token: 0x06000F7E RID: 3966 RVA: 0x000738BC File Offset: 0x00071ABC
		private void Button_MouseUp(object sender, MouseButtonEventArgs e)
		{
			if (this.m_BaseDecorator)
			{
				MyListItem.ClickEventHandler clickEventHandler = this.classBase;
				if (clickEventHandler != null)
				{
					clickEventHandler(RuntimeHelpers.GetObjectValue(sender), e);
				}
				if (!e.Handled)
				{
					if (!string.IsNullOrEmpty(this.EventType))
					{
						ModEvent.TryStartEvent(this.EventType, this.EventData);
						e.Handled = true;
					}
					if (!e.Handled)
					{
						switch (this.Type)
						{
						case MyListItem.CheckType.Clickable:
							ModBase.Log("[Control] 按下单击列表项：" + this.Title, ModBase.LogLevel.Normal, "出现错误");
							return;
						case MyListItem.CheckType.RadioBox:
							ModBase.Log("[Control] 按下单选列表项：" + this.Title, ModBase.LogLevel.Normal, "出现错误");
							if (!this.Checked)
							{
								this.SetChecked(true, true, true);
								return;
							}
							break;
						case MyListItem.CheckType.CheckBox:
							ModBase.Log("[Control] 按下复选列表项（" + (!this.Checked).ToString() + "）：" + this.Title, ModBase.LogLevel.Normal, "出现错误");
							this.SetChecked(!this.Checked, true, true);
							break;
						default:
							return;
						}
					}
				}
			}
		}

		// Token: 0x06000F7F RID: 3967 RVA: 0x0000A0F8 File Offset: 0x000082F8
		private void Button_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (base.IsMouseDirectlyOver && this.Type != MyListItem.CheckType.None)
			{
				this.m_BaseDecorator = true;
				if (!Information.IsNothing(this.m_ReponseBase))
				{
					this.m_ReponseBase.IsHitTestVisible = false;
				}
			}
		}

		// Token: 0x06000F80 RID: 3968 RVA: 0x0000A12A File Offset: 0x0000832A
		private void Button_MouseLeave(object sender, object e)
		{
			this.m_BaseDecorator = false;
			if (!Information.IsNothing(this.m_ReponseBase))
			{
				this.m_ReponseBase.IsHitTestVisible = true;
			}
		}

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06000F81 RID: 3969 RVA: 0x0000A14C File Offset: 0x0000834C
		// (set) Token: 0x06000F82 RID: 3970 RVA: 0x0000A15E File Offset: 0x0000835E
		public string EventType
		{
			get
			{
				return Conversions.ToString(base.GetValue(MyListItem.m_DecoratorDecorator));
			}
			set
			{
				base.SetValue(MyListItem.m_DecoratorDecorator, value);
			}
		}

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x06000F83 RID: 3971 RVA: 0x0000A16C File Offset: 0x0000836C
		// (set) Token: 0x06000F84 RID: 3972 RVA: 0x0000A17E File Offset: 0x0000837E
		public string EventData
		{
			get
			{
				return Conversions.ToString(base.GetValue(MyListItem._FilterDecorator));
			}
			set
			{
				base.SetValue(MyListItem._FilterDecorator, value);
			}
		}

		// Token: 0x06000F85 RID: 3973 RVA: 0x000739D0 File Offset: 0x00071BD0
		public void RefreshColor(object sender, EventArgs e)
		{
			if (this.utilsDecorator != null)
			{
				this.utilsDecorator(RuntimeHelpers.GetObjectValue(sender), e);
				this.utilsDecorator = null;
			}
			string text;
			int num;
			if (this.m_BaseDecorator && (this.Type != MyListItem.CheckType.RadioBox || !this.Checked))
			{
				text = "MouseDown";
				num = 0x78;
			}
			else if (base.IsMouseOver && this.m_AlgoDecorator)
			{
				text = "MouseOver";
				num = 0x78;
			}
			else
			{
				text = "Idle";
				num = 0xB4;
			}
			if (Operators.CompareString(this.m_RuleDecorator, text, true) != 0)
			{
				this.m_RuleDecorator = text;
				if (base.IsLoaded && ModAni.InsertFactory() == 0)
				{
					List<ModAni.AniData> list = new List<ModAni.AniData>();
					if (base.IsMouseOver && this.m_AlgoDecorator)
					{
						if (this.m_ReponseBase != null)
						{
							list.Add(ModAni.AaOpacity(this.m_ReponseBase, 1.0 - this.m_ReponseBase.Opacity, checked((int)Math.Round(unchecked((double)num * 0.7))), checked((int)Math.Round(unchecked((double)num * 0.3))), null, false));
						}
						list.AddRange(new ModAni.AniData[]
						{
							ModAni.AaColor(this.RectBack, Border.BackgroundProperty, this.m_BaseDecorator ? "ColorBrush6" : "ColorBrush9", num, 0, null, false),
							ModAni.AaOpacity(this.RectBack, 1.0 - this.RectBack.Opacity, num, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false)
						});
						if (this.IsScaleAnimationEnabled)
						{
							list.Add(ModAni.AaScaleTransform(this.RectBack, 1.0 - ((ScaleTransform)this.RectBack.RenderTransform).ScaleX, checked((int)Math.Round(unchecked((double)num * 1.6))), 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false));
							if (this.m_BaseDecorator)
							{
								list.Add(ModAni.AaScaleTransform(this, 0.98 - ((ScaleTransform)base.RenderTransform).ScaleX, checked((int)Math.Round(unchecked((double)num * 0.9))), 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false));
							}
							else
							{
								list.Add(ModAni.AaScaleTransform(this, 1.0 - ((ScaleTransform)base.RenderTransform).ScaleX, checked((int)Math.Round(unchecked((double)num * 1.2))), 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false));
							}
						}
					}
					else
					{
						if (this.m_ReponseBase != null)
						{
							list.Add(ModAni.AaOpacity(this.m_ReponseBase, -this.m_ReponseBase.Opacity, checked((int)Math.Round(unchecked((double)num * 0.5))), 0, null, false));
						}
						list.Add(ModAni.AaOpacity(this.RectBack, -this.RectBack.Opacity, num, 0, null, false));
						if (this.IsScaleAnimationEnabled)
						{
							list.AddRange(new ModAni.AniData[]
							{
								ModAni.AaColor(this.RectBack, Border.BackgroundProperty, this.m_BaseDecorator ? "ColorBrush6" : "ColorBrush7", num, 0, null, false),
								ModAni.AaScaleTransform(this, 1.0 - ((ScaleTransform)base.RenderTransform).ScaleX, checked(num * 3), 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
								ModAni.AaScaleTransform(this.RectBack, 0.996 - ((ScaleTransform)this.RectBack.RenderTransform).ScaleX, num, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
								ModAni.AaScaleTransform(this.RectBack, -0.246, 1, 0, null, true)
							});
						}
					}
					ModAni.AniStart(list, "ListItem Color " + Conversions.ToString(this._ClientBase), false);
					return;
				}
				if (base.IsMouseOver && this.m_AlgoDecorator)
				{
					if (this.m_ReponseBase != null)
					{
						this.m_ReponseBase.Opacity = 1.0;
					}
					this.RectBack.Background = ModMain.m_ParserFilter;
					this.RectBack.Opacity = 1.0;
					this.RectBack.RenderTransform = new ScaleTransform(1.0, 1.0);
					base.RenderTransform = new ScaleTransform(1.0, 1.0);
				}
				else
				{
					if (this.m_ReponseBase != null)
					{
						this.m_ReponseBase.Opacity = 0.0;
					}
					base.RenderTransform = new ScaleTransform(1.0, 1.0);
					if (this.m_ListBase != null)
					{
						if (this.IsScaleAnimationEnabled)
						{
							this.RectBack.Background = ModMain._RequestFilter;
						}
						this.RectBack.Opacity = 0.0;
						this.RectBack.RenderTransform = new ScaleTransform(0.75, 0.75);
					}
				}
				ModAni.AniStop("ListItem Color " + Conversions.ToString(this._ClientBase));
			}
		}

		// Token: 0x06000F86 RID: 3974 RVA: 0x00073ED0 File Offset: 0x000720D0
		private void MyListItem_Loaded(object sender, RoutedEventArgs e)
		{
			if (this.Checked)
			{
				base.SetResourceReference(MyListItem._ExpressionDecorator, "ColorBrush3");
			}
			else
			{
				base.SetResourceReference(MyListItem._ExpressionDecorator, "ColorBrush1");
			}
			if (Operators.CompareString(this.EventType, "打开帮助", true) == 0)
			{
				try
				{
					new ModMain.HelpEntry(ModEvent.GetEventAbsoluteUrls(this.EventData, this.EventType)[0]).SetToListItem(this);
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "设置帮助 MyListItem 失败", ModBase.LogLevel.Msgbox, "出现错误");
				}
			}
		}

		// Token: 0x06000F87 RID: 3975 RVA: 0x0000A18C File Offset: 0x0000838C
		public override string ToString()
		{
			return this.Title;
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x06000F88 RID: 3976 RVA: 0x0000A194 File Offset: 0x00008394
		// (set) Token: 0x06000F89 RID: 3977 RVA: 0x0000A19C File Offset: 0x0000839C
		internal virtual MyListItem PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06000F8A RID: 3978 RVA: 0x0000A1A5 File Offset: 0x000083A5
		// (set) Token: 0x06000F8B RID: 3979 RVA: 0x0000A1AD File Offset: 0x000083AD
		internal virtual ColumnDefinition ColumnCheck { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x06000F8C RID: 3980 RVA: 0x0000A1B6 File Offset: 0x000083B6
		// (set) Token: 0x06000F8D RID: 3981 RVA: 0x0000A1BE File Offset: 0x000083BE
		internal virtual ColumnDefinition ColumnPaddingLeft { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x06000F8E RID: 3982 RVA: 0x0000A1C7 File Offset: 0x000083C7
		// (set) Token: 0x06000F8F RID: 3983 RVA: 0x0000A1CF File Offset: 0x000083CF
		internal virtual ColumnDefinition ColumnLogo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06000F90 RID: 3984 RVA: 0x0000A1D8 File Offset: 0x000083D8
		// (set) Token: 0x06000F91 RID: 3985 RVA: 0x0000A1E0 File Offset: 0x000083E0
		internal virtual ColumnDefinition ColumnPaddingRight { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000F92 RID: 3986 RVA: 0x0000A1E9 File Offset: 0x000083E9
		// (set) Token: 0x06000F93 RID: 3987 RVA: 0x0000A1F1 File Offset: 0x000083F1
		internal virtual TextBlock LabTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x06000F94 RID: 3988 RVA: 0x00073F6C File Offset: 0x0007216C
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this._FacadeDecorator)
			{
				this._FacadeDecorator = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/controls/mylistitem.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000F95 RID: 3989 RVA: 0x00073F9C File Offset: 0x0007219C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (MyListItem)target;
				return;
			}
			if (connectionId == 2)
			{
				this.ColumnCheck = (ColumnDefinition)target;
				return;
			}
			if (connectionId == 3)
			{
				this.ColumnPaddingLeft = (ColumnDefinition)target;
				return;
			}
			if (connectionId == 4)
			{
				this.ColumnLogo = (ColumnDefinition)target;
				return;
			}
			if (connectionId == 5)
			{
				this.ColumnPaddingRight = (ColumnDefinition)target;
				return;
			}
			if (connectionId == 6)
			{
				this.LabTitle = (TextBlock)target;
				return;
			}
			this._FacadeDecorator = true;
		}

		// Token: 0x04000814 RID: 2068
		[CompilerGenerated]
		private MyListItem.ClickEventHandler classBase;

		// Token: 0x04000815 RID: 2069
		[CompilerGenerated]
		private MyListItem.LogoClickEventHandler _ServerBase;

		// Token: 0x04000816 RID: 2070
		[CompilerGenerated]
		private IMyRadio.CheckEventHandler m_ConfigBase;

		// Token: 0x04000817 RID: 2071
		[CompilerGenerated]
		private IMyRadio.ChangedEventHandler _ConnectionBase;

		// Token: 0x04000818 RID: 2072
		private Border m_ListBase;

		// Token: 0x04000819 RID: 2073
		public FrameworkElement m_ReponseBase;

		// Token: 0x0400081A RID: 2074
		public FrameworkElement PathLogo;

		// Token: 0x0400081B RID: 2075
		public Border _IdentifierBase;

		// Token: 0x0400081C RID: 2076
		private TextBlock policyBase;

		// Token: 0x0400081D RID: 2077
		public int _ClientBase;

		// Token: 0x0400081E RID: 2078
		private bool _MapBase;

		// Token: 0x0400081F RID: 2079
		private IEnumerable m_ComposerBase;

		// Token: 0x04000820 RID: 2080
		public static readonly DependencyProperty m_PublisherBase;

		// Token: 0x04000821 RID: 2081
		public static readonly DependencyProperty m_MessageBase;

		// Token: 0x04000822 RID: 2082
		private string m_TokenBase;

		// Token: 0x04000823 RID: 2083
		private string procBase;

		// Token: 0x04000824 RID: 2084
		private double m_FactoryDecorator;

		// Token: 0x04000825 RID: 2085
		[CompilerGenerated]
		private bool _ValDecorator;

		// Token: 0x04000826 RID: 2086
		private bool containerDecorator;

		// Token: 0x04000827 RID: 2087
		private MyListItem.CheckType m_ModelDecorator;

		// Token: 0x04000828 RID: 2088
		private bool iteratorDecorator;

		// Token: 0x04000829 RID: 2089
		public static readonly DependencyProperty _ExpressionDecorator;

		// Token: 0x0400082A RID: 2090
		public ModBase.EventDelegate utilsDecorator;

		// Token: 0x0400082B RID: 2091
		private bool m_BaseDecorator;

		// Token: 0x0400082C RID: 2092
		public static readonly DependencyProperty m_DecoratorDecorator;

		// Token: 0x0400082D RID: 2093
		public static readonly DependencyProperty _FilterDecorator;

		// Token: 0x0400082E RID: 2094
		private string m_RuleDecorator;

		// Token: 0x0400082F RID: 2095
		public bool m_AlgoDecorator;

		// Token: 0x04000830 RID: 2096
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private MyListItem _MapperDecorator;

		// Token: 0x04000831 RID: 2097
		[AccessedThroughProperty("ColumnCheck")]
		[CompilerGenerated]
		private ColumnDefinition _ParamsDecorator;

		// Token: 0x04000832 RID: 2098
		[AccessedThroughProperty("ColumnPaddingLeft")]
		[CompilerGenerated]
		private ColumnDefinition m_GlobalDecorator;

		// Token: 0x04000833 RID: 2099
		[CompilerGenerated]
		[AccessedThroughProperty("ColumnLogo")]
		private ColumnDefinition _IssuerDecorator;

		// Token: 0x04000834 RID: 2100
		[AccessedThroughProperty("ColumnPaddingRight")]
		[CompilerGenerated]
		private ColumnDefinition _OrderDecorator;

		// Token: 0x04000835 RID: 2101
		[AccessedThroughProperty("LabTitle")]
		[CompilerGenerated]
		private TextBlock m_ServiceDecorator;

		// Token: 0x04000836 RID: 2102
		private bool _FacadeDecorator;

		// Token: 0x02000163 RID: 355
		// (Invoke) Token: 0x06000F9D RID: 3997
		public delegate void ClickEventHandler(object sender, MouseButtonEventArgs e);

		// Token: 0x02000164 RID: 356
		// (Invoke) Token: 0x06000FA1 RID: 4001
		public delegate void LogoClickEventHandler(object sender, MouseButtonEventArgs e);

		// Token: 0x02000165 RID: 357
		public enum CheckType
		{
			// Token: 0x04000838 RID: 2104
			None,
			// Token: 0x04000839 RID: 2105
			Clickable,
			// Token: 0x0400083A RID: 2106
			RadioBox,
			// Token: 0x0400083B RID: 2107
			CheckBox
		}
	}
}
