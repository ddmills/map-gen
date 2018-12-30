
namespace Depski.Map {
	public class Edge {
		private Map map;
		public int ID { get; private set; }
		public int V0ID { get; private set; }
		public int V1ID { get; private set; }
		public bool MST { get; private set; }
		public EdgeType Type { get; private set; }
		public Vertex V0 {
			get { return map.GetVertex(V0ID); }
		}
		public Vertex V1 {
			get { return map.GetVertex(V1ID); }
		}

		public float Length {
			get { return V0.Distance(V1); }
		}

		public Edge(Map map, int id, int v0ID, int v1ID) {
			this.map = map;
			ID = id;
			V0ID = v0ID;
			V1ID = v1ID;
			MST = false;
			Type = EdgeType.NONE;
			V0.OnEdgeConnected(this);
			V1.OnEdgeConnected(this);
		}

		public bool Contains(Vertex v) {
			return V0ID == v.ID || V1ID == v.ID;
		}

		public Vertex Opposite(Vertex v) {
			return V0ID == v.ID ? V1 : V0;
		}

		public void MarkMSTEdge() {
			MST = true;
		}

		public void MarkRoadEdge() {
			Type = EdgeType.ROAD;
		}
	}
}
