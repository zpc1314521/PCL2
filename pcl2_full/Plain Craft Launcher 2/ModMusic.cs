using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using NAudio.Wave;
using PCL.My;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Controls;

namespace PCL
{
	// Token: 0x0200005B RID: 91
	[StandardModule]
	public sealed class ModMusic
	{
		// Token: 0x06000287 RID: 647 RVA: 0x000039B1 File Offset: 0x00001BB1
		// Note: this type is marked as 'beforefieldinit'.
		static ModMusic()
		{
			ModMusic.m_PredicateVal = null;
			ModMusic.m_StructVal = null;
			ModMusic.resolverVal = null;
			ModMusic.collectionVal = "";
		}

		// Token: 0x06000288 RID: 648 RVA: 0x000199E0 File Offset: 0x00017BE0
		private static void MusicListInit(bool ForceReload, string IgnoreFirst = "")
		{
			if (ForceReload)
			{
				ModMusic.m_StructVal = null;
			}
			try
			{
				if (ModMusic.m_StructVal == null)
				{
					ModMusic.m_StructVal = new List<string>();
					Directory.CreateDirectory(ModBase.Path + "PCL\\Musics\\");
					try
					{
						foreach (string text in MyWpfExtension.RunFactory().FileSystem.GetFiles(ModBase.Path + "PCL\\Musics\\", Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, new string[]
						{
							"*.*"
						}))
						{
							string left = text.Split(new char[]
							{
								'.'
							}).Last<string>().ToLower();
							if (Operators.CompareString(left, "ini", true) != 0 && Operators.CompareString(left, "jpg", true) != 0 && Operators.CompareString(left, "txt", true) != 0 && Operators.CompareString(left, "cfg", true) != 0 && Operators.CompareString(left, "png", true) != 0)
							{
								ModMusic.m_StructVal.Add(text);
							}
						}
					}
					finally
					{
						IEnumerator<string> enumerator;
						if (enumerator != null)
						{
							enumerator.Dispose();
						}
					}
				}
				ModMusic.m_PredicateVal = (List<string>)ModBase.RandomChaos<string>(new List<string>(ModMusic.m_StructVal));
				if (Operators.CompareString(IgnoreFirst, "", true) != 0 && ModMusic.m_PredicateVal.Count != 0 && Operators.CompareString(ModMusic.m_PredicateVal[0], IgnoreFirst, true) == 0)
				{
					ModMusic.m_PredicateVal.RemoveAt(0);
					ModMusic.m_PredicateVal.Add(IgnoreFirst);
				}
			}
			catch (Exception ex)
			{
				ModBase.Log(ex, "初始化音乐列表失败", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00019B90 File Offset: 0x00017D90
		private static string DequeueNextMusicAddress()
		{
			if (ModMusic.m_StructVal == null)
			{
				ModMusic.MusicListInit(false, "");
			}
			if (ModMusic.m_StructVal.Count == 0)
			{
				throw new Exception("在没有音乐时尝试获取音乐路径");
			}
			string text = ModMusic.m_PredicateVal[0];
			ModMusic.m_PredicateVal.RemoveAt(0);
			if (ModMusic.m_PredicateVal.Count == 0)
			{
				ModMusic.MusicListInit(false, text);
			}
			return text;
		}

		// Token: 0x0600028A RID: 650 RVA: 0x000039CF File Offset: 0x00001BCF
		private static void MusicRefreshUI()
		{
			ModBase.RunInUi((ModMusic._Closure$__.$I5-0 == null) ? (ModMusic._Closure$__.$I5-0 = delegate()
			{
				try
				{
					if (ModMusic.m_StructVal.Count == 0)
					{
						ModMain.m_GetterFilter.BtnExtraMusic.Show = false;
					}
					else
					{
						ModMain.m_GetterFilter.BtnExtraMusic.Show = true;
						string text = "正在播放：" + ModBase.GetFileNameWithoutExtentionFromPath(ModMusic.collectionVal);
						if (ModMusic.SetupContainer() == ModMusic.MusicStates.Pause)
						{
							ModMain.m_GetterFilter.BtnExtraMusic.Logo = "M803.904 463.936a55.168 55.168 0 0 1 0 96.128l-463.616 264.448C302.848 845.888 256 819.136 256 776.448V247.616c0-42.752 46.848-69.44 84.288-48.064l463.616 264.384z";
							ModMain.m_GetterFilter.BtnExtraMusic.AwakeFactory(0.8);
							if (ModMusic.m_StructVal.Count > 1)
							{
								text += "\r\n左键播放，右键播放下一曲。";
							}
						}
						else
						{
							ModMain.m_GetterFilter.BtnExtraMusic.Logo = "M348.293565 716.53287V254.797913c0-41.672348 28.004174-78.358261 68.919652-90.37913L815.994435 40.826435c62.775652-18.610087 125.907478 26.579478 125.907478 89.933913v539.158261c8.013913 42.25113-8.94887 89.177043-47.014956 127.109565a232.848696 232.848696 0 0 1-170.785392 65.758609c-61.885217-2.938435-111.081739-33.435826-129.113043-80.050087-18.031304-46.614261-2.137043-102.177391 41.672348-145.853218a232.848696 232.848696 0 0 1 170.785391-65.80313c21.014261 1.024 40.514783 5.164522 57.878261 12.065391V233.338435c0-12.109913-10.551652-20.034783-20.569044-20.034783a24.620522 24.620522 0 0 0-5.787826 0.934957L439.785739 338.18713a19.545043 19.545043 0 0 0-14.825739 19.144348v438.984348H423.846957c11.53113 43.987478-5.164522 94.208-45.412174 134.322087a232.848696 232.848696 0 0 1-170.785392 65.758609c-61.885217-2.938435-111.081739-33.435826-129.113043-80.050087-18.031304-46.614261-2.137043-102.177391 41.672348-145.853218a232.848696 232.848696 0 0 1 170.785391-65.80313c20.791652 1.024 40.069565 5.075478 57.299478 11.842783z";
							ModMain.m_GetterFilter.BtnExtraMusic.AwakeFactory(1.0);
							if (ModMusic.m_StructVal.Count > 1)
							{
								text += "\r\n左键暂停，右键播放下一曲。";
							}
						}
						ModMain.m_GetterFilter.BtnExtraMusic.ToolTip = text;
						ToolTipService.SetVerticalOffset(ModMain.m_GetterFilter.BtnExtraMusic, (double)(text.Contains("\n") ? 0xA : 0x10));
					}
					if (ModMain.processFilter != null)
					{
						ModMain.processFilter.MusicRefreshUI();
					}
				}
				catch (Exception ex)
				{
					ModBase.Log(ex, "刷新背景音乐 UI 失败", ModBase.LogLevel.Feedback, "出现错误");
				}
			}) : ModMusic._Closure$__.$I5-0, false);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00019BF4 File Offset: 0x00017DF4
		public static void MusicControlPause()
		{
			if (ModMusic.resolverVal == null)
			{
				ModMain.Hint("音乐播放尚未开始！", ModMain.HintType.Critical, true);
				return;
			}
			ModMusic.MusicStates musicStates = ModMusic.SetupContainer();
			if (musicStates == ModMusic.MusicStates.Play)
			{
				ModMusic.MusicPause();
				return;
			}
			if (musicStates == ModMusic.MusicStates.Pause)
			{
				ModMusic.MusicResume();
				return;
			}
			ModMain.Hint("音乐目前为停止状态！", ModMain.HintType.Critical, true);
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00019C40 File Offset: 0x00017E40
		public static void MusicControlNext()
		{
			if (ModMusic.m_StructVal.Count == 1)
			{
				ModMain.Hint("播放列表中仅有一首歌曲！", ModMain.HintType.Info, true);
				return;
			}
			string text = ModMusic.DequeueNextMusicAddress();
			ModMusic.MusicStartPlay(text, false);
			ModMain.Hint("正在播放：" + ModBase.GetFileNameFromPath(text), ModMain.HintType.Finish, true);
			ModMusic.MusicRefreshUI();
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00019C90 File Offset: 0x00017E90
		public static ModMusic.MusicStates SetupContainer()
		{
			ModMusic.MusicStates result;
			if (ModMusic.resolverVal == null)
			{
				result = ModMusic.MusicStates.Stop;
			}
			else
			{
				object left = NewLateBinding.LateGet(ModMusic.resolverVal, null, "PlaybackState", new object[0], null, null, null);
				if (Operators.ConditionalCompareObjectEqual(left, 0, true))
				{
					result = ModMusic.MusicStates.Stop;
				}
				else if (Operators.ConditionalCompareObjectEqual(left, 2, true))
				{
					result = ModMusic.MusicStates.Pause;
				}
				else
				{
					result = ModMusic.MusicStates.Play;
				}
			}
			return result;
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00019CEC File Offset: 0x00017EEC
		public static void MusicRefreshPlay(bool ShowHint, bool IsFirstLoad = false)
		{
			try
			{
				ModMusic.MusicListInit(true, "");
				if (ModMusic.m_StructVal.Count == 0)
				{
					if (ModMusic.resolverVal == null)
					{
						if (ShowHint)
						{
							ModMain.Hint("未检测到可用的背景音乐！", ModMain.HintType.Critical, true);
						}
					}
					else
					{
						ModMusic.resolverVal = null;
						if (ShowHint)
						{
							ModMain.Hint("背景音乐已清除！", ModMain.HintType.Finish, true);
						}
					}
				}
				else
				{
					string text = ModMusic.DequeueNextMusicAddress();
					try
					{
						ModMusic.MusicStartPlay(text, IsFirstLoad);
						if (ShowHint)
						{
							ModMain.Hint("背景音乐已刷新：" + ModBase.GetFileNameFromPath(text), ModMain.HintType.Finish, false);
						}
					}
					catch (Exception ex)
					{
					}
				}
				ModMusic.MusicRefreshUI();
			}
			catch (Exception ex2)
			{
				ModBase.Log(ex2, "刷新背景音乐播放失败", ModBase.LogLevel.Feedback, "出现错误");
			}
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00019DB8 File Offset: 0x00017FB8
		private static void MusicStartPlay(string Address, bool IsFirstLoad = false)
		{
			ModBase.Log("[Music] 播放开始：" + Address, ModBase.LogLevel.Normal, "出现错误");
			ModBase.RunInNewThread(delegate
			{
				ModMusic.MusicLoop(Address, IsFirstLoad);
			}, "Music", ThreadPriority.BelowNormal);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00019E0C File Offset: 0x0001800C
		public static bool MusicPause()
		{
			bool result;
			if (ModMusic.SetupContainer() == ModMusic.MusicStates.Play)
			{
				ModBase.RunInThread((ModMusic._Closure$__.$I13-0 == null) ? (ModMusic._Closure$__.$I13-0 = delegate()
				{
					NewLateBinding.LateCall(ModMusic.resolverVal, null, "Pause", new object[0], null, null, null, true);
					ModMusic.MusicRefreshUI();
				}) : ModMusic._Closure$__.$I13-0);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00019E54 File Offset: 0x00018054
		public static bool MusicResume()
		{
			bool result;
			if (ModMusic.SetupContainer() == ModMusic.MusicStates.Pause)
			{
				ModBase.RunInThread((ModMusic._Closure$__.$I14-0 == null) ? (ModMusic._Closure$__.$I14-0 = delegate()
				{
					NewLateBinding.LateCall(ModMusic.resolverVal, null, "Play", new object[0], null, null, null, true);
					ModMusic.MusicRefreshUI();
				}) : ModMusic._Closure$__.$I14-0);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00019E9C File Offset: 0x0001809C
		private static void MusicLoop(string Address, bool IsFirstLoad = false)
		{
			ModMusic.collectionVal = Address;
			WaveOut waveOut = null;
			WaveStream waveStream = null;
			try
			{
				waveOut = new WaveOut();
				ModMusic.resolverVal = waveOut;
				waveStream = new AudioFileReader(Address);
				waveOut.Init(waveStream);
				waveOut.Play();
				if (Conversions.ToBoolean(IsFirstLoad && Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("UiMusicAuto", null)))))
				{
					waveOut.Pause();
				}
				ModMusic.MusicRefreshUI();
				while (waveOut.Equals(RuntimeHelpers.GetObjectValue(ModMusic.resolverVal)) && waveOut.PlaybackState != PlaybackState.Stopped)
				{
					waveOut.Volume = Conversions.ToSingle(Operators.DivideObject(ModBase._BaseRule.Get("UiMusicVolume", null), 0x3E8));
					Thread.Sleep(0x32);
				}
				if (waveOut.PlaybackState == PlaybackState.Stopped && ModMusic.m_StructVal.Count > 0)
				{
					ModMusic.MusicStartPlay(ModMusic.DequeueNextMusicAddress(), false);
				}
			}
			catch (Exception ex)
			{
				if (!ex.Message.Contains("Got a frame at sample rate") && !ex.Message.Contains("does not support changes to"))
				{
					if (!Address.ToLower().EndsWith(".wav") && !Address.ToLower().EndsWith(".mp3") && !Address.ToLower().EndsWith(".flac"))
					{
						ModMain.Hint("播放音乐失败（" + ModBase.GetFileNameFromPath(Address) + "）：PCL2 可能不支持此音乐格式，请将格式转换为 .wav、.mp3 或 .flac 后再试", ModMain.HintType.Critical, true);
					}
					else
					{
						ModBase.Log(ex, "播放音乐失败（" + ModBase.GetFileNameFromPath(Address) + "）", ModBase.LogLevel.Hint, "出现错误");
					}
				}
				else
				{
					ModMain.Hint("播放音乐失败（" + ModBase.GetFileNameFromPath(Address) + "）：PCL2 不支持播放音频属性在中途发生变化的音乐", ModMain.HintType.Critical, true);
				}
				ModBase.Log(ex, "播放音乐失败（" + Address + "）", ModBase.LogLevel.Developer, "出现错误");
				if (ModMusic.m_StructVal.Count > 1)
				{
					Thread.Sleep(0x3E8);
					ModMusic.MusicStartPlay(ModMusic.DequeueNextMusicAddress(), false);
				}
			}
			finally
			{
				if (waveOut != null)
				{
					waveOut.Dispose();
				}
				if (waveStream != null)
				{
					waveStream.Dispose();
				}
				ModMusic.MusicRefreshUI();
			}
		}

		// Token: 0x0400013A RID: 314
		public static List<string> m_PredicateVal;

		// Token: 0x0400013B RID: 315
		public static List<string> m_StructVal;

		// Token: 0x0400013C RID: 316
		public static WaveOut resolverVal;

		// Token: 0x0400013D RID: 317
		private static string collectionVal;

		// Token: 0x0200005C RID: 92
		public enum MusicStates
		{
			// Token: 0x0400013F RID: 319
			Stop,
			// Token: 0x04000140 RID: 320
			Play,
			// Token: 0x04000141 RID: 321
			Pause
		}
	}
}
