using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Enum;
public class level0Button : MonoBehaviour
{
    public CDInfo level0cd;
    public TapeInfo level0tape;
    public BDInfo level0bd;
    public infotype infoType;
    public GameObject level0info;
    public GameObject textprefab;

    public GameObject level1buttonprefab ;

    public void clearLevel0()
    {
        for (int i = 0; i < level0info.transform.childCount; i++)
        {
            Destroy(level0info.transform.GetChild(i).gameObject);
        }

    }
    public void level0Button_Click()
    {
        UIManager.instance.clearlevel1list();
        UIManager.instance.clearlevel0info();
        PropertyInfo[] properties;
        Type type = typeof(void);
        if (infoType == infotype.CD)
        {
            type = typeof(CDInfo);

        }
        else if (infoType == infotype.Tape)
        {
            type = typeof(TapeInfo);
        }
        else if (infoType == infotype.BD)
        {
            type = typeof(BDInfo);
        }
        //获取所有属性。
        properties = type.GetProperties();



        foreach (PropertyInfo prop in properties)
        {
            Console.WriteLine(prop.Name);
            // Console.WriteLine(prop.GetValue(t));
            try
            {

                if (infoType == infotype.CD)
                {
                    addDescripion(prop.Name, (string)prop.GetValue(level0cd));

                }
                else if (infoType == infotype.Tape)
                {
                    addDescripion(prop.Name, (string)prop.GetValue(level0tape));
                }
                else if (infoType == infotype.BD)
                {
                    addDescripion(prop.Name, (string)prop.GetValue(level0bd));
                }
            }
            catch (Exception e)
            {

            }

        }
        //添加level1list
        if (infoType == infotype.CD)
        {
           foreach(var singer in level0cd.Singles){
            GameObject single_info =addlevel1list(singer.Name);
            single_info.GetComponent<level1Button>().cdSingleInfos=singer.CDSingleInfos;
           }

        }
        else if (infoType == infotype.Tape)
        {
            GameObject SideA=addlevel1list("SideA");
            GameObject SideB=addlevel1list("SideB");
            SideA.GetComponent<level1Button>().Tapelength=level0tape.ASide[0].side_Length;
            SideA.GetComponent<level1Button>().level1tape=level0tape;
            SideB.GetComponent<level1Button>().level1tape=level0tape;
            
            SideB.GetComponent<level1Button>().Tapelength=level0tape.BSide[0].side_Length;

        }
        else if (infoType == infotype.BD)
        {
            GameObject BD;
            BD=addlevel1list(level0bd.TrophyInfos.main_title_name);
            defined_trophies defined =level0bd.TrophyInfos.Defined_trophies;
            int defined_trophie=defined.Gold_trophy+defined.Bronze_trophy+defined.Sliver_trophy+defined.Platinum_trophy;
            int earned_trophie=level0bd.TrophyInfos.earned_trophies.Count;
            BD.GetComponent<level1Button>().unattained_trophy_number=defined_trophie-earned_trophie;
            BD.GetComponent<level1Button>().level1bd=level0bd;
            foreach (var titlename in level0bd.TrophyInfos.Dlc_infos)
            {
             BD=addlevel1list(titlename.Title_name);
             BD.GetComponent<level1Button>().level1bd=level0bd;
            }
        }


    }

    private void addDescripion(string name, string value)
    {
        GameObject newtext = Instantiate(textprefab);
        newtext.GetComponent<Text>().text = (name + ":" + value);
        newtext.transform.SetParent(level0info.transform);
        newtext.GetComponent<RectTransform>().localScale = Vector3.one;
    }
    private GameObject addlevel1list(string text)
    {
        GameObject newtext = Instantiate(level1buttonprefab);
        if(infoType == infotype.Tape){

        }
        if(infoType == infotype.BD){
            
        }
        newtext.GetComponent<Transform>().name = text;
        newtext.transform.SetParent(UIManager.instance.level1list.transform);
        newtext.GetComponent<RectTransform>().localScale = Vector3.one;
        newtext.GetComponent<level1Button>().Infotype=this.infoType;
        return newtext;
    }
    // Start is called before the first frame update
    void Start()
    {
        level0info=UIManager.instance.level0info;

    }


    // Update is called once per frame
    void Update()
    {

    }

    private class datainfos
    {
    }
}
