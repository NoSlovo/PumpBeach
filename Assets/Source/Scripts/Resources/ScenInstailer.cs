using System.Collections.Generic;
using Reflex;
using Reflex.Scripts;
using UnityEngine;

public class ScenInstailer : Installer
{
    [SerializeField] private List<Bonfire> _bonfires;

    public override void InstallBindings(Container container)
    {
        container.BindInstanceAs(_bonfires);
    }
}
