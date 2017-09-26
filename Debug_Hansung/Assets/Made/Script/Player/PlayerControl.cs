using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {

    public static PlayerControl instance = null;

    public bool blackOut;

    public float gameTime;                 //전체 게임 시간 측정
    public float fadeTime;                 //MessageUI 씬으로 이동시 FadeOut을 위함
    public float endingTime;               //마지막 Ending까지 시간을 측정

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
    //int layerMask;
    //LineRenderer line;
    //Ray ray = new Ray();
    //RaycastHit hit;
    //public Transform lineStart;
    //float timer = 0f;
    
    //-------------------------------------------
    //각 아이템을 얻었는지 판단하는 부울 변수들 모음
    public bool getKnife;
    public bool getKey;
    public bool getCutter;
    public bool getBattery;
	public bool getNipper;
    //-------------------------------------------
    //라이팅 관련
    Light InnerLight;
    Light OuterLight;
    LEDControl LEDCtrl;
    //-------------------------------------------
    static string startPosition = "InitPosition";            //씬이 로드될 때 시작하는 위치를 String으로 저장

    static int msgCount;                   //획득한 쪽지 개수를 세기 위한 변수

    public bool isPaused;                         //게임을 일시정지했는가(쪽지함을 열었는가)
    public bool messageUIOpened;
    public string sceneName;                //쪽지함 Scene을 열 때, 쪽지함 Scene에서 다시 이동할 씬을 저장하기 위함. 쪽지함 씬을 제외한 모든 씬을 이동할 때, 트리거에서 씬 이름을 받아와서 저장. 또는 각 SceneManager 스크립트의 Start에서 저장
    public Transform sceneTransform;           //쪽지함 Scene을 열 때, 쪽지함 Scene에서 다시 이동한 후 원래 있던 위치와 Rotation을 저장하기 위함

    public bool ending;
    public bool isGameBegin;

    public GameObject rightArm;
    public GameObject leftArm;

    public bool isMessageScene;

    GameObject MsgUIOut;

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
        Debug.Log(msgCount);
    }
    
    // Use this for initialization
    void Awake()
    {
        MsgUIOut = GameObject.Find("MsgUIOut");

        isMessageScene = false;
        getBattery = false;

        messageUIOpened = false;
        isPaused = false;

        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);


        DontDestroyOnLoad(gameObject);
        cc = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;

        InnerLight = GameObject.Find("InnerLED").GetComponent<Light>();
        OuterLight = GameObject.Find("OuterLED").GetComponent<Light>();
        LEDCtrl = GetComponent<LEDControl>();

        //씬에서 로드될 때의 위치와 바라보는 방향 설정
        //transform.position = GameObject.Find(startPosition).transform.position;
        //transform.Rotate(GameObject.Find(startPosition).transform.rotation.eulerAngles);

        rightArm = GameObject.Find("RightArm");
        leftArm = GameObject.Find("LeftArm");
    }
    
    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        //playerYAngle = new Vector3(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
        if(!isPaused)
            FPMove();
        FPRotate();           //HMD 없이 돌려볼 때에는 주석을 해제하고 할것
        if (isGameBegin)
        {
            LEDOnOff();
            if (Input.GetKeyDown(KeyCode.Escape) && !messageUIOpened)
            {
                MsgUIOut.transform.position = transform.position;
                MsgUIOut.transform.rotation = transform.rotation;
                Debug.Log(MsgUIOut.transform.position);
                fadeTime = gameTime;
                Camera.main.GetComponent<OVRScreenFade>().StartFadeOut();
                isPaused = !isPaused;                           //이동을 막기 위함
            }
        }
		//if (Input.GetKeyDown(KeyCode.R)&&getBattery) //배터리 획득후 R누르면 충전 
  //      {
  //          InnerLight.intensity = GetComponent<LEDControl>().inner;
  //          OuterLight.intensity = GetComponent<LEDControl>().outer;
  //      }

        if (gameTime - fadeTime >= 1.25f && fadeTime != 0)
        {
            fadeTime = 0;
            SceneManager.LoadScene("MessageUI");
        }

        if (ending)
            Ending();

        if (gameTime - endingTime == 2f && endingTime != 0)
            Camera.main.GetComponent<OVRScreenFade>().StartFadeOut();
        
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
    
    //RightArm.x = 1.4까지, LeftArm.x = -0.65까지
    void Ending()
    {
        iTween.RotateUpdate(rightArm, GameObject.Find("RightArmDestination").transform.rotation.eulerAngles, 2f);
        iTween.RotateUpdate(leftArm, GameObject.Find("LeftArmDestination").transform.rotation.eulerAngles, 2f);
    }

}