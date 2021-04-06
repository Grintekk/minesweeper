using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class OpenCell : MonoBehaviour
{

  
    public Vector2 cellPosition;
    public GameObject cellClone;
    public bool cellBomb;
    public bool isOpen = false ;
    private bool userClick;
    
    BombCount bombCount{get;set;}


    // Update is called once per frame
    void OnMouseDown()
    {
        if(this.cellBomb == false)
        {
            //userClick = true;
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
                SceneManager.LoadScene("menu");
        }
           //Debug.Log(bombCount);
        
        if(FieldControl.Instance.AreYouWin())
        {
            SizeOfField a = new SizeOfField();
            a.buttonsShow.SetActive(true);
        }
    }
    public void OpenEmpty(int i, int j)
    {
        
        int bombscounter;
        //Debug.Log(this.cellPosition.x + " this  x  " + this.cellPosition.y + "this  y ");
        
        for (int k = -1;k<2;k++)
        {
               
                for (int l = -1; l<2;l++)
                {
                    var posI = i + k;
                    var posJ = j + l;
                    if((posI >= 0&&posI < FieldControl.Instance.cellField.GetLength(0))&&
                    (posJ >= 0&&posJ <FieldControl.Instance.cellField.GetLength(1)))//проверка за границы
                    {
                        
                        bombscounter = FieldControl.Instance.bombsNear(FieldControl.Instance.cellField[posI,posJ]); //проверяем и открываем ячейку
                        
                        if(bombscounter == 0 && FieldControl.Instance.cellField[posI,posJ].isOpen == false)
                        {
                            FieldControl.Instance.cellField[posI,posJ].isOpen = true;
                           // Debug.Log("рекурсия зашла в  i =" + posI + " || j =  " + posJ);
                            FieldControl.Instance.cellField[posI,posJ].OpenEmpty(posI,posJ);
                        }

                    }
                    
                }
                
        }
          //Debug.Log(add + " -  count");
    }
}
