using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCL.My;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x020000B0 RID: 176
	[DesignerGenerated]
	public class PageVersionOverall : AdornerDecorator, IComponentConnector
	{
		// Token: 0x06000680 RID: 1664 RVA: 0x00005D80 File Offset: 0x00003F80
		public PageVersionOverall()
		{
			base.Loaded += this.PageSetupLaunch_Loaded;
			this.interpreterModel = false;
			this.InitializeComponent();
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x00005DA7 File Offset: 0x00003FA7
		private void PageSetupLaunch_Loaded(object sender, RoutedEventArgs e)
		{
			this.PanBack.ScrollToHome();
			this.ItemDisplayLogoCustom.Tag = "PCL\\Logo.png";
			this.Reload();
			if (!this.interpreterModel)
			{
				this.interpreterModel = true;
				this.PanDisplay.TriggerForceResize();
			}
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x00030E14 File Offset: 0x0002F014
		private void Reload()
		{
			checked
			{
				ModAni.ListFactory(ModAni.InsertFactory() + 1);
				this.ComboDisplayType.SelectedIndex = Conversions.ToInteger(ModBase.ReadIni(PageVersionLeft.m_OrderModel.Path + "PCL\\Setup.ini", "DisplayType", Conversions.ToString(0)));
				this.BtnDisplayStar.Text = (PageVersionLeft.m_OrderModel.m_QueueAlgo ? "从收藏夹中移除" : "加入收藏夹");
				this.PanDisplayItem.Children.Clear();
				this.predicateModel = ModMinecraft.McVersionListItem(PageVersionLeft.m_OrderModel);
				this.predicateModel.IsHitTestVisible = false;
				this.PanDisplayItem.Children.Add(this.predicateModel);
				ModMain.m_GetterFilter.PageNameRefresh();
				this.ComboDisplayLogo.SelectedIndex = 0;
				string text = ModBase.ReadIni(PageVersionLeft.m_OrderModel.Path + "PCL\\Setup.ini", "Logo", "");
				if (Conversions.ToBoolean(ModBase.ReadIni(PageVersionLeft.m_OrderModel.Path + "PCL\\Setup.ini", "LogoCustom", "False")))
				{
					try
					{
						foreach (object obj in ((IEnumerable)this.ComboDisplayLogo.Items))
						{
							MyComboBoxItem myComboBoxItem = (MyComboBoxItem)obj;
							if (Operators.ConditionalCompareObjectEqual(myComboBoxItem.Tag, text, true) || (Operators.ConditionalCompareObjectEqual(myComboBoxItem.Tag, "PCL\\Logo.png", true) && text.EndsWith("PCL\\Logo.png")))
							{
								this.ComboDisplayLogo.SelectedItem = myComboBoxItem;
								break;
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
				ModAni.ListFactory(ModAni.InsertFactory() - 1);
			}
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x00030FC4 File Offset: 0x0002F1C4
		private void ComboDisplayType_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.interpreterModel && ModAni.InsertFactory() == 0)
			{
				if (this.ComboDisplayType.SelectedIndex != 1)
				{
					try
					{
						ModBase.WriteIni(PageVersionLeft.m_OrderModel.Path + "PCL\\Setup.ini", "DisplayType", Conversions.ToString(this.ComboDisplayType.SelectedIndex));
						ModBase.WriteIni(ModMinecraft.m_ResolverIterator + "PCL.ini", "VersionCache", "");
						ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", false);
						return;
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "修改版本分类失败（" + PageVersionLeft.m_OrderModel.Name + "）", ModBase.LogLevel.Feedback, "出现错误");
						return;
					}
				}
				try
				{
					if (Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("HintHide", null))))
					{
						if (ModMain.MyMsgBox("确认要从版本列表中隐藏该版本吗？隐藏该版本后，它将不再出现于 PCL 显示的版本列表中。\r\n此后，在版本列表页面按下 F11 才可以查看被隐藏的版本。", "隐藏版本提示", "确定", "取消", "", false, true, false) != 1)
						{
							this.ComboDisplayType.SelectedIndex = 0;
							return;
						}
						ModBase._BaseRule.Set("HintHide", true, false, null);
					}
					ModBase.WriteIni(PageVersionLeft.m_OrderModel.Path + "PCL\\Setup.ini", "DisplayType", Conversions.ToString(1));
					ModBase.WriteIni(ModMinecraft.m_ResolverIterator + "PCL.ini", "VersionCache", "");
					ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", false);
				}
				catch (Exception ex2)
				{
					ModBase.Log(ex2, "隐藏版本 " + PageVersionLeft.m_OrderModel.Name + " 失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x000311AC File Offset: 0x0002F3AC
		private void BtnDisplayDesc_Click(object sender, EventArgs e)
		{
			try
			{
				string text = ModBase.ReadIni(PageVersionLeft.m_OrderModel.Path + "PCL\\Setup.ini", "CustomInfo", "");
				string text2 = ModMain.MyMsgBoxInput(text, new Collection<Validate>(), "留空即为使用默认描述", "更改描述", "确定", "取消", false);
				if (text2 != null && Operators.CompareString(text, text2, true) != 0)
				{
					ModBase.WriteIni(PageVersionLeft.m_OrderModel.Path + "PCL\\Setup.ini", "CustomInfo", text2);
				}
				PageVersionLeft.m_OrderModel = new ModMinecraft.McVersion(PageVersionLeft.m_OrderModel.Name).Load();
				this.Reload();
				ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", false);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "版本 " + PageVersionLeft.m_OrderModel.Name + " 描述更改失败", ModBase.LogLevel.Msgbox, "出现错误");
			}
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x000312A8 File Offset: 0x0002F4A8
		private void BtnDisplayRename_Click(object sender, EventArgs e)
		{
			try
			{
				string name = PageVersionLeft.m_OrderModel.Name;
				string path = PageVersionLeft.m_OrderModel.Path;
				string text = ModMain.MyMsgBoxInput(name, new Collection<Validate>
				{
					new ValidateFolderName(ModMinecraft.m_ResolverIterator + "versions", true, false)
				}, "", "重命名版本", "确定", "取消", false);
				if (!string.IsNullOrWhiteSpace(text))
				{
					string text2 = ModMinecraft.m_ResolverIterator + "versions\\" + text + "\\";
					string text3 = text + "_temp";
					string directory = ModMinecraft.m_ResolverIterator + "versions\\" + text3 + "\\";
					bool flag = Operators.CompareString(text.ToLower(), name.ToLower(), true) == 0;
					JObject jobject;
					try
					{
						jobject = (JObject)ModBase.GetJson(ModBase.ReadFile(PageVersionLeft.m_OrderModel.Path + PageVersionLeft.m_OrderModel.Name + ".json"));
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "重命名读取 Json 时失败", ModBase.LogLevel.Debug, "出现错误");
						jobject = PageVersionLeft.m_OrderModel.VerifyUtils();
					}
					MyWpfExtension.RunFactory().FileSystem.RenameDirectory(path, text3);
					MyWpfExtension.RunFactory().FileSystem.RenameDirectory(directory, text);
					try
					{
						foreach (DirectoryInfo directoryInfo in new DirectoryInfo(text2).EnumerateDirectories())
						{
							if (directoryInfo.Name.Contains(name))
							{
								if (flag)
								{
									MyWpfExtension.RunFactory().FileSystem.RenameDirectory(directoryInfo.FullName, directoryInfo.Name + "_temp");
									MyWpfExtension.RunFactory().FileSystem.RenameDirectory(directoryInfo.FullName + "_temp", directoryInfo.Name.Replace(name, text));
								}
								else
								{
									ModBase.DeleteDirectory(text2 + directoryInfo.Name.Replace(name, text), false);
									MyWpfExtension.RunFactory().FileSystem.RenameDirectory(directoryInfo.FullName, directoryInfo.Name.Replace(name, text));
								}
							}
						}
					}
					finally
					{
						IEnumerator<DirectoryInfo> enumerator;
						if (enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					try
					{
						foreach (FileInfo fileInfo in new DirectoryInfo(text2).EnumerateFiles())
						{
							if (fileInfo.Name.Contains(name))
							{
								if (flag)
								{
									MyWpfExtension.RunFactory().FileSystem.RenameFile(fileInfo.FullName, fileInfo.Name + "_temp");
									MyWpfExtension.RunFactory().FileSystem.RenameFile(fileInfo.FullName + "_temp", fileInfo.Name.Replace(name, text));
								}
								else
								{
									if (File.Exists(text2 + fileInfo.Name.Replace(name, text)))
									{
										File.Delete(text2 + fileInfo.Name.Replace(name, text));
									}
									MyWpfExtension.RunFactory().FileSystem.RenameFile(fileInfo.FullName, fileInfo.Name.Replace(name, text));
								}
							}
						}
					}
					finally
					{
						IEnumerator<FileInfo> enumerator2;
						if (enumerator2 != null)
						{
							enumerator2.Dispose();
						}
					}
					if (File.Exists(text2 + "PCL\\Setup.ini"))
					{
						ModBase.WriteFile(text2 + "PCL\\Setup.ini", ModBase.ReadFile(text2 + "PCL\\Setup.ini").Replace(path, text2), false, null);
					}
					if (Operators.CompareString(ModBase.ReadIni(ModMinecraft.m_ResolverIterator + "PCL.ini", "Version", ""), name, true) == 0)
					{
						ModBase.WriteIni(ModMinecraft.m_ResolverIterator + "PCL.ini", "Version", text);
					}
					if (File.Exists(text2 + text + ".json"))
					{
						try
						{
							jobject["id"] = text;
							ModBase.WriteFile(text2 + text + ".json", jobject.ToString(), false, null);
						}
						catch (Exception ex2)
						{
							ModBase.Log(ex2, "重命名 Json 时失败", ModBase.LogLevel.Debug, "出现错误");
						}
					}
					ModMain.Hint("重命名成功！", ModMain.HintType.Finish, true);
					PageVersionLeft.m_OrderModel = new ModMinecraft.McVersion(text).Load();
					if (!Information.IsNothing(ModMinecraft.ValidateContainer()) && ModMinecraft.ValidateContainer().Equals(PageVersionLeft.m_OrderModel))
					{
						ModBase.WriteIni(ModMinecraft.m_ResolverIterator + "PCL.ini", "Version", text);
					}
					this.Reload();
					ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", false);
				}
			}
			catch (Exception ex3)
			{
				ModBase.Log(ex3, "重命名版本失败", ModBase.LogLevel.Msgbox, "出现错误");
			}
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x000317C0 File Offset: 0x0002F9C0
		private void BtnDisplayStar_Click(object sender, EventArgs e)
		{
			try
			{
				ModBase.WriteIni(PageVersionLeft.m_OrderModel.Path + "PCL\\Setup.ini", "IsStar", Conversions.ToString(!PageVersionLeft.m_OrderModel.m_QueueAlgo));
				PageVersionLeft.m_OrderModel = new ModMinecraft.McVersion(PageVersionLeft.m_OrderModel.Name).Load();
				this.Reload();
				ModMinecraft.m_PoolIterator = true;
				ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", false);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "版本 " + PageVersionLeft.m_OrderModel.Name + " 收藏状态更改失败", ModBase.LogLevel.Msgbox, "出现错误");
			}
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x00031880 File Offset: 0x0002FA80
		private void BtnManageCheck_Click(object sender, EventArgs e)
		{
			checked
			{
				try
				{
					PageVersionOverall._Closure$__9-0 CS$<>8__locals1 = new PageVersionOverall._Closure$__9-0(CS$<>8__locals1);
					object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
					ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
					lock (loaderTaskbarLock)
					{
						int num = ModLoader.LoaderTaskbar.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(ModLoader.LoaderTaskbar[i], null, "Name", new object[0], null, null, null), PageVersionLeft.m_OrderModel.Name + " 文件补全", true))
							{
								ModMain.Hint("正在处理中，请稍候！", ModMain.HintType.Critical, true);
								return;
							}
						}
					}
					CS$<>8__locals1.$VB$Local_Loader = new ModLoader.LoaderCombo<string>(PageVersionLeft.m_OrderModel.Name + " 文件补全", ModDownload.DlClientFix(PageVersionLeft.m_OrderModel, true, ModDownload.AssetsIndexExistsBehaviour.AlwaysDownload, false));
					CS$<>8__locals1.$VB$Local_Loader.OnStateChanged = delegate(object a0)
					{
						base._Lambda$__0();
					};
					CS$<>8__locals1.$VB$Local_Loader.Start(PageVersionLeft.m_OrderModel.Name, false);
					ModLoader.LoaderTaskbarAdd(CS$<>8__locals1.$VB$Local_Loader);
					ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
					ModMain.m_GetterFilter.BtnExtraDownload.Ribble();
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "尝试补全文件失败（" + PageVersionLeft.m_OrderModel.Name + "）", ModBase.LogLevel.Msgbox, "出现错误");
				}
			}
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x00031A10 File Offset: 0x0002FC10
		private void BtnManageDelete_Click(object sender, EventArgs e)
		{
			try
			{
				if (ModMain.MyMsgBox("你确定要删除版本 " + PageVersionLeft.m_OrderModel.Name + " 吗？该操作不可撤销！" + ((Operators.CompareString(PageVersionLeft.m_OrderModel.ManageExpression(), ModMinecraft.m_ResolverIterator, true) != 0) ? "\r\n由于该版本开启了版本隔离，删除版本时该版本对应的存档、资源包、Mod 等文件也将被一并删除！" : ""), "删除版本", "确定", "取消", "", true, true, false) == 1)
				{
					ModBase.DeleteDirectory(PageVersionLeft.m_OrderModel.Path, false);
					ModMain.Hint("版本 " + PageVersionLeft.m_OrderModel.Name + " 已删除！", ModMain.HintType.Finish, true);
					ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", false);
					ModMain.m_GetterFilter.PageBack();
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "删除版本 " + PageVersionLeft.m_OrderModel.Name + " 失败", ModBase.LogLevel.Msgbox, "出现错误");
			}
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x00005DE4 File Offset: 0x00003FE4
		private void BtnManageFolder_Click()
		{
			PageVersionOverall.OpenVersionFolder(PageVersionLeft.m_OrderModel);
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x00005DF0 File Offset: 0x00003FF0
		public static void OpenVersionFolder(ModMinecraft.McVersion Version)
		{
			ModBase.OpenExplorer("\"" + Version.Path + "\"");
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00031B10 File Offset: 0x0002FD10
		private void ComboDisplayLogo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.interpreterModel && ModAni.InsertFactory() == 0)
			{
				try
				{
					if (this.ComboDisplayLogo.SelectedItem == this.ItemDisplayLogoCustom)
					{
						string text = ModBase.SelectFile("常用图片文件(*.png;*.jpg;*.gif)|*.png;*.jpg;*.gif", "选择图片");
						if (Operators.CompareString(text, "", true) == 0)
						{
							this.Reload();
							return;
						}
						File.Delete(PageVersionLeft.m_OrderModel.Path + "PCL\\Logo.png");
						File.Copy(text, PageVersionLeft.m_OrderModel.Path + "PCL\\Logo.png");
					}
					else
					{
						File.Delete(PageVersionLeft.m_OrderModel.Path + "PCL\\Logo.png");
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "更改自定义版本图标失败（" + PageVersionLeft.m_OrderModel.Name + "）", ModBase.LogLevel.Feedback, "出现错误");
				}
				try
				{
					string text2 = Conversions.ToString(NewLateBinding.LateGet(this.ComboDisplayLogo.SelectedItem, null, "Tag", new object[0], null, null, null));
					ModBase.WriteIni(PageVersionLeft.m_OrderModel.Path + "PCL\\Setup.ini", "Logo", text2);
					ModBase.WriteIni(PageVersionLeft.m_OrderModel.Path + "PCL\\Setup.ini", "LogoCustom", Conversions.ToString(Operators.CompareString(text2, "", true) != 0));
					ModBase.WriteIni(ModMinecraft.m_ResolverIterator + "PCL.ini", "VersionCache", "");
					PageVersionLeft.m_OrderModel = new ModMinecraft.McVersion(PageVersionLeft.m_OrderModel.Name).Load();
					this.Reload();
					ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", false);
				}
				catch (Exception ex2)
				{
					ModBase.Log(ex2, "更改版本图标失败（" + PageVersionLeft.m_OrderModel.Name + "）", ModBase.LogLevel.Feedback, "出现错误");
				}
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600068C RID: 1676 RVA: 0x00005E0C File Offset: 0x0000400C
		// (set) Token: 0x0600068D RID: 1677 RVA: 0x00005E14 File Offset: 0x00004014
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600068E RID: 1678 RVA: 0x00005E1D File Offset: 0x0000401D
		// (set) Token: 0x0600068F RID: 1679 RVA: 0x00005E25 File Offset: 0x00004025
		internal virtual StackPanel PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000690 RID: 1680 RVA: 0x00005E2E File Offset: 0x0000402E
		// (set) Token: 0x06000691 RID: 1681 RVA: 0x00005E36 File Offset: 0x00004036
		internal virtual MyCard PanDisplay { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000692 RID: 1682 RVA: 0x00005E3F File Offset: 0x0000403F
		// (set) Token: 0x06000693 RID: 1683 RVA: 0x00005E47 File Offset: 0x00004047
		internal virtual Grid PanDisplayItem { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000694 RID: 1684 RVA: 0x00005E50 File Offset: 0x00004050
		// (set) Token: 0x06000695 RID: 1685 RVA: 0x00005E58 File Offset: 0x00004058
		internal virtual Grid PanDisplayIcon { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000696 RID: 1686 RVA: 0x00005E61 File Offset: 0x00004061
		// (set) Token: 0x06000697 RID: 1687 RVA: 0x00031D10 File Offset: 0x0002FF10
		internal virtual MyComboBox ComboDisplayLogo
		{
			[CompilerGenerated]
			get
			{
				return this.fieldModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SelectionChangedEventHandler value2 = new SelectionChangedEventHandler(this.ComboDisplayLogo_SelectionChanged);
				MyComboBox myComboBox = this.fieldModel;
				if (myComboBox != null)
				{
					myComboBox.SelectionChanged -= value2;
				}
				this.fieldModel = value;
				myComboBox = this.fieldModel;
				if (myComboBox != null)
				{
					myComboBox.SelectionChanged += value2;
				}
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000698 RID: 1688 RVA: 0x00005E69 File Offset: 0x00004069
		// (set) Token: 0x06000699 RID: 1689 RVA: 0x00005E71 File Offset: 0x00004071
		internal virtual MyComboBoxItem ItemDisplayLogoCustom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x0600069A RID: 1690 RVA: 0x00005E7A File Offset: 0x0000407A
		// (set) Token: 0x0600069B RID: 1691 RVA: 0x00031D54 File Offset: 0x0002FF54
		internal virtual MyComboBox ComboDisplayType
		{
			[CompilerGenerated]
			get
			{
				return this.requestModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SelectionChangedEventHandler value2 = new SelectionChangedEventHandler(this.ComboDisplayType_SelectionChanged);
				MyComboBox myComboBox = this.requestModel;
				if (myComboBox != null)
				{
					myComboBox.SelectionChanged -= value2;
				}
				this.requestModel = value;
				myComboBox = this.requestModel;
				if (myComboBox != null)
				{
					myComboBox.SelectionChanged += value2;
				}
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x0600069C RID: 1692 RVA: 0x00005E82 File Offset: 0x00004082
		// (set) Token: 0x0600069D RID: 1693 RVA: 0x00031D98 File Offset: 0x0002FF98
		internal virtual MyButton BtnDisplayRename
		{
			[CompilerGenerated]
			get
			{
				return this.poolModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnDisplayRename_Click);
				MyButton myButton = this.poolModel;
				if (myButton != null)
				{
					myButton.CancelModel(obj);
				}
				this.poolModel = value;
				myButton = this.poolModel;
				if (myButton != null)
				{
					myButton.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x0600069E RID: 1694 RVA: 0x00005E8A File Offset: 0x0000408A
		// (set) Token: 0x0600069F RID: 1695 RVA: 0x00031DDC File Offset: 0x0002FFDC
		internal virtual MyButton BtnDisplayDesc
		{
			[CompilerGenerated]
			get
			{
				return this.parserModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnDisplayDesc_Click);
				MyButton myButton = this.parserModel;
				if (myButton != null)
				{
					myButton.CancelModel(obj);
				}
				this.parserModel = value;
				myButton = this.parserModel;
				if (myButton != null)
				{
					myButton.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060006A0 RID: 1696 RVA: 0x00005E92 File Offset: 0x00004092
		// (set) Token: 0x060006A1 RID: 1697 RVA: 0x00031E20 File Offset: 0x00030020
		internal virtual MyButton BtnDisplayStar
		{
			[CompilerGenerated]
			get
			{
				return this.m_ProxyModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnDisplayStar_Click);
				MyButton proxyModel = this.m_ProxyModel;
				if (proxyModel != null)
				{
					proxyModel.CancelModel(obj);
				}
				this.m_ProxyModel = value;
				proxyModel = this.m_ProxyModel;
				if (proxyModel != null)
				{
					proxyModel.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060006A2 RID: 1698 RVA: 0x00005E9A File Offset: 0x0000409A
		// (set) Token: 0x060006A3 RID: 1699 RVA: 0x00005EA2 File Offset: 0x000040A2
		internal virtual MyCard PanManage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060006A4 RID: 1700 RVA: 0x00005EAB File Offset: 0x000040AB
		// (set) Token: 0x060006A5 RID: 1701 RVA: 0x00031E64 File Offset: 0x00030064
		internal virtual MyButton BtnManageFolder
		{
			[CompilerGenerated]
			get
			{
				return this._MerchantModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.BtnManageFolder_Click();
				};
				MyButton merchantModel = this._MerchantModel;
				if (merchantModel != null)
				{
					merchantModel.CancelModel(obj);
				}
				this._MerchantModel = value;
				merchantModel = this._MerchantModel;
				if (merchantModel != null)
				{
					merchantModel.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060006A6 RID: 1702 RVA: 0x00005EB3 File Offset: 0x000040B3
		// (set) Token: 0x060006A7 RID: 1703 RVA: 0x00031EA8 File Offset: 0x000300A8
		internal virtual MyButton BtnManageCheck
		{
			[CompilerGenerated]
			get
			{
				return this.m_EventModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnManageCheck_Click);
				MyButton eventModel = this.m_EventModel;
				if (eventModel != null)
				{
					eventModel.CancelModel(obj);
				}
				this.m_EventModel = value;
				eventModel = this.m_EventModel;
				if (eventModel != null)
				{
					eventModel.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060006A8 RID: 1704 RVA: 0x00005EBB File Offset: 0x000040BB
		// (set) Token: 0x060006A9 RID: 1705 RVA: 0x00031EEC File Offset: 0x000300EC
		internal virtual MyButton BtnManageDelete
		{
			[CompilerGenerated]
			get
			{
				return this.m_PrinterModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnManageDelete_Click);
				MyButton printerModel = this.m_PrinterModel;
				if (printerModel != null)
				{
					printerModel.CancelModel(obj);
				}
				this.m_PrinterModel = value;
				printerModel = this.m_PrinterModel;
				if (printerModel != null)
				{
					printerModel.ValidateModel(obj);
				}
			}
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x00031F30 File Offset: 0x00030130
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.productModel)
			{
				this.productModel = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pageversion/pageversionoverall.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x00031F60 File Offset: 0x00030160
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
				this.PanDisplay = (MyCard)target;
				return;
			}
			if (connectionId == 4)
			{
				this.PanDisplayItem = (Grid)target;
				return;
			}
			if (connectionId == 5)
			{
				this.PanDisplayIcon = (Grid)target;
				return;
			}
			if (connectionId == 6)
			{
				this.ComboDisplayLogo = (MyComboBox)target;
				return;
			}
			if (connectionId == 7)
			{
				this.ItemDisplayLogoCustom = (MyComboBoxItem)target;
				return;
			}
			if (connectionId == 8)
			{
				this.ComboDisplayType = (MyComboBox)target;
				return;
			}
			if (connectionId == 9)
			{
				this.BtnDisplayRename = (MyButton)target;
				return;
			}
			if (connectionId == 0xA)
			{
				this.BtnDisplayDesc = (MyButton)target;
				return;
			}
			if (connectionId == 0xB)
			{
				this.BtnDisplayStar = (MyButton)target;
				return;
			}
			if (connectionId == 0xC)
			{
				this.PanManage = (MyCard)target;
				return;
			}
			if (connectionId == 0xD)
			{
				this.BtnManageFolder = (MyButton)target;
				return;
			}
			if (connectionId == 0xE)
			{
				this.BtnManageCheck = (MyButton)target;
				return;
			}
			if (connectionId == 0xF)
			{
				this.BtnManageDelete = (MyButton)target;
				return;
			}
			this.productModel = true;
		}

		// Token: 0x0400030F RID: 783
		private bool interpreterModel;

		// Token: 0x04000310 RID: 784
		public MyListItem predicateModel;

		// Token: 0x04000311 RID: 785
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private MyScrollViewer structModel;

		// Token: 0x04000312 RID: 786
		[AccessedThroughProperty("PanMain")]
		[CompilerGenerated]
		private StackPanel _ResolverModel;

		// Token: 0x04000313 RID: 787
		[AccessedThroughProperty("PanDisplay")]
		[CompilerGenerated]
		private MyCard collectionModel;

		// Token: 0x04000314 RID: 788
		[AccessedThroughProperty("PanDisplayItem")]
		[CompilerGenerated]
		private Grid _TestsModel;

		// Token: 0x04000315 RID: 789
		[AccessedThroughProperty("PanDisplayIcon")]
		[CompilerGenerated]
		private Grid m_BroadcasterModel;

		// Token: 0x04000316 RID: 790
		[AccessedThroughProperty("ComboDisplayLogo")]
		[CompilerGenerated]
		private MyComboBox fieldModel;

		// Token: 0x04000317 RID: 791
		[AccessedThroughProperty("ItemDisplayLogoCustom")]
		[CompilerGenerated]
		private MyComboBoxItem statusModel;

		// Token: 0x04000318 RID: 792
		[AccessedThroughProperty("ComboDisplayType")]
		[CompilerGenerated]
		private MyComboBox requestModel;

		// Token: 0x04000319 RID: 793
		[CompilerGenerated]
		[AccessedThroughProperty("BtnDisplayRename")]
		private MyButton poolModel;

		// Token: 0x0400031A RID: 794
		[CompilerGenerated]
		[AccessedThroughProperty("BtnDisplayDesc")]
		private MyButton parserModel;

		// Token: 0x0400031B RID: 795
		[AccessedThroughProperty("BtnDisplayStar")]
		[CompilerGenerated]
		private MyButton m_ProxyModel;

		// Token: 0x0400031C RID: 796
		[AccessedThroughProperty("PanManage")]
		[CompilerGenerated]
		private MyCard setterModel;

		// Token: 0x0400031D RID: 797
		[CompilerGenerated]
		[AccessedThroughProperty("BtnManageFolder")]
		private MyButton _MerchantModel;

		// Token: 0x0400031E RID: 798
		[CompilerGenerated]
		[AccessedThroughProperty("BtnManageCheck")]
		private MyButton m_EventModel;

		// Token: 0x0400031F RID: 799
		[AccessedThroughProperty("BtnManageDelete")]
		[CompilerGenerated]
		private MyButton m_PrinterModel;

		// Token: 0x04000320 RID: 800
		private bool productModel;
	}
}
