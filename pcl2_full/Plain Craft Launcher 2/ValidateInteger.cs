using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.CompilerServices;

namespace PCL
{
	// Token: 0x020000D5 RID: 213
	public class ValidateInteger : Validate
	{
		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060007E2 RID: 2018 RVA: 0x0000650C File Offset: 0x0000470C
		// (set) Token: 0x060007E3 RID: 2019 RVA: 0x00006514 File Offset: 0x00004714
		public int Min { get; set; }

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060007E4 RID: 2020 RVA: 0x0000651D File Offset: 0x0000471D
		// (set) Token: 0x060007E5 RID: 2021 RVA: 0x00006525 File Offset: 0x00004725
		public int Max { get; set; }

		// Token: 0x060007E6 RID: 2022 RVA: 0x0000652E File Offset: 0x0000472E
		public ValidateInteger()
		{
			this.Max = int.MaxValue;
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x00006541 File Offset: 0x00004741
		public ValidateInteger(int Min, int Max)
		{
			this.Max = int.MaxValue;
			this.Min = Min;
			this.Max = Max;
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x0003CBF4 File Offset: 0x0003ADF4
		public override string Validate(string Str)
		{
			string result;
			if (Str.Length > 9)
			{
				result = "请输入一个大小合理的数字！";
			}
			else if (Operators.CompareString((checked((int)Math.Round(ModBase.Val(Str)))).ToString(), Str, true) != 0)
			{
				result = "请输入一个整数！";
			}
			else if (ModBase.Val(Str) > (double)this.Max)
			{
				result = "不可超过 " + Conversions.ToString(this.Max) + "！";
			}
			else if (ModBase.Val(Str) < (double)this.Min)
			{
				result = "不可低于 " + Conversions.ToString(this.Min) + "！";
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x04000418 RID: 1048
		[CompilerGenerated]
		private int _PublisherModel;

		// Token: 0x04000419 RID: 1049
		[CompilerGenerated]
		private int _MessageModel;
	}
}
