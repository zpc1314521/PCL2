using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PCL.My;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PCL
{
	// Token: 0x02000153 RID: 339
	[DesignerGenerated]
	public class PageSetupLaunch : AdornerDecorator, IComponentConnector
	{
		// Token: 0x06000CEE RID: 3310 RVA: 0x00009115 File Offset: 0x00007315
		public PageSetupLaunch()
		{
			base.Loaded += this.PageSetupLaunch_Loaded;
			this.fieldUtils = false;
			this.m_StatusUtils = 2;
			this.requestUtils = 1;
			this.InitializeComponent();
		}

		// Token: 0x06000CEF RID: 3311 RVA: 0x00068E04 File Offset: 0x00067004
		private void PageSetupLaunch_Loaded(object sender, RoutedEventArgs e)
		{
			this.PanBack.ScrollToHome();
			this.RefreshRam(false);
			checked
			{
				if (!this.fieldUtils)
				{
					this.fieldUtils = true;
					ModAni.ListFactory(ModAni.InsertFactory() + 1);
					this.Reload();
					ModAni.ListFactory(ModAni.InsertFactory() - 1);
					DispatcherTimer dispatcherTimer = new DispatcherTimer();
					dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
					dispatcherTimer.Tick += delegate(object sender, EventArgs e)
					{
						this.RefreshRam();
					};
					dispatcherTimer.Start();
				}
			}
		}

		// Token: 0x06000CF0 RID: 3312 RVA: 0x00068E7C File Offset: 0x0006707C
		public void Reload()
		{
			try
			{
				((MyRadioBox)base.FindName(Conversions.ToString(Operators.ConcatenateObject("RadioSkinType", ModBase._BaseRule.Load("LaunchSkinType", false, null))))).Checked = true;
				this.TextSkinID.Text = Conversions.ToString(ModBase._BaseRule.Get("LaunchSkinID", null));
				this.TextArgumentTitle.Text = Conversions.ToString(ModBase._BaseRule.Get("LaunchArgumentTitle", null));
				this.TextArgumentInfo.Text = Conversions.ToString(ModBase._BaseRule.Get("LaunchArgumentInfo", null));
				this.ComboArgumentIndie.SelectedIndex = Conversions.ToInteger(ModBase._BaseRule.Get("LaunchArgumentIndie", null));
				this.ComboArgumentVisibie.SelectedIndex = Conversions.ToInteger(ModBase._BaseRule.Get("LaunchArgumentVisible", null));
				this.ComboArgumentPriority.SelectedIndex = Conversions.ToInteger(ModBase._BaseRule.Get("LaunchArgumentPriority", null));
				this.ComboArgumentWindowType.SelectedIndex = Conversions.ToInteger(ModBase._BaseRule.Get("LaunchArgumentWindowType", null));
				this.TextArgumentWindowWidth.Text = Conversions.ToString(ModBase._BaseRule.Get("LaunchArgumentWindowWidth", null));
				this.TextArgumentWindowHeight.Text = Conversions.ToString(ModBase._BaseRule.Get("LaunchArgumentWindowHeight", null));
				this.RefreshJavaComboBox();
				((MyRadioBox)base.FindName(Conversions.ToString(Operators.ConcatenateObject("RadioRamType", ModBase._BaseRule.Load("LaunchRamType", false, null))))).Checked = true;
				this.SliderRamCustom.Value = Conversions.ToInteger(ModBase._BaseRule.Get("LaunchRamCustom", null));
				this.TextAdvanceJvm.Text = Conversions.ToString(ModBase._BaseRule.Get("LaunchAdvanceJvm", null));
				this.TextAdvanceGame.Text = Conversions.ToString(ModBase._BaseRule.Get("LaunchAdvanceGame", null));
				this.CheckAdvanceAssets.Checked = Conversions.ToBoolean(ModBase._BaseRule.Get("LaunchAdvanceAssets", null));
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "重载启动设置时出错", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x06000CF1 RID: 3313 RVA: 0x000690D0 File Offset: 0x000672D0
		public void Reset()
		{
			try
			{
				ModBase._BaseRule.Reset("LaunchArgumentTitle", false, null);
				ModBase._BaseRule.Reset("LaunchArgumentInfo", false, null);
				ModBase._BaseRule.Reset("LaunchArgumentIndie", false, null);
				ModBase._BaseRule.Reset("LaunchArgumentVisible", false, null);
				ModBase._BaseRule.Reset("LaunchArgumentWindowType", false, null);
				ModBase._BaseRule.Reset("LaunchArgumentWindowWidth", false, null);
				ModBase._BaseRule.Reset("LaunchArgumentWindowHeight", false, null);
				ModBase._BaseRule.Reset("LaunchArgumentPriority", false, null);
				ModBase._BaseRule.Reset("LaunchRamType", false, null);
				ModBase._BaseRule.Reset("LaunchRamCustom", false, null);
				ModBase._BaseRule.Reset("LaunchSkinType", false, null);
				ModBase._BaseRule.Reset("LaunchSkinID", false, null);
				ModBase._BaseRule.Reset("LaunchAdvanceJvm", false, null);
				ModBase._BaseRule.Reset("LaunchAdvanceGame", false, null);
				ModBase._BaseRule.Reset("LaunchAdvanceAssets", false, null);
				ModBase._BaseRule.Reset("LaunchArgumentJavaAll", false, null);
				ModBase._BaseRule.Reset("LaunchArgumentJavaSelect", false, null);
				ModMinecraft._PredicateIterator.Start(ModBase.GetUuid(), false);
				ModBase.Log("[Setup] 已初始化启动设置", ModBase.LogLevel.Normal, "出现错误");
				ModMain.Hint("已初始化启动设置！", ModMain.HintType.Finish, false);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "初始化启动设置失败", ModBase.LogLevel.Msgbox, "出现错误");
			}
			this.Reload();
		}

		// Token: 0x06000CF2 RID: 3314 RVA: 0x00069270 File Offset: 0x00067470
		private static void RadioBoxChange(MyRadioBox sender, object e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set(sender.Tag.ToString().Split(new char[]
				{
					'/'
				})[0], ModBase.Val(sender.Tag.ToString().Split(new char[]
				{
					'/'
				})[1]), false, null);
			}
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x0000914A File Offset: 0x0000734A
		private static void TextBoxChange(MyTextBox sender, object e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set(Conversions.ToString(sender.Tag), sender.Text, false, null);
			}
		}

		// Token: 0x06000CF4 RID: 3316 RVA: 0x00009170 File Offset: 0x00007370
		private static void SliderChange(MySlider sender, object e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set(Conversions.ToString(sender.Tag), sender.Value, false, null);
			}
		}

		// Token: 0x06000CF5 RID: 3317 RVA: 0x0000919B File Offset: 0x0000739B
		private static void ComboChange(MyComboBox sender, object e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set(Conversions.ToString(sender.Tag), sender.SelectedIndex, false, null);
			}
		}

		// Token: 0x06000CF6 RID: 3318 RVA: 0x000091C6 File Offset: 0x000073C6
		private static void CheckBoxChange(MyCheckBox sender, object e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set(Conversions.ToString(sender.Tag), sender.Checked, false, null);
			}
		}

		// Token: 0x06000CF7 RID: 3319 RVA: 0x000692D4 File Offset: 0x000674D4
		private void BtnSkinChange_Click(object sender, EventArgs e)
		{
			ModMinecraft.McSkinInfo mcSkinInfo = ModMinecraft.McSkinSelect(true);
			if (mcSkinInfo._ExpressionMapper)
			{
				try
				{
					File.Delete(ModBase.m_GlobalRule + "CustomSkin.png");
					File.Copy(mcSkinInfo._IteratorMapper, ModBase.m_GlobalRule + "CustomSkin.png");
					ModBase._BaseRule.Set("LaunchSkinSlim", mcSkinInfo.m_ModelMapper, false, null);
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "设置离线皮肤失败", ModBase.LogLevel.Msgbox, "出现错误");
				}
				finally
				{
					PageLaunchLeft.m_InterpreterExpression.Start(null, true);
				}
			}
		}

		// Token: 0x06000CF8 RID: 3320 RVA: 0x00069388 File Offset: 0x00067588
		private void RadioSkinType3_Check(object sender, ModBase.RouteEventArgs e)
		{
			if (ModAni.InsertFactory() == 0 && e.schemaMapper)
			{
				try
				{
					if (!File.Exists(ModBase.m_GlobalRule + "CustomSkin.png"))
					{
						ModMinecraft.McSkinInfo mcSkinInfo = ModMinecraft.McSkinSelect(true);
						if (!mcSkinInfo._ExpressionMapper)
						{
							e._HelperMapper = true;
						}
						else
						{
							File.Delete(ModBase.m_GlobalRule + "CustomSkin.png");
							File.Copy(mcSkinInfo._IteratorMapper, ModBase.m_GlobalRule + "CustomSkin.png");
							ModBase._BaseRule.Set("LaunchSkinSlim", mcSkinInfo.m_ModelMapper, false, null);
						}
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "设置离线皮肤失败", ModBase.LogLevel.Msgbox, "出现错误");
					e._HelperMapper = true;
				}
				finally
				{
					PageLaunchLeft.m_InterpreterExpression.Start(null, true);
				}
			}
		}

		// Token: 0x06000CF9 RID: 3321 RVA: 0x0006947C File Offset: 0x0006767C
		private void BtnSkinDelete_Click(object sender, EventArgs e)
		{
			try
			{
				File.Delete(ModBase.m_GlobalRule + "CustomSkin.png");
				this.RadioSkinType0.SetChecked(true, true, true);
				ModMain.Hint("离线皮肤已清空！", ModMain.HintType.Finish, true);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "清空离线皮肤失败", ModBase.LogLevel.Msgbox, "出现错误");
			}
		}

		// Token: 0x06000CFA RID: 3322 RVA: 0x000091F1 File Offset: 0x000073F1
		private void BtnSkinSave_Click(object sender, EventArgs e)
		{
			MySkin.Save(PageLaunchLeft.m_InterpreterExpression);
		}

		// Token: 0x06000CFB RID: 3323 RVA: 0x000091FD File Offset: 0x000073FD
		private void BtnSkinCache_Click(object sender, EventArgs e)
		{
			MySkin.RefreshCache(null);
		}

		// Token: 0x06000CFC RID: 3324 RVA: 0x00009205 File Offset: 0x00007405
		public void RamType(int Type)
		{
			if (this.SliderRamCustom != null)
			{
				this.SliderRamCustom.IsEnabled = (Type == 1);
			}
		}

		// Token: 0x06000CFD RID: 3325 RVA: 0x000694E8 File Offset: 0x000676E8
		public void RefreshRam(bool ShowAnim)
		{
			if (this.LabRamGame != null && this.LabRamUsed != null && !(ModMain.m_GetterFilter.publisherDecorator != FormMain.PageType.Setup) && ModMain.m_TaskFilter.configurationUtils == FormMain.PageSubType.Default)
			{
				double ram = PageSetupLaunch.GetRam(ModMinecraft.ValidateContainer(), false);
				double num = Math.Round(MyWpfExtension.RunFactory().Info.TotalPhysicalMemory / 1024.0 / 1024.0 / 1024.0 * 10.0) / 10.0;
				double num2 = Math.Round(MyWpfExtension.RunFactory().Info.AvailablePhysicalMemory / 1024.0 / 1024.0 / 1024.0 * 10.0) / 10.0;
				double num3 = Math.Min(ram, num2);
				double num4 = num - num2;
				double num5 = Math.Round(ModBase.MathRange(num - num4 - ram, 0.0, 1000.0) * 10.0) / 10.0;
				checked
				{
					if (num <= 1.5)
					{
						this.SliderRamCustom.MaxValue = (int)Math.Round(Math.Max(Math.Floor(unchecked(num - 0.3) / 0.1), 1.0));
					}
					else if (num <= 8.0)
					{
						this.SliderRamCustom.MaxValue = (int)Math.Round(unchecked(Math.Floor((num - 1.5) / 0.5) + 12.0));
					}
					else if (num <= 16.0)
					{
						this.SliderRamCustom.MaxValue = (int)Math.Round(unchecked(Math.Floor((num - 8.0) / 1.0) + 25.0));
					}
					else if (num <= 32.0)
					{
						this.SliderRamCustom.MaxValue = (int)Math.Round(unchecked(Math.Floor((num - 16.0) / 2.0) + 33.0));
					}
					else
					{
						this.SliderRamCustom.MaxValue = (int)Math.Round(Math.Min(unchecked(Math.Floor((num - 32.0) / 4.0) + 41.0), 49.0));
					}
					this.LabRamGame.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((ram == Math.Floor(ram)) ? (Conversions.ToString(ram) + ".0") : ram, " GB"), (ram != num3) ? Operators.ConcatenateObject(Operators.ConcatenateObject(" (可用 ", (num3 == Math.Floor(num3)) ? (Conversions.ToString(num3) + ".0") : num3), " GB)") : ""));
					this.LabRamUsed.Text = Conversions.ToString(Operators.ConcatenateObject((num4 == Math.Floor(num4)) ? (Conversions.ToString(num4) + ".0") : num4, " GB"));
					this.LabRamTotal.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(" / ", (num == Math.Floor(num)) ? (Conversions.ToString(num) + ".0") : num), " GB"));
					this.LabRamWarn.Visibility = ((ram != 1.0 || ModMinecraft.JavaUse64Bit(null) || ModBase.m_MapperRule) ? Visibility.Collapsed : Visibility.Visible);
				}
				if (ShowAnim)
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaGridLengthWidth(this.ColumnRamUsed, num4 - this.ColumnRamUsed.Width.Value, 0x320, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false),
						ModAni.AaGridLengthWidth(this.ColumnRamGame, num3 - this.ColumnRamGame.Width.Value, 0x320, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false),
						ModAni.AaGridLengthWidth(this.ColumnRamEmpty, num5 - this.ColumnRamEmpty.Width.Value, 0x320, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false)
					}, "SetupLaunch Ram Grid", false);
					return;
				}
				this.ColumnRamUsed.Width = new GridLength(num4, GridUnitType.Star);
				this.ColumnRamGame.Width = new GridLength(num3, GridUnitType.Star);
				this.ColumnRamEmpty.Width = new GridLength(num5, GridUnitType.Star);
			}
		}

		// Token: 0x06000CFE RID: 3326 RVA: 0x0000921E File Offset: 0x0000741E
		private void RefreshRam()
		{
			this.RefreshRam(true);
		}

		// Token: 0x06000CFF RID: 3327 RVA: 0x00069994 File Offset: 0x00067B94
		private void RefreshRamText()
		{
			double actualWidth = this.RectRamUsed.ActualWidth;
			double actualWidth2 = this.PanRamDisplay.ActualWidth;
			double actualWidth3 = this.LabRamGame.ActualWidth;
			double actualWidth4 = this.LabRamUsed.ActualWidth;
			double actualWidth5 = this.LabRamTotal.ActualWidth;
			double actualWidth6 = this.LabRamGameTitle.ActualWidth;
			double actualWidth7 = this.LabRamUsedTitle.ActualWidth;
			int num;
			if (actualWidth - 30.0 >= actualWidth4 && actualWidth - 30.0 >= actualWidth7)
			{
				if (actualWidth - 25.0 < actualWidth4 + actualWidth5)
				{
					num = 1;
				}
				else
				{
					num = 2;
				}
			}
			else
			{
				num = 0;
			}
			if (this.m_StatusUtils != num)
			{
				this.m_StatusUtils = num;
				switch (num)
				{
				case 0:
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaOpacity(this.LabRamUsed, -this.LabRamUsed.Opacity, 0x64, 0, null, false),
						ModAni.AaOpacity(this.LabRamTotal, -this.LabRamTotal.Opacity, 0x64, 0, null, false),
						ModAni.AaOpacity(this.LabRamUsedTitle, -this.LabRamUsedTitle.Opacity, 0x64, 0, null, false)
					}, "SetupLaunch Ram TextLeft", false);
					break;
				case 1:
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaOpacity(this.LabRamUsed, 1.0 - this.LabRamUsed.Opacity, 0x64, 0, null, false),
						ModAni.AaOpacity(this.LabRamTotal, -this.LabRamTotal.Opacity, 0x64, 0, null, false),
						ModAni.AaOpacity(this.LabRamUsedTitle, 0.7 - this.LabRamUsedTitle.Opacity, 0x64, 0, null, false)
					}, "SetupLaunch Ram TextLeft", false);
					break;
				case 2:
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaOpacity(this.LabRamUsed, 1.0 - this.LabRamUsed.Opacity, 0x64, 0, null, false),
						ModAni.AaOpacity(this.LabRamTotal, 1.0 - this.LabRamTotal.Opacity, 0x64, 0, null, false),
						ModAni.AaOpacity(this.LabRamUsedTitle, 0.7 - this.LabRamUsedTitle.Opacity, 0x64, 0, null, false)
					}, "SetupLaunch Ram TextLeft", false);
					break;
				}
			}
			int num2;
			if (actualWidth2 >= actualWidth3 + 2.0 + actualWidth && actualWidth2 >= actualWidth6 + 2.0 + actualWidth)
			{
				num2 = 1;
			}
			else
			{
				num2 = 0;
			}
			if (num2 == 0)
			{
				if (ModAni.InsertFactory() == 0 && (this.requestUtils != num2 || ModAni.AniIsRun("SetupLaunch Ram TextRight")))
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaX(this.LabRamGame, actualWidth2 - actualWidth3 - this.LabRamGame.Margin.Left, 0x64, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false),
						ModAni.AaX(this.LabRamGameTitle, actualWidth2 - actualWidth6 - this.LabRamGameTitle.Margin.Left, 0x64, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false)
					}, "SetupLaunch Ram TextRight", false);
				}
				else
				{
					this.LabRamGame.Margin = new Thickness(actualWidth2 - actualWidth3, 3.0, 0.0, 0.0);
					this.LabRamGameTitle.Margin = new Thickness(actualWidth2 - actualWidth6, 0.0, 0.0, 5.0);
				}
			}
			else if (ModAni.InsertFactory() == 0 && (this.requestUtils != num2 || ModAni.AniIsRun("SetupLaunch Ram TextRight")))
			{
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaX(this.LabRamGame, 2.0 + actualWidth - this.LabRamGame.Margin.Left, 0x64, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false),
					ModAni.AaX(this.LabRamGameTitle, 2.0 + actualWidth - this.LabRamGameTitle.Margin.Left, 0x64, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false)
				}, "SetupLaunch Ram TextRight", false);
			}
			else
			{
				this.LabRamGame.Margin = new Thickness(2.0 + actualWidth, 3.0, 0.0, 0.0);
				this.LabRamGameTitle.Margin = new Thickness(2.0 + actualWidth, 0.0, 0.0, 5.0);
			}
			this.requestUtils = num2;
		}

		// Token: 0x06000D00 RID: 3328 RVA: 0x00069E58 File Offset: 0x00068058
		public static double GetRam(ModMinecraft.McVersion Version, bool UseVersionJavaSetup)
		{
			double num7;
			if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LaunchRamType", null), 0, true))
			{
				double num = Math.Round(MyWpfExtension.RunFactory().Info.AvailablePhysicalMemory / 1024.0 / 1024.0 / 1024.0 * 10.0) / 10.0;
				if (Version != null && !Version._ReponseAlgo)
				{
					Version.Load();
				}
				double val;
				double num3;
				double num4;
				double num5;
				if (Version != null && Version.Version.LoginUtils())
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(Version.ManageExpression() + "mods\\");
					int num2 = directoryInfo.Exists ? directoryInfo.GetFiles().Length : 0;
					val = 0.4 + (double)num2 / 150.0;
					num3 = 1.5 + (double)num2 / 100.0;
					num4 = 3.0 + (double)num2 / 60.0;
					num5 = 6.0 + (double)num2 / 30.0;
				}
				else if (Version != null && Version.Version.m_ComposerAlgo)
				{
					val = 0.3;
					num3 = 1.5;
					num4 = 3.0;
					num5 = 6.0;
				}
				else
				{
					val = 0.3;
					num3 = 1.5;
					num4 = 2.5;
					num5 = 4.0;
				}
				double num6 = num3;
				num = Math.Max(0.0, num - 0.1);
				num7 += Math.Min(num * 1.0, num6);
				num -= num6 / 1.0 + 0.1;
				if (num >= 0.1)
				{
					num6 = num4 - num3;
					num = Math.Max(0.0, num - 0.1);
					num7 += Math.Min(num * 0.8, num6);
					num -= num6 / 0.8 + 0.1;
					if (num >= 0.1)
					{
						num6 = num5 - num4;
						num = Math.Max(0.0, num - 0.2);
						num7 += Math.Min(num * 0.6, num6);
						num -= num6 / 0.6 + 0.2;
						if (num >= 0.1)
						{
							num6 = num5;
							num = Math.Max(0.0, num - 0.3);
							num7 += Math.Min(num * 0.4, num6);
							num -= num6 / 0.4 + 0.3;
						}
					}
				}
				num7 = Math.Round(Math.Max(num7, val), 1);
			}
			else
			{
				int num8 = Conversions.ToInteger(ModBase._BaseRule.Get("LaunchRamCustom", null));
				if (num8 <= 0xC)
				{
					num7 = (double)num8 * 0.1 + 0.3;
				}
				else if (num8 <= 0x19)
				{
					num7 = (double)(checked(num8 - 0xC)) * 0.5 + 1.5;
				}
				else if (num8 <= 0x21)
				{
					num7 = (double)(checked((num8 - 0x19) * 1 + 8));
				}
				else if (num8 <= 0x29)
				{
					num7 = (double)(checked((num8 - 0x21) * 2 + 0x10));
				}
				else
				{
					num7 = (double)(checked((num8 - 0x29) * 4 + 0x20));
				}
			}
			if (!ModMinecraft.JavaUse64Bit(UseVersionJavaSetup ? Version : null))
			{
				num7 = Math.Min(1.0, num7);
			}
			return num7;
		}

		// Token: 0x06000D01 RID: 3329 RVA: 0x0006A20C File Offset: 0x0006840C
		public void RefreshJavaComboBox()
		{
			if (this.ComboArgumentJava != null)
			{
				this.ComboArgumentJava.Items.Clear();
				this.ComboArgumentJava.Items.Add(new MyComboBoxItem
				{
					Content = "自动选择适合所选游戏版本的 Java",
					Tag = "自动选择"
				});
				MyComboBoxItem myComboBoxItem = null;
				string text = Conversions.ToString(ModBase._BaseRule.Get("LaunchArgumentJavaSelect", null));
				try
				{
					try
					{
						foreach (ModMinecraft.JavaEntry javaEntry in ModMinecraft._ConfigurationIterator)
						{
							MyComboBoxItem myComboBoxItem2 = new MyComboBoxItem
							{
								Content = javaEntry.ToString(),
								ToolTip = javaEntry.m_AnnotationAlgo,
								Tag = javaEntry
							};
							ToolTipService.SetPlacement(myComboBoxItem2, PlacementMode.Right);
							ToolTipService.SetHorizontalOffset(myComboBoxItem2, 5.0);
							this.ComboArgumentJava.Items.Add(myComboBoxItem2);
							if (Operators.CompareString(text, "", true) != 0 && Operators.CompareString(ModMinecraft.JavaEntry.FromJson((JObject)ModBase.GetJson(text)).m_AnnotationAlgo, javaEntry.m_AnnotationAlgo, true) == 0)
							{
								myComboBoxItem = myComboBoxItem2;
							}
						}
					}
					finally
					{
						List<ModMinecraft.JavaEntry>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
				}
				catch (Exception ex)
				{
					ModBase._BaseRule.Set("LaunchArgumentJavaSelect", "", false, null);
					ModBase.Log(ex, "更新设置 Java 下拉框失败", ModBase.LogLevel.Feedback, "出现错误");
				}
				if (myComboBoxItem == null && ModMinecraft._ConfigurationIterator.Count > 0)
				{
					myComboBoxItem = (MyComboBoxItem)this.ComboArgumentJava.Items[0];
				}
				this.ComboArgumentJava.SelectedItem = myComboBoxItem;
				if (myComboBoxItem == null)
				{
					this.ComboArgumentJava.Items.Clear();
					this.ComboArgumentJava.Items.Add(new ComboBoxItem
					{
						Content = "未找到可用的 Java",
						IsSelected = true
					});
				}
				this.RefreshRam(true);
			}
		}

		// Token: 0x06000D02 RID: 3330 RVA: 0x0006A3FC File Offset: 0x000685FC
		private void ComboArgumentJava_DropDownOpened(object sender, EventArgs e)
		{
			if (this.ComboArgumentJava.SelectedItem == null || Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(this.ComboArgumentJava.Items[0], null, "Content", new object[0], null, null, null), "未找到可用的 Java", true) || Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(this.ComboArgumentJava.Items[0], null, "Content", new object[0], null, null, null), "加载中……", true))
			{
				this.ComboArgumentJava.IsDropDownOpen = false;
			}
		}

		// Token: 0x06000D03 RID: 3331 RVA: 0x0006A488 File Offset: 0x00068688
		private void JavaSelectionUpdate()
		{
			if (ModAni.InsertFactory() == 0 && this.ComboArgumentJava.SelectedItem != null && NewLateBinding.LateGet(this.ComboArgumentJava.SelectedItem, null, "Tag", new object[0], null, null, null) != null)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(this.ComboArgumentJava.SelectedItem, null, "Tag", new object[0], null, null, null));
				if ("自动选择".Equals(RuntimeHelpers.GetObjectValue(objectValue)))
				{
					ModBase._BaseRule.Set("LaunchArgumentJavaSelect", "", false, null);
					ModBase.Log("[Java] 修改 Java 选择设置：自动选择", ModBase.LogLevel.Normal, "出现错误");
				}
				else
				{
					ModBase._BaseRule.Set("LaunchArgumentJavaSelect", ((JObject)NewLateBinding.LateGet(objectValue, null, "ToJson", new object[0], null, null, null)).ToString(Formatting.None, new JsonConverter[0]), false, null);
					ModBase.Log("[Java] 修改 Java 选择设置：" + objectValue.ToString(), ModBase.LogLevel.Normal, "出现错误");
				}
				this.RefreshRam(true);
			}
		}

		// Token: 0x06000D04 RID: 3332 RVA: 0x0006A58C File Offset: 0x0006878C
		private void BtnArgumentJavaSelect_Click(object sender, EventArgs e)
		{
			if (ModMinecraft._PredicateIterator.State == ModBase.LoadState.Loading)
			{
				ModMain.Hint("正在搜索 Java，请稍候！", ModMain.HintType.Critical, true);
				return;
			}
			string text = ModBase.SelectFile("javaw.exe|javaw.exe", "选择 javaw.exe 文件");
			if (Operators.CompareString(text, "", true) != 0)
			{
				if (!text.ToLower().EndsWith("javaw.exe"))
				{
					ModMain.Hint("请选择 bin 文件夹中的 javaw.exe 文件！", ModMain.HintType.Critical, true);
					return;
				}
				text = ModBase.GetPathFromFullPath(text);
				try
				{
					ModMinecraft.JavaEntry javaEntry = new ModMinecraft.JavaEntry(text, true);
					javaEntry.Check();
					JArray jarray = new JArray
					{
						javaEntry.ToJson()
					};
					try
					{
						foreach (object obj in ((IEnumerable)ModBase.GetJson(Conversions.ToString(ModBase._BaseRule.Get("LaunchArgumentJavaAll", null)))))
						{
							object objectValue = RuntimeHelpers.GetObjectValue(obj);
							if (Operators.CompareString(ModMinecraft.JavaEntry.FromJson((JObject)objectValue).m_AnnotationAlgo, javaEntry.m_AnnotationAlgo, true) != 0)
							{
								jarray.Add(RuntimeHelpers.GetObjectValue(objectValue));
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
					ModBase._BaseRule.Set("LaunchArgumentJavaAll", jarray.ToString(Formatting.None, new JsonConverter[0]), false, null);
					ModBase._BaseRule.Set("LaunchArgumentJavaSelect", javaEntry.ToJson().ToString(Formatting.None, new JsonConverter[0]), false, null);
					ModMinecraft._PredicateIterator.Start(ModBase.GetUuid(), false);
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "该 Java 存在异常，无法使用", ModBase.LogLevel.Msgbox, "异常的 Java");
				}
			}
		}

		// Token: 0x06000D05 RID: 3333 RVA: 0x0006A728 File Offset: 0x00068928
		private void BtnArgumentJavaSearch_Click(object sender, EventArgs e)
		{
			if (ModMinecraft._PredicateIterator.State == ModBase.LoadState.Loading)
			{
				ModMain.Hint("正在搜索 Java，请稍候！", ModMain.HintType.Critical, true);
				return;
			}
			ModBase.RunInThread((PageSetupLaunch._Closure$__.$I26-0 == null) ? (PageSetupLaunch._Closure$__.$I26-0 = delegate()
			{
				ModMain.Hint("正在搜索 Java！", ModMain.HintType.Info, true);
				ModMinecraft._PredicateIterator.WaitForExit(ModBase.GetUuid(), null, false);
				if (ModMinecraft._ConfigurationIterator.Count == 0)
				{
					ModMain.Hint("未找到可用的 Java！", ModMain.HintType.Critical, true);
					return;
				}
				ModMain.Hint("已找到 " + Conversions.ToString(ModMinecraft._ConfigurationIterator.Count) + " 个 Java，请检查下拉框查看列表！", ModMain.HintType.Finish, true);
			}) : PageSetupLaunch._Closure$__.$I26-0);
		}

		// Token: 0x06000D06 RID: 3334 RVA: 0x0006A778 File Offset: 0x00068978
		private void WindowTypeUIRefresh()
		{
			if (this.ComboArgumentWindowType != null)
			{
				if (this.ComboArgumentWindowType.SelectedIndex == 3 && this.LabArgumentWindowMiddle != null && this.LabArgumentWindowMiddle.Visibility == Visibility.Collapsed)
				{
					this.LabArgumentWindowMiddle.Visibility = Visibility.Visible;
					this.TextArgumentWindowHeight.Visibility = Visibility.Visible;
					this.TextArgumentWindowWidth.Visibility = Visibility.Visible;
					return;
				}
				if (this.ComboArgumentWindowType.SelectedIndex != 3 && this.LabArgumentWindowMiddle != null && this.LabArgumentWindowMiddle.Visibility == Visibility.Visible)
				{
					this.LabArgumentWindowMiddle.Visibility = Visibility.Collapsed;
					this.TextArgumentWindowHeight.Visibility = Visibility.Collapsed;
					this.TextArgumentWindowWidth.Visibility = Visibility.Collapsed;
				}
			}
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x0006A820 File Offset: 0x00068A20
		private void ComboArgumentVisibie_SizeChanged(object sender, SelectionChangedEventArgs e)
		{
			if (ModAni.InsertFactory() == 0 && this.ComboArgumentVisibie.SelectedIndex == 0 && ModMain.MyMsgBox("若在游戏启动后立即关闭启动器，崩溃检测、更改游戏标题等功能将失效。\r\n如果想保留这些功能，可以选择让启动器在游戏启动后隐藏，游戏退出后自动关闭。", "提示", "继续", "取消", "", false, true, false) == 2)
			{
				this.ComboArgumentVisibie.SelectedItem = RuntimeHelpers.GetObjectValue(e.RemovedItems[0]);
			}
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000D08 RID: 3336 RVA: 0x00009227 File Offset: 0x00007427
		// (set) Token: 0x06000D09 RID: 3337 RVA: 0x0000922F File Offset: 0x0000742F
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000D0A RID: 3338 RVA: 0x00009238 File Offset: 0x00007438
		// (set) Token: 0x06000D0B RID: 3339 RVA: 0x00009240 File Offset: 0x00007440
		internal virtual StackPanel PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000D0C RID: 3340 RVA: 0x00009249 File Offset: 0x00007449
		// (set) Token: 0x06000D0D RID: 3341 RVA: 0x00009251 File Offset: 0x00007451
		internal virtual MyCard CardSkin { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000D0E RID: 3342 RVA: 0x0000925A File Offset: 0x0000745A
		// (set) Token: 0x06000D0F RID: 3343 RVA: 0x0006A884 File Offset: 0x00068A84
		internal virtual MyRadioBox RadioSkinType0
		{
			[CompilerGenerated]
			get
			{
				return this.setterUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = (PageSetupLaunch._Closure$__.$IR43-2 == null) ? (PageSetupLaunch._Closure$__.$IR43-2 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					PageSetupLaunch.RadioBoxChange((MyRadioBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR43-2;
				MyRadioBox myRadioBox = this.setterUtils;
				if (myRadioBox != null)
				{
					myRadioBox.Check -= value2;
				}
				this.setterUtils = value;
				myRadioBox = this.setterUtils;
				if (myRadioBox != null)
				{
					myRadioBox.Check += value2;
				}
			}
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000D10 RID: 3344 RVA: 0x00009262 File Offset: 0x00007462
		// (set) Token: 0x06000D11 RID: 3345 RVA: 0x0006A8E0 File Offset: 0x00068AE0
		internal virtual MyRadioBox RadioSkinType1
		{
			[CompilerGenerated]
			get
			{
				return this._MerchantUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = (PageSetupLaunch._Closure$__.$IR47-3 == null) ? (PageSetupLaunch._Closure$__.$IR47-3 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					PageSetupLaunch.RadioBoxChange((MyRadioBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR47-3;
				MyRadioBox merchantUtils = this._MerchantUtils;
				if (merchantUtils != null)
				{
					merchantUtils.Check -= value2;
				}
				this._MerchantUtils = value;
				merchantUtils = this._MerchantUtils;
				if (merchantUtils != null)
				{
					merchantUtils.Check += value2;
				}
			}
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000D12 RID: 3346 RVA: 0x0000926A File Offset: 0x0000746A
		// (set) Token: 0x06000D13 RID: 3347 RVA: 0x0006A93C File Offset: 0x00068B3C
		internal virtual MyRadioBox RadioSkinType2
		{
			[CompilerGenerated]
			get
			{
				return this.m_EventUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = (PageSetupLaunch._Closure$__.$IR51-4 == null) ? (PageSetupLaunch._Closure$__.$IR51-4 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					PageSetupLaunch.RadioBoxChange((MyRadioBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR51-4;
				MyRadioBox eventUtils = this.m_EventUtils;
				if (eventUtils != null)
				{
					eventUtils.Check -= value2;
				}
				this.m_EventUtils = value;
				eventUtils = this.m_EventUtils;
				if (eventUtils != null)
				{
					eventUtils.Check += value2;
				}
			}
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000D14 RID: 3348 RVA: 0x00009272 File Offset: 0x00007472
		// (set) Token: 0x06000D15 RID: 3349 RVA: 0x0006A998 File Offset: 0x00068B98
		internal virtual MyRadioBox RadioSkinType3
		{
			[CompilerGenerated]
			get
			{
				return this.printerUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = (PageSetupLaunch._Closure$__.$IR55-5 == null) ? (PageSetupLaunch._Closure$__.$IR55-5 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					PageSetupLaunch.RadioBoxChange((MyRadioBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR55-5;
				MyRadioBox myRadioBox = this.printerUtils;
				if (myRadioBox != null)
				{
					myRadioBox.Check -= value2;
				}
				this.printerUtils = value;
				myRadioBox = this.printerUtils;
				if (myRadioBox != null)
				{
					myRadioBox.Check += value2;
				}
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000D16 RID: 3350 RVA: 0x0000927A File Offset: 0x0000747A
		// (set) Token: 0x06000D17 RID: 3351 RVA: 0x0006A9F4 File Offset: 0x00068BF4
		internal virtual MyRadioBox RadioSkinType4
		{
			[CompilerGenerated]
			get
			{
				return this._ProductUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = (PageSetupLaunch._Closure$__.$IR59-6 == null) ? (PageSetupLaunch._Closure$__.$IR59-6 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					PageSetupLaunch.RadioBoxChange((MyRadioBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR59-6;
				MyRadioBox.PreviewCheckEventHandler obj = new MyRadioBox.PreviewCheckEventHandler(this.RadioSkinType3_Check);
				MyRadioBox productUtils = this._ProductUtils;
				if (productUtils != null)
				{
					productUtils.Check -= value2;
					productUtils.CalculateIterator(obj);
				}
				this._ProductUtils = value;
				productUtils = this._ProductUtils;
				if (productUtils != null)
				{
					productUtils.Check += value2;
					productUtils.ChangeIterator(obj);
				}
			}
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000D18 RID: 3352 RVA: 0x00009282 File Offset: 0x00007482
		// (set) Token: 0x06000D19 RID: 3353 RVA: 0x0000928A File Offset: 0x0000748A
		internal virtual Grid PanSkinID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000D1A RID: 3354 RVA: 0x00009293 File Offset: 0x00007493
		// (set) Token: 0x06000D1B RID: 3355 RVA: 0x0006AA6C File Offset: 0x00068C6C
		internal virtual MyTextBox TextSkinID
		{
			[CompilerGenerated]
			get
			{
				return this.m_RegistryUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = (PageSetupLaunch._Closure$__.$IR67-7 == null) ? (PageSetupLaunch._Closure$__.$IR67-7 = delegate(object sender, RoutedEventArgs e)
				{
					PageSetupLaunch.TextBoxChange((MyTextBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR67-7;
				MyTextBox registryUtils = this.m_RegistryUtils;
				if (registryUtils != null)
				{
					registryUtils.ResolveVal(value2);
				}
				this.m_RegistryUtils = value;
				registryUtils = this.m_RegistryUtils;
				if (registryUtils != null)
				{
					registryUtils.CancelVal(value2);
				}
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000D1C RID: 3356 RVA: 0x0000929B File Offset: 0x0000749B
		// (set) Token: 0x06000D1D RID: 3357 RVA: 0x0006AAC8 File Offset: 0x00068CC8
		internal virtual MyButton BtnSkinSave
		{
			[CompilerGenerated]
			get
			{
				return this.m_AttributeUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnSkinSave_Click);
				MyButton attributeUtils = this.m_AttributeUtils;
				if (attributeUtils != null)
				{
					attributeUtils.CancelModel(obj);
				}
				this.m_AttributeUtils = value;
				attributeUtils = this.m_AttributeUtils;
				if (attributeUtils != null)
				{
					attributeUtils.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06000D1E RID: 3358 RVA: 0x000092A3 File Offset: 0x000074A3
		// (set) Token: 0x06000D1F RID: 3359 RVA: 0x0006AB0C File Offset: 0x00068D0C
		internal virtual MyButton BtnSkinCache
		{
			[CompilerGenerated]
			get
			{
				return this._ValueUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnSkinCache_Click);
				MyButton valueUtils = this._ValueUtils;
				if (valueUtils != null)
				{
					valueUtils.CancelModel(obj);
				}
				this._ValueUtils = value;
				valueUtils = this._ValueUtils;
				if (valueUtils != null)
				{
					valueUtils.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000D20 RID: 3360 RVA: 0x000092AB File Offset: 0x000074AB
		// (set) Token: 0x06000D21 RID: 3361 RVA: 0x000092B3 File Offset: 0x000074B3
		internal virtual Grid PanSkinChange { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000D22 RID: 3362 RVA: 0x000092BC File Offset: 0x000074BC
		// (set) Token: 0x06000D23 RID: 3363 RVA: 0x0006AB50 File Offset: 0x00068D50
		internal virtual MyButton BtnSkinChange
		{
			[CompilerGenerated]
			get
			{
				return this.advisorUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnSkinChange_Click);
				MyButton myButton = this.advisorUtils;
				if (myButton != null)
				{
					myButton.CancelModel(obj);
				}
				this.advisorUtils = value;
				myButton = this.advisorUtils;
				if (myButton != null)
				{
					myButton.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000D24 RID: 3364 RVA: 0x000092C4 File Offset: 0x000074C4
		// (set) Token: 0x06000D25 RID: 3365 RVA: 0x0006AB94 File Offset: 0x00068D94
		internal virtual MyButton BtnSkinDelete
		{
			[CompilerGenerated]
			get
			{
				return this._StrategyUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnSkinDelete_Click);
				MyButton strategyUtils = this._StrategyUtils;
				if (strategyUtils != null)
				{
					strategyUtils.CancelModel(obj);
				}
				this._StrategyUtils = value;
				strategyUtils = this._StrategyUtils;
				if (strategyUtils != null)
				{
					strategyUtils.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000D26 RID: 3366 RVA: 0x000092CC File Offset: 0x000074CC
		// (set) Token: 0x06000D27 RID: 3367 RVA: 0x000092D4 File Offset: 0x000074D4
		internal virtual MyCard CardArgument { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000D28 RID: 3368 RVA: 0x000092DD File Offset: 0x000074DD
		// (set) Token: 0x06000D29 RID: 3369 RVA: 0x0006ABD8 File Offset: 0x00068DD8
		internal virtual MyTextBox TextArgumentTitle
		{
			[CompilerGenerated]
			get
			{
				return this.m_WriterUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = (PageSetupLaunch._Closure$__.$IR95-8 == null) ? (PageSetupLaunch._Closure$__.$IR95-8 = delegate(object sender, RoutedEventArgs e)
				{
					PageSetupLaunch.TextBoxChange((MyTextBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR95-8;
				MyTextBox writerUtils = this.m_WriterUtils;
				if (writerUtils != null)
				{
					writerUtils.ResolveVal(value2);
				}
				this.m_WriterUtils = value;
				writerUtils = this.m_WriterUtils;
				if (writerUtils != null)
				{
					writerUtils.CancelVal(value2);
				}
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000D2A RID: 3370 RVA: 0x000092E5 File Offset: 0x000074E5
		// (set) Token: 0x06000D2B RID: 3371 RVA: 0x0006AC34 File Offset: 0x00068E34
		internal virtual MyTextBox TextArgumentInfo
		{
			[CompilerGenerated]
			get
			{
				return this.exporterUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = (PageSetupLaunch._Closure$__.$IR99-9 == null) ? (PageSetupLaunch._Closure$__.$IR99-9 = delegate(object sender, RoutedEventArgs e)
				{
					PageSetupLaunch.TextBoxChange((MyTextBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR99-9;
				MyTextBox myTextBox = this.exporterUtils;
				if (myTextBox != null)
				{
					myTextBox.ResolveVal(value2);
				}
				this.exporterUtils = value;
				myTextBox = this.exporterUtils;
				if (myTextBox != null)
				{
					myTextBox.CancelVal(value2);
				}
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000D2C RID: 3372 RVA: 0x000092ED File Offset: 0x000074ED
		// (set) Token: 0x06000D2D RID: 3373 RVA: 0x0006AC90 File Offset: 0x00068E90
		internal virtual MyComboBox ComboArgumentIndie
		{
			[CompilerGenerated]
			get
			{
				return this._RecordUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SelectionChangedEventHandler value2 = (PageSetupLaunch._Closure$__.$IR103-10 == null) ? (PageSetupLaunch._Closure$__.$IR103-10 = delegate(object sender, SelectionChangedEventArgs e)
				{
					PageSetupLaunch.ComboChange((MyComboBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR103-10;
				MyComboBox recordUtils = this._RecordUtils;
				if (recordUtils != null)
				{
					recordUtils.SelectionChanged -= value2;
				}
				this._RecordUtils = value;
				recordUtils = this._RecordUtils;
				if (recordUtils != null)
				{
					recordUtils.SelectionChanged += value2;
				}
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000D2E RID: 3374 RVA: 0x000092F5 File Offset: 0x000074F5
		// (set) Token: 0x06000D2F RID: 3375 RVA: 0x0006ACEC File Offset: 0x00068EEC
		internal virtual MyComboBox ComboArgumentVisibie
		{
			[CompilerGenerated]
			get
			{
				return this.m_GetterUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SelectionChangedEventHandler value2 = (PageSetupLaunch._Closure$__.$IR107-11 == null) ? (PageSetupLaunch._Closure$__.$IR107-11 = delegate(object sender, SelectionChangedEventArgs e)
				{
					PageSetupLaunch.ComboChange((MyComboBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR107-11;
				SelectionChangedEventHandler value3 = new SelectionChangedEventHandler(this.ComboArgumentVisibie_SizeChanged);
				MyComboBox getterUtils = this.m_GetterUtils;
				if (getterUtils != null)
				{
					getterUtils.SelectionChanged -= value2;
					getterUtils.SelectionChanged -= value3;
				}
				this.m_GetterUtils = value;
				getterUtils = this.m_GetterUtils;
				if (getterUtils != null)
				{
					getterUtils.SelectionChanged += value2;
					getterUtils.SelectionChanged += value3;
				}
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000D30 RID: 3376 RVA: 0x000092FD File Offset: 0x000074FD
		// (set) Token: 0x06000D31 RID: 3377 RVA: 0x0006AD64 File Offset: 0x00068F64
		internal virtual MyComboBox ComboArgumentPriority
		{
			[CompilerGenerated]
			get
			{
				return this._InterceptorUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SelectionChangedEventHandler value2 = (PageSetupLaunch._Closure$__.$IR111-12 == null) ? (PageSetupLaunch._Closure$__.$IR111-12 = delegate(object sender, SelectionChangedEventArgs e)
				{
					PageSetupLaunch.ComboChange((MyComboBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR111-12;
				MyComboBox interceptorUtils = this._InterceptorUtils;
				if (interceptorUtils != null)
				{
					interceptorUtils.SelectionChanged -= value2;
				}
				this._InterceptorUtils = value;
				interceptorUtils = this._InterceptorUtils;
				if (interceptorUtils != null)
				{
					interceptorUtils.SelectionChanged += value2;
				}
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000D32 RID: 3378 RVA: 0x00009305 File Offset: 0x00007505
		// (set) Token: 0x06000D33 RID: 3379 RVA: 0x0000930D File Offset: 0x0000750D
		internal virtual Grid PanArgumentWindow { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000D34 RID: 3380 RVA: 0x00009316 File Offset: 0x00007516
		// (set) Token: 0x06000D35 RID: 3381 RVA: 0x0006ADC0 File Offset: 0x00068FC0
		internal virtual MyComboBox ComboArgumentWindowType
		{
			[CompilerGenerated]
			get
			{
				return this.candidateUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SelectionChangedEventHandler value2 = (PageSetupLaunch._Closure$__.$IR119-13 == null) ? (PageSetupLaunch._Closure$__.$IR119-13 = delegate(object sender, SelectionChangedEventArgs e)
				{
					PageSetupLaunch.ComboChange((MyComboBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR119-13;
				SelectionChangedEventHandler value3 = delegate(object sender, SelectionChangedEventArgs e)
				{
					this.WindowTypeUIRefresh();
				};
				MyComboBox myComboBox = this.candidateUtils;
				if (myComboBox != null)
				{
					myComboBox.SelectionChanged -= value2;
					myComboBox.SelectionChanged -= value3;
				}
				this.candidateUtils = value;
				myComboBox = this.candidateUtils;
				if (myComboBox != null)
				{
					myComboBox.SelectionChanged += value2;
					myComboBox.SelectionChanged += value3;
				}
			}
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000D36 RID: 3382 RVA: 0x0000931E File Offset: 0x0000751E
		// (set) Token: 0x06000D37 RID: 3383 RVA: 0x0006AE38 File Offset: 0x00069038
		internal virtual MyTextBox TextArgumentWindowWidth
		{
			[CompilerGenerated]
			get
			{
				return this._DescriptorUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = (PageSetupLaunch._Closure$__.$IR123-15 == null) ? (PageSetupLaunch._Closure$__.$IR123-15 = delegate(object sender, RoutedEventArgs e)
				{
					PageSetupLaunch.TextBoxChange((MyTextBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR123-15;
				MyTextBox descriptorUtils = this._DescriptorUtils;
				if (descriptorUtils != null)
				{
					descriptorUtils.ResolveVal(value2);
				}
				this._DescriptorUtils = value;
				descriptorUtils = this._DescriptorUtils;
				if (descriptorUtils != null)
				{
					descriptorUtils.CancelVal(value2);
				}
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000D38 RID: 3384 RVA: 0x00009326 File Offset: 0x00007526
		// (set) Token: 0x06000D39 RID: 3385 RVA: 0x0000932E File Offset: 0x0000752E
		internal virtual TextBlock LabArgumentWindowMiddle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000D3A RID: 3386 RVA: 0x00009337 File Offset: 0x00007537
		// (set) Token: 0x06000D3B RID: 3387 RVA: 0x0006AE94 File Offset: 0x00069094
		internal virtual MyTextBox TextArgumentWindowHeight
		{
			[CompilerGenerated]
			get
			{
				return this.observerUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = (PageSetupLaunch._Closure$__.$IR131-16 == null) ? (PageSetupLaunch._Closure$__.$IR131-16 = delegate(object sender, RoutedEventArgs e)
				{
					PageSetupLaunch.TextBoxChange((MyTextBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR131-16;
				MyTextBox myTextBox = this.observerUtils;
				if (myTextBox != null)
				{
					myTextBox.ResolveVal(value2);
				}
				this.observerUtils = value;
				myTextBox = this.observerUtils;
				if (myTextBox != null)
				{
					myTextBox.CancelVal(value2);
				}
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000D3C RID: 3388 RVA: 0x0000933F File Offset: 0x0000753F
		// (set) Token: 0x06000D3D RID: 3389 RVA: 0x0006AEF0 File Offset: 0x000690F0
		internal virtual MyComboBox ComboArgumentJava
		{
			[CompilerGenerated]
			get
			{
				return this.tokenizerUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.ComboArgumentJava_DropDownOpened);
				SelectionChangedEventHandler value3 = delegate(object sender, SelectionChangedEventArgs e)
				{
					this.JavaSelectionUpdate();
				};
				MyComboBox myComboBox = this.tokenizerUtils;
				if (myComboBox != null)
				{
					myComboBox.DropDownOpened -= value2;
					myComboBox.SelectionChanged -= value3;
				}
				this.tokenizerUtils = value;
				myComboBox = this.tokenizerUtils;
				if (myComboBox != null)
				{
					myComboBox.DropDownOpened += value2;
					myComboBox.SelectionChanged += value3;
				}
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000D3E RID: 3390 RVA: 0x00009347 File Offset: 0x00007547
		// (set) Token: 0x06000D3F RID: 3391 RVA: 0x0006AF50 File Offset: 0x00069150
		internal virtual MyTextButton BtnArgumentJavaSearch
		{
			[CompilerGenerated]
			get
			{
				return this.dispatcherUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyTextButton.ClickEventHandler obj = new MyTextButton.ClickEventHandler(this.BtnArgumentJavaSearch_Click);
				MyTextButton myTextButton = this.dispatcherUtils;
				if (myTextButton != null)
				{
					myTextButton.FindContainer(obj);
				}
				this.dispatcherUtils = value;
				myTextButton = this.dispatcherUtils;
				if (myTextButton != null)
				{
					myTextButton.CreateContainer(obj);
				}
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000D40 RID: 3392 RVA: 0x0000934F File Offset: 0x0000754F
		// (set) Token: 0x06000D41 RID: 3393 RVA: 0x0006AF94 File Offset: 0x00069194
		internal virtual MyTextButton BtnArgumentJavaSelect
		{
			[CompilerGenerated]
			get
			{
				return this._TagUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyTextButton.ClickEventHandler obj = new MyTextButton.ClickEventHandler(this.BtnArgumentJavaSelect_Click);
				MyTextButton tagUtils = this._TagUtils;
				if (tagUtils != null)
				{
					tagUtils.FindContainer(obj);
				}
				this._TagUtils = value;
				tagUtils = this._TagUtils;
				if (tagUtils != null)
				{
					tagUtils.CreateContainer(obj);
				}
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000D42 RID: 3394 RVA: 0x00009357 File Offset: 0x00007557
		// (set) Token: 0x06000D43 RID: 3395 RVA: 0x0000935F File Offset: 0x0000755F
		internal virtual MyHint LabRamWarn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000D44 RID: 3396 RVA: 0x00009368 File Offset: 0x00007568
		// (set) Token: 0x06000D45 RID: 3397 RVA: 0x0006AFD8 File Offset: 0x000691D8
		internal virtual MyRadioBox RadioRamType0
		{
			[CompilerGenerated]
			get
			{
				return this.propertyUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = (PageSetupLaunch._Closure$__.$IR151-18 == null) ? (PageSetupLaunch._Closure$__.$IR151-18 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					PageSetupLaunch.RadioBoxChange((MyRadioBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR151-18;
				IMyRadio.CheckEventHandler value3 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.RefreshRam();
				};
				MyRadioBox myRadioBox = this.propertyUtils;
				if (myRadioBox != null)
				{
					myRadioBox.Check -= value2;
					myRadioBox.Check -= value3;
				}
				this.propertyUtils = value;
				myRadioBox = this.propertyUtils;
				if (myRadioBox != null)
				{
					myRadioBox.Check += value2;
					myRadioBox.Check += value3;
				}
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000D46 RID: 3398 RVA: 0x00009370 File Offset: 0x00007570
		// (set) Token: 0x06000D47 RID: 3399 RVA: 0x0006B050 File Offset: 0x00069250
		internal virtual MyRadioBox RadioRamType1
		{
			[CompilerGenerated]
			get
			{
				return this.m_WatcherUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = (PageSetupLaunch._Closure$__.$IR155-20 == null) ? (PageSetupLaunch._Closure$__.$IR155-20 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					PageSetupLaunch.RadioBoxChange((MyRadioBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR155-20;
				IMyRadio.CheckEventHandler value3 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.RefreshRam();
				};
				MyRadioBox watcherUtils = this.m_WatcherUtils;
				if (watcherUtils != null)
				{
					watcherUtils.Check -= value2;
					watcherUtils.Check -= value3;
				}
				this.m_WatcherUtils = value;
				watcherUtils = this.m_WatcherUtils;
				if (watcherUtils != null)
				{
					watcherUtils.Check += value2;
					watcherUtils.Check += value3;
				}
			}
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000D48 RID: 3400 RVA: 0x00009378 File Offset: 0x00007578
		// (set) Token: 0x06000D49 RID: 3401 RVA: 0x0006B0C8 File Offset: 0x000692C8
		internal virtual MySlider SliderRamCustom
		{
			[CompilerGenerated]
			get
			{
				return this.m_StateUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MySlider.ChangeEventHandler obj = (PageSetupLaunch._Closure$__.$IR159-22 == null) ? (PageSetupLaunch._Closure$__.$IR159-22 = delegate(object a0, bool a1)
				{
					PageSetupLaunch.SliderChange((MySlider)a0, a1);
				}) : PageSetupLaunch._Closure$__.$IR159-22;
				MySlider.ChangeEventHandler obj2 = delegate(object a0, bool a1)
				{
					this.RefreshRam();
				};
				MySlider stateUtils = this.m_StateUtils;
				if (stateUtils != null)
				{
					stateUtils.InstantiateIterator(obj);
					stateUtils.InstantiateIterator(obj2);
				}
				this.m_StateUtils = value;
				stateUtils = this.m_StateUtils;
				if (stateUtils != null)
				{
					stateUtils.InterruptIterator(obj);
					stateUtils.InterruptIterator(obj2);
				}
			}
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000D4A RID: 3402 RVA: 0x00009380 File Offset: 0x00007580
		// (set) Token: 0x06000D4B RID: 3403 RVA: 0x00009388 File Offset: 0x00007588
		internal virtual Grid PanRamDisplay { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000D4C RID: 3404 RVA: 0x00009391 File Offset: 0x00007591
		// (set) Token: 0x06000D4D RID: 3405 RVA: 0x00009399 File Offset: 0x00007599
		internal virtual ColumnDefinition ColumnRamUsed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000D4E RID: 3406 RVA: 0x000093A2 File Offset: 0x000075A2
		// (set) Token: 0x06000D4F RID: 3407 RVA: 0x000093AA File Offset: 0x000075AA
		internal virtual ColumnDefinition ColumnRamGame { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000D50 RID: 3408 RVA: 0x000093B3 File Offset: 0x000075B3
		// (set) Token: 0x06000D51 RID: 3409 RVA: 0x000093BB File Offset: 0x000075BB
		internal virtual ColumnDefinition ColumnRamEmpty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000D52 RID: 3410 RVA: 0x000093C4 File Offset: 0x000075C4
		// (set) Token: 0x06000D53 RID: 3411 RVA: 0x000093CC File Offset: 0x000075CC
		internal virtual Rectangle RectRamUsed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000D54 RID: 3412 RVA: 0x000093D5 File Offset: 0x000075D5
		// (set) Token: 0x06000D55 RID: 3413 RVA: 0x0006B140 File Offset: 0x00069340
		internal virtual Rectangle RectRamGame
		{
			[CompilerGenerated]
			get
			{
				return this.taskUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SizeChangedEventHandler value2 = delegate(object sender, SizeChangedEventArgs e)
				{
					this.RefreshRamText();
				};
				Rectangle rectangle = this.taskUtils;
				if (rectangle != null)
				{
					rectangle.SizeChanged -= value2;
				}
				this.taskUtils = value;
				rectangle = this.taskUtils;
				if (rectangle != null)
				{
					rectangle.SizeChanged += value2;
				}
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000D56 RID: 3414 RVA: 0x000093DD File Offset: 0x000075DD
		// (set) Token: 0x06000D57 RID: 3415 RVA: 0x0006B184 File Offset: 0x00069384
		internal virtual Rectangle RectRamEmpty
		{
			[CompilerGenerated]
			get
			{
				return this.m_AuthenticationUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SizeChangedEventHandler value2 = delegate(object sender, SizeChangedEventArgs e)
				{
					this.RefreshRamText();
				};
				Rectangle authenticationUtils = this.m_AuthenticationUtils;
				if (authenticationUtils != null)
				{
					authenticationUtils.SizeChanged -= value2;
				}
				this.m_AuthenticationUtils = value;
				authenticationUtils = this.m_AuthenticationUtils;
				if (authenticationUtils != null)
				{
					authenticationUtils.SizeChanged += value2;
				}
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000D58 RID: 3416 RVA: 0x000093E5 File Offset: 0x000075E5
		// (set) Token: 0x06000D59 RID: 3417 RVA: 0x000093ED File Offset: 0x000075ED
		internal virtual TextBlock LabRamUsedTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000D5A RID: 3418 RVA: 0x000093F6 File Offset: 0x000075F6
		// (set) Token: 0x06000D5B RID: 3419 RVA: 0x000093FE File Offset: 0x000075FE
		internal virtual TextBlock LabRamGameTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000D5C RID: 3420 RVA: 0x00009407 File Offset: 0x00007607
		// (set) Token: 0x06000D5D RID: 3421 RVA: 0x0000940F File Offset: 0x0000760F
		internal virtual TextBlock LabRamUsed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000D5E RID: 3422 RVA: 0x00009418 File Offset: 0x00007618
		// (set) Token: 0x06000D5F RID: 3423 RVA: 0x00009420 File Offset: 0x00007620
		internal virtual TextBlock LabRamTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000D60 RID: 3424 RVA: 0x00009429 File Offset: 0x00007629
		// (set) Token: 0x06000D61 RID: 3425 RVA: 0x0006B1C8 File Offset: 0x000693C8
		internal virtual TextBlock LabRamGame
		{
			[CompilerGenerated]
			get
			{
				return this.m_AdapterUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SizeChangedEventHandler value2 = delegate(object sender, SizeChangedEventArgs e)
				{
					this.RefreshRamText();
				};
				TextBlock adapterUtils = this.m_AdapterUtils;
				if (adapterUtils != null)
				{
					adapterUtils.SizeChanged -= value2;
				}
				this.m_AdapterUtils = value;
				adapterUtils = this.m_AdapterUtils;
				if (adapterUtils != null)
				{
					adapterUtils.SizeChanged += value2;
				}
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000D62 RID: 3426 RVA: 0x00009431 File Offset: 0x00007631
		// (set) Token: 0x06000D63 RID: 3427 RVA: 0x0006B20C File Offset: 0x0006940C
		internal virtual MyTextBox TextAdvanceJvm
		{
			[CompilerGenerated]
			get
			{
				return this.m_AnnotationUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = (PageSetupLaunch._Closure$__.$IR211-27 == null) ? (PageSetupLaunch._Closure$__.$IR211-27 = delegate(object sender, RoutedEventArgs e)
				{
					PageSetupLaunch.TextBoxChange((MyTextBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR211-27;
				MyTextBox annotationUtils = this.m_AnnotationUtils;
				if (annotationUtils != null)
				{
					annotationUtils.ResolveVal(value2);
				}
				this.m_AnnotationUtils = value;
				annotationUtils = this.m_AnnotationUtils;
				if (annotationUtils != null)
				{
					annotationUtils.CancelVal(value2);
				}
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000D64 RID: 3428 RVA: 0x00009439 File Offset: 0x00007639
		// (set) Token: 0x06000D65 RID: 3429 RVA: 0x0006B268 File Offset: 0x00069468
		internal virtual MyTextBox TextAdvanceGame
		{
			[CompilerGenerated]
			get
			{
				return this.readerUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = (PageSetupLaunch._Closure$__.$IR215-28 == null) ? (PageSetupLaunch._Closure$__.$IR215-28 = delegate(object sender, RoutedEventArgs e)
				{
					PageSetupLaunch.TextBoxChange((MyTextBox)sender, e);
				}) : PageSetupLaunch._Closure$__.$IR215-28;
				MyTextBox myTextBox = this.readerUtils;
				if (myTextBox != null)
				{
					myTextBox.ResolveVal(value2);
				}
				this.readerUtils = value;
				myTextBox = this.readerUtils;
				if (myTextBox != null)
				{
					myTextBox.CancelVal(value2);
				}
			}
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000D66 RID: 3430 RVA: 0x00009441 File Offset: 0x00007641
		// (set) Token: 0x06000D67 RID: 3431 RVA: 0x0006B2C4 File Offset: 0x000694C4
		internal virtual MyCheckBox CheckAdvanceAssets
		{
			[CompilerGenerated]
			get
			{
				return this._RegUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyCheckBox.ChangeEventHandler obj = (PageSetupLaunch._Closure$__.$IR219-29 == null) ? (PageSetupLaunch._Closure$__.$IR219-29 = delegate(object a0, bool a1)
				{
					PageSetupLaunch.CheckBoxChange((MyCheckBox)a0, a1);
				}) : PageSetupLaunch._Closure$__.$IR219-29;
				MyCheckBox regUtils = this._RegUtils;
				if (regUtils != null)
				{
					regUtils.SearchIterator(obj);
				}
				this._RegUtils = value;
				regUtils = this._RegUtils;
				if (regUtils != null)
				{
					regUtils.RunIterator(obj);
				}
			}
		}

		// Token: 0x06000D68 RID: 3432 RVA: 0x0006B320 File Offset: 0x00069520
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.m_DefinitionUtils)
			{
				this.m_DefinitionUtils = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagesetup/pagesetuplaunch.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x0006B350 File Offset: 0x00069550
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (MyScrollViewer)target;
				return;
			}
			if (connectionId == 2)
			{
				this.PanMain = (StackPanel)target;
				return;
			}
			if (connectionId == 3)
			{
				this.CardSkin = (MyCard)target;
				return;
			}
			if (connectionId == 4)
			{
				this.RadioSkinType0 = (MyRadioBox)target;
				return;
			}
			if (connectionId == 5)
			{
				this.RadioSkinType1 = (MyRadioBox)target;
				return;
			}
			if (connectionId == 6)
			{
				this.RadioSkinType2 = (MyRadioBox)target;
				return;
			}
			if (connectionId == 7)
			{
				this.RadioSkinType3 = (MyRadioBox)target;
				return;
			}
			if (connectionId == 8)
			{
				this.RadioSkinType4 = (MyRadioBox)target;
				return;
			}
			if (connectionId == 9)
			{
				this.PanSkinID = (Grid)target;
				return;
			}
			if (connectionId == 0xA)
			{
				this.TextSkinID = (MyTextBox)target;
				return;
			}
			if (connectionId == 0xB)
			{
				this.BtnSkinSave = (MyButton)target;
				return;
			}
			if (connectionId == 0xC)
			{
				this.BtnSkinCache = (MyButton)target;
				return;
			}
			if (connectionId == 0xD)
			{
				this.PanSkinChange = (Grid)target;
				return;
			}
			if (connectionId == 0xE)
			{
				this.BtnSkinChange = (MyButton)target;
				return;
			}
			if (connectionId == 0xF)
			{
				this.BtnSkinDelete = (MyButton)target;
				return;
			}
			if (connectionId == 0x10)
			{
				this.CardArgument = (MyCard)target;
				return;
			}
			if (connectionId == 0x11)
			{
				this.TextArgumentTitle = (MyTextBox)target;
				return;
			}
			if (connectionId == 0x12)
			{
				this.TextArgumentInfo = (MyTextBox)target;
				return;
			}
			if (connectionId == 0x13)
			{
				this.ComboArgumentIndie = (MyComboBox)target;
				return;
			}
			if (connectionId == 0x14)
			{
				this.ComboArgumentVisibie = (MyComboBox)target;
				return;
			}
			if (connectionId == 0x15)
			{
				this.ComboArgumentPriority = (MyComboBox)target;
				return;
			}
			if (connectionId == 0x16)
			{
				this.PanArgumentWindow = (Grid)target;
				return;
			}
			if (connectionId == 0x17)
			{
				this.ComboArgumentWindowType = (MyComboBox)target;
				return;
			}
			if (connectionId == 0x18)
			{
				this.TextArgumentWindowWidth = (MyTextBox)target;
				return;
			}
			if (connectionId == 0x19)
			{
				this.LabArgumentWindowMiddle = (TextBlock)target;
				return;
			}
			if (connectionId == 0x1A)
			{
				this.TextArgumentWindowHeight = (MyTextBox)target;
				return;
			}
			if (connectionId == 0x1B)
			{
				this.ComboArgumentJava = (MyComboBox)target;
				return;
			}
			if (connectionId == 0x1C)
			{
				this.BtnArgumentJavaSearch = (MyTextButton)target;
				return;
			}
			if (connectionId == 0x1D)
			{
				this.BtnArgumentJavaSelect = (MyTextButton)target;
				return;
			}
			if (connectionId == 0x1E)
			{
				this.LabRamWarn = (MyHint)target;
				return;
			}
			if (connectionId == 0x1F)
			{
				this.RadioRamType0 = (MyRadioBox)target;
				return;
			}
			if (connectionId == 0x20)
			{
				this.RadioRamType1 = (MyRadioBox)target;
				return;
			}
			if (connectionId == 0x21)
			{
				this.SliderRamCustom = (MySlider)target;
				return;
			}
			if (connectionId == 0x22)
			{
				this.PanRamDisplay = (Grid)target;
				return;
			}
			if (connectionId == 0x23)
			{
				this.ColumnRamUsed = (ColumnDefinition)target;
				return;
			}
			if (connectionId == 0x24)
			{
				this.ColumnRamGame = (ColumnDefinition)target;
				return;
			}
			if (connectionId == 0x25)
			{
				this.ColumnRamEmpty = (ColumnDefinition)target;
				return;
			}
			if (connectionId == 0x26)
			{
				this.RectRamUsed = (Rectangle)target;
				return;
			}
			if (connectionId == 0x27)
			{
				this.RectRamGame = (Rectangle)target;
				return;
			}
			if (connectionId == 0x28)
			{
				this.RectRamEmpty = (Rectangle)target;
				return;
			}
			if (connectionId == 0x29)
			{
				this.LabRamUsedTitle = (TextBlock)target;
				return;
			}
			if (connectionId == 0x2A)
			{
				this.LabRamGameTitle = (TextBlock)target;
				return;
			}
			if (connectionId == 0x2B)
			{
				this.LabRamUsed = (TextBlock)target;
				return;
			}
			if (connectionId == 0x2C)
			{
				this.LabRamTotal = (TextBlock)target;
				return;
			}
			if (connectionId == 0x2D)
			{
				this.LabRamGame = (TextBlock)target;
				return;
			}
			if (connectionId == 0x2E)
			{
				this.TextAdvanceJvm = (MyTextBox)target;
				return;
			}
			if (connectionId == 0x2F)
			{
				this.TextAdvanceGame = (MyTextBox)target;
				return;
			}
			if (connectionId == 0x30)
			{
				this.CheckAdvanceAssets = (MyCheckBox)target;
				return;
			}
			this.m_DefinitionUtils = true;
		}

		// Token: 0x040006DD RID: 1757
		private bool fieldUtils;

		// Token: 0x040006DE RID: 1758
		private int m_StatusUtils;

		// Token: 0x040006DF RID: 1759
		private int requestUtils;

		// Token: 0x040006E0 RID: 1760
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private MyScrollViewer _PoolUtils;

		// Token: 0x040006E1 RID: 1761
		[AccessedThroughProperty("PanMain")]
		[CompilerGenerated]
		private StackPanel parserUtils;

		// Token: 0x040006E2 RID: 1762
		[AccessedThroughProperty("CardSkin")]
		[CompilerGenerated]
		private MyCard proxyUtils;

		// Token: 0x040006E3 RID: 1763
		[CompilerGenerated]
		[AccessedThroughProperty("RadioSkinType0")]
		private MyRadioBox setterUtils;

		// Token: 0x040006E4 RID: 1764
		[AccessedThroughProperty("RadioSkinType1")]
		[CompilerGenerated]
		private MyRadioBox _MerchantUtils;

		// Token: 0x040006E5 RID: 1765
		[CompilerGenerated]
		[AccessedThroughProperty("RadioSkinType2")]
		private MyRadioBox m_EventUtils;

		// Token: 0x040006E6 RID: 1766
		[CompilerGenerated]
		[AccessedThroughProperty("RadioSkinType3")]
		private MyRadioBox printerUtils;

		// Token: 0x040006E7 RID: 1767
		[AccessedThroughProperty("RadioSkinType4")]
		[CompilerGenerated]
		private MyRadioBox _ProductUtils;

		// Token: 0x040006E8 RID: 1768
		[AccessedThroughProperty("PanSkinID")]
		[CompilerGenerated]
		private Grid comparatorUtils;

		// Token: 0x040006E9 RID: 1769
		[CompilerGenerated]
		[AccessedThroughProperty("TextSkinID")]
		private MyTextBox m_RegistryUtils;

		// Token: 0x040006EA RID: 1770
		[AccessedThroughProperty("BtnSkinSave")]
		[CompilerGenerated]
		private MyButton m_AttributeUtils;

		// Token: 0x040006EB RID: 1771
		[AccessedThroughProperty("BtnSkinCache")]
		[CompilerGenerated]
		private MyButton _ValueUtils;

		// Token: 0x040006EC RID: 1772
		[AccessedThroughProperty("PanSkinChange")]
		[CompilerGenerated]
		private Grid roleUtils;

		// Token: 0x040006ED RID: 1773
		[AccessedThroughProperty("BtnSkinChange")]
		[CompilerGenerated]
		private MyButton advisorUtils;

		// Token: 0x040006EE RID: 1774
		[AccessedThroughProperty("BtnSkinDelete")]
		[CompilerGenerated]
		private MyButton _StrategyUtils;

		// Token: 0x040006EF RID: 1775
		[AccessedThroughProperty("CardArgument")]
		[CompilerGenerated]
		private MyCard m_WrapperUtils;

		// Token: 0x040006F0 RID: 1776
		[AccessedThroughProperty("TextArgumentTitle")]
		[CompilerGenerated]
		private MyTextBox m_WriterUtils;

		// Token: 0x040006F1 RID: 1777
		[CompilerGenerated]
		[AccessedThroughProperty("TextArgumentInfo")]
		private MyTextBox exporterUtils;

		// Token: 0x040006F2 RID: 1778
		[CompilerGenerated]
		[AccessedThroughProperty("ComboArgumentIndie")]
		private MyComboBox _RecordUtils;

		// Token: 0x040006F3 RID: 1779
		[AccessedThroughProperty("ComboArgumentVisibie")]
		[CompilerGenerated]
		private MyComboBox m_GetterUtils;

		// Token: 0x040006F4 RID: 1780
		[AccessedThroughProperty("ComboArgumentPriority")]
		[CompilerGenerated]
		private MyComboBox _InterceptorUtils;

		// Token: 0x040006F5 RID: 1781
		[CompilerGenerated]
		[AccessedThroughProperty("PanArgumentWindow")]
		private Grid _InvocationUtils;

		// Token: 0x040006F6 RID: 1782
		[AccessedThroughProperty("ComboArgumentWindowType")]
		[CompilerGenerated]
		private MyComboBox candidateUtils;

		// Token: 0x040006F7 RID: 1783
		[CompilerGenerated]
		[AccessedThroughProperty("TextArgumentWindowWidth")]
		private MyTextBox _DescriptorUtils;

		// Token: 0x040006F8 RID: 1784
		[CompilerGenerated]
		[AccessedThroughProperty("LabArgumentWindowMiddle")]
		private TextBlock contextUtils;

		// Token: 0x040006F9 RID: 1785
		[CompilerGenerated]
		[AccessedThroughProperty("TextArgumentWindowHeight")]
		private MyTextBox observerUtils;

		// Token: 0x040006FA RID: 1786
		[AccessedThroughProperty("ComboArgumentJava")]
		[CompilerGenerated]
		private MyComboBox tokenizerUtils;

		// Token: 0x040006FB RID: 1787
		[AccessedThroughProperty("BtnArgumentJavaSearch")]
		[CompilerGenerated]
		private MyTextButton dispatcherUtils;

		// Token: 0x040006FC RID: 1788
		[CompilerGenerated]
		[AccessedThroughProperty("BtnArgumentJavaSelect")]
		private MyTextButton _TagUtils;

		// Token: 0x040006FD RID: 1789
		[AccessedThroughProperty("LabRamWarn")]
		[CompilerGenerated]
		private MyHint initializerUtils;

		// Token: 0x040006FE RID: 1790
		[CompilerGenerated]
		[AccessedThroughProperty("RadioRamType0")]
		private MyRadioBox propertyUtils;

		// Token: 0x040006FF RID: 1791
		[AccessedThroughProperty("RadioRamType1")]
		[CompilerGenerated]
		private MyRadioBox m_WatcherUtils;

		// Token: 0x04000700 RID: 1792
		[CompilerGenerated]
		[AccessedThroughProperty("SliderRamCustom")]
		private MySlider m_StateUtils;

		// Token: 0x04000701 RID: 1793
		[AccessedThroughProperty("PanRamDisplay")]
		[CompilerGenerated]
		private Grid creatorUtils;

		// Token: 0x04000702 RID: 1794
		[AccessedThroughProperty("ColumnRamUsed")]
		[CompilerGenerated]
		private ColumnDefinition _PageUtils;

		// Token: 0x04000703 RID: 1795
		[CompilerGenerated]
		[AccessedThroughProperty("ColumnRamGame")]
		private ColumnDefinition instanceUtils;

		// Token: 0x04000704 RID: 1796
		[AccessedThroughProperty("ColumnRamEmpty")]
		[CompilerGenerated]
		private ColumnDefinition _TestUtils;

		// Token: 0x04000705 RID: 1797
		[AccessedThroughProperty("RectRamUsed")]
		[CompilerGenerated]
		private Rectangle customerUtils;

		// Token: 0x04000706 RID: 1798
		[AccessedThroughProperty("RectRamGame")]
		[CompilerGenerated]
		private Rectangle taskUtils;

		// Token: 0x04000707 RID: 1799
		[AccessedThroughProperty("RectRamEmpty")]
		[CompilerGenerated]
		private Rectangle m_AuthenticationUtils;

		// Token: 0x04000708 RID: 1800
		[CompilerGenerated]
		[AccessedThroughProperty("LabRamUsedTitle")]
		private TextBlock m_ProcessUtils;

		// Token: 0x04000709 RID: 1801
		[CompilerGenerated]
		[AccessedThroughProperty("LabRamGameTitle")]
		private TextBlock listenerUtils;

		// Token: 0x0400070A RID: 1802
		[AccessedThroughProperty("LabRamUsed")]
		[CompilerGenerated]
		private TextBlock m_ImporterUtils;

		// Token: 0x0400070B RID: 1803
		[AccessedThroughProperty("LabRamTotal")]
		[CompilerGenerated]
		private TextBlock m_TemplateUtils;

		// Token: 0x0400070C RID: 1804
		[AccessedThroughProperty("LabRamGame")]
		[CompilerGenerated]
		private TextBlock m_AdapterUtils;

		// Token: 0x0400070D RID: 1805
		[AccessedThroughProperty("TextAdvanceJvm")]
		[CompilerGenerated]
		private MyTextBox m_AnnotationUtils;

		// Token: 0x0400070E RID: 1806
		[CompilerGenerated]
		[AccessedThroughProperty("TextAdvanceGame")]
		private MyTextBox readerUtils;

		// Token: 0x0400070F RID: 1807
		[AccessedThroughProperty("CheckAdvanceAssets")]
		[CompilerGenerated]
		private MyCheckBox _RegUtils;

		// Token: 0x04000710 RID: 1808
		private bool m_DefinitionUtils;
	}
}
