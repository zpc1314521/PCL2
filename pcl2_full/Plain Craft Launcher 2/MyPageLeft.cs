using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PCL
{
	// Token: 0x02000034 RID: 52
	public class MyPageLeft : Grid
	{
		// Token: 0x060000EB RID: 235 RVA: 0x00002CE5 File Offset: 0x00000EE5
		// Note: this type is marked as 'beforefieldinit'.
		static MyPageLeft()
		{
			MyPageLeft.status = DependencyProperty.Register("AnimatedControl", typeof(FrameworkElement), typeof(MyPageLeft), new PropertyMetadata(null));
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00002D10 File Offset: 0x00000F10
		public MyPageLeft()
		{
			this._Field = ModBase.GetUuid();
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000ED RID: 237 RVA: 0x00002D23 File Offset: 0x00000F23
		// (set) Token: 0x060000EE RID: 238 RVA: 0x00002D35 File Offset: 0x00000F35
		public FrameworkElement AnimatedControl
		{
			get
			{
				return (FrameworkElement)base.GetValue(MyPageLeft.status);
			}
			set
			{
				base.SetValue(MyPageLeft.status, value);
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000115EC File Offset: 0x0000F7EC
		public void TriggerShowAnimation()
		{
			base.Opacity = 0.0;
			if (this.AnimatedControl == null)
			{
				if (!(base.RenderTransform is ScaleTransform))
				{
					base.RenderTransform = new ScaleTransform(0.96, 0.96);
					base.RenderTransformOrigin = new Point(0.5, 0.5);
				}
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaScaleTransform(this, 1.0 - ((ScaleTransform)base.RenderTransform).ScaleX, 0x190, 0x28, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Weak), false),
					ModAni.AaOpacity(this, 1.0 - base.Opacity, 0x32, 0x28, null, false)
				}, "GridPage PageChange " + Conversions.ToString(this._Field), false);
				return;
			}
			ModBase.RunInNewThread(delegate
			{
				Thread.Sleep(0x28);
				ModBase.RunInUi(checked(delegate()
				{
					base.Opacity = 1.0;
					List<ModAni.AniData> list = new List<ModAni.AniData>();
					int num = 0;
					int num2 = 0;
					List<FrameworkElement> allAnimControls = this.GetAllAnimControls();
					try
					{
						List<FrameworkElement>.Enumerator enumerator = allAnimControls.GetEnumerator();
						while (enumerator.MoveNext())
						{
							MyPageLeft._Closure$__7-0 CS$<>8__locals1 = new MyPageLeft._Closure$__7-0(CS$<>8__locals1);
							CS$<>8__locals1.$VB$Me = this;
							CS$<>8__locals1.$VB$Local_Element = enumerator.Current;
							CS$<>8__locals1.$VB$Local_Element.Opacity = 0.0;
							CS$<>8__locals1.$VB$Local_Element.RenderTransform = new TranslateTransform(-25.0, 0.0);
							list.Add(ModAni.AaOpacity(CS$<>8__locals1.$VB$Local_Element, (CS$<>8__locals1.$VB$Local_Element is TextBlock) ? 0.6 : 1.0, 0xC8, num2, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false));
							list.Add(ModAni.AaTranslateX(CS$<>8__locals1.$VB$Local_Element, 5.0, 0xC8, num2, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false));
							list.Add(ModAni.AaTranslateX(CS$<>8__locals1.$VB$Local_Element, 20.0, 0x12C, num2, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Weak), false));
							if (CS$<>8__locals1.$VB$Local_Element is MyListItem)
							{
								list.Add(ModAni.AaCode(delegate
								{
									((MyListItem)CS$<>8__locals1.$VB$Local_Element).m_AlgoDecorator = true;
									((MyListItem)CS$<>8__locals1.$VB$Local_Element).RefreshColor(CS$<>8__locals1.$VB$Me, new EventArgs());
								}, num2 + 0x118, false));
							}
							num2 = (int)Math.Round(unchecked((double)num2 + (double)Math.Max(8, checked(0x14 - num)) * 2.5));
							num++;
						}
					}
					finally
					{
						List<FrameworkElement>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					ModAni.AniStart(list, "GridPage PageChange " + Conversions.ToString(this._Field), false);
				}), false);
			}, "GridPage Wait", ThreadPriority.Normal);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000116EC File Offset: 0x0000F8EC
		public void TriggerHideAnimation()
		{
			if (this.AnimatedControl == null)
			{
				if (!(base.RenderTransform is ScaleTransform))
				{
					base.RenderTransform = new ScaleTransform(1.0, 1.0);
					base.RenderTransformOrigin = new Point(0.5, 0.5);
				}
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaScaleTransform(this, 0.97 - ((ScaleTransform)base.RenderTransform).ScaleX, 0x64, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Weak), false),
					ModAni.AaOpacity(this, -base.Opacity, 0x50, 0x14, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false)
				}, "GridPage PageChange " + Conversions.ToString(this._Field), false);
				return;
			}
			List<ModAni.AniData> list = new List<ModAni.AniData>();
			int num = 0;
			List<FrameworkElement> allAnimControls = this.GetAllAnimControls();
			checked
			{
				try
				{
					foreach (FrameworkElement frameworkElement in allAnimControls)
					{
						list.Add(ModAni.AaOpacity(frameworkElement, unchecked(-frameworkElement.Opacity), 0x3C, (int)Math.Round(unchecked(70.0 / (double)allAnimControls.Count * (double)num)), null, false));
						list.Add(ModAni.AaTranslateX(frameworkElement, -6.0, 0x3C, (int)Math.Round(unchecked(70.0 / (double)allAnimControls.Count * (double)num)), null, false));
						num++;
					}
				}
				finally
				{
					List<FrameworkElement>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				ModAni.AniStart(list, "GridPage PageChange " + Conversions.ToString(this._Field), false);
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00011890 File Offset: 0x0000FA90
		private List<FrameworkElement> GetAllAnimControls()
		{
			List<FrameworkElement> result = new List<FrameworkElement>();
			this.GetAllAnimControls(this.AnimatedControl, ref result);
			return result;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000118B4 File Offset: 0x0000FAB4
		private void GetAllAnimControls(FrameworkElement Element, ref List<FrameworkElement> AllControls)
		{
			if (Element.Visibility != Visibility.Collapsed)
			{
				if (Element is MyListItem)
				{
					((MyListItem)Element).m_AlgoDecorator = false;
					AllControls.Add(Element);
					return;
				}
				if (Element is ContentControl)
				{
					this.GetAllAnimControls((FrameworkElement)((ContentControl)Element).Content, ref AllControls);
					return;
				}
				if (Element is Panel)
				{
					try
					{
						foreach (object obj in ((Panel)Element).Children)
						{
							FrameworkElement element = (FrameworkElement)obj;
							this.GetAllAnimControls(element, ref AllControls);
						}
						return;
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
				AllControls.Add(Element);
			}
		}

		// Token: 0x04000085 RID: 133
		private int _Field;

		// Token: 0x04000086 RID: 134
		public static readonly DependencyProperty status;
	}
}
