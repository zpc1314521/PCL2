using System;

// Token: 0x020001C9 RID: 457
static class Class1
{
	// Token: 0x060012F8 RID: 4856 RVA: 0x0008AB54 File Offset: 0x00088D54
	internal static void smethod_0(uint[] uint_0)
	{
		int i = 0;
		uint num = 0U;
		while (i < uint_0.Length)
		{
			num = ~uint_0[i] + 1U;
			uint_0[i] = num;
			if (num == 0U)
			{
				i++;
			}
			else
			{
				i++;
				IL_24:
				if (num != 0U)
				{
					while (i < uint_0.Length)
					{
						uint_0[i] = ~uint_0[i];
						i++;
					}
					return;
				}
				uint_0 = Class1.smethod_1(uint_0, uint_0.Length + 1);
				uint_0[uint_0.Length - 1] = 1U;
				return;
			}
		}
		goto IL_24;
	}

	// Token: 0x060012F9 RID: 4857 RVA: 0x0008ABB4 File Offset: 0x00088DB4
	private static uint[] smethod_1(uint[] uint_0, int int_1)
	{
		if (uint_0.Length == int_1)
		{
			return uint_0;
		}
		uint[] array = new uint[int_1];
		int num = Math.Min(uint_0.Length, int_1);
		for (int i = 0; i < num; i++)
		{
			array[i] = uint_0[i];
		}
		return array;
	}

	// Token: 0x060012FA RID: 4858 RVA: 0x0008ABF0 File Offset: 0x00088DF0
	internal static void smethod_2<T>(ref T gparam_0, ref T gparam_1)
	{
		T t = gparam_0;
		gparam_0 = gparam_1;
		gparam_1 = t;
	}

	// Token: 0x060012FB RID: 4859 RVA: 0x0000BEEF File Offset: 0x0000A0EF
	internal static ulong smethod_3(uint uint_0, uint uint_1)
	{
		return (ulong)uint_0 << 0x20 | (ulong)uint_1;
	}

	// Token: 0x060012FC RID: 4860 RVA: 0x0000BEF9 File Offset: 0x0000A0F9
	internal static uint smethod_4(ulong ulong_0)
	{
		return (uint)ulong_0;
	}

	// Token: 0x060012FD RID: 4861 RVA: 0x0000BEFD File Offset: 0x0000A0FD
	internal static uint smethod_5(ulong ulong_0)
	{
		return (uint)(ulong_0 >> 0x20);
	}

	// Token: 0x060012FE RID: 4862 RVA: 0x0000BF04 File Offset: 0x0000A104
	private static uint smethod_6(uint uint_0, uint uint_1)
	{
		return (uint_0 << 7 | uint_0 >> 0x19) ^ uint_1;
	}

	// Token: 0x060012FF RID: 4863 RVA: 0x0000BF10 File Offset: 0x0000A110
	internal static int smethod_7(int int_1, int int_2)
	{
		return (int)Class1.smethod_6((uint)int_1, (uint)int_2);
	}

	// Token: 0x06001300 RID: 4864 RVA: 0x0008AC18 File Offset: 0x00088E18
	internal static int smethod_8(uint uint_0)
	{
		if (uint_0 == 0U)
		{
			return 0x20;
		}
		int num = 0;
		if ((uint_0 & 0xFFFF0000U) == 0U)
		{
			num += 0x10;
			uint_0 <<= 0x10;
		}
		if ((uint_0 & 0xFF000000U) == 0U)
		{
			num += 8;
			uint_0 <<= 8;
		}
		if ((uint_0 & 0xF0000000U) == 0U)
		{
			num += 4;
			uint_0 <<= 4;
		}
		if ((uint_0 & 0xC0000000U) == 0U)
		{
			num += 2;
			uint_0 <<= 2;
		}
		if ((uint_0 & 0x80000000U) == 0U)
		{
			num++;
		}
		return num;
	}

	// Token: 0x04000A3C RID: 2620
	private const int int_0 = 0x20;
}
