using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

// Token: 0x0200020C RID: 524
static class Class39
{
	// Token: 0x0600156F RID: 5487 RVA: 0x0009C0E4 File Offset: 0x0009A2E4
	public static IntPtr smethod_0(string string_0, int int_5, int int_6, IntPtr intptr_3, int int_7, int int_8, IntPtr intptr_4)
	{
		if (string.Equals(Path.GetFullPath(string_0), Assembly.GetExecutingAssembly().Location, StringComparison.OrdinalIgnoreCase))
		{
			string_0 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "2.2.3.exe.hash");
		}
		return Class39.CreateFile(string_0, int_5, int_6, intptr_3, int_7, int_8, intptr_4);
	}

	// Token: 0x06001570 RID: 5488
	[DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern IntPtr CreateFileMapping(IntPtr intptr_3, IntPtr intptr_4, Class39.Enum2 enum2_0, int int_5, int int_6, string string_0);

	// Token: 0x06001571 RID: 5489
	[DllImport("kernel32", SetLastError = true)]
	public static extern bool FlushViewOfFile(IntPtr intptr_3, int int_5);

	// Token: 0x06001572 RID: 5490
	[DllImport("kernel32", SetLastError = true)]
	public static extern IntPtr MapViewOfFile(IntPtr intptr_3, Class39.Enum3 enum3_0, int int_5, int int_6, IntPtr intptr_4);

	// Token: 0x06001573 RID: 5491
	[DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern IntPtr OpenFileMapping(int int_5, bool bool_0, string string_0);

	// Token: 0x06001574 RID: 5492
	[DllImport("kernel32", SetLastError = true)]
	public static extern bool UnmapViewOfFile(IntPtr intptr_3);

	// Token: 0x06001575 RID: 5493
	[DllImport("kernel32", SetLastError = true)]
	public static extern bool CloseHandle(IntPtr intptr_3);

	// Token: 0x06001576 RID: 5494
	[DllImport("kernel32", SetLastError = true)]
	public static extern uint GetFileSize(IntPtr intptr_3, IntPtr intptr_4);

	// Token: 0x06001577 RID: 5495
	[DllImport("kernel32", SetLastError = true)]
	public static extern IntPtr VirtualAlloc(IntPtr intptr_3, UIntPtr uintptr_0, Class39.Enum1 enum1_0, Class39.Enum2 enum2_0);

	// Token: 0x06001578 RID: 5496
	[DllImport("kernel32", SetLastError = true)]
	public static extern bool VirtualFree(IntPtr intptr_3, uint uint_0, uint uint_1);

	// Token: 0x06001579 RID: 5497
	[DllImport("kernel32", SetLastError = true)]
	public static extern bool VirtualProtect(IntPtr intptr_3, UIntPtr uintptr_0, Class39.Enum2 enum2_0, out Class39.Enum2 enum2_1);

	// Token: 0x0600157A RID: 5498
	[DllImport("kernel32", SetLastError = true)]
	public static extern bool GetVolumeInformation(string string_0, StringBuilder stringBuilder_0, uint uint_0, ref uint uint_1, ref uint uint_2, ref uint uint_3, StringBuilder stringBuilder_1, uint uint_4);

	// Token: 0x0600157B RID: 5499
	[DllImport("kernel32")]
	public static extern bool IsDebuggerPresent();

	// Token: 0x0600157C RID: 5500
	[DllImport("kernel32")]
	public static extern bool CheckRemoteDebuggerPresent();

	// Token: 0x0600157D RID: 5501
	[DllImport("kernel32", SetLastError = true)]
	public static extern uint EnumSystemFirmwareTables(uint uint_0, IntPtr intptr_3, uint uint_1);

	// Token: 0x0600157E RID: 5502
	[DllImport("kernel32", SetLastError = true)]
	public static extern uint GetSystemFirmwareTable(uint uint_0, uint uint_1, IntPtr intptr_3, uint uint_2);

	// Token: 0x0600157F RID: 5503
	[DllImport("ntdll")]
	public static extern int NtQueryInformationProcess(IntPtr intptr_3, int int_5, IntPtr intptr_4, uint uint_0, out uint uint_1);

	// Token: 0x06001580 RID: 5504 RVA: 0x0000D3D6 File Offset: 0x0000B5D6
	// Note: this type is marked as 'beforefieldinit'.
	static Class39()
	{
		Class39.intptr_0 = new IntPtr(-1);
		Class39.intptr_1 = IntPtr.Zero;
		Class39.intptr_2 = new IntPtr(-1);
	}

	// Token: 0x06001581 RID: 5505
	[DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr CreateFile(string string_0, int int_5, int int_6, IntPtr intptr_3, int int_7, int int_8, IntPtr intptr_4);

	// Token: 0x04000B03 RID: 2819
	public const int int_0 = -0x80000000;

	// Token: 0x04000B04 RID: 2820
	public const int int_1 = 3;

	// Token: 0x04000B05 RID: 2821
	public const int int_2 = 0x80;

	// Token: 0x04000B06 RID: 2822
	public const int int_3 = 1;

	// Token: 0x04000B07 RID: 2823
	public const int int_4 = 2;

	// Token: 0x04000B08 RID: 2824
	public static readonly IntPtr intptr_0;

	// Token: 0x04000B09 RID: 2825
	public static readonly IntPtr intptr_1;

	// Token: 0x04000B0A RID: 2826
	public static readonly IntPtr intptr_2;

	// Token: 0x0200020D RID: 525
	[Flags]
	public enum Enum1 : uint
	{
		// Token: 0x04000B0C RID: 2828
		flag_0 = 0x1000U,
		// Token: 0x04000B0D RID: 2829
		flag_1 = 0x2000U
	}

	// Token: 0x0200020E RID: 526
	[Flags]
	public enum Enum2 : uint
	{
		// Token: 0x04000B0F RID: 2831
		flag_0 = 1U,
		// Token: 0x04000B10 RID: 2832
		flag_1 = 2U,
		// Token: 0x04000B11 RID: 2833
		flag_2 = 4U,
		// Token: 0x04000B12 RID: 2834
		flag_3 = 8U,
		// Token: 0x04000B13 RID: 2835
		flag_4 = 0x10U,
		// Token: 0x04000B14 RID: 2836
		flag_5 = 0x20U,
		// Token: 0x04000B15 RID: 2837
		flag_6 = 0x40U,
		// Token: 0x04000B16 RID: 2838
		flag_7 = 0x100U
	}

	// Token: 0x0200020F RID: 527
	[Flags]
	public enum Enum3 : uint
	{
		// Token: 0x04000B18 RID: 2840
		flag_0 = 1U,
		// Token: 0x04000B19 RID: 2841
		flag_1 = 2U,
		// Token: 0x04000B1A RID: 2842
		flag_2 = 4U,
		// Token: 0x04000B1B RID: 2843
		flag_3 = 0x1FU
	}

	// Token: 0x02000210 RID: 528
	[Flags]
	public enum Enum4 : uint
	{
		// Token: 0x04000B1D RID: 2845
		flag_0 = 0x20000000U,
		// Token: 0x04000B1E RID: 2846
		flag_1 = 0x40000000U,
		// Token: 0x04000B1F RID: 2847
		flag_2 = 0x80000000U
	}
}
