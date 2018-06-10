using System.Collections;
using UnityEngine;
using UnityEngine.Networking; 
using UnityEngine.UI;
using System.Xml;

public class SelectContentType : MonoBehaviour {

	private int contentsNum=0;
	private double bandwidth = 0;
    private int videoBW = 0, imageBW = 0;
    private string videoNM = "", imageNM = "";

    private string TrackableName = "";

    private string url = "http://192.168.35.123:3000/";

    IEnumerator loadContents(string trackable)
    {
        TrackableName = trackable;
        
        yield return StartCoroutine (getBandwidth ());
		contentsNum = select ();

		Debug.Log ("select content: " + contentsNum);

		switch (contentsNum) {
		case 0:
			break;
		case 1:
			GameObject.Find (trackable).GetComponent<LoadImage> ().getImageLoad (this.url + imageNM);
			Debug.Log ("select Image");
			break;
		case 2:
			GameObject.Find (trackable).GetComponent<StreamingVideo> ().playVideoLoad (this.url + videoNM);
			Debug.Log ("select video");
			break;
		default:
			break;
		}
	}

	// Use this for initialization
	IEnumerator getBandwidth () {
        string myUri =this.url+TrackableName+".txt";
        UnityWebRequest www = new UnityWebRequest(myUri);
		www.downloadHandler = new DownloadHandlerBuffer();

		System.DateTime start = System.DateTime.Now;
		Debug.Log (start);

		yield return www.SendWebRequest();

		if (www.isNetworkError || www.isHttpError) {
			Debug.Log (www.error);
		} else
        {
			System.DateTime curr = System.DateTime.Now;
			System.TimeSpan dateDiff = curr - start;

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
            Debug.Log(www.downloadHandler.text);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(www.downloadHandler.text);

            // 하나씩 가져오기
            XmlNodeList mpd = xmlDoc.GetElementsByTagName("Representation");
            foreach (XmlNode ele in mpd)
            {
                if (ele.Attributes["mimeType"].Value.Contains("video"))
                {
                    this.videoNM = ele.FirstChild.FirstChild.Value;
                    Debug.Log("v파일이름v:" + this.videoNM);
                    this.videoBW = XmlConvert.ToInt32(ele.Attributes["bandwidth"].Value);
                    
                }
                else if (ele.Attributes["mimeType"].Value.Contains("image"))
                {
                    this.imageNM = ele.FirstChild.FirstChild.Value;
                    Debug.Log("v파일이름v:" + this.imageNM);
                    this.imageBW = XmlConvert.ToInt32(ele.Attributes["bandwidth"].Value);
                    
                }
            }
        
            //float curr = (Time.deltaTime*1000)-start;
            Debug.Log (dateDiff.TotalMilliseconds);
			Debug.Log (www.downloadedBytes);

			bandwidth = www.downloadedBytes*8 / (dateDiff.TotalMilliseconds / 1000);

			//GameObject.Find ("BW").GetComponent<Text>().text = "bandwidth:"+(int)bandwidth+"bps"+"\nlatency:"+dateDiff.TotalMilliseconds+"ms";
			Debug.Log ("bandwidth: " + bandwidth);
		}
			
	}

    public int select(){

		Debug.Log ("이미지 기준: "+imageBW);
        Debug.Log("동영상 기준: " + videoBW);
        if (bandwidth < imageBW) {
			return 0;
		} else if (imageBW <= bandwidth && bandwidth < videoBW) {
			return 1;
		} else {
			return 2;
		}

	}
		
}
