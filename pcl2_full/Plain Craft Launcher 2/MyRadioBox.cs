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
using System.Windows.Shapes;

namespace PCL
{
	// Token: 0x02000172 RID: 370
	[DesignerGenerated]
	public class MyRadioBox : Grid, IMyRadio, IComponentConnector
	{
		// Token: 0x06001042 RID: 4162 RVA: 0x0000A74A File Offset: 0x0000894A
		// Note: this type is marked as 'beforefieldinit'.
		static MyRadioBox()
		{
			MyRadioBox.writerDecorator = DependencyProperty.Register("Text", typeof(string), typeof(MyRadioBox), new PropertyMetadata(delegate(DependencyObject sender, DependencyPropertyChangedEventArgs e)
			{
				if (!Information.IsNothing(sender))
				{
					((MyRadioBox)sender).LabText.Text = Conversions.ToString(e.NewValue);
				}
			}));
		}

		// Token: 0x06001043 RID: 4163 RVA: 0x00076B68 File Offset: 0x00074D68
		public MyRadioBox()
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
			base.IsEnabledChanged += delegate(object sender, DependencyPropertyChangedEventArgs e)
			{
				this.Radiobox_IsEnabledChanged();
			};
			base.MouseEnter += delegate(object sender, MouseEventArgs e)
			{
				this.Radiobox_MouseEnterAnimation();
			};
			base.MouseLeave += delegate(object sender, MouseEventArgs e)
			{
				this.Radiobox_MouseLeaveAnimation();
			};
			this._AttributeDecorator = ModBase.GetUuid();
			this.wrapperDecorator = false;
			this.exporterDecorator = false;
			this.recordDecorator = true;
			this.InitializeComponent();
		}

		// Token: 0x06001044 RID: 4164 RVA: 0x00076C10 File Offset: 0x00074E10
		[CompilerGenerated]
		public void ChangeIterator(MyRadioBox.PreviewCheckEventHandler obj)
		{
			MyRadioBox.PreviewCheckEventHandler previewCheckEventHandler = this.valueDecorator;
			MyRadioBox.PreviewCheckEventHandler previewCheckEventHandler2;
			do
			{
				previewCheckEventHandler2 = previewCheckEventHandler;
				MyRadioBox.PreviewCheckEventHandler value = (MyRadioBox.PreviewCheckEventHandler)Delegate.Combine(previewCheckEventHandler2, obj);
				previewCheckEventHandler = Interlocked.CompareExchange<MyRadioBox.PreviewCheckEventHandler>(ref this.valueDecorator, value, previewCheckEventHandler2);
			}
			while (previewCheckEventHandler != previewCheckEventHandler2);
		}

		// Token: 0x06001045 RID: 4165 RVA: 0x00076C48 File Offset: 0x00074E48
		[CompilerGenerated]
		public void CalculateIterator(MyRadioBox.PreviewCheckEventHandler obj)
		{
			MyRadioBox.PreviewCheckEventHandler previewCheckEventHandler = this.valueDecorator;
			MyRadioBox.PreviewCheckEventHandler previewCheckEventHandler2;
			do
			{
				previewCheckEventHandler2 = previewCheckEventHandler;
				MyRadioBox.PreviewCheckEventHandler value = (MyRadioBox.PreviewCheckEventHandler)Delegate.Remove(previewCheckEventHandler2, obj);
				previewCheckEventHandler = Interlocked.CompareExchange<MyRadioBox.PreviewCheckEventHandler>(ref this.valueDecorator, value, previewCheckEventHandler2);
			}
			while (previewCheckEventHandler != previewCheckEventHandler2);
		}

		// Token: 0x06001046 RID: 4166 RVA: 0x00076C80 File Offset: 0x00074E80
		[CompilerGenerated]
		public void GetIterator(MyRadioBox.PreviewChangeEventHandler obj)
		{
			MyRadioBox.PreviewChangeEventHandler previewChangeEventHandler = this._RoleDecorator;
			MyRadioBox.PreviewChangeEventHandler previewChangeEventHandler2;
			do
			{
				previewChangeEventHandler2 = previewChangeEventHandler;
				MyRadioBox.PreviewChangeEventHandler value = (MyRadioBox.PreviewChangeEventHandler)Delegate.Combine(previewChangeEventHandler2, obj);
				previewChangeEventHandler = Interlocked.CompareExchange<MyRadioBox.PreviewChangeEventHandler>(ref this._RoleDecorator, value, previewChangeEventHandler2);
			}
			while (previewChangeEventHandler != previewChangeEventHandler2);
		}

