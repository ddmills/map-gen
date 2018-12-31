using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Depski.Map {
	public class Site : MonoBehaviour {
		[SerializeField]
		public int VertexId { get; private set; }
		public Vertex Vertex {
			get { return WorldMap.Instance.Map.GetVertex(VertexId); }
		}
		public IEnumerable<Site> Connected {
			get { return Vertex.Connected.Select(v => v.site); }
		}
		public IEnumerable<Road> Roads {
			get { return Vertex.Roads.Select(r => r.road); }
		}

		public void Init(int vertexId) {
			VertexId = vertexId;
			transform.position = Vertex.Position;
			Vertex.site = this;
		}
	}
}
