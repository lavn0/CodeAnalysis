﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxCopCustomUnitTest
{
	[TestClass]
	public class FxCopCustomUnitTest : BaseFxCopUnitTest
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void ConcatConstStringSample()
		{
			Assert.AreEqual(1, this.GetErrors("ConcatConstString", "ConcatConstStringSample", "NG1()").Count, "NG1()");
			Assert.AreEqual(1, this.GetErrors("ConcatConstString", "ConcatConstStringSample", "NG2()").Count, "NG2()");
			Assert.AreEqual(2, this.GetErrors("ConcatConstString", "ConcatConstStringSample", "NG3()").Count, "NG3()");
			Assert.AreEqual(2, this.GetErrors("ConcatConstString", "ConcatConstStringSample", "NG4()").Count, "NG4()");
			Assert.AreEqual(3, this.GetErrors("ConcatConstString", "ConcatConstStringSample", "NG5()").Count, "NG5()");
			Assert.AreEqual(0, this.GetErrors("ConcatConstString", "ConcatConstStringSample", "OK1()").Count, "OK1()");
			Assert.AreEqual(9, this.GetErrors("ConcatConstString", "ConcatConstStringSample").Count);
		}

		[TestMethod]
		public void DontDefineMemberSample()
		{
			Assert.AreEqual(0, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "IsMethodOK()").Count, "IsMethodOK()");
			Assert.AreEqual(0, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "AddOK()").Count, "AddOK()");
			Assert.AreEqual(0, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "PutOK()").Count, "PutOK()");
			Assert.AreEqual(0, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "RemoveOK()").Count, "RemoveOK()");
			Assert.AreEqual(1, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "IsMethodNG()").Count, "IsMethodNG()");
			Assert.AreEqual(1, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "StartsWithNG()").Count, "StartsWithNG()");
			Assert.AreEqual(1, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "EndsWith()").Count, "EndsWith()");
			Assert.AreEqual(0, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "IsPropertyOK").Count, "IsPropertyOK");
			Assert.AreEqual(1, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "IsPropertyNG").Count, "IsPropertyNG");
			Assert.AreEqual(0, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "IsFieldOK").Count, "IsFieldOK");
			Assert.AreEqual(1, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "IsFieldNG").Count, "IsFieldNG");
			Assert.AreEqual(1, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "CanFieldNG").Count, "CanFieldNG");
			Assert.AreEqual(1, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "HasFieldNG").Count, "HasFieldNG");
			Assert.AreEqual(1, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "ShouldFieldNG").Count, "ShouldFieldNG");
			Assert.AreEqual(1, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "CouldFieldNG").Count, "CouldFieldNG");
			Assert.AreEqual(1, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "WillFieldNG").Count, "WillFieldNG");
			Assert.AreEqual(1, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "ShallFieldNG").Count, "ShallFieldNG");
			Assert.AreEqual(1, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "CheckFieldNG").Count, "CheckFieldNG");
			Assert.AreEqual(1, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "ContainsFieldNG").Count, "ContainsFieldNG");
			Assert.AreEqual(1, this.GetErrors("DontDefineMember", "DontDefineMemberSample", "EqualsFieldNG").Count, "EqualsFieldNG");
			Assert.AreEqual(14, this.GetErrors("DontDefineMember", "DontDefineMemberSample").Count);
		}

		[TestMethod]
		public void DontPassParameterTypeSample()
		{
			Assert.AreEqual(0, this.GetErrors("DontPassParameterType", "DontPassParameterTypeSample", "OK1()").Count, "OK1()");
			Assert.AreEqual(1, this.GetErrors("DontPassParameterType", "DontPassParameterTypeSample", "NG1()").Count, "NG1()");
			Assert.AreEqual(1, this.GetErrors("DontPassParameterType", "DontPassParameterTypeSample").Count);
		}

		[TestMethod]
		public void DontUseMethodSample()
		{
			Assert.AreEqual(0, this.GetErrors("DontUseMethod", "DontUseMethodSample", "OK()").Count, "OK()");
			Assert.AreEqual(1, this.GetErrors("DontUseMethod", "DontUseMethodSample", "NG1()").Count, "NG1()");
			Assert.AreEqual(1, this.GetErrors("DontUseMethod", "DontUseMethodSample").Count);
		}

		[TestMethod]
		public void LinqResultComparedByNullSample()
		{
			Assert.AreEqual(1, this.GetErrors("LinqResultComparedByNull", "LinqResultComparedByNullSample", "NG1()").Count, "NG1()");
			Assert.AreEqual(1, this.GetErrors("LinqResultComparedByNull", "LinqResultComparedByNullSample", "NG2()").Count, "NG2()");
			Assert.AreEqual(0, this.GetErrors("LinqResultComparedByNull", "LinqResultComparedByNullSample", "OK1()").Count, "OK1()");
			Assert.AreEqual(2, this.GetErrors("LinqResultComparedByNull", "LinqResultComparedByNullSample").Count);
		}

		[TestMethod]
		public void NeedToCatchSample()
		{
			Assert.AreEqual(0, this.GetErrors("NeedToCatch", "NeedToCatchSample", "OK1()").Count, "OK1()");
			Assert.AreEqual(0, this.GetErrors("NeedToCatch", "NeedToCatchSample", "OK2()").Count, "OK2()");
			Assert.AreEqual(1, this.GetErrors("NeedToCatch", "NeedToCatchSample", "NG1()").Count, "NG1()");
			Assert.AreEqual(1, this.GetErrors("NeedToCatch", "NeedToCatchSample", "NG2()").Count, "NG2()");
			Assert.AreEqual(1, this.GetErrors("NeedToCatch", "NeedToCatchSample", "NG3()").Count, "NG3()");
			Assert.AreEqual(1, this.GetErrors("NeedToCatch", "NeedToCatchSample", "NG4()").Count, "NG4()");
			Assert.AreEqual(4, this.GetErrors("NeedToCatch", "NeedToCatchSample").Count);
		}

		[TestMethod]
		public void StaticMethodShouldNotCallDateTimeNowSample()
		{
			Assert.AreEqual(0, this.GetErrors("StaticMethodShouldNotCallDateTimeNow", "StaticMethodShouldNotCallDateTimeNowSample", "OK()").Count, "OK()");
			Assert.AreEqual(1, this.GetErrors("StaticMethodShouldNotCallDateTimeNow", "StaticMethodShouldNotCallDateTimeNowSample", "NG()").Count, "NG()");
			Assert.AreEqual(1, this.GetErrors("StaticMethodShouldNotCallDateTimeNow", "StaticMethodShouldNotCallDateTimeNowSample").Count);
		}

		[TestMethod]
		public void UnusedReasignSample()
		{
			Assert.AreEqual(1, this.GetErrors("UnusedReasign", "UnusedReasignSample", "NG1()").Count, "NG1()");
			Assert.AreEqual(1, this.GetErrors("UnusedReasign", "UnusedReasignSample", "NG2()").Count, "NG2()");
			Assert.AreEqual(1, this.GetErrors("UnusedReasign", "UnusedReasignSample", "NG3()").Count, "NG3()");
			Assert.AreEqual(1, this.GetErrors("UnusedReasign", "UnusedReasignSample", "NG4()").Count, "NG4()");
			Assert.AreEqual(0, this.GetErrors("UnusedReasign", "UnusedReasignSample", "OK1()").Count, "OK1()");
			Assert.AreEqual(0, this.GetErrors("UnusedReasign", "UnusedReasignSample", "OK2()").Count, "OK2()");
			Assert.AreEqual(0, this.GetErrors("UnusedReasign", "UnusedReasignSample", "OK3()").Count, "OK3()");
			Assert.AreEqual(4, this.GetErrors("UnusedReasign", "UnusedReasignSample").Count);
		}

		[TestMethod]
		public void AsignedConstOnlySample()
		{
			Assert.AreEqual(1, this.GetErrors("AsignedConstOnly", "AsignedConstOnlySample", "NG1()").Count, "NG1()");
			Assert.AreEqual(1, this.GetErrors("AsignedConstOnly", "AsignedConstOnlySample", "NG2()").Count, "NG2()");
			Assert.AreEqual(1, this.GetErrors("AsignedConstOnly", "AsignedConstOnlySample", "NG3()").Count, "NG3()");
			Assert.AreEqual(0, this.GetErrors("AsignedConstOnly", "AsignedConstOnlySample", "OK1()").Count, "OK1()");
			Assert.AreEqual(0, this.GetErrors("AsignedConstOnly", "AsignedConstOnlySample", "OK2()").Count, "OK2()");
			Assert.AreEqual(0, this.GetErrors("AsignedConstOnly", "AsignedConstOnlySample", "OK3()").Count, "OK3()");
			Assert.AreEqual(3, this.GetErrors("AsignedConstOnly", "AsignedConstOnlySample").Count);
		}

		[TestMethod]
		public void CompareZeroToCountResultSample()
		{
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK1_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK1_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK2_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK2_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK4_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK4_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK5_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK5_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK7_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK7_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK8_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK8_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK10_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK10_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK11_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK11_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK13_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK13_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK14_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK14_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK16_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK16_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK17_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK17_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK20_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK20_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK23_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK23_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK26_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK26_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK29_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK29_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK31_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK31_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK32_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK32_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK34_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK34_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(0, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "OK35_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "OK35_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG1_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG1_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Any", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG1_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG1_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG2_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG2_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("TakeCount", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG2_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG2_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG3_Error(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG3_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Error", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG3_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG3_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG4_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG4_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Any", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG4_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG4_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG5_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG5_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("TakeCount", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG5_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG5_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG6_Error(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG6_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Error", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG6_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG6_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG7_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG7_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Any", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG7_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG7_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG8_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG8_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("TakeCount", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG8_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG8_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG9_Error(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG9_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Error", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG9_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG9_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG10_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG10_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Any", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG10_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG10_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG11_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG11_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("TakeCount", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG11_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG11_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG12_Error(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG12_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Error", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG12_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG12_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG13_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG13_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Any", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG13_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG13_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG14_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG14_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("SkipAny", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG14_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG14_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG15_Error(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG15_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Error", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG15_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG15_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG16_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG16_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Any", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG16_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG16_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG17_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG17_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("SkipAny", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG17_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG17_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG18_Error(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG18_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Error", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG18_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG18_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG19_Error(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG19_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Error", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG19_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG19_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG20_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG20_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Any", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG20_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG20_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG21_Error(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG21_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Error", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG21_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG21_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG22_Error(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG22_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Error", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG22_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG22_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG23_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG23_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Any", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG23_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG23_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG24_Error(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG24_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Error", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG24_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG24_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG25_Error(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG25_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Error", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG25_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG25_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG26_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG26_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Any", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG26_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG26_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG27_Error(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG27_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Error", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG27_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG27_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG28_Error(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG28_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Error", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG28_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG28_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG29_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG29_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Any", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG29_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG29_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG30_Error(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG30_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Error", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG30_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG30_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG31_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG31_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Any", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG31_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG31_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG32_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG32_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("SkipAny", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG32_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG32_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG33_Error(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG33_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Error", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG33_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG33_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG34_Any(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG34_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Any", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG34_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG34_Any(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG35_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG35_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("SkipAny", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG35_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG35_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(1, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG36_Error(System.Collections.Generic.IEnumerable`1<System.Object>)").Count, "NG36_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual("Error", this.GetError("CompareZeroToCountResult", "CompareZeroToCountResultSample", "NG36_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value, "ResolutionName: NG36_Error(System.Collections.Generic.IEnumerable`1<System.Object>)");
			Assert.AreEqual(36, this.GetErrors("CompareZeroToCountResult", "CompareZeroToCountResultSample").Count);
		}
	}
}