using System;
using System.Reflection;

// Token: 0x020001BD RID: 445
class Class0
{
	// Token: 0x060012C0 RID: 4800 RVA: 0x00089A48 File Offset: 0x00087C48
	internal static void RemoveProduct(int typemdt)
	{
		Type type = Class0._ConsumerMapper.ResolveType(0x2000000 + typemdt);
		foreach (FieldInfo fieldInfo in type.GetFields())
		{
			MethodInfo method = (MethodInfo)Class0._ConsumerMapper.ResolveMethod(fieldInfo.MetadataToken + 0x6000000);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	// Token: 0x060012C2 RID: 4802 RVA: 0x0000BC94 File Offset: 0x00009E94
	// Note: this type is marked as 'beforefieldinit'.
	static Class0()
	{
		Class0._ConsumerMapper = typeof(Class0).Assembly.ManifestModule;
	}

	// Token: 0x04000A26 RID: 2598
	internal static Module _ConsumerMapper;

	// Token: 0x020001BE RID: 446
	// (Invoke) Token: 0x060012C4 RID: 4804
	internal delegate void Delegate0(object o);
}
