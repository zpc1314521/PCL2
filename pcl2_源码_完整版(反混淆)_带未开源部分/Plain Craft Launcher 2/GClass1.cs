using System;
using System.IO;

// Token: 0x020001D3 RID: 467
public class GClass1
{
	// Token: 0x06001329 RID: 4905 RVA: 0x0000C0CD File Offset: 0x0000A2CD
	public void method_0(uint uint_5)
	{
		if (this.uint_1 != uint_5)
		{
			this.byte_0 = new byte[uint_5];
		}
		this.uint_1 = uint_5;
		this.uint_0 = 0U;
		this.uint_2 = 0U;
	}

	// Token: 0x0600132A RID: 4906 RVA: 0x0000C0F9 File Offset: 0x0000A2F9
	public void method_1(Stream stream_1, bool bool_0)
	{
		this.method_2();
		this.stream_0 = stream_1;
		if (!bool_0)
		{
			this.uint_2 = 0U;
			this.uint_0 = 0U;
			this.uint_4 = 0U;
		}
	}

	// Token: 0x0600132B RID: 4907 RVA: 0x0000C120 File Offset: 0x0000A320
	public void method_2()
	{
		this.method_3();
		this.stream_0 = null;
	}

	// Token: 0x0600132C RID: 4908 RVA: 0x0008B88C File Offset: 0x00089A8C
	public void method_3()
	{
		uint num = this.uint_0 - this.uint_2;
		if (num == 0U)
		{
			return;
		}
		this.stream_0.Write(this.byte_0, (int)this.uint_2, (int)num);
		if (this.uint_0 >= this.uint_1)
		{
			this.uint_0 = 0U;
		}
		this.uint_2 = this.uint_0;
	}

	// Token: 0x0600132D RID: 4909 RVA: 0x0008B8E4 File Offset: 0x00089AE4
	public void method_4(uint uint_5, uint uint_6)
	{
		uint num = this.uint_0 - uint_5 - 1U;
		if (num >= this.uint_1)
		{
			num += this.uint_1;
		}
		while (uint_6 > 0U)
		{
			if (num >= this.uint_1)
			{
				num = 0U;
			}
			byte[] array = this.byte_0;
			uint num2 = this.uint_0;
			this.uint_0 = num2 + 1U;
			array[(int)num2] = this.byte_0[(int)num++];
			if (this.uint_0 >= this.uint_1)
			{
				this.method_3();
			}
			uint_6 -= 1U;
		}
	}

	// Token: 0x0600132E RID: 4910 RVA: 0x0008B95C File Offset: 0x00089B5C
	public void method_5(byte byte_1)
	{
		byte[] array = this.byte_0;
		uint num = this.uint_0;
		this.uint_0 = num + 1U;
		array[(int)num] = byte_1;
		if (this.uint_0 >= this.uint_1)
		{
			this.method_3();
		}
	}

	// Token: 0x0600132F RID: 4911 RVA: 0x0008B998 File Offset: 0x00089B98
	public byte method_6(uint uint_5)
	{
		uint num = this.uint_0 - uint_5 - 1U;
		if (num >= this.uint_1)
		{
			num += this.uint_1;
		}
		return this.byte_0[(int)num];
	}

	// Token: 0x06001330 RID: 4912 RVA: 0x0000C12F File Offset: 0x0000A32F
	public GClass1()
	{
		this.uint_3 = 1U;
		base..ctor();
	}

	// Token: 0x04000A77 RID: 2679
	private byte[] byte_0;

	// Token: 0x04000A78 RID: 2680
	private uint uint_0;

	// Token: 0x04000A79 RID: 2681
	private uint uint_1;

	// Token: 0x04000A7A RID: 2682
	private uint uint_2;

	// Token: 0x04000A7B RID: 2683
	private Stream stream_0;

	// Token: 0x04000A7C RID: 2684
	private uint uint_3;

	// Token: 0x04000A7D RID: 2685
	public uint uint_4;
}
