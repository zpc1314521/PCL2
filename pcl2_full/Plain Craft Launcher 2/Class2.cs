using System;

// Token: 0x020001CA RID: 458
abstract class Class2
{
	// Token: 0x06001301 RID: 4865 RVA: 0x0000BF19 File Offset: 0x0000A119
	public static uint smethod_0(uint uint_9)
	{
		uint_9 -= 2U;
		if (uint_9 < 4U)
		{
			return uint_9;
		}
		return 3U;
	}

	// Token: 0x04000A3D RID: 2621
	public const uint uint_0 = 0xCU;

	// Token: 0x04000A3E RID: 2622
	public const int int_0 = 6;

	// Token: 0x04000A3F RID: 2623
	private const int int_1 = 2;

	// Token: 0x04000A40 RID: 2624
	public const uint uint_1 = 4U;

	// Token: 0x04000A41 RID: 2625
	public const uint uint_2 = 2U;

	// Token: 0x04000A42 RID: 2626
	public const int int_2 = 4;

	// Token: 0x04000A43 RID: 2627
	public const uint uint_3 = 4U;

	// Token: 0x04000A44 RID: 2628
	public const uint uint_4 = 0xEU;

	// Token: 0x04000A45 RID: 2629
	public const uint uint_5 = 0x80U;

	// Token: 0x04000A46 RID: 2630
	public const int int_3 = 4;

	// Token: 0x04000A47 RID: 2631
	public const uint uint_6 = 0x10U;

	// Token: 0x04000A48 RID: 2632
	public const int int_4 = 3;

	// Token: 0x04000A49 RID: 2633
	public const int int_5 = 3;

	// Token: 0x04000A4A RID: 2634
	public const int int_6 = 8;

	// Token: 0x04000A4B RID: 2635
	public const uint uint_7 = 8U;

	// Token: 0x04000A4C RID: 2636
	public const uint uint_8 = 8U;

	// Token: 0x020001CB RID: 459
	public struct Struct19
	{
		// Token: 0x06001303 RID: 4867 RVA: 0x0000BF27 File Offset: 0x0000A127
		public void method_0()
		{
			this.uint_0 = 0U;
		}

		// Token: 0x06001304 RID: 4868 RVA: 0x0000BF30 File Offset: 0x0000A130
		public void method_1()
		{
			if (this.uint_0 < 4U)
			{
				this.uint_0 = 0U;
				return;
			}
			if (this.uint_0 < 0xAU)
			{
				this.uint_0 -= 3U;
				return;
			}
			this.uint_0 -= 6U;
		}

		// Token: 0x06001305 RID: 4869 RVA: 0x0000BF6A File Offset: 0x0000A16A
		public void method_2()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 7U : 0xAU);
		}

		// Token: 0x06001306 RID: 4870 RVA: 0x0000BF80 File Offset: 0x0000A180
		public void method_3()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 8U : 0xBU);
		}

		// Token: 0x06001307 RID: 4871 RVA: 0x0000BF96 File Offset: 0x0000A196
		public void method_4()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 9U : 0xBU);
		}

		// Token: 0x06001308 RID: 4872 RVA: 0x0000BFAD File Offset: 0x0000A1AD
		public bool method_5()
		{
			return this.uint_0 < 7U;
		}

		// Token: 0x04000A4D RID: 2637
		public uint uint_0;
	}
}
