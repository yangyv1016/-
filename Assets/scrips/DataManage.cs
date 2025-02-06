using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Unity.VisualScripting;
//using Sirenix.OdinInspector;
using System.IO;
using System;
using Sirenix.OdinInspector;
using UnityEngine.UIElements;

public class DataManage :  SerializedMonoBehaviour
{
    private string jsonData = "";


    public MusicData data;
    public static DataManage instance;
    private void loadData()
    {

        string path = "Assets/scrips/Collections.json";
        jsonData = File.ReadAllText(path);



        data = JsonConvert.DeserializeObject<MusicData>(jsonData);

        //磁带长度计算
        int Length=0;
        foreach(var tape in data.TapeInfos){
            foreach(var tapesingle in tape.ASide[0].tape_single_infos){
                Length+=Lengthcal(tapesingle.start_time,tapesingle.end_time);
            }
            tape.ASide[0].side_Length=time_inttostring(Length);
            Length=0;
            foreach(var tapesingle in tape.BSide[0].tape_single_infos){
                Length+=Lengthcal(tapesingle.start_time,tapesingle.end_time);
            }
            tape.BSide[0].side_Length=time_inttostring(Length);
            
        }
        
      

    }
    string time_inttostring(int time){
        if(time%60<10){
            return (time/60).ToString()+":0"+(time%60).ToString();
        }
        return (time/60).ToString()+":"+(time%60).ToString();
    }
    int Lengthcal(string start,string end){
        string []time1=start.Split(':');
        string[]time2=end.Split(':');
        int m=int.Parse(time2[0])-int.Parse(time1[0]);
        int s=int.Parse(time2[1])-int.Parse(time1[1]);
        
        return  m*60+s;
    }
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
        //data=new Data();
        loadData();

    }

};





