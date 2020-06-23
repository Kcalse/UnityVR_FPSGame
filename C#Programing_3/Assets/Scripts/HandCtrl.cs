using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCtrl : MonoBehaviour           // VR 컨트롤러의 조작을 위한 클래스
{
    public GameObject Bullet;                   // 총알 오브젝트를 사용하기 위한 선언
    public Transform FirePos;                   // 총알 발사위치 오브젝트를 사용하기 위한 선언
    public AudioClip ShotSound;                 // 사운드를 사용하기 위한 선언

    private SteamVR_TrackedObject controller;   // 스팀VR 에서 제공하는 센서 조작을 설정하기 위한 클래스 참조
    private SteamVR_Controller.Device device;   // 스팀VR 에서 제공하는 컨트롤러를 설정하기 위한 클래스 참조
    private AudioSource _audio;                 // 사운드 파일을 사용하기 위한 클래스 참조
    // Start is called before the first frame update
    void Start()                                // 처음 파일 실행시 한번만 실행되는 초기 설정을 위한 함수
    {
        controller = GetComponent<SteamVR_TrackedObject>(); // controller 변수에 센서로 익식되는 컨트롤러를 등록하는 코드
        _audio = GetComponent<AudioSource>();   // _audio 변수에 오디오 설정을 저장
    }
    // Update is called once per frame
    void Update()                               // 매 프레임마다 변화하는 상태를 표시, 화면의 실시간 상태변화를 표현하는 함수
    {
        device = SteamVR_Controller.Input((int)controller.index);   // 컨트롤러 변수 device 에 센서에 익식되는 컨트롤러를 등록하는 코드
        if(device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))  // 인식 된 컨트롤러에 지정 트리거가 입력됐을 때 밑의 코드 실행
        {
            _audio.PlayOneShot(ShotSound);      // 총을 격발할 때의 사운드 재생
            Instantiate(Bullet, FirePos.position, FirePos.rotation);    // Bullet 오브젝트를 FirePos 위치와 각도에 맞게 생성(오브젝트 생성 코드)
            device.TriggerHapticPulse(1200);    // 컨트롤러의 진동 세기를 지정하는 코드
        }
    }
}
