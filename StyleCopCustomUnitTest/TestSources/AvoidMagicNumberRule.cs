namespace StyleCopCustomUnitTest.TestSources
{
	public class AvoidMagicNumberRule
	{
		public static void ViolateMethod(string str, int slesholdCount, bool isVisible, bool isEnabled, bool? isChecked)
		{
		}

		public void OK1()
		{
			// 名前付き引数で指定すれば、マジックナンバー扱いしない
			AvoidMagicNumberRule.ViolateMethod(str: "value", slesholdCount: 10, isVisible: true, isEnabled: false, isChecked: null);
		}

		public void OK2()
		{
			// 変数で指定すれば、マジックナンバー扱いしない
			string str = "value";
			int slesholdCount = 10;
			bool isVisible = true;
			bool isEnabled = false;
			bool? isChecked = null;
			AvoidMagicNumberRule.ViolateMethod(str, slesholdCount, isVisible, isEnabled, isChecked);
		}

		public void NG1()
		{
			// 固定値で指定すれば、マジックナンバー扱い
			// ERROR(39,45) "value"
			// ERROR(48,49) 10
			// ERROR(52,55) true
			// ERROR(58,62) false
			// ERROR(65,68) null
			AvoidMagicNumberRule.ViolateMethod("value", 10, true, false, null);
		}

		public void NG2()
		{
			// 式も固定値と判断できればNG
			// ERROR(39,55) "va" + "l" + "ue"
			// ERROR(58,69) 10 * 10 * 10
			// ERROR(72,90) true & false | true
			// ERROR(93,114) false && true || false
			// ERROR(117,136) true & false || true
			AvoidMagicNumberRule.ViolateMethod("va" + "l" + "ue", 10 * 10 * 10, true & false | true, false && true || false, true & false || true);
		}

		public void OK3()
		{
			string str = "value";
			int slesholdCount = 10;
			bool isVisible = true;
			bool isEnabled = false;
			bool? isChecked = null;

			// 式だろうと、変数値が交じれば例外
			AvoidMagicNumberRule.ViolateMethod(
				str + "va" + "l" + "ue",
				slesholdCount + 10 * 10 * 10,
				isVisible & true & false | true,
				isEnabled && false && true || false,
				isChecked.Value | true & false || true);
		}
	}
}
