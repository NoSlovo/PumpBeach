using Reflex;
using Reflex.Scripts;
using UnityEngine;

public class ScenInstailer : Installer
{
    [SerializeField] private SpawnEnemy _spawnEnemy;

    public override void InstallBindings(Container container)
    {
        container.BindInstanceAs(_spawnEnemy);
    }
}
