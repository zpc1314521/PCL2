using System;
using System.Runtime.InteropServices;

// Token: 0x020001D9 RID: 473
public static class GClass5
{
	// Token: 0x06001348 RID: 4936 RVA: 0x0008CEB8 File Offset: 0x0008B0B8
	public static int[] smethod_0(int int_0)
	{
		IntPtr intPtr = IntPtr.Zero;
		int[] result;
		try
		{
			byte[] array = (IntPtr.Size == 4) ? GClass5.byte_0 : GClass5.byte_1;
			intPtr = Class39.VirtualAlloc(IntPtr.Zero, new UIntPtr((uint)array.Length), Class39.Enum1.flag_0 | Class39.Enum1.flag_1, Class39.Enum2.flag_6);
			Marshal.Copy(array, 0, intPtr, array.Length);
			GClass5.Delegate1 @delegate = (GClass5.Delegate1)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(GClass5.Delegate1));
			GCHandle a = default(GCHandle);
			int[] array2 = new int[4];
			try
			{
				a = GCHandle.Alloc(array2, GCHandleType.Pinned);
				@delegate(int_0, array2);
			}
			finally
			{
				if (a != default(GCHandle))
				{
					a.Free();
				}
			}
			result = array2;
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Class39.VirtualFree(intPtr, 0U, 0x8000U);
			}
		}
		return result;
	}

	// Token: 0x06001349 RID: 4937 RVA: 0x0000C201 File Offset: 0x0000A401
	// Note: this type is marked as 'beforefieldinit'.
	static GClass5()
	{
		GClass5.byte_0 = new byte[]
		{
			0x55,
			0x8B,
			0xEC,
			0x53,
			0x57,
			0x8B,
			0x45,
			8,
			0xF,
			0xA2,
			0x8B,
			0x7D,
			0xC,
			0x89,
			7,
			0x89,
			0x5F,
			4,
			0x89,
			0x4F,
			8,
			0x89,
			0x57,
			0xC,
			0x5F,
			0x5B,
			0x8B,
			0xE5,
			0x5D,
			0xC3
		};
		GClass5.byte_1 = new byte[]
		{
			0x53,
			0x49,
			0x89,
			0xD0,
			0x89,
			0xC8,
			0xF,
			0xA2,
			0x41,
			0x89,
			0x40,
			0,
			0x41,
			0x89,
			0x58,
			4,
			0x41,
			0x89,
			0x48,
			8,
			0x41,
			0x89,
			0x50,
			0xC,
			0x5B,
			0xC3
		};
	}

	// Token: 0x04000A9F RID: 2719
	private static readonly byte[] byte_0;

	// Token: 0x04000AA0 RID: 2720
	private static readonly byte[] byte_1;

	// Token: 0x020001DA RID: 474
	// (Invoke) Token: 0x0600134B RID: 4939
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate void Delegate1(int int_0, int[] int_1);
}
