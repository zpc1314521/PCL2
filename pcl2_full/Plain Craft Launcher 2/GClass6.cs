using System;
using System.Runtime.InteropServices;

// Token: 0x020001DB RID: 475
public class GClass6
{
	// Token: 0x0600134E RID: 4942 RVA: 0x0008CF98 File Offset: 0x0008B198
	public GClass6(byte[] byte_0)
	{
		uint num = 0x5EE46D90U;
		base..ctor();
		for (;;)
		{
			uint num2 = num ^ 0x5EE46D94U;
			num = 0x4FC66494U / num;
			uint num3 = num2;
			int num4 = (int)(num - 0xFFFFFFFEU);
			num += 0x23832F15U;
			uint[] array = new uint[num4];
			num ^= 0x3BC40671U;
			uint[] array2 = array;
			num <<= 0x10;
			uint num5;
			do
			{
				this.uint_0 = new uint[num ^ 0x29640020U];
				num5 = (num ^ 0x29640007U);
				num ^= 0x8703072U;
				array2[(int)(num ^ 0x21143073U)] = num + 0xDEEBCF8EU;
			}
			while (num % 0x641B18CFU == 0U);
			while (0x72C438E7U != num)
			{
				uint num6 = num5;
				uint num7 = num ^ 0xDEEBCF8DU;
				num = (0x1B980474U ^ num);
				if (num6 == num7)
				{
					num -= 0x3963300CU;
					uint[] array3 = this.uint_0;
					int num8 = (int)(num + 0xFED6FC06U);
					num *= 0x36234906U;
					array3[num8] = num + 0x776DF08DU;
					num = 0x3F144A32U >> (int)num;
					uint num9 = num + 0xFFFFFFFEU;
					num = 0x58641317U - num;
					num5 = num9;
					while (num < 0x605B5AB8U)
					{
						uint num10 = num5;
						uint num11 = num + 0xA79BED0CU;
						num = (0x2F67C21U & num);
						if (num10 >= num11)
						{
							num = 0x919318FU - num;
							uint num12 = num + 0xF74ADE71U;
							num = 0x8322D37U / num;
							uint num13 = num12;
							num = 0x4BF26F6CU * num;
							uint num14 = num12;
							num5 = num12;
							num ^= 0x40B85EA8U;
							uint num15 = num12;
							uint num16 = num12;
							while (0x1D382388U <= num)
							{
								if (num13 >= (num ^ 0x40B85EC8U))
								{
									return;
								}
								num16 = (this.uint_0[(int)num5] = GClass9.smethod_0(this.uint_0[(int)num5] + num16 + num15, 3));
								num15 = (array2[(int)num14] = GClass9.smethod_0(array2[(int)num14] + num16 + num15, (int)(num16 + num15)));
								num13 += 1U;
								num5 = (num5 + 1U) % 0x20U;
								num14 = (num14 + 1U) % 2U;
								num = 0x40B85EA8U;
							}
							break;
						}
						this.uint_0[(int)num5] = this.uint_0[(int)(num5 - 1U)] + 0x1FD036FBU;
						num5 += 1U;
						num = 0x58641314U;
					}
					break;
				}
				array2[(int)(num5 / num3)] = (array2[(int)(num5 / num3)] << 8) + (uint)byte_0[(int)num5];
				num5 -= 1U;
				num = 0x21143072U;
			}
		}
	}

	// Token: 0x0600134F RID: 4943 RVA: 0x0008D2EC File Offset: 0x0008B4EC
	private void method_0(ref GClass6.Struct23 struct23_0)
	{
		for (;;)
		{
			uint num = struct23_0.uint_0 + this.uint_0[0];
			uint num2 = struct23_0.uint_1 + this.uint_0[1];
			uint num3 = 0xC4CC152U;
			uint num4 = num2;
			for (;;)
			{
				uint num5 = num3 - 0xC4CC151U;
				num3 = 0x69041639U - num3;
				uint num6 = num5;
				if (0x27B54FFU - num3 == 0U)
				{
					goto IL_74;
				}
				IL_4C:
				num3 = 0x2DE005FAU % num3;
				if (num3 == 0x2E53758AU)
				{
					continue;
				}
				uint num7 = num6;
				uint num8 = num3 ^ 0x2DE005F5U;
				num3 = 0x1FA0756DU - num3;
				if (num7 > num8)
				{
					break;
				}
				IL_74:
				num = GClass9.smethod_0(num ^ num4, (int)num4) + this.uint_0[(int)(2U * num6)];
				num4 = GClass9.smethod_0(num4 ^ num, (int)num) + this.uint_0[(int)(2U * num6 + 1U)];
				num6 += 1U;
				num3 = 0x5CB754E7U;
				goto IL_4C;
			}
			if (num3 % 0x51840274U != 0U)
			{
				struct23_0.uint_0 = num;
				num3 = (0x61646E3CU | num3);
				struct23_0.uint_1 = num4;
				if (num3 - 0x43DD4564U != 0U)
				{
					break;
				}
			}
		}
	}

