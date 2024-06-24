using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;

public class DefaultClient : MonoBehaviour {
    [SerializeField] private static AsynchronousClient _client;
    [SerializeField] private Entity _currentPlayer;
    [SerializeField] private string _username;
    [SerializeField] private int _connectionTimeoutMs = 10000;
    [SerializeField] private string _serverIp = "127.0.0.1";
    [SerializeField] private int _serverPort = 11000;
    [SerializeField] private bool _logReceivedPackets = true;
    [SerializeField] private bool _logSentPackets = true;

    private bool _connecting = false;

    public string Username { get { return _username; } }
    public bool LogReceivedPackets { get { return _logReceivedPackets; } }
    public bool LogSentPackets { get { return _logSentPackets; } }
    public int ConnectionTimeoutMs { get { return _connectionTimeoutMs; } }

    private static DefaultClient _instance;
    public static DefaultClient Instance { get { return _instance; } }

    private void Awake() {
        if (_instance == null) {
            _instance = this;
        } else if (_instance != this) {
            Destroy(this);
        }
    }

    private void Start() {
        if(World.Instance != null && World.Instance.OfflineMode) {
            this.enabled = false;
        }
    }

    public async void Connect(string user) {
        if(_connecting) {
            return;
        }

        _connecting = true;
        _username = user; 
        _client = new AsynchronousClient(_serverIp, _serverPort);
        bool connected = await Task.Run(_client.Connect);
        if(connected) {  
            _connecting = false;

            LoginServerPacketHandler.Instance.SetClient(_client);
            LoginClientPacketHandler.Instance.SetClient(_client);     
            
            LoginClientPacketHandler.Instance.SendPing();
            LoginClientPacketHandler.Instance.SendAuth(user);                                   
        }
    }

    public void OnConnectionFailed() {
        _connecting = false;
    }

    public void OnConnectionAllowed() {
        Debug.Log("Connected");
        GameManager.Instance.OnConnectionAllowed();
    }

    public int GetPing() {
        return _client.Ping;
    }

    public void Disconnect() {
        if (_client != null) {
            _client.Disconnect();
        }
    }

    public void OnDisconnect() {
        Debug.Log("Disconnected");
        _client = null;
        GameManager.Instance.OnDisconnect();
    }

    void OnApplicationQuit() {
        if(_client != null) {
            _client.Disconnect();
        }   
    }
}
