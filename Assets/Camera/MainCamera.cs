using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Depski.Camera {
	using Depski.Generic;

	public class MainCamera : Singleton<MainCamera> {
		[SerializeField]
		private Transform target;
		[SerializeField]
		private float followDistance = 4f;
		[SerializeField]
		private float followAngle = 20f;
		[SerializeField]
		private float speed = .05f;

		void Update () {
			Vector3 newRotation = Quaternion.Euler(followAngle, 0, 0) * Vector3.back;
			Vector3 newPosition = target.position + (newRotation * followDistance);

			transform.position = Vector3.Lerp(transform.position, newPosition, speed);

			Vector3 difference = target.position - transform.position;
			Quaternion newRot = Quaternion.LookRotation(difference);
			transform.rotation = Quaternion.Lerp(transform.rotation, newRot, speed);
		}

		public void LookAt(Vector3 position) {
			target.position = position;
		}
	}
}
