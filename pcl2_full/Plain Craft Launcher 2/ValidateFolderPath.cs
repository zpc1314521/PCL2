using Microsoft.VisualBasic.CompilerServices;
using PCL.My;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PCL
{
	// Token: 0x020000DA RID: 218
	public class ValidateFolderPath : Validate
	{
		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000809 RID: 2057 RVA: 0x000066BC File Offset: 0x000048BC
		// (set) Token: 0x0600080A RID: 2058 RVA: 0x000066C4 File Offset: 0x000048C4
		public bool UseMinecraftCharCheck { get; set; }

		// Token: 0x0600080B RID: 2059 RVA: 0x000066CD File Offset: 0x000048CD
		public ValidateFolderPath()
		{
			this.UseMinecraftCharCheck = true;
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x000066DC File Offset: 0x000048DC
		public ValidateFolderPath(bool UseMinecraftCharCheck)
		{
			this.UseMinecraftCharCheck = true;
			this.UseMinecraftCharCheck = UseMinecraftCharCheck;
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x0003D338 File Offset: 0x0003B538
		public override string Validate(string Str)
		{
			Str = Str.Replace("/", "\\");
			if (!Str.TrimEnd(new char[]
			{
				'\\'
			}).EndsWith(":"))
			{
				Str = Str.TrimEnd(new char[]
				{
					'\\'
				});
			}
			string text = new ValidateNullOrWhiteSpace().Validate(Str);
			checked
			{
				string result;
				if (Operators.CompareString(text, "", true) != 0)
				{
					result = text;
				}
				else
				{
					text = new ValidateLength(1, 0xFE).Validate(Str);
					if (Operators.CompareString(text, "", true) != 0)
					{
						result = text;
					}
					else
					{
						if (!Str.StartsWith("\\\\Mac\\"))
						{
							try
							{
								foreach (DriveInfo driveInfo in MyWpfExtension.RunFactory().FileSystem.Drives)
								{
									if (Operators.CompareString(Str.ToUpper(), driveInfo.Name, true) == 0)
									{
										return "";
									}
									if (Str.ToUpper().StartsWith(driveInfo.Name))
									{
										goto IL_109;
									}
								}
							}
							finally
							{
								IEnumerator<DriveInfo> enumerator;
								if (enumerator != null)
								{
									enumerator.Dispose();
								}
							}
							return "文件夹路径头存在错误！";
						}
						IL_109:
						int num = Str.StartsWith("\\\\Mac\\") ? 2 : 1;
						int num2 = Str.Split(new char[]
						{
							'\\'
						}).Count<string>() - 1;
						for (int i = num; i <= num2; i++)
						{
							string text2 = Str.Split(new char[]
							{
								'\\'
							})[i];
							if (Operators.CompareString(new ValidateNullOrWhiteSpace().Validate(text2), "", true) != 0)
							{
								return "文件夹路径存在错误！";
							}
							string text3 = new ValidateExcept(new string(Path.GetInvalidFileNameChars()) + (this.UseMinecraftCharCheck ? "!;" : ""), "路径中存在无效字符！").Validate(text2);
							if (Operators.CompareString(text3, "", true) != 0)
							{
								return text3;
							}
							if (text2.StartsWith(" "))
							{
								return "文件夹名不能以空格开头！";
							}
							if (text2.EndsWith(" "))
							{
								return "文件夹名不能以空格结尾！";
							}
							if (text2.EndsWith("."))
							{
								return "文件夹名不能以小数点结尾！";
							}
							string text4 = new ValidateExceptSame(new string[]
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
							}, "文件夹名不可为 %！", false).Validate(text2);
							if (Operators.CompareString(text4, "", true) != 0)
							{
								return text4;
							}
						}
						result = "";
					}
				}
				return result;
			}
		}

		// Token: 0x04000425 RID: 1061
		[CompilerGenerated]
		private bool m_FilterIterator;
	}
}
