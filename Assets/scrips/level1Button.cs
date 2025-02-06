using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static Enum;

public class level1Button : MonoBehaviour
{
        public CDInfo level1cd;
        public int unattained_trophy_number;
    public TapeInfo level1tape;
    public BDInfo level1bd;
    public infotype Infotype ;
    public GameObject textprefab;
    public GameObject level2buttonprefab;
    public List<CDSingleInfo> cdSingleInfos; 
    public string Tapelength;
 public static long ConvertToTimestamp(string dateTimeStr)
    {
        // 定义时间格式
        string format = "yyyy MM-dd HH:mm";
        
        // 解析字符串为 DateTime 对象
        DateTime dateTime = DateTime.ParseExact(dateTimeStr, format, CultureInfo.InvariantCulture);

        // 转换为 UTC 时间
        DateTime utcDateTime = dateTime.ToUniversalTime();

        // 计算时间戳（秒）
        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        TimeSpan timeSpan = utcDateTime - epoch;
        long timestamp = (long)timeSpan.TotalSeconds;

        return timestamp;
    }
private GameObject addlevel2list(string text)
    {
        GameObject newtext = Instantiate(level2buttonprefab);
        if(Infotype==infotype.CD){
             
        }
        if(Infotype == infotype.Tape){

        }
        if(Infotype == infotype.BD){
            
        }
        newtext.GetComponent<Transform>().name = text;
        newtext.transform.SetParent(UIManager.instance.level2list.transform);
        newtext.GetComponent<RectTransform>().localScale = Vector3.one;
        newtext.GetComponent<level2Button>().infoType=this.Infotype;
        return newtext;
    }

    private void addDescripion(string text1,string text2)
    {
        GameObject newtext = Instantiate(textprefab);
        
        newtext.GetComponent<Text>().text = (text1+text2);
        newtext.transform.SetParent(UIManager.instance.level1info.transform);
        newtext.GetComponent<RectTransform>().localScale = Vector3.one;
    }

    public void onclick_level1Button(){
        UIManager.instance.clearlevel1info();
        UIManager.instance.clearlevel2list();

        GameObject level1info=UIManager.instance.level1info;
        if (Infotype == infotype.CD)
        {
            SortCDSingleInfosByTheoreticalValue(cdSingleInfos);
            addDescripion(this.name,"");
            foreach(var cd2 in cdSingleInfos){
                GameObject cdbutton =addlevel2list(cd2.Description);
                
                cdbutton.GetComponent<level2Button>().url=cd2.ImageUrl;
            }

        }
        else if (Infotype == infotype.Tape)
        {
             if(this.transform.name=="SideA")
                level1tape.ASide[0].tape_single_infos=level1tape.ASide[0].tape_single_infos.OrderBy(t=>t.start_time).ToList();
                foreach(var singer in level1tape.ASide[0].tape_single_infos){
                    addlevel2list(singer.Name+"\n"+singer.start_time+"——"+singer.end_time);
                }
             if(this.transform.name=="SideB")
                level1tape.BSide[0].tape_single_infos=level1tape.BSide[0].tape_single_infos.OrderBy(t=>t.start_time).ToList();
                foreach(var singer in level1tape.BSide[0].tape_single_infos){
                    addlevel2list(singer.Name+"\n"+singer.start_time+"——"+singer.end_time);
                }
            addDescripion(this.name+"/",Tapelength);
        }
        else if (Infotype == infotype.BD)
        {
            level1bd.TrophyInfos.earned_trophies=level1bd.TrophyInfos.earned_trophies.OrderBy(t => t.earned_time).ToList();
            addDescripion("unattained_trophy_number:",unattained_trophy_number.ToString());
            foreach(var bd2 in level1bd.TrophyInfos.earned_trophies){
                GameObject bdbutton=addlevel2list(bd2.Id+"\n"+bd2.rare_type);
            }
        }
   }
   
public void SortCDSingleInfosByTheoreticalValue(List<CDSingleInfo> CDSingleInfos)
    {
        if (CDSingleInfos == null || CDSingleInfos.Count <= 1)
            return;

        // 使用冒泡排序
        int n = CDSingleInfos.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (CDSingleInfos[j].TheoreticalValue > CDSingleInfos[j + 1].TheoreticalValue)
                {
                    // 交换位置
                    CDSingleInfo temp = CDSingleInfos[j];
                    CDSingleInfos[j] = CDSingleInfos[j + 1];
                    CDSingleInfos[j + 1] = temp;
                }
            }
        }
    }

}

