using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.CompilerServices;

namespace PCL
{
	// Token: 0x020000D6 RID: 214
	public class ValidateLength : Validate
	{
		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060007E9 RID: 2025 RVA: 0x00006562 File Offset: 0x00004762
		// (set) Token: 0x060007EA RID: 2026 RVA: 0x0000656A File Offset: 0x0000476A
		public int Min { get; set; }

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060007EB RID: 2027 RVA: 0x00006573 File Offset: 0x00004773
		// (set) Token: 0x060007EC RID: 2028 RVA: 0x0000657B File Offset: 0x0000477B
		public int Max { get; set; }

		// Token: 0x060007ED RID: 2029 RVA: 0x00006584 File Offset: 0x00004784
		public ValidateLength()
		{
			this.Min = 0;
			this.Max = int.MaxValue;
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x0000659E File Offset: 0x0000479E
		public ValidateLength(int Min, int Max = 0x7FFFFFFF)
		{
			this.Min = 0;
			this.Max = int.MaxValue;
			this.Min = Min;
			this.Max = Max;
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x0003CC9C File Offset: 0x0003AE9C
		public override string Validate(string Str)
		{
			string result;
			if (Strings.Len(Str) != this.Max && this.Max == this.Min)
			{
				result = "长度必须为 " + Conversions.ToString(this.Max) + " 个字符！";
			}
			else if (Strings.Len(Str) > this.Max)
			{
				result = "长度最长为 " + Conversions.ToString(this.Max) + " 个字符！";
			}
			else if (Strings.Len(Str) < this.Min)
			{
				result = "长度至少需 " + Conversions.ToString(this.Min) + " 个字符！";
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0400041A RID: 1050
		[CompilerGenerated]
		private int tokenModel;

		// Token: 0x0400041B RID: 1051
		[CompilerGenerated]
		private int procModel;
	}
}
