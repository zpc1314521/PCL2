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
	// Token: 0x02000180 RID: 384
	[DesignerGenerated]
	public class MyRadioButton : Border, IComponentConnector
	{
		// Token: 0x060010C1 RID: 4289 RVA: 0x0000AB88 File Offset: 0x00008D88
		// Note: this type is marked as 'beforefieldinit'.
		static MyRadioButton()
		{
			MyRadioButton.rulesDecorator = DependencyProperty.Register("Text", typeof(string), typeof(MyRadioButton), new PropertyMetadata(delegate(DependencyObject sender, DependencyPropertyChangedEventArgs e)
			{
				if (!Information.IsNothing(sender))
				{
					((MyRadioButton)sender).LabText.Text = Conversions.ToString(e.NewValue);
				}
			}));
		}

		// Token: 0x060010C2 RID: 4290 RVA: 0x00078F30 File Offset: 0x00077130
		public MyRadioButton()
		{
			base.MouseLeftButtonUp += delegate(object sender, MouseButtonEventArgs e)
			{
				this.Radiobox_MouseUp();
			};
			base.MouseLeftButtonDown += delegate(object sender, MouseButtonEventArgs e)
			{
				this.Radiobox_MouseDown();
			};
			base.MouseLeave += delegate(object sender, MouseEventArgs e)
			{
				this.Radiobox_MouseLeave();
			};
			base.MouseEnter += new MouseEventHandler(this.RefreshColor);
			base.MouseLeave += new MouseEventHandler(this.RefreshColor);
			base.Loaded += new RoutedEventHandler(this.RefreshColor);
			this.m_HelperDecorator = ModBase.GetUuid();
			this._ProducerDecorator = 1.0;
			this._ExceptionDecorator = false;
			this.classDecorator = MyRadioButton.ColorState.White;
			this._ServerDecorator = false;
			this.InitializeComponent();
		}

		// Token: 0x060010C3 RID: 4291 RVA: 0x00078FE4 File Offset: 0x000771E4
		[CompilerGenerated]
		public void VisitIterator(MyRadioButton.CheckEventHandler obj)
		{
			MyRadioButton.CheckEventHandler checkEventHandler = this.m_ConsumerDecorator;
			MyRadioButton.CheckEventHandler checkEventHandler2;
			do
			{
				checkEventHandler2 = checkEventHandler;
				MyRadioButton.CheckEventHandler value = (MyRadioButton.CheckEventHandler)Delegate.Combine(checkEventHandler2, obj);
				checkEventHandler = Interlocked.CompareExchange<MyRadioButton.CheckEventHandler>(ref this.m_ConsumerDecorator, value, checkEventHandler2);
			}
			while (checkEventHandler != checkEventHandler2);
		}

		// Token: 0x060010C4 RID: 4292 RVA: 0x0007901C File Offset: 0x0007721C
		[CompilerGenerated]
		public void CountIterator(MyRadioButton.CheckEventHandler obj)
		{
			MyRadioButton.CheckEventHandler checkEventHandler = this.m_ConsumerDecorator;
			MyRadioButton.CheckEventHandler checkEventHandler2;
			do
			{
				checkEventHandler2 = checkEventHandler;
				MyRadioButton.CheckEventHandler value = (MyRadioButton.CheckEventHandler)Delegate.Remove(checkEventHandler2, obj);
				checkEventHandler = Interlocked.CompareExchange<MyRadioButton.CheckEventHandler>(ref this.m_ConsumerDecorator, value, checkEventHandler2);
			}
			while (checkEventHandler != checkEventHandler2);
		}

		// Token: 0x060010C5 RID: 4293 RVA: 0x00079054 File Offset: 0x00077254
		[CompilerGenerated]
		public void AssetIterator(MyRadioButton.ChangeEventHandler obj)
		{
			MyRadioButton.ChangeEventHandler changeEventHandler = this.m_QueueDecorator;
			MyRadioButton.ChangeEventHandler changeEventHandler2;
			do
			{
				changeEventHandler2 = changeEventHandler;
				MyRadioButton.ChangeEventHandler value = (MyRadioButton.ChangeEventHandler)Delegate.Combine(changeEventHandler2, obj);
				changeEventHandler = Interlocked.CompareExchange<MyRadioButton.ChangeEventHandler>(ref this.m_QueueDecorator, value, changeEventHandler2);
			}
			while (changeEventHandler != changeEventHandler2);
		}

		// Token: 0x060010C6 RID: 4294 RVA: 0x0007908C File Offset: 0x0007728C
		[CompilerGenerated]
		public void SortIterator(MyRadioButton.ChangeEventHandler obj)
		{
			MyRadioButton.ChangeEventHandler changeEventHandler = this.m_QueueDecorator;
			MyRadioButton.ChangeEventHandler changeEventHandler2;
			do
			{
				changeEventHandler2 = changeEventHandler;
				MyRadioButton.ChangeEventHandler value = (MyRadioButton.ChangeEventHandler)Delegate.Remove(changeEventHandler2, obj);
				changeEventHandler = Interlocked.CompareExchange<MyRadioButton.ChangeEventHandler>(ref this.m_QueueDecorator, value, changeEventHandler2);
			}
			while (changeEventHandler != changeEventHandler2);
		}

		// Token: 0x060010C7 RID: 4295 RVA: 0x000790C4 File Offset: 0x000772C4
		public void RaiseChange()
		{
			MyRadioButton.ChangeEventHandler queueDecorator = this.m_QueueDecorator;
			if (queueDecorator != null)
			{
				queueDecorator(this, false);
			}
		}

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x060010C8 RID: 4296 RVA: 0x0000ABC2 File Offset: 0x00008DC2
		// (set) Token: 0x060010C9 RID: 4297 RVA: 0x0000ABD4 File Offset: 0x00008DD4
		public string Logo
		{
			get
			{
				return this.ShapeLogo.Data.ToString();
			}
			set
			{
				this.ShapeLogo.Data = (Geometry)new GeometryConverter().ConvertFromString(value);
			}
		}

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x060010CA RID: 4298 RVA: 0x0000ABF1 File Offset: 0x00008DF1
		// (set) Token: 0x060010CB RID: 4299 RVA: 0x0000ABF9 File Offset: 0x00008DF9
		public double LogoScale
		{
			get
			{
				return this._ProducerDecorator;
			}
			set
			{
				this._ProducerDecorator = value;
				if (!Information.IsNothing(this.ShapeLogo))
				{
					this.ShapeLogo.RenderTransform = new ScaleTransform
					{
						ScaleX = this.LogoScale,
						ScaleY = this.LogoScale
					};
				}
			}
		}

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x060010CC RID: 4300 RVA: 0x0000AC37 File Offset: 0x00008E37
		// (set) Token: 0x060010CD RID: 4301 RVA: 0x0000AC3F File Offset: 0x00008E3F
		public bool Checked
		{
			get
			{
				return this._ExceptionDecorator;
			}
			set
			{
				this.SetChecked(value, false, true);
			}
		}

		// Token: 0x060010CE RID: 4302 RVA: 0x000790E4 File Offset: 0x000772E4
		public void SetChecked(bool value, bool user, bool anime)
		{
			checked
			{
				try
				{
					bool flag = false;
					if (base.IsLoaded && value != this._ExceptionDecorator)
					{
						MyRadioButton.ChangeEventHandler queueDecorator = this.m_QueueDecorator;
						if (queueDecorator != null)
						{
							queueDecorator(this, user);
						}
					}
					if (value != this._ExceptionDecorator)
					{
						this._ExceptionDecorator = value;
						flag = true;
					}
					if (!Information.IsNothing(base.Parent))
					{
						ArrayList arrayList = new ArrayList();
						int num = 0;
						try
						{
							foreach (object obj in ((IEnumerable)NewLateBinding.LateGet(base.Parent, null, "Children", new object[0], null, null, null)))
							{
								object objectValue = RuntimeHelpers.GetObjectValue(obj);
								if (Operators.CompareString(objectValue.GetType().Name, "MyRadioButton", true) == 0)
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
										MyRadioButton myRadioButton = (MyRadioButton)obj2;
										if (myRadioButton.Checked && !myRadioButton.Equals(this))
										{
											myRadioButton.Checked = false;
										}
									}
									goto IL_1DB;
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
									MyRadioButton myRadioButton2 = (MyRadioButton)obj3;
									if (myRadioButton2.Checked)
									{
										if (flag2)
										{
											myRadioButton2.Checked = false;
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
						IL_1DB:
						if (flag)
						{
							this.RefreshColor(null, anime);
							if (this.Checked)
							{
								MyRadioButton.CheckEventHandler consumerDecorator = this.m_ConsumerDecorator;
								if (consumerDecorator != null)
								{
									consumerDecorator(this, user);
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "单选按钮勾选改变错误", ModBase.LogLevel.Hint, "出现错误");
				}
			}
		}

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x060010CF RID: 4303 RVA: 0x0000AC4A File Offset: 0x00008E4A
		// (set) Token: 0x060010D0 RID: 4304 RVA: 0x0000AC5C File Offset: 0x00008E5C
		public string Text
		{
			get
			{
				return Conversions.ToString(base.GetValue(MyRadioButton.rulesDecorator));
			}
			set
			{
				base.SetValue(MyRadioButton.rulesDecorator, value);
			}
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x060010D1 RID: 4305 RVA: 0x0000AC6A File Offset: 0x00008E6A
		// (set) Token: 0x060010D2 RID: 4306 RVA: 0x0000AC72 File Offset: 0x00008E72
		public MyRadioButton.ColorState ColorType
		{
			get
			{
				return this.classDecorator;
			}
			set
			{
				this.classDecorator = value;
				this.RefreshColor(null, null);
			}
		}

		// Token: 0x060010D3 RID: 4307 RVA: 0x0000AC83 File Offset: 0x00008E83
		private void Radiobox_MouseUp()
		{
			if (!this.Checked && this._ServerDecorator)
			{
				ModBase.Log("[Control] 按下单选按钮：" + this.Text, ModBase.LogLevel.Normal, "出现错误");
				this._ServerDecorator = false;
				this.SetChecked(true, true, true);
			}
		}

		// Token: 0x060010D4 RID: 4308 RVA: 0x0000ACC0 File Offset: 0x00008EC0
		private void Radiobox_MouseDown()
		{
			if (!this.Checked)
			{
				this._ServerDecorator = true;
				this.RefreshColor(null, null);
			}
		}

		// Token: 0x060010D5 RID: 4309 RVA: 0x0000ACD9 File Offset: 0x00008ED9
		private void Radiobox_MouseLeave()
		{
			this._ServerDecorator = false;
		}

		// Token: 0x060010D6 RID: 4310 RVA: 0x00079384 File Offset: 0x00077584
		private void RefreshColor(object obj = null, object e = null)
		{
			try
			{
				if (base.IsLoaded && ModAni.InsertFactory() == 0 && !false.Equals(RuntimeHelpers.GetObjectValue(e)))
				{
					MyRadioButton.ColorState colorType = this.ColorType;
					if (colorType != MyRadioButton.ColorState.White)
					{
						if (colorType == MyRadioButton.ColorState.Highlight)
						{
							if (this.Checked)
							{
								ModAni.AniStart(new ModAni.AniData[]
								{
									ModAni.AaColor(this.ShapeLogo, Shape.FillProperty, new ModBase.MyColor(255.0, 255.0, 255.0) - this.ShapeLogo.Fill, 0x78, 0, null, false),
									ModAni.AaColor(this.LabText, TextBlock.ForegroundProperty, new ModBase.MyColor(255.0, 255.0, 255.0) - this.LabText.Foreground, 0x78, 0, null, false)
								}, "MyRadioButton Checked " + Conversions.ToString(this.m_HelperDecorator), false);
								ModAni.AniStart(ModAni.AaColor(this, Border.BackgroundProperty, "ColorBrush3", 0x78, 0, null, false), "MyRadioButton Color " + Conversions.ToString(this.m_HelperDecorator), false);
							}
							else if (this._ServerDecorator)
							{
								ModAni.AniStart(ModAni.AaColor(this, Border.BackgroundProperty, "ColorBrush6", 0x5A, 0, null, false), "MyRadioButton Color " + Conversions.ToString(this.m_HelperDecorator), false);
							}
							else if (base.IsMouseOver)
							{
								ModAni.AniStart(new ModAni.AniData[]
								{
									ModAni.AaColor(this.ShapeLogo, Shape.FillProperty, "ColorBrush3", 0x5A, 0, null, false),
									ModAni.AaColor(this.LabText, TextBlock.ForegroundProperty, "ColorBrush3", 0x5A, 0, null, false)
								}, "MyRadioButton Checked " + Conversions.ToString(this.m_HelperDecorator), false);
								ModAni.AniStart(ModAni.AaColor(this, Border.BackgroundProperty, "ColorBrush7", 0x5A, 0, null, false), "MyRadioButton Color " + Conversions.ToString(this.m_HelperDecorator), false);
							}
							else
							{
								ModAni.AniStart(new ModAni.AniData[]
								{
									ModAni.AaColor(this.ShapeLogo, Shape.FillProperty, "ColorBrush3", 0x96, 0, null, false),
									ModAni.AaColor(this.LabText, TextBlock.ForegroundProperty, "ColorBrush3", 0x96, 0, null, false)
								}, "MyRadioButton Checked " + Conversions.ToString(this.m_HelperDecorator), false);
								ModAni.AniStart(ModAni.AaColor(this, Border.BackgroundProperty, ModMain.m_AttributeFilter - base.Background, 0x96, 0, null, false), "MyRadioButton Color " + Conversions.ToString(this.m_HelperDecorator), false);
							}
						}
					}
					else if (this.Checked)
					{
						ModAni.AniStart(new ModAni.AniData[]
						{
							ModAni.AaColor(this.ShapeLogo, Shape.FillProperty, "ColorBrush3", 0x78, 0, null, false),
							ModAni.AaColor(this.LabText, TextBlock.ForegroundProperty, "ColorBrush3", 0x78, 0, null, false)
						}, "MyRadioButton Checked " + Conversions.ToString(this.m_HelperDecorator), false);
						ModAni.AniStart(ModAni.AaColor(this, Border.BackgroundProperty, new ModBase.MyColor(255.0, 255.0, 255.0) - base.Background, 0x78, 0, null, false), "MyRadioButton Color " + Conversions.ToString(this.m_HelperDecorator), false);
					}
					else if (this._ServerDecorator)
					{
						ModAni.AniStart(ModAni.AaColor(this, Border.BackgroundProperty, new ModBase.MyColor(120.0, ModMain.poolFilter) - base.Background, 0x3C, 0, null, false), "MyRadioButton Color " + Conversions.ToString(this.m_HelperDecorator), false);
					}
					else if (base.IsMouseOver)
					{
						ModAni.AniStart(new ModAni.AniData[]
						{
							ModAni.AaColor(this.ShapeLogo, Shape.FillProperty, new ModBase.MyColor(255.0, 255.0, 255.0) - this.ShapeLogo.Fill, 0x5A, 0, null, false),
							ModAni.AaColor(this.LabText, TextBlock.ForegroundProperty, new ModBase.MyColor(255.0, 255.0, 255.0) - this.LabText.Foreground, 0x5A, 0, null, false)
						}, "MyRadioButton Checked " + Conversions.ToString(this.m_HelperDecorator), false);
						ModAni.AniStart(ModAni.AaColor(this, Border.BackgroundProperty, new ModBase.MyColor(50.0, ModMain.poolFilter) - base.Background, 0x5A, 0, null, false), "MyRadioButton Color " + Conversions.ToString(this.m_HelperDecorator), false);
					}
					else
					{
						ModAni.AniStart(new ModAni.AniData[]
						{
							ModAni.AaColor(this.ShapeLogo, Shape.FillProperty, new ModBase.MyColor(255.0, 255.0, 255.0) - this.ShapeLogo.Fill, 0x96, 0, null, false),
							ModAni.AaColor(this.LabText, TextBlock.ForegroundProperty, new ModBase.MyColor(255.0, 255.0, 255.0) - this.LabText.Foreground, 0x96, 0, null, false)
						}, "MyRadioButton Checked " + Conversions.ToString(this.m_HelperDecorator), false);
						ModAni.AniStart(ModAni.AaColor(this, Border.BackgroundProperty, ModMain.m_AttributeFilter - base.Background, 0x96, 0, null, false), "MyRadioButton Color " + Conversions.ToString(this.m_HelperDecorator), false);
					}
				}
				else
				{
					ModAni.AniStop("MyRadioButton Checked " + Conversions.ToString(this.m_HelperDecorator));
					ModAni.AniStop("MyRadioButton Color " + Conversions.ToString(this.m_HelperDecorator));
					MyRadioButton.ColorState colorType2 = this.ColorType;
					if (colorType2 != MyRadioButton.ColorState.White)
					{
						if (colorType2 == MyRadioButton.ColorState.Highlight)
						{
							if (this.Checked)
							{
								base.SetResourceReference(Border.BackgroundProperty, "ColorBrush3");
								this.ShapeLogo.Fill = new ModBase.MyColor(255.0, 255.0, 255.0);
								this.LabText.Foreground = new ModBase.MyColor(255.0, 255.0, 255.0);
							}
							else
							{
								base.Background = ModMain.m_AttributeFilter;
								this.ShapeLogo.SetResourceReference(Shape.FillProperty, "ColorBrush3");
								this.LabText.SetResourceReference(TextBlock.ForegroundProperty, "ColorBrush3");
							}
						}
					}
					else if (this.Checked)
					{
						base.Background = new ModBase.MyColor(255.0, 255.0, 255.0);
						this.ShapeLogo.SetResourceReference(Shape.FillProperty, "ColorBrush3");
						this.LabText.SetResourceReference(TextBlock.ForegroundProperty, "ColorBrush3");
					}
					else
					{
						base.Background = ModMain.m_AttributeFilter;
						this.ShapeLogo.Fill = new ModBase.MyColor(255.0, 255.0, 255.0);
						this.LabText.Foreground = new ModBase.MyColor(255.0, 255.0, 255.0);
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "刷新按钮颜色出错", ModBase.LogLevel.Debug, "出现错误");
			}
		}

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x060010D7 RID: 4311 RVA: 0x0000ACE2 File Offset: 0x00008EE2
		// (set) Token: 0x060010D8 RID: 4312 RVA: 0x0000ACEA File Offset: 0x00008EEA
		internal virtual MyRadioButton PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x060010D9 RID: 4313 RVA: 0x0000ACF3 File Offset: 0x00008EF3
		// (set) Token: 0x060010DA RID: 4314 RVA: 0x0000ACFB File Offset: 0x00008EFB
		internal virtual Path ShapeLogo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x060010DB RID: 4315 RVA: 0x0000AD04 File Offset: 0x00008F04
		// (set) Token: 0x060010DC RID: 4316 RVA: 0x0000AD0C File Offset: 0x00008F0C
		internal virtual TextBlock LabText { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x060010DD RID: 4317 RVA: 0x00079BD4 File Offset: 0x00077DD4
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this._ReponseDecorator)
			{
				this._ReponseDecorator = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/controls/myradiobutton.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x060010DE RID: 4318 RVA: 0x0000AD15 File Offset: 0x00008F15
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (MyRadioButton)target;
				return;
			}
			if (connectionId == 2)
			{
				this.ShapeLogo = (Path)target;
				return;
			}
			if (connectionId == 3)
			{
				this.LabText = (TextBlock)target;
				return;
			}
			this._ReponseDecorator = true;
		}

		// Token: 0x040008B6 RID: 2230
		public int m_HelperDecorator;

		// Token: 0x040008B7 RID: 2231
		[CompilerGenerated]
		private MyRadioButton.CheckEventHandler m_ConsumerDecorator;

		// Token: 0x040008B8 RID: 2232
		[CompilerGenerated]
		private MyRadioButton.ChangeEventHandler m_QueueDecorator;

		// Token: 0x040008B9 RID: 2233
		private double _ProducerDecorator;

		// Token: 0x040008BA RID: 2234
		private bool _ExceptionDecorator;

		// Token: 0x040008BB RID: 2235
		public static readonly DependencyProperty rulesDecorator;

		// Token: 0x040008BC RID: 2236
		private MyRadioButton.ColorState classDecorator;

		// Token: 0x040008BD RID: 2237
		private bool _ServerDecorator;

		// Token: 0x040008BE RID: 2238
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private MyRadioButton _ConfigDecorator;

		// Token: 0x040008BF RID: 2239
		[AccessedThroughProperty("ShapeLogo")]
		[CompilerGenerated]
		private Path connectionDecorator;

		// Token: 0x040008C0 RID: 2240
		[CompilerGenerated]
		[AccessedThroughProperty("LabText")]
		private TextBlock _ListDecorator;

		// Token: 0x040008C1 RID: 2241
		private bool _ReponseDecorator;

		// Token: 0x02000181 RID: 385
		// (Invoke) Token: 0x060010E5 RID: 4325
		public delegate void CheckEventHandler(object sender, bool raiseByMouse);

		// Token: 0x02000182 RID: 386
		// (Invoke) Token: 0x060010E9 RID: 4329
		public delegate void ChangeEventHandler(object sender, bool raiseByMouse);

		// Token: 0x02000183 RID: 387
		public enum ColorState
		{
			// Token: 0x040008C3 RID: 2243
			White,
			// Token: 0x040008C4 RID: 2244
			Highlight
		}
	}
}
