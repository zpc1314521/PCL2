using System;
using System.Diagnostics;

// Token: 0x020001C8 RID: 456
struct Struct18
{
	// Token: 0x060012E1 RID: 4833 RVA: 0x0000519F File Offset: 0x0000339F
	[Conditional("DEBUG")]
	private void method_0(bool bool_1)
	{
	}

	// Token: 0x060012E2 RID: 4834 RVA: 0x0000BE62 File Offset: 0x0000A062
	internal Struct18(int int_2)
	{
		this.int_1 = 0;
		this.uint_0 = 0U;
		if (int_2 > 1)
		{
			this.uint_1 = new uint[int_2];
			this.bool_0 = true;
			return;
		}
		this.uint_1 = null;
		this.bool_0 = false;
	}

	// Token: 0x060012E3 RID: 4835 RVA: 0x0008A0E4 File Offset: 0x000882E4
	internal Struct18(Struct17 struct17_0, ref int int_2)
	{
		this.bool_0 = false;
		this.uint_1 = struct17_0.UInt32_0;
		int int32_ = struct17_0.Int32_1;
		int num = int32_ >> 0x1F;
		int_2 = (int_2 ^ num) - num;
		if (this.uint_1 == null)
		{
			this.int_1 = 0;
			this.uint_0 = (uint)((int32_ ^ num) - num);
			return;
		}
		this.int_1 = this.uint_1.Length - 1;
		this.uint_0 = this.uint_1[0];
		while (this.int_1 > 0 && this.uint_1[this.int_1] == 0U)
		{
			this.int_1--;
		}
	}

	// Token: 0x060012E4 RID: 4836 RVA: 0x0008A17C File Offset: 0x0008837C
	internal Struct17 method_1(int int_2)
	{
		uint[] uint_;
		this.method_2(int_2, out int_2, out uint_);
		return new Struct17(int_2, uint_);
	}

	// Token: 0x060012E5 RID: 4837 RVA: 0x0008A19C File Offset: 0x0008839C
	private void method_2(int int_2, out int int_3, out uint[] uint_2)
	{
		if (this.int_1 == 0)
		{
			if (this.uint_0 <= 0x7FFFFFFFU)
			{
				int_3 = int_2 * (int)this.uint_0;
				uint_2 = null;
				return;
			}
			if (this.uint_1 == null)
			{
				this.uint_1 = new uint[]
				{
					this.uint_0
				};
			}
			else if (this.bool_0)
			{
				this.uint_1[0] = this.uint_0;
			}
			else if (this.uint_1[0] != this.uint_0)
			{
				this.uint_1 = new uint[]
				{
					this.uint_0
				};
			}
		}
		int_3 = int_2;
		int num = this.uint_1.Length - this.int_1 - 1;
		if (num <= 1)
		{
			if (num == 0 || this.uint_1[this.int_1 + 1] == 0U)
			{
				this.bool_0 = false;
				uint_2 = this.uint_1;
				return;
			}
			if (this.bool_0)
			{
				this.uint_1[this.int_1 + 1] = 0U;
				this.bool_0 = false;
				uint_2 = this.uint_1;
				return;
			}
		}
		uint_2 = this.uint_1;
		Array.Resize<uint>(ref uint_2, this.int_1 + 1);
		if (!this.bool_0)
		{
			this.uint_1 = uint_2;
		}
	}

	// Token: 0x060012E6 RID: 4838 RVA: 0x0000BE98 File Offset: 0x0000A098
	private void method_3(uint uint_2)
	{
		this.uint_0 = uint_2;
		this.int_1 = 0;
	}

	// Token: 0x060012E7 RID: 4839 RVA: 0x0008A2B4 File Offset: 0x000884B4
	private void method_4(ulong ulong_0)
	{
		uint num = Class1.smethod_5(ulong_0);
		if (num == 0U)
		{
			this.uint_0 = Class1.smethod_4(ulong_0);
			this.int_1 = 0;
			return;
		}
		this.method_6(2);
		this.uint_1[0] = (uint)ulong_0;
		this.uint_1[1] = num;
	}

	// Token: 0x1700034C RID: 844
	// (get) Token: 0x060012E8 RID: 4840 RVA: 0x0000BEA8 File Offset: 0x0000A0A8
	internal int Int32_0
	{
		get
		{
			return this.int_1 + 1;
		}
	}