		// Token: 0x06001047 RID: 4167 RVA: 0x00076CB8 File Offset: 0x00074EB8
		[CompilerGenerated]
		public void StartIterator(MyRadioBox.PreviewChangeEventHandler obj)
		{
			MyRadioBox.PreviewChangeEventHandler previewChangeEventHandler = this._RoleDecorator;
			MyRadioBox.PreviewChangeEventHandler previewChangeEventHandler2;
			do
			{
				previewChangeEventHandler2 = previewChangeEventHandler;
				MyRadioBox.PreviewChangeEventHandler value = (MyRadioBox.PreviewChangeEventHandler)Delegate.Remove(previewChangeEventHandler2, obj);
				previewChangeEventHandler = Interlocked.CompareExchange<MyRadioBox.PreviewChangeEventHandler>(ref this._RoleDecorator, value, previewChangeEventHandler2);
			}
			while (previewChangeEventHandler != previewChangeEventHandler2);
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06001048 RID: 4168 RVA: 0x00076CF0 File Offset: 0x00074EF0
		// (remove) Token: 0x06001049 RID: 4169 RVA: 0x00076D28 File Offset: 0x00074F28
		public event IMyRadio.CheckEventHandler Check
		{
			[CompilerGenerated]
			add
			{
				IMyRadio.CheckEventHandler checkEventHandler = this.m_AdvisorDecorator;
				IMyRadio.CheckEventHandler checkEventHandler2;
				do
				{
					checkEventHandler2 = checkEventHandler;
					IMyRadio.CheckEventHandler value2 = (IMyRadio.CheckEventHandler)Delegate.Combine(checkEventHandler2, value);
					checkEventHandler = Interlocked.CompareExchange<IMyRadio.CheckEventHandler>(ref this.m_AdvisorDecorator, value2, checkEventHandler2);
				}
				while (checkEventHandler != checkEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				IMyRadio.CheckEventHandler checkEventHandler = this.m_AdvisorDecorator;
				IMyRadio.CheckEventHandler checkEventHandler2;
				do
				{
					checkEventHandler2 = checkEventHandler;
					IMyRadio.CheckEventHandler value2 = (IMyRadio.CheckEventHandler)Delegate.Remove(checkEventHandler2, value);
					checkEventHandler = Interlocked.CompareExchange<IMyRadio.CheckEventHandler>(ref this.m_AdvisorDecorator, value2, checkEventHandler2);
				}
				while (checkEventHandler != checkEventHandler2);
			}
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x0600104A RID: 4170 RVA: 0x00076D60 File Offset: 0x00074F60
		// (remove) Token: 0x0600104B RID: 4171 RVA: 0x00076D98 File Offset: 0x00074F98
		public event IMyRadio.ChangedEventHandler Changed
		{
			[CompilerGenerated]
			add
			{
				IMyRadio.ChangedEventHandler changedEventHandler = this._StrategyDecorator;
				IMyRadio.ChangedEventHandler changedEventHandler2;
				do
				{
					changedEventHandler2 = changedEventHandler;
					IMyRadio.ChangedEventHandler value2 = (IMyRadio.ChangedEventHandler)Delegate.Combine(changedEventHandler2, value);
					changedEventHandler = Interlocked.CompareExchange<IMyRadio.ChangedEventHandler>(ref this._StrategyDecorator, value2, changedEventHandler2);
				}
				while (changedEventHandler != changedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				IMyRadio.ChangedEventHandler changedEventHandler = this._StrategyDecorator;
				IMyRadio.ChangedEventHandler changedEventHandler2;
				do
				{
					changedEventHandler2 = changedEventHandler;
					IMyRadio.ChangedEventHandler value2 = (IMyRadio.ChangedEventHandler)Delegate.Remove(changedEventHandler2, value);
					changedEventHandler = Interlocked.CompareExchange<IMyRadio.ChangedEventHandler>(ref this._StrategyDecorator, value2, changedEventHandler2);
				}
				while (changedEventHandler != changedEventHandler2);
			}
		}

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x0600104C RID: 4172 RVA: 0x0000A784 File Offset: 0x00008984
		// (set) Token: 0x0600104D RID: 4173 RVA: 0x0000A78C File Offset: 0x0000898C
		public bool Checked
		{
			get
			{
				return this.wrapperDecorator;
			}
			set
			{
				this.SetChecked(value, false, true);
			}
		}

		// Token: 0x0600104E RID: 4174 RVA: 0x00076DD0 File Offset: 0x00074FD0
		public void SetChecked(bool value, bool user, bool anime)
		{
			try
			{
				if (value && user)
				{
					ModBase.RouteEventArgs routeEventArgs = new ModBase.RouteEventArgs(user);
					MyRadioBox.PreviewCheckEventHandler previewCheckEventHandler = this.valueDecorator;
					if (previewCheckEventHandler != null)
					{
						previewCheckEventHandler(this, routeEventArgs);
					}
					if (routeEventArgs._HelperMapper)
					{
						this.Radiobox_MouseLeave();
						return;
					}
				}
				bool flag = false;
				if (base.IsLoaded && value != this.wrapperDecorator)
				{
					MyRadioBox.PreviewChangeEventHandler roleDecorator = this._RoleDecorator;
					if (roleDecorator != null)
					{
						roleDecorator(this, new ModBase.RouteEventArgs(user));
					}
				}
				if (value != this.wrapperDecorator)
				{
					this.wrapperDecorator = value;
					flag = true;
				}
				if (base.Parent != null)
				{
					ArrayList arrayList = new ArrayList();
					int num = 0;
					checked
					{
						try
						{
							foreach (object obj in ((IEnumerable)NewLateBinding.LateGet(base.Parent, null, "Children", new object[0], null, null, null)))
							{
								object objectValue = RuntimeHelpers.GetObjectValue(obj);
								if (Operators.CompareString(objectValue.GetType().Name, "MyRadioBox", true) == 0)
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
										MyRadioBox myRadioBox = (MyRadioBox)obj2;
										if (myRadioBox.Checked && !myRadioBox.Equals(this))
										{
											myRadioBox.Checked = false;
										}
									}
									goto IL_213;
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
									MyRadioBox myRadioBox2 = (MyRadioBox)obj3;
									if (myRadioBox2.Checked)
									{
										if (flag2)
										{
											myRadioBox2.Checked = false;
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
						IL_213:;
					}
					if (flag)
					{
						if (base.IsLoaded && ModAni.InsertFactory() == 0 && anime)
						{
							if (this.Checked)
							{
								if (this.ShapeDot.Opacity < 0.01)
								{
									this.ShapeDot.Opacity = 1.0;
								}
								ModAni.AniStart(new ModAni.AniData[]
								{
									ModAni.AaScale(this.ShapeBorder, 10.0 - this.ShapeBorder.Width, 0x96, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false, true),
									ModAni.AaScale(this.ShapeBorder, 8.0, 0x12C, 0x5A, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Middle), false, true)
								}, "MyRadioBox Border " + Conversions.ToString(this._AttributeDecorator), false);
								ModAni.AniStart(new ModAni.AniData[]
								{
									ModAni.AaScale(this.ShapeDot, 9.0 - this.ShapeDot.Width, 0x186, 0, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Weak), false, true),
									ModAni.AaOpacity(this.ShapeDot, 1.0 - this.ShapeDot.Opacity, 0x4B, 0x5A, null, false)
								}, "MyRadioBox Dot " + Conversions.ToString(this._AttributeDecorator), false);
								ModAni.AniStart(new ModAni.AniData[]
								{
									ModAni.AaColor(this.ShapeBorder, Shape.StrokeProperty, base.IsMouseOver ? "ColorBrush3" : (base.IsEnabled ? "ColorBrush2" : "ColorBrushGray4"), 0x96, 0, null, false)
								}, "MyRadioBox BorderColor " + Conversions.ToString(this._AttributeDecorator), false);
							}
							else
							{
								ModAni.AniStart(new ModAni.AniData[]
								{
									ModAni.AaScale(this.ShapeBorder, 18.0 - this.ShapeBorder.Width, 0x96, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false, true)
								}, "MyRadioBox Border " + Conversions.ToString(this._AttributeDecorator), false);
								ModAni.AniStart(new ModAni.AniData[]
								{
									ModAni.AaScale(this.ShapeDot, -this.ShapeDot.Width, 0x96, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false, true),
									ModAni.AaOpacity(this.ShapeDot, -this.ShapeDot.Opacity, 0x4B, 0x1E, null, false)
								}, "MyRadioBox Dot " + Conversions.ToString(this._AttributeDecorator), false);
								ModAni.AniStart(new ModAni.AniData[]
								{
									ModAni.AaColor(this.ShapeBorder, Shape.StrokeProperty, base.IsMouseOver ? "ColorBrush3" : (base.IsEnabled ? "ColorBrush1" : "ColorBrushGray4"), 0x96, 0, null, false)
								}, "MyRadioBox BorderColor " + Conversions.ToString(this._AttributeDecorator), false);
							}
						}
						else
						{
							ModAni.AniStop("MyRadioBox Border " + Conversions.ToString(this._AttributeDecorator));
							ModAni.AniStop("MyRadioBox Dot " + Conversions.ToString(this._AttributeDecorator));
							ModAni.AniStop("MyRadioBox BorderColor " + Conversions.ToString(this._AttributeDecorator));
							if (this.Checked)
							{
								this.ShapeDot.Width = 9.0;
								this.ShapeDot.Height = 9.0;
								this.ShapeDot.Opacity = 1.0;
								this.ShapeDot.Margin = new Thickness(5.5, 0.0, 0.0, 0.0);
								this.ShapeBorder.SetResourceReference(Shape.StrokeProperty, base.IsEnabled ? "ColorBrush2" : "ColorBrushGray4");
							}
							else
							{
								this.ShapeDot.Width = 0.0;
								this.ShapeDot.Height = 0.0;
								this.ShapeDot.Opacity = 0.0;
								this.ShapeDot.Margin = new Thickness(10.0, 0.0, 0.0, 0.0);
								this.ShapeBorder.SetResourceReference(Shape.StrokeProperty, base.IsEnabled ? "ColorBrush1" : "ColorBrushGray4");
							}
						}
						if (this.Checked)
						{
							IMyRadio.CheckEventHandler advisorDecorator = this.m_AdvisorDecorator;
							if (advisorDecorator != null)
							{
								advisorDecorator(this, new ModBase.RouteEventArgs(user));
							}
						}
						IMyRadio.ChangedEventHandler strategyDecorator = this._StrategyDecorator;
						if (strategyDecorator != null)
						{
							strategyDecorator(this, new ModBase.RouteEventArgs(user));
						}
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "单选框勾选改变错误", ModBase.LogLevel.Hint, "出现错误");
			}
		}

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x0600104F RID: 4175 RVA: 0x0000A797 File Offset: 0x00008997
		// (set) Token: 0x06001050 RID: 4176 RVA: 0x0000A7A9 File Offset: 0x000089A9
		public string Text
		{
			get
			{
				return Conversions.ToString(base.GetValue(MyRadioBox.writerDecorator));
			}
			set
			{
				base.SetValue(MyRadioBox.writerDecorator, value);
			}
		}

		// Token: 0x06001051 RID: 4177 RVA: 0x0007752C File Offset: 0x0007572C
		private void Radiobox_MouseUp()
		{
			if (this.exporterDecorator)
			{
				this.exporterDecorator = false;
				ModBase.Log("[Control] 按下单选框：" + this.Text, ModBase.LogLevel.Normal, "出现错误");
				this.SetChecked(true, true, true);
				ModAni.AniStart(ModAni.AaColor(this.ShapeBorder, Shape.FillProperty, "ColorBrushHalfWhite", 0x64, 0, null, false), "MyRadioBox Background " + Conversions.ToString(this._AttributeDecorator), false);
			}
		}

		// Token: 0x06001052 RID: 4178 RVA: 0x000775A4 File Offset: 0x000757A4
		private void Radiobox_MouseDown()
		{
			this.exporterDecorator = true;
			base.Focus();
			ModAni.AniStart(ModAni.AaColor(this.ShapeBorder, Shape.FillProperty, "ColorBrush9", 0x64, 0, null, false), "MyRadioBox Background " + Conversions.ToString(this._AttributeDecorator), false);
			if (!this.Checked)
			{
				ModAni.AniStart(ModAni.AaScale(this.ShapeBorder, 16.5 - this.ShapeBorder.Width, 0x3E8, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false, true), "MyRadioBox Border " + Conversions.ToString(this._AttributeDecorator), false);
			}
		}

		// Token: 0x06001053 RID: 4179 RVA: 0x00077648 File Offset: 0x00075848
		private void Radiobox_MouseLeave()
		{
			if (this.exporterDecorator)
			{
				this.exporterDecorator = false;
				ModAni.AniStart(ModAni.AaColor(this.ShapeBorder, Shape.FillProperty, "ColorBrushHalfWhite", 0x64, 0, null, false), "MyRadioBox Background " + Conversions.ToString(this._AttributeDecorator), false);
				if (!this.Checked)
				{
					ModAni.AniStart(ModAni.AaScale(this.ShapeBorder, 18.0 - this.ShapeBorder.Width, 0x190, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false, true), "MyRadioBox Border " + Conversions.ToString(this._AttributeDecorator), false);
				}
			}
		}

		// Token: 0x06001054 RID: 4180 RVA: 0x000776F0 File Offset: 0x000758F0
		private void Radiobox_IsEnabledChanged()
		{
			if (!base.IsLoaded || ModAni.InsertFactory() != 0)
			{
				ModAni.AniStop("MyRadioBox BorderColor " + Conversions.ToString(this._AttributeDecorator));
				ModAni.AniStop("MyRadioBox TextColor " + Conversions.ToString(this._AttributeDecorator));
				this.LabText.SetResourceReference(TextBlock.ForegroundProperty, base.IsEnabled ? "ColorBrush1" : "ColorBrushGray4");
				this.ShapeBorder.SetResourceReference(Shape.StrokeProperty, base.IsEnabled ? (this.Checked ? "ColorBrush2" : "ColorBrush1") : "ColorBrushGray4");
				return;
			}
			if (base.IsEnabled)
			{
				this.Radiobox_MouseLeaveAnimation();
				return;
			}
			ModAni.AniStart(ModAni.AaColor(this.ShapeBorder, Shape.StrokeProperty, ModMain._EventFilter - this.ShapeBorder.Stroke, 0xC8, 0, null, false), "MyRadioBox BorderColor " + Conversions.ToString(this._AttributeDecorator), false);
			ModAni.AniStart(ModAni.AaColor(this.LabText, TextBlock.ForegroundProperty, ModMain._EventFilter - this.LabText.Foreground, 0xC8, 0, null, false), "MyRadioBox TextColor " + Conversions.ToString(this._AttributeDecorator), false);
		}

		// Token: 0x06001055 RID: 4181 RVA: 0x00077848 File Offset: 0x00075A48
		private void Radiobox_MouseEnterAnimation()
		{
			ModAni.AniStart(ModAni.AaColor(this.ShapeBorder, Shape.StrokeProperty, "ColorBrush3", 0x64, 0, null, false), "MyRadioBox BorderColor " + Conversions.ToString(this._AttributeDecorator), false);
			ModAni.AniStart(ModAni.AaColor(this.LabText, TextBlock.ForegroundProperty, "ColorBrush3", 0x64, 0, null, false), "MyRadioBox TextColor " + Conversions.ToString(this._AttributeDecorator), false);
		}

		// Token: 0x06001056 RID: 4182 RVA: 0x000778C0 File Offset: 0x00075AC0
		private void Radiobox_MouseLeaveAnimation()
		{
			if (base.IsEnabled)
			{
				if (base.IsLoaded && ModAni.InsertFactory() == 0)
				{
					ModAni.AniStart(ModAni.AaColor(this.ShapeBorder, Shape.StrokeProperty, base.IsEnabled ? (this.Checked ? "ColorBrush2" : "ColorBrush1") : "ColorBrushGray4", 0xC8, 0, null, false), "MyRadioBox BorderColor " + Conversions.ToString(this._AttributeDecorator), false);
					ModAni.AniStart(ModAni.AaColor(this.LabText, TextBlock.ForegroundProperty, base.IsEnabled ? "ColorBrush1" : "ColorBrushGray4", 0xC8, 0, null, false), "MyRadioBox TextColor " + Conversions.ToString(this._AttributeDecorator), false);
					return;
				}
				this.ShapeBorder.SetResourceReference(Shape.StrokeProperty, base.IsEnabled ? (this.Checked ? "ColorBrush2" : "ColorBrush1") : "ColorBrushGray4");
				this.LabText.SetResourceReference(TextBlock.ForegroundProperty, base.IsEnabled ? "ColorBrush1" : "ColorBrushGray4");
			}
		}

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06001057 RID: 4183 RVA: 0x0000A7B7 File Offset: 0x000089B7
		// (set) Token: 0x06001058 RID: 4184 RVA: 0x0000A7BF File Offset: 0x000089BF
		internal virtual MyRadioBox PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06001059 RID: 4185 RVA: 0x0000A7C8 File Offset: 0x000089C8
		// (set) Token: 0x0600105A RID: 4186 RVA: 0x0000A7D0 File Offset: 0x000089D0
		internal virtual TextBlock LabText { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x0600105B RID: 4187 RVA: 0x0000A7D9 File Offset: 0x000089D9
		// (set) Token: 0x0600105C RID: 4188 RVA: 0x0000A7E1 File Offset: 0x000089E1
		internal virtual Ellipse ShapeBorder { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x0600105D RID: 4189 RVA: 0x0000A7EA File Offset: 0x000089EA
		// (set) Token: 0x0600105E RID: 4190 RVA: 0x0000A7F2 File Offset: 0x000089F2
		internal virtual Ellipse ShapeDot { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x0600105F RID: 4191 RVA: 0x000779E4 File Offset: 0x00075BE4
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.descriptorDecorator)
			{
				this.descriptorDecorator = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/controls/myradiobox.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06001060 RID: 4192 RVA: 0x00077A14 File Offset: 0x00075C14
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (MyRadioBox)target;
				return;
			}
			if (connectionId == 2)
			{
				this.LabText = (TextBlock)target;
				return;
			}
			if (connectionId == 3)
			{
				this.ShapeBorder = (Ellipse)target;
				return;
			}
			if (connectionId == 4)
			{
				this.ShapeDot = (Ellipse)target;
				return;
			}
			this.descriptorDecorator = true;
		}

		// Token: 0x04000877 RID: 2167
		public int _AttributeDecorator;

		// Token: 0x04000878 RID: 2168
		[CompilerGenerated]
		private MyRadioBox.PreviewCheckEventHandler valueDecorator;

		// Token: 0x04000879 RID: 2169
		[CompilerGenerated]
		private MyRadioBox.PreviewChangeEventHandler _RoleDecorator;

		// Token: 0x0400087A RID: 2170
		[CompilerGenerated]
		private IMyRadio.CheckEventHandler m_AdvisorDecorator;

		// Token: 0x0400087B RID: 2171
		[CompilerGenerated]
		private IMyRadio.ChangedEventHandler _StrategyDecorator;

		// Token: 0x0400087C RID: 2172
		private bool wrapperDecorator;

		// Token: 0x0400087D RID: 2173
		public static readonly DependencyProperty writerDecorator;

		// Token: 0x0400087E RID: 2174
		private bool exporterDecorator;

		// Token: 0x0400087F RID: 2175
		private bool recordDecorator;

		// Token: 0x04000880 RID: 2176
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private MyRadioBox _GetterDecorator;

		// Token: 0x04000881 RID: 2177
		[AccessedThroughProperty("LabText")]
		[CompilerGenerated]
		private TextBlock m_InterceptorDecorator;

		// Token: 0x04000882 RID: 2178
		[AccessedThroughProperty("ShapeBorder")]
		[CompilerGenerated]
		private Ellipse invocationDecorator;

		// Token: 0x04000883 RID: 2179
		[AccessedThroughProperty("ShapeDot")]
		[CompilerGenerated]
		private Ellipse m_CandidateDecorator;

		// Token: 0x04000884 RID: 2180
		private bool descriptorDecorator;

		// Token: 0x02000173 RID: 371
		// (Invoke) Token: 0x0600106A RID: 4202
		public delegate void PreviewCheckEventHandler(object sender, ModBase.RouteEventArgs e);

		// Token: 0x02000174 RID: 372
		// (Invoke) Token: 0x0600106E RID: 4206
		public delegate void PreviewChangeEventHandler(object sender, ModBase.RouteEventArgs e);
	}
}
