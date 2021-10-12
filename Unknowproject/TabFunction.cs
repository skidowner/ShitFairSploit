using System;
using System.Windows.Controls;

namespace Unknowproject
{
	// Token: 0x02000002 RID: 2
	internal static class TabFunction
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static T GetTemplateItem<T>(this Control elem, string name)
		{
			object obj = elem.Template.FindName(name, elem);
			T result;
			if (obj is T)
			{
				T t = (T)((object)obj);
				result = t;
			}
			else
			{
				result = default(T);
			}
			return result;
		}
	}
}
