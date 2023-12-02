using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = "Floating Int", menuName = "ejected/Floating Int", order = 0)]
public class FloatingInt : ScriptableObject {
    [SerializeField] int InitialValue = 0;
    [SerializeField] int MaxValue = 0;
    [SerializeField] int MinValue = 0;
    int currentValue;


    public void Awake()        {resetValue();}
    void clamp()               {currentValue = math.clamp(currentValue,MinValue,MaxValue);}
    public void resetValue()   {currentValue = InitialValue;}
    public void add(int value) {currentValue += value; clamp();}
    public void set(int value) {currentValue = value;  clamp();}
    public int get() {return currentValue;}
}