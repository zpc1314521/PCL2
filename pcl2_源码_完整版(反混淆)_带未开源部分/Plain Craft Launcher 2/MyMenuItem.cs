using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PCL
{
	// Token: 0x02000047 RID: 71
	public class MyMenuItem : MenuItem
	{
		// Token: 0x060001B0 RID: 432 RVA: 0x00013F90 File Offset: 0x00012190
		public MyMenuItem()
		{
			base.Loaded += this.MyMenuItem_Loaded;
			base.MouseEnter += delegate(object sender, MouseEventArgs e)
			{
				this.RefreshColor();
			};
			base.MouseLeave += delegate(object sender, MouseEventArgs e)
			{
				this.RefreshColor();
			};
			base.IsEnabledChanged += delegate(object sender, DependencyPropertyChangedEventArgs e)
			{
				this.RefreshColor();
			};
			this.config = ModBase.GetUuid();
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00013FF8 File Offset: 0x000121F8
		private void MyMenuItem_Loaded(object sender, RoutedEventArgs e)
		{
			if (base.Icon != null)
			{
				Path path = (Path)base.GetTemplateChild("Icon");
				if (path != null)
				{
					path.Data = (Geometry)new GeometryConverter().ConvertFromString(Conversions.ToString(base.Icon));
				}
			}
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00014044 File Offset: 0x00012244
		private void RefreshColor()
		{
			string text;
			string text2;
			int time;
			if (!base.IsEnabled)
			{
				text = "ColorBrushTransparent";
				text2 = "ColorBrushGray5";
				time = 0xC8;
			}
			else if (base.IsMouseOver)
			{
				text = "ColorBrush6";
				text2 = "ColorBrush2";
				time = 0x64;
			}
			else
			{
				text = "ColorBrushTransparent";
				text2 = "ColorBrush1";
				time = 0xC8;
			}
			if (Operators.CompareString(this._Connection, text, true) != 0)
			{
				this._Connection = text;
				if (base.IsLoaded && ModAni.InsertFactory() == 0)
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaColor(this, Control.BackgroundProperty, text, time, 0, null, false),
						ModAni.AaColor(this, Control.ForegroundProperty, text2, time, 0, null, false)
					}, "MyMenuItem Color " + Conversions.ToString(this.config), false);
					return;
				}
				ModAni.AniStop("MyMenuItem Color " + Conversions.ToString(this.config));
				base.SetResourceReference(Control.BackgroundProperty, text);
				base.SetResourceReference(Control.ForegroundProperty, text2);
			}
		}

		// Token: 0x040000C9 RID: 201
		public int config;

		// Token: 0x040000CA RID: 202
		private string _Connection;
	}
}
