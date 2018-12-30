using System.Collections.Generic;

namespace Depski.Map {
	public class Map {
		private Dictionary<int, Vertex> vertices;
		private Dictionary<int, Edge> edges;
		public ICollection<Vertex> Vertices {
			get { return vertices.Values; }
		}
		public ICollection<Edge> Edges {
			get { return edges.Values; }
		}
		public int VertexCount {
			get { return Vertices.Count; }
		}
		public int EdgeCount {
			get { return Edges.Count; }
		}
		private int currentId;
		private int NextID {
			get { return currentId++; }
		}

		public Map() {
			currentId = 0;
			vertices = new Dictionary<int, Vertex>();
			edges = new Dictionary<int, Edge>();
		}

		public Vertex AddVertex(float x, float y) {
			Vertex v = new Vertex(this, NextID, x, y);

			vertices.Add(v.ID, v);

			return v;
		}

		public Edge GetEdge(int id) {
			return edges[id];
		}

		public Vertex GetVertex(int id) {
			return vertices[id];
		}

		public Edge AddEdge(int v0, int v1) {
			Edge e = new Edge(this, NextID, v0, v1);

			edges.Add(e.ID, e);

			return e;
		}
	}
}
