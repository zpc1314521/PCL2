using System;
using System.Diagnostics;

// Token: 0x020001C7 RID: 455
[Serializable]
struct Struct17
{
	// Token: 0x060012C7 RID: 4807 RVA: 0x0000BCAF File Offset: 0x00009EAF
	[Conditional("DEBUG")]
	private void method_0()
	{
		if (this.uint_1 != null)
		{
			Struct17.smethod_11(this.uint_1);
		}
	}

	// Token: 0x17000348 RID: 840
	// (get) Token: 0x060012C8 RID: 4808 RVA: 0x0000BCC5 File Offset: 0x00009EC5
	private bool Boolean_0
	{
		get
		{
			if (this.uint_1 != null)
			{
				return (this.uint_1[0] & 1U) == 0U;
			}
			return (this.int_1 & 1) == 0;
		}
	}

	// Token: 0x17000349 RID: 841
	// (get) Token: 0x060012C9 RID: 4809 RVA: 0x0000BCE8 File Offset: 0x00009EE8
	private int Int32_0
	{
		get
		{
			return (this.int_1 >> 0x1F) - (-this.int_1 >> 0x1F);
		}
	}

	// Token: 0x060012CA RID: 4810 RVA: 0x0000BCFE File Offset: 0x00009EFE
	public bool F445C1DF(object object_0)
	{
		return object_0 is Struct17 && this.Equals((Struct17)object_0);
	}

	// Token: 0x060012CB RID: 4811 RVA: 0x00089AB4 File Offset: 0x00087CB4
	public int vmethod_0()
	{
		if (this.uint_1 == null)
		{
			return this.int_1;
		}
		int result = this.int_1;
		int num = Struct17.smethod_11(this.uint_1);
		while (--num >= 0)
		{
			result = Class1.smethod_7(result, (int)this.uint_1[num]);
		}
		return result;
	}

	// Token: 0x060012CC RID: 4812 RVA: 0x00089B00 File Offset: 0x00087D00
	private int method_1(Struct17 struct17_4)
	{
		if ((this.int_1 ^ struct17_4.int_1) < 0)
		{
			if (this.int_1 >= 0)
			{
				return 1;
			}
			return -1;
		}
		else if (this.uint_1 == null)
		{
			if (struct17_4.uint_1 != null)
			{
				return -struct17_4.int_1;
			}
			if (this.int_1 < struct17_4.int_1)
			{
				return -1;
			}
			if (this.int_1 <= struct17_4.int_1)
			{
				return 0;
			}
			return 1;
		}
		else
		{
			int num;
			int num2;
			if (struct17_4.uint_1 == null || (num = Struct17.smethod_11(this.uint_1)) > (num2 = Struct17.smethod_11(struct17_4.uint_1)))
			{
				return this.int_1;
			}
			if (num < num2)
			{
				return -this.int_1;
			}
			int num3 = Struct17.smethod_12(this.uint_1, struct17_4.uint_1, num);
			if (num3 == 0)
			{
				return 0;
			}
			if (this.uint_1[num3 - 1] >= struct17_4.uint_1[num3 - 1])
			{
				return this.int_1;
			}
			return -this.int_1;
		}
	}

	// Token: 0x060012CD RID: 4813 RVA: 0x00089BD8 File Offset: 0x00087DD8
	internal byte[] method_2()
	{
		if (this.uint_1 == null && this.int_1 == 0)
		{
			return new byte[1];
		}
		uint[] array;
		byte b;
		if (this.uint_1 == null)
		{
			array = new uint[]
			{
				(uint)this.int_1
			};
			b = ((this.int_1 < 0) ? byte.MaxValue : 0);
		}
		else if (this.int_1 == -1)
		{
			array = (uint[])this.uint_1.Clone();
			Class1.smethod_0(array);
			b = byte.MaxValue;
		}
		else
		{
			array = this.uint_1;
			b = 0;
		}
		byte[] array2 = new byte[checked(4 * array.Length)];
		int num = 0;
		foreach (uint num2 in array)
		{
			for (int j = 0; j < 4; j++)
			{
				array2[num++] = (byte)(num2 & 0xFFU);
				num2 >>= 8;
			}
		}
		if ((array2[array2.Length - 1] & 0x80) == (b & 0x80))
		{
			return array2;
		}
		byte[] array4 = new byte[array2.Length + 1];
		Array.Copy(array2, array4, array2.Length);
		array4[array4.Length - 1] = b;
		return array4;
	}

