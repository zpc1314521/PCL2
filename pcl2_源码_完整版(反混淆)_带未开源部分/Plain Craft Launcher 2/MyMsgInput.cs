using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
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
	// Token: 0x02000048 RID: 72
	[DesignerGenerated]
	public class MyMsgInput : Grid, IComponentConnector
	{
		// Token: 0x060001B6 RID: 438 RVA: 0x00014144 File Offset: 0x00012344
		public MyMsgInput(ModMain.MyMsgBoxConverter Converter)
		{
			base.Loaded += new RoutedEventHandler(this.Load);
			this.reponse = ModBase.GetUuid();
			try
			{
				this.InitializeComponent();
				this.Btn1.Name = this.Btn1.Name + Conversions.ToString(ModBase.GetUuid());
				this.Btn2.Name = this.Btn2.Name + Conversions.ToString(ModBase.GetUuid());
				this.Btn3.Name = this.Btn3.Name + Conversions.ToString(ModBase.GetUuid());
				this.m_List = Converter;
				this.LabTitle.Text = Converter.Title;
				this.TextCaption.Text = Conversions.ToString(Converter.m_PoolMapper);
				this.TextCaption.HintText = Converter._ProxyMapper;
				this.TextCaption.ValidateRules = Converter.parserMapper;
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
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "输入弹窗初始化失败", ModBase.LogLevel.Hint, "出现错误");
			}
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0001432C File Offset: 0x0001252C
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
				this.TextCaption.Focus();
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
				}, "MyMsgBox Start " + Conversions.ToString(this.reponse), false);
				this.ShapeLine.Width = 0.0;
				this.ShapeLine.HorizontalAlignment = HorizontalAlignment.Center;
				this.LabTitle.Width = 0.0;
				this.LabTitle.Opacity = 0.0;
				this.LabTitle.TextWrapping = TextWrapping.NoWrap;
				this.PanCaption.Opacity = 0.0;
				ModBase.Log("[Control] 输入弹窗：" + this.LabTitle.Text, ModBase.LogLevel.Normal, "出现错误");
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "输入弹窗加载失败", ModBase.LogLevel.Hint, "出现错误");
			}
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x00014714 File Offset: 0x00012914
		private void Close()
		{
			this.m_List.registryMapper.Continue = false;
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
			}, "MyMsgBox Close " + Conversions.ToString(this.reponse), false);
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00014978 File Offset: 0x00012B78
		public void Btn1_Click()
		{
			if (!this.m_List.attributeMapper && Operators.CompareString(this.TextCaption.ValidateResult, "", true) == 0)
			{
				this.m_List.attributeMapper = true;
				this.m_List.valueMapper = this.TextCaption.Text;
				this.Close();
			}
		}

		// Token: 0x060001BA RID: 442 RVA: 0x000032A8 File Offset: 0x000014A8
		private void Btn2_Click()
		{
			if (!this.m_List.attributeMapper)
			{
				this.m_List.attributeMapper = true;
				this.m_List.valueMapper = null;
				this.Close();
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000032A8 File Offset: 0x000014A8
		private void Btn3_Click()
		{
			if (!this.m_List.attributeMapper)
			{
				this.m_List.attributeMapper = true;
				this.m_List.valueMapper = null;
				this.Close();
			}
		}

		// Token: 0x060001BC RID: 444 RVA: 0x000032D5 File Offset: 0x000014D5
		private void TextCaption_ValidateChanged(object sender, EventArgs e)
		{
			this.Btn1.IsEnabled = (Operators.CompareString(this.TextCaption.ValidateResult, "", true) == 0);
		}

		// Token: 0x060001BD RID: 445 RVA: 0x000149D4 File Offset: 0x00012BD4
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

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060001BE RID: 446 RVA: 0x000032FB File Offset: 0x000014FB
		// (set) Token: 0x060001BF RID: 447 RVA: 0x00014A8C File Offset: 0x00012C8C
		internal virtual Border PanBorder
		{
			[CompilerGenerated]
			get
			{
				return this._Identifier;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseButtonEventHandler value2 = new MouseButtonEventHandler(this.Drag);
				Border identifier = this._Identifier;
				if (identifier != null)
				{
					identifier.MouseLeftButtonDown -= value2;
				}
				this._Identifier = value;
				identifier = this._Identifier;
				if (identifier != null)
				{
					identifier.MouseLeftButtonDown += value2;
				}
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x00003303 File Offset: 0x00001503
		// (set) Token: 0x060001C1 RID: 449 RVA: 0x0000330B File Offset: 0x0000150B
		internal virtual DropShadowEffect EffectShadow { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x00003314 File Offset: 0x00001514
		// (set) Token: 0x060001C3 RID: 451 RVA: 0x0000331C File Offset: 0x0000151C
		internal virtual StackPanel PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x00003325 File Offset: 0x00001525
		// (set) Token: 0x060001C5 RID: 453 RVA: 0x00014AD0 File Offset: 0x00012CD0
		internal virtual TextBlock LabTitle
		{
			[CompilerGenerated]
			get
			{
				return this._Map;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseButtonEventHandler value2 = new MouseButtonEventHandler(this.Drag);
				TextBlock map = this._Map;
				if (map != null)
				{
					map.MouseLeftButtonDown -= value2;
				}
				this._Map = value;
				map = this._Map;
				if (map != null)
				{
					map.MouseLeftButtonDown += value2;
				}
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x0000332D File Offset: 0x0000152D
		// (set) Token: 0x060001C7 RID: 455 RVA: 0x00003335 File Offset: 0x00001535
		internal virtual Rectangle ShapeLine { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x0000333E File Offset: 0x0000153E
		// (set) Token: 0x060001C9 RID: 457 RVA: 0x00003346 File Offset: 0x00001546
		internal virtual Border PanCaption { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060001CA RID: 458 RVA: 0x0000334F File Offset: 0x0000154F
		// (set) Token: 0x060001CB RID: 459 RVA: 0x00014B14 File Offset: 0x00012D14
		internal virtual MyTextBox TextCaption
		{
			[CompilerGenerated]
			get
			{
				return this.message;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyTextBox.ValidateChangedEventHandler obj = new MyTextBox.ValidateChangedEventHandler(this.TextCaption_ValidateChanged);
				if (this.message != null)
				{
					MyTextBox.EnableVal(obj);
				}
				this.message = value;
				if (this.message != null)
				{
					MyTextBox.ManageVal(obj);
				}
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060001CC RID: 460 RVA: 0x00003357 File Offset: 0x00001557
		// (set) Token: 0x060001CD RID: 461 RVA: 0x0000335F File Offset: 0x0000155F
		internal virtual StackPanel PanBtn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060001CE RID: 462 RVA: 0x00003368 File Offset: 0x00001568
		// (set) Token: 0x060001CF RID: 463 RVA: 0x00014B54 File Offset: 0x00012D54
		internal virtual MyButton Btn1
		{
			[CompilerGenerated]
			get
			{
				return this._Proc;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.Btn1_Click();
				};
				MyButton proc = this._Proc;
				if (proc != null)
				{
					proc.CancelModel(obj);
				}
				this._Proc = value;
				proc = this._Proc;
				if (proc != null)
				{
					proc.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x00003370 File Offset: 0x00001570
		// (set) Token: 0x060001D1 RID: 465 RVA: 0x00014B98 File Offset: 0x00012D98
		internal virtual MyButton Btn2
		{
			[CompilerGenerated]
			get
			{
				return this.factoryVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.Btn2_Click();
				};
				MyButton myButton = this.factoryVal;
				if (myButton != null)
				{
					myButton.CancelModel(obj);
				}
				this.factoryVal = value;
				myButton = this.factoryVal;
				if (myButton != null)
				{
					myButton.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x00003378 File Offset: 0x00001578
		// (set) Token: 0x060001D3 RID: 467 RVA: 0x00014BDC File Offset: 0x00012DDC
		internal virtual MyButton Btn3
		{
			[CompilerGenerated]
			get
			{
				return this.valVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.Btn3_Click();
				};
				MyButton myButton = this.valVal;
				if (myButton != null)
				{
					myButton.CancelModel(obj);
				}
				this.valVal = value;
				myButton = this.valVal;
				if (myButton != null)
				{
					myButton.ValidateModel(obj);
				}
			}
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00014C20 File Offset: 0x00012E20
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.m_ContainerVal)
			{
				this.m_ContainerVal = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/controls/mymsg/mymsginput.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00014C50 File Offset: 0x00012E50
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBorder = (Border)target;
				return;
			}
			if (connectionId == 2)
			{
				this.EffectShadow = (DropShadowEffect)target;
				return;
			}
			if (connectionId == 3)
			{
				this.PanMain = (StackPanel)target;
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
				this.PanCaption = (Border)target;
				return;
			}
			if (connectionId == 7)
			{
				this.TextCaption = (MyTextBox)target;
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
			this.m_ContainerVal = true;
		}

		// Token: 0x040000CB RID: 203
		private readonly ModMain.MyMsgBoxConverter m_List;

		// Token: 0x040000CC RID: 204
		private readonly int reponse;

		// Token: 0x040000CD RID: 205
		[AccessedThroughProperty("PanBorder")]
		[CompilerGenerated]
		private Border _Identifier;

		// Token: 0x040000CE RID: 206
		[CompilerGenerated]
		[AccessedThroughProperty("EffectShadow")]
		private DropShadowEffect policy;

		// Token: 0x040000CF RID: 207
		[CompilerGenerated]
		[AccessedThroughProperty("PanMain")]
		private StackPanel _Client;

		// Token: 0x040000D0 RID: 208
		[AccessedThroughProperty("LabTitle")]
		[CompilerGenerated]
		private TextBlock _Map;

		// Token: 0x040000D1 RID: 209
		[CompilerGenerated]
		[AccessedThroughProperty("ShapeLine")]
		private Rectangle _Composer;

		// Token: 0x040000D2 RID: 210
		[AccessedThroughProperty("PanCaption")]
		[CompilerGenerated]
		private Border _Publisher;

		// Token: 0x040000D3 RID: 211
		[CompilerGenerated]
		[AccessedThroughProperty("TextCaption")]
		private MyTextBox message;

		// Token: 0x040000D4 RID: 212
		[CompilerGenerated]
		[AccessedThroughProperty("PanBtn")]
		private StackPanel _Token;

		// Token: 0x040000D5 RID: 213
		[AccessedThroughProperty("Btn1")]
		[CompilerGenerated]
		private MyButton _Proc;

		// Token: 0x040000D6 RID: 214
		[AccessedThroughProperty("Btn2")]
		[CompilerGenerated]
		private MyButton factoryVal;

		// Token: 0x040000D7 RID: 215
		[AccessedThroughProperty("Btn3")]
		[CompilerGenerated]
		private MyButton valVal;

		// Token: 0x040000D8 RID: 216
		private bool m_ContainerVal;
	}
}
