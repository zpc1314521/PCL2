using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media;

namespace PCL
{
	// Token: 0x02000088 RID: 136
	[DesignerGenerated]
	public class PageDownloadCfDetail : AdornerDecorator, IComponentConnector
	{
		// Token: 0x0600047E RID: 1150 RVA: 0x00004B27 File Offset: 0x00002D27
		// Note: this type is marked as 'beforefieldinit'.
		static PageDownloadCfDetail()
		{
			PageDownloadCfDetail.m_ProccesorContainer = null;
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00004B2F File Offset: 0x00002D2F
		public PageDownloadCfDetail()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.Init();
			};
			this.repositoryContainer = null;
			this.InitializeComponent();
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x000281A0 File Offset: 0x000263A0
		public void Init()
		{
			checked
			{
				ModAni.ListFactory(ModAni.InsertFactory() + 1);
				this._SystemContainer = (ModDownload.DlCfProject)ModMain.m_GetterFilter.publisherDecorator.m_StatusMapper;
				this.PanBack.ScrollToHome();
				ModDownload._MethodIterator.Start(new KeyValuePair<int, bool>(this._SystemContainer._PrinterAlgo, this._SystemContainer.m_WrapperAlgo), false);
				this.Load.State = ModDownload._MethodIterator;
				if (this.repositoryContainer != null)
				{
					this.PanIntro.Children.Remove(this.repositoryContainer);
				}
				this.repositoryContainer = this._SystemContainer.ToCfItem(null);
				this.repositoryContainer.Margin = new Thickness(-7.0, -7.0, 0.0, 8.0);
				this.PanIntro.Children.Insert(0, this.repositoryContainer);
				this.BtnIntroWiki.Visibility = ((this._SystemContainer.productAlgo == 0) ? Visibility.Collapsed : Visibility.Visible);
				this.BtnIntroMCBBS.Visibility = ((this._SystemContainer.PublishExpression() == null) ? Visibility.Collapsed : Visibility.Visible);
				ModAni.ListFactory(ModAni.InsertFactory() - 1);
			}
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00004B56 File Offset: 0x00002D56
		public void RefreshLoader()
		{
			ModDownload._MethodIterator.Start(new KeyValuePair<int, bool>(this._SystemContainer._PrinterAlgo, this._SystemContainer.m_WrapperAlgo), false);
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x00004B7E File Offset: 0x00002D7E
		private void Load_Click()
		{
			if (this.Load.State.LoadingState == MyLoading.MyLoadingState.Error)
			{
				this.RefreshLoader();
			}
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x000282D4 File Offset: 0x000264D4
		private void Load_State(MyLoading sender, MyLoading.MyLoadingState state)
		{
			switch (ModDownload._MethodIterator.State)
			{
			case ModBase.LoadState.Loading:
				this.Load_OnStart();
				return;
			case ModBase.LoadState.Finished:
				this.Load_OnFinish();
				return;
			case ModBase.LoadState.Failed:
			{
				string text = "";
				if (ModDownload._MethodIterator.Error != null)
				{
					text = ModBase.GetString(ModDownload._MethodIterator.Error, true, false);
				}
				if (text.Contains("不是有效的 Json 文件"))
				{
					ModBase.Log("[Download] 下载的工程详情 Json 文件损坏，已自动重试", ModBase.LogLevel.Debug, "出现错误");
					this.RefreshLoader();
				}
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x00028358 File Offset: 0x00026558
		private void Load_OnStart()
		{
			this.PanLoad.Visibility = Visibility.Visible;
			if (ModAni.InsertFactory() == 0)
			{
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaOpacity(this.PanLoad, 1.0 - this.PanLoad.Opacity, 0x96, 0, null, false),
					ModAni.AaOpacity(this.PanMain, -this.PanMain.Opacity, 0x96, 0, null, false),
					ModAni.AaCode(delegate
					{
						this.PanMain.Visibility = Visibility.Collapsed;
						this.PanMain.Children.Clear();
					}, 0, true)
				}, "FrmDownloadCfDetail Load Switch", false);
				return;
			}
			this.PanLoad.Opacity = 1.0;
			this.PanMain.Opacity = 0.0;
			this.PanMain.Visibility = Visibility.Collapsed;
			this.PanMain.Children.Clear();
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00028440 File Offset: 0x00026640
		private void Load_OnFinish()
		{
			SortedDictionary<string, List<ModDownload.DlCfFile>> sortedDictionary = new SortedDictionary<string, List<ModDownload.DlCfFile>>(new ModMinecraft.VersionSorter(true));
			try
			{
				sortedDictionary.Add("未知版本", new List<ModDownload.DlCfFile>());
				try
				{
					foreach (ModDownload.DlCfFile dlCfFile in ModDownload._MethodIterator.Output)
					{
						foreach (string text in dlCfFile.candidateAlgo)
						{
							string key;
							if (text != null && text.Split(new char[]
							{
								'.'
							}).Count<string>() >= 2)
							{
								key = text;
							}
							else
							{
								key = "未知版本";
							}
							if (!sortedDictionary.ContainsKey(key))
							{
								sortedDictionary.Add(key, new List<ModDownload.DlCfFile>());
							}
							if (!sortedDictionary[key].Contains(dlCfFile))
							{
								sortedDictionary[key].Add(dlCfFile);
							}
						}
					}
				}
				finally
				{
					List<ModDownload.DlCfFile>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "准备工程下载列表出错", ModBase.LogLevel.Feedback, "出现错误");
			}
			try
			{
				this.PanMain.Children.Clear();
				try
				{
					foreach (KeyValuePair<string, List<ModDownload.DlCfFile>> keyValuePair in sortedDictionary)
					{
						if (keyValuePair.Value.Count != 0)
						{
							MyCard myCard = new MyCard();
							myCard.Title = keyValuePair.Key;
							myCard.Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
							myCard.InitFactory(this._SystemContainer.m_WrapperAlgo ? 9 : 8);
							MyCard myCard2 = myCard;
							StackPanel stackPanel = new StackPanel
							{
								Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
								VerticalAlignment = VerticalAlignment.Top,
								RenderTransform = new TranslateTransform(0.0, 0.0),
								Tag = keyValuePair.Value
							};
							myCard2.Children.Add(stackPanel);
							myCard2.thread = stackPanel;
							myCard2.IsSwaped = true;
							this.PanMain.Children.Add(myCard2);
							if (Operators.CompareString(keyValuePair.Key, "未知版本", true) == 0)
							{
								stackPanel.Children.Add(new MyHint
								{
									Text = "由于 API 的版本信息更新缓慢，可能无法识别刚更新不久的 MC 版本，只需等待几天即可自动恢复正常。",
									IsWarn = false,
									Margin = new Thickness(0.0, 0.0, 0.0, 7.0)
								});
							}
						}
					}
				}
				finally
				{
					SortedDictionary<string, List<ModDownload.DlCfFile>>.Enumerator enumerator2;
					((IDisposable)enumerator2).Dispose();
				}
				if (this.PanMain.Children.Count == 1)
				{
					((MyCard)this.PanMain.Children[0]).IsSwaped = false;
				}
				this.PanMain.Visibility = Visibility.Visible;
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaOpacity(this.PanLoad, -this.PanLoad.Opacity, 0x96, 0, null, false),
					ModAni.AaOpacity(this.PanMain, 1.0 - this.PanMain.Opacity, 0x96, 0, null, false),
					ModAni.AaCode(delegate
					{
						this.PanLoad.Visibility = Visibility.Collapsed;
					}, 0, true)
				}, "FrmDownloadCfDetail Load Switch", false);
			}
			catch (Exception ex2)
			{
				ModBase.Log(ex2, "可视化工程下载列表出错", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x00028838 File Offset: 0x00026A38
		public void Install_Click(MyListItem sender, EventArgs e)
		{
			try
			{
				ModDownload.DlCfFile dlCfFile = (ModDownload.DlCfFile)sender.Tag;
				string name = "CurseForge 整合包下载：" + this._SystemContainer.NewExpression() + " ";
				string text = this._SystemContainer.NewExpression().Replace(".zip", "").Replace(".rar", "").Replace("\\", "＼").Replace("/", "／").Replace("|", "｜").Replace(":", "：").Replace("<", "＜").Replace(">", "＞").Replace("*", "＊").Replace("?", "？").Replace("\"", "").Replace("： ", "：");
				ValidateFolderName validateFolderName = new ValidateFolderName(ModMinecraft.m_ResolverIterator + "versions", true, true);
				if (Operators.CompareString(validateFolderName.Validate(text), "", true) != 0)
				{
					text = "";
				}
				string VersionName = ModMain.MyMsgBoxInput(text, new Collection<Validate>
				{
					validateFolderName
				}, "", "输入版本名", "确定", "取消", false);
				if (!string.IsNullOrEmpty(VersionName))
				{
					ArrayList arrayList = new ArrayList();
					string Target = ModMinecraft.m_ResolverIterator + "versions\\" + VersionName + "\\原始整合包.rar";
					arrayList.Add(new ModNet.LoaderDownload("下载整合包文件", new List<ModNet.NetFile>
					{
						dlCfFile.GetDownloadFile(Target, true)
					})
					{
						ProgressWeight = 10.0,
						Block = true
					});
					arrayList.Add(new ModLoader.LoaderTask<int, int>("准备安装整合包", delegate(ModLoader.LoaderTask<int, int> a0)
					{
						base._Lambda$__0();
					}, null, ThreadPriority.Normal)
					{
						ProgressWeight = 0.1
					});
					ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(name, arrayList);
					loaderCombo.OnStateChanged = ((PageDownloadCfDetail._Closure$__.$I10-1 == null) ? (PageDownloadCfDetail._Closure$__.$I10-1 = delegate(object MyLoader)
					{
						object left = NewLateBinding.LateGet(MyLoader, null, "State", new object[0], null, null, null);
						if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Failed, true))
						{
							object left2 = Operators.ConcatenateObject(NewLateBinding.LateGet(MyLoader, null, "Name", new object[0], null, null, null), "失败：");
							object[] array;
							bool[] array2;
							object right = NewLateBinding.LateGet(null, typeof(ModBase), "GetString", array = new object[]
							{
								NewLateBinding.LateGet(MyLoader, null, "Error", new object[0], null, null, null)
							}, null, null, array2 = new bool[]
							{
								true
							});
							if (array2[0])
							{
								NewLateBinding.LateSetComplex(MyLoader, null, "Error", new object[]
								{
									array[0]
								}, null, null, true, false);
							}
							ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject(left2, right)), ModMain.HintType.Critical, true);
						}
						else if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Aborted, true))
						{
							ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(MyLoader, null, "Name", new object[0], null, null, null), "已取消！")), ModMain.HintType.Info, true);
						}
						else if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Loading, true))
						{
							return;
						}
						ModDownloadLib.McInstallFailedClearFolder(RuntimeHelpers.GetObjectValue(MyLoader));
					}) : PageDownloadCfDetail._Closure$__.$I10-1);
					loaderCombo.Start(ModMinecraft.m_ResolverIterator + "versions\\" + VersionName + "\\", false);
					ModLoader.LoaderTaskbarAdd(loaderCombo);
					ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
					ModMain.m_GetterFilter.BtnExtraDownload.Ribble();
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "下载 CurseForge 整合包失败", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00028AF0 File Offset: 0x00026CF0
		public void Save_Click(object sender, EventArgs e)
		{
			try
			{
				string str = this._SystemContainer.m_WrapperAlgo ? "整合包" : "Mod ";
				string text = null;
				if (!this._SystemContainer.m_WrapperAlgo)
				{
					text = Conversions.ToString(PageDownloadCfDetail.m_ProccesorContainer);
					if (ModMinecraft.ValidateContainer() != null)
					{
						if (!ModMinecraft.ValidateContainer()._ReponseAlgo)
						{
							ModMinecraft.ValidateContainer().Load();
						}
						if (ModMinecraft.ValidateContainer().Version.LoginUtils())
						{
							text = ModMinecraft.ValidateContainer().ManageExpression() + "mods\\";
							Directory.CreateDirectory(text);
						}
					}
					if (string.IsNullOrEmpty(text))
					{
						text = null;
					}
				}
				ModDownload.DlCfFile dlCfFile = (ModDownload.DlCfFile)NewLateBinding.LateGet((sender is MyListItem) ? sender : NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null);
				string fileName = ((Operators.CompareString(this._SystemContainer.NewExpression(), this._SystemContainer.Name, true) == 0) ? "" : ("[" + this._SystemContainer.NewExpression().Replace(" (", "Å").Split(new char[]
				{
					'Å'
				}).First<string>().Replace("\\", "＼").Replace("/", "／").Replace("|", "｜").Replace(":", "：").Replace("<", "＜").Replace(">", "＞").Replace("*", "＊").Replace("?", "？").Replace("\"", "").Replace("： ", "：") + "] ")) + dlCfFile._ContextAlgo;
				string text2;
				if (dlCfFile._ContextAlgo.EndsWith(".litemod"))
				{
					text2 = ModBase.SelectAs("选择保存位置", fileName, str + "文件|" + (this._SystemContainer.m_WrapperAlgo ? "*.zip" : "*.litemod"), text);
				}
				else
				{
					text2 = ModBase.SelectAs("选择保存位置", fileName, str + "文件|" + (this._SystemContainer.m_WrapperAlgo ? "*.zip" : "*.jar"), text);
				}
				if (text2.Contains("\\"))
				{
					string name = str + "下载：" + dlCfFile.m_InterceptorAlgo + " ";
					if (Operators.CompareString(text2, text, true) != 0 && !this._SystemContainer.m_WrapperAlgo)
					{
						PageDownloadCfDetail.m_ProccesorContainer = ModBase.GetPathFromFullPath(text2);
					}
					ModLoader.LoaderCombo<int> loaderCombo = new ModLoader.LoaderCombo<int>(name, new ArrayList
					{
						new ModNet.LoaderDownload("下载文件", new List<ModNet.NetFile>
						{
							dlCfFile.GetDownloadFile(text2, true)
						})
						{
							ProgressWeight = 6.0,
							Block = true
						}
					});
					loaderCombo.OnStateChanged = new ModLoader.LoaderStateDelegate(ModDownloadLib.DownloadStateSave);
					loaderCombo.Start(1, false);
					ModLoader.LoaderTaskbarAdd(loaderCombo);
					ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
					ModMain.m_GetterFilter.BtnExtraDownload.Ribble();
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "保存 CurseForge 文件失败", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00004B99 File Offset: 0x00002D99
		private void BtnIntroCf_Click(object sender, EventArgs e)
		{
			ModBase.OpenWebsite(this._SystemContainer._RegistryAlgo);
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x00004BAB File Offset: 0x00002DAB
		private void BtnIntroWiki_Click(object sender, EventArgs e)
		{
			ModBase.OpenWebsite("https://www.mcmod.cn/class/" + Conversions.ToString(this._SystemContainer.productAlgo) + ".html");
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00004BD1 File Offset: 0x00002DD1
		private void BtnIntroMCBBS_Click(object sender, EventArgs e)
		{
			ModBase.OpenWebsite("https://www.mcbbs.net/thread-" + this._SystemContainer.PublishExpression() + "-1-1.html");
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x00004BF2 File Offset: 0x00002DF2
		// (set) Token: 0x0600048C RID: 1164 RVA: 0x00004BFA File Offset: 0x00002DFA
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x00004C03 File Offset: 0x00002E03
		// (set) Token: 0x0600048E RID: 1166 RVA: 0x00004C0B File Offset: 0x00002E0B
		internal virtual StackPanel PanIntro { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x0600048F RID: 1167 RVA: 0x00004C14 File Offset: 0x00002E14
		// (set) Token: 0x06000490 RID: 1168 RVA: 0x00028E5C File Offset: 0x0002705C
		internal virtual MyButton BtnIntroCf
		{
			[CompilerGenerated]
			get
			{
				return this.m_ParameterContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnIntroCf_Click);
				MyButton parameterContainer = this.m_ParameterContainer;
				if (parameterContainer != null)
				{
					parameterContainer.CancelModel(obj);
				}
				this.m_ParameterContainer = value;
				parameterContainer = this.m_ParameterContainer;
				if (parameterContainer != null)
				{
					parameterContainer.ValidateModel(obj);
				}
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x00004C1C File Offset: 0x00002E1C
		// (set) Token: 0x06000492 RID: 1170 RVA: 0x00028EA0 File Offset: 0x000270A0
		internal virtual MyButton BtnIntroWiki
		{
			[CompilerGenerated]
			get
			{
				return this._StubContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnIntroWiki_Click);
				MyButton stubContainer = this._StubContainer;
				if (stubContainer != null)
				{
					stubContainer.CancelModel(obj);
				}
				this._StubContainer = value;
				stubContainer = this._StubContainer;
				if (stubContainer != null)
				{
					stubContainer.ValidateModel(obj);
				}
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000493 RID: 1171 RVA: 0x00004C24 File Offset: 0x00002E24
		// (set) Token: 0x06000494 RID: 1172 RVA: 0x00028EE4 File Offset: 0x000270E4
		internal virtual MyButton BtnIntroMCBBS
		{
			[CompilerGenerated]
			get
			{
				return this._AccountContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnIntroMCBBS_Click);
				MyButton accountContainer = this._AccountContainer;
				if (accountContainer != null)
				{
					accountContainer.CancelModel(obj);
				}
				this._AccountContainer = value;
				accountContainer = this._AccountContainer;
				if (accountContainer != null)
				{
					accountContainer.ValidateModel(obj);
				}
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x00004C2C File Offset: 0x00002E2C
		// (set) Token: 0x06000496 RID: 1174 RVA: 0x00004C34 File Offset: 0x00002E34
		internal virtual StackPanel PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x00004C3D File Offset: 0x00002E3D
		// (set) Token: 0x06000498 RID: 1176 RVA: 0x00004C45 File Offset: 0x00002E45
		internal virtual MyCard PanLoad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x00004C4E File Offset: 0x00002E4E
		// (set) Token: 0x0600049A RID: 1178 RVA: 0x00028F28 File Offset: 0x00027128
		internal virtual MyLoading Load
		{
			[CompilerGenerated]
			get
			{
				return this.predicateContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyLoading.ClickEventHandler obj = delegate(object sender, MouseButtonEventArgs e)
				{
					this.Load_Click();
				};
				MyLoading.StateChangedEventHandler obj2 = delegate(object a0, MyLoading.MyLoadingState a1)
				{
					this.Load_State((MyLoading)a0, a1);
				};
				MyLoading myLoading = this.predicateContainer;
				if (myLoading != null)
				{
					myLoading.UpdateVal(obj);
					myLoading.InitVal(obj2);
				}
				this.predicateContainer = value;
				myLoading = this.predicateContainer;
				if (myLoading != null)
				{
					myLoading.PrepareVal(obj);
					myLoading.FillVal(obj2);
				}
			}
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00028F88 File Offset: 0x00027188
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.m_StructContainer)
			{
				this.m_StructContainer = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagedownload/pagedownloadcfdetail.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00028FB8 File Offset: 0x000271B8
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
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
				this.PanIntro = (StackPanel)target;
				return;
			}
			if (connectionId == 3)
			{
				this.BtnIntroCf = (MyButton)target;
				return;
			}
			if (connectionId == 4)
			{
				this.BtnIntroWiki = (MyButton)target;
				return;
			}
			if (connectionId == 5)
			{
				this.BtnIntroMCBBS = (MyButton)target;
				return;
			}
			if (connectionId == 6)
			{
				this.PanMain = (StackPanel)target;
				return;
			}
			if (connectionId == 7)
			{
				this.PanLoad = (MyCard)target;
				return;
			}
			if (connectionId == 8)
			{
				this.Load = (MyLoading)target;
				return;
			}
			this.m_StructContainer = true;
		}

		// Token: 0x04000242 RID: 578
		private MyCfItem repositoryContainer;

		// Token: 0x04000243 RID: 579
		private ModDownload.DlCfProject _SystemContainer;

		// Token: 0x04000244 RID: 580
		public static string m_ProccesorContainer;

		// Token: 0x04000245 RID: 581
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private MyScrollViewer prototypeContainer;

		// Token: 0x04000246 RID: 582
		[CompilerGenerated]
		[AccessedThroughProperty("PanIntro")]
		private StackPanel m_RefContainer;

		// Token: 0x04000247 RID: 583
		[CompilerGenerated]
		[AccessedThroughProperty("BtnIntroCf")]
		private MyButton m_ParameterContainer;

		// Token: 0x04000248 RID: 584
		[CompilerGenerated]
		[AccessedThroughProperty("BtnIntroWiki")]
		private MyButton _StubContainer;

		// Token: 0x04000249 RID: 585
		[AccessedThroughProperty("BtnIntroMCBBS")]
		[CompilerGenerated]
		private MyButton _AccountContainer;

		// Token: 0x0400024A RID: 586
		[AccessedThroughProperty("PanMain")]
		[CompilerGenerated]
		private StackPanel configurationContainer;

		// Token: 0x0400024B RID: 587
		[AccessedThroughProperty("PanLoad")]
		[CompilerGenerated]
		private MyCard _InterpreterContainer;

		// Token: 0x0400024C RID: 588
		[CompilerGenerated]
		[AccessedThroughProperty("Load")]
		private MyLoading predicateContainer;

		// Token: 0x0400024D RID: 589
		private bool m_StructContainer;
	}
}
