using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace PCL
{
	// Token: 0x02000093 RID: 147
	[DesignerGenerated]
	public class PageLoginMs : StackPanel, IComponentConnector
	{
		// Token: 0x0600053A RID: 1338 RVA: 0x00005191 File Offset: 0x00003391
		public PageLoginMs()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x0000519F File Offset: 0x0000339F
		public void Reload(bool KeepInput)
		{
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x000051A1 File Offset: 0x000033A1
		public ModLaunch.McLoginMs GetLoginData()
		{
			return new ModLaunch.McLoginMs
			{
				creatorAlgo = Conversions.ToString(ModBase._BaseRule.Get("CacheMsOAuthRefresh", null)),
				testAlgo = Conversions.ToString(ModBase._BaseRule.Get("CacheMsName", null))
			};
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0002A9D0 File Offset: 0x00028BD0
		public static string IsVaild(ModLaunch.McLoginMs LoginData)
		{
			string result;
			if (Operators.CompareString(LoginData.creatorAlgo, "", true) == 0)
			{
				result = "请在登录账号后再继续！";
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x000051DE File Offset: 0x000033DE
		public string IsVaild()
		{
			return PageLoginMs.IsVaild(this.GetLoginData());
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x000051EB File Offset: 0x000033EB
		private void BtnLogin_Click(object sender, EventArgs e)
		{
			this.BtnLogin.IsEnabled = false;
			this.BtnLogin.Text = "登录中 0%";
			ModBase.RunInNewThread(delegate
			{
				try
				{
					ModLaunch.systemIterator.Start(this.GetLoginData(), false);
					while (ModLaunch.systemIterator.State == ModBase.LoadState.Loading)
					{
						ModBase.RunInUi(delegate()
						{
							this.BtnLogin.Text = "登录中 " + Conversions.ToString(Math.Round(ModLaunch.systemIterator.Progress * 100.0)) + "%";
						}, false);
						Thread.Sleep(0x32);
					}
					if (ModLaunch.systemIterator.State == ModBase.LoadState.Finished)
					{
						ModBase.RunInUi((PageLoginMs._Closure$__.$I5-2 == null) ? (PageLoginMs._Closure$__.$I5-2 = delegate()
						{
							ModMain.m_InvocationFilter.RefreshPage(false, true);
						}) : PageLoginMs._Closure$__.$I5-2, false);
					}
					else
					{
						if (ModLaunch.systemIterator.State == ModBase.LoadState.Aborted)
						{
							throw new OperationCanceledException();
						}
						if (ModLaunch.systemIterator.Error == null)
						{
							throw new Exception("未知错误！");
						}
						throw new Exception(ModLaunch.systemIterator.Error.Message, ModLaunch.systemIterator.Error);
					}
				}
				catch (OperationCanceledException ex)
				{
					ModMain.Hint("登录已取消！", ModMain.HintType.Info, true);
				}
				catch (Exception ex2)
				{
					if (Operators.CompareString(ex2.Message, "$$", true) != 0)
					{
						if (ex2.Message.StartsWith("$"))
						{
							ModMain.Hint(ex2.Message.TrimStart(new char[]
							{
								'$'
							}), ModMain.HintType.Critical, true);
						}
						else
						{
							ModBase.Log(ex2, "微软登录尝试失败", ModBase.LogLevel.Msgbox, "出现错误");
						}
					}
				}
				finally
				{
					ModBase.RunInUi(delegate()
					{
						this.BtnLogin.IsEnabled = true;
						this.BtnLogin.Text = "添加账号";
					}, false);
				}
			}, "Ms Login", ThreadPriority.Normal);
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000540 RID: 1344 RVA: 0x00005221 File Offset: 0x00003421
		// (set) Token: 0x06000541 RID: 1345 RVA: 0x00005229 File Offset: 0x00003429
		internal virtual StackPanel PanEmpty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000542 RID: 1346 RVA: 0x00005232 File Offset: 0x00003432
		// (set) Token: 0x06000543 RID: 1347 RVA: 0x0002AA00 File Offset: 0x00028C00
		internal virtual MyButton BtnLogin
		{
			[CompilerGenerated]
			get
			{
				return this.customerContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnLogin_Click);
				MyButton myButton = this.customerContainer;
				if (myButton != null)
				{
					myButton.CancelModel(obj);
				}
				this.customerContainer = value;
				myButton = this.customerContainer;
				if (myButton != null)
				{
					myButton.ValidateModel(obj);
				}
			}
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0002AA44 File Offset: 0x00028C44
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this._TaskContainer)
			{
				this._TaskContainer = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagelaunch/pageloginms.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0000523A File Offset: 0x0000343A
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanEmpty = (StackPanel)target;
				return;
			}
			if (connectionId == 2)
			{
				this.BtnLogin = (MyButton)target;
				return;
			}
			this._TaskContainer = true;
		}

		// Token: 0x04000281 RID: 641
		[CompilerGenerated]
		[AccessedThroughProperty("PanEmpty")]
		private StackPanel _InstanceContainer;

		// Token: 0x04000282 RID: 642
		[CompilerGenerated]
		[AccessedThroughProperty("BtnLogin")]
		private MyButton customerContainer;

		// Token: 0x04000283 RID: 643
		private bool _TaskContainer;
	}
}
