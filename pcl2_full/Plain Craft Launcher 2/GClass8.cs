using System;

// Token: 0x020001DE RID: 478
public class GClass8
{
	// Token: 0x06001357 RID: 4951 RVA: 0x0000C231 File Offset: 0x0000A431
	public GClass8()
	{
		this.uint_0 = 0x64B217AU;
	}

	// Token: 0x06001358 RID: 4952 RVA: 0x0008D7DC File Offset: 0x0008B9DC
	public uint method_0(uint uint_1)
	{
		uint num = uint_1 ^ this.uint_0;
		this.uint_0 = (GClass9.smethod_0(this.uint_0, 7) ^ num);
		return num;
	}

	// Token: 0x04000AAC RID: 2732
	private uint uint_0;
}
