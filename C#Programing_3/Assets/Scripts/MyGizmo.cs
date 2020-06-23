using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 적 오브젝트 스폰을 위한 장소를 설정을 돕기위해 제작 중에는 표시 되지만 게임 실행시 눈에 안 보이게 하는 설정

public class MyGizmo : MonoBehaviour                
{
    public Color color = Color.green;       //  Color 라는 색 지정 자료형에 스폰 장소의 색을 명시
    public float radius = 0.02f;            // float 라는 자료형에 스폰 위치를 표시하기 도형의 크기 명시

    void OnDrawGizmos()                     // 스폰 장소 표시를 위한 함수
    {
        Gizmos.color = color;               // 위에서 지정한 color 변수를 이용해 색을 지정
        Gizmos.DrawSphere(transform.position, radius);  // 스폰 위치 표시 위한 도형의 모양과 크기 설정
    }
}
