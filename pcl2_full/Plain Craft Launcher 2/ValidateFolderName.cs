using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace PCL
{
	// Token: 0x020000D9 RID: 217
	public class ValidateFolderName : Validate
	{
		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000801 RID: 2049 RVA: 0x00006689 File Offset: 0x00004889
		// (set) Token: 0x06000802 RID: 2050 RVA: 0x00006691 File Offset: 0x00004891
		public string Path { get; set; }

		// Token: 0x06000803 RID: 2051 RVA: 0x0000669A File Offset: 0x0000489A
		[CompilerGenerated]
		public bool AddContainer()
		{
			return this.m_UtilsIterator;
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x000066A2 File Offset: 0x000048A2
		[CompilerGenerated]
		public void DisableContainer(bool AutoPropertyValue)
		{
			this.m_UtilsIterator = AutoPropertyValue;
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x000066AB File Offset: 0x000048AB
		[CompilerGenerated]
		public bool ResetContainer()
		{
			return this.baseIterator;
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x000066B3 File Offset: 0x000048B3
		[CompilerGenerated]
		public void CompareContainer(bool AutoPropertyValue)
		{
			this.baseIterator = AutoPropertyValue;
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x0003CF8C File Offset: 0x0003B18C
		public ValidateFolderName(string Path, bool UseMinecraftCharCheck = true, bool IgnoreCase = true)
		{
			this.DisableContainer(true);
			this.CompareContainer(true);
			int num2;
			int num4;
			object obj;
			try
			{
				IL_14:
				int num = 1;
				this.Path = Path;
				IL_1D:
				num = 2;
				this.CompareContainer(IgnoreCase);
				IL_26:
				num = 3;
				this.DisableContainer(UseMinecraftCharCheck);
				IL_2F:
				ProjectData.ClearProjectError();
				num2 = 1;
				IL_36:
				num = 5;
				this.decoratorIterator = new DirectoryInfo(Path).EnumerateDirectories();
				IL_49:
				goto IL_B0;
				IL_4B:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_71:
				goto IL_A5;
				IL_73:
				num4 = num;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num2);
				IL_83:;
			}
			catch when (endfilter(obj is Exception & num2 != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_73;
			}
			IL_A5:
			throw ProjectData.CreateProjectError(-0x7FF5FFCD);
			IL_B0:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x0003D064 File Offset: 0x0003B264
		public override string Validate(string Str)
		{
			string result;
			try
			{
				string text = new ValidateNullOrWhiteSpace().Validate(Str);
				if (Operators.CompareString(text, "", true) != 0)
				{
					result = text;
				}
				else if (Str.StartsWith(" "))
				{
					result = "文件夹名不能以空格开头！";
				}
				else if (Str.EndsWith(" "))
				{
					result = "文件夹名不能以空格结尾！";
				}
				else
				{
					text = new ValidateLength(1, 0x64).Validate(Str);
					if (Operators.CompareString(text, "", true) != 0)
					{
						result = text;
					}
					else if (Str.EndsWith("."))
					{
						result = "文件夹名不能以小数点结尾！";
					}
					else
					{
						string text2 = new ValidateExcept(new string(System.IO.Path.GetInvalidFileNameChars()) + (this.AddContainer() ? "!;" : ""), "文件夹名不可包含 % 字符！").Validate(Str);
						if (Operators.CompareString(text2, "", true) != 0)
						{
							result = text2;
						}
						else
						{
							string text3 = new ValidateExceptSame(new string[]
							{
								"CON",
								"PRN",
								"AUX",
								"CLOCK$",
								"NUL",
								"COM0",
								"COM1",
								"COM2",
								"COM3",
								"COM4",
								"COM5",
								"COM6",
								"COM7",
								"COM8",
								"COM9",
								"LPT0",
								"LPT1",
								"LPT2",
								"LPT3",
								"LPT4",
								"LPT5",
								"LPT6",
								"LPT7",
								"LPT8",
								"LPT9"
							}, "文件夹名不可为 %！", false).Validate(Str);
							if (Operators.CompareString(text3, "", true) != 0)
							{
								result = text3;
							}
							else
							{
								ArrayList arrayList = new ArrayList();
								if (this.decoratorIterator != null)
								{
									try
									{
										foreach (DirectoryInfo directoryInfo in this.decoratorIterator)
										{
											arrayList.Add(directoryInfo.Name);
										}
									}
									finally
									{
										IEnumerator<DirectoryInfo> enumerator;
										if (enumerator != null)
										{
											enumerator.Dispose();
										}
									}
								}
								string text4 = new ValidateExceptSame(arrayList, "不可与现有文件夹重名！", this.ResetContainer()).Validate(Str);
								if (Operators.CompareString(text4, "", true) != 0)
								{
									result = text4;
								}
								else
								{
									result = "";
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "检查文件夹名出错", ModBase.LogLevel.Debug, "出现错误");
				result = "意外错误：" + ex.Message;
			}
			return result;
		}

		// Token: 0x04000421 RID: 1057
		[CompilerGenerated]
		private string _ExpressionIterator;

		// Token: 0x04000422 RID: 1058
		[CompilerGenerated]
		private bool m_UtilsIterator;

		// Token: 0x04000423 RID: 1059
		[CompilerGenerated]
		private bool baseIterator;

		// Token: 0x04000424 RID: 1060
		private readonly IEnumerable<DirectoryInfo> decoratorIterator;
	}
}
