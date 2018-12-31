using System.Collections.Generic;
using UnityEngine;
using Depski.Generic;

namespace Depski.Meeples {
	public class MeepleManager : Singleton<MeepleManager> {
		[SerializeField]
		private GameObject meeplePrefab;
		[SerializeField]
		private List<Meeple> meeples;

		public Meeple AddMeeple(Location location) {
			GameObject meepleObj = Object.Instantiate(meeplePrefab, transform);
			Meeple meeple =  meepleObj.GetComponent<Meeple>();

			location.AddMeeple(meeple);

			return meeple;
		}
	}
}
