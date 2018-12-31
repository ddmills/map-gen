using System.Collections.Generic;
using HutongGames.PlayMaker;
using UnityEngine;

namespace Depski.PlayMaker.Actions {
	using Depski.Map;

	[ActionCategory("Map")]
	[HutongGames.PlayMaker.Tooltip("Each time this action is called it gets the next Site neighbor.")]
	public class SiteNeighborGetNext : FsmStateAction {
		[ActionSection("Set up")]

		[RequiredField]
		[HutongGames.PlayMaker.Tooltip("The site to get neighbors from")]
		[CheckForComponent(typeof(Site))]
		public FsmOwnerDefault site;

		[HutongGames.PlayMaker.Tooltip("Event to send to get the next item.")]
		public FsmEvent loopEvent;

		[HutongGames.PlayMaker.Tooltip("Event to send when there are no more items.")]
		public FsmEvent finishedEvent;

		[ActionSection("Result")]

		[UIHint(UIHint.Variable)]
		[HutongGames.PlayMaker.Tooltip("The value for the current site.")]
		public FsmGameObject result;
		private IEnumerator<Site> enumerator;

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
				enumerator = s.Connected.GetEnumerator();
			}

			DoGetNextItem();
			Finish();
		}

		void DoGetNextItem() {
			if (enumerator.MoveNext()) {
				Site current = enumerator.Current;

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