	// Token: 0x060012E9 RID: 4841 RVA: 0x0008A2FC File Offset: 0x000884FC
	private void method_5()
	{
		if (this.int_1 > 0 && this.uint_1[this.int_1] == 0U)
		{
			this.uint_0 = this.uint_1[0];
			int num;
			do
			{
				num = this.int_1 - 1;
				this.int_1 = num;
			}
			while (num > 0 && this.uint_1[this.int_1] == 0U);
		}
	}

	// Token: 0x1700034D RID: 845
	// (get) Token: 0x060012EA RID: 4842 RVA: 0x0008A354 File Offset: 0x00088554
	private int Int32_1
	{
		get
		{
			int num = 0;
			for (int i = this.int_1; i >= 0; i--)
			{
				if (this.uint_1[i] != 0U)
				{
					num++;
				}
			}
			return num;
		}
	}

	// Token: 0x060012EB RID: 4843 RVA: 0x0000BEB2 File Offset: 0x0000A0B2
	private void method_6(int int_2)
	{
		if (int_2 <= 1)
		{
			this.int_1 = 0;
			return;
		}
		if (!this.bool_0 || this.uint_1.Length < int_2)
		{
			this.uint_1 = new uint[int_2];
			this.bool_0 = true;
		}
		this.int_1 = int_2 - 1;
	}

	// Token: 0x060012EC RID: 4844 RVA: 0x0008A384 File Offset: 0x00088584
	private void method_7(int int_2)
	{
		if (int_2 <= 1)
		{
			this.int_1 = 0;
			this.uint_0 = 0U;
			return;
		}
		if (this.bool_0 && this.uint_1.Length >= int_2)
		{
			Array.Clear(this.uint_1, 0, int_2);
		}
		else
		{
			this.uint_1 = new uint[int_2];
			this.bool_0 = true;
		}
		this.int_1 = int_2 - 1;
	}

	// Token: 0x060012ED RID: 4845 RVA: 0x0008A3E4 File Offset: 0x000885E4
	private void method_8(int int_2, int int_3)
	{
		if (int_2 <= 1)
		{
			if (this.int_1 > 0)
			{
				this.uint_0 = this.uint_1[0];
			}
			this.int_1 = 0;
			return;
		}
		if (this.bool_0 && this.uint_1.Length >= int_2)
		{
			if (this.int_1 + 1 < int_2)
			{
				Array.Clear(this.uint_1, this.int_1 + 1, int_2 - this.int_1 - 1);
				if (this.int_1 == 0)
				{
					this.uint_1[0] = this.uint_0;
				}
			}
		}
		else
		{
			uint[] array = new uint[int_2 + int_3];
			if (this.int_1 == 0)
			{
				array[0] = this.uint_0;
			}
			else
			{
				Array.Copy(this.uint_1, array, Math.Min(int_2, this.int_1 + 1));
			}
			this.uint_1 = array;
			this.bool_0 = true;
		}
		this.int_1 = int_2 - 1;
	}

	// Token: 0x060012EE RID: 4846 RVA: 0x0008A4B4 File Offset: 0x000886B4
	private void method_9(int int_2 = 0)
	{
		if (this.bool_0)
		{
			return;
		}
		uint[] destinationArray = new uint[this.int_1 + 1 + int_2];
		Array.Copy(this.uint_1, destinationArray, this.int_1 + 1);
		this.uint_1 = destinationArray;
		this.bool_0 = true;
	}

	// Token: 0x060012EF RID: 4847 RVA: 0x0008A4FC File Offset: 0x000886FC
	private void method_10(ref Struct18 struct18_0, int int_2)
	{
		if (struct18_0.int_1 == 0)
		{
			this.uint_0 = struct18_0.uint_0;
			this.int_1 = 0;
			return;
		}
		if (!this.bool_0 || this.uint_1.Length <= struct18_0.int_1)
		{
			this.uint_1 = new uint[struct18_0.int_1 + 1 + int_2];
			this.bool_0 = true;
		}
		this.int_1 = struct18_0.int_1;
		Array.Copy(struct18_0.uint_1, this.uint_1, this.int_1 + 1);
	}

	// Token: 0x060012F0 RID: 4848 RVA: 0x0008A580 File Offset: 0x00088780
	private void method_11(uint uint_2)
	{
		if (uint_2 == 0U)
		{
			this.method_3(0U);
			return;
		}
		if (uint_2 == 1U)
		{
			return;
		}
		if (this.int_1 == 0)
		{
			this.method_4((ulong)this.uint_0 * (ulong)uint_2);
			return;
		}
		this.method_9(1);
		uint num = 0U;
		for (int i = 0; i <= this.int_1; i++)
		{
			num = Struct18.smethod_3(ref this.uint_1[i], uint_2, num);
		}
		if (num != 0U)
		{
			this.method_8(this.int_1 + 2, 0);
			this.uint_1[this.int_1] = num;
		}
	}

