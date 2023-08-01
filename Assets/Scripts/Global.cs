using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;

public struct SetInfo
{
    public int type;//0-와인, 1-맥주
    public bool is_auto_login;
    public bool is_coffee;
    public bool is_id_saved;
    public int app_type;//0-beer 1-wine
    public int self_cnt;
    public UserInfo userinfo;
    public DeviceInfo[] gateways;
    public DeviceInfo[] controllers;
    public List<TapInfo> tapInfoList;
}

public struct UserInfo
{
    public int id;
    public string userID;
    public string password;
    public int pub_id;
    public string pub_name;
    public bool is_open;
}

public struct DeviceInfo
{
    public string no;
    public string name;
    public string id;
    public string mac;
    public string ip;
}

public struct TapInfo
{
    public int serial_number;
    public int tagGWNo;
    public int tagGW_channel;
    public int boardNo;
    public int board_channel;

    public int max_quantity;
    public int flow_sensor;
    public int soldout;
    public int decarbonation;
    public int open_settingtime;

    public int appType;
    public int appNo;

    public int soldout_state;
    public int valve1_state;
    public int valve2_state;
}

public class Global
{
    public static bool is_pos_run = false;

    //setting information
    public static SetInfo setinfo = new SetInfo();
    public static string PrinterName = "";
    public static string filePath = "";

    public static Process posExe = null;
    public static Process udpConnecter = null;
    public static Process[] tagGWProcessList = null;
    public static Process[] boardProcessList = null;
    //api
    public static bool is_from_splash = false;
    public static string server_address = "127.0.0.1";
    public static string api_server_port = "3006";
    public static string api_url = "";
    static string api_prefix = "m-api/match/";
    //self_device셀프단말기용 api
    public static string login_api = api_prefix + "login";
    public static string server_local_api = api_prefix + "server-local";
    public static string local_server_api = api_prefix + "local-server";

    //socket server
    public static string socket_server = "";
}