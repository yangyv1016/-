using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Microsoft.Unity.VisualStudio.Editor;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static Enum;

public class level2Button : MonoBehaviour
{
    
    public string url="";
    public infotype infoType;
    public void on_level2_click(){
StartCoroutine(Download(url));
    }
    
    public IEnumerator Download(string url){
        Uri uri = new Uri(url);
    UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(uri);
        yield return webRequest.SendWebRequest();
            // 发送请求
            

            // 检查是否出错
            if (webRequest.result == UnityWebRequest.Result.ConnectionError || 
                webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error downloading image: " + webRequest.error);
            }
            else
            {
                // 获取下载的纹理
                Texture2D texture = DownloadHandlerTexture.GetContent(webRequest);

                // 将纹理转换为 Sprite
                Sprite sprite = Sprite.Create(
                    texture,
                    new Rect(0, 0, texture.width, texture.height),
                    new Vector2(0.5f, 0.5f) // 设置锚点为中心
                );

                // 加载 Sprite 到 Button 的 Image 组件

                    GetComponent<UnityEngine.UI.Image>().sprite = sprite;

                    // 自适应图片大小
                    AdjustImageSize(texture.width, texture.height);
                
               
}
    }
    private void AdjustImageSize(int imageWidth, int imageHeight)
    {


        // 获取 Image 组件的 RectTransform
        RectTransform imageRect = GetComponent<RectTransform>();

        // 计算图片的宽高比
        float aspectRatio = (float)imageWidth / imageHeight;

        // 获取父容器的尺寸
        RectTransform parentRect = imageRect.parent as RectTransform;
        float parentWidth = parentRect.rect.width;
        float parentHeight = parentRect.rect.height;

        // 根据宽高比调整图片大小
        if (aspectRatio > 1) // 图片宽度大于高度
        {
            imageRect.sizeDelta = new Vector2(parentWidth, parentWidth / aspectRatio);
        }
        else // 图片高度大于宽度
        {
            imageRect.sizeDelta = new Vector2(parentHeight * aspectRatio, parentHeight);
        }
    }

    
    }