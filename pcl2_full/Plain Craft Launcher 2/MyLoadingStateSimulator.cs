using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace PCL
{
	// Token: 0x02000046 RID: 70
	public class MyLoadingStateSimulator : ILoadingTrigger
	{
		// Token: 0x060001A8 RID: 424 RVA: 0x00003269 File Offset: 0x00001469
		public MyLoadingStateSimulator()
		{
			this.DeleteVal(MyLoading.MyLoadingState.Unloaded);
			this.IsLoader = 0;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0000327F File Offset: 0x0000147F
		[CompilerGenerated]
		private MyLoading.MyLoadingState DestroyVal()
		{
			return this.m_Exception;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00003287 File Offset: 0x00001487
		[CompilerGenerated]
		private void DeleteVal(MyLoading.MyLoadingState AutoPropertyValue)
		{
			this.m_Exception = AutoPropertyValue;
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060001AB RID: 427 RVA: 0x00003290 File Offset: 0x00001490
		// (set) Token: 0x060001AC RID: 428 RVA: 0x00013EF0 File Offset: 0x000120F0
		public MyLoading.MyLoadingState LoadingState
		{
			get
			{
				return this.DestroyVal();
			}
			set
			{
				if (this.DestroyVal() != value)
				{
					this.DeleteVal(value);
					ILoadingTrigger.LoadingStateChangedEventHandler server = this._Server;
					if (server != null)
					{
						server(value);
					}
				}
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060001AD RID: 429 RVA: 0x00003298 File Offset: 0x00001498
		public bool IsLoader { get; }

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060001AE RID: 430 RVA: 0x00013F20 File Offset: 0x00012120
		// (remove) Token: 0x060001AF RID: 431 RVA: 0x00013F58 File Offset: 0x00012158
		public event ILoadingTrigger.LoadingStateChangedEventHandler LoadingStateChanged
		{
			[CompilerGenerated]
			add
			{
				ILoadingTrigger.LoadingStateChangedEventHandler loadingStateChangedEventHandler = this._Server;
				ILoadingTrigger.LoadingStateChangedEventHandler loadingStateChangedEventHandler2;
				do
				{
					loadingStateChangedEventHandler2 = loadingStateChangedEventHandler;
					ILoadingTrigger.LoadingStateChangedEventHandler value2 = (ILoadingTrigger.LoadingStateChangedEventHandler)Delegate.Combine(loadingStateChangedEventHandler2, value);
					loadingStateChangedEventHandler = Interlocked.CompareExchange<ILoadingTrigger.LoadingStateChangedEventHandler>(ref this._Server, value2, loadingStateChangedEventHandler2);
				}
				while (loadingStateChangedEventHandler != loadingStateChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ILoadingTrigger.LoadingStateChangedEventHandler loadingStateChangedEventHandler = this._Server;
				ILoadingTrigger.LoadingStateChangedEventHandler loadingStateChangedEventHandler2;
				do
				{
					loadingStateChangedEventHandler2 = loadingStateChangedEventHandler;
					ILoadingTrigger.LoadingStateChangedEventHandler value2 = (ILoadingTrigger.LoadingStateChangedEventHandler)Delegate.Remove(loadingStateChangedEventHandler2, value);
					loadingStateChangedEventHandler = Interlocked.CompareExchange<ILoadingTrigger.LoadingStateChangedEventHandler>(ref this._Server, value2, loadingStateChangedEventHandler2);
				}
				while (loadingStateChangedEventHandler != loadingStateChangedEventHandler2);
			}
		}

		// Token: 0x040000C6 RID: 198
		[CompilerGenerated]
		private MyLoading.MyLoadingState m_Exception;

		// Token: 0x040000C7 RID: 199
		[CompilerGenerated]
		private bool m_Class;

		// Token: 0x040000C8 RID: 200
		[CompilerGenerated]
		private ILoadingTrigger.LoadingStateChangedEventHandler _Server;
	}
}
