using System;

namespace PCL
{
	// Token: 0x02000044 RID: 68
	public interface ILoadingTrigger
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600019F RID: 415
		bool IsLoader { get; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060001A0 RID: 416
		// (set) Token: 0x060001A1 RID: 417
		MyLoading.MyLoadingState LoadingState { get; set; }

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060001A2 RID: 418
		// (remove) Token: 0x060001A3 RID: 419
		event ILoadingTrigger.LoadingStateChangedEventHandler LoadingStateChanged;

		// Token: 0x02000045 RID: 69
		// (Invoke) Token: 0x060001A7 RID: 423
		public delegate void LoadingStateChangedEventHandler(MyLoading.MyLoadingState NewState);
	}
}
