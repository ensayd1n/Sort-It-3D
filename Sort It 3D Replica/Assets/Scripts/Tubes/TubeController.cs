using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeController : MonoBehaviour
{
   private GameObject _ball;

   [HideInInspector]
   public List<GameObject> TubeList = new List<GameObject>();

   public bool Complated = false;

   [HideInInspector]
   public float BallInstantiateTransformY=2F;

   [HideInInspector]
   public int Tubemaxlimit = 4;

   private string _ballcolor;
   private string _tubecolor;

   private int _tubecompatedindex;
   
   public void CheckUpTube()
   {
      if (TubeList.Count > 1)
      {
         _tubecolor = TubeList[0].tag;
         Complated = true;

         for (int i = 0; i < TubeList.Count; i++)
         {
            if (TubeList[i].gameObject.tag != _tubecolor)
            {
               Complated = false;
            }
         }
      }

      else if (TubeList.Count is 1)
      {
         Complated = false;
      }

      else
      {
         Complated = true;
      }
   }

   public void AddListBall(GameObject Ball)
   {
      TubeList.Add(Ball);
      BallInstantiateTransformY += 1F;
   }

   public void ReduceListBall()
   {
      TubeList.RemoveAt(TubeList.Count-1);
   }

   private void FixedUpdate()
   {
      CheckUpTube();
   }
}

