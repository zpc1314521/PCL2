using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;

namespace PCL
{
	// Token: 0x02000160 RID: 352
	public partial class Application : Application
	{
		// Token: 0x06000F47 RID: 3911 RVA: 0x00009F28 File Offset: 0x00008128
		// Note: this type is marked as 'beforefieldinit'.
		static Application()
		{
			Application._QueueBase = RuntimeHelpers.GetObjectValue(new object());
			Application.producerBase = RuntimeHelpers.GetObjectValue(new object());
			Application._ExceptionBase = RuntimeHelpers.GetObjectValue(new object());
		}

		// Token: 0x06000F48 RID: 3912 RVA: 0x00071A1C File Offset: 0x0006FC1C
		public Application()
		{
			base.Startup += this.Application_Startup;
			base.SessionEnding += this.Application_SessionEnding;
			base.DispatcherUnhandledException += this.Application_DispatcherUnhandledException;
			this.dicBase = false;
		}

		// Token: 0x06000F49 RID: 3913 RVA: 0x00071A6C File Offset: 0x0006FC6C
		private void Application_Startup(object sender, System.Windows.StartupEventArgs e)
		{
			object[] object_ = new object[]
			{
				this,
				sender,
				e
			};
			new GClass18().method_112(object_, 0xAECA6);
		}

		// Token: 0x06000F4A RID: 3914 RVA: 0x00003B77 File Offset: 0x00001D77
		private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
		{
			ModMain.m_GetterFilter.EndProgram(false);
		}

		// Token: 0x06000F4B RID: 3915 RVA: 0x00071AA4 File Offset: 0x0006FCA4
		private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
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
				e.Handled = true;
				IL_10:
				num2 = 3;
				if (ModBase._AlgoRule)
				{
					goto IL_C5;
				}
				IL_1C:
				num2 = 5;
				if (!this.dicBase)
				{
					goto IL_33;
				}
				IL_26:
				num2 = 6;
				FormMain.EndProgramForce(ModBase.Result.Exception);
				goto IL_C5;
				IL_33:
				num2 = 8;
				this.dicBase = true;
				IL_3C:
				num2 = 9;
				string @string = ModBase.GetString(e.Exception, false, true);
				IL_4D:
				num2 = 0xA;
				if (@string.Contains("System.Windows.Threading.Dispatcher.Invoke") || @string.Contains("MS.Internal.AppModel.ITaskbarList.HrInit") || @string.Contains("未能加载文件或程序集"))
				{
					goto IL_9A;
				}
				IL_77:
				num2 = 0xF;
				ModBase.FeedbackInfo();
				IL_7F:
				num2 = 0x10;
				ModBase.Log(e.Exception, "程序出现未知错误", ModBase.LogLevel.Assert, "锟斤拷烫烫烫");
				goto IL_C5;
				IL_9A:
				num2 = 0xB;
				ModBase.OpenWebsite("https://www.microsoft.com/zh-CN/download/details.aspx?id=30653");
				IL_A7:
				num2 = 0xC;
				Interaction.MsgBox("你的 .Net Framework 版本过低或损坏，请在打开的网页中重新下载并安装 .Net Framework 4.5 后重试！", MsgBoxStyle.Information, "运行环境错误");
				IL_BC:
				num2 = 0xD;
				FormMain.EndProgramForce(ModBase.Result.Cancel);
				IL_C5:
				goto IL_15B;
				IL_CA:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_11C:
				goto IL_150;
				IL_11E:
				num4 = num2;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_12E:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_11E;
			}
			IL_150:
			throw ProjectData.CreateProjectError(-0x7FF5FFCD);
			IL_15B:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x06000F4C RID: 3916 RVA: 0x00071C30 File Offset: 0x0006FE30
		public static Assembly AssemblyResolve(object sender, ResolveEventArgs args)
		{
			if (args.Name.StartsWith("NAudio"))
			{
				object queueBase = Application._QueueBase;
				ObjectFlowControl.CheckForSyncLockOnValueType(queueBase);
				lock (queueBase)
				{
					if (Application.schemaBase == null)
					{
						ModBase.Log("[Start] 加载 DLL：NAudio", ModBase.LogLevel.Normal, "出现错误");
						Application.schemaBase = Assembly.Load(ModBase.GetResources("NAudio"));
					}
					return Application.schemaBase;
				}
			}
			if (args.Name.StartsWith("Newtonsoft.Json"))
			{
				object obj = Application.producerBase;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				lock (obj)
				{
					if (Application.m_HelperBase == null)
					{
						ModBase.Log("[Start] 加载 DLL：Json", ModBase.LogLevel.Normal, "出现错误");
						Application.m_HelperBase = Assembly.Load(ModBase.GetResources("Json"));
					}
					return Application.m_HelperBase;
				}
			}
			if (args.Name.StartsWith("Ookii.Dialogs.Wpf"))
			{
				object exceptionBase = Application._ExceptionBase;
				ObjectFlowControl.CheckForSyncLockOnValueType(exceptionBase);
				lock (exceptionBase)
				{
					if (Application.m_ConsumerBase == null)
					{
						ModBase.Log("[Start] 加载 DLL：Dialogs", ModBase.LogLevel.Normal, "出现错误");
						Application.m_ConsumerBase = Assembly.Load(ModBase.GetResources("Dialogs"));
					}
					return Application.m_ConsumerBase;
				}
			}
			return null;
		}

