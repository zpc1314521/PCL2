using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace PCL
{
	// Token: 0x0200004B RID: 75
	public class MyScrollViewer : ScrollViewer
	{
		// Token: 0x0600020B RID: 523 RVA: 0x00003504 File Offset: 0x00001704
		public MyScrollViewer()
		{
			base.PreviewMouseWheel += this.MyScrollViewer_PreviewMouseWheel;
			base.ScrollChanged += this.MyScrollViewer_ScrollChanged;
			this.DeltaMuity = 1.0;
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600020C RID: 524 RVA: 0x0000353F File Offset: 0x0000173F
		// (set) Token: 0x0600020D RID: 525 RVA: 0x00003547 File Offset: 0x00001747
		public double DeltaMuity { get; set; }

		// Token: 0x0600020E RID: 526 RVA: 0x00015B88 File Offset: 0x00013D88
		private void MyScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			if (e.Delta != 0 && base.ActualHeight != 0.0 && base.ScrollableHeight != 0.0)
			{
				string name = e.Source.GetType().Name;
				if (NewLateBinding.LateGet(base.Content, null, "TemplatedParent", new object[0], null, null, null) != null || (!name.Contains("Combo") && Operators.CompareString(name, "MyTextBox", true) != 0))
				{
					this.PerformVerticalOffsetDelta((double)(checked(0 - e.Delta)));
					e.Handled = true;
				}
			}
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00003550 File Offset: 0x00001750
		public void PerformVerticalOffsetDelta(double Delta)
		{
			ModAni.AniStart(ModAni.AaDouble(delegate(object a0)
			{
				this._Lambda$__7-0(Conversions.ToDouble(a0));
			}, Delta * this.DeltaMuity, 0x78, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false), "", false);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00003580 File Offset: 0x00001780
		private void MyScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
		{
			this._BridgeVal = base.VerticalOffset;
			if (ModMain.m_GetterFilter != null)
			{
				ModMain.m_GetterFilter.BtnExtraBack.ShowRefresh();
			}
		}

		// Token: 0x040000E9 RID: 233
		[CompilerGenerated]
		private double m_MappingVal;

		// Token: 0x040000EA RID: 234
		private double _BridgeVal;
	}
}
