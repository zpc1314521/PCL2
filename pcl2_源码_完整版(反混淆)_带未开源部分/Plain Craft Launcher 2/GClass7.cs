using System;
using System.Runtime.InteropServices;

// Token: 0x020001DD RID: 477
public class GClass7
{
	// Token: 0x06001355 RID: 4949 RVA: 0x0008D72C File Offset: 0x0008B92C
	public GClass7()
	{
		if (GClass7.uint_0 == null)
		{
			GClass7.uint_0 = new uint[0x100];
			for (int i = 0; i < 0x100; i++)
			{
				uint num = (uint)i;
				for (int j = 0; j < 8; j++)
				{
					if ((num & 1U) == 1U)
					{
						num = (num >> 1 ^ 0xEDB88320U);
					}
					else
					{
						num >>= 1;
					}
				}
				GClass7.uint_0[i] = num;
			}
		}
	}

	// Token: 0x06001356 RID: 4950 RVA: 0x0008D794 File Offset: 0x0008B994
	public uint method_0(IntPtr intptr_0, uint uint_1)
	{
		uint num = 0U;
		int num2 = 0;
		while ((long)num2 < (long)((ulong)uint_1))
		{
			num = (GClass7.uint_0[(int)(((uint)Marshal.ReadByte(new IntPtr(intptr_0.ToInt64() + (long)num2)) ^ num) & 0xFFU)] ^ num >> 8);
			num2++;
		}
		return ~num;
	}

	// Token: 0x04000AAB RID: 2731
	private static uint[] uint_0;
}
