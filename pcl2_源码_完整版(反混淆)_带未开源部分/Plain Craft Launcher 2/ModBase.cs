using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Newtonsoft.Json;
using Ookii.Dialogs.Wpf;
using PCL.My;
using PCL.My.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml.Linq;

namespace PCL
{
	// Token: 0x0200019D RID: 413
	[StandardModule]
	public sealed class ModBase
	{
		// Token: 0x060011FD RID: 4605 RVA: 0x0008442C File Offset: 0x0008262C
		// Note: this type is marked as 'beforefieldinit'.
		static ModBase()
		{
			ModBase.Path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
			ModBase.m_ExpressionRule = "pack://application:,,,/images/";
			ModBase.m_UtilsRule = "zh_CN";
			ModBase._BaseRule = new ModSetup();
			ModBase._FilterRule = DateTime.Now;
			ModBase.ruleRule = ModBase.GetUniqueAddress();
			ModBase._AlgoRule = false;
			ModBase.m_MapperRule = !Environment.Is64BitOperatingSystem;
			ModBase._ParamsRule = Environment.OSVersion.Version;
			ModBase.m_GlobalRule = (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("SystemSystemCache", null), "", true) ? (System.IO.Path.GetTempPath() + "PCL\\") : ModBase._BaseRule.Get("SystemSystemCache", null)).ToString().Replace("/", "\\").TrimEnd(new char[]
			{
				'\\'
			}) + "\\";
			ModBase.m_IssuerRule = new Dictionary<string, ModBase.IniCache>();
			ModBase.orderRule = Convert.ToChar(0x201C);
			ModBase.m_ServiceRule = Convert.ToChar(0x201D);
			ModBase._FacadeRule = "<RS!AKeyValu!e><Mo!dul!us>0L/cZoJUyBRAIE8OKiG8$qYOytXD$azFCBsmOuQra";
			ModBase._CodeRule = 1;
			ModBase._BridgeRule = checked((int)Math.Round((double)Graphics.FromHwnd(IntPtr.Zero).DpiX));
			ModBase.m_SingletonRule = Thread.CurrentThread.ManagedThreadId;
			ModBase.errorRule = false;
			ModBase.m_ObjectRule = false;
			ModBase._CallbackRule = new StringBuilder();
			ModBase.m_VisitorRule = RuntimeHelpers.GetObjectValue(new object());
			ModBase._IndexerRule = RuntimeHelpers.GetObjectValue(new object());
			ModBase.methodRule = new Random();
		}

