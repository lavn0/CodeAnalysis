using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;

public static class XmlExtention
{
	public static IEnumerable<T> XPathEvaluate<T>(this XNode xnode, string xpath)
	{
		return ((IEnumerable<object>)xnode.XPathEvaluate(xpath)).Cast<T>();
	}
}
