using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;

namespace PCL.My
{
	// Token: 0x02000009 RID: 9
	[StandardModule]
	[HideModuleName]
	sealed class MyWpfExtension
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00002448 File Offset: 0x00000648
		// Note: this type is marked as 'beforefieldinit'.
		static MyWpfExtension()
		{
			MyWpfExtension.m_Factory = new MyProject.ThreadSafeObjectProvider<Computer>();
			MyWpfExtension.val = new MyProject.ThreadSafeObjectProvider<User>();
			MyWpfExtension._Container = new MyProject.ThreadSafeObjectProvider<MyWpfExtension.MyWindows>();
			MyWpfExtension._Model = new MyProject.ThreadSafeObjectProvider<Log>();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002472 File Offset: 0x00000672
		internal static Application PopFactory()
		{
			return (Application)Application.Current;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000247E File Offset: 0x0000067E
		internal static Computer RunFactory()
		{
			return MyWpfExtension.m_Factory.RestartIterator();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000248A File Offset: 0x0000068A
		internal static User CollectFactory()
		{
			return MyWpfExtension.val.RestartIterator();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002496 File Offset: 0x00000696
		internal static Log FindFactory()
		{
			return MyWpfExtension._Model.RestartIterator();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000024A2 File Offset: 0x000006A2
		[DebuggerHidden]
		internal static MyWpfExtension.MyWindows SetupFactory()
		{
			return MyWpfExtension._Container.RestartIterator();
		}

		// Token: 0x04000002 RID: 2
		private static MyProject.ThreadSafeObjectProvider<Computer> m_Factory;

		// Token: 0x04000003 RID: 3
		private static MyProject.ThreadSafeObjectProvider<User> val;

		// Token: 0x04000004 RID: 4
		private static MyProject.ThreadSafeObjectProvider<MyWpfExtension.MyWindows> _Container;

		// Token: 0x04000005 RID: 5
		private static MyProject.ThreadSafeObjectProvider<Log> _Model;

		// Token: 0x0200000A RID: 10
		[MyGroupCollection("System.Windows.Window", "Create__Instance__", "Dispose__Instance__", "My.MyWpfExtenstionModule.Windows")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal sealed class MyWindows
		{
			// Token: 0x0600001E RID: 30 RVA: 0x0000D3F8 File Offset: 0x0000B5F8
			[DebuggerHidden]
			private static T Create__Instance__<T>(T Instance) where T : Window, new()
			{
				T result;
				if (Instance == null)
				{
					if (MyWpfExtension.MyWindows._AttrRule != null)
					{
						if (MyWpfExtension.MyWindows._AttrRule.ContainsKey(typeof(T)))
						{
							throw new InvalidOperationException("The window cannot be accessed via My.Windows from the Window constructor.");
						}
					}
					else
					{
						MyWpfExtension.MyWindows._AttrRule = new Hashtable();
					}
					MyWpfExtension.MyWindows._AttrRule.Add(typeof(T), null);
					result = Activator.CreateInstance<T>();
				}
				else
				{
					result = Instance;
				}
				return result;
			}

			// Token: 0x0600001F RID: 31 RVA: 0x000024AE File Offset: 0x000006AE
			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance) where T : Window
			{
				instance = default(T);
			}

			// Token: 0x06000020 RID: 32 RVA: 0x00002440 File Offset: 0x00000640
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public MyWindows()
			{
			}

			// Token: 0x06000021 RID: 33 RVA: 0x000024B7 File Offset: 0x000006B7
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			// Token: 0x06000022 RID: 34 RVA: 0x000024C5 File Offset: 0x000006C5
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x06000023 RID: 35 RVA: 0x000024CD File Offset: 0x000006CD
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal new Type GetType()
			{
				return typeof(MyWpfExtension.MyWindows);
			}

			// Token: 0x06000024 RID: 36 RVA: 0x000024D9 File Offset: 0x000006D9
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override string ToString()
			{
				return base.ToString();
			}

			// Token: 0x06000025 RID: 37 RVA: 0x000024E1 File Offset: 0x000006E1
			public FormLoginOAuth PopExpression()
			{
				this.threadRule = MyWpfExtension.MyWindows.Create__Instance__<FormLoginOAuth>(this.threadRule);
				return this.threadRule;
			}

			// Token: 0x06000026 RID: 38 RVA: 0x000024FA File Offset: 0x000006FA
			public FormMain SearchExpression()
			{
				this._ManagerRule = MyWpfExtension.MyWindows.Create__Instance__<FormMain>(this._ManagerRule);
				return this._ManagerRule;
			}

			// Token: 0x06000027 RID: 39 RVA: 0x00002513 File Offset: 0x00000713
			public void VerifyExpression(FormLoginOAuth Value)
			{
				if (Value != this.threadRule)
				{
					if (Value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					this.Dispose__Instance__<FormLoginOAuth>(ref this.threadRule);
				}
			}

			// Token: 0x06000028 RID: 40 RVA: 0x00002538 File Offset: 0x00000738
			public void CollectExpression(FormMain Value)
			{
				if (Value != this._ManagerRule)
				{
					if (Value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					this.Dispose__Instance__<FormMain>(ref this._ManagerRule);
				}
			}

			// Token: 0x04000006 RID: 6
			[ThreadStatic]
			private static Hashtable _AttrRule;

			// Token: 0x04000007 RID: 7
			[EditorBrowsable(EditorBrowsableState.Never)]
			public FormLoginOAuth threadRule;

			// Token: 0x04000008 RID: 8
			[EditorBrowsable(EditorBrowsableState.Never)]
			public FormMain _ManagerRule;
		}
	}
}
