using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;

/// <summary>
/// 
/// </summary>
public class Testing : MonoBehaviour
{
    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;
    private void Start()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        // 如果要创建第二个实体，可以简单的传递第二个参数
        // 但是更好的方法是创建实体原型。
        // 原型本质上是一组特定的组件
        EntityArchetype entityArcheType = entityManager.CreateArchetype(
            typeof(LevelComponent), // 自定义组件(仅数据)
            typeof(Translation),  // 位置组件(仅数据)
            typeof(RenderMesh),  // 渲染组件(仅数据)
            typeof(LocalToWorld), // 坐标计算(仅数据)
            typeof(RenderBounds), // 之前的旧版本这个component会自动添加进来，新版本不会自动添加需要手动添加。
            typeof(MoveComponent)  // 自定义移动组件
        );

        NativeArray<Entity> nativeArray = new NativeArray<Entity>(100000, Allocator.Temp);
        entityManager.CreateEntity(entityArcheType, nativeArray);

        for (int i = 0; i < nativeArray.Length; i++)
        {
            Entity entity = nativeArray[i];
            // 初始level为10
            entityManager.SetComponentData<LevelComponent>(entity,
                new LevelComponent
                {
                    level = Random.Range(10, 100)
                }
            );

            // 初始化渲染组件
            entityManager.SetSharedComponentData(entity,
                new RenderMesh
                {
                    mesh = mesh,
                    material = material
                }
            );

            // 初始化速度组件
            entityManager.SetComponentData(entity,
                new MoveComponent
                {
                    moveSpeed = Random.Range(1f, 5f)
                }
            );

            entityManager.SetComponentData(entity,
                new Translation
                {
                    Value = new Unity.Mathematics.float3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), 20)
                }
            );
        }

        nativeArray.Dispose();

    }

}
