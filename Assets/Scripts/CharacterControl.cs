using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] NavMeshAgent player;
    //[SerializeField] Animator playerAnimator;
    [SerializeField] GameObject targetDest;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitpoint;

            if(Physics.Raycast(ray, out hitpoint))
            {
                targetDest.transform.position = hitpoint.point;
                player.SetDestination(hitpoint.point);
            }
        }

       /* if(player.velocity != Vector3.zero)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        else if (player.velocity == Vector3.zero)
        {
            playerAnimator.SetBool("isWalking", false);
        }*/
    }
}
