using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;


[System.Serializable]
public class CDInfo
{
    public string Name { get; set; }
    public string Singer { get; set; }
    public string Description { get; set; }
    public string ReleaseTime { get; set; }
    public string Company { get; set; }
    public List<Single> Singles { get; set; }
}
[System.Serializable]
public class Single
{
    public string Name { get; set; }
     [JsonProperty(propertyName: "cd_single_infos")]
    public List<CDSingleInfo> CDSingleInfos { get; set; }
}
[System.Serializable]
public class CDSingleInfo
{
    public string Description { get; set; }
    
    [JsonProperty(propertyName: "image_url")]
    public string ImageUrl { get; set; }
    [JsonProperty(propertyName: "theoretical_value")]
    public double TheoreticalValue { get; set; }
}
[System.Serializable]
public class TapeInfo
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ReleaseTime { get; set; }
    public string Company { get; set; }
    public List<Side> ASide { get; set; }
    public List<Side> BSide { get; set; }
}
[System.Serializable]
public class Side
{
    public string side_Name { get; set; }
    public string side_Length { get; set; }
    public List<tape_single_info> tape_single_infos { get; set; }
}
[System.Serializable]
public class tape_single_info
{
    public string Name { get; set; }
    public string start_time { get; set; }
    public string end_time { get; set; }
}
[System.Serializable]
public class BDInfo
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ReleaseTime { get; set; }
    public string Company { get; set; }
    public string Platform { get; set; }
    public TrophyInfo TrophyInfos { get; set; }
}
[System.Serializable]
public class TrophyInfo
{
    public string main_title_name { get; set; }
    public defined_trophies Defined_trophies { get; set; }
    public List<earned_trophie> earned_trophies { get; set; }
    public List<dlc_info> Dlc_infos { get; set; }
}
[System.Serializable]
public class defined_trophies
{
    public int Bronze_trophy { get; set; }
    public int Sliver_trophy { get; set; }
    public int Gold_trophy { get; set; }
    public int Platinum_trophy{ get; set; }
}
[System.Serializable]
public class earned_trophie
{
    public int Id { get; set; }
    public string rare_type { get; set; }
    public string earned_time { get; set; }
}
[System.Serializable]
public class dlc_info
{
    public string Title_name { get; set; }
    public string Description { get; set; }
    public string Release_time { get; set; }
    public defined_trophies Defined_trophies { get; set; }
    public List<earned_trophie> Earned_trophies { get; set; }
}
[System.Serializable]
public class MusicData
{

    public List<CDInfo> CDInfos { get; set; }
    public List<TapeInfo> TapeInfos { get; set; }
    public List<BDInfo> BDInfos { get; set; }

}

