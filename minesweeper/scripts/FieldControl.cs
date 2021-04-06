using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldControl : MonoBehaviour
{


    [SerializeField] public Vector2 fieldSize;
    public static FieldControl Instance {get;set;}
    [SerializeField] public OpenCell [,] cellField;
    
    [SerializeField]public Sprite [] spriteArray = new Sprite [10];
    
    void Start()
    {   
        //fieldSize.Set(4,5);
        
    }
    void Awake()
    {
        if(Instance == null)
        Instance = this;
        
    }
    public void clearField()
    {
               GameObject parent = GameObject.FindGameObjectWithTag("Cell Field");
               if(parent!=null)
               Destroy(parent);
           
    }
    public void createCellField()
    {
      
        cellField = new OpenCell [(int)fieldSize.x,(int)fieldSize.y]; // создание массива с размерами(vector2)
    }
    public void addCellToField (OpenCell cell,int i,int j)
    {
        cellField[i,j] = cell; //добавление элемента в массив
    }
    public void generateBombs() // спаун бомб

    {
        OpenCell cell;
        for(int i=0;i<2;)
        {
            cell = FieldControl.Instance.cellField[(int)Random.Range(0,FieldControl.Instance.fieldSize.x),(int)Random.Range(0,FieldControl.Instance.fieldSize.y)];
            if(cell.cellBomb != true)
            {
                cell.cellBomb = true;
                i++;
            }
        }
       
    }
    public int bombsNear(OpenCell cell)
    {
        int countBomb=0;
        for (int i = (int)cell.cellPosition.x -1;i<(int)cell.cellPosition.x+2;i++)
        {
            
                for (int j = (int)cell.cellPosition.y -1;j<(int)cell.cellPosition.y+2;j++)
                {
                    if((i<0||i+1>cellField.GetLength(0))||(j<0||j+1>cellField.GetLength(1)))
                    {
                        continue;
                    }
                    else
                    {
                        if(FieldControl.Instance.cellField[i,j].cellBomb == true)
                        {
                            countBomb++;
                        }
                    }   
                }
                
        }
        cell.GetComponent<SpriteRenderer>().sprite = FieldControl.Instance.spriteArray[countBomb];
        return countBomb;
    }
    

}
