using System;
using System.IO;

// Token: 0x020001CC RID: 460
public class GClass0
{
	// Token: 0x06001309 RID: 4873 RVA: 0x0008AC88 File Offset: 0x00088E88
	public GClass0()
	{
		this.uint_0 = 1U;
		this.gclass1_0 = new GClass1();
		this.class5_0 = new Class5();
		this.struct21_0 = new Struct21[0xC0];
		this.struct21_1 = new Struct21[0xC];
		this.struct21_2 = new Struct21[0xC];
		this.struct21_3 = new Struct21[0xC];
		this.struct21_4 = new Struct21[0xC];
		this.struct21_5 = new Struct21[0xC0];
		this.struct22_0 = new Struct22[4];
		this.struct21_6 = new Struct21[0x72];
		this.struct22_1 = new Struct22(4);
		this.class3_0 = new GClass0.Class3();
		this.class3_1 = new GClass0.Class3();
		this.class4_0 = new GClass0.Class4();
		base..ctor();
		this.uint_1 = uint.MaxValue;
		int num = 0;
		while ((long)num < 4L)
		{
			this.struct22_0[num] = new Struct22(6);
			num++;
		}
	}

	// Token: 0x0600130A RID: 4874 RVA: 0x0008AD80 File Offset: 0x00088F80
	private void method_0(uint uint_4)
	{
		if (this.uint_1 != uint_4)
		{
			this.uint_1 = uint_4;
			this.uint_2 = Math.Max(this.uint_1, 1U);
			uint uint_5 = Math.Max(this.uint_2, 0x1000U);
			this.gclass1_0.method_0(uint_5);
		}
	}

	// Token: 0x0600130B RID: 4875 RVA: 0x0000BFB8 File Offset: 0x0000A1B8
	private void method_1(int int_0, int int_1)
	{
		if (int_0 > 8)
		{
			throw new ArgumentException("lp > 8");
		}
		if (int_1 > 8)
		{
			throw new ArgumentException("lc > 8");
		}
		this.class4_0.method_0(int_0, int_1);
	}

	// Token: 0x0600130C RID: 4876 RVA: 0x0008ADCC File Offset: 0x00088FCC
	private void method_2(int int_0)
	{
		if (int_0 > 4)
		{
			throw new ArgumentException("pb > Base.KNumPosStatesBitsMax");
		}
		uint num = 1U << int_0;
		this.class3_0.method_0(num);
		this.class3_1.method_0(num);
		this.uint_3 = num - 1U;
	}

	// Token: 0x0600130D RID: 4877 RVA: 0x0008AE10 File Offset: 0x00089010
	private void method_3(Stream stream_0, Stream stream_1)
	{
		this.class5_0.method_0(stream_0);
		this.gclass1_0.method_1(stream_1, false);
		for (uint num = 0U; num < 0xCU; num += 1U)
		{
			for (uint num2 = 0U; num2 <= this.uint_3; num2 += 1U)
			{
				uint num3 = (num << 4) + num2;
				this.struct21_0[(int)num3].method_0();
				this.struct21_5[(int)num3].method_0();
			}
			this.struct21_1[(int)num].method_0();
			this.struct21_2[(int)num].method_0();
			this.struct21_3[(int)num].method_0();
			this.struct21_4[(int)num].method_0();
		}
		this.class4_0.method_1();
		for (uint num = 0U; num < 4U; num += 1U)
		{
			this.struct22_0[(int)num].method_0();
		}
		for (uint num = 0U; num < 0x72U; num += 1U)
		{
			this.struct21_6[(int)num].method_0();
		}
		this.class3_0.method_1();
		this.class3_1.method_1();
		this.struct22_1.method_0();
	}

