using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace PCL
{
	// Token: 0x020000C1 RID: 193
	[StandardModule]
	public sealed class ModNet
	{
		// Token: 0x06000782 RID: 1922 RVA: 0x00036DC4 File Offset: 0x00034FC4
		// Note: this type is marked as 'beforefieldinit'.
		static ModNet()
		{
			ModNet._ServerModel = 0x100000L;
			ModNet._ConfigModel = -1L;
			ModNet._ConnectionModel = -1L;
			ModNet.m_ListModel = RuntimeHelpers.GetObjectValue(new object());
			ModNet.m_IdentifierModel = 0;
			ModNet._PolicyModel = RuntimeHelpers.GetObjectValue(new object());
			ModNet._ClientModel = new ModNet.NetManagerClass();
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x00036E2C File Offset: 0x0003502C
		public static string NetGetCodeByClient(string Url, Encoding Encoding, string Accept = "application/json, text/javascript, */*; q=0.01")
		{
			int num = 0;
			Exception ex = null;
			long timeTick = ModBase.GetTimeTick();
			checked
			{
				string result;
				try
				{
					IL_0A:
					if (num != 0)
					{
						if (num != 1)
						{
							if (ModBase.GetTimeTick() - timeTick <= 0x157CL)
							{
								throw ex;
							}
							Thread.Sleep(0x1F4);
							result = ModNet.NetGetCodeByClient(Url, Encoding, 0xFA0, Accept);
						}
						else
						{
							Thread.Sleep(0x1F4);
							result = ModNet.NetGetCodeByClient(Url, Encoding, 0x7530, Accept);
						}
					}
					else
					{
						result = ModNet.NetGetCodeByClient(Url, Encoding, 0x2710, Accept);
					}
				}
				catch (Exception ex2)
				{
					if (num == 0)
					{
						ex = ex2;
						num++;
						goto IL_0A;
					}
					if (num != 1)
					{
						throw;
					}
					num++;
					goto IL_0A;
				}
				return result;
			}
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x00036EE0 File Offset: 0x000350E0
		public static string NetGetCodeByClient(string Url, Encoding Encoding, int Timeout, string Accept)
		{
			Url = Conversions.ToString(ModBase.GetCdnTypeA(Url));
			ModBase.Log("[Net] 获取客户端网络结果：" + Url + "，最大超时 " + Conversions.ToString(Timeout), ModBase.LogLevel.Normal, "出现错误");
			HttpWebResponse httpWebResponse = null;
			Stream stream = null;
			string result;
			try
			{
				CookieWebClient cookieWebClient = new CookieWebClient();
				cookieWebClient.Encoding = Encoding;
				cookieWebClient.requestVal = Timeout;
				cookieWebClient.Headers["User-Agent"] = "PCL2/2.2.3.0 Mozilla/5.0 AppleWebKit/537.36 Chrome/63.0.3239.132 Safari/537.36";
				cookieWebClient.Headers["Accept"] = Accept;
				cookieWebClient.Headers["Accept-Language"] = "en-US,en;q=0.5";
				cookieWebClient.Headers["X-Requested-With"] = "XMLHttpRequest";
				cookieWebClient.Headers["Referer"] = "http://" + Conversions.ToString(0xEA) + ".pcl2.server/";
				result = cookieWebClient.DownloadString(Url);
			}
			catch (Exception ex)
			{
				if (ex.GetType().Equals(typeof(WebException)) && ((WebException)ex).Status == WebExceptionStatus.Timeout)
				{
					throw new TimeoutException("连接服务器超时（" + Url + "）", ex);
				}
				throw new WebException(string.Concat(new string[]
				{
					"获取结果失败，",
					ex.Message,
					"（",
					Url,
					"）"
				}), ex);
			}
			finally
			{
				if (!Information.IsNothing(stream))
				{
					stream.Dispose();
				}
				if (!Information.IsNothing(httpWebResponse))
				{
					httpWebResponse.Dispose();
				}
			}
			return result;
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x00037084 File Offset: 0x00035284
		public static object NetGetCodeByRequestRetry(string Url, Encoding Encode = null, string Accept = "", bool IsJson = false)
		{
			int num = 0;
			Exception ex = null;
			long timeTick = ModBase.GetTimeTick();
			checked
			{
				object result;
				try
				{
					IL_0A:
					if (num != 0)
					{
						if (num != 1)
						{
							if (ModBase.GetTimeTick() - timeTick <= 0x157CL)
							{
								throw ex;
							}
							Thread.Sleep(0x1F4);
							result = ModNet.NetGetCodeRequest(Url, Encode, 0xFA0, IsJson, Accept);
						}
						else
						{
							Thread.Sleep(0x1F4);
							result = ModNet.NetGetCodeRequest(Url, Encode, 0x7530, IsJson, Accept);
						}
					}
					else
					{
						result = ModNet.NetGetCodeRequest(Url, Encode, 0x2710, IsJson, Accept);
					}
				}
				catch (Exception ex2)
				{
					if (num == 0)
					{
						ex = ex2;
						num++;
						goto IL_0A;
					}
					if (num != 1)
					{
						throw;
					}
					num++;
					goto IL_0A;
				}
				return result;
			}
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x0003713C File Offset: 0x0003533C
		public static object NetGetCodeByRequestMuity(string Url, Encoding Encode = null, string Accept = "", bool IsJson = false)
		{
			ModNet._Closure$__5-0 CS$<>8__locals1 = new ModNet._Closure$__5-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_Url = Url;
			CS$<>8__locals1.$VB$Local_Encode = Encode;
			CS$<>8__locals1.$VB$Local_Accept = Accept;
			CS$<>8__locals1.$VB$Local_IsJson = IsJson;
			List<Thread> list = new List<Thread>();
			CS$<>8__locals1.$VB$Local_RequestResult = null;
			CS$<>8__locals1.$VB$Local_RequestEx = null;
			CS$<>8__locals1.$VB$Local_FailCount = 0;
			int num = 1;
			checked
			{
				do
				{
					Thread thread = new Thread((CS$<>8__locals1.$I0 == null) ? (CS$<>8__locals1.$I0 = delegate()
					{
						try
						{
							CS$<>8__locals1.$VB$Local_RequestResult = RuntimeHelpers.GetObjectValue(ModNet.NetGetCodeRequest(CS$<>8__locals1.$VB$Local_Url, CS$<>8__locals1.$VB$Local_Encode, 0x7530, CS$<>8__locals1.$VB$Local_IsJson, CS$<>8__locals1.$VB$Local_Accept));
						}
						catch (Exception $VB$Local_RequestEx)
						{
							CS$<>8__locals1.$VB$Local_FailCount++;
							CS$<>8__locals1.$VB$Local_RequestEx = $VB$Local_RequestEx;
						}
					}) : CS$<>8__locals1.$I0);
					thread.Start();
					list.Add(thread);
					Thread.Sleep(0x14);
					num++;
				}
				while (num <= 5);
				while (CS$<>8__locals1.$VB$Local_RequestResult == null)
				{
					if (CS$<>8__locals1.$VB$Local_FailCount == 5)
					{
						Block_5:
						try
						{
							try
							{
								foreach (Thread thread2 in list)
								{
									if (thread2.IsAlive)
									{
										thread2.Abort();
									}
								}
							}
							finally
							{
								List<Thread>.Enumerator enumerator;
								((IDisposable)enumerator).Dispose();
							}
						}
						catch (Exception ex)
						{
						}
						throw CS$<>8__locals1.$VB$Local_RequestEx;
					}
					Thread.Sleep(0x14);
				}
				try
				{
					try
					{
						foreach (Thread thread3 in list)
						{
							if (thread3.IsAlive)
							{
								thread3.Abort();
							}
						}
					}
					finally
					{
						List<Thread>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
					goto IL_147;
				}
				catch (Exception ex2)
				{
					goto IL_147;
				}
				goto Block_5;
				IL_147:
				return CS$<>8__locals1.$VB$Local_RequestResult;
			}
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x000372CC File Offset: 0x000354CC
		private static object NetGetCodeRequest(string Url, Encoding Encode, int Timeout, bool IsJson, string Accept)
		{
			Url = Conversions.ToString(ModBase.GetCdnTypeA(Url));
			ModBase.Log("[Net] 获取网络结果：" + Url + "，最大超时 " + Conversions.ToString(Timeout), ModBase.LogLevel.Normal, "出现错误");
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
			object obj;
			try
			{
				if (Url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
				{
					httpWebRequest.ProtocolVersion = HttpVersion.Version10;
				}
				httpWebRequest.Timeout = Timeout;
				httpWebRequest.Accept = Accept;
				httpWebRequest.KeepAlive = false;
				httpWebRequest.UserAgent = "PCL2/2.2.3.0 Mozilla/5.0 AppleWebKit/537.36 Chrome/63.0.3239.132 Safari/537.36";
				httpWebRequest.Referer = "http://" + Conversions.ToString(0xEA) + ".pcl2.server/";
				using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
				{
					using (Stream responseStream = httpWebResponse.GetResponseStream())
					{
						responseStream.ReadTimeout = Timeout;
						byte[] array = new byte[0x4001];
						int i = responseStream.Read(array, 0, 0x4000);
						List<byte> list = new List<byte>();
						while (i > 0)
						{
							Thread.Sleep(6);
							if (i > 0)
							{
								list.AddRange(array.ToList<byte>().GetRange(0, i));
							}
							i = responseStream.Read(array, 0, 0x4000);
						}
						obj = ((Encode == null) ? ModBase.DecodeBytes(list.ToArray()) : Encode.GetString(list.ToArray()));
						if (IsJson)
						{
							obj = ModBase.GetJson(Conversions.ToString(obj));
						}
					}
				}
			}
			catch (Exception ex)
			{
				if (ex.GetType().Equals(typeof(WebException)) && ((WebException)ex).Status == WebExceptionStatus.Timeout)
				{
					throw new TimeoutException("连接服务器超时（" + Url + "）", ex);
				}
				throw new WebException(string.Concat(new string[]
				{
					"获取结果失败，",
					ex.Message,
					"（",
					Url,
					"）"
				}), ex);
			}
			finally
			{
				httpWebRequest.Abort();
			}
			return obj;
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x00037520 File Offset: 0x00035720
		public static string NetGetCodeByDownload(string Url, int Timeout = 0xAFC8, bool IsJson = false)
		{
			string text = string.Concat(new string[]
			{
				ModBase.m_GlobalRule,
				"Cache\\Code\\",
				Conversions.ToString(Url.GetHashCode()),
				"_",
				Conversions.ToString(ModBase.GetUuid())
			});
			ModNet.LoaderDownload loaderDownload = new ModNet.LoaderDownload("源码获取 " + Conversions.ToString(ModBase.GetUuid()) + "#", new List<ModNet.NetFile>
			{
				new ModNet.NetFile(new string[]
				{
					Url
				}, text, new ModBase.FileChecker(-1L, -1L, null, null, true, false)
				{
					m_DefinitionMapper = IsJson
				})
			});
			string result;
			try
			{
				loaderDownload.WaitForExitTime(Timeout, null, "连接服务器超时（" + Url + "）", null, false);
				result = ModBase.ReadFile(text);
				File.Delete(text);
			}
			finally
			{
				loaderDownload.Abort();
			}
			return result;
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x0003760C File Offset: 0x0003580C
		public static string NetGetCodeByDownload(string[] Urls, int Timeout = 0xAFC8, bool IsJson = false)
		{
			string text = string.Concat(new string[]
			{
				ModBase.m_GlobalRule,
				"Cache\\Code\\",
				Conversions.ToString(Urls[0].GetHashCode()),
				"_",
				Conversions.ToString(ModBase.GetUuid())
			});
			ModNet.LoaderDownload loaderDownload = new ModNet.LoaderDownload("源码获取 " + Conversions.ToString(ModBase.GetUuid()) + "#", new List<ModNet.NetFile>
			{
				new ModNet.NetFile(Urls, text, new ModBase.FileChecker(-1L, -1L, null, null, true, false)
				{
					m_DefinitionMapper = IsJson
				})
			});
			string result;
			try
			{
				loaderDownload.WaitForExitTime(Timeout, null, "连接服务器超时（第一下载源：" + Urls[0] + "）", null, false);
				result = ModBase.ReadFile(text);
				File.Delete(text);
			}
			finally
			{
				loaderDownload.Abort();
			}
			return result;
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x000376F0 File Offset: 0x000358F0
		public static void NetDownload(string Url, string LocalFile)
		{
			ModBase.Log("[Net] 直接下载文件：" + Url, ModBase.LogLevel.Normal, "出现错误");
			try
			{
				Directory.CreateDirectory(ModBase.GetPathFromFullPath(LocalFile));
				File.Delete(LocalFile);
			}
			catch (Exception innerException)
			{
				throw new WebException("预处理下载文件路径失败（" + LocalFile + "）。", innerException);
			}
			using (WebClient webClient = new WebClient())
			{
				try
				{
					webClient.DownloadFile(Url, LocalFile);
				}
				catch (Exception innerException2)
				{
					throw new WebException("直接下载文件失败（" + Url + "）。", innerException2);
				}
			}
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x000377A8 File Offset: 0x000359A8
		public static string NetRequestRetry(string Url, string Method, object Data, string ContentType, bool DontRetryOnRefused = true, Dictionary<string, string> Headers = null)
		{
			int num = 0;
			Exception ex = null;
			long timeTick = ModBase.GetTimeTick();
			checked
			{
				string result;
				try
				{
					IL_0A:
					if (num != 0)
					{
						if (num != 1)
						{
							if (ModBase.GetTimeTick() - timeTick <= 0x157CL)
							{
								throw ex;
							}
							Thread.Sleep(0x1F4);
							result = ModNet.NetRequestOnce(Url, Method, RuntimeHelpers.GetObjectValue(Data), ContentType, 0xFA0, Headers, true);
						}
						else
						{
							Thread.Sleep(0x1F4);
							result = ModNet.NetRequestOnce(Url, Method, RuntimeHelpers.GetObjectValue(Data), ContentType, 0x61A8, Headers, true);
						}
					}
					else
					{
						result = ModNet.NetRequestOnce(Url, Method, RuntimeHelpers.GetObjectValue(Data), ContentType, 0x3A98, Headers, true);
					}
				}
				catch (Exception ex2)
				{
					if (ex2.InnerException != null && ex2.InnerException.Message.Contains("(40") && DontRetryOnRefused)
					{
						num = 0x3E7;
					}
					if (num == 0)
					{
						if (ModBase.errorRule)
						{
							ModBase.Log(ex2, "[Net] 网络请求第一次失败（" + Url + "）", ModBase.LogLevel.Debug, "出现错误");
						}
						ex = ex2;
						num++;
						goto IL_0A;
					}
					if (num != 1)
					{
						throw;
					}
					if (ModBase.errorRule)
					{
						ModBase.Log(ex2, "[Net] 网络请求第二次失败（" + Url + "）", ModBase.LogLevel.Debug, "出现错误");
					}
					num++;
					goto IL_0A;
				}
				return result;
			}
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x000378F8 File Offset: 0x00035AF8
		public static object NetRequestMuity(string Url, string Method, object Data, string ContentType, int RequestCount = 5, Dictionary<string, string> Headers = null)
		{
			ModNet._Closure$__11-0 CS$<>8__locals1 = new ModNet._Closure$__11-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_Url = Url;
			CS$<>8__locals1.$VB$Local_Method = Method;
			CS$<>8__locals1.$VB$Local_Data = Data;
			CS$<>8__locals1.$VB$Local_ContentType = ContentType;
			CS$<>8__locals1.$VB$Local_Headers = Headers;
			List<Thread> list = new List<Thread>();
			CS$<>8__locals1.$VB$Local_RequestResult = null;
			CS$<>8__locals1.$VB$Local_RequestEx = null;
			CS$<>8__locals1.$VB$Local_FailCount = 0;
			checked
			{
				for (int i = 1; i <= RequestCount; i++)
				{
					Thread thread = new Thread((CS$<>8__locals1.$I0 == null) ? (CS$<>8__locals1.$I0 = delegate()
					{
						try
						{
							CS$<>8__locals1.$VB$Local_RequestResult = ModNet.NetRequestOnce(CS$<>8__locals1.$VB$Local_Url, CS$<>8__locals1.$VB$Local_Method, RuntimeHelpers.GetObjectValue(CS$<>8__locals1.$VB$Local_Data), CS$<>8__locals1.$VB$Local_ContentType, 0x7530, CS$<>8__locals1.$VB$Local_Headers, true);
						}
						catch (Exception $VB$Local_RequestEx)
						{
							CS$<>8__locals1.$VB$Local_FailCount++;
							CS$<>8__locals1.$VB$Local_RequestEx = $VB$Local_RequestEx;
						}
					}) : CS$<>8__locals1.$I0);
					thread.Start();
					list.Add(thread);
					Thread.Sleep(0x14);
				}
				while (CS$<>8__locals1.$VB$Local_RequestResult == null)
				{
					if (CS$<>8__locals1.$VB$Local_FailCount == RequestCount)
					{
						Block_5:
						try
						{
							try
							{
								foreach (Thread thread2 in list)
								{
									if (thread2.IsAlive)
									{
										thread2.Abort();
									}
								}
							}
							finally
							{
								List<Thread>.Enumerator enumerator;
								((IDisposable)enumerator).Dispose();
							}
						}
						catch (Exception ex)
						{
						}
						throw CS$<>8__locals1.$VB$Local_RequestEx;
					}
					Thread.Sleep(0x14);
				}
				try
				{
					try
					{
						foreach (Thread thread3 in list)
						{
							if (thread3.IsAlive)
							{
								thread3.Abort();
							}
						}
					}
					finally
					{
						List<Thread>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
					goto IL_155;
				}
				catch (Exception ex2)
				{
					goto IL_155;
				}
				goto Block_5;
				IL_155:
				return CS$<>8__locals1.$VB$Local_RequestResult;
			}
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x00037A98 File Offset: 0x00035C98
		public static string NetRequestOnce(string Url, string Method, byte[] Data, string ContentType, int Timeout = 0x61A8, Dictionary<string, string> Headers = null, bool MakeLog = true)
		{
			Url = Conversions.ToString(ModBase.GetCdnTypeA(Url));
			if (MakeLog)
			{
				ModBase.Log(string.Concat(new string[]
				{
					"[Net] 发起网络请求（",
					Method,
					"，",
					Url,
					"），最大超时 ",
					Conversions.ToString(Timeout)
				}), ModBase.LogLevel.Normal, "出现错误");
			}
			StreamReader streamReader = null;
			Stream stream = null;
			WebResponse webResponse = null;
			string result;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(Url));
				httpWebRequest.Method = Method;
				byte[] array;
				if (Data is byte[])
				{
					array = (byte[])Data;
				}
				else
				{
					array = new UTF8Encoding(false).GetBytes(Data.ToString());
				}
				if (Headers != null)
				{
					try
					{
						foreach (KeyValuePair<string, string> keyValuePair in Headers)
						{
							httpWebRequest.Headers.Add(keyValuePair.Key, keyValuePair.Value);
						}
					}
					finally
					{
						Dictionary<string, string>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
				}
				httpWebRequest.ContentType = ContentType;
				httpWebRequest.Timeout = Timeout;
				httpWebRequest.KeepAlive = false;
				httpWebRequest.UserAgent = "PCL2/2.2.3.0 Mozilla/5.0 AppleWebKit/537.36 Chrome/63.0.3239.132 Safari/537.36";
				httpWebRequest.Referer = "http://" + Conversions.ToString(0xEA) + ".pcl2.server/";
				if (Operators.CompareString(Method, "POST", true) == 0 || Operators.CompareString(Method, "PUT", true) == 0)
				{
					httpWebRequest.ContentLength = (long)array.Length;
					stream = httpWebRequest.GetRequestStream();
					stream.WriteTimeout = Timeout;
					stream.ReadTimeout = Timeout;
					stream.Write(array, 0, array.Length);
					stream.Close();
				}
				webResponse = httpWebRequest.GetResponse();
				stream = webResponse.GetResponseStream();
				stream.WriteTimeout = Timeout;
				stream.ReadTimeout = Timeout;
				streamReader = new StreamReader(stream);
				result = streamReader.ReadToEnd();
			}
			catch (ThreadAbortException ex)
			{
				throw;
			}
			catch (WebException ex2)
			{
				if (ex2.Status == WebExceptionStatus.Timeout)
				{
					throw new TimeoutException("连接服务器超时，请检查你的网络环境是否良好（" + Url + "）", ex2);
				}
				string text = "";
				try
				{
					stream = ex2.Response.GetResponseStream();
					stream.WriteTimeout = Timeout;
					stream.ReadTimeout = Timeout;
					streamReader = new StreamReader(stream);
					text = streamReader.ReadToEnd();
				}
				catch (Exception ex3)
				{
				}
				throw new WebException(string.Concat(new string[]
				{
					"网络请求失败（",
					Url,
					"，",
					ex2.Message,
					"）",
					string.IsNullOrEmpty(text) ? "" : ("\r\n" + text)
				}), ex2);
			}
			catch (Exception innerException)
			{
				throw new WebException("网络请求失败（" + Url + "）", innerException);
			}
			finally
			{
				if (streamReader != null)
				{
					streamReader.Dispose();
				}
				if (stream != null)
				{
					stream.Dispose();
				}
				if (webResponse != null)
				{
					webResponse.Dispose();
				}
			}
			return result;
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x00037DE8 File Offset: 0x00035FE8
		public static bool HasDownloadingTask(bool IgnoreCustomDownload = false)
		{
			object loaderTaskbarLock = ModLoader.LoaderTaskbarLock;
			ObjectFlowControl.CheckForSyncLockOnValueType(loaderTaskbarLock);
			lock (loaderTaskbarLock)
			{
				try
				{
					foreach (object obj in ModLoader.LoaderTaskbar)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(obj);
						if (Conversions.ToBoolean(Conversions.ToBoolean(NewLateBinding.LateGet(objectValue, null, "Show", new object[0], null, null, null)) && Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue, null, "State", new object[0], null, null, null), ModBase.LoadState.Loading, true) && (!IgnoreCustomDownload || !NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null).ToString().Contains("自定义下载"))))
						{
							return true;
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
			return false;
		}

		// Token: 0x0400039E RID: 926
		public static int m_ClassModel;

		// Token: 0x0400039F RID: 927
		public static long _ServerModel;

		// Token: 0x040003A0 RID: 928
		public static long _ConfigModel;

		// Token: 0x040003A1 RID: 929
		public static long _ConnectionModel;

		// Token: 0x040003A2 RID: 930
		private static readonly object m_ListModel;

		// Token: 0x040003A3 RID: 931
		private static long reponseModel;

		// Token: 0x040003A4 RID: 932
		public static int m_IdentifierModel;

		// Token: 0x040003A5 RID: 933
		private static readonly object _PolicyModel;

		// Token: 0x040003A6 RID: 934
		public static ModNet.NetManagerClass _ClientModel;

		// Token: 0x020000C2 RID: 194
		public class NetSource
		{
			// Token: 0x06000790 RID: 1936 RVA: 0x0000632E File Offset: 0x0000452E
			public override string ToString()
			{
				return this.regRule;
			}

			// Token: 0x040003A7 RID: 935
			public int m_ReaderRule;

			// Token: 0x040003A8 RID: 936
			public string regRule;

			// Token: 0x040003A9 RID: 937
			public int m_DefinitionRule;

			// Token: 0x040003AA RID: 938
			public Exception _ParamRule;

			// Token: 0x040003AB RID: 939
			public ModNet.NetThread mockRule;

			// Token: 0x040003AC RID: 940
			public bool m_SpecificationRule;
		}

		// Token: 0x020000C3 RID: 195
		public enum NetState
		{
			// Token: 0x040003AE RID: 942
			WaitForCheck = -1,
			// Token: 0x040003AF RID: 943
			WaitForDownload,
			// Token: 0x040003B0 RID: 944
			Connect,
			// Token: 0x040003B1 RID: 945
			Get,
			// Token: 0x040003B2 RID: 946
			Download,
			// Token: 0x040003B3 RID: 947
			Merge,
			// Token: 0x040003B4 RID: 948
			WaitForCopy,
			// Token: 0x040003B5 RID: 949
			Finish,
			// Token: 0x040003B6 RID: 950
			Error
		}

		// Token: 0x020000C4 RID: 196
		public enum NetPreDownloadBehaviour
		{
			// Token: 0x040003B8 RID: 952
			HintWhileExists,
			// Token: 0x040003B9 RID: 953
			ExitWhileExistsOrDownloading,
			// Token: 0x040003BA RID: 954
			IgnoreCheck
		}

		// Token: 0x020000C5 RID: 197
		public class NetThread : IEnumerable<ModNet.NetThread>
		{
			// Token: 0x06000791 RID: 1937 RVA: 0x00037EF4 File Offset: 0x000360F4
			public NetThread()
			{
				this._ExceptionRule = 0L;
				this.rulesRule = ModBase.GetTimeTick();
				this.m_ClassRule = 0L;
				this._ServerRule = 0L;
				this.configRule = ModBase.GetTimeTick();
				this.m_ConnectionRule = -1L;
				this._ListRule = ModNet.NetState.WaitForDownload;
			}

			// Token: 0x06000792 RID: 1938 RVA: 0x00006336 File Offset: 0x00004536
			private IEnumerable<ModNet.NetThread> ConnectExpression()
			{
				ModNet.NetThread.VB$StateMachine_5_get_Next vb$StateMachine_5_get_Next = new ModNet.NetThread.VB$StateMachine_5_get_Next(-2);
				vb$StateMachine_5_get_Next.$VB$Me = this;
				return vb$StateMachine_5_get_Next;
			}

			// Token: 0x06000793 RID: 1939 RVA: 0x00006346 File Offset: 0x00004546
			public IEnumerator<ModNet.NetThread> GetEnumerator()
			{
				return this.ConnectExpression().GetEnumerator();
			}

			// Token: 0x06000794 RID: 1940 RVA: 0x00006346 File Offset: 0x00004546
			IEnumerator IEnumerable.IEnumerable_GetEnumerator()
			{
				return this.ConnectExpression().GetEnumerator();
			}

			// Token: 0x06000795 RID: 1941 RVA: 0x00006353 File Offset: 0x00004553
			public bool PrintExpression()
			{
				return this.m_ProducerRule == 0L && this._DicRule.m_ProcRule == -2L;
			}

			// Token: 0x06000796 RID: 1942 RVA: 0x00037F60 File Offset: 0x00036160
			public long LoginExpression()
			{
				object globalAlgo = this._DicRule.globalAlgo;
				ObjectFlowControl.CheckForSyncLockOnValueType(globalAlgo);
				checked
				{
					long result;
					lock (globalAlgo)
					{
						if (this.m_HelperRule == null)
						{
							if (this._DicRule._FactoryAlgo)
							{
								result = 0x40000000L;
							}
							else
							{
								result = this._DicRule.m_ProcRule - 1L;
							}
						}
						else
						{
							result = this.m_HelperRule.m_ProducerRule - 1L;
						}
					}
					return result;
				}
			}

			// Token: 0x06000797 RID: 1943 RVA: 0x00006375 File Offset: 0x00004575
			public long SelectExpression()
			{
				return checked(this.LoginExpression() + 1L - (this.m_ProducerRule + this._ExceptionRule));
			}

			// Token: 0x06000798 RID: 1944 RVA: 0x00037FF8 File Offset: 0x000361F8
			public long DefineExpression()
			{
				checked
				{
					if (ModBase.GetTimeTick() - this.rulesRule > 0xC8L)
					{
						long num = ModBase.GetTimeTick() - this.rulesRule;
						this._ServerRule = (long)Math.Round((double)(this._ExceptionRule - this.m_ClassRule) / ((double)num / 1000.0));
						this.m_ClassRule = this._ExceptionRule;
						ref long ptr = ref this.rulesRule;
						this.rulesRule = ptr + num;
					}
					return this._ServerRule;
				}
			}

			// Token: 0x06000799 RID: 1945 RVA: 0x00006395 File Offset: 0x00004595
			public bool CheckExpression()
			{
				return this._ListRule == ModNet.NetState.Finish || this._ListRule == ModNet.NetState.Error;
			}

			// Token: 0x040003BB RID: 955
			public ModNet.NetFile _DicRule;

			// Token: 0x040003BC RID: 956
			public Thread schemaRule;

			// Token: 0x040003BD RID: 957
			public ModNet.NetThread m_HelperRule;

			// Token: 0x040003BE RID: 958
			public int _ConsumerRule;

			// Token: 0x040003BF RID: 959
			public string m_QueueRule;

			// Token: 0x040003C0 RID: 960
			public long m_ProducerRule;

			// Token: 0x040003C1 RID: 961
			public long _ExceptionRule;

			// Token: 0x040003C2 RID: 962
			private long rulesRule;

			// Token: 0x040003C3 RID: 963
			private long m_ClassRule;

			// Token: 0x040003C4 RID: 964
			private long _ServerRule;

			// Token: 0x040003C5 RID: 965
			public long configRule;

			// Token: 0x040003C6 RID: 966
			public long m_ConnectionRule;

			// Token: 0x040003C7 RID: 967
			public ModNet.NetState _ListRule;

			// Token: 0x040003C8 RID: 968
			public ModNet.NetSource Source;
		}

		// Token: 0x020000C7 RID: 199
		public class NetFile
		{
			// Token: 0x060007A2 RID: 1954 RVA: 0x00038124 File Offset: 0x00036324
			private ModNet.NetSource GetSource(int Id = 0)
			{
				if (Id >= this.identifierRule.Count<ModNet.NetSource>() || Id < 0)
				{
					Id = 0;
				}
				object obj = this.issuerAlgo;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				checked
				{
					ModNet.NetSource result;
					lock (obj)
					{
						if (!this.IsSourceFailed(false))
						{
							ModNet.NetSource netSource = this.identifierRule[Id];
							while (netSource.m_SpecificationRule)
							{
								Id++;
								if (Id >= this.identifierRule.Count<ModNet.NetSource>())
								{
									Id = 0;
								}
								netSource = this.identifierRule[Id];
							}
							result = netSource;
						}
						else if (this.clientRule.Count > 0)
						{
							result = this.clientRule[0];
						}
						else
						{
							result = null;
						}
					}
					return result;
				}
			}

			// Token: 0x060007A3 RID: 1955 RVA: 0x000381D8 File Offset: 0x000363D8
			public bool IsSourceFailed(bool AllowOnceSource = true)
			{
				checked
				{
					bool result;
					if (AllowOnceSource && this.clientRule.Count > 0)
					{
						result = false;
					}
					else
					{
						object obj = this.issuerAlgo;
						ObjectFlowControl.CheckForSyncLockOnValueType(obj);
						lock (obj)
						{
							ModNet.NetSource[] array = this.identifierRule;
							for (int i = 0; i < array.Length; i++)
							{
								if (!array[i].m_SpecificationRule)
								{
									return false;
								}
							}
						}
						result = true;
					}
					return result;
				}
			}

			// Token: 0x060007A4 RID: 1956 RVA: 0x000063DC File Offset: 0x000045DC
			public bool ChangeExpression()
			{
				return this._FactoryAlgo || this.m_ProcRule < 0x40000L;
			}

			// Token: 0x060007A5 RID: 1957 RVA: 0x00038258 File Offset: 0x00036458
			public long ViewExpression()
			{
				checked
				{
					if (ModBase.GetTimeTick() - this.expressionAlgo > 0xC8L)
					{
						long num = ModBase.GetTimeTick() - this.expressionAlgo;
						this.baseAlgo = (long)Math.Round((double)(this._ContainerAlgo - this.m_UtilsAlgo) / ((double)num / 1000.0));
						this.m_UtilsAlgo = this._ContainerAlgo;
						ref long ptr = ref this.expressionAlgo;
						this.expressionAlgo = ptr + num;
					}
					return this.baseAlgo;
				}
			}

			// Token: 0x1700014E RID: 334
			// (get) Token: 0x060007A6 RID: 1958 RVA: 0x000382D0 File Offset: 0x000364D0
			public double Progress
			{
				get
				{
					double result;
					switch (this.publisherRule)
					{
					case ModNet.NetState.WaitForCheck:
						result = 0.0;
						break;
					case ModNet.NetState.WaitForDownload:
						result = 0.01;
						break;
					case ModNet.NetState.Connect:
						result = 0.02;
						break;
					case ModNet.NetState.Get:
						result = 0.04;
						break;
					case ModNet.NetState.Download:
					{
						double num = this._FactoryAlgo ? 0.5 : ((double)this._ContainerAlgo / (double)Math.Max(this.m_ProcRule, 1L));
						num = 1.0 - Math.Pow(1.0 - num, 0.9);
						result = num * 0.94 + 0.05;
						break;
					}
					case ModNet.NetState.Merge:
						result = 0.99;
						break;
					case ModNet.NetState.WaitForCopy:
						result = 0.2;
						break;
					case ModNet.NetState.Finish:
					case ModNet.NetState.Error:
						result = 1.0;
						break;
					default:
						throw new ArgumentOutOfRangeException("文件状态未知：" + Conversions.ToString((int)this.publisherRule));
					}
					return result;
				}
			}

			// Token: 0x060007A7 RID: 1959 RVA: 0x000383F8 File Offset: 0x000365F8
			private int CustomizeExpression()
			{
				object mapperAlgo = this._MapperAlgo;
				ObjectFlowControl.CheckForSyncLockOnValueType(mapperAlgo);
				int result;
				lock (mapperAlgo)
				{
					result = checked((int)Math.Round((this.filterAlgo == 0) ? -1.0 : ((double)this._RuleAlgo / (double)this.filterAlgo)));
				}
				return result;
			}

			// Token: 0x060007A8 RID: 1960 RVA: 0x00038464 File Offset: 0x00036664
			public override bool Equals(object obj)
			{
				ModNet.NetFile netFile = obj as ModNet.NetFile;
				return netFile != null && this.m_ServiceAlgo == netFile.m_ServiceAlgo;
			}

			// Token: 0x060007A9 RID: 1961 RVA: 0x0003848C File Offset: 0x0003668C
			public NetFile(string[] Urls, string LocalPath, ModBase.FileChecker Check = null)
			{
				this._ReponseRule = new List<ModNet.LoaderDownload>();
				this.m_PolicyRule = 0;
				this.clientRule = new List<ModNet.NetSource>();
				this.mapRule = null;
				this.m_ComposerRule = null;
				this.publisherRule = ModNet.NetState.WaitForCheck;
				this.m_MessageRule = new List<Exception>();
				this.m_ProcRule = -2L;
				this._FactoryAlgo = false;
				this._ContainerAlgo = 0L;
				this._ModelAlgo = RuntimeHelpers.GetObjectValue(new object());
				this.expressionAlgo = ModBase.GetTimeTick();
				this.m_UtilsAlgo = 0L;
				this.baseAlgo = 0L;
				this.decoratorAlgo = false;
				this.filterAlgo = 0;
				this._RuleAlgo = 0L;
				this._AlgoAlgo = ModBase.RandomInteger(0, 0xF423F);
				this._MapperAlgo = RuntimeHelpers.GetObjectValue(new object());
				this.m_ParamsAlgo = RuntimeHelpers.GetObjectValue(new object());
				this.globalAlgo = RuntimeHelpers.GetObjectValue(new object());
				this.issuerAlgo = RuntimeHelpers.GetObjectValue(new object());
				this.orderAlgo = RuntimeHelpers.GetObjectValue(new object());
				this.m_ServiceAlgo = ModBase.GetUuid();
				List<ModNet.NetSource> list = new List<ModNet.NetSource>();
				int num = 0;
				Urls = ModBase.ArrayNoDouble<string>(Urls, null);
				checked
				{
					foreach (string text in Urls)
					{
						list.Add(new ModNet.NetSource
						{
							m_DefinitionRule = 0,
							regRule = Conversions.ToString(ModBase.GetCdnTypeA(text.Replace("\r", "").Replace("\n", "").Trim())),
							m_ReaderRule = num,
							m_SpecificationRule = false,
							_ParamRule = null
						});
						num++;
					}
					this.identifierRule = list.ToArray();
					this.mapRule = LocalPath;
					this.iteratorAlgo = Check;
					this.m_ComposerRule = ModBase.GetFileNameFromPath(LocalPath);
				}
			}

			// Token: 0x060007AA RID: 1962 RVA: 0x00038670 File Offset: 0x00036870
			public bool TryBeginThread()
			{
				checked
				{
					bool result;
					try
					{
						if (ModNet.m_IdentifierModel < ModNet.m_ClassModel && !this.IsSourceFailed(true))
						{
							if (!this.ChangeExpression() || this._TokenRule == null || this._TokenRule._ListRule == ModNet.NetState.Error)
							{
								if (this.publisherRule < ModNet.NetState.Merge)
								{
									if (this.publisherRule != ModNet.NetState.WaitForCheck)
									{
										object paramsAlgo = this.m_ParamsAlgo;
										ObjectFlowControl.CheckForSyncLockOnValueType(paramsAlgo);
										lock (paramsAlgo)
										{
											if (this.publisherRule < ModNet.NetState.Connect)
											{
												this.publisherRule = ModNet.NetState.Connect;
											}
										}
										ModNet.NetSource netSource = null;
										object obj = this.globalAlgo;
										ObjectFlowControl.CheckForSyncLockOnValueType(obj);
										Thread thread;
										ModNet.NetThread netThread4;
										lock (obj)
										{
											if (!this.ChangeExpression())
											{
												if (!this.IsSourceFailed(false))
												{
													goto IL_16C;
												}
												if (this.clientRule[0].mockRule != null && this.clientRule[0].mockRule._ListRule != ModNet.NetState.Error)
												{
													return false;
												}
											}
											this.m_ValAlgo = null;
											this._TokenRule = null;
											ModNet.NetManagerClass clientModel;
											(clientModel = ModNet._ClientModel).LogoutExpression(clientModel.ConcatExpression() - this._ContainerAlgo);
											object modelAlgo = this._ModelAlgo;
											ObjectFlowControl.CheckForSyncLockOnValueType(modelAlgo);
											lock (modelAlgo)
											{
												this._ContainerAlgo = 0L;
											}
											this.m_UtilsAlgo = 0L;
											this.publisherRule = ModNet.NetState.Get;
											IL_16C:
											long num;
											if (this._TokenRule == null)
											{
												num = 0L;
												netSource = this.GetSource(this.m_PolicyRule);
												if (netSource == null)
												{
													throw new Exception("无可用源，请反馈此问题。");
												}
												this.m_PolicyRule = netSource.m_ReaderRule + 1;
											}
											else
											{
												try
												{
													foreach (ModNet.NetThread netThread in this._TokenRule)
													{
														if (netThread._ListRule == ModNet.NetState.Error && netThread.SelectExpression() > 0L)
														{
															num = netThread.m_ProducerRule + netThread._ExceptionRule;
															netSource = this.GetSource(netThread.Source.m_ReaderRule + 1);
															goto IL_2F6;
														}
													}
												}
												finally
												{
													IEnumerator<ModNet.NetThread> enumerator;
													if (enumerator != null)
													{
														enumerator.Dispose();
													}
												}
												string regRule = this.GetSource(0).regRule;
												if (regRule.Contains("pcl2-server"))
												{
													return false;
												}
												long num2 = regRule.Contains("download.mcbbs.net") ? 0x140000L : 0x40000L;
												ModNet.NetThread netThread2 = this._TokenRule;
												try
												{
													foreach (ModNet.NetThread netThread3 in this._TokenRule)
													{
														if (netThread3.SelectExpression() > netThread2.SelectExpression())
														{
															netThread2 = netThread3;
														}
													}
												}
												finally
												{
													IEnumerator<ModNet.NetThread> enumerator2;
													if (enumerator2 != null)
													{
														enumerator2.Dispose();
													}
												}
												if (netThread2 == null || netThread2.SelectExpression() < num2)
												{
													return false;
												}
												num = (long)Math.Round(unchecked((double)netThread2.LoginExpression() - (double)netThread2.SelectExpression() * 0.4));
												netSource = this.GetSource(0);
											}
											IL_2F6:
											if ((num > this.m_ProcRule && this.m_ProcRule >= 0L && !this._FactoryAlgo) || num < 0L || Information.IsNothing(netSource))
											{
												return false;
											}
											int uuid = ModBase.GetUuid();
											object obj2 = this.orderAlgo;
											ObjectFlowControl.CheckForSyncLockOnValueType(obj2);
											lock (obj2)
											{
												if (this._ReponseRule.Count == 0)
												{
													return false;
												}
												thread = new Thread(delegate(object a0)
												{
													this.Thread((ModNet.NetThread)a0);
												})
												{
													Name = string.Concat(new string[]
													{
														"NetTask ",
														Conversions.ToString(this._ReponseRule[0].Uuid),
														"/",
														Conversions.ToString(this.m_ServiceAlgo),
														" Download ",
														Conversions.ToString(uuid),
														"#"
													}),
													Priority = ThreadPriority.BelowNormal
												};
											}
											netThread4 = new ModNet.NetThread
											{
												_ConsumerRule = uuid,
												m_ProducerRule = num,
												schemaRule = thread,
												Source = netSource,
												_DicRule = this,
												_ListRule = ModNet.NetState.WaitForDownload
											};
											if (!netThread4.PrintExpression() && this._TokenRule != null)
											{
												ModNet.NetThread netThread5 = this._TokenRule;
												while (netThread5.LoginExpression() <= num)
												{
													netThread5 = netThread5.m_HelperRule;
												}
												netThread4.m_HelperRule = netThread5.m_HelperRule;
												netThread5.m_HelperRule = netThread4;
											}
											else
											{
												this._TokenRule = netThread4;
											}
										}
										object policyModel = ModNet._PolicyModel;
										ObjectFlowControl.CheckForSyncLockOnValueType(policyModel);
										lock (policyModel)
										{
											ModNet.m_IdentifierModel++;
										}
										object obj3 = this.issuerAlgo;
										ObjectFlowControl.CheckForSyncLockOnValueType(obj3);
										lock (obj3)
										{
											if (this.IsSourceFailed(false))
											{
												this.clientRule[0].mockRule = netThread4;
											}
										}
										thread.Start(netThread4);
										return true;
									}
								}
								return false;
							}
						}
						result = false;
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "尝试开始下载线程失败（" + (this.m_ComposerRule ?? "Nothing") + "）", ModBase.LogLevel.Hint, "出现错误");
						result = false;
					}
					return result;
				}
			}

			// Token: 0x060007AB RID: 1963 RVA: 0x00038CB4 File Offset: 0x00036EB4
			private void Thread(ModNet.NetThread Info)
			{
				if (ModBase.errorRule || Info.m_ProducerRule == 0L)
				{
					ModBase.Log(string.Concat(new string[]
					{
						"[Download] ",
						this.m_ComposerRule,
						" ",
						Conversions.ToString(Info._ConsumerRule),
						"#：开始，起始点 ",
						Conversions.ToString(Info.m_ProducerRule),
						"，",
						Info.Source.regRule
					}), ModBase.LogLevel.Normal, "出现错误");
				}
				HttpWebResponse httpWebResponse = null;
				Stream stream = null;
				Stream stream2 = null;
				checked
				{
					int num = Math.Min(Math.Max(this.CustomizeExpression(), 0x1770) * (1 + Info.Source.m_DefinitionRule), 0x7530);
					Info._ListRule = ModNet.NetState.Connect;
					try
					{
						int num3;
						if (!this.clientRule.Contains(Info.Source) || Info.Equals(Info.Source.mockRule))
						{
							HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Info.Source.regRule);
							if (Info.Source.regRule.StartsWith("https", StringComparison.OrdinalIgnoreCase))
							{
								httpWebRequest.ProtocolVersion = HttpVersion.Version10;
							}
							httpWebRequest.Timeout = num;
							httpWebRequest.UserAgent = "PCL2/2.2.3.0 Mozilla/5.0 AppleWebKit/537.36 Chrome/63.0.3239.132 Safari/537.36";
							httpWebRequest.AddRange(Info.m_ProducerRule);
							httpWebRequest.Referer = "http://" + Conversions.ToString(0xEA) + ".pcl2.server/";
							httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
							long contentLength = httpWebResponse.ContentLength;
							if (contentLength == -1L)
							{
								if (this.m_ProcRule > 1L)
								{
									ModBase.Log(string.Concat(new string[]
									{
										"[Download] ",
										this.m_ComposerRule,
										" ",
										Conversions.ToString(Info._ConsumerRule),
										"#：文件大小未知，但已从其他下载源获取，不作处理"
									}), ModBase.LogLevel.Normal, "出现错误");
								}
								else
								{
									this.m_ProcRule = -1L;
									this._FactoryAlgo = true;
									ModBase.Log(string.Concat(new string[]
									{
										"[Download] ",
										this.m_ComposerRule,
										" ",
										Conversions.ToString(Info._ConsumerRule),
										"#：文件大小未知"
									}), ModBase.LogLevel.Normal, "出现错误");
								}
							}
							else
							{
								if (contentLength < 0L)
								{
									throw new Exception("获取片大小失败，结果为 " + Conversions.ToString(contentLength) + "。");
								}
								if (Info.PrintExpression())
								{
									if (this.iteratorAlgo != null)
									{
										if (contentLength < this.iteratorAlgo._AdapterMapper && this.iteratorAlgo._AdapterMapper > 0L)
										{
											throw new Exception(string.Concat(new string[]
											{
												"文件大小不足，获取结果为 ",
												Conversions.ToString(contentLength),
												"，要求至少为 ",
												Conversions.ToString(this.iteratorAlgo._AdapterMapper),
												"。"
											}));
										}
										if (contentLength != this.iteratorAlgo.templateMapper && this.iteratorAlgo.templateMapper > 0L)
										{
											throw new Exception(string.Concat(new string[]
											{
												"文件大小不一致，获取结果为 ",
												Conversions.ToString(contentLength),
												"，要求必须为 ",
												Conversions.ToString(this.iteratorAlgo.templateMapper),
												"。"
											}));
										}
									}
									this.m_ProcRule = contentLength;
									this._FactoryAlgo = false;
									ModBase.Log(string.Concat(new string[]
									{
										"[Download] ",
										this.m_ComposerRule,
										"：文件大小 ",
										Conversions.ToString(contentLength),
										" B（",
										ModBase.GetString(contentLength),
										"）"
									}), ModBase.LogLevel.Normal, "出现错误");
									if (contentLength > 0x3200000L)
									{
										foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
										{
											string text = driveInfo.Name.First<char>().ToString();
											double num2 = unchecked((ModBase.m_GlobalRule.StartsWith(text) ? ((double)contentLength * 1.1) : 0.0) + (double)(this.mapRule.StartsWith(text) ? checked(contentLength + 0x500000L) : 0L));
											if ((double)driveInfo.TotalFreeSpace < num2)
											{
												throw new Exception(string.Concat(new string[]
												{
													text,
													" 盘空间不足，无法进行下载。\r\n需要至少 ",
													ModBase.GetString((long)Math.Round(num2)),
													" 空间，但当前仅剩余 ",
													ModBase.GetString(driveInfo.TotalFreeSpace),
													"。",
													ModBase.m_GlobalRule.StartsWith(text) ? "\r\n\r\n下载时需要与文件同等大小的空间存放缓存，你可以在设置中调整缓存文件夹的位置。" : ""
												}));
											}
										}
									}
								}
								else
								{
									if (this.m_ProcRule < 0L)
									{
										throw new Exception("非首线程运行时，尚未获取文件大小。");
									}
									if (Info.m_ProducerRule > 0L && contentLength == this.m_ProcRule)
									{
										object obj = this.issuerAlgo;
										ObjectFlowControl.CheckForSyncLockOnValueType(obj);
										lock (obj)
										{
											if (this.clientRule.Contains(Info.Source))
											{
												goto IL_A86;
											}
											this.clientRule.Add(Info.Source);
										}
										throw new WebException("该下载源不支持断点续传。");
									}
									if (this.m_ProcRule - Info.m_ProducerRule != contentLength)
									{
										throw new WebException(string.Concat(new string[]
										{
											"获取到的片大小不一致：线程结果为 ",
											Conversions.ToString(contentLength),
											" B，任务结果为 ",
											Conversions.ToString(this.m_ProcRule),
											"B，起点为 ",
											Conversions.ToString(Info.m_ProducerRule),
											"B。"
										}));
									}
								}
							}
							Info._ListRule = ModNet.NetState.Get;
							object paramsAlgo = this.m_ParamsAlgo;
							ObjectFlowControl.CheckForSyncLockOnValueType(paramsAlgo);
							lock (paramsAlgo)
							{
								if (this.publisherRule < ModNet.NetState.Get)
								{
									this.publisherRule = ModNet.NetState.Get;
								}
							}
							if (this.ChangeExpression())
							{
								Info.m_QueueRule = null;
								this.m_ValAlgo = new List<byte>();
							}
							else
							{
								Info.m_QueueRule = string.Concat(new string[]
								{
									ModBase.m_GlobalRule,
									"Download\\",
									Conversions.ToString(this.m_ServiceAlgo),
									"_",
									Conversions.ToString(Info._ConsumerRule),
									"_",
									Conversions.ToString(ModBase.RandomInteger(0, 0xF423F)),
									".tmp"
								});
								stream2 = new FileStream(Info.m_QueueRule, FileMode.Create, FileAccess.Write, FileShare.Read);
							}
							stream = httpWebResponse.GetResponseStream();
							stream.ReadTimeout = num;
							if (Conversions.ToBoolean(ModBase._BaseRule.Get("SystemDebugDelay", null)))
							{
								System.Threading.Thread.Sleep(ModBase.RandomInteger(0x32, 0xBB8));
							}
							byte[] array = new byte[0x4001];
							num3 = stream.Read(array, 0, 0x4000);
							int num4;
							long num5;
							for (;;)
							{
								if (!this._FactoryAlgo)
								{
									if (Info.SelectExpression() <= 0L)
									{
										break;
									}
								}
								if (num3 <= 0 || ModBase._AlgoRule || this.publisherRule >= ModNet.NetState.Merge)
								{
									break;
								}
								if (Info.Source.m_SpecificationRule && !Info.Equals(Info.Source.mockRule))
								{
									break;
								}
								while (ModNet._ConfigModel > 0L && ModNet._ConnectionModel <= 0L)
								{
									System.Threading.Thread.Sleep(0x10);
								}
								num4 = (int)(unchecked(this._FactoryAlgo ? ((long)num3) : Math.Min((long)num3, Info.SelectExpression())));
								object listModel = ModNet.m_ListModel;
								ObjectFlowControl.CheckForSyncLockOnValueType(listModel);
								lock (listModel)
								{
									if (ModNet._ConfigModel > 0L)
									{
										ModNet._ConnectionModel -= unchecked((long)num4);
									}
								}
								num5 = ModBase.GetTimeTick() - Info.m_ConnectionRule;
								if (num5 > 0xF4240L)
								{
									num5 = 0L;
								}
								if (num4 > 0)
								{
									long ptr2;
									if (Info._ExceptionRule == 0L)
									{
										Info._ListRule = ModNet.NetState.Download;
										object paramsAlgo2 = this.m_ParamsAlgo;
										ObjectFlowControl.CheckForSyncLockOnValueType(paramsAlgo2);
										lock (paramsAlgo2)
										{
											if (this.publisherRule < ModNet.NetState.Download)
											{
												this.publisherRule = ModNet.NetState.Download;
											}
										}
										object mapperAlgo = this._MapperAlgo;
										ObjectFlowControl.CheckForSyncLockOnValueType(mapperAlgo);
										lock (mapperAlgo)
										{
											ref int ptr = ref this.filterAlgo;
											this.filterAlgo = ptr + 1;
											ptr2 = ref this._RuleAlgo;
											this._RuleAlgo = ptr2 + (ModBase.GetTimeTick() - Info.configRule);
										}
									}
									object mapperAlgo2 = this._MapperAlgo;
									ObjectFlowControl.CheckForSyncLockOnValueType(mapperAlgo2);
									lock (mapperAlgo2)
									{
										Info.Source.m_DefinitionRule = 0;
										object obj2 = this.orderAlgo;
										ObjectFlowControl.CheckForSyncLockOnValueType(obj2);
										lock (obj2)
										{
											try
											{
												foreach (ModNet.LoaderDownload loaderDownload in this._ReponseRule)
												{
													loaderDownload.FailCount = 0;
												}
											}
											finally
											{
												List<ModNet.LoaderDownload>.Enumerator enumerator;
												((IDisposable)enumerator).Dispose();
											}
										}
									}
									ModNet.NetManagerClass clientModel;
									(clientModel = ModNet._ClientModel).LogoutExpression(clientModel.ConcatExpression() + unchecked((long)num4));
									object modelAlgo = this._ModelAlgo;
									ObjectFlowControl.CheckForSyncLockOnValueType(modelAlgo);
									lock (modelAlgo)
									{
										ptr2 = ref this._ContainerAlgo;
										this._ContainerAlgo = ptr2 + unchecked((long)num4);
									}
									ptr2 = ref Info._ExceptionRule;
									Info._ExceptionRule = ptr2 + unchecked((long)num4);
									if (this.ChangeExpression())
									{
										if (array.Count<byte>() == num4)
										{
											this.m_ValAlgo.AddRange(array);
										}
										else
										{
											this.m_ValAlgo.AddRange(array.ToList<byte>().GetRange(0, num4));
										}
									}
									else
									{
										stream2.Write(array, 0, num4);
									}
									if (num5 > 0x3E8L && num5 > unchecked((long)num4))
									{
										goto IL_A3E;
									}
									Info.m_ConnectionRule = ModBase.GetTimeTick();
									if (Info.SelectExpression() == 0L && !this._FactoryAlgo)
									{
										break;
									}
								}
								else if (Info.m_ConnectionRule > 0L && num5 > unchecked((long)num))
								{
									goto IL_A7B;
								}
								num3 = stream.Read(array, 0, 0x4000);
							}
							goto IL_A86;
							IL_A3E:
							throw new TimeoutException(string.Concat(new string[]
							{
								"由于速度过慢断开链接，下载 ",
								Conversions.ToString(num4),
								" B，消耗 ",
								Conversions.ToString(num5),
								" ms。"
							}));
							IL_A7B:
							throw new TimeoutException("操作超时，无数据。");
						}
						IL_A86:
						if (num3 == 0 && Info.SelectExpression() > 0L && !this._FactoryAlgo)
						{
							throw new Exception("服务器无返回数据，但下载尚未完成");
						}
						if (this.publisherRule != ModNet.NetState.Error && !Info.Source.m_SpecificationRule && (Info.SelectExpression() <= 0L || this._FactoryAlgo))
						{
							Info._ListRule = ModNet.NetState.Finish;
							if (ModBase.errorRule)
							{
								ModBase.Log(string.Concat(new string[]
								{
									"[Download] ",
									this.m_ComposerRule,
									" ",
									Conversions.ToString(Info._ConsumerRule),
									"#：完成，已下载 ",
									ModBase.GetString(Info._ExceptionRule)
								}), ModBase.LogLevel.Normal, "出现错误");
							}
						}
						else
						{
							Info._ListRule = ModNet.NetState.Error;
							ModBase.Log(string.Concat(new string[]
							{
								"[Download] ",
								this.m_ComposerRule,
								" ",
								Conversions.ToString(Info._ConsumerRule),
								"#：中断"
							}), ModBase.LogLevel.Normal, "出现错误");
						}
					}
					catch (Exception ex)
					{
						object mapperAlgo3 = this._MapperAlgo;
						ObjectFlowControl.CheckForSyncLockOnValueType(mapperAlgo3);
						lock (mapperAlgo3)
						{
							ModNet.NetSource source = Info.Source;
							ref int ptr = ref source.m_DefinitionRule;
							source.m_DefinitionRule = ptr + 1;
							object obj3 = this.orderAlgo;
							ObjectFlowControl.CheckForSyncLockOnValueType(obj3);
							lock (obj3)
							{
								try
								{
									foreach (ModNet.LoaderDownload loaderDownload2 in this._ReponseRule)
									{
										ModNet.LoaderDownload loaderDownload3;
										(loaderDownload3 = loaderDownload2).FailCount = loaderDownload3.FailCount + 1;
									}
								}
								finally
								{
									List<ModNet.LoaderDownload>.Enumerator enumerator2;
									((IDisposable)enumerator2).Dispose();
								}
							}
						}
						string text2 = ModBase.GetString(ex, false, false).ToLower().Replace(" ", "");
						bool flag11 = text2.Contains("由于连接方在一段时间后没有正确答复或连接的主机没有反应") || text2.Contains("超时") || text2.Contains("timeout") || text2.Contains("timedout");
						ModBase.Log(string.Concat(new string[]
						{
							"[Download] ",
							this.m_ComposerRule,
							" ",
							Conversions.ToString(Info._ConsumerRule),
							flag11 ? ("#：超时（" + Conversions.ToString(unchecked((double)num * 0.001)) + "s）") : ("#：出错，" + ModBase.GetString(ex, false, false))
						}), ModBase.LogLevel.Normal, "出现错误");
						Info._ListRule = ModNet.NetState.Error;
						Info.Source._ParamRule = ex;
						if (ex.Message.Contains("该下载源不支持") || ex.Message.Contains("(404)") || ex.Message.Contains("(403)") || ex.Message.Contains("(502)") || ex.Message.Contains("无返回数据") || ex.Message.Contains("空间不足") || ((double)Info.Source.m_DefinitionRule >= ModBase.MathRange((double)ModNet.m_ClassModel, 5.0, 40.0) && this._ContainerAlgo < 1L) || Info.Source.m_DefinitionRule > ModNet.m_ClassModel)
						{
							bool flag12 = false;
							object obj4 = this.issuerAlgo;
							ObjectFlowControl.CheckForSyncLockOnValueType(obj4);
							lock (obj4)
							{
								if (Info.Source.mockRule != null && Info.Source.mockRule.Equals(Info))
								{
									this.clientRule.RemoveAt(0);
								}
								else if (Info.Source.m_SpecificationRule)
								{
									goto IL_E61;
								}
								Info.Source.m_SpecificationRule = true;
								flag12 = true;
								IL_E61:;
							}
							if (flag12)
							{
								ModBase.Log(string.Concat(new string[]
								{
									"[Download] ",
									this.m_ComposerRule,
									" ",
									Conversions.ToString(this.m_ServiceAlgo),
									"#：下载源被禁用（",
									Conversions.ToString(Info.Source.m_ReaderRule),
									"）：",
									Info.Source.regRule
								}), ModBase.LogLevel.Normal, "出现错误");
								ModBase.Log(ex, "下载源 " + Conversions.ToString(Info.Source.m_ReaderRule) + " 已被禁用", (ex.Message.Contains("不支持断点续传") || ex.Message.Contains("404") || ex.Message.Contains("416")) ? ModBase.LogLevel.Developer : ModBase.LogLevel.Debug, "出现错误");
								if (this.IsSourceFailed(true))
								{
									ModBase.Log("[Download] 文件 " + this.m_ComposerRule + " 已无可用下载源", ModBase.LogLevel.Normal, "出现错误");
									Exception raiseEx = null;
									object obj5 = this.issuerAlgo;
									ObjectFlowControl.CheckForSyncLockOnValueType(obj5);
									lock (obj5)
									{
										foreach (ModNet.NetSource netSource in this.identifierRule)
										{
											ModBase.Log("[Download] 已禁用的下载源：" + netSource.regRule, ModBase.LogLevel.Normal, "出现错误");
											if (netSource._ParamRule != null)
											{
												raiseEx = netSource._ParamRule;
												ModBase.Log(netSource._ParamRule, "下载源禁用原因", ModBase.LogLevel.Developer, "出现错误");
											}
										}
									}
									this.Fail(raiseEx);
								}
								else if (ex.Message.Contains("空间不足"))
								{
									this.Fail(ex);
								}
							}
						}
						if (this.m_ProcRule == -2L)
						{
							object obj6 = this.globalAlgo;
							ObjectFlowControl.CheckForSyncLockOnValueType(obj6);
							lock (obj6)
							{
								this._TokenRule = null;
							}
						}
					}
					finally
					{
						if (httpWebResponse != null)
						{
							httpWebResponse.Dispose();
						}
						if (stream2 != null)
						{
							stream2.Dispose();
						}
						if (stream != null)
						{
							stream.Dispose();
						}
						object policyModel = ModNet._PolicyModel;
						ObjectFlowControl.CheckForSyncLockOnValueType(policyModel);
						lock (policyModel)
						{
							ModNet.m_IdentifierModel--;
						}
						if (((this.m_ProcRule >= 0L && this._ContainerAlgo >= this.m_ProcRule) || (this.m_ProcRule == -1L && this._ContainerAlgo > 0L)) && this.publisherRule < ModNet.NetState.Merge)
						{
							this.Merge();
						}
					}
				}
			}

			// Token: 0x060007AC RID: 1964 RVA: 0x00039F90 File Offset: 0x00038190
			private void Merge()
			{
				object paramsAlgo = this.m_ParamsAlgo;
				ObjectFlowControl.CheckForSyncLockOnValueType(paramsAlgo);
				lock (paramsAlgo)
				{
					if (this.publisherRule >= ModNet.NetState.Merge)
					{
						return;
					}
					this.publisherRule = ModNet.NetState.Merge;
				}
				int num = 0;
				Stream stream = null;
				BinaryWriter binaryWriter = null;
				checked
				{
					try
					{
						IL_40:
						object obj = this.globalAlgo;
						ObjectFlowControl.CheckForSyncLockOnValueType(obj);
						lock (obj)
						{
							if (ModBase.errorRule)
							{
								ModBase.Log("[Download] " + this.m_ComposerRule + "：正在合并文件", ModBase.LogLevel.Normal, "出现错误");
							}
							if (File.Exists(this.mapRule))
							{
								File.Delete(this.mapRule);
							}
							new FileInfo(this.mapRule).Directory.Create();
							if (this.ChangeExpression())
							{
								stream = new FileStream(this.mapRule, FileMode.Create);
								binaryWriter = new BinaryWriter(stream);
								binaryWriter.Write(this.m_ValAlgo.ToArray());
								binaryWriter.Dispose();
								binaryWriter = null;
								stream.Dispose();
								stream = null;
							}
							else if (this._TokenRule._ExceptionRule == this._ContainerAlgo)
							{
								File.Copy(this._TokenRule.m_QueueRule, this.mapRule, true);
							}
							else
							{
								stream = new FileStream(this.mapRule, FileMode.Create);
								binaryWriter = new BinaryWriter(stream);
								try
								{
									foreach (ModNet.NetThread netThread in this._TokenRule)
									{
										if (netThread._ExceptionRule != 0L)
										{
											using (FileStream fileStream = new FileStream(netThread.m_QueueRule, FileMode.Open, FileAccess.Read, FileShare.Read))
											{
												BinaryReader binaryReader = new BinaryReader(fileStream);
												binaryWriter.Write(binaryReader.ReadBytes((int)fileStream.Length));
												binaryReader.Close();
											}
										}
									}
								}
								finally
								{
									IEnumerator<ModNet.NetThread> enumerator;
									if (enumerator != null)
									{
										enumerator.Dispose();
									}
								}
								binaryWriter.Dispose();
								binaryWriter = null;
								stream.Dispose();
								stream = null;
							}
							if (!this._FactoryAlgo && this.iteratorAlgo != null)
							{
								if (this.iteratorAlgo.templateMapper == -1L)
								{
									this.iteratorAlgo.templateMapper = this.m_ProcRule;
								}
								else if (this.iteratorAlgo.templateMapper != this.m_ProcRule)
								{
									throw new Exception(string.Concat(new string[]
									{
										"文件大小不一致：任务要求为 ",
										Conversions.ToString(this.iteratorAlgo.templateMapper),
										" B，网络获取结果为 ",
										Conversions.ToString(this.m_ProcRule),
										"B"
									}));
								}
							}
							ModBase.FileChecker fileChecker = this.iteratorAlgo;
							string text = (fileChecker != null) ? fileChecker.Check(this.mapRule) : null;
							if (text != null)
							{
								ModBase.Log("[Download] File size detail of " + Conversions.ToString(this.m_ServiceAlgo) + "# :", ModBase.LogLevel.Normal, "出现错误");
								try
								{
									foreach (ModNet.NetThread netThread2 in this._TokenRule)
									{
										ModBase.Log(string.Concat(new string[]
										{
											"[Download] ",
											Conversions.ToString(netThread2._ConsumerRule),
											"#, State ",
											ModBase.GetStringFromEnum(netThread2._ListRule),
											", Range ",
											Conversions.ToString(netThread2.m_ProducerRule),
											"~",
											Conversions.ToString(netThread2.m_ProducerRule + netThread2._ExceptionRule),
											", Left ",
											Conversions.ToString(netThread2.SelectExpression())
										}), ModBase.LogLevel.Normal, "出现错误");
									}
								}
								finally
								{
									IEnumerator<ModNet.NetThread> enumerator2;
									if (enumerator2 != null)
									{
										enumerator2.Dispose();
									}
								}
								throw new Exception(text);
							}
							if (this.ChangeExpression())
							{
								this.m_ValAlgo = null;
							}
							else
							{
								try
								{
									foreach (ModNet.NetThread netThread3 in this._TokenRule)
									{
										if (netThread3.m_QueueRule != null)
										{
											File.Delete(netThread3.m_QueueRule);
										}
									}
								}
								finally
								{
									IEnumerator<ModNet.NetThread> enumerator3;
									if (enumerator3 != null)
									{
										enumerator3.Dispose();
									}
								}
							}
							this.Finish(true);
						}
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "合并文件出错（" + this.m_ComposerRule + "）", ModBase.LogLevel.Debug, "出现错误");
						if (stream != null)
						{
							stream.Dispose();
							stream = null;
						}
						if (binaryWriter != null)
						{
							binaryWriter.Dispose();
							binaryWriter = null;
						}
						if (num <= 3)
						{
							System.Threading.Thread.Sleep(ModBase.RandomInteger(0x1F4, 0x3E8));
							num++;
							goto IL_40;
						}
						this.Fail(ex);
					}
				}
			}

			// Token: 0x060007AD RID: 1965 RVA: 0x0003A4A4 File Offset: 0x000386A4
			private void Fail(Exception RaiseEx = null)
			{
				object paramsAlgo = this.m_ParamsAlgo;
				ObjectFlowControl.CheckForSyncLockOnValueType(paramsAlgo);
				lock (paramsAlgo)
				{
					if (this.publisherRule >= ModNet.NetState.Finish)
					{
						return;
					}
					if (RaiseEx != null)
					{
						this.m_MessageRule.Add(RaiseEx);
					}
					this.publisherRule = ModNet.NetState.Error;
				}
				try
				{
					if (File.Exists(this.mapRule))
					{
						File.Delete(this.mapRule);
					}
				}
				catch (Exception ex)
				{
				}
				object callbackAlgo = ModNet._ClientModel.callbackAlgo;
				ObjectFlowControl.CheckForSyncLockOnValueType(callbackAlgo);
				lock (callbackAlgo)
				{
					ModNet.NetManagerClass clientModel = ModNet._ClientModel;
					ref int ptr = ref clientModel.m_ObjectAlgo;
					clientModel.m_ObjectAlgo = checked(ptr - 1);
					ModBase.Log("[Download] " + this.m_ComposerRule + "：已失败，剩余文件 " + Conversions.ToString(ModNet._ClientModel.m_ObjectAlgo), ModBase.LogLevel.Normal, "出现错误");
				}
				try
				{
					foreach (ModNet.LoaderDownload loaderDownload in this._ReponseRule)
					{
						loaderDownload.OnFileFail(this);
					}
				}
				finally
				{
					List<ModNet.LoaderDownload>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}

			// Token: 0x060007AE RID: 1966 RVA: 0x0003A5F4 File Offset: 0x000387F4
			public void Abort(ModNet.LoaderDownload CausedByTask)
			{
				object obj = this.orderAlgo;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				lock (obj)
				{
					this._ReponseRule.Remove(CausedByTask);
					if (this._ReponseRule.Count > 0)
					{
						return;
					}
				}
				object paramsAlgo = this.m_ParamsAlgo;
				ObjectFlowControl.CheckForSyncLockOnValueType(paramsAlgo);
				lock (paramsAlgo)
				{
					if (this.publisherRule >= ModNet.NetState.Finish)
					{
						return;
					}
					this.publisherRule = ModNet.NetState.Error;
				}
				object callbackAlgo = ModNet._ClientModel.callbackAlgo;
				ObjectFlowControl.CheckForSyncLockOnValueType(callbackAlgo);
				lock (callbackAlgo)
				{
					ModNet.NetManagerClass clientModel = ModNet._ClientModel;
					ref int ptr = ref clientModel.m_ObjectAlgo;
					clientModel.m_ObjectAlgo = checked(ptr - 1);
					if (ModBase.errorRule)
					{
						ModBase.Log("[Download] " + this.m_ComposerRule + "：已取消，剩余文件 " + Conversions.ToString(ModNet._ClientModel.m_ObjectAlgo), ModBase.LogLevel.Normal, "出现错误");
					}
				}
			}

			// Token: 0x060007AF RID: 1967 RVA: 0x0003A71C File Offset: 0x0003891C
			public void Finish(bool PrintLog = true)
			{
				object paramsAlgo = this.m_ParamsAlgo;
				ObjectFlowControl.CheckForSyncLockOnValueType(paramsAlgo);
				lock (paramsAlgo)
				{
					if (this.publisherRule >= ModNet.NetState.Finish)
					{
						return;
					}
					this.publisherRule = ModNet.NetState.Finish;
				}
				object callbackAlgo = ModNet._ClientModel.callbackAlgo;
				ObjectFlowControl.CheckForSyncLockOnValueType(callbackAlgo);
				lock (callbackAlgo)
				{
					ModNet.NetManagerClass clientModel = ModNet._ClientModel;
					ref int ptr = ref clientModel.m_ObjectAlgo;
					clientModel.m_ObjectAlgo = checked(ptr - 1);
					if (PrintLog)
					{
						ModBase.Log("[Download] " + this.m_ComposerRule + "：已完成，剩余文件 " + Conversions.ToString(ModNet._ClientModel.m_ObjectAlgo), ModBase.LogLevel.Normal, "出现错误");
					}
				}
				object obj = this.orderAlgo;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				lock (obj)
				{
					try
					{
						foreach (ModNet.LoaderDownload loaderDownload in this._ReponseRule)
						{
							loaderDownload.OnFileFinish(this);
						}
					}
					finally
					{
						List<ModNet.LoaderDownload>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
				}
			}

			// Token: 0x040003CE RID: 974
			public List<ModNet.LoaderDownload> _ReponseRule;

			// Token: 0x040003CF RID: 975
			public ModNet.NetSource[] identifierRule;

			// Token: 0x040003D0 RID: 976
			private int m_PolicyRule;

			// Token: 0x040003D1 RID: 977
			public List<ModNet.NetSource> clientRule;

			// Token: 0x040003D2 RID: 978
			public string mapRule;

			// Token: 0x040003D3 RID: 979
			public string m_ComposerRule;

			// Token: 0x040003D4 RID: 980
			public ModNet.NetState publisherRule;

			// Token: 0x040003D5 RID: 981
			public List<Exception> m_MessageRule;

			// Token: 0x040003D6 RID: 982
			private ModNet.NetThread _TokenRule;

			// Token: 0x040003D7 RID: 983
			public long m_ProcRule;

			// Token: 0x040003D8 RID: 984
			public bool _FactoryAlgo;

			// Token: 0x040003D9 RID: 985
			private List<byte> m_ValAlgo;

			// Token: 0x040003DA RID: 986
			public long _ContainerAlgo;

			// Token: 0x040003DB RID: 987
			private readonly object _ModelAlgo;

			// Token: 0x040003DC RID: 988
			public ModBase.FileChecker iteratorAlgo;

			// Token: 0x040003DD RID: 989
			private long expressionAlgo;

			// Token: 0x040003DE RID: 990
			private long m_UtilsAlgo;

			// Token: 0x040003DF RID: 991
			private long baseAlgo;

			// Token: 0x040003E0 RID: 992
			public bool decoratorAlgo;

			// Token: 0x040003E1 RID: 993
			private int filterAlgo;

			// Token: 0x040003E2 RID: 994
			private long _RuleAlgo;

			// Token: 0x040003E3 RID: 995
			public readonly int _AlgoAlgo;

			// Token: 0x040003E4 RID: 996
			public readonly object _MapperAlgo;

			// Token: 0x040003E5 RID: 997
			public readonly object m_ParamsAlgo;

			// Token: 0x040003E6 RID: 998
			public readonly object globalAlgo;

			// Token: 0x040003E7 RID: 999
			public readonly object issuerAlgo;

			// Token: 0x040003E8 RID: 1000
			public readonly object orderAlgo;

			// Token: 0x040003E9 RID: 1001
			private readonly int m_ServiceAlgo;
		}

		// Token: 0x020000C8 RID: 200
		public class LoaderDownload : ModLoader.LoaderBase<List<ModNet.NetFile>>
		{
			// Token: 0x1700014F RID: 335
			// (get) Token: 0x060007B1 RID: 1969 RVA: 0x0003A860 File Offset: 0x00038A60
			// (set) Token: 0x060007B2 RID: 1970 RVA: 0x00006407 File Offset: 0x00004607
			public override double Progress
			{
				get
				{
					double result;
					if (base.State >= ModBase.LoadState.Finished)
					{
						result = 1.0;
					}
					else if (this.Files.Count == 0)
					{
						result = 0.0;
					}
					else
					{
						result = this._Progress;
					}
					return result;
				}
				set
				{
					throw new Exception("文件下载不允许指定进度");
				}
			}

			// Token: 0x17000150 RID: 336
			// (get) Token: 0x060007B3 RID: 1971 RVA: 0x00006413 File Offset: 0x00004613
			// (set) Token: 0x060007B4 RID: 1972 RVA: 0x0003A8A4 File Offset: 0x00038AA4
			public int FailCount
			{
				get
				{
					return this._FailCount;
				}
				set
				{
					int num2;
					int num4;
					object obj;
					try
					{
						IL_00:
						int num = 1;
						this._FailCount = value;
						IL_09:
						num = 2;
						if (base.State != ModBase.LoadState.Loading || (double)value < Math.Min(2000.0, Math.Max((double)this.FileRemain * 5.5, (double)ModNet.m_ClassModel * 5.5 + 3.0)))
						{
							goto IL_133;
						}
						IL_5C:
						num = 3;
						ModBase.Log("[Download] 由于同加载器中失败次数过多引发强制失败：连续失败了 " + Conversions.ToString(value) + " 次", ModBase.LogLevel.Debug, "出现错误");
						IL_7E:
						ProjectData.ClearProjectError();
						num2 = 1;
						IL_85:
						num = 5;
						List<Exception> list = new List<Exception>();
						IL_8D:
						num = 6;
						object filesLock = this.FilesLock;
						ObjectFlowControl.CheckForSyncLockOnValueType(filesLock);
						lock (filesLock)
						{
							try
							{
								foreach (ModNet.NetFile netFile in this.Files)
								{
									foreach (ModNet.NetSource netSource in netFile.identifierRule)
									{
										if (netSource._ParamRule != null)
										{
											list.Add(netSource._ParamRule);
											if (list.Count > 0xA)
											{
												goto IL_12A;
											}
										}
									}
								}
							}
							finally
							{
								List<ModNet.NetFile>.Enumerator enumerator;
								((IDisposable)enumerator).Dispose();
							}
						}
						IL_12A:
						num = 7;
						this.OnFail(list);
						IL_133:
						goto IL_1A2;
						IL_135:
						int num3 = num4 + 1;
						num4 = 0;
						@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
						IL_163:
						goto IL_197;
						IL_165:
						num4 = num;
						@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num2);
						IL_175:;
					}
					catch when (endfilter(obj is Exception & num2 != 0 & num4 == 0))
					{
						Exception ex = (Exception)obj2;
						goto IL_165;
					}
					IL_197:
					throw ProjectData.CreateProjectError(-0x7FF5FFCD);
					IL_1A2:
					if (num4 != 0)
					{
						ProjectData.ClearProjectError();
					}
				}
			}

			// Token: 0x060007B5 RID: 1973 RVA: 0x0003AAA8 File Offset: 0x00038CA8
			public void RefreshStat()
			{
				double num = 0.0;
				double num2 = 0.0;
				object filesLock = this.FilesLock;
				ObjectFlowControl.CheckForSyncLockOnValueType(filesLock);
				lock (filesLock)
				{
					try
					{
						foreach (ModNet.NetFile netFile in this.Files)
						{
							if (netFile.decoratorAlgo)
							{
								num += netFile.Progress * 0.2;
								num2 += 0.2;
							}
							else
							{
								num += netFile.Progress;
								num2 += 1.0;
							}
						}
					}
					finally
					{
						List<ModNet.NetFile>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
				}
				if (num2 > 0.0)
				{
					num /= num2;
				}
				if (num < 1.0 && num > 0.0)
				{
					num = 1.0 - Math.Pow(1.0 - num, 0.9);
				}
				this._Progress = num * 0.99 + 0.01;
			}

			// Token: 0x060007B6 RID: 1974 RVA: 0x0003ABE0 File Offset: 0x00038DE0
			public LoaderDownload(string Name, List<ModNet.NetFile> FileTasks)
			{
				this.FilesLock = RuntimeHelpers.GetObjectValue(new object());
				this.FileRemainLock = RuntimeHelpers.GetObjectValue(new object());
				this._Progress = 0.0;
				this._FailCount = 0;
				this.Name = Name;
				this.Files = FileTasks;
			}

			// Token: 0x060007B7 RID: 1975 RVA: 0x0003AC38 File Offset: 0x00038E38
			public override void Start(List<ModNet.NetFile> Input = null, bool IsForceRestart = false)
			{
				if (IsForceRestart)
				{
					throw new Exception("此加载器尚不支持强制加载");
				}
				object filesLock = this.FilesLock;
				ObjectFlowControl.CheckForSyncLockOnValueType(filesLock);
				checked
				{
					lock (filesLock)
					{
						if (Input != null)
						{
							this.Files = Input;
						}
						List<ModNet.NetFile> list = new List<ModNet.NetFile>();
						int num = this.Files.Count - 1;
						int i = 0;
						IL_B0:
						while (i <= num)
						{
							int num2 = i + 1;
							int num3 = this.Files.Count - 1;
							for (int j = num2; j <= num3; j++)
							{
								if (Operators.CompareString(this.Files[i].mapRule, this.Files[j].mapRule, true) == 0)
								{
									IL_AA:
									i++;
									goto IL_B0;
								}
							}
							list.Add(this.Files[i]);
							goto IL_AA;
						}
						this.Files = list;
						object fileRemainLock = this.FileRemainLock;
						ObjectFlowControl.CheckForSyncLockOnValueType(fileRemainLock);
						lock (fileRemainLock)
						{
							try
							{
								List<ModNet.NetFile>.Enumerator enumerator = this.Files.GetEnumerator();
								while (enumerator.MoveNext())
								{
									if (enumerator.Current.publisherRule != ModNet.NetState.Finish)
									{
										ref int ptr = ref this.FileRemain;
										this.FileRemain = ptr + 1;
									}
								}
							}
							finally
							{
								List<ModNet.NetFile>.Enumerator enumerator;
								((IDisposable)enumerator).Dispose();
							}
						}
					}
					base.State = ModBase.LoadState.Loading;
					ModBase.RunInNewThread(delegate
					{
						try
						{
							ModNet.LoaderDownload._Closure$__14-1 CS$<>8__locals1 = new ModNet.LoaderDownload._Closure$__14-1(CS$<>8__locals1);
							CS$<>8__locals1.$VB$Me = this;
							if (this.Files.Count == 0)
							{
								this.OnFinish();
							}
							else
							{
								try
								{
									foreach (ModNet.NetFile netFile in this.Files)
									{
										if (netFile == null)
										{
											throw new ArgumentException("存在空文件请求！");
										}
										foreach (ModNet.NetSource netSource in netFile.identifierRule)
										{
											if (!netSource.regRule.ToLower().StartsWith("https://") && !netSource.regRule.ToLower().StartsWith("http://"))
											{
												netSource._ParamRule = new ArgumentException("输入的下载链接不正确！");
												netSource.m_SpecificationRule = true;
											}
										}
										if (netFile.IsSourceFailed(true))
										{
											throw new ArgumentException("输入的下载链接不正确！");
										}
										if (!netFile.mapRule.ToLower().Contains(":\\"))
										{
											throw new ArgumentException("输入的本地文件地址不正确！");
										}
										if (netFile.mapRule.EndsWith("\\"))
										{
											throw new ArgumentException("请输入含文件名的完整文件路径！");
										}
										string fullName = new FileInfo(netFile.mapRule).Directory.FullName;
										if (!Directory.Exists(fullName))
										{
											Directory.CreateDirectory(fullName);
										}
									}
								}
								finally
								{
									List<ModNet.NetFile>.Enumerator enumerator2;
									((IDisposable)enumerator2).Dispose();
								}
								ModNet._ClientModel.Start(this);
								List<string> list2 = new List<string>();
								CS$<>8__locals1.$VB$Local_FoldersFinal = new List<string>();
								if (Conversions.ToBoolean(Operators.NotObject(ModBase._BaseRule.Get("SystemDebugSkipCopy", null))))
								{
									list2.Add(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\");
									try
									{
										foreach (ModMinecraft.McFolder mcFolder in ModMinecraft.collectionIterator)
										{
											list2.Add(mcFolder.Path);
										}
									}
									finally
									{
										List<ModMinecraft.McFolder>.Enumerator enumerator3;
										((IDisposable)enumerator3).Dispose();
									}
									list2 = ModBase.ArrayNoDouble<string>(list2, null);
									try
									{
										foreach (string text in list2)
										{
											if (Operators.CompareString(text, ModMinecraft.m_ResolverIterator, true) != 0 && Directory.Exists(text))
											{
												CS$<>8__locals1.$VB$Local_FoldersFinal.Add(text);
											}
										}
									}
									finally
									{
										List<string>.Enumerator enumerator4;
										((IDisposable)enumerator4).Dispose();
									}
								}
								object filesLock2 = this.FilesLock;
								ObjectFlowControl.CheckForSyncLockOnValueType(filesLock2);
								lock (filesLock2)
								{
									int num4 = (int)Math.Round(Math.Max(10.0, unchecked((double)this.Files.Count / 10.0 + 1.0)));
									List<ModNet.NetFile> list3 = new List<ModNet.NetFile>();
									try
									{
										foreach (ModNet.NetFile item in this.Files)
										{
											list3.Add(item);
											if (list3.Count == num4)
											{
												ModNet.LoaderDownload._Closure$__14-0 CS$<>8__locals2 = new ModNet.LoaderDownload._Closure$__14-0(CS$<>8__locals2);
												CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2 = CS$<>8__locals1;
												CS$<>8__locals2.$VB$Local_FilesToRun = new List<ModNet.NetFile>();
												CS$<>8__locals2.$VB$Local_FilesToRun.AddRange(list3);
												ModBase.RunInNewThread(delegate
												{
													CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Me.StartCopy(CS$<>8__locals2.$VB$Local_FilesToRun, CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_FoldersFinal);
												}, "NetTask FileCopy " + Conversions.ToString(this.Uuid), ThreadPriority.Normal);
												list3.Clear();
											}
										}
									}
									finally
									{
										List<ModNet.NetFile>.Enumerator enumerator5;
										((IDisposable)enumerator5).Dispose();
									}
									if (list3.Count > 0)
									{
										ModNet.LoaderDownload._Closure$__14-2 CS$<>8__locals3 = new ModNet.LoaderDownload._Closure$__14-2(CS$<>8__locals3);
										CS$<>8__locals3.$VB$NonLocal_$VB$Closure_3 = CS$<>8__locals1;
										CS$<>8__locals3.$VB$Local_FilesToRun = new List<ModNet.NetFile>();
										CS$<>8__locals3.$VB$Local_FilesToRun.AddRange(list3);
										ModBase.RunInNewThread(delegate
										{
											CS$<>8__locals3.$VB$NonLocal_$VB$Closure_3.$VB$Me.StartCopy(CS$<>8__locals3.$VB$Local_FilesToRun, CS$<>8__locals3.$VB$NonLocal_$VB$Closure_3.$VB$Local_FoldersFinal);
										}, "NetTask FileCopy " + Conversions.ToString(this.Uuid), ThreadPriority.Normal);
										list3.Clear();
									}
								}
							}
						}
						catch (Exception item2)
						{
							this.OnFail(new List<Exception>
							{
								item2
							});
						}
					}, "NetTask " + Conversions.ToString(this.Uuid) + " Main", ThreadPriority.Normal);
				}
			}

			// Token: 0x060007B8 RID: 1976 RVA: 0x0003ADF8 File Offset: 0x00038FF8
			private void StartCopy(List<ModNet.NetFile> Files, List<string> FolderList)
			{
				checked
				{
					try
					{
						if (ModBase.errorRule)
						{
							ModBase.Log("[Download] 检查线程分配文件数：" + Conversions.ToString(Files.Count), ModBase.LogLevel.Normal, "出现错误");
						}
						List<Array> list = new List<Array>();
						try
						{
							foreach (ModNet.NetFile netFile in Files)
							{
								string text = null;
								if (netFile.iteratorAlgo != null && ModMinecraft.collectionIterator != null && netFile.iteratorAlgo._RegMapper && netFile.mapRule.StartsWith(ModMinecraft.m_ResolverIterator))
								{
									string str = netFile.mapRule.Replace(ModMinecraft.m_ResolverIterator, "");
									try
									{
										foreach (string str2 in FolderList)
										{
											string text2 = str2 + str;
											if (netFile.iteratorAlgo.Check(text2) == null)
											{
												text = text2;
												break;
											}
										}
									}
									finally
									{
										List<string>.Enumerator enumerator2;
										((IDisposable)enumerator2).Dispose();
									}
								}
								object lockState = this.LockState;
								ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
								lock (lockState)
								{
									if (text != null)
									{
										netFile.publisherRule = ModNet.NetState.WaitForCopy;
										netFile.decoratorAlgo = true;
										list.Add(new object[]
										{
											netFile,
											text
										});
									}
									else
									{
										netFile.publisherRule = ModNet.NetState.WaitForDownload;
										netFile.decoratorAlgo = false;
									}
								}
							}
						}
						finally
						{
							List<ModNet.NetFile>.Enumerator enumerator;
							((IDisposable)enumerator).Dispose();
						}
						try
						{
							foreach (Array instance in list)
							{
								ModNet.NetFile netFile2 = (ModNet.NetFile)NewLateBinding.LateIndexGet(instance, new object[]
								{
									0
								}, null);
								string text3 = Conversions.ToString(NewLateBinding.LateIndexGet(instance, new object[]
								{
									1
								}, null));
								int num = 0;
								for (;;)
								{
									try
									{
										ModBase.Log("[Download] 复制已存在的文件（" + text3 + "）", ModBase.LogLevel.Normal, "出现错误");
										Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(text3, netFile2.mapRule, true);
										netFile2.Finish(false);
										break;
									}
									catch (Exception ex)
									{
										num++;
										ModBase.Log(ex, string.Format("复制已存在的文件失败，重试第 {2} 次（{0} -> {1}）", text3, netFile2.mapRule, num), ModBase.LogLevel.Debug, "出现错误");
										if (num >= 3)
										{
											netFile2.publisherRule = ModNet.NetState.WaitForDownload;
											netFile2.decoratorAlgo = false;
											break;
										}
										Thread.Sleep(0xC8);
									}
								}
							}
						}
						finally
						{
							List<Array>.Enumerator enumerator3;
							((IDisposable)enumerator3).Dispose();
						}
					}
					catch (Exception ex2)
					{
						ModBase.Log(ex2, "下载已存在文件查找失败", ModBase.LogLevel.Feedback, "出现错误");
					}
				}
			}

			// Token: 0x060007B9 RID: 1977 RVA: 0x0003B11C File Offset: 0x0003931C
			public void OnFileFinish(ModNet.NetFile File)
			{
				object fileRemainLock = this.FileRemainLock;
				ObjectFlowControl.CheckForSyncLockOnValueType(fileRemainLock);
				lock (fileRemainLock)
				{
					ref int ptr = ref this.FileRemain;
					this.FileRemain = checked(ptr - 1);
					if (this.FileRemain > 0)
					{
						return;
					}
				}
				this.OnFinish();
			}

			// Token: 0x060007BA RID: 1978 RVA: 0x0003B17C File Offset: 0x0003937C
			public void OnFinish()
			{
				object lockState = this.LockState;
				ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
				lock (lockState)
				{
					if (base.State <= ModBase.LoadState.Loading)
					{
						base.State = ModBase.LoadState.Finished;
					}
				}
			}

			// Token: 0x060007BB RID: 1979 RVA: 0x0003B1D0 File Offset: 0x000393D0
			public void OnFileFail(ModNet.NetFile File)
			{
				foreach (ModNet.NetSource netSource in File.identifierRule)
				{
					if (!Information.IsNothing(netSource._ParamRule))
					{
						File.m_MessageRule.Add(netSource._ParamRule);
					}
				}
				this.OnFail(File.m_MessageRule);
			}

			// Token: 0x060007BC RID: 1980 RVA: 0x0003B220 File Offset: 0x00039420
			public void OnFail(List<Exception> ExList)
			{
				object lockState = this.LockState;
				ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
				lock (lockState)
				{
					if (base.State > ModBase.LoadState.Loading)
					{
						return;
					}
					if (ExList == null || ExList.Count == 0)
					{
						ExList = new List<Exception>
						{
							new Exception("未知错误！")
						};
					}
					base.Error = ExList[0];
					object filesLock = this.FilesLock;
					ObjectFlowControl.CheckForSyncLockOnValueType(filesLock);
					lock (filesLock)
					{
						try
						{
							foreach (ModNet.NetFile netFile in this.Files)
							{
								if (netFile.publisherRule == ModNet.NetState.Error)
								{
									base.Error = new Exception(string.Concat(new string[]
									{
										"文件下载失败：",
										netFile.mapRule,
										"（第一下载源：",
										netFile.identifierRule[0].regRule,
										"）"
									}), ExList[0]);
									break;
								}
							}
						}
						finally
						{
							List<ModNet.NetFile>.Enumerator enumerator;
							((IDisposable)enumerator).Dispose();
						}
					}
					base.State = ModBase.LoadState.Failed;
				}
				object filesLock2 = this.FilesLock;
				ObjectFlowControl.CheckForSyncLockOnValueType(filesLock2);
				lock (filesLock2)
				{
					try
					{
						foreach (ModNet.NetFile netFile2 in this.Files)
						{
							if (netFile2.publisherRule < ModNet.NetState.Merge)
							{
								netFile2.publisherRule = ModNet.NetState.Error;
							}
						}
					}
					finally
					{
						List<ModNet.NetFile>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
				}
				List<string> list = new List<string>();
				try
				{
					foreach (Exception ex in ExList)
					{
						list.Add(ModBase.GetString(ex, false, false));
					}
				}
				finally
				{
					List<Exception>.Enumerator enumerator3;
					((IDisposable)enumerator3).Dispose();
				}
				ModBase.Log("[Download] " + ModBase.Join(ModBase.ArrayNoDouble<string>(list.ToArray(), null), "\r\n"), ModBase.LogLevel.Normal, "出现错误");
			}

			// Token: 0x060007BD RID: 1981 RVA: 0x0003B4B0 File Offset: 0x000396B0
			public override void Abort()
			{
				object lockState = this.LockState;
				ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
				lock (lockState)
				{
					if (base.State >= ModBase.LoadState.Finished)
					{
						return;
					}
					base.State = ModBase.LoadState.Aborted;
				}
				ModBase.Log("[Download] " + this.Name + " 已取消！", ModBase.LogLevel.Normal, "出现错误");
				object filesLock = this.FilesLock;
				ObjectFlowControl.CheckForSyncLockOnValueType(filesLock);
				lock (filesLock)
				{
					try
					{
						foreach (ModNet.NetFile netFile in this.Files)
						{
							netFile.Abort(this);
						}
					}
					finally
					{
						List<ModNet.NetFile>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
				}
			}

			// Token: 0x040003EA RID: 1002
			public List<ModNet.NetFile> Files;

			// Token: 0x040003EB RID: 1003
			private readonly object FilesLock;

			// Token: 0x040003EC RID: 1004
			private int FileRemain;

			// Token: 0x040003ED RID: 1005
			private readonly object FileRemainLock;

			// Token: 0x040003EE RID: 1006
			private double _Progress;

			// Token: 0x040003EF RID: 1007
			private int _FailCount;
		}

		// Token: 0x020000CC RID: 204
		public class NetManagerClass
		{
			// Token: 0x060007C4 RID: 1988 RVA: 0x0003BA04 File Offset: 0x00039C04
			public NetManagerClass()
			{
				this.m_FacadeAlgo = new Dictionary<string, ModNet.NetFile>();
				this._CodeAlgo = RuntimeHelpers.GetObjectValue(new object());
				this.m_MappingAlgo = new List<ModNet.LoaderDownload>();
				this.bridgeAlgo = RuntimeHelpers.GetObjectValue(new object());
				this.singletonAlgo = 0L;
				this.errorAlgo = RuntimeHelpers.GetObjectValue(new object());
				this.m_ObjectAlgo = 0;
				this.callbackAlgo = RuntimeHelpers.GetObjectValue(new object());
				this.workerAlgo = 0L;
				this.m_VisitorAlgo = new List<long>
				{
					0L,
					0L,
					0L,
					0L,
					0L,
					0L,
					0L,
					0L,
					0L,
					0L
				};
				this.indexerAlgo = 0L;
				this._MethodAlgo = ModBase.GetUuid();
				this._AttrAlgo = false;
				this._ThreadAlgo = false;
			}

			// Token: 0x060007C5 RID: 1989 RVA: 0x000064A6 File Offset: 0x000046A6
			public long ConcatExpression()
			{
				return this.singletonAlgo;
			}

			// Token: 0x060007C6 RID: 1990 RVA: 0x0003BB5C File Offset: 0x00039D5C
			public void LogoutExpression(long value)
			{
				object obj = this.errorAlgo;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				lock (obj)
				{
					this.singletonAlgo = value;
				}
			}

			// Token: 0x060007C7 RID: 1991 RVA: 0x0003BBA4 File Offset: 0x00039DA4
			private void RefreshStat()
			{
				checked
				{
					try
					{
						long num = ModBase.GetTimeTick() - this.databaseAlgo;
						ref long ptr = ref this.databaseAlgo;
						this.databaseAlgo = ptr + num;
						double a = Math.Max(0.0, (double)(this.ConcatExpression() - this.workerAlgo) / ((double)num / 1000.0));
						this.m_VisitorAlgo.Add((long)Math.Round(a));
						this.m_VisitorAlgo.RemoveAt(0);
						this.workerAlgo = this.ConcatExpression();
						this.indexerAlgo = (long)Math.Round(unchecked((double)this.m_VisitorAlgo[9] + (double)this.m_VisitorAlgo[8] * 0.9 + (double)this.m_VisitorAlgo[7] * 0.8 + (double)this.m_VisitorAlgo[6] * 0.7 + (double)this.m_VisitorAlgo[5] * 0.6 + (double)this.m_VisitorAlgo[4] * 0.5 + (double)this.m_VisitorAlgo[3] * 0.4 + (double)this.m_VisitorAlgo[2] * 0.3 + (double)this.m_VisitorAlgo[1] * 0.2 + (double)this.m_VisitorAlgo[0] * 0.1) / 5.5);
						this.m_VisitorAlgo.Add((long)Math.Round(a));
						this.m_VisitorAlgo.RemoveAt(0);
						long num2 = (long)Math.Round(unchecked((double)Math.Min(Math.Min(Math.Min(Math.Min(this.m_VisitorAlgo[5], this.m_VisitorAlgo[6]), this.m_VisitorAlgo[7]), this.m_VisitorAlgo[8]), this.m_VisitorAlgo[9]) * 0.9));
						if (num2 > ModNet._ServerModel)
						{
							ModNet._ServerModel = num2;
							ModBase.Log("[Download] 速度下限已提升到 " + ModBase.GetString(num2), ModBase.LogLevel.Normal, "出现错误");
						}
						object obj = this.bridgeAlgo;
						ObjectFlowControl.CheckForSyncLockOnValueType(obj);
						lock (obj)
						{
							try
							{
								foreach (ModNet.LoaderDownload loaderDownload in this.m_MappingAlgo)
								{
									loaderDownload.RefreshStat();
								}
							}
							finally
							{
								List<ModNet.LoaderDownload>.Enumerator enumerator;
								((IDisposable)enumerator).Dispose();
							}
						}
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "刷新下载公开属性失败", ModBase.LogLevel.Debug, "出现错误");
					}
				}
			}

			// Token: 0x060007C8 RID: 1992 RVA: 0x0003BE94 File Offset: 0x0003A094
			private void StartManager()
			{
				checked
				{
					if (!this._AttrAlgo)
					{
						this._AttrAlgo = true;
						ModBase.RunInNewThread(delegate
						{
							try
							{
								for (;;)
								{
									long timeTick = ModBase.GetTimeTick();
									if (this.m_ObjectAlgo == 0 && this.m_FacadeAlgo.Count > 0)
									{
										object codeAlgo = this._CodeAlgo;
										ObjectFlowControl.CheckForSyncLockOnValueType(codeAlgo);
										lock (codeAlgo)
										{
											this.m_FacadeAlgo.Clear();
										}
									}
									if (this.indexerAlgo < ModNet._ServerModel || this.m_ObjectAlgo > ModNet.m_ClassModel)
									{
										bool flag2 = false;
										int num = (int)Math.Round(Math.Max((double)this.m_ObjectAlgo, ModBase.MathRange((double)ModNet.m_IdentifierModel / 2.0, 1.0, 4.0)));
										num = (int)Math.Floor((double)num / 2.0);
										num = (int)Math.Round(ModBase.MathRange((double)num, 1.0, (double)ModNet.m_ClassModel));
										do
										{
											flag2 = false;
											List<ModNet.NetFile> list = new List<ModNet.NetFile>();
											List<ModNet.NetFile> list2 = new List<ModNet.NetFile>();
											object codeAlgo2 = this._CodeAlgo;
											ObjectFlowControl.CheckForSyncLockOnValueType(codeAlgo2);
											lock (codeAlgo2)
											{
												try
												{
													foreach (ModNet.NetFile netFile in this.m_FacadeAlgo.Values)
													{
														if (netFile._AlgoAlgo % 2 != 0)
														{
															if (netFile.publisherRule == ModNet.NetState.WaitForDownload)
															{
																list.Add(netFile);
															}
															else if (netFile.publisherRule < ModNet.NetState.Merge)
															{
																list2.Add(netFile);
															}
														}
													}
												}
												finally
												{
													Dictionary<string, ModNet.NetFile>.ValueCollection.Enumerator enumerator;
													((IDisposable)enumerator).Dispose();
												}
											}
											try
											{
												foreach (ModNet.NetFile netFile2 in list)
												{
													if (num == 0)
													{
														break;
													}
													if (netFile2.TryBeginThread())
													{
														flag2 = true;
														num--;
													}
												}
											}
											finally
											{
												List<ModNet.NetFile>.Enumerator enumerator2;
												((IDisposable)enumerator2).Dispose();
											}
											try
											{
												foreach (ModNet.NetFile netFile3 in list2)
												{
													if (num == 0)
													{
														break;
													}
													if (netFile3.TryBeginThread())
													{
														flag2 = true;
														num--;
													}
												}
											}
											finally
											{
												List<ModNet.NetFile>.Enumerator enumerator3;
												((IDisposable)enumerator3).Dispose();
											}
										}
										while (num > 0 && flag2);
									}
									while (ModBase.GetTimeTick() - timeTick < 0x78L)
									{
										Thread.Sleep(0xA);
									}
								}
							}
							catch (Exception ex)
							{
								if (typeof(ThreadAbortException) != ex.GetType())
								{
									ModBase.Log(ex, "下载管理启动线程 1 出错", ModBase.LogLevel.Assert, "出现错误");
								}
							}
						}, "NetManager ThreadStarter Single", ThreadPriority.Normal);
						ModBase.RunInNewThread(delegate
						{
							try
							{
								for (;;)
								{
									long timeTick = ModBase.GetTimeTick();
									if (this.indexerAlgo < ModNet._ServerModel)
									{
										goto IL_16;
									}
									if (this.m_ObjectAlgo > ModNet.m_ClassModel)
									{
										goto IL_16;
									}
									IL_1BB:
									while (ModBase.GetTimeTick() - timeTick < 0x78L)
									{
										Thread.Sleep(0xA);
									}
									continue;
									IL_16:
									bool flag = false;
									int num = (int)Math.Round(Math.Max((double)this.m_ObjectAlgo, ModBase.MathRange((double)ModNet.m_IdentifierModel / 2.0, 1.0, 4.0)));
									num = (int)Math.Floor((double)num / 2.0);
									num = (int)Math.Round(ModBase.MathRange((double)num, 1.0, (double)ModNet.m_ClassModel));
									for (;;)
									{
										flag = false;
										List<ModNet.NetFile> list = new List<ModNet.NetFile>();
										List<ModNet.NetFile> list2 = new List<ModNet.NetFile>();
										object codeAlgo = this._CodeAlgo;
										ObjectFlowControl.CheckForSyncLockOnValueType(codeAlgo);
										lock (codeAlgo)
										{
											try
											{
												foreach (ModNet.NetFile netFile in this.m_FacadeAlgo.Values)
												{
													if (netFile._AlgoAlgo % 2 != 1)
													{
														if (netFile.publisherRule == ModNet.NetState.WaitForDownload)
														{
															list.Add(netFile);
														}
														else if (netFile.publisherRule < ModNet.NetState.Merge)
														{
															list2.Add(netFile);
														}
													}
												}
											}
											finally
											{
												Dictionary<string, ModNet.NetFile>.ValueCollection.Enumerator enumerator;
												((IDisposable)enumerator).Dispose();
											}
										}
										try
										{
											IL_109:
											foreach (ModNet.NetFile netFile2 in list)
											{
												if (num == 0)
												{
													break;
												}
												if (netFile2.TryBeginThread())
												{
													flag = true;
													num--;
												}
											}
										}
										finally
										{
											List<ModNet.NetFile>.Enumerator enumerator2;
											((IDisposable)enumerator2).Dispose();
										}
										try
										{
											foreach (ModNet.NetFile netFile3 in list2)
											{
												if (num == 0)
												{
													break;
												}
												if (netFile3.TryBeginThread())
												{
													flag = true;
													num--;
												}
											}
										}
										finally
										{
											List<ModNet.NetFile>.Enumerator enumerator3;
											((IDisposable)enumerator3).Dispose();
										}
										if (num > 0 && flag)
										{
											continue;
										}
										goto IL_1BB;
										goto IL_109;
									}
								}
							}
							catch (Exception ex)
							{
								if (typeof(ThreadAbortException) != ex.GetType())
								{
									ModBase.Log(ex, "下载管理启动线程 2 出错", ModBase.LogLevel.Assert, "出现错误");
								}
							}
						}, "NetManager ThreadStarter Odd", ThreadPriority.Normal);
						ModBase.RunInNewThread(delegate
						{
							try
							{
								ModNet.reponseModel = ModBase.GetTimeTick();
								for (;;)
								{
									long timeTick = ModBase.GetTimeTick();
									long num = timeTick;
									if (ModNet._ConfigModel > 0L)
									{
										ModNet._ConnectionModel = (long)Math.Round(unchecked((double)ModNet._ConfigModel / 1000.0 * (double)(checked(timeTick - ModNet.reponseModel))));
									}
									ModNet.reponseModel = timeTick;
									this.RefreshStat();
									while (ModBase.GetTimeTick() - num < 0xAAL)
									{
										Thread.Sleep(0xA);
									}
								}
							}
							catch (Exception ex)
							{
								if (typeof(ThreadAbortException) != ex.GetType())
								{
									ModBase.Log(ex, "下载管理刷新线程出错", ModBase.LogLevel.Assert, "出现错误");
								}
							}
						}, "NetManager StatRefresher", ThreadPriority.Normal);
					}
				}
			}

			// Token: 0x060007C9 RID: 1993 RVA: 0x0003BEF8 File Offset: 0x0003A0F8
			public void Start(ModNet.LoaderDownload Task)
			{
				this.StartManager();
				if (!this._ThreadAlgo)
				{
					try
					{
						ModBase.DeleteDirectory(ModBase.m_GlobalRule + "Download", false);
					}
					catch (Exception ex)
					{
						ModBase.Log(ex, "清理下载缓存失败", ModBase.LogLevel.Debug, "出现错误");
					}
					this._ThreadAlgo = true;
				}
				Directory.CreateDirectory(ModBase.m_GlobalRule + "Download");
				object codeAlgo = this._CodeAlgo;
				ObjectFlowControl.CheckForSyncLockOnValueType(codeAlgo);
				checked
				{
					lock (codeAlgo)
					{
						int num = Task.Files.Count - 1;
						int i = 0;
						while (i <= num)
						{
							ModNet.NetFile netFile = Task.Files[i];
							if (this.m_FacadeAlgo.ContainsKey(netFile.mapRule))
							{
								if (this.m_FacadeAlgo[netFile.mapRule].publisherRule >= ModNet.NetState.Finish)
								{
									object orderAlgo = netFile.orderAlgo;
									ObjectFlowControl.CheckForSyncLockOnValueType(orderAlgo);
									lock (orderAlgo)
									{
										netFile._ReponseRule.Add(Task);
									}
									this.m_FacadeAlgo[netFile.mapRule] = netFile;
									object obj = this.callbackAlgo;
									ObjectFlowControl.CheckForSyncLockOnValueType(obj);
									lock (obj)
									{
										ref int ptr = ref this.m_ObjectAlgo;
										this.m_ObjectAlgo = ptr + 1;
										if (ModBase.errorRule)
										{
											ModBase.Log("[Download] " + netFile.m_ComposerRule + "：已替换列表，剩余文件 " + Conversions.ToString(this.m_ObjectAlgo), ModBase.LogLevel.Normal, "出现错误");
										}
										goto IL_290;
									}
								}
								netFile = this.m_FacadeAlgo[netFile.mapRule];
								object orderAlgo2 = netFile.orderAlgo;
								ObjectFlowControl.CheckForSyncLockOnValueType(orderAlgo2);
								lock (orderAlgo2)
								{
									netFile._ReponseRule.Add(Task);
									goto IL_290;
								}
								goto IL_1DA;
							}
							goto IL_1DA;
							IL_290:
							Task.Files[i] = netFile;
							i++;
							continue;
							IL_1DA:
							object orderAlgo3 = netFile.orderAlgo;
							ObjectFlowControl.CheckForSyncLockOnValueType(orderAlgo3);
							lock (orderAlgo3)
							{
								netFile._ReponseRule.Add(Task);
							}
							this.m_FacadeAlgo.Add(netFile.mapRule, netFile);
							object obj2 = this.callbackAlgo;
							ObjectFlowControl.CheckForSyncLockOnValueType(obj2);
							lock (obj2)
							{
								ref int ptr = ref this.m_ObjectAlgo;
								this.m_ObjectAlgo = ptr + 1;
								if (ModBase.errorRule)
								{
									ModBase.Log("[Download] " + netFile.m_ComposerRule + "：已加入列表，剩余文件 " + Conversions.ToString(this.m_ObjectAlgo), ModBase.LogLevel.Normal, "出现错误");
								}
							}
							goto IL_290;
						}
					}
					object obj3 = this.bridgeAlgo;
					ObjectFlowControl.CheckForSyncLockOnValueType(obj3);
					lock (obj3)
					{
						this.m_MappingAlgo.Add(Task);
					}
				}
			}

			// Token: 0x040003F6 RID: 1014
			public Dictionary<string, ModNet.NetFile> m_FacadeAlgo;

			// Token: 0x040003F7 RID: 1015
			public readonly object _CodeAlgo;

			// Token: 0x040003F8 RID: 1016
			public List<ModNet.LoaderDownload> m_MappingAlgo;

			// Token: 0x040003F9 RID: 1017
			private readonly object bridgeAlgo;

			// Token: 0x040003FA RID: 1018
			private long singletonAlgo;

			// Token: 0x040003FB RID: 1019
			private readonly object errorAlgo;

			// Token: 0x040003FC RID: 1020
			public int m_ObjectAlgo;

			// Token: 0x040003FD RID: 1021
			public readonly object callbackAlgo;

			// Token: 0x040003FE RID: 1022
			private long workerAlgo;

			// Token: 0x040003FF RID: 1023
			public List<long> m_VisitorAlgo;

			// Token: 0x04000400 RID: 1024
			public long indexerAlgo;

			// Token: 0x04000401 RID: 1025
			public readonly int _MethodAlgo;

			// Token: 0x04000402 RID: 1026
			private long databaseAlgo;

			// Token: 0x04000403 RID: 1027
			private bool _AttrAlgo;

			// Token: 0x04000404 RID: 1028
			private bool _ThreadAlgo;
		}
	}
}
