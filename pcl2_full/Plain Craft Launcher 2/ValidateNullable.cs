using Microsoft.VisualBasic;
using System;

namespace PCL
{
	// Token: 0x020000D0 RID: 208
	public class ValidateNullable : Validate
	{
		// Token: 0x060007D4 RID: 2004 RVA: 0x0003CB00 File Offset: 0x0003AD00
		public override string Validate(string Str)
		{
			string result;
			if (!Information.IsNothing(Str) && !string.IsNullOrEmpty(Str))
			{
				result = "";
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
