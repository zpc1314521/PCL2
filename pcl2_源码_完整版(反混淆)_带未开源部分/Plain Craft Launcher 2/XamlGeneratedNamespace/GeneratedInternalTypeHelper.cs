using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Markup;

namespace PCL.XamlGeneratedNamespace
{
	// Token: 0x020001B0 RID: 432
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	public sealed class GeneratedInternalTypeHelper : InternalTypeHelper
	{
		// Token: 0x060012BB RID: 4795 RVA: 0x0000BC4A File Offset: 0x00009E4A
		protected override object CreateInstance(Type type, CultureInfo culture)
		{
			return Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance, null, null, culture);
		}

		// Token: 0x060012BC RID: 4796 RVA: 0x0000BC5A File Offset: 0x00009E5A
		protected override object GetPropertyValue(PropertyInfo propertyInfo, object target, CultureInfo culture)
		{
			return propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(target), BindingFlags.Default, null, null, culture);
		}

		// Token: 0x060012BD RID: 4797 RVA: 0x0000BC6C File Offset: 0x00009E6C
		protected override void SetPropertyValue(PropertyInfo propertyInfo, object target, object value, CultureInfo culture)
		{
			propertyInfo.SetValue(RuntimeHelpers.GetObjectValue(target), RuntimeHelpers.GetObjectValue(value), BindingFlags.Default, null, null, culture);
		}

		// Token: 0x060012BE RID: 4798 RVA: 0x00089A08 File Offset: 0x00087C08
		protected override Delegate CreateDelegate(Type delegateType, object target, string handler)
		{
			return (Delegate)target.GetType().InvokeMember("_CreateDelegate", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, RuntimeHelpers.GetObjectValue(target), new object[]
			{
				delegateType,
				handler
			}, null);
		}

		// Token: 0x060012BF RID: 4799 RVA: 0x0000BC85 File Offset: 0x00009E85
		protected override void AddEventHandler(EventInfo eventInfo, object target, Delegate handler)
		{
			eventInfo.AddEventHandler(RuntimeHelpers.GetObjectValue(target), handler);
		}
	}
}
