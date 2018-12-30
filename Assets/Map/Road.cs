using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Depski.Map {
	public class Road : MonoBehaviour {
		[SerializeField]
		private int edgeId;
		private Edge Edge {
			get { return WorldMap.Instance.Map.GetEdge(edgeId); }
		}

		public void Init(int edgeId) {
			this.edgeId = edgeId;
			transform.position = Edge.Center;
			transform.LookAt(Edge.V0.Position);
			transform.localScale = new Vector3(
				transform.localScale.x,
				transform.localScale.y,
				Edge.Length
			);
		}
	}
}
