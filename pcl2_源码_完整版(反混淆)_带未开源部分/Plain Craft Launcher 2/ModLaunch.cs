using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace PCL
{
	// Token: 0x020000EF RID: 239
	[StandardModule]
	public sealed class ModLaunch
	{
		// Token: 0x06000864 RID: 2148 RVA: 0x0004236C File Offset: 0x0004056C
		// Note: this type is marked as 'beforefieldinit'.
		static ModLaunch()
		{
			ModLaunch.m_ThreadIterator = new ModLoader.LoaderTask<string, object>("Loader Launch", new ModLoader.LoaderTask<string, object>.LoadDelegateSub(ModLaunch.McLaunchStart), null, ThreadPriority.Normal)
			{
				OnStateChanged = delegate(object a0)
				{
					ModLaunch.McLaunchState((ModLoader.LoaderTask<string, object>)a0);
				},
				ReloadTimeout = 1
			};
			ModLaunch._InfoIterator = new ModLoader.LoaderTask<ModLaunch.McLoginData, ModLaunch.McLoginResult>("登录", new ModLoader.LoaderTask<ModLaunch.McLoginData, ModLaunch.McLoginResult>.LoadDelegateSub(ModLaunch.McLoginStart), new ModLoader.LoaderTask<ModLaunch.McLoginData, ModLaunch.McLoginResult>.InputDelegateSub(ModLaunch.McLoginInput), ThreadPriority.BelowNormal)
			{
				ReloadTimeout = 0xEA60,
				ProgressWeight = 15.0,
				Block = false
			};
			ModLaunch.repositoryIterator = new ModLoader.LoaderTask<ModLaunch.McLoginServer, ModLaunch.McLoginResult>("Loader Login Mojang", new ModLoader.LoaderTask<ModLaunch.McLoginServer, ModLaunch.McLoginResult>.LoadDelegateSub(ModLaunch.McLoginServerStart), null, ThreadPriority.Normal)
			{
				ReloadTimeout = 0xEA60
			};
			ModLaunch.systemIterator = new ModLoader.LoaderTask<ModLaunch.McLoginMs, ModLaunch.McLoginResult>("Loader Login Ms", new ModLoader.LoaderTask<ModLaunch.McLoginMs, ModLaunch.McLoginResult>.LoadDelegateSub(ModLaunch.McLoginMsStart), null, ThreadPriority.Normal)
			{
				ReloadTimeout = 0x493E0
			};
			ModLaunch._ProccesorIterator = new ModLoader.LoaderTask<ModLaunch.McLoginLegacy, ModLaunch.McLoginResult>("Loader Login Legacy", new ModLoader.LoaderTask<ModLaunch.McLoginLegacy, ModLaunch.McLoginResult>.LoadDelegateSub(ModLaunch.McLoginLegacyStart), null, ThreadPriority.Normal);
			ModLaunch._PrototypeIterator = new ModLoader.LoaderTask<ModLaunch.McLoginServer, ModLaunch.McLoginResult>("Loader Login Nide", new ModLoader.LoaderTask<ModLaunch.McLoginServer, ModLaunch.McLoginResult>.LoadDelegateSub(ModLaunch.McLoginServerStart), null, ThreadPriority.Normal)
			{
				ReloadTimeout = 0xEA60
			};
			ModLaunch._RefIterator = new ModLoader.LoaderTask<ModLaunch.McLoginServer, ModLaunch.McLoginResult>("Loader Login Auth", new ModLoader.LoaderTask<ModLaunch.McLoginServer, ModLaunch.McLoginResult>.LoadDelegateSub(ModLaunch.McLoginServerStart), null, ThreadPriority.Normal)
			{
				ReloadTimeout = 0xEA60
			};
			ModLaunch.parameterIterator = null;
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x000424C0 File Offset: 0x000406C0
		public static void McLaunchLog(string Text)
		{
			ModBase.RunInUi(delegate()
			{
				TextBlock labLog;
				(labLog = ModMain.m_CandidateFilter.LabLog).Text = string.Concat(new string[]
				{
					labLog.Text,
					"\r\n[",
					ModBase.GetTimeNow(),
					"] ",
					Text
				});
			}, false);
			ModBase.Log("[Launch] " + Text, ModBase.LogLevel.Normal, "出现错误");
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x00042508 File Offset: 0x00040708
		private static void McLaunchState(ModLoader.LoaderTask<string, object> Loader)
		{
			switch (ModLaunch.m_ThreadIterator.State)
			{
			case ModBase.LoadState.Waiting:
			case ModBase.LoadState.Finished:
			case ModBase.LoadState.Failed:
			case ModBase.LoadState.Aborted:
				ModMain.m_InvocationFilter.PageChangeToLogin();
				return;
			case ModBase.LoadState.Loading:
				ModMain.m_CandidateFilter.LabLog.Text = "";
				return;
			default:
				return;
			}
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x0004255C File Offset: 0x0004075C
		private static void McLaunchStart(ModLoader.LoaderTask<string, object> Loader)
		{
			ModLaunch._Closure$__7-0 CS$<>8__locals1 = new ModLaunch._Closure$__7-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_Loader = Loader;
			ModBase.RunInUiWait(new ThreadStart(ModMain.m_InvocationFilter.PageChangeToLaunching));
			try
			{
				ModLaunch.McLaunchPrecheck();
				ModLaunch.McLaunchLog("预检测已通过");
			}
			catch (Exception ex)
			{
				ModMain.Hint(ex.Message, ModMain.HintType.Critical, true);
				throw;
			}
			try
			{
				ModLaunch._InfoIterator.State = ModBase.LoadState.Waiting;
				ModLoader.LoaderCombo<string> value = new ModLoader.LoaderCombo<string>("补全文件", ModDownload.DlClientFix(ModMinecraft.ValidateContainer(), false, ModDownload.AssetsIndexExistsBehaviour.DownloadInBackground, true))
				{
					ProgressWeight = 15.0,
					Show = false,
					Block = true
				};
				ModLoader.LoaderCombo<object> loaderCombo = new ModLoader.LoaderCombo<object>("Minecraft 启动", new ArrayList
				{
					new ModLoader.LoaderCombo<int>("Java 处理", new ArrayList
					{
						new ModLoader.LoaderTask<int, List<ModNet.NetFile>>("Java 验证", (ModLaunch._Closure$__.$IR7-2 == null) ? (ModLaunch._Closure$__.$IR7-2 = delegate(ModLoader.LoaderTask<int, List<ModNet.NetFile>> a0)
						{
							ModLaunch.McLaunchJavaValidate();
						}) : ModLaunch._Closure$__.$IR7-2, null, ThreadPriority.Normal)
						{
							ProgressWeight = 2.0
						}
					})
					{
						ProgressWeight = 2.0,
						Show = false,
						Block = false
					},
					ModLaunch._InfoIterator,
					value,
					new ModLoader.LoaderTask<int, string>("提供参数中的服务器 IP", delegate(ModLoader.LoaderTask<int, string> InnerLoader)
					{
						InnerLoader.Output = CS$<>8__locals1.$VB$Local_Loader.Input;
					}, null, ThreadPriority.Normal)
					{
						ProgressWeight = 0.01,
						Show = false
					},
					new ModLoader.LoaderTask<string, List<ModMinecraft.McLibToken>>("获取启动参数", new ModLoader.LoaderTask<string, List<ModMinecraft.McLibToken>>.LoadDelegateSub(ModLaunch.McLaunchArgumentMain), null, ThreadPriority.Normal)
					{
						ProgressWeight = 2.0
					},
					new ModLoader.LoaderTask<List<ModMinecraft.McLibToken>, int>("解压文件", new ModLoader.LoaderTask<List<ModMinecraft.McLibToken>, int>.LoadDelegateSub(ModLaunch.McLaunchNatives), null, ThreadPriority.Normal)
					{
						ProgressWeight = 2.0
					},
					new ModLoader.LoaderTask<int, int>("预启动处理", (ModLaunch._Closure$__.$IR7-3 == null) ? (ModLaunch._Closure$__.$IR7-3 = delegate(ModLoader.LoaderTask<int, int> a0)
					{
						ModLaunch.McLaunchPrerun();
					}) : ModLaunch._Closure$__.$IR7-3, null, ThreadPriority.Normal)
					{
						ProgressWeight = 1.0
					},
					new ModLoader.LoaderTask<int, Process>("启动进程", new ModLoader.LoaderTask<int, Process>.LoadDelegateSub(ModLaunch.McLaunchRun), null, ThreadPriority.Normal)
					{
						ProgressWeight = 2.0
					},
					new ModLoader.LoaderTask<Process, int>("等待游戏窗口出现", new ModLoader.LoaderTask<Process, int>.LoadDelegateSub(ModLaunch.McLaunchWait), null, ThreadPriority.Normal)
					{
						ProgressWeight = 1.0
					},
					new ModLoader.LoaderTask<int, int>("结束处理", (ModLaunch._Closure$__.$IR7-4 == null) ? (ModLaunch._Closure$__.$IR7-4 = delegate(ModLoader.LoaderTask<int, int> a0)
					{
						ModLaunch.McLaunchEnd();
					}) : ModLaunch._Closure$__.$IR7-4, null, ThreadPriority.Normal)
					{
						ProgressWeight = 1.0
					}
				})
				{
					Show = false
				};
				ModLaunch.m_ManagerIterator = loaderCombo;
				loaderCombo.Start(ModBase.GetUuid(), false);
				ModLoader.LoaderTaskbarAdd(loaderCombo);
				while (loaderCombo.State == ModBase.LoadState.Loading)
				{
					ModMain.m_InvocationFilter.Dispatcher.Invoke(new Action(ModMain.m_InvocationFilter.LaunchingRefresh));
					Thread.Sleep(0xC8);
				}
				ModMain.m_InvocationFilter.Dispatcher.Invoke(new Action(ModMain.m_InvocationFilter.LaunchingRefresh));
				switch (loaderCombo.State)
				{
				case ModBase.LoadState.Finished:
					ModMain.Hint(ModMinecraft.ValidateContainer().Name + " 启动成功！", ModMain.HintType.Finish, true);
					break;
				case ModBase.LoadState.Failed:
					throw loaderCombo.Error;
				case ModBase.LoadState.Aborted:
					ModMain.Hint("已取消启动！", ModMain.HintType.Info, true);
					break;
				default:
					throw new Exception("错误的状态改变：" + ModBase.GetStringFromEnum(loaderCombo.State));
				}
			}
			catch (Exception ex2)
			{
				Exception ex3 = ex2;
				while (!ex3.Message.StartsWith("$"))
				{
					if (ex3.InnerException == null)
					{
						ModLaunch.McLaunchLog("错误：" + ModBase.GetString(ex2, false, false));
						ModBase.Log(ex2, "Minecraft 启动失败", ModBase.LogLevel.Msgbox, "启动失败");
						throw;
					}
					ex3 = ex3.InnerException;
				}
				if (Operators.CompareString(ex3.Message, "$$", true) != 0)
				{
					ModMain.MyMsgBox(ex3.Message.TrimStart(new char[]
					{
						'$'
					}), "启动失败", "确定", "", "", false, true, false);
				}
				throw;
			}
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x000429D0 File Offset: 0x00040BD0
		private static void McLaunchPrecheck()
		{
			if (ModMinecraft.ValidateContainer().ManageExpression().Contains("!") || ModMinecraft.ValidateContainer().ManageExpression().Contains(";"))
			{
				throw new Exception("游戏路径中不可包含 ! 或 ;（" + ModMinecraft.ValidateContainer().ManageExpression() + "）");
			}
			if (ModMinecraft.ValidateContainer().Path.Contains("!") || ModMinecraft.ValidateContainer().Path.Contains(";"))
			{
				throw new Exception("游戏路径中不可包含 ! 或 ;（" + ModMinecraft.ValidateContainer().Path + "）");
			}
			string CheckResult = null;
			ModBase.RunInUiWait(delegate()
			{
				CheckResult = ModLaunch.McLoginAble(ModLaunch.McLoginInput());
			});
			if (Operators.CompareString(CheckResult, "", true) != 0)
			{
				throw new ArgumentException(CheckResult);
			}
			if (ModMinecraft.ValidateContainer() == null)
			{
				throw new Exception("未选择 Minecraft 版本！");
			}
			ModMinecraft.ValidateContainer().Load();
			if (ModMinecraft.ValidateContainer().m_HelperAlgo == ModMinecraft.McVersionState.Error)
			{
				throw new Exception("Minecraft 存在问题：" + ModMinecraft.ValidateContainer().m_SchemaAlgo);
			}
			if (!ModMain.ManageIterator(null))
			{
				ModBase.RunInNewThread((ModLaunch._Closure$__.$I8-1 == null) ? (ModLaunch._Closure$__.$I8-1 = delegate()
				{
					object left = ModBase._BaseRule.Get("SystemLaunchCount", null);
					if (Conversions.ToBoolean(Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x14, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x32, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x64, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x96, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0xC8, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0xFA, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x12C, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x15E, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x190, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x1C2, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x1F4, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x258, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x2BC, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x320, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x384, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x3E8, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x44C, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x4B0, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x514, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x578, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x5DC, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x640, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x6A4, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x708, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x76C, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 0x7D0, true))) && ModMain.MyMsgBox(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("PCL2 已经为你启动了 ", ModBase._BaseRule.Get("SystemLaunchCount", null)), " 次游戏啦！"), "\r\n"), "如果觉得 PCL2 还算好用的话，也可以考虑小小地赞助一下作者呢 qwq……"), "\r\n"), "毕竟一个人开发也不容易（小声）……")), "求赞助啦……", "这就赞助！", "但是我拒绝", "", false, true, false) == 1)
					{
						ModBase.OpenWebsite("https://afdian.net/@LTCat/plan");
					}
				}) : ModLaunch._Closure$__.$I8-1, "Donate", ThreadPriority.Normal);
			}
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x00042B3C File Offset: 0x00040D3C
		public static string McLoginAble()
		{
			object left = ModBase._BaseRule.Get("LoginType", null);
			string result;
			if (Operators.ConditionalCompareObjectEqual(left, ModLaunch.McLoginType.Mojang, true))
			{
				if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("CacheMojangAccess", null), "", true))
				{
					result = ModMain.m_DefinitionFilter.IsVaild();
				}
				else
				{
					result = "";
				}
			}
			else if (Operators.ConditionalCompareObjectEqual(left, ModLaunch.McLoginType.Ms, true))
			{
				if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("CacheMsOAuthRefresh", null), "", true))
				{
					result = ModMain._ConsumerFilter.IsVaild();
				}
				else
				{
					result = "";
				}
			}
			else if (Operators.ConditionalCompareObjectEqual(left, ModLaunch.McLoginType.Legacy, true))
			{
				result = ModMain.m_MockFilter.IsVaild();
			}
			else if (Operators.ConditionalCompareObjectEqual(left, ModLaunch.McLoginType.Nide, true))
			{
				if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("CacheNideAccess", null), "", true))
				{
					result = ModMain.m_SpecificationFilter.IsVaild();
				}
				else
				{
					result = "";
				}
			}
			else if (Operators.ConditionalCompareObjectEqual(left, ModLaunch.McLoginType.Auth, true))
			{
				if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("CacheAuthAccess", null), "", true))
				{
					result = ModMain._SchemaFilter.IsVaild();
				}
				else
				{
					result = "";
				}
			}
			else
			{
				result = "未知的登录方式";
			}
			return result;
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x00042C90 File Offset: 0x00040E90
		public static string McLoginAble(ModLaunch.McLoginData LoginData)
		{
			switch (LoginData.Type)
			{
			case ModLaunch.McLoginType.Legacy:
				return PageLoginLegacy.IsVaild((ModLaunch.McLoginLegacy)LoginData);
			case ModLaunch.McLoginType.Mojang:
				return PageLoginMojang.IsVaild((ModLaunch.McLoginServer)LoginData);
			case ModLaunch.McLoginType.Nide:
				return PageLoginNide.IsVaild((ModLaunch.McLoginServer)LoginData);
			case ModLaunch.McLoginType.Auth:
				return PageLoginAuth.IsVaild((ModLaunch.McLoginServer)LoginData);
			case ModLaunch.McLoginType.Ms:
				return PageLoginMs.IsVaild((ModLaunch.McLoginMs)LoginData);
			}
			return "未知的登录方式";
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x00042D14 File Offset: 0x00040F14
		public static ModLaunch.McLoginData McLoginInput()
		{
			ModLaunch.McLoginData result = null;
			try
			{
				object left = ModBase._BaseRule.Get("LoginType", null);
				if (Operators.ConditionalCompareObjectEqual(left, ModLaunch.McLoginType.Legacy, true))
				{
					result = ModMain.m_MockFilter.GetLoginData();
				}
				else if (Operators.ConditionalCompareObjectEqual(left, ModLaunch.McLoginType.Mojang, true))
				{
					if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("CacheMojangAccess", null), "", true))
					{
						result = ModMain.m_DefinitionFilter.GetLoginData();
					}
					else
					{
						result = ModMain._ParamFilter.GetLoginData();
					}
				}
				else if (Operators.ConditionalCompareObjectEqual(left, ModLaunch.McLoginType.Ms, true))
				{
					if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("CacheMsOAuthRefresh", null), "", true))
					{
						result = ModMain._ConsumerFilter.GetLoginData();
					}
					else
					{
						result = ModMain.queueFilter.GetLoginData();
					}
				}
				else if (Operators.ConditionalCompareObjectEqual(left, ModLaunch.McLoginType.Nide, true))
				{
					if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("CacheNideAccess", null), "", true))
					{
						result = ModMain.m_SpecificationFilter.GetLoginData();
					}
					else
					{
						result = ModMain.dicFilter.GetLoginData();
					}
				}
				else if (Operators.ConditionalCompareObjectEqual(left, ModLaunch.McLoginType.Auth, true))
				{
					if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("CacheAuthAccess", null), "", true))
					{
						result = ModMain._SchemaFilter.GetLoginData();
					}
					else
					{
						result = ModMain.helperFilter.GetLoginData();
					}
				}
				else
				{
					ModBase.DebugAssert(false);
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "获取登录输入信息失败", ModBase.LogLevel.Assert, "出现错误");
			}
			return result;
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x00042EBC File Offset: 0x000410BC
		private static void McLoginStart(ModLoader.LoaderTask<ModLaunch.McLoginData, ModLaunch.McLoginResult> Data)
		{
			ModLaunch.McLaunchLog("登录线程已启动");
			string text = ModLaunch.McLoginAble(Data.Input);
			if (Operators.CompareString(text, "", true) != 0)
			{
				throw new ArgumentException(text);
			}
			object obj = null;
			switch (Data.Input.Type)
			{
			case ModLaunch.McLoginType.Legacy:
				obj = ModLaunch._ProccesorIterator;
				break;
			case ModLaunch.McLoginType.Mojang:
				obj = ModLaunch.repositoryIterator;
				break;
			case ModLaunch.McLoginType.Nide:
				obj = ModLaunch._PrototypeIterator;
				break;
			case ModLaunch.McLoginType.Auth:
				obj = ModLaunch._RefIterator;
				break;
			case ModLaunch.McLoginType.Ms:
				obj = ModLaunch.systemIterator;
				break;
			}
			object instance = obj;
			Type type = null;
			string memberName = "WaitForExit";
			object[] array = new object[3];
			int num = 0;
			ref ModLaunch.McLoginData ptr = ref Data.Input;
			array[num] = Data.Input;
			array[1] = ModLaunch._InfoIterator;
			int num2 = 2;
			ref bool ptr2 = ref Data.IsForceRestart;
			array[num2] = Data.IsForceRestart;
			object[] array2 = array;
			bool[] array3;
			NewLateBinding.LateCall(instance, type, memberName, array, null, null, array3 = new bool[]
			{
				true,
				true,
				true
			}, true);
			if (array3[0])
			{
				ptr = (ModLaunch.McLoginData)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(ModLaunch.McLoginData));
			}
			if (array3[1])
			{
				ModLaunch._InfoIterator = (ModLoader.LoaderTask<ModLaunch.McLoginData, ModLaunch.McLoginResult>)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(ModLoader.LoaderTask<ModLaunch.McLoginData, ModLaunch.McLoginResult>));
			}
			if (array3[2])
			{
				ptr2 = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[2]), typeof(bool));
			}
			object obj2 = NewLateBinding.LateGet(obj, null, "Output", new object[0], null, null, null);
			Data.Output = ((obj2 != null) ? ((ModLaunch.McLoginResult)obj2) : default(ModLaunch.McLoginResult));
			ModBase.RunInUi((ModLaunch._Closure$__.$I19-0 == null) ? (ModLaunch._Closure$__.$I19-0 = delegate()
			{
				ModMain.m_InvocationFilter.RefreshPage(true, false);
			}) : ModLaunch._Closure$__.$I19-0, false);
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x00043068 File Offset: 0x00041268
		private static void McLoginMsStart(ModLoader.LoaderTask<ModLaunch.McLoginMs, ModLaunch.McLoginResult> Data)
		{
			ModLaunch.McLoginMs input = Data.Input;
			string testAlgo = input.testAlgo;
			ModLaunch.McLaunchLog("登录方式：微软正版（" + ((Operators.CompareString(testAlgo, "", true) == 0) ? "尚未登录" : testAlgo) + "）");
			Data.Progress = 0.05;
			if (Operators.CompareString(input._PageAlgo, "", true) != 0 && !Data.IsForceRestart)
			{
				Data.Output = new ModLaunch.McLoginResult
				{
					listenerAlgo = input._PageAlgo,
					Name = input.testAlgo,
					processAlgo = input.m_InstanceAlgo,
					Type = "Microsoft",
					_ImporterAlgo = input.m_InstanceAlgo
				};
			}
			else
			{
				string[] array;
				if (!Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("CacheMsOAuthRefresh", null), "", true))
				{
					array = ModLaunch.MsLoginStep2(Conversions.ToString(ModBase._BaseRule.Get("CacheMsOAuthRefresh", null)), true);
					goto IL_119;
				}
				IL_F2:
				string code = ModLaunch.MsLoginStep1(Data);
				if (Data.IsAborted)
				{
					throw new OperationCanceledException();
				}
				Data.Progress = 0.2;
				array = ModLaunch.MsLoginStep2(code, false);
				IL_119:
				if (Operators.CompareString(array[0], "Relogin", true) == 0)
				{
					goto IL_F2;
				}
				Data.Progress = 0.35;
				if (Data.IsAborted)
				{
					throw new OperationCanceledException();
				}
				string accessToken = array[0];
				string value = array[1];
				string xbltoken = ModLaunch.MsLoginStep3(accessToken);
				Data.Progress = 0.5;
				if (Data.IsAborted)
				{
					throw new OperationCanceledException();
				}
				string[] tokens = ModLaunch.MsLoginStep4(xbltoken);
				Data.Progress = 0.65;
				if (Data.IsAborted)
				{
					throw new OperationCanceledException();
				}
				string text = ModLaunch.MsLoginStep5(tokens);
				Data.Progress = 0.8;
				if (Data.IsAborted)
				{
					throw new OperationCanceledException();
				}
				string[] array2 = ModLaunch.MsLoginStep6(text);
				ModBase._BaseRule.Set("CacheMsOAuthRefresh", value, false, null);
				ModBase._BaseRule.Set("CacheMsAccess", text, false, null);
				ModBase._BaseRule.Set("CacheMsUuid", array2[0], false, null);
				ModBase._BaseRule.Set("CacheMsName", array2[1], false, null);
				Data.Output = new ModLaunch.McLoginResult
				{
					listenerAlgo = text,
					Name = array2[1],
					processAlgo = array2[0],
					Type = "Microsoft",
					_ImporterAlgo = array2[0],
					m_AdapterAlgo = array2[2]
				};
			}
			ModLaunch.McLaunchLog("微软登录完成");
			Data.Progress = 0.95;
			if (ModMain.ThemeUnlock(0xA, false, null))
			{
				ModMain.MyMsgBox("感谢你对正版游戏的支持！\r\n隐藏主题 跳票红 已解锁！", "提示", "确定", "", "", false, true, false);
			}
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x00043324 File Offset: 0x00041524
		private static void McLoginServerStart(ModLoader.LoaderTask<ModLaunch.McLoginServer, ModLaunch.McLoginResult> Data)
		{
			ModLaunch._Closure$__26-0 CS$<>8__locals1 = new ModLaunch._Closure$__26-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_Data = Data;
			ModLaunch.McLoginServer input = CS$<>8__locals1.$VB$Local_Data.Input;
			bool flag = false;
			string text = input._DispatcherAlgo;
			if (Conversions.ToBoolean(text.Contains("@") && Conversions.ToBoolean(ModBase._BaseRule.Get("UiLauncherEmail", null))))
			{
				text = ModMinecraft.AccountFilter(text);
			}
			ModLaunch.McLaunchLog(string.Concat(new string[]
			{
				"登录方式：",
				input._WatcherAlgo,
				"（",
				text,
				"）"
			}));
			CS$<>8__locals1.$VB$Local_Data.Progress = 0.05;
			if (!Conversions.ToBoolean(!CS$<>8__locals1.$VB$Local_Data.Input.m_StateAlgo && Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("Cache" + input.propertyAlgo + "Username", null), CS$<>8__locals1.$VB$Local_Data.Input._DispatcherAlgo, true) && Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("Cache" + input.propertyAlgo + "Pass", null), CS$<>8__locals1.$VB$Local_Data.Input._TagAlgo, true) && Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase._BaseRule.Get("Cache" + input.propertyAlgo + "Access", null), "", true))) && Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase._BaseRule.Get("Cache" + input.propertyAlgo + "Client", null), "", true))) && Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase._BaseRule.Get("Cache" + input.propertyAlgo + "Uuid", null), "", true))) && Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase._BaseRule.Get("Cache" + input.propertyAlgo + "Name", null), "", true)))))
			{
				goto IL_389;
			}
			try
			{
				if (CS$<>8__locals1.$VB$Local_Data.IsAborted)
				{
					throw new OperationCanceledException();
				}
				ModLaunch.McLoginRequestValidate(ref CS$<>8__locals1.$VB$Local_Data);
				goto IL_38F;
			}
			catch (Exception ex)
			{
				string @string = ModBase.GetString(ex, true, false);
				ModLaunch.McLaunchLog("验证登录失败：" + @string);
				if ((@string.Contains("超时") || @string.Contains("imeout")) && !@string.Contains("403"))
				{
					ModLaunch.McLaunchLog("已触发超时登录失败");
					throw new Exception("$登录失败：连接登录服务器超时。\r\n请检查你的网络状况是否良好，或尝试使用 VPN！");
				}
			}
			CS$<>8__locals1.$VB$Local_Data.Progress = 0.25;
			IL_31E:
			try
			{
				if (CS$<>8__locals1.$VB$Local_Data.IsAborted)
				{
					throw new OperationCanceledException();
				}
				ModLaunch.McLoginRequestRefresh(ref CS$<>8__locals1.$VB$Local_Data, flag);
				goto IL_38F;
			}
			catch (Exception ex2)
			{
				ModLaunch.McLaunchLog("刷新登录失败：" + ModBase.GetString(ex2, true, false));
			}
			CS$<>8__locals1.$VB$Local_Data.Progress = (flag ? 0.85 : 0.45);
			IL_389:
			try
			{
				if (CS$<>8__locals1.$VB$Local_Data.IsAborted)
				{
					throw new OperationCanceledException();
				}
				flag = ModLaunch.McLoginRequestLogin(ref CS$<>8__locals1.$VB$Local_Data);
			}
			catch (Exception ex3)
			{
				ModLaunch.McLaunchLog("登录失败：" + ModBase.GetString(ex3, true, false));
				throw;
			}
			if (flag)
			{
				CS$<>8__locals1.$VB$Local_Data.Progress = 0.65;
				goto IL_31E;
			}
			IL_38F:
			CS$<>8__locals1.$VB$Local_Data.Progress = 0.95;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			checked
			{
				try
				{
					if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase._BaseRule.Get("Login" + input.propertyAlgo + "Email", null), "", true))))
					{
						arrayList.AddRange(ModBase._BaseRule.Get("Login" + input.propertyAlgo + "Email", null).ToString().Split(new char[]
						{
							'¨'
						}));
					}
					if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase._BaseRule.Get("Login" + input.propertyAlgo + "Pass", null), "", true))))
					{
						arrayList2.AddRange(ModBase._BaseRule.Get("Login" + input.propertyAlgo + "Pass", null).ToString().Split(new char[]
						{
							'¨'
						}));
					}
					int num = arrayList.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						dictionary.Add(Conversions.ToString(arrayList[i]), Conversions.ToString(arrayList2[i]));
					}
					dictionary.Remove(input._DispatcherAlgo);
					arrayList = new ArrayList(dictionary.Keys.ToArray<string>());
					arrayList.Insert(0, input._DispatcherAlgo);
					arrayList2 = new ArrayList(dictionary.Values.ToArray<string>());
					arrayList2.Insert(0, input._TagAlgo);
					ModBase._BaseRule.Set("Login" + input.propertyAlgo + "Email", ModBase.Join(arrayList.ToArray(), "¨"), false, null);
					ModBase._BaseRule.Set("Login" + input.propertyAlgo + "Pass", ModBase.Join(arrayList2.ToArray(), "¨"), false, null);
				}
				catch (Exception ex4)
				{
					ModBase.Log(ex4, "保存启动记录失败", ModBase.LogLevel.Hint, "出现错误");
					ModBase._BaseRule.Set("Login" + input.propertyAlgo + "Email", "", false, null);
					ModBase._BaseRule.Set("Login" + input.propertyAlgo + "Pass", "", false, null);
				}
				if (Operators.CompareString(input.propertyAlgo, "Mojang", true) == 0 && ModMain.ThemeUnlock(0xA, false, null))
				{
					ModMain.MyMsgBox("感谢你对正版游戏的支持！\r\n隐藏主题 跳票红 已解锁！", "提示", "确定", "", "", false, true, false);
				}
				if (Operators.CompareString(input.propertyAlgo, "Mojang", true) == 0)
				{
					ModBase.RunInThread(delegate
					{
						try
						{
							ModLaunch.McLaunchLog("Mojang 账号已登录，正在检查账号迁移");
							JObject jobject = (JObject)ModBase.GetJson(ModNet.NetRequestRetry("https://api.minecraftservices.com/rollout/v1/msamigration", "GET", "", "", true, new Dictionary<string, string>
							{
								{
									"Authorization",
									"Bearer " + CS$<>8__locals1.$VB$Local_Data.Output.listenerAlgo
								}
							}));
							if (jobject["rollout"] != null)
							{
								bool flag2 = jobject["rollout"].ToObject<bool>();
								ModLaunch.McLaunchLog("账号迁移检查结果：" + Conversions.ToString(flag2));
								if (flag2)
								{
									ModBase.RunInUi((ModLaunch._Closure$__.$I26-1 == null) ? (ModLaunch._Closure$__.$I26-1 = delegate()
									{
										ModMain.m_CandidateFilter.PanMs.Visibility = Visibility.Visible;
									}) : ModLaunch._Closure$__.$I26-1, false);
								}
							}
						}
						catch (Exception ex5)
						{
							ModBase.Log(ex5, "账号迁移检查失败", ModBase.LogLevel.Debug, "出现错误");
						}
					});
				}
			}
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x00043A00 File Offset: 0x00041C00
		private static void McLoginLegacyStart(ModLoader.LoaderTask<ModLaunch.McLoginLegacy, ModLaunch.McLoginResult> Data)
		{
			ModLaunch.McLoginLegacy input = Data.Input;
			ModLaunch.McLaunchLog("登录方式：离线（" + input.m_CustomerAlgo + "）");
			Data.Progress = 0.1;
			Data.Output.Name = input.m_CustomerAlgo;
			Data.Output.processAlgo = Conversions.ToString(ModLaunch.McLoginLegacyUuid(input.m_CustomerAlgo));
			Data.Output.Type = "Legacy";
			checked
			{
				switch (input.taskAlgo)
				{
				case 0:
					goto IL_379;
				case 1:
					while (Operators.CompareString(ModMinecraft.McSkinSex(Data.Output.processAlgo), "Steve", true) != 0)
					{
						if (Data.Output.processAlgo.EndsWith("FFFFF"))
						{
							Data.Output.processAlgo = Strings.Mid(Data.Output.processAlgo, 1, 0x1B) + "00000";
						}
						Data.Output.processAlgo = Strings.Mid(Data.Output.processAlgo, 1, 0x1B) + (long.Parse(Strings.Right(Data.Output.processAlgo, 5), NumberStyles.AllowHexSpecifier) + 1L).ToString("X");
					}
					goto IL_379;
				case 2:
					while (Operators.CompareString(ModMinecraft.McSkinSex(Data.Output.processAlgo), "Alex", true) != 0)
					{
						if (Data.Output.processAlgo.EndsWith("FFFFF"))
						{
							Data.Output.processAlgo = Strings.Mid(Data.Output.processAlgo, 1, 0x1B) + "00000";
						}
						Data.Output.processAlgo = Strings.Mid(Data.Output.processAlgo, 1, 0x1B) + (long.Parse(Strings.Right(Data.Output.processAlgo, 5), NumberStyles.AllowHexSpecifier) + 1L).ToString("X");
					}
					goto IL_379;
				case 3:
					try
					{
						if (Operators.CompareString(input._AuthenticationAlgo, "", true) != 0)
						{
							ModBase.Log("[Skin] 由于离线皮肤设置，使用正版 UUID：" + input._AuthenticationAlgo, ModBase.LogLevel.Normal, "出现错误");
							Data.Output.processAlgo = Conversions.ToString(ModLaunch.McLoginMojangUuid(input._AuthenticationAlgo, false));
						}
						goto IL_379;
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "离线启动时使用的正版皮肤获取失败", ModBase.LogLevel.Debug, "出现错误");
						ModMain.MyMsgBox("由于设置的离线启动时使用的正版皮肤获取失败，游戏将以无皮肤的方式启动。\r\n请检查你的网络是否通畅，或尝试使用 VPN！\r\n\r\n详细的错误信息：" + ex.Message, "皮肤获取失败", "确定", "", "", false, true, false);
						goto IL_379;
					}
					break;
				case 4:
					break;
				default:
					goto IL_379;
				}
				while (Operators.CompareString(ModMinecraft.McSkinSex(Data.Output.processAlgo), (!Conversions.ToBoolean(ModBase._BaseRule.Get("LaunchSkinSlim", null))) ? "Steve" : "Alex", true) != 0)
				{
					if (Data.Output.processAlgo.EndsWith("FFFFF"))
					{
						Data.Output.processAlgo = Strings.Mid(Data.Output.processAlgo, 1, 0x1B) + "00000";
					}
					Data.Output.processAlgo = Strings.Mid(Data.Output.processAlgo, 1, 0x1B) + (long.Parse(Strings.Right(Data.Output.processAlgo, 5), NumberStyles.AllowHexSpecifier) + 1L).ToString("X");
				}
				IL_379:
				Data.Output.listenerAlgo = Data.Output.processAlgo;
				Data.Output._ImporterAlgo = Data.Output.processAlgo;
				ArrayList arrayList = new ArrayList();
				if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase._BaseRule.Get("LoginLegacyName", null), "", true))))
				{
					arrayList.AddRange(ModBase._BaseRule.Get("LoginLegacyName", null).ToString().Split(new char[]
					{
						'¨'
					}));
				}
				arrayList.Remove(input.m_CustomerAlgo);
				arrayList.Insert(0, input.m_CustomerAlgo);
				ModBase._BaseRule.Set("LoginLegacyName", ModBase.Join(arrayList.ToArray(), "¨"), false, null);
				Data.Output = Data.Output;
			}
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x00043E64 File Offset: 0x00042064
		private static void McLoginRequestValidate(ref ModLoader.LoaderTask<ModLaunch.McLoginServer, ModLaunch.McLoginResult> Data)
		{
			ModLaunch.McLaunchLog("验证登录开始（Validate, " + Data.Input.propertyAlgo + "）");
			string text = Conversions.ToString(ModBase._BaseRule.Get("Cache" + Data.Input.propertyAlgo + "Access", null));
			string text2 = Conversions.ToString(ModBase._BaseRule.Get("Cache" + Data.Input.propertyAlgo + "Client", null));
			string processAlgo = Conversions.ToString(ModBase._BaseRule.Get("Cache" + Data.Input.propertyAlgo + "Uuid", null));
			string name = Conversions.ToString(ModBase._BaseRule.Get("Cache" + Data.Input.propertyAlgo + "Name", null));
			ModNet.NetRequestRetry(Data.Input._InitializerAlgo + "/validate", "POST", string.Concat(new string[]
			{
				"{\"accessToken\":\"",
				text,
				"\",\"clientToken\":\"",
				text2,
				"\",\"requestUser\":true}"
			}), "application/json; charset=utf-8", true, null);
			Data.Output.listenerAlgo = text;
			Data.Output._ImporterAlgo = text2;
			Data.Output.processAlgo = processAlgo;
			Data.Output.Name = name;
			Data.Output.Type = Data.Input.propertyAlgo;
			Data.Output._TemplateAlgo = Data.Input._DispatcherAlgo;
			ModLaunch.McLaunchLog("验证登录成功（Validate, " + Data.Input.propertyAlgo + "）");
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x00044018 File Offset: 0x00042218
		private static void McLoginRequestRefresh(ref ModLoader.LoaderTask<ModLaunch.McLoginServer, ModLaunch.McLoginResult> Data, bool RequestUser)
		{
			ModLaunch.McLaunchLog("刷新登录开始（Refresh, " + Data.Input.propertyAlgo + "）");
			JObject jobject = (JObject)ModBase.GetJson(ModNet.NetRequestRetry(Data.Input._InitializerAlgo + "/refresh", "POST", Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("{", RequestUser ? Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("\r\n               \"requestUser\": true,\r\n               \"selectedProfile\": {\r\n                   \"id\":\"", ModBase._BaseRule.Get("Cache" + Data.Input.propertyAlgo + "Uuid", null)), "\",\r\n                   \"name\":\""), ModBase._BaseRule.Get("Cache" + Data.Input.propertyAlgo + "Name", null)), "\"},") : ""), "\r\n               \"accessToken\":\""), ModBase._BaseRule.Get("Cache" + Data.Input.propertyAlgo + "Access", null)), "\",\r\n               \"clientToken\":\""), ModBase._BaseRule.Get("Cache" + Data.Input.propertyAlgo + "Client", null)), "\"}"), "application/json; charset=utf-8", true, null));
			if (jobject["selectedProfile"] == null)
			{
				throw new Exception(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("选择的角色 ", ModBase._BaseRule.Get("Cache" + Data.Input.propertyAlgo + "Name", null)), " 无效！")));
			}
			Data.Output.listenerAlgo = jobject["accessToken"].ToString();
			Data.Output._ImporterAlgo = jobject["clientToken"].ToString();
			Data.Output.processAlgo = jobject["selectedProfile"]["id"].ToString();
			Data.Output.Name = jobject["selectedProfile"]["name"].ToString();
			Data.Output.Type = Data.Input.propertyAlgo;
			Data.Output._TemplateAlgo = Data.Input._DispatcherAlgo;
			ModBase._BaseRule.Set("Cache" + Data.Input.propertyAlgo + "Access", Data.Output.listenerAlgo, false, null);
			ModBase._BaseRule.Set("Cache" + Data.Input.propertyAlgo + "Client", Data.Output._ImporterAlgo, false, null);
			ModBase._BaseRule.Set("Cache" + Data.Input.propertyAlgo + "Uuid", Data.Output.processAlgo, false, null);
			ModBase._BaseRule.Set("Cache" + Data.Input.propertyAlgo + "Name", Data.Output.Name, false, null);
			ModBase._BaseRule.Set("Cache" + Data.Input.propertyAlgo + "Username", Data.Input._DispatcherAlgo, false, null);
			ModBase._BaseRule.Set("Cache" + Data.Input.propertyAlgo + "Pass", Data.Input._TagAlgo, false, null);
			ModLaunch.McLaunchLog("刷新登录成功（Refresh, " + Data.Input.propertyAlgo + "）");
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x000443C8 File Offset: 0x000425C8
		private static bool McLoginRequestLogin(ref ModLoader.LoaderTask<ModLaunch.McLoginServer, ModLaunch.McLoginResult> Data)
		{
			bool result;
			try
			{
				ModLaunch._Closure$__30-0 CS$<>8__locals1 = new ModLaunch._Closure$__30-0(CS$<>8__locals1);
				bool flag = false;
				ModLaunch.McLaunchLog("登录开始（Login, " + Data.Input.propertyAlgo + "）");
				CS$<>8__locals1.$VB$Local_LoginJson = (JObject)ModBase.GetJson(ModNet.NetRequestRetry(Data.Input._InitializerAlgo + "/authenticate", "POST", string.Concat(new string[]
				{
					"{\"agent\": {\"name\": \"Minecraft\",\"version\": 1},\"username\":\"",
					Data.Input._DispatcherAlgo,
					"\",\"password\":\"",
					Data.Input._TagAlgo,
					"\",\"requestUser\":true}"
				}), "application/json; charset=utf-8", true, null));
				if (CS$<>8__locals1.$VB$Local_LoginJson["availableProfiles"].Count<JToken>() == 0)
				{
					if (Data.Input.Type == ModLaunch.McLoginType.Auth)
					{
						if (Data.Input.m_StateAlgo)
						{
							ModMain.Hint("你还没有创建角色，无法更换！", ModMain.HintType.Critical, true);
						}
						throw new Exception("$你还没有创建角色，请在创建角色后再试！");
					}
					throw new Exception("$你还没有购买 Minecraft 正版，请在购买后再试！");
				}
				else
				{
					if (Data.Input.m_StateAlgo && CS$<>8__locals1.$VB$Local_LoginJson["availableProfiles"].Count<JToken>() == 1)
					{
						ModMain.Hint("你的账户中只有一个角色，无法更换！", ModMain.HintType.Critical, true);
					}
					CS$<>8__locals1.$VB$Local_SelectedName = null;
					CS$<>8__locals1.$VB$Local_SelectedId = null;
					if ((CS$<>8__locals1.$VB$Local_LoginJson["selectedProfile"] == null || Data.Input.m_StateAlgo) && CS$<>8__locals1.$VB$Local_LoginJson["availableProfiles"].Count<JToken>() > 1)
					{
						flag = true;
						string right = Conversions.ToString(ModBase._BaseRule.Get("Cache" + Data.Input.propertyAlgo + "Uuid", null));
						try
						{
							foreach (JToken jtoken in ((IEnumerable<JToken>)CS$<>8__locals1.$VB$Local_LoginJson["availableProfiles"]))
							{
								if (Operators.CompareString(jtoken["id"].ToString(), right, true) == 0)
								{
									CS$<>8__locals1.$VB$Local_SelectedName = jtoken["name"].ToString();
									CS$<>8__locals1.$VB$Local_SelectedId = jtoken["id"].ToString();
									ModLaunch.McLaunchLog("根据缓存选择的角色：" + CS$<>8__locals1.$VB$Local_SelectedName);
								}
							}
						}
						finally
						{
							IEnumerator<JToken> enumerator;
							if (enumerator != null)
							{
								enumerator.Dispose();
							}
						}
						if (CS$<>8__locals1.$VB$Local_SelectedName == null)
						{
							ModLaunch.McLaunchLog("要求玩家选择角色");
							ModBase.RunInUiWait(delegate()
							{
								List<IMyRadio> list = new List<IMyRadio>();
								List<JToken> list2 = new List<JToken>();
								try
								{
									foreach (JToken jtoken2 in ((IEnumerable<JToken>)CS$<>8__locals1.$VB$Local_LoginJson["availableProfiles"]))
									{
										list.Add(new MyRadioBox
										{
											Text = jtoken2["name"].ToString()
										});
										list2.Add(jtoken2);
									}
								}
								finally
								{
									IEnumerator<JToken> enumerator2;
									if (enumerator2 != null)
									{
										enumerator2.Dispose();
									}
								}
								int value = ModMain.MyMsgBoxSelect(list, "选择使用的角色", "确定", "", false).Value;
								CS$<>8__locals1.$VB$Local_SelectedName = list2[value]["name"].ToString();
								CS$<>8__locals1.$VB$Local_SelectedId = list2[value]["id"].ToString();
							});
							ModLaunch.McLaunchLog("玩家选择的角色：" + CS$<>8__locals1.$VB$Local_SelectedName);
						}
					}
					else
					{
						CS$<>8__locals1.$VB$Local_SelectedName = CS$<>8__locals1.$VB$Local_LoginJson["selectedProfile"]["name"].ToString();
						CS$<>8__locals1.$VB$Local_SelectedId = CS$<>8__locals1.$VB$Local_LoginJson["selectedProfile"]["id"].ToString();
					}
					Data.Output.listenerAlgo = CS$<>8__locals1.$VB$Local_LoginJson["accessToken"].ToString();
					Data.Output._ImporterAlgo = CS$<>8__locals1.$VB$Local_LoginJson["clientToken"].ToString();
					Data.Output.Name = CS$<>8__locals1.$VB$Local_SelectedName;
					Data.Output.processAlgo = CS$<>8__locals1.$VB$Local_SelectedId;
					Data.Output.Type = Data.Input.propertyAlgo;
					Data.Output._TemplateAlgo = Data.Input._DispatcherAlgo;
					ModBase._BaseRule.Set("Cache" + Data.Input.propertyAlgo + "Access", Data.Output.listenerAlgo, false, null);
					ModBase._BaseRule.Set("Cache" + Data.Input.propertyAlgo + "Client", Data.Output._ImporterAlgo, false, null);
					ModBase._BaseRule.Set("Cache" + Data.Input.propertyAlgo + "Uuid", Data.Output.processAlgo, false, null);
					ModBase._BaseRule.Set("Cache" + Data.Input.propertyAlgo + "Name", Data.Output.Name, false, null);
					ModBase._BaseRule.Set("Cache" + Data.Input.propertyAlgo + "Username", Data.Input._DispatcherAlgo, false, null);
					ModBase._BaseRule.Set("Cache" + Data.Input.propertyAlgo + "Pass", Data.Input._TagAlgo, false, null);
					ModLaunch.McLaunchLog("登录成功（Login, " + Data.Input.propertyAlgo + "）");
					result = flag;
				}
			}
			catch (Exception ex)
			{
				string @string = ModBase.GetString(ex, true, false);
				ModBase.Log(ex, "登录失败原始错误信息", ModBase.LogLevel.Normal, "出现错误");
				if (@string.Contains("403"))
				{
					switch (Data.Input.Type)
					{
					case ModLaunch.McLoginType.Legacy:
						throw;
					case ModLaunch.McLoginType.Mojang:
						if (@string.Contains("Invalid username or password"))
						{
							throw new Exception("$登录失败，以下为可能的原因：\r\n - 输入的账号或密码错误。\r\n - 账号类别错误。如果你在使用微软账号或已完成账号迁移，请将登录方式切换为微软。");
						}
						throw new Exception("$登录尝试过于频繁，导致被 Mojang 暂时屏蔽。请不要操作，等待 10 分钟后再试。");
					case ModLaunch.McLoginType.Nide:
						throw new Exception("$登录失败，以下为可能的原因：\r\n - 输入的账号或密码错误。\r\n - 密码错误次数过多，导致被暂时屏蔽。请不要操作，等待 10 分钟后再试。\r\n" + (Data.Input._DispatcherAlgo.Contains("@") ? "" : " - 登录账号应为邮箱或统一通行证账号，而非游戏角色 ID。\r\n") + " - 只注册了账号，但没有加入对应服务器。");
					case ModLaunch.McLoginType.Auth:
						throw new Exception("$登录失败，以下为可能的原因：\r\n - 输入的账号或密码错误。\r\n - 登录尝试过于频繁，导致被暂时屏蔽。请不要操作，等待 10 分钟后再试。\r\n - 只注册了账号，但没有在皮肤站新建角色。");
					case ModLaunch.McLoginType.Ms:
						throw new Exception("$登录失败，以下为可能的原因：\r\n - 登录尝试过于频繁，导致被暂时屏蔽。请不要操作，等待 10 分钟后再试。\r\n - 账号类别错误。如果你在使用 Mojang 账号，请将登录方式切换为 Mojang。");
					}
					result = false;
				}
				else
				{
					if (@string.Contains("超时") || @string.Contains("imeout"))
					{
						throw new Exception("$登录失败：连接登录服务器超时。\r\n请检查你的网络状况是否良好，或尝试使用 VPN！");
					}
					if (@string.Contains("网络请求失败"))
					{
						throw new Exception("$登录失败：连接登录服务器失败。\r\n请检查你的网络状况是否良好，或尝试使用 VPN！");
					}
					if (ex.Message.StartsWith("$"))
					{
						throw;
					}
					throw new Exception("登录失败：" + ex.Message, ex);
				}
			}
			return result;
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x00044A0C File Offset: 0x00042C0C
		private static string MsLoginStep1(ModLoader.LoaderTask<ModLaunch.McLoginMs, ModLaunch.McLoginResult> Data)
		{
			ModLaunch.McLaunchLog("开始微软登录步骤 1");
			string result;
			if (ModBase._ParamsRule <= new Version(0xA, 0, 0x4563, 0))
			{
				ModMain.MyMsgBox("PCL2 即将打开登录网页。登录后会转到一个空白页面（这代表登录成功了），请将该空白页面的网址复制到 PCL2。\r\n如果网络环境不佳，登录网页可能一直加载不出来，此时请尝试使用 VPN 或代理服务器，然后再试。", "登录说明", "开始", "", "", false, true, true);
				ModBase.OpenWebsite(FormLoginOAuth.strategyContainer);
				string text = ModMain.MyMsgBoxInput("", new Collection<Validate>
				{
					new ValidateRegex("(?<=code\\=)[^&]+", "返回网址应以 https://login.live.com/oauth20_desktop.srf?code= 开头")
				}, "https://login.live.com/oauth20_desktop.srf?code=XXXXXX", "输入登录返回码", "确定", "取消", false);
				if (text == null)
				{
					ModLaunch.McLaunchLog("微软登录已在步骤 1 被取消");
					throw new OperationCanceledException("$$");
				}
				result = ModBase.RegexSeek(text, "(?<=code\\=)[^&]+", RegexOptions.None);
			}
			else
			{
				ModLaunch._Closure$__31-0 CS$<>8__locals1 = new ModLaunch._Closure$__31-0(CS$<>8__locals1);
				CS$<>8__locals1.$VB$Local_ReturnCode = null;
				CS$<>8__locals1.$VB$Local_ReturnEx = null;
				CS$<>8__locals1.$VB$Local_IsFinished = ModBase.LoadState.Loading;
				CS$<>8__locals1.$VB$Local_LoginForm = null;
				ModBase.RunInUi(delegate()
				{
					try
					{
						CS$<>8__locals1.$VB$Local_LoginForm = new FormLoginOAuth();
						CS$<>8__locals1.$VB$Local_LoginForm.Show();
						CS$<>8__locals1.$VB$Local_LoginForm.SelectContainer((CS$<>8__locals1.$I1 == null) ? (CS$<>8__locals1.$I1 = delegate(string Code)
						{
							CS$<>8__locals1.$VB$Local_ReturnCode = Code;
							CS$<>8__locals1.$VB$Local_IsFinished = ModBase.LoadState.Finished;
						}) : CS$<>8__locals1.$I1);
						CS$<>8__locals1.$VB$Local_LoginForm.TestContainer((CS$<>8__locals1.$IR5 == null) ? (CS$<>8__locals1.$IR5 = delegate(bool a0)
						{
							((CS$<>8__locals1.$I2 == null) ? (CS$<>8__locals1.$I2 = delegate()
							{
								CS$<>8__locals1.$VB$Local_IsFinished = ModBase.LoadState.Aborted;
							}) : CS$<>8__locals1.$I2)();
						}) : CS$<>8__locals1.$IR5);
					}
					catch (Exception $VB$Local_ReturnEx)
					{
						CS$<>8__locals1.$VB$Local_ReturnEx = $VB$Local_ReturnEx;
						CS$<>8__locals1.$VB$Local_IsFinished = ModBase.LoadState.Failed;
					}
				}, false);
				while (CS$<>8__locals1.$VB$Local_IsFinished == ModBase.LoadState.Loading && !Data.IsAborted)
				{
					Thread.Sleep(0x14);
				}
				ModBase.RunInUi(delegate()
				{
					if (CS$<>8__locals1.$VB$Local_LoginForm != null)
					{
						CS$<>8__locals1.$VB$Local_LoginForm.Close();
					}
				}, false);
				if (CS$<>8__locals1.$VB$Local_IsFinished == ModBase.LoadState.Finished)
				{
					result = CS$<>8__locals1.$VB$Local_ReturnCode;
				}
				else
				{
					if (CS$<>8__locals1.$VB$Local_IsFinished == ModBase.LoadState.Failed)
					{
						throw CS$<>8__locals1.$VB$Local_ReturnEx;
					}
					ModLaunch.McLaunchLog("微软登录已在步骤 1 被取消");
					throw new OperationCanceledException("$$");
				}
			}
			return result;
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x00044B6C File Offset: 0x00042D6C
		private static string[] MsLoginStep2(string Code, bool IsRefresh)
		{
			ModLaunch.McLaunchLog("开始微软登录步骤 2（" + (IsRefresh ? "" : "非") + "刷新登录）");
			string data;
			if (IsRefresh)
			{
				data = string.Concat(new string[]
				{
					"client_id=00000000402b5328&refresh_token=",
					Uri.EscapeDataString(Code),
					"&grant_type=refresh_token&redirect_uri=",
					Uri.EscapeDataString("https://login.live.com/oauth20_desktop.srf"),
					"&scope=",
					Uri.EscapeDataString("service::user.auth.xboxlive.com::MBI_SSL")
				});
			}
			else
			{
				data = string.Concat(new string[]
				{
					"client_id=00000000402b5328&code=",
					Uri.EscapeDataString(Code),
					"&grant_type=authorization_code&redirect_uri=",
					Uri.EscapeDataString("https://login.live.com/oauth20_desktop.srf"),
					"&scope=",
					Uri.EscapeDataString("service::user.auth.xboxlive.com::MBI_SSL")
				});
			}
			string data2;
			try
			{
				data2 = Conversions.ToString(ModNet.NetRequestMuity("https://login.live.com/oauth20_token.srf", "POST", data, "application/x-www-form-urlencoded", 1, null));
			}
			catch (Exception ex)
			{
				if (!ex.Message.Contains("must sign in again"))
				{
					throw;
				}
				return new string[]
				{
					"Relogin",
					""
				};
			}
			JObject jobject = (JObject)ModBase.GetJson(data2);
			string text = jobject["access_token"].ToString();
			string text2 = jobject["refresh_token"].ToString();
			return new string[]
			{
				text,
				text2
			};
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x00044CD8 File Offset: 0x00042ED8
		private static string MsLoginStep3(string AccessToken)
		{
			ModLaunch.McLaunchLog("开始微软登录步骤 3");
			string data = "{\r\n                                    \"Properties\": {\r\n                                        \"AuthMethod\": \"RPS\",\r\n                                        \"SiteName\": \"user.auth.xboxlive.com\",\r\n                                        \"RpsTicket\": \"" + AccessToken + "\"\r\n                                    },\r\n                                    \"RelyingParty\": \"http://auth.xboxlive.com\",\r\n                                    \"TokenType\": \"JWT\"\r\n                                 }";
			return ((JObject)ModBase.GetJson(Conversions.ToString(ModNet.NetRequestMuity("https://user.auth.xboxlive.com/user/authenticate", "POST", data, "application/json", 3, null))))["Token"].ToString();
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x00044D38 File Offset: 0x00042F38
		private static string[] MsLoginStep4(string XBLToken)
		{
			ModLaunch.McLaunchLog("开始微软登录步骤 4");
			string data = "{\r\n                                    \"Properties\": {\r\n                                        \"SandboxId\": \"RETAIL\",\r\n                                        \"UserTokens\": [\r\n                                            \"" + XBLToken + "\"\r\n                                        ]\r\n                                    },\r\n                                    \"RelyingParty\": \"rp://api.minecraftservices.com/\",\r\n                                    \"TokenType\": \"JWT\"\r\n                                 }";
			string data2;
			try
			{
				data2 = Conversions.ToString(ModNet.NetRequestMuity("https://xsts.auth.xboxlive.com/xsts/authorize", "POST", data, "application/json", 3, null));
			}
			catch (WebException ex)
			{
				if (ex.Message.Contains("2148916233"))
				{
					throw new Exception("$该微软账号尚未购买 Minecraft 或注册 XBox 账户！");
				}
				if (ex.Message.Contains("2148916238"))
				{
					if (ModMain.MyMsgBox("该账号年龄不足，你需要先修改出生日期，然后才能登录。\r\n该账号目前填写的年龄是否在 13 岁以上？", "登录提示", "13 岁以上", "12 岁以下", "我不知道", false, true, false) == 1)
					{
						ModBase.OpenWebsite("https://account.live.com/editprof.aspx");
						ModMain.MyMsgBox("请在打开的网页中修改账号的出生日期（建议改为 18 岁以上）。\r\n在修改成功后等待一分钟，然后再回到 PCL2，就可以正常登录了！", "登录提示", "确定", "", "", false, true, false);
					}
					else
					{
						ModBase.OpenWebsite("https://support.microsoft.com/zh-cn/account-billing/如何更改-microsoft-帐户上的出生日期-837badbc-999e-54d2-2617-d19206b9540a");
						ModMain.MyMsgBox("请根据打开的网页的说明，修改账号的出生日期（建议改为 18 岁以上）。\r\n在修改成功后等待一分钟，然后再回到 PCL2，就可以正常登录了！", "登录提示", "确定", "", "", false, true, false);
					}
					throw new Exception("$$");
				}
				throw;
			}
			JObject jobject = (JObject)ModBase.GetJson(data2);
			string text = jobject["Token"].ToString();
			string text2 = jobject["DisplayClaims"]["xui"][0]["uhs"].ToString();
			return new string[]
			{
				text,
				text2
			};
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x00044EB4 File Offset: 0x000430B4
		private static string MsLoginStep5(string[] Tokens)
		{
			ModLaunch.McLaunchLog("开始微软登录步骤 5");
			string data = string.Concat(new string[]
			{
				"{\"identityToken\": \"XBL3.0 x=",
				Tokens[1],
				";",
				Tokens[0],
				"\"}"
			});
			string data2;
			try
			{
				data2 = Conversions.ToString(ModNet.NetRequestMuity("https://api.minecraftservices.com/authentication/login_with_xbox", "POST", data, "application/json", 2, null));
			}
			catch (WebException ex)
			{
				if (ModBase.GetString(ex, true, false).Contains("(429)"))
				{
					ModBase.Log(ex, "微软登录第 5 步汇报 429", ModBase.LogLevel.Debug, "出现错误");
					throw new Exception("$登录尝试太过频繁，请等待几分钟后再试！");
				}
				throw;
			}
			return ((JObject)ModBase.GetJson(data2))["access_token"].ToString();
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x00044F80 File Offset: 0x00043180
		private static string[] MsLoginStep6(string AccessToken)
		{
			ModLaunch.McLaunchLog("开始微软登录步骤 6");
			string text;
			try
			{
				text = Conversions.ToString(ModNet.NetRequestMuity("https://api.minecraftservices.com/minecraft/profile", "GET", "", "application/json", 2, new Dictionary<string, string>
				{
					{
						"Authorization",
						"Bearer " + AccessToken
					}
				}));
			}
			catch (WebException ex)
			{
				string @string = ModBase.GetString(ex, true, false);
				if (@string.Contains("(429)"))
				{
					ModBase.Log(ex, "微软登录第 6 步汇报 429", ModBase.LogLevel.Debug, "出现错误");
					throw new Exception("$登录尝试太过频繁，请等待几分钟后再试！");
				}
				if (@string.Contains("(404)"))
				{
					ModBase.Log(ex, "微软登录第 6 步汇报 404", ModBase.LogLevel.Debug, "出现错误");
					throw new Exception("$该微软账号尚未购买 Minecraft，或尚未创建游戏角色！");
				}
				throw;
			}
			JObject jobject = (JObject)ModBase.GetJson(text);
			string text2 = jobject["id"].ToString();
			string text3 = jobject["name"].ToString();
			return new string[]
			{
				text2,
				text3,
				text
			};
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x0004508C File Offset: 0x0004328C
		public static object McLoginMojangUuid(string Name, bool ThrowOnNotFound)
		{
			object result;
			if (Name.Trim().Length == 0)
			{
				result = ModBase.StrFill("", "0", 0x20);
			}
			else
			{
				string text = ModBase.ReadIni(ModBase.m_GlobalRule + "Cache\\Uuid\\Mojang.ini", Name, "");
				if (Strings.Len(text) == 0x20)
				{
					result = text;
				}
				else
				{
					try
					{
						JObject jobject = (JObject)ModNet.NetGetCodeByRequestRetry("https://api.mojang.com/users/profiles/minecraft/" + Name, null, "", true);
						if (jobject == null)
						{
							throw new FileNotFoundException("正版玩家档案不存在（" + Name + "）");
						}
						text = (string)(jobject["id"] ?? "");
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "从官网获取正版 Uuid 失败（" + Name + "）", ModBase.LogLevel.Debug, "出现错误");
						if (ThrowOnNotFound || Operators.CompareString(ex.GetType().Name, "FileNotFoundException", true) != 0)
						{
							throw new Exception("从官网获取正版 Uuid 失败", ex);
						}
						text = Conversions.ToString(ModLaunch.McLoginLegacyUuid(Name));
					}
					if (Strings.Len(text) != 0x20)
					{
						throw new Exception("获取的正版 Uuid 长度不足（" + text + "）");
					}
					ModBase.WriteIni(ModBase.m_GlobalRule + "Cache\\Uuid\\Mojang.ini", Name, text);
					result = text;
				}
			}
			return result;
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x000451E8 File Offset: 0x000433E8
		public static object McLoginLegacyUuid(string Name)
		{
			return ModBase.StrFill(Name.Length.ToString("X"), "0", 0x10) + ModBase.StrFill(ModBase.GetHash(Name).ToString("X"), "0", 0x10);
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x00045238 File Offset: 0x00043438
		private static void McLaunchJavaValidate()
		{
			Version version = new Version(0, 0, 0, 0);
			Version version2 = new Version(0x3E7, 0x3E7, 0x3E7, 0x3E7);
			if ((DateTime.Compare(ModMinecraft.ValidateContainer().m_RulesAlgo, new DateTime(0x7E5, 5, 0xB)) >= 0 && ModMinecraft.ValidateContainer().Version.clientAlgo == 0x63) || (ModMinecraft.ValidateContainer().Version.clientAlgo >= 0x11 && ModMinecraft.ValidateContainer().Version.clientAlgo != 0x63))
			{
				version = new Version(1, 0x10, 0, 0);
			}
			else if (ModMinecraft.ValidateContainer().m_RulesAlgo.Year >= 0x7E1)
			{
				version = new Version(1, 8, 0, 0);
			}
			else if (ModMinecraft.ValidateContainer().m_RulesAlgo.Year >= 0x7D1)
			{
				version2 = new Version(1, 0xC, 0x3E7, 0x3E7);
			}
			if (ModMinecraft.ValidateContainer().Version.messageAlgo)
			{
				if (Operators.CompareString(ModMinecraft.ValidateContainer().Version.policyAlgo, "1.7.2", true) == 0)
				{
					version = new Version(1, 7, 0, 0);
					version2 = new Version(1, 7, 0x3E7, 0x3E7);
				}
				else if (ModMinecraft.ValidateContainer().Version.clientAlgo == 0x10 && ModMinecraft.ValidateContainer().Version.clientAlgo != -1 && ModMinecraft.VersionSortBoolean("36.1.65", ModMinecraft.ValidateContainer().Version.m_TokenAlgo))
				{
					version2 = new Version(1, 0xF, 0x3E7, 0x3E7);
				}
				else if (ModMinecraft.ValidateContainer().Version.clientAlgo <= 0xF && ModMinecraft.ValidateContainer().Version.clientAlgo != -1)
				{
					version2 = new Version(1, 0xF, 0x3E7, 0x3E7);
				}
			}
			if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LoginType", null), ModLaunch.McLoginType.Nide, true))
			{
				version = ((new Version(1, 8, 0, 0x65) > version) ? new Version(1, 8, 0, 0x65) : version);
			}
			ModLaunch.McLaunchLog("Java 版本需求：最低 " + version.ToString() + "，最高 " + version2.ToString());
			ModLaunch.parameterIterator = ModMinecraft.JavaSelect(version, version2, ModMinecraft.ValidateContainer());
			if (ModLaunch.parameterIterator == null)
			{
				ModLaunch.McLaunchLog("无合适的 Java，取消启动");
				if (version >= new Version(1, 0x10, 0, 0))
				{
					ModMinecraft.JavaMissing(0x10);
				}
				else if (version2 < new Version(1, 8, 0, 0))
				{
					ModMinecraft.JavaMissing(7);
				}
				else
				{
					ModMinecraft.JavaMissing(8);
				}
				throw new Exception("$$");
			}
			ModLaunch.McLaunchLog("选择的 Java：" + ModLaunch.parameterIterator.ToString());
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x000454D8 File Offset: 0x000436D8
		private static void McLaunchArgumentMain(ModLoader.LoaderTask<string, List<ModMinecraft.McLibToken>> Loader)
		{
			ModLaunch.McLaunchLog("开始获取 Minecraft 启动参数");
			string text;
			if (ModMinecraft.ValidateContainer().VerifyUtils()["arguments"] != null && ModMinecraft.ValidateContainer().VerifyUtils()["arguments"]["jvm"] != null)
			{
				ModLaunch.McLaunchLog("获取新版 JVM 参数");
				text = ModLaunch.McLaunchArgumentsJvmNew(ModMinecraft.ValidateContainer());
				ModLaunch.McLaunchLog("新版 JVM 参数获取成功：");
				ModLaunch.McLaunchLog(text);
			}
			else
			{
				ModLaunch.McLaunchLog("获取旧版 JVM 参数");
				text = ModLaunch.McLaunchArgumentsJvmOld(ModMinecraft.ValidateContainer());
				ModLaunch.McLaunchLog("旧版 JVM 参数获取成功：");
				ModLaunch.McLaunchLog(text);
			}
			if (ModMinecraft.ValidateContainer().VerifyUtils()["minecraftArguments"] != null)
			{
				ModLaunch.McLaunchLog("获取旧版 Game 参数");
				text = text + " " + ModLaunch.McLaunchArgumentsGameOld(ModMinecraft.ValidateContainer());
				ModLaunch.McLaunchLog("旧版 Game 参数获取成功");
			}
			if (ModMinecraft.ValidateContainer().VerifyUtils()["arguments"] != null && ModMinecraft.ValidateContainer().VerifyUtils()["arguments"]["game"] != null)
			{
				ModLaunch.McLaunchLog("获取新版 Game 参数");
				text = text + " " + ModLaunch.McLaunchArgumentsGameNew(ModMinecraft.ValidateContainer());
				ModLaunch.McLaunchLog("新版 Game 参数获取成功");
			}
			Dictionary<string, string> dictionary = ModLaunch.McLaunchArgumentsReplace(ModMinecraft.ValidateContainer(), ref Loader);
			if (string.IsNullOrWhiteSpace(dictionary["${version_type}"]))
			{
				text = text.Replace(" --versionType ${version_type}", "");
				dictionary["${version_type}"] = "\"\"";
			}
			try
			{
				foreach (KeyValuePair<string, string> keyValuePair in dictionary)
				{
					text = text.Replace(keyValuePair.Key, (keyValuePair.Value.Contains(" ") || keyValuePair.Value.Contains(":\\")) ? ("\"" + keyValuePair.Value + "\"") : keyValuePair.Value);
				}
			}
			finally
			{
				Dictionary<string, string>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			text = text.Replace(" -Dos.name=Windows 10 ", " -Dos.name=\"Windows 10\" ");
			if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LaunchArgumentWindowType", null), 0, true))
			{
				text += " --fullscreen";
			}
			string text2 = Conversions.ToString(string.IsNullOrEmpty(Loader.Input) ? ModBase._BaseRule.Get("VersionServerEnter", ModMinecraft.ValidateContainer()) : Loader.Input);
			if (text2.Length > 0)
			{
				if (text2.Contains(":"))
				{
					text = string.Concat(new string[]
					{
						text,
						" --server ",
						text2.Split(new char[]
						{
							':'
						})[0],
						" --port ",
						text2.Split(new char[]
						{
							':'
						})[1]
					});
				}
				else
				{
					text = text + " --server " + text2 + " --port 25565";
				}
				if (ModMinecraft.ValidateContainer().Version.m_ComposerAlgo)
				{
					ModMain.Hint("OptiFine 与自动进入服务器可能不兼容，有概率导致材质丢失甚至游戏崩溃！", ModMain.HintType.Critical, true);
				}
			}
			string text3 = Conversions.ToString(ModBase._BaseRule.Get("VersionAdvanceGame", ModMinecraft.ValidateContainer()));
			text = Conversions.ToString(Operators.AddObject(text, Operators.ConcatenateObject(" ", (Operators.CompareString(text3, "", true) == 0) ? ModBase._BaseRule.Get("LaunchAdvanceGame", null) : text3)));
			ModLaunch.McLaunchLog("Minecraft 启动参数：");
			ModLaunch.McLaunchLog(text.Replace(ModLaunch._InfoIterator.Output.listenerAlgo, ModLaunch._InfoIterator.Output.listenerAlgo.Substring(0, 0x16) + "********" + ModLaunch._InfoIterator.Output.listenerAlgo.Substring(0x1E)));
			ModLaunch._StubIterator = text;
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x00045894 File Offset: 0x00043A94
		private static string McLaunchArgumentsJvmOld(ModMinecraft.McVersion Version)
		{
			List<string> list = new List<string>();
			list.Add("-XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump");
			string text = Conversions.ToString(ModBase._BaseRule.Get("VersionAdvanceJvm", ModMinecraft.ValidateContainer()));
			list.Insert(0, Conversions.ToString((Operators.CompareString(text, "", true) == 0) ? ModBase._BaseRule.Get("LaunchAdvanceJvm", null) : text));
			list.Add("-Xmn256m");
			list.Add("-Xmx" + Conversions.ToString(Math.Floor(PageVersionSetup.GetRam(ModMinecraft.ValidateContainer()) * 1024.0)) + "m");
			list.Add("\"-Djava.library.path=" + Version.Path + Version.Name + "-natives\"");
			list.Add("-cp ${classpath}");
			if (Operators.CompareString(ModLaunch._InfoIterator.Output.Type, "Nide", true) == 0)
			{
				list.Insert(0, Conversions.ToString(Operators.ConcatenateObject("-Dnide8auth.client=true -javaagent:nide8auth.jar=", ModBase._BaseRule.Get("VersionServerNide", ModMinecraft.ValidateContainer()))));
			}
			if (Operators.CompareString(ModLaunch._InfoIterator.Output.Type, "Auth", true) == 0)
			{
				string text2 = Conversions.ToString(ModBase._BaseRule.Get("VersionServerAuthServer", ModMinecraft.ValidateContainer()));
				string s = Conversions.ToString(ModNet.NetGetCodeByRequestRetry(text2, Encoding.UTF8, "", false));
				list.Insert(0, "-javaagent:authlib-injector.jar=" + text2 + " -Dauthlibinjector.side=client -Dauthlibinjector.yggdrasil.prefetched=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(s)));
			}
			if (Version.VerifyUtils()["mainClass"] == null)
			{
				throw new Exception("版本 Json 中没有 mainClass 项！");
			}
			list.Add((string)Version.VerifyUtils()["mainClass"]);
			return ModBase.Join(list, " ");
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x00045A60 File Offset: 0x00043C60
		private static string McLaunchArgumentsJvmNew(ModMinecraft.McVersion Version)
		{
			object[] object_ = new object[]
			{
				Version
			};
			return (string)new GClass18().method_112(object_, 0xB0256);
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x00045A94 File Offset: 0x00043C94
		private static string McLaunchArgumentsGameOld(ModMinecraft.McVersion Version)
		{
			List<string> list = new List<string>();
			string text = Version.VerifyUtils()["minecraftArguments"].ToString();
			if (!text.Contains("--height"))
			{
				text += " --height ${resolution_height} --width ${resolution_width}";
			}
			list.Add(text);
			string text2 = ModBase.Join(list, " ");
			if ((Version.Version.messageAlgo || Version.Version.m_ValMapper) && Version.Version.m_ComposerAlgo)
			{
				if (text2.Contains("--tweakClass optifine.OptiFineForgeTweaker"))
				{
					ModBase.Log("[Launch] 发现正确的 OptiFineForge TweakClass，目前参数：" + text2, ModBase.LogLevel.Normal, "出现错误");
					text2 = text2.Replace(" --tweakClass optifine.OptiFineForgeTweaker", "").Replace("--tweakClass optifine.OptiFineForgeTweaker ", "") + " --tweakClass optifine.OptiFineForgeTweaker";
				}
				if (text2.Contains("--tweakClass optifine.OptiFineTweaker"))
				{
					ModBase.Log("[Launch] 发现错误的 OptiFineForge TweakClass，目前参数：" + text2, ModBase.LogLevel.Normal, "出现错误");
					text2 = text2.Replace(" --tweakClass optifine.OptiFineTweaker", "").Replace("--tweakClass optifine.OptiFineTweaker ", "") + " --tweakClass optifine.OptiFineForgeTweaker";
					try
					{
						ModBase.WriteFile(Version.Path + Version.Name + ".json", ModBase.ReadFile(Version.Path + Version.Name + ".json").Replace("optifine.OptiFineTweaker", "optifine.OptiFineForgeTweaker"), false, null);
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "替换 OptiFineForge TweakClass 失败", ModBase.LogLevel.Debug, "出现错误");
					}
				}
			}
			return text2;
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x00045C2C File Offset: 0x00043E2C
		private static string McLaunchArgumentsGameNew(ModMinecraft.McVersion Version)
		{
			List<string> list = new List<string>();
			ModMinecraft.McVersion mcVersion = Version;
			for (;;)
			{
				if (mcVersion.VerifyUtils()["arguments"] != null && mcVersion.VerifyUtils()["arguments"]["game"] != null)
				{
					try
					{
						foreach (JToken jtoken in ((IEnumerable<JToken>)mcVersion.VerifyUtils()["arguments"]["game"]))
						{
							if (jtoken.Type == JTokenType.String)
							{
								list.Add(jtoken.ToString());
							}
							else if (ModMinecraft.McJsonRuleCheck(jtoken["rules"]))
							{
								if (jtoken["value"].Type == JTokenType.String)
								{
									list.Add(jtoken["value"].ToString());
								}
								else
								{
									try
									{
										foreach (JToken jtoken2 in ((IEnumerable<JToken>)jtoken["value"]))
										{
											list.Add(jtoken2.ToString());
										}
									}
									finally
									{
										IEnumerator<JToken> enumerator2;
										if (enumerator2 != null)
										{
											enumerator2.Dispose();
										}
									}
								}
							}
						}
						goto IL_0D;
					}
					finally
					{
						IEnumerator<JToken> enumerator;
						if (enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					continue;
				}
				IL_0D:
				if (Operators.CompareString(mcVersion.PrintUtils(), "", true) == 0)
				{
					break;
				}
				mcVersion = new ModMinecraft.McVersion(mcVersion.PrintUtils());
			}
			List<string> list2 = new List<string>();
			checked
			{
				int num = list.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string text = list[i];
					if (list[i].StartsWith("-"))
					{
						while (i < list.Count - 1 && !list[i + 1].StartsWith("-"))
						{
							i++;
							text = text + " " + list[i];
						}
					}
					list2.Add(text);
				}
				string text2 = ModBase.Join(ModBase.ArrayNoDouble<string>(list2, null), " ");
				if ((Version.Version.messageAlgo || Version.Version.m_ValMapper) && Version.Version.m_ComposerAlgo)
				{
					if (text2.Contains("--tweakClass optifine.OptiFineForgeTweaker"))
					{
						ModBase.Log("[Launch] 发现正确的 OptiFineForge TweakClass，目前参数：" + text2, ModBase.LogLevel.Normal, "出现错误");
						text2 = text2.Replace(" --tweakClass optifine.OptiFineForgeTweaker", "").Replace("--tweakClass optifine.OptiFineForgeTweaker ", "") + " --tweakClass optifine.OptiFineForgeTweaker";
					}
					if (text2.Contains("--tweakClass optifine.OptiFineTweaker"))
					{
						ModBase.Log("[Launch] 发现错误的 OptiFineForge TweakClass，目前参数：" + text2, ModBase.LogLevel.Normal, "出现错误");
						text2 = text2.Replace(" --tweakClass optifine.OptiFineTweaker", "").Replace("--tweakClass optifine.OptiFineTweaker ", "") + " --tweakClass optifine.OptiFineForgeTweaker";
						try
						{
							ModBase.WriteFile(Version.Path + Version.Name + ".json", ModBase.ReadFile(Version.Path + Version.Name + ".json").Replace("optifine.OptiFineTweaker", "optifine.OptiFineForgeTweaker"), false, null);
						}
						catch (Exception ex)
						{
							ModBase.Log(ex, "替换 OptiFineForge TweakClass 失败", ModBase.LogLevel.Debug, "出现错误");
						}
					}
				}
				return text2;
			}
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x00045F88 File Offset: 0x00044188
		private static Dictionary<string, string> McLaunchArgumentsReplace(ModMinecraft.McVersion Version, ref ModLoader.LoaderTask<string, List<ModMinecraft.McLibToken>> Loader)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("${classpath_separator}", ";");
			dictionary.Add("${natives_directory}", Version.Path + Version.Name + "-natives");
			dictionary.Add("${library_directory}", ModMinecraft.m_ResolverIterator + "libraries");
			dictionary.Add("${libraries_directory}", ModMinecraft.m_ResolverIterator + "libraries");
			dictionary.Add("${launcher_name}", "PCL2");
			dictionary.Add("${launcher_version}", Conversions.ToString(0xEA));
			dictionary.Add("${version_name}", Version.Name);
			string text = Conversions.ToString(ModBase._BaseRule.Get("VersionArgumentInfo", ModMinecraft.ValidateContainer()));
			dictionary.Add("${version_type}", Conversions.ToString((Operators.CompareString(text, "", true) == 0) ? ModBase._BaseRule.Get("LaunchArgumentInfo", null) : text));
			checked
			{
				dictionary.Add("${game_directory}", Strings.Left(ModMinecraft.ValidateContainer().ManageExpression(), ModMinecraft.ValidateContainer().ManageExpression().Count<char>() - 1));
				dictionary.Add("${assets_root}", ModMinecraft.m_ResolverIterator + "assets");
				dictionary.Add("${user_properties}", "{}");
				dictionary.Add("${auth_player_name}", ModLaunch._InfoIterator.Output.Name);
				dictionary.Add("${auth_uuid}", ModLaunch._InfoIterator.Output.processAlgo);
				dictionary.Add("${auth_access_token}", ModLaunch._InfoIterator.Output.listenerAlgo);
				dictionary.Add("${access_token}", ModLaunch._InfoIterator.Output.listenerAlgo);
				dictionary.Add("${auth_session}", ModLaunch._InfoIterator.Output.listenerAlgo);
				dictionary.Add("${user_type}", (Operators.CompareString(ModLaunch._InfoIterator.Output.Type, "Legacy", true) == 0) ? "Legacy" : "Mojang");
				System.Windows.Size launchArgumentWindowSize = ModBase._BaseRule.GetLaunchArgumentWindowSize();
				dictionary.Add("${resolution_width}", Conversions.ToString(launchArgumentWindowSize.Width));
				dictionary.Add("${resolution_height}", Conversions.ToString(launchArgumentWindowSize.Height));
				dictionary.Add("${game_assets}", ModMinecraft.m_ResolverIterator + "assets\\virtual\\legacy");
				dictionary.Add("${assets_index_name}", ModMinecraft.McAssetsGetIndexName(Version));
				List<ModMinecraft.McLibToken> list = ModMinecraft.McLibListGet(Version, !Version.Version.messageAlgo || Version.Version.clientAlgo < 0x11);
				Loader.Output = list;
				List<string> list2 = new List<string>();
				string text2 = null;
				try
				{
					foreach (ModMinecraft.McLibToken mcLibToken in list)
					{
						if (!mcLibToken.m_DecoratorMapper)
						{
							if (mcLibToken.Name != null && Operators.CompareString(mcLibToken.Name, "optifine:OptiFine", true) == 0)
							{
								text2 = mcLibToken.m_UtilsMapper;
							}
							else
							{
								list2.Add(mcLibToken.m_UtilsMapper);
							}
						}
					}
				}
				finally
				{
					List<ModMinecraft.McLibToken>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				if (text2 != null)
				{
					list2.Insert(list2.Count - 2, text2);
				}
				dictionary.Add("${classpath}", ModBase.Join(list2, ";"));
				return dictionary;
			}
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x000462D0 File Offset: 0x000444D0
		private static void McLaunchNatives(ModLoader.LoaderTask<List<ModMinecraft.McLibToken>, int> Loader)
		{
			Directory.CreateDirectory(ModMinecraft.ValidateContainer().Path + ModMinecraft.ValidateContainer().Name + "-natives");
			ModLaunch.McLaunchLog("正在解压 Natives 文件");
			List<string> list = new List<string>();
			try
			{
				foreach (ModMinecraft.McLibToken mcLibToken in Loader.Input)
				{
					if (mcLibToken.m_DecoratorMapper)
					{
						ZipArchive zipArchive = new ZipArchive(new FileStream(mcLibToken.m_UtilsMapper, FileMode.Open));
						try
						{
							foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
							{
								string fullName = zipArchiveEntry.FullName;
								if (fullName.EndsWith(".dll"))
								{
									string text = ModMinecraft.ValidateContainer().Path + ModMinecraft.ValidateContainer().Name + "-natives\\" + fullName;
									list.Add(text);
									FileInfo fileInfo = new FileInfo(text);
									if (fileInfo.Exists)
									{
										if (fileInfo.Length == zipArchiveEntry.Length)
										{
											if (ModBase.errorRule)
											{
												ModLaunch.McLaunchLog("无需解压：" + text);
												continue;
											}
											continue;
										}
										else
										{
											try
											{
												File.Delete(text);
											}
											catch (UnauthorizedAccessException ex)
											{
												ModLaunch.McLaunchLog("删除原 dll 访问被拒绝，这通常代表有一个 MC 正在运行，跳过解压：" + text);
												ModLaunch.McLaunchLog("实际的错误信息：" + ModBase.GetString(ex, true, false));
												break;
											}
										}
									}
									ModBase.WriteFile(text, zipArchiveEntry.Open());
									ModLaunch.McLaunchLog("已解压：" + text);
								}
							}
							goto IL_190;
						}
						finally
						{
							IEnumerator<ZipArchiveEntry> enumerator2;
							if (enumerator2 != null)
							{
								enumerator2.Dispose();
							}
						}
						IL_185:
						zipArchive.Dispose();
						continue;
						IL_190:
						if (zipArchive != null)
						{
							goto IL_185;
						}
					}
				}
			}
			finally
			{
				List<ModMinecraft.McLibToken>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			foreach (string text2 in Directory.GetFiles(ModMinecraft.ValidateContainer().Path + ModMinecraft.ValidateContainer().Name + "-natives"))
			{
				if (!list.Contains(text2))
				{
					try
					{
						ModLaunch.McLaunchLog("删除：" + text2);
						File.Delete(text2);
					}
					catch (UnauthorizedAccessException ex2)
					{
						ModLaunch.McLaunchLog("删除多余文件访问被拒绝，跳过删除步骤");
						ModLaunch.McLaunchLog("实际的错误信息：" + ModBase.GetString(ex2, true, false));
						break;
					}
				}
			}
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x00046580 File Offset: 0x00044780
		private static void McLaunchPrerun()
		{
			try
			{
				if (Operators.CompareString(ModLaunch._InfoIterator.Output.Type, "Mojang", true) == 0 || Operators.CompareString(ModLaunch._InfoIterator.Output.Type, "Microsoft", true) == 0)
				{
					ModMinecraft.McFolderLauncherProfilesJsonCreate(ModMinecraft.m_ResolverIterator);
					JObject content = (JObject)ModBase.GetJson(string.Concat(new string[]
					{
						"\r\n            {\r\n              \"authenticationDatabase\": {\r\n                \"00000111112222233333444445555566\": {\r\n                  \"accessToken\": \"",
						ModLaunch._InfoIterator.Output.listenerAlgo,
						"\",\r\n                  \"username\": \"",
						(ModLaunch._InfoIterator.Output._TemplateAlgo ?? ModLaunch._InfoIterator.Output.Name).Replace("\"", "-"),
						"\",\r\n                  \"profiles\": {\r\n                    \"66666555554444433333222221111100\": {\r\n                        \"displayName\": \"",
						ModLaunch._InfoIterator.Output.Name,
						"\"\r\n                    }\r\n                  }\r\n                }\r\n              },\r\n              \"clientToken\": \"",
						ModLaunch._InfoIterator.Output._ImporterAlgo,
						"\",\r\n              \"selectedUser\": {\r\n                \"account\": \"00000111112222233333444445555566\", \r\n                \"profile\": \"66666555554444433333222221111100\"\r\n              }\r\n            }"
					}));
					JObject jobject = (JObject)ModBase.GetJson(ModBase.ReadFile(ModMinecraft.m_ResolverIterator + "launcher_profiles.json"));
					jobject.Merge(content);
					ModBase.WriteFile(ModMinecraft.m_ResolverIterator + "launcher_profiles.json", jobject.ToString(), false, Encoding.Default);
					ModLaunch.McLaunchLog("已更新 launcher_profiles.json");
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "更新 launcher_profiles.json 失败，将在删除文件后重试", ModBase.LogLevel.Debug, "出现错误");
				try
				{
					File.Delete(ModMinecraft.m_ResolverIterator + "launcher_profiles.json");
					ModMinecraft.McFolderLauncherProfilesJsonCreate(ModMinecraft.m_ResolverIterator);
					JObject content2 = (JObject)ModBase.GetJson(string.Concat(new string[]
					{
						"\r\n                    {\r\n                      \"authenticationDatabase\": {\r\n                        \"00000111112222233333444445555566\": {\r\n                          \"accessToken\": \"",
						ModLaunch._InfoIterator.Output.listenerAlgo,
						"\",\r\n                          \"username\": \"",
						(ModLaunch._InfoIterator.Output._TemplateAlgo ?? ModLaunch._InfoIterator.Output.Name).Replace("\"", "-"),
						"\",\r\n                          \"profiles\": {\r\n                            \"66666555554444433333222221111100\": {\r\n                                \"displayName\": \"",
						ModLaunch._InfoIterator.Output.Name,
						"\"\r\n                            }\r\n                          }\r\n                        }\r\n                      },\r\n                      \"clientToken\": \"",
						ModLaunch._InfoIterator.Output._ImporterAlgo,
						"\",\r\n                      \"selectedUser\": {\r\n                        \"account\": \"00000111112222233333444445555566\", \r\n                        \"profile\": \"66666555554444433333222221111100\"\r\n                      }\r\n                    }"
					}));
					JObject jobject2 = (JObject)ModBase.GetJson(ModBase.ReadFile(ModMinecraft.m_ResolverIterator + "launcher_profiles.json"));
					jobject2.Merge(content2);
					ModBase.WriteFile(ModMinecraft.m_ResolverIterator + "launcher_profiles.json", jobject2.ToString(), false, Encoding.Default);
					ModLaunch.McLaunchLog("已在删除后更新 launcher_profiles.json");
				}
				catch (Exception ex2)
				{
					ModBase.Log(ex2, "更新 launcher_profiles.json 失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}
			string text = ModMinecraft.ValidateContainer().ManageExpression() + "options.txt";
			try
			{
				if (Conversions.ToBoolean(ModBase._BaseRule.Get("ToolHelpChinese", null)))
				{
					if (File.Exists(text) && Directory.Exists(ModMinecraft.ValidateContainer().ManageExpression() + "saves"))
					{
						ModLaunch.McLaunchLog("并非首次启动，不修改语言");
					}
					else
					{
						ModLaunch.McLaunchLog("已根据设置自动修改语言为中文");
						ModBase.WriteIni(text, "lang", "-");
						if (ModMinecraft.ValidateContainer().Version.clientAlgo >= 0xC)
						{
							ModBase.WriteIni(text, "lang", "zh_cn");
						}
						else
						{
							ModBase.WriteIni(text, "lang", "zh_CN");
						}
						ModBase.WriteIni(text, "forceUnicodeFont", "true");
					}
				}
				ModBase.WriteIni(text, "fullscreen", Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LaunchArgumentWindowType", null), 0, true) ? "true" : "false");
			}
			catch (Exception ex3)
			{
				ModBase.Log(ex3, "更新 options.txt 失败", ModBase.LogLevel.Hint, "出现错误");
			}
			try
			{
				if (Conversions.ToBoolean(ModMinecraft.ValidateContainer().Version.clientAlgo <= 7 && ModMinecraft.ValidateContainer().Version.clientAlgo >= 2 && ModLaunch._InfoIterator.Input.Type == ModLaunch.McLoginType.Legacy && (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LaunchSkinType", null), 2, true) || (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LaunchSkinType", null), 4, true) && Conversions.ToBoolean(ModBase._BaseRule.Get("LaunchSkinSlim", null))))))
				{
					ModMain.Hint("此 Minecraft 版本尚不支持 Alex 皮肤，你的皮肤可能会显示为 Steve！", ModMain.HintType.Critical, true);
				}
			}
			catch (Exception ex4)
			{
				ModBase.Log(ex4, "检查离线皮肤失效失败", ModBase.LogLevel.Debug, "出现错误");
			}
			try
			{
				Directory.CreateDirectory(ModMinecraft.ValidateContainer().ManageExpression() + "resourcepacks\\");
				string path = ModMinecraft.ValidateContainer().ManageExpression() + "resourcepacks\\PCL2 Skin.zip";
				bool flag = ModMinecraft.ValidateContainer().Version.clientAlgo >= 0xD || ModMinecraft.ValidateContainer().Version.clientAlgo < 6;
				if (ModLaunch._InfoIterator.Input.Type == ModLaunch.McLoginType.Legacy && Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LaunchSkinType", null), 4, true) && File.Exists(ModBase.m_GlobalRule + "CustomSkin.png"))
				{
					Directory.CreateDirectory(ModBase.m_GlobalRule);
					string text2 = ModBase.m_GlobalRule + "pack.mcmeta";
					string text3 = ModBase.m_GlobalRule + "pack.png";
					int value;
					switch (ModMinecraft.ValidateContainer().Version.clientAlgo)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
						ModLaunch.McLaunchLog("Minecraft 版本过老，尚不支持自定义离线皮肤");
						goto IL_A25;
					case 6:
					case 7:
					case 8:
						value = 1;
						break;
					case 9:
					case 0xA:
						value = 2;
						break;
					case 0xB:
					case 0xC:
						value = 3;
						break;
					case 0xD:
					case 0xE:
						value = 4;
						break;
					case 0xF:
						value = 5;
						break;
					case 0x10:
						value = 6;
						break;
					default:
						value = 7;
						break;
					}
					ModLaunch.McLaunchLog("正在构建自定义皮肤资源包，格式为：" + Conversions.ToString(value));
					new ModBitmap.MyBitmap(ModBase.m_ExpressionRule + "Heads/Logo.png").Save(text3);
					ModBase.WriteFile(text2, "{\"pack\":{\"pack_format\":" + Conversions.ToString(value) + ",\"description\":\"PCL2 自定义离线皮肤资源包\"}}", false, null);
					ModBitmap.MyBitmap myBitmap = new ModBitmap.MyBitmap(ModBase.m_GlobalRule + "CustomSkin.png");
					if ((ModMinecraft.ValidateContainer().Version.clientAlgo == 6 || ModMinecraft.ValidateContainer().Version.clientAlgo == 7) && myBitmap.requestMapper.Height == 0x40)
					{
						ModLaunch.McLaunchLog("该 Minecraft 版本不支持双层皮肤，已进行裁剪");
						myBitmap = myBitmap.Clip(new Rectangle(0, 0, 0x40, 0x20));
					}
					myBitmap.Save(ModBase.Path + "PCL\\CustomSkin_Cliped.png");
					using (FileStream fileStream = new FileStream(path, FileMode.Create))
					{
						using (ZipArchive zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create))
						{
							zipArchive.CreateEntryFromFile(text2, "pack.mcmeta");
							zipArchive.CreateEntryFromFile(text3, "pack.png");
							zipArchive.CreateEntryFromFile(ModBase.Path + "PCL\\CustomSkin_Cliped.png", "assets/minecraft/textures/entity/" + (Conversions.ToBoolean(ModBase._BaseRule.Get("LaunchSkinSlim", null)) ? "alex.png" : "steve.png"));
						}
					}
					File.Delete(ModBase.Path + "PCL\\CustomSkin_Cliped.png");
					ModBase.IniClearCache(text);
					string text4 = ModBase.ReadIni(text, "resourcePacks", "[]").TrimStart(new char[]
					{
						'['
					}).TrimEnd(new char[]
					{
						']'
					});
					if (flag)
					{
						if (Operators.CompareString(text4, "", true) == 0)
						{
							text4 = "\"vanilla\"";
						}
						List<string> list = new List<string>(text4.Split(new char[]
						{
							','
						}));
						List<string> list2 = new List<string>();
						try
						{
							foreach (string text5 in list)
							{
								if (Operators.CompareString(text5, "\"file/PCL2 Skin.zip\"", true) != 0 && Operators.CompareString(text5, "", true) != 0)
								{
									list2.Add(text5);
								}
							}
						}
						finally
						{
							List<string>.Enumerator enumerator;
							((IDisposable)enumerator).Dispose();
						}
						list2.Add("\"file/PCL2 Skin.zip\"");
						string value2 = "[" + ModBase.Join(list2, ",") + "]";
						ModBase.WriteIni(text, "resourcePacks", value2);
					}
					else
					{
						List<string> list3 = new List<string>(text4.Split(new char[]
						{
							','
						}));
						List<string> list4 = new List<string>();
						try
						{
							foreach (string text6 in list3)
							{
								if (Operators.CompareString(text6, "\"PCL2 Skin.zip\"", true) != 0 && Operators.CompareString(text6, "", true) != 0)
								{
									list4.Add(text6);
								}
							}
						}
						finally
						{
							List<string>.Enumerator enumerator2;
							((IDisposable)enumerator2).Dispose();
						}
						list4.Add("\"PCL2 Skin.zip\"");
						string value3 = "[" + ModBase.Join(list4, ",") + "]";
						ModBase.WriteIni(text, "resourcePacks", value3);
					}
				}
				else if (File.Exists(path))
				{
					ModLaunch.McLaunchLog("正在清空自定义皮肤资源包");
					File.Delete(path);
					ModBase.IniClearCache(text);
					string text7 = ModBase.ReadIni(text, "resourcePacks", "[]").TrimStart(new char[]
					{
						'['
					}).TrimEnd(new char[]
					{
						']'
					});
					if (flag)
					{
						if (Operators.CompareString(text7, "", true) == 0)
						{
							text7 = "\"vanilla\"";
						}
						List<string> list5 = new List<string>(text7.Split(new char[]
						{
							','
						}));
						list5.Remove("\"file/PCL2 Skin.zip\"");
						string value4 = "[" + ModBase.Join(list5, ",") + "]";
						ModBase.WriteIni(text, "resourcePacks", value4);
					}
					else
					{
						List<string> list6 = new List<string>(text7.Split(new char[]
						{
							','
						}));
						list6.Remove("\"PCL2 Skin.zip\"");
						string value5 = "[" + ModBase.Join(list6, ",") + "]";
						ModBase.WriteIni(text, "resourcePacks", value5);
					}
				}
				IL_A25:;
			}
			catch (Exception ex5)
			{
				ModBase.Log(ex5, "离线皮肤资源包设置失败", ModBase.LogLevel.Hint, "出现错误");
			}
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x000470B4 File Offset: 0x000452B4
		private static void McLaunchRun(ModLoader.LoaderTask<int, Process> Loader)
		{
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo(ModLaunch.parameterIterator.DisableExpression());
			if (processStartInfo.EnvironmentVariables.ContainsKey("appdata"))
			{
				processStartInfo.EnvironmentVariables["appdata"] = ModMinecraft.m_ResolverIterator;
			}
			else
			{
				processStartInfo.EnvironmentVariables.Add("appdata", ModMinecraft.m_ResolverIterator);
			}
			List<string> list = new List<string>(processStartInfo.EnvironmentVariables["Path"].Split(new char[]
			{
				';'
			}));
			list.Add(ModLaunch.parameterIterator.m_AnnotationAlgo);
			processStartInfo.EnvironmentVariables["Path"] = ModBase.Join(ModBase.ArrayNoDouble<string>(list, null), ";");
			processStartInfo.WorkingDirectory = ModMinecraft.ValidateContainer().ManageExpression();
			processStartInfo.UseShellExecute = false;
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.RedirectStandardError = true;
			processStartInfo.CreateNoWindow = false;
			processStartInfo.Arguments = ModLaunch._StubIterator;
			process.StartInfo = processStartInfo;
			process.Start();
			ModLaunch.McLaunchLog("已启动游戏进程");
			Loader.Output = process;
			ModLaunch.itemIterator = process;
			try
			{
				string text = string.Concat(new string[]
				{
					"@echo off\r\ntitle 启动 - ",
					ModMinecraft.ValidateContainer().Name,
					"\r\necho 游戏正在启动，请稍候。\r\nset APPDATA=\"",
					ModMinecraft.m_ResolverIterator,
					"\"\r\ncd /D \"",
					ModMinecraft.m_ResolverIterator,
					"\"\r\n\"",
					ModLaunch.parameterIterator.AwakeExpression(),
					"\" ",
					ModLaunch._StubIterator,
					"\r\necho 游戏已退出。\r\npause"
				});
				ModBase.WriteFile(ModBase.Path + "PCL\\LatestLaunch.bat", text, false, Encoding.Default);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "输出启动脚本失败", ModBase.LogLevel.Debug, "出现错误");
			}
			try
			{
				if (!process.HasExited)
				{
					process.PriorityBoostEnabled = true;
					object left = ModBase._BaseRule.Get("LaunchArgumentPriority", null);
					if (Operators.ConditionalCompareObjectEqual(left, 0, true))
					{
						process.PriorityClass = ProcessPriorityClass.AboveNormal;
					}
					else if (Operators.ConditionalCompareObjectEqual(left, 2, true))
					{
						process.PriorityClass = ProcessPriorityClass.BelowNormal;
					}
				}
			}
			catch (Exception ex2)
			{
				ModBase.Log(ex2, "设置进程优先级失败", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x00047314 File Offset: 0x00045514
		private static void McLaunchWait(ModLoader.LoaderTask<Process, int> Loader)
		{
			ModLaunch.McLaunchLog("");
			ModLaunch.McLaunchLog("~ 基础参数 ~");
			ModLaunch.McLaunchLog("PCL2 版本：Snapshot 2.2.3 (" + Conversions.ToString(0xEA) + ")");
			ModLaunch.McLaunchLog(string.Concat(new string[]
			{
				"游戏版本：",
				ModMinecraft.ValidateContainer().Version.ToString(),
				"（",
				Conversions.ToString(ModMinecraft.ValidateContainer().Version.clientAlgo),
				"）"
			}));
			ModLaunch.McLaunchLog("资源版本：" + ModMinecraft.McAssetsGetIndexName(ModMinecraft.ValidateContainer()));
			ModLaunch.McLaunchLog("版本继承：" + ((Operators.CompareString(ModMinecraft.ValidateContainer().PrintUtils(), "", true) == 0) ? "无" : ModMinecraft.ValidateContainer().PrintUtils()));
			ModLaunch.McLaunchLog(string.Concat(new string[]
			{
				"分配的内存：",
				Conversions.ToString(PageVersionSetup.GetRam(ModMinecraft.ValidateContainer())),
				" GB（",
				Conversions.ToString(Math.Round(PageVersionSetup.GetRam(ModMinecraft.ValidateContainer()) * 1024.0)),
				" MB）"
			}));
			ModLaunch.McLaunchLog("MC 文件夹：" + ModMinecraft.m_ResolverIterator);
			ModLaunch.McLaunchLog("版本文件夹：" + ModMinecraft.ValidateContainer().Path);
			ModLaunch.McLaunchLog("版本隔离：" + Conversions.ToString(Operators.CompareString(ModMinecraft.ValidateContainer().ManageExpression(), ModMinecraft.ValidateContainer().Path, true) == 0));
			ModLaunch.McLaunchLog("HMCL 格式：" + Conversions.ToString(ModMinecraft.ValidateContainer().FindUtils()));
			ModLaunch.McLaunchLog("Java 信息：" + ((ModLaunch.parameterIterator != null) ? ModLaunch.parameterIterator.ToString() : "无可用 Java"));
			ModLaunch.McLaunchLog("环境变量：" + ((ModLaunch.parameterIterator != null) ? (ModLaunch.parameterIterator.CloneExpression() ? "已设置" : "未设置") : "未设置"));
			ModLaunch.McLaunchLog("");
			ModLaunch.McLaunchLog("~ 登录参数 ~");
			ModLaunch.McLaunchLog("玩家用户名：" + ModLaunch._InfoIterator.Output.Name);
			ModLaunch.McLaunchLog("AccessToken：" + ModLaunch._InfoIterator.Output.listenerAlgo.Substring(0, 0x16) + "********" + ModLaunch._InfoIterator.Output.listenerAlgo.Substring(0x1E));
			ModLaunch.McLaunchLog("ClientToken：" + ModLaunch._InfoIterator.Output._ImporterAlgo);
			ModLaunch.McLaunchLog("UUID：" + ModLaunch._InfoIterator.Output.processAlgo);
			ModLaunch.McLaunchLog("登录方式：" + ModLaunch._InfoIterator.Output.Type);
			ModLaunch.McLaunchLog("");
			string text = Conversions.ToString(ModBase._BaseRule.Get("VersionArgumentTitle", ModMinecraft.ValidateContainer()));
			if (Operators.CompareString(text, "", true) == 0)
			{
				text = Conversions.ToString(ModBase._BaseRule.Get("LaunchArgumentTitle", null));
			}
			text = ModMinecraft.ArgumentReplace(text);
			ModWatcher.Watcher watcher = new ModWatcher.Watcher(Loader, ModMinecraft.ValidateContainer(), text);
			ModLaunch.serializerIterator = watcher;
			while (watcher.State == ModWatcher.Watcher.MinecraftState.Loading)
			{
				Thread.Sleep(0x64);
			}
			if (watcher.State == ModWatcher.Watcher.MinecraftState.Crashed)
			{
				throw new Exception("$$");
			}
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x0004767C File Offset: 0x0004587C
		private static void McLaunchEnd()
		{
			ModLaunch.McLaunchLog("开始启动结束处理");
			if (Conversions.ToBoolean(ModBase._BaseRule.Get("UiMusicStop", null)))
			{
				ModBase.RunInUi((ModLaunch._Closure$__.$I52-0 == null) ? (ModLaunch._Closure$__.$I52-0 = delegate()
				{
					if (ModMusic.MusicPause())
					{
						ModBase.Log("[Music] 已根据设置，在启动后暂停音乐播放", ModBase.LogLevel.Normal, "出现错误");
					}
				}) : ModLaunch._Closure$__.$I52-0, false);
			}
			else if (Conversions.ToBoolean(ModBase._BaseRule.Get("UiMusicStart", null)))
			{
				ModBase.RunInUi((ModLaunch._Closure$__.$I52-1 == null) ? (ModLaunch._Closure$__.$I52-1 = delegate()
				{
					if (ModMusic.MusicResume())
					{
						ModBase.Log("[Music] 已根据设置，在启动后开始音乐播放", ModBase.LogLevel.Normal, "出现错误");
					}
				}) : ModLaunch._Closure$__.$I52-1, false);
			}
			ModLaunch.McLaunchLog(Conversions.ToString(Operators.ConcatenateObject("启动器可见性：", ModBase._BaseRule.Get("LaunchArgumentVisible", null))));
			object left = ModBase._BaseRule.Get("LaunchArgumentVisible", null);
			if (Operators.ConditionalCompareObjectEqual(left, 0, true))
			{
				ModLaunch.McLaunchLog("已根据设置，在启动后关闭启动器");
				ModBase.RunInUi((ModLaunch._Closure$__.$I52-2 == null) ? (ModLaunch._Closure$__.$I52-2 = delegate()
				{
					ModMain.m_GetterFilter.EndProgram(false);
				}) : ModLaunch._Closure$__.$I52-2, false);
			}
			else if (Conversions.ToBoolean(Conversions.ToBoolean(Operators.CompareObjectEqual(left, 2, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, 3, true))))
			{
				ModLaunch.McLaunchLog("已根据设置，在启动后隐藏启动器");
				ModBase.RunInUi((ModLaunch._Closure$__.$I52-3 == null) ? (ModLaunch._Closure$__.$I52-3 = delegate()
				{
					ModMain.m_GetterFilter.Hidden = true;
				}) : ModLaunch._Closure$__.$I52-3, false);
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 4, true))
			{
				ModLaunch.McLaunchLog("已根据设置，在启动后最小化启动器");
				ModBase.RunInUi((ModLaunch._Closure$__.$I52-4 == null) ? (ModLaunch._Closure$__.$I52-4 = delegate()
				{
					ModMain.m_GetterFilter.WindowState = WindowState.Minimized;
				}) : ModLaunch._Closure$__.$I52-4, false);
			}
			else
			{
				Operators.ConditionalCompareObjectEqual(left, 5, true);
			}
			ModBase._BaseRule.Set("SystemLaunchCount", Operators.AddObject(ModBase._BaseRule.Get("SystemLaunchCount", null), 1), false, null);
		}

		// Token: 0x04000491 RID: 1169
		public static ModLoader.LoaderTask<string, object> m_ThreadIterator;

		// Token: 0x04000492 RID: 1170
		public static ModLoader.LoaderCombo<object> m_ManagerIterator;

		// Token: 0x04000493 RID: 1171
		public static Process itemIterator;

		// Token: 0x04000494 RID: 1172
		public static ModWatcher.Watcher serializerIterator;

		// Token: 0x04000495 RID: 1173
		public static ModLoader.LoaderTask<ModLaunch.McLoginData, ModLaunch.McLoginResult> _InfoIterator;

		// Token: 0x04000496 RID: 1174
		public static ModLoader.LoaderTask<ModLaunch.McLoginServer, ModLaunch.McLoginResult> repositoryIterator;

		// Token: 0x04000497 RID: 1175
		public static ModLoader.LoaderTask<ModLaunch.McLoginMs, ModLaunch.McLoginResult> systemIterator;

		// Token: 0x04000498 RID: 1176
		public static ModLoader.LoaderTask<ModLaunch.McLoginLegacy, ModLaunch.McLoginResult> _ProccesorIterator;

		// Token: 0x04000499 RID: 1177
		public static ModLoader.LoaderTask<ModLaunch.McLoginServer, ModLaunch.McLoginResult> _PrototypeIterator;

		// Token: 0x0400049A RID: 1178
		public static ModLoader.LoaderTask<ModLaunch.McLoginServer, ModLaunch.McLoginResult> _RefIterator;

		// Token: 0x0400049B RID: 1179
		private static ModMinecraft.JavaEntry parameterIterator;

		// Token: 0x0400049C RID: 1180
		private static string _StubIterator;

		// Token: 0x020000F0 RID: 240
		public enum McLoginType
		{
			// Token: 0x0400049E RID: 1182
			Legacy,
			// Token: 0x0400049F RID: 1183
			Mojang,
			// Token: 0x040004A0 RID: 1184
			Nide,
			// Token: 0x040004A1 RID: 1185
			Auth,
			// Token: 0x040004A2 RID: 1186
			Ms = 5
		}

		// Token: 0x020000F1 RID: 241
		public abstract class McLoginData
		{
			// Token: 0x06000888 RID: 2184 RVA: 0x00006913 File Offset: 0x00004B13
			public override bool Equals(object obj)
			{
				return obj != null && obj.GetHashCode() == this.GetHashCode();
			}

			// Token: 0x040004A3 RID: 1187
			public ModLaunch.McLoginType Type;
		}

		// Token: 0x020000F2 RID: 242
		public class McLoginServer : ModLaunch.McLoginData
		{
			// Token: 0x06000889 RID: 2185 RVA: 0x00006928 File Offset: 0x00004B28
			public McLoginServer(ModLaunch.McLoginType Type)
			{
				this.m_StateAlgo = false;
				this.Type = Type;
			}

			// Token: 0x0600088A RID: 2186 RVA: 0x00047880 File Offset: 0x00045A80
			public override int GetHashCode()
			{
				return Convert.ToInt32(decimal.Remainder(new decimal(ModBase.GetHash(string.Concat(new string[]
				{
					this._DispatcherAlgo,
					this._TagAlgo,
					this._InitializerAlgo,
					this.propertyAlgo,
					Conversions.ToString((int)this.Type)
				}))), 2147483647m));
			}

			// Token: 0x040004A4 RID: 1188
			public string _DispatcherAlgo;

			// Token: 0x040004A5 RID: 1189
			public string _TagAlgo;

			// Token: 0x040004A6 RID: 1190
			public string _InitializerAlgo;

			// Token: 0x040004A7 RID: 1191
			public string propertyAlgo;

			// Token: 0x040004A8 RID: 1192
			public string _WatcherAlgo;

			// Token: 0x040004A9 RID: 1193
			public bool m_StateAlgo;
		}

		// Token: 0x020000F3 RID: 243
		public class McLoginMs : ModLaunch.McLoginData
		{
			// Token: 0x0600088B RID: 2187 RVA: 0x0000693E File Offset: 0x00004B3E
			public McLoginMs()
			{
				this.creatorAlgo = "";
				this._PageAlgo = "";
				this.m_InstanceAlgo = "";
				this.testAlgo = "";
				this.Type = ModLaunch.McLoginType.Ms;
			}

			// Token: 0x0600088C RID: 2188 RVA: 0x000478EC File Offset: 0x00045AEC
			public override int GetHashCode()
			{
				return Convert.ToInt32(decimal.Remainder(new decimal(ModBase.GetHash(this.creatorAlgo + this._PageAlgo + this.m_InstanceAlgo + this.testAlgo)), 2147483647m));
			}

			// Token: 0x040004AA RID: 1194
			public string creatorAlgo;

			// Token: 0x040004AB RID: 1195
			public string _PageAlgo;

			// Token: 0x040004AC RID: 1196
			public string m_InstanceAlgo;

			// Token: 0x040004AD RID: 1197
			public string testAlgo;
		}

		// Token: 0x020000F4 RID: 244
		public class McLoginLegacy : ModLaunch.McLoginData
		{
			// Token: 0x0600088D RID: 2189 RVA: 0x00006979 File Offset: 0x00004B79
			public McLoginLegacy()
			{
				this.Type = ModLaunch.McLoginType.Legacy;
			}

			// Token: 0x0600088E RID: 2190 RVA: 0x00047938 File Offset: 0x00045B38
			public override int GetHashCode()
			{
				return Convert.ToInt32(decimal.Remainder(new decimal(ModBase.GetHash(this.m_CustomerAlgo + Conversions.ToString(this.taskAlgo) + this._AuthenticationAlgo + Conversions.ToString((int)this.Type))), 2147483647m));
			}

			// Token: 0x040004AE RID: 1198
			public string m_CustomerAlgo;

			// Token: 0x040004AF RID: 1199
			public int taskAlgo;

			// Token: 0x040004B0 RID: 1200
			public string _AuthenticationAlgo;
		}

		// Token: 0x020000F5 RID: 245
		public struct McLoginResult
		{
			// Token: 0x040004B1 RID: 1201
			public string Name;

			// Token: 0x040004B2 RID: 1202
			public string processAlgo;

			// Token: 0x040004B3 RID: 1203
			public string listenerAlgo;

			// Token: 0x040004B4 RID: 1204
			public string Type;

			// Token: 0x040004B5 RID: 1205
			public string _ImporterAlgo;

			// Token: 0x040004B6 RID: 1206
			public string _TemplateAlgo;

			// Token: 0x040004B7 RID: 1207
			public string m_AdapterAlgo;
		}
	}
}
