using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class CurrentTimecode : MonoBehaviour
{
    Text text;
    GameObject timelineObject;
    PlayableDirector timelinePlayer;
    TimelineAsset timelineAsset;
    int playerFps;

    // Start is called before the first frame update
    void Start()
    {
        timelineObject = GameObject.Find("timeline");
        timelinePlayer = timelineObject.GetComponent<PlayableDirector>();
        timelineAsset = (TimelineAsset) timelinePlayer.playableAsset;
        playerFps = (int) timelineAsset.editorSettings.fps;

        text = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        double playerTime = timelinePlayer.time;
        int frame = (int) Math.Ceiling(playerTime * playerFps);
        int seconds = (int) Math.Floor(playerTime);

        TimeSpan span = new TimeSpan(0, 0, seconds);
        int frameCode = frame - (seconds * playerFps);

        text.text = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", span.Hours, span.Minutes, span.Seconds, frameCode);
    }
}
