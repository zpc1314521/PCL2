using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace PCL
{
	// Token: 0x02000148 RID: 328
	[DesignerGenerated]
	public class PageDownloadClient : AdornerDecorator, IComponentConnector
	{
		// Token: 0x06000C66 RID: 3174 RVA: 0x00008D4C File Offset: 0x00006F4C
		// Note: this type is marked as 'beforefieldinit'.
		static PageDownloadClient()
		{
			PageDownloadClient._IndexerUtils = 1;
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x00008D54 File Offset: 0x00006F54
		public PageDownloadClient()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.Init();
			};
			this.visitorUtils = false;
			this.InitializeComponent();
		}

		// Token: 0x06000C68 RID: 3176 RVA: 0x00008D7B File Offset: 0x00006F7B
		private void Init()
		{
			this.PanBack.ScrollToHome();
			ModDownload._AlgoIterator.Start(PageDownloadClient._IndexerUtils, false);
			if (!this.visitorUtils)
			{
				this.visitorUtils = true;
				this.Load.State = ModDownload._AlgoIterator;
			}
		}

		// Token: 0x06000C69 RID: 3177 RVA: 0x00008DB7 File Offset: 0x00006FB7
		public static void RefreshLoader()
		{
			checked
			{
				PageDownloadClient._IndexerUtils++;
				ModDownload._AlgoIterator.Start(PageDownloadClient._IndexerUtils, false);
			}
		}

		// Token: 0x06000C6A RID: 3178 RVA: 0x00008DD5 File Offset: 0x00006FD5
		private void Load_Click(object sender, MouseButtonEventArgs e)
		{
			if (this.Load.State.LoadingState == MyLoading.MyLoadingState.Error)
			{
				PageDownloadClient.RefreshLoader();
			}
		}

		// Token: 0x06000C6B RID: 3179 RVA: 0x00064DD4 File Offset: 0x00062FD4
		private void Load_State(object sender, MyLoading.MyLoadingState state)
		{
			ModBase.LoadState state2 = ModDownload._AlgoIterator.State;
			if (state2 == ModBase.LoadState.Loading)
			{
				this.Load_OnStart();
				return;
			}
			if (state2 != ModBase.LoadState.Finished)
			{
				return;
			}
			this.Load_OnFinish();
		}

		// Token: 0x06000C6C RID: 3180 RVA: 0x00064E04 File Offset: 0x00063004
		private void Load_OnStart()
		{
			this.PanLoad.Visibility = Visibility.Visible;
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.PanLoad, 1.0 - this.PanLoad.Opacity, 0x96, 0, null, false),
				ModAni.AaOpacity(this.PanBack, -this.PanBack.Opacity, 0x96, 0, null, false),
				ModAni.AaCode(delegate
				{
					this.PanBack.Visibility = Visibility.Collapsed;
					this.PanMain.Children.Clear();
				}, 0, true)
			}, "FrmDownloadClient Load Switch", false);
		}

		// Token: 0x06000C6D RID: 3181 RVA: 0x00064EA0 File Offset: 0x000630A0
		private void Load_OnFinish()
		{
			checked
			{
				try
				{
					Dictionary<string, List<JObject>> dictionary = new Dictionary<string, List<JObject>>
					{
						{
							"正式版",
							new List<JObject>()
						},
						{
							"预览版",
							new List<JObject>()
						},
						{
							"远古版",
							new List<JObject>()
						},
						{
							"愚人节版",
							new List<JObject>()
						}
					};
					JArray jarray = (JArray)ModDownload._AlgoIterator.Output.Value["versions"];
					try
					{
						foreach (JToken jtoken in jarray)
						{
							JObject jobject = (JObject)jtoken;
							string text = (string)jobject["type"];
							string left = text;
							if (Operators.CompareString(left, "release", true) == 0)
							{
								text = "正式版";
							}
							else if (Operators.CompareString(left, "snapshot", true) == 0)
							{
								text = "预览版";
								if (jobject["id"].ToString().StartsWith("1.") && !jobject["id"].ToString().ToLower().Contains("combat") && !jobject["id"].ToString().ToLower().Contains("rc") && !jobject["id"].ToString().ToLower().Contains("experimental") && !jobject["id"].ToString().ToLower().Contains("pre"))
								{
									text = "正式版";
									jobject["type"] = "release";
								}
								string left2 = jobject["id"].ToString().ToLower();
								if (Operators.CompareString(left2, "20w14infinite", true) != 0 && Operators.CompareString(left2, "20w14∞", true) != 0)
								{
									if (Operators.CompareString(left2, "3d shareware v1.34", true) == 0 || Operators.CompareString(left2, "1.rv-pre1", true) == 0 || Operators.CompareString(left2, "15w14a", true) == 0 || Operators.CompareString(left2, "2.0", true) == 0)
									{
										text = "愚人节版";
										jobject["type"] = "special";
										jobject.Add("lore", ModMinecraft.GetMcFoolName((string)jobject["id"]));
									}
								}
								else
								{
									text = "愚人节版";
									jobject["id"] = "20w14∞";
									jobject["type"] = "special";
									jobject.Add("lore", ModMinecraft.GetMcFoolName((string)jobject["id"]));
								}
							}
							else if (Operators.CompareString(left, "special", true) == 0)
							{
								text = "愚人节版";
							}
							else
							{
								text = "远古版";
							}
							dictionary[text].Add(jobject);
						}
					}
					finally
					{
						IEnumerator<JToken> enumerator;
						if (enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					int num = dictionary.Keys.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						dictionary[dictionary.Keys.ElementAtOrDefault(i)] = ModBase.Sort<JObject>(dictionary.Values.ElementAtOrDefault(i), (PageDownloadClient._Closure$__.$IR9-2 == null) ? (PageDownloadClient._Closure$__.$IR9-2 = ((object a0, object a1) => ((PageDownloadClient._Closure$__.$I9-0 == null) ? (PageDownloadClient._Closure$__.$I9-0 = ((JObject Left, JObject Right) => DateTime.Compare(Left["releaseTime"].Value<DateTime>(), Right["releaseTime"].Value<DateTime>()) > 0)) : PageDownloadClient._Closure$__.$I9-0)((JObject)a0, (JObject)a1))) : PageDownloadClient._Closure$__.$IR9-2);
					}
					this.PanMain.Children.Clear();
					MyCard myCard = new MyCard();
					myCard.Title = "最新版本";
					myCard.Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
					myCard.InitFactory(2);
					MyCard myCard2 = myCard;
					List<JObject> list = new List<JObject>();
					JObject jobject2 = (JObject)dictionary["正式版"][0].DeepClone();
					jobject2["lore"] = "最新正式版，发布于 " + jobject2["releaseTime"].ToString();
					list.Add(jobject2);
					if (DateTime.Compare(dictionary["正式版"][0]["releaseTime"].Value<DateTime>(), dictionary["预览版"][0]["releaseTime"].Value<DateTime>()) < 0)
					{
						JObject jobject3 = (JObject)dictionary["预览版"][0].DeepClone();
						jobject3["lore"] = "最新预览版，发布于 " + jobject3["releaseTime"].ToString();
						list.Add(jobject3);
					}
					StackPanel element = new StackPanel
					{
						Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
						VerticalAlignment = VerticalAlignment.Top,
						RenderTransform = new TranslateTransform(0.0, 0.0),
						Tag = list
					};
					MyCard.StackInstall(ref element, 2, "");
					myCard2.Children.Add(element);
					this.PanMain.Children.Add(myCard2);
					try
					{
						foreach (KeyValuePair<string, List<JObject>> keyValuePair in dictionary)
						{
							if (keyValuePair.Value.Count != 0)
							{
								MyCard myCard3 = new MyCard();
								myCard3.Title = keyValuePair.Key + " (" + Conversions.ToString(keyValuePair.Value.Count) + ")";
								myCard3.Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
								myCard3.InitFactory(2);
								MyCard myCard4 = myCard3;
								StackPanel stackPanel = new StackPanel
								{
									Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
									VerticalAlignment = VerticalAlignment.Top,
									RenderTransform = new TranslateTransform(0.0, 0.0),
									Tag = keyValuePair.Value
								};
								myCard4.Children.Add(stackPanel);
								myCard4.thread = stackPanel;
								myCard4.IsSwaped = true;
								this.PanMain.Children.Add(myCard4);
							}
						}
					}
					finally
					{
						Dictionary<string, List<JObject>>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "可视化版本列表出错", ModBase.LogLevel.Feedback, "出现错误");
				}
				this.PanBack.Visibility = Visibility.Visible;
			}
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.PanLoad, -this.PanLoad.Opacity, 0x96, 0, null, false),
				ModAni.AaOpacity(this.PanBack, 1.0 - this.PanBack.Opacity, 0x96, 0, null, false),
				ModAni.AaCode(delegate
				{
					this.PanLoad.Visibility = Visibility.Collapsed;
				}, 0, true)
			}, "FrmDownloadClient Load Switch", false);
		}

		// Token: 0x06000C6E RID: 3182 RVA: 0x00008DEF File Offset: 0x00006FEF
		public void DownloadStart(MyListItem sender, object e)
		{
			ModDownloadLib.McDownloadClient(ModNet.NetPreDownloadBehaviour.HintWhileExists, sender.Title, NewLateBinding.LateIndexGet(sender.Tag, new object[]
			{
				"url"
			}, null).ToString());
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000C6F RID: 3183 RVA: 0x00008E1D File Offset: 0x0000701D
		// (set) Token: 0x06000C70 RID: 3184 RVA: 0x00008E25 File Offset: 0x00007025
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000C71 RID: 3185 RVA: 0x00008E2E File Offset: 0x0000702E
		// (set) Token: 0x06000C72 RID: 3186 RVA: 0x00008E36 File Offset: 0x00007036
		internal virtual StackPanel PanMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000C73 RID: 3187 RVA: 0x00008E3F File Offset: 0x0000703F
		// (set) Token: 0x06000C74 RID: 3188 RVA: 0x00008E47 File Offset: 0x00007047
		internal virtual MyCard PanLoad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000C75 RID: 3189 RVA: 0x00008E50 File Offset: 0x00007050
		// (set) Token: 0x06000C76 RID: 3190 RVA: 0x00065628 File Offset: 0x00063828
		internal virtual MyLoading Load
		{
			[CompilerGenerated]
			get
			{
				return this._ThreadUtils;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyLoading.ClickEventHandler obj = new MyLoading.ClickEventHandler(this.Load_Click);
				MyLoading.StateChangedEventHandler obj2 = new MyLoading.StateChangedEventHandler(this.Load_State);
				MyLoading threadUtils = this._ThreadUtils;
				if (threadUtils != null)
				{
					threadUtils.UpdateVal(obj);
					threadUtils.InitVal(obj2);
				}
				this._ThreadUtils = value;
				threadUtils = this._ThreadUtils;
				if (threadUtils != null)
				{
					threadUtils.PrepareVal(obj);
					threadUtils.FillVal(obj2);
				}
			}
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x00065688 File Offset: 0x00063888
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.managerUtils)
			{
				this.managerUtils = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagedownload/pagedownloadclient.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000C78 RID: 3192 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000C79 RID: 3193 RVA: 0x000656B8 File Offset: 0x000638B8
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
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
				this.PanLoad = (MyCard)target;
				return;
			}
			if (connectionId == 4)
			{
				this.Load = (MyLoading)target;
				return;
			}
			this.managerUtils = true;
		}

		// Token: 0x040006AF RID: 1711
		private bool visitorUtils;

		// Token: 0x040006B0 RID: 1712
		public static int _IndexerUtils;

		// Token: 0x040006B1 RID: 1713
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private MyScrollViewer _MethodUtils;

		// Token: 0x040006B2 RID: 1714
		[CompilerGenerated]
		[AccessedThroughProperty("PanMain")]
		private StackPanel m_DatabaseUtils;

		// Token: 0x040006B3 RID: 1715
		[CompilerGenerated]
		[AccessedThroughProperty("PanLoad")]
		private MyCard attrUtils;

		// Token: 0x040006B4 RID: 1716
		[AccessedThroughProperty("Load")]
		[CompilerGenerated]
		private MyLoading _ThreadUtils;

		// Token: 0x040006B5 RID: 1717
		private bool managerUtils;
	}
}
