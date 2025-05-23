// See https://aka.ms/new-console-template for more information
using System.Drawing;
using System.Drawing.Text;

Console.WriteLine("Hello, World!");

var reader = File.ReadAllBytes("C:\\Users\\Lea\\Desktop\\AV_Logo.data");

Console.WriteLine(reader.Length);

const int PIXEL_OFFSET = 3;
const bool HasAlpha = false;


for (int i=0; i*PIXEL_OFFSET<reader.Length; ++i)
{
    byte red = (byte)(reader[i*PIXEL_OFFSET] >> 3);
    byte green = (byte)(reader[i*PIXEL_OFFSET+1] >> 2);
    byte blue = (byte)(reader[i*PIXEL_OFFSET+2] >> 3);

    if (HasAlpha)
    {
        byte alpha = reader[i * PIXEL_OFFSET + 3];
        if (alpha == 0)
        {
            red = green = blue = 0;
        }
        else if (alpha != 255)
        {
            //throw new ArgumentOutOfRangeException();
        }
    }

    ushort color565 = (ushort)((ushort)(red << 11) | (ushort)(green << 6) | (ushort)(blue));
    Console.Write(string.Format("0x{0:x4}, ", color565));
    if (i%20 == 0)
    {
        Console.WriteLine();
    }
}
