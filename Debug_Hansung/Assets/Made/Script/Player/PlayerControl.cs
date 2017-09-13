using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float movementSpeed = 2.5f;
    public float mouseSensitivity = 2f;
    public float upDownRange = 90;
    public float jumpSpeed = 5;
    public float downSpeed = 5;

    private Vector3 speed;
    private float forwardSpeed;
    private float sideSpeed;

    private float rotLeftRight;
    private float rotUpDown;
    private float verticalRotation = 0f;

    private float verticalVelocity = 0f;

    //Vector3 playerYAngle;

    private CharacterController cc;

    //-------------------------------------------
    int layerMask;
    LineRenderer line;
    Ray ray = new Ray();
    RaycastHit hit;
    public Transform lineStart;
    float timer = 0f;
    
    //-------------------------------------------
    //각 아이템을 얻었는지 판단하는 부울 변수들 모음
    public bool getKnife;
    public bool getKey;
    public bool getCutter;
    public bool getBattery;
    //-------------------------------------------
    //라이팅 관련
    Light InnerLight;
    Light OuterLight;
    LEDControl LEDCtrl;
    //-------------------------------------------
    static string startPosition = "InitPosition";            //씬이 로드될 때 시작하는 위치를 String으로 저장

    static int msgCount;                   //획득한 쪽지 개수를 세기 위한 변수

    public void SetStartPosition(string pos)
    {
        startPosition = pos;
    }

    public int GetMsgCount()
    {
        return msgCount;
    }

    public void AddCount()                  //쪽지를 획득할 경우 msgCount를 증가시킴
    {
        msgCount++;
    }
    
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this);
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        InnerLight = GameObject.Find("InnerLED").GetComponent<Light>();
        OuterLight = GameObject.Find("OuterLED").GetComponent<Light>();
        LEDCtrl = GetComponent<LEDControl>();

        //씬에서 로드될 때의 위치와 바라보는 방향 설정
        //transform.position = GameObject.Find(startPosition).transform.position;
        //transform.Rotate(GameObject.Find(startPosition).transform.rotation.eulerAngles);
    }

    // Update is called once per frame
    void Update()
    {
        //playerYAngle = new Vector3(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
        FPMove();
        FPRotate();           //HMD 없이 돌려볼 때에는 주석을 해제하고 할것
        LEDOnOff();
        if (Input.GetKeyDown(KeyCode.R))
        {
            getBattery = true;
            InnerLight.intensity = GetComponent<LEDControl>().inner;
            OuterLight.intensity = GetComponent<LEDControl>().outer;
        }
    }

    //Player의 x축, z축 움직임을 담당
    void FPMove()
    {
        forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        speed = new Vector3(sideSpeed, verticalVelocity , forwardSpeed);
        speed = Quaternion.Euler(transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z) /*transform.rotation */ * speed;

        if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            cc.Move(speed * Time.deltaTime);
    }

    //Player의 회전을 담당
    void FPRotate()
    {
        //좌우 회전
        rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, rotLeftRight, 0f);

        //상하 회전
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
    
    void LEDOnOff()             //손전등
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!getBattery && !InnerLight.enabled && !OuterLight.enabled)      //배터리를 얻지 않은 경우, 켤 때.
            {
                LEDCtrl.LowBatt();
            }
            else                            //그 외에는 그냥 껐다 켰다
            {
                InnerLight.enabled = !InnerLight.enabled;
                OuterLight.enabled = !OuterLight.enabled;
            }
        }
    }

    void Pickup()
    {

    }




}