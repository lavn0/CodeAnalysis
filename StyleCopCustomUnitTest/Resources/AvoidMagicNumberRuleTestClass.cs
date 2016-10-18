namespace StyleCopCustomUnitTest.Resources
{
	public class AvoidMagicNumberRuleTestClass
	{
		private void ViolateMethod(string str, int slesholdCount, bool isVisible, bool isEnabled)
		{
		}

		public void OK1()
		{
			// 名前付き引数で指定すれば、マジックナンバー扱いしない
			ViolateMethod(str: "value", slesholdCount: 10, isVisible: true, isEnabled: false);
		}

		public void OK2()
		{
			// 変数で指定すれば、マジックナンバー扱いしない
			string str = "value";
			int slesholdCount = 10;
			bool isVisible = true;
			bool isEnabled = false;
			ViolateMethod(str, slesholdCount, isVisible, isEnabled);
		}

		public void NG1()
		{
			// 固定値で指定すれば、マジックナンバー扱い
			ViolateMethod("value", 10, true, false);
		}
	}
}