	// Token: 0x060012F1 RID: 4849 RVA: 0x0008A604 File Offset: 0x00088804
	internal void method_12(ref Struct18 struct18_0, ref Struct18 struct18_1)
	{
		if (struct18_0.int_1 == 0)
		{
			if (struct18_1.int_1 == 0)
			{
				this.method_4((ulong)struct18_0.uint_0 * (ulong)struct18_1.uint_0);
				return;
			}
			this.method_10(ref struct18_1, 1);
			this.method_11(struct18_0.uint_0);
			return;
		}
		else
		{
			if (struct18_1.int_1 == 0)
			{
				this.method_10(ref struct18_0, 1);
				this.method_11(struct18_1.uint_0);
				return;
			}
			this.method_7(struct18_0.int_1 + struct18_1.int_1 + 2);
			uint[] array;
			int num;
			uint[] array2;
			int num2;
			if (struct18_0.Int32_1 <= struct18_1.Int32_1)
			{
				array = struct18_0.uint_1;
				num = struct18_0.int_1 + 1;
				array2 = struct18_1.uint_1;
				num2 = struct18_1.int_1 + 1;
			}
			else
			{
				array = struct18_1.uint_1;
				num = struct18_1.int_1 + 1;
				array2 = struct18_0.uint_1;
				num2 = struct18_0.int_1 + 1;
			}
			for (int i = 0; i < num; i++)
			{
				uint num3 = array[i];
				if (num3 != 0U)
				{
					uint num4 = 0U;
					int num5 = i;
					int j = 0;
					while (j < num2)
					{
						num4 = Struct18.smethod_4(ref this.uint_1[num5], num3, array2[j], num4);
						j++;
						num5++;
					}
					while (num4 != 0U)
					{
						num4 = Struct18.smethod_2(ref this.uint_1[num5++], 0U, num4);
					}
				}
			}
			this.method_5();
			return;
		}
	}

	// Token: 0x060012F2 RID: 4850 RVA: 0x0008A74C File Offset: 0x0008894C
	private static uint smethod_0(ref Struct18 struct18_0, uint uint_2)
	{
		if (uint_2 == 1U)
		{
			return 0U;
		}
		if (struct18_0.int_1 == 0)
		{
			return struct18_0.uint_0 % uint_2;
		}
		ulong num = 0UL;
		for (int i = struct18_0.int_1; i >= 0; i--)
		{
			num = Class1.smethod_3((uint)num, struct18_0.uint_1[i]);
			num %= (ulong)uint_2;
		}
		return (uint)num;
	}

	// Token: 0x060012F3 RID: 4851 RVA: 0x0008A7A4 File Offset: 0x000889A4
	internal void method_13(ref Struct18 struct18_0)
	{
		if (struct18_0.int_1 == 0)
		{
			this.method_3(Struct18.smethod_0(ref this, struct18_0.uint_0));
			return;
		}
		if (this.int_1 == 0)
		{
			return;
		}
		Struct18 @struct = default(Struct18);
		Struct18.smethod_1(ref this, ref struct18_0, false, ref @struct);
	}

