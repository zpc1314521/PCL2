using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace PCL
{
	// Token: 0x02000122 RID: 290
	[DesignerGenerated]
	public class MySkin : Grid, IComponentConnector
	{
		// Token: 0x06000A37 RID: 2615 RVA: 0x00059154 File Offset: 0x00057354
		public MySkin()
		{
			base.MouseEnter += this.PanSkin_MouseEnter;
			base.MouseLeave += this.PanSkin_MouseLeave;
			base.MouseLeftButtonDown += this.PanSkin_MouseLeftButtonDown;
			base.MouseLeftButtonUp += this.PanSkin_MouseLeftButtonUp;
			this._IdentifierIterator = false;
			this.m_PolicyIterator = false;
			this.InitializeComponent();
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x000591C4 File Offset: 0x000573C4
		[CompilerGenerated]
		public void SearchModel(MySkin.ClickEventHandler obj)
		{
			MySkin.ClickEventHandler clickEventHandler = this.m_ConnectionIterator;
			MySkin.ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				MySkin.ClickEventHandler value = (MySkin.ClickEventHandler)Delegate.Combine(clickEventHandler2, obj);
				clickEventHandler = Interlocked.CompareExchange<MySkin.ClickEventHandler>(ref this.m_ConnectionIterator, value, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x000591FC File Offset: 0x000573FC
		[CompilerGenerated]
		public void CollectModel(MySkin.ClickEventHandler obj)
		{
			MySkin.ClickEventHandler clickEventHandler = this.m_ConnectionIterator;
			MySkin.ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				MySkin.ClickEventHandler value = (MySkin.ClickEventHandler)Delegate.Remove(clickEventHandler2, obj);
				clickEventHandler = Interlocked.CompareExchange<MySkin.ClickEventHandler>(ref this.m_ConnectionIterator, value, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x00007A82 File Offset: 0x00005C82
		public string RestartContainer()
		{
			return this.listIterator;
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x00007A8A File Offset: 0x00005C8A
		public void RevertContainer(string value)
		{
			this.listIterator = value;
			base.ToolTip = ((Operators.CompareString(this.listIterator, "", true) == 0) ? "加载中" : "点击更换皮肤（右键查看更多选项）");
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x00007AB8 File Offset: 0x00005CB8
		private void PanSkin_MouseEnter(object sender, MouseEventArgs e)
		{
			ModAni.AniStart(ModAni.AaOpacity(this.ShadowSkin, 0.8 - this.ShadowSkin.Opacity, 0xC8, 0x64, null, false), "Skin Shadow", false);
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x00059234 File Offset: 0x00057434
		private void PanSkin_MouseLeave(object sender, MouseEventArgs e)
		{
			ModAni.AniStart(ModAni.AaOpacity(this.ShadowSkin, 0.2 - this.ShadowSkin.Opacity, 0xC8, 0, null, false), "Skin Shadow", false);
			this._IdentifierIterator = false;
			ModAni.AniStart(ModAni.AaScaleTransform(this, 1.0 - ((ScaleTransform)base.RenderTransform).ScaleX, 0x3C, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false), "Skin Scale", false);
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00007AEE File Offset: 0x00005CEE
		private void PanSkin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			this._IdentifierIterator = true;
			ModAni.AniStart(ModAni.AaScaleTransform(this, 0.9 - ((ScaleTransform)base.RenderTransform).ScaleX, 0x3C, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false), "Skin Scale", false);
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x000592B0 File Offset: 0x000574B0
		private void PanSkin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			ModAni.AniStart(ModAni.AaScaleTransform(this, 1.0 - ((ScaleTransform)base.RenderTransform).ScaleX, 0x3C, 0, new ModAni.AniEaseOutFluent(ModAni.AniEasePower.Middle), false), "Skin Scale", false);
			if (this._IdentifierIterator)
			{
				this._IdentifierIterator = false;
				MySkin.ClickEventHandler connectionIterator = this.m_ConnectionIterator;
				if (connectionIterator != null)
				{
					connectionIterator(RuntimeHelpers.GetObjectValue(sender), e);
				}
			}
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x00007B2C File Offset: 0x00005D2C
		private void BtnSkinSave_Click(object sender, RoutedEventArgs e)
		{
			MySkin.Save(this.m_ReponseIterator);
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x00059318 File Offset: 0x00057518
		public static void Save(ModLoader.LoaderTask<ModBase.EqualableList<string>, string> Loader)
		{
			string output = Loader.Output;
			if (Loader.State != ModBase.LoadState.Finished)
			{
				ModMain.Hint("皮肤正在获取中，请稍候！", ModMain.HintType.Critical, true);
				if (Loader.State != ModBase.LoadState.Loading)
				{
					Loader.Start(null, false);
					return;
				}
			}
			else
			{
				try
				{
					string text = ModBase.SelectAs("选取保存皮肤的位置", ModBase.GetFileNameFromPath(output), "皮肤图片文件(*.png)|*.png", null);
					if (text.Contains("\\"))
					{
						File.Delete(text);
						if (output.StartsWith(ModBase.m_ExpressionRule))
						{
							new ModBitmap.MyBitmap(output).Save(text);
						}
						else
						{
							File.Copy(output, text);
						}
						ModMain.Hint("皮肤保存成功！", ModMain.HintType.Finish, true);
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "保存皮肤失败", ModBase.LogLevel.Hint, "出现错误");
				}
			}
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x00007B39 File Offset: 0x00005D39
		private void BtnSkinSave_Checked(MyMenuItem sender, RoutedEventArgs e)
		{
			sender.IsEnabled = (Operators.CompareString(this.RestartContainer(), "", true) == 0);
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x000593E0 File Offset: 0x000575E0
		public void Load()
		{
			try
			{
				this.RevertContainer(this.m_ReponseIterator.Output);
				if (Operators.CompareString(this.RestartContainer(), "", true) == 0)
				{
					throw new Exception("皮肤加载器 " + this.m_ReponseIterator.Name + " 没有输出");
				}
				if (!this.RestartContainer().StartsWith(ModBase.m_ExpressionRule) && !File.Exists(this.RestartContainer()))
				{
					throw new FileNotFoundException("皮肤文件未找到", this.RestartContainer());
				}
				ModBitmap.MyBitmap myBitmap = new ModBitmap.MyBitmap(this.RestartContainer());
				this.ImgBack.Tag = this.RestartContainer();
				if (myBitmap.requestMapper.Width >= 0x40 && myBitmap.requestMapper.Height >= 0x20)
				{
					if (checked(myBitmap.requestMapper.GetPixel(1, 1).A != 0 && myBitmap.requestMapper.GetPixel(myBitmap.requestMapper.Width - 1, myBitmap.requestMapper.Height - 1).A != 0 && myBitmap.requestMapper.GetPixel(myBitmap.requestMapper.Width - 2, 2).A != 0 && (!(myBitmap.requestMapper.GetPixel(1, 1) != myBitmap.requestMapper.GetPixel(0x29, 9)) || !(myBitmap.requestMapper.GetPixel(myBitmap.requestMapper.Width - 1, myBitmap.requestMapper.Height - 1) != myBitmap.requestMapper.GetPixel(0x29, 9)) || !(myBitmap.requestMapper.GetPixel(myBitmap.requestMapper.Width - 2, 2) != myBitmap.requestMapper.GetPixel(0x29, 9)))))
					{
						this.ImgFore.Source = null;
					}
					else
					{
						this.ImgFore.Source = new CroppedBitmap((BitmapSource)myBitmap, new Int32Rect(0x28, 8, 8, 8));
					}
				}
				else
				{
					this.ImgFore.Source = null;
				}
				if (myBitmap.requestMapper.Width < 0x20 || myBitmap.requestMapper.Height < 0x20)
				{
					this.ImgBack.Source = null;
					throw new Exception("图片大小不足，长为 " + Conversions.ToString(myBitmap.requestMapper.Height) + "，宽为 " + Conversions.ToString(myBitmap.requestMapper.Width));
				}
				this.ImgBack.Source = new CroppedBitmap((BitmapSource)myBitmap, new Int32Rect(8, 8, 8, 8));
				ModBase.Log("[Skin] 载入头像成功：" + this.m_ReponseIterator.Name, ModBase.LogLevel.Normal, "出现错误");
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, string.Concat(new string[]
				{
					"载入头像失败（",
					this.RestartContainer() ?? "null",
					",",
					this.m_ReponseIterator.Name,
					"）"
				}), ModBase.LogLevel.Hint, "出现错误");
			}
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x00007B55 File Offset: 0x00005D55
		public void Clear()
		{
			this.RevertContainer("");
			this.ImgFore.Source = null;
			this.ImgBack.Source = null;
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x00007B7A File Offset: 0x00005D7A
		private void RefreshClick(MyMenuItem sender, EventArgs e)
		{
			MySkin.RefreshCache(this.m_ReponseIterator);
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x00059700 File Offset: 0x00057900
		public static void RefreshCache(ModLoader.LoaderTask<ModBase.EqualableList<string>, string> sender = null)
		{
			MySkin._Closure$__22-0 CS$<>8__locals1 = new MySkin._Closure$__22-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_sender = sender;
			bool flag = false;
			try
			{
				List<ModLoader.LoaderTask<ModBase.EqualableList<string>, string>>.Enumerator enumerator = PageLaunchLeft.m_ResolverExpression.GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State == ModBase.LoadState.Loading)
					{
						flag = true;
						break;
					}
				}
			}
			finally
			{
				List<ModLoader.LoaderTask<ModBase.EqualableList<string>, string>>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			if (ModMain.m_InvocationFilter != null && flag)
			{
				ModMain.Hint("有正在获取中的皮肤，请稍后再试！", ModMain.HintType.Info, true);
				return;
			}
			ModBase.RunInThread(checked(delegate
			{
				try
				{
					ModMain.Hint("正在刷新皮肤……", ModMain.HintType.Info, true);
					ModBase.Log("[Skin] 正在清空皮肤缓存", ModBase.LogLevel.Normal, "出现错误");
					if (Directory.Exists(ModBase.m_GlobalRule + "Cache\\Skin"))
					{
						ModBase.DeleteDirectory(ModBase.m_GlobalRule + "Cache\\Skin", false);
					}
					if (Directory.Exists(ModBase.m_GlobalRule + "Cache\\Uuid"))
					{
						ModBase.DeleteDirectory(ModBase.m_GlobalRule + "Cache\\Uuid", false);
					}
					ModBase.IniClearCache(ModBase.m_GlobalRule + "Cache\\Skin\\IndexMojang.ini");
					ModBase.IniClearCache(ModBase.m_GlobalRule + "Cache\\Skin\\IndexMs.ini");
					ModBase.IniClearCache(ModBase.m_GlobalRule + "Cache\\Skin\\IndexNide.ini");
					ModBase.IniClearCache(ModBase.m_GlobalRule + "Cache\\Skin\\IndexAuth.ini");
					ModBase.IniClearCache(ModBase.m_GlobalRule + "Cache\\Uuid\\Mojang.ini");
					ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[] array2;
					if (CS$<>8__locals1.$VB$Local_sender == null)
					{
						ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[] array = new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[3];
						array[0] = PageLaunchLeft.m_AccountExpression;
						array[1] = PageLaunchLeft.m_InterpreterExpression;
						array2 = array;
						array[2] = PageLaunchLeft.m_ConfigurationExpression;
					}
					else
					{
						(array2 = new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[1])[0] = CS$<>8__locals1.$VB$Local_sender;
					}
					ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[] array3 = array2;
					for (int i = 0; i < array3.Length; i++)
					{
						array3[i].WaitForExit(null, null, true);
					}
					ModMain.Hint("已刷新皮肤！", ModMain.HintType.Finish, true);
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "刷新皮肤缓存失败", ModBase.LogLevel.Msgbox, "出现错误");
				}
			}));
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x00059790 File Offset: 0x00057990
		public static void ReloadCache(string SkinAddress, bool IsMsLogin)
		{
			MySkin._Closure$__23-0 CS$<>8__locals1 = new MySkin._Closure$__23-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_SkinAddress = SkinAddress;
			CS$<>8__locals1.$VB$Local_IsMsLogin = IsMsLogin;
			ModBase.RunInThread(checked(delegate
			{
				try
				{
					string text = CS$<>8__locals1.$VB$Local_IsMsLogin ? "Ms" : "Mojang";
					ModBase.WriteIni(ModBase.m_GlobalRule + "Cache\\Skin\\Index" + text + ".ini", Conversions.ToString(ModBase._BaseRule.Get("Cache" + text + "Uuid", null)), CS$<>8__locals1.$VB$Local_SkinAddress);
					ModBase.Log(string.Format("[Skin] 已写入皮肤地址缓存 {0} -> {1}", RuntimeHelpers.GetObjectValue(ModBase._BaseRule.Get("Cache" + text + "Uuid", null)), CS$<>8__locals1.$VB$Local_SkinAddress), ModBase.LogLevel.Normal, "出现错误");
					ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[] array2;
					if (!CS$<>8__locals1.$VB$Local_IsMsLogin)
					{
						ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[] array = new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[2];
						array[0] = PageLaunchLeft.m_AccountExpression;
						array2 = array;
						array[1] = PageLaunchLeft.m_InterpreterExpression;
					}
					else
					{
						ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[] array3 = new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[2];
						array3[0] = PageLaunchLeft.m_ConfigurationExpression;
						array2 = array3;
						array3[1] = PageLaunchLeft.m_InterpreterExpression;
					}
					ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[] array4 = array2;
					for (int i = 0; i < array4.Length; i++)
					{
						array4[i].WaitForExit(null, null, true);
					}
					ModMain.Hint("更改皮肤成功！", ModMain.HintType.Finish, true);
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "更改正版皮肤后刷新皮肤失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}));
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000A48 RID: 2632 RVA: 0x00007B87 File Offset: 0x00005D87
		// (set) Token: 0x06000A49 RID: 2633 RVA: 0x00007B97 File Offset: 0x00005D97
		public bool HasCape
		{
			get
			{
				return this.BtnSkinCape.Visibility == Visibility.Collapsed;
			}
			set
			{
				if (value)
				{
					this.BtnSkinCape.Visibility = Visibility.Visible;
					return;
				}
				this.BtnSkinCape.Visibility = Visibility.Collapsed;
			}
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x000597C4 File Offset: 0x000579C4
		private void BtnSkinCape_Click(object sender, RoutedEventArgs e)
		{
			if (this.m_PolicyIterator)
			{
				ModMain.Hint("正在更改披风中，请稍候！", ModMain.HintType.Info, true);
				return;
			}
			if (ModLaunch.systemIterator.State == ModBase.LoadState.Failed)
			{
				ModMain.Hint("登录失败，无法更改披风！", ModMain.HintType.Critical, true);
				return;
			}
			ModMain.Hint("正在获取披风列表，请稍候……", ModMain.HintType.Info, true);
			this.m_PolicyIterator = true;
			ModBase.RunInNewThread(delegate
			{
				try
				{
					MySkin._Closure$__28-0 CS$<>8__locals1 = new MySkin._Closure$__28-0(CS$<>8__locals1);
					if (ModLaunch.systemIterator.State != ModBase.LoadState.Finished)
					{
						ModLaunch.systemIterator.WaitForExit(null, null, false);
					}
					if (ModLaunch.systemIterator.State == ModBase.LoadState.Failed)
					{
						ModMain.Hint("登录失败，无法更改披风！", ModMain.HintType.Critical, true);
					}
					else
					{
						string listenerAlgo = ModLaunch.systemIterator.Output.listenerAlgo;
						CS$<>8__locals1.$VB$Local_SkinData = (JObject)ModBase.GetJson(ModLaunch.systemIterator.Output.m_AdapterAlgo);
						CS$<>8__locals1.$VB$Local_SelId = null;
						ModBase.RunInUiWait(delegate()
						{
							try
							{
								List<IMyRadio> list = new List<IMyRadio>
								{
									new MyRadioBox
									{
										Text = "无披风"
									}
								};
								try
								{
									foreach (JToken jtoken in ((IEnumerable<JToken>)CS$<>8__locals1.$VB$Local_SkinData["capes"]))
									{
										list.Add(new MyRadioBox
										{
											Text = jtoken["alias"].ToString().Replace("Migrator", "账号迁移披风")
										});
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
								CS$<>8__locals1.$VB$Local_SelId = ModMain.MyMsgBoxSelect(list, "选择披风", "确定", "取消", false);
							}
							catch (Exception ex2)
							{
								ModBase.Log(ex2, "获取玩家皮肤列表失败", ModBase.LogLevel.Feedback, "出现错误");
							}
						});
						if (CS$<>8__locals1.$VB$Local_SelId != null)
						{
							string url = "https://api.minecraftservices.com/minecraft/profile/capes/active";
							int? $VB$Local_SelId = CS$<>8__locals1.$VB$Local_SelId;
							string method = (($VB$Local_SelId != null) ? new bool?($VB$Local_SelId.GetValueOrDefault() == 0) : null).GetValueOrDefault() ? "DELETE" : "PUT";
							$VB$Local_SelId = CS$<>8__locals1.$VB$Local_SelId;
							string text = ModNet.NetRequestRetry(url, method, (($VB$Local_SelId != null) ? new bool?($VB$Local_SelId.GetValueOrDefault() == 0) : null).GetValueOrDefault() ? "" : ("{\"capeId\": \"" + CS$<>8__locals1.$VB$Local_SkinData["capes"][checked(CS$<>8__locals1.$VB$Local_SelId - 1)]["id"].ToString() + "\"}"), "application/json", true, new Dictionary<string, string>
							{
								{
									"Authorization",
									"Bearer " + listenerAlgo
								}
							});
							if (text.Contains("\"errorMessage\""))
							{
								ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject("更改披风失败：", NewLateBinding.LateIndexGet(ModBase.GetJson(text), new object[]
								{
									"errorMessage"
								}, null))), ModMain.HintType.Critical, true);
							}
							else
							{
								ModMain.Hint("更改披风成功！", ModMain.HintType.Finish, true);
							}
						}
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "更改披风失败", ModBase.LogLevel.Hint, "出现错误");
				}
				finally
				{
					this.m_PolicyIterator = false;
				}
			}, "Cape Change", ThreadPriority.Normal);
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000A4B RID: 2635 RVA: 0x00007BB5 File Offset: 0x00005DB5
		// (set) Token: 0x06000A4C RID: 2636 RVA: 0x00007BBD File Offset: 0x00005DBD
		internal virtual DropShadowEffect ShadowSkin { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000A4D RID: 2637 RVA: 0x00007BC6 File Offset: 0x00005DC6
		// (set) Token: 0x06000A4E RID: 2638 RVA: 0x0005982C File Offset: 0x00057A2C
		internal virtual MyMenuItem BtnSkinSave
		{
			[CompilerGenerated]
			get
			{
				return this._MapIterator;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = new RoutedEventHandler(this.BtnSkinSave_Click);
				RoutedEventHandler value3 = delegate(object sender, RoutedEventArgs e)
				{
					this.BtnSkinSave_Checked((MyMenuItem)sender, e);
				};
				MyMenuItem mapIterator = this._MapIterator;
				if (mapIterator != null)
				{
					mapIterator.Click -= value2;
					mapIterator.Checked -= value3;
				}
				this._MapIterator = value;
				mapIterator = this._MapIterator;
				if (mapIterator != null)
				{
					mapIterator.Click += value2;
					mapIterator.Checked += value3;
				}
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000A4F RID: 2639 RVA: 0x00007BCE File Offset: 0x00005DCE
		// (set) Token: 0x06000A50 RID: 2640 RVA: 0x0005988C File Offset: 0x00057A8C
		internal virtual MyMenuItem BtnSkinRefresh
		{
			[CompilerGenerated]
			get
			{
				return this.m_ComposerIterator;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = delegate(object sender, RoutedEventArgs e)
				{
					this.RefreshClick((MyMenuItem)sender, e);
				};
				MyMenuItem composerIterator = this.m_ComposerIterator;
				if (composerIterator != null)
				{
					composerIterator.Click -= value2;
				}
				this.m_ComposerIterator = value;
				composerIterator = this.m_ComposerIterator;
				if (composerIterator != null)
				{
					composerIterator.Click += value2;
				}
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000A51 RID: 2641 RVA: 0x00007BD6 File Offset: 0x00005DD6
		// (set) Token: 0x06000A52 RID: 2642 RVA: 0x000598D0 File Offset: 0x00057AD0
		internal virtual MyMenuItem BtnSkinCape
		{
			[CompilerGenerated]
			get
			{
				return this.m_PublisherIterator;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				RoutedEventHandler value2 = new RoutedEventHandler(this.BtnSkinCape_Click);
				MyMenuItem publisherIterator = this.m_PublisherIterator;
				if (publisherIterator != null)
				{
					publisherIterator.Click -= value2;
				}
				this.m_PublisherIterator = value;
				publisherIterator = this.m_PublisherIterator;
				if (publisherIterator != null)
				{
					publisherIterator.Click += value2;
				}
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000A53 RID: 2643 RVA: 0x00007BDE File Offset: 0x00005DDE
		// (set) Token: 0x06000A54 RID: 2644 RVA: 0x00007BE6 File Offset: 0x00005DE6
		internal virtual Image ImgBack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000A55 RID: 2645 RVA: 0x00007BEF File Offset: 0x00005DEF
		// (set) Token: 0x06000A56 RID: 2646 RVA: 0x00007BF7 File Offset: 0x00005DF7
		internal virtual Image ImgFore { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x06000A57 RID: 2647 RVA: 0x00059914 File Offset: 0x00057B14
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.m_ProcIterator)
			{
				this.m_ProcIterator = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagelaunch/myskin.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x00003037 File Offset: 0x00001237
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x00059944 File Offset: 0x00057B44
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.ShadowSkin = (DropShadowEffect)target;
				return;
			}
			if (connectionId == 2)
			{
				this.BtnSkinSave = (MyMenuItem)target;
				return;
			}
			if (connectionId == 3)
			{
				this.BtnSkinRefresh = (MyMenuItem)target;
				return;
			}
			if (connectionId == 4)
			{
				this.BtnSkinCape = (MyMenuItem)target;
				return;
			}
			if (connectionId == 5)
			{
				this.ImgBack = (Image)target;
				return;
			}
			if (connectionId == 6)
			{
				this.ImgFore = (Image)target;
				return;
			}
			this.m_ProcIterator = true;
		}

		// Token: 0x040005B8 RID: 1464
		[CompilerGenerated]
		private MySkin.ClickEventHandler m_ConnectionIterator;

		// Token: 0x040005B9 RID: 1465
		private string listIterator;

		// Token: 0x040005BA RID: 1466
		public ModLoader.LoaderTask<ModBase.EqualableList<string>, string> m_ReponseIterator;

		// Token: 0x040005BB RID: 1467
		private bool _IdentifierIterator;

		// Token: 0x040005BC RID: 1468
		private bool m_PolicyIterator;

		// Token: 0x040005BD RID: 1469
		[CompilerGenerated]
		[AccessedThroughProperty("ShadowSkin")]
		private DropShadowEffect _ClientIterator;

		// Token: 0x040005BE RID: 1470
		[AccessedThroughProperty("BtnSkinSave")]
		[CompilerGenerated]
		private MyMenuItem _MapIterator;

		// Token: 0x040005BF RID: 1471
		[AccessedThroughProperty("BtnSkinRefresh")]
		[CompilerGenerated]
		private MyMenuItem m_ComposerIterator;

		// Token: 0x040005C0 RID: 1472
		[CompilerGenerated]
		[AccessedThroughProperty("BtnSkinCape")]
		private MyMenuItem m_PublisherIterator;

		// Token: 0x040005C1 RID: 1473
		[AccessedThroughProperty("ImgBack")]
		[CompilerGenerated]
		private Image m_MessageIterator;

		// Token: 0x040005C2 RID: 1474
		[AccessedThroughProperty("ImgFore")]
		[CompilerGenerated]
		private Image m_TokenIterator;

		// Token: 0x040005C3 RID: 1475
		private bool m_ProcIterator;

		// Token: 0x02000123 RID: 291
		// (Invoke) Token: 0x06000A60 RID: 2656
		public delegate void ClickEventHandler(object sender, MouseButtonEventArgs e);
	}
}
