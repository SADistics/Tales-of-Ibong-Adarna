using UnityEngine;
using System.Collections;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
		private Transform noTarget;
		public Transform[] moveSpots;
		private float waitTime;
		public float startWaitTime;
		private int randomSpot;
		private int prevSpot;
		public bool aiDest;
		public bool inAttackRange;

		IAstarAI ai;

        private void Start()
        {
			waitTime = startWaitTime;
			randomSpot = Random.Range(0, moveSpots.Length);
			prevSpot = randomSpot;
			target = moveSpots[randomSpot].transform;
        }

        void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () {
			if (target != null && ai != null) ai.destination = target.position;

			if (aiDest)
			{
                if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 2f)
                {
					if (waitTime <= 0)
					{
						aiDest = false;
						randomSpot = Random.Range(0, moveSpots.Length);
						prevSpot = randomSpot;
						waitTime = startWaitTime;
						target = moveSpots[randomSpot].transform;
					}
					else
					{
						waitTime -= Time.deltaTime;
					}
                }
                else
                {
					if (waitTime <= 0)
					{
						aiDest = false;
						randomSpot = Random.Range(0, moveSpots.Length);
						prevSpot = randomSpot;
						waitTime = startWaitTime;
						target = moveSpots[randomSpot].transform;
					}
					else
					{
						waitTime -= Time.deltaTime;
					}
				}
			}
			else if (!aiDest && target == noTarget)
            {
				target = moveSpots[randomSpot].transform;
			}
			else if (!aiDest && inAttackRange)
            {
				target = noTarget;
            }
		}

		public void GetPlayer(Transform player)
        {
			target = player;
        }

		public void OutOfRange()
        {
			target = noTarget;
			aiDest = false;
        }

		public void SetDest(bool nextDest)
        {
			aiDest = nextDest;
        }
	}
}
