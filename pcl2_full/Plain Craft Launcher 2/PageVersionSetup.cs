using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PCL.My;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
	// Token: 0x020000B2 RID: 178
	[DesignerGenerated]
	public class PageVersionSetup : AdornerDecorator, IComponentConnector
	{
		// Token: 0x060006B1 RID: 1713 RVA: 0x00005EEA File Offset: 0x000040EA
		public PageVersionSetup()
		{
			base.Loaded += this.PageSetupSystem_Loaded;
			this._ComparatorModel = false;
			this.m_RegistryModel = 2;
			this.m_AttributeModel = 1;
			this.InitializeComponent();
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x00032114 File Offset: 0x00030314
		private void PageSetupSystem_Loaded(object sender, RoutedEventArgs e)
		{
			this.PanBack.ScrollToHome();
			this.RefreshRam(false);
			checked
			{
				ModAni.ListFactory(ModAni.InsertFactory() + 1);
				this.Reload();
				ModAni.ListFactory(ModAni.InsertFactory() - 1);
				if (!this._ComparatorModel)
				{
					this._ComparatorModel = true;
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

		// Token: 0x060006B3 RID: 1715 RVA: 0x0003218C File Offset: 0x0003038C
		public void Reload()
		{
			try
			{
				this.TextArgumentTitle.Text = Conversions.ToString(ModBase._BaseRule.Get("VersionArgumentTitle", PageVersionLeft.m_OrderModel));
				this.TextArgumentInfo.Text = Conversions.ToString(ModBase._BaseRule.Get("VersionArgumentInfo", PageVersionLeft.m_OrderModel));
				int num = Conversions.ToInteger(ModBase._BaseRule.Get("VersionArgumentIndie", PageVersionLeft.m_OrderModel));
				if (num == -1)
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(PageVersionLeft.m_OrderModel.Path + "mods\\");
					DirectoryInfo directoryInfo2 = new DirectoryInfo(PageVersionLeft.m_OrderModel.Path + "saves\\");
					if ((directoryInfo.Exists && directoryInfo.EnumerateFiles().Count<FileInfo>() > 0) || (directoryInfo2.Exists && directoryInfo2.EnumerateFiles().Count<FileInfo>() > 0))
					{
						ModBase._BaseRule.Set("VersionArgumentIndie", 1, false, PageVersionLeft.m_OrderModel);
						ModBase.Log("[Setup] 已自动开启单版本隔离：" + PageVersionLeft.m_OrderModel.Name, ModBase.LogLevel.Normal, "出现错误");
						num = 1;
					}
					else
					{
						ModBase._BaseRule.Set("VersionArgumentIndie", 0, false, PageVersionLeft.m_OrderModel);
						ModBase.Log("[Setup] 版本隔离使用全局设置：" + PageVersionLeft.m_OrderModel.Name, ModBase.LogLevel.Normal, "出现错误");
						num = 0;
					}
				}
				this.ComboArgumentIndie.SelectedIndex = num;
				this.TextAdvanceJvm.Text = Conversions.ToString(ModBase._BaseRule.Get("VersionAdvanceJvm", PageVersionLeft.m_OrderModel));
				this.TextAdvanceGame.Text = Conversions.ToString(ModBase._BaseRule.Get("VersionAdvanceGame", PageVersionLeft.m_OrderModel));
				this.ComboAdvanceAssets.SelectedIndex = Conversions.ToInteger(ModBase._BaseRule.Get("VersionAdvanceAssets", PageVersionLeft.m_OrderModel));
				this.RefreshJavaComboBox();
				((MyRadioBox)base.FindName(Conversions.ToString(Operators.ConcatenateObject("RadioRamType", ModBase._BaseRule.Load("VersionRamType", false, PageVersionLeft.m_OrderModel))))).Checked = true;
				this.SliderRamCustom.Value = Conversions.ToInteger(ModBase._BaseRule.Get("VersionRamCustom", PageVersionLeft.m_OrderModel));
				this.TextServerEnter.Text = Conversions.ToString(ModBase._BaseRule.Get("VersionServerEnter", PageVersionLeft.m_OrderModel));
				this.ComboServerLogin.SelectedIndex = Conversions.ToInteger(ModBase._BaseRule.Get("VersionServerLogin", PageVersionLeft.m_OrderModel));
				this._ValueModel = this.ComboServerLogin.SelectedIndex;
				this.ServerLogin(this.ComboServerLogin.SelectedIndex);
				this.TextServerNide.Text = Conversions.ToString(ModBase._BaseRule.Get("VersionServerNide", PageVersionLeft.m_OrderModel));
				this.TextServerAuthServer.Text = Conversions.ToString(ModBase._BaseRule.Get("VersionServerAuthServer", PageVersionLeft.m_OrderModel));
				this.TextServerAuthName.Text = Conversions.ToString(ModBase._BaseRule.Get("VersionServerAuthName", PageVersionLeft.m_OrderModel));
				this.TextServerAuthRegister.Text = Conversions.ToString(ModBase._BaseRule.Get("VersionServerAuthRegister", PageVersionLeft.m_OrderModel));
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "重载版本独立设置时出错", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x000324EC File Offset: 0x000306EC
		public void Reset()
		{
			try
			{
				ModBase._BaseRule.Reset("VersionServerEnter", false, PageVersionLeft.m_OrderModel);
				ModBase._BaseRule.Reset("VersionServerLogin", false, PageVersionLeft.m_OrderModel);
				ModBase._BaseRule.Reset("VersionServerNide", false, PageVersionLeft.m_OrderModel);
				ModBase._BaseRule.Reset("VersionServerAuthServer", false, PageVersionLeft.m_OrderModel);
				ModBase._BaseRule.Reset("VersionServerAuthRegister", false, PageVersionLeft.m_OrderModel);
				ModBase._BaseRule.Reset("VersionServerNide", false, PageVersionLeft.m_OrderModel);
				ModBase._BaseRule.Reset("VersionArgumentTitle", false, PageVersionLeft.m_OrderModel);
				ModBase._BaseRule.Reset("VersionArgumentInfo", false, PageVersionLeft.m_OrderModel);
				ModBase._BaseRule.Set("VersionArgumentIndie", 0, false, PageVersionLeft.m_OrderModel);
				ModBase._BaseRule.Reset("VersionRamType", false, PageVersionLeft.m_OrderModel);
				ModBase._BaseRule.Reset("VersionRamCustom", false, PageVersionLeft.m_OrderModel);
				ModBase._BaseRule.Reset("VersionAdvanceJvm", false, PageVersionLeft.m_OrderModel);
				ModBase._BaseRule.Reset("VersionAdvanceGame", false, PageVersionLeft.m_OrderModel);
				ModBase._BaseRule.Reset("VersionAdvanceAssets", false, PageVersionLeft.m_OrderModel);
				ModBase._BaseRule.Reset("VersionArgumentJavaSelect", false, PageVersionLeft.m_OrderModel);
				ModMinecraft._PredicateIterator.Start(ModBase.GetUuid(), false);
				ModBase.Log("[Setup] 已初始化版本独立设置", ModBase.LogLevel.Normal, "出现错误");
				ModMain.Hint("已初始化版本独立设置！", ModMain.HintType.Finish, false);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "初始化版本独立设置失败", ModBase.LogLevel.Msgbox, "出现错误");
			}
			this.Reload();
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x000326AC File Offset: 0x000308AC
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
				})[1]), false, PageVersionLeft.m_OrderModel);
			}
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x00032714 File Offset: 0x00030914
		private static void TextBoxChange(MyTextBox sender, object e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				string text = sender.Text;
				if (Operators.ConditionalCompareObjectEqual(sender.Tag, "VersionServerAuthServer", true) || Operators.ConditionalCompareObjectEqual(sender.Tag, "VersionServerAuthRegister", true))
				{
					text = text.TrimEnd(new char[]
					{
						'/'
					});
				}
				ModBase._BaseRule.Set(Conversions.ToString(sender.Tag), text, false, PageVersionLeft.m_OrderModel);
			}
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x00005F1F File Offset: 0x0000411F
		private static void SliderChange(MySlider sender, object e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set(Conversions.ToString(sender.Tag), sender.Value, false, PageVersionLeft.m_OrderModel);
			}
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x00005F4E File Offset: 0x0000414E
		private static void ComboChange(MyComboBox sender, object e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set(Conversions.ToString(sender.Tag), sender.SelectedIndex, false, PageVersionLeft.m_OrderModel);
			}
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00005F7D File Offset: 0x0000417D
		public void RamType(int Type)
		{
			if (this.SliderRamCustom != null)
			{
				this.SliderRamCustom.IsEnabled = (Type == 1);
			}
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x00032784 File Offset: 0x00030984
		public void RefreshRam(bool ShowAnim)
		{
			if (this.LabRamGame != null && this.LabRamUsed != null && !(ModMain.m_GetterFilter.publisherDecorator != FormMain.PageType.VersionSetup) && ModMain.producerFilter.m_ServiceModel == FormMain.PageSubType.DownloadInstall)
			{
				double ram = PageVersionSetup.GetRam(PageVersionLeft.m_OrderModel);
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
					this.LabRamWarn.Visibility = ((ram != 1.0 || ModMinecraft.JavaUse64Bit(PageVersionLeft.m_OrderModel) || ModBase.m_MapperRule) ? Visibility.Collapsed : Visibility.Visible);
				}
				if (ShowAnim)
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaGridLengthWidth(this.ColumnRamUsed, num4 - this.ColumnRamUsed.Width.Value, 0x320, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false),
						ModAni.AaGridLengthWidth(this.ColumnRamGame, num3 - this.ColumnRamGame.Width.Value, 0x320, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false),
						ModAni.AaGridLengthWidth(this.ColumnRamEmpty, num5 - this.ColumnRamEmpty.Width.Value, 0x320, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false)
					}, "VersionSetup Ram Grid", false);
					return;
				}
				this.ColumnRamUsed.Width = new GridLength(num4, GridUnitType.Star);
				this.ColumnRamGame.Width = new GridLength(num3, GridUnitType.Star);
				this.ColumnRamEmpty.Width = new GridLength(num5, GridUnitType.Star);
			}
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x00005F96 File Offset: 0x00004196
		private void RefreshRam()
		{
			this.RefreshRam(true);
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x00032C34 File Offset: 0x00030E34
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
			if (this.m_RegistryModel != num)
			{
				this.m_RegistryModel = num;
				switch (num)
				{
				case 0:
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaOpacity(this.LabRamUsed, -this.LabRamUsed.Opacity, 0x64, 0, null, false),
						ModAni.AaOpacity(this.LabRamTotal, -this.LabRamTotal.Opacity, 0x64, 0, null, false),
						ModAni.AaOpacity(this.LabRamUsedTitle, -this.LabRamUsedTitle.Opacity, 0x64, 0, null, false)
					}, "VersionSetup Ram TextLeft", false);
					break;
				case 1:
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaOpacity(this.LabRamUsed, 1.0 - this.LabRamUsed.Opacity, 0x64, 0, null, false),
						ModAni.AaOpacity(this.LabRamTotal, -this.LabRamTotal.Opacity, 0x64, 0, null, false),
						ModAni.AaOpacity(this.LabRamUsedTitle, 0.7 - this.LabRamUsedTitle.Opacity, 0x64, 0, null, false)
					}, "VersionSetup Ram TextLeft", false);
					break;
				case 2:
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaOpacity(this.LabRamUsed, 1.0 - this.LabRamUsed.Opacity, 0x64, 0, null, false),
						ModAni.AaOpacity(this.LabRamTotal, 1.0 - this.LabRamTotal.Opacity, 0x64, 0, null, false),
						ModAni.AaOpacity(this.LabRamUsedTitle, 0.7 - this.LabRamUsedTitle.Opacity, 0x64, 0, null, false)
					}, "VersionSetup Ram TextLeft", false);
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
				if (ModAni.InsertFactory() == 0 && (this.m_AttributeModel != num2 || ModAni.AniIsRun("VersionSetup Ram TextRight")))
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaX(this.LabRamGame, actualWidth2 - actualWidth3 - this.LabRamGame.Margin.Left, 0x64, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false),
						ModAni.AaX(this.LabRamGameTitle, actualWidth2 - actualWidth6 - this.LabRamGameTitle.Margin.Left, 0x64, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false)
					}, "VersionSetup Ram TextRight", false);
				}
				else
				{
					this.LabRamGame.Margin = new Thickness(actualWidth2 - actualWidth3, 3.0, 0.0, 0.0);
					this.LabRamGameTitle.Margin = new Thickness(actualWidth2 - actualWidth6, 0.0, 0.0, 5.0);
				}
			}
			else if (ModAni.InsertFactory() == 0 && (this.m_AttributeModel != num2 || ModAni.AniIsRun("VersionSetup Ram TextRight")))
			{
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaX(this.LabRamGame, 2.0 + actualWidth - this.LabRamGame.Margin.Left, 0x64, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false),
					ModAni.AaX(this.LabRamGameTitle, 2.0 + actualWidth - this.LabRamGameTitle.Margin.Left, 0x64, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false)
				}, "VersionSetup Ram TextRight", false);
			}
			else
			{
				this.LabRamGame.Margin = new Thickness(2.0 + actualWidth, 3.0, 0.0, 0.0);
				this.LabRamGameTitle.Margin = new Thickness(2.0 + actualWidth, 0.0, 0.0, 5.0);
			}
			this.m_AttributeModel = num2;
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x000330F8 File Offset: 0x000312F8
		public static double GetRam(ModMinecraft.McVersion Version)
		{
			double result;
			if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("VersionRamType", Version), 2, true))
			{
				result = PageSetupLaunch.GetRam(Version, true);
			}
			else
			{
				double num7;
				if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("VersionRamType", Version), 0, true))
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
					int num8 = Conversions.ToInteger(ModBase._BaseRule.Get("VersionRamCustom", Version));
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
				if (!ModMinecraft.JavaUse64Bit(PageVersionLeft.m_OrderModel))
				{
					num7 = Math.Min(1.0, num7);
				}
				result = num7;
			}
			return result;
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x000334DC File Offset: 0x000316DC
		private void ComboServerLogin_Changed()
		{
			if (ModAni.InsertFactory() == 0)
			{
				this.ServerLogin(this.ComboServerLogin.SelectedIndex);
				if ((this.ComboServerLogin.SelectedIndex != 3 || Operators.CompareString(this.TextServerNide.ValidateResult, "", true) == 0) && (this.ComboServerLogin.SelectedIndex != 4 || (Operators.CompareString(this.TextServerAuthServer.ValidateResult, "", true) == 0 && Operators.CompareString(this.TextServerAuthRegister.ValidateResult, "", true) == 0)) && this._ValueModel != this.ComboServerLogin.SelectedIndex)
				{
					this._ValueModel = this.ComboServerLogin.SelectedIndex;
					PageVersionSetup.ComboChange(this.ComboServerLogin, null);
				}
			}
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x00033598 File Offset: 0x00031798
		public void ServerLogin(int Type)
		{
			if (this.LabServerNide != null)
			{
				this.LabServerNide.Visibility = ((Type == 3) ? Visibility.Visible : Visibility.Collapsed);
				this.TextServerNide.Visibility = ((Type == 3) ? Visibility.Visible : Visibility.Collapsed);
				this.PanServerNide.Visibility = ((Type == 3) ? Visibility.Visible : Visibility.Collapsed);
				this.LabServerAuthName.Visibility = ((Type == 4) ? Visibility.Visible : Visibility.Collapsed);
				this.TextServerAuthName.Visibility = ((Type == 4) ? Visibility.Visible : Visibility.Collapsed);
				this.LabServerAuthRegister.Visibility = ((Type == 4) ? Visibility.Visible : Visibility.Collapsed);
				this.TextServerAuthRegister.Visibility = ((Type == 4) ? Visibility.Visible : Visibility.Collapsed);
				this.LabServerAuthServer.Visibility = ((Type == 4) ? Visibility.Visible : Visibility.Collapsed);
				this.TextServerAuthServer.Visibility = ((Type == 4) ? Visibility.Visible : Visibility.Collapsed);
				this.CardServer.TriggerForceResize();
			}
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x00005F9F File Offset: 0x0000419F
		private void BtnServerNideWeb_Click(object sender, EventArgs e)
		{
			ModBase.OpenWebsite("https://login2.nide8.com:233/server/intro");
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x00005FAB File Offset: 0x000041AB
		private void BtnServerNideBbs_Click(object sender, EventArgs e)
		{
			ModBase.OpenWebsite("https://www.mcbbs.net/thread-729821-1-1.html");
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00033668 File Offset: 0x00031868
		public void RefreshJavaComboBox()
		{
			if (this.ComboArgumentJava != null)
			{
				this.ComboArgumentJava.Items.Clear();
				this.ComboArgumentJava.Items.Add(new MyComboBoxItem
				{
					Content = "使用全局设置",
					Tag = "使用全局设置"
				});
				this.ComboArgumentJava.Items.Add(new MyComboBoxItem
				{
					Content = "自动选择适合所选游戏版本的 Java",
					Tag = "自动选择"
				});
				MyComboBoxItem myComboBoxItem = null;
				string text = Conversions.ToString(ModBase._BaseRule.Get("VersionArgumentJavaSelect", PageVersionLeft.m_OrderModel));
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
							if (Operators.CompareString(text, "", true) != 0 && Operators.CompareString(text, "使用全局设置", true) != 0 && Operators.CompareString(ModMinecraft.JavaEntry.FromJson((JObject)ModBase.GetJson(text)).m_AnnotationAlgo, javaEntry.m_AnnotationAlgo, true) == 0)
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
					ModBase._BaseRule.Set("VersionArgumentJavaSelect", "使用全局设置", false, PageVersionLeft.m_OrderModel);
					ModBase.Log(ex, "更新版本设置 Java 下拉框失败", ModBase.LogLevel.Feedback, "出现错误");
				}
				if (myComboBoxItem == null && ModMinecraft._ConfigurationIterator.Count > 0)
				{
					if (Operators.CompareString(text, "", true) == 0)
					{
						myComboBoxItem = (MyComboBoxItem)this.ComboArgumentJava.Items[1];
					}
					else
					{
						myComboBoxItem = (MyComboBoxItem)this.ComboArgumentJava.Items[0];
					}
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

		// Token: 0x060006C3 RID: 1731 RVA: 0x000338C0 File Offset: 0x00031AC0
		private void ComboArgumentJava_DropDownOpened(object sender, EventArgs e)
		{
			if (this.ComboArgumentJava.SelectedItem == null || Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(this.ComboArgumentJava.Items[0], null, "Content", new object[0], null, null, null), "未找到可用的 Java", true) || Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(this.ComboArgumentJava.Items[0], null, "Content", new object[0], null, null, null), "加载中……", true))
			{
				this.ComboArgumentJava.IsDropDownOpen = false;
			}
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x0003394C File Offset: 0x00031B4C
		private void JavaSelectionUpdate()
		{
			if (ModAni.InsertFactory() == 0 && this.ComboArgumentJava.SelectedItem != null && NewLateBinding.LateGet(this.ComboArgumentJava.SelectedItem, null, "Tag", new object[0], null, null, null) != null)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(this.ComboArgumentJava.SelectedItem, null, "Tag", new object[0], null, null, null));
				if ("使用全局设置".Equals(RuntimeHelpers.GetObjectValue(objectValue)))
				{
					ModBase._BaseRule.Set("VersionArgumentJavaSelect", "使用全局设置", false, PageVersionLeft.m_OrderModel);
					ModBase.Log("[Java] 修改版本 Java 选择设置：使用全局设置", ModBase.LogLevel.Normal, "出现错误");
				}
				else if ("自动选择".Equals(RuntimeHelpers.GetObjectValue(objectValue)))
				{
					ModBase._BaseRule.Set("VersionArgumentJavaSelect", "", false, PageVersionLeft.m_OrderModel);
					ModBase.Log("[Java] 修改版本 Java 选择设置：自动选择", ModBase.LogLevel.Normal, "出现错误");
				}
				else
				{
					ModBase._BaseRule.Set("VersionArgumentJavaSelect", ((JObject)NewLateBinding.LateGet(objectValue, null, "ToJson", new object[0], null, null, null)).ToString(Formatting.None, new JsonConverter[0]), false, PageVersionLeft.m_OrderModel);
					ModBase.Log("[Java] 修改版本 Java 选择设置：" + objectValue.ToString(), ModBase.LogLevel.Normal, "出现错误");
				}
				this.RefreshRam(true);
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060006C5 RID: 1733 RVA: 0x00005FB7 File Offset: 0x000041B7
		// (set) Token: 0x060006C6 RID: 1734 RVA: 0x00005FBF File Offset: 0x000041BF
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060006C7 RID: 1735 RVA: 0x00005FC8 File Offset: 0x000041C8
		// (set) Token: 0x060006C8 RID: 1736 RVA: 0x00005FD0 File Offset: 0x000041D0
		internal virtual StackPanel PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060006C9 RID: 1737 RVA: 0x00005FD9 File Offset: 0x000041D9
		// (set) Token: 0x060006CA RID: 1738 RVA: 0x00005FE1 File Offset: 0x000041E1
		internal virtual MyCard CardArgument { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060006CB RID: 1739 RVA: 0x00005FEA File Offset: 0x000041EA
		// (set) Token: 0x060006CC RID: 1740 RVA: 0x00033A98 File Offset: 0x00031C98
		internal virtual MyTextBox TextArgumentTitle
		{
			[CompilerGenerated]
			get
			{
				return this.wrapperModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = (PageVersionSetup._Closure$__.$IR38-2 == null) ? (PageVersionSetup._Closure$__.$IR38-2 = delegate(object sender, RoutedEventArgs e)
				{
					PageVersionSetup.TextBoxChange((MyTextBox)sender, e);
				}) : PageVersionSetup._Closure$__.$IR38-2;
				MyTextBox myTextBox = this.wrapperModel;
				if (myTextBox != null)
				{
					myTextBox.ResolveVal(value2);
				}
				this.wrapperModel = value;
				myTextBox = this.wrapperModel;
				if (myTextBox != null)
				{
					myTextBox.CancelVal(value2);
				}
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060006CD RID: 1741 RVA: 0x00005FF2 File Offset: 0x000041F2
		// (set) Token: 0x060006CE RID: 1742 RVA: 0x00033AF4 File Offset: 0x00031CF4
		internal virtual MyTextBox TextArgumentInfo
		{
			[CompilerGenerated]
			get
			{
				return this.m_WriterModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = (PageVersionSetup._Closure$__.$IR42-3 == null) ? (PageVersionSetup._Closure$__.$IR42-3 = delegate(object sender, RoutedEventArgs e)
				{
					PageVersionSetup.TextBoxChange((MyTextBox)sender, e);
				}) : PageVersionSetup._Closure$__.$IR42-3;
				MyTextBox writerModel = this.m_WriterModel;
				if (writerModel != null)
				{
					writerModel.ResolveVal(value2);
				}
				this.m_WriterModel = value;
				writerModel = this.m_WriterModel;
				if (writerModel != null)
				{
					writerModel.CancelVal(value2);
				}
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060006CF RID: 1743 RVA: 0x00005FFA File Offset: 0x000041FA
		// (set) Token: 0x060006D0 RID: 1744 RVA: 0x00033B50 File Offset: 0x00031D50
		internal virtual MyTextBox TextAdvanceJvm
		{
			[CompilerGenerated]
			get
			{
				return this.m_ExporterModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = (PageVersionSetup._Closure$__.$IR46-4 == null) ? (PageVersionSetup._Closure$__.$IR46-4 = delegate(object sender, RoutedEventArgs e)
				{
					PageVersionSetup.TextBoxChange((MyTextBox)sender, e);
				}) : PageVersionSetup._Closure$__.$IR46-4;
				MyTextBox exporterModel = this.m_ExporterModel;
				if (exporterModel != null)
				{
					exporterModel.ResolveVal(value2);
				}
				this.m_ExporterModel = value;
				exporterModel = this.m_ExporterModel;
				if (exporterModel != null)
				{
					exporterModel.CancelVal(value2);
				}
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060006D1 RID: 1745 RVA: 0x00006002 File Offset: 0x00004202
		// (set) Token: 0x060006D2 RID: 1746 RVA: 0x00033BAC File Offset: 0x00031DAC
		internal virtual MyTextBox TextAdvanceGame
		{
			[CompilerGenerated]
			get
			{
				return this._RecordModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = (PageVersionSetup._Closure$__.$IR50-5 == null) ? (PageVersionSetup._Closure$__.$IR50-5 = delegate(object sender, RoutedEventArgs e)
				{
					PageVersionSetup.TextBoxChange((MyTextBox)sender, e);
				}) : PageVersionSetup._Closure$__.$IR50-5;
				MyTextBox recordModel = this._RecordModel;
				if (recordModel != null)
				{
					recordModel.ResolveVal(value2);
				}
				this._RecordModel = value;
				recordModel = this._RecordModel;
				if (recordModel != null)
				{
					recordModel.CancelVal(value2);
				}
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060006D3 RID: 1747 RVA: 0x0000600A File Offset: 0x0000420A
		// (set) Token: 0x060006D4 RID: 1748 RVA: 0x00033C08 File Offset: 0x00031E08
		internal virtual MyComboBox ComboArgumentIndie
		{
			[CompilerGenerated]
			get
			{
				return this.m_GetterModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SelectionChangedEventHandler value2 = (PageVersionSetup._Closure$__.$IR54-6 == null) ? (PageVersionSetup._Closure$__.$IR54-6 = delegate(object sender, SelectionChangedEventArgs e)
				{
					PageVersionSetup.ComboChange((MyComboBox)sender, e);
				}) : PageVersionSetup._Closure$__.$IR54-6;
				MyComboBox getterModel = this.m_GetterModel;
				if (getterModel != null)
				{
					getterModel.SelectionChanged -= value2;
				}
				this.m_GetterModel = value;
				getterModel = this.m_GetterModel;
				if (getterModel != null)
				{
					getterModel.SelectionChanged += value2;
				}
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060006D5 RID: 1749 RVA: 0x00006012 File Offset: 0x00004212
		// (set) Token: 0x060006D6 RID: 1750 RVA: 0x00033C64 File Offset: 0x00031E64
		internal virtual MyComboBox ComboAdvanceAssets
		{
			[CompilerGenerated]
			get
			{
				return this.interceptorModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SelectionChangedEventHandler value2 = (PageVersionSetup._Closure$__.$IR58-7 == null) ? (PageVersionSetup._Closure$__.$IR58-7 = delegate(object sender, SelectionChangedEventArgs e)
				{
					PageVersionSetup.ComboChange((MyComboBox)sender, e);
				}) : PageVersionSetup._Closure$__.$IR58-7;
				MyComboBox myComboBox = this.interceptorModel;
				if (myComboBox != null)
				{
					myComboBox.SelectionChanged -= value2;
				}
				this.interceptorModel = value;
				myComboBox = this.interceptorModel;
				if (myComboBox != null)
				{
					myComboBox.SelectionChanged += value2;
				}
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x0000601A File Offset: 0x0000421A
		// (set) Token: 0x060006D8 RID: 1752 RVA: 0x00033CC0 File Offset: 0x00031EC0
		internal virtual MyComboBox ComboArgumentJava
		{
			[CompilerGenerated]
			get
			{
				return this._InvocationModel;
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
				MyComboBox invocationModel = this._InvocationModel;
				if (invocationModel != null)
				{
					invocationModel.DropDownOpened -= value2;
					invocationModel.SelectionChanged -= value3;
				}
				this._InvocationModel = value;
				invocationModel = this._InvocationModel;
				if (invocationModel != null)
				{
					invocationModel.DropDownOpened += value2;
					invocationModel.SelectionChanged += value3;
				}
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060006D9 RID: 1753 RVA: 0x00006022 File Offset: 0x00004222
		// (set) Token: 0x060006DA RID: 1754 RVA: 0x0000602A File Offset: 0x0000422A
		internal virtual MyHint LabRamWarn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060006DB RID: 1755 RVA: 0x00006033 File Offset: 0x00004233
		// (set) Token: 0x060006DC RID: 1756 RVA: 0x00033D20 File Offset: 0x00031F20
		internal virtual MyRadioBox RadioRamType2
		{
			[CompilerGenerated]
			get
			{
				return this.descriptorModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = (PageVersionSetup._Closure$__.$IR70-9 == null) ? (PageVersionSetup._Closure$__.$IR70-9 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					PageVersionSetup.RadioBoxChange((MyRadioBox)sender, e);
				}) : PageVersionSetup._Closure$__.$IR70-9;
				IMyRadio.CheckEventHandler value3 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.RefreshRam();
				};
				MyRadioBox myRadioBox = this.descriptorModel;
				if (myRadioBox != null)
				{
					myRadioBox.Check -= value2;
					myRadioBox.Check -= value3;
				}
				this.descriptorModel = value;
				myRadioBox = this.descriptorModel;
				if (myRadioBox != null)
				{
					myRadioBox.Check += value2;
					myRadioBox.Check += value3;
				}
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x0000603B File Offset: 0x0000423B
		// (set) Token: 0x060006DE RID: 1758 RVA: 0x00033D98 File Offset: 0x00031F98
		internal virtual MyRadioBox RadioRamType0
		{
			[CompilerGenerated]
			get
			{
				return this._ContextModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = (PageVersionSetup._Closure$__.$IR74-11 == null) ? (PageVersionSetup._Closure$__.$IR74-11 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					PageVersionSetup.RadioBoxChange((MyRadioBox)sender, e);
				}) : PageVersionSetup._Closure$__.$IR74-11;
				IMyRadio.CheckEventHandler value3 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.RefreshRam();
				};
				MyRadioBox contextModel = this._ContextModel;
				if (contextModel != null)
				{
					contextModel.Check -= value2;
					contextModel.Check -= value3;
				}
				this._ContextModel = value;
				contextModel = this._ContextModel;
				if (contextModel != null)
				{
					contextModel.Check += value2;
					contextModel.Check += value3;
				}
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x00006043 File Offset: 0x00004243
		// (set) Token: 0x060006E0 RID: 1760 RVA: 0x00033E10 File Offset: 0x00032010
		internal virtual MyRadioBox RadioRamType1
		{
			[CompilerGenerated]
			get
			{
				return this.observerModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				IMyRadio.CheckEventHandler value2 = (PageVersionSetup._Closure$__.$IR78-13 == null) ? (PageVersionSetup._Closure$__.$IR78-13 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					PageVersionSetup.RadioBoxChange((MyRadioBox)sender, e);
				}) : PageVersionSetup._Closure$__.$IR78-13;
				IMyRadio.CheckEventHandler value3 = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.RefreshRam();
				};
				MyRadioBox myRadioBox = this.observerModel;
				if (myRadioBox != null)
				{
					myRadioBox.Check -= value2;
					myRadioBox.Check -= value3;
				}
				this.observerModel = value;
				myRadioBox = this.observerModel;
				if (myRadioBox != null)
				{
					myRadioBox.Check += value2;
					myRadioBox.Check += value3;
				}
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060006E1 RID: 1761 RVA: 0x0000604B File Offset: 0x0000424B
		// (set) Token: 0x060006E2 RID: 1762 RVA: 0x00033E88 File Offset: 0x00032088
		internal virtual MySlider SliderRamCustom
		{
			[CompilerGenerated]
			get
			{
				return this._TokenizerModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MySlider.ChangeEventHandler obj = (PageVersionSetup._Closure$__.$IR82-15 == null) ? (PageVersionSetup._Closure$__.$IR82-15 = delegate(object a0, bool a1)
				{
					PageVersionSetup.SliderChange((MySlider)a0, a1);
				}) : PageVersionSetup._Closure$__.$IR82-15;
				MySlider.ChangeEventHandler obj2 = delegate(object a0, bool a1)
				{
					this.RefreshRam();
				};
				MySlider tokenizerModel = this._TokenizerModel;
				if (tokenizerModel != null)
				{
					tokenizerModel.InstantiateIterator(obj);
					tokenizerModel.InstantiateIterator(obj2);
				}
				this._TokenizerModel = value;
				tokenizerModel = this._TokenizerModel;
				if (tokenizerModel != null)
				{
					tokenizerModel.InterruptIterator(obj);
					tokenizerModel.InterruptIterator(obj2);
				}
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060006E3 RID: 1763 RVA: 0x00006053 File Offset: 0x00004253
		// (set) Token: 0x060006E4 RID: 1764 RVA: 0x0000605B File Offset: 0x0000425B
		internal virtual Grid PanRamDisplay { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060006E5 RID: 1765 RVA: 0x00006064 File Offset: 0x00004264
		// (set) Token: 0x060006E6 RID: 1766 RVA: 0x0000606C File Offset: 0x0000426C
		internal virtual ColumnDefinition ColumnRamUsed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060006E7 RID: 1767 RVA: 0x00006075 File Offset: 0x00004275
		// (set) Token: 0x060006E8 RID: 1768 RVA: 0x0000607D File Offset: 0x0000427D
		internal virtual ColumnDefinition ColumnRamGame { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060006E9 RID: 1769 RVA: 0x00006086 File Offset: 0x00004286
		// (set) Token: 0x060006EA RID: 1770 RVA: 0x0000608E File Offset: 0x0000428E
		internal virtual ColumnDefinition ColumnRamEmpty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060006EB RID: 1771 RVA: 0x00006097 File Offset: 0x00004297
		// (set) Token: 0x060006EC RID: 1772 RVA: 0x0000609F File Offset: 0x0000429F
		internal virtual Rectangle RectRamUsed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060006ED RID: 1773 RVA: 0x000060A8 File Offset: 0x000042A8
		// (set) Token: 0x060006EE RID: 1774 RVA: 0x00033F00 File Offset: 0x00032100
		internal virtual Rectangle RectRamGame
		{
			[CompilerGenerated]
			get
			{
				return this.m_StateModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SizeChangedEventHandler value2 = delegate(object sender, SizeChangedEventArgs e)
				{
					this.RefreshRamText();
				};
				Rectangle stateModel = this.m_StateModel;
				if (stateModel != null)
				{
					stateModel.SizeChanged -= value2;
				}
				this.m_StateModel = value;
				stateModel = this.m_StateModel;
				if (stateModel != null)
				{
					stateModel.SizeChanged += value2;
				}
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060006EF RID: 1775 RVA: 0x000060B0 File Offset: 0x000042B0
		// (set) Token: 0x060006F0 RID: 1776 RVA: 0x00033F44 File Offset: 0x00032144
		internal virtual Rectangle RectRamEmpty
		{
			[CompilerGenerated]
			get
			{
				return this.creatorModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SizeChangedEventHandler value2 = delegate(object sender, SizeChangedEventArgs e)
				{
					this.RefreshRamText();
				};
				Rectangle rectangle = this.creatorModel;
				if (rectangle != null)
				{
					rectangle.SizeChanged -= value2;
				}
				this.creatorModel = value;
				rectangle = this.creatorModel;
				if (rectangle != null)
				{
					rectangle.SizeChanged += value2;
				}
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060006F1 RID: 1777 RVA: 0x000060B8 File Offset: 0x000042B8
		// (set) Token: 0x060006F2 RID: 1778 RVA: 0x000060C0 File Offset: 0x000042C0
		internal virtual TextBlock LabRamUsedTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060006F3 RID: 1779 RVA: 0x000060C9 File Offset: 0x000042C9
		// (set) Token: 0x060006F4 RID: 1780 RVA: 0x000060D1 File Offset: 0x000042D1
		internal virtual TextBlock LabRamGameTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x060006F5 RID: 1781 RVA: 0x000060DA File Offset: 0x000042DA
		// (set) Token: 0x060006F6 RID: 1782 RVA: 0x000060E2 File Offset: 0x000042E2
		internal virtual TextBlock LabRamUsed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060006F7 RID: 1783 RVA: 0x000060EB File Offset: 0x000042EB
		// (set) Token: 0x060006F8 RID: 1784 RVA: 0x000060F3 File Offset: 0x000042F3
		internal virtual TextBlock LabRamTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060006F9 RID: 1785 RVA: 0x000060FC File Offset: 0x000042FC
		// (set) Token: 0x060006FA RID: 1786 RVA: 0x00033F88 File Offset: 0x00032188
		internal virtual TextBlock LabRamGame
		{
			[CompilerGenerated]
			get
			{
				return this.m_TaskModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SizeChangedEventHandler value2 = delegate(object sender, SizeChangedEventArgs e)
				{
					this.RefreshRamText();
				};
				TextBlock taskModel = this.m_TaskModel;
				if (taskModel != null)
				{
					taskModel.SizeChanged -= value2;
				}
				this.m_TaskModel = value;
				taskModel = this.m_TaskModel;
				if (taskModel != null)
				{
					taskModel.SizeChanged += value2;
				}
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060006FB RID: 1787 RVA: 0x00006104 File Offset: 0x00004304
		// (set) Token: 0x060006FC RID: 1788 RVA: 0x0000610C File Offset: 0x0000430C
		internal virtual MyCard CardServer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060006FD RID: 1789 RVA: 0x00006115 File Offset: 0x00004315
		// (set) Token: 0x060006FE RID: 1790 RVA: 0x00033FCC File Offset: 0x000321CC
		internal virtual MyComboBox ComboServerLogin
		{
			[CompilerGenerated]
			get
			{
				return this.m_ProcessModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SelectionChangedEventHandler value2 = delegate(object sender, SelectionChangedEventArgs e)
				{
					this.ComboServerLogin_Changed();
				};
				MyComboBox processModel = this.m_ProcessModel;
				if (processModel != null)
				{
					processModel.SelectionChanged -= value2;
				}
				this.m_ProcessModel = value;
				processModel = this.m_ProcessModel;
				if (processModel != null)
				{
					processModel.SelectionChanged += value2;
				}
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060006FF RID: 1791 RVA: 0x0000611D File Offset: 0x0000431D
		// (set) Token: 0x06000700 RID: 1792 RVA: 0x00006125 File Offset: 0x00004325
		internal virtual TextBlock LabServerNide { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000701 RID: 1793 RVA: 0x0000612E File Offset: 0x0000432E
		// (set) Token: 0x06000702 RID: 1794 RVA: 0x00034010 File Offset: 0x00032210
		internal virtual MyTextBox TextServerNide
		{
			[CompilerGenerated]
			get
			{
				return this._ImporterModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = (PageVersionSetup._Closure$__.$IR146-21 == null) ? (PageVersionSetup._Closure$__.$IR146-21 = delegate(object sender, RoutedEventArgs e)
				{
					PageVersionSetup.TextBoxChange((MyTextBox)sender, e);
				}) : PageVersionSetup._Closure$__.$IR146-21;
				RoutedEventHandler value3 = delegate(object sender, RoutedEventArgs e)
				{
					this.ComboServerLogin_Changed();
				};
				MyTextBox importerModel = this._ImporterModel;
				if (importerModel != null)
				{
					importerModel.ResolveVal(value2);
					importerModel.ResolveVal(value3);
				}
				this._ImporterModel = value;
				importerModel = this._ImporterModel;
				if (importerModel != null)
				{
					importerModel.CancelVal(value2);
					importerModel.CancelVal(value3);
				}
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000703 RID: 1795 RVA: 0x00006136 File Offset: 0x00004336
		// (set) Token: 0x06000704 RID: 1796 RVA: 0x0000613E File Offset: 0x0000433E
		internal virtual TextBlock LabServerAuthServer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000705 RID: 1797 RVA: 0x00006147 File Offset: 0x00004347
		// (set) Token: 0x06000706 RID: 1798 RVA: 0x00034088 File Offset: 0x00032288
		internal virtual MyTextBox TextServerAuthServer
		{
			[CompilerGenerated]
			get
			{
				return this.m_AdapterModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = (PageVersionSetup._Closure$__.$IR154-23 == null) ? (PageVersionSetup._Closure$__.$IR154-23 = delegate(object sender, RoutedEventArgs e)
				{
					PageVersionSetup.TextBoxChange((MyTextBox)sender, e);
				}) : PageVersionSetup._Closure$__.$IR154-23;
				RoutedEventHandler value3 = delegate(object sender, RoutedEventArgs e)
				{
					this.ComboServerLogin_Changed();
				};
				MyTextBox adapterModel = this.m_AdapterModel;
				if (adapterModel != null)
				{
					adapterModel.ResolveVal(value2);
					adapterModel.ResolveVal(value3);
				}
				this.m_AdapterModel = value;
				adapterModel = this.m_AdapterModel;
				if (adapterModel != null)
				{
					adapterModel.CancelVal(value2);
					adapterModel.CancelVal(value3);
				}
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x0000614F File Offset: 0x0000434F
		// (set) Token: 0x06000708 RID: 1800 RVA: 0x00006157 File Offset: 0x00004357
		internal virtual TextBlock LabServerAuthRegister { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000709 RID: 1801 RVA: 0x00006160 File Offset: 0x00004360
		// (set) Token: 0x0600070A RID: 1802 RVA: 0x00034100 File Offset: 0x00032300
		internal virtual MyTextBox TextServerAuthRegister
		{
			[CompilerGenerated]
			get
			{
				return this.readerModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = (PageVersionSetup._Closure$__.$IR162-25 == null) ? (PageVersionSetup._Closure$__.$IR162-25 = delegate(object sender, RoutedEventArgs e)
				{
					PageVersionSetup.TextBoxChange((MyTextBox)sender, e);
				}) : PageVersionSetup._Closure$__.$IR162-25;
				RoutedEventHandler value3 = delegate(object sender, RoutedEventArgs e)
				{
					this.ComboServerLogin_Changed();
				};
				MyTextBox myTextBox = this.readerModel;
				if (myTextBox != null)
				{
					myTextBox.ResolveVal(value2);
					myTextBox.ResolveVal(value3);
				}
				this.readerModel = value;
				myTextBox = this.readerModel;
				if (myTextBox != null)
				{
					myTextBox.CancelVal(value2);
					myTextBox.CancelVal(value3);
				}
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x00006168 File Offset: 0x00004368
		// (set) Token: 0x0600070C RID: 1804 RVA: 0x00006170 File Offset: 0x00004370
		internal virtual TextBlock LabServerAuthName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x00006179 File Offset: 0x00004379
		// (set) Token: 0x0600070E RID: 1806 RVA: 0x00034178 File Offset: 0x00032378
		internal virtual MyTextBox TextServerAuthName
		{
			[CompilerGenerated]
			get
			{
				return this.definitionModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = (PageVersionSetup._Closure$__.$IR170-27 == null) ? (PageVersionSetup._Closure$__.$IR170-27 = delegate(object sender, RoutedEventArgs e)
				{
					PageVersionSetup.TextBoxChange((MyTextBox)sender, e);
				}) : PageVersionSetup._Closure$__.$IR170-27;
				MyTextBox myTextBox = this.definitionModel;
				if (myTextBox != null)
				{
					myTextBox.ResolveVal(value2);
				}
				this.definitionModel = value;
				myTextBox = this.definitionModel;
				if (myTextBox != null)
				{
					myTextBox.CancelVal(value2);
				}
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x00006181 File Offset: 0x00004381
		// (set) Token: 0x06000710 RID: 1808 RVA: 0x000341D4 File Offset: 0x000323D4
		internal virtual MyTextBox TextServerEnter
		{
			[CompilerGenerated]
			get
			{
				return this.m_ParamModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = (PageVersionSetup._Closure$__.$IR174-28 == null) ? (PageVersionSetup._Closure$__.$IR174-28 = delegate(object sender, RoutedEventArgs e)
				{
					PageVersionSetup.TextBoxChange((MyTextBox)sender, e);
				}) : PageVersionSetup._Closure$__.$IR174-28;
				MyTextBox paramModel = this.m_ParamModel;
				if (paramModel != null)
				{
					paramModel.ResolveVal(value2);
				}
				this.m_ParamModel = value;
				paramModel = this.m_ParamModel;
				if (paramModel != null)
				{
					paramModel.CancelVal(value2);
				}
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000711 RID: 1809 RVA: 0x00006189 File Offset: 0x00004389
		// (set) Token: 0x06000712 RID: 1810 RVA: 0x00006191 File Offset: 0x00004391
		internal virtual Grid PanServerNide { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000713 RID: 1811 RVA: 0x0000619A File Offset: 0x0000439A
		// (set) Token: 0x06000714 RID: 1812 RVA: 0x00034230 File Offset: 0x00032430
		internal virtual MyButton BtnServerNideWeb
		{
			[CompilerGenerated]
			get
			{
				return this._SpecificationModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnServerNideWeb_Click);
				MyButton specificationModel = this._SpecificationModel;
				if (specificationModel != null)
				{
					specificationModel.CancelModel(obj);
				}
				this._SpecificationModel = value;
				specificationModel = this._SpecificationModel;
				if (specificationModel != null)
				{
					specificationModel.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000715 RID: 1813 RVA: 0x000061A2 File Offset: 0x000043A2
		// (set) Token: 0x06000716 RID: 1814 RVA: 0x00034274 File Offset: 0x00032474
		internal virtual MyButton BtnServerNideBbs
		{
			[CompilerGenerated]
			get
			{
				return this.m_DicModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnServerNideBbs_Click);
				MyButton dicModel = this.m_DicModel;
				if (dicModel != null)
				{
					dicModel.CancelModel(obj);
				}
				this.m_DicModel = value;
				dicModel = this.m_DicModel;
				if (dicModel != null)
				{
					dicModel.ValidateModel(obj);
				}
			}
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x000342B8 File Offset: 0x000324B8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.schemaModel)
			{
				this.schemaModel = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pageversion/pageversionsetup.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x000342E8 File Offset: 0x000324E8
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
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
				this.CardArgument = (MyCard)target;
				return;
			}
			if (connectionId == 4)
			{
				this.TextArgumentTitle = (MyTextBox)target;
				return;
			}
			if (connectionId == 5)
			{
				this.TextArgumentInfo = (MyTextBox)target;
				return;
			}
			if (connectionId == 6)
			{
				this.TextAdvanceJvm = (MyTextBox)target;
				return;
			}
			if (connectionId == 7)
			{
				this.TextAdvanceGame = (MyTextBox)target;
				return;
			}
			if (connectionId == 8)
			{
				this.ComboArgumentIndie = (MyComboBox)target;
				return;
			}
			if (connectionId == 9)
			{
				this.ComboAdvanceAssets = (MyComboBox)target;
				return;
			}
			if (connectionId == 0xA)
			{
				this.ComboArgumentJava = (MyComboBox)target;
				return;
			}
			if (connectionId == 0xB)
			{
				this.LabRamWarn = (MyHint)target;
				return;
			}
			if (connectionId == 0xC)
			{
				this.RadioRamType2 = (MyRadioBox)target;
				return;
			}
			if (connectionId == 0xD)
			{
				this.RadioRamType0 = (MyRadioBox)target;
				return;
			}
			if (connectionId == 0xE)
			{
				this.RadioRamType1 = (MyRadioBox)target;
				return;
			}
			if (connectionId == 0xF)
			{
				this.SliderRamCustom = (MySlider)target;
				return;
			}
			if (connectionId == 0x10)
			{
				this.PanRamDisplay = (Grid)target;
				return;
			}
			if (connectionId == 0x11)
			{
				this.ColumnRamUsed = (ColumnDefinition)target;
				return;
			}
			if (connectionId == 0x12)
			{
				this.ColumnRamGame = (ColumnDefinition)target;
				return;
			}
			if (connectionId == 0x13)
			{
				this.ColumnRamEmpty = (ColumnDefinition)target;
				return;
			}
			if (connectionId == 0x14)
			{
				this.RectRamUsed = (Rectangle)target;
				return;
			}
			if (connectionId == 0x15)
			{
				this.RectRamGame = (Rectangle)target;
				return;
			}
			if (connectionId == 0x16)
			{
				this.RectRamEmpty = (Rectangle)target;
				return;
			}
			if (connectionId == 0x17)
			{
				this.LabRamUsedTitle = (TextBlock)target;
				return;
			}
			if (connectionId == 0x18)
			{
				this.LabRamGameTitle = (TextBlock)target;
				return;
			}
			if (connectionId == 0x19)
			{
				this.LabRamUsed = (TextBlock)target;
				return;
			}
			if (connectionId == 0x1A)
			{
				this.LabRamTotal = (TextBlock)target;
				return;
			}
			if (connectionId == 0x1B)
			{
				this.LabRamGame = (TextBlock)target;
				return;
			}
			if (connectionId == 0x1C)
			{
				this.CardServer = (MyCard)target;
				return;
			}
			if (connectionId == 0x1D)
			{
				this.ComboServerLogin = (MyComboBox)target;
				return;
			}
			if (connectionId == 0x1E)
			{
				this.LabServerNide = (TextBlock)target;
				return;
			}
			if (connectionId == 0x1F)
			{
				this.TextServerNide = (MyTextBox)target;
				return;
			}
			if (connectionId == 0x20)
			{
				this.LabServerAuthServer = (TextBlock)target;
				return;
			}
			if (connectionId == 0x21)
			{
				this.TextServerAuthServer = (MyTextBox)target;
				return;
			}
			if (connectionId == 0x22)
			{
				this.LabServerAuthRegister = (TextBlock)target;
				return;
			}
			if (connectionId == 0x23)
			{
				this.TextServerAuthRegister = (MyTextBox)target;
				return;
			}
			if (connectionId == 0x24)
			{
				this.LabServerAuthName = (TextBlock)target;
				return;
			}
			if (connectionId == 0x25)
			{
				this.TextServerAuthName = (MyTextBox)target;
				return;
			}
			if (connectionId == 0x26)
			{
				this.TextServerEnter = (MyTextBox)target;
				return;
			}
			if (connectionId == 0x27)
			{
				this.PanServerNide = (Grid)target;
				return;
			}
			if (connectionId == 0x28)
			{
				this.BtnServerNideWeb = (MyButton)target;
				return;
			}
			if (connectionId == 0x29)
			{
				this.BtnServerNideBbs = (MyButton)target;
				return;
			}
			this.schemaModel = true;
		}

		// Token: 0x04000322 RID: 802
		private bool _ComparatorModel;

		// Token: 0x04000323 RID: 803
		private int m_RegistryModel;

		// Token: 0x04000324 RID: 804
		private int m_AttributeModel;

		// Token: 0x04000325 RID: 805
		private int _ValueModel;

		// Token: 0x04000326 RID: 806
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private MyScrollViewer _RoleModel;

		// Token: 0x04000327 RID: 807
		[CompilerGenerated]
		[AccessedThroughProperty("PanMain")]
		private StackPanel advisorModel;

		// Token: 0x04000328 RID: 808
		[CompilerGenerated]
		[AccessedThroughProperty("CardArgument")]
		private MyCard strategyModel;

		// Token: 0x04000329 RID: 809
		[CompilerGenerated]
		[AccessedThroughProperty("TextArgumentTitle")]
		private MyTextBox wrapperModel;

		// Token: 0x0400032A RID: 810
		[CompilerGenerated]
		[AccessedThroughProperty("TextArgumentInfo")]
		private MyTextBox m_WriterModel;

		// Token: 0x0400032B RID: 811
		[AccessedThroughProperty("TextAdvanceJvm")]
		[CompilerGenerated]
		private MyTextBox m_ExporterModel;

		// Token: 0x0400032C RID: 812
		[CompilerGenerated]
		[AccessedThroughProperty("TextAdvanceGame")]
		private MyTextBox _RecordModel;

		// Token: 0x0400032D RID: 813
		[AccessedThroughProperty("ComboArgumentIndie")]
		[CompilerGenerated]
		private MyComboBox m_GetterModel;

		// Token: 0x0400032E RID: 814
		[CompilerGenerated]
		[AccessedThroughProperty("ComboAdvanceAssets")]
		private MyComboBox interceptorModel;

		// Token: 0x0400032F RID: 815
		[AccessedThroughProperty("ComboArgumentJava")]
		[CompilerGenerated]
		private MyComboBox _InvocationModel;

		// Token: 0x04000330 RID: 816
		[CompilerGenerated]
		[AccessedThroughProperty("LabRamWarn")]
		private MyHint m_CandidateModel;

		// Token: 0x04000331 RID: 817
		[CompilerGenerated]
		[AccessedThroughProperty("RadioRamType2")]
		private MyRadioBox descriptorModel;

		// Token: 0x04000332 RID: 818
		[AccessedThroughProperty("RadioRamType0")]
		[CompilerGenerated]
		private MyRadioBox _ContextModel;

		// Token: 0x04000333 RID: 819
		[AccessedThroughProperty("RadioRamType1")]
		[CompilerGenerated]
		private MyRadioBox observerModel;

		// Token: 0x04000334 RID: 820
		[CompilerGenerated]
		[AccessedThroughProperty("SliderRamCustom")]
		private MySlider _TokenizerModel;

		// Token: 0x04000335 RID: 821
		[CompilerGenerated]
		[AccessedThroughProperty("PanRamDisplay")]
		private Grid _DispatcherModel;

		// Token: 0x04000336 RID: 822
		[CompilerGenerated]
		[AccessedThroughProperty("ColumnRamUsed")]
		private ColumnDefinition tagModel;

		// Token: 0x04000337 RID: 823
		[CompilerGenerated]
		[AccessedThroughProperty("ColumnRamGame")]
		private ColumnDefinition initializerModel;

		// Token: 0x04000338 RID: 824
		[AccessedThroughProperty("ColumnRamEmpty")]
		[CompilerGenerated]
		private ColumnDefinition m_PropertyModel;

		// Token: 0x04000339 RID: 825
		[CompilerGenerated]
		[AccessedThroughProperty("RectRamUsed")]
		private Rectangle watcherModel;

		// Token: 0x0400033A RID: 826
		[CompilerGenerated]
		[AccessedThroughProperty("RectRamGame")]
		private Rectangle m_StateModel;

		// Token: 0x0400033B RID: 827
		[CompilerGenerated]
		[AccessedThroughProperty("RectRamEmpty")]
		private Rectangle creatorModel;

		// Token: 0x0400033C RID: 828
		[AccessedThroughProperty("LabRamUsedTitle")]
		[CompilerGenerated]
		private TextBlock _PageModel;

		// Token: 0x0400033D RID: 829
		[AccessedThroughProperty("LabRamGameTitle")]
		[CompilerGenerated]
		private TextBlock instanceModel;

		// Token: 0x0400033E RID: 830
		[AccessedThroughProperty("LabRamUsed")]
		[CompilerGenerated]
		private TextBlock _TestModel;

		// Token: 0x0400033F RID: 831
		[CompilerGenerated]
		[AccessedThroughProperty("LabRamTotal")]
		private TextBlock m_CustomerModel;

		// Token: 0x04000340 RID: 832
		[AccessedThroughProperty("LabRamGame")]
		[CompilerGenerated]
		private TextBlock m_TaskModel;

		// Token: 0x04000341 RID: 833
		[CompilerGenerated]
		[AccessedThroughProperty("CardServer")]
		private MyCard authenticationModel;

		// Token: 0x04000342 RID: 834
		[AccessedThroughProperty("ComboServerLogin")]
		[CompilerGenerated]
		private MyComboBox m_ProcessModel;

		// Token: 0x04000343 RID: 835
		[AccessedThroughProperty("LabServerNide")]
		[CompilerGenerated]
		private TextBlock listenerModel;

		// Token: 0x04000344 RID: 836
		[CompilerGenerated]
		[AccessedThroughProperty("TextServerNide")]
		private MyTextBox _ImporterModel;

		// Token: 0x04000345 RID: 837
		[AccessedThroughProperty("LabServerAuthServer")]
		[CompilerGenerated]
		private TextBlock templateModel;

		// Token: 0x04000346 RID: 838
		[CompilerGenerated]
		[AccessedThroughProperty("TextServerAuthServer")]
		private MyTextBox m_AdapterModel;

		// Token: 0x04000347 RID: 839
		[CompilerGenerated]
		[AccessedThroughProperty("LabServerAuthRegister")]
		private TextBlock annotationModel;

		// Token: 0x04000348 RID: 840
		[CompilerGenerated]
		[AccessedThroughProperty("TextServerAuthRegister")]
		private MyTextBox readerModel;

		// Token: 0x04000349 RID: 841
		[CompilerGenerated]
		[AccessedThroughProperty("LabServerAuthName")]
		private TextBlock regModel;

		// Token: 0x0400034A RID: 842
		[AccessedThroughProperty("TextServerAuthName")]
		[CompilerGenerated]
		private MyTextBox definitionModel;

		// Token: 0x0400034B RID: 843
		[AccessedThroughProperty("TextServerEnter")]
		[CompilerGenerated]
		private MyTextBox m_ParamModel;

		// Token: 0x0400034C RID: 844
		[AccessedThroughProperty("PanServerNide")]
		[CompilerGenerated]
		private Grid mockModel;

		// Token: 0x0400034D RID: 845
		[CompilerGenerated]
		[AccessedThroughProperty("BtnServerNideWeb")]
		private MyButton _SpecificationModel;

		// Token: 0x0400034E RID: 846
		[AccessedThroughProperty("BtnServerNideBbs")]
		[CompilerGenerated]
		private MyButton m_DicModel;

		// Token: 0x0400034F RID: 847
		private bool schemaModel;
	}
}
