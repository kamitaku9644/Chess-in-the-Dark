using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class GetPosition : MonoBehaviour {

   readonly float[] queue = new float[12];
   readonly float[] row = new float[12];

    protected int nowSquareQueue;
    protected int nowSquareRow;



    //列取得
    protected void GetQueue(float playerpositionx)
    {
        float a;
        int b;
        
        for (a = -5.5f, b = 0; -6 < a & a < 6; a++, b++)
        {
            queue[b] = a;

            if (queue[b] == playerpositionx)
            {
                nowSquareQueue = b ;

            }
        }

        
    }

    //行取得
    protected void GetRow(float playerpositionz)
    {
        float c;
        int d;
        for (c = -5.5f, d = 0; -6 < c & c < 6; c++, d++)
        {
            row[d] = c;
            if (c == playerpositionz)
            {
                nowSquareRow = d;

            }
        }
    }
}
