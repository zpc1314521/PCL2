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
	// Token: 0x02000171 RID: 369
	[DesignerGenerated]
	public class MyMsgText : Grid, IComponentConnector
	{
		// Token: 0x0600101D RID: 4125 RVA: 0x00075FA8 File Offset: 0x000741A8
		public MyMsgText(ModMain.MyMsgBoxConverter Converter)
		{
			base.Loaded += new RoutedEventHandler(this.Load);
			this._FieldDecorator = ModBase.GetUuid();
			try
			{
				this.InitializeComponent();
				this.Btn1.Name = this.Btn1.Name + Conversions.ToString(ModBase.GetUuid());
				this.Btn2.Name = this.Btn2.Name + Conversions.ToString(ModBase.GetUuid());
				this.Btn3.Name = this.Btn3.Name + Conversions.ToString(ModBase.GetUuid());
				this.m_BroadcasterDecorator = Converter;
				this.LabTitle.Text = Converter.Title;
				this.LabCaption.Text = Conversions.ToString(Converter.m_PoolMapper);
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
				this.ShapeLine.StrokeThickness = ModBase.smethod_4(1.0);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "普通弹窗初始化失败", ModBase.LogLevel.Hint, "出现错误");
			}
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x00076188 File Offset: 0x00074388
		private void Load(object sender, EventArgs e)
		{
			try
			{
				if (this.Btn2.IsVisible && this.Btn1.ColorType != MyButton.ColorState.Red)
				{
					this.Btn1.ColorType = MyButton.ColorState.Highlight;
				}
				base.Measure(new Size(ModMain.m_GetterFilter.Width - 20.0, ModMain.m_GetterFilter.Height - 20.0));
				base.Arrange(new Rect(0.0, 0.0, ModMain.m_GetterFilter.Width - 20.0, ModMain.m_GetterFilter.Height - 20.0));
				this.Btn1.Focus();
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaColor(ModMain.m_GetterFilter.PanMsg, Panel.BackgroundProperty, new ModBase.MyColor(60.0, 0.0, 0.0, 0.0), 0xFA, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaColor(this.PanBorder, Border.BackgroundProperty, new ModBase.MyColor(255.0, 0.0, 0.0, 0.0), 0x96, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaOpacity(this.EffectShadow, 0.75, 0x190, 0x32, null, false),
					ModAni.AaWidth(this.ShapeLine, this.ShapeLine.ActualWidth, 0xFA, 0x64, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaOpacity(this.ShapeLine, 1.0, 0xC8, 0x64, null, false),
					ModAni.AaWidth(this.LabTitle, this.LabTitle.ActualWidth, 0xC8, 0x96, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
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
				}, "MyMsgBox Start " + Conversions.ToString(this._FieldDecorator), false);
				this.ShapeLine.Width = 0.0;
				this.ShapeLine.HorizontalAlignment = HorizontalAlignment.Center;
				this.LabTitle.Width = 0.0;
				this.LabTitle.Opacity = 0.0;
				this.LabTitle.TextWrapping = TextWrapping.NoWrap;
				this.PanCaption.Opacity = 0.0;
				ModBase.Log("[Control] 普通弹窗：" + this.LabTitle.Text + "\r\n" + this.LabCaption.Text, ModBase.LogLevel.Normal, "出现错误");
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "普通弹窗加载失败", ModBase.LogLevel.Hint, "出现错误");
			}
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x00076558 File Offset: 0x00074758
		private void Close()
		{
			if (this.m_BroadcasterDecorator._ComparatorMapper || Operators.CompareString(this.m_BroadcasterDecorator._EventMapper, "", true) != 0)
			{
				this.m_BroadcasterDecorator.registryMapper.Continue = false;
			}
			ComponentDispatcher.PopModal();
			this.LabTitle.TextTrimming = TextTrimming.None;
			this.LabTitle.TextWrapping = TextWrapping.NoWrap;
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaColor(ModMain.m_GetterFilter.PanMsg, Panel.BackgroundProperty, new ModBase.MyColor(-60.0, 0.0, 0.0, 0.0), 0x15E, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaColor(this.PanBorder, Border.BackgroundProperty, new ModBase.MyColor(-255.0, 0.0, 0.0, 0.0), 0x12C, 0x64, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false),
				ModAni.AaOpacity(this.EffectShadow, -0.75, 0x96, 0, null, false),
				ModAni.AaWidth(this.ShapeLine, -this.ShapeLine.ActualWidth, 0xFA, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Weak), false),
				ModAni.AaOpacity(this.ShapeLine, -1.0, 0xC8, 0, null, false),
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
			}, "MyMsgBox Close " + Conversions.ToString(this._FieldDecorator), false);
			this.ShapeLine.MinWidth = 0.0;
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x0000A60E File Offset: 0x0000880E
		public void Btn1_Click()
		{
			if (!this.m_BroadcasterDecorator.attributeMapper)
			{
				this.m_BroadcasterDecorator.attributeMapper = true;
				this.m_BroadcasterDecorator.valueMapper = 1;
				this.Close();
			}
		}

		// Token: 0x06001021 RID: 4129 RVA: 0x0000A640 File Offset: 0x00008840
		private void Btn2_Click()
		{
			if (!this.m_BroadcasterDecorator.attributeMapper)
			{
				this.m_BroadcasterDecorator.attributeMapper = true;
				this.m_BroadcasterDecorator.valueMapper = 2;
				this.Close();
			}
		}

		// Token: 0x06001022 RID: 4130 RVA: 0x0000A672 File Offset: 0x00008872
		private void Btn3_Click()
		{
			if (!this.m_BroadcasterDecorator.attributeMapper)
			{
				this.m_BroadcasterDecorator.attributeMapper = true;
				this.m_BroadcasterDecorator.valueMapper = 3;
				this.Close();
			}
		}

		// Token: 0x06001023 RID: 4131 RVA: 0x000767F4 File Offset: 0x000749F4
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

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06001024 RID: 4132 RVA: 0x0000A6A4 File Offset: 0x000088A4
		// (set) Token: 0x06001025 RID: 4133 RVA: 0x0000A6AC File Offset: 0x000088AC
		internal virtual MyMsgText PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x06001026 RID: 4134 RVA: 0x0000A6B5 File Offset: 0x000088B5
		// (set) Token: 0x06001027 RID: 4135 RVA: 0x000768AC File Offset: 0x00074AAC
		internal virtual Border PanBorder
		{
			[CompilerGenerated]
			get
			{
				return this.requestDecorator;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseButtonEventHandler value2 = new MouseButtonEventHandler(this.Drag);
				Border border = this.requestDecorator;
				if (border != null)
				{
					border.MouseLeftButtonDown -= value2;
				}
				this.requestDecorator = value;
				border = this.requestDecorator;
				if (border != null)
				{
					border.MouseLeftButtonDown += value2;
				}
			}
		}

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x06001028 RID: 4136 RVA: 0x0000A6BD File Offset: 0x000088BD
		// (set) Token: 0x06001029 RID: 4137 RVA: 0x0000A6C5 File Offset: 0x000088C5
		internal virtual DropShadowEffect EffectShadow { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x0600102A RID: 4138 RVA: 0x0000A6CE File Offset: 0x000088CE
		// (set) Token: 0x0600102B RID: 4139 RVA: 0x000768F0 File Offset: 0x00074AF0
		internal virtual TextBlock LabTitle
		{
			[CompilerGenerated]
			get
			{
				return this._ParserDecorator;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseButtonEventHandler value2 = new MouseButtonEventHandler(this.Drag);
				TextBlock parserDecorator = this._ParserDecorator;
				if (parserDecorator != null)
				{
					parserDecorator.MouseLeftButtonDown -= value2;
				}
				this._ParserDecorator = value;
				parserDecorator = this._ParserDecorator;
				if (parserDecorator != null)
				{
					parserDecorator.MouseLeftButtonDown += value2;
				}
			}
		}

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x0600102C RID: 4140 RVA: 0x0000A6D6 File Offset: 0x000088D6
		// (set) Token: 0x0600102D RID: 4141 RVA: 0x0000A6DE File Offset: 0x000088DE
		internal virtual Rectangle ShapeLine { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x0600102E RID: 4142 RVA: 0x0000A6E7 File Offset: 0x000088E7
		// (set) Token: 0x0600102F RID: 4143 RVA: 0x0000A6EF File Offset: 0x000088EF
		internal virtual MyScrollViewer PanCaption { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06001030 RID: 4144 RVA: 0x0000A6F8 File Offset: 0x000088F8
		// (set) Token: 0x06001031 RID: 4145 RVA: 0x0000A700 File Offset: 0x00008900
		internal virtual TextBlock LabCaption { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06001032 RID: 4146 RVA: 0x0000A709 File Offset: 0x00008909
		// (set) Token: 0x06001033 RID: 4147 RVA: 0x0000A711 File Offset: 0x00008911
		internal virtual StackPanel PanBtn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06001034 RID: 4148 RVA: 0x0000A71A File Offset: 0x0000891A
		// (set) Token: 0x06001035 RID: 4149 RVA: 0x00076934 File Offset: 0x00074B34
		internal virtual MyButton Btn1
		{
			[CompilerGenerated]
			get
			{
				return this.m_PrinterDecorator;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.Btn1_Click();
				};
				MyButton printerDecorator = this.m_PrinterDecorator;
				if (printerDecorator != null)
				{
					printerDecorator.CancelModel(obj);
				}
				this.m_PrinterDecorator = value;
				printerDecorator = this.m_PrinterDecorator;
				if (printerDecorator != null)
				{
					printerDecorator.ValidateModel(obj);
				}
			}
		}

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06001036 RID: 4150 RVA: 0x0000A722 File Offset: 0x00008922
		// (set) Token: 0x06001037 RID: 4151 RVA: 0x00076978 File Offset: 0x00074B78
		internal virtual MyButton Btn2
		{
			[CompilerGenerated]
			get
			{
				return this.m_ProductDecorator;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.Btn2_Click();
				};
				MyButton productDecorator = this.m_ProductDecorator;
				if (productDecorator != null)
				{
					productDecorator.CancelModel(obj);
				}
				this.m_ProductDecorator = value;
				productDecorator = this.m_ProductDecorator;
				if (productDecorator != null)
				{
					productDecorator.ValidateModel(obj);
				}
			}
		}

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06001038 RID: 4152 RVA: 0x0000A72A File Offset: 0x0000892A
		// (set) Token: 0x06001039 RID: 4153 RVA: 0x000769BC File Offset: 0x00074BBC
		internal virtual MyButton Btn3
		{
			[CompilerGenerated]
			get
			{
				return this.comparatorDecorator;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.Btn3_Click();
				};
				MyButton myButton = this.comparatorDecorator;
				if (myButton != null)
				{
					myButton.CancelModel(obj);
				}
				this.comparatorDecorator = value;
				myButton = this.comparatorDecorator;
				if (myButton != null)
				{
					myButton.ValidateModel(obj);
				}
			}
		}

		// Token: 0x0600103A RID: 4154 RVA: 0x00076A00 File Offset: 0x00074C00
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.registryDecorator)
			{
				this.registryDecorator = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/controls/mymsg/mymsgtext.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x0600103B RID: 4155 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600103C RID: 4156 RVA: 0x00076A30 File Offset: 0x00074C30
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (MyMsgText)target;
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
				this.LabCaption = (TextBlock)target;
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
			this.registryDecorator = true;
		}

		// Token: 0x04000869 RID: 2153
		private readonly ModMain.MyMsgBoxConverter m_BroadcasterDecorator;

		// Token: 0x0400086A RID: 2154
		private readonly int _FieldDecorator;

		// Token: 0x0400086B RID: 2155
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private MyMsgText statusDecorator;

		// Token: 0x0400086C RID: 2156
		[AccessedThroughProperty("PanBorder")]
		[CompilerGenerated]
		private Border requestDecorator;

		// Token: 0x0400086D RID: 2157
		[AccessedThroughProperty("EffectShadow")]
		[CompilerGenerated]
		private DropShadowEffect poolDecorator;

		// Token: 0x0400086E RID: 2158
		[AccessedThroughProperty("LabTitle")]
		[CompilerGenerated]
		private TextBlock _ParserDecorator;

		// Token: 0x0400086F RID: 2159
		[CompilerGenerated]
		[AccessedThroughProperty("ShapeLine")]
		private Rectangle _ProxyDecorator;

		// Token: 0x04000870 RID: 2160
		[CompilerGenerated]
		[AccessedThroughProperty("PanCaption")]
		private MyScrollViewer _SetterDecorator;

		// Token: 0x04000871 RID: 2161
		[CompilerGenerated]
		[AccessedThroughProperty("LabCaption")]
		private TextBlock m_MerchantDecorator;

		// Token: 0x04000872 RID: 2162
		[CompilerGenerated]
		[AccessedThroughProperty("PanBtn")]
		private StackPanel eventDecorator;

		// Token: 0x04000873 RID: 2163
		[CompilerGenerated]
		[AccessedThroughProperty("Btn1")]
		private MyButton m_PrinterDecorator;

		// Token: 0x04000874 RID: 2164
		[CompilerGenerated]
		[AccessedThroughProperty("Btn2")]
		private MyButton m_ProductDecorator;

		// Token: 0x04000875 RID: 2165
		[CompilerGenerated]
		[AccessedThroughProperty("Btn3")]
		private MyButton comparatorDecorator;

		// Token: 0x04000876 RID: 2166
		private bool registryDecorator;
	}
}
