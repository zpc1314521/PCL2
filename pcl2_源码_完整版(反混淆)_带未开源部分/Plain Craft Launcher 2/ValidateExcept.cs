using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace PCL
{
	// Token: 0x020000D7 RID: 215
	public class ValidateExcept : Validate
	{
		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060007F0 RID: 2032 RVA: 0x000065C6 File Offset: 0x000047C6
		// (set) Token: 0x060007F1 RID: 2033 RVA: 0x000065CE File Offset: 0x000047CE
		public Collection<string> Excepts { get; set; }

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060007F2 RID: 2034 RVA: 0x000065D7 File Offset: 0x000047D7
		// (set) Token: 0x060007F3 RID: 2035 RVA: 0x000065DF File Offset: 0x000047DF
		public string ErrorMessage { get; set; }

		// Token: 0x060007F4 RID: 2036 RVA: 0x000065E8 File Offset: 0x000047E8
		public ValidateExcept()
		{
			this.Excepts = new Collection<string>();
			this.ErrorMessage = "输入内容不能包含 %！";
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x00006606 File Offset: 0x00004806
		public ValidateExcept(Collection<string> Excepts, string ErrorMessage = "输入内容不能包含 %！")
		{
			this.Excepts = new Collection<string>();
			this.Excepts = Excepts;
			this.ErrorMessage = ErrorMessage;
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x0003CD40 File Offset: 0x0003AF40
		public ValidateExcept(IEnumerable Excepts, string ErrorMessage = "输入内容不能包含 %！")
		{
			this.Excepts = new Collection<string>();
			this.Excepts = new Collection<string>();
			this.ErrorMessage = ErrorMessage;
			try
			{
				foreach (object value in Excepts)
				{
					string item = Conversions.ToString(value);
					this.Excepts.Add(item);
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x0003CDC0 File Offset: 0x0003AFC0
		public override string Validate(string Str)
		{
			try
			{
				foreach (string text in this.Excepts)
				{
					if (Str.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
					{
						if (Information.IsNothing(this.ErrorMessage))
						{
							this.ErrorMessage = "";
						}
						return this.ErrorMessage.Replace("%", text);
					}
				}
			}
			finally
			{
				IEnumerator<string> enumerator;
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}
			return "";
		}

		// Token: 0x0400041C RID: 1052
		[CompilerGenerated]
		private Collection<string> m_FactoryIterator;

		// Token: 0x0400041D RID: 1053
		[CompilerGenerated]
		private string m_ValIterator;
	}
}
