using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel4SwordMan : StateMachineBehaviour
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.GetInteger("Level") == 1)
        {
            SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        }
        if (animator.GetInteger("Level") == 2)
        {
            SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
        }
    }
}
