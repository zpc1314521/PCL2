using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Linq;

namespace PCL
{
	// Token: 0x020000DB RID: 219
	public class ValidateFilter : Validate
	{
		// Token: 0x0600080E RID: 2062 RVA: 0x000066F2 File Offset: 0x000048F2
		// Note: this type is marked as 'beforefieldinit'.
		static ValidateFilter()
		{
			ValidateFilter._RuleIterator = ModBase.CancelIterator("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", "").Split(new char[]
			{
				'|'
			});
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x0003D684 File Offset: 0x0003B884
		public override string Validate(string Str)
		{
			string text = "";
			foreach (char value in (Str ?? "").ToLower())
			{
				if (!string.IsNullOrWhiteSpace(value.ToString()) && !("!@#$%^&*()_+-={}[]|\\;':\",./<>? ~\u3000·！￥…（）—，。、《》？‘；：【】｛｝" + Conversions.ToString(ModBase.orderRule) + Conversions.ToString(ModBase.m_ServiceRule)).ToCharArray().Contains(value))
				{
					text += Conversions.ToString(value);
				}
			}
			foreach (string value2 in ValidateFilter._RuleIterator)
			{
				if (text.Contains(value2))
				{
					return "存在敏感内容！";
				}
			}
			return "";
		}

		// Token: 0x04000426 RID: 1062
		private static string[] _RuleIterator;
	}
}
