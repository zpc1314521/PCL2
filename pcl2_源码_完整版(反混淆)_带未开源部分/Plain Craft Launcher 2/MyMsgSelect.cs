using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace PCL
{
	// Token: 0x02000049 RID: 73
	[DesignerGenerated]
	public class MyMsgSelect : Grid, IComponentConnector
	{
		// Token: 0x060001DC RID: 476 RVA: 0x00014D88 File Offset: 0x00012F88
		public MyMsgSelect(ModMain.MyMsgBoxConverter Converter)
		{
			base.Loaded += new RoutedEventHandler(this.Load);
			this.m_IteratorVal = ModBase.GetUuid();
			this.m_ExpressionVal = -1;
			try
			{
				this.InitializeComponent();
				this.Btn1.Name = this.Btn1.Name + Conversions.ToString(ModBase.GetUuid());
				this.Btn2.Name = this.Btn2.Name + Conversions.ToString(ModBase.GetUuid());
				this.Btn3.Name = this.Btn3.Name + Conversions.ToString(ModBase.GetUuid());
				this._ModelVal = Converter;
				this.LabTitle.Text = Converter.Title;
				this.Btn1.Text = Converter.merchantMapper;
				if (Converter._ProductMapper)
				{
					this.Btn1.ColorType = MyButton.ColorState.Red;
					this.LabTitle.SetResourceReference(TextBlock.ForegroundProperty, "ColorBrushRedLight");
					this.ShapeLine.SetResourceReference(Shape.FillProperty, "ColorBrushRedLight");
				}
				this.Btn2.Text = Converter._EventMapper;
				this.Btn3.Text = Converter._PrinterMapper;
				this.Btn2.Visibility = ((Operators.CompareString(Converter._EventMapper, "", true) == 0) ? Visibility.Collapsed : Visibility.Visible);
				this.Btn3.Visibility = ((Operators.CompareString(Converter._PrinterMapper, "", true) == 0) ? Visibility.Collapsed : Visibility.Visible);
				try
				{
					foreach (object obj in ((IEnumerable)Converter.m_PoolMapper))
					{
						IMyRadio myRadio = (IMyRadio)obj;
						this.PanSelection.Children.Add((UIElement)myRadio);
						myRadio.Check += delegate(object sender, ModBase.RouteEventArgs e)
						{
							this.OnChecked((IMyRadio)sender, e);
						};
						if (myRadio is MyListItem)
						{
							((MyListItem)myRadio).Type = MyListItem.CheckType.RadioBox;
							((MyListItem)myRadio).MinHeight = 24.0;
						}
						else
						{
							((MyRadioBox)myRadio).MinHeight = 26.0;
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
			catch (Exception ex)
			{
				ModBase.Log(ex, "选择弹窗初始化失败", ModBase.LogLevel.Hint, "出现错误");
			}
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00014FFC File Offset: 0x000131FC
		private void Load(object sender, EventArgs e)
		{
			try
			{
				if (this.Btn2.IsVisible && this.Btn1.ColorType != MyButton.ColorState.Red)
				{
					this.Btn1.ColorType = MyButton.ColorState.Highlight;
				}
				this.ShapeLine.StrokeThickness = ModBase.smethod_4(1.0);
				base.Measure(new Size(ModMain.m_GetterFilter.Width, ModMain.m_GetterFilter.Height));
				base.Arrange(new Rect(0.0, 0.0, ModMain.m_GetterFilter.Width, ModMain.m_GetterFilter.Height));
				if (ModMain.m_GetterFilter.Width - base.ActualWidth < 20.0)
				{
					base.Width = ModMain.m_GetterFilter.Width - ModBase.smethod_4(2.0);
				}
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaColor(ModMain.m_GetterFilter.PanMsg, Panel.BackgroundProperty, new ModBase.MyColor(60.0, 0.0, 0.0, 0.0), 0xFA, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaColor(this.PanBorder, Border.BackgroundProperty, new ModBase.MyColor(255.0, 0.0, 0.0, 0.0), 0x96, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaOpacity(this.EffectShadow, 0.75, 0x190, 0x32, null, false),
					ModAni.AaWidth(this.ShapeLine, this.ShapeLine.ActualWidth, 0xFA, 0x64, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaOpacity(this.ShapeLine, 1.0, 0xC8, 0x64, null, false),
					ModAni.AaWidth(this.LabTitle, this.LabTitle.ActualWidth, 0xC8, 0x64, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaOpacity(this.LabTitle, 1.0, 0x96, 0x96, null, false),
					ModAni.AaOpacity(this.PanCaption, 1.0, 0x96, 0x96, null, false),
					ModAni.AaOpacity(this.Btn1, 1.0, 0x96, 0x64, null, false),
					ModAni.AaOpacity(this.Btn2, 1.0, 0x96, 0x96, null, false),
					ModAni.AaOpacity(this.Btn3, 1.0, 0x96, 0xC8, null, false),
					ModAni.AaCode(delegate
					{
						this.ShapeLine.MinWidth = this.ShapeLine.ActualWidth;
						this.ShapeLine.HorizontalAlignment = HorizontalAlignment.Stretch;
						this.ShapeLine.Width = double.NaN;
						this.LabTitle.Width = double.NaN;
						this.LabTitle.TextTrimming = TextTrimming.CharacterEllipsis;
					}, 0x15E, false)
				}, "MyMsgBox Start " + Conversions.ToString(this.m_IteratorVal), false);
				this.ShapeLine.Width = 0.0;
				this.ShapeLine.HorizontalAlignment = HorizontalAlignment.Center;
				this.LabTitle.Width = 0.0;
				this.LabTitle.Opacity = 0.0;
				this.LabTitle.TextWrapping = TextWrapping.NoWrap;
				this.PanCaption.Opacity = 0.0;
				ModBase.Log("[Control] 选择弹窗：" + this.LabTitle.Text, ModBase.LogLevel.Normal, "出现错误");
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "选择弹窗加载失败", ModBase.LogLevel.Hint, "出现错误");
			}
		}

		// Token: 0x060001DE RID: 478 RVA: 0x000153D8 File Offset: 0x000135D8
		private void Close()
		{
			this._ModelVal.registryMapper.Continue = false;
			ComponentDispatcher.PopModal();
			this.LabTitle.TextTrimming = TextTrimming.None;
			this.LabTitle.TextWrapping = TextWrapping.NoWrap;
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaColor(ModMain.m_GetterFilter.PanMsg, Panel.BackgroundProperty, new ModBase.MyColor(-60.0, 0.0, 0.0, 0.0), 0x15E, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaColor(this.PanBorder, Border.BackgroundProperty, new ModBase.MyColor(-255.0, 0.0, 0.0, 0.0), 0x12C, 0x64, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaOpacity(this.EffectShadow, -0.75, 0x96, 0, null, false),
				ModAni.AaWidth(this.ShapeLine, -this.ShapeLine.ActualWidth, 0xFA, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaOpacity(this.ShapeLine, -1.0, 0x96, 0x64, null, false),
				ModAni.AaWidth(this.LabTitle, -this.LabTitle.ActualWidth, 0xFA, 0, null, false),
				ModAni.AaOpacity(this.LabTitle, -1.0, 0xC8, 0, null, false),
				ModAni.AaOpacity(this.PanCaption, -1.0, 0xC8, 0, null, false),
				ModAni.AaOpacity(this.Btn1, -1.0, 0x96, 0, null, false),
				ModAni.AaOpacity(this.Btn2, -1.0, 0x96, 0x32, null, false),
				ModAni.AaOpacity(this.Btn3, -1.0, 0x96, 0x64, null, false),
				ModAni.AaCode(delegate
				{
					((Grid)base.Parent).Children.Remove(this);
				}, 0, true)
			}, "MyMsgBox Close " + Conversions.ToString(this.m_IteratorVal), false);
		}

		// Token: 0x060001DF RID: 479 RVA: 0x000033B0 File Offset: 0x000015B0
		public void Btn1_Click()
		{
			if (!this._ModelVal.attributeMapper && this.m_ExpressionVal != -1)
			{
				this._ModelVal.attributeMapper = true;
				this._ModelVal.valueMapper = this.m_ExpressionVal;
				this.Close();
			}
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x000033F0 File Offset: 0x000015F0
		private void Btn2_Click()
		{
			if (!this._ModelVal.attributeMapper)
			{
				this._ModelVal.attributeMapper = true;
				this._ModelVal.valueMapper = null;
				this.Close();
			}
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x000033F0 File Offset: 0x000015F0
		private void Btn3_Click()
		{
			if (!this._ModelVal.attributeMapper)
			{
				this._ModelVal.attributeMapper = true;
				this._ModelVal.valueMapper = null;
				this.Close();
			}
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0000341D File Offset: 0x0000161D
		private void OnChecked(IMyRadio sender, EventArgs e)
		{
			this.Btn1.IsEnabled = true;
			this.m_ExpressionVal = this.PanSelection.Children.IndexOf((UIElement)sender);
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0001563C File Offset: 0x0001383C
		private void Drag(object sender, MouseButtonEventArgs e)
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
				if (e.GetPosition(this.ShapeLine).Y > 2.0)
				{
					goto IL_34;
				}
				IL_28:
				num2 = 3;
				ModMain.m_GetterFilter.DragMove();
				IL_34:
				goto IL_93;
				IL_36:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_54:
				goto IL_88;
				IL_56:
				num4 = num2;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_66:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_56;
			}
			IL_88:
			throw ProjectData.CreateProjectError(-0x7FF5FFCD);
			IL_93:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x00003447 File Offset: 0x00001647
		// (set) Token: 0x060001E5 RID: 485 RVA: 0x0000344F File Offset: 0x0000164F
		internal virtual MyMsgSelect PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x00003458 File Offset: 0x00001658
		// (set) Token: 0x060001E7 RID: 487 RVA: 0x000156F4 File Offset: 0x000138F4
		internal virtual Border PanBorder
		{
			[CompilerGenerated]
			get
			{
				return this.baseVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseButtonEventHandler value2 = new MouseButtonEventHandler(this.Drag);
				Border border = this.baseVal;
				if (border != null)
				{
					border.MouseLeftButtonDown -= value2;
				}
				this.baseVal = value;
				border = this.baseVal;
				if (border != null)
				{
					border.MouseLeftButtonDown += value2;
				}
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x00003460 File Offset: 0x00001660
		// (set) Token: 0x060001E9 RID: 489 RVA: 0x00003468 File Offset: 0x00001668
		internal virtual DropShadowEffect EffectShadow { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060001EA RID: 490 RVA: 0x00003471 File Offset: 0x00001671
		// (set) Token: 0x060001EB RID: 491 RVA: 0x00015738 File Offset: 0x00013938
		internal virtual TextBlock LabTitle
		{
			[CompilerGenerated]
			get
			{
				return this.filterVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseButtonEventHandler value2 = new MouseButtonEventHandler(this.Drag);
				TextBlock textBlock = this.filterVal;
				if (textBlock != null)
				{
					textBlock.MouseLeftButtonDown -= value2;
				}
				this.filterVal = value;
				textBlock = this.filterVal;
				if (textBlock != null)
				{
					textBlock.MouseLeftButtonDown += value2;
				}
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060001EC RID: 492 RVA: 0x00003479 File Offset: 0x00001679
		// (set) Token: 0x060001ED RID: 493 RVA: 0x00003481 File Offset: 0x00001681
		internal virtual Rectangle ShapeLine { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060001EE RID: 494 RVA: 0x0000348A File Offset: 0x0000168A
		// (set) Token: 0x060001EF RID: 495 RVA: 0x00003492 File Offset: 0x00001692
		internal virtual MyScrollViewer PanCaption { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x0000349B File Offset: 0x0000169B
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x000034A3 File Offset: 0x000016A3
		internal virtual StackPanel PanSelection { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x000034AC File Offset: 0x000016AC
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x000034B4 File Offset: 0x000016B4
		internal virtual StackPanel PanBtn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x000034BD File Offset: 0x000016BD
		// (set) Token: 0x060001F5 RID: 501 RVA: 0x0001577C File Offset: 0x0001397C
		internal virtual MyButton Btn1
		{
			[CompilerGenerated]
			get
			{
				return this.m_GlobalVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.Btn1_Click();
				};
				MyButton globalVal = this.m_GlobalVal;
				if (globalVal != null)
				{
					globalVal.CancelModel(obj);
				}
				this.m_GlobalVal = value;
				globalVal = this.m_GlobalVal;
				if (globalVal != null)
				{
					globalVal.ValidateModel(obj);
				}
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x000034C5 File Offset: 0x000016C5
		// (set) Token: 0x060001F7 RID: 503 RVA: 0x000157C0 File Offset: 0x000139C0
		internal virtual MyButton Btn2
		{
			[CompilerGenerated]
			get
			{
				return this.m_IssuerVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.Btn2_Click();
				};
				MyButton issuerVal = this.m_IssuerVal;
				if (issuerVal != null)
				{
					issuerVal.CancelModel(obj);
				}
				this.m_IssuerVal = value;
				issuerVal = this.m_IssuerVal;
				if (issuerVal != null)
				{
					issuerVal.ValidateModel(obj);
				}
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x000034CD File Offset: 0x000016CD
		// (set) Token: 0x060001F9 RID: 505 RVA: 0x00015804 File Offset: 0x00013A04
		internal virtual MyButton Btn3
		{
			[CompilerGenerated]
			get
			{
				return this._ServiceVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.Btn3_Click();
				};
				MyButton serviceVal = this._ServiceVal;
				if (serviceVal != null)
				{
					serviceVal.CancelModel(obj);
				}
				this._ServiceVal = value;
				serviceVal = this._ServiceVal;
				if (serviceVal != null)
				{
					serviceVal.ValidateModel(obj);
				}
			}
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00015848 File Offset: 0x00013A48
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.m_FacadeVal)
			{
				this.m_FacadeVal = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/controls/mymsg/mymsgselect.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00015878 File Offset: 0x00013A78
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (MyMsgSelect)target;
				return;
			}
			if (connectionId == 2)
			{
				this.PanBorder = (Border)target;
				return;
			}
			if (connectionId == 3)
			{
				this.EffectShadow = (DropShadowEffect)target;
				return;
			}
			if (connectionId == 4)
			{
				this.LabTitle = (TextBlock)target;
				return;
			}
			if (connectionId == 5)
			{
				this.ShapeLine = (Rectangle)target;
				return;
			}
			if (connectionId == 6)
			{
				this.PanCaption = (MyScrollViewer)target;
				return;
			}
			if (connectionId == 7)
			{
				this.PanSelection = (StackPanel)target;
				return;
			}
			if (connectionId == 8)
			{
				this.PanBtn = (StackPanel)target;
				return;
			}
			if (connectionId == 9)
			{
				this.Btn1 = (MyButton)target;
				return;
			}
			if (connectionId == 0xA)
			{
				this.Btn2 = (MyButton)target;
				return;
			}
			if (connectionId == 0xB)
			{
				this.Btn3 = (MyButton)target;
				return;
			}
			this.m_FacadeVal = true;
		}

		// Token: 0x040000D9 RID: 217
		private readonly ModMain.MyMsgBoxConverter _ModelVal;

		// Token: 0x040000DA RID: 218
		private readonly int m_IteratorVal;

		// Token: 0x040000DB RID: 219
		private int m_ExpressionVal;

		// Token: 0x040000DC RID: 220
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private MyMsgSelect m_UtilsVal;

		// Token: 0x040000DD RID: 221
		[CompilerGenerated]
		[AccessedThroughProperty("PanBorder")]
		private Border baseVal;

		// Token: 0x040000DE RID: 222
		[CompilerGenerated]
		[AccessedThroughProperty("EffectShadow")]
		private DropShadowEffect _DecoratorVal;

		// Token: 0x040000DF RID: 223
		[CompilerGenerated]
		[AccessedThroughProperty("LabTitle")]
		private TextBlock filterVal;

		// Token: 0x040000E0 RID: 224
		[AccessedThroughProperty("ShapeLine")]
		[CompilerGenerated]
		private Rectangle m_RuleVal;

		// Token: 0x040000E1 RID: 225
		[CompilerGenerated]
		[AccessedThroughProperty("PanCaption")]
		private MyScrollViewer algoVal;

		// Token: 0x040000E2 RID: 226
		[CompilerGenerated]
		[AccessedThroughProperty("PanSelection")]
		private StackPanel mapperVal;

		// Token: 0x040000E3 RID: 227
		[CompilerGenerated]
		[AccessedThroughProperty("PanBtn")]
		private StackPanel m_ParamsVal;

		// Token: 0x040000E4 RID: 228
		[AccessedThroughProperty("Btn1")]
		[CompilerGenerated]
		private MyButton m_GlobalVal;

		// Token: 0x040000E5 RID: 229
		[AccessedThroughProperty("Btn2")]
		[CompilerGenerated]
		private MyButton m_IssuerVal;

		// Token: 0x040000E6 RID: 230
		[CompilerGenerated]
		[AccessedThroughProperty("Btn3")]
		private MyButton _ServiceVal;

		// Token: 0x040000E7 RID: 231
		private bool m_FacadeVal;
	}
}
