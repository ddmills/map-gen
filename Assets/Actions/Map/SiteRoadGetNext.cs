using System.Collections.Generic;
using HutongGames.PlayMaker;
using UnityEngine;

namespace Depski.PlayMaker.Actions {
	using Depski.Map;

	[ActionCategory("Map")]
	[HutongGames.PlayMaker.Tooltip("Each time this action is called it gets the next Site road.")]
	public class SiteRoadGetNext : FsmStateAction {
		[ActionSection("Set up")]

		[RequiredField]
		[HutongGames.PlayMaker.Tooltip("The site to get roads from")]
		[CheckForComponent(typeof(Site))]
		public FsmOwnerDefault site;

		[HutongGames.PlayMaker.Tooltip("Event to send to get the next item.")]
		public FsmEvent loopEvent;

		[HutongGames.PlayMaker.Tooltip("Event to send when there are no more items.")]
		public FsmEvent finishedEvent;

		[ActionSection("Result")]

		[UIHint(UIHint.Variable)]
		[HutongGames.PlayMaker.Tooltip("The value for the current road.")]
		public FsmGameObject result;
		private IEnumerator<Road> enumerator;

		public override void Reset() {
			site = null;
			loopEvent = null;
			finishedEvent = null;
			result = null;
			enumerator = null;
		}

		public override void OnEnter() {
			Site s = Fsm.GetOwnerDefaultTarget(site).GetComponent<Site>();
			if (enumerator == null) {
				enumerator = s.Roads.GetEnumerator();
			}

			DoGetNextItem();
			Finish();
		}

		void DoGetNextItem() {
			if (enumerator.MoveNext()) {
				Road current = enumerator.Current;

				result.Value = current.gameObject;

				if (loopEvent != null) {
					Fsm.Event(loopEvent);
				}
			} else {
				enumerator = null;
				Fsm.Event(finishedEvent);
			}
		}
	}
}
