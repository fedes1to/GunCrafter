using System;

namespace CompilerGenerated
{
	[Serializable]
	internal sealed class _0024adaptor_0024__Menus_0024callable10_00248379_64___0024Action_00244
	{
		protected __Menus_0024callable10_00248379_64__ _0024from;

		public _0024adaptor_0024__Menus_0024callable10_00248379_64___0024Action_00244(__Menus_0024callable10_00248379_64__ from)
		{
			_0024from = from;
		}

		public void Invoke(bool arg1, string arg2)
		{
			_0024from(arg1);
		}

		public static Action<bool, string> Adapt(__Menus_0024callable10_00248379_64__ from)
		{
			return new _0024adaptor_0024__Menus_0024callable10_00248379_64___0024Action_00244(from).Invoke;
		}
	}
}
