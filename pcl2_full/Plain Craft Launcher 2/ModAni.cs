using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PCL
{
	// Token: 0x0200001D RID: 29
	[StandardModule]
	public sealed class ModAni
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x0000EF84 File Offset: 0x0000D184
		// Note: this type is marked as 'beforefieldinit'.
		static ModAni()
		{
			ModAni._Parameter = 1.0;
			ModAni._Stub = new Dictionary<string, ModAni.AniGroupEntry>();
			ModAni._Configuration = false;
			ModAni.m_Interpreter = 0;
			ModAni.m_Predicate = RuntimeHelpers.GetObjectValue(new object());
			ModAni._Resolver = 0;
			ModAni.collection = 0;
			ModAni.tests = 0L;
			ModAni._Broadcaster = 0;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000EFE4 File Offset: 0x0000D1E4
		public static void AniDispose(MyCard Control, bool RemoveFromChildren, ParameterizedThreadStart CallBack = null)
		{
			if (Control.IsHitTestVisible)
			{
				Control.IsHitTestVisible = false;
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaScaleTransform(Control, -0.08, 0xC8, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaOpacity(Control, -1.0, 0xC8, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaHeight(Control, -Control.ActualHeight, 0x96, 0x64, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaCode(delegate
					{
						if (RemoveFromChildren)
						{
							object[] array;
							bool[] array2;
							NewLateBinding.LateCall(NewLateBinding.LateGet(Control.Parent, null, "Children", new object[0], null, null, null), null, "Remove", array = new object[]
							{
								Control
							}, null, null, array2 = new bool[]
							{
								true
							}, true);
							if (array2[0])
							{
								Control = (MyCard)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(MyCard));
							}
						}
						else
						{
							Control.Visibility = Visibility.Collapsed;
						}
						if (CallBack != null)
						{
							CallBack(Control);
						}
					}, 0, true)
				}, "MyCard Dispose " + Conversions.ToString(Control._Object), false);
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000F0E4 File Offset: 0x0000D2E4
		public static void AniDispose(MyHint Control, bool RemoveFromChildren, ParameterizedThreadStart CallBack = null)
		{
			if (Control.IsHitTestVisible)
			{
				Control.IsHitTestVisible = false;
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaScaleTransform(Control, -0.08, 0xC8, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaOpacity(Control, -1.0, 0xC8, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaHeight(Control, -Control.ActualHeight, 0x96, 0x64, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaCode(delegate
					{
						if (RemoveFromChildren)
						{
							object[] array;
							bool[] array2;
							NewLateBinding.LateCall(NewLateBinding.LateGet(Control.Parent, null, "Children", new object[0], null, null, null), null, "Remove", array = new object[]
							{
								Control
							}, null, null, array2 = new bool[]
							{
								true
							}, true);
							if (array2[0])
							{
								Control = (MyHint)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(MyHint));
							}
						}
						else
						{
							Control.Visibility = Visibility.Collapsed;
						}
						if (CallBack != null)
						{
							CallBack(Control);
						}
					}, 0, true)
				}, "MyCard Dispose " + Conversions.ToString(Control.interceptor), false);
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000F1E4 File Offset: 0x0000D3E4
		public static void AniDispose(MyIconButton Control, bool RemoveFromChildren, ParameterizedThreadStart CallBack = null)
		{
			if (Control.IsHitTestVisible)
			{
				Control.IsHitTestVisible = false;
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaScaleTransform(Control, -1.5, 0xC8, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaCode(delegate
					{
						if (RemoveFromChildren)
						{
							object[] array;
							bool[] array2;
							NewLateBinding.LateCall(NewLateBinding.LateGet(Control.Parent, null, "Children", new object[0], null, null, null), null, "Remove", array = new object[]
							{
								Control
							}, null, null, array2 = new bool[]
							{
								true
							}, true);
							if (array2[0])
							{
								Control = (MyIconButton)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(MyIconButton));
							}
						}
						else
						{
							Control.Visibility = Visibility.Collapsed;
						}
						if (CallBack != null)
						{
							CallBack(Control);
						}
					}, 0, true)
				}, "MyIconButton Dispose " + Conversions.ToString(Control._AccountDecorator), false);
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00002A96 File Offset: 0x00000C96
		public static int InsertFactory()
		{
			return ModAni.m_Interpreter;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000F290 File Offset: 0x0000D490
		public static void ListFactory(int value)
		{
			object predicate = ModAni.m_Predicate;
			ObjectFlowControl.CheckForSyncLockOnValueType(predicate);
			lock (predicate)
			{
				ModAni.m_Interpreter = value;
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000F2D8 File Offset: 0x0000D4D8
		public static ModAni.AniData AaX(object Obj, double Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Number,
				_RepositoryRule = ModAni.TypeSub.X,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = RuntimeHelpers.GetObjectValue(Obj),
				Value = Value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000F348 File Offset: 0x0000D548
		public static ModAni.AniData AaY(object Obj, double Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Number,
				_RepositoryRule = ModAni.TypeSub.Y,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = RuntimeHelpers.GetObjectValue(Obj),
				Value = Value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000F3B8 File Offset: 0x0000D5B8
		public static ModAni.AniData AaWidth(object Obj, double Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Number,
				_RepositoryRule = ModAni.TypeSub.Width,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = RuntimeHelpers.GetObjectValue(Obj),
				Value = Value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000F428 File Offset: 0x0000D628
		public static ModAni.AniData AaHeight(object Obj, double Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Number,
				_RepositoryRule = ModAni.TypeSub.Height,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = RuntimeHelpers.GetObjectValue(Obj),
				Value = Value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000F498 File Offset: 0x0000D698
		public static ModAni.AniData AaOpacity(object Obj, double Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Number,
				_RepositoryRule = ModAni.TypeSub.Opacity,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = RuntimeHelpers.GetObjectValue(Obj),
				Value = Value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000F508 File Offset: 0x0000D708
		public static ModAni.AniData AaValue(object Obj, double Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Number,
				_RepositoryRule = ModAni.TypeSub.Value,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = RuntimeHelpers.GetObjectValue(Obj),
				Value = Value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000F578 File Offset: 0x0000D778
		public static ModAni.AniData AaRadius(object Obj, double Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Number,
				_RepositoryRule = ModAni.TypeSub.Radius,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = RuntimeHelpers.GetObjectValue(Obj),
				Value = Value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000F5E8 File Offset: 0x0000D7E8
		public static ModAni.AniData AaBorderThickness(object Obj, double Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Number,
				_RepositoryRule = ModAni.TypeSub.BorderThickness,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = RuntimeHelpers.GetObjectValue(Obj),
				Value = Value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000F658 File Offset: 0x0000D858
		public static ModAni.AniData AaStrokeThickness(object Obj, double Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Number,
				_RepositoryRule = ModAni.TypeSub.StrokeThickness,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = RuntimeHelpers.GetObjectValue(Obj),
				Value = Value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000F6C8 File Offset: 0x0000D8C8
		public static ModAni.AniData AaGridLengthWidth(object Obj, double Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Number,
				_RepositoryRule = ModAni.TypeSub.GridLengthWidth,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = RuntimeHelpers.GetObjectValue(Obj),
				Value = Value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000F738 File Offset: 0x0000D938
		public static ModAni.AniData AaDouble(object Obj, DependencyProperty Prop, double Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Number,
				_RepositoryRule = ModAni.TypeSub.Double,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = new object[]
				{
					Obj,
					Prop,
					""
				},
				Value = Value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000F7B8 File Offset: 0x0000D9B8
		public static ModAni.AniData AaDouble(ParameterizedThreadStart Lambda, double Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Number,
				_RepositoryRule = ModAni.TypeSub.DoubleParam,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = Lambda,
				Value = Value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000F824 File Offset: 0x0000DA24
		public static ModAni.AniData AaColor(FrameworkElement Obj, DependencyProperty Prop, ModBase.MyColor Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Color,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = new object[]
				{
					Obj,
					Prop,
					""
				},
				Value = Value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay),
				m_AccountRule = new ModBase.MyColor(0.0, 0.0, 0.0, 0.0)
			};
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000F8C8 File Offset: 0x0000DAC8
		public static ModAni.AniData AaColor(FrameworkElement Obj, DependencyProperty Prop, string Res, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Color,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = new object[]
				{
					Obj,
					Prop,
					Res
				},
				Value = new ModBase.MyColor(RuntimeHelpers.GetObjectValue(Application.Current.FindResource(Res))) - new ModBase.MyColor(RuntimeHelpers.GetObjectValue(Obj.GetValue(Prop))),
				m_RefRule = After,
				proccesorRule = checked(0 - Delay),
				m_AccountRule = new ModBase.MyColor(0.0, 0.0, 0.0, 0.0)
			};
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000F990 File Offset: 0x0000DB90
		public static ModAni.AniData AaScale(object Obj, double Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false, bool Absolute = false)
		{
			ModBase.MyRect value;
			if (Absolute)
			{
				value = new ModBase.MyRect(-0.5 * Value, -0.5 * Value, Value, Value);
			}
			else
			{
				value = new ModBase.MyRect(Conversions.ToDouble(Operators.MultiplyObject(Operators.MultiplyObject(-0.5, NewLateBinding.LateGet(Obj, null, "ActualWidth", new object[0], null, null, null)), Value)), Conversions.ToDouble(Operators.MultiplyObject(Operators.MultiplyObject(-0.5, NewLateBinding.LateGet(Obj, null, "ActualHeight", new object[0], null, null, null)), Value)), Conversions.ToDouble(Operators.MultiplyObject(NewLateBinding.LateGet(Obj, null, "ActualWidth", new object[0], null, null, null), Value)), Conversions.ToDouble(Operators.MultiplyObject(NewLateBinding.LateGet(Obj, null, "ActualHeight", new object[0], null, null, null), Value)));
			}
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Scale,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = RuntimeHelpers.GetObjectValue(Obj),
				Value = value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000FAD8 File Offset: 0x0000DCD8
		public static ModAni.AniData AaTextAppear(object Obj, bool Hide = false, bool TimePerText = true, int Time = 0x46, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return checked(new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.TextAppear,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_SystemRule = (TimePerText ? (Time * ((Operators.CompareString(Obj.GetType().Name, "TextBlock", true) == 0) ? NewLateBinding.LateGet(Obj, null, "Text", new object[0], null, null, null) : NewLateBinding.LateGet(Obj, null, "Context", new object[0], null, null, null).ToString()).ToString().Length) : Time),
				m_StubRule = RuntimeHelpers.GetObjectValue(Obj),
				Value = new object[]
				{
					(Operators.CompareString(Obj.GetType().Name, "TextBlock", true) == 0) ? NewLateBinding.LateGet(Obj, null, "Text", new object[0], null, null, null) : NewLateBinding.LateGet(Obj, null, "Context", new object[0], null, null, null).ToString(),
					Hide
				},
				m_RefRule = After,
				proccesorRule = 0 - Delay
			});
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000FBF0 File Offset: 0x0000DDF0
		public static ModAni.AniData AaCode(ThreadStart Code, int Delay = 0, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Code,
				m_SystemRule = 1,
				Value = Code,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000FC30 File Offset: 0x0000DE30
		public static ModAni.AniData AaScaleTransform(object Obj, double Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.ScaleTransform,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = RuntimeHelpers.GetObjectValue(Obj),
				Value = Value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000FC98 File Offset: 0x0000DE98
		public static ModAni.AniData AaRotateTransform(object Obj, double Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.RotateTransform,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = RuntimeHelpers.GetObjectValue(Obj),
				Value = Value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000FD00 File Offset: 0x0000DF00
		public static ModAni.AniData AaTranslateX(object Obj, double Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Number,
				_RepositoryRule = ModAni.TypeSub.TranslateX,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = RuntimeHelpers.GetObjectValue(Obj),
				Value = Value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000FD70 File Offset: 0x0000DF70
		public static ModAni.AniData AaTranslateY(object Obj, double Value, int Time = 0x190, int Delay = 0, ModAni.AniEase Ease = null, bool After = false)
		{
			return new ModAni.AniData
			{
				_InfoRule = ModAni.AniType.Number,
				_RepositoryRule = ModAni.TypeSub.TranslateY,
				m_SystemRule = Time,
				parameterRule = (Ease ?? new ModAni.AniEaseLinear()),
				m_StubRule = RuntimeHelpers.GetObjectValue(Obj),
				Value = Value,
				m_RefRule = After,
				proccesorRule = checked(0 - Delay)
			};
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000FDE0 File Offset: 0x0000DFE0
		public static ArrayList AaStack(StackPanel Stack, int Time = 0x64, int Delay = 0x19)
		{
			ArrayList arrayList = new ArrayList();
			int num = 0;
			checked
			{
				try
				{
					foreach (object obj in Stack.Children)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(obj);
						NewLateBinding.LateSet(objectValue, null, "Opacity", new object[]
						{
							0
						}, null, null);
						arrayList.Add(ModAni.AaOpacity(RuntimeHelpers.GetObjectValue(objectValue), 1.0, Time, num, null, false));
						num += Delay;
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
				return arrayList;
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000FE84 File Offset: 0x0000E084
		public static void AniStart(IList AniGroup, string Name = "", bool RefreshTime = false)
		{
			if (RefreshTime)
			{
				ModAni.m_Account = ModBase.GetTimeTick();
			}
			if (Operators.CompareString(Name, "", true) == 0)
			{
				Name = Conversions.ToString(ModBase.GetUuid());
			}
			else
			{
				ModAni.AniStop(Name);
			}
			ModAni._Stub.Add(Name, new ModAni.AniGroupEntry
			{
				m_ItemRule = ModBase.GetFullList<ModAni.AniData>(AniGroup),
				Name = Name,
				_SerializerRule = ModBase.GetTimeTick()
			});
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00002A9D File Offset: 0x00000C9D
		public static void AniStart(ModAni.AniData AniGroup, string Name = "", bool RefreshTime = false)
		{
			ModAni.AniStart(new List<ModAni.AniData>
			{
				AniGroup
			}, Name, RefreshTime);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00002AB2 File Offset: 0x00000CB2
		public static void AniStop(string Name)
		{
			ModAni._Stub.Remove(Name);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00002AC0 File Offset: 0x00000CC0
		public static bool AniIsRun(string Name)
		{
			return ModAni._Stub.ContainsKey(Name);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000FEF8 File Offset: 0x0000E0F8
		public static void AniStartRun()
		{
			ModAni.m_Account = ModBase.GetTimeTick();
			ModAni.tests = ModAni.m_Account;
			ModAni._Configuration = true;
			ModBase.RunInNewThread((ModAni._Closure$__.$I60-0 == null) ? (ModAni._Closure$__.$I60-0 = checked(delegate()
			{
				try
				{
					for (;;)
					{
						ModAni._Closure$__60-0 CS$<>8__locals1 = new ModAni._Closure$__60-0(CS$<>8__locals1);
						CS$<>8__locals1.$VB$Local_DeltaTime = (long)Math.Round(ModBase.MathRange((double)(ModBase.GetTimeTick() - ModAni.m_Account), 0.0, 10000.0));
						if (CS$<>8__locals1.$VB$Local_DeltaTime >= 3L)
						{
							ModAni.m_Account = ModBase.GetTimeTick();
							if (ModBase.errorRule)
							{
								if (ModBase.MathRange((double)(ModAni.m_Account - ModAni.tests), 0.0, 10000.0) >= 500.0)
								{
									ModAni._Broadcaster = ModAni.collection;
									ModAni.collection = 0;
									ModAni.tests = ModAni.m_Account;
								}
								ModAni.collection += 2;
							}
							ModBase.RunInUiWait(delegate()
							{
								ModAni._Resolver = 0;
								ModAni.AniTimer((int)Math.Round(unchecked((double)CS$<>8__locals1.$VB$Local_DeltaTime * ModAni._Parameter)));
								if (ModBase.RandomInteger(0, 0x40 * (ModBase.errorRule ? 5 : 0x1E)) == 0 && ((ModAni._Broadcaster < 0x3E && ModAni._Broadcaster > 0) || ModAni._Resolver > 4 || ModNet._ClientModel.m_ObjectAlgo != 0))
								{
									ModBase.Log(string.Concat(new string[]
									{
										"[Report] FPS ",
										Conversions.ToString(ModAni._Broadcaster),
										", 动画 ",
										Conversions.ToString(ModAni._Resolver),
										", 下载中 ",
										Conversions.ToString(ModNet._ClientModel.m_ObjectAlgo)
									}), ModBase.LogLevel.Normal, "出现错误");
								}
							});
						}
						Thread.Sleep(1);
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "动画帧执行失败", ModBase.LogLevel.Assert, "出现错误");
				}
			})) : ModAni._Closure$__.$I60-0, "Animation", ThreadPriority.AboveNormal);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000FF50 File Offset: 0x0000E150
		public static void AniTimer(int DeltaTick)
		{
			checked
			{
				try
				{
					int num = -1;
					while (num + 1 < ModAni._Stub.Count)
					{
						num++;
						ModAni.AniGroupEntry aniGroupEntry = ModAni._Stub.Values.ElementAtOrDefault(num);
						if (aniGroupEntry._SerializerRule <= ModAni.m_Account)
						{
							bool flag = true;
							int i = 0;
							while (i < aniGroupEntry.m_ItemRule.Count)
							{
								ModAni.AniData aniData = aniGroupEntry.m_ItemRule[i];
								if (!aniData.m_RefRule)
								{
									flag = false;
									ref int ptr = ref aniData.proccesorRule;
									aniData.proccesorRule = ptr + DeltaTick;
									if (aniData.proccesorRule > 0)
									{
										aniData = ModAni.AniRun(aniData);
										ModAni._Resolver++;
									}
									if (aniData.proccesorRule >= aniData.m_SystemRule)
									{
										if (Conversions.ToBoolean(aniData._InfoRule == ModAni.AniType.Color && Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(aniData.m_StubRule, new object[]
										{
											2
										}, null), "", true)))))
										{
											object instance = NewLateBinding.LateIndexGet(aniData.m_StubRule, new object[]
											{
												0
											}, null);
											Type type = null;
											string memberName = "SetResourceReference";
											object[] array = new object[2];
											int num2 = 0;
											object stubRule = aniData.m_StubRule;
											object instance2 = stubRule;
											object[] array2 = new object[1];
											object obj = array2[0] = 1;
											array[num2] = NewLateBinding.LateIndexGet(instance2, array2, null);
											int num3 = 1;
											object stubRule2 = aniData.m_StubRule;
											object instance3 = stubRule2;
											object[] array3 = new object[1];
											object obj2 = array3[0] = 2;
											array[num3] = NewLateBinding.LateIndexGet(instance3, array3, null);
											object[] array4 = array;
											bool[] array5;
											NewLateBinding.LateCall(instance, type, memberName, array, null, null, array5 = new bool[]
											{
												true,
												true
											}, true);
											if (array5[0])
											{
												NewLateBinding.LateIndexSetComplex(stubRule, new object[]
												{
													obj,
													array4[0]
												}, null, true, false);
											}
											if (array5[1])
											{
												NewLateBinding.LateIndexSetComplex(stubRule2, new object[]
												{
													obj2,
													array4[1]
												}, null, true, false);
											}
										}
										aniGroupEntry.m_ItemRule.RemoveAt(i);
									}
									else
									{
										aniGroupEntry.m_ItemRule[i] = aniData;
										i++;
									}
								}
								else
								{
									if (!flag)
									{
										break;
									}
									flag = false;
									aniData.m_RefRule = false;
									aniGroupEntry.m_ItemRule[i] = aniData;
								}
							}
							if (aniGroupEntry.m_ItemRule.Count == 0)
							{
								ModAni._Stub.Remove(aniGroupEntry.Name);
								num--;
							}
						}
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "动画刻执行失败", ModBase.LogLevel.Hint, "出现错误");
				}
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000101D4 File Offset: 0x0000E3D4
		private static ModAni.AniData AniRun(ModAni.AniData Ani)
		{
			try
			{
				switch (Ani._InfoRule)
				{
				case ModAni.AniType.Number:
				{
					double num = ModBase.MathPercent(0.0, Conversions.ToDouble(Ani.Value), Ani.parameterRule.GetDelta((double)Ani.proccesorRule / (double)Ani.m_SystemRule, Ani.m_PrototypeRule));
					if (num != 0.0)
					{
						switch (Ani._RepositoryRule)
						{
						case ModAni.TypeSub.X:
							ModBase.DeltaLeft((FrameworkElement)Ani.m_StubRule, num);
							break;
						case ModAni.TypeSub.Y:
							ModBase.DeltaTop((FrameworkElement)Ani.m_StubRule, num);
							break;
						case ModAni.TypeSub.Width:
						{
							FrameworkElement frameworkElement = (FrameworkElement)Ani.m_StubRule;
							frameworkElement.Width = Math.Max((double.IsNaN(frameworkElement.Width) ? frameworkElement.ActualWidth : frameworkElement.Width) + num, 0.0);
							break;
						}
						case ModAni.TypeSub.Height:
						{
							FrameworkElement frameworkElement2 = (FrameworkElement)Ani.m_StubRule;
							frameworkElement2.Height = Math.Max((double.IsNaN(frameworkElement2.Height) ? frameworkElement2.ActualHeight : frameworkElement2.Height) + num, 0.0);
							break;
						}
						case ModAni.TypeSub.Opacity:
							NewLateBinding.LateSet(Ani.m_StubRule, null, "Opacity", new object[]
							{
								ModBase.MathRange(Conversions.ToDouble(Operators.AddObject(NewLateBinding.LateGet(Ani.m_StubRule, null, "Opacity", new object[0], null, null, null), num)), 0.0, 1.0)
							}, null, null);
							break;
						case ModAni.TypeSub.Value:
						{
							object stubRule = Ani.m_StubRule;
							NewLateBinding.LateSet(stubRule, null, "Value", new object[]
							{
								Operators.AddObject(NewLateBinding.LateGet(stubRule, null, "Value", new object[0], null, null, null), num)
							}, null, null);
							break;
						}
						case ModAni.TypeSub.Radius:
						{
							object stubRule = Ani.m_StubRule;
							NewLateBinding.LateSet(stubRule, null, "Radius", new object[]
							{
								Operators.AddObject(NewLateBinding.LateGet(stubRule, null, "Radius", new object[0], null, null, null), num)
							}, null, null);
							break;
						}
						case ModAni.TypeSub.BorderThickness:
						{
							object stubRule2 = Ani.m_StubRule;
							Type type = null;
							string memberName = "BorderThickness";
							object[] array = new object[1];
							int num2 = 0;
							object obj = NewLateBinding.LateGet(Ani.m_StubRule, null, "BorderThickness", new object[0], null, null, null);
							array[num2] = new Thickness(((obj != null) ? ((Thickness)obj) : default(Thickness)).Bottom + num);
							NewLateBinding.LateSet(stubRule2, type, memberName, array, null, null);
							break;
						}
						case ModAni.TypeSub.StrokeThickness:
							NewLateBinding.LateSet(Ani.m_StubRule, null, "StrokeThickness", new object[]
							{
								NewLateBinding.LateGet(null, typeof(Math), "Max", new object[]
								{
									Operators.AddObject(NewLateBinding.LateGet(Ani.m_StubRule, null, "StrokeThickness", new object[0], null, null, null), num),
									0
								}, null, null, null)
							}, null, null);
							break;
						case ModAni.TypeSub.TranslateX:
						{
							if (Information.IsNothing(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Ani.m_StubRule, null, "RenderTransform", new object[0], null, null, null))) || Operators.CompareString(NewLateBinding.LateGet(Ani.m_StubRule, null, "RenderTransform", new object[0], null, null, null).GetType().Name, "TranslateTransform", true) != 0)
							{
								NewLateBinding.LateSet(Ani.m_StubRule, null, "RenderTransform", new object[]
								{
									new TranslateTransform(0.0, 0.0)
								}, null, null);
							}
							TranslateTransform translateTransform;
							(translateTransform = (TranslateTransform)NewLateBinding.LateGet(Ani.m_StubRule, null, "RenderTransform", new object[0], null, null, null)).X = translateTransform.X + num;
							break;
						}
						case ModAni.TypeSub.TranslateY:
						{
							if (Information.IsNothing(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Ani.m_StubRule, null, "RenderTransform", new object[0], null, null, null))) || Operators.CompareString(NewLateBinding.LateGet(Ani.m_StubRule, null, "RenderTransform", new object[0], null, null, null).GetType().Name, "TranslateTransform", true) != 0)
							{
								NewLateBinding.LateSet(Ani.m_StubRule, null, "RenderTransform", new object[]
								{
									new TranslateTransform(0.0, 0.0)
								}, null, null);
							}
							TranslateTransform translateTransform;
							(translateTransform = (TranslateTransform)NewLateBinding.LateGet(Ani.m_StubRule, null, "RenderTransform", new object[0], null, null, null)).Y = translateTransform.Y + num;
							break;
						}
						case ModAni.TypeSub.Double:
						{
							object instance = NewLateBinding.LateIndexGet(Ani.m_StubRule, new object[]
							{
								0
							}, null);
							Type type2 = null;
							string memberName2 = "SetValue";
							object[] array2 = new object[2];
							int num3 = 0;
							object stubRule = Ani.m_StubRule;
							object instance2 = stubRule;
							object[] array3 = new object[1];
							object obj2 = array3[0] = 1;
							array2[num3] = NewLateBinding.LateIndexGet(instance2, array3, null);
							int num4 = 1;
							object instance3 = NewLateBinding.LateIndexGet(Ani.m_StubRule, new object[]
							{
								0
							}, null);
							Type type3 = null;
							string memberName3 = "GetValue";
							object[] array4 = new object[1];
							int num5 = 0;
							object stubRule3 = Ani.m_StubRule;
							object instance4 = stubRule3;
							object[] array5 = new object[1];
							object obj3 = array5[0] = 1;
							array4[num5] = NewLateBinding.LateIndexGet(instance4, array5, null);
							object[] array6 = array4;
							bool[] array7;
							object left = NewLateBinding.LateGet(instance3, type3, memberName3, array4, null, null, array7 = new bool[]
							{
								true
							});
							if (array7[0])
							{
								NewLateBinding.LateIndexSetComplex(stubRule3, new object[]
								{
									obj3,
									array6[0]
								}, null, true, false);
							}
							array2[num4] = Operators.AddObject(left, num);
							object[] array8 = array2;
							string[] argumentNames = null;
							Type[] typeArguments = null;
							bool[] array9 = new bool[2];
							array9[0] = true;
							bool[] array10 = array9;
							NewLateBinding.LateCall(instance, type2, memberName2, array2, argumentNames, typeArguments, array9, true);
							if (array10[0])
							{
								NewLateBinding.LateIndexSetComplex(stubRule, new object[]
								{
									obj2,
									array8[0]
								}, null, true, false);
							}
							break;
						}
						case ModAni.TypeSub.DoubleParam:
							((ParameterizedThreadStart)Ani.m_StubRule)(num);
							break;
						case ModAni.TypeSub.GridLengthWidth:
							NewLateBinding.LateSet(Ani.m_StubRule, null, "Width", new object[]
							{
								new GridLength(Conversions.ToDouble(NewLateBinding.LateGet(null, typeof(Math), "Max", new object[]
								{
									Operators.AddObject(NewLateBinding.LateGet(NewLateBinding.LateGet(Ani.m_StubRule, null, "Width", new object[0], null, null, null), null, "Value", new object[0], null, null, null), num),
									0
								}, null, null, null)), GridUnitType.Star)
							}, null, null);
							break;
						}
					}
					break;
				}
				case ModAni.AniType.Color:
				{
					ModBase.MyColor b = ModBase.MathPercent(new ModBase.MyColor(0.0, 0.0, 0.0, 0.0), (ModBase.MyColor)Ani.Value, Ani.parameterRule.GetDelta((double)Ani.proccesorRule / (double)Ani.m_SystemRule, Ani.m_PrototypeRule)) + (ModBase.MyColor)Ani.m_AccountRule;
					FrameworkElement frameworkElement3 = (FrameworkElement)NewLateBinding.LateIndexGet(Ani.m_StubRule, new object[]
					{
						0
					}, null);
					DependencyProperty dependencyProperty = (DependencyProperty)NewLateBinding.LateIndexGet(Ani.m_StubRule, new object[]
					{
						1
					}, null);
					ModBase.MyColor myColor = new ModBase.MyColor(RuntimeHelpers.GetObjectValue(frameworkElement3.GetValue(dependencyProperty))) + b;
					frameworkElement3.SetValue(dependencyProperty, RuntimeHelpers.GetObjectValue((Operators.CompareString(dependencyProperty.PropertyType.Name, "Color", true) == 0) ? myColor : myColor));
					Ani.m_AccountRule = myColor - new ModBase.MyColor(RuntimeHelpers.GetObjectValue(frameworkElement3.GetValue(dependencyProperty)));
					break;
				}
				case ModAni.AniType.Scale:
				{
					FrameworkElement frameworkElement4 = (FrameworkElement)Ani.m_StubRule;
					double delta = Ani.parameterRule.GetDelta((double)Ani.proccesorRule / (double)Ani.m_SystemRule, Ani.m_PrototypeRule);
					frameworkElement4.Margin = new Thickness(frameworkElement4.Margin.Left + ModBase.MathPercent(0.0, Conversions.ToDouble(NewLateBinding.LateGet(Ani.Value, null, "Left", new object[0], null, null, null)), delta), frameworkElement4.Margin.Top + ModBase.MathPercent(0.0, Conversions.ToDouble(NewLateBinding.LateGet(Ani.Value, null, "Top", new object[0], null, null, null)), delta), frameworkElement4.Margin.Right + ModBase.MathPercent(0.0, Conversions.ToDouble(NewLateBinding.LateGet(Ani.Value, null, "Left", new object[0], null, null, null)), delta), frameworkElement4.Margin.Bottom + ModBase.MathPercent(0.0, Conversions.ToDouble(NewLateBinding.LateGet(Ani.Value, null, "Top", new object[0], null, null, null)), delta));
					frameworkElement4.Width = Math.Max(frameworkElement4.Width + ModBase.MathPercent(0.0, Conversions.ToDouble(NewLateBinding.LateGet(Ani.Value, null, "Width", new object[0], null, null, null)), delta), 0.0);
					frameworkElement4.Height = Math.Max(frameworkElement4.Height + ModBase.MathPercent(0.0, Conversions.ToDouble(NewLateBinding.LateGet(Ani.Value, null, "Height", new object[0], null, null, null)), delta), 0.0);
					break;
				}
				case ModAni.AniType.TextAppear:
					checked
					{
						int num6 = (int)Math.Round(unchecked((double)(Conversions.ToBoolean(NewLateBinding.LateIndexGet(Ani.Value, new object[]
						{
							1
						}, null)) ? NewLateBinding.LateIndexGet(Ani.Value, new object[]
						{
							0
						}, null).ToString().Length : 0) + Math.Round((double)(checked(NewLateBinding.LateIndexGet(Ani.Value, new object[]
						{
							0
						}, null).ToString().Length * (Conversions.ToBoolean(NewLateBinding.LateIndexGet(Ani.Value, new object[]
						{
							1
						}, null)) ? -1 : 1))) * Ani.parameterRule.GetDelta((double)Ani.proccesorRule / (double)Ani.m_SystemRule, 0.0))));
						string text = Strings.Mid(Conversions.ToString(NewLateBinding.LateIndexGet(Ani.Value, new object[]
						{
							0
						}, null)), 1, num6);
						if (num6 < NewLateBinding.LateIndexGet(Ani.Value, new object[]
						{
							0
						}, null).ToString().Length)
						{
							if (Convert.ToInt32(Convert.ToChar(Strings.Mid(Conversions.ToString(NewLateBinding.LateIndexGet(Ani.Value, new object[]
							{
								0
							}, null)), num6 + 1, 1))) >= Convert.ToInt32(Convert.ToChar(0x80)))
							{
								text += Encoding.GetEncoding("GB18030").GetString(new byte[]
								{
									(byte)ModBase.RandomInteger(0xB0, 0xF7),
									(byte)ModBase.RandomInteger(0xA1, 0xF9)
								});
							}
							else
							{
								text = Conversions.ToString(Operators.ConcatenateObject(text, ModBase.RandomOne("0123456789./*-+\\[]{};':/?,!@#$%^&*()_+-=qwwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray())));
							}
						}
						if (Operators.CompareString(Ani.m_StubRule.GetType().Name, "TextBlock", true) == 0)
						{
							NewLateBinding.LateSet(Ani.m_StubRule, null, "Text", new object[]
							{
								text
							}, null, null);
						}
						else
						{
							NewLateBinding.LateSet(Ani.m_StubRule, null, "Context", new object[]
							{
								text
							}, null, null);
						}
						break;
					}
				case ModAni.AniType.Code:
					((ThreadStart)Ani.Value)();
					break;
				case ModAni.AniType.ScaleTransform:
				{
					FrameworkElement frameworkElement5 = (FrameworkElement)Ani.m_StubRule;
					if (Operators.CompareString(frameworkElement5.RenderTransform.GetType().Name, "ScaleTransform", true) != 0)
					{
						frameworkElement5.RenderTransformOrigin = new Point(0.5, 0.5);
						frameworkElement5.RenderTransform = new ScaleTransform(1.0, 1.0);
					}
					double num7 = ModBase.MathPercent(0.0, Conversions.ToDouble(Ani.Value), Ani.parameterRule.GetDelta((double)Ani.proccesorRule / (double)Ani.m_SystemRule, Ani.m_PrototypeRule));
					((ScaleTransform)frameworkElement5.RenderTransform).ScaleX = Math.Max(((ScaleTransform)frameworkElement5.RenderTransform).ScaleX + num7, 0.0);
					((ScaleTransform)frameworkElement5.RenderTransform).ScaleY = Math.Max(((ScaleTransform)frameworkElement5.RenderTransform).ScaleY + num7, 0.0);
					break;
				}
				case ModAni.AniType.RotateTransform:
				{
					FrameworkElement frameworkElement6 = (FrameworkElement)Ani.m_StubRule;
					if (Operators.CompareString(frameworkElement6.RenderTransform.GetType().Name, "RotateTransform", true) != 0)
					{
						frameworkElement6.RenderTransformOrigin = new Point(0.5, 0.5);
						frameworkElement6.RenderTransform = new RotateTransform(0.0);
					}
					double num8 = ModBase.MathPercent(0.0, Conversions.ToDouble(Ani.Value), Ani.parameterRule.GetDelta((double)Ani.proccesorRule / (double)Ani.m_SystemRule, Ani.m_PrototypeRule));
					((RotateTransform)frameworkElement6.RenderTransform).Angle = ((RotateTransform)frameworkElement6.RenderTransform).Angle + num8;
					break;
				}
				}
				Ani.m_PrototypeRule = (double)Ani.proccesorRule / (double)Ani.m_SystemRule;
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "执行动画失败：" + Ani.ToString(), ModBase.LogLevel.Hint, "出现错误");
			}
			return Ani;
		}

		// Token: 0x0400003A RID: 58
		public static double _Parameter;

		// Token: 0x0400003B RID: 59
		private static Dictionary<string, ModAni.AniGroupEntry> _Stub;

		// Token: 0x0400003C RID: 60
		private static long m_Account;

		// Token: 0x0400003D RID: 61
		public static bool _Configuration;

		// Token: 0x0400003E RID: 62
		private static int m_Interpreter;

		// Token: 0x0400003F RID: 63
		private static readonly object m_Predicate;

		// Token: 0x04000040 RID: 64
		private static int _Resolver;

		// Token: 0x04000041 RID: 65
		private static int collection;

		// Token: 0x04000042 RID: 66
		private static long tests;

		// Token: 0x04000043 RID: 67
		public static int _Broadcaster;

		// Token: 0x0200001E RID: 30
		private struct AniGroupEntry
		{
			// Token: 0x04000044 RID: 68
			public List<ModAni.AniData> m_ItemRule;

			// Token: 0x04000045 RID: 69
			public string Name;

			// Token: 0x04000046 RID: 70
			public long _SerializerRule;
		}

		// Token: 0x0200001F RID: 31
		public struct AniData
		{
			// Token: 0x04000047 RID: 71
			public ModAni.AniType _InfoRule;

			// Token: 0x04000048 RID: 72
			public ModAni.TypeSub _RepositoryRule;

			// Token: 0x04000049 RID: 73
			public int m_SystemRule;

			// Token: 0x0400004A RID: 74
			public int proccesorRule;

			// Token: 0x0400004B RID: 75
			public double m_PrototypeRule;

			// Token: 0x0400004C RID: 76
			public bool m_RefRule;

			// Token: 0x0400004D RID: 77
			public ModAni.AniEase parameterRule;

			// Token: 0x0400004E RID: 78
			public object[] m_StubRule;

			// Token: 0x0400004F RID: 79
			public object[] Value;

			// Token: 0x04000050 RID: 80
			public ModBase.MyColor m_AccountRule;
		}

		// Token: 0x02000020 RID: 32
		public enum AniType
		{
			// Token: 0x04000052 RID: 82
			Number,
			// Token: 0x04000053 RID: 83
			Color,
			// Token: 0x04000054 RID: 84
			Scale,
			// Token: 0x04000055 RID: 85
			TextAppear,
			// Token: 0x04000056 RID: 86
			Code,
			// Token: 0x04000057 RID: 87
			ScaleTransform,
			// Token: 0x04000058 RID: 88
			RotateTransform
		}

		// Token: 0x02000021 RID: 33
		public enum TypeSub
		{
			// Token: 0x0400005A RID: 90
			X,
			// Token: 0x0400005B RID: 91
			Y,
			// Token: 0x0400005C RID: 92
			Width,
			// Token: 0x0400005D RID: 93
			Height,
			// Token: 0x0400005E RID: 94
			Opacity,
			// Token: 0x0400005F RID: 95
			Value,
			// Token: 0x04000060 RID: 96
			Radius,
			// Token: 0x04000061 RID: 97
			BorderThickness,
			// Token: 0x04000062 RID: 98
			StrokeThickness,
			// Token: 0x04000063 RID: 99
			TranslateX,
			// Token: 0x04000064 RID: 100
			TranslateY,
			// Token: 0x04000065 RID: 101
			Double,
			// Token: 0x04000066 RID: 102
			DoubleParam,
			// Token: 0x04000067 RID: 103
			GridLengthWidth
		}

		// Token: 0x02000022 RID: 34
		public enum AniEasePower
		{
			// Token: 0x04000069 RID: 105
			Weak = 2,
			// Token: 0x0400006A RID: 106
			Middle,
			// Token: 0x0400006B RID: 107
			Strong,
			// Token: 0x0400006C RID: 108
			ExtraStrong
		}

		// Token: 0x02000023 RID: 35
		public abstract class AniEase
		{
			// Token: 0x060000C7 RID: 199
			public abstract double GetValue(double t);

			// Token: 0x060000C8 RID: 200 RVA: 0x00002ACD File Offset: 0x00000CCD
			public virtual double GetDelta(double t1, double t0)
			{
				return this.GetValue(t1) - this.GetValue(t0);
			}
		}

		// Token: 0x02000024 RID: 36
		public class AniEaseInout : ModAni.AniEase
		{
			// Token: 0x060000C9 RID: 201 RVA: 0x00002ADE File Offset: 0x00000CDE
			public AniEaseInout(ModAni.AniEase EaseIn, ModAni.AniEase EaseOut, double EaseInPercent = 0.5)
			{
				this.configurationRule = EaseIn;
				this.EaseOut = EaseOut;
				this.interpreterRule = EaseInPercent;
			}

			// Token: 0x060000CA RID: 202 RVA: 0x00010FEC File Offset: 0x0000F1EC
			public override double GetValue(double t)
			{
				double result;
				if (t < this.interpreterRule)
				{
					result = this.interpreterRule * this.configurationRule.GetValue(t / this.interpreterRule);
				}
				else
				{
					result = (1.0 - this.interpreterRule) * this.EaseOut.GetValue((t - this.interpreterRule) / (1.0 - this.interpreterRule)) + this.interpreterRule;
				}
				return result;
			}

			// Token: 0x0400006D RID: 109
			private readonly ModAni.AniEase configurationRule;

			// Token: 0x0400006E RID: 110
			private readonly ModAni.AniEase EaseOut;

			// Token: 0x0400006F RID: 111
			private readonly double interpreterRule;
		}

		// Token: 0x02000025 RID: 37
		public class AniEaseLinear : ModAni.AniEase
		{
			// Token: 0x060000CC RID: 204 RVA: 0x00002B03 File Offset: 0x00000D03
			public override double GetValue(double t)
			{
				return ModBase.MathRange(t, 0.0, 1.0);
			}

			// Token: 0x060000CD RID: 205 RVA: 0x00002B1D File Offset: 0x00000D1D
			public override double GetDelta(double t1, double t0)
			{
				return ModBase.MathRange(t1, 0.0, 1.0) - ModBase.MathRange(t0, 0.0, 1.0);
			}
		}

		// Token: 0x02000026 RID: 38
		public class AniEaseInFluent : ModAni.AniEase
		{
			// Token: 0x060000CE RID: 206 RVA: 0x00002B50 File Offset: 0x00000D50
			public AniEaseInFluent(ModAni.AniEasePower Power = ModAni.AniEasePower.Middle)
			{
				this._PredicateRule = Power;
			}

			// Token: 0x060000CF RID: 207 RVA: 0x00002B5F File Offset: 0x00000D5F
			public override double GetValue(double t)
			{
				return Math.Pow(ModBase.MathRange(t, 0.0, 1.0), (double)this._PredicateRule);
			}

			// Token: 0x04000070 RID: 112
			private readonly ModAni.AniEasePower _PredicateRule;
		}

		// Token: 0x02000027 RID: 39
		public class AniEaseOutFluent : ModAni.AniEase
		{
			// Token: 0x060000D0 RID: 208 RVA: 0x00002B85 File Offset: 0x00000D85
			public AniEaseOutFluent(ModAni.AniEasePower Power = ModAni.AniEasePower.Middle)
			{
				this.m_StructRule = Power;
			}

			// Token: 0x060000D1 RID: 209 RVA: 0x00002B94 File Offset: 0x00000D94
			public override double GetValue(double t)
			{
				return 1.0 - Math.Pow(ModBase.MathRange(1.0 - t, 0.0, 1.0), (double)this.m_StructRule);
			}

			// Token: 0x04000071 RID: 113
			private readonly ModAni.AniEasePower m_StructRule;
		}

		// Token: 0x02000028 RID: 40
		public class AniEaseInoutFluent : ModAni.AniEase
		{
			// Token: 0x060000D2 RID: 210 RVA: 0x00002BCE File Offset: 0x00000DCE
			public AniEaseInoutFluent(ModAni.AniEasePower Power = ModAni.AniEasePower.Middle, double Middle = 0.5)
			{
				this._ResolverRule = new ModAni.AniEaseInout(new ModAni.AniEaseInFluent(Power), new ModAni.AniEaseOutFluent(Power), Middle);
			}

			// Token: 0x060000D3 RID: 211 RVA: 0x00002BEE File Offset: 0x00000DEE
			public override double GetValue(double t)
			{
				return this._ResolverRule.GetValue(t);
			}

			// Token: 0x04000072 RID: 114
			private ModAni.AniEaseInout _ResolverRule;
		}

		// Token: 0x02000029 RID: 41
		public class AniEaseInBack : ModAni.AniEase
		{
			// Token: 0x060000D4 RID: 212 RVA: 0x00002BFC File Offset: 0x00000DFC
			public AniEaseInBack(ModAni.AniEasePower Power = ModAni.AniEasePower.Middle)
			{
				this._CollectionRule = 3.0 - (double)Power * 0.5;
			}

			// Token: 0x060000D5 RID: 213 RVA: 0x00011060 File Offset: 0x0000F260
			public override double GetValue(double t)
			{
				t = ModBase.MathRange(t, 0.0, 1.0);
				return Math.Pow(t, this._CollectionRule) * Math.Cos(4.71238898038469 * (1.0 - t));
			}

			// Token: 0x04000073 RID: 115
			private readonly double _CollectionRule;
		}

		// Token: 0x0200002A RID: 42
		public class AniEaseOutBack : ModAni.AniEase
		{
			// Token: 0x060000D6 RID: 214 RVA: 0x00002C20 File Offset: 0x00000E20
			public AniEaseOutBack(ModAni.AniEasePower Power = ModAni.AniEasePower.Middle)
			{
				this.testsRule = 3.0 - (double)Power * 0.5;
			}

			// Token: 0x060000D7 RID: 215 RVA: 0x000110B0 File Offset: 0x0000F2B0
			public override double GetValue(double t)
			{
				t = ModBase.MathRange(t, 0.0, 1.0);
				return 1.0 - Math.Pow(1.0 - t, this.testsRule) * Math.Cos(4.71238898038469 * t);
			}

			// Token: 0x04000074 RID: 116
			private readonly double testsRule;
		}

		// Token: 0x0200002B RID: 43
		public class AniEaseInCar : ModAni.AniEase
		{
			// Token: 0x060000D8 RID: 216 RVA: 0x00002C44 File Offset: 0x00000E44
			public AniEaseInCar(double Middle = 0.7, ModAni.AniEasePower Power = ModAni.AniEasePower.Middle)
			{
				this._BroadcasterRule = new ModAni.AniEaseInout(new ModAni.AniEaseInBack(Power), new ModAni.AniEaseOutFluent(Power), Middle);
			}

			// Token: 0x060000D9 RID: 217 RVA: 0x00002C64 File Offset: 0x00000E64
			public override double GetValue(double t)
			{
				return this._BroadcasterRule.GetValue(t);
			}

			// Token: 0x04000075 RID: 117
			private ModAni.AniEaseInout _BroadcasterRule;
		}

		// Token: 0x0200002C RID: 44
		public class AniEaseOutCar : ModAni.AniEase
		{
			// Token: 0x060000DA RID: 218 RVA: 0x00002C72 File Offset: 0x00000E72
			public AniEaseOutCar(double Middle = 0.3, ModAni.AniEasePower Power = ModAni.AniEasePower.Middle)
			{
				this._FieldRule = new ModAni.AniEaseInout(new ModAni.AniEaseInFluent(Power), new ModAni.AniEaseOutBack(Power), Middle);
			}

			// Token: 0x060000DB RID: 219 RVA: 0x00002C92 File Offset: 0x00000E92
			public override double GetValue(double t)
			{
				return this._FieldRule.GetValue(t);
			}

			// Token: 0x04000076 RID: 118
			private ModAni.AniEaseInout _FieldRule;
		}

		// Token: 0x0200002D RID: 45
		public class AniEaseInElastic : ModAni.AniEase
		{
			// Token: 0x060000DC RID: 220 RVA: 0x00002CA0 File Offset: 0x00000EA0
			public AniEaseInElastic(ModAni.AniEasePower Power = ModAni.AniEasePower.Middle)
			{
				this.m_StatusRule = (int)(checked(Power + 4));
			}

			// Token: 0x060000DD RID: 221 RVA: 0x00011108 File Offset: 0x0000F308
			public override double GetValue(double t)
			{
				t = ModBase.MathRange(t, 0.0, 1.0);
				return Math.Pow(t, (double)(checked(this.m_StatusRule - 1)) * 0.25) * Math.Cos(((double)this.m_StatusRule - 3.5) * 3.1415926535897931 * Math.Pow(1.0 - t, 1.5));
			}

			// Token: 0x04000077 RID: 119
			private readonly int m_StatusRule;
		}

		// Token: 0x0200002E RID: 46
		public class AniEaseOutElastic : ModAni.AniEase
		{
			// Token: 0x060000DE RID: 222 RVA: 0x00002CB1 File Offset: 0x00000EB1
			public AniEaseOutElastic(ModAni.AniEasePower Power = ModAni.AniEasePower.Middle)
			{
				this._RequestRule = (int)(checked(Power + 4));
			}

			// Token: 0x060000DF RID: 223 RVA: 0x00011184 File Offset: 0x0000F384
			public override double GetValue(double t)
			{
				t = 1.0 - ModBase.MathRange(t, 0.0, 1.0);
				return 1.0 - Math.Pow(t, (double)(checked(this._RequestRule - 1)) * 0.25) * Math.Cos(((double)this._RequestRule - 3.5) * 3.1415926535897931 * Math.Pow(1.0 - t, 1.5));
			}

			// Token: 0x04000078 RID: 120
			private readonly int _RequestRule;
		}
	}
}