	// Token: 0x0600130E RID: 4878 RVA: 0x0008AF30 File Offset: 0x00089130
	public void method_4(Stream stream_0, Stream stream_1, long long_0)
	{
		this.method_3(stream_0, stream_1);
		Class2.Struct19 @struct = default(Class2.Struct19);
		@struct.method_0();
		uint num = 0U;
		uint num2 = 0U;
		uint num3 = 0U;
		uint num4 = 0U;
		ulong num5 = 0UL;
		if (0L < long_0)
		{
			if (this.struct21_0[(int)((int)@struct.uint_0 << 4)].method_1(this.class5_0) != 0U)
			{
				throw new InvalidDataException("IsMatchDecoders");
			}
			@struct.method_1();
			byte byte_ = this.class4_0.method_3(this.class5_0, 0U, 0);
			this.gclass1_0.method_5(byte_);
			num5 += 1UL;
		}
		while (num5 < (ulong)long_0)
		{
			uint num6 = (uint)num5 & this.uint_3;
			if (this.struct21_0[(int)((@struct.uint_0 << 4) + num6)].method_1(this.class5_0) == 0U)
			{
				byte byte_2 = this.gclass1_0.method_6(0U);
				byte byte_3;
				if (!@struct.method_5())
				{
					byte_3 = this.class4_0.method_4(this.class5_0, (uint)num5, byte_2, this.gclass1_0.method_6(num));
				}
				else
				{
					byte_3 = this.class4_0.method_3(this.class5_0, (uint)num5, byte_2);
				}
				this.gclass1_0.method_5(byte_3);
				@struct.method_1();
				num5 += 1UL;
			}
			else
			{
				uint num8;
				if (this.struct21_1[(int)@struct.uint_0].method_1(this.class5_0) == 1U)
				{
					if (this.struct21_2[(int)@struct.uint_0].method_1(this.class5_0) == 0U)
					{
						if (this.struct21_5[(int)((@struct.uint_0 << 4) + num6)].method_1(this.class5_0) == 0U)
						{
							@struct.method_4();
							this.gclass1_0.method_5(this.gclass1_0.method_6(num));
							num5 += 1UL;
							continue;
						}
					}
					else
					{
						uint num7;
						if (this.struct21_3[(int)@struct.uint_0].method_1(this.class5_0) == 0U)
						{
							num7 = num2;
						}
						else
						{
							if (this.struct21_4[(int)@struct.uint_0].method_1(this.class5_0) == 0U)
							{
								num7 = num3;
							}
							else
							{
								num7 = num4;
								num4 = num3;
							}
							num3 = num2;
						}
						num2 = num;
						num = num7;
					}
					num8 = this.class3_1.method_2(this.class5_0, num6) + 2U;
					@struct.method_3();
				}
				else
				{
					num4 = num3;
					num3 = num2;
					num2 = num;
					num8 = 2U + this.class3_0.method_2(this.class5_0, num6);
					@struct.method_2();
					uint num9 = this.struct22_0[(int)Class2.smethod_0(num8)].method_1(this.class5_0);
					if (num9 >= 4U)
					{
						int num10 = (int)((num9 >> 1) - 1U);
						num = (2U | (num9 & 1U)) << num10;
						if (num9 < 0xEU)
						{
							num += Struct22.smethod_0(this.struct21_6, num - num9 - 1U, this.class5_0, num10);
						}
						else
						{
							num += this.class5_0.method_2(num10 - 4) << 4;
							num += this.struct22_1.method_2(this.class5_0);
						}
					}
					else
					{
						num = num9;
					}
				}
				if ((ulong)num < (ulong)this.gclass1_0.uint_4 + num5 && num < this.uint_2)
				{
					this.gclass1_0.method_4(num, num8);
					num5 += (ulong)num8;
				}
				else
				{
					if (num != 0xFFFFFFFFU)
					{
						throw new InvalidDataException("rep0");
					}
					IL_359:
					this.gclass1_0.method_3();
					this.gclass1_0.method_2();
					this.class5_0.method_1();
					return;
				}
			}
		}
		goto IL_359;
	}

	// Token: 0x0600130F RID: 4879 RVA: 0x0008B2B8 File Offset: 0x000894B8
	public void method_5(byte[] byte_0)
	{
		if (byte_0.Length < 5)
		{
			throw new ArgumentException("properties.Length < 5");
		}
		int int_ = (int)(byte_0[0] % 9);
		byte b = byte_0[0] / 9;
		int int_2 = (int)(b % 5);
		int num = (int)(b / 5);
		if (num > 4)
		{
			throw new ArgumentException("pb > Base.kNumPosStatesBitsMax");
		}
		uint num2 = 0U;
		for (int i = 0; i < 4; i++)
		{
			num2 += (uint)((uint)byte_0[1 + i] << i * 8);
		}
		this.method_0(num2);
		this.method_1(int_2, int_);
		this.method_2(num);
	}

