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
			// ERROR(48,54) "value"
			// ERROR(57,58) 10
			// ERROR(61,64) true
			// ERROR(67,71) false
			// ERROR(74,77) null
			AvoidMagicNumberRuleTestClass.ViolateMethod("value", 10, true, false, null);
		}

		public void NG2()
		{
			// 式も固定値と判断できればNG
			// ERROR(48,64) "va" + "l" + "ue"
			// ERROR(67,78) 10 * 10 * 10
			// ERROR(81,99) true & false | true
			// ERROR(102,123) false && true || false
			// ERROR(126,145) true & false || true
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
				isChecked.Value | true & false || true);
		}
	}
}
