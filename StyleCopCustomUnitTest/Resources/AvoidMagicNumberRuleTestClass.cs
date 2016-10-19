namespace StyleCopCustomUnitTest.Resources
{
	public class AvoidMagicNumberRuleTestClass
	{
		public static void ViolateMethod(string str, int slesholdCount, bool isVisible, bool isEnabled, bool? isChecked)
		{
		}

		public void OK1()
		{
			// 名前付き引数で指定すれば、マジックナンバー扱いしない
			AvoidMagicNumberRuleTestClass.ViolateMethod(str: "value", slesholdCount: 10, isVisible: true, isEnabled: false, isChecked: null);
		}

		public void OK2()
		{
			// 変数で指定すれば、マジックナンバー扱いしない
			string str = "value";
			int slesholdCount = 10;
			bool isVisible = true;
			bool isEnabled = false;
			bool? isChecked = null;
			AvoidMagicNumberRuleTestClass.ViolateMethod(str, slesholdCount, isVisible, isEnabled, isChecked);
		}

		public void NG1()
		{
			// 固定値で指定すれば、マジックナンバー扱い
			AvoidMagicNumberRuleTestClass.ViolateMethod("value", 10, true, false, null);
		}

		public void NG2()
		{
			// 式も固定値と判断できればNG
			AvoidMagicNumberRuleTestClass.ViolateMethod("va" + "l" + "ue", 10 * 10 * 10, true & false | true, false && true || false, true & false || true);
		}

		public void OK3()
		{
			string str = "value";
			int slesholdCount = 10;
			bool isVisible = true;
			bool isEnabled = false;
			bool? isChecked = null;

			// 式だろうと、変数値が交じれば例外
			AvoidMagicNumberRuleTestClass.ViolateMethod(
				str + "va" + "l" + "ue",
				slesholdCount + 10 * 10 * 10,
				isVisible & true & false | true,
				isEnabled && false && true || false,
				isChecked | true & false || true);
		}
	}
}
