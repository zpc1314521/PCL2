using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;

namespace PCL
{
	// Token: 0x02000176 RID: 374
	public class MyResizer
	{
		// Token: 0x06001072 RID: 4210 RVA: 0x0000A85D File Offset: 0x00008A5D
		// Note: this type is marked as 'beforefieldinit'.
		static MyResizer()
		{
			MyResizer._TestDecorator = -1;
		}

		// Token: 0x06001073 RID: 4211 RVA: 0x00077A6C File Offset: 0x00075C6C
		public MyResizer(Window target)
		{
			this._ContextDecorator = null;
			this.observerDecorator = false;
			this.tokenizerDecorator = false;
			this.m_DispatcherDecorator = false;
			this.m_TagDecorator = false;
			this.initializerDecorator = new Dictionary<UIElement, short>();
			this._PropertyDecorator = new Dictionary<UIElement, short>();
			this._WatcherDecorator = new Dictionary<UIElement, short>();
			this._StateDecorator = new Dictionary<UIElement, short>();
			this._CreatorDecorator = default(MyResizer.PointAPI);
			this._PageDecorator = default(Size);
			this.m_InstanceDecorator = default(MyResizer.POINT);
			this._ContextDecorator = target;
			if (Information.IsNothing(target))
			{
				throw new Exception("Invalid Window handle");
			}
			target.SourceInitialized += this.MyMacClass_SourceInitialized;
		}

		// Token: 0x06001074 RID: 4212 RVA: 0x0000A865 File Offset: 0x00008A65
		private void MyMacClass_SourceInitialized(object sender, EventArgs e)
		{
			this.customerDecorator = (PresentationSource.FromVisual((Visual)sender) as HwndSource);
			this.customerDecorator.AddHook(new HwndSourceHook(this.WndProc));
		}

		// Token: 0x06001075 RID: 4213 RVA: 0x0000A894 File Offset: 0x00008A94
		private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			if (msg == 0x24)
			{
				MyResizer.WmGetMinMaxInfo(hwnd, lParam);
				handled = true;
			}
			return (IntPtr)0;
		}

		// Token: 0x06001076 RID: 4214 RVA: 0x00077B20 File Offset: 0x00075D20
		private static void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
		{
			object obj = Marshal.PtrToStructure(lParam, typeof(MyResizer.MINMAXINFO));
			MyResizer.MINMAXINFO minmaxinfo = (obj != null) ? ((MyResizer.MINMAXINFO)obj) : default(MyResizer.MINMAXINFO);
			IntPtr intPtr = MyResizer.MonitorFromWindow(hwnd, 2);
			checked
			{
				if (intPtr != IntPtr.Zero)
				{
					MyResizer.MONITORINFO monitorinfo = new MyResizer.MONITORINFO();
					MyResizer.GetMonitorInfo(intPtr, monitorinfo);
					MyResizer.RECT collectionMapper = monitorinfo.collectionMapper;
					MyResizer.RECT resolverMapper = monitorinfo.m_ResolverMapper;
					minmaxinfo._PrototypeMapper._InfoMapper = Math.Abs(collectionMapper.stubMapper - resolverMapper.stubMapper);
					minmaxinfo._PrototypeMapper.repositoryMapper = Math.Abs(collectionMapper.m_AccountMapper - resolverMapper.m_AccountMapper);
					minmaxinfo._ProccesorMapper.repositoryMapper = Math.Abs(collectionMapper.m_InterpreterMapper - collectionMapper.m_AccountMapper);
					MyResizer._TestDecorator = minmaxinfo._ProccesorMapper.repositoryMapper;
					if (collectionMapper.Height == resolverMapper.Height)
					{
						ref int ptr = ref minmaxinfo._ProccesorMapper.repositoryMapper;
						minmaxinfo._ProccesorMapper.repositoryMapper = ptr - 2;
					}
				}
				Marshal.StructureToPtr(minmaxinfo, lParam, true);
			}
		}

		// Token: 0x06001077 RID: 4215
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern bool GetMonitorInfo(IntPtr hMonitor, MyResizer.MONITORINFO lpmi);

