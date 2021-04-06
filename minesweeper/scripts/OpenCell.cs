using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OpenCell : MonoBehaviour
{

    public Vector2 cellPosition;
    public GameObject cellClone;
    public bool cellBomb;
    public bool isOpen;
    
    BombCount bombCount{get;set;}


    // Update is called once per frame
    void OnMouseDown()
    {
        if(this.cellBomb == false)
        {
            int bombsCount = FieldControl.Instance.bombsNear(this);
            //this.GetComponent<SpriteRenderer>().sprite = FieldControl.Instance.spriteArray[bombsCount];
            if(bombsCount==0)
            {
                this.OpenEmpty((int) this.cellPosition.x,(int) this.cellPosition.y);
            }
        }
        else
        {
                this.GetComponent<SpriteRenderer>().sprite = FieldControl.Instance.spriteArray[9];
        }
           //Debug.Log(bombCount);
        
        
    }
    public void OpenEmpty(int i, int j)
    {
        
        int bombscounter = 0;
        Debug.Log(this.cellPosition.x + " this  x  " + this.cellPosition.y + "this  y ");
        
        for (i = (int)this.cellPosition.x -1;i<(int)this.cellPosition.x+2;i++)
        {
               
                for (j = (int)this.cellPosition.y -1;j<(int)this.cellPosition.y+2;j++)
                {
                    //var posI = i + k;
                    //var posJ = j + l;
                    if((i<0||i+1>FieldControl.Instance.cellField.GetLength(0))||
                    (j<0||j+1>FieldControl.Instance.cellField.GetLength(1)))
                    {
                        continue;
                    }
                    else
                    {
                        bombscounter = FieldControl.Instance.bombsNear(FieldControl.Instance.cellField[i,j]);
                        if(bombscounter == 0)
                        {
                            FieldControl.Instance.cellField[i,j].OpenEmpty(i,j);
                        }
                      
                    }
                    
                }
                
        }
          //Debug.Log(add + " -  count");
    }
}
