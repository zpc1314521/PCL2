using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PCL
{
	// Token: 0x02000086 RID: 134
	[DesignerGenerated]
	public class PageDownloadInstall : AdornerDecorator, IComponentConnector
	{
		// Token: 0x060003B5 RID: 949 RVA: 0x00024998 File Offset: 0x00022B98
		public PageDownloadInstall()
		{
			base.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.Init();
			};
			this._ListenerVal = false;
			this.importerVal = false;
			this._TemplateVal = false;
			this.regVal = null;
			this.definitionVal = null;
			this._ParamVal = null;
			this.m_MockVal = null;
			this.specificationVal = null;
			this.m_DicVal = false;
			this._SchemaVal = false;
			this.InitializeComponent();
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x00024A0C File Offset: 0x00022C0C
		private void Init()
		{
			this.PanBack.ScrollToHome();
			ModDownload._AlgoIterator.Start(PageDownloadClient._IndexerUtils, false);
			ModDownload.issuerIterator.Start(PageDownloadOptiFine.writerIterator, false);
			ModDownload.m_BridgeIterator.Start(PageDownloadLiteLoader.LoadInput, false);
			ModDownload.m_ObjectIterator.Start(PageDownloadFabric.watcherVal, false);
			ModDownload._VisitorIterator.Start(PageDownloadFabric.watcherVal, false);
			this.TextSelectName.ValidateRules = new Collection<Validate>
			{
				new ValidateFolderName(ModMinecraft.m_ResolverIterator + "versions", true, true)
			};
			this.TextSelectName.Validate();
			this.SelectReload();
			if (!this._ListenerVal)
			{
				this._ListenerVal = true;
				ModDownloadLib.McDownloadForgeRecommendedRefresh();
				this.LoadMinecraft.State = ModDownload._AlgoIterator;
				this.LoadOptiFine.State = ModDownload.issuerIterator;
				this.LoadLiteLoader.State = ModDownload.m_BridgeIterator;
				this.LoadFabric.State = ModDownload.m_ObjectIterator;
				this.LoadFabricApi.State = ModDownload._VisitorIterator;
			}
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00024B18 File Offset: 0x00022D18
		private void EnterSelectPage()
		{
			if (!this.importerVal)
			{
				this.importerVal = true;
				this.m_DicVal = false;
				this.PanSelect.Visibility = Visibility.Visible;
				this.PanMinecraft.IsHitTestVisible = false;
				this.PanSelect.IsHitTestVisible = true;
				this.PanBack.IsHitTestVisible = false;
				this.PanBack.ScrollToHome();
				this.CardMinecraft.LoadAnimation = false;
				this.CardMinecraft.IsSwaped = true;
				this.CardOptiFine.LoadAnimation = false;
				this.CardOptiFine.IsSwaped = true;
				this.CardLiteLoader.LoadAnimation = false;
				this.CardLiteLoader.IsSwaped = true;
				this.CardForge.LoadAnimation = false;
				this.CardForge.IsSwaped = true;
				this.CardFabric.LoadAnimation = false;
				this.CardFabric.IsSwaped = true;
				this.CardFabricApi.LoadAnimation = false;
				this.CardFabricApi.IsSwaped = true;
				if (Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("HintInstallBack", null))))
				{
					ModBase._BaseRule.Set("HintInstallBack", true, false, null);
					ModMain.Hint("点击 Minecraft 项即可返回游戏主版本选择页面！", ModMain.HintType.Info, true);
				}
				if (this._AdapterVal.StartsWith("1."))
				{
					ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>("DlForgeVersion " + this._AdapterVal, new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>.LoadDelegateSub(ModDownload.DlForgeVersionMain), null, ThreadPriority.Normal);
					this.LoadForge.State = loaderTask;
					loaderTask.Start(this._AdapterVal, false);
				}
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaOpacity(this.PanMinecraft, -this.PanMinecraft.Opacity, 0x64, 0xA, null, false),
					ModAni.AaTranslateX(this.PanMinecraft, -50.0 - ((TranslateTransform)this.PanMinecraft.RenderTransform).X, 0x6E, 0xA, null, false),
					ModAni.AaCode(delegate
					{
						this.PanBack.ScrollToHome();
						this.TextSelectName.Validate();
						this.OptiFine_Loaded();
						this.LiteLoader_Loaded();
						this.Forge_Loaded();
						this.Fabric_Loaded();
						this.FabricApi_Loaded();
						this.SelectReload();
					}, 0, true),
					ModAni.AaOpacity(this.PanSelect, 1.0 - this.PanSelect.Opacity, 0x96, 0x64, null, false),
					ModAni.AaTranslateX(this.PanSelect, -((TranslateTransform)this.PanSelect.RenderTransform).X, 0x140, 0x64, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Weak), false),
					ModAni.AaCode(delegate
					{
						this.PanMinecraft.Visibility = Visibility.Collapsed;
						this.CardMinecraft.LoadAnimation = true;
						this.CardOptiFine.LoadAnimation = true;
						this.CardLiteLoader.LoadAnimation = true;
						this.CardForge.LoadAnimation = true;
						this.CardFabric.LoadAnimation = true;
						this.CardFabricApi.LoadAnimation = true;
						this.PanBack.IsHitTestVisible = true;
						if (!this._TemplateVal)
						{
							this._TemplateVal = true;
							this.BtnOptiFineClearInner.SetBinding(Shape.FillProperty, new Binding("Foreground")
							{
								Source = this.CardOptiFine.m_Bridge,
								Mode = BindingMode.OneWay
							});
							this.BtnLiteLoaderClearInner.SetBinding(Shape.FillProperty, new Binding("Foreground")
							{
								Source = this.CardLiteLoader.m_Bridge,
								Mode = BindingMode.OneWay
							});
							this.BtnForgeClearInner.SetBinding(Shape.FillProperty, new Binding("Foreground")
							{
								Source = this.CardForge.m_Bridge,
								Mode = BindingMode.OneWay
							});
							this.BtnFabricClearInner.SetBinding(Shape.FillProperty, new Binding("Foreground")
							{
								Source = this.CardFabric.m_Bridge,
								Mode = BindingMode.OneWay
							});
							this.BtnFabricApiClearInner.SetBinding(Shape.FillProperty, new Binding("Foreground")
							{
								Source = this.CardFabricApi.m_Bridge,
								Mode = BindingMode.OneWay
							});
						}
					}, 0, true)
				}, "FrmDownloadInstall SelectPageSwitch", true);
			}
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00024DA0 File Offset: 0x00022FA0
		public void ExitSelectPage()
		{
			if (this.importerVal)
			{
				this.importerVal = false;
				this.PanMinecraft.Visibility = Visibility.Visible;
				this.PanSelect.IsHitTestVisible = false;
				this.PanMinecraft.IsHitTestVisible = true;
				this.SelectClear();
				this.PanBack.IsHitTestVisible = false;
				this.PanBack.ScrollToHome();
				this.CardMinecraft.LoadAnimation = false;
				this.CardOptiFine.LoadAnimation = false;
				this.CardLiteLoader.LoadAnimation = false;
				this.CardForge.LoadAnimation = false;
				this.CardFabric.LoadAnimation = false;
				this.CardFabricApi.LoadAnimation = false;
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaOpacity(this.PanSelect, -this.PanSelect.Opacity, 0x5A, 0xA, null, false),
					ModAni.AaTranslateX(this.PanSelect, 50.0 - ((TranslateTransform)this.PanSelect.RenderTransform).X, 0x64, 0xA, null, false),
					ModAni.AaCode(delegate
					{
						this.PanBack.ScrollToHome();
					}, 0, true),
					ModAni.AaOpacity(this.PanMinecraft, 1.0 - this.PanMinecraft.Opacity, 0x78, 0xA, null, false),
					ModAni.AaTranslateX(this.PanMinecraft, -((TranslateTransform)this.PanMinecraft.RenderTransform).X, 0xFA, 0xA, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Weak), false),
					ModAni.AaCode(delegate
					{
						this.PanSelect.Visibility = Visibility.Collapsed;
						this.CardMinecraft.LoadAnimation = true;
						this.CardOptiFine.LoadAnimation = true;
						this.CardLiteLoader.LoadAnimation = true;
						this.CardForge.LoadAnimation = true;
						this.CardFabric.LoadAnimation = true;
						this.CardFabricApi.LoadAnimation = true;
						this.PanBack.IsHitTestVisible = true;
					}, 0, true)
				}, "FrmDownloadInstall SelectPageSwitch", false);
			}
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00024F4C File Offset: 0x0002314C
		public void MinecraftSelected(MyListItem sender, object e)
		{
			this._AdapterVal = sender.Title;
			this.annotationVal = NewLateBinding.LateIndexGet(sender.Tag, new object[]
			{
				"url"
			}, null).ToString();
			this._ReaderVal = sender.Logo;
			this.EnterSelectPage();
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00004399 File Offset: 0x00002599
		private void CardMinecraft_PreviewSwap(object sender, ModBase.RouteEventArgs e)
		{
			this.ExitSelectPage();
			e._HelperMapper = true;
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00024F9C File Offset: 0x0002319C
		private void SetOptiFineInfoShow(string IsShow)
		{
			if (!Operators.ConditionalCompareObjectEqual(this.PanOptiFineInfo.Tag, IsShow, true))
			{
				this.PanOptiFineInfo.Tag = IsShow;
				if (Operators.CompareString(IsShow, "True", true) == 0)
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaTranslateY(this.PanOptiFineInfo, -((TranslateTransform)this.PanOptiFineInfo.RenderTransform).Y, 0x10E, 0x64, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Middle), false),
						ModAni.AaOpacity(this.PanOptiFineInfo, 1.0 - this.PanOptiFineInfo.Opacity, 0x64, 0x5A, null, false)
					}, "SetOptiFineInfoShow", false);
					return;
				}
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaTranslateY(this.PanOptiFineInfo, 6.0 - ((TranslateTransform)this.PanOptiFineInfo.RenderTransform).Y, 0xC8, 0, null, false),
					ModAni.AaOpacity(this.PanOptiFineInfo, -this.PanOptiFineInfo.Opacity, 0x64, 0, null, false)
				}, "SetOptiFineInfoShow", false);
			}
		}

		// Token: 0x060003BC RID: 956 RVA: 0x000250BC File Offset: 0x000232BC
		private void SetLiteLoaderInfoShow(string IsShow)
		{
			if (!Operators.ConditionalCompareObjectEqual(this.PanLiteLoaderInfo.Tag, IsShow, true))
			{
				this.PanLiteLoaderInfo.Tag = IsShow;
				if (Operators.CompareString(IsShow, "True", true) == 0)
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaTranslateY(this.PanLiteLoaderInfo, -((TranslateTransform)this.PanLiteLoaderInfo.RenderTransform).Y, 0x10E, 0x64, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Middle), false),
						ModAni.AaOpacity(this.PanLiteLoaderInfo, 1.0 - this.PanLiteLoaderInfo.Opacity, 0x64, 0x5A, null, false)
					}, "SetLiteLoaderInfoShow", false);
					return;
				}
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaTranslateY(this.PanLiteLoaderInfo, 6.0 - ((TranslateTransform)this.PanLiteLoaderInfo.RenderTransform).Y, 0xC8, 0, null, false),
					ModAni.AaOpacity(this.PanLiteLoaderInfo, -this.PanLiteLoaderInfo.Opacity, 0x64, 0, null, false)
				}, "SetLiteLoaderInfoShow", false);
			}
		}

		// Token: 0x060003BD RID: 957 RVA: 0x000251DC File Offset: 0x000233DC
		private void SetForgeInfoShow(string IsShow)
		{
			if (!Operators.ConditionalCompareObjectEqual(this.PanForgeInfo.Tag, IsShow, true))
			{
				this.PanForgeInfo.Tag = IsShow;
				if (Operators.CompareString(IsShow, "True", true) == 0)
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaTranslateY(this.PanForgeInfo, -((TranslateTransform)this.PanForgeInfo.RenderTransform).Y, 0x10E, 0x64, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Middle), false),
						ModAni.AaOpacity(this.PanForgeInfo, 1.0 - this.PanForgeInfo.Opacity, 0x64, 0x5A, null, false)
					}, "SetForgeInfoShow", false);
					return;
				}
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaTranslateY(this.PanForgeInfo, 6.0 - ((TranslateTransform)this.PanForgeInfo.RenderTransform).Y, 0xC8, 0, null, false),
					ModAni.AaOpacity(this.PanForgeInfo, -this.PanForgeInfo.Opacity, 0x64, 0, null, false)
				}, "SetForgeInfoShow", false);
			}
		}

		// Token: 0x060003BE RID: 958 RVA: 0x000252FC File Offset: 0x000234FC
		private void SetFabricInfoShow(string IsShow)
		{
			if (!Operators.ConditionalCompareObjectEqual(this.PanFabricInfo.Tag, IsShow, true))
			{
				this.PanFabricInfo.Tag = IsShow;
				if (Operators.CompareString(IsShow, "True", true) == 0)
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaTranslateY(this.PanFabricInfo, -((TranslateTransform)this.PanFabricInfo.RenderTransform).Y, 0x10E, 0x64, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Middle), false),
						ModAni.AaOpacity(this.PanFabricInfo, 1.0 - this.PanFabricInfo.Opacity, 0x64, 0x5A, null, false)
					}, "SetFabricInfoShow", false);
					return;
				}
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaTranslateY(this.PanFabricInfo, 6.0 - ((TranslateTransform)this.PanFabricInfo.RenderTransform).Y, 0xC8, 0, null, false),
					ModAni.AaOpacity(this.PanFabricInfo, -this.PanFabricInfo.Opacity, 0x64, 0, null, false)
				}, "SetFabricInfoShow", false);
			}
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0002541C File Offset: 0x0002361C
		private void SetFabricApiInfoShow(string IsShow)
		{
			if (!Operators.ConditionalCompareObjectEqual(this.PanFabricApiInfo.Tag, IsShow, true))
			{
				this.PanFabricApiInfo.Tag = IsShow;
				if (Operators.CompareString(IsShow, "True", true) == 0)
				{
					ModAni.AniStart(new ModAni.AniData[]
					{
						ModAni.AaTranslateY(this.PanFabricApiInfo, -((TranslateTransform)this.PanFabricApiInfo.RenderTransform).Y, 0x10E, 0x64, new ModAni.AniEaseOutBack(ModAni.AniEasePower.Middle), false),
						ModAni.AaOpacity(this.PanFabricApiInfo, 1.0 - this.PanFabricApiInfo.Opacity, 0x64, 0x5A, null, false)
					}, "SetFabricApiInfoShow", false);
					return;
				}
				ModAni.AniStart(new ModAni.AniData[]
				{
					ModAni.AaTranslateY(this.PanFabricApiInfo, 6.0 - ((TranslateTransform)this.PanFabricApiInfo.RenderTransform).Y, 0xC8, 0, null, false),
					ModAni.AaOpacity(this.PanFabricApiInfo, -this.PanFabricApiInfo.Opacity, 0x64, 0, null, false)
				}, "SetFabricApiInfoShow", false);
			}
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x0002553C File Offset: 0x0002373C
		private void SelectReload()
		{
			if (this._AdapterVal != null)
			{
				this.SelectNameUpdate();
				this.ItemSelect.Title = this.TextSelectName.Text;
				this.ItemSelect.Info = this.GetSelectInfo();
				this.ItemSelect.Logo = this.GetSelectLogo();
				this.LabMinecraft.Text = this._AdapterVal;
				this.ImgMinecraft.Source = new ModBitmap.MyBitmap(this._ReaderVal);
				string text = this.LoadOptiFineGetError();
				this.CardOptiFine.singleton.Visibility = ((text == null) ? Visibility.Visible : Visibility.Collapsed);
				if (text != null)
				{
					this.CardOptiFine.IsSwaped = true;
				}
				this.SetOptiFineInfoShow(Conversions.ToString(this.CardOptiFine.IsSwaped));
				if (this.regVal == null)
				{
					this.BtnOptiFineClear.Visibility = Visibility.Collapsed;
					this.ImgOptiFine.Visibility = Visibility.Collapsed;
					this.LabOptiFine.Text = (text ?? "点击选择");
					this.LabOptiFine.Foreground = ModMain._EventFilter;
				}
				else
				{
					this.BtnOptiFineClear.Visibility = Visibility.Visible;
					this.ImgOptiFine.Visibility = Visibility.Visible;
					this.LabOptiFine.Text = this.regVal.m_RepositoryAlgo.Replace(this._AdapterVal + " ", "");
					this.LabOptiFine.Foreground = ModMain.proxyFilter;
				}
				this.HintOptiFine.Visibility = ((this.m_MockVal != null) ? Visibility.Visible : Visibility.Collapsed);
				string text2 = this.LoadLiteLoaderGetError();
				this.CardLiteLoader.singleton.Visibility = ((text2 == null) ? Visibility.Visible : Visibility.Collapsed);
				if (text2 != null)
				{
					this.CardLiteLoader.IsSwaped = true;
				}
				this.SetLiteLoaderInfoShow(Conversions.ToString(this.CardLiteLoader.IsSwaped));
				if (this.definitionVal == null)
				{
					this.BtnLiteLoaderClear.Visibility = Visibility.Collapsed;
					this.ImgLiteLoader.Visibility = Visibility.Collapsed;
					this.LabLiteLoader.Text = (text2 ?? "点击选择");
					this.LabLiteLoader.Foreground = ModMain._EventFilter;
				}
				else
				{
					this.BtnLiteLoaderClear.Visibility = Visibility.Visible;
					this.ImgLiteLoader.Visibility = Visibility.Visible;
					this.LabLiteLoader.Text = this.definitionVal.Inherit;
					this.LabLiteLoader.Foreground = ModMain.proxyFilter;
				}
				string text3 = this.LoadForgeGetError();
				this.CardForge.singleton.Visibility = ((text3 == null) ? Visibility.Visible : Visibility.Collapsed);
				if (text3 != null)
				{
					this.CardForge.IsSwaped = true;
				}
				this.SetForgeInfoShow(Conversions.ToString(this.CardForge.IsSwaped));
				if (this._ParamVal == null)
				{
					this.BtnForgeClear.Visibility = Visibility.Collapsed;
					this.ImgForge.Visibility = Visibility.Collapsed;
					this.LabForge.Text = (text3 ?? "点击选择");
					this.LabForge.Foreground = ModMain._EventFilter;
				}
				else
				{
					this.BtnForgeClear.Visibility = Visibility.Visible;
					this.ImgForge.Visibility = Visibility.Visible;
					this.LabForge.Text = this._ParamVal._ConfigurationAlgo;
					this.LabForge.Foreground = ModMain.proxyFilter;
				}
				string text4 = this.LoadFabricGetError();
				this.CardFabric.singleton.Visibility = ((text4 == null) ? Visibility.Visible : Visibility.Collapsed);
				if (text4 != null)
				{
					this.CardFabric.IsSwaped = true;
				}
				this.SetFabricInfoShow(Conversions.ToString(this.CardFabric.IsSwaped));
				if (this.m_MockVal == null)
				{
					this.BtnFabricClear.Visibility = Visibility.Collapsed;
					this.ImgFabric.Visibility = Visibility.Collapsed;
					this.LabFabric.Text = (text4 ?? "点击选择");
					this.LabFabric.Foreground = ModMain._EventFilter;
				}
				else
				{
					this.BtnFabricClear.Visibility = Visibility.Visible;
					this.ImgFabric.Visibility = Visibility.Visible;
					this.LabFabric.Text = this.m_MockVal.Replace("+build", "");
					this.LabFabric.Foreground = ModMain.proxyFilter;
				}
				this.HintFabric.Visibility = ((this.regVal != null) ? Visibility.Visible : Visibility.Collapsed);
				string text5 = this.LoadFabricApiGetError();
				this.CardFabricApi.singleton.Visibility = ((text5 == null) ? Visibility.Visible : Visibility.Collapsed);
				if (text5 != null || this.m_MockVal == null)
				{
					this.CardFabricApi.IsSwaped = true;
				}
				this.SetFabricApiInfoShow(Conversions.ToString(this.CardFabricApi.IsSwaped));
				if (this.specificationVal == null)
				{
					this.BtnFabricApiClear.Visibility = Visibility.Collapsed;
					this.ImgFabricApi.Visibility = Visibility.Collapsed;
					this.LabFabricApi.Text = (text5 ?? "点击选择");
					this.LabFabricApi.Foreground = ModMain._EventFilter;
				}
				else
				{
					this.BtnFabricApiClear.Visibility = Visibility.Visible;
					this.ImgFabricApi.Visibility = Visibility.Visible;
					this.LabFabricApi.Text = this.specificationVal.m_InterceptorAlgo.Split(new char[]
					{
						']'
					})[1].Replace("Fabric API ", "").Replace(" build ", ".").Trim();
					this.LabFabricApi.Foreground = ModMain.proxyFilter;
				}
				this.HintFabricAPI.Visibility = ((this.m_MockVal == null || this.specificationVal != null) ? Visibility.Collapsed : Visibility.Visible);
			}
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x000043A8 File Offset: 0x000025A8
		private void SelectClear()
		{
			this._AdapterVal = null;
			this.annotationVal = null;
			this._ReaderVal = null;
			this.regVal = null;
			this.definitionVal = null;
			this._ParamVal = null;
			this.m_MockVal = null;
			this.specificationVal = null;
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00025A8C File Offset: 0x00023C8C
		private string GetSelectName()
		{
			string text = this._AdapterVal;
			if (this.m_MockVal != null)
			{
				text = text + "-Fabric " + this.m_MockVal.Replace("+build", "");
			}
			if (this._ParamVal != null)
			{
				text = text + "-Forge_" + this._ParamVal._ConfigurationAlgo;
			}
			if (this.definitionVal != null)
			{
				text += "-LiteLoader";
			}
			if (this.regVal != null)
			{
				text = text + "-OptiFine_" + this.regVal.m_RepositoryAlgo.Replace(this._AdapterVal + " ", "").Replace(" ", "_");
			}
			return text;
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00025B48 File Offset: 0x00023D48
		private string GetSelectInfo()
		{
			string text = "";
			if (this.m_MockVal != null)
			{
				text = text + ", Fabric " + this.m_MockVal.Replace("+build", "");
			}
			if (this._ParamVal != null)
			{
				text = text + ", Forge " + this._ParamVal._ConfigurationAlgo;
			}
			if (this.definitionVal != null)
			{
				text += ", LiteLoader";
			}
			if (this.regVal != null)
			{
				text = text + ", OptiFine " + this.regVal.m_RepositoryAlgo.Replace(this._AdapterVal + " ", "");
			}
			if (Operators.CompareString(text, "", true) == 0)
			{
				text = ", 无附加安装";
			}
			return text.TrimStart(", ".ToCharArray());
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00025C14 File Offset: 0x00023E14
		private string GetSelectLogo()
		{
			string result;
			if (this.m_MockVal != null)
			{
				result = "pack://application:,,,/images/Blocks/Fabric.png";
			}
			else if (this._ParamVal != null)
			{
				result = "pack://application:,,,/images/Blocks/Anvil.png";
			}
			else if (this.definitionVal != null)
			{
				result = "pack://application:,,,/images/Blocks/Egg.png";
			}
			else if (this.regVal != null)
			{
				result = "pack://application:,,,/images/Blocks/GrassPath.png";
			}
			else
			{
				result = this._ReaderVal;
			}
			return result;
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x000043E2 File Offset: 0x000025E2
		private void SelectNameUpdate()
		{
			if (!this.m_DicVal && !this._SchemaVal)
			{
				this._SchemaVal = true;
				this.TextSelectName.Text = this.GetSelectName();
				this._SchemaVal = false;
			}
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00004413 File Offset: 0x00002613
		private void TextSelectName_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (!this._SchemaVal)
			{
				this.m_DicVal = true;
				this.SelectReload();
			}
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0000442A File Offset: 0x0000262A
		private void TextSelectName_ValidateChanged(object sender, EventArgs e)
		{
			this.BtnSelectStart.IsEnabled = (Operators.CompareString(this.TextSelectName.ValidateResult, "", true) == 0);
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00004450 File Offset: 0x00002650
		private void LoadMinecraft_Click(object sender, MouseButtonEventArgs e)
		{
			if (this.LoadMinecraft.State.LoadingState == MyLoading.MyLoadingState.Error)
			{
				PageDownloadClient.RefreshLoader();
			}
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00025C6C File Offset: 0x00023E6C
		private void LoadMinecraft_State(object sender, MyLoading.MyLoadingState state)
		{
			object left = NewLateBinding.LateGet(this.LoadMinecraft.State, null, "State", new object[0], null, null, null);
			if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Loading, true))
			{
				this.LoadMinecraft_OnStart();
				return;
			}
			if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Finished, true))
			{
				this.LoadMinecraft_OnFinish();
			}
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00025CC4 File Offset: 0x00023EC4
		private void LoadMinecraft_OnStart()
		{
			this.PanLoad.Visibility = Visibility.Visible;
			this.ExitSelectPage();
			ModAni.AniStart(new ModAni.AniData[]
			{
				ModAni.AaOpacity(this.PanLoad, 1.0 - this.PanLoad.Opacity, 0x96, 0, null, false),
				ModAni.AaOpacity(this.PanBack, -this.PanBack.Opacity, 0x96, 0, null, false),
				ModAni.AaCode(delegate
				{
					this.PanBack.Visibility = Visibility.Collapsed;
					this.PanMinecraft.Children.Clear();
				}, 0, true)
			}, "FrmDownloadInstall LoadMain Switch", false);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00025D64 File Offset: 0x00023F64
		private void LoadMinecraft_OnFinish()
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
						dictionary[dictionary.Keys.ElementAtOrDefault(i)] = ModBase.Sort<JObject>(dictionary.Values.ElementAtOrDefault(i), (PageDownloadInstall._Closure$__.$IR35-2 == null) ? (PageDownloadInstall._Closure$__.$IR35-2 = ((object a0, object a1) => ((PageDownloadInstall._Closure$__.$I35-0 == null) ? (PageDownloadInstall._Closure$__.$I35-0 = ((JObject Left, JObject Right) => DateTime.Compare(Left["releaseTime"].Value<DateTime>(), Right["releaseTime"].Value<DateTime>()) > 0)) : PageDownloadInstall._Closure$__.$I35-0)((JObject)a0, (JObject)a1))) : PageDownloadInstall._Closure$__.$IR35-2);
					}
					this.PanMinecraft.Children.Clear();
					MyCard myCard = new MyCard();
					myCard.Title = "最新版本";
					myCard.Margin = new Thickness(0.0, 15.0, 0.0, 15.0);
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
					MyCard.StackInstall(ref element, 7, "");
					myCard2.Children.Add(element);
					this.PanMinecraft.Children.Insert(0, myCard2);
					try
					{
						foreach (KeyValuePair<string, List<JObject>> keyValuePair in dictionary)
						{
							if (keyValuePair.Value.Count != 0)
							{
								MyCard myCard3 = new MyCard();
								myCard3.Title = keyValuePair.Key + " (" + Conversions.ToString(keyValuePair.Value.Count) + ")";
								myCard3.Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
								myCard3.InitFactory(7);
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
								this.PanMinecraft.Children.Add(myCard4);
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
					ModBase.Log(ex, "可视化安装版本列表出错", ModBase.LogLevel.Feedback, "出现错误");
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
			}, "FrmDownloadInstall LoadMain Switch", false);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000264EC File Offset: 0x000246EC
		private string LoadOptiFineGetError()
		{
			string result;
			if (this.LoadOptiFine.State.LoadingState == MyLoading.MyLoadingState.Run)
			{
				result = "正在获取版本列表……";
			}
			else if (this.LoadOptiFine.State.LoadingState == MyLoading.MyLoadingState.Error)
			{
				result = Conversions.ToString(Operators.ConcatenateObject("获取版本列表失败：", NewLateBinding.LateGet(NewLateBinding.LateGet(this.LoadOptiFine.State, null, "Error", new object[0], null, null, null), null, "Message", new object[0], null, null, null)));
			}
			else
			{
				try
				{
					List<ModDownload.DlOptiFineListEntry>.Enumerator enumerator = ModDownload.issuerIterator.Output.Value.GetEnumerator();
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.m_RepositoryAlgo.StartsWith(this._AdapterVal + " "))
						{
							if (this._ParamVal != null && ModMinecraft.VersionSortInteger(this._AdapterVal, "1.13") >= 0 && ModMinecraft.VersionSortInteger("1.14.3", this._AdapterVal) >= 0)
							{
								return "与 Forge 不兼容";
							}
							return null;
						}
					}
				}
				finally
				{
					List<ModDownload.DlOptiFineListEntry>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				result = "没有可用版本";
			}
			return result;
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0000446A File Offset: 0x0000266A
		private void CardOptiFine_PreviewSwap(object sender, ModBase.RouteEventArgs e)
		{
			if (this.LoadOptiFineGetError() != null)
			{
				e._HelperMapper = true;
			}
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00026618 File Offset: 0x00024818
		private void OptiFine_Loaded()
		{
			try
			{
				if (ModDownload.issuerIterator.State == ModBase.LoadState.Finished)
				{
					List<ModDownload.DlOptiFineListEntry> list = new List<ModDownload.DlOptiFineListEntry>();
					try
					{
						foreach (ModDownload.DlOptiFineListEntry dlOptiFineListEntry in ModDownload.issuerIterator.Output.Value)
						{
							if (dlOptiFineListEntry.m_RepositoryAlgo.StartsWith(this._AdapterVal + " "))
							{
								list.Add(dlOptiFineListEntry);
							}
						}
					}
					finally
					{
						List<ModDownload.DlOptiFineListEntry>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					if (list.Count != 0)
					{
						list = ModBase.Sort<ModDownload.DlOptiFineListEntry>(list, (PageDownloadInstall._Closure$__.$IR38-3 == null) ? (PageDownloadInstall._Closure$__.$IR38-3 = ((object a0, object a1) => ((PageDownloadInstall._Closure$__.$I38-0 == null) ? (PageDownloadInstall._Closure$__.$I38-0 = ((ModDownload.DlOptiFineListEntry Left, ModDownload.DlOptiFineListEntry Right) => ModMinecraft.VersionSortBoolean(Left.m_RepositoryAlgo, Right.m_RepositoryAlgo))) : PageDownloadInstall._Closure$__.$I38-0)((ModDownload.DlOptiFineListEntry)a0, (ModDownload.DlOptiFineListEntry)a1))) : PageDownloadInstall._Closure$__.$IR38-3);
						this.PanOptiFine.Children.Clear();
						try
						{
							foreach (ModDownload.DlOptiFineListEntry entry in list)
							{
								this.PanOptiFine.Children.Add(ModDownloadLib.OptiFineDownloadListItem(entry, delegate(object sender, MouseButtonEventArgs e)
								{
									this.OptiFine_Selected((MyListItem)sender, e);
								}, false));
							}
						}
						finally
						{
							List<ModDownload.DlOptiFineListEntry>.Enumerator enumerator2;
							((IDisposable)enumerator2).Dispose();
						}
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "可视化 OptiFine 安装版本列表出错", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0000447B File Offset: 0x0000267B
		private void OptiFine_Selected(MyListItem sender, EventArgs e)
		{
			this.regVal = (ModDownload.DlOptiFineListEntry)sender.Tag;
			this.CardOptiFine.IsSwaped = true;
			this.SelectReload();
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x000044A0 File Offset: 0x000026A0
		private void OptiFine_Clear(object sender, MouseButtonEventArgs e)
		{
			this.regVal = null;
			this.CardOptiFine.IsSwaped = true;
			e.Handled = true;
			this.SelectReload();
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x000267A0 File Offset: 0x000249A0
		private string LoadLiteLoaderGetError()
		{
			string result;
			if (this._AdapterVal.Contains("1.") && ModBase.Val(this._AdapterVal.Split(new char[]
			{
				'.'
			})[1]) <= 12.0)
			{
				if (this.LoadLiteLoader.State.LoadingState == MyLoading.MyLoadingState.Run)
				{
					result = "正在获取版本列表……";
				}
				else if (this.LoadLiteLoader.State.LoadingState == MyLoading.MyLoadingState.Error)
				{
					result = Conversions.ToString(Operators.ConcatenateObject("获取版本列表失败：", NewLateBinding.LateGet(NewLateBinding.LateGet(this.LoadLiteLoader.State, null, "Error", new object[0], null, null, null), null, "Message", new object[0], null, null, null)));
				}
				else
				{
					try
					{
						List<ModDownload.DlLiteLoaderListEntry>.Enumerator enumerator = ModDownload.m_BridgeIterator.Output.Value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							if (Operators.CompareString(enumerator.Current.Inherit, this._AdapterVal, true) == 0)
							{
								return null;
							}
						}
					}
					finally
					{
						List<ModDownload.DlLiteLoaderListEntry>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					result = "没有可用版本";
				}
			}
			else
			{
				result = "没有可用版本";
			}
			return result;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x000044C2 File Offset: 0x000026C2
		private void CardLiteLoader_PreviewSwap(object sender, ModBase.RouteEventArgs e)
		{
			if (this.LoadLiteLoaderGetError() != null)
			{
				e._HelperMapper = true;
			}
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x000268D0 File Offset: 0x00024AD0
		private void LiteLoader_Loaded()
		{
			try
			{
				if (ModDownload.m_BridgeIterator.State == ModBase.LoadState.Finished)
				{
					List<ModDownload.DlLiteLoaderListEntry> list = new List<ModDownload.DlLiteLoaderListEntry>();
					try
					{
						foreach (ModDownload.DlLiteLoaderListEntry dlLiteLoaderListEntry in ModDownload.m_BridgeIterator.Output.Value)
						{
							if (Operators.CompareString(dlLiteLoaderListEntry.Inherit, this._AdapterVal, true) == 0)
							{
								list.Add(dlLiteLoaderListEntry);
							}
						}
					}
					finally
					{
						List<ModDownload.DlLiteLoaderListEntry>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					if (list.Count != 0)
					{
						this.PanLiteLoader.Children.Clear();
						try
						{
							foreach (ModDownload.DlLiteLoaderListEntry entry in list)
							{
								this.PanLiteLoader.Children.Add(ModDownloadLib.LiteLoaderDownloadListItem(entry, delegate(object sender, MouseButtonEventArgs e)
								{
									this.LiteLoader_Selected((MyListItem)sender, e);
								}, false));
							}
						}
						finally
						{
							List<ModDownload.DlLiteLoaderListEntry>.Enumerator enumerator2;
							((IDisposable)enumerator2).Dispose();
						}
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "可视化 LiteLoader 安装版本列表出错", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x000044D3 File Offset: 0x000026D3
		private void LiteLoader_Selected(MyListItem sender, EventArgs e)
		{
			this.definitionVal = (ModDownload.DlLiteLoaderListEntry)sender.Tag;
			this.CardLiteLoader.IsSwaped = true;
			this.SelectReload();
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x000044F8 File Offset: 0x000026F8
		private void LiteLoader_Clear(object sender, MouseButtonEventArgs e)
		{
			this.definitionVal = null;
			this.CardLiteLoader.IsSwaped = true;
			e.Handled = true;
			this.SelectReload();
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x00026A00 File Offset: 0x00024C00
		private string LoadForgeGetError()
		{
			string result;
			if (!this._AdapterVal.StartsWith("1."))
			{
				result = "没有可用版本";
			}
			else if (!this.LoadForge.State.IsLoader)
			{
				result = "正在获取版本列表……";
			}
			else
			{
				ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = (ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>)this.LoadForge.State;
				if (Operators.CompareString(this._AdapterVal, loaderTask.Input, true) != 0)
				{
					result = "正在获取版本列表……";
				}
				else if (loaderTask.State == ModBase.LoadState.Loading)
				{
					result = "正在获取版本列表……";
				}
				else if (loaderTask.State == ModBase.LoadState.Failed)
				{
					string message = loaderTask.Error.Message;
					if (message.Contains("没有可用版本"))
					{
						result = "没有可用版本";
					}
					else
					{
						result = "获取版本列表失败：" + message;
					}
				}
				else if (loaderTask.State != ModBase.LoadState.Finished)
				{
					result = "获取版本列表失败：未知错误，状态为 " + ModBase.GetStringFromEnum(loaderTask.State);
				}
				else
				{
					try
					{
						foreach (ModDownload.DlForgeVersionEntry dlForgeVersionEntry in loaderTask.Output)
						{
							if (Operators.CompareString(dlForgeVersionEntry._CollectionAlgo, "universal", true) != 0 && Operators.CompareString(dlForgeVersionEntry._CollectionAlgo, "client", true) != 0)
							{
								if (this.m_MockVal != null)
								{
									return "与 Fabric 不兼容";
								}
								if (this.regVal != null && ModMinecraft.VersionSortInteger(this._AdapterVal, "1.13") >= 0 && ModMinecraft.VersionSortInteger("1.14.3", this._AdapterVal) >= 0)
								{
									return "与 OptiFine 不兼容";
								}
								return null;
							}
						}
					}
					finally
					{
						List<ModDownload.DlForgeVersionEntry>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					result = "该版本不支持自动安装";
				}
			}
			return result;
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0000451A File Offset: 0x0000271A
		private void CardForge_PreviewSwap(object sender, ModBase.RouteEventArgs e)
		{
			if (this.LoadForgeGetError() != null)
			{
				e._HelperMapper = true;
			}
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00026BAC File Offset: 0x00024DAC
		private void Forge_Loaded()
		{
			try
			{
				if (this.LoadForge.State.IsLoader)
				{
					ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = (ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>)this.LoadForge.State;
					if (Operators.CompareString(this._AdapterVal, loaderTask.Input, true) == 0)
					{
						if (loaderTask.State == ModBase.LoadState.Finished)
						{
							List<ModDownload.DlForgeVersionEntry> list = new List<ModDownload.DlForgeVersionEntry>();
							list.AddRange(loaderTask.Output);
							if (loaderTask.Output.Count != 0)
							{
								this.PanForge.Children.Clear();
								list = ModBase.Sort<ModDownload.DlForgeVersionEntry>(list, (PageDownloadInstall._Closure$__.$IR48-6 == null) ? (PageDownloadInstall._Closure$__.$IR48-6 = ((object a0, object a1) => ((PageDownloadInstall._Closure$__.$I48-0 == null) ? (PageDownloadInstall._Closure$__.$I48-0 = ((ModDownload.DlForgeVersionEntry Left, ModDownload.DlForgeVersionEntry Right) => new Version(Left._ConfigurationAlgo) > new Version(Right._ConfigurationAlgo))) : PageDownloadInstall._Closure$__.$I48-0)((ModDownload.DlForgeVersionEntry)a0, (ModDownload.DlForgeVersionEntry)a1))) : PageDownloadInstall._Closure$__.$IR48-6);
								ModDownloadLib.ForgeDownloadListItemPreload(this.PanForge, list, delegate(object sender, MouseButtonEventArgs e)
								{
									this.Forge_Selected((MyListItem)sender, e);
								}, false);
								try
								{
									foreach (ModDownload.DlForgeVersionEntry dlForgeVersionEntry in list)
									{
										if (Operators.CompareString(dlForgeVersionEntry._CollectionAlgo, "universal", true) != 0 && Operators.CompareString(dlForgeVersionEntry._CollectionAlgo, "client", true) != 0)
										{
											this.PanForge.Children.Add(ModDownloadLib.ForgeDownloadListItem(dlForgeVersionEntry, delegate(object sender, MouseButtonEventArgs e)
											{
												this.Forge_Selected((MyListItem)sender, e);
											}, false));
										}
									}
								}
								finally
								{
									List<ModDownload.DlForgeVersionEntry>.Enumerator enumerator;
									((IDisposable)enumerator).Dispose();
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "可视化 Forge 安装版本列表出错", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0000452B File Offset: 0x0000272B
		private void Forge_Selected(MyListItem sender, EventArgs e)
		{
			this._ParamVal = (ModDownload.DlForgeVersionEntry)sender.Tag;
			this.CardForge.IsSwaped = true;
			this.SelectReload();
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00004550 File Offset: 0x00002750
		private void Forge_Clear(object sender, MouseButtonEventArgs e)
		{
			this._ParamVal = null;
			this.CardForge.IsSwaped = true;
			e.Handled = true;
			this.SelectReload();
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00026D4C File Offset: 0x00024F4C
		private string LoadFabricGetError()
		{
			string result;
			if (this.LoadFabric.State.LoadingState == MyLoading.MyLoadingState.Run)
			{
				result = "正在获取版本列表……";
			}
			else if (this.LoadFabric.State.LoadingState == MyLoading.MyLoadingState.Error)
			{
				result = Conversions.ToString(Operators.ConcatenateObject("获取版本列表失败：", NewLateBinding.LateGet(NewLateBinding.LateGet(this.LoadFabric.State, null, "Error", new object[0], null, null, null), null, "Message", new object[0], null, null, null)));
			}
			else
			{
				try
				{
					IEnumerator<JToken> enumerator = ((IEnumerable<JToken>)ModDownload.m_ObjectIterator.Output.Value["game"]).GetEnumerator();
					while (enumerator.MoveNext())
					{
						if (Operators.CompareString(((JObject)enumerator.Current)["version"].ToString(), this._AdapterVal, true) == 0)
						{
							if (this._ParamVal != null)
							{
								return "与 Forge 不兼容";
							}
							return null;
						}
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
				result = "没有可用版本";
			}
			return result;
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00004572 File Offset: 0x00002772
		private void CardFabric_PreviewSwap(object sender, ModBase.RouteEventArgs e)
		{
			if (this.LoadFabricGetError() != null)
			{
				e._HelperMapper = true;
			}
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00026E58 File Offset: 0x00025058
		private void Fabric_Loaded()
		{
			try
			{
				if (ModDownload.m_ObjectIterator.State == ModBase.LoadState.Finished)
				{
					JArray jarray = (JArray)ModDownload.m_ObjectIterator.Output.Value["loader"];
					if (jarray.Count != 0)
					{
						this.PanFabric.Children.Clear();
						try
						{
							foreach (JToken jtoken in jarray)
							{
								this.PanFabric.Children.Add(ModDownloadLib.FabricDownloadListItem((JObject)jtoken, delegate(object sender, MouseButtonEventArgs e)
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
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "可视化 Fabric 安装版本列表出错", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00026F3C File Offset: 0x0002513C
		private void Fabric_Selected(MyListItem sender, EventArgs e)
		{
			this.m_MockVal = NewLateBinding.LateIndexGet(sender.Tag, new object[]
			{
				"version"
			}, null).ToString();
			this.FabricApi_Loaded();
			this.CardFabric.IsSwaped = true;
			this.SelectReload();
			if (Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("HintInstallFabricApi", null))))
			{
				ModBase._BaseRule.Set("HintInstallFabricApi", true, false, null);
				ModMain.Hint("安装 Fabric 时通常还需要安装 Fabric API，在选择 Fabric 后就会显示其安装选项！", ModMain.HintType.Info, true);
			}
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00004583 File Offset: 0x00002783
		private void Fabric_Clear(object sender, MouseButtonEventArgs e)
		{
			this.m_MockVal = null;
			this.specificationVal = null;
			this.CardFabric.IsSwaped = true;
			e.Handled = true;
			this.SelectReload();
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00026FC8 File Offset: 0x000251C8
		private bool IsSuitableFabricApi(string DisplayName, string MinecraftVersion)
		{
			checked
			{
				bool result;
				try
				{
					if (DisplayName != null && MinecraftVersion != null)
					{
						DisplayName = DisplayName.ToLower();
						MinecraftVersion = MinecraftVersion.ToLower();
						if (DisplayName.StartsWith("[" + MinecraftVersion + "]"))
						{
							result = true;
						}
						else if (!DisplayName.Contains("/"))
						{
							result = false;
						}
						else
						{
							List<string> list = ModBase.RegexSearch(DisplayName.Split(new char[]
							{
								']'
							})[0], "[a-z/]+|[0-9/]+", RegexOptions.None);
							List<string> list2 = ModBase.RegexSearch(MinecraftVersion.Split(new char[]
							{
								']'
							})[0], "[a-z/]+|[0-9/]+", RegexOptions.None);
							int num = 0;
							while (list.Count - 1 >= num || list2.Count - 1 >= num)
							{
								string text = (list.Count - 1 < num) ? "-1" : list[num];
								string text2 = (list2.Count - 1 < num) ? "-1" : list2[num];
								if (!text.Contains("/"))
								{
									if (Operators.CompareString(text, text2, true) != 0)
									{
										return false;
									}
								}
								else if (!text.Contains(text2))
								{
									return false;
								}
								num++;
							}
							result = true;
						}
					}
					else
					{
						result = false;
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, string.Concat(new string[]
					{
						"判断 Fabric API 版本适配性出错（",
						DisplayName,
						", ",
						MinecraftVersion,
						"）"
					}), ModBase.LogLevel.Debug, "出现错误");
					result = false;
				}
				return result;
			}
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0002715C File Offset: 0x0002535C
		private string LoadFabricApiGetError()
		{
			string result;
			if (this.LoadFabricApi.State.LoadingState == MyLoading.MyLoadingState.Run)
			{
				result = "正在获取版本列表……";
			}
			else if (this.LoadFabricApi.State.LoadingState == MyLoading.MyLoadingState.Error)
			{
				result = Conversions.ToString(Operators.ConcatenateObject("获取版本列表失败：", NewLateBinding.LateGet(NewLateBinding.LateGet(this.LoadFabricApi.State, null, "Error", new object[0], null, null, null), null, "Message", new object[0], null, null, null)));
			}
			else if (this.m_MockVal == null)
			{
				result = "需要安装 Fabric";
			}
			else
			{
				try
				{
					foreach (ModDownload.DlCfFile dlCfFile in ModDownload._VisitorIterator.Output)
					{
						if (this.IsSuitableFabricApi(dlCfFile.m_InterceptorAlgo, this._AdapterVal))
						{
							return null;
						}
					}
				}
				finally
				{
					List<ModDownload.DlCfFile>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				result = "没有可用版本";
			}
			return result;
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x000045AC File Offset: 0x000027AC
		private void CardFabricApi_PreviewSwap(object sender, ModBase.RouteEventArgs e)
		{
			if (this.LoadFabricApiGetError() != null)
			{
				e._HelperMapper = true;
			}
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00027254 File Offset: 0x00025454
		private void FabricApi_Loaded()
		{
			try
			{
				if (ModDownload._VisitorIterator.State == ModBase.LoadState.Finished)
				{
					if (this._AdapterVal != null && this.m_MockVal != null)
					{
						List<ModDownload.DlCfFile> list = new List<ModDownload.DlCfFile>();
						try
						{
							foreach (ModDownload.DlCfFile dlCfFile in ModDownload._VisitorIterator.Output)
							{
								if (this.IsSuitableFabricApi(dlCfFile.m_InterceptorAlgo, this._AdapterVal))
								{
									if (!dlCfFile.m_InterceptorAlgo.StartsWith("["))
									{
										ModBase.Log("[Download] 已特判修改 Fabric API 显示名：" + dlCfFile.m_InterceptorAlgo, ModBase.LogLevel.Debug, "出现错误");
										dlCfFile.m_InterceptorAlgo = "[" + this._AdapterVal + "] " + dlCfFile.m_InterceptorAlgo;
									}
									list.Add(dlCfFile);
								}
							}
						}
						finally
						{
							List<ModDownload.DlCfFile>.Enumerator enumerator;
							((IDisposable)enumerator).Dispose();
						}
						if (list.Count != 0)
						{
							list = ModBase.Sort<ModDownload.DlCfFile>(list, (PageDownloadInstall._Closure$__.$IR59-10 == null) ? (PageDownloadInstall._Closure$__.$IR59-10 = ((object a0, object a1) => ((PageDownloadInstall._Closure$__.$I59-0 == null) ? (PageDownloadInstall._Closure$__.$I59-0 = ((ModDownload.DlCfFile Left, ModDownload.DlCfFile Right) => DateTime.Compare(Left.invocationAlgo, Right.invocationAlgo) > 0)) : PageDownloadInstall._Closure$__.$I59-0)((ModDownload.DlCfFile)a0, (ModDownload.DlCfFile)a1))) : PageDownloadInstall._Closure$__.$IR59-10);
							this.PanFabricApi.Children.Clear();
							try
							{
								foreach (ModDownload.DlCfFile dlCfFile2 in list)
								{
									if (this.IsSuitableFabricApi(dlCfFile2.m_InterceptorAlgo, this._AdapterVal))
									{
										this.PanFabricApi.Children.Add(ModDownloadLib.FabricApiDownloadListItem(dlCfFile2, delegate(object sender, MouseButtonEventArgs e)
										{
											this.FabricApi_Selected((MyListItem)sender, e);
										}));
									}
								}
							}
							finally
							{
								List<ModDownload.DlCfFile>.Enumerator enumerator2;
								((IDisposable)enumerator2).Dispose();
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "可视化 Fabric API 安装版本列表出错", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x000045BD File Offset: 0x000027BD
		private void FabricApi_Selected(MyListItem sender, EventArgs e)
		{
			this.specificationVal = (ModDownload.DlCfFile)sender.Tag;
			this.CardFabricApi.IsSwaped = true;
			this.SelectReload();
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x000045E2 File Offset: 0x000027E2
		private void FabricApi_Clear(object sender, MouseButtonEventArgs e)
		{
			this.specificationVal = null;
			this.CardFabricApi.IsSwaped = true;
			e.Handled = true;
			this.SelectReload();
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00027448 File Offset: 0x00025648
		private void BtnSelectStart_Click(object sender, EventArgs e)
		{
			if (((this._ParamVal == null && this.m_MockVal == null) || (!Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LaunchArgumentIndie", null), 0, true) && !Operators.ConditionalCompareObjectEqual(ModBase._BaseRule.Get("LaunchArgumentIndie", null), 2, true)) || ModMain.MyMsgBox("你尚未开启版本隔离，这会导致多个 MC 共用同一个 Mod 文件夹。\r\n因此在切换 MC 版本时，MC 会因为读取到与当前版本不符的 Mod 而崩溃。\r\nPCL2 推荐你在开始下载前，在 设置 → 版本隔离 中开启版本隔离选项！", "版本隔离提示", "取消下载", "继续", "", false, true, false) != 1) && ModDownloadLib.McInstall(new ModDownloadLib.McInstallRequest
			{
				m_CandidateRule = this.TextSelectName.Text,
				contextRule = this.annotationVal,
				m_DescriptorRule = this._AdapterVal,
				_TokenizerRule = this.regVal,
				tagRule = this._ParamVal,
				_InitializerRule = this.m_MockVal,
				_PropertyRule = this.specificationVal,
				m_WatcherRule = this.definitionVal
			}))
			{
				this.ExitSelectPage();
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060003E7 RID: 999 RVA: 0x00004604 File Offset: 0x00002804
		// (set) Token: 0x060003E8 RID: 1000 RVA: 0x0000460C File Offset: 0x0000280C
		internal virtual MyScrollViewer PanBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060003E9 RID: 1001 RVA: 0x00004615 File Offset: 0x00002815
		// (set) Token: 0x060003EA RID: 1002 RVA: 0x0000461D File Offset: 0x0000281D
		internal virtual VirtualizingStackPanel PanMinecraft { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060003EB RID: 1003 RVA: 0x00004626 File Offset: 0x00002826
		// (set) Token: 0x060003EC RID: 1004 RVA: 0x0000462E File Offset: 0x0000282E
		internal virtual StackPanel PanSelect { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060003ED RID: 1005 RVA: 0x00004637 File Offset: 0x00002837
		// (set) Token: 0x060003EE RID: 1006 RVA: 0x0000463F File Offset: 0x0000283F
		internal virtual MyHint HintFabricAPI { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x00004648 File Offset: 0x00002848
		// (set) Token: 0x060003F0 RID: 1008 RVA: 0x00004650 File Offset: 0x00002850
		internal virtual MyListItem ItemSelect { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x00004659 File Offset: 0x00002859
		// (set) Token: 0x060003F2 RID: 1010 RVA: 0x0002753C File Offset: 0x0002573C
		internal virtual MyButton BtnSelectStart
		{
			[CompilerGenerated]
			get
			{
				return this._RulesVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyButton.ClickEventHandler obj = new MyButton.ClickEventHandler(this.BtnSelectStart_Click);
				MyButton rulesVal = this._RulesVal;
				if (rulesVal != null)
				{
					rulesVal.CancelModel(obj);
				}
				this._RulesVal = value;
				rulesVal = this._RulesVal;
				if (rulesVal != null)
				{
					rulesVal.ValidateModel(obj);
				}
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x00004661 File Offset: 0x00002861
		// (set) Token: 0x060003F4 RID: 1012 RVA: 0x00027580 File Offset: 0x00025780
		internal virtual MyTextBox TextSelectName
		{
			[CompilerGenerated]
			get
			{
				return this.classVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				TextChangedEventHandler value2 = new TextChangedEventHandler(this.TextSelectName_TextChanged);
				MyTextBox.ValidateChangedEventHandler obj = new MyTextBox.ValidateChangedEventHandler(this.TextSelectName_ValidateChanged);
				MyTextBox myTextBox = this.classVal;
				if (myTextBox != null)
				{
					myTextBox.TextChanged -= value2;
					MyTextBox.EnableVal(obj);
				}
				this.classVal = value;
				myTextBox = this.classVal;
				if (myTextBox != null)
				{
					myTextBox.TextChanged += value2;
					MyTextBox.ManageVal(obj);
				}
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x00004669 File Offset: 0x00002869
		// (set) Token: 0x060003F6 RID: 1014 RVA: 0x000275DC File Offset: 0x000257DC
		internal virtual MyCard CardMinecraft
		{
			[CompilerGenerated]
			get
			{
				return this.m_ServerVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyCard.PreviewSwapEventHandler obj = new MyCard.PreviewSwapEventHandler(this.CardMinecraft_PreviewSwap);
				MyCard serverVal = this.m_ServerVal;
				if (serverVal != null)
				{
					serverVal.RemoveFactory(obj);
				}
				this.m_ServerVal = value;
				serverVal = this.m_ServerVal;
				if (serverVal != null)
				{
					serverVal.DeleteFactory(obj);
				}
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x00004671 File Offset: 0x00002871
		// (set) Token: 0x060003F8 RID: 1016 RVA: 0x00004679 File Offset: 0x00002879
		internal virtual Grid PanMinecraftInfo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060003F9 RID: 1017 RVA: 0x00004682 File Offset: 0x00002882
		// (set) Token: 0x060003FA RID: 1018 RVA: 0x0000468A File Offset: 0x0000288A
		internal virtual Image ImgMinecraft { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x00004693 File Offset: 0x00002893
		// (set) Token: 0x060003FC RID: 1020 RVA: 0x0000469B File Offset: 0x0000289B
		internal virtual TextBlock LabMinecraft { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x000046A4 File Offset: 0x000028A4
		// (set) Token: 0x060003FE RID: 1022 RVA: 0x00027620 File Offset: 0x00025820
		internal virtual MyCard CardOptiFine
		{
			[CompilerGenerated]
			get
			{
				return this.identifierVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyCard.SwapEventHandler obj = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.SelectReload();
				};
				MyCard.PreviewSwapEventHandler obj2 = new MyCard.PreviewSwapEventHandler(this.CardOptiFine_PreviewSwap);
				MyCard myCard = this.identifierVal;
				if (myCard != null)
				{
					myCard.PushFactory(obj);
					myCard.RemoveFactory(obj2);
				}
				this.identifierVal = value;
				myCard = this.identifierVal;
				if (myCard != null)
				{
					myCard.QueryFactory(obj);
					myCard.DeleteFactory(obj2);
				}
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x000046AC File Offset: 0x000028AC
		// (set) Token: 0x06000400 RID: 1024 RVA: 0x000046B4 File Offset: 0x000028B4
		internal virtual MyHint HintOptiFine { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000401 RID: 1025 RVA: 0x000046BD File Offset: 0x000028BD
		// (set) Token: 0x06000402 RID: 1026 RVA: 0x000046C5 File Offset: 0x000028C5
		internal virtual StackPanel PanOptiFine { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000403 RID: 1027 RVA: 0x000046CE File Offset: 0x000028CE
		// (set) Token: 0x06000404 RID: 1028 RVA: 0x000046D6 File Offset: 0x000028D6
		internal virtual Grid PanOptiFineInfo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000405 RID: 1029 RVA: 0x000046DF File Offset: 0x000028DF
		// (set) Token: 0x06000406 RID: 1030 RVA: 0x000046E7 File Offset: 0x000028E7
		internal virtual Image ImgOptiFine { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000407 RID: 1031 RVA: 0x000046F0 File Offset: 0x000028F0
		// (set) Token: 0x06000408 RID: 1032 RVA: 0x000046F8 File Offset: 0x000028F8
		internal virtual TextBlock LabOptiFine { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000409 RID: 1033 RVA: 0x00004701 File Offset: 0x00002901
		// (set) Token: 0x0600040A RID: 1034 RVA: 0x00027680 File Offset: 0x00025880
		internal virtual Grid BtnOptiFineClear
		{
			[CompilerGenerated]
			get
			{
				return this.m_TokenVal;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseButtonEventHandler value2 = new MouseButtonEventHandler(this.OptiFine_Clear);
				Grid tokenVal = this.m_TokenVal;
				if (tokenVal != null)
				{
					tokenVal.MouseLeftButtonUp -= value2;
				}
				this.m_TokenVal = value;
				tokenVal = this.m_TokenVal;
				if (tokenVal != null)
				{
					tokenVal.MouseLeftButtonUp += value2;
				}
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600040B RID: 1035 RVA: 0x00004709 File Offset: 0x00002909
		// (set) Token: 0x0600040C RID: 1036 RVA: 0x00004711 File Offset: 0x00002911
		internal virtual Path BtnOptiFineClearInner { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600040D RID: 1037 RVA: 0x0000471A File Offset: 0x0000291A
		// (set) Token: 0x0600040E RID: 1038 RVA: 0x000276C4 File Offset: 0x000258C4
		internal virtual MyCard CardForge
		{
			[CompilerGenerated]
			get
			{
				return this.factoryContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyCard.SwapEventHandler obj = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.SelectReload();
				};
				MyCard.PreviewSwapEventHandler obj2 = new MyCard.PreviewSwapEventHandler(this.CardForge_PreviewSwap);
				MyCard myCard = this.factoryContainer;
				if (myCard != null)
				{
					myCard.PushFactory(obj);
					myCard.RemoveFactory(obj2);
				}
				this.factoryContainer = value;
				myCard = this.factoryContainer;
				if (myCard != null)
				{
					myCard.QueryFactory(obj);
					myCard.DeleteFactory(obj2);
				}
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600040F RID: 1039 RVA: 0x00004722 File Offset: 0x00002922
		// (set) Token: 0x06000410 RID: 1040 RVA: 0x0000472A File Offset: 0x0000292A
		internal virtual StackPanel PanForge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x00004733 File Offset: 0x00002933
		// (set) Token: 0x06000412 RID: 1042 RVA: 0x0000473B File Offset: 0x0000293B
		internal virtual Grid PanForgeInfo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000413 RID: 1043 RVA: 0x00004744 File Offset: 0x00002944
		// (set) Token: 0x06000414 RID: 1044 RVA: 0x0000474C File Offset: 0x0000294C
		internal virtual Image ImgForge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000415 RID: 1045 RVA: 0x00004755 File Offset: 0x00002955
		// (set) Token: 0x06000416 RID: 1046 RVA: 0x0000475D File Offset: 0x0000295D
		internal virtual TextBlock LabForge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x00004766 File Offset: 0x00002966
		// (set) Token: 0x06000418 RID: 1048 RVA: 0x00027724 File Offset: 0x00025924
		internal virtual Grid BtnForgeClear
		{
			[CompilerGenerated]
			get
			{
				return this.expressionContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseButtonEventHandler value2 = new MouseButtonEventHandler(this.Forge_Clear);
				Grid grid = this.expressionContainer;
				if (grid != null)
				{
					grid.MouseLeftButtonUp -= value2;
				}
				this.expressionContainer = value;
				grid = this.expressionContainer;
				if (grid != null)
				{
					grid.MouseLeftButtonUp += value2;
				}
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x0000476E File Offset: 0x0000296E
		// (set) Token: 0x0600041A RID: 1050 RVA: 0x00004776 File Offset: 0x00002976
		internal virtual Path BtnForgeClearInner { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600041B RID: 1051 RVA: 0x0000477F File Offset: 0x0000297F
		// (set) Token: 0x0600041C RID: 1052 RVA: 0x00027768 File Offset: 0x00025968
		internal virtual MyCard CardFabric
		{
			[CompilerGenerated]
			get
			{
				return this.m_BaseContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyCard.SwapEventHandler obj = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.SelectReload();
				};
				MyCard.PreviewSwapEventHandler obj2 = new MyCard.PreviewSwapEventHandler(this.CardFabric_PreviewSwap);
				MyCard baseContainer = this.m_BaseContainer;
				if (baseContainer != null)
				{
					baseContainer.PushFactory(obj);
					baseContainer.RemoveFactory(obj2);
				}
				this.m_BaseContainer = value;
				baseContainer = this.m_BaseContainer;
				if (baseContainer != null)
				{
					baseContainer.QueryFactory(obj);
					baseContainer.DeleteFactory(obj2);
				}
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600041D RID: 1053 RVA: 0x00004787 File Offset: 0x00002987
		// (set) Token: 0x0600041E RID: 1054 RVA: 0x0000478F File Offset: 0x0000298F
		internal virtual MyHint HintFabric { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x00004798 File Offset: 0x00002998
		// (set) Token: 0x06000420 RID: 1056 RVA: 0x000047A0 File Offset: 0x000029A0
		internal virtual StackPanel PanFabric { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x000047A9 File Offset: 0x000029A9
		// (set) Token: 0x06000422 RID: 1058 RVA: 0x000047B1 File Offset: 0x000029B1
		internal virtual Grid PanFabricInfo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x000047BA File Offset: 0x000029BA
		// (set) Token: 0x06000424 RID: 1060 RVA: 0x000047C2 File Offset: 0x000029C2
		internal virtual Image ImgFabric { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x000047CB File Offset: 0x000029CB
		// (set) Token: 0x06000426 RID: 1062 RVA: 0x000047D3 File Offset: 0x000029D3
		internal virtual TextBlock LabFabric { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x000047DC File Offset: 0x000029DC
		// (set) Token: 0x06000428 RID: 1064 RVA: 0x000277C8 File Offset: 0x000259C8
		internal virtual Grid BtnFabricClear
		{
			[CompilerGenerated]
			get
			{
				return this.paramsContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseButtonEventHandler value2 = new MouseButtonEventHandler(this.Fabric_Clear);
				Grid grid = this.paramsContainer;
				if (grid != null)
				{
					grid.MouseLeftButtonUp -= value2;
				}
				this.paramsContainer = value;
				grid = this.paramsContainer;
				if (grid != null)
				{
					grid.MouseLeftButtonUp += value2;
				}
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x000047E4 File Offset: 0x000029E4
		// (set) Token: 0x0600042A RID: 1066 RVA: 0x000047EC File Offset: 0x000029EC
		internal virtual Path BtnFabricClearInner { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x000047F5 File Offset: 0x000029F5
		// (set) Token: 0x0600042C RID: 1068 RVA: 0x0002780C File Offset: 0x00025A0C
		internal virtual MyCard CardFabricApi
		{
			[CompilerGenerated]
			get
			{
				return this._IssuerContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyCard.SwapEventHandler obj = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.SelectReload();
				};
				MyCard.PreviewSwapEventHandler obj2 = new MyCard.PreviewSwapEventHandler(this.CardFabricApi_PreviewSwap);
				MyCard issuerContainer = this._IssuerContainer;
				if (issuerContainer != null)
				{
					issuerContainer.PushFactory(obj);
					issuerContainer.RemoveFactory(obj2);
				}
				this._IssuerContainer = value;
				issuerContainer = this._IssuerContainer;
				if (issuerContainer != null)
				{
					issuerContainer.QueryFactory(obj);
					issuerContainer.DeleteFactory(obj2);
				}
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x000047FD File Offset: 0x000029FD
		// (set) Token: 0x0600042E RID: 1070 RVA: 0x00004805 File Offset: 0x00002A05
		internal virtual StackPanel PanFabricApi { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x0000480E File Offset: 0x00002A0E
		// (set) Token: 0x06000430 RID: 1072 RVA: 0x00004816 File Offset: 0x00002A16
		internal virtual Grid PanFabricApiInfo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x0000481F File Offset: 0x00002A1F
		// (set) Token: 0x06000432 RID: 1074 RVA: 0x00004827 File Offset: 0x00002A27
		internal virtual Image ImgFabricApi { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x00004830 File Offset: 0x00002A30
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x00004838 File Offset: 0x00002A38
		internal virtual TextBlock LabFabricApi { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x00004841 File Offset: 0x00002A41
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x0002786C File Offset: 0x00025A6C
		internal virtual Grid BtnFabricApiClear
		{
			[CompilerGenerated]
			get
			{
				return this.m_MappingContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseButtonEventHandler value2 = new MouseButtonEventHandler(this.FabricApi_Clear);
				Grid mappingContainer = this.m_MappingContainer;
				if (mappingContainer != null)
				{
					mappingContainer.MouseLeftButtonUp -= value2;
				}
				this.m_MappingContainer = value;
				mappingContainer = this.m_MappingContainer;
				if (mappingContainer != null)
				{
					mappingContainer.MouseLeftButtonUp += value2;
				}
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x00004849 File Offset: 0x00002A49
		// (set) Token: 0x06000438 RID: 1080 RVA: 0x00004851 File Offset: 0x00002A51
		internal virtual Path BtnFabricApiClearInner { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x0000485A File Offset: 0x00002A5A
		// (set) Token: 0x0600043A RID: 1082 RVA: 0x000278B0 File Offset: 0x00025AB0
		internal virtual MyCard CardLiteLoader
		{
			[CompilerGenerated]
			get
			{
				return this._SingletonContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyCard.SwapEventHandler obj = delegate(object sender, ModBase.RouteEventArgs e)
				{
					this.SelectReload();
				};
				MyCard.PreviewSwapEventHandler obj2 = new MyCard.PreviewSwapEventHandler(this.CardLiteLoader_PreviewSwap);
				MyCard singletonContainer = this._SingletonContainer;
				if (singletonContainer != null)
				{
					singletonContainer.PushFactory(obj);
					singletonContainer.RemoveFactory(obj2);
				}
				this._SingletonContainer = value;
				singletonContainer = this._SingletonContainer;
				if (singletonContainer != null)
				{
					singletonContainer.QueryFactory(obj);
					singletonContainer.DeleteFactory(obj2);
				}
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x00004862 File Offset: 0x00002A62
		// (set) Token: 0x0600043C RID: 1084 RVA: 0x0000486A File Offset: 0x00002A6A
		internal virtual StackPanel PanLiteLoader { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x00004873 File Offset: 0x00002A73
		// (set) Token: 0x0600043E RID: 1086 RVA: 0x0000487B File Offset: 0x00002A7B
		internal virtual Grid PanLiteLoaderInfo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x00004884 File Offset: 0x00002A84
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x0000488C File Offset: 0x00002A8C
		internal virtual Image ImgLiteLoader { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x00004895 File Offset: 0x00002A95
		// (set) Token: 0x06000442 RID: 1090 RVA: 0x0000489D File Offset: 0x00002A9D
		internal virtual TextBlock LabLiteLoader { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x000048A6 File Offset: 0x00002AA6
		// (set) Token: 0x06000444 RID: 1092 RVA: 0x00027910 File Offset: 0x00025B10
		internal virtual Grid BtnLiteLoaderClear
		{
			[CompilerGenerated]
			get
			{
				return this.visitorContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseButtonEventHandler value2 = new MouseButtonEventHandler(this.LiteLoader_Clear);
				Grid grid = this.visitorContainer;
				if (grid != null)
				{
					grid.MouseLeftButtonUp -= value2;
				}
				this.visitorContainer = value;
				grid = this.visitorContainer;
				if (grid != null)
				{
					grid.MouseLeftButtonUp += value2;
				}
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x000048AE File Offset: 0x00002AAE
		// (set) Token: 0x06000446 RID: 1094 RVA: 0x000048B6 File Offset: 0x00002AB6
		internal virtual Path BtnLiteLoaderClearInner { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x000048BF File Offset: 0x00002ABF
		// (set) Token: 0x06000448 RID: 1096 RVA: 0x000048C7 File Offset: 0x00002AC7
		internal virtual MyCard PanLoad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x000048D0 File Offset: 0x00002AD0
		// (set) Token: 0x0600044A RID: 1098 RVA: 0x00027954 File Offset: 0x00025B54
		internal virtual MyLoading LoadMinecraft
		{
			[CompilerGenerated]
			get
			{
				return this._DatabaseContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyLoading.ClickEventHandler obj = new MyLoading.ClickEventHandler(this.LoadMinecraft_Click);
				MyLoading.StateChangedEventHandler obj2 = new MyLoading.StateChangedEventHandler(this.LoadMinecraft_State);
				MyLoading databaseContainer = this._DatabaseContainer;
				if (databaseContainer != null)
				{
					databaseContainer.UpdateVal(obj);
					databaseContainer.InitVal(obj2);
				}
				this._DatabaseContainer = value;
				databaseContainer = this._DatabaseContainer;
				if (databaseContainer != null)
				{
					databaseContainer.PrepareVal(obj);
					databaseContainer.FillVal(obj2);
				}
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x000048D8 File Offset: 0x00002AD8
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x000279B4 File Offset: 0x00025BB4
		internal virtual MyLoading LoadOptiFine
		{
			[CompilerGenerated]
			get
			{
				return this.attrContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyLoading.StateChangedEventHandler obj = delegate(object a0, MyLoading.MyLoadingState a1)
				{
					this.SelectReload();
				};
				MyLoading.StateChangedEventHandler obj2 = delegate(object a0, MyLoading.MyLoadingState a1)
				{
					this.OptiFine_Loaded();
				};
				MyLoading myLoading = this.attrContainer;
				if (myLoading != null)
				{
					myLoading.InitVal(obj);
					myLoading.InitVal(obj2);
				}
				this.attrContainer = value;
				myLoading = this.attrContainer;
				if (myLoading != null)
				{
					myLoading.FillVal(obj);
					myLoading.FillVal(obj2);
				}
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x000048E0 File Offset: 0x00002AE0
		// (set) Token: 0x0600044E RID: 1102 RVA: 0x00027A14 File Offset: 0x00025C14
		internal virtual MyLoading LoadForge
		{
			[CompilerGenerated]
			get
			{
				return this.m_ThreadContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyLoading.StateChangedEventHandler obj = delegate(object a0, MyLoading.MyLoadingState a1)
				{
					this.SelectReload();
				};
				MyLoading.StateChangedEventHandler obj2 = delegate(object a0, MyLoading.MyLoadingState a1)
				{
					this.Forge_Loaded();
				};
				MyLoading threadContainer = this.m_ThreadContainer;
				if (threadContainer != null)
				{
					threadContainer.InitVal(obj);
					threadContainer.InitVal(obj2);
				}
				this.m_ThreadContainer = value;
				threadContainer = this.m_ThreadContainer;
				if (threadContainer != null)
				{
					threadContainer.FillVal(obj);
					threadContainer.FillVal(obj2);
				}
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600044F RID: 1103 RVA: 0x000048E8 File Offset: 0x00002AE8
		// (set) Token: 0x06000450 RID: 1104 RVA: 0x00027A74 File Offset: 0x00025C74
		internal virtual MyLoading LoadLiteLoader
		{
			[CompilerGenerated]
			get
			{
				return this.m_ManagerContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyLoading.StateChangedEventHandler obj = delegate(object a0, MyLoading.MyLoadingState a1)
				{
					this.SelectReload();
				};
				MyLoading.StateChangedEventHandler obj2 = delegate(object a0, MyLoading.MyLoadingState a1)
				{
					this.LiteLoader_Loaded();
				};
				MyLoading managerContainer = this.m_ManagerContainer;
				if (managerContainer != null)
				{
					managerContainer.InitVal(obj);
					managerContainer.InitVal(obj2);
				}
				this.m_ManagerContainer = value;
				managerContainer = this.m_ManagerContainer;
				if (managerContainer != null)
				{
					managerContainer.FillVal(obj);
					managerContainer.FillVal(obj2);
				}
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x000048F0 File Offset: 0x00002AF0
		// (set) Token: 0x06000452 RID: 1106 RVA: 0x00027AD4 File Offset: 0x00025CD4
		internal virtual MyLoading LoadFabric
		{
			[CompilerGenerated]
			get
			{
				return this.m_ItemContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyLoading.StateChangedEventHandler obj = delegate(object a0, MyLoading.MyLoadingState a1)
				{
					this.SelectReload();
				};
				MyLoading.StateChangedEventHandler obj2 = delegate(object a0, MyLoading.MyLoadingState a1)
				{
					this.Fabric_Loaded();
				};
				MyLoading itemContainer = this.m_ItemContainer;
				if (itemContainer != null)
				{
					itemContainer.InitVal(obj);
					itemContainer.InitVal(obj2);
				}
				this.m_ItemContainer = value;
				itemContainer = this.m_ItemContainer;
				if (itemContainer != null)
				{
					itemContainer.FillVal(obj);
					itemContainer.FillVal(obj2);
				}
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x000048F8 File Offset: 0x00002AF8
		// (set) Token: 0x06000454 RID: 1108 RVA: 0x00027B34 File Offset: 0x00025D34
		internal virtual MyLoading LoadFabricApi
		{
			[CompilerGenerated]
			get
			{
				return this.m_SerializerContainer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MyLoading.StateChangedEventHandler obj = delegate(object a0, MyLoading.MyLoadingState a1)
				{
					this.SelectReload();
				};
				MyLoading.StateChangedEventHandler obj2 = delegate(object a0, MyLoading.MyLoadingState a1)
				{
					this.FabricApi_Loaded();
				};
				MyLoading serializerContainer = this.m_SerializerContainer;
				if (serializerContainer != null)
				{
					serializerContainer.InitVal(obj);
					serializerContainer.InitVal(obj2);
				}
				this.m_SerializerContainer = value;
				serializerContainer = this.m_SerializerContainer;
				if (serializerContainer != null)
				{
					serializerContainer.FillVal(obj);
					serializerContainer.FillVal(obj2);
				}
			}
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00027B94 File Offset: 0x00025D94
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this._InfoContainer)
			{
				this._InfoContainer = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagedownload/pagedownloadinstall.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x00027BC4 File Offset: 0x00025DC4
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
				this.PanMinecraft = (VirtualizingStackPanel)target;
				return;
			}
			if (connectionId == 3)
			{
				this.PanSelect = (StackPanel)target;
				return;
			}
			if (connectionId == 4)
			{
				this.HintFabricAPI = (MyHint)target;
				return;
			}
			if (connectionId == 5)
			{
				this.ItemSelect = (MyListItem)target;
				return;
			}
			if (connectionId == 6)
			{
				this.BtnSelectStart = (MyButton)target;
				return;
			}
			if (connectionId == 7)
			{
				this.TextSelectName = (MyTextBox)target;
				return;
			}
			if (connectionId == 8)
			{
				this.CardMinecraft = (MyCard)target;
				return;
			}
			if (connectionId == 9)
			{
				this.PanMinecraftInfo = (Grid)target;
				return;
			}
			if (connectionId == 0xA)
			{
				this.ImgMinecraft = (Image)target;
				return;
			}
			if (connectionId == 0xB)
			{
				this.LabMinecraft = (TextBlock)target;
				return;
			}
			if (connectionId == 0xC)
			{
				this.CardOptiFine = (MyCard)target;
				return;
			}
			if (connectionId == 0xD)
			{
				this.HintOptiFine = (MyHint)target;
				return;
			}
			if (connectionId == 0xE)
			{
				this.PanOptiFine = (StackPanel)target;
				return;
			}
			if (connectionId == 0xF)
			{
				this.PanOptiFineInfo = (Grid)target;
				return;
			}
			if (connectionId == 0x10)
			{
				this.ImgOptiFine = (Image)target;
				return;
			}
			if (connectionId == 0x11)
			{
				this.LabOptiFine = (TextBlock)target;
				return;
			}
			if (connectionId == 0x12)
			{
				this.BtnOptiFineClear = (Grid)target;
				return;
			}
			if (connectionId == 0x13)
			{
				this.BtnOptiFineClearInner = (Path)target;
				return;
			}
			if (connectionId == 0x14)
			{
				this.CardForge = (MyCard)target;
				return;
			}
			if (connectionId == 0x15)
			{
				this.PanForge = (StackPanel)target;
				return;
			}
			if (connectionId == 0x16)
			{
				this.PanForgeInfo = (Grid)target;
				return;
			}
			if (connectionId == 0x17)
			{
				this.ImgForge = (Image)target;
				return;
			}
			if (connectionId == 0x18)
			{
				this.LabForge = (TextBlock)target;
				return;
			}
			if (connectionId == 0x19)
			{
				this.BtnForgeClear = (Grid)target;
				return;
			}
			if (connectionId == 0x1A)
			{
				this.BtnForgeClearInner = (Path)target;
				return;
			}
			if (connectionId == 0x1B)
			{
				this.CardFabric = (MyCard)target;
				return;
			}
			if (connectionId == 0x1C)
			{
				this.HintFabric = (MyHint)target;
				return;
			}
			if (connectionId == 0x1D)
			{
				this.PanFabric = (StackPanel)target;
				return;
			}
			if (connectionId == 0x1E)
			{
				this.PanFabricInfo = (Grid)target;
				return;
			}
			if (connectionId == 0x1F)
			{
				this.ImgFabric = (Image)target;
				return;
			}
			if (connectionId == 0x20)
			{
				this.LabFabric = (TextBlock)target;
				return;
			}
			if (connectionId == 0x21)
			{
				this.BtnFabricClear = (Grid)target;
				return;
			}
			if (connectionId == 0x22)
			{
				this.BtnFabricClearInner = (Path)target;
				return;
			}
			if (connectionId == 0x23)
			{
				this.CardFabricApi = (MyCard)target;
				return;
			}
			if (connectionId == 0x24)
			{
				this.PanFabricApi = (StackPanel)target;
				return;
			}
			if (connectionId == 0x25)
			{
				this.PanFabricApiInfo = (Grid)target;
				return;
			}
			if (connectionId == 0x26)
			{
				this.ImgFabricApi = (Image)target;
				return;
			}
			if (connectionId == 0x27)
			{
				this.LabFabricApi = (TextBlock)target;
				return;
			}
			if (connectionId == 0x28)
			{
				this.BtnFabricApiClear = (Grid)target;
				return;
			}
			if (connectionId == 0x29)
			{
				this.BtnFabricApiClearInner = (Path)target;
				return;
			}
			if (connectionId == 0x2A)
			{
				this.CardLiteLoader = (MyCard)target;
				return;
			}
			if (connectionId == 0x2B)
			{
				this.PanLiteLoader = (StackPanel)target;
				return;
			}
			if (connectionId == 0x2C)
			{
				this.PanLiteLoaderInfo = (Grid)target;
				return;
			}
			if (connectionId == 0x2D)
			{
				this.ImgLiteLoader = (Image)target;
				return;
			}
			if (connectionId == 0x2E)
			{
				this.LabLiteLoader = (TextBlock)target;
				return;
			}
			if (connectionId == 0x2F)
			{
				this.BtnLiteLoaderClear = (Grid)target;
				return;
			}
			if (connectionId == 0x30)
			{
				this.BtnLiteLoaderClearInner = (Path)target;
				return;
			}
			if (connectionId == 0x31)
			{
				this.PanLoad = (MyCard)target;
				return;
			}
			if (connectionId == 0x32)
			{
				this.LoadMinecraft = (MyLoading)target;
				return;
			}
			if (connectionId == 0x33)
			{
				this.LoadOptiFine = (MyLoading)target;
				return;
			}
			if (connectionId == 0x34)
			{
				this.LoadForge = (MyLoading)target;
				return;
			}
			if (connectionId == 0x35)
			{
				this.LoadLiteLoader = (MyLoading)target;
				return;
			}
			if (connectionId == 0x36)
			{
				this.LoadFabric = (MyLoading)target;
				return;
			}
			if (connectionId == 0x37)
			{
				this.LoadFabricApi = (MyLoading)target;
				return;
			}
			this._InfoContainer = true;
		}

		// Token: 0x040001F4 RID: 500
		private bool _ListenerVal;

		// Token: 0x040001F5 RID: 501
		private bool importerVal;

		// Token: 0x040001F6 RID: 502
		private bool _TemplateVal;

		// Token: 0x040001F7 RID: 503
		private string _AdapterVal;

		// Token: 0x040001F8 RID: 504
		private string annotationVal;

		// Token: 0x040001F9 RID: 505
		private string _ReaderVal;

		// Token: 0x040001FA RID: 506
		private ModDownload.DlOptiFineListEntry regVal;

		// Token: 0x040001FB RID: 507
		private ModDownload.DlLiteLoaderListEntry definitionVal;

		// Token: 0x040001FC RID: 508
		private ModDownload.DlForgeVersionEntry _ParamVal;

		// Token: 0x040001FD RID: 509
		private string m_MockVal;

		// Token: 0x040001FE RID: 510
		private ModDownload.DlCfFile specificationVal;

		// Token: 0x040001FF RID: 511
		private bool m_DicVal;

		// Token: 0x04000200 RID: 512
		private bool _SchemaVal;

		// Token: 0x04000201 RID: 513
		[CompilerGenerated]
		[AccessedThroughProperty("PanBack")]
		private MyScrollViewer _HelperVal;

		// Token: 0x04000202 RID: 514
		[AccessedThroughProperty("PanMinecraft")]
		[CompilerGenerated]
		private VirtualizingStackPanel _ConsumerVal;

		// Token: 0x04000203 RID: 515
		[CompilerGenerated]
		[AccessedThroughProperty("PanSelect")]
		private StackPanel queueVal;

		// Token: 0x04000204 RID: 516
		[AccessedThroughProperty("HintFabricAPI")]
		[CompilerGenerated]
		private MyHint _ProducerVal;

		// Token: 0x04000205 RID: 517
		[CompilerGenerated]
		[AccessedThroughProperty("ItemSelect")]
		private MyListItem m_ExceptionVal;

		// Token: 0x04000206 RID: 518
		[CompilerGenerated]
		[AccessedThroughProperty("BtnSelectStart")]
		private MyButton _RulesVal;

		// Token: 0x04000207 RID: 519
		[CompilerGenerated]
		[AccessedThroughProperty("TextSelectName")]
		private MyTextBox classVal;

		// Token: 0x04000208 RID: 520
		[AccessedThroughProperty("CardMinecraft")]
		[CompilerGenerated]
		private MyCard m_ServerVal;

		// Token: 0x04000209 RID: 521
		[AccessedThroughProperty("PanMinecraftInfo")]
		[CompilerGenerated]
		private Grid m_ConfigVal;

		// Token: 0x0400020A RID: 522
		[CompilerGenerated]
		[AccessedThroughProperty("ImgMinecraft")]
		private Image m_ConnectionVal;

		// Token: 0x0400020B RID: 523
		[CompilerGenerated]
		[AccessedThroughProperty("LabMinecraft")]
		private TextBlock reponseVal;

		// Token: 0x0400020C RID: 524
		[CompilerGenerated]
		[AccessedThroughProperty("CardOptiFine")]
		private MyCard identifierVal;

		// Token: 0x0400020D RID: 525
		[CompilerGenerated]
		[AccessedThroughProperty("HintOptiFine")]
		private MyHint policyVal;

		// Token: 0x0400020E RID: 526
		[CompilerGenerated]
		[AccessedThroughProperty("PanOptiFine")]
		private StackPanel clientVal;

		// Token: 0x0400020F RID: 527
		[CompilerGenerated]
		[AccessedThroughProperty("PanOptiFineInfo")]
		private Grid composerVal;

		// Token: 0x04000210 RID: 528
		[CompilerGenerated]
		[AccessedThroughProperty("ImgOptiFine")]
		private Image m_PublisherVal;

		// Token: 0x04000211 RID: 529
		[CompilerGenerated]
		[AccessedThroughProperty("LabOptiFine")]
		private TextBlock m_MessageVal;

		// Token: 0x04000212 RID: 530
		[AccessedThroughProperty("BtnOptiFineClear")]
		[CompilerGenerated]
		private Grid m_TokenVal;

		// Token: 0x04000213 RID: 531
		[CompilerGenerated]
		[AccessedThroughProperty("BtnOptiFineClearInner")]
		private Path procVal;

		// Token: 0x04000214 RID: 532
		[CompilerGenerated]
		[AccessedThroughProperty("CardForge")]
		private MyCard factoryContainer;

		// Token: 0x04000215 RID: 533
		[AccessedThroughProperty("PanForge")]
		[CompilerGenerated]
		private StackPanel valContainer;

		// Token: 0x04000216 RID: 534
		[AccessedThroughProperty("PanForgeInfo")]
		[CompilerGenerated]
		private Grid _ContainerContainer;

		// Token: 0x04000217 RID: 535
		[CompilerGenerated]
		[AccessedThroughProperty("ImgForge")]
		private Image modelContainer;

		// Token: 0x04000218 RID: 536
		[AccessedThroughProperty("LabForge")]
		[CompilerGenerated]
		private TextBlock m_IteratorContainer;

		// Token: 0x04000219 RID: 537
		[AccessedThroughProperty("BtnForgeClear")]
		[CompilerGenerated]
		private Grid expressionContainer;

		// Token: 0x0400021A RID: 538
		[CompilerGenerated]
		[AccessedThroughProperty("BtnForgeClearInner")]
		private Path _UtilsContainer;

		// Token: 0x0400021B RID: 539
		[CompilerGenerated]
		[AccessedThroughProperty("CardFabric")]
		private MyCard m_BaseContainer;

		// Token: 0x0400021C RID: 540
		[AccessedThroughProperty("HintFabric")]
		[CompilerGenerated]
		private MyHint m_DecoratorContainer;

		// Token: 0x0400021D RID: 541
		[CompilerGenerated]
		[AccessedThroughProperty("PanFabric")]
		private StackPanel _FilterContainer;

		// Token: 0x0400021E RID: 542
		[CompilerGenerated]
		[AccessedThroughProperty("PanFabricInfo")]
		private Grid ruleContainer;

		// Token: 0x0400021F RID: 543
		[CompilerGenerated]
		[AccessedThroughProperty("ImgFabric")]
		private Image algoContainer;

		// Token: 0x04000220 RID: 544
		[AccessedThroughProperty("LabFabric")]
		[CompilerGenerated]
		private TextBlock _MapperContainer;

		// Token: 0x04000221 RID: 545
		[CompilerGenerated]
		[AccessedThroughProperty("BtnFabricClear")]
		private Grid paramsContainer;

		// Token: 0x04000222 RID: 546
		[CompilerGenerated]
		[AccessedThroughProperty("BtnFabricClearInner")]
		private Path _GlobalContainer;

		// Token: 0x04000223 RID: 547
		[AccessedThroughProperty("CardFabricApi")]
		[CompilerGenerated]
		private MyCard _IssuerContainer;

		// Token: 0x04000224 RID: 548
		[CompilerGenerated]
		[AccessedThroughProperty("PanFabricApi")]
		private StackPanel orderContainer;

		// Token: 0x04000225 RID: 549
		[AccessedThroughProperty("PanFabricApiInfo")]
		[CompilerGenerated]
		private Grid serviceContainer;

		// Token: 0x04000226 RID: 550
		[CompilerGenerated]
		[AccessedThroughProperty("ImgFabricApi")]
		private Image m_FacadeContainer;

		// Token: 0x04000227 RID: 551
		[CompilerGenerated]
		[AccessedThroughProperty("LabFabricApi")]
		private TextBlock m_CodeContainer;

		// Token: 0x04000228 RID: 552
		[AccessedThroughProperty("BtnFabricApiClear")]
		[CompilerGenerated]
		private Grid m_MappingContainer;

		// Token: 0x04000229 RID: 553
		[AccessedThroughProperty("BtnFabricApiClearInner")]
		[CompilerGenerated]
		private Path bridgeContainer;

		// Token: 0x0400022A RID: 554
		[AccessedThroughProperty("CardLiteLoader")]
		[CompilerGenerated]
		private MyCard _SingletonContainer;

		// Token: 0x0400022B RID: 555
		[AccessedThroughProperty("PanLiteLoader")]
		[CompilerGenerated]
		private StackPanel m_ErrorContainer;

		// Token: 0x0400022C RID: 556
		[AccessedThroughProperty("PanLiteLoaderInfo")]
		[CompilerGenerated]
		private Grid m_ObjectContainer;

		// Token: 0x0400022D RID: 557
		[AccessedThroughProperty("ImgLiteLoader")]
		[CompilerGenerated]
		private Image _CallbackContainer;

		// Token: 0x0400022E RID: 558
		[AccessedThroughProperty("LabLiteLoader")]
		[CompilerGenerated]
		private TextBlock _WorkerContainer;

		// Token: 0x0400022F RID: 559
		[AccessedThroughProperty("BtnLiteLoaderClear")]
		[CompilerGenerated]
		private Grid visitorContainer;

		// Token: 0x04000230 RID: 560
		[AccessedThroughProperty("BtnLiteLoaderClearInner")]
		[CompilerGenerated]
		private Path _IndexerContainer;

		// Token: 0x04000231 RID: 561
		[AccessedThroughProperty("PanLoad")]
		[CompilerGenerated]
		private MyCard _MethodContainer;

		// Token: 0x04000232 RID: 562
		[AccessedThroughProperty("LoadMinecraft")]
		[CompilerGenerated]
		private MyLoading _DatabaseContainer;

		// Token: 0x04000233 RID: 563
		[AccessedThroughProperty("LoadOptiFine")]
		[CompilerGenerated]
		private MyLoading attrContainer;

		// Token: 0x04000234 RID: 564
		[CompilerGenerated]
		[AccessedThroughProperty("LoadForge")]
		private MyLoading m_ThreadContainer;

		// Token: 0x04000235 RID: 565
		[AccessedThroughProperty("LoadLiteLoader")]
		[CompilerGenerated]
		private MyLoading m_ManagerContainer;

		// Token: 0x04000236 RID: 566
		[CompilerGenerated]
		[AccessedThroughProperty("LoadFabric")]
		private MyLoading m_ItemContainer;

		// Token: 0x04000237 RID: 567
		[CompilerGenerated]
		[AccessedThroughProperty("LoadFabricApi")]
		private MyLoading m_SerializerContainer;

		// Token: 0x04000238 RID: 568
		private bool _InfoContainer;
	}
}
