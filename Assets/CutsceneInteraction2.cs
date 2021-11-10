using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneInteraction2 : MonoBehaviour
{
    public PlayableDirector playableDirector;
    void Start()
    {
        playableDirector = GameObject.Find("Timeline").GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            TimelineResume();
    }

    public void TimelineResume()
    {
        playableDirector.Resume();
    }
}
