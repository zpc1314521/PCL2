using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PCL
{
	// Token: 0x02000137 RID: 311
	[DesignerGenerated]
	public class PageLaunchLeft : MyPageLeft, IComponentConnector
	{
		// Token: 0x06000B1B RID: 2843 RVA: 0x0005F960 File Offset: 0x0005DB60
		// Note: this type is marked as 'beforefieldinit'.
		static PageLaunchLeft()
		{
			PageLaunchLeft.m_AccountExpression = new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>("Loader Skin Mojang", new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>.LoadDelegateSub(PageLaunchLeft.SkinMojangLoad), new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>.InputDelegateSub(PageLaunchLeft.SkinMojangInput), ThreadPriority.AboveNormal);
			PageLaunchLeft.m_ConfigurationExpression = new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>("Loader Skin Ms", new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>.LoadDelegateSub(PageLaunchLeft.SkinMsLoad), new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>.InputDelegateSub(PageLaunchLeft.SkinMsInput), ThreadPriority.AboveNormal);
			PageLaunchLeft.m_InterpreterExpression = new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>("Loader Skin Legacy", new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>.LoadDelegateSub(PageLaunchLeft.SkinLegacyLoad), new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>.InputDelegateSub(PageLaunchLeft.SkinLegacyInput), ThreadPriority.AboveNormal);
			PageLaunchLeft._PredicateExpression = new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>("Loader Skin Nide", new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>.LoadDelegateSub(PageLaunchLeft.SkinNideLoad), new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>.InputDelegateSub(PageLaunchLeft.SkinNideInput), ThreadPriority.AboveNormal);
			PageLaunchLeft._StructExpression = new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>("Loader Skin Auth", new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>.LoadDelegateSub(PageLaunchLeft.SkinAuthLoad), new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>.InputDelegateSub(PageLaunchLeft.SkinAuthInput), ThreadPriority.AboveNormal);
			PageLaunchLeft.m_ResolverExpression = new List<ModLoader.LoaderTask<ModBase.EqualableList<string>, string>>
			{
				PageLaunchLeft.m_AccountExpression,
				PageLaunchLeft.m_ConfigurationExpression,
				PageLaunchLeft.m_InterpreterExpression,
				PageLaunchLeft._PredicateExpression,
				PageLaunchLeft._StructExpression
			};
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x0005FA78 File Offset: 0x0005DC78
		public PageLaunchLeft()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.PageLaunchLeft_Loaded();
			};
			this._RefExpression = false;
			this._ParameterExpression = false;
			this.m_StubExpression = PageLaunchLeft.PageType.None;
			this.m_CollectionExpression = 0;
			this._TestsExpression = null;
			this.m_BroadcasterExpression = 0.0;
			this.fieldExpression = false;
			this._RequestExpression = false;
			this.InitializeComponent();
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x0005FAE4 File Offset: 0x0005DCE4
		public void PageLaunchLeft_Loaded()
		{
			if (this._RefExpression)
			{
				this.RefreshPage(true, false);
			}
			this.AprilPosTrans.X = 0.0;
			this.AprilPosTrans.Y = 0.0;
			checked
			{
				if (!this._RefExpression)
				{
					this._RefExpression = true;
					ModAni.ListFactory(ModAni.InsertFactory() + 1);
					ModMinecraft.m_ParserIterator.LoadingStateChanged += delegate(MyLoading.MyLoadingState a0)
					{
						this.RefreshButtonsUI();
					};
					ModMinecraft._TestsIterator.LoadingStateChanged += delegate(MyLoading.MyLoadingState a0)
					{
						this.RefreshButtonsUI();
					};
					this.RefreshButtonsUI();
					ModBase.RunInNewThread(delegate
					{
						ModMinecraft.m_ResolverIterator = ModBase._BaseRule.Get("LaunchFolderSelect", null).ToString().Replace("$", ModBase.Path);
						if (Operators.CompareString(ModMinecraft.m_ResolverIterator, "", true) == 0 || !Directory.Exists(ModMinecraft.m_ResolverIterator))
						{
							if (Operators.CompareString(ModMinecraft.m_ResolverIterator, "", true) == 0)
							{
								ModBase.Log("[Launch] 没有已储存的 Minecraft 文件夹", ModBase.LogLevel.Normal, "出现错误");
							}
							else
							{
								ModBase.Log("[Launch] Minecraft 文件夹无效：" + ModMinecraft.m_ResolverIterator, ModBase.LogLevel.Debug, "出现错误");
							}
							ModMinecraft._TestsIterator.WaitForExit(0, null, false);
							ModBase._BaseRule.Set("LaunchFolderSelect", ModMinecraft.collectionIterator[0].Path.Replace(ModBase.Path, "$"), false, null);
						}
						ModBase.Log("[Launch] Minecraft 文件夹：" + ModMinecraft.m_ResolverIterator, ModBase.LogLevel.Normal, "出现错误");
						if (Conversions.ToBoolean(ModBase._BaseRule.Get("SystemDebugDelay", null)))
						{
							Thread.Sleep(ModBase.RandomInteger(0x1F4, 0xBB8));
						}
						string text = Conversions.ToString(ModBase._BaseRule.Get("LaunchVersionSelect", null));
						ModMinecraft.McVersion Version;
						if (Operators.CompareString(text, "", true) == 0)
						{
							Version = null;
						}
						else
						{
							Version = new ModMinecraft.McVersion(text);
						}
						if (Information.IsNothing(Version) || !Version.Path.StartsWith(ModMinecraft.m_ResolverIterator) || !Version.Check())
						{
							ModBase.Log("[Launch] Minecraft 版本无效" + (Information.IsNothing(Version) ? "，没有有效版本" : ("：" + Version.Path)), Information.IsNothing(Version) ? ModBase.LogLevel.Normal : ModBase.LogLevel.Debug, "出现错误");
							if (ModMinecraft.m_ParserIterator.State != ModBase.LoadState.Finished)
							{
								ModLoader.LoaderFolderRun(ModMinecraft.m_ParserIterator, ModMinecraft.m_ResolverIterator, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", true);
							}
							if (ModMinecraft.m_RequestIterator.Count != 0 && !ModMinecraft.m_RequestIterator.First<KeyValuePair<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>>>().Value[0].m_ConsumerAlgo.Contains("RedstoneBlock"))
							{
								Version = ModMinecraft.m_RequestIterator.First<KeyValuePair<ModMinecraft.McVersionCardType, List<ModMinecraft.McVersion>>>().Value[0];
								ModBase._BaseRule.Set("LaunchVersionSelect", Version.Name, false, null);
								ModBase.Log("[Launch] 自动选择 Minecraft 版本：" + Version.Path, ModBase.LogLevel.Normal, "出现错误");
							}
							else
							{
								Version = null;
								ModBase._BaseRule.Set("LaunchVersionSelect", "", false, null);
								ModBase.Log("[Launch] 无可用 Minecraft 版本", ModBase.LogLevel.Normal, "出现错误");
							}
						}
						ModBase.RunInUi(delegate()
						{
							ModMinecraft.CancelContainer(Version);
							this._ParameterExpression = true;
							this.RefreshButtonsUI();
							this.RefreshPage(false, false);
							if (Operators.CompareString(ModLaunch.McLoginAble(), "", true) == 0)
							{
								ModLaunch._InfoIterator.Start(null, false);
							}
						}, false);
					}, "Version Check", ThreadPriority.AboveNormal);
					ModLaunch.McLoginType mcLoginType = (ModLaunch.McLoginType)Conversions.ToInteger(ModBase._BaseRule.Get("LoginType", null));
					if (mcLoginType == ModLaunch.McLoginType.Legacy || mcLoginType == ModLaunch.McLoginType.Mojang || mcLoginType == ModLaunch.McLoginType.Ms)
					{
						((MyRadioButton)base.FindName("RadioLoginType" + Conversions.ToString((int)mcLoginType))).Checked = true;
					}
					this.RefreshPage(false, false);
					ModAni.ListFactory(ModAni.InsertFactory() - 1);
				}
			}
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x0005FBE8 File Offset: 0x0005DDE8
		public void PageChangeToLaunching()
		{
			this.LaunchingPreload();
			this.PanInput.IsHitTestVisible = false;
			this.PanLaunching.IsHitTestVisible = false;
			this.LoadLaunching.State.LoadingState = MyLoading.MyLoadingState.Run;
			this.PanLaunching.Visibility = Visibility.Visible;
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.PanInput, 0.0, 0x32, 0, null, false),
				ModAni.AaOpacity(this.PanInput, -this.PanInput.Opacity, 0x6E, 0, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), true),
				ModAni.AaScaleTransform(this.PanInput, 1.2 - ((ScaleTransform)this.PanInput.RenderTransform).ScaleX, 0xA0, 0, null, false),
				ModAni.AaOpacity(this.PanLaunching, 1.0 - this.PanLaunching.Opacity, 0x96, 0x64, null, false),
				ModAni.AaScaleTransform(this.PanLaunching, 1.0 - ((ScaleTransform)this.PanLaunching.RenderTransform).ScaleX, 0x1F4, 0x64, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Weak), false),
				ModAni.AaCode(delegate
				{
					this.PanLaunching.IsHitTestVisible = true;
				}, 0x96, false)
			}, "Launch State Page", false);
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x0005FD50 File Offset: 0x0005DF50
		public void PageChangeToLogin()
		{
			NewLateBinding.LateCall(this.PageGet(this.m_StubExpression), null, "Reload", new object[]
			{
				false
			}, new string[]
			{
				"KeepInput"
			}, null, null, true);
			this.PanInput.IsHitTestVisible = false;
			this.PanLaunching.IsHitTestVisible = false;
			this.LoadLaunching.State.LoadingState = MyLoading.MyLoadingState.Stop;
			this.PanInput.Visibility = Visibility.Visible;
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.PanLaunching, -this.PanLaunching.Opacity, 0x96, 0, null, false),
				ModAni.AaScaleTransform(this.PanLaunching, 0.8 - ((ScaleTransform)this.PanLaunching.RenderTransform).ScaleX, 0x96, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Weak), false),
				ModAni.AaOpacity(this.PanInput, 1.0 - this.PanInput.Opacity, 0xFA, 0x32, null, false),
				ModAni.AaScaleTransform(this.PanInput, 1.0 - ((ScaleTransform)this.PanInput.RenderTransform).ScaleX, 0x12C, 0x32, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Weak), false),
				ModAni.AaCode(delegate
				{
					this.PanInput.IsHitTestVisible = true;
				}, 0xC8, false)
			}, "Launch State Page", true);
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0005FECC File Offset: 0x0005E0CC
		private object PageGet(PageLaunchLeft.PageType Type)
		{
			object result;
			switch (Type)
			{
			case PageLaunchLeft.PageType.Mojang:
				if (Information.IsNothing(ModMain.m_DefinitionFilter))
				{
					ModMain.m_DefinitionFilter = new PageLoginMojang();
				}
				result = ModMain.m_DefinitionFilter;
				break;
			case PageLaunchLeft.PageType.MojangSkin:
				if (Information.IsNothing(ModMain._ParamFilter))
				{
					ModMain._ParamFilter = new PageLoginMojangSkin();
				}
				result = ModMain._ParamFilter;
				break;
			case PageLaunchLeft.PageType.Legacy:
				if (Information.IsNothing(ModMain.m_MockFilter))
				{
					ModMain.m_MockFilter = new PageLoginLegacy();
				}
				result = ModMain.m_MockFilter;
				break;
			case PageLaunchLeft.PageType.Nide:
				if (Information.IsNothing(ModMain.m_SpecificationFilter))
				{
					ModMain.m_SpecificationFilter = new PageLoginNide();
				}
				result = ModMain.m_SpecificationFilter;
				break;
			case PageLaunchLeft.PageType.NideSkin:
				if (Information.IsNothing(ModMain.dicFilter))
				{
					ModMain.dicFilter = new PageLoginNideSkin();
				}
				result = ModMain.dicFilter;
				break;
			case PageLaunchLeft.PageType.Auth:
				if (Information.IsNothing(ModMain._SchemaFilter))
				{
					ModMain._SchemaFilter = new PageLoginAuth();
				}
				result = ModMain._SchemaFilter;
				break;
			case PageLaunchLeft.PageType.AuthSkin:
				if (Information.IsNothing(ModMain.helperFilter))
				{
					ModMain.helperFilter = new PageLoginAuthSkin();
				}
				result = ModMain.helperFilter;
				break;
			case PageLaunchLeft.PageType.Ms:
				if (Information.IsNothing(ModMain._ConsumerFilter))
				{
					ModMain._ConsumerFilter = new PageLoginMs();
				}
				result = ModMain._ConsumerFilter;
				break;
			case PageLaunchLeft.PageType.MsSkin:
				if (Information.IsNothing(ModMain.queueFilter))
				{
					ModMain.queueFilter = new PageLoginMsSkin();
				}
				result = ModMain.queueFilter;
				break;
			default:
				throw new ArgumentOutOfRangeException("Type", "即将切换的登录分页编号越界");
			}
			return result;
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x00060030 File Offset: 0x0005E230
		private object PageChange(PageLaunchLeft.PageType Type, bool Anim)
		{
			PageLoginMojang PageNew = ModMain.m_DefinitionFilter;
			checked
			{
				object $VB$Local_PageNew;
				try
				{
					if (this.m_StubExpression == Type)
					{
						$VB$Local_PageNew = PageNew;
					}
					else
					{
						PageNew = RuntimeHelpers.GetObjectValue(this.PageGet(Type));
						ModAni.AniStop("FrmLogin PageChange");
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(PageNew)) && !Information.IsNothing(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(PageNew, null, "Parent", new object[0], null, null, null))))
						{
							object $VB$Local_PageNew2 = PageNew;
							Type type = null;
							string memberName = "SetValue";
							object[] array = new object[2];
							array[0] = ContentPresenter.ContentProperty;
							NewLateBinding.LateCall($VB$Local_PageNew2, type, memberName, array, null, null, null, true);
						}
						if (Anim)
						{
							ThreadStart $I1;
							base.Dispatcher.Invoke(delegate()
							{
								ModAni.AniStart(new ModAni.AniData[]
								{
									ModAni.AaOpacity(this.PanLogin, unchecked(-this.PanLogin.Opacity), 0x64, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
									ModAni.AaCode(($I1 == null) ? ($I1 = delegate()
									{
										ModAni.ListFactory(ModAni.InsertFactory() + 1);
										this.PanLogin.Children.Clear();
										this.PanLogin.Children.Add((UIElement)PageNew);
										ModAni.ListFactory(ModAni.InsertFactory() - 1);
									}) : $I1, 0x64, false),
									ModAni.AaOpacity(this.PanLogin, 1.0, 0x64, 0x78, new ModAni.AniEaseInFluent(ModAni.AniEasePower.Middle), false)
								}, "FrmLogin PageChange", false);
							}, DispatcherPriority.Render);
						}
						else
						{
							ModAni.ListFactory(ModAni.InsertFactory() + 1);
							this.PanLogin.Children.Clear();
							this.PanLogin.Children.Add((UIElement)PageNew);
							ModAni.ListFactory(ModAni.InsertFactory() - 1);
						}
						this.m_StubExpression = Type;
						$VB$Local_PageNew = PageNew;
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "切换登录分页失败（" + ModBase.GetStringFromEnum(Type) + "）", ModBase.LogLevel.Feedback, "出现错误");
					$VB$Local_PageNew = PageNew;
				}
				return $VB$Local_PageNew;
			}
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x000601A0 File Offset: 0x0005E3A0
		public void RefreshPage(bool KeepInput, bool Anim)
		{
			int num;
			if (ModMinecraft.ValidateContainer() != null)
			{
				num = Conversions.ToInteger(ModBase._BaseRule.Get("VersionServerLogin", ModMinecraft.ValidateContainer()));
				ModBase._BaseRule.Set("LoginPageType", num, false, null);
			}
			else
			{
				num = Conversions.ToInteger(ModBase._BaseRule.Get("LoginPageType", null));
			}
			PageLaunchLeft.PageType pageType;
			switch (num)
			{
			case 0:
				break;
			case 1:
				if (this.RadioLoginType5.Checked)
				{
					if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("CacheMsAccess", null), "", true))
					{
						pageType = PageLaunchLeft.PageType.Ms;
					}
					else
					{
						pageType = PageLaunchLeft.PageType.MsSkin;
					}
					ModBase._BaseRule.Set("LoginType", ModLaunch.McLoginType.Ms, false, null);
				}
				else
				{
					if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("CacheMojangAccess", null), "", true))
					{
						pageType = PageLaunchLeft.PageType.Mojang;
					}
					else
					{
						pageType = PageLaunchLeft.PageType.MojangSkin;
					}
					ModBase._BaseRule.Set("LoginType", ModLaunch.McLoginType.Mojang, false, null);
				}
				this.PanType.Visibility = Visibility.Visible;
				this.PanTypeOne.Visibility = Visibility.Collapsed;
				this.RadioLoginType1.Visibility = Visibility.Visible;
				this.RadioLoginType5.Visibility = Visibility.Visible;
				this.RadioLoginType0.Visibility = Visibility.Collapsed;
				goto IL_3D0;
			case 2:
				pageType = PageLaunchLeft.PageType.Legacy;
				ModBase._BaseRule.Set("LoginType", ModLaunch.McLoginType.Legacy, false, null);
				this.PanType.Visibility = Visibility.Collapsed;
				this.PanTypeOne.Visibility = Visibility.Visible;
				this.PathTypeOne.Data = (Geometry)new GeometryConverter().ConvertFromString("M660.338 528.065c63.61-46.825 105.131-121.964 105.131-206.83 0-141.7-115.29-256.987-256.997-256.987-141.706 0-256.998 115.288-256.998 256.987 0 85.901 42.52 161.887 107.456 208.562-152.1 59.92-260.185 207.961-260.185 381.077 0 21.276 17.253 38.53 38.53 38.53 21.278 0 38.53-17.254 38.53-38.53 0-183.426 149.232-332.671 332.667-332.671 1.589 0 3.113-0.207 4.694-0.244 0.8 0.056 1.553 0.244 2.362 0.244 183.434 0 332.664 149.245 332.664 332.671 0 21.276 17.255 38.53 38.533 38.53 21.277 0 38.53-17.254 38.53-38.53 0-174.885-110.354-324.13-264.917-382.809z m-331.803-206.83c0-99.22 80.72-179.927 179.935-179.927s179.937 80.708 179.937 179.927c0 99.203-80.721 179.91-179.937 179.91s-179.935-80.708-179.935-179.91z");
				this.LabTypeOne.Text = "离线登录";
				goto IL_3D0;
			case 3:
				if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("CacheNideAccess", null), "", true))
				{
					pageType = PageLaunchLeft.PageType.Nide;
				}
				else
				{
					pageType = PageLaunchLeft.PageType.NideSkin;
				}
				ModBase._BaseRule.Set("LoginType", ModLaunch.McLoginType.Nide, false, null);
				this.PanType.Visibility = Visibility.Collapsed;
				this.PanTypeOne.Visibility = Visibility.Visible;
				this.PathTypeOne.Data = (Geometry)new GeometryConverter().ConvertFromString("M834.5 684.1c-31.2-70.4-98.9-120.9-179.1-127.3 63.5-8.5 112.6-63 112.6-128.8 0-71.8-58.2-130-130-130s-130 58.2-130 130c0 65.9 49 120.3 112.6 128.8-80.2 6.4-148 57-179.1 127.3-8.7 19.7 6 42 27.6 42 12.1 0 22.7-7.5 27.7-18.5 24.3-53.9 78.5-91.5 141.3-91.5s117 37.6 141.3 91.5c5 11.1 15.6 18.5 27.7 18.5 21.4 0 36.1-22.3 27.4-42zM567.9 427.9c0-38.6 31.4-70 70-70s70 31.4 70 70-31.4 70-70 70-70-31.4-70-70zM460.3 347.9H216.9c-16.6 0-30 13.4-30 30s13.4 30 30 30h243.3c16.6 0 30-13.4 30-30 0.1-16.5-13.4-30-29.9-30zM367.4 459.6H216.9c-16.6 0-30 13.4-30 30s13.4 30 30 30h150.4c16.6 0 30-13.4 30-30 0.1-16.6-13.4-30-29.9-30zM297.4 571.2H217c-16.6 0-30 13.4-30 30s13.4 30 30 30h80.4c16.6 0 30-13.4 30-30 0-16.5-13.5-30-30-30zM900 236v552H124V236h776m0-60H124c-33.1 0-60 26.9-60 60v552c0 33.1 26.9 60 60 60h776c33.1 0 60-26.9 60-60V236c0-33.1-26.9-60-60-60z");
				this.LabTypeOne.Text = "统一通行证登录";
				goto IL_3D0;
			case 4:
				if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("CacheAuthAccess", null), "", true))
				{
					pageType = PageLaunchLeft.PageType.Auth;
				}
				else
				{
					pageType = PageLaunchLeft.PageType.AuthSkin;
				}
				ModBase._BaseRule.Set("LoginType", ModLaunch.McLoginType.Auth, false, null);
				this.PanType.Visibility = Visibility.Collapsed;
				this.PanTypeOne.Visibility = Visibility.Visible;
				this.PathTypeOne.Data = (Geometry)new GeometryConverter().ConvertFromString("M834.5 684.1c-31.2-70.4-98.9-120.9-179.1-127.3 63.5-8.5 112.6-63 112.6-128.8 0-71.8-58.2-130-130-130s-130 58.2-130 130c0 65.9 49 120.3 112.6 128.8-80.2 6.4-148 57-179.1 127.3-8.7 19.7 6 42 27.6 42 12.1 0 22.7-7.5 27.7-18.5 24.3-53.9 78.5-91.5 141.3-91.5s117 37.6 141.3 91.5c5 11.1 15.6 18.5 27.7 18.5 21.4 0 36.1-22.3 27.4-42zM567.9 427.9c0-38.6 31.4-70 70-70s70 31.4 70 70-31.4 70-70 70-70-31.4-70-70zM460.3 347.9H216.9c-16.6 0-30 13.4-30 30s13.4 30 30 30h243.3c16.6 0 30-13.4 30-30 0.1-16.5-13.4-30-29.9-30zM367.4 459.6H216.9c-16.6 0-30 13.4-30 30s13.4 30 30 30h150.4c16.6 0 30-13.4 30-30 0.1-16.6-13.4-30-29.9-30zM297.4 571.2H217c-16.6 0-30 13.4-30 30s13.4 30 30 30h80.4c16.6 0 30-13.4 30-30 0-16.5-13.5-30-30-30zM900 236v552H124V236h776m0-60H124c-33.1 0-60 26.9-60 60v552c0 33.1 26.9 60 60 60h776c33.1 0 60-26.9 60-60V236c0-33.1-26.9-60-60-60z");
				this.LabTypeOne.Text = Conversions.ToString((ModMinecraft.ValidateContainer() == null) ? ModBase._BaseRule.Get("CacheAuthServerName", null) : ModBase._BaseRule.Get("VersionServerAuthName", ModMinecraft.ValidateContainer()));
				goto IL_3D0;
			default:
				ModBase.Log("[Control] 未知的登录页面：" + Conversions.ToString(num), ModBase.LogLevel.Hint, "出现错误");
				break;
			}
			if (this.RadioLoginType1.Checked)
			{
				if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("CacheMojangAccess", null), "", true))
				{
					pageType = PageLaunchLeft.PageType.Mojang;
				}
				else
				{
					pageType = PageLaunchLeft.PageType.MojangSkin;
				}
				ModBase._BaseRule.Set("LoginType", ModLaunch.McLoginType.Mojang, false, null);
			}
			else if (this.RadioLoginType5.Checked)
			{
				if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("CacheMsAccess", null), "", true))
				{
					pageType = PageLaunchLeft.PageType.Ms;
				}
				else
				{
					pageType = PageLaunchLeft.PageType.MsSkin;
				}
				ModBase._BaseRule.Set("LoginType", ModLaunch.McLoginType.Ms, false, null);
			}
			else
			{
				pageType = PageLaunchLeft.PageType.Legacy;
				ModBase._BaseRule.Set("LoginType", ModLaunch.McLoginType.Legacy, false, null);
			}
			this.PanType.Visibility = Visibility.Visible;
			this.PanTypeOne.Visibility = Visibility.Collapsed;
			this.RadioLoginType1.Visibility = Visibility.Visible;
			this.RadioLoginType5.Visibility = Visibility.Visible;
			this.RadioLoginType0.Visibility = Visibility.Visible;
			IL_3D0:
			if (this.m_StubExpression != pageType)
			{
				object[] array;
				bool[] array2;
				NewLateBinding.LateCall(this.PageChange(pageType, Anim), null, "Reload", array = new object[]
				{
					KeepInput
				}, null, null, array2 = new bool[]
				{
					true
				}, true);
				if (array2[0])
				{
					KeepInput = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(bool));
				}
				MyRadioButton myRadioButton = (MyRadioButton)base.FindName(Conversions.ToString(Operators.ConcatenateObject("RadioLoginType", ModBase._BaseRule.Get("LoginType", null))));
				if (myRadioButton != null)
				{
					myRadioButton.Checked = true;
				}
			}
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x00008235 File Offset: 0x00006435
		private void RadioLoginType_Change(object sender, bool raiseByMouse)
		{
			if (raiseByMouse)
			{
				this.RefreshPage(true, true);
			}
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x00008242 File Offset: 0x00006442
		private static ModBase.EqualableList<string> SkinMojangInput()
		{
			return new ModBase.EqualableList<string>
			{
				Conversions.ToString(ModBase._BaseRule.Get("CacheMojangName", null)),
				Conversions.ToString(ModBase._BaseRule.Get("CacheMojangUuid", null))
			};
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x00060618 File Offset: 0x0005E818
		private static void SkinMojangLoad(ModLoader.LoaderTask<ModBase.EqualableList<string>, string> Data)
		{
			ModBase.RunInUi((PageLaunchLeft._Closure$__.$I15-0 == null) ? (PageLaunchLeft._Closure$__.$I15-0 = delegate()
			{
				if (ModMain._ParamFilter != null && ModMain._ParamFilter.Skin != null)
				{
					ModMain._ParamFilter.Skin.Clear();
				}
			}) : PageLaunchLeft._Closure$__.$I15-0, false);
			string text = Data.Input[0];
			string uuid = Data.Input[1];
			if (Operators.CompareString(text, "", true) == 0)
			{
				Data.Output = ModBase.m_ExpressionRule + "Skins/" + ModMinecraft.McSkinSex(Conversions.ToString(ModLaunch.McLoginLegacyUuid(text))) + ".png";
				ModBase.Log("[Minecraft] 获取正版皮肤失败，ID 为空", ModBase.LogLevel.Normal, "出现错误");
			}
			else
			{
				try
				{
					string text2 = ModMinecraft.McSkinGetAddress(uuid, "Mojang");
					if (Data.IsAborted)
					{
						throw new OperationCanceledException("当前任务已取消：" + text);
					}
					text2 = ModMinecraft.McSkinDownload(text2);
					if (Data.IsAborted)
					{
						throw new OperationCanceledException("当前任务已取消：" + text);
					}
					Data.Output = text2;
				}
				catch (Exception ex)
				{
					if (Operators.CompareString(ex.GetType().Name, "OperationCanceledException", true) == 0)
					{
						Data.Output = "";
						return;
					}
					if (ModBase.GetString(ex, true, false).Contains("429"))
					{
						Data.Output = ModBase.m_ExpressionRule + "Skins/" + ModMinecraft.McSkinSex(Conversions.ToString(ModLaunch.McLoginLegacyUuid(text))) + ".png";
						ModBase.Log("[Minecraft] 获取正版皮肤失败（" + text + "）：获取皮肤太过频繁，请 5 分钟后再试！", ModBase.LogLevel.Hint, "出现错误");
					}
					else if (ModBase.GetString(ex, true, false).Contains("可能是未设置自定义皮肤的用户"))
					{
						Data.Output = ModBase.m_ExpressionRule + "Skins/" + ModMinecraft.McSkinSex(Conversions.ToString(ModLaunch.McLoginLegacyUuid(text))) + ".png";
						ModBase.Log("[Minecraft] 用户未设置自定义皮肤，跳过皮肤加载", ModBase.LogLevel.Normal, "出现错误");
					}
					else
					{
						Data.Output = ModBase.m_ExpressionRule + "Skins/" + ModMinecraft.McSkinSex(Conversions.ToString(ModLaunch.McLoginLegacyUuid(text))) + ".png";
						ModBase.Log(ex, "获取正版皮肤失败（" + text + "）", ModBase.LogLevel.Hint, "出现错误");
					}
				}
			}
			if (ModMain._ParamFilter != null)
			{
				ModBase.RunInUi(new Action(ModMain._ParamFilter.Skin.Load), false);
				return;
			}
			if (!Data.IsAborted)
			{
				Data.Input = null;
			}
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x0000827F File Offset: 0x0000647F
		private static ModBase.EqualableList<string> SkinMsInput()
		{
			return new ModBase.EqualableList<string>
			{
				Conversions.ToString(ModBase._BaseRule.Get("CacheMsName", null)),
				Conversions.ToString(ModBase._BaseRule.Get("CacheMsUuid", null))
			};
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x00060888 File Offset: 0x0005EA88
		private static void SkinMsLoad(ModLoader.LoaderTask<ModBase.EqualableList<string>, string> Data)
		{
			ModBase.RunInUi((PageLaunchLeft._Closure$__.$I18-0 == null) ? (PageLaunchLeft._Closure$__.$I18-0 = delegate()
			{
				if (ModMain.queueFilter != null && ModMain.queueFilter.Skin != null)
				{
					ModMain.queueFilter.Skin.Clear();
				}
			}) : PageLaunchLeft._Closure$__.$I18-0, false);
			string text = Data.Input[0];
			string uuid = Data.Input[1];
			if (Operators.CompareString(text, "", true) == 0)
			{
				Data.Output = ModBase.m_ExpressionRule + "Skins/" + ModMinecraft.McSkinSex(Conversions.ToString(ModLaunch.McLoginLegacyUuid(text))) + ".png";
				ModBase.Log("[Minecraft] 获取微软正版皮肤失败，ID 为空", ModBase.LogLevel.Normal, "出现错误");
			}
			else
			{
				try
				{
					string text2 = ModMinecraft.McSkinGetAddress(uuid, "Ms");
					if (Data.IsAborted)
					{
						throw new OperationCanceledException("当前任务已取消：" + text);
					}
					text2 = ModMinecraft.McSkinDownload(text2);
					if (Data.IsAborted)
					{
						throw new OperationCanceledException("当前任务已取消：" + text);
					}
					Data.Output = text2;
				}
				catch (Exception ex)
				{
					if (Operators.CompareString(ex.GetType().Name, "OperationCanceledException", true) == 0)
					{
						Data.Output = "";
						return;
					}
					if (ModBase.GetString(ex, true, false).Contains("429"))
					{
						Data.Output = ModBase.m_ExpressionRule + "Skins/" + ModMinecraft.McSkinSex(Conversions.ToString(ModLaunch.McLoginLegacyUuid(text))) + ".png";
						ModBase.Log("[Minecraft] 获取正版皮肤失败（" + text + "）：获取皮肤太过频繁，请 5 分钟后再试！", ModBase.LogLevel.Hint, "出现错误");
					}
					else if (ModBase.GetString(ex, true, false).Contains("可能是未设置自定义皮肤的用户"))
					{
						Data.Output = ModBase.m_ExpressionRule + "Skins/" + ModMinecraft.McSkinSex(Conversions.ToString(ModLaunch.McLoginLegacyUuid(text))) + ".png";
						ModBase.Log("[Minecraft] 用户未设置自定义皮肤，跳过皮肤加载", ModBase.LogLevel.Normal, "出现错误");
					}
					else
					{
						Data.Output = ModBase.m_ExpressionRule + "Skins/" + ModMinecraft.McSkinSex(Conversions.ToString(ModLaunch.McLoginLegacyUuid(text))) + ".png";
						ModBase.Log(ex, "获取微软正版皮肤失败（" + text + "）", ModBase.LogLevel.Hint, "出现错误");
					}
				}
			}
			if (ModMain.queueFilter != null)
			{
				ModBase.RunInUi(new Action(ModMain.queueFilter.Skin.Load), false);
				return;
			}
			if (!Data.IsAborted)
			{
				Data.Input = null;
			}
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x00060AF8 File Offset: 0x0005ECF8
		private static ModBase.EqualableList<string> SkinLegacyInput()
		{
			int num = Conversions.ToInteger(ModBase._BaseRule.Get("LaunchSkinType", null));
			ModBase.EqualableList<string> result;
			if (num != 0)
			{
				if (num != 3)
				{
					result = new ModBase.EqualableList<string>
					{
						Conversions.ToString(num)
					};
				}
				else
				{
					result = new ModBase.EqualableList<string>
					{
						Conversions.ToString(3),
						Conversions.ToString(ModBase._BaseRule.Get("LaunchSkinID", null))
					};
				}
			}
			else if (ModMain.m_MockFilter != null && ModMain.m_MockFilter.utilsExpression)
			{
				result = new ModBase.EqualableList<string>
				{
					Conversions.ToString(0),
					ModMain.m_MockFilter.ComboName.Text ?? ""
				};
			}
			else if (Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LoginLegacyName", null), "", true))
			{
				result = new ModBase.EqualableList<string>
				{
					Conversions.ToString(0),
					""
				};
			}
			else
			{
				result = new ModBase.EqualableList<string>
				{
					Conversions.ToString(0),
					ModBase._BaseRule.Get("LoginLegacyName", null).ToString().Split(new char[]
					{
						'¨'
					})[0] ?? ""
				};
			}
			return result;
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x00060C40 File Offset: 0x0005EE40
		private static void SkinLegacyLoad(ModLoader.LoaderTask<ModBase.EqualableList<string>, string> Data)
		{
			ModBase.RunInUi((PageLaunchLeft._Closure$__.$I21-0 == null) ? (PageLaunchLeft._Closure$__.$I21-0 = delegate()
			{
				if (ModMain.m_MockFilter != null && ModMain.m_MockFilter.Skin != null)
				{
					ModMain.m_MockFilter.Skin.Clear();
				}
			}) : PageLaunchLeft._Closure$__.$I21-0, false);
			string left = Data.Input[0];
			if (Operators.CompareString(left, Conversions.ToString(0), true) == 0)
			{
				Data.Output = ModBase.m_ExpressionRule + "Skins/" + ModMinecraft.McSkinSex(Conversions.ToString(ModLaunch.McLoginLegacyUuid(Data.Input[1]))) + ".png";
			}
			else
			{
				if (Operators.CompareString(left, Conversions.ToString(1), true) != 0)
				{
					if (Operators.CompareString(left, Conversions.ToString(2), true) == 0)
					{
						Data.Output = ModBase.m_ExpressionRule + "Skins/Alex.png";
						goto IL_2C1;
					}
					if (Operators.CompareString(left, Conversions.ToString(3), true) == 0)
					{
						string text = Data.Input[1];
						try
						{
							if (text.Count<char>() < 2)
							{
								Data.Output = ModBase.m_ExpressionRule + "Skins/Steve.png";
							}
							else
							{
								string text2 = Conversions.ToString(ModLaunch.McLoginMojangUuid(text, true));
								if (Data.IsAborted)
								{
									throw new OperationCanceledException("当前任务已取消：" + text);
								}
								text2 = ModMinecraft.McSkinGetAddress(text2, "Mojang");
								if (Data.IsAborted)
								{
									throw new OperationCanceledException("当前任务已取消：" + text);
								}
								text2 = ModMinecraft.McSkinDownload(text2);
								if (Data.IsAborted)
								{
									throw new OperationCanceledException("当前任务已取消：" + text);
								}
								Data.Output = text2;
							}
							goto IL_2C1;
						}
						catch (Exception ex)
						{
							if (Operators.CompareString(ex.GetType().Name, "OperationCanceledException", true) == 0)
							{
								Data.Output = "";
								return;
							}
							if (ModBase.GetString(ex, true, false).Contains("429"))
							{
								Data.Output = ModBase.m_ExpressionRule + "Skins/" + ModMinecraft.McSkinSex(Conversions.ToString(ModLaunch.McLoginLegacyUuid(text))) + ".png";
								ModBase.Log("获取离线登录使用的正版皮肤失败（" + text + "）：获取皮肤太过频繁，请 5 分钟后再试！", ModBase.LogLevel.Normal, "出现错误");
							}
							else
							{
								Data.Output = ModBase.m_ExpressionRule + "Skins/" + ModMinecraft.McSkinSex(Conversions.ToString(ModLaunch.McLoginLegacyUuid(text))) + ".png";
								ModBase.Log(ex, "获取离线登录使用的正版皮肤失败（" + text + "）", ModBase.LogLevel.Debug, "出现错误");
							}
							goto IL_2C1;
						}
					}
					if (Operators.CompareString(left, Conversions.ToString(4), true) != 0)
					{
						goto IL_2C1;
					}
					if (File.Exists(ModBase.m_GlobalRule + "CustomSkin.png"))
					{
						Data.Output = ModBase.m_GlobalRule + "CustomSkin.png";
						goto IL_2C1;
					}
					ModMain.Hint("未找到离线皮肤自定义文件，可能它已被删除。PCL2 将使用默认的 Steve 皮肤！", ModMain.HintType.Info, true);
					ModBase._BaseRule.Set("LaunchSkinType", 1, false, null);
				}
				Data.Output = ModBase.m_ExpressionRule + "Skins/Steve.png";
			}
			IL_2C1:
			if (ModMain.m_MockFilter != null)
			{
				ModBase.RunInUi(new Action(ModMain.m_MockFilter.Skin.Load), false);
				return;
			}
			if (!Data.IsAborted)
			{
				Data.Input = null;
			}
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x000082BC File Offset: 0x000064BC
		private static ModBase.EqualableList<string> SkinNideInput()
		{
			return new ModBase.EqualableList<string>
			{
				Conversions.ToString(ModBase._BaseRule.Get("CacheNideName", null)),
				Conversions.ToString(ModBase._BaseRule.Get("CacheNideUuid", null))
			};
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x00060F50 File Offset: 0x0005F150
		private static void SkinNideLoad(ModLoader.LoaderTask<ModBase.EqualableList<string>, string> Data)
		{
			ModBase.RunInUi((PageLaunchLeft._Closure$__.$I24-0 == null) ? (PageLaunchLeft._Closure$__.$I24-0 = delegate()
			{
				if (ModMain.dicFilter != null && ModMain.dicFilter.Skin != null)
				{
					ModMain.dicFilter.Skin.Clear();
				}
			}) : PageLaunchLeft._Closure$__.$I24-0, false);
			string text = Data.Input[0];
			string uuid = Data.Input[1];
			if (Operators.CompareString(text, "", true) == 0)
			{
				Data.Output = ModBase.m_ExpressionRule + "Skins/" + ModMinecraft.McSkinSex(Conversions.ToString(ModLaunch.McLoginLegacyUuid(text))) + ".png";
				ModBase.Log("[Minecraft] 获取统一通行证皮肤失败，ID 为空", ModBase.LogLevel.Normal, "出现错误");
			}
			else
			{
				try
				{
					string text2 = ModMinecraft.McSkinGetAddress(uuid, "Nide");
					if (Data.IsAborted)
					{
						throw new OperationCanceledException("当前任务已取消：" + text);
					}
					text2 = ModMinecraft.McSkinDownload(text2);
					if (Data.IsAborted)
					{
						throw new OperationCanceledException("当前任务已取消：" + text);
					}
					Data.Output = text2;
				}
				catch (Exception ex)
				{
					if (Operators.CompareString(ex.GetType().Name, "OperationCanceledException", true) == 0)
					{
						Data.Output = "";
						return;
					}
					if (ModBase.GetString(ex, true, false).Contains("429"))
					{
						Data.Output = ModBase.m_ExpressionRule + "Skins/Steve.png";
						ModBase.Log("[Minecraft] 获取统一通行证皮肤失败（" + text + "）：获取皮肤太过频繁，请 5 分钟后再试！", ModBase.LogLevel.Hint, "出现错误");
					}
					else if (ModBase.GetString(ex, true, false).Contains("可能是未设置自定义皮肤的用户"))
					{
						Data.Output = ModBase.m_ExpressionRule + "Skins/Steve.png";
						ModBase.Log("[Minecraft] 用户未设置自定义皮肤，跳过皮肤加载", ModBase.LogLevel.Normal, "出现错误");
					}
					else
					{
						Data.Output = ModBase.m_ExpressionRule + "Skins/Steve.png";
						ModBase.Log(ex, "获取统一通行证皮肤失败（" + text + "）", ModBase.LogLevel.Hint, "出现错误");
					}
				}
			}
			if (ModMain.dicFilter != null)
			{
				ModBase.RunInUi(new Action(ModMain.dicFilter.Skin.Load), false);
				return;
			}
			if (!Data.IsAborted)
			{
				Data.Input = null;
			}
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x000082F9 File Offset: 0x000064F9
		private static ModBase.EqualableList<string> SkinAuthInput()
		{
			return new ModBase.EqualableList<string>
			{
				Conversions.ToString(ModBase._BaseRule.Get("CacheAuthName", null)),
				Conversions.ToString(ModBase._BaseRule.Get("CacheAuthUuid", null))
			};
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x00061170 File Offset: 0x0005F370
		private static void SkinAuthLoad(ModLoader.LoaderTask<ModBase.EqualableList<string>, string> Data)
		{
			ModBase.RunInUi((PageLaunchLeft._Closure$__.$I27-0 == null) ? (PageLaunchLeft._Closure$__.$I27-0 = delegate()
			{
				if (ModMain.helperFilter != null && ModMain.helperFilter.Skin != null)
				{
					ModMain.helperFilter.Skin.Clear();
				}
			}) : PageLaunchLeft._Closure$__.$I27-0, false);
			string text = Data.Input[0];
			string uuid = Data.Input[1];
			if (Operators.CompareString(text, "", true) == 0)
			{
				Data.Output = ModBase.m_ExpressionRule + "Skins/Steve.png";
				ModBase.Log("[Minecraft] 获取 Authlib-Injector 皮肤失败，ID 为空", ModBase.LogLevel.Normal, "出现错误");
			}
			else
			{
				try
				{
					string text2 = ModMinecraft.McSkinGetAddress(uuid, "Auth");
					if (Data.IsAborted)
					{
						throw new OperationCanceledException("当前任务已取消：" + text);
					}
					text2 = ModMinecraft.McSkinDownload(text2);
					if (Data.IsAborted)
					{
						throw new OperationCanceledException("当前任务已取消：" + text);
					}
					Data.Output = text2;
				}
				catch (Exception ex)
				{
					if (Operators.CompareString(ex.GetType().Name, "OperationCanceledException", true) == 0)
					{
						Data.Output = "";
						return;
					}
					if (ModBase.GetString(ex, true, false).Contains("429"))
					{
						Data.Output = ModBase.m_ExpressionRule + "Skins/Steve.png";
						ModBase.Log("[Minecraft] 获取 Authlib-Injector 皮肤失败（" + text + "）：获取皮肤太过频繁，请 5 分钟后再试！", ModBase.LogLevel.Hint, "出现错误");
					}
					else if (ModBase.GetString(ex, true, false).Contains("可能是未设置自定义皮肤的用户"))
					{
						Data.Output = ModBase.m_ExpressionRule + "Skins/Steve.png";
						ModBase.Log("[Minecraft] 用户未设置自定义皮肤，跳过皮肤加载", ModBase.LogLevel.Normal, "出现错误");
					}
					else
					{
						Data.Output = ModBase.m_ExpressionRule + "Skins/Steve.png";
						ModBase.Log(ex, "获取 Authlib-Injector 皮肤失败（" + text + "）", ModBase.LogLevel.Hint, "出现错误");
					}
				}
			}
			if (ModMain.helperFilter != null)
			{
				ModBase.RunInUi(new Action(ModMain.helperFilter.Skin.Load), false);
				return;
			}
			if (!Data.IsAborted)
			{
				Data.Input = null;
			}
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x00008336 File Offset: 0x00006536
		private void BtnVersion_Click(object sender, EventArgs e)
		{
			ModMain.m_GetterFilter.PageChange(FormMain.PageType.VersionSelect, FormMain.PageSubType.Default);
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x00008349 File Offset: 0x00006549
		private void BtnLaunch_Click()
		{
			this.LaunchButtonClick("");
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x0006137C File Offset: 0x0005F57C
		public void LaunchButtonClick(string ServerIp = "")
		{
			if (this.BtnLaunch.IsEnabled && this.BtnLaunch.Visibility == Visibility.Visible && this.BtnLaunch.IsHitTestVisible)
			{
				if (Operators.CompareString(this.BtnLaunch.Text, "启动游戏", true) == 0)
				{
					ModLaunch.m_ThreadIterator.Start(ServerIp, false);
				}
				else if (Operators.CompareString(this.BtnLaunch.Text, "下载游戏", true) == 0)
				{
					ModMain.m_GetterFilter.PageChange(FormMain.PageType.Download, FormMain.PageSubType.DownloadInstall);
				}
				if (ModMain.policyFilter && !ModMain.m_ClientFilter)
				{
					ModMain.ThemeUnlock(0xC, false, "隐藏主题 滑稽彩 已解锁！");
					ModMain.m_ClientFilter = true;
					ModMain.m_InvocationFilter.AprilScaleTrans.ScaleX = 1.0;
					ModMain.m_InvocationFilter.AprilScaleTrans.ScaleY = 1.0;
					ModMain.m_GetterFilter.BtnExtraApril.ShowRefresh();
				}
			}
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x0006146C File Offset: 0x0005F66C
		public void RefreshButtonsUI()
		{
			if (this.BtnLaunch.IsLoaded)
			{
				int num;
				if (this._ParameterExpression && ModMinecraft.m_ParserIterator.State != ModBase.LoadState.Loading)
				{
					if (ModMinecraft._TestsIterator.State != ModBase.LoadState.Loading)
					{
						if (ModMinecraft.ValidateContainer() != null)
						{
							num = 3;
							goto IL_77;
						}
						if (Conversions.ToBoolean(Conversions.ToBoolean(ModBase._BaseRule.Get("UiHiddenPageDownload", null)) && !PageSetupUI.WriteModel()))
						{
							num = 1;
							goto IL_77;
						}
						num = 2;
						goto IL_77;
					}
				}
				num = 0;
				IL_77:
				if (num != this.m_CollectionExpression || Operators.CompareString((ModMinecraft.ValidateContainer() == null) ? "" : ModMinecraft.ValidateContainer().Path, (this._TestsExpression == null) ? "" : this._TestsExpression.Path, true) != 0)
				{
					this._TestsExpression = ModMinecraft.ValidateContainer();
					this.m_CollectionExpression = num;
					switch (num)
					{
					case 0:
						ModBase.Log("[Minecraft] 启动按钮：正在加载 Minecraft 版本", ModBase.LogLevel.Normal, "出现错误");
						ModMain.m_InvocationFilter.BtnLaunch.Text = "正在加载";
						ModMain.m_InvocationFilter.BtnLaunch.IsEnabled = false;
						ModMain.m_InvocationFilter.LabVersion.Text = "正在加载版本列表，请稍候";
						ModMain.m_InvocationFilter.BtnVersion.IsEnabled = false;
						ModMain.m_InvocationFilter.BtnMore.Visibility = Visibility.Collapsed;
						break;
					case 1:
						ModBase.Log("[Minecraft] 启动按钮：无 Minecraft 版本，下载已禁用", ModBase.LogLevel.Normal, "出现错误");
						ModMain.m_InvocationFilter.BtnLaunch.Text = "启动游戏";
						ModMain.m_InvocationFilter.BtnLaunch.IsEnabled = false;
						ModMain.m_InvocationFilter.LabVersion.Text = "未找到可用的游戏版本";
						ModMain.m_InvocationFilter.BtnVersion.IsEnabled = true;
						ModMain.m_InvocationFilter.BtnMore.Visibility = Visibility.Collapsed;
						break;
					case 2:
						ModBase.Log("[Minecraft] 启动按钮：无 Minecraft 版本，要求下载", ModBase.LogLevel.Normal, "出现错误");
						ModMain.m_InvocationFilter.BtnLaunch.Text = "下载游戏";
						ModMain.m_InvocationFilter.BtnLaunch.IsEnabled = true;
						ModMain.m_InvocationFilter.LabVersion.Text = "未找到可用的游戏版本";
						ModMain.m_InvocationFilter.BtnVersion.IsEnabled = true;
						ModMain.m_InvocationFilter.BtnMore.Visibility = Visibility.Collapsed;
						break;
					case 3:
						ModBase.Log("[Minecraft] 启动按钮：Minecraft 版本：" + ModMinecraft.ValidateContainer().Path, ModBase.LogLevel.Normal, "出现错误");
						ModMain.m_InvocationFilter.BtnLaunch.Text = "启动游戏";
						ModMain.m_InvocationFilter.BtnVersion.IsEnabled = true;
						ModMain.m_InvocationFilter.BtnLaunch.IsEnabled = true;
						ModMain.m_InvocationFilter.LabVersion.Text = ModMinecraft.ValidateContainer().Name;
						break;
					}
				}
				ModMain.m_InvocationFilter.BtnVersion.Visibility = (Conversions.ToBoolean(!PageSetupUI.WriteModel() && Conversions.ToBoolean(ModBase._BaseRule.Get("UiHiddenFunctionSelect", null))) ? Visibility.Collapsed : Visibility.Visible);
				if (num == 3)
				{
					ModMain.m_InvocationFilter.BtnMore.Visibility = ModMain.m_InvocationFilter.BtnVersion.Visibility;
				}
			}
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x00061774 File Offset: 0x0005F974
		private void BtnCancel_Click()
		{
			if (ModLaunch.m_ManagerIterator != null)
			{
				ModLaunch.m_ManagerIterator.Abort();
				ModLaunch.McLaunchLog("已取消启动");
				try
				{
					if (ModLaunch.serializerIterator != null)
					{
						ModLaunch.serializerIterator.Kill();
					}
					else if (ModLaunch.itemIterator != null && !ModLaunch.itemIterator.HasExited)
					{
						ModLaunch.itemIterator.Kill();
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "取消启动结束进程失败", ModBase.LogLevel.Hint, "出现错误");
				}
			}
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x00008356 File Offset: 0x00006556
		private void BtnMore_Click(object sender, EventArgs e)
		{
			ModMinecraft.ValidateContainer().Load();
			PageVersionLeft.m_OrderModel = ModMinecraft.ValidateContainer();
			ModMain.m_GetterFilter.PageChange(FormMain.PageType.VersionSetup, FormMain.PageSubType.Default);
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x00061800 File Offset: 0x0005FA00
		public void LaunchingPreload()
		{
			object left = ModBase._BaseRule.Get("LoginType", null);
			if (Operators.ConditionalCompareObjectEqual(left, ModLaunch.McLoginType.Legacy, true))
			{
				this.LabLaunchingMethod.Text = "离线登录";
			}
			else if (Operators.ConditionalCompareObjectEqual(left, ModLaunch.McLoginType.Mojang, true))
			{
				this.LabLaunchingMethod.Text = "Mojang 正版登录";
			}
			else if (Operators.ConditionalCompareObjectEqual(left, ModLaunch.McLoginType.Ms, true))
			{
				this.LabLaunchingMethod.Text = "微软正版登录";
			}
			else if (Operators.ConditionalCompareObjectEqual(left, ModLaunch.McLoginType.Nide, true))
			{
				this.LabLaunchingMethod.Text = "统一通行证";
			}
			else if (Operators.ConditionalCompareObjectEqual(left, ModLaunch.McLoginType.Auth, true))
			{
				this.LabLaunchingMethod.Text = "Authlib-Injector";
			}
			this.LabLaunchingName.Text = ModMinecraft.ValidateContainer().Name;
			this.LabLaunchingStage.Text = "初始化";
			this.LabLaunchingTitle.Text = "正在启动游戏";
			this.LabLaunchingProgress.Text = "0.00 %";
			this.LabLaunchingProgress.Opacity = 1.0;
			this.LabLaunchingDownload.Visibility = Visibility.Visible;
			this.LabLaunchingProgressLeft.Opacity = 0.6;
			this.LabLaunchingDownload.Visibility = Visibility.Visible;
			this.LabLaunchingDownload.Text = "0 B/s";
			this.LabLaunchingDownload.Opacity = 0.0;
			this.LabLaunchingDownload.Visibility = Visibility.Collapsed;
			this.LabLaunchingDownloadLeft.Opacity = 0.0;
			this.LabLaunchingDownloadLeft.Visibility = Visibility.Collapsed;
			this.ProgressLaunchingFinished.Width = new GridLength(0.0, GridUnitType.Star);
			this.ProgressLaunchingUnfinished.Width = new GridLength(1.0, GridUnitType.Star);
			this.PanLaunchingHint.Opacity = 0.0;
			this.PanLaunchingHint.Visibility = Visibility.Collapsed;
			this.PanLaunchingInfo.Width = double.NaN;
			ModLaunch.itemIterator = null;
			ModLaunch.serializerIterator = null;
			string text = PageOtherTest.GetRandomHint();
			try
			{
				string[] array = Array.FindAll<string>(ModBase.ReadFile(ModBase.Path + "PCL\\hints.txt").Replace("\n", "").Split(new char[]
				{
					'\r'
				}), (PageLaunchLeft._Closure$__.$I37-0 == null) ? (PageLaunchLeft._Closure$__.$I37-0 = ((string Input) => !string.IsNullOrWhiteSpace(Input))) : PageLaunchLeft._Closure$__.$I37-0);
				if (array.Count<string>() > 0)
				{
					text = Conversions.ToString(ModBase.RandomOne(array));
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "获取自定义 你知道吗 提示失败", ModBase.LogLevel.Hint, "出现错误");
			}
			this.LabLaunchingHint.Text = text;
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x00061AC4 File Offset: 0x0005FCC4
		public void LaunchingRefresh()
		{
			try
			{
				PageLaunchLeft._Closure$__39-0 CS$<>8__locals1 = new PageLaunchLeft._Closure$__39-0(CS$<>8__locals1);
				CS$<>8__locals1.$VB$Me = this;
				if (ModLaunch.m_ManagerIterator.State != ModBase.LoadState.Aborted)
				{
					bool flag = false;
					try
					{
						try
						{
							foreach (object obj in ModLaunch.m_ManagerIterator.GetLoaderList(false))
							{
								object objectValue = RuntimeHelpers.GetObjectValue(obj);
								if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue, null, "State", new object[0], null, null, null), ModBase.LoadState.Finished, true))
								{
									this.LabLaunchingStage.Text = Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null));
									flag = Conversions.ToBoolean(Conversions.ToBoolean(Operators.CompareObjectEqual(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null), "等待游戏窗口出现", true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null), "结束处理", true)));
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
					catch (Exception ex)
					{
						ModBase.Log(ex, "获取是否启动完成失败，可能是由于启动状态改变导致集合已修改", ModBase.LogLevel.Debug, "出现错误");
						return;
					}
					if (ModAni.AniIsRun("Launch State Page"))
					{
						flag = false;
					}
					double progress = ModLaunch.m_ManagerIterator.Progress;
					if (progress >= this.m_BroadcasterExpression)
					{
						ref double ptr = ref this.m_BroadcasterExpression;
						this.m_BroadcasterExpression = ptr + ((progress - this.m_BroadcasterExpression) * 0.2 + 0.005);
					}
					if (progress <= this.m_BroadcasterExpression)
					{
						this.m_BroadcasterExpression = progress;
					}
					if (flag)
					{
						this.m_BroadcasterExpression = 1.0;
					}
					this.LabLaunchingTitle.Text = (flag ? "已启动游戏" : "正在启动游戏");
					this.LabLaunchingProgress.Text = ModBase.StrFillNum(this.m_BroadcasterExpression * 100.0, 2) + " %";
					CS$<>8__locals1.$VB$Local_HasLaunchDownloader = false;
					try
					{
						try
						{
							foreach (ModNet.LoaderDownload loaderDownload in ModNet._ClientModel.m_MappingAlgo)
							{
								if (loaderDownload.RealParent != null && Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(loaderDownload.RealParent, null, "Name", new object[0], null, null, null), "Minecraft 启动", true) && loaderDownload.State == ModBase.LoadState.Loading)
								{
									CS$<>8__locals1.$VB$Local_HasLaunchDownloader = true;
								}
							}
						}
						finally
						{
							List<ModNet.LoaderDownload>.Enumerator enumerator2;
							((IDisposable)enumerator2).Dispose();
						}
					}
					catch (Exception ex2)
					{
						ModBase.Log(ex2, "获取 Minecraft 启动下载器失败，可能是因为启动被取消", ModBase.LogLevel.Debug, "出现错误");
						CS$<>8__locals1.$VB$Local_HasLaunchDownloader = false;
					}
					this.LabLaunchingDownload.Text = ModBase.GetString(ModNet._ClientModel.indexerAlgo) + "/s";
					ArrayList arrayList = new ArrayList
					{
						ModAni.AaGridLengthWidth(this.ProgressLaunchingFinished, this.m_BroadcasterExpression - this.ProgressLaunchingFinished.Width.Value, 0x104, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
						ModAni.AaGridLengthWidth(this.ProgressLaunchingUnfinished, 1.0 - this.m_BroadcasterExpression - this.ProgressLaunchingUnfinished.Width.Value, 0x104, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false)
					};
					if (CS$<>8__locals1.$VB$Local_HasLaunchDownloader == (this.LabLaunchingDownload.Visibility == Visibility.Collapsed))
					{
						this.LabLaunchingDownload.Visibility = Visibility.Visible;
						this.LabLaunchingDownloadLeft.Visibility = Visibility.Visible;
						arrayList.AddRange(new ModAni.AniData[]
						{
							ModAni.AaOpacity(this.LabLaunchingDownload, (double)(CS$<>8__locals1.$VB$Local_HasLaunchDownloader ? 1 : 0) - this.LabLaunchingDownload.Opacity, 0x64, 0, null, false),
							ModAni.AaOpacity(this.LabLaunchingDownloadLeft, (CS$<>8__locals1.$VB$Local_HasLaunchDownloader ? 0.5 : 0.0) - this.LabLaunchingDownloadLeft.Opacity, 0x64, 0, null, false),
							ModAni.AaCode(delegate
							{
								if (!CS$<>8__locals1.$VB$Local_HasLaunchDownloader)
								{
									CS$<>8__locals1.$VB$Me.LabLaunchingDownload.Visibility = Visibility.Collapsed;
									CS$<>8__locals1.$VB$Me.LabLaunchingDownloadLeft.Visibility = Visibility.Collapsed;
								}
							}, 0x6E, false)
						});
					}
					if (!flag == (this.LabLaunchingProgress.Visibility == Visibility.Collapsed))
					{
						this.LabLaunchingProgress.Visibility = Visibility.Visible;
						this.LabLaunchingProgressLeft.Visibility = Visibility.Visible;
						if (flag)
						{
							this.PanLaunchingHint.Visibility = Visibility.Visible;
						}
						arrayList.AddRange(new ModAni.AniData[]
						{
							ModAni.AaOpacity(this.LabLaunchingProgress, (double)((!flag) ? 1 : 0) - this.LabLaunchingProgress.Opacity, 0x64, 0, null, false),
							ModAni.AaOpacity(this.LabLaunchingProgressLeft, ((!flag) ? 0.5 : 0.0) - this.LabLaunchingProgressLeft.Opacity, 0x64, 0, null, false),
							ModAni.AaOpacity(this.PanLaunchingHint, (double)(flag ? 1 : 0) - this.PanLaunchingHint.Opacity, 0x64, 0, null, false)
						});
					}
					ModAni.AniStart(arrayList, "Launching Progress", false);
				}
			}
			catch (Exception ex3)
			{
				ModBase.Log(ex3, "刷新启动信息失败", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x00062064 File Offset: 0x00060264
		private void PanLaunchingInfo_SizeChangedW(object sender, SizeChangedEventArgs e)
		{
			double value = e.NewSize.Width - e.PreviousSize.Width;
			if (e.PreviousSize.Width != 0.0 && !this.fieldExpression && Math.Abs(value) >= 1.0 && this.PanLaunchingInfo.ActualWidth != 0.0)
			{
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaWidth(this.PanLaunchingInfo, value, 0xB4, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaCode(delegate
					{
						this.fieldExpression = false;
						this.PanLaunchingInfo.Width = this._StatusExpression;
					}, 0, true)
				}, "Launching Info Width", false);
				this.fieldExpression = true;
				this._StatusExpression = this.PanLaunchingInfo.Width;
				this.PanLaunchingInfo.Width = e.PreviousSize.Width;
			}
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x0006215C File Offset: 0x0006035C
		private void PanLaunchingInfo_SizeChangedH(object sender, SizeChangedEventArgs e)
		{
			double value = e.NewSize.Height - e.PreviousSize.Height;
			if (e.PreviousSize.Height != 0.0 && !this._RequestExpression && Math.Abs(value) >= 1.0 && this.PanLaunchingInfo.ActualHeight != 0.0)
			{
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaHeight(this.PanLaunchingInfo, value, 0xB4, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false),
					ModAni.AaCode(delegate
					{
						this._RequestExpression = false;
						this.PanLaunchingInfo.Height = this.m_PoolExpression;
					}, 0, true)
				}, "Launching Info Height", false);
				this._RequestExpression = true;
				this.m_PoolExpression = this.PanLaunchingInfo.Height;
				this.PanLaunchingInfo.Height = e.PreviousSize.Height;
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000B38 RID: 2872 RVA: 0x0000837E File Offset: 0x0000657E
		// (set) Token: 0x06000B39 RID: 2873 RVA: 0x00008386 File Offset: 0x00006586
		internal virtual PageLaunchLeft PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000B3A RID: 2874 RVA: 0x0000838F File Offset: 0x0000658F
		// (set) Token: 0x06000B3B RID: 2875 RVA: 0x00008397 File Offset: 0x00006597
		internal virtual Grid PanInput { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000B3C RID: 2876 RVA: 0x000083A0 File Offset: 0x000065A0
		// (set) Token: 0x06000B3D RID: 2877 RVA: 0x00062254 File Offset: 0x00060454
		internal virtual MyButton BtnVersion
		{
			[CompilerGenerated]
			get
			{
				return this._SetterExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnVersion_Click);
				MyButton setterExpression = this._SetterExpression;
				if (setterExpression != null)
				{
					setterExpression.CancelModel(obj);
				}
				this._SetterExpression = value;
				setterExpression = this._SetterExpression;
				if (setterExpression != null)
				{
					setterExpression.ValidateModel(obj);
				}
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000B3E RID: 2878 RVA: 0x000083A8 File Offset: 0x000065A8
		// (set) Token: 0x06000B3F RID: 2879 RVA: 0x00062298 File Offset: 0x00060498
		internal virtual MyButton BtnMore
		{
			[CompilerGenerated]
			get
			{
				return this.merchantExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnMore_Click);
				MyButton myButton = this.merchantExpression;
				if (myButton != null)
				{
					myButton.CancelModel(obj);
				}
				this.merchantExpression = value;
				myButton = this.merchantExpression;
				if (myButton != null)
				{
					myButton.ValidateModel(obj);
				}
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000B40 RID: 2880 RVA: 0x000083B0 File Offset: 0x000065B0
		// (set) Token: 0x06000B41 RID: 2881 RVA: 0x000083B8 File Offset: 0x000065B8
		internal virtual Grid PanLogin { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000B42 RID: 2882 RVA: 0x000083C1 File Offset: 0x000065C1
		// (set) Token: 0x06000B43 RID: 2883 RVA: 0x000083C9 File Offset: 0x000065C9
		internal virtual Grid PanTypeOne { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000B44 RID: 2884 RVA: 0x000083D2 File Offset: 0x000065D2
		// (set) Token: 0x06000B45 RID: 2885 RVA: 0x000083DA File Offset: 0x000065DA
		internal virtual System.Windows.Shapes.Path PathTypeOne { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000B46 RID: 2886 RVA: 0x000083E3 File Offset: 0x000065E3
		// (set) Token: 0x06000B47 RID: 2887 RVA: 0x000083EB File Offset: 0x000065EB
		internal virtual TextBlock LabTypeOne { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000B48 RID: 2888 RVA: 0x000083F4 File Offset: 0x000065F4
		// (set) Token: 0x06000B49 RID: 2889 RVA: 0x000083FC File Offset: 0x000065FC
		internal virtual Grid PanType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000B4A RID: 2890 RVA: 0x00008405 File Offset: 0x00006605
		// (set) Token: 0x06000B4B RID: 2891 RVA: 0x000622DC File Offset: 0x000604DC
		internal virtual MyRadioButton RadioLoginType1
		{
			[CompilerGenerated]
			get
			{
				return this.m_AttributeExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyRadioButton.CheckEventHandler obj = new MyRadioButton.CheckEventHandler(this.RadioLoginType_Change);
				MyRadioButton attributeExpression = this.m_AttributeExpression;
				if (attributeExpression != null)
				{
					attributeExpression.CountIterator(obj);
				}
				this.m_AttributeExpression = value;
				attributeExpression = this.m_AttributeExpression;
				if (attributeExpression != null)
				{
					attributeExpression.VisitIterator(obj);
				}
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000B4C RID: 2892 RVA: 0x0000840D File Offset: 0x0000660D
		// (set) Token: 0x06000B4D RID: 2893 RVA: 0x00062320 File Offset: 0x00060520
		internal virtual MyRadioButton RadioLoginType5
		{
			[CompilerGenerated]
			get
			{
				return this.m_ValueExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyRadioButton.CheckEventHandler obj = new MyRadioButton.CheckEventHandler(this.RadioLoginType_Change);
				MyRadioButton valueExpression = this.m_ValueExpression;
				if (valueExpression != null)
				{
					valueExpression.CountIterator(obj);
				}
				this.m_ValueExpression = value;
				valueExpression = this.m_ValueExpression;
				if (valueExpression != null)
				{
					valueExpression.VisitIterator(obj);
				}
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000B4E RID: 2894 RVA: 0x00008415 File Offset: 0x00006615
		// (set) Token: 0x06000B4F RID: 2895 RVA: 0x00062364 File Offset: 0x00060564
		internal virtual MyRadioButton RadioLoginType0
		{
			[CompilerGenerated]
			get
			{
				return this.roleExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyRadioButton.CheckEventHandler obj = new MyRadioButton.CheckEventHandler(this.RadioLoginType_Change);
				MyRadioButton myRadioButton = this.roleExpression;
				if (myRadioButton != null)
				{
					myRadioButton.CountIterator(obj);
				}
				this.roleExpression = value;
				myRadioButton = this.roleExpression;
				if (myRadioButton != null)
				{
					myRadioButton.VisitIterator(obj);
				}
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000B50 RID: 2896 RVA: 0x0000841D File Offset: 0x0000661D
		// (set) Token: 0x06000B51 RID: 2897 RVA: 0x00008425 File Offset: 0x00006625
		internal virtual ScaleTransform AprilScaleTrans { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000B52 RID: 2898 RVA: 0x0000842E File Offset: 0x0000662E
		// (set) Token: 0x06000B53 RID: 2899 RVA: 0x00008436 File Offset: 0x00006636
		internal virtual TranslateTransform AprilPosTrans { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000B54 RID: 2900 RVA: 0x0000843F File Offset: 0x0000663F
		// (set) Token: 0x06000B55 RID: 2901 RVA: 0x000623A8 File Offset: 0x000605A8
		internal virtual MyButton BtnLaunch
		{
			[CompilerGenerated]
			get
			{
				return this.m_WrapperExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.BtnLaunch_Click();
				};
				RoutedEventHandler value2 = delegate(object sender, RoutedEventArgs e)
				{
					this.RefreshButtonsUI();
				};
				MyButton wrapperExpression = this.m_WrapperExpression;
				if (wrapperExpression != null)
				{
					wrapperExpression.CancelModel(obj);
					wrapperExpression.Loaded -= value2;
				}
				this.m_WrapperExpression = value;
				wrapperExpression = this.m_WrapperExpression;
				if (wrapperExpression != null)
				{
					wrapperExpression.ValidateModel(obj);
					wrapperExpression.Loaded += value2;
				}
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000B56 RID: 2902 RVA: 0x00008447 File Offset: 0x00006647
		// (set) Token: 0x06000B57 RID: 2903 RVA: 0x0000844F File Offset: 0x0000664F
		internal virtual TextBlock LabVersion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000B58 RID: 2904 RVA: 0x00008458 File Offset: 0x00006658
		// (set) Token: 0x06000B59 RID: 2905 RVA: 0x00008460 File Offset: 0x00006660
		internal virtual Grid PanLaunching { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000B5A RID: 2906 RVA: 0x00008469 File Offset: 0x00006669
		// (set) Token: 0x06000B5B RID: 2907 RVA: 0x00008471 File Offset: 0x00006671
		internal virtual MyLoading LoadLaunching { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000B5C RID: 2908 RVA: 0x0000847A File Offset: 0x0000667A
		// (set) Token: 0x06000B5D RID: 2909 RVA: 0x00008482 File Offset: 0x00006682
		internal virtual TextBlock LabLaunchingTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000B5E RID: 2910 RVA: 0x0000848B File Offset: 0x0000668B
		// (set) Token: 0x06000B5F RID: 2911 RVA: 0x00008493 File Offset: 0x00006693
		internal virtual TextBlock LabLaunchingName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000B60 RID: 2912 RVA: 0x0000849C File Offset: 0x0000669C
		// (set) Token: 0x06000B61 RID: 2913 RVA: 0x000084A4 File Offset: 0x000066A4
		internal virtual ColumnDefinition ProgressLaunchingFinished { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000B62 RID: 2914 RVA: 0x000084AD File Offset: 0x000066AD
		// (set) Token: 0x06000B63 RID: 2915 RVA: 0x000084B5 File Offset: 0x000066B5
		internal virtual ColumnDefinition ProgressLaunchingUnfinished { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000B64 RID: 2916 RVA: 0x000084BE File Offset: 0x000066BE
		// (set) Token: 0x06000B65 RID: 2917 RVA: 0x00062408 File Offset: 0x00060608
		internal virtual Grid PanLaunchingInfo
		{
			[CompilerGenerated]
			get
			{
				return this.m_DescriptorExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				SizeChangedEventHandler value2 = new SizeChangedEventHandler(this.PanLaunchingInfo_SizeChangedW);
				SizeChangedEventHandler value3 = new SizeChangedEventHandler(this.PanLaunchingInfo_SizeChangedH);
				Grid descriptorExpression = this.m_DescriptorExpression;
				if (descriptorExpression != null)
				{
					descriptorExpression.SizeChanged -= value2;
					descriptorExpression.SizeChanged -= value3;
				}
				this.m_DescriptorExpression = value;
				descriptorExpression = this.m_DescriptorExpression;
				if (descriptorExpression != null)
				{
					descriptorExpression.SizeChanged += value2;
					descriptorExpression.SizeChanged += value3;
				}
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000B66 RID: 2918 RVA: 0x000084C6 File Offset: 0x000066C6
		// (set) Token: 0x06000B67 RID: 2919 RVA: 0x000084CE File Offset: 0x000066CE
		internal virtual TextBlock LabLaunchingStage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06000B68 RID: 2920 RVA: 0x000084D7 File Offset: 0x000066D7
		// (set) Token: 0x06000B69 RID: 2921 RVA: 0x000084DF File Offset: 0x000066DF
		internal virtual TextBlock LabLaunchingMethod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06000B6A RID: 2922 RVA: 0x000084E8 File Offset: 0x000066E8
		// (set) Token: 0x06000B6B RID: 2923 RVA: 0x000084F0 File Offset: 0x000066F0
		internal virtual TextBlock LabLaunchingProgressLeft { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000B6C RID: 2924 RVA: 0x000084F9 File Offset: 0x000066F9
		// (set) Token: 0x06000B6D RID: 2925 RVA: 0x00008501 File Offset: 0x00006701
		internal virtual TextBlock LabLaunchingProgress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000B6E RID: 2926 RVA: 0x0000850A File Offset: 0x0000670A
		// (set) Token: 0x06000B6F RID: 2927 RVA: 0x00008512 File Offset: 0x00006712
		internal virtual TextBlock LabLaunchingDownloadLeft { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000B70 RID: 2928 RVA: 0x0000851B File Offset: 0x0000671B
		// (set) Token: 0x06000B71 RID: 2929 RVA: 0x00008523 File Offset: 0x00006723
		internal virtual TextBlock LabLaunchingDownload { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06000B72 RID: 2930 RVA: 0x0000852C File Offset: 0x0000672C
		// (set) Token: 0x06000B73 RID: 2931 RVA: 0x00008534 File Offset: 0x00006734
		internal virtual Grid PanLaunchingHint { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000B74 RID: 2932 RVA: 0x0000853D File Offset: 0x0000673D
		// (set) Token: 0x06000B75 RID: 2933 RVA: 0x00008545 File Offset: 0x00006745
		internal virtual TextBlock LabLaunchingHint { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000B76 RID: 2934 RVA: 0x0000854E File Offset: 0x0000674E
		// (set) Token: 0x06000B77 RID: 2935 RVA: 0x00062468 File Offset: 0x00060668
		internal virtual MyButton BtnCancel
		{
			[CompilerGenerated]
			get
			{
				return this.m_StateExpression;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = delegate(object sender, EventArgs e)
				{
					this.BtnCancel_Click();
				};
				MyButton stateExpression = this.m_StateExpression;
				if (stateExpression != null)
				{
					stateExpression.CancelModel(obj);
				}
				this.m_StateExpression = value;
				stateExpression = this.m_StateExpression;
				if (stateExpression != null)
				{
					stateExpression.ValidateModel(obj);
				}
			}
		}

		// Token: 0x06000B78 RID: 2936 RVA: 0x000624AC File Offset: 0x000606AC
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this.m_CreatorExpression)
			{
				this.m_CreatorExpression = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagelaunch/pagelaunchleft.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000B79 RID: 2937 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000B7A RID: 2938 RVA: 0x000624DC File Offset: 0x000606DC
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PanBack = (PageLaunchLeft)target;
				return;
			}
			if (connectionId == 2)
			{
				this.PanInput = (Grid)target;
				return;
			}
			if (connectionId == 3)
			{
				this.BtnVersion = (MyButton)target;
				return;
			}
			if (connectionId == 4)
			{
				this.BtnMore = (MyButton)target;
				return;
			}
			if (connectionId == 5)
			{
				this.PanLogin = (Grid)target;
				return;
			}
			if (connectionId == 6)
			{
				this.PanTypeOne = (Grid)target;
				return;
			}
			if (connectionId == 7)
			{
				this.PathTypeOne = (System.Windows.Shapes.Path)target;
				return;
			}
			if (connectionId == 8)
			{
				this.LabTypeOne = (TextBlock)target;
				return;
			}
			if (connectionId == 9)
			{
				this.PanType = (Grid)target;
				return;
			}
			if (connectionId == 0xA)
			{
				this.RadioLoginType1 = (MyRadioButton)target;
				return;
			}
			if (connectionId == 0xB)
			{
				this.RadioLoginType5 = (MyRadioButton)target;
				return;
			}
			if (connectionId == 0xC)
			{
				this.RadioLoginType0 = (MyRadioButton)target;
				return;
			}
			if (connectionId == 0xD)
			{
				this.AprilScaleTrans = (ScaleTransform)target;
				return;
			}
			if (connectionId == 0xE)
			{
				this.AprilPosTrans = (TranslateTransform)target;
				return;
			}
			if (connectionId == 0xF)
			{
				this.BtnLaunch = (MyButton)target;
				return;
			}
			if (connectionId == 0x10)
			{
				this.LabVersion = (TextBlock)target;
				return;
			}
			if (connectionId == 0x11)
			{
				this.PanLaunching = (Grid)target;
				return;
			}
			if (connectionId == 0x12)
			{
				this.LoadLaunching = (MyLoading)target;
				return;
			}
			if (connectionId == 0x13)
			{
				this.LabLaunchingTitle = (TextBlock)target;
				return;
			}
			if (connectionId == 0x14)
			{
				this.LabLaunchingName = (TextBlock)target;
				return;
			}
			if (connectionId == 0x15)
			{
				this.ProgressLaunchingFinished = (ColumnDefinition)target;
				return;
			}
			if (connectionId == 0x16)
			{
				this.ProgressLaunchingUnfinished = (ColumnDefinition)target;
				return;
			}
			if (connectionId == 0x17)
			{
				this.PanLaunchingInfo = (Grid)target;
				return;
			}
			if (connectionId == 0x18)
			{
				this.LabLaunchingStage = (TextBlock)target;
				return;
			}
			if (connectionId == 0x19)
			{
				this.LabLaunchingMethod = (TextBlock)target;
				return;
			}
			if (connectionId == 0x1A)
			{
				this.LabLaunchingProgressLeft = (TextBlock)target;
				return;
			}
			if (connectionId == 0x1B)
			{
				this.LabLaunchingProgress = (TextBlock)target;
				return;
			}
			if (connectionId == 0x1C)
			{
				this.LabLaunchingDownloadLeft = (TextBlock)target;
				return;
			}
			if (connectionId == 0x1D)
			{
				this.LabLaunchingDownload = (TextBlock)target;
				return;
			}
			if (connectionId == 0x1E)
			{
				this.PanLaunchingHint = (Grid)target;
				return;
			}
			if (connectionId == 0x1F)
			{
				this.LabLaunchingHint = (TextBlock)target;
				return;
			}
			if (connectionId == 0x20)
			{
				this.BtnCancel = (MyButton)target;
				return;
			}
			this.m_CreatorExpression = true;
		}

		// Token: 0x04000613 RID: 1555
		private bool _RefExpression;

		// Token: 0x04000614 RID: 1556
		private bool _ParameterExpression;

		// Token: 0x04000615 RID: 1557
		private PageLaunchLeft.PageType m_StubExpression;

		// Token: 0x04000616 RID: 1558
		public static ModLoader.LoaderTask<ModBase.EqualableList<string>, string> m_AccountExpression;

		// Token: 0x04000617 RID: 1559
		public static ModLoader.LoaderTask<ModBase.EqualableList<string>, string> m_ConfigurationExpression;

		// Token: 0x04000618 RID: 1560
		public static ModLoader.LoaderTask<ModBase.EqualableList<string>, string> m_InterpreterExpression;

		// Token: 0x04000619 RID: 1561
		public static ModLoader.LoaderTask<ModBase.EqualableList<string>, string> _PredicateExpression;

		// Token: 0x0400061A RID: 1562
		public static ModLoader.LoaderTask<ModBase.EqualableList<string>, string> _StructExpression;

		// Token: 0x0400061B RID: 1563
		public static List<ModLoader.LoaderTask<ModBase.EqualableList<string>, string>> m_ResolverExpression;

		// Token: 0x0400061C RID: 1564
		private int m_CollectionExpression;

		// Token: 0x0400061D RID: 1565
		private ModMinecraft.McVersion _TestsExpression;

		// Token: 0x0400061E RID: 1566
		private double m_BroadcasterExpression;

		// Token: 0x0400061F RID: 1567
		private bool fieldExpression;

		// Token: 0x04000620 RID: 1568
		private double _StatusExpression;

		// Token: 0x04000621 RID: 1569
		private bool _RequestExpression;

		// Token: 0x04000622 RID: 1570
		private double m_PoolExpression;

		// Token: 0x04000623 RID: 1571
		[AccessedThroughProperty("PanBack")]
		[CompilerGenerated]
		private PageLaunchLeft _ParserExpression;

		// Token: 0x04000624 RID: 1572
		[CompilerGenerated]
		[AccessedThroughProperty("PanInput")]
		private Grid m_ProxyExpression;

		// Token: 0x04000625 RID: 1573
		[CompilerGenerated]
		[AccessedThroughProperty("BtnVersion")]
		private MyButton _SetterExpression;

		// Token: 0x04000626 RID: 1574
		[AccessedThroughProperty("BtnMore")]
		[CompilerGenerated]
		private MyButton merchantExpression;

		// Token: 0x04000627 RID: 1575
		[AccessedThroughProperty("PanLogin")]
		[CompilerGenerated]
		private Grid _EventExpression;

		// Token: 0x04000628 RID: 1576
		[CompilerGenerated]
		[AccessedThroughProperty("PanTypeOne")]
		private Grid _PrinterExpression;

		// Token: 0x04000629 RID: 1577
		[CompilerGenerated]
		[AccessedThroughProperty("PathTypeOne")]
		private System.Windows.Shapes.Path _ProductExpression;

		// Token: 0x0400062A RID: 1578
		[CompilerGenerated]
		[AccessedThroughProperty("LabTypeOne")]
		private TextBlock _ComparatorExpression;

		// Token: 0x0400062B RID: 1579
		[AccessedThroughProperty("PanType")]
		[CompilerGenerated]
		private Grid registryExpression;

		// Token: 0x0400062C RID: 1580
		[CompilerGenerated]
		[AccessedThroughProperty("RadioLoginType1")]
		private MyRadioButton m_AttributeExpression;

		// Token: 0x0400062D RID: 1581
		[CompilerGenerated]
		[AccessedThroughProperty("RadioLoginType5")]
		private MyRadioButton m_ValueExpression;

		// Token: 0x0400062E RID: 1582
		[CompilerGenerated]
		[AccessedThroughProperty("RadioLoginType0")]
		private MyRadioButton roleExpression;

		// Token: 0x0400062F RID: 1583
		[AccessedThroughProperty("AprilScaleTrans")]
		[CompilerGenerated]
		private ScaleTransform advisorExpression;

		// Token: 0x04000630 RID: 1584
		[CompilerGenerated]
		[AccessedThroughProperty("AprilPosTrans")]
		private TranslateTransform m_StrategyExpression;

		// Token: 0x04000631 RID: 1585
		[CompilerGenerated]
		[AccessedThroughProperty("BtnLaunch")]
		private MyButton m_WrapperExpression;

		// Token: 0x04000632 RID: 1586
		[CompilerGenerated]
		[AccessedThroughProperty("LabVersion")]
		private TextBlock writerExpression;

		// Token: 0x04000633 RID: 1587
		[CompilerGenerated]
		[AccessedThroughProperty("PanLaunching")]
		private Grid _ExporterExpression;

		// Token: 0x04000634 RID: 1588
		[CompilerGenerated]
		[AccessedThroughProperty("LoadLaunching")]
		private MyLoading recordExpression;

		// Token: 0x04000635 RID: 1589
		[AccessedThroughProperty("LabLaunchingTitle")]
		[CompilerGenerated]
		private TextBlock m_GetterExpression;

		// Token: 0x04000636 RID: 1590
		[CompilerGenerated]
		[AccessedThroughProperty("LabLaunchingName")]
		private TextBlock interceptorExpression;

		// Token: 0x04000637 RID: 1591
		[CompilerGenerated]
		[AccessedThroughProperty("ProgressLaunchingFinished")]
		private ColumnDefinition m_InvocationExpression;

		// Token: 0x04000638 RID: 1592
		[CompilerGenerated]
		[AccessedThroughProperty("ProgressLaunchingUnfinished")]
		private ColumnDefinition m_CandidateExpression;

		// Token: 0x04000639 RID: 1593
		[CompilerGenerated]
		[AccessedThroughProperty("PanLaunchingInfo")]
		private Grid m_DescriptorExpression;

		// Token: 0x0400063A RID: 1594
		[CompilerGenerated]
		[AccessedThroughProperty("LabLaunchingStage")]
		private TextBlock _ContextExpression;

		// Token: 0x0400063B RID: 1595
		[AccessedThroughProperty("LabLaunchingMethod")]
		[CompilerGenerated]
		private TextBlock observerExpression;

		// Token: 0x0400063C RID: 1596
		[CompilerGenerated]
		[AccessedThroughProperty("LabLaunchingProgressLeft")]
		private TextBlock tokenizerExpression;

		// Token: 0x0400063D RID: 1597
		[CompilerGenerated]
		[AccessedThroughProperty("LabLaunchingProgress")]
		private TextBlock _DispatcherExpression;

		// Token: 0x0400063E RID: 1598
		[AccessedThroughProperty("LabLaunchingDownloadLeft")]
		[CompilerGenerated]
		private TextBlock m_TagExpression;

		// Token: 0x0400063F RID: 1599
		[CompilerGenerated]
		[AccessedThroughProperty("LabLaunchingDownload")]
		private TextBlock m_InitializerExpression;

		// Token: 0x04000640 RID: 1600
		[CompilerGenerated]
		[AccessedThroughProperty("PanLaunchingHint")]
		private Grid m_PropertyExpression;

		// Token: 0x04000641 RID: 1601
		[AccessedThroughProperty("LabLaunchingHint")]
		[CompilerGenerated]
		private TextBlock m_WatcherExpression;

		// Token: 0x04000642 RID: 1602
		[AccessedThroughProperty("BtnCancel")]
		[CompilerGenerated]
		private MyButton m_StateExpression;

		// Token: 0x04000643 RID: 1603
		private bool m_CreatorExpression;

		// Token: 0x02000138 RID: 312
		private enum PageType
		{
			// Token: 0x04000645 RID: 1605
			None,
			// Token: 0x04000646 RID: 1606
			Mojang,
			// Token: 0x04000647 RID: 1607
			MojangSkin,
			// Token: 0x04000648 RID: 1608
			Legacy,
			// Token: 0x04000649 RID: 1609
			Nide,
			// Token: 0x0400064A RID: 1610
			NideSkin,
			// Token: 0x0400064B RID: 1611
			Auth,
			// Token: 0x0400064C RID: 1612
			AuthSkin,
			// Token: 0x0400064D RID: 1613
			Ms,
			// Token: 0x0400064E RID: 1614
			MsSkin
		}
	}
}
