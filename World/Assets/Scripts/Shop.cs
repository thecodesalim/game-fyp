using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Material[] material;
    public Mesh[] meshes;
    Renderer rend;
    public Transform colorPanel;
    public GameObject colorPanelObj;

     // Start is called before the first frame update
    void Start()
    {
        // Get the players unlocked planet
        //GetComponent<Renderer>().sharedMaterial = material[PlayerPrefs.GetInt("Mat")];
        onColorSelect(PlayerPrefs.GetInt("Mat"));
         // add events to each button
        initShop();
       
    }

    private void initShop() 
    {
        int i = 0;
        foreach (Transform t in colorPanel)
        {
            int currentIndex = i;
            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(() => onColorSelect(currentIndex));
            i++;
        }
    }

    private void onColorSelect(int currentIndex) 
    {
        Material[] mats = GetComponent<Renderer>().materials;
        mats[0] =  material[currentIndex];
        mats[1] =  material[currentIndex];
        GetComponent<Renderer>().materials = mats;
        GetComponent<MeshFilter>().sharedMesh = meshes[currentIndex];
        PlayerPrefs.SetInt("Mat", currentIndex);
       
    }

    public void ViewShop() 
    {
        colorPanelObj.SetActive(true);
    }

    public void ExitShop() 
    {
        colorPanelObj.SetActive(false);
    }
}
