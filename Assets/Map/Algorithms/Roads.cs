using System.Collections.Generic;
using System.Linq;

namespace Depski.Map.Algorithms {
	public class Roads {
		private Map map;
		private float density;

		public Roads(Map map, float density) {
			this.map = map;
			this.density = density;
		}

		public void AssignRoadEdges() {
      foreach (Edge e in map.Edges) {
				if (e.MST) {
					e.MarkRoadEdge();
				} else {
					float r = UnityEngine.Random.Range(0f, 1f);

					if (r < density) {
						e.MarkRoadEdge();
					}
				}
			}
		}
	}
}
