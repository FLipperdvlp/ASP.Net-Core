namespace Minecraft_server_API.Classes;

public class Block
{
    public int X { get; }
    public int Y { get; }
    public int Z { get; }

    public Block(int x, int y, int z) => (X, Y, Z) = (x, y, z);
}