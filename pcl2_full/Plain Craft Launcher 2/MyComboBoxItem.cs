using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PCL
{
	// Token: 0x02000012 RID: 18
	public class MyComboBoxItem : ComboBoxItem
	{
		// Token: 0x0600005A RID: 90 RVA: 0x0000DA18 File Offset: 0x0000BC18
		public MyComboBoxItem()
		{
			base.Unselected += delegate(object sender, RoutedEventArgs e)
			{
				this.RefreshColor();
			};
			base.MouseMove += delegate(object sender, MouseEventArgs e)
			{
				this.RefreshColor();
			};
			base.MouseLeave += delegate(object sender, MouseEventArgs e)
			{
				this.RefreshColor();
			};
			base.Selected += delegate(object sender, RoutedEventArgs e)
			{
				this.RefreshColor();
			};
			base.IsEnabledChanged += delegate(object sender, DependencyPropertyChangedEventArgs e)
			{
				this.RefreshColor();
			};
			base.MouseLeftButtonUp += this.MyComboBoxItem_MouseLeftButtonUp;
			this.issuer = ModBase.GetUuid();
			base.Style = (Style)base.FindResource("MyComboBoxItem");
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000DAB8 File Offset: 0x0000BCB8
		private void RefreshColor()
		{
			string right;
			double num;
			int time;
			if (base.IsSelected)
			{
				right = "ColorBrush6";
				num = 1.0;
				time = 0x64;
			}
			else if (base.IsMouseOver)
			{
				right = "ColorBrush8";
				num = 1.0;
				time = 0x64;
			}
			else if (base.IsEnabled)
			{
				right = "ColorBrushTransparent";
				num = 1.0;
				time = 0x12C;
			}
			else
			{
				right = "ColorBrushTransparent";
				num = 0.4;
				time = 0x12C;
			}
			if (Operators.CompareString(this.order, right, true) != 0 || this.m_Service != num)
			{
				this.order = right;
				this.m_Service = num;
				if (base.IsLoaded && ModAni.InsertFactory() == 0)
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaColor(this, Control.BackgroundProperty, this.order, time, 0, null, false),
						ModAni.AaOpacity(this, this.m_Service - base.Opacity, time, 0, null, false)
					}, "ComboBoxItem Color " + Conversions.ToString(this.issuer), false);
					return;
				}
				ModAni.AniStop("ComboBoxItem Color " + Conversions.ToString(this.issuer));
				base.SetResourceReference(Control.BackgroundProperty, this.order);
				base.Opacity = this.m_Service;
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000270E File Offset: 0x0000090E
		public override string ToString()
		{
			return base.Content.ToString();
		}

		// Token: 0x0600005D RID: 93 RVA: 0x0000271B File Offset: 0x0000091B
		public static implicit operator string(MyComboBoxItem Value)
		{
			return Value.Content.ToString();
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002728 File Offset: 0x00000928
		private void MyComboBoxItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			ModBase.Log("[Control] 选择下拉列表项：" + this.ToString(), ModBase.LogLevel.Normal, "出现错误");
		}

		// Token: 0x04000014 RID: 20
		public int issuer;

		// Token: 0x04000015 RID: 21
		private string order;

		// Token: 0x04000016 RID: 22
		private double m_Service;
	}
}