		// Token: 0x06001078 RID: 4216
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);

		// Token: 0x06001079 RID: 4217 RVA: 0x0000A8AD File Offset: 0x00008AAD
		private void connectMouseHandlers(UIElement element)
		{
			element.MouseLeftButtonDown += this.element_MouseLeftButtonDown;
		}

		// Token: 0x0600107A RID: 4218 RVA: 0x0000A8C1 File Offset: 0x00008AC1
		public void addResizerRight(UIElement element)
		{
			this.connectMouseHandlers(element);
			this._PropertyDecorator.Add(element, 0);
		}

		// Token: 0x0600107B RID: 4219 RVA: 0x0000A8D7 File Offset: 0x00008AD7
		public void addResizerLeft(UIElement element)
		{
			this.connectMouseHandlers(element);
			this.initializerDecorator.Add(element, 0);
		}

		// Token: 0x0600107C RID: 4220 RVA: 0x0000A8ED File Offset: 0x00008AED
		public void addResizerUp(UIElement element)
		{
			this.connectMouseHandlers(element);
			this._WatcherDecorator.Add(element, 0);
		}

		// Token: 0x0600107D RID: 4221 RVA: 0x0000A903 File Offset: 0x00008B03
		public void addResizerDown(UIElement element)
		{
			this.connectMouseHandlers(element);
			this._StateDecorator.Add(element, 0);
		}

		// Token: 0x0600107E RID: 4222 RVA: 0x0000A919 File Offset: 0x00008B19
		public void addResizerRightDown(UIElement element)
		{
			this.connectMouseHandlers(element);
			this._PropertyDecorator.Add(element, 0);
			this._StateDecorator.Add(element, 0);
		}

		// Token: 0x0600107F RID: 4223 RVA: 0x0000A93C File Offset: 0x00008B3C
		public void addResizerLeftDown(UIElement element)
		{
			this.connectMouseHandlers(element);
			this.initializerDecorator.Add(element, 0);
			this._StateDecorator.Add(element, 0);
		}

		// Token: 0x06001080 RID: 4224 RVA: 0x0000A95F File Offset: 0x00008B5F
		public void addResizerRightUp(UIElement element)
		{
			this.connectMouseHandlers(element);
			this._PropertyDecorator.Add(element, 0);
			this._WatcherDecorator.Add(element, 0);
		}

		// Token: 0x06001081 RID: 4225 RVA: 0x0000A982 File Offset: 0x00008B82
		public void addResizerLeftUp(UIElement element)
		{
			this.connectMouseHandlers(element);
			this.initializerDecorator.Add(element, 0);
			this._WatcherDecorator.Add(element, 0);
		}

		// Token: 0x06001082 RID: 4226 RVA: 0x00077C2C File Offset: 0x00075E2C
		private void element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			MyResizer.GetCursorPos(out this._CreatorDecorator);
			checked
			{
				this._CreatorDecorator.X = (int)Math.Round(ModBase.smethod_4((double)this._CreatorDecorator.X));
				this._CreatorDecorator.m_BroadcasterMapper = (int)Math.Round(ModBase.smethod_4((double)this._CreatorDecorator.m_BroadcasterMapper));
				this._PageDecorator = new Size(this._ContextDecorator.Width, this._ContextDecorator.Height);
				this.m_InstanceDecorator = new MyResizer.POINT((int)Math.Round(this._ContextDecorator.Left), (int)Math.Round(this._ContextDecorator.Top));
				UIElement key = (UIElement)sender;
				if (this.initializerDecorator.ContainsKey(key))
				{
					this.tokenizerDecorator = true;
				}
				if (this._PropertyDecorator.ContainsKey(key))
				{
					this.observerDecorator = true;
				}
				if (this._WatcherDecorator.ContainsKey(key))
				{
					this.m_DispatcherDecorator = true;
				}
				if (this._StateDecorator.ContainsKey(key))
				{
					this.m_TagDecorator = true;
				}
				ModBase.RunInNewThread(new ThreadStart(this.updateSizeLoop), "窗口大小调整检测", ThreadPriority.Normal);
			}
		}

		// Token: 0x06001083 RID: 4227 RVA: 0x00077D4C File Offset: 0x00075F4C
		private void updateSizeLoop()
		{
			try
			{
				while (this.m_TagDecorator || this.tokenizerDecorator || this.observerDecorator || this.m_DispatcherDecorator)
				{
					this._ContextDecorator.Dispatcher.Invoke(new Action(this.updateSize), DispatcherPriority.Render);
					this._ContextDecorator.Dispatcher.Invoke(new Action(this.updateMouseDown), DispatcherPriority.Render);
					Thread.Sleep(0);
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06001084 RID: 4228 RVA: 0x00077DE0 File Offset: 0x00075FE0
		private void updateSize()
		{
			MyResizer.PointAPI pointAPI = default(MyResizer.PointAPI);
			MyResizer.GetCursorPos(out pointAPI);
			checked
			{
				pointAPI.X = (int)Math.Round(ModBase.smethod_4((double)pointAPI.X));
				pointAPI.m_BroadcasterMapper = (int)Math.Round(ModBase.smethod_4((double)pointAPI.m_BroadcasterMapper));
			}
			try
			{
				double num = -1.0;
				double num2 = -1.0;
				double num3 = -10000.0;
				double num4 = -10000.0;
				if (this.observerDecorator)
				{
					if (this._ContextDecorator.Width == this._ContextDecorator.MinWidth)
					{
						if (this._CreatorDecorator.X < pointAPI.X)
						{
							num = this._PageDecorator.Width - (double)(checked(this._CreatorDecorator.X - pointAPI.X));
						}
					}
					else if (this._PageDecorator.Width - (double)(checked(this._CreatorDecorator.X - pointAPI.X)) >= this._ContextDecorator.MinWidth)
					{
						num = this._PageDecorator.Width - (double)(checked(this._CreatorDecorator.X - pointAPI.X));
					}
					else
					{
						num = this._ContextDecorator.MinWidth;
					}
				}
				if (this.m_TagDecorator)
				{
					if (this._ContextDecorator.Height == this._ContextDecorator.MinHeight)
					{
						if (this._CreatorDecorator.m_BroadcasterMapper < pointAPI.m_BroadcasterMapper)
						{
							if (MyResizer._TestDecorator > 0)
							{
								num2 = ((this._PageDecorator.Height - (double)(checked(this._CreatorDecorator.m_BroadcasterMapper - pointAPI.m_BroadcasterMapper)) + this._ContextDecorator.Top <= (double)MyResizer._TestDecorator) ? (this._PageDecorator.Height - (double)(checked(this._CreatorDecorator.m_BroadcasterMapper - pointAPI.m_BroadcasterMapper))) : ((double)MyResizer._TestDecorator - this._ContextDecorator.Top));
							}
							else
							{
								num2 = this._PageDecorator.Height - (double)(checked(this._CreatorDecorator.m_BroadcasterMapper - pointAPI.m_BroadcasterMapper));
							}
						}
					}
					else if (this._PageDecorator.Height - (double)(checked(this._CreatorDecorator.m_BroadcasterMapper - pointAPI.m_BroadcasterMapper)) >= this._ContextDecorator.MinHeight)
					{
						if (MyResizer._TestDecorator > 0)
						{
							num2 = ((this._PageDecorator.Height - (double)(checked(this._CreatorDecorator.m_BroadcasterMapper - pointAPI.m_BroadcasterMapper)) + this._ContextDecorator.Top <= (double)MyResizer._TestDecorator) ? (this._PageDecorator.Height - (double)(checked(this._CreatorDecorator.m_BroadcasterMapper - pointAPI.m_BroadcasterMapper))) : ((double)MyResizer._TestDecorator - this._ContextDecorator.Top));
						}
						else
						{
							num2 = this._PageDecorator.Height - (double)(checked(this._CreatorDecorator.m_BroadcasterMapper - pointAPI.m_BroadcasterMapper));
						}
					}
					else
					{
						num2 = this._ContextDecorator.MinHeight;
					}
				}
				if (this.tokenizerDecorator)
				{
					if (this._ContextDecorator.Width == this._ContextDecorator.MinWidth)
					{
						if (this._CreatorDecorator.X > pointAPI.X)
						{
							num = this._PageDecorator.Width + (double)this._CreatorDecorator.X - (double)pointAPI.X;
							num3 = (double)(checked(this.m_InstanceDecorator._InfoMapper - (this._CreatorDecorator.X - pointAPI.X)));
						}
						else
						{
							num = this._ContextDecorator.MinWidth;
							num3 = (double)this.m_InstanceDecorator._InfoMapper + this._PageDecorator.Width - this._ContextDecorator.Width;
						}
					}
					else if (this._PageDecorator.Width + (double)(checked(this._CreatorDecorator.X - pointAPI.X)) >= this._ContextDecorator.MinWidth)
					{
						num = this._PageDecorator.Width + (double)(checked(this._CreatorDecorator.X - pointAPI.X));
						num3 = (double)(checked(this.m_InstanceDecorator._InfoMapper - (this._CreatorDecorator.X - pointAPI.X)));
					}
					else
					{
						num = this._ContextDecorator.MinWidth;
						num3 = (double)this.m_InstanceDecorator._InfoMapper + this._PageDecorator.Width - this._ContextDecorator.Width;
					}
				}
				if (this.m_DispatcherDecorator)
				{
					if (this._ContextDecorator.Height == this._ContextDecorator.MinHeight)
					{
						if (this._CreatorDecorator.m_BroadcasterMapper > pointAPI.m_BroadcasterMapper)
						{
							num2 = this._PageDecorator.Height + (double)this._CreatorDecorator.m_BroadcasterMapper - (double)pointAPI.m_BroadcasterMapper;
							num4 = (double)(checked(this.m_InstanceDecorator.repositoryMapper - (this._CreatorDecorator.m_BroadcasterMapper - pointAPI.m_BroadcasterMapper)));
						}
						else
						{
							num2 = this._ContextDecorator.MinHeight;
							num4 = (double)this.m_InstanceDecorator.repositoryMapper + this._PageDecorator.Height - this._ContextDecorator.Height;
						}
					}
					else if (this._PageDecorator.Height + (double)(checked(this._CreatorDecorator.m_BroadcasterMapper - pointAPI.m_BroadcasterMapper)) >= this._ContextDecorator.MinHeight)
					{
						num2 = this._PageDecorator.Height + (double)this._CreatorDecorator.m_BroadcasterMapper - (double)pointAPI.m_BroadcasterMapper;
						num4 = (double)(checked(this.m_InstanceDecorator.repositoryMapper - (this._CreatorDecorator.m_BroadcasterMapper - pointAPI.m_BroadcasterMapper)));
					}
					else
					{
						num2 = this._ContextDecorator.MinHeight;
						num4 = (double)this.m_InstanceDecorator.repositoryMapper + this._PageDecorator.Height - this._ContextDecorator.Height;
					}
				}
				if (num > 10.0 && Math.Abs(num - this._ContextDecorator.Width) > 0.7)
				{
					this._ContextDecorator.Width = num;
				}
				if (num2 > 10.0 && Math.Abs(num2 - this._ContextDecorator.Height) > 0.7)
				{
					this._ContextDecorator.Height = num2;
				}
				if (num3 > -9999.0 && Math.Abs(num3 - this._ContextDecorator.Left) > 0.7)
				{
					this._ContextDecorator.Left = num3;
				}
				if (num4 > -9999.0 && Math.Abs(num4 - this._ContextDecorator.Top) > 0.7)
				{
					this._ContextDecorator.Top = num4;
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06001085 RID: 4229 RVA: 0x0000A9A5 File Offset: 0x00008BA5
		private void updateMouseDown()
		{
			if (Mouse.LeftButton == MouseButtonState.Released)
			{
				this.observerDecorator = false;
				this.tokenizerDecorator = false;
				this.m_DispatcherDecorator = false;
				this.m_TagDecorator = false;
			}
		}

		// Token: 0x06001086 RID: 4230
		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern bool GetCursorPos(out MyResizer.PointAPI lpPoint);

		// Token: 0x04000886 RID: 2182
		private readonly Window _ContextDecorator;

		// Token: 0x04000887 RID: 2183
		private bool observerDecorator;

		// Token: 0x04000888 RID: 2184
		private bool tokenizerDecorator;

		// Token: 0x04000889 RID: 2185
		private bool m_DispatcherDecorator;

		// Token: 0x0400088A RID: 2186
		private bool m_TagDecorator;

		// Token: 0x0400088B RID: 2187
		private readonly Dictionary<UIElement, short> initializerDecorator;

		// Token: 0x0400088C RID: 2188
		private readonly Dictionary<UIElement, short> _PropertyDecorator;

		// Token: 0x0400088D RID: 2189
		private readonly Dictionary<UIElement, short> _WatcherDecorator;

		// Token: 0x0400088E RID: 2190
		private readonly Dictionary<UIElement, short> _StateDecorator;

		// Token: 0x0400088F RID: 2191
		private MyResizer.PointAPI _CreatorDecorator;

		// Token: 0x04000890 RID: 2192
		private Size _PageDecorator;

		// Token: 0x04000891 RID: 2193
		private MyResizer.POINT m_InstanceDecorator;

		// Token: 0x04000892 RID: 2194
		private static int _TestDecorator;

		// Token: 0x04000893 RID: 2195
		private HwndSource customerDecorator;

		// Token: 0x02000177 RID: 375
		// (Invoke) Token: 0x0600108A RID: 4234
		private delegate void RefreshDelegate();

		// Token: 0x02000178 RID: 376
		private struct POINT
		{
			// Token: 0x0600108B RID: 4235 RVA: 0x0000A9CD File Offset: 0x00008BCD
			public POINT(int x, int y)
			{
				this = default(MyResizer.POINT);
				this._InfoMapper = x;
				this.repositoryMapper = y;
			}

			// Token: 0x04000894 RID: 2196
			public int _InfoMapper;

			// Token: 0x04000895 RID: 2197
			public int repositoryMapper;
		}

		// Token: 0x02000179 RID: 377
		private struct MINMAXINFO
		{
			// Token: 0x04000896 RID: 2198
			public MyResizer.POINT _SystemMapper;

			// Token: 0x04000897 RID: 2199
			public MyResizer.POINT _ProccesorMapper;

			// Token: 0x04000898 RID: 2200
			public MyResizer.POINT _PrototypeMapper;

			// Token: 0x04000899 RID: 2201
			public MyResizer.POINT refMapper;

			// Token: 0x0400089A RID: 2202
			public MyResizer.POINT parameterMapper;
		}

		// Token: 0x0200017A RID: 378
		private struct RECT
		{
			// Token: 0x0600108C RID: 4236 RVA: 0x0000A9E4 File Offset: 0x00008BE4
			// Note: this type is marked as 'beforefieldinit'.
			static RECT()
			{
				MyResizer.RECT.m_PredicateMapper = default(MyResizer.RECT);
			}

			// Token: 0x17000301 RID: 769
			// (get) Token: 0x0600108D RID: 4237 RVA: 0x0000A9F1 File Offset: 0x00008BF1
			public int Width
			{
				get
				{
					return Math.Abs(checked(this._ConfigurationMapper - this.stubMapper));
				}
			}

			// Token: 0x17000302 RID: 770
			// (get) Token: 0x0600108E RID: 4238 RVA: 0x0000AA05 File Offset: 0x00008C05
			public int Height
			{
				get
				{
					return checked(this.m_InterpreterMapper - this.m_AccountMapper);
				}
			}

			// Token: 0x0600108F RID: 4239 RVA: 0x0000AA14 File Offset: 0x00008C14
			public RECT(int left, int top, int right, int bottom)
			{
				this = default(MyResizer.RECT);
				this.stubMapper = left;
				this.m_AccountMapper = top;
				this._ConfigurationMapper = right;
				this.m_InterpreterMapper = bottom;
			}

			// Token: 0x06001090 RID: 4240 RVA: 0x0000AA3A File Offset: 0x00008C3A
			public RECT(MyResizer.RECT rcSrc)
			{
				this = default(MyResizer.RECT);
				this.stubMapper = rcSrc.stubMapper;
				this.m_AccountMapper = rcSrc.m_AccountMapper;
				this._ConfigurationMapper = rcSrc._ConfigurationMapper;
				this.m_InterpreterMapper = rcSrc.m_InterpreterMapper;
			}

			// Token: 0x0400089B RID: 2203
			public int stubMapper;

			// Token: 0x0400089C RID: 2204
			public int m_AccountMapper;

			// Token: 0x0400089D RID: 2205
			public int _ConfigurationMapper;

			// Token: 0x0400089E RID: 2206
			public int m_InterpreterMapper;

			// Token: 0x0400089F RID: 2207
			public static MyResizer.RECT m_PredicateMapper;
		}

		// Token: 0x0200017B RID: 379
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private class MONITORINFO
		{
			// Token: 0x06001091 RID: 4241 RVA: 0x0000AA73 File Offset: 0x00008C73
			public MONITORINFO()
			{
				this._StructMapper = Marshal.SizeOf(typeof(MyResizer.MONITORINFO));
				this.m_ResolverMapper = default(MyResizer.RECT);
				this.collectionMapper = default(MyResizer.RECT);
				this.m_TestsMapper = 0;
			}

			// Token: 0x040008A0 RID: 2208
			public int _StructMapper;

			// Token: 0x040008A1 RID: 2209
			public MyResizer.RECT m_ResolverMapper;

			// Token: 0x040008A2 RID: 2210
			public MyResizer.RECT collectionMapper;

			// Token: 0x040008A3 RID: 2211
			public int m_TestsMapper;
		}

		// Token: 0x0200017C RID: 380
		private struct PointAPI
		{
			// Token: 0x040008A4 RID: 2212
			public int X;

			// Token: 0x040008A5 RID: 2213
			public int m_BroadcasterMapper;
		}
	}
}
