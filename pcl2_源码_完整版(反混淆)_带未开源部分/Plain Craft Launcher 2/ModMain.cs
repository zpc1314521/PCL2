using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json.Linq;
using PCL.My;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;

namespace PCL
{
	// Token: 0x0200018F RID: 399
	[StandardModule]
	public sealed class ModMain
	{
		// Token: 0x060011BA RID: 4538 RVA: 0x0007D810 File Offset: 0x0007BA10
		// Note: this type is marked as 'beforefieldinit'.
		static ModMain()
		{
			ModMain.m_PredicateFilter = (Information.IsNothing(ModMain.m_PredicateFilter) ? new ArrayList() : ModMain.m_PredicateFilter);
			ModMain._StructFilter = (Information.IsNothing(ModMain._StructFilter) ? new ArrayList() : ModMain._StructFilter);
			ModMain.resolverFilter = new ModBase.MyColor(52.0, 61.0, 74.0);
			ModMain.collectionFilter = new ModBase.MyColor(11.0, 91.0, 203.0);
			ModMain.testsFilter = new ModBase.MyColor(19.0, 112.0, 243.0);
			ModMain.m_BroadcasterFilter = new ModBase.MyColor(72.0, 144.0, 245.0);
			ModMain.fieldFilter = new ModBase.MyColor(150.0, 192.0, 249.0);
			ModMain._StatusFilter = new ModBase.MyColor(213.0, 230.0, 253.0);
			ModMain._RequestFilter = new ModBase.MyColor(222.0, 236.0, 253.0);
			ModMain.poolFilter = new ModBase.MyColor(234.0, 242.0, 254.0);
			ModMain.m_ParserFilter = new ModBase.MyColor(128.0, ModMain._RequestFilter);
			ModMain.proxyFilter = new ModBase.MyColor(64.0, 64.0, 64.0);
			ModMain.setterFilter = new ModBase.MyColor(115.0, 115.0, 115.0);
			ModMain.merchantFilter = new ModBase.MyColor(140.0, 140.0, 140.0);
			ModMain._EventFilter = new ModBase.MyColor(166.0, 166.0, 166.0);
			ModMain.printerFilter = new ModBase.MyColor(204.0, 204.0, 204.0);
			ModMain.productFilter = new ModBase.MyColor(235.0, 235.0, 235.0);
			ModMain._ComparatorFilter = new ModBase.MyColor(240.0, 240.0, 240.0);
			ModMain._RegistryFilter = new ModBase.MyColor(245.0, 245.0, 245.0);
			ModMain.m_AttributeFilter = new ModBase.MyColor(1.0, ModMain.poolFilter);
			ModMain._ValueFilter = -1;
			ModMain.m_RoleFilter = 0xD2;
			ModMain.m_AdvisorFilter = 0x55;
			ModMain.m_StrategyFilter = 0;
			ModMain.wrapperFilter = 0;
			ModMain.m_WriterFilter = 0;
			ModMain._ExporterFilter = false;
			ModMain.recordFilter = 1;
			ModMain.connectionFilter = new ModLoader.LoaderTask<int, Dictionary<string, List<ModMain.FeedbackEntry>>>("Feedback Page", new ModLoader.LoaderTask<int, Dictionary<string, List<ModMain.FeedbackEntry>>>.LoadDelegateSub(ModMain.FeedbackLoad), null, ThreadPriority.Lowest)
			{
				ReloadTimeout = 0x2BF20
			};
			ModMain.listFilter = RuntimeHelpers.GetObjectValue(new object());
			ModMain._ReponseFilter = new ModLoader.LoaderTask<int, List<ModMain.HelpEntry>>("Help Page", new ModLoader.LoaderTask<int, List<ModMain.HelpEntry>>.LoadDelegateSub(ModMain.HelpLoad), null, ThreadPriority.BelowNormal);
			ModMain.identifierFilter = new ModLoader.LoaderTask<int, int>("PCL2 服务", new ModLoader.LoaderTask<int, int>.LoadDelegateSub(ModMain.ServerSub), null, ThreadPriority.BelowNormal);
			ModMain.policyFilter = (DateTime.Now.Month == 4 && DateTime.Now.Day == 1);
			ModMain.m_ClientFilter = false;
			ModMain._MapFilter = new Vector(0.0, 0.0);
			ModMain.composerFilter = 0;
			ModMain.publisherFilter = new Point(0.0, 0.0);
			ModMain.messageFilter = false;
			ModMain.m_TokenFilter = false;
			ModMain.m_ProcFilter = "6FxkjKwAyeWfQELDSMKbjZ+Ll3vsf5XcgJhYaolWiXDsyOn5fCNDsxVVARyudyBQAbS3I74LkfckJUD72RCTk5zww8qlp7jEJbQr1+Xid6hSpnenFuRfNsMLybBRUH2orV6+UyMb7eOpoSRR11Zlz9zuQ9Pb4jE3N7ak29MhcUoO8nFiiH4yJdE8modyLNG9Cc9eiYCjPyyzxbj8w6+gKyIdQazINhyn*********************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************";
			ModMain.m_FactoryRule = null;
			ModMain.m_ValRule = null;
			ModMain.containerRule = 0;
			ModMain._ModelRule = 0;
		}

		// Token: 0x060011BB RID: 4539 RVA: 0x0000B3EA File Offset: 0x000095EA
		public static void Hint(string Text, ModMain.HintType Type = ModMain.HintType.Info, bool Log = true)
		{
			if (Information.IsNothing(ModMain.m_PredicateFilter))
			{
				ModMain.m_PredicateFilter = new ArrayList();
			}
			ModMain.m_PredicateFilter.Add(new object[]
			{
				Text,
				Type,
				Log
			});
		}

