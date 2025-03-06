using System;

namespace CADBooster.SolidDna
{
    public class EnableMethodArgs : EventArgs
    {
        public int Result { get; set; } = -1;
        public string Name { get; }

        public EnableMethodArgs(string name)
        {
            Name = name;
        }
    }
}
