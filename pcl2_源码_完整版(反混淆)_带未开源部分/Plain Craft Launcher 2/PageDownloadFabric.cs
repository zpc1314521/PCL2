using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x02000085 RID: 133
	[DesignerGenerated]
	public class PageDownloadFabric : AdornerDecorator, IComponentConnector
	{
		// Token: 0x06000396 RID: 918 RVA: 0x00004230 File Offset: 0x00002430
		// Note: this type is marked as 'beforefieldinit'.
		static PageDownloadFabric()
		{
			PageDownloadFabric.watcherVal = 1;
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00004238 File Offset: 0x00002438
		public PageDownloadFabric()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.Init();
			};
			this.propertyVal = false;
			this.InitializeComponent();
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0000425F File Offset: 0x0000245F
		private void Init()
		{
			this.PanBack.ScrollToHome();
			ModDownload.m_ObjectIterator.Start(PageDownloadFabric.watcherVal, false);
			if (!this.propertyVal)
			{
				this.propertyVal = true;
				this.Load.State = ModDownload.m_ObjectIterator;
			}
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0000429B File Offset: 0x0000249B
		public static void RefreshLoader()
		{
			checked
			{
				PageDownloadFabric.watcherVal++;
				ModDownload.m_ObjectIterator.Start(PageDownloadFabric.watcherVal, false);
			}
		}

		// Token: 0x0600039A RID: 922 RVA: 0x000042B9 File Offset: 0x000024B9
		private void Load_Click(object sender, MouseButtonEventArgs e)
		{
			if (this.Load.State.LoadingState == MyLoading.MyLoadingState.Error)
			{
				PageDownloadFabric.RefreshLoader();
			}
		}

		// Token: 0x0600039B RID: 923 RVA: 0x000245F4 File Offset: 0x000227F4
		private void Load_State(object sender, MyLoading.MyLoadingState state)
		{
			ModBase.LoadState state2 = ModDownload.m_ObjectIterator.State;
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

		// Token: 0x0600039C RID: 924 RVA: 0x00024624 File Offset: 0x00022824
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
					this.PanVersions.Children.Clear();
				}, 0, true)
			}, "FrmDownloadFabric Load Switch", false);
		}

		// Token: 0x0600039D RID: 925 RVA: 0x000246C0 File Offset: 0x000228C0
		private void Load_OnFinish()
		{
			try
			{
				JArray jarray = (JArray)ModDownload.m_ObjectIterator.Output.Value["installer"];
				this.PanVersions.Children.Clear();
				try
				{
					foreach (JToken jtoken in jarray)
					{
						this.PanVersions.Children.Add(ModDownloadLib.FabricDownloadListItem((JObject)jtoken, delegate(object sender, MouseButtonEventArgs e)
						{
							this.Fabric_Selected((MyListItem)sender, e);
						}));
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
				this.CardVersions.Title = "版本列表 (" + Conversions.ToString(jarray.Count) + ")";
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "可视化 Fabric 版本列表出错", ModBase.LogLevel.Feedback, "出现错误");
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
			}, "FrmDownloadFabric Load Switch", false);
		}

		// Token: 0x0600039E RID: 926 RVA: 0x000042D3 File Offset: 0x000024D3
		private void Fabric_Selected(MyListItem sender, EventArgs e)
		{
			ModDownloadLib.McDownloadFabricLoaderSave((JObject)sender.Tag);
		}

		// Token: 0x0600039F RID: 927 RVA: 0x000042E5 File Offset: 0x000024E5
		private void BtnWeb_Click(object sender, EventArgs e)
		{
			ModBase.OpenWebsite("https://www.fabricmc.net");
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x000042F1 File Offset: 0x000024F1
		// (set) Token: 0x060003A1 RID: 929 RVA: 0x000042F9 File Offset: 0x000024F9
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x00004302 File Offset: 0x00002502
		// (set) Token: 0x060003A3 RID: 931 RVA: 0x0000430A File Offset: 0x0000250A
		internal virtual MyCard CardTip { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x00004313 File Offset: 0x00002513
		// (set) Token: 0x060003A5 RID: 933 RVA: 0x00024838 File Offset: 0x00022A38
		internal virtual MyButton BtnWeb
		{
			[CompilerGenerated]
			get
			{
				return this.m_PageVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnWeb_Click);
				MyButton pageVal = this.m_PageVal;
				if (pageVal != null)
				{
					pageVal.CancelModel(obj);
				}
				this.m_PageVal = value;
				pageVal = this.m_PageVal;
				if (pageVal != null)
				{
					pageVal.ValidateModel(obj);
				}
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x0000431B File Offset: 0x0000251B
		// (set) Token: 0x060003A7 RID: 935 RVA: 0x00004323 File Offset: 0x00002523
		internal virtual MyCard CardVersions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060003A8 RID: 936 RVA: 0x0000432C File Offset: 0x0000252C
		// (set) Token: 0x060003A9 RID: 937 RVA: 0x00004334 File Offset: 0x00002534
		internal virtual StackPanel PanVersions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060003AA RID: 938 RVA: 0x0000433D File Offset: 0x0000253D
		// (set) Token: 0x060003AB RID: 939 RVA: 0x00004345 File Offset: 0x00002545
		internal virtual MyCard PanLoad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060003AC RID: 940 RVA: 0x0000434E File Offset: 0x0000254E
		// (set) Token: 0x060003AD RID: 941 RVA: 0x0002487C File Offset: 0x00022A7C
		internal virtual MyLoading Load
		{
			[CompilerGenerated]
			get
			{
				return this.m_AuthenticationVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyLoading.ClickEventHandler obj = new MyLoading.ClickEventHandler(this.Load_Click);
				MyLoading.StateChangedEventHandler obj2 = new MyLoading.StateChangedEventHandler(this.Load_State);
				MyLoading authenticationVal = this.m_AuthenticationVal;
				if (authenticationVal != null)
				{
					authenticationVal.UpdateVal(obj);
					authenticationVal.InitVal(obj2);
				}
				this.m_AuthenticationVal = value;
				authenticationVal = this.m_AuthenticationVal;
				if (authenticationVal != null)
				{
					authenticationVal.PrepareVal(obj);
					authenticationVal.FillVal(obj2);
				}
			}
		}

		// Token: 0x060003AE RID: 942 RVA: 0x000248DC File Offset: 0x00022ADC
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.m_ProcessVal)
			{
				this.m_ProcessVal = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagedownload/pagedownloadfabric.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0002490C File Offset: 0x00022B0C
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
				this.CardTip = (MyCard)target;
				return;
			}
			if (connectionId == 3)
			{
				this.BtnWeb = (MyButton)target;
				return;
			}
			if (connectionId == 4)
			{
				this.CardVersions = (MyCard)target;
				return;
			}
			if (connectionId == 5)
			{
				this.PanVersions = (StackPanel)target;
				return;
			}
			if (connectionId == 6)
			{
				this.PanLoad = (MyCard)target;
				return;
			}
			if (connectionId == 7)
			{
				this.Load = (MyLoading)target;
				return;
			}
			this.m_ProcessVal = true;
		}

		// Token: 0x040001EA RID: 490
		private bool propertyVal;

		// Token: 0x040001EB RID: 491
		public static int watcherVal;

		// Token: 0x040001EC RID: 492
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private MyScrollViewer stateVal;

		// Token: 0x040001ED RID: 493
		[AccessedThroughProperty("CardTip")]
		[CompilerGenerated]
		private MyCard creatorVal;

		// Token: 0x040001EE RID: 494
		[AccessedThroughProperty("BtnWeb")]
		[CompilerGenerated]
		private MyButton m_PageVal;

		// Token: 0x040001EF RID: 495
		[CompilerGenerated]
		[AccessedThroughProperty("CardVersions")]
		private MyCard m_InstanceVal;

		// Token: 0x040001F0 RID: 496
		[AccessedThroughProperty("PanVersions")]
		[CompilerGenerated]
		private StackPanel customerVal;

		// Token: 0x040001F1 RID: 497
		[CompilerGenerated]
		[AccessedThroughProperty("PanLoad")]
		private MyCard _TaskVal;

		// Token: 0x040001F2 RID: 498
		[AccessedThroughProperty("Load")]
		[CompilerGenerated]
		private MyLoading m_AuthenticationVal;

		// Token: 0x040001F3 RID: 499
		private bool m_ProcessVal;
	}
}
