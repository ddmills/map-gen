using System.Collections.Generic;
using UnityEngine;

namespace Depski.Map {
	using Algorithms;

	public class Generator {
		private int vertexCount;
		private float radius;
		private float roadDensity;
		private int smoothingIterations;
		private Dictionary<int, int> vertexIDMap;

		public Generator(int vertexCount = 80, float radius = 100, int smoothingIterations = 5, float roadDensity = .3f) {
			this.vertexCount = vertexCount;
			this.radius = radius;
			this.smoothingIterations = smoothingIterations;
			this.roadDensity = roadDensity;
			vertexIDMap = new Dictionary<int, int>();
		}

		private TriangleNet.Geometry.Polygon createPolygon() {
			TriangleNet.Geometry.Polygon polygon = new TriangleNet.Geometry.Polygon();

			for (int i = 0; i < vertexCount; i++) {
				Vector2 vector = Random.insideUnitCircle * radius;
				TriangleNet.Geometry.Vertex v = new TriangleNet.Geometry.Vertex(vector.x, vector.y);

				polygon.Add(v);
			}

			return polygon;
		}

		private TriangleNet.Mesh createMesh() {
			TriangleNet.Geometry.Polygon polygon = createPolygon();
			TriangleNet.Meshing.ConstraintOptions options = new TriangleNet.Meshing.ConstraintOptions() { ConformingDelaunay = true };
			TriangleNet.Meshing.GenericMesher mesher = new TriangleNet.Meshing.GenericMesher();

			TriangleNet.Mesh mesh = (TriangleNet.Mesh) mesher.Triangulate(polygon, options);

			TriangleNet.Smoothing.SimpleSmoother smoother = new TriangleNet.Smoothing.SimpleSmoother();
			smoother.Smooth(mesh, smoothingIterations);

			return mesh;
		}

		public Map Generate() {
			TriangleNet.Mesh mesh = createMesh();

			Map map = new Map();

			foreach (TriangleNet.Geometry.Vertex triVertex in mesh.Vertices) {
				Vertex v = map.AddVertex((float) triVertex.x, (float) triVertex.y);
				vertexIDMap.Add(triVertex.GetHashCode(), v.ID);
			}

			foreach (TriangleNet.Geometry.Edge Edge in mesh.Edges) {
				map.AddEdge(vertexIDMap[Edge.P0], vertexIDMap[Edge.P1]);
			}

			Prims prims = new Prims(map);
			prims.AssignMSTEdges();

			Roads roads = new Roads(map, roadDensity);
			roads.AssignRoadEdges();

			return map;
		}
	}
}
