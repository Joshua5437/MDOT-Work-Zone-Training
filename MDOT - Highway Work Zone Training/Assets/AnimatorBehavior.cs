using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimatorBehavior : StateMachineBehaviour
{
    public AudioSource DemoInstructions;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("End State"))
        {
            DemoInstructions.Play();
        }
    }
}
