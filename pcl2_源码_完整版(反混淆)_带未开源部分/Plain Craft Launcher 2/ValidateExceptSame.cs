using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace PCL
{
	// Token: 0x020000D8 RID: 216
	public class ValidateExceptSame : Validate
	{
		// Token: 0x060007F8 RID: 2040 RVA: 0x00006627 File Offset: 0x00004827
		[CompilerGenerated]
		public Collection<string> PublishContainer()
		{
			return this._ContainerIterator;
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x0000662F File Offset: 0x0000482F
		[CompilerGenerated]
		public void QueryContainer(Collection<string> AutoPropertyValue)
		{
			this._ContainerIterator = AutoPropertyValue;
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x00006638 File Offset: 0x00004838
		[CompilerGenerated]
		public string NewContainer()
		{
			return this._ModelIterator;
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x00006640 File Offset: 0x00004840
		[CompilerGenerated]
		public void InsertContainer(string AutoPropertyValue)
		{
			this._ModelIterator = AutoPropertyValue;
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x00006649 File Offset: 0x00004849
		[CompilerGenerated]
		public bool CountContainer()
		{
			return this._IteratorIterator;
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x00006651 File Offset: 0x00004851
		[CompilerGenerated]
		public void CallContainer(bool AutoPropertyValue)
		{
			this._IteratorIterator = AutoPropertyValue;
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x0000665A File Offset: 0x0000485A
		public ValidateExceptSame(Collection<string> Excepts, string ErrorMessage = "输入内容不能为 %！", bool IgnoreCase = false)
		{
			this.QueryContainer(new Collection<string>());
			this.CallContainer(false);
			this.QueryContainer(Excepts);
			this.InsertContainer(ErrorMessage);
			this.CallContainer(IgnoreCase);
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x0003CE44 File Offset: 0x0003B044
		public ValidateExceptSame(IEnumerable Excepts, string ErrorMessage = "输入内容不能为 %！", bool IgnoreCase = false)
		{
			this.QueryContainer(new Collection<string>());
			this.CallContainer(false);
			this.QueryContainer(new Collection<string>());
			try
			{
				foreach (object value in Excepts)
				{
					string item = Conversions.ToString(value);
					this.PublishContainer().Add(item);
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
			this.InsertContainer(ErrorMessage);
			this.CallContainer(IgnoreCase);
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x0003CED4 File Offset: 0x0003B0D4
		public override string Validate(string Str)
		{
			string result;
			if (Str == null)
			{
				result = this.NewContainer().Replace("%", "null");
			}
			else
			{
				try
				{
					foreach (string text in this.PublishContainer())
					{
						if (this.CountContainer())
						{
							if (Operators.CompareString(Str.ToLower(), text.ToLower(), true) == 0)
							{
								return this.NewContainer().Replace("%", text);
							}
						}
						else if (Str.Equals(text))
						{
							return this.NewContainer().Replace("%", text);
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
				result = "";
			}
			return result;
		}

		// Token: 0x0400041E RID: 1054
		[CompilerGenerated]
		private Collection<string> _ContainerIterator;

		// Token: 0x0400041F RID: 1055
		[CompilerGenerated]
		private string _ModelIterator;

		// Token: 0x04000420 RID: 1056
		[CompilerGenerated]
		private bool _IteratorIterator;
	}
}