	// Token: 0x04000A4E RID: 2638
	private uint uint_0;

	// Token: 0x04000A4F RID: 2639
	private readonly GClass1 gclass1_0;

	// Token: 0x04000A50 RID: 2640
	private readonly Class5 class5_0;

	// Token: 0x04000A51 RID: 2641
	private readonly Struct21[] struct21_0;

	// Token: 0x04000A52 RID: 2642
	private readonly Struct21[] struct21_1;

	// Token: 0x04000A53 RID: 2643
	private readonly Struct21[] struct21_2;

	// Token: 0x04000A54 RID: 2644
	private readonly Struct21[] struct21_3;

	// Token: 0x04000A55 RID: 2645
	private readonly Struct21[] struct21_4;

	// Token: 0x04000A56 RID: 2646
	private readonly Struct21[] struct21_5;

	// Token: 0x04000A57 RID: 2647
	private readonly Struct22[] struct22_0;

	// Token: 0x04000A58 RID: 2648
	private readonly Struct21[] struct21_6;

	// Token: 0x04000A59 RID: 2649
	private Struct22 struct22_1;

	// Token: 0x04000A5A RID: 2650
	private readonly GClass0.Class3 class3_0;

	// Token: 0x04000A5B RID: 2651
	private readonly GClass0.Class3 class3_1;

	// Token: 0x04000A5C RID: 2652
	private readonly GClass0.Class4 class4_0;

	// Token: 0x04000A5D RID: 2653
	private uint uint_1;

	// Token: 0x04000A5E RID: 2654
	private uint uint_2;

	// Token: 0x04000A5F RID: 2655
	private uint uint_3;

	// Token: 0x020001CD RID: 461
	private class Class3
	{
		// Token: 0x06001310 RID: 4880 RVA: 0x0008B334 File Offset: 0x00089534
		public void method_0(uint uint_1)
		{
			for (uint num = this.uint_0; num < uint_1; num += 1U)
			{
				this.struct22_0[(int)num] = new Struct22(3);
				this.struct22_1[(int)num] = new Struct22(3);
			}
			this.uint_0 = uint_1;
		}

		// Token: 0x06001311 RID: 4881 RVA: 0x0008B380 File Offset: 0x00089580
		public void method_1()
		{
			this.struct21_0.method_0();
			for (uint num = 0U; num < this.uint_0; num += 1U)
			{
				this.struct22_0[(int)num].method_0();
				this.struct22_1[(int)num].method_0();
			}
			this.struct21_1.method_0();
			this.struct22_2.method_0();
		}

		// Token: 0x06001312 RID: 4882 RVA: 0x0008B3E4 File Offset: 0x000895E4
		public uint method_2(Class5 class5_0, uint uint_1)
		{
			if (this.struct21_0.method_1(class5_0) == 0U)
			{
				return this.struct22_0[(int)uint_1].method_1(class5_0);
			}
			uint num = 8U;
			if (this.struct21_1.method_1(class5_0) == 0U)
			{
				num += this.struct22_1[(int)uint_1].method_1(class5_0);
			}
			else
			{
				num += 8U;
				num += this.struct22_2.method_1(class5_0);
			}
			return num;
		}

		// Token: 0x06001313 RID: 4883 RVA: 0x0000BFE5 File Offset: 0x0000A1E5
		public Class3()
		{
			this.struct22_0 = new Struct22[0x10];
			this.struct22_1 = new Struct22[0x10];
			this.struct22_2 = new Struct22(8);
			base..ctor();
		}

		// Token: 0x04000A60 RID: 2656
		private Struct21 struct21_0;

		// Token: 0x04000A61 RID: 2657
		private Struct21 struct21_1;

		// Token: 0x04000A62 RID: 2658
		private readonly Struct22[] struct22_0;

		// Token: 0x04000A63 RID: 2659
		private readonly Struct22[] struct22_1;

		// Token: 0x04000A64 RID: 2660
		private Struct22 struct22_2;

		// Token: 0x04000A65 RID: 2661
		private uint uint_0;
	}

