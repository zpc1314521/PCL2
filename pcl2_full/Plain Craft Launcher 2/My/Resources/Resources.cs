using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace PCL.My.Resources
{
	// Token: 0x0200000B RID: 11
	[StandardModule]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[CompilerGenerated]
	[HideModuleName]
	sealed class Resources
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000029 RID: 41 RVA: 0x0000255D File Offset: 0x0000075D
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager PostFactory
		{
			get
			{
				if (object.ReferenceEquals(Resources.m_Iterator, null))
				{
					Resources.m_Iterator = new ResourceManager("PCL.Resources", typeof(Resources).Assembly);
				}
				return Resources.m_Iterator;
			}
		}

		// Token: 0x17000002 RID: 2
		// (set) Token: 0x0600002A RID: 42 RVA: 0x0000258F File Offset: 0x0000078F
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo LoginFactory
		{
			set
			{
				Resources.expression = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002597 File Offset: 0x00000797
		internal static byte[] Custom
		{
			get
			{
				return (byte[])RuntimeHelpers.GetObjectValue(Resources.PostFactory.GetObject("Custom", Resources.expression));
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600002C RID: 44 RVA: 0x000025B7 File Offset: 0x000007B7
		internal static byte[] Dialogs
		{
			get
			{
				return (byte[])RuntimeHelpers.GetObjectValue(Resources.PostFactory.GetObject("Dialogs", Resources.expression));
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000025D7 File Offset: 0x000007D7
		internal static byte[] ForgeInstaller
		{
			get
			{
				return (byte[])RuntimeHelpers.GetObjectValue(Resources.PostFactory.GetObject("ForgeInstaller", Resources.expression));
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002E RID: 46 RVA: 0x000025F7 File Offset: 0x000007F7
		internal static byte[] Help
		{
			get
			{
				return (byte[])RuntimeHelpers.GetObjectValue(Resources.PostFactory.GetObject("Help", Resources.expression));
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002617 File Offset: 0x00000817
		internal static byte[] Json
		{
			get
			{
				return (byte[])RuntimeHelpers.GetObjectValue(Resources.PostFactory.GetObject("Json", Resources.expression));
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002637 File Offset: 0x00000837
		internal static byte[] ModData
		{
			get
			{
				return (byte[])RuntimeHelpers.GetObjectValue(Resources.PostFactory.GetObject("ModData", Resources.expression));
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002657 File Offset: 0x00000857
		internal static byte[] NAudio
		{
			get
			{
				return (byte[])RuntimeHelpers.GetObjectValue(Resources.PostFactory.GetObject("NAudio", Resources.expression));
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002677 File Offset: 0x00000877
		internal static byte[] Transformer
		{
			get
			{
				return (byte[])RuntimeHelpers.GetObjectValue(Resources.PostFactory.GetObject("Transformer", Resources.expression));
			}
		}

		// Token: 0x04000009 RID: 9
		private static ResourceManager m_Iterator;

		// Token: 0x0400000A RID: 10
		private static CultureInfo expression;
	}
}
