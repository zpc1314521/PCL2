using System;
using System.IO;

// Token: 0x020001D0 RID: 464
class Class5
{
	// Token: 0x0600131E RID: 4894 RVA: 0x0008B5DC File Offset: 0x000897DC
	public void method_0(Stream stream_1)
	{
		this.stream_0 = stream_1;
		this.uint_3 = 0U;
		this.uint_2 = uint.MaxValue;
		for (int i = 0; i < 5; i++)
		{
			this.uint_3 = (this.uint_3 << 8 | (uint)((byte)this.stream_0.ReadByte()));
		}
	}

	// Token: 0x0600131F RID: 4895 RVA: 0x0000C08E File Offset: 0x0000A28E
	public void method_1()
	{
		this.stream_0 = null;
	}

	// Token: 0x06001320 RID: 4896 RVA: 0x0008B628 File Offset: 0x00089828
	public uint method_2(int int_0)
	{
		uint num = this.uint_2;
		uint num2 = this.uint_3;
		uint num3 = 0U;
		for (int i = int_0; i > 0; i--)
		{
			num >>= 1;
			uint num4 = num2 - num >> 0x1F;
			num2 -= (num & num4 - 1U);
			num3 = (num3 << 1 | 1U - num4);
			if (num < 0x1000000U)
			{
				num2 = (num2 << 8 | (uint)((byte)this.stream_0.ReadByte()));
				num <<= 8;
			}
		}
		this.uint_2 = num;
		this.uint_3 = num2;
		return num3;
	}

	// Token: 0x06001321 RID: 4897 RVA: 0x0000C097 File Offset: 0x0000A297
	public Class5()
	{
		this.uint_0 = 1U;
		base..ctor();
	}

	// Token: 0x04000A6C RID: 2668
	private uint uint_0;

	// Token: 0x04000A6D RID: 2669
	public const uint uint_1 = 0x1000000U;

	// Token: 0x04000A6E RID: 2670
	public uint uint_2;

	// Token: 0x04000A6F RID: 2671
	public uint uint_3;

	// Token: 0x04000A70 RID: 2672
	public Stream stream_0;
}
