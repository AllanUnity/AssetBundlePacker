
namespace GS
{
    public partial class Utility
    {
        /// <summary>泛型交换函数</summary>
        public static void Swap<T>(ref T p1, ref T p2)
        {
            T temp = p1;
            p1 = p2;
            p2 = temp;
        }
    }
}
