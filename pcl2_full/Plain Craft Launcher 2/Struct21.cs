using System;

// Token: 0x020001D1 RID: 465
struct Struct21
{
	// Token: 0x06001322 RID: 4898 RVA: 0x0000C0A6 File Offset: 0x0000A2A6
	public void method_0()
	{
		this.uint_1 = 0x400U;
	}

	// Token: 0x06001323 RID: 4899 RVA: 0x0008B69C File Offset: 0x0008989C
	public uint method_1(Class5 class5_0)
	{
		uint num = (class5_0.uint_2 >> 0xB) * this.uint_1;
		if (class5_0.uint_3 < num)
		{
			class5_0.uint_2 = num;
			this.uint_1 += 0x800U - this.uint_1 >> 5;
			if (class5_0.uint_2 < 0x1000000U)
			{
				class5_0.uint_3 = (class5_0.uint_3 << 8 | (uint)((byte)class5_0.stream_0.ReadByte()));
				class5_0.uint_2 <<= 8;
			}
			return 0U;
		}
		class5_0.uint_2 -= num;
		class5_0.uint_3 -= num;
		this.uint_1 -= this.uint_1 >> 5;
		if (class5_0.uint_2 < 0x1000000U)
		{
			class5_0.uint_3 = (class5_0.uint_3 << 8 | (uint)((byte)class5_0.stream_0.ReadByte()));
			class5_0.uint_2 <<= 8;
		}
		return 1U;
	}

	// Token: 0x04000A71 RID: 2673
	private const int int_0 = 0xB;

	// Token: 0x04000A72 RID: 2674
	private const uint uint_0 = 0x800U;

	// Token: 0x04000A73 RID: 2675
	private const int int_1 = 5;

	// Token: 0x04000A74 RID: 2676
	private uint uint_1;
}
