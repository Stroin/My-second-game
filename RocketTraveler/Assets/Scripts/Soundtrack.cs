using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrack : MonoBehaviour
{
    public AudioClip[] soundTrack;
    AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(AS.isPlaying == false)
        {
           int historyID = 0;
           int soundTrackID;
            soundTrackID = soundTrack.Length - 1;
            if(soundTrackID != historyID)
            {
            AS.clip = soundTrack[Random.Range(0, soundTrack.Length - 1)];

            AS.Play();
            }
        }
    }
}
