using System;

// Token: 0x020001D2 RID: 466
struct Struct22
{
	// Token: 0x06001324 RID: 4900 RVA: 0x0000C0B3 File Offset: 0x0000A2B3
	public Struct22(int int_1)
	{
		this.int_0 = int_1;
		this.struct21_0 = new Struct21[1 << int_1];
	}

	// Token: 0x06001325 RID: 4901 RVA: 0x0008B788 File Offset: 0x00089988
	public void method_0()
	{
		uint num = 1U;
		while ((ulong)num < (ulong)(1L << (this.int_0 & 0x1F)))
		{
			this.struct21_0[(int)num].method_0();
			num += 1U;
		}
	}

	// Token: 0x06001326 RID: 4902 RVA: 0x0008B7C0 File Offset: 0x000899C0
	public uint method_1(Class5 class5_0)
	{
		uint num = 1U;
		for (int i = this.int_0; i > 0; i--)
		{
			num = (num << 1) + this.struct21_0[(int)num].method_1(class5_0);
		}
		return num - (1U << this.int_0);
	}

	// Token: 0x06001327 RID: 4903 RVA: 0x0008B804 File Offset: 0x00089A04
	public uint method_2(Class5 class5_0)
	{
		uint num = 1U;
		uint num2 = 0U;
		for (int i = 0; i < this.int_0; i++)
		{
			uint num3 = this.struct21_0[(int)num].method_1(class5_0);
			num <<= 1;
			num += num3;
			num2 |= num3 << i;
		}
		return num2;
	}

	// Token: 0x06001328 RID: 4904 RVA: 0x0008B84C File Offset: 0x00089A4C
	public static uint smethod_0(Struct21[] struct21_1, uint uint_0, Class5 class5_0, int int_1)
	{
		uint num = 1U;
		uint num2 = 0U;
		for (int i = 0; i < int_1; i++)
		{
			uint num3 = struct21_1[(int)(uint_0 + num)].method_1(class5_0);
			num <<= 1;
			num += num3;
			num2 |= num3 << i;
		}
		return num2;
	}

	// Token: 0x04000A75 RID: 2677
	private readonly Struct21[] struct21_0;

	// Token: 0x04000A76 RID: 2678
	private readonly int int_0;
}
