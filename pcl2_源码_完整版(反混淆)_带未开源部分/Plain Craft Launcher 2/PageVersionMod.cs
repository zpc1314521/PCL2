using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using PCL.My;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x020000AE RID: 174
	[DesignerGenerated]
	public class PageVersionMod : AdornerDecorator, IComponentConnector
	{
		// Token: 0x0600063B RID: 1595 RVA: 0x0002F8B4 File Offset: 0x0002DAB4
		// Note: this type is marked as 'beforefieldinit'.
		static PageVersionMod()
		{
			PageVersionMod.callbackModel = new ModLoader.LoaderCombo<string>("Mod List UI Loader Main", new ArrayList
			{
				ModMinecraft._MerchantIterator,
				new ModLoader.LoaderTask<List<ModMinecraft.McMod>, int>("Mod List UI Loader", new ModLoader.LoaderTask<List<ModMinecraft.McMod>, int>.LoadDelegateSub(ModMinecraft.McModListLoad), null, ThreadPriority.Normal)
				{
					ProgressWeight = 0.04
				}
			});
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x00005AD7 File Offset: 0x00003CD7
		public PageVersionMod()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.PageOther_Loaded();
			};
			this._ObjectModel = false;
			this.InitializeComponent();
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x00005AFE File Offset: 0x00003CFE
		public void PageOther_Loaded()
		{
			this.PanBack.ScrollToHome();
			this.RefreshList(false);
			if (!this._ObjectModel)
			{
				this._ObjectModel = true;
				this.Load.State = PageVersionMod.callbackModel;
			}
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x0002F910 File Offset: 0x0002DB10
		public void RefreshList(bool ForceReload = false)
		{
			if (ModMinecraft._MerchantIterator.State != ModBase.LoadState.Loading)
			{
				this.PanLoad.Visibility = Visibility.Collapsed;
				this.PanLoad.Opacity = 0.0;
				this.PanBack.Visibility = Visibility.Collapsed;
				this.PanBack.Opacity = 0.0;
				this.PanEmpty.Visibility = Visibility.Collapsed;
				this.PanEmpty.Opacity = 0.0;
				if (ModLoader.LoaderFolderRun(PageVersionMod.callbackModel, PageVersionLeft.m_OrderModel.ManageExpression() + "mods\\", ForceReload ? ModLoader.LoaderFolderRunType.ForceRun : ModLoader.LoaderFolderRunType.RunOnUpdated, 0, "", false))
				{
					this.PanBack.ScrollToHome();
					this.SearchBox.Text = "";
					return;
				}
				if (ModMinecraft._MerchantIterator.Output.Count == 0)
				{
					this.PanEmpty.Visibility = Visibility.Visible;
					this.PanEmpty.Opacity = 1.0;
					return;
				}
				this.PanBack.Visibility = Visibility.Visible;
				this.PanBack.Opacity = 1.0;
			}
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x0002FA2C File Offset: 0x0002DC2C
		private void Load_State(object sender, MyLoading.MyLoadingState state)
		{
			switch (state)
			{
			case MyLoading.MyLoadingState.Run:
			case MyLoading.MyLoadingState.Error:
				this.PanLoad.Visibility = Visibility.Visible;
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaOpacity(this.PanLoad, 1.0 - this.PanLoad.Opacity, 0x96, 0, null, false),
					ModAni.AaOpacity(this.PanBack, -this.PanBack.Opacity, 0x96, 0, null, false),
					ModAni.AaOpacity(this.PanEmpty, -this.PanEmpty.Opacity, 0x96, 0, null, false),
					ModAni.AaCode(delegate
					{
						this.PanBack.Visibility = Visibility.Collapsed;
						this.PanEmpty.Visibility = Visibility.Collapsed;
					}, 0, true)
				}, "FrmVersionMod Load Switch", true);
				return;
			case MyLoading.MyLoadingState.Stop:
				if (ModMinecraft._MerchantIterator.Output.Count == 0)
				{
					this.PanEmpty.Visibility = Visibility.Visible;
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaOpacity(this.PanLoad, -this.PanLoad.Opacity, 0x96, 0, null, false),
						ModAni.AaOpacity(this.PanEmpty, 1.0 - this.PanEmpty.Opacity, 0x96, 0, null, false),
						ModAni.AaCode(delegate
						{
							this.PanLoad.Visibility = Visibility.Collapsed;
						}, 0, true)
					}, "FrmVersionMod Load Switch", true);
					return;
				}
				this.PanBack.Visibility = Visibility.Visible;
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaOpacity(this.PanLoad, -this.PanLoad.Opacity, 0x96, 0, null, false),
					ModAni.AaOpacity(this.PanBack, 1.0 - this.PanBack.Opacity, 0x96, 0, null, false),
					ModAni.AaCode(delegate
					{
						this.PanLoad.Visibility = Visibility.Collapsed;
					}, 0, true)
				}, "FrmVersionMod Load Switch", true);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x00005B31 File Offset: 0x00003D31
		private void Load_Click(object sender, MouseButtonEventArgs e)
		{
			if (PageVersionMod.callbackModel.State == ModBase.LoadState.Failed)
			{
				ModLoader.LoaderFolderRun(PageVersionMod.callbackModel, PageVersionLeft.m_OrderModel.ManageExpression() + "mods\\", ModLoader.LoaderFolderRunType.ForceRun, 0, "", false);
			}
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x0002FC30 File Offset: 0x0002DE30
		private void BtnManageOpen_Click(object sender, EventArgs e)
		{
			try
			{
				Directory.CreateDirectory(PageVersionLeft.m_OrderModel.ManageExpression() + "mods\\");
				ModBase.OpenExplorer("\"" + PageVersionLeft.m_OrderModel.ManageExpression() + "mods\\\"");
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "打开 Mods 文件夹失败", ModBase.LogLevel.Msgbox, "出现错误");
			}
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x0002FCA8 File Offset: 0x0002DEA8
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void BtnManageChange_Click(MyButton sender, EventArgs e)
		{
			bool flag = true;
			try
			{
				bool flag2 = sender.Text.Contains("禁用");
				try
				{
					foreach (ModMinecraft.McMod mcMod in ModMinecraft._MerchantIterator.Output)
					{
						string text;
						if (mcMod.State == ModMinecraft.McMod.McModState.Fine && flag2)
						{
							text = mcMod.Path + ".disabled";
						}
						else
						{
							if (mcMod.State != ModMinecraft.McMod.McModState.Disabled || flag2)
							{
								continue;
							}
							text = mcMod.Path.Substring(0, checked(mcMod.Path.Count<char>() - ".disabled".Count<char>()));
						}
						try
						{
							if (!File.Exists(mcMod.Path))
							{
								throw new FileNotFoundException("未找到文件：" + mcMod.Path);
							}
							File.Delete(text);
							Microsoft.VisualBasic.FileSystem.Rename(mcMod.Path, text);
						}
						catch (Exception ex)
						{
							ModBase.Log(ex, "全局状态改变中重命名 Mod 失败", ModBase.LogLevel.Debug, "出现错误");
							flag = false;
						}
					}
				}
				finally
				{
					List<ModMinecraft.McMod>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			catch (Exception ex2)
			{
				ModBase.Log(ex2, "改变全部 Mod 状态失败", ModBase.LogLevel.Msgbox, "出现错误");
				flag = false;
			}
			finally
			{
				if (!flag)
				{
					ModMain.Hint("由于文件被占用，部分 Mod 的状态切换失败，请尝试关闭正在运行的游戏后再试！", ModMain.HintType.Critical, true);
				}
				this.RefreshList(false);
			}
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x0002FE58 File Offset: 0x0002E058
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void Item_Click(MyListItem sender, EventArgs e)
		{
			try
			{
				ModMinecraft.McMod mcMod = (ModMinecraft.McMod)sender.Tag;
				string text = null;
				switch (mcMod.State)
				{
				case ModMinecraft.McMod.McModState.Fine:
					if (mcMod.IsPresetMod() && ModMain.MyMsgBox("该 Mod 可能为其他 Mod 的前置，如果禁用可能导致其他 Mod 无法使用。\r\n你确定要继续禁用吗？", "警告", "禁用", "取消", "", false, true, false) == 2)
					{
						return;
					}
					text = mcMod.Path + ".disabled";
					break;
				case ModMinecraft.McMod.McModState.Disabled:
					text = mcMod.Path.Substring(0, checked(mcMod.Path.Count<char>() - ".disabled".Count<char>()));
					break;
				case ModMinecraft.McMod.McModState.Unavaliable:
					ModMain.MyMsgBox("无法读取此 Mod 的信息。\r\n\r\n详细的错误信息：" + ModBase.GetString(mcMod.QueryUtils(), false, false), "Mod 读取失败", "确定", "", "", false, true, false);
					return;
				}
				try
				{
					File.Delete(text);
					Microsoft.VisualBasic.FileSystem.Rename(mcMod.Path, text);
				}
				catch (FileNotFoundException ex)
				{
					ModBase.Log(ex, "未找到理应存在的 Mod 文件（" + mcMod.Path + "）", ModBase.LogLevel.Debug, "出现错误");
					Microsoft.VisualBasic.FileSystem.Rename(text, mcMod.Path);
				}
				ModMinecraft.McMod mcMod2 = new ModMinecraft.McMod(text);
				int index = ModMinecraft._MerchantIterator.Output.IndexOf(mcMod);
				ModMinecraft._MerchantIterator.Output.RemoveAt(index);
				ModMinecraft._MerchantIterator.Output.Insert(index, mcMod2);
				StackPanel stackPanel = (StackPanel)sender.Parent;
				int index2 = stackPanel.Children.IndexOf(sender);
				stackPanel.Children.RemoveAt(index2);
				stackPanel.Children.Insert(index2, ModMinecraft.McModListItem(mcMod2));
				if (string.IsNullOrWhiteSpace(this.SearchBox.Text))
				{
					((MyCard)stackPanel.Parent).Title = ModMinecraft.McModGetTitle(ModMinecraft._MerchantIterator.Output);
					ModLoader.LoaderFolderRun(PageVersionMod.callbackModel, PageVersionLeft.m_OrderModel.ManageExpression() + "mods\\", ModLoader.LoaderFolderRunType.UpdateOnly, 0, "", false);
				}
			}
			catch (Exception ex2)
			{
				ModBase.Log(ex2, "单个状态改变中重命名 Mod 失败", ModBase.LogLevel.Debug, "出现错误");
				ModMain.Hint("切换 Mod 状态失败，请尝试关闭正在运行的游戏后再试！", ModMain.HintType.Info, true);
			}
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x000300B4 File Offset: 0x0002E2B4
		public void Delete_Click(MyIconButton sender, EventArgs e)
		{
			try
			{
				MyListItem myListItem = (MyListItem)sender.Tag;
				ModMinecraft.McMod mcMod = (ModMinecraft.McMod)myListItem.Tag;
				if (!mcMod.IsPresetMod() || ModMain.MyMsgBox("该 Mod 可能为其他 Mod 的前置，如果删除可能导致其他 Mod 无法使用。\r\n你确定要继续删除吗？", "警告", "删除", "取消", "", true, true, false) != 2)
				{
					if (File.Exists(mcMod.Path))
					{
						MyWpfExtension.RunFactory().FileSystem.DeleteFile(mcMod.Path, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
						ModMinecraft._MerchantIterator.Output.Remove(mcMod);
						StackPanel stackPanel = (StackPanel)myListItem.Parent;
						stackPanel.Children.Remove(myListItem);
						if (stackPanel.Children.Count == 0)
						{
							this.RefreshList(true);
						}
						else
						{
							((MyCard)stackPanel.Parent).Title = ModMinecraft.McModGetTitle(ModMinecraft._MerchantIterator.Output);
						}
						ModMain.Hint("已将 " + mcMod.ViewUtils() + " 删除到回收站！", ModMain.HintType.Finish, true);
						ModLoader.LoaderFolderRun(PageVersionMod.callbackModel, PageVersionLeft.m_OrderModel.ManageExpression() + "mods\\", ModLoader.LoaderFolderRunType.UpdateOnly, 0, "", false);
					}
					else
					{
						ModBase.Log("[System] 需要删除的 Mod 文件不存在（" + mcMod.Path + "）", ModBase.LogLevel.Hint, "出现错误");
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "删除 Mod 失败", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x00030234 File Offset: 0x0002E434
		public void Info_Click(object sender, EventArgs e)
		{
			checked
			{
				try
				{
					ModMinecraft.McMod mcMod = (ModMinecraft.McMod)((MyListItem)((sender is MyIconButton) ? NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) : sender)).Tag;
					List<string> list = new List<string>();
					if (mcMod.Description != null)
					{
						list.Add(mcMod.Description + "\r\n");
					}
					if (mcMod.PrepareUtils() != null)
					{
						list.Add("作者：" + mcMod.PrepareUtils());
					}
					list.Add(string.Concat(new string[]
					{
						"文件：",
						mcMod.ViewUtils(),
						"（",
						ModBase.GetString(new FileInfo(mcMod.Path).Length),
						"）"
					}));
					if (mcMod.Version != null)
					{
						list.Add("版本：" + mcMod.Version);
					}
					if (ModBase.errorRule)
					{
						List<string> list2 = new List<string>();
						if (mcMod.InvokeUtils() != null)
						{
							list2.Add("Mod ID：" + mcMod.InvokeUtils());
						}
						if (mcMod.DestroyUtils().Count > 0)
						{
							list2.Add("依赖于：");
							try
							{
								foreach (KeyValuePair<string, string> keyValuePair in mcMod.DestroyUtils())
								{
									list2.Add(" - " + keyValuePair.Key + ((keyValuePair.Value == null) ? "" : ("，版本：" + keyValuePair.Value)));
								}
							}
							finally
							{
								Dictionary<string, string>.Enumerator enumerator;
								((IDisposable)enumerator).Dispose();
							}
						}
						if (list2.Count > 0)
						{
							list.Add("\r\n—————— 调试信息 ——————");
							list.AddRange(list2);
						}
					}
					string text = mcMod.Name.Replace(" ", "+");
					string text2 = text.Substring(0, 1);
					int num = text.Count<char>() - 1;
					for (int i = 1; i <= num; i++)
					{
						bool flag = text[i - 1].ToString().ToLower().Equals(text[i - 1].ToString());
						bool flag2 = text[i].ToString().ToLower().Equals(text[i].ToString());
						if (flag && !flag2)
						{
							text2 += "+";
						}
						text2 += Conversions.ToString(text[i]);
					}
					text2 = text2.Replace("++", "+").Replace("pti+Fine", "ptiFine");
					if (mcMod.FillUtils() == null)
					{
						if (ModMain.MyMsgBox(ModBase.Join(list, "\r\n"), mcMod.Name, "确定", "百科搜索", "", false, true, false) == 2)
						{
							ModBase.OpenWebsite("https://www.mcmod.cn/s?key=" + text2 + "&site=all&filter=0");
						}
					}
					else
					{
						int num2 = ModMain.MyMsgBox(ModBase.Join(list, "\r\n"), mcMod.Name, "确定", "百科搜索", "打开官网", false, true, false);
						if (num2 != 2)
						{
							if (num2 == 3)
							{
								ModBase.OpenWebsite(mcMod.FillUtils());
							}
						}
						else
						{
							ModBase.OpenWebsite("https://www.mcmod.cn/s?key=" + text2 + "&site=all&filter=0");
						}
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "获取 Mod 详情失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x000305CC File Offset: 0x0002E7CC
		public void Open_Click(MyIconButton sender, EventArgs e)
		{
			try
			{
				ModMinecraft.McMod mcMod = (ModMinecraft.McMod)((MyListItem)sender.Tag).Tag;
				ModBase.OpenExplorer("/select,\"" + mcMod.Path + "\"");
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "打开 Mod 文件位置失败", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x0003063C File Offset: 0x0002E83C
		public void SearchRun()
		{
			if (string.IsNullOrWhiteSpace(this.SearchBox.Text))
			{
				ModLoader.LoaderFolderRun(PageVersionMod.callbackModel, PageVersionLeft.m_OrderModel.ManageExpression() + "mods\\", ModLoader.LoaderFolderRunType.RunOnUpdated, 0, "", false);
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaOpacity(this.PanSearch, -this.PanSearch.Opacity, 0x64, 0, null, false),
					ModAni.AaCode(delegate
					{
						this.PanSearch.Height = 0.0;
						this.PanList.Visibility = Visibility.Visible;
						this.PanManage.Visibility = Visibility.Visible;
					}, 0, true),
					ModAni.AaOpacity(this.PanList, 1.0 - this.PanList.Opacity, 0x96, 0x1E, null, false),
					ModAni.AaOpacity(this.PanManage, 1.0 - this.PanManage.Opacity, 0x96, 0x1E, null, false)
				}, "FrmVersionMod Search Switch", false);
				return;
			}
			List<ModBase.SearchEntry<ModMinecraft.McMod>> list = new List<ModBase.SearchEntry<ModMinecraft.McMod>>();
			try
			{
				foreach (ModMinecraft.McMod mcMod in ModMinecraft._MerchantIterator.Output)
				{
					list.Add(new ModBase.SearchEntry<ModMinecraft.McMod>
					{
						m_ParamMapper = mcMod,
						mockMapper = new List<KeyValuePair<string, double>>
						{
							new KeyValuePair<string, double>(mcMod.Name, 1.0),
							new KeyValuePair<string, double>(mcMod.ViewUtils(), 1.0),
							new KeyValuePair<string, double>(mcMod.Description ?? "", 0.5)
						}
					});
				}
			}
			finally
			{
				List<ModMinecraft.McMod>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			List<ModBase.SearchEntry<ModMinecraft.McMod>> list2 = ModBase.Search<ModMinecraft.McMod>(list, this.SearchBox.Text, 5, 0.35);
			this.PanSearchList.Children.Clear();
			if (list2.Count == 0)
			{
				this.PanSearch.Title = "无搜索结果";
				this.PanSearchList.Visibility = Visibility.Collapsed;
			}
			else
			{
				this.PanSearch.Title = "搜索结果";
				try
				{
					foreach (ModBase.SearchEntry<ModMinecraft.McMod> searchEntry in list2)
					{
						MyListItem myListItem = ModMinecraft.McModListItem(searchEntry.m_ParamMapper);
						if (ModBase.errorRule)
						{
							myListItem.Info = string.Concat(new string[]
							{
								searchEntry.m_DicMapper ? "完全匹配，" : "",
								"相似度：",
								Conversions.ToString(Math.Round(searchEntry.specificationMapper, 3)),
								"，",
								myListItem.Info
							});
						}
						this.PanSearchList.Children.Add(myListItem);
					}
				}
				finally
				{
					List<ModBase.SearchEntry<ModMinecraft.McMod>>.Enumerator enumerator2;
					((IDisposable)enumerator2).Dispose();
				}
				this.PanSearchList.Visibility = Visibility.Visible;
			}
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.PanList, -this.PanList.Opacity, 0x64, 0, null, false),
				ModAni.AaOpacity(this.PanManage, -this.PanManage.Opacity, 0x64, 0, null, false),
				ModAni.AaCode(delegate
				{
					this.PanList.Visibility = Visibility.Collapsed;
					this.PanManage.Visibility = Visibility.Collapsed;
					this.PanSearch.Visibility = Visibility.Visible;
					this.PanSearch.TriggerForceResize();
				}, 0, true),
				ModAni.AaOpacity(this.PanSearch, 1.0 - this.PanSearch.Opacity, 0x96, 0x1E, null, false)
			}, "FrmVersionMod Search Switch", false);
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000648 RID: 1608 RVA: 0x00005B67 File Offset: 0x00003D67
		// (set) Token: 0x06000649 RID: 1609 RVA: 0x00005B6F File Offset: 0x00003D6F
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600064A RID: 1610 RVA: 0x00005B78 File Offset: 0x00003D78
		// (set) Token: 0x0600064B RID: 1611 RVA: 0x00005B80 File Offset: 0x00003D80
		internal virtual StackPanel PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x0600064C RID: 1612 RVA: 0x00005B89 File Offset: 0x00003D89
		// (set) Token: 0x0600064D RID: 1613 RVA: 0x000309C8 File Offset: 0x0002EBC8
		internal virtual MySearchBox SearchBox
		{
			[CompilerGenerated]
			get
			{
				return this._IndexerModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MySearchBox.TextChangedEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.SearchRun();
				};
				MySearchBox indexerModel = this._IndexerModel;
				if (indexerModel != null)
				{
					indexerModel.VisitVal(obj);
				}
				this._IndexerModel = value;
				indexerModel = this._IndexerModel;
				if (indexerModel != null)
				{
					indexerModel.MapVal(obj);
				}
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x0600064E RID: 1614 RVA: 0x00005B91 File Offset: 0x00003D91
		// (set) Token: 0x0600064F RID: 1615 RVA: 0x00005B99 File Offset: 0x00003D99
		internal virtual MyCard PanManage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000650 RID: 1616 RVA: 0x00005BA2 File Offset: 0x00003DA2
		// (set) Token: 0x06000651 RID: 1617 RVA: 0x00030A0C File Offset: 0x0002EC0C
		internal virtual MyButton BtnManageOpen
		{
			[CompilerGenerated]
			get
			{
				return this.m_DatabaseModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnManageOpen_Click);
				MyButton databaseModel = this.m_DatabaseModel;
				if (databaseModel != null)
				{
					databaseModel.CancelModel(obj);
				}
				this.m_DatabaseModel = value;
				databaseModel = this.m_DatabaseModel;
				if (databaseModel != null)
				{
					databaseModel.ValidateModel(obj);
				}
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000652 RID: 1618 RVA: 0x00005BAA File Offset: 0x00003DAA
		// (set) Token: 0x06000653 RID: 1619 RVA: 0x00030A50 File Offset: 0x0002EC50
		internal virtual MyButton BtnManageEnabled
		{
			[CompilerGenerated]
			get
			{
				return this.attrModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.BtnManageChange_Click((MyButton)sender, e);
				};
				MyButton myButton = this.attrModel;
				if (myButton != null)
				{
					myButton.CancelModel(obj);
				}
				this.attrModel = value;
				myButton = this.attrModel;
				if (myButton != null)
				{
					myButton.ValidateModel(obj);
				}
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000654 RID: 1620 RVA: 0x00005BB2 File Offset: 0x00003DB2
		// (set) Token: 0x06000655 RID: 1621 RVA: 0x00030A94 File Offset: 0x0002EC94
		internal virtual MyButton BtnManageDisabled
		{
			[CompilerGenerated]
			get
			{
				return this.threadModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.BtnManageChange_Click((MyButton)sender, e);
				};
				MyButton myButton = this.threadModel;
				if (myButton != null)
				{
					myButton.CancelModel(obj);
				}
				this.threadModel = value;
				myButton = this.threadModel;
				if (myButton != null)
				{
					myButton.ValidateModel(obj);
				}
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000656 RID: 1622 RVA: 0x00005BBA File Offset: 0x00003DBA
		// (set) Token: 0x06000657 RID: 1623 RVA: 0x00005BC2 File Offset: 0x00003DC2
		internal virtual MyButton BtnManageCheck { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000658 RID: 1624 RVA: 0x00005BCB File Offset: 0x00003DCB
		// (set) Token: 0x06000659 RID: 1625 RVA: 0x00005BD3 File Offset: 0x00003DD3
		internal virtual MyCard PanSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600065A RID: 1626 RVA: 0x00005BDC File Offset: 0x00003DDC
		// (set) Token: 0x0600065B RID: 1627 RVA: 0x00005BE4 File Offset: 0x00003DE4
		internal virtual StackPanel PanSearchList { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x0600065C RID: 1628 RVA: 0x00005BED File Offset: 0x00003DED
		// (set) Token: 0x0600065D RID: 1629 RVA: 0x00005BF5 File Offset: 0x00003DF5
		internal virtual StackPanel PanList { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x0600065E RID: 1630 RVA: 0x00005BFE File Offset: 0x00003DFE
		// (set) Token: 0x0600065F RID: 1631 RVA: 0x00005C06 File Offset: 0x00003E06
		internal virtual MyCard PanLoad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000660 RID: 1632 RVA: 0x00005C0F File Offset: 0x00003E0F
		// (set) Token: 0x06000661 RID: 1633 RVA: 0x00030AD8 File Offset: 0x0002ECD8
		internal virtual MyLoading Load
		{
			[CompilerGenerated]
			get
			{
				return this.systemModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyLoading.StateChangedEventHandler obj = new MyLoading.StateChangedEventHandler(this.Load_State);
				MyLoading.ClickEventHandler obj2 = new MyLoading.ClickEventHandler(this.Load_Click);
				MyLoading myLoading = this.systemModel;
				if (myLoading != null)
				{
					myLoading.InitVal(obj);
					myLoading.UpdateVal(obj2);
				}
				this.systemModel = value;
				myLoading = this.systemModel;
				if (myLoading != null)
				{
					myLoading.FillVal(obj);
					myLoading.PrepareVal(obj2);
				}
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x00005C17 File Offset: 0x00003E17
		// (set) Token: 0x06000663 RID: 1635 RVA: 0x00005C1F File Offset: 0x00003E1F
		internal virtual MyCard PanEmpty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x00005C28 File Offset: 0x00003E28
		// (set) Token: 0x06000665 RID: 1637 RVA: 0x00030B38 File Offset: 0x0002ED38
		internal virtual MyButton BtnHintOpen
		{
			[CompilerGenerated]
			get
			{
				return this.m_PrototypeModel;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnManageOpen_Click);
				MyButton prototypeModel = this.m_PrototypeModel;
				if (prototypeModel != null)
				{
					prototypeModel.CancelModel(obj);
				}
				this.m_PrototypeModel = value;
				prototypeModel = this.m_PrototypeModel;
				if (prototypeModel != null)
				{
					prototypeModel.ValidateModel(obj);
				}
			}
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x00030B7C File Offset: 0x0002ED7C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this._RefModel)
			{
				this._RefModel = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pageversion/pageversionmod.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x00030BAC File Offset: 0x0002EDAC
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
				this.SearchBox = (MySearchBox)target;
				return;
			}
			if (connectionId == 4)
			{
				this.PanManage = (MyCard)target;
				return;
			}
			if (connectionId == 5)
			{
				this.BtnManageOpen = (MyButton)target;
				return;
			}
			if (connectionId == 6)
			{
				this.BtnManageEnabled = (MyButton)target;
				return;
			}
			if (connectionId == 7)
			{
				this.BtnManageDisabled = (MyButton)target;
				return;
			}
			if (connectionId == 8)
			{
				this.BtnManageCheck = (MyButton)target;
				return;
			}
			if (connectionId == 9)
			{
				this.PanSearch = (MyCard)target;
				return;
			}
			if (connectionId == 0xA)
			{
				this.PanSearchList = (StackPanel)target;
				return;
			}
			if (connectionId == 0xB)
			{
				this.PanList = (StackPanel)target;
				return;
			}
			if (connectionId == 0xC)
			{
				this.PanLoad = (MyCard)target;
				return;
			}
			if (connectionId == 0xD)
			{
				this.Load = (MyLoading)target;
				return;
			}
			if (connectionId == 0xE)
			{
				this.PanEmpty = (MyCard)target;
				return;
			}
			if (connectionId == 0xF)
			{
				this.BtnHintOpen = (MyButton)target;
				return;
			}
			this._RefModel = true;
		}

		// Token: 0x040002F9 RID: 761
		private bool _ObjectModel;

		// Token: 0x040002FA RID: 762
		public static ModLoader.LoaderCombo<string> callbackModel;

		// Token: 0x040002FB RID: 763
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private MyScrollViewer m_WorkerModel;

		// Token: 0x040002FC RID: 764
		[CompilerGenerated]
		[AccessedThroughProperty("PanMain")]
		private StackPanel visitorModel;

		// Token: 0x040002FD RID: 765
		[AccessedThroughProperty("SearchBox")]
		[CompilerGenerated]
		private MySearchBox _IndexerModel;

		// Token: 0x040002FE RID: 766
		[AccessedThroughProperty("PanManage")]
		[CompilerGenerated]
		private MyCard _MethodModel;

		// Token: 0x040002FF RID: 767
		[AccessedThroughProperty("BtnManageOpen")]
		[CompilerGenerated]
		private MyButton m_DatabaseModel;

		// Token: 0x04000300 RID: 768
		[CompilerGenerated]
		[AccessedThroughProperty("BtnManageEnabled")]
		private MyButton attrModel;

		// Token: 0x04000301 RID: 769
		[AccessedThroughProperty("BtnManageDisabled")]
		[CompilerGenerated]
		private MyButton threadModel;

		// Token: 0x04000302 RID: 770
		[AccessedThroughProperty("BtnManageCheck")]
		[CompilerGenerated]
		private MyButton managerModel;

		// Token: 0x04000303 RID: 771
		[AccessedThroughProperty("PanSearch")]
		[CompilerGenerated]
		private MyCard itemModel;

		// Token: 0x04000304 RID: 772
		[AccessedThroughProperty("PanSearchList")]
		[CompilerGenerated]
		private StackPanel serializerModel;

		// Token: 0x04000305 RID: 773
		[AccessedThroughProperty("PanList")]
		[CompilerGenerated]
		private StackPanel infoModel;

		// Token: 0x04000306 RID: 774
		[AccessedThroughProperty("PanLoad")]
		[CompilerGenerated]
		private MyCard _RepositoryModel;

		// Token: 0x04000307 RID: 775
		[AccessedThroughProperty("Load")]
		[CompilerGenerated]
		private MyLoading systemModel;

		// Token: 0x04000308 RID: 776
		[CompilerGenerated]
		[AccessedThroughProperty("PanEmpty")]
		private MyCard _ProccesorModel;

		// Token: 0x04000309 RID: 777
		[CompilerGenerated]
		[AccessedThroughProperty("BtnHintOpen")]
		private MyButton m_PrototypeModel;

		// Token: 0x0400030A RID: 778
		private bool _RefModel;
	}
}
