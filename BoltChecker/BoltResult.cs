using Tekla.Structures.Model;

namespace BoltChecker
{
	public struct BoltResult
	{
		public string Size { get; set; }
		public string Standard { get; set; }
		public BoltGroup.BoltTypeEnum Type { get; set; }
	}
}