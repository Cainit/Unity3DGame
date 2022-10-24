using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKController : MonoBehaviour
{
    protected Animator animator;
    public bool ikActive = false;
    public Transform rightHandObj = null;
    public Transform lookObj = null;
    public Transform interactables;
    public float interactableNearMin = 5f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    //Вызывается при расчёте IK
    void OnAnimatorIK()
    {
        if (animator)
        {
            //Если, мы включили IK, устанавливаем позицию и вращение
            if (ikActive)
            {
                // Устанавливаем цель взгляда для головы
                if (lookObj != null)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookObj.position);
                }
                //устанавливаем взгляд на ближайший интерактивный объект
                else if(interactables != null)
                {
                    Transform nearInteractable = GetNearedInteractable();
                    if (nearInteractable != null)
                    {
                        animator.SetLookAtWeight(1);
                        animator.SetLookAtPosition(nearInteractable.position);
                    }
                }

                // Устанавливаем цель для правой руки и выставляем её в позицию
                if (rightHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                }
            }
        }
        // Если IK неактивен, ставим позицию и вращение рук и головы в изначальное положение
        else
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            animator.SetLookAtWeight(0);
        }
    }

    public Transform GetNearedInteractable()
    {
        Transform nearTransform = null;

        float minDist = interactableNearMin;

        for(int i=0; i<interactables.childCount;++ i)
        {
            float dist = Vector3.Distance(interactables.GetChild(i).position, transform.position);
            if (dist <= minDist)
            {
                minDist = dist;
                nearTransform = interactables.GetChild(i);
            }
        }

        return nearTransform;
    }
}