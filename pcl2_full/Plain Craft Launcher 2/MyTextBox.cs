using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace PCL
{
	// Token: 0x0200004E RID: 78
	public class MyTextBox : TextBox
	{
		// Token: 0x06000228 RID: 552 RVA: 0x000036A6 File Offset: 0x000018A6
		// Note: this type is marked as 'beforefieldinit'.
		static MyTextBox()
		{
			MyTextBox.m_ManagerVal = DependencyProperty.Register("ValidateResult", typeof(string), typeof(MyTextBox), new PropertyMetadata(""));
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00015E10 File Offset: 0x00014010
		public MyTextBox()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.PropertySet();
			};
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.Validate();
			};
			base.TextChanged += delegate(object sender, TextChangedEventArgs e)
			{
				this.MyTextBox_TextChanged((MyTextBox)sender, e);
			};
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
			base.GotFocus += delegate(object sender, RoutedEventArgs e)
			{
				this.RefreshColor();
			};
			base.LostFocus += delegate(object sender, RoutedEventArgs e)
			{
				this.RefreshColor();
			};
			base.IsEnabledChanged += delegate(object sender, DependencyPropertyChangedEventArgs e)
			{
				this.RefreshTextColor();
			};
			this.HasAnimation = true;
			this.ShowValidateResult = true;
			this._IndexerVal = null;
			this.methodVal = null;
			this._DatabaseVal = ModBase.GetUuid();
			this.threadVal = new ArrayList();
			this._ItemVal = new Collection<Validate>();
			this.serializerVal = -1;
			this.m_InfoVal = false;
			this._RepositoryVal = "";
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600022A RID: 554 RVA: 0x000036D5 File Offset: 0x000018D5
		// (set) Token: 0x0600022B RID: 555 RVA: 0x000036DD File Offset: 0x000018DD
		public bool HasAnimation { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600022C RID: 556 RVA: 0x000036E6 File Offset: 0x000018E6
		// (set) Token: 0x0600022D RID: 557 RVA: 0x000036EE File Offset: 0x000018EE
		public bool ShowValidateResult { get; set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600022E RID: 558 RVA: 0x00015F1C File Offset: 0x0001411C
		private TextBlock labWrong
		{
			get
			{
				TextBlock result;
				if (base.Template == null)
				{
					result = null;
				}
				else
				{
					if (this._IndexerVal == null)
					{
						this._IndexerVal = (TextBlock)base.Template.FindName("labWrong", this);
					}
					result = this._IndexerVal;
				}
				return result;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600022F RID: 559 RVA: 0x00015F64 File Offset: 0x00014164
		private TextBlock labHint
		{
			get
			{
				TextBlock result;
				if (base.Template == null)
				{
					result = null;
				}
				else
				{
					if (this.methodVal == null)
					{
						this.methodVal = (TextBlock)base.Template.FindName("labHint", this);
					}
					result = this.methodVal;
				}
				return result;
			}
		}

		// Token: 0x06000230 RID: 560 RVA: 0x000036F7 File Offset: 0x000018F7
		private void PropertySet()
		{
			if (Operators.CompareString(this.HintText, "", true) != 0)
			{
				ModBase.RunInNewThread(delegate
				{
					do
					{
						Thread.Sleep(0xA);
					}
					while (this.labHint == null || this.labWrong == null);
					base.Dispatcher.Invoke(new Action(this.PropertyInit), DispatcherPriority.Loaded);
				}, "TextBox PropertySet " + Conversions.ToString(this._DatabaseVal), ThreadPriority.Normal);
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00015FAC File Offset: 0x000141AC
		private void PropertyInit()
		{
			if (Operators.CompareString(this.HintText, "", true) != 0 && Operators.CompareString(this.labHint.Text, "", true) == 0)
			{
				if (ModAni.InsertFactory() == 0)
				{
					this.labHint.Opacity = 0.0;
					ModAni.AniStart(ModAni.AaOpacity(this.labHint, 1.0, 0xC8, 0, null, false), "", false);
				}
				this.labHint.Text = ((Operators.CompareString(base.Text, "", true) == 0) ? this.HintText : "");
			}
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00016054 File Offset: 0x00014254
		[CompilerGenerated]
		public static void ManageVal(MyTextBox.ValidateChangedEventHandler obj)
		{
			MyTextBox.ValidateChangedEventHandler validateChangedEventHandler = MyTextBox.m_AttrVal;
			MyTextBox.ValidateChangedEventHandler validateChangedEventHandler2;
			do
			{
				validateChangedEventHandler2 = validateChangedEventHandler;
				MyTextBox.ValidateChangedEventHandler value = (MyTextBox.ValidateChangedEventHandler)Delegate.Combine(validateChangedEventHandler2, obj);
				validateChangedEventHandler = Interlocked.CompareExchange<MyTextBox.ValidateChangedEventHandler>(ref MyTextBox.m_AttrVal, value, validateChangedEventHandler2);
			}
			while (validateChangedEventHandler != validateChangedEventHandler2);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00016088 File Offset: 0x00014288
		[CompilerGenerated]
		public static void EnableVal(MyTextBox.ValidateChangedEventHandler obj)
		{
			MyTextBox.ValidateChangedEventHandler validateChangedEventHandler = MyTextBox.m_AttrVal;
			MyTextBox.ValidateChangedEventHandler validateChangedEventHandler2;
			do
			{
				validateChangedEventHandler2 = validateChangedEventHandler;
				MyTextBox.ValidateChangedEventHandler value = (MyTextBox.ValidateChangedEventHandler)Delegate.Remove(validateChangedEventHandler2, obj);
				validateChangedEventHandler = Interlocked.CompareExchange<MyTextBox.ValidateChangedEventHandler>(ref MyTextBox.m_AttrVal, value, validateChangedEventHandler2);
			}
			while (validateChangedEventHandler != validateChangedEventHandler2);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00003734 File Offset: 0x00001934
		public void CancelVal(RoutedEventHandler value)
		{
			this.threadVal.Add(value);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00003743 File Offset: 0x00001943
		public void ResolveVal(RoutedEventHandler value)
		{
			this.threadVal.Remove(value);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x000160BC File Offset: 0x000142BC
		private void raise_ValidatedTextChanged(object sender, TextChangedEventArgs e)
		{
			try
			{
				foreach (object obj in this.threadVal)
				{
					RoutedEventHandler routedEventHandler = (RoutedEventHandler)obj;
					if (!Information.IsNothing(routedEventHandler))
					{
						routedEventHandler(RuntimeHelpers.GetObjectValue(sender), e);
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
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000237 RID: 567 RVA: 0x00003751 File Offset: 0x00001951
		// (set) Token: 0x06000238 RID: 568 RVA: 0x00003763 File Offset: 0x00001963
		public string ValidateResult
		{
			get
			{
				return Conversions.ToString(base.GetValue(MyTextBox.m_ManagerVal));
			}
			set
			{
				base.SetValue(MyTextBox.m_ManagerVal, value);
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000239 RID: 569 RVA: 0x00003771 File Offset: 0x00001971
		// (set) Token: 0x0600023A RID: 570 RVA: 0x00003779 File Offset: 0x00001979
		public Collection<Validate> ValidateRules
		{
			get
			{
				return this._ItemVal;
			}
			set
			{
				this._ItemVal = value;
				this.Validate();
			}
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00016128 File Offset: 0x00014328
		public void Validate()
		{
			MyTextBox._Closure$__37-0 CS$<>8__locals1 = new MyTextBox._Closure$__37-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Me = this;
			this.ValidateResult = "";
			try
			{
				foreach (Validate validate in this.ValidateRules)
				{
					this.ValidateResult = validate.Validate(base.Text);
					if (Information.IsNothing(this.ValidateResult))
					{
						break;
					}
					if (Operators.CompareString(this.ValidateResult, "", true) != 0)
					{
						break;
					}
				}
			}
			finally
			{
				IEnumerator<Validate> enumerator;
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}
			CS$<>8__locals1.$VB$Local_NewResult = ((Operators.CompareString(this.ValidateResult, "", true) == 0) ? 0 : 1);
			if (this.serializerVal != CS$<>8__locals1.$VB$Local_NewResult)
			{
				if (base.IsLoaded && this.labWrong != null)
				{
					this.ChangeValidateResult(Operators.CompareString(this.ValidateResult, "", true) == 0, true);
				}
				else
				{
					ModBase.RunInNewThread(delegate
					{
						Thread.Sleep(0x1E);
						ModBase.RunInUi((CS$<>8__locals1.$I1 == null) ? (CS$<>8__locals1.$I1 = delegate()
						{
							CS$<>8__locals1.$VB$Me.ChangeValidateResult(CS$<>8__locals1.$VB$Local_NewResult != 0, false);
						}) : CS$<>8__locals1.$I1, false);
					}, "DelayedValidate Change", ThreadPriority.Normal);
				}
			}
			if (this.ShowValidateResult && Operators.CompareString(this.ValidateResult, "", true) != 0)
			{
				if (base.IsLoaded && this.labWrong != null)
				{
					this.labWrong.Text = this.ValidateResult;
					return;
				}
				ModBase.RunInNewThread(delegate
				{
					MyTextBox._Closure$__37-1 CS$<>8__locals2 = new MyTextBox._Closure$__37-1(CS$<>8__locals2);
					CS$<>8__locals2.$VB$Me = this;
					CS$<>8__locals2.$VB$Local_IsFinished = false;
					while (!CS$<>8__locals2.$VB$Local_IsFinished)
					{
						Thread.Sleep(0x14);
						ModBase.RunInUiWait(delegate()
						{
							if (CS$<>8__locals2.$VB$Me.labWrong != null)
							{
								CS$<>8__locals2.$VB$Me.labWrong.Text = CS$<>8__locals2.$VB$Me.ValidateResult;
								CS$<>8__locals2.$VB$Local_IsFinished = true;
							}
							if (!CS$<>8__locals2.$VB$Me.IsLoaded)
							{
								CS$<>8__locals2.$VB$Local_IsFinished = true;
							}
						});
					}
				}, "DelayedValidate Text", ThreadPriority.Normal);
			}
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00016284 File Offset: 0x00014484
		private void ChangeValidateResult(bool NewResult, bool IsLoaded)
		{
			if (IsLoaded && ModAni.InsertFactory() == 0 && this.m_InfoVal && this.labWrong != null)
			{
				if (NewResult)
				{
					this.serializerVal = 0;
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaOpacity(this.labWrong, -this.labWrong.Opacity, 0x96, 0, null, false),
						ModAni.AaHeight(this.labWrong, -this.labWrong.Height, 0x96, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
						ModAni.AaCode(delegate
						{
							this.labWrong.Visibility = Visibility.Collapsed;
						}, 0, true)
					}, "MyTextBox Validate " + Conversions.ToString(this._DatabaseVal), false);
				}
				else if (this.ShowValidateResult)
				{
					this.serializerVal = 1;
					this.labWrong.Visibility = Visibility.Visible;
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaOpacity(this.labWrong, 1.0 - this.labWrong.Opacity, 0xAA, 0, null, false),
						ModAni.AaHeight(this.labWrong, 21.0 - this.labWrong.Height, 0x12C, 0, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Weak), false)
					}, "MyTextBox Validate " + Conversions.ToString(this._DatabaseVal), false);
				}
				else
				{
					this.serializerVal = 2;
				}
			}
			else
			{
				this.serializerVal = 3;
			}
			this.RefreshColor();
			MyTextBox.ValidateChangedEventHandler attrVal = MyTextBox.m_AttrVal;
			if (attrVal != null)
			{
				attrVal(this, new EventArgs());
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600023D RID: 573 RVA: 0x00003788 File Offset: 0x00001988
		// (set) Token: 0x0600023E RID: 574 RVA: 0x00003790 File Offset: 0x00001990
		public string HintText
		{
			get
			{
				return this._RepositoryVal;
			}
			set
			{
				this._RepositoryVal = value;
				if (this.labHint != null)
				{
					this.labHint.Text = ((Operators.CompareString(base.Text, "", true) == 0) ? this.HintText : "");
				}
			}
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00016424 File Offset: 0x00014624
		private void MyTextBox_TextChanged(MyTextBox sender, TextChangedEventArgs e)
		{
			try
			{
				if (this.labHint != null)
				{
					this.labHint.Text = ((Operators.CompareString(base.Text, "", true) == 0) ? this.HintText : "");
				}
				this.m_InfoVal = base.IsLoaded;
				this.Validate();
				if (Operators.CompareString(this.ValidateResult, "", true) == 0)
				{
					this.raise_ValidatedTextChanged(sender, e);
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "进行输入验证时出错", ModBase.LogLevel.Assert, "出现错误");
			}
		}

		// Token: 0x06000240 RID: 576 RVA: 0x000164C4 File Offset: 0x000146C4
		private void RefreshColor()
		{
			try
			{
				if (this.HasAnimation)
				{
					if (base.TemplatedParent == null || !base.TemplatedParent.GetType().Equals(typeof(MyComboBox)))
					{
						string text;
						string text2;
						int time;
						if (base.IsEnabled)
						{
							if (Operators.CompareString(this.ValidateResult, "", true) != 0 && this.m_InfoVal)
							{
								text = "ColorBrushRedLight";
								text2 = "ColorBrushRedBack";
								time = 0xC8;
							}
							else if (base.IsFocused)
							{
								text = "ColorBrush4";
								text2 = "ColorBrush9";
								time = 0x3C;
							}
							else if (base.IsMouseOver)
							{
								text = "ColorBrush3";
								text2 = "ColorBrushHalfWhite";
								time = 0x64;
							}
							else
							{
								text = "ColorBrush1";
								text2 = "ColorBrushHalfWhite";
								time = 0xC8;
							}
						}
						else
						{
							text = "ColorBrushGray4";
							text2 = "ColorBrushHalfWhite";
							time = 0xC8;
						}
						if (base.IsLoaded && ModAni.InsertFactory() == 0)
						{
							ModAni.AniStart(new ModAni.AniData[]
							{
								ModAni.AaColor(this, Control.BorderBrushProperty, text, time, 0, null, false),
								ModAni.AaColor(this, Control.BackgroundProperty, text2, time, 0, null, false)
							}, "MyTextBox Color " + Conversions.ToString(this._DatabaseVal), false);
						}
						else
						{
							ModAni.AniStop("MyTextBox Color " + Conversions.ToString(this._DatabaseVal));
							base.SetResourceReference(Control.BorderBrushProperty, text);
							base.SetResourceReference(Control.BackgroundProperty, text2);
						}
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "文本框颜色改变出错", ModBase.LogLevel.Debug, "出现错误");
			}
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00016668 File Offset: 0x00014868
		private void RefreshTextColor()
		{
			ModBase.MyColor myColor = base.IsEnabled ? ModMain.proxyFilter : ModMain._EventFilter;
			if ((double)((SolidColorBrush)base.Foreground).Color.R != myColor._PageMapper)
			{
				if (base.IsLoaded && ModAni.InsertFactory() == 0 && Operators.CompareString(base.Text, "", true) != 0)
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaColor(this, Control.ForegroundProperty, base.IsEnabled ? "ColorBrushGray1" : "ColorBrushGray4", 0xC8, 0, null, false)
					}, "MyTextBox TextColor " + Conversions.ToString(this._DatabaseVal), false);
					return;
				}
				ModAni.AniStop("MyTextBox TextColor " + Conversions.ToString(this._DatabaseVal));
				base.Foreground = myColor;
			}
		}

		// Token: 0x040000EF RID: 239
		[CompilerGenerated]
		private bool _WorkerVal;

		// Token: 0x040000F0 RID: 240
		[CompilerGenerated]
		private bool _VisitorVal;

		// Token: 0x040000F1 RID: 241
		private TextBlock _IndexerVal;

		// Token: 0x040000F2 RID: 242
		private TextBlock methodVal;

		// Token: 0x040000F3 RID: 243
		public int _DatabaseVal;

		// Token: 0x040000F4 RID: 244
		[CompilerGenerated]
		private static MyTextBox.ValidateChangedEventHandler m_AttrVal;

		// Token: 0x040000F5 RID: 245
		public ArrayList threadVal;

		// Token: 0x040000F6 RID: 246
		public static readonly DependencyProperty m_ManagerVal;

		// Token: 0x040000F7 RID: 247
		private Collection<Validate> _ItemVal;

		// Token: 0x040000F8 RID: 248
		private int serializerVal;

		// Token: 0x040000F9 RID: 249
		private bool m_InfoVal;

		// Token: 0x040000FA RID: 250
		private string _RepositoryVal;

		// Token: 0x0200004F RID: 79
		// (Invoke) Token: 0x06000251 RID: 593
		public delegate void ValidateChangedEventHandler(object sender, EventArgs e);
	}
}
