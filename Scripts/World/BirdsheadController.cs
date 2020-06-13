using UnityEngine;

public class BirdsheadController : MonoBehaviour
{
    //TODO Make Multiplayer

    public Animation birdHeadOpen;
    private bool lEyeHit = false;
    private bool rEyeHit = false;
    private void OpenBirdsMouth()
    {
        birdHeadOpen.Play();
    }

    public void HitEye(bool leftEyeNotRight)
    {
        if (leftEyeNotRight)
        {
            lEyeHit = true;
        }
        else
        {
            rEyeHit = true;
        }

        if (lEyeHit && rEyeHit) OpenBirdsMouth();
    }
}
