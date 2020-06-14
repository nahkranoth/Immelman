using UnityEngine;

public class BirdsheadController : MonoBehaviour
{
    //TODO Make Multiplayer

    public Animation birdHeadOpen;
    public int triggerAmount = 2;
    public int currentTriggerCount = 0;
    private void OpenBirdsMouth()
    {
        birdHeadOpen.Play();
    }

    public void HitEye()
    {
        currentTriggerCount++;
        if (currentTriggerCount == triggerAmount) OpenBirdsMouth();
    }
}