		// Token: 0x06000F4D RID: 3917 RVA: 0x00071DA4 File Offset: 0x0006FFA4
		private void MyIconButton_Click(object sender, EventArgs e)
		{
			if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LoginType", null), ModLaunch.McLoginType.Legacy, true))
			{
				ArrayList arrayList = new ArrayList();
				arrayList.AddRange(ModBase._BaseRule.Get("LoginLegacyName", null).ToString().Split(new char[]
				{
					'¨'
				}));
				arrayList.Remove(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null)));
				ModBase._BaseRule.Set("LoginLegacyName", ModBase.Join(arrayList.ToArray(), "¨"), false, null);
				ModMain.m_MockFilter.ComboName.ItemsSource = arrayList;
				ModMain.m_MockFilter.ComboName.Text = Conversions.ToString((arrayList.Count > 0) ? arrayList[0] : "");
				return;
			}
			string stringFromEnum = ModBase.GetStringFromEnum((Enum)ModBase._BaseRule.Get("LoginType", null));
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			ArrayList arrayList2 = new ArrayList();
			ArrayList arrayList3 = new ArrayList();
			if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase._BaseRule.Get("Login" + stringFromEnum + "Email", null), "", true))))
			{
				arrayList2.AddRange(ModBase._BaseRule.Get("Login" + stringFromEnum + "Email", null).ToString().Split(new char[]
				{
					'¨'
				}));
			}
			if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase._BaseRule.Get("Login" + stringFromEnum + "Pass", null), "", true))))
			{
				arrayList3.AddRange(ModBase._BaseRule.Get("Login" + stringFromEnum + "Pass", null).ToString().Split(new char[]
				{
					'¨'
				}));
			}
			checked
			{
				int num = arrayList2.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dictionary.Add(Conversions.ToString(arrayList2[i]), Conversions.ToString(arrayList3[i]));
				}
				dictionary.Remove(Conversions.ToString(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null)));
				ModBase._BaseRule.Set("Login" + stringFromEnum + "Email", ModBase.Join(dictionary.Keys.ToArray<string>(), "¨"), false, null);
				ModBase._BaseRule.Set("Login" + stringFromEnum + "Pass", ModBase.Join(dictionary.Values.ToArray<string>(), "¨"), false, null);
				string left = stringFromEnum;
				if (Operators.CompareString(left, "Mojang", true) == 0)
				{
					ModMain.m_DefinitionFilter.ComboName.ItemsSource = dictionary.Keys;
					ModMain.m_DefinitionFilter.ComboName.Text = ((dictionary.Keys.Count > 0) ? dictionary.Keys.ElementAtOrDefault(0) : "");
					ModMain.m_DefinitionFilter.TextPass.Password = ((dictionary.Values.Count > 0) ? dictionary.Values.ElementAtOrDefault(0) : "");
					return;
				}
				if (Operators.CompareString(left, "Nide", true) == 0)
				{
					ModMain.m_SpecificationFilter.ComboName.ItemsSource = dictionary.Keys;
					ModMain.m_SpecificationFilter.ComboName.Text = ((dictionary.Keys.Count > 0) ? dictionary.Keys.ElementAtOrDefault(0) : "");
					ModMain.m_SpecificationFilter.TextPass.Password = ((dictionary.Values.Count > 0) ? dictionary.Values.ElementAtOrDefault(0) : "");
					return;
				}
				if (Operators.CompareString(left, "Auth", true) == 0)
				{
					ModMain._SchemaFilter.ComboName.ItemsSource = dictionary.Keys;
					ModMain._SchemaFilter.ComboName.Text = ((dictionary.Keys.Count > 0) ? dictionary.Keys.ElementAtOrDefault(0) : "");
					ModMain._SchemaFilter.TextPass.Password = ((dictionary.Values.Count > 0) ? dictionary.Values.ElementAtOrDefault(0) : "");
					return;
				}
				ModBase.DebugAssert(true);
			}
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06000F4E RID: 3918 RVA: 0x00009F57 File Offset: 0x00008157
		internal AssemblyInfo Info
		{
			[DebuggerHidden]
			get
			{
				return new AssemblyInfo(Assembly.GetExecutingAssembly());
			}
		}

		// Token: 0x04000808 RID: 2056
		private bool dicBase;

		// Token: 0x04000809 RID: 2057
		private static Assembly schemaBase;

		// Token: 0x0400080A RID: 2058
		private static Assembly m_HelperBase;

		// Token: 0x0400080B RID: 2059
		private static Assembly m_ConsumerBase;

		// Token: 0x0400080C RID: 2060
		private static readonly object _QueueBase;

		// Token: 0x0400080D RID: 2061
		private static readonly object producerBase;

		// Token: 0x0400080E RID: 2062
		private static readonly object _ExceptionBase;
	}
}