	// Token: 0x060012F4 RID: 4852 RVA: 0x0008A7E8 File Offset: 0x000889E8
	private static void smethod_1(ref Struct18 struct18_0, ref Struct18 struct18_1, bool bool_1, ref Struct18 struct18_2)
	{
		struct18_2.method_3(0U);
		if (struct18_0.int_1 < struct18_1.int_1)
		{
			return;
		}
		int num = struct18_1.int_1 + 1;
		int num2 = struct18_0.int_1 - struct18_1.int_1;
		int num3 = num2;
		int i = struct18_0.int_1;
		while (i >= num2)
		{
			if (struct18_1.uint_1[i - num2] != struct18_0.uint_1[i])
			{
				if (struct18_1.uint_1[i - num2] < struct18_0.uint_1[i])
				{
					num3++;
				}
				IL_7C:
				if (num3 == 0)
				{
					return;
				}
				if (bool_1)
				{
					struct18_2.method_6(num3);
				}
				uint num4 = struct18_1.uint_1[num - 1];
				uint num5 = struct18_1.uint_1[num - 2];
				int num6 = Class1.smethod_8(num4);
				int num7 = 0x20 - num6;
				if (num6 > 0)
				{
					num4 = (num4 << num6 | num5 >> num7);
					num5 <<= num6;
					if (num > 2)
					{
						num5 |= struct18_1.uint_1[num - 3] >> num7;
					}
				}
				struct18_0.method_9(0);
				int num8 = num3;
				while (--num8 >= 0)
				{
					uint num9 = (num8 + num <= struct18_0.int_1) ? struct18_0.uint_1[num8 + num] : 0U;
					ulong num10 = Class1.smethod_3(num9, struct18_0.uint_1[num8 + num - 1]);
					uint num11 = struct18_0.uint_1[num8 + num - 2];
					if (num6 > 0)
					{
						num10 = (num10 << num6 | (ulong)(num11 >> num7));
						num11 <<= num6;
						if (num8 + num >= 3)
						{
							num11 |= struct18_0.uint_1[num8 + num - 3] >> num7;
						}
					}
					ulong num12 = num10 / (ulong)num4;
					ulong num13 = (ulong)((uint)(num10 % (ulong)num4));
					if (num12 > 0xFFFFFFFFUL)
					{
						num13 += (ulong)num4 * (num12 - 0xFFFFFFFFUL);
						num12 = 0xFFFFFFFFUL;
					}
					while (num13 <= 0xFFFFFFFFUL && num12 * (ulong)num5 > Class1.smethod_3((uint)num13, num11))
					{
						num12 -= 1UL;
						num13 += (ulong)num4;
					}
					if (num12 > 0UL)
					{
						ulong num14 = 0UL;
						for (int j = 0; j < num; j++)
						{
							num14 += (ulong)struct18_1.uint_1[j] * num12;
							uint num15 = (uint)num14;
							num14 >>= 0x20;
							if (struct18_0.uint_1[num8 + j] < num15)
							{
								num14 += 1UL;
							}
							struct18_0.uint_1[num8 + j] -= num15;
						}
						if ((ulong)num9 < num14)
						{
							uint uint_ = 0U;
							for (int k = 0; k < num; k++)
							{
								uint_ = Struct18.smethod_2(ref struct18_0.uint_1[num8 + k], struct18_1.uint_1[k], uint_);
							}
							num12 -= 1UL;
						}
						struct18_0.int_1 = num8 + num - 1;
					}
					if (bool_1)
					{
						if (num3 == 1)
						{
							struct18_2.uint_0 = (uint)num12;
						}
						else
						{
							struct18_2.uint_1[num8] = (uint)num12;
						}
					}
				}
				struct18_0.int_1 = num - 1;
				struct18_0.method_5();
				return;
			}
			else
			{
				i--;
			}
		}
		num3++;
		goto IL_7C;
	}

	// Token: 0x060012F5 RID: 4853 RVA: 0x0008AAF0 File Offset: 0x00088CF0
	private static uint smethod_2(ref uint uint_2, uint uint_3, uint uint_4)
	{
		ulong num = (ulong)uint_2 + (ulong)uint_3 + (ulong)uint_4;
		uint_2 = (uint)num;
		return (uint)(num >> 0x20);
	}

	// Token: 0x060012F6 RID: 4854 RVA: 0x0008AB10 File Offset: 0x00088D10
	private static uint smethod_3(ref uint uint_2, uint uint_3, uint uint_4)
	{
		ulong num = (ulong)uint_2 * (ulong)uint_3 + (ulong)uint_4;
		uint_2 = (uint)num;
		return (uint)(num >> 0x20);
	}

	// Token: 0x060012F7 RID: 4855 RVA: 0x0008AB30 File Offset: 0x00088D30
	private static uint smethod_4(ref uint uint_2, uint uint_3, uint uint_4, uint uint_5)
	{
		ulong num = (ulong)uint_3 * (ulong)uint_4 + (ulong)uint_2 + (ulong)uint_5;
		uint_2 = (uint)num;
		return (uint)(num >> 0x20);
	}

	// Token: 0x04000A37 RID: 2615
	private const int int_0 = 0x20;

	// Token: 0x04000A38 RID: 2616
	private int int_1;

	// Token: 0x04000A39 RID: 2617
	private uint uint_0;

	// Token: 0x04000A3A RID: 2618
	private uint[] uint_1;

	// Token: 0x04000A3B RID: 2619
	private bool bool_0;
}
