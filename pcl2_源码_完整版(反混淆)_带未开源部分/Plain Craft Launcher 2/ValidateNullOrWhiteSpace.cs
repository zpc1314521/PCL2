using Microsoft.VisualBasic;
using System;

namespace PCL
{
	// Token: 0x020000D2 RID: 210
	public class ValidateNullOrWhiteSpace : Validate
	{
		// Token: 0x060007D8 RID: 2008 RVA: 0x0003CB54 File Offset: 0x0003AD54
		public override string Validate(string Str)
		{
			string result;
			if (!Information.IsNothing(Str) && !string.IsNullOrWhiteSpace(Str))
			{
				result = "";
			}
			else
			{
				result = "输入内容不能为空！";
			}
			return result;
		}
	}
}