		// Token: 0x060011BC RID: 4540 RVA: 0x0007DC1C File Offset: 0x0007BE1C
		private static void HintTick()
		{
			try
			{
				if (ModMain.m_PredicateFilter.Count != 0)
				{
					while (ModMain.m_PredicateFilter.Count > 0)
					{
						ModMain._Closure$__4-0 CS$<>8__locals1 = new ModMain._Closure$__4-0(CS$<>8__locals1);
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(ModMain.m_PredicateFilter[0])) && !Information.IsNothing(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(ModMain.m_PredicateFilter[0], new object[]
						{
							0
						}, null))))
						{
							NewLateBinding.LateIndexSetComplex(ModMain.m_PredicateFilter[0], new object[]
							{
								0,
								NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateIndexGet(ModMain.m_PredicateFilter[0], new object[]
								{
									0
								}, null), null, "Replace", new object[]
								{
									"\r\n",
									" "
								}, null, null, null), null, "Replace", new object[]
								{
									"\r",
									" "
								}, null, null, null), null, "Replace", new object[]
								{
									"\n",
									" "
								}, null, null, null)
							}, null, false, true);
							if (ModMain.m_GetterFilter.PanHint.Children.Count < 0x14)
							{
								CS$<>8__locals1.$VB$Local_DoubleStack = null;
								try
								{
									foreach (object obj in ModMain.m_GetterFilter.PanHint.Children)
									{
										Border border = (Border)obj;
										if (Conversions.ToBoolean(Conversions.ToBoolean(NewLateBinding.LateIndexGet(border.Tag, new object[]
										{
											0
										}, null)) && Operators.ConditionalCompareObjectEqual(((TextBlock)border.Child).Text, NewLateBinding.LateIndexGet(ModMain.m_PredicateFilter[0], new object[]
										{
											0
										}, null), true)))
										{
											CS$<>8__locals1.$VB$Local_DoubleStack = border;
										}
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
								if (!Information.IsNothing(CS$<>8__locals1.$VB$Local_DoubleStack))
								{
									if (!ModAni.AniIsRun(Conversions.ToString(Operators.ConcatenateObject("Hint Show ", NewLateBinding.LateIndexGet(CS$<>8__locals1.$VB$Local_DoubleStack.Tag, new object[]
									{
										1
									}, null)))))
									{
										ModAni.AniStop(Conversions.ToString(Operators.ConcatenateObject("Hint Hide ", NewLateBinding.LateIndexGet(CS$<>8__locals1.$VB$Local_DoubleStack.Tag, new object[]
										{
											1
										}, null))));
										double a = (800.0 + ModBase.MathRange((double)Strings.Len(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(ModMain.m_PredicateFilter[0], new object[]
										{
											0
										}, null))), 5.0, 23.0) * 180.0) * ModAni._Parameter;
										ModAni.AniStart(checked(new ModAni.AniData[]
										{
											ModAni.AaX(CS$<>8__locals1.$VB$Local_DoubleStack, unchecked(-12.0 - CS$<>8__locals1.$VB$Local_DoubleStack.Margin.Left), 0x32, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
											ModAni.AaX(CS$<>8__locals1.$VB$Local_DoubleStack, -8.0, 0x32, 0x32, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
											ModAni.AaX(CS$<>8__locals1.$VB$Local_DoubleStack, 8.0, 0x32, 0x64, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
											ModAni.AaX(CS$<>8__locals1.$VB$Local_DoubleStack, -8.0, 0x32, 0x96, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
											ModAni.AaX(CS$<>8__locals1.$VB$Local_DoubleStack, -50.0, 0xC8, (int)Math.Round(a), new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
											ModAni.AaOpacity(CS$<>8__locals1.$VB$Local_DoubleStack, -1.0, 0x96, (int)Math.Round(a), null, false),
											ModAni.AaCode(delegate
											{
												NewLateBinding.LateIndexSetComplex(CS$<>8__locals1.$VB$Local_DoubleStack.Tag, new object[]
												{
													0,
													false
												}, null, false, true);
											}, (int)Math.Round(a), false),
											ModAni.AaHeight(CS$<>8__locals1.$VB$Local_DoubleStack, -26.0, 0x64, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), true),
											ModAni.AaCode(delegate
											{
												ModMain.m_GetterFilter.PanHint.Children.Remove(CS$<>8__locals1.$VB$Local_DoubleStack);
											}, 0, true)
										}), Conversions.ToString(Operators.ConcatenateObject("Hint Hide ", NewLateBinding.LateIndexGet(CS$<>8__locals1.$VB$Local_DoubleStack.Tag, new object[]
										{
											1
										}, null))), false);
									}
								}
								else
								{
									ModMain._Closure$__4-1 CS$<>8__locals2 = new ModMain._Closure$__4-1(CS$<>8__locals2);
									CS$<>8__locals2.$VB$Local_NewHintControl = new Border
									{
										Tag = new object[]
										{
											true,
											ModBase.GetUuid()
										},
										Margin = new Thickness(-70.0, 0.0, 20.0, 0.0),
										Opacity = 0.0,
										Height = 0.0,
										HorizontalAlignment = HorizontalAlignment.Left,
										CornerRadius = new CornerRadius(0.0, 6.0, 6.0, 0.0)
									};
									object left = NewLateBinding.LateIndexGet(ModMain.m_PredicateFilter[0], new object[]
									{
										1
									}, null);
									if (Operators.ConditionalCompareObjectEqual(left, ModMain.HintType.Info, true))
									{
										CS$<>8__locals2.$VB$Local_NewHintControl.Background = new LinearGradientBrush(new GradientStopCollection(new List<GradientStop>
										{
											new GradientStop(new ModBase.MyColor(10.0, 142.0, 252.0), 1.0),
											new GradientStop(new ModBase.MyColor(37.0, 155.0, 252.0), 0.0)
										}), 90.0);
									}
									else if (Operators.ConditionalCompareObjectEqual(left, ModMain.HintType.Finish, true))
									{
										CS$<>8__locals2.$VB$Local_NewHintControl.Background = new LinearGradientBrush(new GradientStopCollection(new List<GradientStop>
										{
											new GradientStop(new ModBase.MyColor(29.0, 160.0, 29.0), 1.0),
											new GradientStop(new ModBase.MyColor(33.0, 177.0, 33.0), 0.0)
										}), 90.0);
									}
									else if (Operators.ConditionalCompareObjectEqual(left, ModMain.HintType.Critical, true))
									{
										CS$<>8__locals2.$VB$Local_NewHintControl.Background = new LinearGradientBrush(new GradientStopCollection(new List<GradientStop>
										{
											new GradientStop(new ModBase.MyColor(244.0, 43.0, 0.0), 1.0),
											new GradientStop(new ModBase.MyColor(255.0, 53.0, 11.0), 0.0)
										}), 90.0);
										ModBase.m_ObjectRule = true;
									}
									else
									{
										ModBase.DebugAssert(false);
									}
									CS$<>8__locals2.$VB$Local_NewHintControl.Child = new TextBlock
									{
										TextTrimming = TextTrimming.CharacterEllipsis,
										FontSize = 13.0,
										Text = Conversions.ToString(NewLateBinding.LateIndexGet(ModMain.m_PredicateFilter[0], new object[]
										{
											0
										}, null)),
										Foreground = new ModBase.MyColor(255.0, 255.0, 255.0),
										Margin = new Thickness(33.0, 5.0, 8.0, 5.0)
									};
									ModMain.m_GetterFilter.PanHint.Children.Add(CS$<>8__locals2.$VB$Local_NewHintControl);
									ArrayList arrayList = new ArrayList();
									if (ModMain.m_GetterFilter.PanHint.Children.Count > 1)
									{
										arrayList.Add(ModAni.AaHeight(CS$<>8__locals2.$VB$Local_NewHintControl, 26.0, 0x96, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false));
									}
									else
									{
										CS$<>8__locals2.$VB$Local_NewHintControl.Height = 26.0;
									}
									arrayList.AddRange(new ModAni.AniData[]
									{
										ModAni.AaX(CS$<>8__locals2.$VB$Local_NewHintControl, 30.0, 0x1F4, 0, new ModAni.AniEaseOutElastic(ModAni.AniEasePower.Weak), false),
										ModAni.AaX(CS$<>8__locals2.$VB$Local_NewHintControl, 20.0, 0xFA, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
										ModAni.AaOpacity(CS$<>8__locals2.$VB$Local_NewHintControl, 1.0, 0x96, 0x64, null, false)
									});
									ModAni.AniStart(arrayList, Conversions.ToString(Operators.ConcatenateObject("Hint Show ", NewLateBinding.LateIndexGet(CS$<>8__locals2.$VB$Local_NewHintControl.Tag, new object[]
									{
										1
									}, null))), false);
									double a2 = (800.0 + ModBase.MathRange((double)Strings.Len(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(ModMain.m_PredicateFilter[0], new object[]
									{
										0
									}, null))), 5.0, 23.0) * 180.0) * ModAni._Parameter;
									ModAni.AniStart(checked(new ModAni.AniData[]
									{
										ModAni.AaX(CS$<>8__locals2.$VB$Local_NewHintControl, -50.0, 0xC8, (int)Math.Round(a2), new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
										ModAni.AaOpacity(CS$<>8__locals2.$VB$Local_NewHintControl, -1.0, 0x96, (int)Math.Round(a2), null, false),
										ModAni.AaCode(delegate
										{
											NewLateBinding.LateIndexSetComplex(CS$<>8__locals2.$VB$Local_NewHintControl.Tag, new object[]
											{
												0,
												false
											}, null, false, true);
										}, (int)Math.Round(a2), false),
										ModAni.AaHeight(CS$<>8__locals2.$VB$Local_NewHintControl, -26.0, 0x64, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), true),
										ModAni.AaCode(delegate
										{
											ModMain.m_GetterFilter.PanHint.Children.Remove(CS$<>8__locals2.$VB$Local_NewHintControl);
										}, 0, true)
									}), Conversions.ToString(Operators.ConcatenateObject("Hint Hide ", NewLateBinding.LateIndexGet(CS$<>8__locals2.$VB$Local_NewHintControl.Tag, new object[]
									{
										1
									}, null))), false);
								}
							}
							if (Conversions.ToBoolean(NewLateBinding.LateIndexGet(ModMain.m_PredicateFilter[0], new object[]
							{
								2
							}, null)))
							{
								ModBase.Log(Conversions.ToString(Operators.ConcatenateObject("[UI] 弹出提示：", NewLateBinding.LateIndexGet(ModMain.m_PredicateFilter[0], new object[]
								{
									0
								}, null))), ModBase.LogLevel.Normal, "出现错误");
							}
							ModMain.m_PredicateFilter.RemoveAt(0);
						}
						else
						{
							ModMain.m_PredicateFilter.RemoveAt(0);
						}
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "显示弹出提示失败", ModBase.LogLevel.Normal, "出现错误");
			}
		}

		// Token: 0x060011BD RID: 4541 RVA: 0x0007E7B4 File Offset: 0x0007C9B4
		public static int MyMsgBox(string Caption, string Title = "提示", string Button1 = "确定", string Button2 = "", string Button3 = "", bool IsWarn = false, bool HighLight = true, bool ForceWait = false)
		{
			ModMain.MyMsgBoxConverter myMsgBoxConverter = new ModMain.MyMsgBoxConverter
			{
				Type = ModMain.MyMsgBoxType.Text,
				merchantMapper = Button1,
				_EventMapper = Button2,
				_PrinterMapper = Button3,
				m_PoolMapper = Caption,
				_ProductMapper = IsWarn,
				Title = Title,
				setterMapper = HighLight,
				_ComparatorMapper = true
			};
			ModMain._StructFilter.Add(myMsgBoxConverter);
			if (ModBase.RunInUi())
			{
				ModMain.MyMsgBoxTick();
			}
			checked
			{
				int result;
				if (Button2.Length <= 0 && !ForceWait)
				{
					result = 1;
				}
				else
				{
					if (ModMain.m_GetterFilter != null && (ModMain.m_GetterFilter.PanMsg != null || !ModBase.RunInUi()))
					{
						try
						{
							ModMain.m_GetterFilter.DragStop();
							ComponentDispatcher.PushModal();
							Dispatcher.PushFrame(myMsgBoxConverter.registryMapper);
							goto IL_17C;
						}
						finally
						{
							ComponentDispatcher.PopModal();
						}
					}
					ModMain._StructFilter.Remove(myMsgBoxConverter);
					if (Button2.Length > 0)
					{
						MsgBoxResult msgBoxResult = Interaction.MsgBox(Caption, ((Button3.Length > 0) ? MsgBoxStyle.YesNoCancel : MsgBoxStyle.YesNo) + (IsWarn ? 0x10 : 0x20), Title);
						if (msgBoxResult != MsgBoxResult.Cancel)
						{
							if (msgBoxResult != MsgBoxResult.Yes)
							{
								if (msgBoxResult == MsgBoxResult.No)
								{
									myMsgBoxConverter.valueMapper = 2;
								}
							}
							else
							{
								myMsgBoxConverter.valueMapper = 1;
							}
						}
						else
						{
							myMsgBoxConverter.valueMapper = 3;
						}
					}
					else
					{
						Interaction.MsgBox(Caption, MsgBoxStyle.OkOnly + (IsWarn ? 0x10 : 0x20), Title);
						myMsgBoxConverter.valueMapper = 1;
					}
					ModBase.Log(string.Concat(new string[]
					{
						"[Control] 主窗体加载完成前出现意料外的等待弹窗：",
						Button1,
						",",
						Button2,
						",",
						Button3
					}), ModBase.LogLevel.Debug, "出现错误");
					IL_17C:
					ModBase.Log(Conversions.ToString(Operators.ConcatenateObject("[Control] 普通弹框返回：", myMsgBoxConverter.valueMapper ?? "null")), ModBase.LogLevel.Normal, "出现错误");
					result = Conversions.ToInteger(myMsgBoxConverter.valueMapper);
				}
				return result;
			}
		}

		// Token: 0x060011BE RID: 4542 RVA: 0x0007E984 File Offset: 0x0007CB84
		public static string MyMsgBoxInput(string Caption, Collection<Validate> ValidateRules, string HintText = "", string Title = "提示", string Button1 = "确定", string Button2 = "", bool IsWarn = false)
		{
			ModMain.MyMsgBoxConverter myMsgBoxConverter = new ModMain.MyMsgBoxConverter
			{
				_ProxyMapper = HintText,
				Type = ModMain.MyMsgBoxType.Input,
				parserMapper = ValidateRules,
				merchantMapper = Button1,
				_EventMapper = Button2,
				m_PoolMapper = Caption,
				_ProductMapper = IsWarn,
				Title = Title
			};
			ModMain._StructFilter.Add(myMsgBoxConverter);
			try
			{
				if (ModMain.m_GetterFilter != null)
				{
					ModMain.m_GetterFilter.DragStop();
				}
				ComponentDispatcher.PushModal();
				Dispatcher.PushFrame(myMsgBoxConverter.registryMapper);
			}
			finally
			{
				ComponentDispatcher.PopModal();
			}
			ModBase.Log(Conversions.ToString(Operators.ConcatenateObject("[Control] 输入弹框返回：", myMsgBoxConverter.valueMapper ?? "null")), ModBase.LogLevel.Normal, "出现错误");
			return Conversions.ToString(myMsgBoxConverter.valueMapper);
		}

		// Token: 0x060011BF RID: 4543 RVA: 0x0007EA4C File Offset: 0x0007CC4C
		public static int? MyMsgBoxSelect(List<IMyRadio> Selections, string Title = "提示", string Button1 = "确定", string Button2 = "", bool IsWarn = false)
		{
			ModMain.MyMsgBoxConverter myMsgBoxConverter = new ModMain.MyMsgBoxConverter
			{
				Type = ModMain.MyMsgBoxType.Select,
				merchantMapper = Button1,
				_EventMapper = Button2,
				m_PoolMapper = Selections,
				_ProductMapper = IsWarn,
				Title = Title
			};
			ModMain._StructFilter.Add(myMsgBoxConverter);
			try
			{
				if (ModMain.m_GetterFilter != null)
				{
					ModMain.m_GetterFilter.DragStop();
				}
				ComponentDispatcher.PushModal();
				Dispatcher.PushFrame(myMsgBoxConverter.registryMapper);
			}
			finally
			{
				ComponentDispatcher.PopModal();
			}
			ModBase.Log(Conversions.ToString(Operators.ConcatenateObject("[Control] 选择弹框返回：", myMsgBoxConverter.valueMapper ?? "null")), ModBase.LogLevel.Normal, "出现错误");
			return (int?)myMsgBoxConverter.valueMapper;
		}

		// Token: 0x060011C0 RID: 4544 RVA: 0x0007EB04 File Offset: 0x0007CD04
		public static void MyMsgBoxTick()
		{
			if (ModMain.m_GetterFilter != null && ModMain.m_GetterFilter.PanMsg != null && ModMain.m_GetterFilter.WindowState != WindowState.Minimized)
			{
				if (ModMain.m_GetterFilter.PanMsg.Children.Count > 0)
				{
					ModMain.m_GetterFilter.PanMsg.Visibility = Visibility.Visible;
					return;
				}
				if (ModMain._StructFilter.Count > 0)
				{
					ModMain.m_GetterFilter.PanMsg.Visibility = Visibility.Visible;
					switch (((ModMain.MyMsgBoxConverter)ModMain._StructFilter[0]).Type)
					{
					case ModMain.MyMsgBoxType.Text:
						ModMain.m_GetterFilter.PanMsg.Children.Add(new MyMsgText((ModMain.MyMsgBoxConverter)ModMain._StructFilter[0]));
						break;
					case ModMain.MyMsgBoxType.Select:
						ModMain.m_GetterFilter.PanMsg.Children.Add(new MyMsgSelect((ModMain.MyMsgBoxConverter)ModMain._StructFilter[0]));
						break;
					case ModMain.MyMsgBoxType.Input:
						ModMain.m_GetterFilter.PanMsg.Children.Add(new MyMsgInput((ModMain.MyMsgBoxConverter)ModMain._StructFilter[0]));
						break;
					}
					ModMain._StructFilter.RemoveAt(0);
					return;
				}
				if (ModMain.m_GetterFilter.PanMsg.Visibility != Visibility.Collapsed)
				{
					ModMain.m_GetterFilter.PanMsg.Visibility = Visibility.Collapsed;
				}
			}
		}

		// Token: 0x060011C1 RID: 4545 RVA: 0x0007EC60 File Offset: 0x0007CE60
		public static void CompareIterator(int setup = -1)
		{
			try
			{
				if (ModMain._ValueFilter != setup || setup < 0)
				{
					if (setup >= 0)
					{
						ModMain._ValueFilter = setup;
					}
					int valueFilter = ModMain._ValueFilter;
					checked
					{
						switch (valueFilter)
						{
						case 0:
							ModMain.m_RoleFilter = 0xD2;
							ModMain.m_AdvisorFilter = 0x55;
							ModMain.m_StrategyFilter = 0;
							ModMain.wrapperFilter = 0;
							break;
						case 1:
							ModMain.m_RoleFilter = 0xB4;
							ModMain.m_AdvisorFilter = 0x32;
							ModMain.m_StrategyFilter = 0;
							ModMain.wrapperFilter = 0;
							break;
						case 2:
							ModMain.m_RoleFilter = 0x82;
							ModMain.m_AdvisorFilter = 0x28;
							ModMain.m_StrategyFilter = 0;
							ModMain.wrapperFilter = new int[]
							{
								5,
								-5,
								5
							};
							break;
						case 3:
							ModMain.m_RoleFilter = 0x4B;
							ModMain.m_AdvisorFilter = 0x32;
							ModMain.m_StrategyFilter = 0;
							ModMain.wrapperFilter = 0;
							break;
						case 4:
							ModMain.m_RoleFilter = 0x23;
							ModMain.m_AdvisorFilter = 0x1E;
							ModMain.m_StrategyFilter = 0;
							ModMain.wrapperFilter = 0;
							break;
						case 5:
							ModMain.m_RoleFilter = 0xE1;
							ModMain.m_AdvisorFilter = 0xA;
							ModMain.m_StrategyFilter = -0x14;
							ModMain.wrapperFilter = 0;
							break;
						case 6:
							ModMain.m_RoleFilter = 0x159;
							ModMain.m_AdvisorFilter = 0x46;
							ModMain.m_StrategyFilter = 0xF;
							ModMain.wrapperFilter = 0;
							break;
						case 7:
							ModMain.m_RoleFilter = 0x11D;
							ModMain.m_AdvisorFilter = 0x32;
							ModMain.m_StrategyFilter = 0;
							ModMain.wrapperFilter = 0;
							break;
						case 8:
							ModMain.m_RoleFilter = 0x32;
							ModMain.m_AdvisorFilter = 0x41;
							ModMain.m_StrategyFilter = 0xA;
							ModMain.wrapperFilter = 0;
							break;
						case 9:
							ModMain.m_RoleFilter = 0x19;
							ModMain.m_AdvisorFilter = 0x4B;
							ModMain.m_StrategyFilter = 5;
							ModMain.wrapperFilter = 0;
							break;
						case 0xA:
							ModMain.m_RoleFilter = 5;
							ModMain.m_AdvisorFilter = 0x46;
							ModMain.m_StrategyFilter = -5;
							ModMain.wrapperFilter = 0;
							break;
						case 0xB:
							ModMain.m_RoleFilter = 0xE6;
							ModMain.m_AdvisorFilter = 0x3C;
							ModMain.m_StrategyFilter = -5;
							ModMain.wrapperFilter = 0;
							break;
						case 0xC:
							if (!ModMain._ExporterFilter)
							{
								ModMain._ExporterFilter = true;
								ModMain.m_RoleFilter = ModBase.RandomInteger(0, 0x167);
								ModMain.recordFilter = (ModBase.RandomInteger(0, 1) * 2 - 1) * 4;
							}
							ModMain.m_RoleFilter = (ModMain.m_RoleFilter + ModMain.recordFilter) % 0x168;
							ModMain.m_AdvisorFilter = 0x2D;
							ModMain.m_StrategyFilter = 0;
							break;
						case 0xD:
							ModMain.m_RoleFilter = 0x122;
							ModMain.m_AdvisorFilter = 0x32;
							ModMain.m_StrategyFilter = 0;
							ModMain.wrapperFilter = new int[]
							{
								-0x1E,
								0xA,
								0x32
							};
							break;
						case 0xE:
							ModMain.m_RoleFilter = Conversions.ToInteger(ModBase._BaseRule.Get("UiLauncherHue", null));
							ModMain.m_AdvisorFilter = Conversions.ToInteger(ModBase._BaseRule.Get("UiLauncherSat", null));
							ModMain.m_StrategyFilter = Conversions.ToInteger(Operators.SubtractObject(ModBase._BaseRule.Get("UiLauncherLight", null), 0x14));
							ModMain.wrapperFilter = Operators.SubtractObject(ModBase._BaseRule.Get("UiLauncherDelta", null), 0x5A);
							break;
						default:
							if (valueFilter != 0x2A)
							{
								ModMain.m_RoleFilter = 0xD7;
								ModMain.m_AdvisorFilter = 0x5A;
								ModMain.m_StrategyFilter = 0;
							}
							else
							{
								ModMain.m_RoleFilter = 0xE1;
								ModMain.m_AdvisorFilter = 0x3C;
								ModMain.m_StrategyFilter = -0xF;
								ModMain.wrapperFilter = 0;
							}
							break;
						}
						switch (ModMain.m_WriterFilter)
						{
						case 1:
							ModMain.m_StrategyFilter = 0x3E7;
							break;
						case 2:
							ModMain.m_RoleFilter = ModBase.RandomInteger(0, 0x167);
							ModMain.m_AdvisorFilter = ModBase.RandomInteger(0x28, 0x46);
							ModMain.m_StrategyFilter = ModBase.RandomInteger(-0x14, 0x14);
							break;
						}
						ModMain.resolverFilter = unchecked(new ModBase.MyColor().FromHSL2((double)ModMain.m_RoleFilter, (double)ModMain.m_AdvisorFilter * 0.2, 25.0 + (double)ModMain.m_StrategyFilter * 0.3));
						ModMain.collectionFilter = new ModBase.MyColor().FromHSL2((double)ModMain.m_RoleFilter, (double)ModMain.m_AdvisorFilter, (double)(0x2D + ModMain.m_StrategyFilter));
						ModMain.testsFilter = new ModBase.MyColor().FromHSL2((double)ModMain.m_RoleFilter, (double)ModMain.m_AdvisorFilter, (double)(0x37 + ModMain.m_StrategyFilter));
						ModMain.m_BroadcasterFilter = new ModBase.MyColor().FromHSL2((double)ModMain.m_RoleFilter, (double)ModMain.m_AdvisorFilter, (double)(0x41 + ModMain.m_StrategyFilter));
					}
					ModMain.fieldFilter = new ModBase.MyColor().FromHSL2((double)ModMain.m_RoleFilter, (double)ModMain.m_AdvisorFilter, 80.0 + (double)ModMain.m_StrategyFilter * 0.4);
					ModMain._StatusFilter = new ModBase.MyColor().FromHSL2((double)ModMain.m_RoleFilter, (double)ModMain.m_AdvisorFilter, 91.0 + (double)ModMain.m_StrategyFilter * 0.1);
					ModMain._RequestFilter = new ModBase.MyColor().FromHSL2((double)ModMain.m_RoleFilter, (double)ModMain.m_AdvisorFilter, 94.0);
					ModMain.poolFilter = new ModBase.MyColor().FromHSL2((double)ModMain.m_RoleFilter, (double)ModMain.m_AdvisorFilter, 97.0);
					ModMain.m_ParserFilter = new ModBase.MyColor(190.0, ModMain._RequestFilter);
					ModMain.m_AttributeFilter = new ModBase.MyColor(1.0, ModMain.poolFilter);
					Application.Current.Resources["ColorBrush1"] = new SolidColorBrush(ModMain.resolverFilter);
					Application.Current.Resources["ColorBrush2"] = new SolidColorBrush(ModMain.collectionFilter);
					Application.Current.Resources["ColorBrush3"] = new SolidColorBrush(ModMain.testsFilter);
					Application.Current.Resources["ColorBrush4"] = new SolidColorBrush(ModMain.m_BroadcasterFilter);
					Application.Current.Resources["ColorBrush5"] = new SolidColorBrush(ModMain.fieldFilter);
					Application.Current.Resources["ColorBrush6"] = new SolidColorBrush(ModMain._StatusFilter);
					Application.Current.Resources["ColorBrush7"] = new SolidColorBrush(ModMain._RequestFilter);
					Application.Current.Resources["ColorBrush8"] = new SolidColorBrush(ModMain.poolFilter);
					Application.Current.Resources["ColorBrush9"] = new SolidColorBrush(ModMain.m_ParserFilter);
					Application.Current.Resources["ColorObject1"] = ModMain.resolverFilter;
					Application.Current.Resources["ColorObject2"] = ModMain.collectionFilter;
					Application.Current.Resources["ColorObject3"] = ModMain.testsFilter;
					Application.Current.Resources["ColorObject4"] = ModMain.m_BroadcasterFilter;
					Application.Current.Resources["ColorObject5"] = ModMain.fieldFilter;
					Application.Current.Resources["ColorObject6"] = ModMain._StatusFilter;
					Application.Current.Resources["ColorObject7"] = ModMain._RequestFilter;
					Application.Current.Resources["ColorObject8"] = ModMain.poolFilter;
					Application.Current.Resources["ColorObject9"] = ModMain.m_ParserFilter;
					ModMain.CloneIterator();
					if (ModMain._ValueFilter != 0xC && ModMain._ValueFilter != 0xE && ModMain.m_WriterFilter != 2)
					{
						ModBase.Log("[UI] 刷新主题：" + Conversions.ToString(ModMain._ValueFilter), ModBase.LogLevel.Normal, "出现错误");
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "刷新主题颜色失败", ModBase.LogLevel.Hint, "出现错误");
			}
		}

		// Token: 0x060011C2 RID: 4546 RVA: 0x0000B429 File Offset: 0x00009629
		public static void CloneIterator()
		{
			ModBase.RunInUi((ModMain._Closure$__.$I39-0 == null) ? (ModMain._Closure$__.$I39-0 = delegate()
			{
				if (ModMain.m_GetterFilter.IsLoaded)
				{
					LinearGradientBrush linearGradientBrush = new LinearGradientBrush
					{
						EndPoint = new Point(1.0, 0.0),
						StartPoint = new Point(0.0, 0.0)
					};
					checked
					{
						if (ModMain._ValueFilter == 5)
						{
							linearGradientBrush.GradientStops.Add(new GradientStop
							{
								Offset = 0.0,
								Color = new ModBase.MyColor().FromHSL2((double)ModMain.m_RoleFilter, (double)ModMain.m_AdvisorFilter, 25.0)
							});
							linearGradientBrush.GradientStops.Add(new GradientStop
							{
								Offset = 0.5,
								Color = new ModBase.MyColor().FromHSL2((double)ModMain.m_RoleFilter, (double)ModMain.m_AdvisorFilter, 15.0)
							});
							linearGradientBrush.GradientStops.Add(new GradientStop
							{
								Offset = 1.0,
								Color = new ModBase.MyColor().FromHSL2((double)ModMain.m_RoleFilter, (double)ModMain.m_AdvisorFilter, 25.0)
							});
							ModMain.m_GetterFilter.PanTitle.Background = linearGradientBrush;
							ModMain.m_GetterFilter.PanTitle.Background.Freeze();
						}
						else if (ModMain._ValueFilter != 0xC && ModMain.m_WriterFilter != 2)
						{
							if (ModMain.wrapperFilter.GetType().Equals(typeof(int)))
							{
								linearGradientBrush.GradientStops.Add(new GradientStop
								{
									Offset = 0.0,
									Color = new ModBase.MyColor().FromHSL2(Conversions.ToDouble(Operators.SubtractObject(ModMain.m_RoleFilter, ModMain.wrapperFilter)), (double)ModMain.m_AdvisorFilter, (double)(0x30 + ModMain.m_StrategyFilter))
								});
								linearGradientBrush.GradientStops.Add(new GradientStop
								{
									Offset = 0.5,
									Color = new ModBase.MyColor().FromHSL2((double)ModMain.m_RoleFilter, (double)ModMain.m_AdvisorFilter, (double)(0x36 + ModMain.m_StrategyFilter))
								});
								linearGradientBrush.GradientStops.Add(new GradientStop
								{
									Offset = 1.0,
									Color = new ModBase.MyColor().FromHSL2(Conversions.ToDouble(Operators.AddObject(ModMain.m_RoleFilter, ModMain.wrapperFilter)), (double)ModMain.m_AdvisorFilter, (double)(0x30 + ModMain.m_StrategyFilter))
								});
							}
							else
							{
								linearGradientBrush.GradientStops.Add(new GradientStop
								{
									Offset = 0.0,
									Color = new ModBase.MyColor().FromHSL2(Conversions.ToDouble(Operators.AddObject(ModMain.m_RoleFilter, NewLateBinding.LateIndexGet(ModMain.wrapperFilter, new object[]
									{
										0
									}, null))), (double)ModMain.m_AdvisorFilter, (double)(0x30 + ModMain.m_StrategyFilter))
								});
								linearGradientBrush.GradientStops.Add(new GradientStop
								{
									Offset = 0.5,
									Color = new ModBase.MyColor().FromHSL2(Conversions.ToDouble(Operators.AddObject(ModMain.m_RoleFilter, NewLateBinding.LateIndexGet(ModMain.wrapperFilter, new object[]
									{
										1
									}, null))), (double)ModMain.m_AdvisorFilter, (double)(0x36 + ModMain.m_StrategyFilter))
								});
								linearGradientBrush.GradientStops.Add(new GradientStop
								{
									Offset = 1.0,
									Color = new ModBase.MyColor().FromHSL2(Conversions.ToDouble(Operators.AddObject(ModMain.m_RoleFilter, NewLateBinding.LateIndexGet(ModMain.wrapperFilter, new object[]
									{
										2
									}, null))), (double)ModMain.m_AdvisorFilter, (double)(0x30 + ModMain.m_StrategyFilter))
								});
							}
							ModMain.m_GetterFilter.PanTitle.Background = linearGradientBrush;
							ModMain.m_GetterFilter.PanTitle.Background.Freeze();
						}
						else
						{
							linearGradientBrush.GradientStops.Add(new GradientStop
							{
								Offset = 0.0,
								Color = new ModBase.MyColor().FromHSL2((double)(ModMain.m_RoleFilter - 0x15), (double)ModMain.m_AdvisorFilter, (double)(0x35 + ModMain.m_StrategyFilter))
							});
							linearGradientBrush.GradientStops.Add(new GradientStop
							{
								Offset = 0.33,
								Color = new ModBase.MyColor().FromHSL2((double)(ModMain.m_RoleFilter - 7), (double)ModMain.m_AdvisorFilter, (double)(0x2F + ModMain.m_StrategyFilter))
							});
							linearGradientBrush.GradientStops.Add(new GradientStop
							{
								Offset = 0.67,
								Color = new ModBase.MyColor().FromHSL2((double)(ModMain.m_RoleFilter + 7), (double)ModMain.m_AdvisorFilter, (double)(0x2F + ModMain.m_StrategyFilter))
							});
							linearGradientBrush.GradientStops.Add(new GradientStop
							{
								Offset = 1.0,
								Color = new ModBase.MyColor().FromHSL2((double)(ModMain.m_RoleFilter + 0x15), (double)ModMain.m_AdvisorFilter, (double)(0x35 + ModMain.m_StrategyFilter))
							});
							ModMain.m_GetterFilter.PanTitle.Background = linearGradientBrush;
						}
						if (ModMain._ValueFilter >= 5 && ModMain._ValueFilter != 0xE)
						{
							ModMain.m_GetterFilter.ImgTitle.Source = new ModBitmap.MyBitmap(ModBase.m_ExpressionRule + "Themes/" + Conversions.ToString(ModMain._ValueFilter) + ".png");
						}
						else
						{
							ModMain.m_GetterFilter.ImgTitle.Source = null;
						}
						ModMain.m_GetterFilter.ImgTitle.Opacity = ((ModMain._ValueFilter == 0xD) ? 0.25 : 0.5);
					}
					if (Conversions.ToBoolean(ModBase._BaseRule.Get("UiBackgroundColorful", null)))
					{
						linearGradientBrush = new LinearGradientBrush
						{
							EndPoint = new Point(0.1, 1.0),
							StartPoint = new Point(0.9, 0.0)
						};
						linearGradientBrush.GradientStops.Add(new GradientStop
						{
							Offset = -0.1,
							Color = new ModBase.MyColor().FromHSL2((double)(checked(ModMain.m_RoleFilter - 0x14)), (double)Math.Min(0x3C, ModMain.m_AdvisorFilter) * 0.5, 80.0)
						});
						linearGradientBrush.GradientStops.Add(new GradientStop
						{
							Offset = 0.4,
							Color = new ModBase.MyColor().FromHSL2((double)ModMain.m_RoleFilter, (double)ModMain.m_AdvisorFilter * 0.9, 90.0)
						});
						linearGradientBrush.GradientStops.Add(new GradientStop
						{
							Offset = 1.1,
							Color = new ModBase.MyColor().FromHSL2((double)(checked(ModMain.m_RoleFilter + 0x14)), (double)Math.Min(0x3C, ModMain.m_AdvisorFilter) * 0.5, 80.0)
						});
						ModMain.m_GetterFilter.PanForm.Background = linearGradientBrush;
					}
					else
					{
						ModMain.m_GetterFilter.PanForm.Background = new ModBase.MyColor(250.0, 250.0, 250.0);
					}
					ModMain.m_GetterFilter.PanForm.Background.Freeze();
				}
			}) : ModMain._Closure$__.$I39-0, false);
		}

		// Token: 0x060011C3 RID: 4547 RVA: 0x0007F4C0 File Offset: 0x0007D6C0
		public static void ForgotIterator(bool excludelast)
		{
			ModMain._Closure$__40-0 CS$<>8__locals1 = new ModMain._Closure$__40-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_EffectSetup = excludelast;
			ModBase.RunInUi(checked(delegate()
			{
				try
				{
					string text = Conversions.ToString(ModBase._BaseRule.Get("UiLauncherThemeHide2", null));
					if (Operators.CompareString(text, "", true) == 0)
					{
						text = "3";
					}
					if (ModBase._BaseRule.Get("UiLauncherThemeHide", null).ToString().Contains("7"))
					{
						text += "|7";
					}
					if (ModBase._BaseRule.Get("UiLauncherThemeHide", null).ToString().Contains("6"))
					{
						text += "|6";
					}
					text = ModBase.Join(ModBase.ArrayNoDouble<string>(text.Split(new char[]
					{
						'|'
					}), null).SkipWhile((ModMain._Closure$__.$I40-1 == null) ? (ModMain._Closure$__.$I40-1 = ((string Data) => string.IsNullOrEmpty(Data))) : ModMain._Closure$__.$I40-1).ToList<string>(), "|");
					ModBase._BaseRule.Set("UiLauncherThemeHide2", text, false, null);
					ArrayList arrayList = new ArrayList(text.Split(new char[]
					{
						'|'
					}));
					int num = 0;
					try
					{
						foreach (object value in arrayList)
						{
							int num2 = Conversions.ToInteger(value);
							if (num2 >= 5 && num2 <= 0xE && num2 != 8)
							{
								num++;
							}
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
					if (ModMain.ManageIterator(null))
					{
						num++;
					}
					string text2 = Conversions.ToString(ModBase._BaseRule.Get("UiLauncherTheme", null));
					if (!ModMain.MoveIterator(Conversions.ToInteger(text2)))
					{
						ModBase.Log("[UI] 检测到尚未解锁的主题：" + text2 + "，已重置为默认主题", ModBase.LogLevel.Normal, "出现错误");
						ModBase._BaseRule.Set("UiLauncherTheme", 0, false, null);
					}
					if (CS$<>8__locals1.$VB$Local_EffectSetup && ModMain.processFilter != null)
					{
						ModAni.ListFactory(ModAni.InsertFactory() + 1);
						if (arrayList.Contains("5"))
						{
							ModMain.processFilter.RadioLauncherTheme5.Opacity = 1.0;
							ModMain.processFilter.LabLauncherTheme5Unlock.Visibility = Visibility.Collapsed;
							ModMain.processFilter.RadioLauncherTheme5Gray.Visibility = Visibility.Collapsed;
						}
						if (arrayList.Contains("6"))
						{
							ModMain.processFilter.RadioLauncherTheme6.Text = "铁杆粉";
							ModMain.processFilter.RadioLauncherTheme6.IsEnabled = true;
						}
						if (arrayList.Contains("7"))
						{
							ModMain.processFilter.RadioLauncherTheme7.Text = "神秘紫";
							ModMain.processFilter.RadioLauncherTheme7.IsEnabled = true;
						}
						if (ModMain.ManageIterator(null))
						{
							ModMain.processFilter.RadioLauncherTheme8.Text = "秋仪金";
							ModMain.processFilter.LabLauncherTheme8Copy.Visibility = Visibility.Collapsed;
							ModMain.processFilter.RadioLauncherTheme8.IsEnabled = true;
						}
						if (arrayList.Contains("9"))
						{
							ModMain.processFilter.RadioLauncherTheme9.Text = "活跃橙";
							ModMain.processFilter.LabLauncherTheme9Copy.Visibility = Visibility.Collapsed;
							ModMain.processFilter.RadioLauncherTheme9.IsEnabled = true;
						}
						if (arrayList.Contains("10"))
						{
							ModMain.processFilter.RadioLauncherTheme10.Text = "跳票红";
							ModMain.processFilter.RadioLauncherTheme10.IsEnabled = true;
						}
						if (arrayList.Contains("11"))
						{
							ModMain.processFilter.RadioLauncherTheme11.Text = "极客蓝";
							ModMain.processFilter.LabLauncherTheme11Click.Visibility = Visibility.Collapsed;
							ModMain.processFilter.RadioLauncherTheme11.IsEnabled = true;
						}
						else if (!Information.IsNothing(ModMain.processFilter) && !Information.IsNothing(ModMain.processFilter.RadioLauncherTheme11) && ModMain.processFilter.RadioLauncherTheme11.IsLoaded)
						{
							if (num < 3)
							{
								ModMain.processFilter.LabLauncherTheme11Click.ToolTip = "需要解锁三个隐藏主题";
							}
							else
							{
								ModMain.processFilter.LabLauncherTheme11Click.ToolTip = "点击打开解密游戏入口";
							}
						}
						if (arrayList.Contains("12"))
						{
							ModMain.processFilter.RadioLauncherTheme12.Text = "滑稽彩";
							ModMain.processFilter.RadioLauncherTheme12.IsEnabled = true;
						}
						if (arrayList.Contains("13"))
						{
							ModMain.processFilter.RadioLauncherTheme13.Text = "欧皇彩";
							ModMain.processFilter.RadioLauncherTheme13.IsEnabled = true;
						}
						if (num >= 5)
						{
							ModMain.processFilter.RadioLauncherTheme14.IsEnabled = true;
						}
						ModAni.ListFactory(ModAni.InsertFactory() - 1);
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "检查主题失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}), false);
		}

		// Token: 0x060011C4 RID: 4548 RVA: 0x0007F4F0 File Offset: 0x0007D6F0
		public static bool MoveIterator(int no__var1)
		{
			checked
			{
				bool result;
				if (no__var1 == 8)
				{
					result = ModMain.ManageIterator(null);
				}
				else if (no__var1 == 0xE)
				{
					int num = 0;
					string[] array = ModBase._BaseRule.Get("UiLauncherThemeHide2", null).ToString().Split(new char[]
					{
						'|'
					});
					for (int i = 0; i < array.Length; i++)
					{
						int num2 = Conversions.ToInteger(array[i]);
						if (num2 >= 5 && num2 <= 0xE && num2 != 8)
						{
							num++;
						}
					}
					if (ModMain.ManageIterator(null))
					{
						num++;
					}
					result = (num >= 5);
				}
				else
				{
					result = (new int[]
					{
						0,
						1,
						2,
						3,
						4,
						0x2A
					}.Contains(no__var1) || ModBase._BaseRule.Get("UiLauncherThemeHide2", null).ToString().Split(new char[]
					{
						'|'
					}).Contains(no__var1.ToString()));
				}
				return result;
			}
		}

		// Token: 0x060011C5 RID: 4549 RVA: 0x0007F5CC File Offset: 0x0007D7CC
		public static bool ThemeUnlock(int Id, bool ShowDoubleHint = true, string UnlockHint = null)
		{
			object[] object_ = new object[]
			{
				Id,
				ShowDoubleHint,
				UnlockHint
			};
			return (bool)new GClass18().method_112(object_, 0xB1F3D);
		}

		// Token: 0x060011C6 RID: 4550 RVA: 0x0007F610 File Offset: 0x0007D810
		public static bool ManageIterator(string config = null)
		{
			string visitor = (config ?? ModBase._BaseRule.Get("UiLauncherThemeGold", null)).ToString().Replace("#", "");
			return ModBase.ResolveIterator("Gold|0|" + ModBase.ruleRule.Replace("-", ""), visitor);
		}

		// Token: 0x060011C7 RID: 4551 RVA: 0x0007F66C File Offset: 0x0007D86C
		public static void BackgroundRefresh(bool IsHint, bool Refresh)
		{
			try
			{
				List<string> list = new List<string>();
				try
				{
					foreach (string text in MyWpfExtension.RunFactory().FileSystem.GetFiles(ModBase.Path + "PCL\\Pictures\\", Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, new string[]
					{
						"*.*"
					}))
					{
						if (!text.ToLower().EndsWith(".ini"))
						{
							list.Add(text);
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
				if (list.Count == 0)
				{
					if (Refresh)
					{
						if (ModMain.m_GetterFilter.ImgBack.Visibility == Visibility.Collapsed)
						{
							if (IsHint)
							{
								ModMain.Hint("未检测到可用背景图片！", ModMain.HintType.Critical, true);
							}
						}
						else
						{
							ModMain.m_GetterFilter.ImgBack.Visibility = Visibility.Collapsed;
							if (IsHint)
							{
								ModMain.Hint("背景图片已清除！", ModMain.HintType.Finish, true);
							}
						}
					}
					if (!Information.IsNothing(ModMain.processFilter))
					{
						ModMain.processFilter.BackgroundRefreshUI(false, 0);
					}
				}
				else
				{
					if (Refresh)
					{
						string text2 = Conversions.ToString(ModBase.RandomOne(list));
						try
						{
							ModBase.Log("[UI] 加载背景图片：" + text2, ModBase.LogLevel.Normal, "出现错误");
							ModMain.m_GetterFilter.ImgBack.Background = new ModBitmap.MyBitmap(text2);
							ModBase._BaseRule.Load("UiBackgroundSuit", true, null);
							ModMain.m_GetterFilter.ImgBack.Visibility = Visibility.Visible;
							if (IsHint)
							{
								ModMain.Hint("背景图片已刷新：" + ModBase.GetFileNameFromPath(text2), ModMain.HintType.Finish, false);
							}
						}
						catch (Exception ex)
						{
							if (ex.Message.Contains("参数无效"))
							{
								ModBase.Log("刷新背景图片失败，该图片文件可能并非标准格式。\r\n你可以尝试使用画图打开该文件并重新保存，这会让图片变为标准格式。\r\n文件：" + text2, ModBase.LogLevel.Msgbox, "出现错误");
							}
							else
							{
								ModBase.Log(ex, "刷新背景图片失败（" + text2 + "）", ModBase.LogLevel.Msgbox, "出现错误");
							}
						}
					}
					if (!Information.IsNothing(ModMain.processFilter))
					{
						ModMain.processFilter.BackgroundRefreshUI(true, list.Count);
					}
				}
			}
			catch (Exception ex2)
			{
				ModBase.Log(ex2, "刷新背景图片时出现未知错误", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x060011C8 RID: 4552 RVA: 0x0007F8B8 File Offset: 0x0007DAB8
		public static void FeedbackLoad(ModLoader.LoaderTask<int, Dictionary<string, List<ModMain.FeedbackEntry>>> Loader)
		{
			checked
			{
				try
				{
					string text = Conversions.ToString(ModNet.NetGetCodeByRequestRetry("https://jinshuju.net/f/rP4b6E/r/rP4b6E/share_entries?per_page=300", Encoding.UTF8, "", false));
					if (!Loader.IsAborted)
					{
						if (text.Length < 0x3E8)
						{
							throw new Exception("获取的反馈列表内容异常：" + text);
						}
						List<string> list = ModBase.RegexSearch(text, "<tr [\\S\\s]*?</tr>", RegexOptions.None);
						ArrayList arrayList = new ArrayList();
						Dictionary<string, List<ModMain.FeedbackEntry>> dictionary = new Dictionary<string, List<ModMain.FeedbackEntry>>();
						bool flag = false;
						try
						{
							foreach (string str in list)
							{
								try
								{
									ModMain.FeedbackEntry feedbackEntry = default(ModMain.FeedbackEntry);
									feedbackEntry.roleMapper = Conversions.ToInteger(ModBase.RegexSearch(str, "(?<=serial_number\"[\\s\\S]+?title=\")[0-9]*", RegexOptions.None)[0]);
									feedbackEntry.Type = ModBase.RegexSearch(str, "(?<=field_1\"[\\s\\S]+?title=\")[^\"]*", RegexOptions.None)[0];
									feedbackEntry.Title = ModBase.RegexSearch(str, "(?<=field_12\"[\\s\\S]+?title=\")[^\"]*", RegexOptions.None)[0].Replace("&quot;", "\"").Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&#39;", "'").Replace("&amp;", "&");
									feedbackEntry.m_AdvisorMapper = ModBase.RegexSearch(str, "(?<=field_2\"[\\s\\S]+?title=\")[^\"]*", RegexOptions.None)[0];
									feedbackEntry._WriterMapper = ModBase.RegexSearch(str, "(?<=field_3\"[\\s\\S]+?title=\")[^\"]*", RegexOptions.None)[0].Replace("&quot;", "\"").Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&#39;", "'").Replace("&amp;", "&");
									feedbackEntry.recordMapper = ModBase.RegexSearch(str, "(?<=field_8\"[\\s\\S]+?title=\")[^\"]*", RegexOptions.None)[0];
									feedbackEntry._GetterMapper = ModBase.RegexSearch(str, "(?<=field_7\"[\\s\\S]+?title=\")[^\"]*", RegexOptions.None)[0].Replace("&quot;", "\"").Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&#39;", "'").Replace("&amp;", "&");
									feedbackEntry._WrapperMapper = Conversions.ToInteger(ModBase.RegexSearch(str, "(?<=field_14\"[\\s\\S]+?title=\")[0-9]*", RegexOptions.None)[0]);
									feedbackEntry.invocationMapper = ModBase.RegexSearch(str, "(?<=updated_at\"[\\s\\S]+?title=\")[^\"]*", RegexOptions.None)[0];
									feedbackEntry.m_InterceptorMapper = ModBase.RegexSearch(str, "(?<=created_at\"[\\s\\S]+?title=\")[^\"]*", RegexOptions.None)[0];
									feedbackEntry._ExporterMapper = ModBase.RegexSearch(str, "(?<=field_15\"[\\s\\S]+?title=\")[^\"]*", RegexOptions.None)[0];
									feedbackEntry._StrategyMapper = ModBase.RegexSearch(str, "(?<=field_10\"[\\s\\S]+?title=\")[^\"]*", RegexOptions.None)[0].Replace("&quot;", "\"").Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&#39;", "'").Replace("&amp;", "&");
									if (!feedbackEntry._StrategyMapper.EndsWith("！") && !feedbackEntry._StrategyMapper.EndsWith("？") && !feedbackEntry._StrategyMapper.EndsWith("…"))
									{
										ref string ptr = ref feedbackEntry._StrategyMapper;
										feedbackEntry._StrategyMapper = ptr + "。";
									}
									if (feedbackEntry.recordMapper.Contains(ModBase.ruleRule))
									{
										if (!dictionary.ContainsKey("我的反馈"))
										{
											dictionary.Add("我的反馈", new List<ModMain.FeedbackEntry>());
										}
										dictionary["我的反馈"].Add(feedbackEntry);
										List<string> list2 = ModBase.RegexSearch(Conversions.ToString(ModBase._BaseRule.Get("HintFeedback", null)), "(?<=\\[" + Conversions.ToString(feedbackEntry.roleMapper) + ",)[0-9]+", RegexOptions.None);
										if (list2.Count == 0)
										{
											ModBase._BaseRule.Set("HintFeedback", Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(ModBase._BaseRule.Get("HintFeedback", null), "["), feedbackEntry.roleMapper), ","), feedbackEntry._WrapperMapper), "]"), false, null);
											if (feedbackEntry._WrapperMapper > 0)
											{
												ModMain.MyMsgBox(string.Concat(new string[]
												{
													"你的反馈 ",
													feedbackEntry.Title,
													" 已收到回复。\r\n目前状态：",
													feedbackEntry.m_AdvisorMapper,
													"\r\n\r\n开发者回复（",
													ModBase.GetTimeSpanString(DateTime.Parse(feedbackEntry.invocationMapper) - DateTime.Now),
													"）：\r\n",
													feedbackEntry._StrategyMapper
												}), "反馈回复通知", "确定", "", "", false, true, false);
											}
										}
										else if (Conversions.ToDouble(list2[0]) < (double)feedbackEntry._WrapperMapper)
										{
											ModBase._BaseRule.Set("HintFeedback", ModBase.RegexReplace(Conversions.ToString(ModBase._BaseRule.Get("HintFeedback", null)), Conversions.ToString(feedbackEntry._WrapperMapper), "(?<=\\[" + Conversions.ToString(feedbackEntry.roleMapper) + ",)[0-9]+", RegexOptions.None), false, null);
											ModMain.MyMsgBox(string.Concat(new string[]
											{
												"你的反馈 ",
												feedbackEntry.Title,
												" 已收到回复。\r\n目前状态：",
												feedbackEntry.m_AdvisorMapper,
												"\r\n\r\n开发者回复（",
												ModBase.GetTimeSpanString(DateTime.Parse(feedbackEntry.invocationMapper) - DateTime.Now),
												"）：\r\n",
												feedbackEntry._StrategyMapper
											}), "反馈回复通知", "确定", "", "", false, true, false);
										}
										if ((Operators.CompareString(feedbackEntry.m_AdvisorMapper, "已处理", true) == 0 || Operators.CompareString(feedbackEntry.m_AdvisorMapper, "等待处理", true) == 0 || Operators.CompareString(feedbackEntry.m_AdvisorMapper, "等待更新", true) == 0 || Operators.CompareString(feedbackEntry.m_AdvisorMapper, "已放弃", true) == 0) && Operators.CompareString(feedbackEntry.Type, "Bug 汇报", true) == 0 && !flag)
										{
											flag = true;
											if (ModMain.ThemeUnlock(9, false, null))
											{
												ModMain.MyMsgBox("感谢你的支持，今后有什么问题也请多多反馈啦！\r\n隐藏主题 活跃橙 已解锁！", "提示", "确定", "", "", false, true, false);
											}
										}
									}
									if (Operators.CompareString(feedbackEntry.Type, "已忽略", true) != 0)
									{
										arrayList.Add(feedbackEntry);
									}
								}
								catch (Exception ex)
								{
									ModBase.Log(ex, "加载反馈列表项目失败", ModBase.LogLevel.Debug, "出现错误");
								}
							}
						}
						finally
						{
							List<string>.Enumerator enumerator;
							((IDisposable)enumerator).Dispose();
						}
						ModMain.FeedbackFilter(ref dictionary, arrayList, new string[]
						{
							"尚未查看"
						}, "未处理");
						ModMain.FeedbackFilter(ref dictionary, arrayList, new string[]
						{
							"等待确认",
							"正在处理"
						}, "处理中");
						ModMain.FeedbackFilter(ref dictionary, arrayList, new string[]
						{
							"等待更新",
							"已处理"
						}, "已处理");
						ModMain.FeedbackFilter(ref dictionary, arrayList, new string[]
						{
							"等待处理"
						}, "暂缓");
						ModMain.FeedbackFilter(ref dictionary, arrayList, new string[]
						{
							"已放弃"
						}, "放弃");
						ModMain.FeedbackFilter(ref dictionary, arrayList, new string[]
						{
							"已拒绝"
						}, "拒绝");
						try
						{
							foreach (KeyValuePair<string, List<ModMain.FeedbackEntry>> keyValuePair in dictionary)
							{
								for (;;)
								{
									IL_82E:
									int num = keyValuePair.Value.Count - 2;
									for (int i = 0; i <= num; i++)
									{
										if (Operators.CompareString(keyValuePair.Value[i].m_InterceptorMapper, keyValuePair.Value[i + 1].m_InterceptorMapper, true) < 0)
										{
											ModMain.FeedbackEntry value = keyValuePair.Value[i];
											keyValuePair.Value[i] = keyValuePair.Value[i + 1];
											keyValuePair.Value[i + 1] = value;
											goto IL_82E;
										}
									}
									break;
								}
							}
						}
						finally
						{
							Dictionary<string, List<ModMain.FeedbackEntry>>.Enumerator enumerator2;
							((IDisposable)enumerator2).Dispose();
						}
						if (!Loader.IsAborted)
						{
							Loader.Output = dictionary;
						}
					}
				}
				catch (Exception ex2)
				{
					ModBase.Log(ex2, "反馈列表加载失败", ModBase.LogLevel.Debug, "出现错误");
					throw;
				}
			}
		}

		// Token: 0x060011C9 RID: 4553 RVA: 0x000801B8 File Offset: 0x0007E3B8
		private static void FeedbackFilter(ref Dictionary<string, List<ModMain.FeedbackEntry>> Dict, ArrayList List, string[] Formula, string Key)
		{
			List<ModMain.FeedbackEntry> list = new List<ModMain.FeedbackEntry>();
			try
			{
				foreach (object obj in List)
				{
					ModMain.FeedbackEntry feedbackEntry = (obj != null) ? ((ModMain.FeedbackEntry)obj) : default(ModMain.FeedbackEntry);
					foreach (string right in Formula)
					{
						if (Operators.CompareString(feedbackEntry.m_AdvisorMapper, right, true) == 0)
						{
							list.Add(feedbackEntry);
							break;
						}
					}
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
			if (list.Count > 0)
			{
				Dict.Add(Key, list);
			}
		}

		// Token: 0x060011CA RID: 4554 RVA: 0x00080268 File Offset: 0x0007E468
		public static void FeedbackListLoad(Dictionary<string, List<ModMain.FeedbackEntry>> Dict)
		{
			try
			{
				if (ModMain.readerFilter == null)
				{
					ModMain.readerFilter = new PageOtherFeedback();
				}
				ModMain.readerFilter.PanList.Children.Clear();
				ModMain.readerFilter.PanBack.ScrollToHome();
				try
				{
					foreach (KeyValuePair<string, List<ModMain.FeedbackEntry>> keyValuePair in Dict)
					{
						string text = keyValuePair.Key;
						string left = text;
						if (Operators.CompareString(left, "我的反馈", true) == 0 || Operators.CompareString(left, "处理中", true) == 0 || Operators.CompareString(left, "未处理", true) == 0)
						{
							text = text + " (" + Conversions.ToString(keyValuePair.Value.Count) + ")";
						}
						MyCard myCard = new MyCard();
						myCard.Title = text;
						myCard.Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
						myCard.InitFactory(1);
						MyCard myCard2 = myCard;
						StackPanel stackPanel = new StackPanel
						{
							Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
							VerticalAlignment = VerticalAlignment.Top,
							RenderTransform = new TranslateTransform(0.0, 0.0),
							Tag = keyValuePair.Value
						};
						if (Operators.CompareString(keyValuePair.Key, "我的反馈", true) == 0)
						{
							stackPanel.Children.Add(new MyHint
							{
								_Candidate = "HintFeedbackDelete",
								CanClose = true,
								IsWarn = false,
								Margin = new Thickness(0.0, 0.0, 0.0, 8.0),
								Text = "为保证反馈页面的加载速度，已处理或已忽略的反馈可能会在保留数天后被删除。"
							});
						}
						myCard2.Children.Add(stackPanel);
						myCard2.thread = stackPanel;
						if (Operators.CompareString(keyValuePair.Key, "我的反馈", true) != 0 && Operators.CompareString(keyValuePair.Key, "处理中", true) != 0 && Operators.CompareString(keyValuePair.Key, "未处理", true) != 0)
						{
							myCard2.IsSwaped = true;
						}
						else
						{
							MyCard.StackInstall(ref stackPanel, 1, keyValuePair.Key);
						}
						ModMain.readerFilter.PanList.Children.Add(myCard2);
					}
				}
				finally
				{
					Dictionary<string, List<ModMain.FeedbackEntry>>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "加载反馈列表 UI 失败", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x060011CB RID: 4555 RVA: 0x00080530 File Offset: 0x0007E730
		public static MyListItem FeedbackListItem(ModMain.FeedbackEntry Entry, string CardTitle)
		{
			string type = Entry.Type;
			string logo;
			if (Operators.CompareString(type, "优化建议", true) == 0)
			{
				logo = "pack://application:,,,/images/Blocks/Grass.png";
			}
			else if (Operators.CompareString(type, "新功能提议", true) == 0)
			{
				logo = "pack://application:,,,/images/Blocks/Anvil.png";
			}
			else
			{
				logo = "pack://application:,,,/images/Blocks/RedstoneBlock.png";
			}
			MyListItem myListItem = new MyListItem
			{
				Logo = logo,
				SnapsToDevicePixels = true,
				Title = Entry.Title,
				Info = ((Operators.CompareString(CardTitle, "已处理", true) == 0 || Operators.CompareString(CardTitle, "处理中", true) == 0 || Operators.CompareString(CardTitle, "我的反馈", true) == 0) ? (Entry.m_AdvisorMapper + "：") : string.Empty) + Entry._StrategyMapper.TrimEnd(new char[]
				{
					'。'
				}),
				Height = 42.0,
				Type = MyListItem.CheckType.Clickable,
				Tag = Entry,
				PaddingRight = 4
			};
			myListItem.QueryModel(delegate(object sender, MouseButtonEventArgs e)
			{
				base._Lambda$__0();
			});
			return myListItem;
		}

		// Token: 0x060011CC RID: 4556 RVA: 0x00080660 File Offset: 0x0007E860
		private static string FeedbackDesc(ModMain.FeedbackEntry Entry)
		{
			string text = "";
			if (!string.IsNullOrWhiteSpace(Entry._GetterMapper))
			{
				text = string.Concat(new string[]
				{
					text,
					"提交者：",
					Entry._GetterMapper,
					"（",
					ModBase.GetTimeSpanString(DateTime.Parse(Entry.m_InterceptorMapper) - DateTime.Now),
					"）"
				});
			}
			else
			{
				text = text + "提交于：" + ModBase.GetTimeSpanString(DateTime.Parse(Entry.m_InterceptorMapper) - DateTime.Now);
			}
			text = text + "\r\n状态：" + Entry.m_AdvisorMapper;
			if (!string.IsNullOrWhiteSpace(Entry._WriterMapper))
			{
				text = text + "\r\n\r\n" + Entry._WriterMapper;
			}
			if (!Entry._StrategyMapper.Contains("未查看该反馈"))
			{
				text = text + "\r\n\r\n开发者回复：\r\n" + Entry._StrategyMapper;
			}
			return text;
		}

		// Token: 0x060011CD RID: 4557 RVA: 0x0008074C File Offset: 0x0007E94C
		public static void HelpLoad(ModLoader.LoaderTask<int, List<ModMain.HelpEntry>> Loader)
		{
			object obj = ModMain.listFilter;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			checked
			{
				lock (obj)
				{
					try
					{
						ModBase.Log("[Help] 正在检查内置帮助文件", ModBase.LogLevel.Normal, "出现错误");
						if (Operators.ConditionalCompareObjectNotEqual(ModBase._BaseRule.Get("SystemHelpVersion", null), 0xEA, true) || !File.Exists(ModBase.m_GlobalRule + "Help\\启动器\\联机.xaml"))
						{
							ModBase.DeleteDirectory(ModBase.m_GlobalRule + "Help", false);
							Directory.CreateDirectory(ModBase.m_GlobalRule + "Help");
							ModBase.WriteFile(ModBase.m_GlobalRule + "Cache\\Help.zip", ModBase.GetResources("Help"), false);
							ModBase.ExtractFile(ModBase.m_GlobalRule + "Cache\\Help.zip", ModBase.m_GlobalRule + "Help", Encoding.UTF8);
							ModBase._BaseRule.Set("SystemHelpVersion", 0xEA, false, null);
							ModBase.Log("[Help] 已解压内置帮助文件：" + Conversions.ToString(File.Exists(ModBase.m_GlobalRule + "Help\\启动器\\联机.xaml")), ModBase.LogLevel.Normal, "出现错误");
						}
						List<string> list = new List<string>();
						try
						{
							List<string> list2 = new List<string>();
							if (Directory.Exists(ModBase.Path + "PCL\\Help\\"))
							{
								try
								{
									foreach (FileInfo fileInfo in ModBase.EnumerateFiles(ModBase.Path + "PCL\\Help\\"))
									{
										if (Operators.CompareString(fileInfo.Extension.ToLower(), ".helpignore", true) == 0)
										{
											ModBase.Log("[Help] 发现 .helpignore 文件：" + fileInfo.FullName, ModBase.LogLevel.Normal, "出现错误");
											string[] array = File.ReadAllLines(fileInfo.FullName);
											for (int i = 0; i < array.Length; i++)
											{
												string text = array[i].Split(new char[]
												{
													'#'
												}).First<string>().Trim();
												if (!string.IsNullOrWhiteSpace(text))
												{
													list2.Add(text);
													if (ModBase.errorRule)
													{
														ModBase.Log("[Help]  > " + text, ModBase.LogLevel.Normal, "出现错误");
													}
												}
											}
										}
										else if (Operators.CompareString(fileInfo.Extension.ToLower(), ".json", true) == 0)
										{
											list.Add(fileInfo.FullName);
										}
									}
								}
								finally
								{
									List<FileInfo>.Enumerator enumerator;
									((IDisposable)enumerator).Dispose();
								}
							}
							ModBase.Log("[Help] 已扫描 PCL 文件夹下的帮助文件，目前总计 " + Conversions.ToString(list.Count) + " 条", ModBase.LogLevel.Normal, "出现错误");
							try
							{
								List<FileInfo>.Enumerator enumerator2 = ModBase.EnumerateFiles(ModBase.m_GlobalRule + "Help").GetEnumerator();
								IL_387:
								while (enumerator2.MoveNext())
								{
									FileInfo fileInfo2 = enumerator2.Current;
									if (Operators.CompareString(fileInfo2.Extension.ToLower(), ".json", true) == 0 && !fileInfo2.Directory.FullName.Replace(ModBase.m_GlobalRule + "Help", "").Contains("\\."))
									{
										string text2 = fileInfo2.FullName.Replace(ModBase.m_GlobalRule + "Help\\", "");
										try
										{
											foreach (string text3 in list2)
											{
												if (ModBase.RegexCheck(text2, text3, RegexOptions.None))
												{
													if (ModBase.errorRule)
													{
														ModBase.Log("[Help] 已忽略 " + text2 + "：" + text3, ModBase.LogLevel.Normal, "出现错误");
													}
													goto IL_387;
												}
											}
										}
										finally
										{
											List<string>.Enumerator enumerator3;
											((IDisposable)enumerator3).Dispose();
										}
										list.Add(fileInfo2.FullName);
									}
								}
							}
							finally
							{
								List<FileInfo>.Enumerator enumerator2;
								((IDisposable)enumerator2).Dispose();
							}
							ModBase.Log("[Help] 已扫描缓存文件夹下的帮助文件，目前总计 " + Conversions.ToString(list.Count) + " 条", ModBase.LogLevel.Normal, "出现错误");
						}
						catch (Exception ex)
						{
							ModBase.Log(ex, "检查帮助文件夹失败", ModBase.LogLevel.Msgbox, "出现错误");
						}
						if (!Loader.IsAborted)
						{
							List<ModMain.HelpEntry> list3 = new List<ModMain.HelpEntry>();
							try
							{
								foreach (string text4 in list)
								{
									try
									{
										ModMain.HelpEntry helpEntry = new ModMain.HelpEntry(text4);
										list3.Add(helpEntry);
										if (ModBase.errorRule)
										{
											ModBase.Log("[Help] 已加载的帮助条目：" + helpEntry.Title + " ← " + text4, ModBase.LogLevel.Normal, "出现错误");
										}
									}
									catch (Exception ex2)
									{
										ModBase.Log(ex2, "初始化帮助条目失败（" + text4 + "）", ModBase.LogLevel.Msgbox, "出现错误");
									}
								}
							}
							finally
							{
								List<string>.Enumerator enumerator4;
								((IDisposable)enumerator4).Dispose();
							}
							if (list3.Count == 0)
							{
								throw new Exception("未找到可用的帮助；若不需要帮助页面，可以在 设置 → 个性化 → 功能隐藏 中将其隐藏");
							}
							if (!Loader.IsAborted)
							{
								Loader.Output = list3;
							}
						}
					}
					catch (Exception ex3)
					{
						ModBase.Log(ex3, "帮助列表初始化失败", ModBase.LogLevel.Debug, "出现错误");
						throw;
					}
				}
			}
		}

		// Token: 0x060011CE RID: 4558 RVA: 0x00080D00 File Offset: 0x0007EF00
		public static void HelpListLoad(List<ModMain.HelpEntry> HelpItems)
		{
			try
			{
				if (ModMain.m_AdapterFilter == null)
				{
					ModMain.m_AdapterFilter = new PageOtherHelp();
				}
				ModMain.m_AdapterFilter.PanList.Children.Clear();
				ModMain.m_AdapterFilter.PanBack.ScrollToHome();
				List<string> list = new List<string>();
				try
				{
					foreach (ModMain.HelpEntry helpEntry in HelpItems)
					{
						if ((ModBase.Val("0") != 50.0 || helpEntry.dispatcherMapper) && (ModBase.Val("0") == 50.0 || helpEntry.m_TagMapper))
						{
							try
							{
								foreach (string item in helpEntry.m_ContextMapper)
								{
									if (!list.Contains(item))
									{
										list.Add(item);
									}
								}
							}
							finally
							{
								List<string>.Enumerator enumerator2;
								((IDisposable)enumerator2).Dispose();
							}
						}
					}
				}
				finally
				{
					List<ModMain.HelpEntry>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				if (list.Contains("指南"))
				{
					list.Remove("指南");
					list.Insert(0, "指南");
				}
				try
				{
					foreach (string text in list)
					{
						List<ModMain.HelpEntry> list2 = new List<ModMain.HelpEntry>();
						try
						{
							foreach (ModMain.HelpEntry helpEntry2 in HelpItems)
							{
								if ((ModBase.Val("0") != 50.0 || helpEntry2.dispatcherMapper) && (ModBase.Val("0") == 50.0 || helpEntry2.m_TagMapper) && helpEntry2.m_ContextMapper.Contains(text))
								{
									list2.Add(helpEntry2);
								}
							}
						}
						finally
						{
							List<ModMain.HelpEntry>.Enumerator enumerator4;
							((IDisposable)enumerator4).Dispose();
						}
						MyCard myCard = new MyCard();
						myCard.Title = text;
						myCard.Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
						myCard.InitFactory(0xB);
						MyCard myCard2 = myCard;
						StackPanel stackPanel = new StackPanel
						{
							Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
							VerticalAlignment = VerticalAlignment.Top,
							RenderTransform = new TranslateTransform(0.0, 0.0),
							Tag = list2
						};
						myCard2.Children.Add(stackPanel);
						myCard2.thread = stackPanel;
						if (Operators.CompareString(text, "指南", true) == 0)
						{
							MyCard.StackInstall(ref stackPanel, 0xB, "指南");
						}
						else
						{
							myCard2.IsSwaped = true;
						}
						ModMain.m_AdapterFilter.PanList.Children.Add(myCard2);
					}
				}
				finally
				{
					List<string>.Enumerator enumerator3;
					((IDisposable)enumerator3).Dispose();
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "加载帮助列表 UI 失败", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x060011CF RID: 4559 RVA: 0x00081074 File Offset: 0x0007F274
		private static void ServerSub(ModLoader.LoaderTask<int, int> Loader)
		{
			try
			{
				if (File.Exists(ModBase.Path + "PCL\\update.exe"))
				{
					File.Delete(ModBase.Path + "PCL\\update.exe");
					ModBase.Log("[Server] 已清理更新缓存", ModBase.LogLevel.Normal, "出现错误");
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "清理更新缓存失败", ModBase.LogLevel.Debug, "出现错误");
			}
			ModBase.Log("[Server] 正在连接到 PCL2 服务器", ModBase.LogLevel.Normal, "出现错误");
			try
			{
				ModMain.ServerSubReal();
			}
			catch (Exception ex2)
			{
				ModBase.Log(ex2, "连接到 PCL2 服务器失败", ModBase.LogLevel.Debug, "出现错误");
			}
		}

		// Token: 0x060011D0 RID: 4560 RVA: 0x00081130 File Offset: 0x0007F330
		private static void ServerSubReal()
		{
			int num = Conversions.ToInteger(ModBase._BaseRule.Get("HintNotice", null));
			int num2 = Conversions.ToInteger(ModBase._BaseRule.Get("HintDownload", null));
			checked
			{
				int num3;
				int num4;
				try
				{
					string text = Conversions.ToString(ModNet.NetGetCodeByRequestRetry("http://pcl2-server-1253424809.file.myqcloud.com/notice.cfg{CDN}", null, "", false));
					num3 = (int)Math.Round(ModBase.Val(text.Split(new char[]
					{
						'|'
					})[0]));
					num4 = (int)Math.Round(ModBase.Val(text.Split(new char[]
					{
						'|'
					})[3]));
					if (num3 == 0)
					{
						throw new Exception("获取到的内容有误！（" + text + "）");
					}
					if (num3 > num)
					{
						ModBase.Log(string.Concat(new string[]
						{
							"[Server] 服务器公告：",
							text,
							"，本地公告编号：",
							Conversions.ToString(num),
							"，需更新"
						}), ModBase.LogLevel.Normal, "出现错误");
					}
					else
					{
						ModBase.Log("[Server] 服务器公告：" + text + "，无需更新", ModBase.LogLevel.Normal, "出现错误");
					}
					ModBase.WriteFile(ModBase.m_GlobalRule + "Cache\\Notice.cfg", text, false, null);
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "获取 PCL2 服务器状态失败", ModBase.LogLevel.Debug, "出现错误");
				}
				if (Conversions.ToBoolean(NewLateBinding.LateGet(ModBase._BaseRule.Get("UiLauncherThemeHide2", null), null, "Contains", new object[]
				{
					"42"
				}, null, null, null)))
				{
					ModBase._BaseRule.Set("UiLauncherThemeHide2", "3", false, null);
				}
				try
				{
					if (num4 > num2 || !File.Exists(ModBase.m_GlobalRule + "download.json"))
					{
						string text2 = ModNet.NetGetCodeByDownload("http://pcl2-server-1253424809.file.myqcloud.com/minecraft/download.json{CDN}", 0xAFC8, true);
						Directory.CreateDirectory(ModBase.m_GlobalRule + "Cache\\");
						ModBase.WriteFile(ModBase.m_GlobalRule + "Cache\\download.json", text2, false, null);
					}
					ModBase._BaseRule.Set("HintDownload", num4, false, null);
				}
				catch (Exception ex2)
				{
					ModBase.Log(ex2, "下载 PCL2 特供版信息失败", ModBase.LogLevel.Debug, "出现错误");
					File.Delete(ModBase.m_GlobalRule + "Cache\\download.json");
				}
				string text3;
				try
				{
					if (num3 <= num && File.Exists(ModBase.m_GlobalRule + "Cache\\Notice.json"))
					{
						text3 = ModBase.ReadFile(ModBase.m_GlobalRule + "Cache\\Notice.json");
					}
					else
					{
						text3 = Conversions.ToString(ModNet.NetGetCodeByRequestRetry("http://pcl2-server-1253424809.file.myqcloud.com/notice.json{CDN}", null, "", false));
						Directory.CreateDirectory(ModBase.m_GlobalRule + "Cache\\");
						ModBase.WriteFile(ModBase.m_GlobalRule + "Cache\\Notice.json", text3, false, null);
					}
					ModBase._BaseRule.Set("HintNotice", num3, false, null);
				}
				catch (Exception ex3)
				{
					ModBase.Log(ex3, "下载 PCL2 服务器公告失败", ModBase.LogLevel.Debug, "出现错误");
					File.Delete(ModBase.m_GlobalRule + "Cache\\Notice.json");
					return;
				}
				try
				{
					try
					{
						foreach (object obj in ((IEnumerable)ModBase.GetJson(text3.Replace("{UNIQUE}", ModBase.ruleRule))))
						{
							JObject jobject = (JObject)obj;
							int num5 = (int)Math.Round(ModBase.Val(jobject["id"] ?? 0));
							if (num5 > num)
							{
								bool flag = true;
								try
								{
									foreach (JToken jtoken in ((IEnumerable<JToken>)(jobject["requirements"] ?? new byte[0])))
									{
										JProperty jproperty = (JProperty)jtoken;
										if (!ModMain.ServerRequirement(jproperty.Name, jproperty.Value))
										{
											flag = false;
										}
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
								if (flag)
								{
									int num6 = (int)(jobject["importantLevel"] ?? 2);
									bool flag2 = (bool)(jobject["isUpdate"] ?? false);
									ModBase.Log("[Server] 重要等级 " + Conversions.ToString(num6) + "，更新公告 " + Conversions.ToString(flag2), ModBase.LogLevel.Normal, "出现错误");
									if (!Operators.ConditionalCompareObjectGreater(ModBase._BaseRule.Get(flag2 ? "SystemSystemUpdate" : "SystemSystemActivity", null), num6, true) && (!flag2 || !ModMain.messageFilter))
									{
										string title = (jobject["title"] ?? "公告").ToString();
										string text4 = (jobject["description"] ?? "").ToString().Replace("\\n", "\r\n");
										JContainer jcontainer = (JContainer)(jobject["buttons"] ?? ModBase.GetJson("[]"));
										int count = jcontainer.Count;
										object obj2 = new object[0];
										if (count > 0)
										{
											ModBase.Log("[Server] 显示公告 " + Conversions.ToString(num5) + "：" + text4, ModBase.LogLevel.Normal, "出现错误");
											int num7;
											switch (count)
											{
											case 1:
												num7 = ModMain.MyMsgBox(text4, title, (jcontainer[0]["text"] ?? "确定").ToString(), "", "", false, true, true);
												break;
											case 2:
												num7 = ModMain.MyMsgBox(text4, title, (jcontainer[0]["text"] ?? "确定").ToString(), (jcontainer[1]["text"] ?? "确定").ToString(), "", false, true, false);
												break;
											case 3:
												num7 = ModMain.MyMsgBox(text4, title, (jcontainer[0]["text"] ?? "确定").ToString(), (jcontainer[1]["text"] ?? "确定").ToString(), (jcontainer[2]["text"] ?? "确定").ToString(), false, true, false);
												break;
											default:
												ModBase.Log(string.Concat(new string[]
												{
													"[Server] 公告 ",
													Conversions.ToString(num5),
													" 的弹窗有 ",
													Conversions.ToString(count),
													" 个按钮，无法显示"
												}), ModBase.LogLevel.Debug, "出现错误");
												continue;
											}
											num7 = (int)Math.Round(ModBase.MathRange((double)num7, 1.0, (double)count));
											obj2 = (jcontainer[num7 - 1]["actions"] ?? new byte[0]);
										}
										else
										{
											obj2 = (jobject["actions"] ?? new byte[0]);
										}
										try
										{
											foreach (object obj3 in ((IEnumerable)obj2))
											{
												JProperty jproperty2 = (JProperty)obj3;
												try
												{
													string name = jproperty2.Name;
													if (Operators.CompareString(name, "copy", true) == 0)
													{
														ModBase.ClipboardSet(jproperty2.Value.ToString(), true);
													}
													else if (Operators.CompareString(name, "shell", true) == 0)
													{
														Process.Start(jproperty2.Value.ToString());
													}
													else if (Operators.CompareString(name, "stop", true) == 0)
													{
														ModMain.m_GetterFilter.EndProgram(false);
													}
													else if (Operators.CompareString(name, "setup", true) == 0)
													{
														ModBase._BaseRule.Set(((JProperty)jproperty2.Value).Name, ((JProperty)jproperty2.Value).Value.ToString(), false, null);
													}
													else if (Operators.CompareString(name, "slientupdate", true) == 0)
													{
														JObject jobject2 = (JObject)jproperty2.Value;
														if (jobject2["requireUserInput"] != null && jobject2["requireUserInput"].ToObject<bool>())
														{
															if (ModMain.CanSkipUpdateMark())
															{
																ModMain.UpdateStart((jobject2["url"] ?? "http://pcl2-server-1253424809.file.myqcloud.com/update/{KEY}.zip{CDN}").ToString(), true, null, false);
															}
														}
														else
														{
															ModMain.UpdateStart((jobject2["url"] ?? "http://pcl2-server-1253424809.file.myqcloud.com/update/{KEY}.zip{CDN}").ToString(), true, null, true);
														}
													}
													else
													{
														if (Operators.CompareString(name, "update", true) != 0)
														{
															throw new Exception("未知的行动支：" + jproperty2.Name + ", " + jproperty2.Value.ToString());
														}
														JObject jobject3 = (JObject)jproperty2.Value;
														if (jobject3["requireUserInput"] != null && jobject3["requireUserInput"].ToObject<bool>())
														{
															string text5 = null;
															if (!ModMain.CanSkipUpdateMark())
															{
																text5 = ModMain.MyMsgBoxInput("", new Collection<Validate>
																{
																	new ValidateNullOrWhiteSpace()
																}, "", "输入更新密钥", "确定", "取消", false);
																if (text5 == null)
																{
																	return;
																}
															}
															ModMain.UpdateStart((jobject3["url"] ?? "http://pcl2-server-1253424809.file.myqcloud.com/update/{KEY}.zip{CDN}").ToString(), false, text5, false);
														}
														else
														{
															ModMain.UpdateStart((jobject3["url"] ?? "http://pcl2-server-1253424809.file.myqcloud.com/update/{KEY}.zip{CDN}").ToString(), false, null, true);
														}
													}
												}
												catch (Exception ex4)
												{
													ModBase.Log(ex4, string.Concat(new string[]
													{
														"执行 PCL2 服务器公告动作失败（",
														jproperty2.Name,
														", ",
														jproperty2.Value.ToString(),
														"）"
													}), ModBase.LogLevel.Hint, "出现错误");
												}
											}
										}
										finally
										{
											IEnumerator enumerator3;
											if (enumerator3 is IDisposable)
											{
												(enumerator3 as IDisposable).Dispose();
											}
										}
									}
								}
							}
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
				catch (Exception ex5)
				{
					ModBase.Log(text3, ModBase.LogLevel.Normal, "出现错误");
					ModBase.Log(ex5, "读取 PCL2 服务器公告失败（" + Conversions.ToString(text3.Length) + "）", ModBase.LogLevel.Hint, "出现错误");
					File.Delete(ModBase.m_GlobalRule + "Cache\\Notice.json");
				}
			}
		}

		// Token: 0x060011D1 RID: 4561 RVA: 0x00081C8C File Offset: 0x0007FE8C
		private static bool ServerRequirement(string Name, JToken Value)
		{
			checked
			{
				bool result;
				try
				{
					if (Operators.CompareString(Name, "d10000 <=", true) == 0)
					{
						result = ((double)ModBase.RandomInteger(1, 0x2710) <= ModBase.Val(Value));
					}
					else if (Operators.CompareString(Name, "opencount <=", true) == 0)
					{
						result = Operators.ConditionalCompareObjectLessEqual(ModBase._BaseRule.Get("SystemCount", null), ModBase.Val(Value), true);
					}
					else if (Operators.CompareString(Name, "opencount >=", true) == 0)
					{
						result = Operators.ConditionalCompareObjectGreaterEqual(ModBase._BaseRule.Get("SystemCount", null), ModBase.Val(Value), true);
					}
					else if (Operators.CompareString(Name, "versioncode <=", true) == 0)
					{
						result = (234.0 <= ModBase.Val(Value));
					}
					else if (Operators.CompareString(Name, "versioncode >=", true) == 0)
					{
						result = (234.0 >= ModBase.Val(Value));
					}
					else if (Operators.CompareString(Name, "versionbranch <=", true) == 0)
					{
						result = (ModBase.Val("0") <= ModBase.Val(Value));
					}
					else if (Operators.CompareString(Name, "versionbranch >=", true) == 0)
					{
						result = (ModBase.Val("0") >= ModBase.Val(Value));
					}
					else if (Operators.CompareString(Name, "uniqueaddress =", true) == 0)
					{
						result = (Operators.CompareString(ModBase.ruleRule, Value.ToString(), true) == 0);
					}
					else if (Operators.CompareString(Name, "unlockedtheme =", true) == 0)
					{
						result = ModMain.MoveIterator((int)Math.Round(ModBase.Val(Value)));
					}
					else if (Operators.CompareString(Name, "unlockedtheme !=", true) == 0)
					{
						result = !ModMain.MoveIterator((int)Math.Round(ModBase.Val(Value)));
					}
					else if (Operators.CompareString(Name, "setupinteger >=", true) == 0)
					{
						result = Operators.ConditionalCompareObjectGreaterEqual(ModBase._BaseRule.Get(((JProperty)Value).Name, null), ModBase.Val(((JProperty)Value).Value), true);
					}
					else if (Operators.CompareString(Name, "setupinteger <=", true) == 0)
					{
						result = Operators.ConditionalCompareObjectLessEqual(ModBase._BaseRule.Get(((JProperty)Value).Name, null), ModBase.Val(((JProperty)Value).Value), true);
					}
					else if (Operators.CompareString(Name, "setupboolean =", true) == 0)
					{
						result = (Operators.CompareString(ModBase._BaseRule.Get(((JProperty)Value).Name, null).ToString().ToLower(), ((JProperty)Value).Value.ToString().ToLower(), true) == 0);
					}
					else if (Operators.CompareString(Name, "debug =", true) == 0)
					{
						result = (Operators.CompareString(ModBase.errorRule.ToString().ToLower(), Value.ToString().ToLower(), true) == 0);
					}
					else if (Operators.CompareString(Name, "keyhash !=", true) == 0)
					{
						result = (ModBase.GetHash(ModBase._FacadeRule.ToLower()) != ModBase.GetHash(Value.ToString().ToLower()));
					}
					else
					{
						ModBase.Log("[Server] 未知的条件支：" + Name + ", " + Value.ToString(), ModBase.LogLevel.Debug, "出现错误");
						result = false;
					}
				}
				catch (Exception ex)
				{
					ModBase.Log("[Server] 判断分支条件失败：" + Name + ", " + Value.ToString(), ModBase.LogLevel.Debug, "出现错误");
					result = false;
				}
				return result;
			}
		}

		// Token: 0x060011D2 RID: 4562 RVA: 0x00082004 File Offset: 0x00080204
		private static void TimerFool()
		{
			try
			{
				if (ModMain.m_InvocationFilter != null && ModMain.m_InvocationFilter.AprilPosTrans != null && ModMain.m_GetterFilter._FactoryFilter != null)
				{
					if (!ModMain.m_ClientFilter && !(ModMain.m_GetterFilter.publisherDecorator != FormMain.PageType.Launch) && ModAni.InsertFactory() == 0 && ModMain.m_InvocationFilter.BtnLaunch.IsLoaded)
					{
						Point position = ModMain.m_GetterFilter._FactoryFilter.GetPosition(ModMain.m_GetterFilter);
						double num;
						double num2;
						Vector vector;
						Vector vector3;
						checked
						{
							if (position == ModMain.publisherFilter)
							{
								ModMain.composerFilter++;
							}
							else
							{
								ModMain.publisherFilter = position;
								ModMain.composerFilter = 0;
							}
							num = ModMain.m_InvocationFilter.BtnLaunch.ActualWidth / 2.0;
							num2 = ModMain.m_InvocationFilter.BtnLaunch.ActualHeight / 2.0;
							vector = (Vector)(ModMain.m_GetterFilter._FactoryFilter.GetPosition(ModMain.m_InvocationFilter.BtnLaunch) - new Vector(num, num2));
							Vector vector2 = new Vector(vector.X, vector.Y);
							vector2.Normalize();
							vector3 = -vector2;
						}
						double length = new Vector(Math.Max(0.0, Math.Abs(vector.X) - num), Math.Max(0.0, Math.Abs(vector.Y) - num2)).Length;
						double num3 = Math.Sin((double)ModMain._ModelRule / 37.5 * 3.1415926535897931);
						Vector vector4 = Math.Max(0.0, num3 * 0.25 - 0.65 - Math.Log((length + 0.4) / 200.0)) * vector3;
						if (ModMain.composerFilter >= 0x140)
						{
							Vector vector5 = (Vector)(ModMain.m_GetterFilter._FactoryFilter.GetPosition(ModMain.m_GetterFilter.PanMain) - new Vector(num, ModMain.m_GetterFilter.PanMain.ActualHeight - num2 * 3.0));
							Vector vector6 = new Vector(ModMain.m_InvocationFilter.AprilPosTrans.X, ModMain.m_InvocationFilter.AprilPosTrans.Y);
							if (vector5.Length > 250.0 && vector6.Length > 0.4)
							{
								vector4 -= vector6 * 0.0005;
								vector6.Normalize();
								vector4 -= vector6 * 0.15;
							}
						}
						Point point = ModMain.m_InvocationFilter.BtnLaunch.TranslatePoint(new Point(0.0, 0.0), ModMain.m_GetterFilter.PanForm);
						if (point.X < -num * 2.0)
						{
							TranslateTransform aprilPosTrans;
							(aprilPosTrans = ModMain.m_InvocationFilter.AprilPosTrans).X = aprilPosTrans.X + (ModMain.m_GetterFilter.PanForm.ActualWidth + num * 2.0);
							ModMain._MapFilter.X = ModMain._MapFilter.X - 80.0;
							if (point.Y < 0.0)
							{
								(aprilPosTrans = ModMain.m_InvocationFilter.AprilPosTrans).Y = aprilPosTrans.Y + num2 * 2.5;
							}
							else if (point.Y > ModMain.m_GetterFilter.PanForm.ActualHeight - num2 * 2.0)
							{
								(aprilPosTrans = ModMain.m_InvocationFilter.AprilPosTrans).Y = aprilPosTrans.Y - num2 * 2.5;
							}
						}
						else if (point.X > ModMain.m_GetterFilter.PanForm.ActualWidth)
						{
							TranslateTransform aprilPosTrans;
							(aprilPosTrans = ModMain.m_InvocationFilter.AprilPosTrans).X = aprilPosTrans.X - (ModMain.m_GetterFilter.PanForm.ActualWidth + num * 2.0);
							ModMain._MapFilter.X = ModMain._MapFilter.X + 80.0;
							if (point.Y < 0.0)
							{
								(aprilPosTrans = ModMain.m_InvocationFilter.AprilPosTrans).Y = aprilPosTrans.Y + num2 * 2.5;
							}
							else if (point.Y > ModMain.m_GetterFilter.PanForm.ActualHeight - num2 * 2.0)
							{
								(aprilPosTrans = ModMain.m_InvocationFilter.AprilPosTrans).Y = aprilPosTrans.Y - num2 * 2.5;
							}
						}
						else if (point.Y < -num2 * 2.0)
						{
							TranslateTransform aprilPosTrans;
							(aprilPosTrans = ModMain.m_InvocationFilter.AprilPosTrans).Y = aprilPosTrans.Y + (ModMain.m_GetterFilter.PanForm.ActualHeight + num2 * 2.0);
							ModMain._MapFilter.Y = ModMain._MapFilter.Y - 25.0;
							if (point.X < 0.0)
							{
								(aprilPosTrans = ModMain.m_InvocationFilter.AprilPosTrans).X = aprilPosTrans.X + num * 2.0;
							}
							else if (point.X > ModMain.m_GetterFilter.PanForm.ActualWidth - num * 2.0)
							{
								(aprilPosTrans = ModMain.m_InvocationFilter.AprilPosTrans).X = aprilPosTrans.X - num * 2.0;
							}
						}
						else if (point.Y > ModMain.m_GetterFilter.PanForm.ActualHeight)
						{
							TranslateTransform aprilPosTrans;
							(aprilPosTrans = ModMain.m_InvocationFilter.AprilPosTrans).Y = aprilPosTrans.Y - (ModMain.m_GetterFilter.PanForm.ActualHeight + num2 * 2.0);
							ModMain._MapFilter.Y = ModMain._MapFilter.Y + 25.0;
							if (point.X < 0.0)
							{
								(aprilPosTrans = ModMain.m_InvocationFilter.AprilPosTrans).X = aprilPosTrans.X + num * 2.0;
							}
							else if (point.X > ModMain.m_GetterFilter.PanForm.ActualWidth - num * 2.0)
							{
								(aprilPosTrans = ModMain.m_InvocationFilter.AprilPosTrans).X = aprilPosTrans.X - num * 2.0;
							}
						}
						ModMain._MapFilter = ModMain._MapFilter * 0.8 + vector4;
						double num4 = Math.Min(80.0, ModMain._MapFilter.Length);
						if (num4 >= 0.01)
						{
							ModMain._MapFilter.Normalize();
							ModMain._MapFilter *= num4;
							TranslateTransform aprilPosTrans;
							(aprilPosTrans = ModMain.m_InvocationFilter.AprilPosTrans).X = aprilPosTrans.X + ModMain._MapFilter.X;
							(aprilPosTrans = ModMain.m_InvocationFilter.AprilPosTrans).Y = aprilPosTrans.Y + ModMain._MapFilter.Y;
							ModMain.m_InvocationFilter.AprilScaleTrans.ScaleX = ModBase.MathRange(1.0 - (Math.Abs(vector3.X) - Math.Abs(vector3.Y)) * (num4 / 160.0), 0.2, 1.8);
							ModMain.m_InvocationFilter.AprilScaleTrans.ScaleY = ModBase.MathRange(1.0 - (Math.Abs(vector3.Y) - Math.Abs(vector3.X)) * (num4 / 100.0), 0.2, 1.8);
						}
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "愚人节移动出错", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x060011D3 RID: 4563 RVA: 0x00082878 File Offset: 0x00080A78
		public static void UpdateStart(string BaseUrl, bool Slient, string ReceivedKey = null, bool ForceValidated = false)
		{
			object[] object_ = new object[]
			{
				BaseUrl,
				Slient,
				ReceivedKey,
				ForceValidated
			};
			new GClass18().method_112(object_, 0xABB23);
		}

		// Token: 0x060011D4 RID: 4564 RVA: 0x000828BC File Offset: 0x00080ABC
		public static void UpdateRestart(bool TriggerRestartAndByEnd)
		{
			ModMain.m_TokenFilter = false;
			string fileName = ModBase.Path + "PCL\\Plain Craft Launcher 2.exe";
			string applicationName = AppDomain.CurrentDomain.SetupInformation.ApplicationName;
			string text = applicationName;
			string text2 = string.Concat(new string[]
			{
				"--update ",
				Conversions.ToString(Process.GetCurrentProcess().Id),
				" \"",
				applicationName,
				"\" \"",
				text,
				"\" ",
				Conversions.ToString(TriggerRestartAndByEnd)
			});
			ModBase.Log("[System] 更新程序启动，参数：" + text2, ModBase.LogLevel.Normal, "出现错误");
			Process.Start(new ProcessStartInfo(fileName)
			{
				WindowStyle = ProcessWindowStyle.Hidden,
				CreateNoWindow = true,
				Arguments = text2
			});
			if (TriggerRestartAndByEnd)
			{
				ModMain.m_GetterFilter.EndProgram(false);
				ModBase.Log("[System] 已由于更新强制结束程序", ModBase.LogLevel.Normal, "出现错误");
			}
		}

		// Token: 0x060011D5 RID: 4565 RVA: 0x00082998 File Offset: 0x00080B98
		public static void UpdateReplace(int ProcessId, string OldFileName, string NewFileName, bool TriggerRestart)
		{
			try
			{
				Process.GetProcessById(ProcessId).Kill();
			}
			catch (Exception ex)
			{
			}
			checked
			{
				string path = Strings.Mid(ModBase.Path, 1, ModBase.Path.Length - 4) + OldFileName;
				string text = Strings.Mid(ModBase.Path, 1, ModBase.Path.Length - 4) + NewFileName;
				Exception ex2 = null;
				int num = 0;
				do
				{
					try
					{
						if (File.Exists(path))
						{
							File.Delete(path);
						}
						if (File.Exists(text))
						{
							File.Delete(text);
						}
						if (!File.Exists(path) && !File.Exists(text))
						{
							break;
						}
						Thread.Sleep(0x7D0);
					}
					catch (Exception ex3)
					{
						ex2 = ex3;
					}
					num++;
				}
				while (num <= 4);
				if (!File.Exists(path) && !File.Exists(text))
				{
					try
					{
						File.Copy(ModBase.Path + AppDomain.CurrentDomain.SetupInformation.ApplicationName, text);
					}
					catch (UnauthorizedAccessException ex4)
					{
						Interaction.MsgBox("PCL2 更新失败：权限不足。请手动复制 PCL 文件夹下的新版本程序。\r\n若 PCL2 位于桌面或 C 盘，你可以尝试将其挪到其他文件夹，这可能可以解决权限问题。\r\n" + ModBase.GetString(ex4, true, false), MsgBoxStyle.Critical, "更新失败");
					}
					catch (Exception ex5)
					{
						Interaction.MsgBox("PCL2 更新失败：无法复制新文件。请手动复制 PCL 文件夹下的新版本程序。\r\n" + ModBase.GetString(ex5, true, false), MsgBoxStyle.Critical, "更新失败");
						return;
					}
					if (TriggerRestart)
					{
						try
						{
							Process.Start(text);
						}
						catch (Exception ex6)
						{
							Interaction.MsgBox("PCL2 更新失败：无法重新启动。\r\n" + ModBase.GetString(ex6, true, false), MsgBoxStyle.Critical, "更新失败");
						}
					}
					return;
				}
				if (ex2 is UnauthorizedAccessException)
				{
					Interaction.MsgBox(string.Concat(new string[]
					{
						"由于权限不足，PCL2 无法完成更新。请尝试：\r\n",
						(text.StartsWith(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) || text.StartsWith(Environment.GetFolderPath(Environment.SpecialFolder.Personal))) ? " - 将 PCL2 文件移动到桌面、文档以外的文件夹（这或许可以一劳永逸地解决权限问题）\r\n" : "",
						text.StartsWith("C") ? " - 将 PCL2 文件移动到 C 盘以外的文件夹（这或许可以一劳永逸地解决权限问题）\r\n" : "",
						" - 右键以管理员身份运行 PCL2\r\n - 手动复制已下载到 PCL 文件夹下的新版本程序，覆盖原程序\r\n\r\n",
						ModBase.GetString(ex2, true, false)
					}), MsgBoxStyle.Critical, "更新失败");
					return;
				}
				Interaction.MsgBox("PCL2 更新失败：无法删除原文件。请手动复制已下载到 PCL 文件夹下的新版本程序覆盖原程序。\r\n" + ModBase.GetString(ex2, true, false), MsgBoxStyle.Critical, "更新失败");
			}
		}

		// Token: 0x060011D6 RID: 4566 RVA: 0x0000B455 File Offset: 0x00009655
		public static string GetUniqueMark(string CustomKey)
		{
			return ModBase.ValidateIterator(ModBase.ruleRule + "|Snapshot 2.2.3|" + CustomKey, "Your Best Nightmare");
		}

		// Token: 0x060011D7 RID: 4567 RVA: 0x0000B471 File Offset: 0x00009671
		public static bool CanSkipUpdateMark()
		{
			return (bool)new GClass18().method_112(null, 0xAD9DE);
		}

		// Token: 0x060011D8 RID: 4568 RVA: 0x00082C08 File Offset: 0x00080E08
		public static int ReplaceStringInBytes(ref byte[] FileData, string SourceString, string TargetString, bool HasWhiteSpace)
		{
			byte[] array = ModMain.StringToExeBytes(SourceString, HasWhiteSpace);
			byte[] collection = ModMain.StringToExeBytes(Strings.Mid(TargetString.PadRight(SourceString.Count<char>(), '*'), 1, SourceString.Count<char>()), HasWhiteSpace);
			int num = 0;
			List<byte> list = new List<byte>();
			checked
			{
				for (int i = 0; i < FileData.Length; i++)
				{
					if (i < FileData.Length - array.Length)
					{
						bool flag = true;
						int num2 = array.Length - 1;
						int j = 0;
						while (j <= num2)
						{
							if (FileData[i + j] != array[j])
							{
								flag = false;
								IL_72:
								if (flag)
								{
									list.AddRange(collection);
									i += array.Length - 1;
									num++;
									goto IL_A5;
								}
								list.Add(FileData[i]);
								goto IL_A5;
							}
							else
							{
								j++;
							}
						}
						goto IL_72;
					}
					list.Add(FileData[i]);
					IL_A5:;
				}
				FileData = list.ToArray();
				return num;
			}
		}

		// Token: 0x060011D9 RID: 4569 RVA: 0x00082CD4 File Offset: 0x00080ED4
		private static byte[] StringToExeBytes(string Source, bool HasWhiteSpace)
		{
			List<byte> list = new List<byte>();
			foreach (byte item in Encoding.ASCII.GetBytes(Source))
			{
				list.Add(item);
				if (HasWhiteSpace)
				{
					list.Add(0);
				}
			}
			return list.ToArray();
		}

		// Token: 0x060011DA RID: 4570 RVA: 0x00082D1C File Offset: 0x00080F1C
		private static void TimerMain()
		{
			checked
			{
				try
				{
					ModMain.HintTick();
					ModMain.MyMsgBoxTick();
					ModMain.m_GetterFilter.DragTick();
					ModLoader.LoaderTaskbarProgressRefresh();
					if (ModMain.m_WriterFilter == 2)
					{
						ModMain.CompareIterator(-1);
					}
					ModMain.containerRule++;
					if (ModMain.containerRule == 4)
					{
						ModMain.containerRule = 0;
						if (ModMain._ValueFilter == 0xC)
						{
							ModMain.CompareIterator(-1);
						}
					}
					ModMain._ModelRule++;
					if (ModMain._ModelRule == 0x96)
					{
						ModMain._ModelRule = 0;
						if (ModMain.m_GetterFilter.BtnExtraApril_ShowCheck())
						{
							ModMain.m_GetterFilter.BtnExtraApril.Ribble();
						}
						ModBase.RunInUi((ModMain._Closure$__.$I125-0 == null) ? (ModMain._Closure$__.$I125-0 = delegate()
						{
							if (!ModMain.m_GetterFilter.Hidden)
							{
								if (ModMain.m_GetterFilter.Top < -10000.0)
								{
									ModMain.m_GetterFilter.Top = 100.0;
								}
								if (ModMain.m_GetterFilter.Left < -10000.0)
								{
									ModMain.m_GetterFilter.Left = 100.0;
								}
							}
						}) : ModMain._Closure$__.$I125-0, false);
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "主时钟执行异常", ModBase.LogLevel.Assert, "出现错误");
				}
			}
		}

		// Token: 0x060011DB RID: 4571 RVA: 0x00082E10 File Offset: 0x00081010
		public static void TimerMainStartRun()
		{
			ModBase.RunInNewThread((ModMain._Closure$__.$I126-0 == null) ? (ModMain._Closure$__.$I126-0 = delegate()
			{
				try
				{
					for (;;)
					{
						ModBase.RunInUiWait(new ThreadStart(ModMain.TimerMain));
						Thread.Sleep(0x31);
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "程序主时钟出错", ModBase.LogLevel.Feedback, "出现错误");
				}
			}) : ModMain._Closure$__.$I126-0, "Timer Main", ThreadPriority.Normal);
			if (ModMain.policyFilter)
			{
				ModBase.RunInNewThread((ModMain._Closure$__.$I126-1 == null) ? (ModMain._Closure$__.$I126-1 = delegate()
				{
					try
					{
						int tickCount = MyWpfExtension.RunFactory().Clock.TickCount;
						for (;;)
						{
							if (tickCount != MyWpfExtension.RunFactory().Clock.TickCount)
							{
								tickCount = MyWpfExtension.RunFactory().Clock.TickCount;
								ModBase.RunInUiWait(new ThreadStart(ModMain.TimerFool));
							}
							Thread.Sleep(1);
						}
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "愚人节主时钟出错", ModBase.LogLevel.Feedback, "出现错误");
					}
				}) : ModMain._Closure$__.$I126-1, "Timer Main Fool", ThreadPriority.Normal);
			}
		}

		// Token: 0x0400092C RID: 2348
		private static ArrayList m_PredicateFilter;

		// Token: 0x0400092D RID: 2349
		public static ArrayList _StructFilter;

		// Token: 0x0400092E RID: 2350
		public static ModBase.MyColor resolverFilter;

		// Token: 0x0400092F RID: 2351
		public static ModBase.MyColor collectionFilter;

		// Token: 0x04000930 RID: 2352
		public static ModBase.MyColor testsFilter;

		// Token: 0x04000931 RID: 2353
		public static ModBase.MyColor m_BroadcasterFilter;

		// Token: 0x04000932 RID: 2354
		public static ModBase.MyColor fieldFilter;

		// Token: 0x04000933 RID: 2355
		public static ModBase.MyColor _StatusFilter;

		// Token: 0x04000934 RID: 2356
		public static ModBase.MyColor _RequestFilter;

		// Token: 0x04000935 RID: 2357
		public static ModBase.MyColor poolFilter;

		// Token: 0x04000936 RID: 2358
		public static ModBase.MyColor m_ParserFilter;

		// Token: 0x04000937 RID: 2359
		public static ModBase.MyColor proxyFilter;

		// Token: 0x04000938 RID: 2360
		public static ModBase.MyColor setterFilter;

		// Token: 0x04000939 RID: 2361
		public static ModBase.MyColor merchantFilter;

		// Token: 0x0400093A RID: 2362
		public static ModBase.MyColor _EventFilter;

		// Token: 0x0400093B RID: 2363
		public static ModBase.MyColor printerFilter;

		// Token: 0x0400093C RID: 2364
		public static ModBase.MyColor productFilter;

		// Token: 0x0400093D RID: 2365
		public static ModBase.MyColor _ComparatorFilter;

		// Token: 0x0400093E RID: 2366
		public static ModBase.MyColor _RegistryFilter;

		// Token: 0x0400093F RID: 2367
		public static ModBase.MyColor m_AttributeFilter;

		// Token: 0x04000940 RID: 2368
		public static int _ValueFilter;

		// Token: 0x04000941 RID: 2369
		public static int m_RoleFilter;

		// Token: 0x04000942 RID: 2370
		public static int m_AdvisorFilter;

		// Token: 0x04000943 RID: 2371
		public static int m_StrategyFilter;

		// Token: 0x04000944 RID: 2372
		public static int[] wrapperFilter;

		// Token: 0x04000945 RID: 2373
		public static int m_WriterFilter;

		// Token: 0x04000946 RID: 2374
		private static bool _ExporterFilter;

		// Token: 0x04000947 RID: 2375
		private static int recordFilter;

		// Token: 0x04000948 RID: 2376
		public static FormMain m_GetterFilter;

		// Token: 0x04000949 RID: 2377
		public static SplashScreen m_InterceptorFilter;

		// Token: 0x0400094A RID: 2378
		public static PageLaunchLeft m_InvocationFilter;

		// Token: 0x0400094B RID: 2379
		public static PageLaunchRight m_CandidateFilter;

		// Token: 0x0400094C RID: 2380
		public static PageSelectLeft m_DescriptorFilter;

		// Token: 0x0400094D RID: 2381
		public static PageSelectRight contextFilter;

		// Token: 0x0400094E RID: 2382
		public static PageSpeedLeft observerFilter;

		// Token: 0x0400094F RID: 2383
		public static PageSpeedRight _TokenizerFilter;

		// Token: 0x04000950 RID: 2384
		public static PageLinkLeft _DispatcherFilter;

		// Token: 0x04000951 RID: 2385
		public static PageLinkRight _TagFilter;

		// Token: 0x04000952 RID: 2386
		public static PageDownloadLeft _InitializerFilter;

		// Token: 0x04000953 RID: 2387
		public static PageDownloadInstall propertyFilter;

		// Token: 0x04000954 RID: 2388
		public static PageDownloadClient m_WatcherFilter;

		// Token: 0x04000955 RID: 2389
		public static PageDownloadOptiFine m_StateFilter;

		// Token: 0x04000956 RID: 2390
		public static PageDownloadLiteLoader creatorFilter;

		// Token: 0x04000957 RID: 2391
		public static PageDownloadForge m_PageFilter;

		// Token: 0x04000958 RID: 2392
		public static PageDownloadFabric instanceFilter;

		// Token: 0x04000959 RID: 2393
		public static PageDownloadMod m_TestFilter;

		// Token: 0x0400095A RID: 2394
		public static PageDownloadPack m_CustomerFilter;

		// Token: 0x0400095B RID: 2395
		public static PageSetupLeft m_TaskFilter;

		// Token: 0x0400095C RID: 2396
		public static PageSetupLaunch m_AuthenticationFilter;

		// Token: 0x0400095D RID: 2397
		public static PageSetupUI processFilter;

		// Token: 0x0400095E RID: 2398
		public static PageSetupSystem _ListenerFilter;

		// Token: 0x0400095F RID: 2399
		public static PageSetupAccount m_ImporterFilter;

		// Token: 0x04000960 RID: 2400
		public static PageOtherLeft _TemplateFilter;

		// Token: 0x04000961 RID: 2401
		public static PageOtherHelp m_AdapterFilter;

		// Token: 0x04000962 RID: 2402
		public static PageOtherAbout _AnnotationFilter;

		// Token: 0x04000963 RID: 2403
		public static PageOtherFeedback readerFilter;

		// Token: 0x04000964 RID: 2404
		public static PageOtherTest _RegFilter;

		// Token: 0x04000965 RID: 2405
		public static PageLoginMojang m_DefinitionFilter;

		// Token: 0x04000966 RID: 2406
		public static PageLoginMojangSkin _ParamFilter;

		// Token: 0x04000967 RID: 2407
		public static PageLoginLegacy m_MockFilter;

		// Token: 0x04000968 RID: 2408
		public static PageLoginNide m_SpecificationFilter;

		// Token: 0x04000969 RID: 2409
		public static PageLoginNideSkin dicFilter;

		// Token: 0x0400096A RID: 2410
		public static PageLoginAuth _SchemaFilter;

		// Token: 0x0400096B RID: 2411
		public static PageLoginAuthSkin helperFilter;

		// Token: 0x0400096C RID: 2412
		public static PageLoginMs _ConsumerFilter;

		// Token: 0x0400096D RID: 2413
		public static PageLoginMsSkin queueFilter;

		// Token: 0x0400096E RID: 2414
		public static PageVersionLeft producerFilter;

		// Token: 0x0400096F RID: 2415
		public static PageVersionOverall _ExceptionFilter;

		// Token: 0x04000970 RID: 2416
		public static PageVersionMod m_RulesFilter;

		// Token: 0x04000971 RID: 2417
		public static PageVersionModDisabled m_ClassFilter;

		// Token: 0x04000972 RID: 2418
		public static PageVersionSetup _ServerFilter;

		// Token: 0x04000973 RID: 2419
		public static PageDownloadCfDetail m_ConfigFilter;

		// Token: 0x04000974 RID: 2420
		public static ModLoader.LoaderTask<int, Dictionary<string, List<ModMain.FeedbackEntry>>> connectionFilter;

		// Token: 0x04000975 RID: 2421
		private static readonly object listFilter;

		// Token: 0x04000976 RID: 2422
		public static ModLoader.LoaderTask<int, List<ModMain.HelpEntry>> _ReponseFilter;

		// Token: 0x04000977 RID: 2423
		public static ModLoader.LoaderTask<int, int> identifierFilter;

		// Token: 0x04000978 RID: 2424
		public static bool policyFilter;

		// Token: 0x04000979 RID: 2425
		public static bool m_ClientFilter;

		// Token: 0x0400097A RID: 2426
		private static Vector _MapFilter;

		// Token: 0x0400097B RID: 2427
		private static int composerFilter;

		// Token: 0x0400097C RID: 2428
		private static Point publisherFilter;

		// Token: 0x0400097D RID: 2429
		public static bool messageFilter;

		// Token: 0x0400097E RID: 2430
		public static bool m_TokenFilter;

		// Token: 0x0400097F RID: 2431
		public static string m_ProcFilter;

		// Token: 0x04000980 RID: 2432
		public static string m_FactoryRule;

		// Token: 0x04000981 RID: 2433
		public static MySlider m_ValRule;

		// Token: 0x04000982 RID: 2434
		private static int containerRule;

		// Token: 0x04000983 RID: 2435
		private static int _ModelRule;

		// Token: 0x02000190 RID: 400
		public enum HintType
		{
			// Token: 0x04000985 RID: 2437
			Info,
			// Token: 0x04000986 RID: 2438
			Finish,
			// Token: 0x04000987 RID: 2439
			Critical
		}

		// Token: 0x02000191 RID: 401
		public class MyMsgBoxConverter
		{
			// Token: 0x060011DC RID: 4572 RVA: 0x00082E84 File Offset: 0x00081084
			public MyMsgBoxConverter()
			{
				this._ProxyMapper = "";
				this.merchantMapper = "确定";
				this._EventMapper = "";
				this._PrinterMapper = "";
				this._ProductMapper = false;
				this._ComparatorMapper = false;
				this.registryMapper = new DispatcherFrame(true);
				this.attributeMapper = false;
			}

			// Token: 0x04000988 RID: 2440
			public ModMain.MyMsgBoxType Type;

			// Token: 0x04000989 RID: 2441
			public string Title;

			// Token: 0x0400098A RID: 2442
			public object m_PoolMapper;

			// Token: 0x0400098B RID: 2443
			public Collection<Validate> parserMapper;

			// Token: 0x0400098C RID: 2444
			public string _ProxyMapper;

			// Token: 0x0400098D RID: 2445
			public bool setterMapper;

			// Token: 0x0400098E RID: 2446
			public string merchantMapper;

			// Token: 0x0400098F RID: 2447
			public string _EventMapper;

			// Token: 0x04000990 RID: 2448
			public string _PrinterMapper;

			// Token: 0x04000991 RID: 2449
			public bool _ProductMapper;

			// Token: 0x04000992 RID: 2450
			public bool _ComparatorMapper;

			// Token: 0x04000993 RID: 2451
			public DispatcherFrame registryMapper;

			// Token: 0x04000994 RID: 2452
			public bool attributeMapper;

			// Token: 0x04000995 RID: 2453
			public string valueMapper;
		}

		// Token: 0x02000192 RID: 402
		public enum MyMsgBoxType
		{
			// Token: 0x04000997 RID: 2455
			Text,
			// Token: 0x04000998 RID: 2456
			Select,
			// Token: 0x04000999 RID: 2457
			Input
		}

		// Token: 0x02000193 RID: 403
		public struct FeedbackEntry
		{
			// Token: 0x060011DD RID: 4573 RVA: 0x0000B488 File Offset: 0x00009688
			public bool IsActive()
			{
				return Operators.CompareString(this.m_AdvisorMapper, "尚未查看", true) == 0 || Operators.CompareString(this.m_AdvisorMapper, "等待确认", true) == 0 || Operators.CompareString(this.m_AdvisorMapper, "正在处理", true) == 0;
			}

			// Token: 0x0400099A RID: 2458
			public int roleMapper;

			// Token: 0x0400099B RID: 2459
			public string Type;

			// Token: 0x0400099C RID: 2460
			public string m_AdvisorMapper;

			// Token: 0x0400099D RID: 2461
			public string _StrategyMapper;

			// Token: 0x0400099E RID: 2462
			public string Title;

			// Token: 0x0400099F RID: 2463
			public int _WrapperMapper;

			// Token: 0x040009A0 RID: 2464
			public string _WriterMapper;

			// Token: 0x040009A1 RID: 2465
			public string _ExporterMapper;

			// Token: 0x040009A2 RID: 2466
			public string recordMapper;

			// Token: 0x040009A3 RID: 2467
			public string _GetterMapper;

			// Token: 0x040009A4 RID: 2468
			public string m_InterceptorMapper;

			// Token: 0x040009A5 RID: 2469
			public string invocationMapper;
		}

		// Token: 0x02000194 RID: 404
		public class HelpEntry
		{
			// Token: 0x060011DE RID: 4574 RVA: 0x00082EE4 File Offset: 0x000810E4
			public HelpEntry(string FilePath)
			{
				this._ObserverMapper = null;
				this.m_TokenizerMapper = true;
				this.dispatcherMapper = true;
				this.m_TagMapper = true;
				JObject jobject = (JObject)ModBase.GetJson(ModBase.ReadFile(FilePath).Replace("{path}", ModBase.Path));
				if (jobject == null)
				{
					throw new FileNotFoundException("未找到帮助文件：" + FilePath, FilePath);
				}
				if (jobject["Title"] == null)
				{
					throw new ArgumentException("未找到 Title 项");
				}
				this.Title = (string)jobject["Title"];
				this._CandidateMapper = (string)(jobject["Description"] ?? "");
				this.descriptorMapper = (string)(jobject["Keywords"] ?? "");
				this._ObserverMapper = (string)jobject["Logo"];
				this.m_TokenizerMapper = (bool)(jobject["ShowInSearch"] ?? this.m_TokenizerMapper);
				this.dispatcherMapper = (bool)(jobject["ShowInPublic"] ?? this.dispatcherMapper);
				this.m_TagMapper = (bool)(jobject["ShowInSnapshot"] ?? this.m_TagMapper);
				this.m_ContextMapper = new List<string>();
				try
				{
					foreach (object obj in ((IEnumerable)(jobject["Types"] ?? ModBase.GetJson("[]"))))
					{
						object objectValue = RuntimeHelpers.GetObjectValue(obj);
						this.m_ContextMapper.Add(Conversions.ToString(objectValue));
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
				if (((bool?)(jobject["IsEvent"] ?? false)).GetValueOrDefault())
				{
					this.m_PropertyMapper = (string)jobject["EventType"];
					if (this.m_PropertyMapper == null)
					{
						throw new ArgumentException("未找到 EventType 项");
					}
					this._WatcherMapper = (string)(jobject["EventData"] ?? "");
					this._InitializerMapper = true;
					return;
				}
				else
				{
					string text = FilePath.ToLower().Replace(".json", ".xaml");
					if (!File.Exists(text))
					{
						throw new FileNotFoundException("未找到帮助条目 .json 对应的 .xaml 文件（" + text + "）");
					}
					this.stateMapper = ModBase.ReadFile(text);
					this._InitializerMapper = false;
					return;
				}
			}

			// Token: 0x060011DF RID: 4575 RVA: 0x0000B4C6 File Offset: 0x000096C6
			public MyListItem ToListItem()
			{
				return this.SetToListItem(new MyListItem());
			}

			// Token: 0x060011E0 RID: 4576 RVA: 0x00083188 File Offset: 0x00081388
			public MyListItem SetToListItem(MyListItem Item)
			{
				string text;
				if (this._InitializerMapper)
				{
					if (Operators.CompareString(this.m_PropertyMapper, "弹出窗口", true) == 0)
					{
						text = "pack://application:,,,/images/Blocks/GrassPath.png";
					}
					else
					{
						text = "pack://application:,,,/images/Blocks/CommandBlock.png";
					}
				}
				else
				{
					text = "pack://application:,,,/images/Blocks/Grass.png";
				}
				Item.SnapsToDevicePixels = true;
				Item.Title = this.Title;
				Item.Info = this._CandidateMapper;
				Item.Logo = (this._ObserverMapper ?? text);
				Item.Height = 42.0;
				Item.Type = MyListItem.CheckType.Clickable;
				Item.Tag = this;
				Item.PaddingRight = 4;
				Item.EventType = null;
				Item.EventData = null;
				Item.QueryModel((ModMain.HelpEntry._Closure$__.$I14-0 == null) ? (ModMain.HelpEntry._Closure$__.$I14-0 = delegate(object sender, MouseButtonEventArgs e)
				{
					PageOtherHelp.OnItemClick((ModMain.HelpEntry)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null));
				}) : ModMain.HelpEntry._Closure$__.$I14-0);
				return Item;
			}

			// Token: 0x040009A6 RID: 2470
			public string Title;

			// Token: 0x040009A7 RID: 2471
			public string _CandidateMapper;

			// Token: 0x040009A8 RID: 2472
			public string descriptorMapper;

			// Token: 0x040009A9 RID: 2473
			public List<string> m_ContextMapper;

			// Token: 0x040009AA RID: 2474
			public string _ObserverMapper;

			// Token: 0x040009AB RID: 2475
			public bool m_TokenizerMapper;

			// Token: 0x040009AC RID: 2476
			public bool dispatcherMapper;

			// Token: 0x040009AD RID: 2477
			public bool m_TagMapper;

			// Token: 0x040009AE RID: 2478
			public bool _InitializerMapper;

			// Token: 0x040009AF RID: 2479
			public string m_PropertyMapper;

			// Token: 0x040009B0 RID: 2480
			public string _WatcherMapper;

			// Token: 0x040009B1 RID: 2481
			public string stateMapper;
		}
	}
}
