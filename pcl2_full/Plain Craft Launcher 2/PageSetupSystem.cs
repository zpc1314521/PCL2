using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x02000155 RID: 341
	[DesignerGenerated]
	public class PageSetupSystem : AdornerDecorator, IComponentConnector
	{
		// Token: 0x06000D8B RID: 3467 RVA: 0x000094C5 File Offset: 0x000076C5
		public PageSetupSystem()
		{
			base.Loaded += this.PageSetupSystem_Loaded;
			this._ParamUtils = false;
			this.mockUtils = false;
			this.specificationUtils = false;
			this.InitializeComponent();
		}

		// Token: 0x06000D8C RID: 3468 RVA: 0x0006B724 File Offset: 0x00069924
		private void PageSetupSystem_Loaded(object sender, RoutedEventArgs e)
		{
			this.PanBack.ScrollToHome();
			this.ItemSystemUpdateDownload.Content = "在有新版本时自动下载（更新快照版可能需要更新密钥）";
			checked
			{
				if (!this._ParamUtils)
				{
					this._ParamUtils = true;
					ModAni.ListFactory(ModAni.InsertFactory() + 1);
					this.Reload();
					this.SliderLoad();
					ModAni.ListFactory(ModAni.InsertFactory() - 1);
				}
			}
		}

		// Token: 0x06000D8D RID: 3469 RVA: 0x0006B780 File Offset: 0x00069980
		public void Reload()
		{
			this.SliderDownloadThread.Value = Conversions.ToInteger(ModBase._BaseRule.Get("ToolDownloadThread", null));
			this.SliderDownloadSpeed.Value = Conversions.ToInteger(ModBase._BaseRule.Get("ToolDownloadSpeed", null));
			this.ComboDownloadVersion.SelectedIndex = Conversions.ToInteger(ModBase._BaseRule.Get("ToolDownloadVersion", null));
			this.CheckUpdateRelease.Checked = Conversions.ToBoolean(ModBase._BaseRule.Get("ToolUpdateRelease", null));
			this.CheckUpdateSnapshot.Checked = Conversions.ToBoolean(ModBase._BaseRule.Get("ToolUpdateSnapshot", null));
			this.CheckHelpChinese.Checked = Conversions.ToBoolean(ModBase._BaseRule.Get("ToolHelpChinese", null));
			this.ComboSystemUpdate.SelectedIndex = Conversions.ToInteger(ModBase._BaseRule.Get("SystemSystemUpdate", null));
			this.ComboSystemActivity.SelectedIndex = Conversions.ToInteger(ModBase._BaseRule.Get("SystemSystemActivity", null));
			this.TextSystemCache.Text = Conversions.ToString(ModBase._BaseRule.Get("SystemSystemCache", null));
			this.CheckDebugMode.Checked = Conversions.ToBoolean(ModBase._BaseRule.Get("SystemDebugMode", null));
			this.SliderDebugAnim.Value = Conversions.ToInteger(ModBase._BaseRule.Get("SystemDebugAnim", null));
			this.CheckDebugDelay.Checked = Conversions.ToBoolean(ModBase._BaseRule.Get("SystemDebugDelay", null));
			this.CheckDebugSkipCopy.Checked = Conversions.ToBoolean(ModBase._BaseRule.Get("SystemDebugSkipCopy", null));
		}

		// Token: 0x06000D8E RID: 3470 RVA: 0x0006B930 File Offset: 0x00069B30
		public void Reset()
		{
			try
			{
				ModBase._BaseRule.Reset("ToolDownloadThread", false, null);
				ModBase._BaseRule.Reset("ToolDownloadSpeed", false, null);
				ModBase._BaseRule.Reset("ToolDownloadVersion", false, null);
				ModBase._BaseRule.Reset("ToolUpdateRelease", false, null);
				ModBase._BaseRule.Reset("ToolUpdateSnapshot", false, null);
				ModBase._BaseRule.Reset("ToolHelpChinese", false, null);
				ModBase._BaseRule.Reset("SystemDebugMode", false, null);
				ModBase._BaseRule.Reset("SystemDebugAnim", false, null);
				ModBase._BaseRule.Reset("SystemDebugDelay", false, null);
				ModBase._BaseRule.Reset("SystemDebugSkipCopy", false, null);
				ModBase._BaseRule.Reset("SystemSystemCache", false, null);
				ModBase._BaseRule.Reset("SystemSystemUpdate", false, null);
				ModBase._BaseRule.Reset("SystemSystemActivity", false, null);
				ModBase.Log("[Setup] 已初始化启动器页设置", ModBase.LogLevel.Normal, "出现错误");
				ModMain.Hint("已初始化启动器页设置！", ModMain.HintType.Finish, false);
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "初始化启动器页设置失败", ModBase.LogLevel.Msgbox, "出现错误");
			}
			this.Reload();
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x000091C6 File Offset: 0x000073C6
		private static void CheckBoxChange(MyCheckBox sender, object e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set(Conversions.ToString(sender.Tag), sender.Checked, false, null);
			}
		}

		// Token: 0x06000D90 RID: 3472 RVA: 0x00009170 File Offset: 0x00007370
		private static void SliderChange(MySlider sender, object e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set(Conversions.ToString(sender.Tag), sender.Value, false, null);
			}
		}

		// Token: 0x06000D91 RID: 3473 RVA: 0x0000919B File Offset: 0x0000739B
		private static void ComboChange(MyComboBox sender, object e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set(Conversions.ToString(sender.Tag), sender.SelectedIndex, false, null);
			}
		}

		// Token: 0x06000D92 RID: 3474 RVA: 0x0000914A File Offset: 0x0000734A
		private static void TextBoxChange(MyTextBox sender, object e)
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModBase._BaseRule.Set(Conversions.ToString(sender.Tag), sender.Text, false, null);
			}
		}

		// Token: 0x06000D93 RID: 3475 RVA: 0x0006BA70 File Offset: 0x00069C70
		private void SliderLoad()
		{
			this.SliderDownloadThread._AdapterDecorator = ((PageSetupSystem._Closure$__.$I9-0 == null) ? (PageSetupSystem._Closure$__.$I9-0 = ((int Value) => checked(Value + 1))) : PageSetupSystem._Closure$__.$I9-0);
			this.SliderDownloadSpeed._AdapterDecorator = ((PageSetupSystem._Closure$__.$I9-1 == null) ? (PageSetupSystem._Closure$__.$I9-1 = delegate(int Value)
			{
				string result;
				if (Value <= 0xE)
				{
					result = Conversions.ToString((double)(checked(Value + 1)) * 0.1) + " M/s";
				}
				else if (Value <= 0x1F)
				{
					result = Conversions.ToString((double)(checked(Value - 0xB)) * 0.5) + " M/s";
				}
				else if (Value <= 0x29)
				{
					result = Conversions.ToString(checked(Value - 0x15)) + " M/s";
				}
				else
				{
					result = "无限制";
				}
				return result;
			}) : PageSetupSystem._Closure$__.$I9-1);
			this.SliderDebugAnim._AdapterDecorator = ((PageSetupSystem._Closure$__.$I9-2 == null) ? (PageSetupSystem._Closure$__.$I9-2 = delegate(int Value)
			{
				if (Value <= 0x1D)
				{
					return Conversions.ToString((double)Value / 10.0 + 0.1) + "x";
				}
				return "关闭";
			}) : PageSetupSystem._Closure$__.$I9-2);
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x0006BB0C File Offset: 0x00069D0C
		private void SliderDownloadThread_PreviewChange(object sender, ModBase.RouteEventArgs e)
		{
			if (this.SliderDownloadThread.Value >= 0x64 && Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("HintDownloadThread", null))))
			{
				ModBase._BaseRule.Set("HintDownloadThread", true, false, null);
				ModMain.MyMsgBox("如果设置过多的下载线程，可能会导致下载时出现非常严重的卡顿。\r\n一般设置 64 线程即可满足大多数下载需求，除非你知道你在干什么，否则不建议设置更多的线程数！", "警告", "我知道了", "", "", true, true, false);
			}
		}

		// Token: 0x06000D95 RID: 3477 RVA: 0x000094FA File Offset: 0x000076FA
		private void CheckDebugMode_Change()
		{
			if (ModAni.InsertFactory() == 0)
			{
				ModMain.Hint("部分调试信息将在刷新或启动器重启后切换显示！", ModMain.HintType.Info, false);
			}
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x0006BB80 File Offset: 0x00069D80
		private void BtnSystemCacheClear_Click(object sender, EventArgs e)
		{
			if (ModNet.HasDownloadingTask(false))
			{
				ModMain.Hint("请在所有下载任务完成后再清理缓存！", ModMain.HintType.Critical, true);
				return;
			}
			if (ModMain.MyMsgBox("你确定要清理缓存吗？\r\n在清理缓存后，PCL2 会被强制关闭，以避免缓存缺失带来的异常。", "清理缓存", "确定", "取消", "", false, true, false) != 2 && !this.mockUtils)
			{
				this.mockUtils = true;
				try
				{
					ulong num = this.DeleteCacheDirectory(ModBase.m_GlobalRule, 0UL);
					if (decimal.Compare(new decimal(num), 0m) <= 0)
					{
						ModMain.Hint("没有可清理的缓存！", ModMain.HintType.Info, true);
					}
					else
					{
						ModMain.MyMsgBox("已清理 " + ModBase.GetString(checked((long)num)) + " 缓存！\r\nPCL2 即将自动关闭。", "缓存已清理", "确定", "", "", false, true, true);
						ModMain.m_GetterFilter.EndProgram(false);
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "清理缓存失败", ModBase.LogLevel.Hint, "出现错误");
				}
				finally
				{
					this.mockUtils = false;
				}
			}
		}

		// Token: 0x06000D97 RID: 3479 RVA: 0x0006BC94 File Offset: 0x00069E94
		private ulong DeleteCacheDirectory(string Path, ulong TotalSize = 0UL)
		{
			checked
			{
				ulong result;
				if (!Directory.Exists(Path))
				{
					result = TotalSize;
				}
				else
				{
					foreach (string text in Directory.GetFiles(Path))
					{
						try
						{
							FileInfo fileInfo = new FileInfo(text);
							double num = unchecked(Math.Ceiling((double)fileInfo.Length / 4096.0) * 4096.0);
							fileInfo.Delete();
							TotalSize = (ulong)Math.Round(unchecked(TotalSize + num));
						}
						catch (Exception ex)
						{
							ModBase.Log(ex, "删除失败的缓存文件（" + text + "）", ModBase.LogLevel.Debug, "出现错误");
						}
					}
					foreach (string path in Directory.GetDirectories(Path))
					{
						TotalSize += this.DeleteCacheDirectory(path, 0UL);
					}
					result = TotalSize;
				}
				return result;
			}
		}

		// Token: 0x06000D98 RID: 3480 RVA: 0x0006BD7C File Offset: 0x00069F7C
		private void ComboSystemActivity_SizeChanged(object sender, SelectionChangedEventArgs e)
		{
			if (ModAni.InsertFactory() == 0 && this.ComboSystemActivity.SelectedIndex == 2 && ModMain.MyMsgBox("若选择此项，即使在将来出现严重问题时，你也无法获取相关通知。\r\n例如，如果发现某个版本游戏存在严重 Bug，你可能就会因为无法得到通知而导致无法预知的后果。\r\n\r\n一般选择 仅在有重要通知时显示公告 就可以让你尽量不受打扰了。\r\n除非你在制作服务器整合包，或时常手动更新启动器，否则极度不推荐选择此项！", "警告", "继续", "取消", "", false, true, false) == 2)
			{
				this.ComboSystemActivity.SelectedItem = RuntimeHelpers.GetObjectValue(e.RemovedItems[0]);
			}
		}

		// Token: 0x06000D99 RID: 3481 RVA: 0x0006BDE0 File Offset: 0x00069FE0
		private void ComboSystemUpdate_SizeChanged(object sender, SelectionChangedEventArgs e)
		{
			if (ModAni.InsertFactory() == 0 && this.ComboSystemUpdate.SelectedIndex == 3 && ModMain.MyMsgBox("若选择此项，即使在启动器将来出现严重问题时，你也无法获取更新并获得修复。\r\n例如，如果官方修改了登录方式，从而导致现有启动器无法登录，你可能就会因为无法更新而无法开始游戏。\r\n\r\n一般选择 仅在有重大漏洞更新时显示提示 就可以让你尽量不受打扰了。\r\n除非你在制作服务器整合包，或时常手动更新启动器，否则极度不推荐选择此项！", "警告", "继续", "取消", "", false, true, false) == 2)
			{
				this.ComboSystemUpdate.SelectedItem = RuntimeHelpers.GetObjectValue(e.RemovedItems[0]);
			}
		}

		// Token: 0x06000D9A RID: 3482 RVA: 0x0000950F File Offset: 0x0000770F
		private void BtnSystemUpdate_Click(object sender, EventArgs e)
		{
			if (!this.specificationUtils)
			{
				this.specificationUtils = true;
				ModBase.RunInThread(delegate
				{
					try
					{
						bool? flag = PageSetupSystem.IsLauncherNewest();
						if (flag == null)
						{
							ModMain.Hint("连接 PCL2 服务器失败，请确认系统时间与北京时间一致，或尝试关闭杀毒软件，然后重启 PCL2 再试！", ModMain.HintType.Critical, true);
						}
						else if (flag.GetValueOrDefault())
						{
							ModMain.Hint("当前启动器已为最新版！", ModMain.HintType.Finish, true);
						}
						else
						{
							ModMain.Hint("正在检查更新，请稍候！", ModMain.HintType.Info, true);
							if (!ModMain.CanSkipUpdateMark())
							{
								if (ModMain.MyMsgBox("发现了启动器更新！\r\n请在 PCL2 内群中发送 .更新 以获取你的更新密钥。", "启动器更新", "输入更新密钥", "取消", "", false, true, false) != 2)
								{
									string text = ModMain.MyMsgBoxInput("", new Collection<Validate>
									{
										new ValidateNullOrWhiteSpace()
									}, "输入更新密钥", "下载 PCL2 更新", "确定", "取消", false);
									if (text != null)
									{
										ModMain.UpdateStart("http://pcl2-server-1253424809.file.myqcloud.com/update/{KEY}.zip{CDN}", false, text, false);
									}
								}
							}
							else if (ModMain.MyMsgBox("发现了启动器更新，是否下载？", "启动器更新", "确定", "取消", "", false, true, false) != 2)
							{
								ModMain.UpdateStart("http://pcl2-server-1253424809.file.myqcloud.com/update/{KEY}.zip{CDN}", false, null, false);
							}
						}
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "尝试手动开始更新失败", ModBase.LogLevel.Feedback, "出现错误");
					}
					finally
					{
						this.specificationUtils = false;
					}
				});
			}
		}

		// Token: 0x06000D9B RID: 3483 RVA: 0x0006BE44 File Offset: 0x0006A044
		public static bool? IsLauncherNewest()
		{
			bool? result;
			try
			{
				string text = ModBase.ReadFile(ModBase.m_GlobalRule + "Cache\\Notice.cfg");
				if (text.Split(new char[]
				{
					'|'
				}).Count<string>() < 3)
				{
					result = null;
				}
				else
				{
					int num = Conversions.ToInteger(text.Split(new char[]
					{
						'|'
					})[1]);
					result = new bool?(num <= 0xEA);
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "确认启动器更新失败", ModBase.LogLevel.Feedback, "出现错误");
				result = null;
			}
			return result;
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000D9C RID: 3484 RVA: 0x00009531 File Offset: 0x00007731
		// (set) Token: 0x06000D9D RID: 3485 RVA: 0x00009539 File Offset: 0x00007739
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000D9E RID: 3486 RVA: 0x00009542 File Offset: 0x00007742
		// (set) Token: 0x06000D9F RID: 3487 RVA: 0x0000954A File Offset: 0x0000774A
		internal virtual StackPanel PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000DA0 RID: 3488 RVA: 0x00009553 File Offset: 0x00007753
		// (set) Token: 0x06000DA1 RID: 3489 RVA: 0x0006BEF0 File Offset: 0x0006A0F0
		internal virtual MyComboBox ComboDownloadVersion
		{
			[CompilerGenerated]
			get
			{
				return this._HelperUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SelectionChangedEventHandler value2 = (PageSetupSystem._Closure$__.$IR30-1 == null) ? (PageSetupSystem._Closure$__.$IR30-1 = delegate(object sender, SelectionChangedEventArgs e)
				{
					PageSetupSystem.ComboChange((MyComboBox)sender, e);
				}) : PageSetupSystem._Closure$__.$IR30-1;
				MyComboBox helperUtils = this._HelperUtils;
				if (helperUtils != null)
				{
					helperUtils.SelectionChanged -= value2;
				}
				this._HelperUtils = value;
				helperUtils = this._HelperUtils;
				if (helperUtils != null)
				{
					helperUtils.SelectionChanged += value2;
				}
			}
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000DA2 RID: 3490 RVA: 0x0000955B File Offset: 0x0000775B
		// (set) Token: 0x06000DA3 RID: 3491 RVA: 0x0006BF4C File Offset: 0x0006A14C
		internal virtual MySlider SliderDownloadThread
		{
			[CompilerGenerated]
			get
			{
				return this._ConsumerUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MySlider.ChangeEventHandler obj = (PageSetupSystem._Closure$__.$IR34-2 == null) ? (PageSetupSystem._Closure$__.$IR34-2 = delegate(object a0, bool a1)
				{
					PageSetupSystem.SliderChange((MySlider)a0, a1);
				}) : PageSetupSystem._Closure$__.$IR34-2;
				MySlider.PreviewChangeEventHandler obj2 = new MySlider.PreviewChangeEventHandler(this.SliderDownloadThread_PreviewChange);
				MySlider consumerUtils = this._ConsumerUtils;
				if (consumerUtils != null)
				{
					consumerUtils.InstantiateIterator(obj);
					consumerUtils.RegisterIterator(obj2);
				}
				this._ConsumerUtils = value;
				consumerUtils = this._ConsumerUtils;
				if (consumerUtils != null)
				{
					consumerUtils.InterruptIterator(obj);
					consumerUtils.InitIterator(obj2);
				}
			}
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000DA4 RID: 3492 RVA: 0x00009563 File Offset: 0x00007763
		// (set) Token: 0x06000DA5 RID: 3493 RVA: 0x0006BFC4 File Offset: 0x0006A1C4
		internal virtual MySlider SliderDownloadSpeed
		{
			[CompilerGenerated]
			get
			{
				return this._QueueUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MySlider.ChangeEventHandler obj = (PageSetupSystem._Closure$__.$IR38-3 == null) ? (PageSetupSystem._Closure$__.$IR38-3 = delegate(object a0, bool a1)
				{
					PageSetupSystem.SliderChange((MySlider)a0, a1);
				}) : PageSetupSystem._Closure$__.$IR38-3;
				MySlider queueUtils = this._QueueUtils;
				if (queueUtils != null)
				{
					queueUtils.InstantiateIterator(obj);
				}
				this._QueueUtils = value;
				queueUtils = this._QueueUtils;
				if (queueUtils != null)
				{
					queueUtils.InterruptIterator(obj);
				}
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000DA6 RID: 3494 RVA: 0x0000956B File Offset: 0x0000776B
		// (set) Token: 0x06000DA7 RID: 3495 RVA: 0x0006C020 File Offset: 0x0006A220
		internal virtual MyCheckBox CheckUpdateRelease
		{
			[CompilerGenerated]
			get
			{
				return this.m_ProducerUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyCheckBox.ChangeEventHandler obj = (PageSetupSystem._Closure$__.$IR42-4 == null) ? (PageSetupSystem._Closure$__.$IR42-4 = delegate(object a0, bool a1)
				{
					PageSetupSystem.CheckBoxChange((MyCheckBox)a0, a1);
				}) : PageSetupSystem._Closure$__.$IR42-4;
				MyCheckBox producerUtils = this.m_ProducerUtils;
				if (producerUtils != null)
				{
					producerUtils.SearchIterator(obj);
				}
				this.m_ProducerUtils = value;
				producerUtils = this.m_ProducerUtils;
				if (producerUtils != null)
				{
					producerUtils.RunIterator(obj);
				}
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000DA8 RID: 3496 RVA: 0x00009573 File Offset: 0x00007773
		// (set) Token: 0x06000DA9 RID: 3497 RVA: 0x0006C07C File Offset: 0x0006A27C
		internal virtual MyCheckBox CheckUpdateSnapshot
		{
			[CompilerGenerated]
			get
			{
				return this.exceptionUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyCheckBox.ChangeEventHandler obj = (PageSetupSystem._Closure$__.$IR46-5 == null) ? (PageSetupSystem._Closure$__.$IR46-5 = delegate(object a0, bool a1)
				{
					PageSetupSystem.CheckBoxChange((MyCheckBox)a0, a1);
				}) : PageSetupSystem._Closure$__.$IR46-5;
				MyCheckBox myCheckBox = this.exceptionUtils;
				if (myCheckBox != null)
				{
					myCheckBox.SearchIterator(obj);
				}
				this.exceptionUtils = value;
				myCheckBox = this.exceptionUtils;
				if (myCheckBox != null)
				{
					myCheckBox.RunIterator(obj);
				}
			}
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000DAA RID: 3498 RVA: 0x0000957B File Offset: 0x0000777B
		// (set) Token: 0x06000DAB RID: 3499 RVA: 0x0006C0D8 File Offset: 0x0006A2D8
		internal virtual MyCheckBox CheckHelpChinese
		{
			[CompilerGenerated]
			get
			{
				return this._RulesUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyCheckBox.ChangeEventHandler obj = (PageSetupSystem._Closure$__.$IR50-6 == null) ? (PageSetupSystem._Closure$__.$IR50-6 = delegate(object a0, bool a1)
				{
					PageSetupSystem.CheckBoxChange((MyCheckBox)a0, a1);
				}) : PageSetupSystem._Closure$__.$IR50-6;
				MyCheckBox rulesUtils = this._RulesUtils;
				if (rulesUtils != null)
				{
					rulesUtils.SearchIterator(obj);
				}
				this._RulesUtils = value;
				rulesUtils = this._RulesUtils;
				if (rulesUtils != null)
				{
					rulesUtils.RunIterator(obj);
				}
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000DAC RID: 3500 RVA: 0x00009583 File Offset: 0x00007783
		// (set) Token: 0x06000DAD RID: 3501 RVA: 0x0006C134 File Offset: 0x0006A334
		internal virtual MyComboBox ComboSystemUpdate
		{
			[CompilerGenerated]
			get
			{
				return this._ClassUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SelectionChangedEventHandler value2 = (PageSetupSystem._Closure$__.$IR54-7 == null) ? (PageSetupSystem._Closure$__.$IR54-7 = delegate(object sender, SelectionChangedEventArgs e)
				{
					PageSetupSystem.ComboChange((MyComboBox)sender, e);
				}) : PageSetupSystem._Closure$__.$IR54-7;
				SelectionChangedEventHandler value3 = new SelectionChangedEventHandler(this.ComboSystemUpdate_SizeChanged);
				MyComboBox classUtils = this._ClassUtils;
				if (classUtils != null)
				{
					classUtils.SelectionChanged -= value2;
					classUtils.SelectionChanged -= value3;
				}
				this._ClassUtils = value;
				classUtils = this._ClassUtils;
				if (classUtils != null)
				{
					classUtils.SelectionChanged += value2;
					classUtils.SelectionChanged += value3;
				}
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000DAE RID: 3502 RVA: 0x0000958B File Offset: 0x0000778B
		// (set) Token: 0x06000DAF RID: 3503 RVA: 0x00009593 File Offset: 0x00007793
		internal virtual MyComboBoxItem ItemSystemUpdateDownload { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000DB0 RID: 3504 RVA: 0x0000959C File Offset: 0x0000779C
		// (set) Token: 0x06000DB1 RID: 3505 RVA: 0x0006C1AC File Offset: 0x0006A3AC
		internal virtual MyComboBox ComboSystemActivity
		{
			[CompilerGenerated]
			get
			{
				return this.m_ConfigUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SelectionChangedEventHandler value2 = (PageSetupSystem._Closure$__.$IR62-8 == null) ? (PageSetupSystem._Closure$__.$IR62-8 = delegate(object sender, SelectionChangedEventArgs e)
				{
					PageSetupSystem.ComboChange((MyComboBox)sender, e);
				}) : PageSetupSystem._Closure$__.$IR62-8;
				SelectionChangedEventHandler value3 = new SelectionChangedEventHandler(this.ComboSystemActivity_SizeChanged);
				MyComboBox configUtils = this.m_ConfigUtils;
				if (configUtils != null)
				{
					configUtils.SelectionChanged -= value2;
					configUtils.SelectionChanged -= value3;
				}
				this.m_ConfigUtils = value;
				configUtils = this.m_ConfigUtils;
				if (configUtils != null)
				{
					configUtils.SelectionChanged += value2;
					configUtils.SelectionChanged += value3;
				}
			}
		}

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000DB2 RID: 3506 RVA: 0x000095A4 File Offset: 0x000077A4
		// (set) Token: 0x06000DB3 RID: 3507 RVA: 0x0006C224 File Offset: 0x0006A424
		internal virtual MyTextBox TextSystemCache
		{
			[CompilerGenerated]
			get
			{
				return this.m_ConnectionUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = (PageSetupSystem._Closure$__.$IR66-9 == null) ? (PageSetupSystem._Closure$__.$IR66-9 = delegate(object sender, RoutedEventArgs e)
				{
					PageSetupSystem.TextBoxChange((MyTextBox)sender, e);
				}) : PageSetupSystem._Closure$__.$IR66-9;
				MyTextBox connectionUtils = this.m_ConnectionUtils;
				if (connectionUtils != null)
				{
					connectionUtils.ResolveVal(value2);
				}
				this.m_ConnectionUtils = value;
				connectionUtils = this.m_ConnectionUtils;
				if (connectionUtils != null)
				{
					connectionUtils.CancelVal(value2);
				}
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000DB4 RID: 3508 RVA: 0x000095AC File Offset: 0x000077AC
		// (set) Token: 0x06000DB5 RID: 3509 RVA: 0x0006C280 File Offset: 0x0006A480
		internal virtual MyButton BtnSystemUpdate
		{
			[CompilerGenerated]
			get
			{
				return this._ListUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnSystemUpdate_Click);
				MyButton listUtils = this._ListUtils;
				if (listUtils != null)
				{
					listUtils.CancelModel(obj);
				}
				this._ListUtils = value;
				listUtils = this._ListUtils;
				if (listUtils != null)
				{
					listUtils.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000DB6 RID: 3510 RVA: 0x000095B4 File Offset: 0x000077B4
		// (set) Token: 0x06000DB7 RID: 3511 RVA: 0x0006C2C4 File Offset: 0x0006A4C4
		internal virtual MyButton BtnSystemCacheClear
		{
			[CompilerGenerated]
			get
			{
				return this._ReponseUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnSystemCacheClear_Click);
				MyButton reponseUtils = this._ReponseUtils;
				if (reponseUtils != null)
				{
					reponseUtils.CancelModel(obj);
				}
				this._ReponseUtils = value;
				reponseUtils = this._ReponseUtils;
				if (reponseUtils != null)
				{
					reponseUtils.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000DB8 RID: 3512 RVA: 0x000095BC File Offset: 0x000077BC
		// (set) Token: 0x06000DB9 RID: 3513 RVA: 0x000095C4 File Offset: 0x000077C4
		internal virtual MyCard CardDebug { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000DBA RID: 3514 RVA: 0x000095CD File Offset: 0x000077CD
		// (set) Token: 0x06000DBB RID: 3515 RVA: 0x000095D5 File Offset: 0x000077D5
		internal virtual Grid PanDebugAnim { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000DBC RID: 3516 RVA: 0x000095DE File Offset: 0x000077DE
		// (set) Token: 0x06000DBD RID: 3517 RVA: 0x0006C308 File Offset: 0x0006A508
		internal virtual MySlider SliderDebugAnim
		{
			[CompilerGenerated]
			get
			{
				return this.m_ClientUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MySlider.ChangeEventHandler obj = (PageSetupSystem._Closure$__.$IR86-10 == null) ? (PageSetupSystem._Closure$__.$IR86-10 = delegate(object a0, bool a1)
				{
					PageSetupSystem.SliderChange((MySlider)a0, a1);
				}) : PageSetupSystem._Closure$__.$IR86-10;
				MySlider clientUtils = this.m_ClientUtils;
				if (clientUtils != null)
				{
					clientUtils.InstantiateIterator(obj);
				}
				this.m_ClientUtils = value;
				clientUtils = this.m_ClientUtils;
				if (clientUtils != null)
				{
					clientUtils.InterruptIterator(obj);
				}
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000DBE RID: 3518 RVA: 0x000095E6 File Offset: 0x000077E6
		// (set) Token: 0x06000DBF RID: 3519 RVA: 0x0006C364 File Offset: 0x0006A564
		internal virtual MyCheckBox CheckDebugSkipCopy
		{
			[CompilerGenerated]
			get
			{
				return this._MapUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyCheckBox.ChangeEventHandler obj = (PageSetupSystem._Closure$__.$IR90-11 == null) ? (PageSetupSystem._Closure$__.$IR90-11 = delegate(object a0, bool a1)
				{
					PageSetupSystem.CheckBoxChange((MyCheckBox)a0, a1);
				}) : PageSetupSystem._Closure$__.$IR90-11;
				MyCheckBox mapUtils = this._MapUtils;
				if (mapUtils != null)
				{
					mapUtils.SearchIterator(obj);
				}
				this._MapUtils = value;
				mapUtils = this._MapUtils;
				if (mapUtils != null)
				{
					mapUtils.RunIterator(obj);
				}
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000DC0 RID: 3520 RVA: 0x000095EE File Offset: 0x000077EE
		// (set) Token: 0x06000DC1 RID: 3521 RVA: 0x0006C3C0 File Offset: 0x0006A5C0
		internal virtual MyCheckBox CheckDebugMode
		{
			[CompilerGenerated]
			get
			{
				return this.m_ComposerUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyCheckBox.ChangeEventHandler obj = (PageSetupSystem._Closure$__.$IR94-12 == null) ? (PageSetupSystem._Closure$__.$IR94-12 = delegate(object a0, bool a1)
				{
					PageSetupSystem.CheckBoxChange((MyCheckBox)a0, a1);
				}) : PageSetupSystem._Closure$__.$IR94-12;
				MyCheckBox.ChangeEventHandler obj2 = delegate(object a0, bool a1)
				{
					this.CheckDebugMode_Change();
				};
				MyCheckBox composerUtils = this.m_ComposerUtils;
				if (composerUtils != null)
				{
					composerUtils.SearchIterator(obj);
					composerUtils.SearchIterator(obj2);
				}
				this.m_ComposerUtils = value;
				composerUtils = this.m_ComposerUtils;
				if (composerUtils != null)
				{
					composerUtils.RunIterator(obj);
					composerUtils.RunIterator(obj2);
				}
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000DC2 RID: 3522 RVA: 0x000095F6 File Offset: 0x000077F6
		// (set) Token: 0x06000DC3 RID: 3523 RVA: 0x0006C438 File Offset: 0x0006A638
		internal virtual MyCheckBox CheckDebugDelay
		{
			[CompilerGenerated]
			get
			{
				return this.publisherUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyCheckBox.ChangeEventHandler obj = (PageSetupSystem._Closure$__.$IR98-14 == null) ? (PageSetupSystem._Closure$__.$IR98-14 = delegate(object a0, bool a1)
				{
					PageSetupSystem.CheckBoxChange((MyCheckBox)a0, a1);
				}) : PageSetupSystem._Closure$__.$IR98-14;
				MyCheckBox myCheckBox = this.publisherUtils;
				if (myCheckBox != null)
				{
					myCheckBox.SearchIterator(obj);
				}
				this.publisherUtils = value;
				myCheckBox = this.publisherUtils;
				if (myCheckBox != null)
				{
					myCheckBox.RunIterator(obj);
				}
			}
		}

		// Token: 0x06000DC4 RID: 3524 RVA: 0x0006C494 File Offset: 0x0006A694
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.messageUtils)
			{
				this.messageUtils = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagesetup/pagesetupsystem.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000DC5 RID: 3525 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000DC6 RID: 3526 RVA: 0x0006C4C4 File Offset: 0x0006A6C4
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
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
				this.ComboDownloadVersion = (MyComboBox)target;
				return;
			}
			if (connectionId == 4)
			{
				this.SliderDownloadThread = (MySlider)target;
				return;
			}
			if (connectionId == 5)
			{
				this.SliderDownloadSpeed = (MySlider)target;
				return;
			}
			if (connectionId == 6)
			{
				this.CheckUpdateRelease = (MyCheckBox)target;
				return;
			}
			if (connectionId == 7)
			{
				this.CheckUpdateSnapshot = (MyCheckBox)target;
				return;
			}
			if (connectionId == 8)
			{
				this.CheckHelpChinese = (MyCheckBox)target;
				return;
			}
			if (connectionId == 9)
			{
				this.ComboSystemUpdate = (MyComboBox)target;
				return;
			}
			if (connectionId == 0xA)
			{
				this.ItemSystemUpdateDownload = (MyComboBoxItem)target;
				return;
			}
			if (connectionId == 0xB)
			{
				this.ComboSystemActivity = (MyComboBox)target;
				return;
			}
			if (connectionId == 0xC)
			{
				this.TextSystemCache = (MyTextBox)target;
				return;
			}
			if (connectionId == 0xD)
			{
				this.BtnSystemUpdate = (MyButton)target;
				return;
			}
			if (connectionId == 0xE)
			{
				this.BtnSystemCacheClear = (MyButton)target;
				return;
			}
			if (connectionId == 0xF)
			{
				this.CardDebug = (MyCard)target;
				return;
			}
			if (connectionId == 0x10)
			{
				this.PanDebugAnim = (Grid)target;
				return;
			}
			if (connectionId == 0x11)
			{
				this.SliderDebugAnim = (MySlider)target;
				return;
			}
			if (connectionId == 0x12)
			{
				this.CheckDebugSkipCopy = (MyCheckBox)target;
				return;
			}
			if (connectionId == 0x13)
			{
				this.CheckDebugMode = (MyCheckBox)target;
				return;
			}
			if (connectionId == 0x14)
			{
				this.CheckDebugDelay = (MyCheckBox)target;
				return;
			}
			this.messageUtils = true;
		}

		// Token: 0x04000727 RID: 1831
		private bool _ParamUtils;

		// Token: 0x04000728 RID: 1832
		private bool mockUtils;

		// Token: 0x04000729 RID: 1833
		private bool specificationUtils;

		// Token: 0x0400072A RID: 1834
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private MyScrollViewer _DicUtils;

		// Token: 0x0400072B RID: 1835
		[AccessedThroughProperty("PanMain")]
		[CompilerGenerated]
		private StackPanel _SchemaUtils;

		// Token: 0x0400072C RID: 1836
		[AccessedThroughProperty("ComboDownloadVersion")]
		[CompilerGenerated]
		private MyComboBox _HelperUtils;

		// Token: 0x0400072D RID: 1837
		[CompilerGenerated]
		[AccessedThroughProperty("SliderDownloadThread")]
		private MySlider _ConsumerUtils;

		// Token: 0x0400072E RID: 1838
		[AccessedThroughProperty("SliderDownloadSpeed")]
		[CompilerGenerated]
		private MySlider _QueueUtils;

		// Token: 0x0400072F RID: 1839
		[CompilerGenerated]
		[AccessedThroughProperty("CheckUpdateRelease")]
		private MyCheckBox m_ProducerUtils;

		// Token: 0x04000730 RID: 1840
		[CompilerGenerated]
		[AccessedThroughProperty("CheckUpdateSnapshot")]
		private MyCheckBox exceptionUtils;

		// Token: 0x04000731 RID: 1841
		[CompilerGenerated]
		[AccessedThroughProperty("CheckHelpChinese")]
		private MyCheckBox _RulesUtils;

		// Token: 0x04000732 RID: 1842
		[CompilerGenerated]
		[AccessedThroughProperty("ComboSystemUpdate")]
		private MyComboBox _ClassUtils;

		// Token: 0x04000733 RID: 1843
		[AccessedThroughProperty("ItemSystemUpdateDownload")]
		[CompilerGenerated]
		private MyComboBoxItem m_ServerUtils;

		// Token: 0x04000734 RID: 1844
		[AccessedThroughProperty("ComboSystemActivity")]
		[CompilerGenerated]
		private MyComboBox m_ConfigUtils;

		// Token: 0x04000735 RID: 1845
		[AccessedThroughProperty("TextSystemCache")]
		[CompilerGenerated]
		private MyTextBox m_ConnectionUtils;

		// Token: 0x04000736 RID: 1846
		[AccessedThroughProperty("BtnSystemUpdate")]
		[CompilerGenerated]
		private MyButton _ListUtils;

		// Token: 0x04000737 RID: 1847
		[AccessedThroughProperty("BtnSystemCacheClear")]
		[CompilerGenerated]
		private MyButton _ReponseUtils;

		// Token: 0x04000738 RID: 1848
		[AccessedThroughProperty("CardDebug")]
		[CompilerGenerated]
		private MyCard identifierUtils;

		// Token: 0x04000739 RID: 1849
		[AccessedThroughProperty("PanDebugAnim")]
		[CompilerGenerated]
		private Grid m_PolicyUtils;

		// Token: 0x0400073A RID: 1850
		[CompilerGenerated]
		[AccessedThroughProperty("SliderDebugAnim")]
		private MySlider m_ClientUtils;

		// Token: 0x0400073B RID: 1851
		[CompilerGenerated]
		[AccessedThroughProperty("CheckDebugSkipCopy")]
		private MyCheckBox _MapUtils;

		// Token: 0x0400073C RID: 1852
		[AccessedThroughProperty("CheckDebugMode")]
		[CompilerGenerated]
		private MyCheckBox m_ComposerUtils;

		// Token: 0x0400073D RID: 1853
		[CompilerGenerated]
		[AccessedThroughProperty("CheckDebugDelay")]
		private MyCheckBox publisherUtils;

		// Token: 0x0400073E RID: 1854
		private bool messageUtils;
	}
}
