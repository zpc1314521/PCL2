using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;

namespace PCL
{
	// Token: 0x0200015A RID: 346
	[DesignerGenerated]
	public class PageSpeedLeft : MyPageLeft, IComponentConnector
	{
		// Token: 0x06000F1D RID: 3869 RVA: 0x00009D09 File Offset: 0x00007F09
		public PageSpeedLeft()
		{
			base.Loaded += this.Page_Loaded;
			this.importerBase = false;
			this.m_TemplateBase = new Dictionary<string, MyCard>();
			this.InitializeComponent();
		}

		// Token: 0x06000F1E RID: 3870 RVA: 0x00070834 File Offset: 0x0006EA34
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			this.Watcher();
			this.TryReturnToHome();
			if (!this.importerBase)
			{
				this.importerBase = true;
				DispatcherTimer dispatcherTimer = new DispatcherTimer();
				dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 0x12C);
				dispatcherTimer.Tick += delegate(object sender, EventArgs e)
				{
					this.Watcher();
				};
				dispatcherTimer.Start();
				if (!ModBase.errorRule)
				{
					base.RowDefinitions[0xC].Height = new GridLength(0.0);
					base.RowDefinitions[0xD].Height = new GridLength(0.0);
					base.RowDefinitions[0xE].Height = new GridLength(0.0);
					base.RowDefinitions[0xF].Height = new GridLength(0.0);
				}
			}
		}

		// Token: 0x06000F1F RID: 3871 RVA: 0x0007091C File Offset: 0x0006EB1C
		private void Watcher()
		{
			if (ModMain.m_GetterFilter.publisherDecorator == FormMain.PageType.DownloadManager)
			{
				try
				{
					if (ModLoader.LoaderTaskbar.Count == 0)
					{
						this.LabProgress.Text = "100 %";
						this.LabSpeed.Text = "0 B/s";
						this.LabFile.Text = "0";
						this.LabThread.Text = "0 / " + Conversions.ToString(ModNet.m_ClassModel);
					}
					else
					{
						double loaderTaskbarProgress = ModLoader.LoaderTaskbarProgress;
						string text = Conversions.ToString(Math.Floor(loaderTaskbarProgress * 100.0)) + "." + ModBase.StrFill(Conversions.ToString(Math.Floor((loaderTaskbarProgress * 100.0 - Math.Floor(loaderTaskbarProgress * 100.0)) * 100.0)), "0", 2) + " %";
						this.LabProgress.Text = ((loaderTaskbarProgress > 0.999999) ? "100 %" : text);
						this.LabSpeed.Text = ModBase.GetString(ModNet._ClientModel.indexerAlgo) + "/s";
						this.LabFile.Text = Conversions.ToString((ModNet._ClientModel.m_ObjectAlgo < 0) ? "0*" : ModNet._ClientModel.m_ObjectAlgo);
						this.LabThread.Text = Conversions.ToString(ModNet.m_IdentifierModel) + " / " + Conversions.ToString(ModNet.m_ClassModel);
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "下载管理左栏监视出错", ModBase.LogLevel.Feedback, "出现错误");
				}
				checked
				{
					if (ModMain._TokenizerFilter != null && ModMain._TokenizerFilter.PanMain != null)
					{
						try
						{
							object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
							ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
							lock (loaderTaskbarLock)
							{
								int num = ModLoader.LoaderTaskbar.Count - 1;
								for (int i = 0; i <= num; i++)
								{
									this.TaskRefresh(RuntimeHelpers.GetObjectValue(ModLoader.LoaderTaskbar[i]));
								}
							}
						}
						catch (Exception ex2)
						{
							ModBase.Log(ex2, "下载管理右栏监视出错", ModBase.LogLevel.Feedback, "出现错误");
						}
					}
				}
			}
		}

		// Token: 0x06000F20 RID: 3872 RVA: 0x00070BAC File Offset: 0x0006EDAC
		public void TaskRefresh(object Loader)
		{
			PageSpeedLeft._Closure$__6-1 CS$<>8__locals1 = new PageSpeedLeft._Closure$__6-1(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Me = this;
			CS$<>8__locals1.$VB$Local_Loader = Loader;
			checked
			{
				if (!Conversions.ToBoolean(CS$<>8__locals1.$VB$Local_Loader == null || Conversions.ToBoolean(Operators.NotObject(NewLateBinding.LateGet(CS$<>8__locals1.$VB$Local_Loader, null, "Show", new object[0], null, null, null)))))
				{
					try
					{
						ArrayList arrayList = (ArrayList)NewLateBinding.LateGet(CS$<>8__locals1.$VB$Local_Loader, null, "GetLoaderList", new object[0], null, null, null);
						if (this.m_TemplateBase.ContainsKey(Conversions.ToString(NewLateBinding.LateGet(CS$<>8__locals1.$VB$Local_Loader, null, "Name", new object[0], null, null, null))))
						{
							Grid grid = this.m_TemplateBase[Conversions.ToString(NewLateBinding.LateGet(CS$<>8__locals1.$VB$Local_Loader, null, "Name", new object[0], null, null, null))];
							double num = Conversions.ToDouble(Operators.AddObject(NewLateBinding.LateGet(CS$<>8__locals1.$VB$Local_Loader, null, "Progress", new object[0], null, null, null), NewLateBinding.LateGet(CS$<>8__locals1.$VB$Local_Loader, null, "State", new object[0], null, null, null)));
							if (ModBase.Val(RuntimeHelpers.GetObjectValue(grid.Tag)) == num)
							{
								return;
							}
							grid.Tag = num;
							if (grid.Children.Count <= 3)
							{
								ModBase.Log(Conversions.ToString(Operators.ConcatenateObject("[Watcher] 元素不足的卡片：", NewLateBinding.LateGet(CS$<>8__locals1.$VB$Local_Loader, null, "name", new object[0], null, null, null))), ModBase.LogLevel.Debug, "出现错误");
								return;
							}
							grid = (Grid)grid.Children[3];
							try
							{
								object left = NewLateBinding.LateGet(CS$<>8__locals1.$VB$Local_Loader, null, "State", new object[0], null, null, null);
								if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Failed, true))
								{
									grid.RowDefinitions.Clear();
									grid.Children.Clear();
									grid.Children.Add((UIElement)ModBase.GetObjectFromXML("<Path xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Stretch=\"Uniform\" Tag=\"Failed\" Data=\"F1 M2.5,0 L0,2.5 7.5,10 0,17.5 2.5,20 10,12.5 17.5,20 20,17.5 12.5,10 20,2.5 17.5,0 10,7.5 2.5,0Z\" Height=\"15\" Width=\"15\" HorizontalAlignment=\"Center\" Grid.Column=\"0\" Grid.Row=\"0\" Fill=\"{DynamicResource ColorBrush3}\" Margin=\"0,1,0,0\" VerticalAlignment=\"Top\"/>"));
									TextBlock textBlock = (TextBlock)ModBase.GetObjectFromXML("<TextBlock xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" TextWrapping=\"Wrap\" HorizontalAlignment=\"Left\" ToolTipService.ShowDuration=\"2333333\" ToolTip=\"单击复制错误详情\" Grid.Column=\"1\" Grid.Row=\"0\" Margin=\"0,0,0,5\" />");
									textBlock.Text = ModBase.GetString((Exception)NewLateBinding.LateGet(CS$<>8__locals1.$VB$Local_Loader, null, "Error", new object[0], null, null, null), false, false);
									textBlock.MouseDown += ((PageSpeedLeft._Closure$__.$IR6-2 == null) ? (PageSpeedLeft._Closure$__.$IR6-2 = delegate(object sender, MouseButtonEventArgs e)
									{
										((PageSpeedLeft._Closure$__.$I6-0 == null) ? (PageSpeedLeft._Closure$__.$I6-0 = delegate(TextBlock sender, EventArgs e)
										{
											ModBase.ClipboardSet(sender.Text, false);
											ModMain.Hint("已复制错误详情！", ModMain.HintType.Finish, true);
										}) : PageSpeedLeft._Closure$__.$I6-0)((TextBlock)sender, e);
									}) : PageSpeedLeft._Closure$__.$IR6-2);
									grid.Children.Add(textBlock);
								}
								else if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Finished, true))
								{
									ModAni.AniDispose((MyCard)grid.Parent, true, delegate(object a0)
									{
										this.TryReturnToHome();
									});
								}
								else if (Conversions.ToBoolean(Conversions.ToBoolean(Operators.CompareObjectEqual(left, ModBase.LoadState.Loading, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, ModBase.LoadState.Waiting, true))))
								{
									try
									{
										if (grid.Children.Count < arrayList.Count * 2)
										{
											ModBase.Log("刷新下载管理卡片失败：卡片中仅有 " + Conversions.ToString(grid.Children.Count) + " 个子项", ModBase.LogLevel.Debug, "出现错误");
										}
										else
										{
											int num2 = 0;
											try
											{
												foreach (object obj in arrayList)
												{
													object objectValue = RuntimeHelpers.GetObjectValue(obj);
													object left2 = NewLateBinding.LateGet(objectValue, null, "State", new object[0], null, null, null);
													if (Operators.ConditionalCompareObjectEqual(left2, ModBase.LoadState.Waiting, true))
													{
														if (Operators.ConditionalCompareObjectNotEqual(((FrameworkElement)grid.Children[num2 * 2]).Tag, "Waiting", true))
														{
															grid.Children.RemoveAt(num2 * 2);
															grid.Children.Insert(num2 * 2, (UIElement)ModBase.GetObjectFromXML("<Path xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" xmlns:local=\"clr-namespace:PCL;assembly=Plain Craft Launcher 2\" Stretch=\"Uniform\" Tag=\"Waiting\" Data=\"F1 M5,0 a5,5 360 1 0 0,0.0001 m15,0 a5,5 360 1 0 0,0.0001 m15,0 a5,5 360 1 0 0,0.0001 Z\" Width=\"18\" HorizontalAlignment=\"Center\" Grid.Column=\"0\" Grid.Row=\"" + Conversions.ToString(num2) + "\" Fill=\"{DynamicResource ColorBrush3}\" Margin=\"0,7,0,0\" VerticalAlignment=\"Top\" Height=\"6\"/>"));
														}
													}
													else if (Operators.ConditionalCompareObjectEqual(left2, ModBase.LoadState.Loading, true))
													{
														if (Operators.ConditionalCompareObjectNotEqual(((FrameworkElement)grid.Children[num2 * 2]).Tag, "Loading", true))
														{
															grid.Children.RemoveAt(num2 * 2);
															grid.Children.Insert(num2 * 2, (UIElement)NewLateBinding.LateGet(null, typeof(ModBase), "GetObjectFromXML", new object[]
															{
																Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("<TextBlock xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" xmlns:local=\"clr-namespace:PCL;assembly=Plain Craft Launcher 2\" Text=\"", NewLateBinding.LateGet(null, typeof(Math), "Floor", new object[]
																{
																	Operators.MultiplyObject(NewLateBinding.LateGet(objectValue, null, "Progress", new object[0], null, null, null), 0x64)
																}, null, null, null)), "%\" Tag=\"Loading\" HorizontalAlignment=\"Center\" Grid.Column=\"0\" Grid.Row=\""), num2), "\" Foreground=\"{DynamicResource ColorBrush3}\"/>")
															}, null, null, null));
														}
														else
														{
															((TextBlock)grid.Children[num2 * 2]).Text = Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(null, typeof(Math), "Floor", new object[]
															{
																Operators.MultiplyObject(NewLateBinding.LateGet(objectValue, null, "Progress", new object[0], null, null, null), 0x64)
															}, null, null, null), "%"));
														}
													}
													else if (Operators.ConditionalCompareObjectEqual(left2, ModBase.LoadState.Finished, true) && Operators.ConditionalCompareObjectNotEqual(((FrameworkElement)grid.Children[num2 * 2]).Tag, "Finished", true))
													{
														grid.Children.RemoveAt(num2 * 2);
														grid.Children.Insert(num2 * 2, (UIElement)ModBase.GetObjectFromXML("<Path xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" xmlns:local=\"clr-namespace:PCL;assembly=Plain Craft Launcher 2\" Stretch=\"Uniform\" Tag=\"Finished\" Data=\"F1 M 23.7501,33.25L 34.8334,44.3333L 52.2499,22.1668L 56.9999,26.9168L 34.8334,53.8333L 19.0001,38L 23.7501,33.25 Z\" Height=\"16\" Width=\"15\" HorizontalAlignment=\"Center\" Grid.Column=\"0\" Grid.Row=\"" + Conversions.ToString(num2) + "\" Fill=\"{DynamicResource ColorBrush3}\" Margin=\"0,3,0,0\" VerticalAlignment=\"Top\"/>"));
													}
													num2++;
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
									}
									catch (Exception ex)
									{
										ModBase.Log(ex, "刷新下载管理卡片失败", ModBase.LogLevel.Feedback, "出现错误");
									}
								}
								goto IL_B1E;
							}
							catch (Exception ex2)
							{
								ModBase.Log(ex2, "更新下载管理显示失败（" + NewLateBinding.LateGet(CS$<>8__locals1.$VB$Local_Loader, null, "State", new object[0], null, null, null).ToString() + "）", ModBase.LogLevel.Feedback, "出现错误");
								goto IL_B1E;
							}
						}
						if (Conversions.ToBoolean(Operators.NotObject(Conversions.ToBoolean(Operators.CompareObjectEqual(NewLateBinding.LateGet(CS$<>8__locals1.$VB$Local_Loader, null, "State", new object[0], null, null, null), ModBase.LoadState.Aborted, true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(NewLateBinding.LateGet(CS$<>8__locals1.$VB$Local_Loader, null, "State", new object[0], null, null, null), ModBase.LoadState.Finished, true)))))
						{
							try
							{
								PageSpeedLeft._Closure$__6-0 CS$<>8__locals2 = new PageSpeedLeft._Closure$__6-0(CS$<>8__locals2);
								CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2 = CS$<>8__locals1;
								string text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("\r\n                        <local:MyCard xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" xmlns:local=\"clr-namespace:PCL;assembly=Plain Craft Launcher 2\"\r\n                            Tag=\"", Operators.AddObject(NewLateBinding.LateGet(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Loader, null, "Progress", new object[0], null, null, null), NewLateBinding.LateGet(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Loader, null, "State", new object[0], null, null, null))), "\" Title=\""), ModBase.smethod_3(Conversions.ToString(NewLateBinding.LateGet(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Loader, null, "Name", new object[0], null, null, null)))), "\" Margin=\"0,0,0,15\">\r\n                            <Grid Margin=\"14,40,15,10\">\r\n                                <Grid.ColumnDefinitions>\r\n                                    <ColumnDefinition Width=\"50\"/>\r\n                                    <ColumnDefinition/>\r\n                                </Grid.ColumnDefinitions>\r\n                                <Grid.RowDefinitions>"));
								try
								{
									foreach (object obj2 in arrayList)
									{
										RuntimeHelpers.GetObjectValue(obj2);
										text += "<RowDefinition Height=\"26\"/>";
									}
								}
								finally
								{
									IEnumerator enumerator2;
									if (enumerator2 is IDisposable)
									{
										(enumerator2 as IDisposable).Dispose();
									}
								}
								text += "</Grid.RowDefinitions>";
								int num3 = 0;
								try
								{
									foreach (object obj3 in arrayList)
									{
										object objectValue2 = RuntimeHelpers.GetObjectValue(obj3);
										object left3 = NewLateBinding.LateGet(objectValue2, null, "State", new object[0], null, null, null);
										if (Operators.ConditionalCompareObjectEqual(left3, ModBase.LoadState.Waiting, true))
										{
											text = text + "<Path Stretch=\"Uniform\" Tag=\"Waiting\" Data=\"F1 M5,0 a5,5 360 1 0 0,0.0001 m15,0 a5,5 360 1 0 0,0.0001 m15,0 a5,5 360 1 0 0,0.0001 Z\" Width=\"18\" HorizontalAlignment=\"Center\" Grid.Column=\"0\" Grid.Row=\"" + Conversions.ToString(num3) + "\" Fill=\"{DynamicResource ColorBrush3}\" Margin=\"0,7,0,0\" VerticalAlignment=\"Top\" Height=\"6\"/>";
										}
										else if (Operators.ConditionalCompareObjectEqual(left3, ModBase.LoadState.Loading, true))
										{
											text = Conversions.ToString(Operators.AddObject(text, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("<TextBlock Text=\"", NewLateBinding.LateGet(null, typeof(Math), "Floor", new object[]
											{
												Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, null, "Progress", new object[0], null, null, null), 0x64)
											}, null, null, null)), "%\" Tag=\"Loading\" HorizontalAlignment=\"Center\" Grid.Column=\"0\" Grid.Row=\""), num3), "\" Foreground=\"{DynamicResource ColorBrush3}\" />")));
										}
										else if (Operators.ConditionalCompareObjectEqual(left3, ModBase.LoadState.Finished, true))
										{
											text = text + "<Path Stretch=\"Uniform\" Tag=\"Finished\" Data=\"F1 M 23.7501,33.25L 34.8334,44.3333L 52.2499,22.1668L 56.9999,26.9168L 34.8334,53.8333L 19.0001,38L 23.7501,33.25 Z\" Height=\"16\" Width=\"15\" HorizontalAlignment=\"Center\" Grid.Column=\"0\" Grid.Row=\"" + Conversions.ToString(num3) + "\" Fill=\"{DynamicResource ColorBrush3}\" Margin=\"0,3,0,0\" VerticalAlignment=\"Top\"/>";
										}
										else
										{
											text = text + "<Path Stretch=\"Uniform\" Tag=\"Failed\" Data=\"F1 M2.5,0 L0,2.5 7.5,10 0,17.5 2.5,20 10,12.5 17.5,20 20,17.5 12.5,10 20,2.5 17.5,0 10,7.5 2.5,0Z\" Height=\"15\" Width=\"15\" HorizontalAlignment=\"Center\" Grid.Column=\"0\" Grid.Row=\"" + Conversions.ToString(num3) + "\" Fill=\"{DynamicResource ColorBrush3}\" Margin=\"0,1,0,0\" VerticalAlignment=\"Top\"/>";
										}
										text = string.Concat(new string[]
										{
											text,
											"<TextBlock Text=\"",
											ModBase.smethod_3(Conversions.ToString(NewLateBinding.LateGet(objectValue2, null, "Name", new object[0], null, null, null))),
											"\" HorizontalAlignment=\"Left\" Grid.Column=\"1\" Grid.Row=\"",
											Conversions.ToString(num3),
											"\"/>"
										});
										num3++;
									}
								}
								finally
								{
									IEnumerator enumerator3;
									if (enumerator3 is IDisposable)
									{
										(enumerator3 as IDisposable).Dispose();
									}
								}
								text += "\r\n                            </Grid>\r\n                        </local:MyCard>";
								try
								{
									CS$<>8__locals2.$VB$Local_Card = (MyCard)ModBase.GetObjectFromXML(text);
								}
								catch (Exception ex3)
								{
									ModBase.Log(ex3, "新建下载管理卡片失败", ModBase.LogLevel.Debug, "出现错误");
									ModBase.Log("出错的卡片内容：\r\n" + text, ModBase.LogLevel.Normal, "出现错误");
									throw;
								}
								ModMain._TokenizerFilter.PanMain.Children.Insert(0, CS$<>8__locals2.$VB$Local_Card);
								this.m_TemplateBase.Add(Conversions.ToString(NewLateBinding.LateGet(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Loader, null, "Name", new object[0], null, null, null)), CS$<>8__locals2.$VB$Local_Card);
								MyIconButton myIconButton = new MyIconButton
								{
									Name = "BtnCancel",
									Logo = "F1 M2,0 L0,2 8,10 0,18 2,20 10,12 18,20 20,18 12,10 20,2 18,0 10,8 2,0Z",
									Height = 20.0,
									Margin = new Thickness(0.0, 10.0, 10.0, 0.0),
									LogoScale = 1.1,
									HorizontalAlignment = HorizontalAlignment.Right,
									VerticalAlignment = VerticalAlignment.Top
								};
								CS$<>8__locals2.$VB$Local_Card.Children.Add(myIconButton);
								myIconButton.Click += delegate(object sender, EventArgs e)
								{
									base._Lambda$__1((MyIconButton)sender, e);
								};
								if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Loader, null, "State", new object[0], null, null, null), ModBase.LoadState.Failed, true))
								{
									CS$<>8__locals2.$VB$Local_Card.Tag = null;
									this.TaskRefresh(RuntimeHelpers.GetObjectValue(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_Loader));
								}
							}
							catch (Exception ex4)
							{
								ModBase.Log(ex4, "添加下载管理卡片失败", ModBase.LogLevel.Feedback, "出现错误");
							}
						}
						IL_B1E:;
					}
					catch (Exception ex5)
					{
						ModBase.Log(ex5, "刷新下载管理显示失败", ModBase.LogLevel.Feedback, "出现错误");
					}
				}
			}
		}

		// Token: 0x06000F21 RID: 3873 RVA: 0x000717C0 File Offset: 0x0006F9C0
		public void TaskRemove(object Loader)
		{
			if (this.m_TemplateBase.ContainsKey(Conversions.ToString(NewLateBinding.LateGet(Loader, null, "Name", new object[0], null, null, null))))
			{
				ModBase.RunInUiWait(delegate()
				{
					Grid element = this.m_TemplateBase[Conversions.ToString(NewLateBinding.LateGet(Loader, null, "Name", new object[0], null, null, null))];
					ModMain._TokenizerFilter.PanMain.Children.Remove(element);
					this.m_TemplateBase.Remove(Conversions.ToString(NewLateBinding.LateGet(Loader, null, "Name", new object[0], null, null, null)));
				});
			}
		}

		// Token: 0x06000F22 RID: 3874 RVA: 0x00009D3B File Offset: 0x00007F3B
		private void TryReturnToHome()
		{
			if (ModMain._TokenizerFilter.PanMain.Children.Count == 0 && ModMain.m_GetterFilter.publisherDecorator == FormMain.PageType.DownloadManager)
			{
				ModMain.m_GetterFilter.PageBack();
			}
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x06000F23 RID: 3875 RVA: 0x00009D74 File Offset: 0x00007F74
		// (set) Token: 0x06000F24 RID: 3876 RVA: 0x00009D7C File Offset: 0x00007F7C
		internal virtual TextBlock LabProgress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x06000F25 RID: 3877 RVA: 0x00009D85 File Offset: 0x00007F85
		// (set) Token: 0x06000F26 RID: 3878 RVA: 0x00009D8D File Offset: 0x00007F8D
		internal virtual TextBlock LabSpeed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x06000F27 RID: 3879 RVA: 0x00009D96 File Offset: 0x00007F96
		// (set) Token: 0x06000F28 RID: 3880 RVA: 0x00009D9E File Offset: 0x00007F9E
		internal virtual TextBlock LabFile { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x06000F29 RID: 3881 RVA: 0x00009DA7 File Offset: 0x00007FA7
		// (set) Token: 0x06000F2A RID: 3882 RVA: 0x00009DAF File Offset: 0x00007FAF
		internal virtual TextBlock LabThread { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x06000F2B RID: 3883 RVA: 0x00071820 File Offset: 0x0006FA20
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this._DefinitionBase)
			{
				this._DefinitionBase = true;
				Uri resourceLocator = new Uri("/Plain Craft Launcher 2;component/pages/pagespeedleft.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000F2C RID: 3884 RVA: 0x00003037 File Offset: 0x00001237
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000F2D RID: 3885 RVA: 0x00071850 File Offset: 0x0006FA50
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.LabProgress = (TextBlock)target;
				return;
			}
			if (connectionId == 2)
			{
				this.LabSpeed = (TextBlock)target;
				return;
			}
			if (connectionId == 3)
			{
				this.LabFile = (TextBlock)target;
				return;
			}
			if (connectionId == 4)
			{
				this.LabThread = (TextBlock)target;
				return;
			}
			this._DefinitionBase = true;
		}

		// Token: 0x040007F2 RID: 2034
		private bool importerBase;

		// Token: 0x040007F3 RID: 2035
		private readonly Dictionary<string, MyCard> m_TemplateBase;

		// Token: 0x040007F4 RID: 2036
		[AccessedThroughProperty("LabProgress")]
		[CompilerGenerated]
		private TextBlock _AdapterBase;

		// Token: 0x040007F5 RID: 2037
		[AccessedThroughProperty("LabSpeed")]
		[CompilerGenerated]
		private TextBlock annotationBase;

		// Token: 0x040007F6 RID: 2038
		[AccessedThroughProperty("LabFile")]
		[CompilerGenerated]
		private TextBlock readerBase;

		// Token: 0x040007F7 RID: 2039
		[CompilerGenerated]
		[AccessedThroughProperty("LabThread")]
		private TextBlock regBase;

		// Token: 0x040007F8 RID: 2040
		private bool _DefinitionBase;
	}
}
