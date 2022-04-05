using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour
{
    public int currentState;
    bool isSelected = false;
    public static int selectedCount=0; 

    public Material Unselected;
    public Material Selected;
    public Material Highlighted;


    // Start is called before the first frame update
    void Start()
    {
        // Material newMat = Resources.Load("Unselected", typeof(Material)) as Material;
        // gameObject.renderer.material = newMat;  
        gameObject.GetComponent<Renderer>().material = Unselected;
        currentState=0;
    }

    // Update is called once per frame
    void Update()
    {
        // if(TileInstantiation.states == "Game Wait"){
        //     selectedCount = 0;
        // }

    }

    public void TileDefault(){
        gameObject.GetComponent<Renderer>().material = Unselected;
        isSelected = false;
    }

     public bool isTileDefault(){
        if(gameObject.GetComponent<Renderer>().material == Unselected){
            return true;
        }
        return false;
    }


    public bool isTileHighlighted(){
        if(gameObject.GetComponent<Renderer>().material == Highlighted){
            return true;
        }
        return false;
    }

    public void HighlightTile(){
        gameObject.GetComponent<Renderer>().material = Highlighted;
        
    }

    public bool isTileSelected(){
        return isSelected;
        // Debug.Log(gameObject.GetComponent<Renderer>().material == Selected);
        // if(gameObject.GetComponent<Renderer>().material == Selected){

        //     return true;
        // }
        // return false;
    }

    void TileSelected(){
        gameObject.GetComponent<Renderer>().material = Selected;
    }

    void OnMouseDown() {
      if(TileInstantiation.states == "Game Select"){
         if(isSelected){
            gameObject.GetComponent<Renderer>().material = Unselected;
            isSelected = false;
            selectedCount--;
         }
         else{
            gameObject.GetComponent<Renderer>().material = Selected;
            isSelected = true;
            selectedCount++;
         }
        // Destroy(gameObject);
      }   
    }

    public void DestroyTile(){
        Destroy(gameObject);
        selectedCount=0;
    }
}
