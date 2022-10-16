using System;
using UnityEngine.Events;

namespace CompilerGenerated
{
	[Serializable]
	internal sealed class _0024adaptor_0024__Menus_PopupSingleCallback_0024callable2_00243643_34___0024UnityAction_00240
	{
		protected __Menus_PopupSingleCallback_0024callable2_00243643_34__ _0024from;

		public _0024adaptor_0024__Menus_PopupSingleCallback_0024callable2_00243643_34___0024UnityAction_00240(__Menus_PopupSingleCallback_0024callable2_00243643_34__ from)
		{
			_0024from = from;
		}

		public void Invoke(string arg0)
		{
			_0024from();
		}

		public static UnityAction<string> Adapt(__Menus_PopupSingleCallback_0024callable2_00243643_34__ from)
		{
			return new _0024adaptor_0024__Menus_PopupSingleCallback_0024callable2_00243643_34___0024UnityAction_00240(from).Invoke;
		}
	}
}
