using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
   private Rigidbody _rigidbody;


   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
   }

   public void SelectedBall()
   {
      _rigidbody.useGravity = false;
      
      transform.DOMoveY(0.7F, 1F);
   }

   public void ResetSelectedBall()
   {
      _rigidbody.useGravity = true;
   }

   public void BallPositionChangeToTube(GameObject _tube)
   {
      transform.DOMoveX(_tube.transform.position.x, 1F);
      StartCoroutine(ChangeBallUseGravity());
   }

   IEnumerator ChangeBallUseGravity()
   {
      yield return new WaitForSecondsRealtime(1F);
      _rigidbody.useGravity = true;
   }
}
