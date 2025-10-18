using UnityEngine;

public interface IFireworksPool
{
    FireworkView GetFirework(Color color);
    void ReturnFirework(FireworkView firework);
}
