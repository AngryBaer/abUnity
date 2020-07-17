using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class CurrentFrame : MonoBehaviour
{
    Text text;
    GameObject timelineObject;
    PlayableDirector timelinePlayer;
    TimelineAsset timelineAsset;
    float playerFps;

    // Start is called before the first frame update
    void Start()
    {
        timelineObject = GameObject.Find("timeline");
        timelinePlayer = timelineObject.GetComponent<PlayableDirector>();
        timelineAsset = (TimelineAsset) timelinePlayer.playableAsset;
        playerFps = timelineAsset.editorSettings.fps;

        text = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        double playerTime = timelinePlayer.time;
        int frame = (int) Math.Ceiling(playerTime * playerFps);

        text.text = frame.ToString();
    }
}
