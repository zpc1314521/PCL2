using System;
using System.Collections.Generic;
using System.Net;

namespace PCL
{
	// Token: 0x02000067 RID: 103
	public class CookieWebClient : WebClient
	{
		// Token: 0x060002BF RID: 703 RVA: 0x0001B038 File Offset: 0x00019238
		public CookieWebClient(CookieContainer container, Dictionary<string, string> Headers) : this(container)
		{
			try
			{
				foreach (KeyValuePair<string, string> keyValuePair in Headers)
				{
					base.Headers[keyValuePair.Key] = keyValuePair.Value;
				}
			}
			finally
			{
				Dictionary<string, string>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00003B84 File Offset: 0x00001D84
		public CookieWebClient() : this(new CookieContainer())
		{
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00003B91 File Offset: 0x00001D91
		public CookieWebClient(CookieContainer container)
		{
			this.m_StatusVal = new CookieContainer();
			this.requestVal = 0x927C0;
			ServicePointManager.Expect100Continue = false;
			ServicePointManager.MaxServicePointIdleTime = 0x7D0;
			this.m_StatusVal = container;
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0001B0A0 File Offset: 0x000192A0
		protected override WebRequest GetWebRequest(Uri address)
		{
			WebRequest webRequest = base.GetWebRequest(address);
			HttpWebRequest httpWebRequest = webRequest as HttpWebRequest;
			if (httpWebRequest != null)
			{
				httpWebRequest.CookieContainer = this.m_StatusVal;
				httpWebRequest.Timeout = this.requestVal;
			}
			return webRequest;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0001B0D8 File Offset: 0x000192D8
		protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
		{
			WebResponse webResponse = base.GetWebResponse(request, result);
			this.ReadCookies(webResponse);
			return webResponse;
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0001B0F8 File Offset: 0x000192F8
		protected override WebResponse GetWebResponse(WebRequest request)
		{
			WebResponse webResponse = base.GetWebResponse(request);
			this.ReadCookies(webResponse);
			return webResponse;
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0001B118 File Offset: 0x00019318
		private void ReadCookies(WebResponse r)
		{
			HttpWebResponse httpWebResponse = r as HttpWebResponse;
			if (httpWebResponse != null)
			{
				CookieCollection cookies = httpWebResponse.Cookies;
				this.m_StatusVal.Add(cookies);
			}
		}

		// Token: 0x04000169 RID: 361
		private readonly CookieContainer m_StatusVal;

		// Token: 0x0400016A RID: 362
		public int requestVal;
	}
}
