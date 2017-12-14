using System.Collections.Generic;
using Tekla.Structures.Model;

namespace BoltChecker
{
	public static class TeklaExtensionMethods
	{
		public static List<ModelObject> ToList(this ModelObjectEnumerator enumerator)
		{
			enumerator.SelectInstances = false;

			var modelObjects = new List<ModelObject>();
			while (enumerator.MoveNext())
			{
				var modelObject = enumerator.Current;
				if (modelObject == null) continue;
				modelObjects.Add(modelObject);
			}

			return modelObjects;
		}
	}
}