	// Token: 0x060012CE RID: 4814 RVA: 0x0000BD21 File Offset: 0x00009F21
	private Struct17(int int_2)
	{
		if (int_2 == -0x80000000)
		{
			this = Struct17.struct17_0;
			return;
		}
		this.int_1 = int_2;
		this.uint_1 = null;
	}

	// Token: 0x060012CF RID: 4815 RVA: 0x00089CE8 File Offset: 0x00087EE8
	internal Struct17(byte[] byte_0)
	{
		if (byte_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		int num = byte_0.Length;
		bool flag = num > 0 && (byte_0[num - 1] & 0x80) == 0x80;
		while (num > 0 && byte_0[num - 1] == 0)
		{
			num--;
		}
		if (num == 0)
		{
			this.int_1 = 0;
			this.uint_1 = null;
			return;
		}
		if (num <= 4)
		{
			if (flag)
			{
				this.int_1 = -1;
			}
			else
			{
				this.int_1 = 0;
			}
			for (int i = num - 1; i >= 0; i--)
			{
				this.int_1 <<= 8;
				this.int_1 |= (int)byte_0[i];
			}
			this.uint_1 = null;
			if (this.int_1 < 0 && !flag)
			{
				this.uint_1 = new uint[1];
				this.uint_1[0] = (uint)this.int_1;
				this.int_1 = 1;
			}
			if (this.int_1 == -0x80000000)
			{
				this = Struct17.struct17_0;
				return;
			}
		}
		else
		{
			int num2 = num % 4;
			int num3 = num / 4 + ((num2 == 0) ? 0 : 1);
			bool flag2 = true;
			uint[] array = new uint[num3];
			int j = 3;
			int k;
			for (k = 0; k < num3 - ((num2 != 0) ? 1 : 0); k++)
			{
				for (int l = 0; l < 4; l++)
				{
					if (byte_0[j] != 0)
					{
						flag2 = false;
					}
					array[k] <<= 8;
					array[k] |= (uint)byte_0[j];
					j--;
				}
				j += 8;
			}
			if (num2 != 0)
			{
				if (flag)
				{
					array[num3 - 1] = uint.MaxValue;
				}
				for (j = num - 1; j >= num - num2; j--)
				{
					if (byte_0[j] != 0)
					{
						flag2 = false;
					}
					array[k] <<= 8;
					array[k] |= (uint)byte_0[j];
				}
			}
			if (flag2)
			{
				this = Struct17.struct17_2;
				return;
			}
			if (flag)
			{
				Class1.smethod_0(array);
				int num4 = array.Length;
				while (num4 > 0 && array[num4 - 1] == 0U)
				{
					num4--;
				}
				if (num4 == 1 && array[0] > 0U)
				{
					if (array[0] == 1U)
					{
						this = Struct17.struct17_3;
						return;
					}
					if (array[0] == 0x80000000U)
					{
						this = Struct17.struct17_0;
						return;
					}
					this.int_1 = (int)(uint.MaxValue * array[0]);
					this.uint_1 = null;
					return;
				}
				else
				{
					if (num4 != array.Length)
					{
						this.int_1 = -1;
						this.uint_1 = new uint[num4];
						Array.Copy(array, this.uint_1, num4);
						return;
					}
					this.int_1 = -1;
					this.uint_1 = array;
					return;
				}
			}
			else
			{
				this.int_1 = 1;
				this.uint_1 = array;
			}
		}
	}

	// Token: 0x060012D0 RID: 4816 RVA: 0x0000BD45 File Offset: 0x00009F45
	internal Struct17(int int_2, uint[] uint_2)
	{
		this.int_1 = int_2;
		this.uint_1 = uint_2;
	}

	// Token: 0x060012D1 RID: 4817 RVA: 0x0000BD55 File Offset: 0x00009F55
	private static void smethod_0(ref Struct18 struct18_0, ref Struct18 struct18_1, ref Struct18 struct18_2, ref Struct18 struct18_3)
	{
		Class1.smethod_2<Struct18>(ref struct18_0, ref struct18_3);
		struct18_0.method_12(ref struct18_3, ref struct18_1);
		struct18_0.method_13(ref struct18_2);
	}

	// Token: 0x060012D2 RID: 4818 RVA: 0x0000BD6D File Offset: 0x00009F6D
	private static void smethod_1(ref Struct18 struct18_0, ref Struct18 struct18_1, ref Struct18 struct18_2)
	{
		Class1.smethod_2<Struct18>(ref struct18_0, ref struct18_2);
		struct18_0.method_12(ref struct18_2, ref struct18_2);
		struct18_0.method_13(ref struct18_1);
	}

	// Token: 0x060012D3 RID: 4819 RVA: 0x0000BD85 File Offset: 0x00009F85
	private static void smethod_2(uint uint_2, ref Struct18 struct18_0, ref Struct18 struct18_1, ref Struct18 struct18_2, ref Struct18 struct18_3)
	{
		while (uint_2 != 0U)
		{
			if ((uint_2 & 1U) == 1U)
			{
				Struct17.smethod_0(ref struct18_0, ref struct18_1, ref struct18_2, ref struct18_3);
			}
			if (uint_2 == 1U)
			{
				break;
			}
			Struct17.smethod_1(ref struct18_1, ref struct18_2, ref struct18_3);
			uint_2 >>= 1;
		}
	}

	// Token: 0x060012D4 RID: 4820 RVA: 0x00089F70 File Offset: 0x00088170
	private static void smethod_3(uint uint_2, ref Struct18 struct18_0, ref Struct18 struct18_1, ref Struct18 struct18_2, ref Struct18 struct18_3)
	{
		for (int i = 0; i < 0x20; i++)
		{
			if ((uint_2 & 1U) == 1U)
			{
				Struct17.smethod_0(ref struct18_0, ref struct18_1, ref struct18_2, ref struct18_3);
			}
			Struct17.smethod_1(ref struct18_1, ref struct18_2, ref struct18_3);
			uint_2 >>= 1;
		}
	}

	// Token: 0x060012D5 RID: 4821 RVA: 0x00089FA8 File Offset: 0x000881A8
	internal static Struct17 smethod_4(Struct17 struct17_4, Struct17 struct17_5, Struct17 struct17_6)
	{
		if (struct17_5.Int32_0 < 0)
		{
			throw new ArgumentOutOfRangeException("exponent", "ArgumentOutOfRange must be non negative");
		}
		int num = 1;
		int num2 = 1;
		int num3 = 1;
		bool boolean_ = struct17_5.Boolean_0;
		Struct18 @struct = new Struct18(Struct17.struct17_1, ref num);
		Struct18 struct2 = new Struct18(struct17_4, ref num2);
		Struct18 struct3 = new Struct18(struct17_6, ref num3);
		Struct18 struct4 = new Struct18(struct2.Int32_0);
		@struct.method_13(ref struct3);
		if (struct17_5.uint_1 == null)
		{
			Struct17.smethod_2((uint)struct17_5.int_1, ref @struct, ref struct2, ref struct3, ref struct4);
		}
		else
		{
			int num4 = Struct17.smethod_11(struct17_5.uint_1);
			for (int i = 0; i < num4 - 1; i++)
			{
				Struct17.smethod_3(struct17_5.uint_1[i], ref @struct, ref struct2, ref struct3, ref struct4);
			}
			Struct17.smethod_2(struct17_5.uint_1[num4 - 1], ref @struct, ref struct2, ref struct3, ref struct4);
		}
		return @struct.method_1((struct17_4.int_1 > 0) ? 1 : (boolean_ ? 1 : -1));
	}

	// Token: 0x060012D6 RID: 4822 RVA: 0x0000BDAF File Offset: 0x00009FAF
	public static bool smethod_5(Struct17 struct17_4, Struct17 struct17_5)
	{
		return struct17_4.method_1(struct17_5) < 0;
	}

	// Token: 0x060012D7 RID: 4823 RVA: 0x0000BDBC File Offset: 0x00009FBC
	public static bool smethod_6(Struct17 struct17_4, Struct17 struct17_5)
	{
		return struct17_4.method_1(struct17_5) <= 0;
	}

	// Token: 0x060012D8 RID: 4824 RVA: 0x0000BDCC File Offset: 0x00009FCC
	public static bool smethod_7(Struct17 struct17_4, Struct17 struct17_5)
	{
		return struct17_4.method_1(struct17_5) > 0;
	}

	// Token: 0x060012D9 RID: 4825 RVA: 0x0000BDD9 File Offset: 0x00009FD9
	public static bool smethod_8(Struct17 struct17_4, Struct17 struct17_5)
	{
		return struct17_4.method_1(struct17_5) >= 0;
	}

	// Token: 0x060012DA RID: 4826 RVA: 0x0000BDE9 File Offset: 0x00009FE9
	public static bool smethod_9(Struct17 struct17_4, Struct17 struct17_5)
	{
		return struct17_4.Equals(struct17_5);
	}

	// Token: 0x060012DB RID: 4827 RVA: 0x0000BDFE File Offset: 0x00009FFE
	public static bool smethod_10(Struct17 struct17_4, Struct17 struct17_5)
	{
		return !struct17_4.Equals(struct17_5);
	}

	// Token: 0x060012DC RID: 4828 RVA: 0x0008A09C File Offset: 0x0008829C
	private static int smethod_11(uint[] uint_2)
	{
		int num = uint_2.Length;
		if (uint_2[num - 1] != 0U)
		{
			return num;
		}
		return num - 1;
	}

	// Token: 0x1700034A RID: 842
	// (get) Token: 0x060012DD RID: 4829 RVA: 0x0000BE16 File Offset: 0x0000A016
	internal int Int32_1
	{
		get
		{
			return this.int_1;
		}
	}

	// Token: 0x1700034B RID: 843
	// (get) Token: 0x060012DE RID: 4830 RVA: 0x0000BE1E File Offset: 0x0000A01E
	internal uint[] UInt32_0
	{
		get
		{
			return this.uint_1;
		}
	}

	// Token: 0x060012DF RID: 4831 RVA: 0x0008A0BC File Offset: 0x000882BC
	private static int smethod_12(uint[] uint_2, uint[] uint_3, int int_2)
	{
		int num = int_2;
		while (--num >= 0)
		{
			if (uint_2[num] != uint_3[num])
			{
				return num + 1;
			}
		}
		return 0;
	}

	// Token: 0x060012E0 RID: 4832 RVA: 0x0000BE26 File Offset: 0x0000A026
	// Note: this type is marked as 'beforefieldinit'.
	static Struct17()
	{
		Struct17.struct17_0 = new Struct17(-1, new uint[]
		{
			0x80000000U
		});
		Struct17.struct17_1 = new Struct17(1);
		Struct17.struct17_2 = new Struct17(0);
		Struct17.struct17_3 = new Struct17(-1);
	}

	// Token: 0x04000A2F RID: 2607
	private const uint uint_0 = 0x80000000U;

	// Token: 0x04000A30 RID: 2608
	private const int int_0 = 0x20;

	// Token: 0x04000A31 RID: 2609
	private readonly int int_1;

	// Token: 0x04000A32 RID: 2610
	private readonly uint[] uint_1;

	// Token: 0x04000A33 RID: 2611
	private static readonly Struct17 struct17_0;

	// Token: 0x04000A34 RID: 2612
	private static readonly Struct17 struct17_1;

	// Token: 0x04000A35 RID: 2613
	private static readonly Struct17 struct17_2;

	// Token: 0x04000A36 RID: 2614
	private static readonly Struct17 struct17_3;
}
