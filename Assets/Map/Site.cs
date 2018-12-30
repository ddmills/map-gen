using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Depski.Map {
	public class Site : MonoBehaviour {
		[SerializeField]
		private int vertexId;
		private Vertex Vertex {
			get { return WorldMap.Instance.Map.GetVertex(vertexId); }
		}

		public void Init(int vertexId) {
			this.vertexId = vertexId;
			transform.position = Vertex.Position;
		}
	}
}
