using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public string stateGroupName;

    public string flyingStateName;
    public string flyingCloudsStateName;
    public string groundedStateName;

    private string currentMusicState;
    public bool muted = true;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        TriggerGroundedMusic();
    }

    public void TriggerFlyingMusic()
    {
        if (currentMusicState == flyingStateName || muted) return;
        AkSoundEngine.SetState(stateGroupName, flyingStateName);
        currentMusicState = flyingStateName;
    }

    public void TriggerFlyingCloudsMusic()
    {
        if (currentMusicState == flyingCloudsStateName || muted) return;
        AkSoundEngine.SetState(stateGroupName, flyingCloudsStateName);
        currentMusicState = flyingCloudsStateName;
    }

    public void TriggerGroundedMusic()
    {
        if (currentMusicState == groundedStateName || muted) return;
        AkSoundEngine.SetState(stateGroupName, groundedStateName);
        currentMusicState = groundedStateName;
    }

}
