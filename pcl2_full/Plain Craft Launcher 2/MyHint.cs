using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PCL
{
	// Token: 0x0200003E RID: 62
	[DesignerGenerated]
	public class MyHint : Border, IComponentConnector
	{
		// Token: 0x06000137 RID: 311 RVA: 0x00002EFE File Offset: 0x000010FE
		public MyHint()
		{
			base.Loaded += this.MyHint_Loaded;
			this.interceptor = ModBase.GetUuid();
			this.m_Invocation = true;
			this._Candidate = "";
			this.InitializeComponent();
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00002F3B File Offset: 0x0000113B
		// (set) Token: 0x06000139 RID: 313 RVA: 0x00012ECC File Offset: 0x000110CC
		public bool IsWarn
		{
			get
			{
				return this.m_Invocation;
			}
			set
			{
				if (this.m_Invocation != value)
				{
					this.m_Invocation = value;
					if (this.m_Invocation)
					{
						base.BorderBrush = new ModBase.MyColor("#99FF4444");
						this.Gradient1.Color = new ModBase.MyColor("#88FFBBBB");
						this.Gradient2.Color = new ModBase.MyColor("#88FF8888");
						this.Path.Fill = new ModBase.MyColor("#BF0000");
						this.LabText.Foreground = new ModBase.MyColor("#BF0000");
						this.BtnClose.Foreground = new ModBase.MyColor("#BF0000");
						this.Path.Data = (Geometry)new GeometryConverter().ConvertFromString("F1 M 58.5832,55.4172L 17.4169,55.4171C 15.5619,53.5621 15.5619,50.5546 17.4168,48.6996L 35.201,15.8402C 37.056,13.9852 40.0635,13.9852 41.9185,15.8402L 58.5832,48.6997C 60.4382,50.5546 60.4382,53.5622 58.5832,55.4172 Z M 34.0417,25.7292L 36.0208,41.9584L 39.9791,41.9583L 41.9583,25.7292L 34.0417,25.7292 Z M 38,44.3333C 36.2511,44.3333 34.8333,45.7511 34.8333,47.5C 34.8333,49.2489 36.2511,50.6667 38,50.6667C 39.7489,50.6667 41.1666,49.2489 41.1666,47.5C 41.1666,45.7511 39.7489,44.3333 38,44.3333 Z ");
						return;
					}
					base.BorderBrush = new ModBase.MyColor("#994D76FF");
					this.Gradient1.Color = new ModBase.MyColor("#88B0D0FF");
					this.Gradient2.Color = new ModBase.MyColor("#889EBAFF");
					this.Path.Fill = new ModBase.MyColor("#0062BF");
					this.LabText.Foreground = new ModBase.MyColor("#0062BF");
					this.BtnClose.Foreground = new ModBase.MyColor("#0062BF");
					this.Path.Data = (Geometry)new GeometryConverter().ConvertFromString("F1M38,19C48.4934,19 57,27.5066 57,38 57,48.4934 48.4934,57 38,57 27.5066,57 19,48.4934 19,38 19,27.5066 27.5066,19 38,19z M33.25,33.25L33.25,36.4167 36.4166,36.4167 36.4166,47.5 33.25,47.5 33.25,50.6667 44.3333,50.6667 44.3333,47.5 41.1666,47.5 41.1666,36.4167 41.1666,33.25 33.25,33.25z M38.7917,25.3333C37.48,25.3333 36.4167,26.3967 36.4167,27.7083 36.4167,29.02 37.48,30.0833 38.7917,30.0833 40.1033,30.0833 41.1667,29.02 41.1667,27.7083 41.1667,26.3967 40.1033,25.3333 38.7917,25.3333z");
				}
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00002F43 File Offset: 0x00001143
		// (set) Token: 0x0600013B RID: 315 RVA: 0x00002F50 File Offset: 0x00001150
		public string Text
		{
			get
			{
				return this.LabText.Text;
			}
			set
			{
				this.LabText.Text = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00002F5E File Offset: 0x0000115E
		// (set) Token: 0x0600013D RID: 317 RVA: 0x00002F6E File Offset: 0x0000116E
		public bool CanClose
		{
			get
			{
				return this.BtnClose.Visibility == Visibility.Visible;
			}
			set
			{
				this.BtnClose.Visibility = (value ? Visibility.Visible : Visibility.Collapsed);
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00002F82 File Offset: 0x00001182
		private void MyHint_Loaded(object sender, RoutedEventArgs e)
		{
			if (Conversions.ToBoolean(this.CanClose && Conversions.ToBoolean(ModBase._BaseRule.Get(this._Candidate, null))))
			{
				base.Visibility = Visibility.Collapsed;
			}
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00002FB8 File Offset: 0x000011B8
		private void BtnClose_Click(object sender, EventArgs e)
		{
			ModBase._BaseRule.Set(this._Candidate, true, false, null);
			ModAni.AniDispose(this, false, null);
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000140 RID: 320 RVA: 0x00002FDA File Offset: 0x000011DA
		// (set) Token: 0x06000141 RID: 321 RVA: 0x00002FE2 File Offset: 0x000011E2
		internal virtual MyHint PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000142 RID: 322 RVA: 0x00002FEB File Offset: 0x000011EB
		// (set) Token: 0x06000143 RID: 323 RVA: 0x00002FF3 File Offset: 0x000011F3
		internal virtual GradientStop Gradient1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000144 RID: 324 RVA: 0x00002FFC File Offset: 0x000011FC
		// (set) Token: 0x06000145 RID: 325 RVA: 0x00003004 File Offset: 0x00001204
		internal virtual GradientStop Gradient2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000146 RID: 326 RVA: 0x0000300D File Offset: 0x0000120D
		// (set) Token: 0x06000147 RID: 327 RVA: 0x00003015 File Offset: 0x00001215
		internal virtual Path Path { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000148 RID: 328 RVA: 0x0000301E File Offset: 0x0000121E
		// (set) Token: 0x06000149 RID: 329 RVA: 0x00003026 File Offset: 0x00001226
		internal virtual TextBlock LabText { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600014A RID: 330 RVA: 0x0000302F File Offset: 0x0000122F
		// (set) Token: 0x0600014B RID: 331 RVA: 0x00013064 File Offset: 0x00011264
		internal virtual MyIconButton BtnClose
		{
			[CompilerGenerated]
			get
			{
				return this._Initializer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyIconButton.ClickEventHandler value2 = new MyIconButton.ClickEventHandler(this.BtnClose_Click);
				MyIconButton initializer = this._Initializer;
				if (initializer != null)
				{
					initializer.Click -= value2;
				}
				this._Initializer = value;
				initializer = this._Initializer;
				if (initializer != null)
				{
					initializer.Click += value2;
				}
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x000130A8 File Offset: 0x000112A8
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.watcher)
			{
				this.watcher = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/controls/myhint.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x000130D8 File Offset: 0x000112D8
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (MyHint)target;
				return;
			}
			if (connectionId == 2)
			{
				this.Gradient1 = (GradientStop)target;
				return;
			}
			if (connectionId == 3)
			{
				this.Gradient2 = (GradientStop)target;
				return;
			}
			if (connectionId == 4)
			{
				this.Path = (Path)target;
				return;
			}
			if (connectionId == 5)
			{
				this.LabText = (TextBlock)target;
				return;
			}
			if (connectionId == 6)
			{
				this.BtnClose = (MyIconButton)target;
				return;
			}
			this.watcher = true;
		}

		// Token: 0x0400009F RID: 159
		public int interceptor;

		// Token: 0x040000A0 RID: 160
		private bool m_Invocation;

		// Token: 0x040000A1 RID: 161
		public string _Candidate;

		// Token: 0x040000A2 RID: 162
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private MyHint context;

		// Token: 0x040000A3 RID: 163
		[CompilerGenerated]
		[AccessedThroughProperty("Gradient1")]
		private GradientStop m_Observer;

		// Token: 0x040000A4 RID: 164
		[AccessedThroughProperty("Gradient2")]
		[CompilerGenerated]
		private GradientStop m_Tokenizer;

		// Token: 0x040000A5 RID: 165
		[AccessedThroughProperty("Path")]
		[CompilerGenerated]
		private Path _Dispatcher;

		// Token: 0x040000A6 RID: 166
		[CompilerGenerated]
		[AccessedThroughProperty("LabText")]
		private TextBlock m_Tag;

		// Token: 0x040000A7 RID: 167
		[AccessedThroughProperty("BtnClose")]
		[CompilerGenerated]
		private MyIconButton _Initializer;

		// Token: 0x040000A8 RID: 168
		private bool watcher;
	}
}
