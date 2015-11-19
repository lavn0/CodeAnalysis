using Microsoft.FxCop.Sdk;
using System.Linq;

namespace FxCopCustom
{
	/// <summary><see cref="System"/>名前空間のメンバーです。</summary>
	/// <seealso cref="Munyabe.FxCop.Rules"/>
	public static class SystemMembers
	{
		private static readonly Method ObjectGetHashCodeMethod = FrameworkTypes.Object.GetMethod(Identifier.For("GetHashCode"));
		private static readonly Method EnumerableCount_Method = GetOneParamEnumerableMethod("Count");
		private static readonly Method EnumerableAnyMethod = GetOneParamEnumerableMethod("Any");
		private static readonly Method EnumerableFirstMethod = GetOneParamEnumerableMethod("First");
		private static readonly Method EnumerableFirstOrDefaultMethod = GetOneParamEnumerableMethod("FirstOrDefault");
		private static readonly Method EnumerableOrderByMethod = GetFirstEnumerableMethod("OrderBy");
		private static readonly Method EnumerableThenByMethod = GetFirstEnumerableMethod("ThenBy");
		private static readonly Method IDictionaryContainsKeyMethod = FrameworkTypes.GenericIDictionary.GetMethod(Identifier.For("ContainsKey"), FrameworkTypes.GenericIDictionary.TemplateParameters[0]);
		private static readonly PropertyNode IDictionaryIndexerProperty = FrameworkTypes.GenericIDictionary.GetProperty(Identifier.For("Item"), FrameworkTypes.GenericIDictionary.TemplateParameters[0]);

		/// <summary><see cref="object.GetHashCode"/>のメソッドです。</summary>
		public static Method ObjectGetHashCode
		{
			get { return ObjectGetHashCodeMethod; }
		}

		/// <summary><see cref="System.Linq.Enumerable.Count{TSource}(System.Collections.Generic.IEnumerable{TSource})"/>のメソッドです。</summary>
		public static Method EnumerableCount
		{
			get { return EnumerableCount_Method; }
		}

		/// <summary><see cref="System.Linq.Enumerable.Any{TSource}(System.Collections.Generic.IEnumerable{TSource})"/>のメソッドです。</summary>
		public static Method EnumerableAny
		{
			get { return EnumerableAnyMethod; }
		}

		/// <summary><see cref="System.Linq.Enumerable.First{TSource}(System.Collections.Generic.IEnumerable{TSource})"/>のメソッドです。</summary>
		public static Method EnumerableFirst
		{
			get { return EnumerableFirstMethod; }
		}

		/// <summary><see cref="System.Linq.Enumerable.FirstOrDefault{TSource}(System.Collections.Generic.IEnumerable{TSource})"/>のメソッドです。</summary>
		public static Method EnumerableFirstOrDefault
		{
			get { return EnumerableFirstOrDefaultMethod; }
		}

		/// <summary><see cref="System.Linq.Enumerable.OrderBy{TSource, TKey}(System.Collections.Generic.IEnumerable{TSource}, System.Func{TSource, TKey})"/>のメソッドです。</summary>
		public static Method EnumerableOrderBy
		{
			get { return EnumerableOrderByMethod; }
		}

		/// <summary><see cref="System.Linq.Enumerable.ThenBy{TSource, TKey}(IOrderedEnumerable{TSource}, System.Func{TSource, TKey})"/>のメソッドです。</summary>
		public static Method EnumerableThenBy
		{
			get { return EnumerableThenByMethod; }
		}

		/// <summary><see cref="System.Collections.Generic.IDictionary{TKey, TValue}.ContainsKey(TKey)"/>のメソッドです。</summary>
		public static Method IDictionaryContainsKey
		{
			get { return IDictionaryContainsKeyMethod; }
		}

		/// <summary><see cref="System.Collections.Generic.IDictionary{TKey, TValue}"/>のインデクサーです。</summary>
		public static PropertyNode IDictionaryIndexer
		{
			get { return IDictionaryIndexerProperty; }
		}

		/// <summary><see cref="System.IEquatable{T}"/>のパラメーターのみ取る<see cref="System.Linq.Enumerable"/>のメソッドを取得します。</summary>
		/// <param name="methodName">メソッド名</param>
		/// <returns><see cref="System.IEquatable{T}"/>のメソッドの最初の候補</returns>
		private static Method GetOneParamEnumerableMethod(string methodName)
		{
			return FrameworkAssemblies.SystemCore == null
				? null
				: FrameworkAssemblies.SystemCore
					.GetType(Identifier.For("System.Linq"), Identifier.For("Enumerable"))
					.GetMembersNamed(Identifier.For(methodName))
					.OfType<Method>()
					.First(method => method.Parameters.Count == 1 && method.Parameters[0].Type.IsAssignableToInstanceOf(FrameworkTypes.GenericIEnumerable));
		}

		/// <summary><see cref="System.Linq.Enumerable"/>のメソッドの最初の候補を取得します。</summary>
		/// <param name="methodName">メソッド名</param>
		/// <returns><see cref="System.Linq.Enumerable"/>のメソッドの最初の候補</returns>
		private static Method GetFirstEnumerableMethod(string methodName)
		{
			return FrameworkAssemblies.SystemCore == null
				? null
				: FrameworkAssemblies.SystemCore
					.GetType(Identifier.For("System.Linq"), Identifier.For("Enumerable"))
					.GetMembersNamed(Identifier.For(methodName))
					.OfType<Method>()
					.First();
		}
	}
}