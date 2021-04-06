using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
   
    
    
    [SerializeField] private OpenCell cell_Clone;
    /*void Start()
    {   
        //fieldSize.Set(4,5);
        FieldControl.Instance.createCellField(fieldSize);
    }*/

    public void OnMouseDown()
    {
        this.generateField();
    }
    [ContextMenu("generate")]
    public void generateField(){

          if(FieldControl.Instance.cellField != null)
           //foreach (OpenCell i in cellField)
           {
               FieldControl.Instance.clearField();
           }
        FieldControl.Instance.createCellField();       
        
        var parent = new GameObject("Cell");
        parent.tag = "Cell Field";
        
        for(int i=0;i<FieldControl.Instance.fieldSize.x;i++)
        {
            for(int j=0;j<FieldControl.Instance.fieldSize.y;j++)
            {
                
                var sprite = cell_Clone.GetComponent<SpriteRenderer>();
                var spriteSize = sprite.size;
                var position = new Vector2(spriteSize.y*(j),spriteSize.x*(-i));
                var cellNew = Instantiate(cell_Clone,parent.transform);
                cellNew.cellPosition.x = i;
                cellNew.cellPosition.y = j;
                cellNew.transform.position = position;
                cellNew.name = "Cell "+i+' '+j;
                FieldControl.Instance.addCellToField(cellNew,i,j);          //создание поля
                

            }
        }
        FieldControl.Instance.generateBombs();
       //cell_Clone.spriteArray = Resources.LoadAll<Sprite>("sprites/minesweeper_sprite_0");
    }
    
}