	// Token: 0x06001350 RID: 4944 RVA: 0x0008D438 File Offset: 0x0008B638
	private void method_1(ref GClass6.Struct23 struct23_0)
	{
		uint num = struct23_0.uint_1;
		uint num2 = 0U;
		uint num3 = struct23_0.uint_0;
		uint num4 = 0xFU;
		for (;;)
		{
			num2 = 0x5F231E7FU - num2;
			uint num5 = num4;
			uint num6 = num2 ^ 0x5F231E7FU;
			num2 %= 0x48B1D8CU;
			if (num5 <= num6 && 0x5E33112FU != num2)
			{
				break;
			}
			num = (GClass9.smethod_1(num - this.uint_0[(int)(2U * num4 + 1U)], (int)num3) ^ num3);
			num3 = (GClass9.smethod_1(num3 - this.uint_0[(int)(2U * num4)], (int)num) ^ num);
			num4 -= 1U;
			num2 = 0U;
		}
		uint num7 = num;
		uint[] array = this.uint_0;
		int num8 = (int)(num2 + 0xFBBB3072U);
		num2 = (0x62FA63C9U ^ num2);
		uint num9 = num7 - array[num8];
		num2 = 0x67D24044U >> (int)num2;
		struct23_0.uint_1 = num9;
		uint num10 = num3;
		num2 %= 0x3665171BU;
		num2 = (0xB403BF2U ^ num2);
		uint[] array2 = this.uint_0;
		num2 = (0x72435A98U & num2);
		struct23_0.uint_0 = num10 - array2[(int)(num2 - 0x2435290U)];
	}

	// Token: 0x06001351 RID: 4945 RVA: 0x0008D584 File Offset: 0x0008B784
	public byte[] method_2(byte[] byte_0)
	{
		uint num = 0x51B01U;
		byte[] array = new byte[byte_0.Length];
		do
		{
			num *= 0x2CC022CFU;
			byte[] byte_ = array;
			num *= 0x23E378F0U;
			this.method_4(byte_0, byte_);
		}
		while (num == 0x7FB925A5U);
		return array;
	}

	// Token: 0x06001352 RID: 4946 RVA: 0x0008D5C8 File Offset: 0x0008B7C8
	public byte[] method_3(byte[] byte_0)
	{
		byte[] array = new byte[byte_0.Length];
		this.method_5(byte_0, array);
		return array;
	}

	// Token: 0x06001353 RID: 4947 RVA: 0x0008D5E8 File Offset: 0x0008B7E8
	public void method_4(byte[] byte_0, byte[] byte_1)
	{
		GClass6.Struct23 @struct = default(GClass6.Struct23);
		int num = 0;
		uint num2 = 0x4ABF52D7U;
		int num3 = num;
		for (;;)
		{
			num2 /= 0x53FB53AAU;
			int num4 = num3;
			num2 <<= 0x1F;
			int num5 = byte_0.Length;
			num2 -= 0xB112386U;
			if (num4 >= num5)
			{
				break;
			}
			@struct.ulong_0 = BitConverter.ToUInt64(byte_0, num3);
			this.method_0(ref @struct);
			BitConverter.GetBytes(@struct.ulong_0).CopyTo(byte_1, num3);
			num3 += 8;
			num2 = 0x4ABF52D7U;
		}
	}

	// Token: 0x06001354 RID: 4948 RVA: 0x0008D698 File Offset: 0x0008B898
	public void method_5(byte[] byte_0, byte[] byte_1)
	{
		GClass6.Struct23 @struct = default(GClass6.Struct23);
		int num = 0;
		for (;;)
		{
			uint num2 = 0x7F2B7AA5U;
			if (num >= byte_0.Length)
			{
				if (num2 > 0x3C83250CU)
				{
					break;
				}
			}
			else
			{
				@struct.ulong_0 = BitConverter.ToUInt64(byte_0, num);
				this.method_1(ref @struct);
				BitConverter.GetBytes(@struct.ulong_0).CopyTo(byte_1, num);
				num += 8;
			}
		}
	}

	// Token: 0x04000AA1 RID: 2721
	private const int int_0 = 0xF;

	// Token: 0x04000AA2 RID: 2722
	private const int int_1 = 8;

	// Token: 0x04000AA3 RID: 2723
	private const int int_2 = 2;

	// Token: 0x04000AA4 RID: 2724
	private const int int_3 = 0x20;

	// Token: 0x04000AA5 RID: 2725
	private readonly uint[] uint_0;

	// Token: 0x04000AA6 RID: 2726
	private const uint uint_1 = 0xFACE0001U;

	// Token: 0x04000AA7 RID: 2727
	private const uint uint_2 = 0xFACE0002U;

	// Token: 0x020001DC RID: 476
	[StructLayout(LayoutKind.Explicit)]
	private struct Struct23
	{
		// Token: 0x04000AA8 RID: 2728
		[FieldOffset(0)]
		public ulong ulong_0;

		// Token: 0x04000AA9 RID: 2729
		[FieldOffset(0)]
		public uint uint_0;

		// Token: 0x04000AAA RID: 2730
		[FieldOffset(4)]
		public uint uint_1;
	}
}
