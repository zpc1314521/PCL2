using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace PCL
{
	// Token: 0x020000D3 RID: 211
	public class ValidateRegex : Validate
	{
		// Token: 0x060007D9 RID: 2009 RVA: 0x000064B6 File Offset: 0x000046B6
		[CompilerGenerated]
		public string CustomizeContainer()
		{
			return this._MapModel;
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x000064BE File Offset: 0x000046BE
		[CompilerGenerated]
		public void CalcContainer(string AutoPropertyValue)
		{
			this._MapModel = AutoPropertyValue;
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x000064C7 File Offset: 0x000046C7
		[CompilerGenerated]
		public string LogoutContainer()
		{
			return this._ComposerModel;
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x000064CF File Offset: 0x000046CF
		[CompilerGenerated]
		public void PatchContainer(string AutoPropertyValue)
		{
			this._ComposerModel = AutoPropertyValue;
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x000064D8 File Offset: 0x000046D8
		public ValidateRegex()
		{
			this.PatchContainer("");
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x000064EB File Offset: 0x000046EB
		public ValidateRegex(string Regex, string ErrorDescription = "")
		{
			this.PatchContainer("");
			this.CalcContainer(Regex);
			this.PatchContainer(ErrorDescription);
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x0003CB80 File Offset: 0x0003AD80
		public override string Validate(string Str)
		{
			string result;
			if (!ModBase.RegexCheck(Str, this.CustomizeContainer(), RegexOptions.None))
			{
				result = this.LogoutContainer();
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x04000416 RID: 1046
		[CompilerGenerated]
		private string _MapModel;

		// Token: 0x04000417 RID: 1047
		[CompilerGenerated]
		private string _ComposerModel;
	}
}
