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
	// Token: 0x0200003F RID: 63
	[DesignerGenerated]
	public class MyLoading : Grid, IComponentConnector
	{
		// Token: 0x0600014F RID: 335 RVA: 0x00003041 File Offset: 0x00001241
		// Note: this type is marked as 'beforefieldinit'.
		static MyLoading()
		{
			MyLoading._Task = DependencyProperty.Register("Foreground", typeof(SolidColorBrush), typeof(MyLoading));
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00013154 File Offset: 0x00011354
		[CompilerGenerated]
		public void InvokeVal(MyLoading.IsErrorChangedEventHandler obj)
		{
			MyLoading.IsErrorChangedEventHandler isErrorChangedEventHandler = this._Creator;
			MyLoading.IsErrorChangedEventHandler isErrorChangedEventHandler2;
			do
			{
				isErrorChangedEventHandler2 = isErrorChangedEventHandler;
				MyLoading.IsErrorChangedEventHandler value = (MyLoading.IsErrorChangedEventHandler)Delegate.Combine(isErrorChangedEventHandler2, obj);
				isErrorChangedEventHandler = Interlocked.CompareExchange<MyLoading.IsErrorChangedEventHandler>(ref this._Creator, value, isErrorChangedEventHandler2);
			}
			while (isErrorChangedEventHandler != isErrorChangedEventHandler2);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0001318C File Offset: 0x0001138C
		[CompilerGenerated]
		public void InterruptVal(MyLoading.IsErrorChangedEventHandler obj)
		{
			MyLoading.IsErrorChangedEventHandler isErrorChangedEventHandler = this._Creator;
			MyLoading.IsErrorChangedEventHandler isErrorChangedEventHandler2;
			do
			{
				isErrorChangedEventHandler2 = isErrorChangedEventHandler;
				MyLoading.IsErrorChangedEventHandler value = (MyLoading.IsErrorChangedEventHandler)Delegate.Remove(isErrorChangedEventHandler2, obj);
				isErrorChangedEventHandler = Interlocked.CompareExchange<MyLoading.IsErrorChangedEventHandler>(ref this._Creator, value, isErrorChangedEventHandler2);
			}
			while (isErrorChangedEventHandler != isErrorChangedEventHandler2);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x000131C4 File Offset: 0x000113C4
		[CompilerGenerated]
		public void FillVal(MyLoading.StateChangedEventHandler obj)
		{
			MyLoading.StateChangedEventHandler stateChangedEventHandler = this.page;
			MyLoading.StateChangedEventHandler stateChangedEventHandler2;
			do
			{
				stateChangedEventHandler2 = stateChangedEventHandler;
				MyLoading.StateChangedEventHandler value = (MyLoading.StateChangedEventHandler)Delegate.Combine(stateChangedEventHandler2, obj);
				stateChangedEventHandler = Interlocked.CompareExchange<MyLoading.StateChangedEventHandler>(ref this.page, value, stateChangedEventHandler2);
			}
			while (stateChangedEventHandler != stateChangedEventHandler2);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x000131FC File Offset: 0x000113FC
		[CompilerGenerated]
		public void InitVal(MyLoading.StateChangedEventHandler obj)
		{
			MyLoading.StateChangedEventHandler stateChangedEventHandler = this.page;
			MyLoading.StateChangedEventHandler stateChangedEventHandler2;
			do
			{
				stateChangedEventHandler2 = stateChangedEventHandler;
				MyLoading.StateChangedEventHandler value = (MyLoading.StateChangedEventHandler)Delegate.Remove(stateChangedEventHandler2, obj);
				stateChangedEventHandler = Interlocked.CompareExchange<MyLoading.StateChangedEventHandler>(ref this.page, value, stateChangedEventHandler2);
			}
			while (stateChangedEventHandler != stateChangedEventHandler2);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00013234 File Offset: 0x00011434
		[CompilerGenerated]
		public void PrepareVal(MyLoading.ClickEventHandler obj)
		{
			MyLoading.ClickEventHandler clickEventHandler = this.instance;
			MyLoading.ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				MyLoading.ClickEventHandler value = (MyLoading.ClickEventHandler)Delegate.Combine(clickEventHandler2, obj);
				clickEventHandler = Interlocked.CompareExchange<MyLoading.ClickEventHandler>(ref this.instance, value, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0001326C File Offset: 0x0001146C
		[CompilerGenerated]
		public void UpdateVal(MyLoading.ClickEventHandler obj)
		{
			MyLoading.ClickEventHandler clickEventHandler = this.instance;
			MyLoading.ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				MyLoading.ClickEventHandler value = (MyLoading.ClickEventHandler)Delegate.Remove(clickEventHandler2, obj);
				clickEventHandler = Interlocked.CompareExchange<MyLoading.ClickEventHandler>(ref this.instance, value, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000156 RID: 342 RVA: 0x00003066 File Offset: 0x00001266
		// (set) Token: 0x06000157 RID: 343 RVA: 0x0000306E File Offset: 0x0000126E
		public bool AutoRun { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000158 RID: 344 RVA: 0x00003077 File Offset: 0x00001277
		// (set) Token: 0x06000159 RID: 345 RVA: 0x00003089 File Offset: 0x00001289
		public SolidColorBrush Foreground
		{
			get
			{
				return (SolidColorBrush)base.GetValue(MyLoading._Task);
			}
			set
			{
				base.SetValue(MyLoading._Task, value);
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x000132A4 File Offset: 0x000114A4
		public MyLoading()
		{
			this.InvokeVal(delegate(object a0, bool a1)
			{
				this.RefreshText();
			});
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.RefreshText();
			};
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.InitState();
			};
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.RefreshState();
			};
			base.Unloaded += delegate(object sender, RoutedEventArgs e)
			{
				this.RefreshState();
			};
			base.MouseLeftButtonUp += this.Button_MouseUp;
			base.MouseLeftButtonDown += this.Button_MouseDown;
			base.MouseLeave += new MouseEventHandler(this.Button_MouseLeave);
			base.MouseLeftButtonUp += new MouseButtonEventHandler(this.Button_MouseLeave);
			this.AutoRun = true;
			this._Customer = ModBase.GetUuid();
			this.RateVal(false);
			this.process = "加载中";
			this._Listener = "加载失败";
			this.ExcludeVal(true);
			this.OrderVal(MyLoading.MyLoadingState.Unloaded);
			this.StartVal(MyLoading.MyLoadingState.Unloaded);
			this.HasAnimation = true;
			this.m_Reg = false;
			this._Definition = false;
			this._Param = false;
			this.InitializeComponent();
			base.SetResourceReference(MyLoading._Task, "ColorBrush3");
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00003097 File Offset: 0x00001297
		[CompilerGenerated]
		private bool FindVal()
		{
			return this._Authentication;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0000309F File Offset: 0x0000129F
		[CompilerGenerated]
		private void RateVal(bool AutoPropertyValue)
		{
			this._Authentication = AutoPropertyValue;
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600015D RID: 349 RVA: 0x000030A8 File Offset: 0x000012A8
		// (set) Token: 0x0600015E RID: 350 RVA: 0x000030B0 File Offset: 0x000012B0
		public bool ShowProgress
		{
			get
			{
				return this.FindVal();
			}
			set
			{
				if (this.FindVal() != value)
				{
					this.RateVal(value);
					this.RefreshText();
				}
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600015F RID: 351 RVA: 0x000030C8 File Offset: 0x000012C8
		// (set) Token: 0x06000160 RID: 352 RVA: 0x000030D0 File Offset: 0x000012D0
		public string Text
		{
			get
			{
				return this.process;
			}
			set
			{
				this.process = value;
				this.RefreshText();
			}
		}

		// Token: 0x06000161 RID: 353 RVA: 0x000030DF File Offset: 0x000012DF
		public string ReflectVal()
		{
			return this._Listener;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x000030E7 File Offset: 0x000012E7
		public void LoginVal(string value)
		{
			this._Listener = value;
			this.RefreshText();
		}

		// Token: 0x06000163 RID: 355 RVA: 0x000030F6 File Offset: 0x000012F6
		[CompilerGenerated]
		public bool SelectVal()
		{
			return this._Importer;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x000030FE File Offset: 0x000012FE
		[CompilerGenerated]
		public void ExcludeVal(bool AutoPropertyValue)
		{
			this._Importer = AutoPropertyValue;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x000133D0 File Offset: 0x000115D0
		private void RefreshText()
		{
			if (this.CalcVal() == MyLoading.MyLoadingState.Error)
			{
				if (!this.SelectVal() || !this.State.IsLoader)
				{
					this.LabText.Text = this.ReflectVal();
					return;
				}
				Exception ex = (Exception)NewLateBinding.LateGet(this.State, null, "Error", new object[0], null, null, null);
				if (ex == null)
				{
					this.LabText.Text = "未知错误";
					return;
				}
				while (ex.InnerException != null)
				{
					ex = ex.InnerException;
				}
				this.LabText.Text = Conversions.ToString(ModBase.StrTrim(ex.Message, true));
				if (this.LabText.Text.Contains("远程主机强迫关闭了一个现有的连接"))
				{
					this.LabText.Text = "网络环境不佳，请重试或使用 VPN";
					return;
				}
			}
			else
			{
				if (this.ShowProgress && this.State.IsLoader)
				{
					this.LabText.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(this.Text + " - ", NewLateBinding.LateGet(null, typeof(Math), "Floor", new object[]
					{
						Operators.MultiplyObject(NewLateBinding.LateGet(this.State, null, "Progress", new object[0], null, null, null), 0x64)
					}, null, null, null)), "%"));
					return;
				}
				this.LabText.Text = this.Text;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000166 RID: 358 RVA: 0x00003107 File Offset: 0x00001307
		// (set) Token: 0x06000167 RID: 359 RVA: 0x00013540 File Offset: 0x00011740
		private virtual ILoadingTrigger _State
		{
			[CompilerGenerated]
			get
			{
				return this._Template;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ILoadingTrigger.LoadingStateChangedEventHandler value2 = delegate(MyLoading.MyLoadingState a0)
				{
					this.RefreshState();
				};
				ILoadingTrigger template = this._Template;
				if (template != null)
				{
					template.LoadingStateChanged -= value2;
				}
				this._Template = value;
				template = this._Template;
				if (template != null)
				{
					template.LoadingStateChanged += value2;
				}
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000168 RID: 360 RVA: 0x0000310F File Offset: 0x0000130F
		// (set) Token: 0x06000169 RID: 361 RVA: 0x0000311D File Offset: 0x0000131D
		public ILoadingTrigger State
		{
			get
			{
				this.InitState();
				return this._State;
			}
			set
			{
				this._State = value;
				this.RefreshState();
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000312C File Offset: 0x0000132C
		private void InitState()
		{
			if (this._State == null)
			{
				this._State = new MyLoadingStateSimulator();
				if (this.AutoRun)
				{
					this._State.LoadingState = MyLoading.MyLoadingState.Run;
				}
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00013584 File Offset: 0x00011784
		private void RefreshState()
		{
			if (this._State.LoadingState == MyLoading.MyLoadingState.Run && !base.IsLoaded)
			{
				this.ConcatVal(MyLoading.MyLoadingState.Stop);
			}
			this.ConcatVal(this._State.LoadingState);
			this.CalculateVal(this._State.LoadingState);
			this.AniLoop();
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00003155 File Offset: 0x00001355
		[CompilerGenerated]
		private MyLoading.MyLoadingState CheckVal()
		{
			return this._Adapter;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0000315D File Offset: 0x0000135D
		[CompilerGenerated]
		private void OrderVal(MyLoading.MyLoadingState AutoPropertyValue)
		{
			this._Adapter = AutoPropertyValue;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00003166 File Offset: 0x00001366
		private MyLoading.MyLoadingState ChangeVal()
		{
			return this.CheckVal();
		}

		// Token: 0x0600016F RID: 367 RVA: 0x000135D8 File Offset: 0x000117D8
		private void CalculateVal(MyLoading.MyLoadingState value)
		{
			if (this.CheckVal() != value)
			{
				int num = (int)this.CheckVal();
				this.OrderVal(value);
				MyLoading.StateChangedEventHandler stateChangedEventHandler = this.page;
				if (stateChangedEventHandler != null)
				{
					stateChangedEventHandler(this, value);
				}
				if (num == 2 != (value == MyLoading.MyLoadingState.Error))
				{
					MyLoading.IsErrorChangedEventHandler creator = this._Creator;
					if (creator != null)
					{
						creator(this, value == MyLoading.MyLoadingState.Error);
					}
				}
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000316E File Offset: 0x0000136E
		[CompilerGenerated]
		private MyLoading.MyLoadingState GetVal()
		{
			return this.annotation;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00003176 File Offset: 0x00001376
		[CompilerGenerated]
		private void StartVal(MyLoading.MyLoadingState AutoPropertyValue)
		{
			this.annotation = AutoPropertyValue;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000317F File Offset: 0x0000137F
		private MyLoading.MyLoadingState CalcVal()
		{
			return this.GetVal();
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00003187 File Offset: 0x00001387
		private void ConcatVal(MyLoading.MyLoadingState value)
		{
			if (this.GetVal() != value)
			{
				int val = (int)this.GetVal();
				this.StartVal(value);
				this.AniLoop();
				if (val == 2 != (value == MyLoading.MyLoadingState.Error))
				{
					this.ErrorAnimation(this, value == MyLoading.MyLoadingState.Error);
				}
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000174 RID: 372 RVA: 0x000031B9 File Offset: 0x000013B9
		// (set) Token: 0x06000175 RID: 373 RVA: 0x000031C1 File Offset: 0x000013C1
		public bool HasAnimation { get; set; }

		// Token: 0x06000176 RID: 374 RVA: 0x0001362C File Offset: 0x0001182C
		private void AniLoop()
		{
			if (this.HasAnimation && !this.m_Reg && this.CalcVal() == MyLoading.MyLoadingState.Run && ModAni._Parameter <= 10.0 && base.IsLoaded)
			{
				this.m_Reg = true;
				this._Definition = true;
				if (this.ShowProgress)
				{
					this.RefreshText();
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaRotateTransform(this.PathPickaxe, -20.0 - ((RotateTransform)this.PathPickaxe.RenderTransform).Angle, 0x15E, 0xFA, new ModAni.AniEaseInBack(ModAni.AniEasePower.Weak), false),
						ModAni.AaCode(new ThreadStart(this.RefreshText), 0x96, false),
						ModAni.AaCode(new ThreadStart(this.RefreshText), 0x12C, false),
						ModAni.AaCode(new ThreadStart(this.RefreshText), 0x1C2, false),
						ModAni.AaRotateTransform(this.PathPickaxe, 50.0, 0x384, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), true),
						ModAni.AaRotateTransform(this.PathPickaxe, 25.0, 0x384, 0, new ModAni.AniEaseOutElastic(ModAni.AniEasePower.Weak), false),
						ModAni.AaCode(delegate
						{
							this.PathLeft.Opacity = 1.0;
							this.PathLeft.Margin = new Thickness(7.0, 41.0, 0.0, 0.0);
							this.PathRight.Opacity = 1.0;
							this.PathRight.Margin = new Thickness(14.0, 41.0, 0.0, 0.0);
							this._Definition = false;
							this.RefreshText();
						}, 0, false),
						ModAni.AaCode(new ThreadStart(this.RefreshText), 0x96, false),
						ModAni.AaCode(new ThreadStart(this.RefreshText), 0x12C, false),
						ModAni.AaCode(new ThreadStart(this.RefreshText), 0x1C2, false),
						ModAni.AaCode(new ThreadStart(this.RefreshText), 0x258, false),
						ModAni.AaCode(new ThreadStart(this.RefreshText), 0x2EE, false),
						ModAni.AaOpacity(this.PathLeft, -1.0, 0x64, 0x46, null, false),
						ModAni.AaX(this.PathLeft, -5.0, 0xB4, 0x14, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
						ModAni.AaY(this.PathLeft, -6.0, 0xB4, 0x14, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
						ModAni.AaOpacity(this.PathRight, -1.0, 0x64, 0x46, null, false),
						ModAni.AaX(this.PathRight, 5.0, 0xB4, 0x14, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
						ModAni.AaY(this.PathRight, -6.0, 0xB4, 0x14, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
						ModAni.AaCode(delegate
						{
							this.m_Reg = false;
							this.AniLoop();
						}, 0, true)
					}, "MyLoader Loop " + Conversions.ToString(this._Customer) + "/" + Conversions.ToString(ModBase.GetUuid()), false);
					return;
				}
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaRotateTransform(this.PathPickaxe, -20.0 - ((RotateTransform)this.PathPickaxe.RenderTransform).Angle, 0x15E, 0xFA, new ModAni.AniEaseInBack(ModAni.AniEasePower.Weak), false),
					ModAni.AaRotateTransform(this.PathPickaxe, 50.0, 0x384, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), true),
					ModAni.AaRotateTransform(this.PathPickaxe, 25.0, 0x384, 0, new ModAni.AniEaseOutElastic(ModAni.AniEasePower.Weak), false),
					ModAni.AaCode(delegate
					{
						this.PathLeft.Opacity = 1.0;
						this.PathLeft.Margin = new Thickness(7.0, 41.0, 0.0, 0.0);
						this.PathRight.Opacity = 1.0;
						this.PathRight.Margin = new Thickness(14.0, 41.0, 0.0, 0.0);
						this._Definition = false;
					}, 0, false),
					ModAni.AaOpacity(this.PathLeft, -1.0, 0x64, 0x32, null, false),
					ModAni.AaX(this.PathLeft, -5.0, 0xB4, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaY(this.PathLeft, -6.0, 0xB4, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaOpacity(this.PathRight, -1.0, 0x64, 0x32, null, false),
					ModAni.AaX(this.PathRight, 5.0, 0xB4, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaY(this.PathRight, -6.0, 0xB4, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaCode(delegate
					{
						this.m_Reg = false;
						this.AniLoop();
					}, 0, true)
				}, "MyLoader Loop " + Conversions.ToString(this._Customer) + "/" + Conversions.ToString(ModBase.GetUuid()), false);
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00013B4C File Offset: 0x00011D4C
		private void ErrorAnimation(object sender, bool isError)
		{
			if (isError)
			{
				int num = this._Definition ? 0x190 : 0;
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaColor(this.PanBack, MyLoading._Task, "ColorBrushRedLight", 0x12C, 0, null, false),
					ModAni.AaOpacity(this.PathError, 1.0 - this.PathError.Opacity, 0x64, checked(0x12C + num), null, false),
					ModAni.AaScaleTransform(this.PathError, 1.0 - ((ScaleTransform)this.PathError.RenderTransform).ScaleX, 0x190, checked(0x12C + num), new ModAni.AniEaseOutBack(ModAni.AniEasePower.Middle), false)
				}, "MyLoader Error " + Conversions.ToString(this._Customer), false);
				return;
			}
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.PathError, -this.PathError.Opacity, 0x64, 0, null, false),
				ModAni.AaScaleTransform(this.PathError, 0.5 - ((ScaleTransform)this.PathError.RenderTransform).ScaleX, 0xC8, 0, null, false),
				ModAni.AaColor(this.PanBack, MyLoading._Task, "ColorBrush3", 0x12C, 0, null, false)
			}, "MyLoader Error " + Conversions.ToString(this._Customer), false);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00013CD0 File Offset: 0x00011ED0
		private void Button_MouseUp(object sender, MouseButtonEventArgs e)
		{
			MyLoading.ClickEventHandler clickEventHandler = this.instance;
			if (clickEventHandler != null)
			{
				clickEventHandler(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000031CA File Offset: 0x000013CA
		private void Button_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this._Param = true;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x000031D3 File Offset: 0x000013D3
		private void Button_MouseLeave(object sender, object e)
		{
			this._Param = false;
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600017B RID: 379 RVA: 0x000031DC File Offset: 0x000013DC
		// (set) Token: 0x0600017C RID: 380 RVA: 0x000031E4 File Offset: 0x000013E4
		internal virtual MyLoading PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600017D RID: 381 RVA: 0x000031ED File Offset: 0x000013ED
		// (set) Token: 0x0600017E RID: 382 RVA: 0x000031F5 File Offset: 0x000013F5
		internal virtual Path PathPickaxe { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600017F RID: 383 RVA: 0x000031FE File Offset: 0x000013FE
		// (set) Token: 0x06000180 RID: 384 RVA: 0x00003206 File Offset: 0x00001406
		internal virtual Path PathLeft { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000181 RID: 385 RVA: 0x0000320F File Offset: 0x0000140F
		// (set) Token: 0x06000182 RID: 386 RVA: 0x00003217 File Offset: 0x00001417
		internal virtual Path PathRight { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000183 RID: 387 RVA: 0x00003220 File Offset: 0x00001420
		// (set) Token: 0x06000184 RID: 388 RVA: 0x00003228 File Offset: 0x00001428
		internal virtual Path PathError { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00003231 File Offset: 0x00001431
		// (set) Token: 0x06000186 RID: 390 RVA: 0x00003239 File Offset: 0x00001439
		internal virtual TextBlock LabText { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x06000187 RID: 391 RVA: 0x00013CF4 File Offset: 0x00011EF4
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.producer)
			{
				this.producer = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/controls/myloading.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00013D24 File Offset: 0x00011F24
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (MyLoading)target;
				return;
			}
			if (connectionId == 2)
			{
				this.PathPickaxe = (Path)target;
				return;
			}
			if (connectionId == 3)
			{
				this.PathLeft = (Path)target;
				return;
			}
			if (connectionId == 4)
			{
				this.PathRight = (Path)target;
				return;
			}
			if (connectionId == 5)
			{
				this.PathError = (Path)target;
				return;
			}
			if (connectionId == 6)
			{
				this.LabText = (TextBlock)target;
				return;
			}
			this.producer = true;
		}

		// Token: 0x040000A9 RID: 169
		[CompilerGenerated]
		private MyLoading.IsErrorChangedEventHandler _Creator;

		// Token: 0x040000AA RID: 170
		[CompilerGenerated]
		private MyLoading.StateChangedEventHandler page;

		// Token: 0x040000AB RID: 171
		[CompilerGenerated]
		private MyLoading.ClickEventHandler instance;

		// Token: 0x040000AC RID: 172
		[CompilerGenerated]
		private bool m_Test;

		// Token: 0x040000AD RID: 173
		private int _Customer;

		// Token: 0x040000AE RID: 174
		public static readonly DependencyProperty _Task;

		// Token: 0x040000AF RID: 175
		[CompilerGenerated]
		private bool _Authentication;

		// Token: 0x040000B0 RID: 176
		private string process;

		// Token: 0x040000B1 RID: 177
		private string _Listener;

		// Token: 0x040000B2 RID: 178
		[CompilerGenerated]
		private bool _Importer;

		// Token: 0x040000B3 RID: 179
		[CompilerGenerated]
		[AccessedThroughProperty("_State")]
		private ILoadingTrigger _Template;

		// Token: 0x040000B4 RID: 180
		[CompilerGenerated]
		private MyLoading.MyLoadingState _Adapter;

		// Token: 0x040000B5 RID: 181
		[CompilerGenerated]
		private MyLoading.MyLoadingState annotation;

		// Token: 0x040000B6 RID: 182
		[CompilerGenerated]
		private bool m_Reader;

		// Token: 0x040000B7 RID: 183
		private bool m_Reg;

		// Token: 0x040000B8 RID: 184
		private bool _Definition;

		// Token: 0x040000B9 RID: 185
		private bool _Param;

		// Token: 0x040000BA RID: 186
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private MyLoading mock;

		// Token: 0x040000BB RID: 187
		[AccessedThroughProperty("PathPickaxe")]
		[CompilerGenerated]
		private Path _Dic;

		// Token: 0x040000BC RID: 188
		[CompilerGenerated]
		[AccessedThroughProperty("PathLeft")]
		private Path _Schema;

		// Token: 0x040000BD RID: 189
		[CompilerGenerated]
		[AccessedThroughProperty("PathRight")]
		private Path m_Helper;

		// Token: 0x040000BE RID: 190
		[AccessedThroughProperty("PathError")]
		[CompilerGenerated]
		private Path consumer;

		// Token: 0x040000BF RID: 191
		[CompilerGenerated]
		[AccessedThroughProperty("LabText")]
		private TextBlock m_Queue;

		// Token: 0x040000C0 RID: 192
		private bool producer;

		// Token: 0x02000040 RID: 64
		// (Invoke) Token: 0x06000196 RID: 406
		public delegate void IsErrorChangedEventHandler(object sender, bool isError);

		// Token: 0x02000041 RID: 65
		// (Invoke) Token: 0x0600019A RID: 410
		public delegate void StateChangedEventHandler(object sender, MyLoading.MyLoadingState newState);

		// Token: 0x02000042 RID: 66
		// (Invoke) Token: 0x0600019E RID: 414
		public delegate void ClickEventHandler(object sender, MouseButtonEventArgs e);

		// Token: 0x02000043 RID: 67
		public enum MyLoadingState
		{
			// Token: 0x040000C2 RID: 194
			Unloaded = -1,
			// Token: 0x040000C3 RID: 195
			Run,
			// Token: 0x040000C4 RID: 196
			Stop,
			// Token: 0x040000C5 RID: 197
			Error
		}
	}
}
