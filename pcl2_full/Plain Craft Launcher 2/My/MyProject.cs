using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PCL.My
{
	// Token: 0x02000007 RID: 7
	[GeneratedCode("MyTemplate", "11.0.0.0")]
	[StandardModule]
	[HideModuleName]
	sealed class MyProject
	{
		// Token: 0x02000008 RID: 8
		[ComVisible(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal sealed class ThreadSafeObjectProvider<T> where T : new()
		{
			// Token: 0x06000016 RID: 22 RVA: 0x00002423 File Offset: 0x00000623
			[DebuggerHidden]
			internal T RestartIterator()
			{
				if (MyProject.ThreadSafeObjectProvider<T>.databaseRule == null)
				{
					MyProject.ThreadSafeObjectProvider<T>.databaseRule = Activator.CreateInstance<T>();
				}
				return MyProject.ThreadSafeObjectProvider<T>.databaseRule;
			}

			// Token: 0x06000017 RID: 23 RVA: 0x00002440 File Offset: 0x00000640
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public ThreadSafeObjectProvider()
			{
			}

			// Token: 0x04000001 RID: 1
			[CompilerGenerated]
			[ThreadStatic]
			private static T databaseRule;
		}
	}
}
