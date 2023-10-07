using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class InstantiateBallController : MonoBehaviour
{
    public GameObject[] BallOptions;
    public GameObject[] Tubes;
    
    private void Start()
    {
        StartCoroutine(BallInstantiateTimer());
        
    }

    private void InstantiateBallsRandomTube()
    {
        int _balloptionindex=0;
        
        for (int i = 0; i < Tubes.Length*4-6; i++)
        {
            int _randomtubeindex = Random.Range(0, Tubes.Length);
            TubeController _tubeController = Tubes[_randomtubeindex].GetComponent<TubeController>();

            if (_tubeController.TubeList.Count<_tubeController.Tubemaxlimit)
            {
                GameObject _ball = Instantiate(BallOptions[_balloptionindex],new Vector3(Tubes[_randomtubeindex].transform.position.x,_tubeController.BallInstantiateTransformY,0.4F),Quaternion.identity);
                _tubeController.AddListBall(_ball);
                _balloptionindex++;

                if (_balloptionindex ==BallOptions.Length)
                {
                    _balloptionindex = 0;   
                }
            }
            else if (_tubeController.TubeList.Count>=_tubeController.Tubemaxlimit)
            {
                i--;
            }
        }
    }

    private IEnumerator BallInstantiateTimer()
    {
        yield return new WaitForSecondsRealtime(1F);
        InstantiateBallsRandomTube();
    }
}
