using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Depski.Map {
	public class Vertex {
		private Map map;
		public float X { get; private set; }
		public float Y { get; private set; }
		public int ID { get; private set; }
		public List<int> EdgeIds { get; private set; }
		public IEnumerable<Edge> Edges {
			get { return EdgeIds.Select(id => map.GetEdge(id)); }
		}
		public Vector3 vector3 {
			get { return new Vector3(X, 0, Y); }
		}
		public IEnumerable<Vertex> Neighbors {
			get { return Edges.Select(e => e.Opposite(this)); }
		}

		public Vertex(Map map, int id, float x, float y) {
			this.map = map;
			ID = id;
			X = x;
			Y = y;
			EdgeIds = new List<int>();
		}

		public void OnEdgeConnected(Edge e) {
			EdgeIds.Add(e.ID);
		}

		public float Distance(Vertex other) {
			return Vector3.Distance(vector3, other.vector3);
		}

		public Edge GetEdge(Vertex other) {
			return Edges.First((e) => e.Contains(other));
		}
	}
}
