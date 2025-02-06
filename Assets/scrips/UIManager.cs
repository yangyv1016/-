using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

public GameObject level0list;
public GameObject level0info;
public GameObject level1list;
public GameObject level1info;
public GameObject level2list;
public static UIManager instance;
void Awake(){
    if (instance == null)
            instance = this;
        else
            Destroy(instance);
}

public void clearlevel0list(){

for(int i=0;i<level0list.transform.childCount;i++)
        {
            Destroy(level0list.transform.GetChild(i).gameObject);
        }
}
public void clearlevel0info(){
for(int i=0;i<level0info.transform.childCount;i++)
        {
            Destroy(level0info.transform.GetChild(i).gameObject);
        }

}
public void clearlevel1list(){
for(int i=0;i<level1list.transform.childCount;i++)
        {
            Destroy(level1list.transform.GetChild(i).gameObject);
        }

}
public void clearlevel1info(){
for(int i=0;i<level1info.transform.childCount;i++)
        {
            Destroy(level1info.transform.GetChild(i).gameObject);
        }

}
public void clearlevel2list(){
for(int i=0;i<level2list.transform.childCount;i++)
        {
            Destroy(level2list.transform.GetChild(i).gameObject);
        }

}


}
