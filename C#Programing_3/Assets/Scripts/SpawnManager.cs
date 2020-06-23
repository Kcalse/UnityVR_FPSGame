using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour       // 적 스폰 지역 설정을 위한 클래스 코드
{
    public Transform[] SpawnPoint = new Transform[7];   // 여러 오브젝트의 상태를 저장하기 위한 자료형, 여러개의 오브젝트를 배열에 저장
    // Transform 자료형 : 게임오브젝트의 위치, 회전 그리고 스케일(scale)을 나타냅니다.

    public GameObject Enemy;                    // 적 오브젝트를 지정하기 위한 선언
    private float SpawnTime;                    // 적 재생성 시간을 지정하는 선언
    // Start is called before the first frame update
    void Start()                                // 처음 파일 실행시 한번만 실행되는 초기 설정을 위한 함수
    {
        SpawnTime = 2.0f;                       // 적 오브잭트 재생성 시간 지정
        StartCoroutine(Spawn());                // Spawn 이란 함수를 반복 시행한다는 코드
    }
    IEnumerator Spawn()                         // 적 오브젝트 생성을 위한 Spawn 이란 이름의 함수(코루틴 반복을 위한 함수)
    {
        while(true)
        {
            int point = Random.Range(0,7);      // 적 생성 위치를 SpawnPoint 중 랜덤으로 지정
            Instantiate(Enemy, SpawnPoint[point].position, SpawnPoint[point].rotation); // 적 오브젝트를 Spownpoint 위치와 각도에 맞춰서 생성
            yield return new WaitForSeconds(SpawnTime); // 매 반복마다 재생성 시간을 지정하기 위한 코드
            //  yield return : 코루틴 반복문에서 object 타입의 값을 전달, 수정 하는 역할을 한다.

            SpawnTime -= 0.01f;                 // 재생성 시간을 수정하는 코드
        }
        yield return null;                      // 코루틴 반복의 끝을 나타내기 위한 것 (아마도 딱히 필요 없을지도...)
    }
}
