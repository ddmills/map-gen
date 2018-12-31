using UnityEngine;
using System.Linq;

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
		private GameObject sitePrefab;
		[SerializeField]
		private GameObject roadPrefab;
		[SerializeField]
		public Map Map { get; private set; }

		public Map Init() {
			Random.InitState(seed);
			Map = MapFactory.Create(locationCount, radius, smoothingIterations, roadDensity);

			foreach (Vertex vertex in Map.Vertices) {
				GameObject siteOb = Instantiate(sitePrefab, this.transform);
				siteOb.GetComponent<Site>().Init(vertex.ID);
			}

			foreach (Edge road in Map.Roads) {
				GameObject roadOb = Instantiate(roadPrefab, this.transform);
				roadOb.GetComponent<Road>().Init(road.ID);
			}

			return Map;
		}
	}
}
