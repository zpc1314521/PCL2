using System;

// Token: 0x020001E8 RID: 488
public static class GClass16
{
	// Token: 0x06001378 RID: 4984 RVA: 0x0008DA4C File Offset: 0x0008BC4C
	internal static bool smethod_0(byte[] byte_0)
	{
		for (int i = 0; i < byte_0.Length; i++)
		{
			if (i + 3 < byte_0.Length && byte_0[i] == 0x51 && byte_0[i + 1] == 0x45 && byte_0[i + 2] == 0x4D && byte_0[i + 3] == 0x55)
			{
				return true;
			}
			if (i + 8 < byte_0.Length && byte_0[i] == 0x4D && byte_0[i + 1] == 0x69 && byte_0[i + 2] == 0x63 && byte_0[i + 3] == 0x72 && byte_0[i + 4] == 0x6F && byte_0[i + 5] == 0x73 && byte_0[i + 6] == 0x6F && byte_0[i + 7] == 0x66 && byte_0[i + 8] == 0x74)
			{
				return true;
			}
			if (i + 6 < byte_0.Length && byte_0[i] == 0x69 && byte_0[i + 1] == 0x6E && byte_0[i + 2] == 0x6E && byte_0[i + 3] == 0x6F && byte_0[i + 4] == 0x74 && byte_0[i + 5] == 0x65 && byte_0[i + 6] == 0x6B)
			{
				return true;
			}
			if (i + 9 < byte_0.Length && byte_0[i] == 0x56 && byte_0[i + 1] == 0x69 && byte_0[i + 2] == 0x72 && byte_0[i + 3] == 0x74 && byte_0[i + 4] == 0x75 && byte_0[i + 5] == 0x61 && byte_0[i + 6] == 0x6C && byte_0[i + 7] == 0x42 && byte_0[i + 8] == 0x6F && byte_0[i + 9] == 0x78)
			{
				return true;
			}
			if (i + 5 < byte_0.Length && byte_0[i] == 0x56 && byte_0[i + 1] == 0x4D && byte_0[i + 2] == 0x77 && byte_0[i + 3] == 0x61 && byte_0[i + 4] == 0x72 && byte_0[i + 5] == 0x65)
			{
				return true;
			}
			if (i + 8 < byte_0.Length && byte_0[i] == 0x50 && byte_0[i + 1] == 0x61 && byte_0[i + 2] == 0x72 && byte_0[i + 3] == 0x61 && byte_0[i + 4] == 0x6C && byte_0[i + 5] == 0x6C && byte_0[i + 6] == 0x65 && byte_0[i + 7] == 0x6C && byte_0[i + 8] == 0x73)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x04000AC6 RID: 2758
	public static object[] object_0;
}
