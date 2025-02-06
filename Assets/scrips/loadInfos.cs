using System.Collections;
using System.Collections.Generic;
using System.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UIElements;
using static Enum;

public class loadCDInfos : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject level0list;
    public List<CDInfo> cdInfos;
    public List<TapeInfo> tapeInfos;
    public List<BDInfo> bdInfos;
    public infotype infoType;
    // Start is called before the first frame update
    void Start()
    {
        cdInfos=DataManage.instance.data.CDInfos;
        tapeInfos=DataManage.instance.data.TapeInfos;
        bdInfos=DataManage.instance.data.BDInfos;
    }
    public void clearLevel0(){
        UIManager.instance.clearlevel1list();
        UIManager.instance.clearlevel1info();
        UIManager.instance.clearlevel2list();
        UIManager.instance.clearlevel0list();

    }
    public void refeshLevel0_CD(){
        clearLevel0();
        
        
      
        foreach(var cd in cdInfos){
        GameObject button=Instantiate(buttonPrefab);
        button.name=cd.Name;
        
        button.transform.parent=level0list.transform;
        button.GetComponent<RectTransform>().localScale=Vector3.one;
        button.GetComponent<level0Button>().level0cd=cd;
        button.GetComponent<level0Button>().infoType=infotype.CD;
        }


    }
    public void refeshLevel0_Tape(){
        clearLevel0();
        foreach(var tape in tapeInfos){
        GameObject button=Instantiate(buttonPrefab);
        button.name=tape.Name;
        button.transform.parent=level0list.transform;
        button.GetComponent<RectTransform>().localScale=Vector3.one;
        button.GetComponent<level0Button>().level0tape=tape;
                button.GetComponent<level0Button>().infoType=infotype.Tape;
        }


    }
    public void refeshLevel0_BD(){
        clearLevel0();
        foreach(var BD in bdInfos){
        GameObject button=Instantiate(buttonPrefab);
        button.name=BD.Name;
        button.transform.parent=level0list.transform;
        button.GetComponent<RectTransform>().localScale=Vector3.one;
        button.GetComponent<level0Button>().level0bd=BD;
        button.GetComponent<level0Button>().infoType=infotype.BD;
        }


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
