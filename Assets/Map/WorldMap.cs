using UnityEngine;

namespace Depski.Map {
	using Depski.Generic;

	public class WorldMap : Singleton<WorldMap> {
		private TriangleNet.Mesh mesh;
		[SerializeField]
		private int seed;
		[SerializeField]
		private int locationCount;
		[SerializeField]
		private float radius;
		[SerializeField]
		private float roadDensity;
		[SerializeField]
		private int smoothingIterations;
		[SerializeField]
		private Map map;

		void Start () {
			Random.InitState(seed);
			map = MapFactory.Create(locationCount, radius, smoothingIterations, roadDensity);
		}

		public void OnDrawGizmos() {
			if (map == null) {
				return;
			}

			foreach (Edge edge in map.Edges) {
				if (edge.Type == EdgeType.ROAD) {
					Gizmos.color = Color.red;
					Gizmos.DrawLine(edge.V0.vector3, edge.V1.vector3);
				} else {
					Gizmos.color = Color.black;
				}
			}

			foreach (Vertex vertex in map.Vertices) {
				Gizmos.color = Color.black;
				Gizmos.DrawSphere(vertex.vector3, 1);
			}
		}
	}
}