		// Token: 0x060011FE RID: 4606 RVA: 0x000845B4 File Offset: 0x000827B4
		public static double MathBezier(double x, double x1, double y1, double x2, double y2, double acc = 0.01)
		{
			double result;
			if (x > 0.0 && !double.IsNaN(x))
			{
				if (x >= 1.0)
				{
					result = 1.0;
				}
				else
				{
					object obj = x;
					object obj2;
					do
					{
						obj2 = Operators.MultiplyObject(Operators.MultiplyObject(3, obj), Operators.AddObject(Operators.AddObject(Operators.MultiplyObject(Operators.MultiplyObject(0.33333333 + x1 - x2, obj), obj), Operators.MultiplyObject(x2 - 2.0 * x1, obj)), x1));
						obj = Operators.AddObject(obj, Operators.MultiplyObject(Operators.SubtractObject(x, obj2), 0.5));
					}
					while (!Operators.ConditionalCompareObjectLess(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[]
					{
						Operators.SubtractObject(obj2, x)
					}, null, null, null), acc, true));
					result = Conversions.ToDouble(Operators.MultiplyObject(Operators.MultiplyObject(3, obj), Operators.AddObject(Operators.AddObject(Operators.MultiplyObject(Operators.MultiplyObject(0.33333333 + y1 - y2, obj), obj), Operators.MultiplyObject(y2 - 2.0 * y1, obj)), y1)));
				}
			}
			else
			{
				result = 0.0;
			}
			return result;
		}

		// Token: 0x060011FF RID: 4607 RVA: 0x0000B64D File Offset: 0x0000984D
		public static byte MathByte(double d)
		{
			if (d < 0.0)
			{
				d = 0.0;
			}
			if (d > 255.0)
			{
				d = 255.0;
			}
			return checked((byte)Math.Round(d));
		}

		// Token: 0x06001200 RID: 4608 RVA: 0x00084728 File Offset: 0x00082928
		public static ModBase.MyColor MathRound(ModBase.MyColor col, int w = 0)
		{
			return new ModBase.MyColor
			{
				creatorMapper = Math.Round(col.creatorMapper, w),
				_PageMapper = Math.Round(col._PageMapper, w),
				instanceMapper = Math.Round(col.instanceMapper, w),
				testMapper = Math.Round(col.testMapper, w)
			};
		}

		// Token: 0x06001201 RID: 4609 RVA: 0x0000B684 File Offset: 0x00009884
		public static double MathPercent(double ValueA, double ValueB, double Percent)
		{
			return Math.Round(ValueA * (1.0 - Percent) + ValueB * Percent, 6);
		}

		// Token: 0x06001202 RID: 4610 RVA: 0x0000B69D File Offset: 0x0000989D
		public static ModBase.MyColor MathPercent(ModBase.MyColor ValueA, ModBase.MyColor ValueB, double Percent)
		{
			return ModBase.MathRound(ValueA * (1.0 - Percent) + ValueB * Percent, 6);
		}

		// Token: 0x06001203 RID: 4611 RVA: 0x0000B6C2 File Offset: 0x000098C2
		public static double MathRange(double value, double min, double max)
		{
			return Math.Max(min, Math.Min(max, value));
		}

		// Token: 0x06001204 RID: 4612 RVA: 0x00084784 File Offset: 0x00082984
		public static int MathSgn(double Value)
		{
			int result;
			if (Value == 0.0)
			{
				result = 0;
			}
			else if (Value > 0.0)
			{
				result = 1;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x06001205 RID: 4613 RVA: 0x000847B4 File Offset: 0x000829B4
		public static void RegRename(RegistryKey parentKey, string subKeyName, string newSubKeyName)
		{
			if (parentKey.GetSubKeyNames().Contains(newSubKeyName))
			{
				parentKey.DeleteSubKeyTree(newSubKeyName, false);
			}
			RegistryKey registryKey = parentKey.OpenSubKey(subKeyName);
			if (!Information.IsNothing(registryKey))
			{
				RegistryKey registryKey2 = parentKey.CreateSubKey(newSubKeyName);
				if (registryKey.GetSubKeyNames().Length > 0)
				{
					throw new NotSupportedException("不支持对包含子键的子键进行重命名：" + registryKey.GetSubKeyNames()[0] + "。");
				}
				foreach (string name in registryKey.GetValueNames())
				{
					object objectValue = RuntimeHelpers.GetObjectValue(registryKey.GetValue(name));
					RegistryValueKind valueKind = registryKey.GetValueKind(name);
					registryKey2.SetValue(name, RuntimeHelpers.GetObjectValue(objectValue), valueKind);
				}
				parentKey.DeleteSubKeyTree(subKeyName, false);
			}
		}

		// Token: 0x06001206 RID: 4614 RVA: 0x00084864 File Offset: 0x00082A64
		public static string ReadReg(string Key, string DefaultValue = "")
		{
			string result;
			try
			{
				RegistryKey registryKey = MyWpfExtension.RunFactory().Registry.CurrentUser.OpenSubKey("Software\\PCL", true);
				if (registryKey == null)
				{
					result = DefaultValue;
				}
				else
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.AppendLine(Conversions.ToString(registryKey.GetValue(Key)));
					string text = stringBuilder.ToString().Replace("\r\n", "");
					result = ((Operators.CompareString(text, "", true) == 0) ? DefaultValue : text);
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "读取注册表出错：" + Key, ModBase.LogLevel.Hint, "出现错误");
				result = DefaultValue;
			}
			return result;
		}

		// Token: 0x06001207 RID: 4615 RVA: 0x00084910 File Offset: 0x00082B10
		public static void WriteReg(string Key, string Value, bool ShowException = false)
		{
			try
			{
				RegistryKey currentUser = MyWpfExtension.RunFactory().Registry.CurrentUser;
				RegistryKey registryKey = currentUser.OpenSubKey("Software\\PCL", true);
				if (registryKey == null)
				{
					registryKey = currentUser.CreateSubKey("Software\\PCL");
				}
				registryKey.SetValue(Key, Value);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "写入注册表出错：" + Key, ShowException ? ModBase.LogLevel.Hint : ModBase.LogLevel.Developer, "出现错误");
				if (ShowException)
				{
					throw;
				}
			}
		}

		// Token: 0x06001208 RID: 4616 RVA: 0x0000B6D1 File Offset: 0x000098D1
		public static void IniClearCache(string FileName)
		{
			if (!FileName.Contains(":\\"))
			{
				FileName = ModBase.Path + "PCL\\" + FileName + ".ini";
			}
			if (ModBase.m_IssuerRule.ContainsKey(FileName))
			{
				ModBase.m_IssuerRule.Remove(FileName);
			}
		}

		// Token: 0x06001209 RID: 4617 RVA: 0x00084994 File Offset: 0x00082B94
		private static ModBase.IniCache IniGetContent(string FileName)
		{
			ModBase.IniCache result;
			try
			{
				if (!FileName.Contains(":\\"))
				{
					FileName = ModBase.Path + "PCL\\" + FileName + ".ini";
				}
				if (ModBase.m_IssuerRule.ContainsKey(FileName))
				{
					ModBase.IniCache iniCache = new ModBase.IniCache();
					ModBase.m_IssuerRule.TryGetValue(FileName, out iniCache);
					result = iniCache;
				}
				else
				{
					ModBase.IniCache iniCache2;
					if (File.Exists(FileName))
					{
						string listenerMapper = ("\r\n" + ModBase.ReadFile(FileName) + "\r\n").Replace("\r\n", "\r").Replace("\n", "\r").Replace("\r", "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\0", "");
						iniCache2 = new ModBase.IniCache
						{
							listenerMapper = listenerMapper
						};
					}
					else
					{
						iniCache2 = new ModBase.IniCache
						{
							listenerMapper = ""
						};
					}
					if (!ModBase.m_IssuerRule.ContainsKey(FileName))
					{
						ModBase.m_IssuerRule.Add(FileName, iniCache2);
					}
					result = iniCache2;
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "读取文件失败：" + FileName, ModBase.LogLevel.Hint, "出现错误");
				result = new ModBase.IniCache
				{
					listenerMapper = ""
				};
			}
			return result;
		}

		// Token: 0x0600120A RID: 4618 RVA: 0x00084ADC File Offset: 0x00082CDC
		public static string ReadIni(string FileName, string Key, string DefaultValue = "")
		{
			string result;
			try
			{
				ModBase.IniCache iniCache = ModBase.IniGetContent(FileName);
				if (Information.IsNothing(iniCache))
				{
					result = DefaultValue;
				}
				else if (iniCache._ImporterMapper.ContainsKey(Key))
				{
					result = (iniCache._ImporterMapper[Key] ?? DefaultValue);
				}
				else if (iniCache.listenerMapper.Contains("\r\n" + Key + ":"))
				{
					string text = Strings.Mid(iniCache.listenerMapper, checked(iniCache.listenerMapper.IndexOf("\r\n" + Key + ":") + 3));
					text = (text.Contains("\r\n") ? Strings.Mid(text, 1, text.IndexOf("\r\n")) : text).Replace(Key + ":", "");
					iniCache._ImporterMapper.Add(Key, (Operators.CompareString(text, "\n", true) == 0) ? "" : text);
					result = ((Operators.CompareString(text, "\n", true) == 0) ? "" : text);
				}
				else
				{
					result = DefaultValue;
				}
			}
			catch (Exception ex)
			{
				result = DefaultValue;
			}
			return result;
		}

		// Token: 0x0600120B RID: 4619 RVA: 0x00084C08 File Offset: 0x00082E08
		public static void WriteIni(string FileName, string Key, string Value)
		{
			try
			{
				if (!FileName.Contains(":\\"))
				{
					FileName = ModBase.Path + "PCL\\" + FileName + ".ini";
				}
				if (Information.IsNothing(Value))
				{
					Value = "";
				}
				Value = Value.Replace("\r\n", "");
				if (!Directory.Exists(ModBase.GetPathFromFullPath(FileName)))
				{
					Directory.CreateDirectory(ModBase.GetPathFromFullPath(FileName));
				}
				string text = ModBase.IniGetContent(FileName).listenerMapper;
				if (!text.EndsWith("\r\n"))
				{
					text += "\r\n";
				}
				if (!text.Contains(string.Concat(new string[]
				{
					"\r\n",
					Key,
					":",
					Value,
					"\r\n"
				})))
				{
					string text2 = ModBase.ReadIni(FileName, Key, "");
					if (Operators.CompareString(text2, "", true) == 0 && !text.Contains("\r\n" + Key + ":"))
					{
						text = string.Concat(new string[]
						{
							text,
							"\r\n",
							Key,
							":",
							Value,
							"\r\n"
						});
					}
					else
					{
						text = text.Replace(string.Concat(new string[]
						{
							"\r\n",
							Key,
							":",
							text2,
							"\r\n"
						}), string.Concat(new string[]
						{
							"\r\n",
							Key,
							":",
							Value,
							"\r\n"
						}));
					}
					ModBase.WriteFile(FileName, text, false, null);
					ModBase.m_IssuerRule[FileName].listenerMapper = text;
					ModBase.m_IssuerRule[FileName]._ImporterMapper.Remove(Key);
					ModBase.m_IssuerRule[FileName]._ImporterMapper.Add(Key, Value);
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, string.Concat(new string[]
				{
					"写入文件失败：",
					FileName,
					"/",
					Key,
					": ",
					Value
				}), ModBase.LogLevel.Debug, "出现错误");
			}
		}

		// Token: 0x0600120C RID: 4620 RVA: 0x00084E44 File Offset: 0x00083044
		public static string GetPathFromFullPath(string FilePath)
		{
			if (!FilePath.Contains("\\") && !FilePath.Contains("/"))
			{
				throw new Exception("不包含路径：" + FilePath);
			}
			checked
			{
				string text;
				if (!FilePath.EndsWith("\\") && !FilePath.EndsWith("/"))
				{
					text = Strings.Left(FilePath, FilePath.LastIndexOfAny(new char[]
					{
						'\\',
						'/'
					}) + 1);
					if (Operators.CompareString(text, "", true) == 0)
					{
						throw new Exception("不包含路径：" + FilePath);
					}
				}
				else
				{
					bool flag = FilePath.EndsWith("\\");
					FilePath = Strings.Left(FilePath, Strings.Len(FilePath) - 1);
					text = Strings.Left(FilePath, FilePath.LastIndexOfAny(new char[]
					{
						'\\',
						'/'
					})) + (flag ? "\\" : "/");
					if (Operators.CompareString(text, "", true) == 0)
					{
						throw new Exception("不包含路径：" + FilePath);
					}
				}
				return text;
			}
		}

		// Token: 0x0600120D RID: 4621 RVA: 0x00084F44 File Offset: 0x00083144
		public static string GetFileNameFromPath(string FilePath)
		{
			if (!FilePath.EndsWith("\\") && !FilePath.EndsWith("/"))
			{
				string text;
				if (!FilePath.Contains("\\") && !FilePath.Contains("/"))
				{
					text = FilePath;
				}
				else
				{
					if (FilePath.Contains("?"))
					{
						FilePath = Strings.Left(FilePath, FilePath.LastIndexOf("?"));
					}
					text = Strings.Mid(FilePath, checked(FilePath.LastIndexOfAny(new char[]
					{
						'\\',
						'/'
					}) + 2));
					if (Operators.CompareString(text, "", true) == 0)
					{
						throw new Exception("不包含文件名：" + FilePath);
					}
				}
				return text;
			}
			throw new Exception("不包含文件名：" + FilePath);
		}

		// Token: 0x0600120E RID: 4622 RVA: 0x00084FFC File Offset: 0x000831FC
		public static string GetFileNameWithoutExtentionFromPath(string FilePath)
		{
			string fileNameFromPath = ModBase.GetFileNameFromPath(FilePath);
			string result;
			if (fileNameFromPath.Contains("."))
			{
				result = fileNameFromPath.Substring(0, fileNameFromPath.LastIndexOf("."));
			}
			else
			{
				result = fileNameFromPath;
			}
			return result;
		}

		// Token: 0x0600120F RID: 4623 RVA: 0x00085038 File Offset: 0x00083238
		public static string GetFolderNameFromPath(string FolderPath)
		{
			string result;
			if (!FolderPath.EndsWith(":\\") && !FolderPath.EndsWith(":\\\\"))
			{
				if (FolderPath.EndsWith("\\") || FolderPath.EndsWith("/"))
				{
					FolderPath = Strings.Left(FolderPath, checked(FolderPath.Length - 1));
				}
				result = ModBase.GetFileNameFromPath(FolderPath);
			}
			else
			{
				result = FolderPath.Substring(0, 1);
			}
			return result;
		}

		// Token: 0x06001210 RID: 4624 RVA: 0x0008509C File Offset: 0x0008329C
		public static string ReadFile(string FilePath)
		{
			string result;
			try
			{
				if (!FilePath.Contains(":\\"))
				{
					FilePath = ModBase.Path + FilePath;
				}
				if (File.Exists(FilePath))
				{
					result = ModBase.DecodeBytes(File.ReadAllBytes(FilePath));
				}
				else
				{
					result = "";
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "读取文件出错：" + FilePath, ModBase.LogLevel.Debug, "出现错误");
				result = "";
			}
			return result;
		}

		// Token: 0x06001211 RID: 4625 RVA: 0x00085120 File Offset: 0x00083320
		public static string ReadFile(Stream Stream, Encoding Encoding = null)
		{
			string result;
			try
			{
				byte[] array = new byte[0x4001];
				int i = Stream.Read(array, 0, 0x4000);
				List<byte> list = new List<byte>();
				while (i > 0)
				{
					if (i > 0)
					{
						list.AddRange(array.ToList<byte>().GetRange(0, i));
					}
					i = Stream.Read(array, 0, 0x4000);
				}
				byte[] bytes = list.ToArray();
				result = (Encoding ?? ModBase.GetEncoding(bytes)).GetString(bytes);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "读取流出错", ModBase.LogLevel.Debug, "出现错误");
				result = "";
			}
			return result;
		}

		// Token: 0x06001212 RID: 4626 RVA: 0x000851D0 File Offset: 0x000833D0
		public static bool WriteFile(string FilePath, string Text, bool Append = false, Encoding Encoding = null)
		{
			bool result;
			try
			{
				if (!FilePath.Contains(":\\"))
				{
					FilePath = ModBase.Path + FilePath;
				}
				Directory.CreateDirectory(ModBase.GetPathFromFullPath(FilePath));
				if (File.Exists(FilePath))
				{
					using (StreamWriter streamWriter = new StreamWriter(FilePath, Append, Encoding ?? ModBase.GetEncoding(FilePath)))
					{
						streamWriter.Write(Text);
						streamWriter.Flush();
						streamWriter.Close();
						goto IL_72;
					}
				}
				File.WriteAllText(FilePath, Text, Encoding ?? new UTF8Encoding(false));
				IL_72:
				result = true;
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "写入文件时出错：" + FilePath, ModBase.LogLevel.Debug, "出现错误");
				result = false;
			}
			return result;
		}

		// Token: 0x06001213 RID: 4627 RVA: 0x00085298 File Offset: 0x00083498
		public static bool WriteFile(string FilePath, byte[] Content, bool Append = false)
		{
			bool result;
			try
			{
				if (!FilePath.Contains(":\\"))
				{
					FilePath = ModBase.Path + FilePath;
				}
				Directory.CreateDirectory(ModBase.GetPathFromFullPath(FilePath));
				File.WriteAllBytes(FilePath, Content);
				result = true;
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "写入文件时出错：" + FilePath, ModBase.LogLevel.Debug, "出现错误");
				result = false;
			}
			return result;
		}

		// Token: 0x06001214 RID: 4628 RVA: 0x00085310 File Offset: 0x00083510
		public static bool WriteFile(string FilePath, Stream Stream)
		{
			bool result;
			try
			{
				if (!FilePath.Contains(":\\"))
				{
					FilePath = ModBase.Path + FilePath;
				}
				Directory.CreateDirectory(ModBase.GetPathFromFullPath(FilePath));
				using (FileStream fileStream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
				{
					byte[] array = new byte[0x4001];
					for (int i = Stream.Read(array, 0, 0x4000); i > 0; i = Stream.Read(array, 0, 0x4000))
					{
						if (i > 0)
						{
							fileStream.Write(array, 0, i);
						}
					}
					fileStream.Close();
				}
				result = true;
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "保存流出错", ModBase.LogLevel.Debug, "出现错误");
				result = false;
			}
			return result;
		}

		// Token: 0x06001215 RID: 4629 RVA: 0x000853DC File Offset: 0x000835DC
		public static Encoding GetEncoding(string FilePath)
		{
			if (!FilePath.Contains(":\\"))
			{
				FilePath = ModBase.Path + FilePath;
			}
			return ModBase.GetEncoding(File.ReadAllBytes(FilePath));
		}

		// Token: 0x06001216 RID: 4630 RVA: 0x00085410 File Offset: 0x00083610
		public static Encoding GetEncoding(byte[] Bytes)
		{
			Encoding result;
			if (Bytes.Count<byte>() <= 2)
			{
				result = new UTF8Encoding(false);
			}
			else if (Bytes[0] >= 0xEF)
			{
				if (Bytes[0] == 0xEF && Bytes[1] == 0xBB)
				{
					result = new UTF8Encoding(true);
				}
				else if (Bytes[0] == 0xFE && Bytes[1] == 0xFF)
				{
					result = Encoding.BigEndianUnicode;
				}
				else if (Bytes[0] == 0xFF && Bytes[1] == 0xFE)
				{
					result = Encoding.Unicode;
				}
				else
				{
					result = Encoding.GetEncoding("GB18030");
				}
			}
			else
			{
				string @string = Encoding.UTF8.GetString(Bytes);
				char value = Encoding.UTF8.GetString(new byte[]
				{
					0xEF,
					0xBF,
					0xBD
				}).ToCharArray()[0];
				if (@string.Contains(Conversions.ToString(value)))
				{
					result = Encoding.GetEncoding("GB18030");
				}
				else
				{
					result = new UTF8Encoding(false);
				}
			}
			return result;
		}

		// Token: 0x06001217 RID: 4631 RVA: 0x000854F4 File Offset: 0x000836F4
		public static string DecodeBytes(byte[] Bytes)
		{
			int num = Bytes.Length;
			checked
			{
				string result;
				if (num < 3)
				{
					result = Encoding.UTF8.GetString(Bytes);
				}
				else if (Bytes[0] >= 0xEF)
				{
					if (Bytes[0] == 0xEF && Bytes[1] == 0xBB)
					{
						result = Encoding.UTF8.GetString(Bytes, 3, num - 3);
					}
					else if (Bytes[0] == 0xFE && Bytes[1] == 0xFF)
					{
						result = Encoding.BigEndianUnicode.GetString(Bytes, 3, num - 3);
					}
					else if (Bytes[0] == 0xFF && Bytes[1] == 0xFE)
					{
						result = Encoding.Unicode.GetString(Bytes, 3, num - 3);
					}
					else
					{
						result = Encoding.GetEncoding("GB18030").GetString(Bytes, 3, num - 3);
					}
				}
				else
				{
					string @string = Encoding.UTF8.GetString(Bytes);
					char value = Encoding.UTF8.GetString(new byte[]
					{
						0xEF,
						0xBF,
						0xBD
					}).ToCharArray()[0];
					if (@string.Contains(Conversions.ToString(value)))
					{
						result = Encoding.GetEncoding("GB18030").GetString(Bytes);
					}
					else
					{
						result = @string;
					}
				}
				return result;
			}
		}

		// Token: 0x06001218 RID: 4632 RVA: 0x0008560C File Offset: 0x0008380C
		public static string SelectAs(string Title, string FileName, string FileFilter = null, string DefaultDir = null)
		{
			string fileName;
			using (System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog())
			{
				saveFileDialog.AddExtension = true;
				saveFileDialog.AutoUpgradeEnabled = true;
				saveFileDialog.Title = Title;
				saveFileDialog.FileName = FileName;
				if (FileFilter != null)
				{
					saveFileDialog.Filter = FileFilter;
				}
				if (DefaultDir != null)
				{
					saveFileDialog.InitialDirectory = DefaultDir;
				}
				saveFileDialog.ShowDialog();
				fileName = saveFileDialog.FileName;
				ModBase.Log("[UI] 选择文件返回：" + fileName, ModBase.LogLevel.Normal, "出现错误");
			}
			return fileName;
		}

		// Token: 0x06001219 RID: 4633 RVA: 0x00085690 File Offset: 0x00083890
		public static string SelectFile(string FileFilter, string Title)
		{
			string fileName;
			using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
			{
				openFileDialog.AddExtension = true;
				openFileDialog.AutoUpgradeEnabled = true;
				openFileDialog.CheckFileExists = true;
				openFileDialog.Filter = FileFilter;
				openFileDialog.Multiselect = false;
				openFileDialog.Title = Title;
				openFileDialog.ValidateNames = true;
				openFileDialog.ShowDialog();
				fileName = openFileDialog.FileName;
				ModBase.Log("[UI] 选择文件返回：" + fileName, ModBase.LogLevel.Normal, "出现错误");
			}
			return fileName;
		}

		// Token: 0x0600121A RID: 4634 RVA: 0x00085718 File Offset: 0x00083918
		public static string SelectFolder(string Title = "选择文件夹")
		{
			VistaFolderBrowserDialog vistaFolderBrowserDialog = new VistaFolderBrowserDialog
			{
				ShowNewFolderButton = true,
				RootFolder = Environment.SpecialFolder.Desktop,
				Description = Title,
				UseDescriptionForTitle = true
			};
			vistaFolderBrowserDialog.ShowDialog();
			string text = string.IsNullOrEmpty(vistaFolderBrowserDialog.SelectedPath) ? "" : (vistaFolderBrowserDialog.SelectedPath + (vistaFolderBrowserDialog.SelectedPath.EndsWith("\\") ? "" : "\\"));
			ModBase.Log("[UI] 选择文件夹返回：" + text, ModBase.LogLevel.Normal, "出现错误");
			return text;
		}

		// Token: 0x0600121B RID: 4635 RVA: 0x000857A4 File Offset: 0x000839A4
		public static bool CheckPermission(string Path)
		{
			bool result;
			try
			{
				if (Operators.CompareString(Path, "", true) == 0)
				{
					result = false;
				}
				else
				{
					if (!Path.EndsWith("\\"))
					{
						Path += "\\";
					}
					if (!Path.EndsWith(":\\System Volume Information\\") && !Path.EndsWith(":\\$RECYCLE.BIN\\"))
					{
						if (!Directory.Exists(Path))
						{
							result = false;
						}
						else
						{
							string str = "CheckPermission" + Conversions.ToString(ModBase.GetUuid());
							if (File.Exists(Path + str))
							{
								File.Delete(Path + str);
							}
							File.Create(Path + str).Dispose();
							File.Delete(Path + str);
							result = true;
						}
					}
					else
					{
						result = false;
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "没有对文件夹 " + Path + " 的权限，请尝试以管理员权限运行 PCL", ModBase.LogLevel.Debug, "出现错误");
				result = false;
			}
			return result;
		}

		// Token: 0x0600121C RID: 4636 RVA: 0x0008589C File Offset: 0x00083A9C
		public static void CheckPermissionWithException(string Path)
		{
			if (string.IsNullOrWhiteSpace(Path))
			{
				throw new ArgumentNullException("文件夹名不能为空！");
			}
			if (!Path.EndsWith("\\"))
			{
				Path += "\\";
			}
			if (!Directory.Exists(Path))
			{
				throw new DirectoryNotFoundException("文件夹不存在！");
			}
			if (File.Exists(Path + "CheckPermission"))
			{
				File.Delete(Path + "CheckPermission");
			}
			File.Create(Path + "CheckPermission").Dispose();
			File.Delete(Path + "CheckPermission");
		}

		// Token: 0x0600121D RID: 4637 RVA: 0x00085930 File Offset: 0x00083B30
		public static string smethod_0(string FilePath)
		{
			bool flag = false;
			checked
			{
				string result;
				for (;;)
				{
					try
					{
						StringBuilder stringBuilder = new StringBuilder();
						FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
						byte[] array = new MD5CryptoServiceProvider().ComputeHash(fileStream);
						fileStream.Close();
						int num = array.Length - 1;
						for (int i = 0; i <= num; i++)
						{
							stringBuilder.Append(array[i].ToString("x2"));
						}
						result = stringBuilder.ToString();
						break;
					}
					catch (Exception ex)
					{
						if (flag)
						{
							ModBase.Log(ex, "获取文件 MD5 失败：" + FilePath, ModBase.LogLevel.Debug, "出现错误");
							result = "";
							break;
						}
						flag = true;
						ModBase.Log(ex, "获取文件 MD5 可重试失败：" + FilePath, ModBase.LogLevel.Normal, "出现错误");
						Thread.Sleep(ModBase.RandomInteger(0xC8, 0x1F4));
					}
				}
				return result;
			}
		}

		// Token: 0x0600121E RID: 4638 RVA: 0x00085A20 File Offset: 0x00083C20
		public static string smethod_1(string FilePath)
		{
			bool flag = false;
			checked
			{
				string result;
				for (;;)
				{
					try
					{
						FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
						byte[] array = new SHA1CryptoServiceProvider().ComputeHash(fileStream);
						fileStream.Close();
						StringBuilder stringBuilder = new StringBuilder();
						int num = array.Length - 1;
						for (int i = 0; i <= num; i++)
						{
							stringBuilder.Append(array[i].ToString("x2"));
						}
						result = stringBuilder.ToString();
						break;
					}
					catch (Exception ex)
					{
						if (flag)
						{
							ModBase.Log(ex, "获取文件 SHA1 失败：" + FilePath, ModBase.LogLevel.Debug, "出现错误");
							result = "";
							break;
						}
						flag = true;
						ModBase.Log(ex, "获取文件 SHA1 可重试失败：" + FilePath, ModBase.LogLevel.Normal, "出现错误");
						Thread.Sleep(ModBase.RandomInteger(0xC8, 0x1F4));
					}
				}
				return result;
			}
		}

		// Token: 0x0600121F RID: 4639 RVA: 0x00085B10 File Offset: 0x00083D10
		public static string smethod_2(Stream Stream)
		{
			checked
			{
				string result;
				try
				{
					byte[] array = new SHA1CryptoServiceProvider().ComputeHash(Stream);
					StringBuilder stringBuilder = new StringBuilder();
					int num = array.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						stringBuilder.Append(array[i].ToString("x2"));
					}
					result = stringBuilder.ToString();
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "获取流 SHA1 失败", ModBase.LogLevel.Debug, "出现错误");
					result = "";
				}
				return result;
			}
		}

		// Token: 0x06001220 RID: 4640 RVA: 0x00085BA0 File Offset: 0x00083DA0
		public static bool ExtractFile(string CompressFilePath, string DestDirectory, Encoding Encode = null)
		{
			bool result;
			try
			{
				Directory.CreateDirectory(DestDirectory);
				if (!CompressFilePath.EndsWith(".zip") && !CompressFilePath.EndsWith(".jar"))
				{
					if (CompressFilePath.EndsWith(".gz"))
					{
						GZipStream gzipStream = new GZipStream(new FileStream(CompressFilePath, FileMode.Open, FileAccess.ReadWrite), CompressionMode.Decompress);
						FileStream fileStream = new FileStream(DestDirectory + ModBase.GetFileNameFromPath(CompressFilePath).ToLower().Replace(".tar", "").Replace(".gz", ""), FileMode.OpenOrCreate, FileAccess.Write);
						for (int num = gzipStream.ReadByte(); num != -1; num = gzipStream.ReadByte())
						{
							fileStream.WriteByte(checked((byte)num));
						}
						fileStream.Close();
						gzipStream.Close();
						result = true;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					ZipFile.ExtractToDirectory(CompressFilePath, DestDirectory, Encode ?? Encoding.Default);
					result = true;
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "尝试解压文件失败", ModBase.LogLevel.Debug, "出现错误");
				result = false;
			}
			return result;
		}

		// Token: 0x06001221 RID: 4641 RVA: 0x00085CA0 File Offset: 0x00083EA0
		public static void DeleteDirectory(string Path, bool IgnoreIssue = false)
		{
			checked
			{
				if (Directory.Exists(Path))
				{
					foreach (string path in Directory.GetFiles(Path))
					{
						try
						{
							File.Delete(path);
						}
						catch (Exception ex)
						{
							if (!IgnoreIssue)
							{
								throw;
							}
							ModBase.Log(ex, "删除单个文件可忽略地失败", ModBase.LogLevel.Debug, "出现错误");
						}
					}
					string[] directories = Directory.GetDirectories(Path);
					for (int j = 0; j < directories.Length; j++)
					{
						ModBase.DeleteDirectory(directories[j], false);
					}
					try
					{
						Directory.Delete(Path, true);
					}
					catch (Exception ex2)
					{
						if (!IgnoreIssue)
						{
							throw;
						}
						ModBase.Log(ex2, "删除单个文件夹可忽略地失败", ModBase.LogLevel.Debug, "出现错误");
					}
				}
			}
		}

		// Token: 0x06001222 RID: 4642 RVA: 0x00085D70 File Offset: 0x00083F70
		public static List<FileInfo> EnumerateFiles(string Directory)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Directory);
			List<FileInfo> list = new List<FileInfo>();
			list.AddRange(directoryInfo.EnumerateFiles());
			try
			{
				foreach (DirectoryInfo directoryInfo2 in directoryInfo.EnumerateDirectories())
				{
					list.AddRange(ModBase.EnumerateFiles(directoryInfo2.FullName));
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
			return list;
		}

		// Token: 0x06001223 RID: 4643 RVA: 0x00085DE4 File Offset: 0x00083FE4
		public static string GetString(Exception Ex, bool IsLine = true, bool ShowAllTrace = false)
		{
			string result;
			if (Ex == null)
			{
				result = "无可用错误信息！";
			}
			else
			{
				string fullName = Ex.GetType().FullName;
				List<string> list = new List<string>();
				if (Operators.CompareString(fullName, "System.TypeLoadException", true) != 0 && Operators.CompareString(fullName, "System.NotImplementedException", true) != 0)
				{
					if (Operators.CompareString(fullName, "System.UnauthorizedAccessException", true) == 0)
					{
						list.Add("PCL2 权限不足，请尝试右键 PCL2，选择以管理员身份运行");
					}
				}
				else
				{
					list.Add("系统环境存在问题，请尝试重装 .Net Framework 4.5");
				}
				if (IsLine)
				{
					if (Ex.InnerException == null)
					{
						result = Ex.Message.Replace("\r\n", "\r").Replace("\n", "\r").Replace("\r\r", "\r").Replace("\r", " ");
					}
					else
					{
						while (Ex != null)
						{
							list.Add(Ex.Message.Replace("\r\n", "\r").Replace("\n", "\r").Replace("\r\r", "\r").Replace("\r", " "));
							Ex = Ex.InnerException;
						}
						list.Reverse();
						result = ModBase.Join(list, " → ");
					}
				}
				else
				{
					List<string> list2 = new List<string>();
					while (Ex != null)
					{
						list.Add(Ex.Message.Replace("\r\n", "\r").Replace("\n", "\r").Replace("\r\r", "\r").Replace("\r", "\r\n"));
						if (Ex.StackTrace != null)
						{
							foreach (string text in Ex.StackTrace.Split(new char[]
							{
								'\r'
							}))
							{
								if (ShowAllTrace || text.ToLower().Contains("pcl"))
								{
									list2.Add(text.Replace("\r", string.Empty).Replace("\n", string.Empty));
								}
							}
						}
						Ex = Ex.InnerException;
					}
					result = ModBase.Join(list, "\r\nCaused By: ") + ((list2.Count > 0) ? ("\r\n" + ModBase.Join(list2, "\r\n")) : "") + ((Operators.CompareString(fullName, "System.Exception", true) == 0) ? "" : ("\r\n错误类型：" + fullName));
				}
			}
			return result;
		}

		// Token: 0x06001224 RID: 4644 RVA: 0x0000B710 File Offset: 0x00009910
		public static string GetStringFromEnum(Enum EnumData)
		{
			return Enum.GetName(EnumData.GetType(), EnumData);
		}

		// Token: 0x06001225 RID: 4645 RVA: 0x00086044 File Offset: 0x00084244
		public static string GetString(long FileSize)
		{
			checked
			{
				string result;
				if (FileSize < 0x3E8L)
				{
					result = Conversions.ToString(FileSize) + " B";
				}
				else if (FileSize < 0xFA000L)
				{
					string text = Conversions.ToString(Math.Round((double)FileSize / 1024.0));
					result = Conversions.ToString(Math.Round((double)FileSize / 1024.0, (int)Math.Round(ModBase.MathRange((double)(3 - text.Length), 0.0, 2.0)))) + " K";
				}
				else if (FileSize < 0x3E800000L)
				{
					string text2 = Conversions.ToString(Math.Round((double)FileSize / 1024.0 / 1024.0));
					result = Conversions.ToString(Math.Round((double)FileSize / 1024.0 / 1024.0, (int)Math.Round(ModBase.MathRange((double)(3 - text2.Length), 0.0, 2.0)))) + " M";
				}
				else
				{
					string text3 = Conversions.ToString(Math.Round((double)FileSize / 1024.0 / 1024.0 / 1024.0));
					result = Conversions.ToString(Math.Round((double)FileSize / 1024.0 / 1024.0 / 1024.0, (int)Math.Round(ModBase.MathRange((double)(3 - text3.Length), 0.0, 2.0)))) + " G";
				}
				return result;
			}
		}

		// Token: 0x06001226 RID: 4646 RVA: 0x0000B71E File Offset: 0x0000991E
		public static object GetJson(string Data)
		{
			return JsonConvert.DeserializeObject(Data, new JsonSerializerSettings
			{
				DateTimeZoneHandling = DateTimeZoneHandling.Local
			});
		}

		// Token: 0x06001227 RID: 4647 RVA: 0x000861EC File Offset: 0x000843EC
		public static string StrFill(string Str, string Code, byte Length)
		{
			string result;
			if (Str.Length > (int)Length)
			{
				result = Strings.Mid(Str, 1, (int)Length);
			}
			else
			{
				result = Strings.Mid(Str.PadRight((int)Length, Conversions.ToChar(Code)), checked(Str.Length + 1)) + Str;
			}
			return result;
		}

		// Token: 0x06001228 RID: 4648 RVA: 0x00086230 File Offset: 0x00084430
		public static string StrFillNum(double Num, int Length)
		{
			Num = Math.Round(Num, Length, MidpointRounding.AwayFromZero);
			string text = Conversions.ToString(Num);
			checked
			{
				if (!text.Contains("."))
				{
					text = (text + ".").PadRight(text.Length + 1 + Length, '0');
				}
				else
				{
					text = text.PadRight(text.Split(new char[]
					{
						'.'
					})[0].Length + 1 + Length, '0');
				}
				return text;
			}
		}

		// Token: 0x06001229 RID: 4649 RVA: 0x000862A0 File Offset: 0x000844A0
		public static object StrTrim(string Str, bool RemoveQuote = true)
		{
			if (RemoveQuote)
			{
				Str = Str.Split(new char[]
				{
					'（'
				})[0].Split(new char[]
				{
					'：'
				})[0].Split(new char[]
				{
					'('
				})[0].Split(new char[]
				{
					':'
				})[0];
			}
			return Str.Trim(new char[]
			{
				'.',
				'。',
				'！',
				' ',
				'!',
				'?',
				'？',
				'\r',
				'\n'
			});
		}

		// Token: 0x0600122A RID: 4650 RVA: 0x0008631C File Offset: 0x0008451C
		public static string Join(ICollection List, string Split)
		{
			StringBuilder stringBuilder = new StringBuilder();
			checked
			{
				int num = List.Count - 1;
				int num2 = num;
				for (int i = 0; i <= num2; i++)
				{
					if (List.Cast<object>().ElementAtOrDefault(i) != null)
					{
						stringBuilder.Append(RuntimeHelpers.GetObjectValue(List.Cast<object>().ElementAtOrDefault(i)));
					}
					if (i != num)
					{
						stringBuilder.Append(Split);
					}
				}
				return stringBuilder.ToString();
			}
		}

		// Token: 0x0600122B RID: 4651 RVA: 0x00086380 File Offset: 0x00084580
		public static ulong GetHash(string Str)
		{
			ulong num = 0x1505UL;
			checked
			{
				int num2 = Str.Length - 1;
				for (int i = 0; i <= num2; i++)
				{
					num = (num << 5 ^ num ^ (ulong)Str[i]);
				}
				return num ^ 0xA98F501BC684032FUL;
			}
		}

		// Token: 0x0600122C RID: 4652 RVA: 0x000863C8 File Offset: 0x000845C8
		public static string GetStringMD5(string Str)
		{
			byte[] array = new MD5CryptoServiceProvider().ComputeHash(Encoding.GetEncoding("gb2312").GetBytes(Str));
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in array)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600122D RID: 4653 RVA: 0x0000B732 File Offset: 0x00009932
		public static double Val(object Str)
		{
			if (Str is string && Operators.ConditionalCompareObjectEqual(Str, "&", true))
			{
				return 0.0;
			}
			return Conversion.Val(RuntimeHelpers.GetObjectValue(Str));
		}

		// Token: 0x0600122E RID: 4654 RVA: 0x00086424 File Offset: 0x00084624
		public static string smethod_3(string Str)
		{
			return Str.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&apos;").Replace("\"", "&quot;");
		}

		// Token: 0x0600122F RID: 4655 RVA: 0x00086480 File Offset: 0x00084680
		public static List<string> RegexSearch(string str, string regex, RegexOptions options = RegexOptions.None)
		{
			List<string> list;
			try
			{
				list = new List<string>();
				MatchCollection matchCollection = new Regex(regex, options).Matches(str);
				if (matchCollection == null)
				{
					list = list;
				}
				else
				{
					try
					{
						foreach (object obj in matchCollection)
						{
							Match match = (Match)obj;
							list.Add(match.Value);
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
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "正则匹配全部项出错", ModBase.LogLevel.Debug, "出现错误");
				list = new List<string>();
			}
			return list;
		}

		// Token: 0x06001230 RID: 4656 RVA: 0x00086530 File Offset: 0x00084730
		public static string RegexSeek(string str, string regex, RegexOptions options = RegexOptions.None)
		{
			string result;
			try
			{
				string value = Regex.Match(str, regex, options).Value;
				result = ((Operators.CompareString(value, "", true) == 0) ? null : value);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "正则匹配第一项出错", ModBase.LogLevel.Debug, "出现错误");
				result = null;
			}
			return result;
		}

		// Token: 0x06001231 RID: 4657 RVA: 0x00086594 File Offset: 0x00084794
		public static bool RegexCheck(string str, string regex, RegexOptions options = RegexOptions.None)
		{
			bool result;
			try
			{
				result = Regex.IsMatch(str, regex, options);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "正则检查出错", ModBase.LogLevel.Debug, "出现错误");
				result = false;
			}
			return result;
		}

		// Token: 0x06001232 RID: 4658 RVA: 0x0000B75F File Offset: 0x0000995F
		public static string RegexReplace(string Input, string Replacement, string Regex, RegexOptions options = RegexOptions.None)
		{
			return Regex.Replace(Input, Regex, Replacement, options);
		}

		// Token: 0x06001233 RID: 4659 RVA: 0x000865E0 File Offset: 0x000847E0
		private static string EnableIterator(string asset)
		{
			string result;
			if (string.IsNullOrEmpty(asset))
			{
				result = "@;$ Abv2";
			}
			else
			{
				result = Strings.Mid(ModBase.StrFill(Conversions.ToString(ModBase.GetHash(asset)), "X", 8), 1, 8);
			}
			return result;
		}

		// Token: 0x06001234 RID: 4660 RVA: 0x0008661C File Offset: 0x0008481C
		public static string ValidateIterator(string instance, string second = "")
		{
			second = ModBase.EnableIterator(second);
			byte[] bytes = Encoding.UTF8.GetBytes(second);
			byte[] bytes2 = Encoding.UTF8.GetBytes("95168702");
			DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
			string result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				byte[] bytes3 = Encoding.UTF8.GetBytes(instance);
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, descryptoServiceProvider.CreateEncryptor(bytes, bytes2), CryptoStreamMode.Write))
				{
					cryptoStream.Write(bytes3, 0, bytes3.Length);
					cryptoStream.FlushFinalBlock();
					result = Convert.ToBase64String(memoryStream.ToArray());
				}
			}
			return result;
		}

		// Token: 0x06001235 RID: 4661 RVA: 0x000866D4 File Offset: 0x000848D4
		public static string CancelIterator(string v, string selection = "")
		{
			selection = ModBase.EnableIterator(selection);
			byte[] bytes = Encoding.UTF8.GetBytes(selection);
			byte[] bytes2 = Encoding.UTF8.GetBytes("95168702");
			DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
			string @string;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				byte[] array = Convert.FromBase64String(v);
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, descryptoServiceProvider.CreateDecryptor(bytes, bytes2), CryptoStreamMode.Write))
				{
					cryptoStream.Write(array, 0, array.Length);
					cryptoStream.FlushFinalBlock();
					@string = Encoding.UTF8.GetString(memoryStream.ToArray());
				}
			}
			return @string;
		}

		// Token: 0x06001236 RID: 4662 RVA: 0x0008678C File Offset: 0x0008498C
		public static bool ResolveIterator(string task, string visitor)
		{
			bool result;
			try
			{
				RSACryptoServiceProvider rsacryptoServiceProvider = new RSACryptoServiceProvider(0x200);
				rsacryptoServiceProvider.FromXmlString(ModBase._FacadeRule.Replace("!", "").Replace("$", "+") + "/R1Frckd3/Sn+Zsx9aD6U2f" + Conversions.ToString(Math.Round(84m)) + "SdWMDlrRY9DfhQ==</Modulus><Exponent>AQAB<\\Exponent><\\RSAKeyValue>".Replace("\\", "/"));
				result = rsacryptoServiceProvider.VerifyData(Encoding.Default.GetBytes(task), typeof(SHA256), Convert.FromBase64String(visitor));
			}
			catch (Exception ex)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001237 RID: 4663 RVA: 0x00086844 File Offset: 0x00084A44
		private static double SearchSimilarity(string Source, string Query)
		{
			int i = 0;
			double num = 0.0;
			Source = Source.ToLower().Replace(" ", "");
			Query = Query.ToLower().Replace(" ", "");
			int length = Source.Length;
			int length2 = Query.Length;
			checked
			{
				while (i < Query.Length)
				{
					int j = 0;
					int num2 = 0;
					int num3 = 0;
					while (j < Source.Length)
					{
						int num4 = 0;
						while (i + num4 < Query.Length && j + num4 < Source.Length)
						{
							if (Source[j + num4] != Query[i + num4])
							{
								break;
							}
							num4++;
						}
						if (num4 > num2)
						{
							num2 = num4;
							num3 = j;
						}
						j += Math.Max(1, num4);
					}
					if (num2 > 0)
					{
						Source = Source.Substring(0, num3) + ((Source.Count<char>() > num3 + num2) ? Source.Substring(num3 + num2) : string.Empty);
						unchecked
						{
							double num5 = Math.Pow(1.4, (double)(checked(3 + num2))) - 3.6;
							num5 *= 1.0 + 0.3 * (double)Math.Max(0, checked(3 - Math.Abs(i - num3)));
							num += num5;
						}
					}
					i += Math.Max(1, num2);
				}
			}
			return num / (double)length2 * (3.0 / Math.Pow((double)(checked(length + 0xF)), 0.5)) * (double)((length2 <= 2) ? checked(3 - length2) : 1);
		}

		// Token: 0x06001238 RID: 4664 RVA: 0x000869D4 File Offset: 0x00084BD4
		private static double SearchSimilarityWeighted(List<KeyValuePair<string, double>> Source, string Query)
		{
			double num = 0.0;
			double num2 = 0.0;
			try
			{
				foreach (KeyValuePair<string, double> keyValuePair in Source)
				{
					num2 += ModBase.SearchSimilarity(keyValuePair.Key, Query) * keyValuePair.Value;
					num += keyValuePair.Value;
				}
			}
			finally
			{
				List<KeyValuePair<string, double>>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			return num2 / num;
		}

		// Token: 0x06001239 RID: 4665 RVA: 0x00086A54 File Offset: 0x00084C54
		public static List<ModBase.SearchEntry<T>> Search<T>(List<ModBase.SearchEntry<T>> Entries, string Query, int MaxBlurCount = 5, double MinBlurSimilarity = 0.1)
		{
			List<ModBase.SearchEntry<T>> list = new List<ModBase.SearchEntry<T>>();
			checked
			{
				List<ModBase.SearchEntry<T>> result;
				if (Entries.Count == 0)
				{
					result = list;
				}
				else
				{
					try
					{
						foreach (ModBase.SearchEntry<T> searchEntry in Entries)
						{
							searchEntry.specificationMapper = ModBase.SearchSimilarityWeighted(searchEntry.mockMapper, Query);
							searchEntry.m_DicMapper = false;
							try
							{
								foreach (KeyValuePair<string, double> keyValuePair in searchEntry.mockMapper)
								{
									if (keyValuePair.Key.ToLower().Replace(" ", "").Contains(Query.ToLower().Replace(" ", "")))
									{
										searchEntry.m_DicMapper = true;
									}
								}
							}
							finally
							{
								List<KeyValuePair<string, double>>.Enumerator enumerator2;
								((IDisposable)enumerator2).Dispose();
							}
						}
					}
					finally
					{
						List<ModBase.SearchEntry<T>>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					Entries = ModBase.Sort<ModBase.SearchEntry<T>>(Entries, (ModBase._Closure$__92<T>.$IR92-1 == null) ? (ModBase._Closure$__92<T>.$IR92-1 = ((object a0, object a1) => ((ModBase._Closure$__92<$CLS0>.$I92-0 == null) ? (ModBase._Closure$__92<$CLS0>.$I92-0 = delegate(ModBase.SearchEntry<$CLS0> Left, ModBase.SearchEntry<$CLS0> Right)
					{
						bool result2;
						if (Left.m_DicMapper ^ Right.m_DicMapper)
						{
							result2 = Left.m_DicMapper;
						}
						else
						{
							result2 = (Left.specificationMapper > Right.specificationMapper);
						}
						return result2;
					}) : ModBase._Closure$__92<$CLS0>.$I92-0)((ModBase.SearchEntry<$CLS0>)a0, (ModBase.SearchEntry<$CLS0>)a1))) : ModBase._Closure$__92<T>.$IR92-1);
					int num = 0;
					try
					{
						foreach (ModBase.SearchEntry<T> searchEntry2 in Entries)
						{
							if (searchEntry2.m_DicMapper)
							{
								list.Add(searchEntry2);
							}
							else
							{
								if (searchEntry2.specificationMapper < MinBlurSimilarity)
								{
									break;
								}
								if (num == MaxBlurCount)
								{
									break;
								}
								list.Add(searchEntry2);
								num++;
							}
						}
					}
					finally
					{
						List<ModBase.SearchEntry<T>>.Enumerator enumerator3;
						((IDisposable)enumerator3).Dispose();
					}
					result = list;
				}
				return result;
			}
		}

		// Token: 0x0600123A RID: 4666 RVA: 0x00086BF0 File Offset: 0x00084DF0
		public static int GetUuid()
		{
			if (ModBase.mappingRule == null)
			{
				ModBase.mappingRule = RuntimeHelpers.GetObjectValue(new object());
			}
			object obj = ModBase.mappingRule;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			checked
			{
				int codeRule;
				lock (obj)
				{
					ModBase._CodeRule++;
					codeRule = ModBase._CodeRule;
				}
				return codeRule;
			}
		}

		// Token: 0x0600123B RID: 4667 RVA: 0x00086C58 File Offset: 0x00084E58
		public static ArrayList GetFullList(IList data)
		{
			ArrayList arrayList = new ArrayList();
			checked
			{
				int num = data.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (data[i].GetType().ToString().Contains("List"))
					{
						arrayList.AddRange((ICollection)data[i]);
					}
					else
					{
						arrayList.Add(RuntimeHelpers.GetObjectValue(data[i]));
					}
				}
				return arrayList;
			}
		}

		// Token: 0x0600123C RID: 4668 RVA: 0x00086CC8 File Offset: 0x00084EC8
		public static List<T> GetFullList<T>(IList data)
		{
			List<T> list = new List<T>();
			checked
			{
				int num = data.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (data[i].GetType().ToString().Contains("List"))
					{
						list.AddRange((IEnumerable<T>)data[i]);
					}
					else
					{
						list.Add(Conversions.ToGenericParameter<T>(data[i]));
					}
				}
				return list;
			}
		}

		// Token: 0x0600123D RID: 4669 RVA: 0x00086D34 File Offset: 0x00084F34
		public static T[] ArrayNoDouble<T>(T[] Arr, ModBase.CompareThreadStart IsEqual = null)
		{
			List<T> list = new List<T>();
			int num = Information.UBound(Arr, 1);
			int i = 0;
			IL_86:
			checked
			{
				while (i <= num)
				{
					int num2 = i + 1;
					int num3 = Information.UBound(Arr, 1);
					int j = num2;
					while (j <= num3)
					{
						if (IsEqual == null)
						{
							if (Arr[i].Equals(Arr[j]))
							{
								goto IL_82;
							}
						}
						else if (IsEqual(Arr[i], Arr[j]))
						{
							goto IL_82;
						}
						j++;
						continue;
						IL_82:
						i++;
						goto IL_86;
					}
					list.Add(Arr[i]);
					goto IL_82;
				}
				return list.ToArray();
			}
		}

		// Token: 0x0600123E RID: 4670 RVA: 0x00086DD4 File Offset: 0x00084FD4
		public static List<T> ArrayNoDouble<T>(List<T> Arr, ModBase.CompareThreadStart IsEqual = null)
		{
			List<T> list = new List<T>();
			checked
			{
				int num = Arr.Count - 1;
				int i = 0;
				IL_8A:
				while (i <= num)
				{
					int num2 = i + 1;
					int num3 = Arr.Count - 1;
					int j = num2;
					while (j <= num3)
					{
						if (IsEqual == null)
						{
							T t = Arr[i];
							if (t.Equals(Arr[j]))
							{
								goto IL_86;
							}
						}
						else if (IsEqual(Arr[i], Arr[j]))
						{
							goto IL_86;
						}
						j++;
						continue;
						IL_86:
						i++;
						goto IL_8A;
					}
					list.Add(Arr[i]);
					goto IL_86;
				}
				return list;
			}
		}

		// Token: 0x0600123F RID: 4671 RVA: 0x0000B76A File Offset: 0x0000996A
		public static void DictionaryAdd<TKey, TValue>(ref Dictionary<TKey, TValue> Dict, TKey Key, TValue Value)
		{
			if (Dict.ContainsKey(Key))
			{
				Dict[Key] = Value;
				return;
			}
			Dict.Add(Key, Value);
		}

		// Token: 0x06001240 RID: 4672 RVA: 0x00086E70 File Offset: 0x00085070
		public static string GetTimeNow()
		{
			return DateTime.Now.ToString("HH:mm:ss.fff");
		}

		// Token: 0x06001241 RID: 4673 RVA: 0x0000B789 File Offset: 0x00009989
		public static long GetTimeTick()
		{
			return checked(unchecked((long)MyWpfExtension.RunFactory().Clock.TickCount) + 0x80000003L);
		}

		// Token: 0x06001242 RID: 4674 RVA: 0x00086E90 File Offset: 0x00085090
		public static string GetTimeSpanString(TimeSpan Span)
		{
			string str = (Span.TotalMilliseconds > 0.0) ? "后" : "前";
			if (Span.TotalMilliseconds < 0.0)
			{
				Span = -Span;
			}
			double num = Math.Floor((double)Span.Days / 30.0);
			string str2;
			if (num >= 61.0)
			{
				str2 = Conversions.ToString(Math.Floor(num / 12.0)) + " 年";
			}
			else if (num >= 12.0)
			{
				str2 = Conversions.ToString(Math.Floor(num / 12.0)) + " 年" + ((num % 12.0 > 0.0) ? (" " + Conversions.ToString(num % 12.0) + " 个月") : "");
			}
			else if (num >= 4.0)
			{
				str2 = Conversions.ToString(num) + " 月";
			}
			else if (num >= 1.0)
			{
				str2 = Conversions.ToString(num) + " 月" + ((Span.Days % 0x1E > 0) ? (" " + Conversions.ToString(Span.Days % 0x1E) + " 天") : "");
			}
			else if (Span.TotalDays >= 4.0)
			{
				str2 = Conversions.ToString(Span.Days) + " 天";
			}
			else if (Span.TotalDays >= 1.0)
			{
				str2 = Conversions.ToString(Span.Days) + " 天" + ((Span.Hours > 0) ? (" " + Conversions.ToString(Span.Hours) + " 小时") : "");
			}
			else if (Span.TotalHours >= 10.0)
			{
				str2 = Conversions.ToString(Span.Hours) + " 小时";
			}
			else if (Span.TotalHours >= 1.0)
			{
				str2 = Conversions.ToString(Span.Hours) + " 小时" + ((Span.Minutes > 0) ? (" " + Conversions.ToString(Span.Minutes) + " 分钟") : "");
			}
			else if (Span.TotalMinutes >= 10.0)
			{
				str2 = Conversions.ToString(Span.Minutes) + " 分钟";
			}
			else if (Span.TotalMinutes >= 1.0)
			{
				str2 = Conversions.ToString(Span.Minutes) + " 分" + ((Span.Seconds > 0) ? (" " + Conversions.ToString(Span.Seconds) + " 秒") : "");
			}
			else if (Span.TotalSeconds >= 1.0)
			{
				str2 = Conversions.ToString(Span.Seconds) + " 秒";
			}
			else
			{
				str2 = "1 秒";
			}
			return str2 + str;
		}

		// Token: 0x06001243 RID: 4675 RVA: 0x000871D4 File Offset: 0x000853D4
		public static long GetUnixTimestamp()
		{
			return checked((long)Math.Round((double)(DateAndTime.Now.ToUniversalTime().Ticks - 0x89F7FF5F7B58000L) / 10000000.0));
		}

		// Token: 0x06001244 RID: 4676 RVA: 0x00087214 File Offset: 0x00085414
		public static object GetCdnTypeA(string UrlWithMark)
		{
			object result;
			if (!UrlWithMark.EndsWith("{CDN}"))
			{
				result = UrlWithMark;
			}
			else
			{
				string text = UrlWithMark.Replace("{CDN}", "").Replace(" ", "%20");
				string text2 = ModBase.StrFill(ModBase.RandomInteger(0, 0x7FFFFFFD).ToString("x"), "0", 8);
				string text3 = ModBase.CancelIterator("VwHB1je1uabAr0gKijpFaQ==", "CDN");
				string text4 = Conversions.ToString(ModBase.GetUnixTimestamp());
				string text5 = text.Substring(checked(text.IndexOf("://") + 3));
				text5 = text5.Substring(text5.IndexOf("/"));
				string stringMD = ModBase.GetStringMD5(ModBase.Join(new string[]
				{
					text5,
					text4,
					text2,
					"0",
					text3
				}, "-"));
				result = text + "?sign=" + ModBase.Join(new string[]
				{
					text4,
					text2,
					"0",
					stringMD
				}, "-");
			}
			return result;
		}

		// Token: 0x06001245 RID: 4677 RVA: 0x00087324 File Offset: 0x00085524
		public static ModBase.Result ShellAndGetExitCode(string FileName, string Arguments = "", bool WaitForExit = false, int Timeout = 0xF4240)
		{
			ModBase.Result result;
			try
			{
				using (Process process = new Process())
				{
					process.StartInfo.Arguments = Arguments;
					process.StartInfo.FileName = FileName;
					ModBase.Log("[System] 执行外部命令并等待返回码：" + FileName + " " + Arguments, ModBase.LogLevel.Normal, "出现错误");
					process.Start();
					if (WaitForExit)
					{
						if (process.WaitForExit(Timeout))
						{
							result = (ModBase.Result)process.ExitCode;
						}
						else
						{
							result = ModBase.Result.Timeout;
						}
					}
					else
					{
						result = ModBase.Result.Success;
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "执行命令失败：" + FileName, ModBase.LogLevel.Msgbox, "出现错误");
				result = ModBase.Result.Fail;
			}
			return result;
		}

		// Token: 0x06001246 RID: 4678 RVA: 0x000873E0 File Offset: 0x000855E0
		public static string ShellAndGetOutput(string FileName, string Arguments = "", int Timeout = 0xF4240, string WorkingDirectory = null)
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo
			{
				Arguments = Arguments,
				FileName = FileName,
				UseShellExecute = false,
				CreateNoWindow = true,
				RedirectStandardError = true,
				RedirectStandardOutput = true,
				WorkingDirectory = (WorkingDirectory ?? ModBase.Path.TrimEnd(new char[]
				{
					'\\'
				}))
			};
			if (WorkingDirectory != null)
			{
				if (processStartInfo.EnvironmentVariables.ContainsKey("appdata"))
				{
					processStartInfo.EnvironmentVariables["appdata"] = WorkingDirectory;
				}
				else
				{
					processStartInfo.EnvironmentVariables.Add("appdata", WorkingDirectory);
				}
			}
			ModBase.Log("[System] 执行外部命令并等待返回结果：" + FileName + " " + Arguments, ModBase.LogLevel.Normal, "出现错误");
			string result;
			using (Process process = new Process
			{
				StartInfo = processStartInfo
			})
			{
				process.Start();
				process.WaitForExit(Timeout);
				result = process.StandardOutput.ReadToEnd() + process.StandardError.ReadToEnd();
			}
			return result;
		}

		// Token: 0x06001247 RID: 4679 RVA: 0x000874EC File Offset: 0x000856EC
		public static Thread RunInNewThread(ThreadStart ThreadStart, string Name, ThreadPriority Priority = ThreadPriority.Normal)
		{
			Thread thread = new Thread(delegate()
			{
				try
				{
					ThreadStart();
				}
				catch (ThreadAbortException ex)
				{
					ModBase.Log(Name + "：线程已中止", ModBase.LogLevel.Normal, "出现错误");
				}
				catch (Exception ex2)
				{
					ModBase.Log(ex2, Name + "：线程执行失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			});
			thread.Name = Name;
			thread.Priority = Priority;
			thread.Start();
			return thread;
		}

		// Token: 0x06001248 RID: 4680 RVA: 0x00087538 File Offset: 0x00085738
		public static void RunInUi(Delegate ThreadStart, params object[] Param)
		{
			if (ModBase.RunInUi())
			{
				try
				{
					ThreadStart.DynamicInvoke(Param);
					return;
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "在 UI 线程执行代码出错", ModBase.LogLevel.Feedback, "出现错误");
					return;
				}
			}
			ModMain.m_GetterFilter.Dispatcher.Invoke(ThreadStart, Param);
		}

		// Token: 0x06001249 RID: 4681 RVA: 0x0000B7A5 File Offset: 0x000099A5
		public static void RunInUiWait(ThreadStart ThreadStart)
		{
			if (ModBase.RunInUi())
			{
				ThreadStart();
				return;
			}
			System.Windows.Application.Current.Dispatcher.Invoke(ThreadStart, new object[0]);
		}

		// Token: 0x0600124A RID: 4682 RVA: 0x0000B7CC File Offset: 0x000099CC
		public static void RunInUiWait(ParameterizedThreadStart ThreadStart, object Param)
		{
			if (ModBase.RunInUi())
			{
				ThreadStart(RuntimeHelpers.GetObjectValue(Param));
				return;
			}
			System.Windows.Application.Current.Dispatcher.Invoke(ThreadStart, new object[]
			{
				Param
			});
		}

		// Token: 0x0600124B RID: 4683 RVA: 0x0000B7FD File Offset: 0x000099FD
		public static void RunInUi(Action ThreadStart, bool ForceWaitUntilLoaded = false)
		{
			if (ForceWaitUntilLoaded)
			{
				System.Windows.Application.Current.Dispatcher.InvokeAsync(ThreadStart, DispatcherPriority.Loaded);
				return;
			}
			if (ModBase.RunInUi())
			{
				ThreadStart();
				return;
			}
			System.Windows.Application.Current.Dispatcher.InvokeAsync(ThreadStart);
		}

		// Token: 0x0600124C RID: 4684 RVA: 0x0000B834 File Offset: 0x00009A34
		public static void RunInThread(ThreadStart ThreadStart)
		{
			if (ModBase.RunInUi())
			{
				ModBase.RunInNewThread(ThreadStart, "Runtime Invoke " + Conversions.ToString(ModBase.GetUuid()) + "#", ThreadPriority.Normal);
				return;
			}
			ThreadStart();
		}

		// Token: 0x0600124D RID: 4685 RVA: 0x0000B865 File Offset: 0x00009A65
		public static string GetUniqueAddress()
		{
			return (string)new GClass18().method_112(null, 0xB34D3);
		}

		// Token: 0x0600124E RID: 4686 RVA: 0x00087598 File Offset: 0x00085798
		public static ArrayList Sort(ArrayList List, ModBase.CompareThreadStart SortRule)
		{
			ArrayList arrayList = new ArrayList();
			checked
			{
				while (List.Count > 0)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(List[0]);
					int num = List.Count - 1;
					for (int i = 1; i <= num; i++)
					{
						if (SortRule(RuntimeHelpers.GetObjectValue(List[i]), RuntimeHelpers.GetObjectValue(objectValue)))
						{
							objectValue = RuntimeHelpers.GetObjectValue(List[i]);
						}
					}
					List.Remove(RuntimeHelpers.GetObjectValue(objectValue));
					arrayList.Add(RuntimeHelpers.GetObjectValue(objectValue));
				}
				return arrayList;
			}
		}

		// Token: 0x0600124F RID: 4687 RVA: 0x0008761C File Offset: 0x0008581C
		public static List<T> Sort<T>(List<T> List, ModBase.CompareThreadStart SortRule)
		{
			List<T> list = new List<T>();
			checked
			{
				while (List.Count > 0)
				{
					T t = List[0];
					int num = List.Count - 1;
					for (int i = 1; i <= num; i++)
					{
						if (SortRule(List[i], t))
						{
							t = List[i];
						}
					}
					List.Remove(t);
					list.Add(t);
				}
				return list;
			}
		}

		// Token: 0x06001250 RID: 4688 RVA: 0x0008768C File Offset: 0x0008588C
		public static object GetProgramArgument(string Name, object DefaultValue = "")
		{
			string[] array = Interaction.Command().Split(new char[]
			{
				' '
			});
			checked
			{
				int num = array.Length - 1;
				for (int i = 0; i <= num; i++)
				{
					if (Operators.CompareString(array[i], "-" + Name, true) == 0)
					{
						object result;
						if (array.Length != i + 1 && !array[i + 1].StartsWith("-"))
						{
							result = array[i + 1];
						}
						else
						{
							result = true;
						}
						return result;
					}
				}
				return DefaultValue;
			}
		}

		// Token: 0x06001251 RID: 4689 RVA: 0x00087704 File Offset: 0x00085904
		public static DateTime GetDate(int timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(0x7B2, 1, 1, 0, 0, 0, DateTimeKind.Utc));
			long ticks = checked(unchecked((long)timeStamp) * 0x989680L);
			return dateTime.Add(new TimeSpan(ticks));
		}

		// Token: 0x06001252 RID: 4690 RVA: 0x00087748 File Offset: 0x00085948
		public static DateTime GetLocalTime(DateTime UtcDate)
		{
			return DateTime.SpecifyKind(UtcDate, DateTimeKind.Utc).ToLocalTime();
		}

		// Token: 0x06001253 RID: 4691 RVA: 0x00087764 File Offset: 0x00085964
		public static void OpenWebsite(string Url)
		{
			try
			{
				ModBase.Log("[System] 正在打开网页：" + Url, ModBase.LogLevel.Normal, "出现错误");
				Process.Start(Url);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "无法打开网页（" + Url + "）", ModBase.LogLevel.Debug, "出现错误");
				ModBase.ClipboardSet(Url, false);
				ModMain.MyMsgBox("可能由于浏览器未正确配置，PCL2 无法为你打开网页。\r\n网址已经复制到剪贴板，若有需要可以手动粘贴访问。", "无法打开网页", "确定", "", "", false, true, false);
			}
		}

		// Token: 0x06001254 RID: 4692 RVA: 0x000877F4 File Offset: 0x000859F4
		public static void OpenExplorer(string Argument)
		{
			try
			{
				Process.Start("explorer.exe", Argument);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "打开资源管理器失败，请尝试关闭安全软件（如 360 安全卫士）", ModBase.LogLevel.Msgbox, "出现错误");
			}
		}

		// Token: 0x06001255 RID: 4693 RVA: 0x00087840 File Offset: 0x00085A40
		public static void ShowWindowToTop(IntPtr Handle)
		{
			try
			{
				ModBase.PostMessageA(Handle, 0x1902U, 0L, 0L);
				ModBase.SetForegroundWindow(Handle);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "设置窗口置顶失败", ModBase.LogLevel.Hint, "出现错误");
			}
		}

		// Token: 0x06001256 RID: 4694
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr FindWindowA([MarshalAs(UnmanagedType.VBByRefStr)] ref string ClassName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string WindowName);

		// Token: 0x06001257 RID: 4695
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int SetForegroundWindow(IntPtr hWnd);

		// Token: 0x06001258 RID: 4696
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern bool PostMessageA(IntPtr hWnd, uint msg, long wParam, long lParam);

		// Token: 0x06001259 RID: 4697 RVA: 0x000878A4 File Offset: 0x00085AA4
		public static void ClipboardSet(string Text, bool ShowSuccessHint = true)
		{
			ModBase._Closure$__129-0 CS$<>8__locals1 = new ModBase._Closure$__129-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_Text = Text;
			CS$<>8__locals1.$VB$Local_ShowSuccessHint = ShowSuccessHint;
			ModBase.RunInThread(checked(delegate
			{
				int num = 0;
				for (;;)
				{
					try
					{
						ModBase.RunInUi((CS$<>8__locals1.$I1 == null) ? (CS$<>8__locals1.$I1 = delegate()
						{
							MyWpfExtension.RunFactory().Clipboard.Clear();
							MyWpfExtension.RunFactory().Clipboard.SetText(CS$<>8__locals1.$VB$Local_Text);
						}) : CS$<>8__locals1.$I1, false);
						break;
					}
					catch (Exception ex)
					{
						num++;
						if (num > 5)
						{
							ModBase.Log(ex, "可能由于剪贴板被其他程序占用，文本复制失败", ModBase.LogLevel.Hint, "出现错误");
							break;
						}
						Thread.Sleep(0x14);
					}
				}
				if (CS$<>8__locals1.$VB$Local_ShowSuccessHint)
				{
					ModMain.Hint("已成功复制！", ModMain.HintType.Finish, true);
				}
			}));
		}

		// Token: 0x0600125A RID: 4698 RVA: 0x0000B87C File Offset: 0x00009A7C
		public static byte[] GetResources(string ResourceName)
		{
			ModBase.Log("[System] 获取资源：" + ResourceName, ModBase.LogLevel.Normal, "出现错误");
			return (byte[])Resources.PostFactory.GetObject(ResourceName);
		}

		// Token: 0x0600125B RID: 4699 RVA: 0x000878D8 File Offset: 0x00085AD8
		public static void DeltaLeft(FrameworkElement control, double newValue)
		{
			ModBase.DebugAssert(!double.IsNaN(newValue));
			ModBase.DebugAssert(!double.IsInfinity(newValue));
			if (control is Window)
			{
				Window window;
				(window = (Window)control).Left = window.Left + newValue;
				return;
			}
			switch (control.HorizontalAlignment)
			{
			case System.Windows.HorizontalAlignment.Left:
			case System.Windows.HorizontalAlignment.Stretch:
				control.Margin = new Thickness(control.Margin.Left + newValue, control.Margin.Top, control.Margin.Right, control.Margin.Bottom);
				return;
			default:
				ModBase.DebugAssert(false);
				return;
			case System.Windows.HorizontalAlignment.Right:
				control.Margin = new Thickness(control.Margin.Left, control.Margin.Top, control.Margin.Right - newValue, control.Margin.Bottom);
				return;
			}
		}

		// Token: 0x0600125C RID: 4700 RVA: 0x000879D0 File Offset: 0x00085BD0
		public static void SetLeft(FrameworkElement control, double newValue)
		{
			ModBase.DebugAssert(control.HorizontalAlignment == System.Windows.HorizontalAlignment.Left);
			control.Margin = new Thickness(newValue, control.Margin.Top, control.Margin.Right, control.Margin.Bottom);
		}

		// Token: 0x0600125D RID: 4701 RVA: 0x00087A24 File Offset: 0x00085C24
		public static void DeltaTop(FrameworkElement control, double newValue)
		{
			ModBase.DebugAssert(!double.IsNaN(newValue));
			ModBase.DebugAssert(!double.IsInfinity(newValue));
			if (control is Window)
			{
				Window window;
				(window = (Window)control).Top = window.Top + newValue;
				return;
			}
			VerticalAlignment verticalAlignment = control.VerticalAlignment;
			if (verticalAlignment == VerticalAlignment.Top)
			{
				control.Margin = new Thickness(control.Margin.Left, control.Margin.Top + newValue, control.Margin.Right, control.Margin.Bottom);
				return;
			}
			if (verticalAlignment != VerticalAlignment.Bottom)
			{
				ModBase.DebugAssert(false);
				return;
			}
			control.Margin = new Thickness(control.Margin.Left, control.Margin.Top, control.Margin.Right, control.Margin.Bottom - newValue);
		}

		// Token: 0x0600125E RID: 4702 RVA: 0x00087B0C File Offset: 0x00085D0C
		public static void SetTop(FrameworkElement control, double newValue)
		{
			ModBase.DebugAssert(control.VerticalAlignment == VerticalAlignment.Top);
			control.Margin = new Thickness(control.Margin.Left, newValue, control.Margin.Right, control.Margin.Bottom);
		}

		// Token: 0x0600125F RID: 4703 RVA: 0x0000B8A4 File Offset: 0x00009AA4
		public static double GetPixelSize(double WPFSize)
		{
			return WPFSize / 96.0 * (double)ModBase._BridgeRule;
		}

		// Token: 0x06001260 RID: 4704 RVA: 0x0000B8B8 File Offset: 0x00009AB8
		public static double smethod_4(double PixelSize)
		{
			return PixelSize * 96.0 / (double)ModBase._BridgeRule;
		}

		// Token: 0x06001261 RID: 4705 RVA: 0x00087B60 File Offset: 0x00085D60
		public static ImageBrush ControlBrush(FrameworkElement UI)
		{
			double actualWidth = UI.ActualWidth;
			double actualHeight = UI.ActualHeight;
			ImageBrush result;
			if (actualWidth >= 1.0 && actualHeight >= 1.0)
			{
				RenderTargetBitmap renderTargetBitmap = checked(new RenderTargetBitmap((int)Math.Round(ModBase.GetPixelSize(actualWidth)), (int)Math.Round(ModBase.GetPixelSize(actualHeight)), (double)ModBase._BridgeRule, (double)ModBase._BridgeRule, PixelFormats.Pbgra32));
				renderTargetBitmap.Render(UI);
				result = new ImageBrush(renderTargetBitmap);
			}
			else
			{
				result = new ImageBrush();
			}
			return result;
		}

		// Token: 0x06001262 RID: 4706 RVA: 0x00087BDC File Offset: 0x00085DDC
		public static ImageBrush ControlBrush(FrameworkElement UI, double Width, double Height, double Left = 0.0, double Top = 0.0)
		{
			UI.Measure(new System.Windows.Size(Width, Height));
			UI.Arrange(new Rect(0.0, 0.0, Width, Height));
			RenderTargetBitmap renderTargetBitmap = checked(new RenderTargetBitmap((int)Math.Round(ModBase.GetPixelSize(Width)), (int)Math.Round(ModBase.GetPixelSize(Height)), (double)ModBase._BridgeRule, (double)ModBase._BridgeRule, PixelFormats.Default));
			renderTargetBitmap.Render(UI);
			if (Left != 0.0 || Top != 0.0)
			{
				UI.Arrange(new Rect(Left, Top, Width, Height));
			}
			return new ImageBrush(renderTargetBitmap);
		}

		// Token: 0x06001263 RID: 4707 RVA: 0x0000B8CC File Offset: 0x00009ACC
		public static void ControlFreeze(System.Windows.Controls.Panel UI)
		{
			UI.Background = ModBase.ControlBrush(UI);
			UI.Children.Clear();
		}

		// Token: 0x06001264 RID: 4708 RVA: 0x0000B8E5 File Offset: 0x00009AE5
		public static void ControlFreeze(Border UI)
		{
			UI.Background = ModBase.ControlBrush(UI);
			UI.Child = null;
		}

		// Token: 0x06001265 RID: 4709 RVA: 0x00087C7C File Offset: 0x00085E7C
		public static object GetObjectFromXML(XElement Str)
		{
			object result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (StreamWriter streamWriter = new StreamWriter(memoryStream))
				{
					streamWriter.Write(Str.ToString());
					streamWriter.Flush();
					memoryStream.Position = 0L;
					result = XamlReader.Load(memoryStream);
				}
			}
			return result;
		}

		// Token: 0x06001266 RID: 4710 RVA: 0x00087CF4 File Offset: 0x00085EF4
		public static object GetObjectFromXML(string Str)
		{
			object result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (StreamWriter streamWriter = new StreamWriter(memoryStream))
				{
					streamWriter.Write(Str);
					streamWriter.Flush();
					memoryStream.Position = 0L;
					result = XamlReader.Load(memoryStream);
				}
			}
			return result;
		}

		// Token: 0x06001267 RID: 4711 RVA: 0x0000B8FA File Offset: 0x00009AFA
		public static bool RunInUi()
		{
			return Thread.CurrentThread.ManagedThreadId == ModBase.m_SingletonRule;
		}

		// Token: 0x06001268 RID: 4712 RVA: 0x0000B90D File Offset: 0x00009B0D
		public static void LogStart()
		{
			ModBase.RunInNewThread((ModBase._Closure$__.$I151-0 == null) ? (ModBase._Closure$__.$I151-0 = delegate()
			{
				bool flag = true;
				try
				{
					if (File.Exists(ModBase.Path + "PCL\\Log4.txt"))
					{
						if (File.Exists(ModBase.Path + "PCL\\Log5.txt"))
						{
							File.Delete(ModBase.Path + "PCL\\Log5.txt");
						}
						File.Copy(ModBase.Path + "PCL\\Log4.txt", ModBase.Path + "PCL\\Log5.txt");
					}
					if (File.Exists(ModBase.Path + "PCL\\Log3.txt"))
					{
						if (File.Exists(ModBase.Path + "PCL\\Log4.txt"))
						{
							File.Delete(ModBase.Path + "PCL\\Log4.txt");
						}
						File.Copy(ModBase.Path + "PCL\\Log3.txt", ModBase.Path + "PCL\\Log4.txt");
					}
					if (File.Exists(ModBase.Path + "PCL\\Log2.txt"))
					{
						if (File.Exists(ModBase.Path + "PCL\\Log3.txt"))
						{
							File.Delete(ModBase.Path + "PCL\\Log3.txt");
						}
						File.Copy(ModBase.Path + "PCL\\Log2.txt", ModBase.Path + "PCL\\Log3.txt");
					}
					if (File.Exists(ModBase.Path + "PCL\\Log1.txt"))
					{
						if (File.Exists(ModBase.Path + "PCL\\Log2.txt"))
						{
							File.Delete(ModBase.Path + "PCL\\Log2.txt");
						}
						File.Copy(ModBase.Path + "PCL\\Log1.txt", ModBase.Path + "PCL\\Log2.txt");
					}
					File.Create(ModBase.Path + "PCL\\Log1.txt").Dispose();
				}
				catch (Exception ex)
				{
					flag = false;
					ModMain.Hint("可能同时开启了多个 PCL2，程序可能会出现未知问题！", ModMain.HintType.Critical, true);
					ModBase.Log(ex, "日志初始化失败", ModBase.LogLevel.Debug, "出现错误");
				}
				try
				{
					ModBase._WorkerRule = new StreamWriter(ModBase.Path + "PCL\\Log1.txt", true)
					{
						AutoFlush = true
					};
					goto IL_239;
				}
				catch (Exception ex2)
				{
					ModBase._WorkerRule = null;
					ModBase.Log(ex2, "日志写入失败", ModBase.LogLevel.Hint, "出现错误");
					goto IL_239;
				}
				IL_21F:
				ModBase._CallbackRule = new StringBuilder();
				IL_229:
				Thread.Sleep(0x32);
				IL_239:
				if (flag)
				{
					ModBase.LogFlush();
					goto IL_229;
				}
				goto IL_21F;
			}) : ModBase._Closure$__.$I151-0, "Log Writer", ThreadPriority.Lowest);
		}

		// Token: 0x06001269 RID: 4713 RVA: 0x00087D64 File Offset: 0x00085F64
		public static void LogFlush()
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_00:
				ProjectData.ClearProjectError();
				num = 1;
				IL_07:
				int num2 = 2;
				if (ModBase._WorkerRule == null)
				{
					goto IL_72;
				}
				IL_10:
				num2 = 4;
				string text = null;
				IL_14:
				num2 = 5;
				object visitorRule = ModBase.m_VisitorRule;
				ObjectFlowControl.CheckForSyncLockOnValueType(visitorRule);
				lock (visitorRule)
				{
					if (ModBase._CallbackRule.Length > 0)
					{
						StringBuilder callbackRule = ModBase._CallbackRule;
						ModBase._CallbackRule = new StringBuilder();
						text = callbackRule.ToString();
					}
				}
				IL_60:
				num2 = 6;
				if (text == null)
				{
					goto IL_72;
				}
				IL_65:
				num2 = 7;
				ModBase._WorkerRule.Write(text);
				IL_72:
				goto IL_E1;
				IL_74:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_A2:
				goto IL_D6;
				IL_A4:
				num4 = num2;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_B4:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_A4;
			}
			IL_D6:
			throw ProjectData.CreateProjectError(-0x7FF5FFCD);
			IL_E1:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x00087E78 File Offset: 0x00086078
		public static void Log(string Text, ModBase.LogLevel Level = ModBase.LogLevel.Normal, string Title = "出现错误")
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_00:
				ProjectData.ClearProjectError();
				num = 1;
				IL_07:
				int num2 = 2;
				string value = string.Concat(new string[]
				{
					"[",
					ModBase.GetTimeNow(),
					"] ",
					Text,
					"\r\n"
				});
				IL_39:
				num2 = 3;
				if (!ModBase.errorRule)
				{
					goto IL_78;
				}
				IL_42:
				num2 = 4;
				object indexerRule = ModBase._IndexerRule;
				ObjectFlowControl.CheckForSyncLockOnValueType(indexerRule);
				lock (indexerRule)
				{
					ModBase._CallbackRule.Append(value);
					goto IL_86;
				}
				IL_78:
				num2 = 6;
				ModBase._CallbackRule.Append(value);
				IL_86:
				num2 = 7;
				if (ModBase._AlgoRule || Level == ModBase.LogLevel.Normal)
				{
					goto IL_209;
				}
				IL_98:
				num2 = 9;
				Text = ModBase.RegexReplace(Text, "", "\\[[^\\]]+?\\] ", RegexOptions.None);
				IL_AE:
				num2 = 0xA;
				switch (Level)
				{
				case ModBase.LogLevel.Debug:
					IL_DA:
					num2 = 0xD;
					if (!ModBase.errorRule)
					{
						break;
					}
					IL_E7:
					num2 = 0xE;
					ModMain.Hint("[调试模式] " + Text, ModMain.HintType.Info, false);
					break;
				case ModBase.LogLevel.Hint:
					IL_101:
					num2 = 0x10;
					ModBase.m_ObjectRule = true;
					IL_10A:
					num2 = 0x11;
					ModMain.Hint(Text, ModMain.HintType.Critical, false);
					break;
				case ModBase.LogLevel.Msgbox:
					IL_11A:
					num2 = 0x13;
					ModBase.m_ObjectRule = true;
					IL_123:
					num2 = 0x14;
					ModMain.MyMsgBox(Text, Title, "确定", "", "", false, true, false);
					break;
				case ModBase.LogLevel.Feedback:
					IL_145:
					num2 = 0x16;
					ModBase.m_ObjectRule = true;
					IL_14E:
					num2 = 0x17;
					if (ModMain.MyMsgBox(Text + "\r\n\r\n是否反馈此问题？如果不反馈，这个问题可能永远无法得到解决！", Title, "反馈", "取消", "", false, true, false) != 1)
					{
						break;
					}
					IL_17A:
					num2 = 0x18;
					ModBase.Feedback("exlog", false, true);
					break;
				case ModBase.LogLevel.Assert:
				{
					IL_18B:
					num2 = 0x1A;
					ModBase.m_ObjectRule = true;
					IL_194:
					num2 = 0x1B;
					long timeTick = ModBase.GetTimeTick();
					IL_19E:
					num2 = 0x1C;
					if (Interaction.MsgBox(Text + "\r\n\r\n是否反馈此问题？如果不反馈，这个问题可能永远无法得到解决！", MsgBoxStyle.YesNo | MsgBoxStyle.Critical, Title) != MsgBoxResult.Yes)
					{
						goto IL_1C6;
					}
					IL_1B7:
					num2 = 0x1D;
					ModBase.Feedback("exlog", false, true);
					IL_1C6:
					num2 = 0x1E;
					if (checked(ModBase.GetTimeTick() - timeTick) >= 0x5DCL)
					{
						goto IL_200;
					}
					IL_1DC:
					num2 = 0x1F;
					ModBase.Log("[System] PCL 已崩溃：\r\n" + Text, ModBase.LogLevel.Normal, "出现错误");
					IL_1F5:
					num2 = 0x20;
					FormMain.EndProgramForce(ModBase.Result.Exception);
					break;
					IL_200:
					num2 = 0x22;
					FormMain.EndProgramForce(ModBase.Result.Fail);
					break;
				}
				}
				IL_209:
				goto IL_2EB;
				IL_20E:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_2AC:
				goto IL_2E0;
				IL_2AE:
				num4 = num2;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_2BE:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_2AE;
			}
			IL_2E0:
			throw ProjectData.CreateProjectError(-0x7FF5FFCD);
			IL_2EB:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x0600126B RID: 4715 RVA: 0x000881AC File Offset: 0x000863AC
		public static void Log(Exception Ex, string Desc, ModBase.LogLevel Level = ModBase.LogLevel.Debug, string Title = "出现错误")
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_00:
				ProjectData.ClearProjectError();
				num = 1;
				IL_07:
				int num2 = 2;
				ModBase.m_ObjectRule = true;
				IL_0F:
				num2 = 3;
				string text = Desc + "：" + ModBase.GetString(Ex, false, false);
				IL_25:
				num2 = 4;
				string value = string.Concat(new string[]
				{
					"[",
					ModBase.GetTimeNow(),
					"] ",
					Desc,
					"：",
					ModBase.GetString(Ex, false, true),
					"\r\n"
				});
				IL_6B:
				num2 = 5;
				if (!ModBase.errorRule)
				{
					goto IL_AB;
				}
				IL_74:
				num2 = 6;
				object indexerRule = ModBase._IndexerRule;
				ObjectFlowControl.CheckForSyncLockOnValueType(indexerRule);
				lock (indexerRule)
				{
					ModBase._CallbackRule.Append(value);
					goto IL_BA;
				}
				IL_AB:
				num2 = 8;
				ModBase._CallbackRule.Append(value);
				IL_BA:
				num2 = 9;
				if (ModBase._AlgoRule)
				{
					goto IL_232;
				}
				IL_C7:
				num2 = 0xB;
				switch (Level)
				{
				case ModBase.LogLevel.Debug:
				{
					IL_F5:
					num2 = 0xF;
					string str = Desc + "：" + ModBase.GetString(Ex, true, false);
					IL_10D:
					num2 = 0x10;
					if (!ModBase.errorRule)
					{
						break;
					}
					IL_11A:
					num2 = 0x11;
					ModMain.Hint("[调试模式] " + str, ModMain.HintType.Info, false);
					break;
				}
				case ModBase.LogLevel.Hint:
				{
					IL_135:
					num2 = 0x13;
					string text2 = Desc + "：" + ModBase.GetString(Ex, true, false);
					IL_14D:
					num2 = 0x14;
					ModMain.Hint(text2, ModMain.HintType.Critical, false);
					break;
				}
				case ModBase.LogLevel.Msgbox:
					IL_15E:
					num2 = 0x16;
					ModMain.MyMsgBox(text, Title, "确定", "", "", false, true, false);
					break;
				case ModBase.LogLevel.Feedback:
					IL_180:
					num2 = 0x18;
					if (ModMain.MyMsgBox(text + "\r\n\r\n是否反馈此问题？如果不反馈，这个问题可能永远无法得到解决！", Title, "反馈", "取消", "", false, true, false) != 1)
					{
						break;
					}
					IL_1AC:
					num2 = 0x19;
					ModBase.Feedback("exlog", false, true);
					break;
				case ModBase.LogLevel.Assert:
				{
					IL_1BD:
					num2 = 0x1B;
					long timeTick = ModBase.GetTimeTick();
					IL_1C7:
					num2 = 0x1C;
					if (Interaction.MsgBox(text + "\r\n\r\n是否反馈此问题？如果不反馈，这个问题可能永远无法得到解决！", MsgBoxStyle.YesNo | MsgBoxStyle.Critical, Title) != MsgBoxResult.Yes)
					{
						goto IL_1EF;
					}
					IL_1E0:
					num2 = 0x1D;
					ModBase.Feedback("exlog", false, true);
					IL_1EF:
					num2 = 0x1E;
					if (checked(ModBase.GetTimeTick() - timeTick) >= 0x5DCL)
					{
						goto IL_229;
					}
					IL_205:
					num2 = 0x1F;
					ModBase.Log("[System] PCL 已崩溃：\r\n" + text, ModBase.LogLevel.Normal, "出现错误");
					IL_21E:
					num2 = 0x20;
					FormMain.EndProgramForce(ModBase.Result.Exception);
					break;
					IL_229:
					num2 = 0x22;
					FormMain.EndProgramForce(ModBase.Result.Fail);
					break;
				}
				}
				IL_232:
				goto IL_314;
				IL_237:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_2D5:
				goto IL_309;
				IL_2D7:
				num4 = num2;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_2E7:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_2D7;
			}
			IL_309:
			throw ProjectData.CreateProjectError(-0x7FF5FFCD);
			IL_314:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x0600126C RID: 4716 RVA: 0x0008850C File Offset: 0x0008670C
		public static void Feedback(string Source, bool ShowMsgbox = true, bool ForceOpenLog = false)
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_00:
				ProjectData.ClearProjectError();
				num = 1;
				IL_07:
				int num2 = 2;
				ModBase.FeedbackInfo();
				IL_0E:
				num2 = 3;
				if (!ForceOpenLog && (!ShowMsgbox || ModMain.MyMsgBox("若你在汇报一个 Bug，请点击 打开文件夹 按钮，并上传 Log(1~5).txt 中包含错误信息的文件。\r\n游戏崩溃一般与启动器无关，请不要因为游戏崩溃而提交反馈。", "反馈提交提醒", "打开文件夹", "不需要", "", false, true, false) != 1))
				{
					goto IL_55;
				}
				IL_3A:
				num2 = 4;
				ModBase.OpenExplorer("\"" + ModBase.Path + "PCL\\\"");
				IL_55:
				num2 = 5;
				ModBase.OpenWebsite("https://jinshuju.net/f/rP4b6E?x_field_1=" + Source);
				IL_67:
				num2 = 6;
				if (!Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("HintFeedback", null), "", true))
				{
					goto IL_9E;
				}
				IL_86:
				num2 = 7;
				ModBase._BaseRule.Set("HintFeedback", "/", false, null);
				IL_9E:
				goto IL_10D;
				IL_A0:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_CE:
				goto IL_102;
				IL_D0:
				num4 = num2;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_E0:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_D0;
			}
			IL_102:
			throw ProjectData.CreateProjectError(-0x7FF5FFCD);
			IL_10D:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x0600126D RID: 4717 RVA: 0x00088640 File Offset: 0x00086840
		public static void FeedbackInfo()
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_00:
				ProjectData.ClearProjectError();
				num = 1;
				IL_07:
				int num2 = 2;
				ModBase.Log(string.Concat(new string[]
				{
					"[System] 诊断信息：\r\n操作系统：",
					MyWpfExtension.RunFactory().Info.OSFullName,
					"\r\n剩余内存：",
					Conversions.ToString(Conversion.Int(MyWpfExtension.RunFactory().Info.AvailablePhysicalMemory / 1024.0 / 1024.0)),
					" M / ",
					Conversions.ToString(Conversion.Int(MyWpfExtension.RunFactory().Info.TotalPhysicalMemory / 1024.0 / 1024.0)),
					" M\r\nDPI：",
					Conversions.ToString(ModBase._BridgeRule),
					"（",
					Conversions.ToString(Math.Round((double)ModBase._BridgeRule / 96.0, 2) * 100.0),
					"%）\r\n文件位置：",
					ModBase.Path
				}), ModBase.LogLevel.Normal, "出现错误");
				IL_106:
				goto IL_161;
				IL_108:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_122:
				goto IL_156;
				IL_124:
				num4 = num2;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_134:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_124;
			}
			IL_156:
			throw ProjectData.CreateProjectError(-0x7FF5FFCD);
			IL_161:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x0600126E RID: 4718 RVA: 0x0000B93F File Offset: 0x00009B3F
		public static void DebugAssert(bool Exp)
		{
			if (!Exp)
			{
				throw new Exception("断言命中");
			}
		}

		// Token: 0x0600126F RID: 4719 RVA: 0x0000B94F File Offset: 0x00009B4F
		public static object RandomOne(Array objects)
		{
			return objects.GetValue(ModBase.RandomInteger(0, checked(objects.Length - 1)));
		}

		// Token: 0x06001270 RID: 4720 RVA: 0x0000B965 File Offset: 0x00009B65
		public static object RandomOne(IList objects)
		{
			return objects[ModBase.RandomInteger(0, checked(objects.Count - 1))];
		}

		// Token: 0x06001271 RID: 4721 RVA: 0x0000B97B File Offset: 0x00009B7B
		public static int RandomInteger(int min, int max)
		{
			return checked((int)Math.Round(unchecked(Math.Floor((double)(checked(max - min + 1)) * ModBase.methodRule.NextDouble()) + (double)min)));
		}

		// Token: 0x06001272 RID: 4722 RVA: 0x000887D4 File Offset: 0x000869D4
		public static IList<T> RandomChaos<T>(IList<T> array)
		{
			IList<T> list = new List<T>();
			while (array.Count > 0)
			{
				int index = ModBase.RandomInteger(0, checked(array.Count - 1));
				list.Add(array[index]);
				array.RemoveAt(index);
			}
			return list;
		}

		// Token: 0x040009C6 RID: 2502
		public static IntPtr m_IteratorRule;

		// Token: 0x040009C7 RID: 2503
		public static string Path;

		// Token: 0x040009C8 RID: 2504
		public static string m_ExpressionRule;

		// Token: 0x040009C9 RID: 2505
		public static string m_UtilsRule;

		// Token: 0x040009CA RID: 2506
		public static ModSetup _BaseRule;

		// Token: 0x040009CB RID: 2507
		public static long decoratorRule;

		// Token: 0x040009CC RID: 2508
		public static DateTime _FilterRule;

		// Token: 0x040009CD RID: 2509
		public static string ruleRule;

		// Token: 0x040009CE RID: 2510
		public static bool _AlgoRule;

		// Token: 0x040009CF RID: 2511
		public static bool m_MapperRule;

		// Token: 0x040009D0 RID: 2512
		public static Version _ParamsRule;

		// Token: 0x040009D1 RID: 2513
		public static string m_GlobalRule;

		// Token: 0x040009D2 RID: 2514
		private static readonly Dictionary<string, ModBase.IniCache> m_IssuerRule;

		// Token: 0x040009D3 RID: 2515
		public static char orderRule;

		// Token: 0x040009D4 RID: 2516
		public static char m_ServiceRule;

		// Token: 0x040009D5 RID: 2517
		public static string _FacadeRule;

		// Token: 0x040009D6 RID: 2518
		private static int _CodeRule;

		// Token: 0x040009D7 RID: 2519
		private static object mappingRule;

		// Token: 0x040009D8 RID: 2520
		public static readonly int _BridgeRule;

		// Token: 0x040009D9 RID: 2521
		private static readonly int m_SingletonRule;

		// Token: 0x040009DA RID: 2522
		public static bool errorRule;

		// Token: 0x040009DB RID: 2523
		public static bool m_ObjectRule;

		// Token: 0x040009DC RID: 2524
		private static StringBuilder _CallbackRule;

		// Token: 0x040009DD RID: 2525
		private static StreamWriter _WorkerRule;

		// Token: 0x040009DE RID: 2526
		private static readonly object m_VisitorRule;

		// Token: 0x040009DF RID: 2527
		private static readonly object _IndexerRule;

		// Token: 0x040009E0 RID: 2528
		private static readonly Random methodRule;

		// Token: 0x0200019E RID: 414
		public class Logo
		{
		}

		// Token: 0x0200019F RID: 415
		public class MyColor
		{
			// Token: 0x06001274 RID: 4724 RVA: 0x0000B99C File Offset: 0x00009B9C
			public static implicit operator ModBase.MyColor(string str)
			{
				return new ModBase.MyColor(str);
			}

			// Token: 0x06001275 RID: 4725 RVA: 0x0000B9A4 File Offset: 0x00009BA4
			public static implicit operator ModBase.MyColor(System.Windows.Media.Color col)
			{
				return new ModBase.MyColor(col);
			}

			// Token: 0x06001276 RID: 4726 RVA: 0x0000B9AC File Offset: 0x00009BAC
			public static implicit operator System.Windows.Media.Color(ModBase.MyColor conv)
			{
				return System.Windows.Media.Color.FromArgb(ModBase.MathByte(conv.creatorMapper), ModBase.MathByte(conv._PageMapper), ModBase.MathByte(conv.instanceMapper), ModBase.MathByte(conv.testMapper));
			}

			// Token: 0x06001277 RID: 4727 RVA: 0x0000B9DF File Offset: 0x00009BDF
			public static implicit operator System.Drawing.Color(ModBase.MyColor conv)
			{
				return System.Drawing.Color.FromArgb((int)ModBase.MathByte(conv.creatorMapper), (int)ModBase.MathByte(conv._PageMapper), (int)ModBase.MathByte(conv.instanceMapper), (int)ModBase.MathByte(conv.testMapper));
			}

			// Token: 0x06001278 RID: 4728 RVA: 0x0000BA12 File Offset: 0x00009C12
			public static implicit operator ModBase.MyColor(SolidColorBrush bru)
			{
				return new ModBase.MyColor(bru.Color);
			}

			// Token: 0x06001279 RID: 4729 RVA: 0x0000BA1F File Offset: 0x00009C1F
			public static implicit operator SolidColorBrush(ModBase.MyColor conv)
			{
				return new SolidColorBrush(System.Windows.Media.Color.FromArgb(ModBase.MathByte(conv.creatorMapper), ModBase.MathByte(conv._PageMapper), ModBase.MathByte(conv.instanceMapper), ModBase.MathByte(conv.testMapper)));
			}

			// Token: 0x0600127A RID: 4730 RVA: 0x0000BA57 File Offset: 0x00009C57
			public static implicit operator ModBase.MyColor(System.Windows.Media.Brush bru)
			{
				return new ModBase.MyColor(bru);
			}

			// Token: 0x0600127B RID: 4731 RVA: 0x0000BA1F File Offset: 0x00009C1F
			public static implicit operator System.Windows.Media.Brush(ModBase.MyColor conv)
			{
				return new SolidColorBrush(System.Windows.Media.Color.FromArgb(ModBase.MathByte(conv.creatorMapper), ModBase.MathByte(conv._PageMapper), ModBase.MathByte(conv.instanceMapper), ModBase.MathByte(conv.testMapper)));
			}

			// Token: 0x0600127C RID: 4732 RVA: 0x00088818 File Offset: 0x00086A18
			public static ModBase.MyColor operator +(ModBase.MyColor a, ModBase.MyColor b)
			{
				return new ModBase.MyColor
				{
					creatorMapper = a.creatorMapper + b.creatorMapper,
					testMapper = a.testMapper + b.testMapper,
					instanceMapper = a.instanceMapper + b.instanceMapper,
					_PageMapper = a._PageMapper + b._PageMapper
				};
			}

			// Token: 0x0600127D RID: 4733 RVA: 0x00088878 File Offset: 0x00086A78
			public static ModBase.MyColor operator -(ModBase.MyColor a, ModBase.MyColor b)
			{
				return new ModBase.MyColor
				{
					creatorMapper = a.creatorMapper - b.creatorMapper,
					testMapper = a.testMapper - b.testMapper,
					instanceMapper = a.instanceMapper - b.instanceMapper,
					_PageMapper = a._PageMapper - b._PageMapper
				};
			}

			// Token: 0x0600127E RID: 4734 RVA: 0x0000BA5F File Offset: 0x00009C5F
			public static ModBase.MyColor operator *(ModBase.MyColor a, double b)
			{
				return new ModBase.MyColor
				{
					creatorMapper = a.creatorMapper * b,
					testMapper = a.testMapper * b,
					instanceMapper = a.instanceMapper * b,
					_PageMapper = a._PageMapper * b
				};
			}

			// Token: 0x0600127F RID: 4735 RVA: 0x0000BA9E File Offset: 0x00009C9E
			public static ModBase.MyColor operator /(ModBase.MyColor a, double b)
			{
				return new ModBase.MyColor
				{
					creatorMapper = a.creatorMapper / b,
					testMapper = a.testMapper / b,
					instanceMapper = a.instanceMapper / b,
					_PageMapper = a._PageMapper / b
				};
			}

			// Token: 0x06001280 RID: 4736 RVA: 0x000888D8 File Offset: 0x00086AD8
			public static bool operator ==(ModBase.MyColor a, ModBase.MyColor b)
			{
				return (Information.IsNothing(a) && Information.IsNothing(b)) || (!Information.IsNothing(a) && !Information.IsNothing(b) && (a.creatorMapper == b.creatorMapper && a._PageMapper == b._PageMapper && a.instanceMapper == b.instanceMapper) && a.testMapper == b.testMapper);
			}

			// Token: 0x06001281 RID: 4737 RVA: 0x0008894C File Offset: 0x00086B4C
			public static bool operator !=(ModBase.MyColor a, ModBase.MyColor b)
			{
				return (!Information.IsNothing(a) || !Information.IsNothing(b)) && (Information.IsNothing(a) || Information.IsNothing(b) || a.creatorMapper != b.creatorMapper || a._PageMapper != b._PageMapper || a.instanceMapper != b.instanceMapper || a.testMapper != b.testMapper);
			}

			// Token: 0x06001282 RID: 4738 RVA: 0x000889C4 File Offset: 0x00086BC4
			public MyColor()
			{
				this.creatorMapper = 255.0;
				this._PageMapper = 0.0;
				this.instanceMapper = 0.0;
				this.testMapper = 0.0;
			}

			// Token: 0x06001283 RID: 4739 RVA: 0x00088A14 File Offset: 0x00086C14
			public MyColor(System.Windows.Media.Color col)
			{
				this.creatorMapper = 255.0;
				this._PageMapper = 0.0;
				this.instanceMapper = 0.0;
				this.testMapper = 0.0;
				this.creatorMapper = (double)col.A;
				this._PageMapper = (double)col.R;
				this.instanceMapper = (double)col.G;
				this.testMapper = (double)col.B;
			}

			// Token: 0x06001284 RID: 4740 RVA: 0x00088A9C File Offset: 0x00086C9C
			public MyColor(string HexString)
			{
				this.creatorMapper = 255.0;
				this._PageMapper = 0.0;
				this.instanceMapper = 0.0;
				this.testMapper = 0.0;
				object obj = System.Windows.Media.ColorConverter.ConvertFromString(HexString);
				System.Windows.Media.Color color = (obj != null) ? ((System.Windows.Media.Color)obj) : default(System.Windows.Media.Color);
				this.creatorMapper = (double)color.A;
				this._PageMapper = (double)color.R;
				this.instanceMapper = (double)color.G;
				this.testMapper = (double)color.B;
			}

			// Token: 0x06001285 RID: 4741 RVA: 0x00088B40 File Offset: 0x00086D40
			public MyColor(double newA, ModBase.MyColor col)
			{
				this.creatorMapper = 255.0;
				this._PageMapper = 0.0;
				this.instanceMapper = 0.0;
				this.testMapper = 0.0;
				this.creatorMapper = newA;
				this._PageMapper = col._PageMapper;
				this.instanceMapper = col.instanceMapper;
				this.testMapper = col.testMapper;
			}

			// Token: 0x06001286 RID: 4742 RVA: 0x00088BBC File Offset: 0x00086DBC
			public MyColor(double newR, double newG, double newB)
			{
				this.creatorMapper = 255.0;
				this._PageMapper = 0.0;
				this.instanceMapper = 0.0;
				this.testMapper = 0.0;
				this.creatorMapper = 255.0;
				this._PageMapper = newR;
				this.instanceMapper = newG;
				this.testMapper = newB;
			}

			// Token: 0x06001287 RID: 4743 RVA: 0x00088C30 File Offset: 0x00086E30
			public MyColor(double newA, double newR, double newG, double newB)
			{
				this.creatorMapper = 255.0;
				this._PageMapper = 0.0;
				this.instanceMapper = 0.0;
				this.testMapper = 0.0;
				this.creatorMapper = newA;
				this._PageMapper = newR;
				this.instanceMapper = newG;
				this.testMapper = newB;
			}

			// Token: 0x06001288 RID: 4744 RVA: 0x00088C9C File Offset: 0x00086E9C
			public MyColor(System.Windows.Media.Brush brush)
			{
				this.creatorMapper = 255.0;
				this._PageMapper = 0.0;
				this.instanceMapper = 0.0;
				this.testMapper = 0.0;
				System.Windows.Media.Color color = ((SolidColorBrush)brush).Color;
				this.creatorMapper = (double)color.A;
				this._PageMapper = (double)color.R;
				this.instanceMapper = (double)color.G;
				this.testMapper = (double)color.B;
			}

			// Token: 0x06001289 RID: 4745 RVA: 0x00088D30 File Offset: 0x00086F30
			public MyColor(SolidColorBrush brush)
			{
				this.creatorMapper = 255.0;
				this._PageMapper = 0.0;
				this.instanceMapper = 0.0;
				this.testMapper = 0.0;
				System.Windows.Media.Color color = brush.Color;
				this.creatorMapper = (double)color.A;
				this._PageMapper = (double)color.R;
				this.instanceMapper = (double)color.G;
				this.testMapper = (double)color.B;
			}

			// Token: 0x0600128A RID: 4746 RVA: 0x00088DC0 File Offset: 0x00086FC0
			public MyColor(object obj)
			{
				this.creatorMapper = 255.0;
				this._PageMapper = 0.0;
				this.instanceMapper = 0.0;
				this.testMapper = 0.0;
				if (obj == null)
				{
					this.creatorMapper = 255.0;
					this._PageMapper = 255.0;
					this.instanceMapper = 255.0;
					this.testMapper = 255.0;
					return;
				}
				if (obj.GetType().Equals(typeof(SolidColorBrush)))
				{
					object obj2 = NewLateBinding.LateGet(obj, null, "Color", new object[0], null, null, null);
					System.Windows.Media.Color color = (obj2 != null) ? ((System.Windows.Media.Color)obj2) : default(System.Windows.Media.Color);
					this.creatorMapper = (double)color.A;
					this._PageMapper = (double)color.R;
					this.instanceMapper = (double)color.G;
					this.testMapper = (double)color.B;
					return;
				}
				this.creatorMapper = Conversions.ToDouble(NewLateBinding.LateGet(obj, null, "A", new object[0], null, null, null));
				this._PageMapper = Conversions.ToDouble(NewLateBinding.LateGet(obj, null, "R", new object[0], null, null, null));
				this.instanceMapper = Conversions.ToDouble(NewLateBinding.LateGet(obj, null, "G", new object[0], null, null, null));
				this.testMapper = Conversions.ToDouble(NewLateBinding.LateGet(obj, null, "B", new object[0], null, null, null));
			}

			// Token: 0x0600128B RID: 4747 RVA: 0x00088F4C File Offset: 0x0008714C
			public double Hue(double v1, double v2, double vH)
			{
				if (vH < 0.0)
				{
					vH += 1.0;
				}
				if (vH > 1.0)
				{
					vH -= 1.0;
				}
				double result;
				if (vH < 0.16667)
				{
					result = v1 + (v2 - v1) * 6.0 * vH;
				}
				else if (vH < 0.5)
				{
					result = v2;
				}
				else if (vH < 0.66667)
				{
					result = v1 + (v2 - v1) * (4.0 - vH * 6.0);
				}
				else
				{
					result = v1;
				}
				return result;
			}

			// Token: 0x0600128C RID: 4748 RVA: 0x00088FE8 File Offset: 0x000871E8
			public ModBase.MyColor FromHSL(double sH, double sS, double sL)
			{
				if (sS == 0.0)
				{
					this._PageMapper = sL * 2.55;
					this.instanceMapper = this._PageMapper;
					this.testMapper = this._PageMapper;
				}
				else
				{
					double num = sH / 360.0;
					double num2 = sS / 100.0;
					double num3 = sL / 100.0;
					num2 = ((num3 < 0.5) ? (num2 * num3 + num3) : (num2 * (1.0 - num3) + num3));
					num3 = 2.0 * num3 - num2;
					this._PageMapper = 255.0 * this.Hue(num3, num2, num + 0.33333333333333331);
					this.instanceMapper = 255.0 * this.Hue(num3, num2, num);
					this.testMapper = 255.0 * this.Hue(num3, num2, num - 0.33333333333333331);
				}
				this.creatorMapper = 255.0;
				return this;
			}

			// Token: 0x0600128D RID: 4749 RVA: 0x000890F4 File Offset: 0x000872F4
			public ModBase.MyColor FromHSL2(double sH, double sS, double sL)
			{
				if (sS == 0.0)
				{
					this._PageMapper = sL * 2.55;
					this.instanceMapper = this._PageMapper;
					this.testMapper = this._PageMapper;
				}
				else
				{
					sH = (sH + 3600000.0) % 360.0;
					double[] array = new double[]
					{
						0.1,
						-0.06,
						-0.3,
						-0.19,
						-0.15,
						-0.24,
						-0.32,
						-0.09,
						0.18,
						0.05,
						-0.12,
						-0.02,
						0.1,
						-0.06
					};
					double num = sH / 30.0;
					int num2 = checked((int)Math.Floor(num));
					num = 50.0 - ((1.0 - num + (double)num2) * array[num2] + (num - (double)num2) * array[checked(num2 + 1)]) * sS;
					sL = ((sL < num) ? (sL / num) : (1.0 + (sL - num) / (100.0 - num))) * 50.0;
					this.FromHSL(sH, sS, sL);
				}
				this.creatorMapper = 255.0;
				return this;
			}

			// Token: 0x0600128E RID: 4750 RVA: 0x000891EC File Offset: 0x000873EC
			public override string ToString()
			{
				return string.Concat(new string[]
				{
					"(",
					Conversions.ToString(this.creatorMapper),
					",",
					Conversions.ToString(this._PageMapper),
					",",
					Conversions.ToString(this.instanceMapper),
					",",
					Conversions.ToString(this.testMapper),
					")"
				});
			}

			// Token: 0x0600128F RID: 4751 RVA: 0x0000BADD File Offset: 0x00009CDD
			public override bool Equals(object obj)
			{
				return this == (ModBase.MyColor)obj;
			}

			// Token: 0x040009E1 RID: 2529
			public double creatorMapper;

			// Token: 0x040009E2 RID: 2530
			public double _PageMapper;

			// Token: 0x040009E3 RID: 2531
			public double instanceMapper;

			// Token: 0x040009E4 RID: 2532
			public double testMapper;
		}

		// Token: 0x020001A0 RID: 416
		public class MyRect
		{
			// Token: 0x17000342 RID: 834
			// (get) Token: 0x06001290 RID: 4752 RVA: 0x0000BAEB File Offset: 0x00009CEB
			// (set) Token: 0x06001291 RID: 4753 RVA: 0x0000BAF3 File Offset: 0x00009CF3
			public double Width { get; set; }

			// Token: 0x17000343 RID: 835
			// (get) Token: 0x06001292 RID: 4754 RVA: 0x0000BAFC File Offset: 0x00009CFC
			// (set) Token: 0x06001293 RID: 4755 RVA: 0x0000BB04 File Offset: 0x00009D04
			public double Height { get; set; }

			// Token: 0x17000344 RID: 836
			// (get) Token: 0x06001294 RID: 4756 RVA: 0x0000BB0D File Offset: 0x00009D0D
			// (set) Token: 0x06001295 RID: 4757 RVA: 0x0000BB15 File Offset: 0x00009D15
			public double Left { get; set; }

			// Token: 0x17000345 RID: 837
			// (get) Token: 0x06001296 RID: 4758 RVA: 0x0000BB1E File Offset: 0x00009D1E
			// (set) Token: 0x06001297 RID: 4759 RVA: 0x0000BB26 File Offset: 0x00009D26
			public double Top { get; set; }

			// Token: 0x06001298 RID: 4760 RVA: 0x00089268 File Offset: 0x00087468
			public MyRect()
			{
				this.Width = 0.0;
				this.Height = 0.0;
				this.Left = 0.0;
				this.Top = 0.0;
			}

			// Token: 0x06001299 RID: 4761 RVA: 0x000892B8 File Offset: 0x000874B8
			public MyRect(double left, double top, double width, double height)
			{
				this.Width = 0.0;
				this.Height = 0.0;
				this.Left = 0.0;
				this.Top = 0.0;
				this.Left = left;
				this.Top = top;
				this.Width = width;
				this.Height = height;
			}

			// Token: 0x040009E5 RID: 2533
			[CompilerGenerated]
			private double customerMapper;

			// Token: 0x040009E6 RID: 2534
			[CompilerGenerated]
			private double taskMapper;

			// Token: 0x040009E7 RID: 2535
			[CompilerGenerated]
			private double m_AuthenticationMapper;

			// Token: 0x040009E8 RID: 2536
			[CompilerGenerated]
			private double _ProcessMapper;
		}

		// Token: 0x020001A1 RID: 417
		public enum LoadState
		{
			// Token: 0x040009EA RID: 2538
			Waiting,
			// Token: 0x040009EB RID: 2539
			Loading,
			// Token: 0x040009EC RID: 2540
			Finished,
			// Token: 0x040009ED RID: 2541
			Failed,
			// Token: 0x040009EE RID: 2542
			Aborted
		}

		// Token: 0x020001A2 RID: 418
		public enum Result
		{
			// Token: 0x040009F0 RID: 2544
			Aborted = -1,
			// Token: 0x040009F1 RID: 2545
			Success,
			// Token: 0x040009F2 RID: 2546
			Fail,
			// Token: 0x040009F3 RID: 2547
			Exception,
			// Token: 0x040009F4 RID: 2548
			Timeout,
			// Token: 0x040009F5 RID: 2549
			Cancel
		}

		// Token: 0x020001A3 RID: 419
		public class EqualableList<T> : List<T>
		{
			// Token: 0x0600129B RID: 4763 RVA: 0x00089324 File Offset: 0x00087524
			public override bool Equals(object obj)
			{
				checked
				{
					bool result;
					if (!(obj is List<T>))
					{
						result = false;
					}
					else
					{
						List<T> list = (List<T>)obj;
						if (list.Count != base.Count)
						{
							result = false;
						}
						else
						{
							int num = list.Count - 1;
							for (int i = 0; i <= num; i++)
							{
								T t = list[i];
								if (!t.Equals(base[i]))
								{
									return false;
								}
							}
							result = true;
						}
					}
					return result;
				}
			}

			// Token: 0x0600129C RID: 4764 RVA: 0x0000BB37 File Offset: 0x00009D37
			public static bool operator ==(ModBase.EqualableList<T> left, ModBase.EqualableList<T> right)
			{
				return EqualityComparer<ModBase.EqualableList<T>>.Default.Equals(left, right);
			}

			// Token: 0x0600129D RID: 4765 RVA: 0x0000BB45 File Offset: 0x00009D45
			public static bool operator !=(ModBase.EqualableList<T> left, ModBase.EqualableList<T> right)
			{
				return !(left == right);
			}
		}

		// Token: 0x020001A4 RID: 420
		private class IniCache
		{
			// Token: 0x0600129E RID: 4766 RVA: 0x0000BB51 File Offset: 0x00009D51
			public IniCache()
			{
				this.listenerMapper = "";
				this._ImporterMapper = new Dictionary<string, string>();
			}

			// Token: 0x040009F6 RID: 2550
			public string listenerMapper;

			// Token: 0x040009F7 RID: 2551
			public Dictionary<string, string> _ImporterMapper;
		}

		// Token: 0x020001A5 RID: 421
		public class FileChecker
		{
			// Token: 0x0600129F RID: 4767 RVA: 0x00089398 File Offset: 0x00087598
			public FileChecker(long MinSize = -1L, long ActualSize = -1L, string MD5 = null, string SHA1 = null, bool CanUseExistsFile = true, bool IsJson = false)
			{
				this.templateMapper = -1L;
				this._AdapterMapper = -1L;
				this.annotationMapper = null;
				this.readerMapper = null;
				this._RegMapper = true;
				this.m_DefinitionMapper = false;
				this.templateMapper = ActualSize;
				this._AdapterMapper = MinSize;
				this.annotationMapper = MD5;
				this.readerMapper = SHA1;
				this._RegMapper = CanUseExistsFile;
				this.m_DefinitionMapper = IsJson;
			}

			// Token: 0x060012A0 RID: 4768 RVA: 0x00089414 File Offset: 0x00087614
			public string Check(string LocalPath)
			{
				string result;
				try
				{
					FileInfo fileInfo = new FileInfo(LocalPath);
					if (!fileInfo.Exists)
					{
						result = "文件不存在：" + LocalPath;
					}
					else
					{
						long length = fileInfo.Length;
						if (this.templateMapper >= 0L && this.templateMapper != length)
						{
							result = string.Concat(new string[]
							{
								"文件大小应为 ",
								Conversions.ToString(this.templateMapper),
								" B，实际为 ",
								Conversions.ToString(length),
								" B"
							});
						}
						else if (this._AdapterMapper >= 0L && this._AdapterMapper > length)
						{
							result = string.Concat(new string[]
							{
								"文件大小应大于 ",
								Conversions.ToString(this._AdapterMapper),
								" B，实际为 ",
								Conversions.ToString(length),
								" B"
							});
						}
						else if (!string.IsNullOrEmpty(this.annotationMapper) && Operators.CompareString(this.annotationMapper, ModBase.smethod_0(LocalPath), true) != 0)
						{
							result = "文件 MD5 应为 " + this.annotationMapper + "，实际为 " + ModBase.smethod_0(LocalPath);
						}
						else if (!string.IsNullOrEmpty(this.readerMapper) && Operators.CompareString(this.readerMapper, ModBase.smethod_1(LocalPath), true) != 0)
						{
							result = "文件 SHA1 应为 " + this.readerMapper + "，实际为 " + ModBase.smethod_1(LocalPath);
						}
						else
						{
							if (this.m_DefinitionMapper)
							{
								string text = ModBase.ReadFile(LocalPath);
								if (Operators.CompareString(text, "", true) == 0)
								{
									throw new Exception("读取到的文件为空");
								}
								try
								{
									ModBase.GetJson(text);
								}
								catch (Exception innerException)
								{
									throw new Exception("不是有效的 Json 文件", innerException);
								}
							}
							result = null;
						}
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "检查文件出错", ModBase.LogLevel.Debug, "出现错误");
					result = ModBase.GetString(ex, true, false);
				}
				return result;
			}

			// Token: 0x040009F8 RID: 2552
			public long templateMapper;

			// Token: 0x040009F9 RID: 2553
			public long _AdapterMapper;

			// Token: 0x040009FA RID: 2554
			public string annotationMapper;

			// Token: 0x040009FB RID: 2555
			public string readerMapper;

			// Token: 0x040009FC RID: 2556
			public bool _RegMapper;

			// Token: 0x040009FD RID: 2557
			public bool m_DefinitionMapper;
		}

		// Token: 0x020001A6 RID: 422
		public class SearchEntry<T>
		{
			// Token: 0x040009FE RID: 2558
			public T m_ParamMapper;

			// Token: 0x040009FF RID: 2559
			public List<KeyValuePair<string, double>> mockMapper;

			// Token: 0x04000A00 RID: 2560
			public double specificationMapper;

			// Token: 0x04000A01 RID: 2561
			public bool m_DicMapper;
		}

		// Token: 0x020001A7 RID: 423
		// (Invoke) Token: 0x060012A5 RID: 4773
		public delegate void EventDelegate(object sender, EventArgs e);

		// Token: 0x020001A8 RID: 424
		public sealed class RouteEventArgs : EventArgs
		{
			// Token: 0x060012A6 RID: 4774 RVA: 0x0000BB6F File Offset: 0x00009D6F
			public RouteEventArgs(bool RaiseByMouse = false)
			{
				this._HelperMapper = false;
				this.schemaMapper = RaiseByMouse;
			}

			// Token: 0x04000A02 RID: 2562
			public bool schemaMapper;

			// Token: 0x04000A03 RID: 2563
			public bool _HelperMapper;
		}

		// Token: 0x020001A9 RID: 425
		// (Invoke) Token: 0x060012AA RID: 4778
		public delegate bool CompareThreadStart(object Left, object Right);

		// Token: 0x020001AA RID: 426
		public enum LogLevel
		{
			// Token: 0x04000A05 RID: 2565
			Normal,
			// Token: 0x04000A06 RID: 2566
			Developer,
			// Token: 0x04000A07 RID: 2567
			Debug,
			// Token: 0x04000A08 RID: 2568
			Hint,
			// Token: 0x04000A09 RID: 2569
			Msgbox,
			// Token: 0x04000A0A RID: 2570
			Feedback,
			// Token: 0x04000A0B RID: 2571
			Assert
		}
	}
}
