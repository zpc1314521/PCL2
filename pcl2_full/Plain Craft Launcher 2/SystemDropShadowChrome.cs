using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PCL
{
	// Token: 0x020000B4 RID: 180
	public sealed class SystemDropShadowChrome : Decorator
	{
		// Token: 0x06000738 RID: 1848 RVA: 0x000345D8 File Offset: 0x000327D8
		// Note: this type is marked as 'beforefieldinit'.
		static SystemDropShadowChrome()
		{
			SystemDropShadowChrome.m_HelperModel = DependencyProperty.Register("Color", typeof(Color), typeof(SystemDropShadowChrome), new FrameworkPropertyMetadata(Color.FromArgb(0x71, 0, 0, 0), FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(SystemDropShadowChrome.ClearBrushes)));
			SystemDropShadowChrome.m_ConsumerModel = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(SystemDropShadowChrome), new FrameworkPropertyMetadata(default(CornerRadius), FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(SystemDropShadowChrome.ClearBrushes)), new ValidateValueCallback(SystemDropShadowChrome.IsCornerRadiusValid));
			SystemDropShadowChrome.exceptionModel = RuntimeHelpers.GetObjectValue(new object());
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x0600073A RID: 1850 RVA: 0x0003468C File Offset: 0x0003288C
		// (set) Token: 0x0600073B RID: 1851 RVA: 0x0000621B File Offset: 0x0000441B
		public Color Color
		{
			get
			{
				object value = base.GetValue(SystemDropShadowChrome.m_HelperModel);
				if (value == null)
				{
					return default(Color);
				}
				return (Color)value;
			}
			set
			{
				base.SetValue(SystemDropShadowChrome.m_HelperModel, value);
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x0600073C RID: 1852 RVA: 0x000346B8 File Offset: 0x000328B8
		// (set) Token: 0x0600073D RID: 1853 RVA: 0x0000622E File Offset: 0x0000442E
		public CornerRadius CornerRadius
		{
			get
			{
				object value = base.GetValue(SystemDropShadowChrome.m_ConsumerModel);
				if (value == null)
				{
					return default(CornerRadius);
				}
				return (CornerRadius)value;
			}
			set
			{
				base.SetValue(SystemDropShadowChrome.m_ConsumerModel, value);
			}
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x000346E4 File Offset: 0x000328E4
		private static bool IsCornerRadiusValid(object value)
		{
			CornerRadius cornerRadius = (value != null) ? ((CornerRadius)value) : default(CornerRadius);
			return cornerRadius.TopLeft >= 0.0 && cornerRadius.TopRight >= 0.0 && cornerRadius.BottomLeft >= 0.0 && cornerRadius.BottomRight >= 0.0 && !double.IsNaN(cornerRadius.TopLeft) && !double.IsNaN(cornerRadius.TopRight) && !double.IsNaN(cornerRadius.BottomLeft) && !double.IsNaN(cornerRadius.BottomRight) && !double.IsInfinity(cornerRadius.TopLeft) && !double.IsInfinity(cornerRadius.TopRight) && !double.IsInfinity(cornerRadius.BottomLeft) && !double.IsInfinity(cornerRadius.BottomRight);
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x000347CC File Offset: 0x000329CC
		protected override void OnRender(DrawingContext drawingContext)
		{
			CornerRadius cornerRadius = this.CornerRadius;
			Rect rect = new Rect(new Point(5.0, 5.0), new Size(base.RenderSize.Width, base.RenderSize.Height));
			Color color = this.Color;
			if (rect.Width > 0.0 && rect.Height > 0.0 && color.A > 0)
			{
				double num = rect.Right - rect.Left - 10.0;
				double num2 = rect.Bottom - rect.Top - 10.0;
				double val = Math.Min(num * 0.5, num2 * 0.5);
				cornerRadius.TopLeft = Math.Min(cornerRadius.TopLeft, val);
				cornerRadius.TopRight = Math.Min(cornerRadius.TopRight, val);
				cornerRadius.BottomLeft = Math.Min(cornerRadius.BottomLeft, val);
				cornerRadius.BottomRight = Math.Min(cornerRadius.BottomRight, val);
				Brush[] brushes = this.GetBrushes(color, cornerRadius);
				double num3 = rect.Top + 5.0;
				double num4 = rect.Left + 5.0;
				double num5 = rect.Right - 5.0;
				double num6 = rect.Bottom - 5.0;
				double[] array = new double[]
				{
					num4,
					num4 + cornerRadius.TopLeft,
					num5 - cornerRadius.TopRight,
					num4 + cornerRadius.BottomLeft,
					num5 - cornerRadius.BottomRight,
					num5
				};
				double[] array2 = new double[]
				{
					num3,
					num3 + cornerRadius.TopLeft,
					num3 + cornerRadius.TopRight,
					num6 - cornerRadius.BottomLeft,
					num6 - cornerRadius.BottomRight,
					num6
				};
				drawingContext.PushGuidelineSet(new GuidelineSet(array, array2));
				cornerRadius.TopLeft += 5.0;
				cornerRadius.TopRight += 5.0;
				cornerRadius.BottomLeft += 5.0;
				cornerRadius.BottomRight += 5.0;
				Rect rectangle = new Rect(rect.Left, rect.Top, cornerRadius.TopLeft, cornerRadius.TopLeft);
				drawingContext.DrawRectangle(brushes[0], null, rectangle);
				double num7 = array[2] - array[1];
				if (num7 > 0.0)
				{
					Rect rectangle2 = new Rect(array[1], rect.Top, num7, 5.0);
					drawingContext.DrawRectangle(brushes[1], null, rectangle2);
				}
				Rect rectangle3 = new Rect(array[2], rect.Top, cornerRadius.TopRight, cornerRadius.TopRight);
				drawingContext.DrawRectangle(brushes[2], null, rectangle3);
				double num8 = array2[3] - array2[1];
				if (num8 > 0.0)
				{
					Rect rectangle4 = new Rect(rect.Left, array2[1], 5.0, num8);
					drawingContext.DrawRectangle(brushes[3], null, rectangle4);
				}
				double num9 = array2[4] - array2[2];
				if (num9 > 0.0)
				{
					Rect rectangle5 = new Rect(array[5], array2[2], 5.0, num9);
					drawingContext.DrawRectangle(brushes[5], null, rectangle5);
				}
				Rect rectangle6 = new Rect(rect.Left, array2[3], cornerRadius.BottomLeft, cornerRadius.BottomLeft);
				drawingContext.DrawRectangle(brushes[6], null, rectangle6);
				double num10 = array[4] - array[3];
				if (num10 > 0.0)
				{
					Rect rectangle7 = new Rect(array[3], array2[5], num10, 5.0);
					drawingContext.DrawRectangle(brushes[7], null, rectangle7);
				}
				Rect rectangle8 = new Rect(array[4], array2[4], cornerRadius.BottomRight, cornerRadius.BottomRight);
				drawingContext.DrawRectangle(brushes[8], null, rectangle8);
				if (cornerRadius.TopLeft == 5.0 && cornerRadius.TopLeft == cornerRadius.TopRight && cornerRadius.TopLeft == cornerRadius.BottomLeft && cornerRadius.TopLeft == cornerRadius.BottomRight)
				{
					Rect rectangle9 = new Rect(array[0], array2[0], num, num2);
					drawingContext.DrawRectangle(brushes[4], null, rectangle9);
				}
				else
				{
					PathFigure pathFigure = new PathFigure();
					if (cornerRadius.TopLeft > 5.0)
					{
						pathFigure.StartPoint = new Point(array[1], array2[0]);
						pathFigure.Segments.Add(new LineSegment(new Point(array[1], array2[1]), true));
						pathFigure.Segments.Add(new LineSegment(new Point(array[0], array2[1]), true));
					}
					else
					{
						pathFigure.StartPoint = new Point(array[0], array2[0]);
					}
					if (cornerRadius.BottomLeft > 5.0)
					{
						pathFigure.Segments.Add(new LineSegment(new Point(array[0], array2[3]), true));
						pathFigure.Segments.Add(new LineSegment(new Point(array[3], array2[3]), true));
						pathFigure.Segments.Add(new LineSegment(new Point(array[3], array2[5]), true));
					}
					else
					{
						pathFigure.Segments.Add(new LineSegment(new Point(array[0], array2[5]), true));
					}
					if (cornerRadius.BottomRight > 5.0)
					{
						pathFigure.Segments.Add(new LineSegment(new Point(array[4], array2[5]), true));
						pathFigure.Segments.Add(new LineSegment(new Point(array[4], array2[4]), true));
						pathFigure.Segments.Add(new LineSegment(new Point(array[5], array2[4]), true));
					}
					else
					{
						pathFigure.Segments.Add(new LineSegment(new Point(array[5], array2[5]), true));
					}
					if (cornerRadius.TopRight > 5.0)
					{
						pathFigure.Segments.Add(new LineSegment(new Point(array[5], array2[2]), true));
						pathFigure.Segments.Add(new LineSegment(new Point(array[2], array2[2]), true));
						pathFigure.Segments.Add(new LineSegment(new Point(array[2], array2[0]), true));
					}
					else
					{
						pathFigure.Segments.Add(new LineSegment(new Point(array[5], array2[0]), true));
					}
					pathFigure.IsClosed = true;
					pathFigure.Freeze();
					PathGeometry pathGeometry = new PathGeometry();
					pathGeometry.Figures.Add(pathFigure);
					pathGeometry.Freeze();
					drawingContext.DrawGeometry(brushes[4], null, pathGeometry);
				}
				drawingContext.Pop();
			}
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00006241 File Offset: 0x00004441
		private static void ClearBrushes(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			((SystemDropShadowChrome)o)._RulesModel = null;
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00034EE4 File Offset: 0x000330E4
		private static GradientStopCollection CreateStops(Color c, double cornerRadius)
		{
			double num = 1.0 / (cornerRadius + 5.0);
			GradientStopCollection gradientStopCollection = new GradientStopCollection();
			gradientStopCollection.Add(new GradientStop(c, (0.5 + cornerRadius) * num));
			Color color = c;
			color.A = checked((byte)Math.Round(unchecked(0.74336 * (double)c.A)));
			gradientStopCollection.Add(new GradientStop(color, (1.5 + cornerRadius) * num));
			color.A = checked((byte)Math.Round(unchecked(0.38053 * (double)c.A)));
			gradientStopCollection.Add(new GradientStop(color, (2.5 + cornerRadius) * num));
			color.A = checked((byte)Math.Round(unchecked(0.12389 * (double)c.A)));
			gradientStopCollection.Add(new GradientStop(color, (3.5 + cornerRadius) * num));
			color.A = checked((byte)Math.Round(unchecked(0.02654 * (double)c.A)));
			gradientStopCollection.Add(new GradientStop(color, (4.5 + cornerRadius) * num));
			color.A = 0;
			gradientStopCollection.Add(new GradientStop(color, (5.0 + cornerRadius) * num));
			gradientStopCollection.Freeze();
			return gradientStopCollection;
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x00035030 File Offset: 0x00033230
		private static Brush[] CreateBrushes(Color c, CornerRadius cornerRadius)
		{
			Brush[] array = new Brush[9];
			array[4] = new SolidColorBrush(c);
			array[4].Freeze();
			GradientStopCollection gradientStopCollection = SystemDropShadowChrome.CreateStops(c, 0.0);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(gradientStopCollection, new Point(0.0, 1.0), new Point(0.0, 0.0));
			linearGradientBrush.Freeze();
			array[1] = linearGradientBrush;
			LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(gradientStopCollection, new Point(1.0, 0.0), new Point(0.0, 0.0));
			linearGradientBrush2.Freeze();
			array[3] = linearGradientBrush2;
			LinearGradientBrush linearGradientBrush3 = new LinearGradientBrush(gradientStopCollection, new Point(0.0, 0.0), new Point(1.0, 0.0));
			linearGradientBrush3.Freeze();
			array[5] = linearGradientBrush3;
			LinearGradientBrush linearGradientBrush4 = new LinearGradientBrush(gradientStopCollection, new Point(0.0, 0.0), new Point(0.0, 1.0));
			linearGradientBrush4.Freeze();
			array[7] = linearGradientBrush4;
			GradientStopCollection gradientStopCollection2;
			if (cornerRadius.TopLeft == 0.0)
			{
				gradientStopCollection2 = gradientStopCollection;
			}
			else
			{
				gradientStopCollection2 = SystemDropShadowChrome.CreateStops(c, cornerRadius.TopLeft);
			}
			RadialGradientBrush radialGradientBrush = new RadialGradientBrush(gradientStopCollection2)
			{
				RadiusX = 1.0,
				RadiusY = 1.0,
				Center = new Point(1.0, 1.0),
				GradientOrigin = new Point(1.0, 1.0)
			};
			radialGradientBrush.Freeze();
			array[0] = radialGradientBrush;
			GradientStopCollection gradientStopCollection3;
			if (cornerRadius.TopRight == 0.0)
			{
				gradientStopCollection3 = gradientStopCollection;
			}
			else if (cornerRadius.TopRight == cornerRadius.TopLeft)
			{
				gradientStopCollection3 = gradientStopCollection2;
			}
			else
			{
				gradientStopCollection3 = SystemDropShadowChrome.CreateStops(c, cornerRadius.TopRight);
			}
			RadialGradientBrush radialGradientBrush2 = new RadialGradientBrush(gradientStopCollection3)
			{
				RadiusX = 1.0,
				RadiusY = 1.0,
				Center = new Point(0.0, 1.0),
				GradientOrigin = new Point(0.0, 1.0)
			};
			radialGradientBrush2.Freeze();
			array[2] = radialGradientBrush2;
			GradientStopCollection gradientStopCollection4;
			if (cornerRadius.BottomLeft == 0.0)
			{
				gradientStopCollection4 = gradientStopCollection;
			}
			else if (cornerRadius.BottomLeft == cornerRadius.TopLeft)
			{
				gradientStopCollection4 = gradientStopCollection2;
			}
			else if (cornerRadius.BottomLeft == cornerRadius.TopRight)
			{
				gradientStopCollection4 = gradientStopCollection3;
			}
			else
			{
				gradientStopCollection4 = SystemDropShadowChrome.CreateStops(c, cornerRadius.BottomLeft);
			}
			RadialGradientBrush radialGradientBrush3 = new RadialGradientBrush(gradientStopCollection4)
			{
				RadiusX = 1.0,
				RadiusY = 1.0,
				Center = new Point(1.0, 0.0),
				GradientOrigin = new Point(1.0, 0.0)
			};
			radialGradientBrush3.Freeze();
			array[6] = radialGradientBrush3;
			GradientStopCollection gradientStopCollection5;
			if (cornerRadius.BottomRight == 0.0)
			{
				gradientStopCollection5 = gradientStopCollection;
			}
			else if (cornerRadius.BottomRight == cornerRadius.TopLeft)
			{
				gradientStopCollection5 = gradientStopCollection2;
			}
			else if (cornerRadius.BottomRight == cornerRadius.TopRight)
			{
				gradientStopCollection5 = gradientStopCollection3;
			}
			else if (cornerRadius.BottomRight == cornerRadius.BottomLeft)
			{
				gradientStopCollection5 = gradientStopCollection4;
			}
			else
			{
				gradientStopCollection5 = SystemDropShadowChrome.CreateStops(c, cornerRadius.BottomRight);
			}
			RadialGradientBrush radialGradientBrush4 = new RadialGradientBrush(gradientStopCollection5)
			{
				RadiusX = 1.0,
				RadiusY = 1.0,
				Center = new Point(0.0, 0.0),
				GradientOrigin = new Point(0.0, 0.0)
			};
			radialGradientBrush4.Freeze();
			array[8] = radialGradientBrush4;
			return array;
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x00035434 File Offset: 0x00033634
		private Brush[] GetBrushes(Color c, CornerRadius cornerRadius)
		{
			if (SystemDropShadowChrome.m_QueueModel == null)
			{
				object obj = SystemDropShadowChrome.exceptionModel;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				lock (obj)
				{
					if (SystemDropShadowChrome.m_QueueModel == null)
					{
						SystemDropShadowChrome.m_QueueModel = SystemDropShadowChrome.CreateBrushes(c, cornerRadius);
						SystemDropShadowChrome.producerModel = cornerRadius;
					}
				}
			}
			Brush[] result;
			if (c == ((SolidColorBrush)SystemDropShadowChrome.m_QueueModel[4]).Color && cornerRadius == SystemDropShadowChrome.producerModel)
			{
				this._RulesModel = null;
				result = SystemDropShadowChrome.m_QueueModel;
			}
			else
			{
				if (this._RulesModel == null)
				{
					this._RulesModel = SystemDropShadowChrome.CreateBrushes(c, cornerRadius);
				}
				result = this._RulesModel;
			}
			return result;
		}

		// Token: 0x04000360 RID: 864
		public static readonly DependencyProperty m_HelperModel;

		// Token: 0x04000361 RID: 865
		public static readonly DependencyProperty m_ConsumerModel;

		// Token: 0x04000362 RID: 866
		private const double ShadowDepth = 5.0;

		// Token: 0x04000363 RID: 867
		private static Brush[] m_QueueModel;

		// Token: 0x04000364 RID: 868
		private static CornerRadius producerModel;

		// Token: 0x04000365 RID: 869
		private static readonly object exceptionModel;

		// Token: 0x04000366 RID: 870
		private Brush[] _RulesModel;

		// Token: 0x020000B5 RID: 181
		private enum Placement
		{
			// Token: 0x04000368 RID: 872
			TopLeft,
			// Token: 0x04000369 RID: 873
			Top,
			// Token: 0x0400036A RID: 874
			TopRight,
			// Token: 0x0400036B RID: 875
			Left,
			// Token: 0x0400036C RID: 876
			Center,
			// Token: 0x0400036D RID: 877
			Right,
			// Token: 0x0400036E RID: 878
			BottomLeft,
			// Token: 0x0400036F RID: 879
			Bottom,
			// Token: 0x04000370 RID: 880
			BottomRight
		}
	}
}
