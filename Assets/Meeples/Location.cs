using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Depski.Meeples {
	public class Location : MonoBehaviour {
		[SerializeField]
		private List<Meeple> meeples = new List<Meeple>();
		[SerializeField]
		private List<Transform> slots = new List<Transform>();
		public List<Meeple> Meeples {
			get { return meeples; }
		}

		private Transform GetSlot() {
			return slots.Find((s) => s.childCount == 0);
		}

		public void AddMeeple(Meeple meeple) {
			meeples.Add(meeple);
			Transform slot = GetSlot();
			meeple.transform.parent = slot;
			meeple.transform.localPosition = Vector3.zero;
		}
	}
}
