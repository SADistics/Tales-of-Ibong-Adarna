using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneInteraction : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public void TimelinePlay()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void TimelineStop()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TimelinePlay();
    }

}
