using System;
using System.Text.RegularExpressions;

namespace PCL
{
	// Token: 0x020000D4 RID: 212
	public class ValidateHttp : Validate
	{
		// Token: 0x060007E1 RID: 2017 RVA: 0x0003CBAC File Offset: 0x0003ADAC
		public override string Validate(string Str)
		{
			if (Str.EndsWith("/"))
			{
				Str = Str.Substring(0, checked(Str.Length - 1));
			}
			string result;
			if (!ModBase.RegexCheck(Str, "^(http[s]?)\\://", RegexOptions.None))
			{
				result = "输入的网址无效！";
			}
			else
			{
				result = "";
			}
			return result;
		}
	}
}
