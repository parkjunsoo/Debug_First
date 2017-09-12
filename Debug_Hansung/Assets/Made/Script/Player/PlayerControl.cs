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

    Vector3 playerYAngle;

    private CharacterController cc;

    static int msgCount;                   //획득한 쪽지 개수를 세기 위한 변수

    //-------------------------------------------
    //각 아이템을 얻었는지 판단하는 부울 변수들 모음
    public bool getKnife;
    public bool getKey;
    public bool getCutter;
    static bool isInit;             //게임이 시작되고 씬 전환이 한번도 되지 않았는지를 판단. 처음에는 false로 하고 화장실을 들어가는 순간 true로 할 예정
    //-------------------------------------------

    static string startPosition = "InitPosition";            //씬이 로드될 때 시작하는 위치를 String으로 저장

    public void SetStartPosition(string pos)
    {
        startPosition = pos;
    }

    public bool GetisInit(){
        return isInit;
    }

    public void Init()
    {
        isInit = true;              //화장실에 들어가고 난 후 true. true인 경우 처음 게임 시작 위치 뒤쪽에 있는 collider를 제거
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
        transform.position = GameObject.Find(startPosition).transform.position;
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        playerYAngle = new Vector3(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
        FPMove();
        FPRotate();           //HMD 없이 돌려볼 때에는 주석을 해제하고 할것
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
    
}