using System.Collections.Generic;
using System.Linq;

namespace Depski.Map.Algorithms {
	public class Prims {
		private Map map;
		List<int> visited;
		Dictionary<int, float> costs;
		Dictionary<int, int> prevs;

		public Prims(Map map) {
			this.map = map;
			visited = new List<int>();
			costs = new Dictionary<int, float>();
			prevs = new Dictionary<int, int>();

			foreach (Vertex v in this.map.Vertices) {
				costs.Add(v.ID, float.PositiveInfinity);
			}

			int first = costs.Keys.First();

			costs[first] = 0;
		}

		private Vertex PopMinCost() {
			float minCost = float.PositiveInfinity;
			int minId = -1;

			foreach (KeyValuePair<int, float> next in costs) {
				if (minId == -1 || next.Value < minCost) {
					minCost = next.Value;
					minId = next.Key;
				}
			}

			costs.Remove(minId);

			return map.GetVertex(minId);
		}

		private Vertex GetPrev(Vertex v) {
			if (prevs.ContainsKey(v.ID)) {
				int prevId = prevs[v.ID];

				return map.GetVertex(prevId);
			}

			return null;
		}

		public float ComputeCost(Vertex v1, Vertex v2) {
			return v1.Distance(v2);
		}

		public void AssignMSTEdges() {
			if (costs.Count <= 0) {
				return;
			}

			Vertex next = PopMinCost();
			Vertex prev = GetPrev(next);

			visited.Add(next.ID);

			if (prev != null) {
				Edge e = next.GetEdge(prev);
				e.MarkMSTEdge();
			}

			foreach (Vertex v in next.Neighbors) {
				if (!visited.Contains(v.ID)) {
					float cost = ComputeCost(next, v);

					if (cost < costs[v.ID]) {
						costs[v.ID] = cost;
						prevs[v.ID] = next.ID;
					}
				}
			}
			AssignMSTEdges();
		}
	}
}
