using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour  // 총알 조종을 위한 전체 공유 클래스
{
    private float BulletSpeed = 25.0f;  // 총알 속도를 지정하기위한 float 자료형 변수 선언

    void Start()                        // 첫 화면 시작 전 초기 설정을 위한 함수
    {
        Destroy(gameObject, 3.0f);      // 지정된 게임 오브젝트를 파괴(제거)
    }

    // Update is called once per frame
    void Update()                       // 매 프레임마다 실행되는 함수, 화면의 변화를 실시간으로 표현
    {
        transform.position += transform.forward * BulletSpeed * Time.deltaTime; // 총알 오브젝트의 이동 방향과 속도를 지정
    }
}