	// Token: 0x020001CE RID: 462
	private class Class4
	{
		// Token: 0x06001314 RID: 4884 RVA: 0x0008B450 File Offset: 0x00089650
		public void method_0(int int_2, int int_3)
		{
			if (this.struct20_0 != null && this.int_0 == int_3 && this.int_1 == int_2)
			{
				return;
			}
			this.int_1 = int_2;
			this.uint_1 = (1U << int_2) - 1U;
			this.int_0 = int_3;
			uint num = 1U << this.int_0 + this.int_1;
			this.struct20_0 = new GClass0.Class4.Struct20[num];
			for (uint num2 = 0U; num2 < num; num2 += 1U)
			{
				this.struct20_0[(int)num2].method_0();
			}
		}

		// Token: 0x06001315 RID: 4885 RVA: 0x0008B4D0 File Offset: 0x000896D0
		public void method_1()
		{
			uint num = 1U << this.int_0 + this.int_1;
			for (uint num2 = 0U; num2 < num; num2 += 1U)
			{
				this.struct20_0[(int)num2].method_1();
			}
		}

		// Token: 0x06001316 RID: 4886 RVA: 0x0000C013 File Offset: 0x0000A213
		private uint method_2(uint uint_2, byte byte_0)
		{
			return ((uint_2 & this.uint_1) << this.int_0) + (uint)(byte_0 >> 8 - this.int_0);
		}

		// Token: 0x06001317 RID: 4887 RVA: 0x0000C035 File Offset: 0x0000A235
		public byte method_3(Class5 class5_0, uint uint_2, byte byte_0)
		{
			return this.struct20_0[(int)this.method_2(uint_2, byte_0)].method_2(class5_0);
		}

		// Token: 0x06001318 RID: 4888 RVA: 0x0000C050 File Offset: 0x0000A250
		public byte method_4(Class5 class5_0, uint uint_2, byte byte_0, byte byte_1)
		{
			return this.struct20_0[(int)this.method_2(uint_2, byte_0)].method_3(class5_0, byte_1);
		}

		// Token: 0x06001319 RID: 4889 RVA: 0x0000C06D File Offset: 0x0000A26D
		public Class4()
		{
			this.uint_0 = 1U;
			base..ctor();
		}

		// Token: 0x04000A66 RID: 2662
		private uint uint_0;

		// Token: 0x04000A67 RID: 2663
		private GClass0.Class4.Struct20[] struct20_0;

		// Token: 0x04000A68 RID: 2664
		private int int_0;

		// Token: 0x04000A69 RID: 2665
		private int int_1;

		// Token: 0x04000A6A RID: 2666
		private uint uint_1;

		// Token: 0x020001CF RID: 463
		private struct Struct20
		{
			// Token: 0x0600131A RID: 4890 RVA: 0x0000C07C File Offset: 0x0000A27C
			public void method_0()
			{
				this.struct21_0 = new Struct21[0x300];
			}

			// Token: 0x0600131B RID: 4891 RVA: 0x0008B510 File Offset: 0x00089710
			public void method_1()
			{
				for (int i = 0; i < 0x300; i++)
				{
					this.struct21_0[i].method_0();
				}
			}

			// Token: 0x0600131C RID: 4892 RVA: 0x0008B540 File Offset: 0x00089740
			public byte method_2(Class5 class5_0)
			{
				uint num = 1U;
				do
				{
					num = (num << 1 | this.struct21_0[(int)num].method_1(class5_0));
				}
				while (num < 0x100U);
				return (byte)num;
			}

			// Token: 0x0600131D RID: 4893 RVA: 0x0008B570 File Offset: 0x00089770
			public byte method_3(Class5 class5_0, byte byte_0)
			{
				uint num = 1U;
				for (;;)
				{
					uint num2 = (uint)(byte_0 >> 7 & 1);
					byte_0 = (byte)(byte_0 << 1);
					uint num3 = this.struct21_0[(int)((1U + num2 << 8) + num)].method_1(class5_0);
					num = (num << 1 | num3);
					if (num2 != num3)
					{
						break;
					}
					if (num >= 0x100U)
					{
						goto IL_5C;
					}
				}
				while (num < 0x100U)
				{
					num = (num << 1 | this.struct21_0[(int)num].method_1(class5_0));
				}
				IL_5C:
				return (byte)num;
			}

			// Token: 0x04000A6B RID: 2667
			private Struct21[] struct21_0;
		}
	}
}
