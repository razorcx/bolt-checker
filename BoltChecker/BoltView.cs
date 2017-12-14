using Tekla.Structures.Model;

namespace BoltChecker
{
	public class BoltView
	{
		public string Size { get; set; }
		public string Standard { get; set; }
		public BoltGroup.BoltTypeEnum Type { get; set; }
		public int Quantity { get; set; }
	}
}