using SimpleJSON;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainManager : MonoBehaviour
{
    public GameObject busObj;
    public GameObject busNoticeObj;
    public InputField busIDTxt;
    //public InputField ipTxt;
    public GameObject err_popup;
    public Text err_str;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("bus_id") != null && PlayerPrefs.GetString("bus_id") != "")
        {
            busObj.SetActive(false);
            busNoticeObj.SetActive(false);
        }
        else
        {
            busObj.SetActive(true);
            busNoticeObj.SetActive(true);
        }
        busIDTxt.text = PlayerPrefs.GetString("bus_id");
        //ipTxt.text = PlayerPrefs.GetString("ip");
    }

    // Update is called once per frame
    void Update()
    {

    }
    float time = 0f;
    void FixedUpdate()
    {
        if (!Input.anyKey)
        {
            time += Time.deltaTime;
        }
        else
        {
            if (time != 0f)
            {
                GameObject.Find("touch").GetComponent<AudioSource>().Play();
                time = 0f;
            }
        }
    }

    public void onSeverToLocal()
    {
        if (busIDTxt.text == "")
        {
            err_popup.SetActive(true);
            err_str.text = "사업자번호를 정확히 입력하세요.";
            return;
        }
        //if (ipTxt.text == "")
        //{
        //    err_str.text = "ip를 정확히 입력하세요.";
        //    err_popup.SetActive(true);
        //    return;
        //}
        //Global.server_address = ipTxt.text;
        //PlayerPrefs.SetString("ip", Global.server_address);
        Global.api_url = "http://" + Global.server_address + ":" + Global.api_server_port + "/";
        Debug.Log(Global.api_url + Global.server_local_api);
        WWWForm form = new WWWForm();
        form.AddField("bus_id", busIDTxt.text);
        WWW www = new WWW(Global.api_url + Global.server_local_api, form);
        StartCoroutine(ProcessServerToLocal(www));
    }
    
    IEnumerator ProcessServerToLocal(WWW www)
    {
        yield return www;
        if(www.error == null)
        {
            JSONNode jsonNode = SimpleJSON.JSON.Parse(www.text);
            if (jsonNode["suc"].AsInt == 1)
            {
                PlayerPrefs.SetString("bus_id", busIDTxt.text);
                //PlayerPrefs.SetString("local_ip", ipTxt.text);
                err_popup.SetActive(true);
                err_str.text = "디비매칭에 성공하였습니다.";
            }
            else
            {
                err_popup.SetActive(true);
                err_str.text = "디비매칭에 실패하였습니다.";
            }
        }
        else
        {
            err_str.text = "서버와의 접속이 원활하지 않습니다.";
            err_popup.SetActive(true);
        }
    }

    public void onLocalToServer()
    {
        if (busIDTxt.text == "")
        {
            err_popup.SetActive(true);
            err_str.text = "사업자번호를 정확히 입력하세요.";
            return;
        }
        //if (ipTxt.text == "")
        //{
        //    err_str.text = "ip를 정확히 입력하세요.";
        //    err_popup.SetActive(true);
        //    return;
        //}
        //Global.server_address = ipTxt.text;
        //PlayerPrefs.SetString("ip", Global.server_address);
        Global.api_url = "http://" + Global.server_address + ":" + Global.api_server_port + "/";
        WWWForm form = new WWWForm();
        form.AddField("bus_id", busIDTxt.text);
        WWW www = new WWW(Global.api_url + Global.local_server_api, form);
        StartCoroutine(ProcessLocalToServer(www));
    }

    IEnumerator ProcessLocalToServer(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            JSONNode jsonNode = SimpleJSON.JSON.Parse(www.text);
            if (jsonNode["suc"].AsInt == 1)
            {
                PlayerPrefs.SetString("bus_id", busIDTxt.text);
                //PlayerPrefs.SetString("local_ip", ipTxt.text);
                err_popup.SetActive(true);
                err_str.text = "디비매칭에 성공하였습니다.";
            }
            else
            {
                err_popup.SetActive(true);
                err_str.text = "디비매칭에 실패하였습니다.";
            }
        }
        else
        {
            err_str.text = "서버와의 접속이 원활하지 않습니다.";
            err_popup.SetActive(true);
        }
    }

    public void onErrPopup()
    {
        err_popup.SetActive(false);
    }
}