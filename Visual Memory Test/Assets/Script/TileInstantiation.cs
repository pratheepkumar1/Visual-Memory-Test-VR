using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TileInstantiation : MonoBehaviour 
{


    public RectTransform panelRow;
    public Transform grid;
    public GameObject block;
    public Transform cam;
    
    public int row = 3;
    public int column = 3;
    private GameObject[,] allTiles;

    float deltaTime= .0f;
    bool tileCreation = false;
    bool tileHighlighting = false;
    bool gameStart = true;
    private int gameLevel = 3;
    // float previousTime =0.0f;

    //Tile Values
    private List<int[]> highlightedTiles;
    private List<int[]> selectedTiles;
    private List<int[]> answerTiles;
    private int selectedCount = 0;
    public static string states;
    


    void Awake() {
        highlightedTiles = new List<int[]>();
        selectedTiles = new List<int[]>();
        answerTiles = new List<int[]>();
        CreateTiles();
    }
//    void Start()
//    {
//        TileValueClear();
//    }



    void CreateTiles(){

        allTiles  = new GameObject[row,column];
        RectTransform rowParent;

        // to check if it is odd
        bool IsOdd(int value)
        {
            return value % 2 != 0;
        }       

        float v;
        v = (IsOdd(gameLevel))?((gameLevel-1)/2):(gameLevel/2);


        for (int y=0; y<row; y++)
            {

                rowParent = (RectTransform)Instantiate(panelRow);
                rowParent.transform.SetParent(grid);
                rowParent.transform.localScale = Vector3.one;

                for (int x=0; x<column; x++)
                {


                    allTiles[x,y] = (GameObject)Instantiate(block);
                    allTiles[x,y].transform.SetParent(rowParent);
                    allTiles[x,y].transform.localScale = Vector2.one; 
                    states = "Game Start";
                    // // Dynamic position of cells
                    // float colPos = x-column+v+1;
                    // float rowPos = y-row+v+1;

                    // // Dynamic resizing of cells to fit in fixed width
                    // allTiles[x,y] = Instantiate(block, new Vector3(colPos,rowPos,0), Quaternion.identity);
                    // allTiles[x,y].transform.SetParent(rowParent);
                    // // Debug.Log("Col" + colPos + "," + "Row" + rowPos);
                    // allTiles[x,y].transform.localScale += new Vector3(-0.1f, -0.1f, -0.1f);
                    // states = "Game Start";
                    // //    Debug.Log(allTiles[x,y].GetComponent<tileScript>().currentState); 
                }
            }
        
        // cam.transform.position = new Vector3((float)row/2,(float)column/2,-5f * (float)row/1.5f );
        tileCreation = true;
    }

    void TileValueClear(){
        // allTiles  = new GameObject[3,3];
        Debug.Log("Clear executed");
        for (int y=0; y<row; y++)
        {
           for (int x=0; x<column; x++)
           {
            //    allTiles[x,y] = Instantiate(block, new Vector3(x,y,0), Quaternion.identity);
            //    allTiles[x,y].transform.localScale += new Vector3(-0.1f, -0.1f, -0.1f);
            //    Debug.Log(allTiles[x,y].GetComponent<tileScript>().currentState); 
                allTiles[x,y].GetComponent<tileScript>().TileDefault();
           }
        } 
        tileScript.selectedCount = 0;
        Debug.Log("Clear executed");
    }


    void RoundReset(){
        highlightedTiles.Clear();
        selectedTiles.Clear();
        TileValueClear();
        for (int y=0; y<row; y++)
        // {
        //    for (int x=0; x<column; x++)
        //    {
        //        allTiles[x,y].GetComponent<tileScript>().DestroyTile();
        //    }
        // }   
        for (int count = 0; count < grid.childCount; count++)
        {
            Destroy(grid.GetChild(count).gameObject);
        }
        row++;
        column++;
        gameLevel++;
        CreateTiles();
    }

    void TileHighlight(){

    }


    void TileSelection(){


    }

    void RandomTileHighlight(){
        Debug.Log(row);
        Debug.Log(column);

        int h = 0;
        while(h<gameLevel){
            int x = Random.Range(0,column);
            int y = Random.Range(0,row);
            if(allTiles[x,y].GetComponent<tileScript>().isTileHighlighted()){
                continue;
            }              
            allTiles[x,y].GetComponent<tileScript>().HighlightTile();
            int [] highlightedVal = new int[2]{x,y};
            highlightedTiles.Add(highlightedVal);
            h++;
        }
        tileHighlighting = true;
        // Debugging the highlighted tile number
        // foreach (var x in highlightedTiles)
        // {
        //     string a= "";
        //     foreach(var y in x){
        //         a+=y + " ";
        //     }
        //     Debug.Log(a);
        // }
        // Debug.Log($"{randCol},{randRow}");
        // Debug.Log(highlightedTiles);
    }

    void SelectTiles(){
            for (int y=0; y<row; y++)
            {
                for (int x=0; x<column; x++)
                {
                    if(allTiles[x,y].GetComponent<tileScript>().isTileSelected()){
                        int [] selectedVal = new int[2]{x,y};
                        selectedTiles.Add(selectedVal);
                    }
                    // if(allTiles[x,y].GetComponent<tileScript>().isTileSelected()){
                    //     count++;
                    // }
                    // if (count==gameLevel)
                    // {
                    // Debug.Log("hello");
                    // selectedCount++;
                    // }
                }
            }  
    }




    void ValidateSelection(){
        
        // answerTiles = selectedTiles.Except(highlightedTiles).ToList();

        foreach (var i in highlightedTiles)
        {
            int var1 = i[0];
            int var2 = i[1];
            foreach(var j in selectedTiles){
                int var21 = j[0];
                int var22 = j[1];
                if(var1 == var21 && var2 == var22){
                Debug.Log("matching at position" + var2 + " " + var1);        
                }
            }   
        }
       
            // bool tileAnswer = highlightedTiles.Contains(selectedTiles);
            // Debug.Log(tileAnswer);
    }

    void Update() {
        deltaTime += Time.deltaTime;
        
        switch(states){
            case "Game Start":
                if(tileCreation){
                    if(gameStart){
                    RandomTileHighlight();
                    gameStart = false;
                }
                if (deltaTime > 2.5f && tileHighlighting == true)
                    {
                        Debug.Log("Highlight Executed");
                        states = "Game Select";
                        TileValueClear();
                        deltaTime = 0.0f;
                        gameStart = true;
                        tileCreation = false;
                    }
                }
                break;
            case "Game Select":
                if(tileScript.selectedCount==gameLevel){
                    // Debug.Log(gameLevel);
                    // Debug.Log(selectedCount);
                    Debug.Log("Select Started");
                    SelectTiles();
                    Debug.Log(deltaTime);
                    Debug.Log("Select Executed");
                    deltaTime = 0.0f;
                    states = "Game Wait";
                }
                break;
            case "Game Wait":  
                if(deltaTime > 2f){
                    Debug.Log("Validate Started");
                    ValidateSelection();
                    RoundReset();
                    states = "Game Start";
                    Debug.Log("Validate Executed");
                }
                break;
        }
   }
}


