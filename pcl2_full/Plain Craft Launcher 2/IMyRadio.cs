using System;

namespace PCL
{
	// Token: 0x0200000D RID: 13
	public interface IMyRadio
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000033 RID: 51
		// (remove) Token: 0x06000034 RID: 52
		event IMyRadio.CheckEventHandler Check;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000035 RID: 53
		// (remove) Token: 0x06000036 RID: 54
		event IMyRadio.ChangedEventHandler Changed;

		// Token: 0x0200000E RID: 14
		// (Invoke) Token: 0x0600003A RID: 58
		public delegate void CheckEventHandler(object sender, ModBase.RouteEventArgs e);

		// Token: 0x0200000F RID: 15
		// (Invoke) Token: 0x0600003E RID: 62
		public delegate void ChangedEventHandler(object sender, ModBase.RouteEventArgs e);
	}
}
