using System;

namespace Extensions
{
    public static class PrimitiveExtensions
    {
        public static int ToInt(this bool flag)
        {
            return Convert.ToInt32(flag);
        }
    }
}
