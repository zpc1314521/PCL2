using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace PCL
{
	// Token: 0x0200007F RID: 127
	[DesignerGenerated]
	public class MyCfItem : Grid, IComponentConnector
	{
		// Token: 0x06000346 RID: 838 RVA: 0x00023460 File Offset: 0x00021660
		public MyCfItem()
		{
			base.PreviewMouseLeftButtonUp += this.Button_MouseUp;
			base.PreviewMouseLeftButtonDown += this.Button_MouseDown;
			base.MouseLeave += new MouseEventHandler(this.Button_MouseLeave);
			base.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(this.Button_MouseLeave);
			base.MouseEnter += new MouseEventHandler(this.RefreshColor);
			base.MouseLeave += new MouseEventHandler(this.RefreshColor);
			base.MouseLeftButtonDown += new MouseButtonEventHandler(this.RefreshColor);
			base.MouseLeftButtonUp += new MouseButtonEventHandler(this.RefreshColor);
			this.proxyVal = ModBase.GetUuid();
			this.m_SetterVal = "";
			this.eventVal = false;
			this._PrinterVal = null;
			this.m_ComparatorVal = true;
			this.InitializeComponent();
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000347 RID: 839 RVA: 0x00003F65 File Offset: 0x00002165
		// (set) Token: 0x06000348 RID: 840 RVA: 0x00023534 File Offset: 0x00021734
		public string Logo
		{
			get
			{
				return this.m_SetterVal;
			}
			set
			{
				if (Operators.CompareString(this.m_SetterVal, value, true) != 0 && value != null)
				{
					this.m_SetterVal = value;
					string FileAddress = ModBase.m_GlobalRule + "CFLogo\\" + Conversions.ToString(ModBase.GetHash(this.m_SetterVal)) + ".png";
					try
					{
						if (this.m_SetterVal.ToLower().StartsWith("http"))
						{
							if (File.Exists(FileAddress))
							{
								this.PathLogo.Source = new ModBitmap.MyBitmap(FileAddress);
							}
							else
							{
								this.PathLogo.Source = new ModBitmap.MyBitmap("pack://application:,,,/images/Icons/NoIcon.png");
								ModBase.RunInNewThread(delegate
								{
									this.LogoLoader(FileAddress);
								}, "CurseForge Logo Loader " + Conversions.ToString(this.proxyVal) + "#", ThreadPriority.BelowNormal);
							}
						}
						else
						{
							this.PathLogo.Source = new ModBitmap.MyBitmap(this.m_SetterVal);
						}
					}
					catch (IOException ex)
					{
						ModBase.Log(ex, "加载 CurseForge 工程图标时读取失败（" + FileAddress + "）", ModBase.LogLevel.Debug, "出现错误");
					}
					catch (ArgumentException ex2)
					{
						ModBase.Log(ex2, "可视化 CurseForge 工程图标失败（" + FileAddress + "）", ModBase.LogLevel.Debug, "出现错误");
						try
						{
							File.Delete(FileAddress);
							ModBase.Log("[Download] 已清理损坏的 CurseForge 工程图标：" + FileAddress, ModBase.LogLevel.Normal, "出现错误");
						}
						catch (Exception ex3)
						{
							ModBase.Log(ex3, "清理损坏的 CurseForge 工程图标缓存失败（" + FileAddress + "）", ModBase.LogLevel.Hint, "出现错误");
						}
					}
					catch (Exception ex4)
					{
						ModBase.Log(ex4, "加载 CurseForge 工程图标失败（" + value + "）", ModBase.LogLevel.Debug, "出现错误");
					}
				}
			}
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0002375C File Offset: 0x0002195C
		private void LogoLoader(string Address)
		{
			MyCfItem._Closure$__6-0 CS$<>8__locals1 = new MyCfItem._Closure$__6-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Me = this;
			CS$<>8__locals1.$VB$Local_Address = Address;
			bool flag = false;
			CS$<>8__locals1.$VB$Local_DownloadEnd = Conversions.ToString(ModBase.GetUuid());
			for (;;)
			{
				try
				{
					ModNet.NetDownload(this.m_SetterVal, CS$<>8__locals1.$VB$Local_Address + CS$<>8__locals1.$VB$Local_DownloadEnd);
					ModBase.RunInUi(delegate()
					{
						try
						{
							if (Operators.CompareString(CS$<>8__locals1.$VB$Local_Address, ModBase.m_GlobalRule + "CFLogo\\" + Conversions.ToString(ModBase.GetHash(CS$<>8__locals1.$VB$Me.m_SetterVal)) + ".png", true) == 0)
							{
								CS$<>8__locals1.$VB$Me.PathLogo.Source = new ModBitmap.MyBitmap(CS$<>8__locals1.$VB$Local_Address + CS$<>8__locals1.$VB$Local_DownloadEnd);
								FileSystem.MoveFile(CS$<>8__locals1.$VB$Local_Address + CS$<>8__locals1.$VB$Local_DownloadEnd, CS$<>8__locals1.$VB$Local_Address);
							}
						}
						catch (Exception ex2)
						{
							ModBase.Log(ex2, "读取 CurseForge 工程图标失败（" + CS$<>8__locals1.$VB$Local_Address + "）", ModBase.LogLevel.Hint, "出现错误");
						}
					}, false);
					break;
				}
				catch (Exception ex)
				{
					if (flag)
					{
						ModBase.Log(ex, "下载 CurseForge 工程图标失败", ModBase.LogLevel.Debug, "出现错误");
						break;
					}
					flag = true;
				}
			}
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00023800 File Offset: 0x00021A00
		[CompilerGenerated]
		public void ReflectContainer(MyCfItem.ClickEventHandler obj)
		{
			MyCfItem.ClickEventHandler clickEventHandler = this.m_MerchantVal;
			MyCfItem.ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				MyCfItem.ClickEventHandler value = (MyCfItem.ClickEventHandler)Delegate.Combine(clickEventHandler2, obj);
				clickEventHandler = Interlocked.CompareExchange<MyCfItem.ClickEventHandler>(ref this.m_MerchantVal, value, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00023838 File Offset: 0x00021A38
		[CompilerGenerated]
		public void LoginContainer(MyCfItem.ClickEventHandler obj)
		{
			MyCfItem.ClickEventHandler clickEventHandler = this.m_MerchantVal;
			MyCfItem.ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				MyCfItem.ClickEventHandler value = (MyCfItem.ClickEventHandler)Delegate.Remove(clickEventHandler2, obj);
				clickEventHandler = Interlocked.CompareExchange<MyCfItem.ClickEventHandler>(ref this.m_MerchantVal, value, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00023870 File Offset: 0x00021A70
		private void Button_MouseUp(object sender, MouseButtonEventArgs e)
		{
			if (this.eventVal)
			{
				MyCfItem.ClickEventHandler merchantVal = this.m_MerchantVal;
				if (merchantVal != null)
				{
					merchantVal(RuntimeHelpers.GetObjectValue(sender), e);
				}
				if (!e.Handled)
				{
					ModBase.Log("[Control] 按下 CurseForge 工程列表项：" + this.LabTitle.Text, ModBase.LogLevel.Normal, "出现错误");
				}
			}
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00003F6D File Offset: 0x0000216D
		private void Button_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (base.IsMouseOver)
			{
				this.eventVal = true;
			}
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00003F7E File Offset: 0x0000217E
		private void Button_MouseLeave(object sender, object e)
		{
			this.eventVal = false;
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600034F RID: 847 RVA: 0x000238C4 File Offset: 0x00021AC4
		public Border RectBack
		{
			get
			{
				if (this._PrinterVal == null)
				{
					Border border = new Border
					{
						Name = "RectBack",
						CornerRadius = new CornerRadius(3.0),
						RenderTransform = new ScaleTransform(0.8, 0.8),
						RenderTransformOrigin = new Point(0.5, 0.5),
						BorderThickness = new Thickness(ModBase.smethod_4(1.0)),
						SnapsToDevicePixels = true,
						IsHitTestVisible = false,
						Opacity = 0.0
					};
					border.SetResourceReference(Border.BackgroundProperty, "ColorBrush7");
					border.SetResourceReference(Border.BorderBrushProperty, "ColorBrush6");
					Grid.SetColumnSpan(border, 0x3E7);
					Grid.SetRowSpan(border, 0x3E7);
					base.Children.Insert(0, border);
					this._PrinterVal = border;
				}
				return this._PrinterVal;
			}
		}

		// Token: 0x06000350 RID: 848 RVA: 0x000239C4 File Offset: 0x00021BC4
		public void RefreshColor(object sender, EventArgs e)
		{
			if (this.m_ComparatorVal)
			{
				string text;
				int num;
				if (base.IsMouseOver)
				{
					if (this.eventVal)
					{
						text = "MouseDown";
						num = 0x78;
					}
					else
					{
						text = "MouseOver";
						num = 0x78;
					}
				}
				else
				{
					text = "Idle";
					num = 0xB4;
				}
				if (Operators.CompareString(this.m_ProductVal, text, true) != 0)
				{
					this.m_ProductVal = text;
					if (base.IsLoaded && ModAni.InsertFactory() == 0)
					{
						List<ModAni.AniData> list = new List<ModAni.AniData>();
						if (base.IsMouseOver)
						{
							list.AddRange(new ModAni.AniData[]
							{
								ModAni.AaColor(this.RectBack, Border.BackgroundProperty, this.eventVal ? "ColorBrush6" : "ColorBrush9", num, 0, null, false),
								ModAni.AaOpacity(this.RectBack, 1.0 - this.RectBack.Opacity, num, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false)
							});
							if (this.eventVal)
							{
								list.Add(ModAni.AaScaleTransform(this.RectBack, 0.996 - ((ScaleTransform)this.RectBack.RenderTransform).ScaleX, checked((int)Math.Round(unchecked((double)num * 1.2))), 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false));
							}
							else
							{
								list.Add(ModAni.AaScaleTransform(this.RectBack, 1.0 - ((ScaleTransform)this.RectBack.RenderTransform).ScaleX, checked((int)Math.Round(unchecked((double)num * 1.2))), 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false));
							}
						}
						else
						{
							list.AddRange(new ModAni.AniData[]
							{
								ModAni.AaOpacity(this.RectBack, -this.RectBack.Opacity, num, 0, null, false),
								ModAni.AaColor(this.RectBack, Border.BackgroundProperty, this.eventVal ? "ColorBrush6" : "ColorBrush7", num, 0, null, false),
								ModAni.AaScaleTransform(this.RectBack, 0.996 - ((ScaleTransform)this.RectBack.RenderTransform).ScaleX, num, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
								ModAni.AaScaleTransform(this.RectBack, -0.196, 1, 0, null, true)
							});
						}
						ModAni.AniStart(list, "CfItem Color " + Conversions.ToString(this.proxyVal), false);
						return;
					}
					ModAni.AniStop("CfItem Color " + Conversions.ToString(this.proxyVal));
					if (this._PrinterVal != null)
					{
						this.RectBack.Opacity = 0.0;
					}
				}
			}
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00023C68 File Offset: 0x00021E68
		private void LabInfo_MouseEnter(object sender, MouseEventArgs e)
		{
			if (this.IsTextTrimmed(this.LabInfo))
			{
				this.ToolTipInfo.Content = this.LabInfo.Text;
				this.ToolTipInfo.Width = this.LabInfo.ActualWidth + 25.0;
				this.LabInfo.ToolTip = this.ToolTipInfo;
				return;
			}
			this.LabInfo.ToolTip = null;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x00023CD8 File Offset: 0x00021ED8
		private bool IsTextTrimmed(TextBlock textBlock)
		{
			Typeface typeface = new Typeface(textBlock.FontFamily, textBlock.FontStyle, textBlock.FontWeight, textBlock.FontStretch);
			return new FormattedText(textBlock.Text, Thread.CurrentThread.CurrentCulture, textBlock.FlowDirection, typeface, textBlock.FontSize, textBlock.Foreground).Width > textBlock.ActualWidth;
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000353 RID: 851 RVA: 0x00003F87 File Offset: 0x00002187
		// (set) Token: 0x06000354 RID: 852 RVA: 0x00003F8F File Offset: 0x0000218F
		internal virtual MyCfItem PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000355 RID: 853 RVA: 0x00003F98 File Offset: 0x00002198
		// (set) Token: 0x06000356 RID: 854 RVA: 0x00003FA0 File Offset: 0x000021A0
		internal virtual Image PathLogo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000357 RID: 855 RVA: 0x00003FA9 File Offset: 0x000021A9
		// (set) Token: 0x06000358 RID: 856 RVA: 0x00003FB1 File Offset: 0x000021B1
		internal virtual TextBlock LabTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000359 RID: 857 RVA: 0x00003FBA File Offset: 0x000021BA
		// (set) Token: 0x0600035A RID: 858 RVA: 0x00003FC2 File Offset: 0x000021C2
		internal virtual TextBlock LabLeft { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600035B RID: 859 RVA: 0x00003FCB File Offset: 0x000021CB
		// (set) Token: 0x0600035C RID: 860 RVA: 0x00023D38 File Offset: 0x00021F38
		internal virtual TextBlock LabInfo
		{
			[CompilerGenerated]
			get
			{
				return this.advisorVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.LabInfo_MouseEnter);
				TextBlock textBlock = this.advisorVal;
				if (textBlock != null)
				{
					textBlock.MouseEnter -= value2;
				}
				this.advisorVal = value;
				textBlock = this.advisorVal;
				if (textBlock != null)
				{
					textBlock.MouseEnter += value2;
				}
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600035D RID: 861 RVA: 0x00003FD3 File Offset: 0x000021D3
		// (set) Token: 0x0600035E RID: 862 RVA: 0x00003FDB File Offset: 0x000021DB
		internal virtual ToolTip ToolTipInfo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x0600035F RID: 863 RVA: 0x00023D7C File Offset: 0x00021F7C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.wrapperVal)
			{
				this.wrapperVal = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagedownload/mycfitem.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00023DAC File Offset: 0x00021FAC
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (MyCfItem)target;
				return;
			}
			if (connectionId == 2)
			{
				this.PathLogo = (Image)target;
				return;
			}
			if (connectionId == 3)
			{
				this.LabTitle = (TextBlock)target;
				return;
			}
			if (connectionId == 4)
			{
				this.LabLeft = (TextBlock)target;
				return;
			}
			if (connectionId == 5)
			{
				this.LabInfo = (TextBlock)target;
				return;
			}
			if (connectionId == 6)
			{
				this.ToolTipInfo = (ToolTip)target;
				return;
			}
			this.wrapperVal = true;
		}

		// Token: 0x040001C7 RID: 455
		public int proxyVal;

		// Token: 0x040001C8 RID: 456
		private string m_SetterVal;

		// Token: 0x040001C9 RID: 457
		[CompilerGenerated]
		private MyCfItem.ClickEventHandler m_MerchantVal;

		// Token: 0x040001CA RID: 458
		private bool eventVal;

		// Token: 0x040001CB RID: 459
		private Border _PrinterVal;

		// Token: 0x040001CC RID: 460
		private string m_ProductVal;

		// Token: 0x040001CD RID: 461
		public bool m_ComparatorVal;

		// Token: 0x040001CE RID: 462
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private MyCfItem registryVal;

		// Token: 0x040001CF RID: 463
		[AccessedThroughProperty("PathLogo")]
		[CompilerGenerated]
		private Image attributeVal;

		// Token: 0x040001D0 RID: 464
		[CompilerGenerated]
		[AccessedThroughProperty("LabTitle")]
		private TextBlock _ValueVal;

		// Token: 0x040001D1 RID: 465
		[CompilerGenerated]
		[AccessedThroughProperty("LabLeft")]
		private TextBlock _RoleVal;

		// Token: 0x040001D2 RID: 466
		[AccessedThroughProperty("LabInfo")]
		[CompilerGenerated]
		private TextBlock advisorVal;

		// Token: 0x040001D3 RID: 467
		[AccessedThroughProperty("ToolTipInfo")]
		[CompilerGenerated]
		private ToolTip strategyVal;

		// Token: 0x040001D4 RID: 468
		private bool wrapperVal;

		// Token: 0x02000080 RID: 128
		// (Invoke) Token: 0x06000364 RID: 868
		public delegate void ClickEventHandler(object sender, MouseButtonEventArgs e);
	}
}
