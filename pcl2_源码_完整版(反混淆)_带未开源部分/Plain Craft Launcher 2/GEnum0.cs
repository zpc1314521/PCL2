using System;

// Token: 0x020001D4 RID: 468
[Flags]
public enum GEnum0
{
	// Token: 0x04000A7F RID: 2687
	Success = 0,
	// Token: 0x04000A80 RID: 2688
	Corrupted = 1,
	// Token: 0x04000A81 RID: 2689
	Invalid = 2,
	// Token: 0x04000A82 RID: 2690
	Blacklisted = 4,
	// Token: 0x04000A83 RID: 2691
	DateExpired = 8,
	// Token: 0x04000A84 RID: 2692
	RunningTimeOver = 0x10,
	// Token: 0x04000A85 RID: 2693
	BadHwid = 0x20,
	// Token: 0x04000A86 RID: 2694
	MaxBuildExpired = 0x40
}
