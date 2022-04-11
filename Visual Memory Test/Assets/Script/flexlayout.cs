// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class flexlayout : LayoutGroup
// {
   
//     public int rows;
//     public int columns;
//     public Vector2 cellSize;

//     public override void CalculateLayoutInputHorizontal()
//     {
//         base.CalculateLayoutInputHorizontal();
        
//         float sqrRt = Matf.Sqrt(transform.childCount);
//         rows = Mathf.CeiltoInt(sqrRt);
//         columns = Matf.CeiltoInt(sqrRt);

//         float parentWidth = rectTransform.rect.width;
//         float parentHeight = rectTransform.rect.height;

//         float cellWidth = parentWidth / (float)columns;
//         float cellHeight = parentHeight / (float)rows;

//         cellSize.x = cellWidth;
//         cellSize.x = cellHeight;

//         int columnCount = 0;
//         int rowCount = 0;

//         for (int i=0; i < rectChildren.Count; i++)
//         {
//             rowCount = i / columns;
//             columnCount = i % columns;

//             var item = rectChildren[i];

//             var xPos = (cellSize.x * columnCount);
//             var yPos = (cellSize.y * rowCount);

//             setChildAlongAxis(item,0,xPos,cellSize.x);
//             setChildAlongAxis(item,1,yPos,cellSize.y);

//         }
//     }

//     public override void CalculateLayoutInputVertical()
//     {

//     }

//     public override void SetLayoutHorizontal()
//     {

//     }

//     public override void SetLayoutVertical()
//     {

//     }

// }
