using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PCL
{
	// Token: 0x02000010 RID: 16
	public class MyComboBox : ComboBox
	{
		// Token: 0x0600003F RID: 63 RVA: 0x0000D460 File Offset: 0x0000B660
		public MyComboBox()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.MyComboBox_Loaded();
			};
			base.PreviewMouseLeftButtonDown += this.MyComboBox_PreviewMouseLeftButtonDown;
			base.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(this.MyComboBox_PreviewMouseLeftButtonUp);
			base.MouseLeave += new MouseEventHandler(this.MyComboBox_PreviewMouseLeftButtonUp);
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
			base.PreviewMouseLeftButtonDown += delegate(object sender, MouseButtonEventArgs e)
			{
				this.RefreshColor();
			};
			base.PreviewMouseLeftButtonUp += delegate(object sender, MouseButtonEventArgs e)
			{
				this.RefreshColor();
			};
			base.GotKeyboardFocus += delegate(object sender, KeyboardFocusChangedEventArgs e)
			{
				this.RefreshColor();
			};
			base.DropDownOpened += this.MyComboBox_DropDownOpened;
			base.DropDownClosed += this.MyComboBox_DropDownClosed;
			this.GetFactory(new MyComboBox.TextChangedEventHandler(this.MyComboBox_TextChanged));
			this.@base = ModBase.GetUuid();
			this._Decorator = false;
			this.HintText = "";
			this.m_Rule = Conversions.ToString(base.SelectedItem);
			this._Algo = false;
			this.global = false;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000D59C File Offset: 0x0000B79C
		[CompilerGenerated]
		public void GetFactory(MyComboBox.TextChangedEventHandler obj)
		{
			MyComboBox.TextChangedEventHandler textChangedEventHandler = this.m_Utils;
			MyComboBox.TextChangedEventHandler textChangedEventHandler2;
			do
			{
				textChangedEventHandler2 = textChangedEventHandler;
				MyComboBox.TextChangedEventHandler value = (MyComboBox.TextChangedEventHandler)Delegate.Combine(textChangedEventHandler2, obj);
				textChangedEventHandler = Interlocked.CompareExchange<MyComboBox.TextChangedEventHandler>(ref this.m_Utils, value, textChangedEventHandler2);
			}
			while (textChangedEventHandler != textChangedEventHandler2);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000D5D4 File Offset: 0x0000B7D4
		[CompilerGenerated]
		public void StartFactory(MyComboBox.TextChangedEventHandler obj)
		{
			MyComboBox.TextChangedEventHandler textChangedEventHandler = this.m_Utils;
			MyComboBox.TextChangedEventHandler textChangedEventHandler2;
			do
			{
				textChangedEventHandler2 = textChangedEventHandler;
				MyComboBox.TextChangedEventHandler value = (MyComboBox.TextChangedEventHandler)Delegate.Remove(textChangedEventHandler2, obj);
				textChangedEventHandler = Interlocked.CompareExchange<MyComboBox.TextChangedEventHandler>(ref this.m_Utils, value, textChangedEventHandler2);
			}
			while (textChangedEventHandler != textChangedEventHandler2);
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002697 File Offset: 0x00000897
		// (set) Token: 0x06000043 RID: 67 RVA: 0x0000269F File Offset: 0x0000089F
		public string HintText { get; set; }

		// Token: 0x06000044 RID: 68 RVA: 0x0000D60C File Offset: 0x0000B80C
		public void MyComboBox_Loaded()
		{
			if (!this._Decorator)
			{
				this._Decorator = true;
				if (base.IsEditable)
				{
					try
					{
						this.TextBox = (MyTextBox)base.Template.FindName("PART_EditableTextBox", this);
						this.TextBox.AddHandler(UIElement.LostFocusEvent, new RoutedEventHandler(delegate(object sender, RoutedEventArgs e)
						{
							this.RefreshColor();
						}));
						this.TextBox.threadVal.Add(new RoutedEventHandler(delegate(object sender, RoutedEventArgs e)
						{
							MyComboBox.TextChangedEventHandler utils2 = this.m_Utils;
							if (utils2 != null)
							{
								utils2(RuntimeHelpers.GetObjectValue(sender), (TextChangedEventArgs)e);
							}
						}));
						this.TextBox.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
						if (Operators.CompareString(this.Text, "", true) == 0)
						{
							this.TextBox.Text = this.m_Rule;
						}
						else
						{
							MyComboBox.TextChangedEventHandler utils = this.m_Utils;
							if (utils != null)
							{
								utils(this, null);
							}
						}
						if (this.HintText.Length > 0)
						{
							this.TextBox.HintText = this.HintText;
						}
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "初始化可编辑文本框失败（" + base.Name + "）", ModBase.LogLevel.Feedback, "出现错误");
					}
				}
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000045 RID: 69 RVA: 0x0000D73C File Offset: 0x0000B93C
		// (set) Token: 0x06000046 RID: 70 RVA: 0x000026A8 File Offset: 0x000008A8
		public new string Text
		{
			get
			{
				string result;
				if (base.IsEditable)
				{
					if (this.TextBox == null)
					{
						result = (this.m_Rule ?? "");
					}
					else
					{
						result = (this.TextBox.Text ?? "");
					}
				}
				else
				{
					result = (base.SelectedItem ?? "").ToString();
				}
				return result;
			}
			set
			{
				if (!base.IsEditable)
				{
					throw new NotSupportedException("该 ComboBox 不支持修改文本。");
				}
				if (Information.IsNothing(this.TextBox))
				{
					this.m_Rule = value;
					return;
				}
				this.TextBox.Text = value;
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000026DE File Offset: 0x000008DE
		private void MyComboBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			this._Algo = true;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000026E7 File Offset: 0x000008E7
		private void MyComboBox_PreviewMouseLeftButtonUp(object sender, EventArgs e)
		{
			this._Algo = false;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000D798 File Offset: 0x0000B998
		public void RefreshColor()
		{
			string text;
			string text2;
			int time;
			if (base.IsEnabled)
			{
				if (Conversions.ToBoolean(base.IsEditable && Conversions.ToBoolean(NewLateBinding.LateGet(base.Template.FindName("PART_EditableTextBox", this), null, "IsFocused", new object[0], null, null, null))))
				{
					text = "ColorBrush4";
					text2 = "ColorBrush9";
					time = 0x3C;
				}
				else if (!this._Algo && !base.IsDropDownOpen)
				{
					if (base.IsMouseOver)
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
					text = "ColorBrush3";
					text2 = "ColorBrush9";
					time = 0x3C;
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
					ModAni.AaColor(this, Control.ForegroundProperty, text, time, 0, null, false),
					ModAni.AaColor(this, Control.BackgroundProperty, text2, time, 0, null, false)
				}, "MyComboBox Color " + Conversions.ToString(this.@base), false);
				return;
			}
			ModAni.AniStop("MyComboBox Color " + Conversions.ToString(this.@base));
			base.SetResourceReference(Control.ForegroundProperty, text);
			base.SetResourceReference(Control.BackgroundProperty, text2);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000D8F4 File Offset: 0x0000BAF4
		private void MyComboBox_DropDownOpened(object sender, EventArgs e)
		{
			this.mapper = base.Width;
			base.Width = base.ActualWidth;
			try
			{
				((Grid)base.Template.FindName("PanPopup", this)).Opacity = ModMain.m_GetterFilter.Opacity;
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "设置下拉框透明度失败", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000026F0 File Offset: 0x000008F0
		private void MyComboBox_DropDownClosed(object sender, EventArgs e)
		{
			base.Width = this.mapper;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000D970 File Offset: 0x0000BB70
		private void MyComboBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (!this.global && base.IsEditable && base.SelectedItem != null && Operators.CompareString(this.Text, base.SelectedItem.ToString(), true) != 0)
			{
				string text = this.Text;
				int selectionStart = this.TextBox.SelectionStart;
				this.global = true;
				base.SelectedItem = null;
				this.Text = text;
				this.TextBox.SelectionStart = selectionStart;
				this.global = false;
			}
		}

		// Token: 0x0400000B RID: 11
		[CompilerGenerated]
		private MyComboBox.TextChangedEventHandler m_Utils;

		// Token: 0x0400000C RID: 12
		public int @base;

		// Token: 0x0400000D RID: 13
		private bool _Decorator;

		// Token: 0x0400000E RID: 14
		private MyTextBox TextBox;

		// Token: 0x0400000F RID: 15
		[CompilerGenerated]
		private string m_Filter;

		// Token: 0x04000010 RID: 16
		private string m_Rule;

		// Token: 0x04000011 RID: 17
		private bool _Algo;

		// Token: 0x04000012 RID: 18
		private double mapper;

		// Token: 0x04000013 RID: 19
		private bool global;

		// Token: 0x02000011 RID: 17
		// (Invoke) Token: 0x06000059 RID: 89
		public delegate void TextChangedEventHandler(object sender, TextChangedEventArgs e);
	}
}
