using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Shell;

namespace PCL
{
	// Token: 0x020000B6 RID: 182
	[StandardModule]
	public sealed class ModLoader
	{
		// Token: 0x06000744 RID: 1860 RVA: 0x0000624F File Offset: 0x0000444F
		// Note: this type is marked as 'beforefieldinit'.
		static ModLoader()
		{
			ModLoader.LoaderTaskbarLock = RuntimeHelpers.GetObjectValue(new object());
			ModLoader.LoaderTaskbar = new ArrayList();
			ModLoader.LoaderTaskbarProgress = 0.0;
			ModLoader.LoaderTaskbarProgressLast = TaskbarItemProgressState.None;
			ModLoader.LoaderFolderDictionary = new Dictionary<object, ModLoader.LoaderFolderDictionaryEntry>();
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x000354E8 File Offset: 0x000336E8
		public static void LoaderTaskbarAdd(object Loader)
		{
			if (ModMain.observerFilter != null)
			{
				ModMain.observerFilter.TaskRemove(RuntimeHelpers.GetObjectValue(Loader));
			}
			object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
			ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
			lock (loaderTaskbarLock)
			{
				ModLoader.LoaderTaskbar.Add(RuntimeHelpers.GetObjectValue(Loader));
			}
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x00035550 File Offset: 0x00033750
		public static void LoaderTaskbarProgressRefresh()
		{
			try
			{
				double num = ModLoader.LoaderTaskbarProgressGet();
				object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
				ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
				checked
				{
					lock (loaderTaskbarLock)
					{
						bool flag2 = true;
						try
						{
							foreach (object obj in ModLoader.LoaderTaskbar)
							{
								object objectValue = RuntimeHelpers.GetObjectValue(obj);
								if (Conversions.ToBoolean(Conversions.ToBoolean(NewLateBinding.LateGet(objectValue, null, "Show", new object[0], null, null, null)) && Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue, null, "State", new object[0], null, null, null), ModBase.LoadState.Loading, true)))
								{
									flag2 = false;
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
						ArrayList arrayList = new ArrayList();
						int num2 = ModLoader.LoaderTaskbar.Count - 1;
						for (int i = 0; i <= num2; i++)
						{
							if (Conversions.ToBoolean((flag2 || Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(ModLoader.LoaderTaskbar[i], null, "State", new object[0], null, null, null), ModBase.LoadState.Aborted, true)) && Conversions.ToBoolean(NewLateBinding.LateGet(ModLoader.LoaderTaskbar[i], null, "Show", new object[0], null, null, null))))
							{
								if (ModMain.observerFilter != null)
								{
									ModMain.observerFilter.TaskRefresh(RuntimeHelpers.GetObjectValue(ModLoader.LoaderTaskbar[i]));
								}
								arrayList.Add(RuntimeHelpers.GetObjectValue(ModLoader.LoaderTaskbar[i]));
							}
						}
						try
						{
							foreach (object obj2 in arrayList)
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(obj2);
								ModLoader.LoaderTaskbar.Remove(RuntimeHelpers.GetObjectValue(objectValue2));
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
					}
				}
				if (num > 0.0 && num < 1.0 && ModLoader.LoaderTaskbarProgress <= num)
				{
					ModLoader.LoaderTaskbarProgress = ModLoader.LoaderTaskbarProgress * 0.9 + num * 0.1;
				}
				else
				{
					ModLoader.LoaderTaskbarProgress = num;
				}
				TaskbarItemProgressState taskbarItemProgressState;
				if (ModLoader.LoaderTaskbar.Count != 0)
				{
					if (ModLoader.LoaderTaskbarProgress != 1.0)
					{
						if (ModLoader.LoaderTaskbarProgress < 0.015)
						{
							taskbarItemProgressState = TaskbarItemProgressState.Indeterminate;
							goto IL_266;
						}
						taskbarItemProgressState = TaskbarItemProgressState.Normal;
						ModMain.m_GetterFilter.TaskbarItemInfo.ProgressValue = ModLoader.LoaderTaskbarProgress;
						goto IL_266;
					}
				}
				taskbarItemProgressState = TaskbarItemProgressState.None;
				IL_266:
				if (ModLoader.LoaderTaskbarProgressLast != taskbarItemProgressState)
				{
					ModLoader.LoaderTaskbarProgressLast = taskbarItemProgressState;
					ModMain.m_GetterFilter.TaskbarItemInfo.ProgressState = taskbarItemProgressState;
					ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "刷新任务栏进度显示失败", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x00035878 File Offset: 0x00033A78
		public static double LoaderTaskbarProgressGet()
		{
			checked
			{
				double result;
				try
				{
					double num = 0.0;
					int num2 = 0;
					object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
					ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
					lock (loaderTaskbarLock)
					{
						int num3 = ModLoader.LoaderTaskbar.Count - 1;
						for (int i = 0; i <= num3; i++)
						{
							num = Conversions.ToDouble(Operators.AddObject(num, NewLateBinding.LateGet(ModLoader.LoaderTaskbar[i], null, "Progress", new object[0], null, null, null)));
							num2++;
						}
					}
					if (num2 == 0)
					{
						result = 1.0;
					}
					else
					{
						result = ModBase.MathRange(num / (double)num2, 0.0, 1.0);
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "获取任务栏进度出错", ModBase.LogLevel.Feedback, "出现错误");
					result = 0.5;
				}
				return result;
			}
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x00035980 File Offset: 0x00033B80
		public static bool LoaderFolderRun(object Loader, string FolderPath, ModLoader.LoaderFolderRunType Type, int MaxDepth = 0, string ExtraPath = "", bool WaitForExit = false)
		{
			ModLoader.LoaderFolderDictionaryEntry value = default(ModLoader.LoaderFolderDictionaryEntry);
			value.FolderPath = FolderPath + ExtraPath;
			value.LastCheckTime = null;
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(FolderPath + ExtraPath);
				value.LastCheckTime = new DateTime?(directoryInfo.Exists ? ModLoader.GetActualLastWriteTimeUtc(directoryInfo, MaxDepth) : DateTime.MinValue);
				if (Type == ModLoader.LoaderFolderRunType.RunOnUpdated && ModLoader.LoaderFolderDictionary.ContainsKey(RuntimeHelpers.GetObjectValue(Loader)))
				{
					if (directoryInfo.Exists)
					{
						ModLoader.LoaderFolderDictionaryEntry loaderFolderDictionaryEntry = ModLoader.LoaderFolderDictionary[RuntimeHelpers.GetObjectValue(Loader)];
						if (loaderFolderDictionaryEntry.LastCheckTime != null && value.Equals(ModLoader.LoaderFolderDictionary[RuntimeHelpers.GetObjectValue(Loader)]))
						{
							return false;
						}
					}
					else
					{
						ModLoader.LoaderFolderDictionaryEntry loaderFolderDictionaryEntry = ModLoader.LoaderFolderDictionary[RuntimeHelpers.GetObjectValue(Loader)];
						if (loaderFolderDictionaryEntry.LastCheckTime == null)
						{
							return false;
						}
					}
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "文件夹加载器启动检测出错", ModBase.LogLevel.Debug, "出现错误");
			}
			ModBase.DictionaryAdd<object, ModLoader.LoaderFolderDictionaryEntry>(ref ModLoader.LoaderFolderDictionary, RuntimeHelpers.GetObjectValue(Loader), value);
			bool result;
			if (Type == ModLoader.LoaderFolderRunType.UpdateOnly)
			{
				result = false;
			}
			else
			{
				if (WaitForExit)
				{
					object[] array;
					bool[] array2;
					NewLateBinding.LateCall(Loader, null, "WaitForExit", array = new object[]
					{
						FolderPath
					}, null, null, array2 = new bool[]
					{
						true
					}, true);
					if (array2[0])
					{
						FolderPath = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
					}
				}
				else
				{
					object[] array;
					bool[] array2;
					NewLateBinding.LateCall(Loader, null, "Start", array = new object[]
					{
						FolderPath
					}, null, null, array2 = new bool[]
					{
						true
					}, true);
					if (array2[0])
					{
						FolderPath = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x00035B68 File Offset: 0x00033D68
		private static DateTime GetActualLastWriteTimeUtc(DirectoryInfo FolderInfo, int MaxDepth)
		{
			DateTime dateTime = FolderInfo.LastWriteTimeUtc;
			if (MaxDepth > 0)
			{
				try
				{
					foreach (DirectoryInfo folderInfo in FolderInfo.EnumerateDirectories())
					{
						DateTime actualLastWriteTimeUtc = ModLoader.GetActualLastWriteTimeUtc(folderInfo, checked(MaxDepth - 1));
						if (DateTime.Compare(actualLastWriteTimeUtc, dateTime) > 0)
						{
							dateTime = actualLastWriteTimeUtc;
						}
					}
				}
				finally
				{
					IEnumerator<DirectoryInfo> enumerator;
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
			}
			return dateTime;
		}

		// Token: 0x04000371 RID: 881
		public static object LoaderTaskbarLock;

		// Token: 0x04000372 RID: 882
		public static ArrayList LoaderTaskbar;

		// Token: 0x04000373 RID: 883
		public static double LoaderTaskbarProgress;

		// Token: 0x04000374 RID: 884
		private static TaskbarItemProgressState LoaderTaskbarProgressLast;

		// Token: 0x04000375 RID: 885
		private static Dictionary<object, ModLoader.LoaderFolderDictionaryEntry> LoaderFolderDictionary;

		// Token: 0x020000B7 RID: 183
		// (Invoke) Token: 0x0600074D RID: 1869
		public delegate void LoaderStateDelegate(object Loader);

		// Token: 0x020000B8 RID: 184
		public abstract class LoaderBase<InputType> : ILoadingTrigger
		{
			// Token: 0x0600074E RID: 1870 RVA: 0x00035BD0 File Offset: 0x00033DD0
			protected LoaderBase()
			{
				this.IsLoader = 1;
				this.Uuid = ModBase.GetUuid();
				this.Name = "未命名任务 " + Conversions.ToString(this.Uuid) + "#";
				this.Type = typeof(InputType);
				this.LockState = RuntimeHelpers.GetObjectValue(new object());
				this.Parent = null;
				this._State = ModBase.LoadState.Waiting;
				this._LoadingState = MyLoading.MyLoadingState.Stop;
				this.OnStateChangedRunInUi = true;
				this.Error = null;
				this.Block = true;
				this.Show = true;
				this._Progress = -1.0;
				this.ProgressWeight = 1.0;
			}

			// Token: 0x17000144 RID: 324
			// (get) Token: 0x0600074F RID: 1871 RVA: 0x00006288 File Offset: 0x00004488
			public bool IsLoader { get; }

			// Token: 0x17000145 RID: 325
			// (get) Token: 0x06000750 RID: 1872 RVA: 0x00035C84 File Offset: 0x00033E84
			public object RealParent
			{
				get
				{
					object obj;
					try
					{
						obj = RuntimeHelpers.GetObjectValue(this.Parent);
						while (obj != null && obj.GetType().Name.StartsWith("Loader") && NewLateBinding.LateGet(obj, null, "Parent", new object[0], null, null, null) != null)
						{
							obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj, null, "Parent", new object[0], null, null, null));
						}
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "获取父加载器失败（" + this.Name + "）", ModBase.LogLevel.Feedback, "出现错误");
						obj = null;
					}
					return obj;
				}
			}

			// Token: 0x06000751 RID: 1873 RVA: 0x00006290 File Offset: 0x00004490
			public virtual void InitParent(object Parent)
			{
				this.Parent = RuntimeHelpers.GetObjectValue(Parent);
			}

			// Token: 0x17000146 RID: 326
			// (get) Token: 0x06000752 RID: 1874 RVA: 0x0000629E File Offset: 0x0000449E
			// (set) Token: 0x06000753 RID: 1875 RVA: 0x00035D30 File Offset: 0x00033F30
			public ModBase.LoadState State
			{
				get
				{
					return this._State;
				}
				set
				{
					if (this._State != value)
					{
						if (Conversions.ToBoolean(ModBase._BaseRule.Get("SystemDebugDelay", null)))
						{
							Thread.Sleep(ModBase.RandomInteger(0x32, 0x12C));
						}
						this._State = value;
						ModBase.Log("[Loader] 加载器 " + this.Name + " 状态改变：" + ModBase.GetStringFromEnum(value), ModBase.LogLevel.Normal, "出现错误");
						ModBase.RunInUi(delegate()
						{
							ModBase.LoadState $VB$Local_value = value;
							if ($VB$Local_value == ModBase.LoadState.Loading)
							{
								this.LoadingState = MyLoading.MyLoadingState.Run;
								return;
							}
							if ($VB$Local_value != ModBase.LoadState.Failed)
							{
								this.LoadingState = MyLoading.MyLoadingState.Stop;
								return;
							}
							this.LoadingState = MyLoading.MyLoadingState.Error;
						}, false);
						if (this.OnStateChanged != null)
						{
							if (!this.OnStateChangedRunInUi)
							{
								this.OnStateChanged(this);
								return;
							}
							ModBase.RunInUi(this.OnStateChanged, new object[]
							{
								this
							});
						}
					}
				}
			}

			// Token: 0x17000147 RID: 327
			// (get) Token: 0x06000754 RID: 1876 RVA: 0x000062A6 File Offset: 0x000044A6
			// (set) Token: 0x06000755 RID: 1877 RVA: 0x00035E0C File Offset: 0x0003400C
			public MyLoading.MyLoadingState LoadingState
			{
				get
				{
					return this._LoadingState;
				}
				set
				{
					if (this._LoadingState != value)
					{
						this._LoadingState = value;
						ILoadingTrigger.LoadingStateChangedEventHandler loadingStateChangedEvent = this.LoadingStateChangedEvent;
						if (loadingStateChangedEvent != null)
						{
							loadingStateChangedEvent(value);
						}
					}
				}
			}

			// Token: 0x14000005 RID: 5
			// (add) Token: 0x06000756 RID: 1878 RVA: 0x00035E3C File Offset: 0x0003403C
			// (remove) Token: 0x06000757 RID: 1879 RVA: 0x00035E74 File Offset: 0x00034074
			public event ILoadingTrigger.LoadingStateChangedEventHandler LoadingStateChanged;

			// Token: 0x17000148 RID: 328
			// (get) Token: 0x06000758 RID: 1880 RVA: 0x000062AE File Offset: 0x000044AE
			// (set) Token: 0x06000759 RID: 1881 RVA: 0x000062B6 File Offset: 0x000044B6
			public Exception Error { get; set; }

			// Token: 0x17000149 RID: 329
			// (get) Token: 0x0600075A RID: 1882 RVA: 0x00035EAC File Offset: 0x000340AC
			// (set) Token: 0x0600075B RID: 1883 RVA: 0x000062BF File Offset: 0x000044BF
			public virtual double Progress
			{
				get
				{
					ModBase.LoadState state = this.State;
					double result;
					if (state != ModBase.LoadState.Waiting)
					{
						if (state != ModBase.LoadState.Loading)
						{
							result = 1.0;
						}
						else if (this._Progress == -1.0)
						{
							result = 0.02;
						}
						else
						{
							result = this._Progress;
						}
					}
					else
					{
						result = 0.0;
					}
					return result;
				}
				set
				{
					this._Progress = value;
				}
			}

			// Token: 0x1700014A RID: 330
			// (get) Token: 0x0600075C RID: 1884 RVA: 0x000062C8 File Offset: 0x000044C8
			// (set) Token: 0x0600075D RID: 1885 RVA: 0x000062D0 File Offset: 0x000044D0
			public double ProgressWeight { get; set; }

			// Token: 0x0600075E RID: 1886
			public abstract void Start(InputType Input = default(InputType), bool IsForceRestart = false);

			// Token: 0x0600075F RID: 1887
			public abstract void Abort();

			// Token: 0x06000760 RID: 1888 RVA: 0x00035F04 File Offset: 0x00034104
			public void WaitForExit(InputType Input = default(InputType), object LoaderToSyncProgress = null, bool IsForceRestart = false)
			{
				if (IsForceRestart || this.State != ModBase.LoadState.Loading)
				{
					this.Start(Input, IsForceRestart);
				}
				while (this.State == ModBase.LoadState.Loading)
				{
					if (LoaderToSyncProgress != null)
					{
						NewLateBinding.LateSet(LoaderToSyncProgress, null, "Progress", new object[]
						{
							this.Progress
						}, null, null);
					}
					Thread.Sleep(0xA);
				}
				if (this.State == ModBase.LoadState.Finished)
				{
					return;
				}
				if (this.State == ModBase.LoadState.Aborted)
				{
					throw new OperationCanceledException("加载器执行已中断。");
				}
				if (Information.IsNothing(this.Error))
				{
					throw new Exception("未知错误！");
				}
				throw new Exception(this.Error.Message, this.Error);
			}

			// Token: 0x06000761 RID: 1889 RVA: 0x00035FA8 File Offset: 0x000341A8
			public void WaitForExitTime(int Timeout, InputType Input = default(InputType), string TimeoutMessage = "等待加载器执行超时。", object LoaderToSyncProgress = null, bool IsForceRestart = false)
			{
				if (this.State != ModBase.LoadState.Loading)
				{
					this.Start(Input, IsForceRestart);
				}
				checked
				{
					while (this.State == ModBase.LoadState.Loading)
					{
						if (LoaderToSyncProgress != null)
						{
							NewLateBinding.LateSet(LoaderToSyncProgress, null, "Progress", new object[]
							{
								this.Progress
							}, null, null);
						}
						Thread.Sleep(0xA);
						Timeout -= 0xA;
						if (Timeout < 0)
						{
							throw new TimeoutException(TimeoutMessage);
						}
					}
					if (this.State == ModBase.LoadState.Finished)
					{
						return;
					}
					if (this.State == ModBase.LoadState.Aborted)
					{
						throw new OperationCanceledException("加载器执行已中断。");
					}
					if (Information.IsNothing(this.Error))
					{
						throw new Exception("未知错误！");
					}
					throw this.Error;
				}
			}

			// Token: 0x06000762 RID: 1890 RVA: 0x00036050 File Offset: 0x00034250
			public override bool Equals(object obj)
			{
				ModLoader.LoaderBase<InputType> loaderBase = obj as ModLoader.LoaderBase<InputType>;
				return loaderBase != null && this.Uuid == loaderBase.Uuid;
			}

			// Token: 0x04000377 RID: 887
			public int Uuid;

			// Token: 0x04000378 RID: 888
			public string Name;

			// Token: 0x04000379 RID: 889
			public Type Type;

			// Token: 0x0400037A RID: 890
			public readonly object LockState;

			// Token: 0x0400037B RID: 891
			public object Parent;

			// Token: 0x0400037C RID: 892
			private ModBase.LoadState _State;

			// Token: 0x0400037D RID: 893
			private MyLoading.MyLoadingState _LoadingState;

			// Token: 0x0400037E RID: 894
			public ModLoader.LoaderStateDelegate OnStateChanged;

			// Token: 0x0400037F RID: 895
			public bool OnStateChangedRunInUi;

			// Token: 0x04000382 RID: 898
			public bool Block;

			// Token: 0x04000383 RID: 899
			public bool Show;

			// Token: 0x04000384 RID: 900
			private double _Progress;
		}

		// Token: 0x020000BA RID: 186
		public class LoaderTask<InputType, OutputType> : ModLoader.LoaderBase<InputType>
		{
			// Token: 0x06000765 RID: 1893 RVA: 0x000062D9 File Offset: 0x000044D9
			public override void Start(InputType Input = default(InputType), bool IsForceRestart = false)
			{
				this.StartReal(Input, false, IsForceRestart);
			}

			// Token: 0x06000766 RID: 1894 RVA: 0x000360BC File Offset: 0x000342BC
			private void StartReal(InputType Input, bool IsRefreshRestart, bool IsForceRestart)
			{
				try
				{
					if (Input == null && this.InputDelegate != null)
					{
						ModBase.RunInUiWait(delegate()
						{
							Input = this.InputDelegate();
						});
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "加载输入获取失败（" + this.Name + "）", ModBase.LogLevel.Hint, "出现错误");
					base.Error = ex;
					object lockState = this.LockState;
					ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
					lock (lockState)
					{
						base.State = ModBase.LoadState.Failed;
					}
					return;
				}
				if (IsForceRestart || Input == null || !Input.Equals(this.Input) || (base.State != ModBase.LoadState.Loading && base.State != ModBase.LoadState.Finished) || (this.ReloadTimeout != -1 && checked(ModBase.GetTimeTick() - this.LastFinishedTime) >= (long)this.ReloadTimeout))
				{
					this.Input = Input;
					this.IsAborted = false;
					ref int ptr = ref this.StartId;
					this.StartId = checked(ptr + 1);
					object lockState2 = this.LockState;
					ObjectFlowControl.CheckForSyncLockOnValueType(lockState2);
					lock (lockState2)
					{
						base.State = ModBase.LoadState.Loading;
					}
					int MyStartId = this.StartId;
					ModBase.RunInNewThread(delegate
					{
						try
						{
							this.IsForceRestart = IsForceRestart;
							this.LoadDelegate(this);
							if (MyStartId == this.StartId && !this.IsAborted)
							{
								this.State = ModBase.LoadState.Finished;
							}
						}
						catch (Exception ex2)
						{
							if (MyStartId == this.StartId && !this.IsAborted)
							{
								ModBase.Log(ex2, "加载线程 " + this.Name + " 发生运行时错误", ModBase.LogLevel.Developer, "出现错误");
								this.Error = ex2;
								this.State = ModBase.LoadState.Failed;
							}
						}
						finally
						{
							if (MyStartId == this.StartId && !this.IsAborted)
							{
								this.LastFinishedTime = ModBase.GetTimeTick();
							}
						}
					}, this.Name, this.ThreadPriority);
				}
			}

			// Token: 0x06000767 RID: 1895 RVA: 0x000062E4 File Offset: 0x000044E4
			public override void Abort()
			{
				base.State = ModBase.LoadState.Aborted;
				this.IsAborted = true;
				this.Input = default(InputType);
			}

			// Token: 0x06000768 RID: 1896 RVA: 0x0003627C File Offset: 0x0003447C
			public LoaderTask()
			{
				this.IsAborted = false;
				this.StartId = 0;
				this.ReloadTimeout = -1;
				this.LastFinishedTime = 0L;
				this.Input = default(InputType);
				this.Output = default(OutputType);
				this.IsForceRestart = false;
			}

			// Token: 0x06000769 RID: 1897 RVA: 0x000362D4 File Offset: 0x000344D4
			public LoaderTask(string Name, ModLoader.LoaderTask<InputType, OutputType>.LoadDelegateSub LoadDelegate, ModLoader.LoaderTask<InputType, OutputType>.InputDelegateSub InputDelegate = null, ThreadPriority Priority = ThreadPriority.Normal)
			{
				this.IsAborted = false;
				this.StartId = 0;
				this.ReloadTimeout = -1;
				this.LastFinishedTime = 0L;
				this.Input = default(InputType);
				this.Output = default(OutputType);
				this.IsForceRestart = false;
				this.Name = Name;
				this.LoadDelegate = LoadDelegate;
				this.InputDelegate = InputDelegate;
				this.ThreadPriority = Priority;
			}

			// Token: 0x04000388 RID: 904
			protected internal ThreadPriority ThreadPriority;

			// Token: 0x04000389 RID: 905
			protected internal ModLoader.LoaderTask<InputType, OutputType>.LoadDelegateSub LoadDelegate;

			// Token: 0x0400038A RID: 906
			protected internal ModLoader.LoaderTask<InputType, OutputType>.InputDelegateSub InputDelegate;

			// Token: 0x0400038B RID: 907
			public bool IsAborted;

			// Token: 0x0400038C RID: 908
			public int StartId;

			// Token: 0x0400038D RID: 909
			public int ReloadTimeout;

			// Token: 0x0400038E RID: 910
			public long LastFinishedTime;

			// Token: 0x0400038F RID: 911
			public InputType Input;

			// Token: 0x04000390 RID: 912
			public OutputType Output;

			// Token: 0x04000391 RID: 913
			public bool IsForceRestart;

			// Token: 0x020000BB RID: 187
			// (Invoke) Token: 0x0600076D RID: 1901
			public delegate void LoadDelegateSub(ModLoader.LoaderTask<InputType, OutputType> Input);

			// Token: 0x020000BC RID: 188
			// (Invoke) Token: 0x06000771 RID: 1905
			public delegate InputType InputDelegateSub();
		}

		// Token: 0x020000BE RID: 190
		public class LoaderCombo<InputType> : ModLoader.LoaderBase<InputType>
		{
			// Token: 0x1700014B RID: 331
			// (get) Token: 0x06000775 RID: 1909 RVA: 0x00036468 File Offset: 0x00034668
			// (set) Token: 0x06000776 RID: 1910 RVA: 0x00006318 File Offset: 0x00004518
			public override double Progress
			{
				get
				{
					ModBase.LoadState state = base.State;
					double result;
					if (state != ModBase.LoadState.Waiting)
					{
						if (state != ModBase.LoadState.Loading)
						{
							result = 1.0;
						}
						else
						{
							double num = 0.0;
							double num2 = 0.0;
							try
							{
								foreach (object obj in this.Loaders)
								{
									object objectValue = RuntimeHelpers.GetObjectValue(obj);
									num = Conversions.ToDouble(Operators.AddObject(num, NewLateBinding.LateGet(objectValue, null, "ProgressWeight", new object[0], null, null, null)));
									num2 = Conversions.ToDouble(Operators.AddObject(num2, Operators.MultiplyObject(NewLateBinding.LateGet(objectValue, null, "ProgressWeight", new object[0], null, null, null), NewLateBinding.LateGet(objectValue, null, "Progress", new object[0], null, null, null))));
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
							if (num == 0.0)
							{
								result = 0.0;
							}
							else
							{
								result = num2 / num;
							}
						}
					}
					else
					{
						result = 0.0;
					}
					return result;
				}
				set
				{
					throw new Exception("多重加载器不支持设置进度");
				}
			}

			// Token: 0x06000777 RID: 1911 RVA: 0x0003658C File Offset: 0x0003478C
			public LoaderCombo(string Name, ArrayList Loaders)
			{
				this.Loaders = new ArrayList();
				this.Loaders.Clear();
				try
				{
					foreach (object obj in Loaders)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(obj);
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
						{
							this.Loaders.Add(RuntimeHelpers.GetObjectValue(objectValue));
							NewLateBinding.LateSet(objectValue, null, "OnStateChanged", new object[]
							{
								new ModLoader.LoaderStateDelegate(this.SubTaskStateChanged)
							}, null, null);
							NewLateBinding.LateSet(objectValue, null, "OnStateChangedRunInUi", new object[]
							{
								false
							}, null, null);
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
				this.InitParent(null);
				this.Name = Name;
			}

			// Token: 0x06000778 RID: 1912 RVA: 0x00036668 File Offset: 0x00034868
			public override void InitParent(object Parent)
			{
				this.Parent = RuntimeHelpers.GetObjectValue(Parent);
				try
				{
					foreach (object obj in this.Loaders)
					{
						NewLateBinding.LateCall(RuntimeHelpers.GetObjectValue(obj), null, "InitParent", new object[]
						{
							this
						}, null, null, null, true);
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

			// Token: 0x06000779 RID: 1913 RVA: 0x000366E4 File Offset: 0x000348E4
			public override void Start(InputType Input = default(InputType), bool IsForceRestart = false)
			{
				if (IsForceRestart)
				{
					throw new Exception("此加载器尚不支持强制加载");
				}
				bool flag = base.State == ModBase.LoadState.Finished;
				object lockState = this.LockState;
				ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
				lock (lockState)
				{
					if (base.State == ModBase.LoadState.Loading)
					{
						return;
					}
					base.State = ModBase.LoadState.Loading;
				}
				this.Input = Input;
				if (flag)
				{
					try
					{
						foreach (object obj in this.Loaders)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(obj);
							if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue, null, "State", new object[0], null, null, null), ModBase.LoadState.Finished, true))
							{
								NewLateBinding.LateSet(objectValue, null, "State", new object[]
								{
									ModBase.LoadState.Waiting
								}, null, null);
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
				this.Update();
			}

			// Token: 0x0600077A RID: 1914 RVA: 0x000367E8 File Offset: 0x000349E8
			public override void Abort()
			{
				object lockState = this.LockState;
				ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
				lock (lockState)
				{
					if (base.State != ModBase.LoadState.Loading && base.State != ModBase.LoadState.Waiting)
					{
						return;
					}
					base.State = ModBase.LoadState.Aborted;
				}
				ModBase.RunInThread(delegate
				{
					try
					{
						foreach (object obj in this.Loaders)
						{
							NewLateBinding.LateCall(RuntimeHelpers.GetObjectValue(obj), null, "Abort", new object[0], null, null, null, true);
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
					object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
					ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
					lock (loaderTaskbarLock)
					{
						if (ModLoader.LoaderTaskbar.Contains(this))
						{
							ModLoader.LoaderTaskbar.Remove(this);
						}
					}
				});
			}

			// Token: 0x0600077B RID: 1915 RVA: 0x00036854 File Offset: 0x00034A54
			private void SubTaskStateChanged(object Loader)
			{
				object left = NewLateBinding.LateGet(Loader, null, "State", new object[0], null, null, null);
				if (!Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Loading, true) && !Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Waiting, true))
				{
					if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Finished, true))
					{
						this.Update();
						return;
					}
					if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Aborted, true))
					{
						this.Abort();
						return;
					}
					object lockState = this.LockState;
					ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
					lock (lockState)
					{
						if (base.State >= ModBase.LoadState.Finished)
						{
							return;
						}
						base.Error = new Exception(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, null, "Name", new object[0], null, null, null), "失败")), (Exception)NewLateBinding.LateGet(Loader, null, "Error", new object[0], null, null, null));
						base.State = (ModBase.LoadState)Conversions.ToInteger(NewLateBinding.LateGet(Loader, null, "State", new object[0], null, null, null));
					}
					try
					{
						foreach (object obj in this.Loaders)
						{
							Loader = RuntimeHelpers.GetObjectValue(obj);
							NewLateBinding.LateCall(Loader, null, "Abort", new object[0], null, null, null, true);
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
					ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
				}
			}

			// Token: 0x0600077C RID: 1916 RVA: 0x000369E0 File Offset: 0x00034BE0
			private void Update()
			{
				if (Conversions.ToBoolean(ModBase._BaseRule.Get("SystemDebugDelay", null)))
				{
					Thread.Sleep(ModBase.RandomInteger(0x32, 0x12C));
				}
				if (base.State < ModBase.LoadState.Finished)
				{
					bool flag = true;
					bool flag2 = false;
					object obj = this.Input;
					try
					{
						foreach (object obj2 in this.Loaders)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(obj2);
							object left = NewLateBinding.LateGet(objectValue, null, "State", new object[0], null, null, null);
							if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Finished, true))
							{
								if (objectValue.GetType().Name.StartsWith("LoaderTask"))
								{
									obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "Output", new object[0], null, null, null));
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Loading, true))
							{
								flag = false;
								flag2 = true;
							}
							else if (Operators.ConditionalCompareObjectEqual(left, ModBase.LoadState.Waiting, true))
							{
								flag = false;
								if (!flag2)
								{
									if (obj != null && obj.GetType() == NewLateBinding.LateGet(objectValue, null, "Type", new object[0], null, null, null))
									{
										object[] array;
										bool[] array2;
										NewLateBinding.LateCall(objectValue, null, "Start", array = new object[]
										{
											obj
										}, null, null, array2 = new bool[]
										{
											true
										}, true);
										if (array2[0])
										{
											obj = RuntimeHelpers.GetObjectValue(array[0]);
										}
									}
									else
									{
										NewLateBinding.LateCall(objectValue, null, "Start", new object[0], null, null, null, true);
									}
									if (Conversions.ToBoolean(NewLateBinding.LateGet(objectValue, null, "Block", new object[0], null, null, null)))
									{
										flag2 = true;
									}
								}
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
					if (flag)
					{
						base.State = ModBase.LoadState.Finished;
						ModMain.m_GetterFilter.BtnExtraDownload.ShowRefresh();
					}
				}
			}

			// Token: 0x0600077D RID: 1917 RVA: 0x00036BD4 File Offset: 0x00034DD4
			public static void GetLoaderList(object Loader, ref ArrayList List, bool RequireShow = true)
			{
				try
				{
					foreach (object obj in ((IEnumerable)NewLateBinding.LateGet(Loader, null, "Loaders", new object[0], null, null, null)))
					{
						object objectValue = RuntimeHelpers.GetObjectValue(obj);
						if (Conversions.ToBoolean(Conversions.ToBoolean(NewLateBinding.LateGet(objectValue, null, "Show", new object[0], null, null, null)) || !RequireShow))
						{
							List.Add(RuntimeHelpers.GetObjectValue(objectValue));
						}
						if (objectValue.GetType().Name.StartsWith("LoaderCombo"))
						{
							ModLoader.LoaderCombo<InputType>.GetLoaderList(RuntimeHelpers.GetObjectValue(objectValue), ref List, true);
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

			// Token: 0x0600077E RID: 1918 RVA: 0x00006324 File Offset: 0x00004524
			public void GetLoaderList(ref ArrayList List, bool RequireShow = true)
			{
				ModLoader.LoaderCombo<InputType>.GetLoaderList(this, ref List, RequireShow);
			}

			// Token: 0x0600077F RID: 1919 RVA: 0x00036CA0 File Offset: 0x00034EA0
			public ArrayList GetLoaderList(bool RequireShow = true)
			{
				ArrayList result = new ArrayList();
				this.GetLoaderList(ref result, RequireShow);
				return result;
			}

			// Token: 0x04000396 RID: 918
			public ArrayList Loaders;

			// Token: 0x04000397 RID: 919
			public InputType Input;
		}

		// Token: 0x020000BF RID: 191
		private struct LoaderFolderDictionaryEntry
		{
			// Token: 0x06000781 RID: 1921 RVA: 0x00036D70 File Offset: 0x00034F70
			public override bool Equals(object obj)
			{
				bool result;
				if (!(obj is ModLoader.LoaderFolderDictionaryEntry))
				{
					result = false;
				}
				else
				{
					ModLoader.LoaderFolderDictionaryEntry loaderFolderDictionaryEntry = (ModLoader.LoaderFolderDictionaryEntry)obj;
					result = (EqualityComparer<DateTime?>.Default.Equals(this.LastCheckTime, loaderFolderDictionaryEntry.LastCheckTime) && Operators.CompareString(this.FolderPath, loaderFolderDictionaryEntry.FolderPath, true) == 0);
				}
				return result;
			}

			// Token: 0x04000398 RID: 920
			public DateTime? LastCheckTime;

			// Token: 0x04000399 RID: 921
			public string FolderPath;
		}

		// Token: 0x020000C0 RID: 192
		public enum LoaderFolderRunType
		{
			// Token: 0x0400039B RID: 923
			RunOnUpdated,
			// Token: 0x0400039C RID: 924
			ForceRun,
			// Token: 0x0400039D RID: 925
			UpdateOnly
		}
	}
}
