using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PCL
{
	// Token: 0x02000013 RID: 19
	public class MyCard : Grid
	{
		// Token: 0x06000064 RID: 100 RVA: 0x0000274D File Offset: 0x0000094D
		// Note: this type is marked as 'beforefieldinit'.
		static MyCard()
		{
			MyCard.callback = DependencyProperty.Register("Title", typeof(string), typeof(MyCard), new PropertyMetadata(""));
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000065 RID: 101 RVA: 0x0000277C File Offset: 0x0000097C
		// (set) Token: 0x06000066 RID: 102 RVA: 0x0000278E File Offset: 0x0000098E
		public string Title
		{
			get
			{
				return Conversions.ToString(base.GetValue(MyCard.callback));
			}
			set
			{
				base.SetValue(MyCard.callback, value);
				if (this.m_Bridge != null)
				{
					this.m_Bridge.Text = value;
				}
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000DC00 File Offset: 0x0000BE00
		public MyCard()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.MyCard_Loaded();
			};
			base.MouseEnter += this.MyCard_MouseEnter;
			base.MouseLeave += this.MyCard_MouseLeave;
			base.SizeChanged += this.MySizeChanged;
			base.MouseLeftButtonDown += this.MyCard_MouseLeftButtonDown;
			base.MouseLeftButtonUp += this.MyCard_MouseLeftButtonUp;
			base.MouseLeave += this.MyCard_MouseLeave_Swap;
			this._Object = ModBase.GetUuid();
			this.worker = false;
			this.UseAnimation = true;
			this.LoadAnimation = true;
			this.m_Database = false;
			this.CanSwap = false;
			this.m_Serializer = false;
			this.SwapLogoRight = false;
			this._System = false;
			this._Code = new SystemDropShadowChrome
			{
				Margin = new Thickness(-9.5, -9.0, 0.5, -0.5),
				Opacity = 0.1,
				CornerRadius = new CornerRadius(6.0)
			};
			this._Code.SetResourceReference(SystemDropShadowChrome.m_HelperModel, "ColorObject1");
			base.Children.Add(this._Code);
			this.m_Mapping = new Border
			{
				Background = new SolidColorBrush(Color.FromArgb(0xCD, byte.MaxValue, byte.MaxValue, byte.MaxValue)),
				CornerRadius = new CornerRadius(6.0),
				IsHitTestVisible = false
			};
			base.Children.Add(this.m_Mapping);
			this.facade = new Grid();
			base.Children.Add(this.facade);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000DDD4 File Offset: 0x0000BFD4
		private void MyCard_Loaded()
		{
			if (this.LoadAnimation && this.worker)
			{
				this.StartHeightAnimation(Math.Min(50.0, base.ActualHeight), base.ActualHeight - Math.Min(50.0, base.ActualHeight), true);
			}
			if (!this.worker)
			{
				if (Operators.CompareString(this.Title, "", true) != 0 && Information.IsNothing(this.m_Bridge))
				{
					this.m_Bridge = new TextBlock
					{
						HorizontalAlignment = HorizontalAlignment.Left,
						VerticalAlignment = VerticalAlignment.Top,
						Margin = new Thickness(15.0, 12.0, 0.0, 0.0),
						FontWeight = FontWeights.Bold,
						FontSize = 13.0,
						IsHitTestVisible = false
					};
					this.m_Bridge.SetResourceReference(TextBlock.ForegroundProperty, "ColorBrush1");
					this.m_Bridge.SetBinding(TextBlock.TextProperty, new Binding("Title")
					{
						Source = this,
						Mode = BindingMode.OneWay
					});
					this.facade.Children.Add(this.m_Bridge);
				}
				if (this.CanSwap || this.thread != null)
				{
					if (this.thread == null && base.Children.Count > 3)
					{
						this.thread = base.Children[3];
					}
					this.singleton = new Path
					{
						HorizontalAlignment = HorizontalAlignment.Right,
						Stretch = Stretch.Uniform,
						Height = 6.0,
						Width = 10.0,
						VerticalAlignment = VerticalAlignment.Top,
						Margin = new Thickness(0.0, 17.0, 16.0, 0.0),
						Data = (Geometry)new GeometryConverter().ConvertFromString("M2,4 l-2,2 10,10 10,-10 -2,-2 -8,8 -8,-8 z"),
						RenderTransform = new RotateTransform(180.0),
						RenderTransformOrigin = new Point(0.5, 0.5)
					};
					this.singleton.SetResourceReference(Shape.FillProperty, "ColorBrush1");
					this.facade.Children.Add(this.singleton);
				}
				this.worker = true;
				if (this.IsSwaped && this.thread != null)
				{
					base.Height = 40.0;
					this.singleton.RenderTransform = new RotateTransform((double)(this.SwapLogoRight ? 0x10E : 0));
					ModAni.AniStop("MyCard Height " + Conversions.ToString(this._Object));
					this.m_Database = false;
					double num = Conversions.ToDouble(NewLateBinding.LateGet(NewLateBinding.LateGet(this.thread, null, "Margin", new object[0], null, null, null), null, "Top", new object[0], null, null, null));
					this.StartHeightAnimation(Math.Min(20.0, num), num - Math.Min(20.0, num), true);
				}
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000E100 File Offset: 0x0000C300
		public void StackInstall()
		{
			StackPanel stackPanel = (StackPanel)this.thread;
			MyCard.StackInstall(ref stackPanel, this.FillFactory(), this.Title);
			this.thread = stackPanel;
			this.TriggerForceResize();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000E138 File Offset: 0x0000C338
		public static void StackInstall(ref StackPanel Stack, int Type, string CardTitle = "")
		{
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(Stack.Tag)))
			{
				switch (Type)
				{
				case 3:
					Stack.Tag = ModBase.Sort((ArrayList)Stack.Tag, (MyCard._Closure$__.$IR15-8 == null) ? (MyCard._Closure$__.$IR15-8 = ((object a0, object a1) => ((MyCard._Closure$__.$I15-0 == null) ? (MyCard._Closure$__.$I15-0 = ((ModDownload.DlOptiFineListEntry Left, ModDownload.DlOptiFineListEntry Right) => ModMinecraft.VersionSortBoolean(Left.m_RepositoryAlgo, Right.m_RepositoryAlgo))) : MyCard._Closure$__.$I15-0)((ModDownload.DlOptiFineListEntry)a0, (ModDownload.DlOptiFineListEntry)a1))) : MyCard._Closure$__.$IR15-8);
					break;
				case 4:
				case 0xA:
					Stack.Tag = ModBase.Sort<ModDownload.DlLiteLoaderListEntry>((List<ModDownload.DlLiteLoaderListEntry>)Stack.Tag, (MyCard._Closure$__.$IR15-9 == null) ? (MyCard._Closure$__.$IR15-9 = ((object a0, object a1) => ((MyCard._Closure$__.$I15-1 == null) ? (MyCard._Closure$__.$I15-1 = ((ModDownload.DlLiteLoaderListEntry Left, ModDownload.DlLiteLoaderListEntry Right) => ModMinecraft.VersionSortBoolean(Left.Inherit, Right.Inherit))) : MyCard._Closure$__.$I15-1)((ModDownload.DlLiteLoaderListEntry)a0, (ModDownload.DlLiteLoaderListEntry)a1))) : MyCard._Closure$__.$IR15-9);
					break;
				case 6:
					Stack.Tag = ModBase.Sort<ModDownload.DlForgeVersionEntry>((List<ModDownload.DlForgeVersionEntry>)Stack.Tag, (MyCard._Closure$__.$IR15-10 == null) ? (MyCard._Closure$__.$IR15-10 = ((object a0, object a1) => ((MyCard._Closure$__.$I15-2 == null) ? (MyCard._Closure$__.$I15-2 = ((ModDownload.DlForgeVersionEntry Left, ModDownload.DlForgeVersionEntry Right) => ModMinecraft.VersionSortBoolean(Left._ConfigurationAlgo, Right._ConfigurationAlgo))) : MyCard._Closure$__.$I15-2)((ModDownload.DlForgeVersionEntry)a0, (ModDownload.DlForgeVersionEntry)a1))) : MyCard._Closure$__.$IR15-10);
					break;
				case 8:
				case 9:
					Stack.Tag = ModBase.Sort<ModDownload.DlCfFile>((List<ModDownload.DlCfFile>)Stack.Tag, (MyCard._Closure$__.$IR15-11 == null) ? (MyCard._Closure$__.$IR15-11 = ((object a0, object a1) => ((MyCard._Closure$__.$I15-3 == null) ? (MyCard._Closure$__.$I15-3 = ((ModDownload.DlCfFile Left, ModDownload.DlCfFile Right) => DateTime.Compare(Left.invocationAlgo, Right.invocationAlgo) > 0)) : MyCard._Closure$__.$I15-3)((ModDownload.DlCfFile)a0, (ModDownload.DlCfFile)a1))) : MyCard._Closure$__.$IR15-11);
					break;
				}
				switch (Type)
				{
				case 5:
				{
					MyLoading myLoading = new MyLoading
					{
						Text = "正在获取版本列表",
						Margin = new Thickness(5.0)
					};
					ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>("DlForgeVersion Main", new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>.LoadDelegateSub(ModDownload.DlForgeVersionMain), null, ThreadPriority.Normal);
					myLoading.State = loaderTask;
					loaderTask.Start(Conversions.ToString(Stack.Tag), false);
					MyLoading myLoading2 = myLoading;
					MyCard._Closure$__R15-1 CS$<>8__locals1 = new MyCard._Closure$__R15-1(CS$<>8__locals1);
					CS$<>8__locals1.$VB$NonLocal_2 = ModMain.m_PageFilter;
					myLoading2.FillVal(delegate(object a0, MyLoading.MyLoadingState a1)
					{
						CS$<>8__locals1.$VB$NonLocal_2.Forge_StateChanged((MyLoading)a0, a1);
					});
					MyLoading myLoading3 = myLoading;
					MyCard._Closure$__R15-2 CS$<>8__locals2 = new MyCard._Closure$__R15-2(CS$<>8__locals2);
					CS$<>8__locals2.$VB$NonLocal_3 = ModMain.m_PageFilter;
					myLoading3.PrepareVal(delegate(object sender, MouseButtonEventArgs e)
					{
						CS$<>8__locals2.$VB$NonLocal_3.Forge_Click((MyLoading)sender, e);
					});
					Stack.Children.Add(myLoading);
					break;
				}
				case 6:
					ModDownloadLib.ForgeDownloadListItemPreload(Stack, (List<ModDownload.DlForgeVersionEntry>)Stack.Tag, new MyListItem.ClickEventHandler(ModDownloadLib.ForgeSave_Click), true);
					break;
				case 8:
				{
					StackPanel stack = Stack;
					List<ModDownload.DlCfFile> entrys = (List<ModDownload.DlCfFile>)Stack.Tag;
					MyCard._Closure$__R15-3 CS$<>8__locals3 = new MyCard._Closure$__R15-3(CS$<>8__locals3);
					CS$<>8__locals3.$VB$NonLocal_4 = ModMain.m_TestFilter;
					ModDownload.DlCfFilesPreload(stack, entrys, delegate(object sender, MouseButtonEventArgs e)
					{
						CS$<>8__locals3.$VB$NonLocal_4.ProjectClick((MyCfItem)sender, e);
					});
					break;
				}
				}
				try
				{
					foreach (object obj in ((IEnumerable)Stack.Tag))
					{
						object objectValue = RuntimeHelpers.GetObjectValue(obj);
						switch (Type)
						{
						case 0:
							Stack.Children.Add(ModMinecraft.McVersionListItem((ModMinecraft.McVersion)objectValue));
							break;
						case 1:
						{
							UIElementCollection children = Stack.Children;
							object obj2 = objectValue;
							children.Add(ModMain.FeedbackListItem((obj2 != null) ? ((ModMain.FeedbackEntry)obj2) : default(ModMain.FeedbackEntry), CardTitle));
							break;
						}
						case 2:
							Stack.Children.Add(ModDownloadLib.McDownloadListItem((JObject)objectValue, new MyListItem.ClickEventHandler(ModDownloadLib.McDownloadMenuSave), true));
							break;
						case 3:
							Stack.Children.Add(ModDownloadLib.OptiFineDownloadListItem((ModDownload.DlOptiFineListEntry)objectValue, new MyListItem.ClickEventHandler(ModDownloadLib.OptiFineSave_Click), true));
							break;
						case 4:
						{
							UIElementCollection children2 = Stack.Children;
							ModDownload.DlLiteLoaderListEntry entry = (ModDownload.DlLiteLoaderListEntry)objectValue;
							MyCard._Closure$__R15-4 CS$<>8__locals4 = new MyCard._Closure$__R15-4(CS$<>8__locals4);
							CS$<>8__locals4.$VB$NonLocal_5 = ModMain.creatorFilter;
							children2.Add(ModDownloadLib.LiteLoaderDownloadListItem(entry, delegate(object sender, MouseButtonEventArgs e)
							{
								CS$<>8__locals4.$VB$NonLocal_5.DownloadStart((MyListItem)sender, e);
							}, false));
							break;
						}
						case 5:
							break;
						case 6:
							Stack.Children.Add(ModDownloadLib.ForgeDownloadListItem((ModDownload.DlForgeVersionEntry)objectValue, new MyListItem.ClickEventHandler(ModDownloadLib.ForgeSave_Click), true));
							break;
						case 7:
						{
							UIElementCollection children3 = Stack.Children;
							JObject entry2 = (JObject)objectValue;
							MyCard._Closure$__R15-5 CS$<>8__locals5 = new MyCard._Closure$__R15-5(CS$<>8__locals5);
							CS$<>8__locals5.$VB$NonLocal_6 = ModMain.propertyFilter;
							children3.Add(ModDownloadLib.McDownloadListItem(entry2, delegate(object sender, MouseButtonEventArgs e)
							{
								CS$<>8__locals5.$VB$NonLocal_6.MinecraftSelected((MyListItem)sender, e);
							}, false));
							break;
						}
						case 8:
							Stack.Children.Add(((ModDownload.DlCfFile)objectValue).ToListItem(new MyListItem.ClickEventHandler(ModMain.m_ConfigFilter.Save_Click), null));
							break;
						case 9:
						{
							UIElementCollection children4 = Stack.Children;
							ModDownload.DlCfFile dlCfFile = (ModDownload.DlCfFile)objectValue;
							MyCard._Closure$__R15-6 CS$<>8__locals6 = new MyCard._Closure$__R15-6(CS$<>8__locals6);
							CS$<>8__locals6.$VB$NonLocal_7 = ModMain.m_ConfigFilter;
							children4.Add(dlCfFile.ToListItem(delegate(object sender, MouseButtonEventArgs e)
							{
								CS$<>8__locals6.$VB$NonLocal_7.Install_Click((MyListItem)sender, e);
							}, new MyIconButton.ClickEventHandler(ModMain.m_ConfigFilter.Save_Click)));
							break;
						}
						case 0xA:
							Stack.Children.Add(ModDownloadLib.LiteLoaderDownloadListItem((ModDownload.DlLiteLoaderListEntry)objectValue, new MyListItem.ClickEventHandler(ModDownloadLib.LiteLoaderSave_Click), true));
							break;
						case 0xB:
							Stack.Children.Add(((ModMain.HelpEntry)objectValue).ToListItem());
							break;
						default:
							ModBase.Log("未知的虚拟化种类：" + Conversions.ToString(Type), ModBase.LogLevel.Feedback, "出现错误");
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
				Stack.Children.Add(new FrameworkElement
				{
					Height = 18.0
				});
				Stack.Tag = null;
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000E6A8 File Offset: 0x0000C8A8
		private void MyCard_MouseEnter(object sender, MouseEventArgs e)
		{
			ArrayList arrayList = new ArrayList();
			if (!Information.IsNothing(this.m_Bridge))
			{
				arrayList.Add(ModAni.AaColor(this.m_Bridge, TextBlock.ForegroundProperty, "ColorBrush2", 0x96, 0, null, false));
			}
			if (!Information.IsNothing(this.singleton))
			{
				arrayList.Add(ModAni.AaColor(this.singleton, Shape.FillProperty, "ColorBrush2", 0x96, 0, null, false));
			}
			arrayList.AddRange(new ModAni.AniData[]
			{
				ModAni.AaColor(this._Code, SystemDropShadowChrome.m_HelperModel, "ColorObject2", 0xB4, 0, null, false),
				ModAni.AaColor(this.m_Mapping, Border.BackgroundProperty, new ModBase.MyColor(230.0, 255.0, 255.0, 255.0) - this.m_Mapping.Background, 0xB4, 0, null, false),
				ModAni.AaOpacity(this._Code, 0.3 - this._Code.Opacity, 0xB4, 0, null, false)
			});
			ModAni.AniStart(arrayList, "MyCard Mouse " + Conversions.ToString(this._Object), false);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000E800 File Offset: 0x0000CA00
		private void MyCard_MouseLeave(object sender, MouseEventArgs e)
		{
			ArrayList arrayList = new ArrayList();
			if (!Information.IsNothing(this.m_Bridge))
			{
				arrayList.Add(ModAni.AaColor(this.m_Bridge, TextBlock.ForegroundProperty, "ColorBrush1", 0xFA, 0, null, false));
			}
			if (!Information.IsNothing(this.singleton))
			{
				arrayList.Add(ModAni.AaColor(this.singleton, Shape.FillProperty, "ColorBrush1", 0xFA, 0, null, false));
			}
			arrayList.AddRange(new ModAni.AniData[]
			{
				ModAni.AaColor(this._Code, SystemDropShadowChrome.m_HelperModel, "ColorObject1", 0x12C, 0, null, false),
				ModAni.AaColor(this.m_Mapping, Border.BackgroundProperty, new ModBase.MyColor(205.0, 255.0, 255.0, 255.0) - this.m_Mapping.Background, 0x12C, 0, null, false),
				ModAni.AaOpacity(this._Code, 0.1 - this._Code.Opacity, 0x12C, 0, null, false)
			});
			ModAni.AniStart(arrayList, "MyCard Mouse " + Conversions.ToString(this._Object), false);
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600006D RID: 109 RVA: 0x000027B0 File Offset: 0x000009B0
		// (set) Token: 0x0600006E RID: 110 RVA: 0x000027B8 File Offset: 0x000009B8
		public bool UseAnimation { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600006F RID: 111 RVA: 0x000027C1 File Offset: 0x000009C1
		// (set) Token: 0x06000070 RID: 112 RVA: 0x000027C9 File Offset: 0x000009C9
		public bool LoadAnimation { get; set; }

		// Token: 0x06000071 RID: 113 RVA: 0x0000E958 File Offset: 0x0000CB58
		private void MySizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (this.UseAnimation)
			{
				double num = (this.IsSwaped ? 40.0 : e.NewSize.Height) - e.PreviousSize.Height;
				bool flag;
				if ((!(flag = (e.PreviousSize.Height == 0.0)) || this.LoadAnimation) && !this.m_Database && Math.Abs(num) >= 1.0 && base.ActualHeight != 0.0)
				{
					if (flag)
					{
						this.StartHeightAnimation(Math.Min(20.0, num), num - Math.Min(20.0, num), true);
						return;
					}
					this.StartHeightAnimation(num, e.PreviousSize.Height, false);
				}
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000EA34 File Offset: 0x0000CC34
		private void StartHeightAnimation(double DeltaHeight, double PreviousHeight, bool IsLoadAnimation)
		{
			if (!this.m_Database && ModMain.m_GetterFilter != null)
			{
				ArrayList arrayList = new ArrayList();
				if (DeltaHeight <= 10.0 && (DeltaHeight >= -10.0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(this.thread))))
				{
					arrayList.AddRange(new ModAni.AniData[]
					{
						ModAni.AaHeight(this, DeltaHeight, checked((int)Math.Round(ModBase.MathRange(unchecked(Math.Abs(DeltaHeight) * 4.0), 150.0, 250.0))), 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false)
					});
				}
				else
				{
					double num = ModBase.MathRange(Math.Abs(DeltaHeight) * 0.05, 3.0, 10.0) * (double)Math.Sign(DeltaHeight);
					arrayList.AddRange(new ModAni.AniData[]
					{
						ModAni.AaHeight(this, DeltaHeight + num, 0x12C, IsLoadAnimation ? 0x1E : 0, (ModAni.AniEase)((DeltaHeight > ModMain.m_GetterFilter.Height) ? new ModAni.AniEaseInFluent(ModAni.AniEasePower.ExtraStrong) : new ModAni.AniEaseOutFluent(ModAni.AniEasePower.ExtraStrong)), false),
						ModAni.AaHeight(this, -num, 0x96, 0x104, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Strong), false)
					});
				}
				arrayList.Add(ModAni.AaCode(delegate
				{
					this.m_Database = false;
					base.Height = this.attr;
					if (this.IsSwaped)
					{
						NewLateBinding.LateSet(this.thread, null, "Visibility", new object[]
						{
							Visibility.Collapsed
						}, null, null);
					}
				}, 0, true));
				ModAni.AniStart(arrayList, "MyCard Height " + Conversions.ToString(this._Object), false);
				this.m_Database = true;
				this.attr = (this.IsSwaped ? 40.0 : base.Height);
				base.Height = PreviousHeight;
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000EBDC File Offset: 0x0000CDDC
		public void TriggerForceResize()
		{
			base.Height = (this.IsSwaped ? 40.0 : double.NaN);
			ModAni.AniStop("MyCard Height " + Conversions.ToString(this._Object));
			this.m_Database = false;
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000074 RID: 116 RVA: 0x000027D2 File Offset: 0x000009D2
		// (set) Token: 0x06000075 RID: 117 RVA: 0x000027DA File Offset: 0x000009DA
		public bool CanSwap { get; set; }

		// Token: 0x06000076 RID: 118 RVA: 0x000027E3 File Offset: 0x000009E3
		[CompilerGenerated]
		public int FillFactory()
		{
			return this._Item;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000027EB File Offset: 0x000009EB
		[CompilerGenerated]
		public void InitFactory(int AutoPropertyValue)
		{
			this._Item = AutoPropertyValue;
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000078 RID: 120 RVA: 0x000027F4 File Offset: 0x000009F4
		// (set) Token: 0x06000079 RID: 121 RVA: 0x0000EC2C File Offset: 0x0000CE2C
		public bool IsSwaped
		{
			get
			{
				return this.m_Serializer;
			}
			set
			{
				if (this.m_Serializer != value)
				{
					this.m_Serializer = value;
					if (this.thread != null)
					{
						if (!this.IsSwaped && this.thread.GetType().Equals(typeof(StackPanel)))
						{
							StackPanel stackPanel = (StackPanel)this.thread;
							MyCard.StackInstall(ref stackPanel, this.FillFactory(), this.Title);
							this.thread = stackPanel;
						}
						if (base.IsLoaded)
						{
							NewLateBinding.LateSet(this.thread, null, "Visibility", new object[]
							{
								Visibility.Visible
							}, null, null);
							this.TriggerForceResize();
							ModAni.AniStart(ModAni.AaRotateTransform(this.singleton, (double)(this.m_Serializer ? (this.SwapLogoRight ? 0x10E : 0) : 0xB4) - ((RotateTransform)this.singleton.RenderTransform).Angle, 0x190, 0, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Weak), false), "MyCard Swap " + Conversions.ToString(this._Object), true);
						}
					}
				}
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600007A RID: 122 RVA: 0x000027FC File Offset: 0x000009FC
		// (set) Token: 0x0600007B RID: 123 RVA: 0x00002804 File Offset: 0x00000A04
		public bool SwapLogoRight { get; set; }

		// Token: 0x0600007C RID: 124 RVA: 0x0000ED3C File Offset: 0x0000CF3C
		[CompilerGenerated]
		public void DeleteFactory(MyCard.PreviewSwapEventHandler obj)
		{
			MyCard.PreviewSwapEventHandler previewSwapEventHandler = this._Proccesor;
			MyCard.PreviewSwapEventHandler previewSwapEventHandler2;
			do
			{
				previewSwapEventHandler2 = previewSwapEventHandler;
				MyCard.PreviewSwapEventHandler value = (MyCard.PreviewSwapEventHandler)Delegate.Combine(previewSwapEventHandler2, obj);
				previewSwapEventHandler = Interlocked.CompareExchange<MyCard.PreviewSwapEventHandler>(ref this._Proccesor, value, previewSwapEventHandler2);
			}
			while (previewSwapEventHandler != previewSwapEventHandler2);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000ED74 File Offset: 0x0000CF74
		[CompilerGenerated]
		public void RemoveFactory(MyCard.PreviewSwapEventHandler obj)
		{
			MyCard.PreviewSwapEventHandler previewSwapEventHandler = this._Proccesor;
			MyCard.PreviewSwapEventHandler previewSwapEventHandler2;
			do
			{
				previewSwapEventHandler2 = previewSwapEventHandler;
				MyCard.PreviewSwapEventHandler value = (MyCard.PreviewSwapEventHandler)Delegate.Remove(previewSwapEventHandler2, obj);
				previewSwapEventHandler = Interlocked.CompareExchange<MyCard.PreviewSwapEventHandler>(ref this._Proccesor, value, previewSwapEventHandler2);
			}
			while (previewSwapEventHandler != previewSwapEventHandler2);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000EDAC File Offset: 0x0000CFAC
		[CompilerGenerated]
		public void QueryFactory(MyCard.SwapEventHandler obj)
		{
			MyCard.SwapEventHandler swapEventHandler = this.@ref;
			MyCard.SwapEventHandler swapEventHandler2;
			do
			{
				swapEventHandler2 = swapEventHandler;
				MyCard.SwapEventHandler value = (MyCard.SwapEventHandler)Delegate.Combine(swapEventHandler2, obj);
				swapEventHandler = Interlocked.CompareExchange<MyCard.SwapEventHandler>(ref this.@ref, value, swapEventHandler2);
			}
			while (swapEventHandler != swapEventHandler2);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000EDE4 File Offset: 0x0000CFE4
		[CompilerGenerated]
		public void PushFactory(MyCard.SwapEventHandler obj)
		{
			MyCard.SwapEventHandler swapEventHandler = this.@ref;
			MyCard.SwapEventHandler swapEventHandler2;
			do
			{
				swapEventHandler2 = swapEventHandler;
				MyCard.SwapEventHandler value = (MyCard.SwapEventHandler)Delegate.Remove(swapEventHandler2, obj);
				swapEventHandler = Interlocked.CompareExchange<MyCard.SwapEventHandler>(ref this.@ref, value, swapEventHandler2);
			}
			while (swapEventHandler != swapEventHandler2);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000EE1C File Offset: 0x0000D01C
		private void MyCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			double y = Mouse.GetPosition(this).Y;
			if (this.IsSwaped || (!Information.IsNothing(RuntimeHelpers.GetObjectValue(this.thread)) && y <= 40.0 && (y != 0.0 || base.IsMouseDirectlyOver)))
			{
				this._System = true;
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000EE7C File Offset: 0x0000D07C
		private void MyCard_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (this._System)
			{
				this._System = false;
				double y = Mouse.GetPosition(this).Y;
				if (this.IsSwaped || (!Information.IsNothing(RuntimeHelpers.GetObjectValue(this.thread)) && y <= 40.0 && (y != 0.0 || base.IsMouseDirectlyOver)))
				{
					ModBase.RouteEventArgs routeEventArgs = new ModBase.RouteEventArgs(true);
					MyCard.PreviewSwapEventHandler proccesor = this._Proccesor;
					if (proccesor != null)
					{
						proccesor(this, routeEventArgs);
					}
					if (routeEventArgs._HelperMapper)
					{
						this._System = false;
						return;
					}
					this.IsSwaped = !this.IsSwaped;
					ModBase.Log("[Control] " + (this.IsSwaped ? "折叠卡片" : "展开卡片") + ((this.Title == null) ? "" : ("：" + this.Title)), ModBase.LogLevel.Normal, "出现错误");
					MyCard.SwapEventHandler swapEventHandler = this.@ref;
					if (swapEventHandler != null)
					{
						swapEventHandler(this, routeEventArgs);
					}
				}
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000280D File Offset: 0x00000A0D
		private void MyCard_MouseLeave_Swap(object sender, MouseEventArgs e)
		{
			this._System = false;
		}

		// Token: 0x04000017 RID: 23
		private readonly Grid facade;

		// Token: 0x04000018 RID: 24
		private readonly SystemDropShadowChrome _Code;

		// Token: 0x04000019 RID: 25
		private readonly Border m_Mapping;

		// Token: 0x0400001A RID: 26
		public TextBlock m_Bridge;

		// Token: 0x0400001B RID: 27
		public Path singleton;

		// Token: 0x0400001C RID: 28
		public int _Object;

		// Token: 0x0400001D RID: 29
		public static readonly DependencyProperty callback;

		// Token: 0x0400001E RID: 30
		private bool worker;

		// Token: 0x0400001F RID: 31
		[CompilerGenerated]
		private bool _Indexer;

		// Token: 0x04000020 RID: 32
		[CompilerGenerated]
		private bool method;

		// Token: 0x04000021 RID: 33
		private bool m_Database;

		// Token: 0x04000022 RID: 34
		private double attr;

		// Token: 0x04000023 RID: 35
		public object thread;

		// Token: 0x04000024 RID: 36
		[CompilerGenerated]
		private bool m_Manager;

		// Token: 0x04000025 RID: 37
		[CompilerGenerated]
		private int _Item;

		// Token: 0x04000026 RID: 38
		private bool m_Serializer;

		// Token: 0x04000027 RID: 39
		[CompilerGenerated]
		private bool repository;

		// Token: 0x04000028 RID: 40
		private bool _System;

		// Token: 0x04000029 RID: 41
		[CompilerGenerated]
		private MyCard.PreviewSwapEventHandler _Proccesor;

		// Token: 0x0400002A RID: 42
		[CompilerGenerated]
		private MyCard.SwapEventHandler @ref;

		// Token: 0x02000014 RID: 20
		// (Invoke) Token: 0x06000088 RID: 136
		public delegate void PreviewSwapEventHandler(object sender, ModBase.RouteEventArgs e);

		// Token: 0x02000015 RID: 21
		// (Invoke) Token: 0x0600008C RID: 140
		public delegate void SwapEventHandler(object sender, ModBase.RouteEventArgs e);
	}
}
