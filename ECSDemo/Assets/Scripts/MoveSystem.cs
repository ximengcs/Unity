using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class MoveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        // 抓取tranlation组件
        Entities.ForEach((ref Translation translation, ref MoveComponent moveComponent) =>
        {
            // 修改translation组件值
            translation.Value.y += moveComponent.moveSpeed * Time.DeltaTime;

            if(translation.Value.y > 10)
            {
                moveComponent.moveSpeed = -Math.Abs(moveComponent.moveSpeed);
            }

            if(translation.Value.y < -10)
            {
                moveComponent.moveSpeed = Math.Abs(moveComponent.moveSpeed);
            }
        });
    }
}
