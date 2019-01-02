using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Depski.Meeples;
using Depski.Map;

public class Setup : MonoBehaviour {
	void Start () {
		WorldMap.Instance.Init();
		Vertex startingVertex = WorldMap.Instance.Map.Vertices.First();

		startingVertex.isDiscovered = true;
		startingVertex.isExplored = true;

		Location startingLocation = startingVertex.site.gameObject.GetComponent<Location>();

		Depski.Meeples.MeepleManager.Instance.AddMeeple(startingLocation);
		Depski.Meeples.MeepleManager.Instance.AddMeeple(startingLocation);

		Depski.Camera.MainCamera.Instance.LookAt(startingVertex.Position);
	}
}

