using Microsoft.VisualBasic;
using System;

namespace PCL
{
	// Token: 0x020000D1 RID: 209
	public class ValidateNullOrEmpty : Validate
	{
		// Token: 0x060007D6 RID: 2006 RVA: 0x0003CB28 File Offset: 0x0003AD28
		public override string Validate(string Str)
		{
			string result;
			if (!Information.IsNothing(Str) && !string.IsNullOrEmpty(Str))
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
