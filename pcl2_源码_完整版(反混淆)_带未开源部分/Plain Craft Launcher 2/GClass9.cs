using System;

// Token: 0x020001DF RID: 479
public class GClass9
{
	// Token: 0x06001359 RID: 4953 RVA: 0x0008D808 File Offset: 0x0008BA08
	public static uint smethod_0(uint uint_0, int int_1)
	{
		uint num = uint_0 << int_1;
		uint num2 = uint_0 >> 0x20 - int_1;
		return num | num2;
	}

	// Token: 0x0600135A RID: 4954 RVA: 0x0008D828 File Offset: 0x0008BA28
	public static uint smethod_1(uint uint_0, int int_1)
	{
		uint num = uint_0 >> int_1;
		uint num2 = uint_0 << 0x20 - int_1;
		return num | num2;
	}

	// Token: 0x0600135B RID: 4955 RVA: 0x0008D848 File Offset: 0x0008BA48
	public static uint smethod_2(uint uint_0)
	{
		uint num = uint_0 & 0xFF00FFU;
		uint num2 = uint_0 & 0xFF00FF00U;
		return (num >> 8 | num << 0x18) + (num2 << 8 | num2 >> 0x18);
	}

	// Token: 0x04000AAD RID: 2733
	public const int int_0 = 0x20;
}
