using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace PCL
{
	// Token: 0x0200004A RID: 74
	public class MyScrollBar : ScrollBar
	{
		// Token: 0x06000203 RID: 515 RVA: 0x000159B0 File Offset: 0x00013BB0
		public MyScrollBar()
		{
			base.IsEnabledChanged += delegate(object sender, DependencyPropertyChangedEventArgs e)
			{
				this.RefreshColor();
			};
			base.GotMouseCapture += delegate(object sender, MouseEventArgs e)
			{
				this.RefreshColor();
			};
			base.LostMouseCapture += delegate(object sender, MouseEventArgs e)
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
			base.IsVisibleChanged += delegate(object sender, DependencyPropertyChangedEventArgs e)
			{
				this.RefreshColor();
			};
			this._CodeVal = ModBase.GetUuid();
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00015A3C File Offset: 0x00013C3C
		private void RefreshColor()
		{
			try
			{
				double num;
				int time;
				string text;
				if (!base.IsVisible)
				{
					num = 0.0;
					time = 0x14;
					text = "ColorBrush4";
				}
				else if (base.IsMouseCaptureWithin)
				{
					num = 1.0;
					text = "ColorBrush4";
					time = 0x32;
				}
				else if (base.IsMouseOver)
				{
					num = 0.9;
					text = "ColorBrush3";
					time = 0x82;
				}
				else
				{
					num = 0.5;
					text = "ColorBrush4";
					time = 0xB4;
				}
				if (base.IsLoaded && ModAni.InsertFactory() == 0)
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaColor(this, Control.ForegroundProperty, text, time, 0, null, false),
						ModAni.AaOpacity(this, num - base.Opacity, time, 0, null, false)
					}, "MyScrollBar Color " + Conversions.ToString(this._CodeVal), false);
				}
				else
				{
					ModAni.AniStop("MyScrollBar Color " + Conversions.ToString(this._CodeVal));
					base.SetResourceReference(Control.ForegroundProperty, text);
					base.Opacity = num;
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "滚动条颜色改变出错", ModBase.LogLevel.Debug, "出现错误");
			}
		}

		// Token: 0x040000E8 RID: 232
		public int _CodeVal;
	}
}
