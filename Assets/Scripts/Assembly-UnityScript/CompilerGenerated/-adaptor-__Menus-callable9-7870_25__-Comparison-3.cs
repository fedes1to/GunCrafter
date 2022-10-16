using System;

namespace CompilerGenerated
{
	[Serializable]
	internal sealed class _0024adaptor_0024__Menus_0024callable9_00247870_25___0024Comparison_00243
	{
		protected __Menus_0024callable9_00247870_25__ _0024from;

		public _0024adaptor_0024__Menus_0024callable9_00247870_25___0024Comparison_00243(__Menus_0024callable9_00247870_25__ from)
		{
			_0024from = from;
		}

		public int Invoke(OnlinePlayer x, OnlinePlayer y)
		{
			return _0024from(x, y);
		}

		public static Comparison<OnlinePlayer> Adapt(__Menus_0024callable9_00247870_25__ from)
		{
			return new _0024adaptor_0024__Menus_0024callable9_00247870_25___0024Comparison_00243(from).Invoke;
		}
	}
}
