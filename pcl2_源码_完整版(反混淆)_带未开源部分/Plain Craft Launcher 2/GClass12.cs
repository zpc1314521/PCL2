using System;
using System.Net.Security;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

// Token: 0x020001E3 RID: 483
public class GClass12
{
	// Token: 0x06001368 RID: 4968 RVA: 0x0008D8DC File Offset: 0x0008BADC
	public GClass12(long long_1)
	{
		object[] array = new object[]
		{
			this,
			long_1
		};
		new GClass18().method_112(array, 0xAF739);
	}

	// Token: 0x06001369 RID: 4969 RVA: 0x0008D914 File Offset: 0x0008BB14
	public GClass12(byte[] byte_2)
	{
		object[] array = new object[]
		{
			this,
			byte_2
		};
		new GClass18().method_112(array, 0xADE86);
	}

	// Token: 0x04000AB9 RID: 2745
	private readonly byte[] byte_0;

	// Token: 0x04000ABA RID: 2746
	private byte[] byte_1;

	// Token: 0x04000ABB RID: 2747
	private readonly object object_0;

	// Token: 0x04000ABC RID: 2748
	private GEnum0 genum0_0;

	// Token: 0x04000ABD RID: 2749
	private long long_0;

	// Token: 0x04000ABE RID: 2750
	private readonly int int_0;

	// Token: 0x04000ABF RID: 2751
	private int int_1;

	// Token: 0x04000AC0 RID: 2752
	private uint uint_0;

	// Token: 0x020001E4 RID: 484
	public class GClass13
	{
		// Token: 0x0600136A RID: 4970 RVA: 0x0008D948 File Offset: 0x0008BB48
		protected bool method_0(byte[] byte_0)
		{
			int num = BitConverter.ToInt32(byte_0, 0x20);
			if (num == 0)
			{
				return false;
			}
			int index = BitConverter.ToInt32(byte_0, 0x1C);
			this.String_0 = Encoding.UTF8.GetString(byte_0, index, num);
			if (this.String_0[this.String_0.Length - 1] != '/')
			{
				this.String_0 += "/";
			}
			return true;
		}

		// Token: 0x0600136B RID: 4971 RVA: 0x0000C30F File Offset: 0x0000A50F
		protected void method_1()
		{
			this.String_0 = Convert.ToBase64String(Encoding.UTF8.GetBytes(this.String_0));
		}

		// Token: 0x0600136C RID: 4972 RVA: 0x0000C32C File Offset: 0x0000A52C
		protected void method_2(string string_2, string string_3)
		{
			this.method_3(string_2, false);
			this.method_3(string_3, true);
		}

		// Token: 0x0600136D RID: 4973 RVA: 0x0008D9B4 File Offset: 0x0008BBB4
		private void method_3(string string_2, bool bool_0)
		{
			if (bool_0)
			{
				StringBuilder stringBuilder = new StringBuilder(this.String_0);
				foreach (char c in string_2)
				{
					if (c != '+')
					{
						if (c != '/')
						{
							if (c != '=')
							{
								stringBuilder.Append(c);
							}
							else
							{
								stringBuilder.Append("%3D");
							}
						}
						else
						{
							stringBuilder.Append("%2F");
						}
					}
					else
					{
						stringBuilder.Append("%2B");
					}
				}
				this.String_0 = stringBuilder.ToString();
				return;
			}
			this.String_0 += string_2;
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x0600136E RID: 4974 RVA: 0x0000C33E File Offset: 0x0000A53E
		// (set) Token: 0x0600136F RID: 4975 RVA: 0x0000C346 File Offset: 0x0000A546
		public string String_0 { get; private set; }

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06001370 RID: 4976 RVA: 0x0000C34F File Offset: 0x0000A54F
		// (set) Token: 0x06001371 RID: 4977 RVA: 0x0000C357 File Offset: 0x0000A557
		public string String_1 { get; private set; }

		// Token: 0x06001373 RID: 4979 RVA: 0x0000C360 File Offset: 0x0000A560
		public unsafe static object smethod_0(void* pVoid_0)
		{
			return Pointer.Box(pVoid_0, typeof(void*));
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x0000C372 File Offset: 0x0000A572
		public unsafe static void* smethod_1(object object_0)
		{
			return Pointer.Unbox(object_0);
		}

		// Token: 0x04000AC1 RID: 2753
		[CompilerGenerated]
		private string string_0;

		// Token: 0x04000AC2 RID: 2754
		[CompilerGenerated]
		private string string_1;

		// Token: 0x020001E5 RID: 485
		[CompilerGenerated]
		[Serializable]
		private sealed class Class6
		{
			// Token: 0x06001375 RID: 4981 RVA: 0x0000C37A File Offset: 0x0000A57A
			// Note: this type is marked as 'beforefieldinit'.
			static Class6()
			{
				GClass12.GClass13.Class6.class6_0 = new GClass12.GClass13.Class6();
			}

			// Token: 0x06001377 RID: 4983 RVA: 0x00009FAD File Offset: 0x000081AD
			internal bool method_0(object object_0, X509Certificate x509Certificate_0, X509Chain x509Chain_0, SslPolicyErrors sslPolicyErrors_0)
			{
				return true;
			}

			// Token: 0x04000AC3 RID: 2755
			public static readonly GClass12.GClass13.Class6 class6_0;

			// Token: 0x04000AC4 RID: 2756
			public static RemoteCertificateValidationCallback remoteCertificateValidationCallback_0;
		}
	}

	// Token: 0x020001E6 RID: 486
	public class GClass14 : GClass12.GClass13
	{
		// Token: 0x04000AC5 RID: 2757
		[CompilerGenerated]
		private string string_2;
	}

	// Token: 0x020001E7 RID: 487
	public class GClass15 : GClass12.GClass13
	{
	}
}
